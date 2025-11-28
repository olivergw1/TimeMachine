Public Class MachineInterface
    Private currentTime As DateTime
    Private speedControl As TrackBar

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

        ' Fast, fixed timer tick so we can apply big time deltas per real second smoothly.
        Timer1.Interval = 50 ' 20 ticks/sec; reduce to 10 ms for smoother updates (more CPU)
        Timer1.Start()
        UpdateLabelsFromCurrentTime()
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

        currentTime = SafeAddSeconds(currentTime, secondsThisTick)
        UpdateLabelsFromCurrentTime()
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

End Class