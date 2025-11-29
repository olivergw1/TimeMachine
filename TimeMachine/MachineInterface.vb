Public Class MachineInterface
    Private currentTime As DateTime
    Private previousTime As DateTime
    Private speedControl As TrackBar
    Private originalBackground As Image = Nothing
    Private dayLightOriginalColor As Color = Color.Empty

    ' YearLight support
    Private yearLightOriginalColor As Color = Color.Empty
    Private yearLightControl As Control = Nothing

    ' MonthLight support
    Private monthLightOriginalColor As Color = Color.Empty
    Private monthLightControl As Control = Nothing

    ' How many months at year-end should YearLight be active (1 = December only, 2 = Nov+Dec, etc.)
    Private yearLightMonthsThreshold As Integer = 2

    Private Sub MachineInterface_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Build initial time from Form1 fields (fallback to Now where parse fails)
        Dim h As Integer, m As Integer, s As Integer
        Dim d As Integer = 1, mo As Integer = 1, y As Integer = DateTime.Now.Year

        Integer.TryParse(Form1.Hour.Text, h)
        Integer.TryParse(Form1.Minute.Text, m)
        Integer.TryParse(Form1.Second.Text, s)
        Integer.TryParse(Form1.Day.Text, d)
        Integer.TryParse(Form1.Month.Text, mo)
        Integer.TryParse(Form1.Year.Text, y)

        Try
            currentTime = New DateTime(y, mo, d, h, m, s)
        Catch
            currentTime = DateTime.Now
        End Try

        ' initialize previousTime to currentTime so first comparison is valid
        previousTime = currentTime

        ' Find the TrackBar named "TimeControl" (works if nested)
        Dim found() As Control = Me.Controls.Find("TimeControl", True)
        If found.Length > 0 AndAlso TypeOf found(0) Is TrackBar Then
            speedControl = CType(found(0), TrackBar)
            ' Use an exponential scale for huge forward/reverse speeds.
            If speedControl.Minimum > -12 Then speedControl.Minimum = -12
            If speedControl.Maximum < 12 Then speedControl.Maximum = 12
            If speedControl.Value = 0 Then speedControl.Value = 1 ' default to 1x if not set

            AddHandler speedControl.Scroll, AddressOf SpeedControl_Changed
            AddHandler speedControl.ValueChanged, AddressOf SpeedControl_Changed
        End If

        ' Ensure PictureBox scales the image to the control bounds and does not AutoSize
        If PictureBox1 IsNot Nothing Then
            ' Keep reference to original image so we can hide/show it without hiding the control
            originalBackground = PictureBox1.Image

            PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
            ' If designer set AutoSize, enforce the intended size so it doesn't expand the control
            If PictureBox1.AutoSize Then
                PictureBox1.AutoSize = False
                PictureBox1.Size = New Size(1000, 561)
            End If
        End If

        ' remember the DayLight original color so we can restore it later
        If DayLight IsNot Nothing Then
            dayLightOriginalColor = DayLight.BackColor
        End If

        ' Try to find YearLight control (safe even if it's not present in Designer)
        Dim yf() As Control = Me.Controls.Find("YearLight", True)
        If yf.Length > 0 Then
            yearLightControl = yf(0)
            yearLightOriginalColor = yearLightControl.BackColor
        End If

        ' Try to find MonthLight control (safe even if it's not present in Designer)
        Dim mf() As Control = Me.Controls.Find("MonthLight", True)
        If mf.Length > 0 Then
            monthLightControl = mf(0)
            monthLightOriginalColor = monthLightControl.BackColor
        End If

        ' Make labels draw transparently over the PictureBox by reparenting them
        Dim overlayLabels() As Label = {DLabel, MoLabel, YLabel}
        If PictureBox1 IsNot Nothing Then
            For Each lbl As Label In overlayLabels
                If lbl IsNot Nothing Then
                    ' Compute location relative to the PictureBox before changing parent
                    Dim relX As Integer = lbl.Left - PictureBox1.Left
                    Dim relY As Integer = lbl.Top - PictureBox1.Top
                    lbl.Parent = PictureBox1
                    lbl.Location = New Point(relX, relY)
                    lbl.BackColor = Color.Transparent
                End If
            Next
        End If

        ' Restore clickable invisible hit area for clickspot (preserve designer size)
        If clickspot IsNot Nothing AndAlso PictureBox1 IsNot Nothing Then
            ' Preserve the designer size before clearing text (AutoSize true would collapse when text removed)
            Dim hitSize As Size = clickspot.Size

            ' Convert designer position to PictureBox client coordinates (handles DPI/autoscale)
            Dim clickScreenPos As Point = clickspot.PointToScreen(Point.Empty)
            Dim clickPbPos As Point = PictureBox1.PointToClient(clickScreenPos)

            ' Ensure the label keeps a fixed hit area even with no text
            clickspot.AutoSize = False
            clickspot.Size = hitSize
            clickspot.Text = String.Empty
            clickspot.Parent = PictureBox1
            clickspot.Location = clickPbPos
            clickspot.BackColor = Color.Transparent
            clickspot.Cursor = Cursors.Hand
            clickspot.Enabled = True
            clickspot.Visible = True
            clickspot.BringToFront()

            ' Attach click handler safely (avoid duplicate handlers)
            RemoveHandler clickspot.Click, AddressOf clickspot_Click
            AddHandler clickspot.Click, AddressOf clickspot_Click
        End If

        ' Fast, fixed timer tick so we can apply big time deltas per real second smoothly.
        Timer1.Interval = 50 ' 20 ticks/sec; reduce to 10 ms for smoother updates (more CPU)
        Timer1.Start()
        UpdateLabelsFromCurrentTime()
        ' ensure initial DayLight / YearLight / MonthLight state is correct
        UpdateDayLightState()
        UpdateYearLightState()
        UpdateMonthLightState()
    End Sub

    Private Sub SpeedControl_Changed(sender As Object, e As EventArgs)
        Dim statusText As String = "Status: Travelling @" & If(speedControl IsNot Nothing, speedControl.Value.ToString(), "N/A") & "x real-time"

        ' Try to find a StatusStrip named "StatusStrip1"
        Dim found() As Control = Me.Controls.Find("StatusStrip1", True)
        If found.Length > 0 AndAlso TypeOf found(0) Is StatusStrip Then
            Dim ss As StatusStrip = CType(found(0), StatusStrip)

            ' Try to get a named ToolStripItem first (common pattern)
            Dim tsi As ToolStripItem = Nothing
            Try
                tsi = ss.Items("ToolStripStatusLabel1") ' replace with actual item name if known
            Catch
            End Try

            ' If not found by name, fall back to first ToolStripStatusLabel in the Items collection
            If tsi Is Nothing Then
                For Each it As ToolStripItem In ss.Items
                    If TypeOf it Is ToolStripStatusLabel Then
                        tsi = it
                        Exit For
                    End If
                Next
            End If

            If tsi IsNot Nothing Then
                tsi.Text = statusText
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ' Read the trackbar value; default to 1 if absent
        Dim v As Integer = If(speedControl IsNot Nothing, speedControl.Value, 1)

        ' v = 0 => still tick but don't change time
        If v = 0 Then
            UpdateLabelsFromCurrentTime()
            Return
        End If

        ' Exponential mapping: secondsPerSecond = sign(v) * 10^(abs(v)-1)
        ' v=1 => 1 sec/sec, v=2 => 10 sec/sec, v=3 => 100 sec/sec, etc.
        Dim sign As Integer = Math.Sign(v)
        Dim magnitude As Double = Math.Pow(10.0, Math.Abs(v) - 1)
        Dim secondsPerSecond As Double = sign * magnitude

        ' Compute seconds to add for this tick (Timer1.Interval is ms)
        Dim secondsThisTick As Double = secondsPerSecond * (Timer1.Interval / 1000.0)

        ' Capture previous time to detect day boundary even if we jump many seconds
        Dim oldTime As DateTime = currentTime

        currentTime = SafeAddSeconds(currentTime, secondsThisTick)
        UpdateLabelsFromCurrentTime()

        ' detect date rollover (crossed midnight) - kept for backward compatibility
        CheckDayBoundary(oldTime, currentTime)

        ' update DayLight / YearLight / MonthLight state based on current time
        UpdateDayLightState()
        UpdateYearLightState()
        UpdateMonthLightState()

        ' store for next tick if other logic needs it
        previousTime = currentTime
    End Sub

    Private Sub CheckDayBoundary(prev As DateTime, curr As DateTime)
        If PictureBox1 Is Nothing Then Return
        Try
            If prev.Date <> curr.Date Then
                ' crossed midnight — trigger DayLight as an immediate indicator
                If DayLight IsNot Nothing Then
                    DayLight.BackColor = Color.Yellow
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub UpdateDayLightState()
        If DayLight Is Nothing Then Return

        Try
            ' Light during the last three hours of the day (21:00 - 23:59:59)
            Dim startLastThree As TimeSpan = TimeSpan.FromHours(21) ' 24 - 3 = 21
            If currentTime.TimeOfDay >= startLastThree Then
                DayLight.BackColor = Color.Yellow
            Else
                ' restore the original color if recorded
                If dayLightOriginalColor <> Color.Empty Then
                    DayLight.BackColor = dayLightOriginalColor
                Else
                    ' fallback to default
                    DayLight.BackColor = SystemColors.Control
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub UpdateYearLightState()
        If yearLightControl Is Nothing Then Return

        Try
            ' Determine the start month for the last N months of the year.
            ' yearLightMonthsThreshold is inclusive: 1 => December only, 2 => November+December, etc.
            Dim threshold As Integer = Math.Max(1, Math.Min(12, yearLightMonthsThreshold))
            Dim startMonth As Integer = Math.Max(1, 12 - threshold + 1)

            If currentTime.Month >= startMonth Then
                yearLightControl.BackColor = Color.Red
            Else
                If yearLightOriginalColor <> Color.Empty Then
                    yearLightControl.BackColor = yearLightOriginalColor
                Else
                    yearLightControl.BackColor = SystemColors.Control
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub UpdateMonthLightState()
        If monthLightControl Is Nothing Then Return

        Try
            ' Light during the last week of the month (e.g., 24th to 31st)
            Dim lastWeekStart As DateTime = New DateTime(currentTime.Year, currentTime.Month, 24)
            Dim lastWeekEnd As DateTime = lastWeekStart.AddDays(7).AddTicks(-1) ' to the last tick of the 30th/31st

            If currentTime >= lastWeekStart AndAlso currentTime <= lastWeekEnd Then
                monthLightControl.BackColor = Color.Green
            Else
                If monthLightOriginalColor <> Color.Empty Then
                    monthLightControl.BackColor = monthLightOriginalColor
                Else
                    monthLightControl.BackColor = SystemColors.Control
                End If
            End If
        Catch
        End Try
    End Sub

    Private Function SafeAddSeconds(dt As DateTime, seconds As Double) As DateTime
        If seconds = 0.0 Then Return dt

        Dim ticksPerSecond As Double = TimeSpan.TicksPerSecond
        Dim addTicks As Double = seconds * ticksPerSecond
        Dim result As Double = CDbl(dt.Ticks) + addTicks

        If result >= CDbl(DateTime.MaxValue.Ticks) Then Return DateTime.MaxValue
        If result <= CDbl(DateTime.MinValue.Ticks) Then Return DateTime.MinValue

        Return New DateTime(CLng(result))
    End Function

    Private Sub UpdateLabelsFromCurrentTime()
        SLabel.Text = currentTime.Second.ToString("D2")
        MLabel.Text = currentTime.Minute.ToString("D2")
        HLabel.Text = currentTime.Hour.ToString("D2")
        DLabel.Text = currentTime.Day.ToString("D2")
        MoLabel.Text = currentTime.Month.ToString("D2")
        YLabel.Text = currentTime.Year.ToString()
    End Sub

    ' Public API used by Settings form
    Public Sub SetBackgroundVisible(visible As Boolean)
        If PictureBox1 Is Nothing Then Return
        ' Toggle the PictureBox image rather than hiding the whole control so child labels remain visible
        If visible Then
            PictureBox1.Image = originalBackground
        Else
            PictureBox1.Image = Nothing
        End If
    End Sub

    Public Sub ResetTimeToNow()
        currentTime = DateTime.Now
        UpdateLabelsFromCurrentTime()
        UpdateDayLightState()
        UpdateYearLightState()
        UpdateMonthLightState()
    End Sub

    ' Click handler for the invisible clickspot label
    Private Sub clickspot_Click(sender As Object, e As EventArgs) Handles clickspot.Click
        Dim s As New Settings()
        s.StartPosition = FormStartPosition.CenterParent
        s.ShowDialog(Me)
    End Sub

End Class