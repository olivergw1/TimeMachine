Public Class Settings
    Public Sub New()
        Try
            ' Required by the Windows Form Designer
            InitializeComponent()
            ' Check the current settings from the actual MachineInterface instance
            Dim mi = GetMachineInterfaceInstance()
            If mi IsNot Nothing Then
                ' Set initial checkbox states based on the current instance settings
                HideBG.Checked = mi.PictureBox1.Image Is Nothing
                HideHMS.Checked = Not mi.HLabel.Visible
                HideLites.Checked = Not mi.DayLight.Visible
            End If



            ' Ensure the form appears in front for debugging/normal use
            Me.StartPosition = FormStartPosition.CenterParent
        Catch ex As Exception
            ' Surface initialization errors so you can see what's failing
            MessageBox.Show("Settings initialization failed:" & Environment.NewLine & ex.ToString(),
                            "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SettingsOK_Click(sender As Object, e As EventArgs) Handles SettingsOK.Click
        ' Close the settings box when OK clicked
        Me.Close()
    End Sub

    ' Find the actual MachineInterface instance to operate on:
    Private Function GetMachineInterfaceInstance() As MachineInterface
        ' Prefer the dialog owner (Set when calling ShowDialog(Me))
        Dim mi As MachineInterface = TryCast(Me.Owner, MachineInterface)
        If mi IsNot Nothing Then Return mi

        ' Fallback: find any open MachineInterface form
        For Each f As Form In Application.OpenForms
            mi = TryCast(f, MachineInterface)
            If mi IsNot Nothing Then Return mi
        Next

        Return Nothing
    End Function

    Private Sub HideBG_CheckedChanged(sender As Object, e As EventArgs) Handles HideBG.CheckedChanged
        Try
            Dim mi = GetMachineInterfaceInstance()
            If mi Is Nothing Then
                MessageBox.Show("Unable to find the Time Machine window to apply this setting.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' When checked -> hide background (image) while leaving labels intact
            mi.SetBackgroundVisible(Not HideBG.Checked)
        Catch ex As Exception
            MessageBox.Show("Unable to change background visibility: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ResetTime_Click(sender As Object, e As EventArgs) Handles ResetTime.Click
        Try
            Dim mi = GetMachineInterfaceInstance()
            If mi Is Nothing Then
                MessageBox.Show("Unable to find the Time Machine window to reset the time.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            mi.ResetTimeToNow()
        Catch ex As Exception
            MessageBox.Show("Unable to reset time: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub HideHMS_CheckedChanged(sender As Object, e As EventArgs) Handles HideHMS.CheckedChanged
        Try
            Dim mi = GetMachineInterfaceInstance()
            If mi Is Nothing Then
                MessageBox.Show("Unable to find the Time Machine window to apply this setting.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Toggle visibility on the actual instance's labels
            Dim visible As Boolean = Not HideHMS.Checked
            mi.HLabel.Visible = visible
            mi.MLabel.Visible = visible
            mi.SLabel.Visible = visible
        Catch ex As Exception
            MessageBox.Show("Unable to toggle H:M:S visibility: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub HideLites_CheckedChanged(sender As Object, e As EventArgs) Handles HideLites.CheckedChanged
        Try
            Dim mi = GetMachineInterfaceInstance()
            If mi Is Nothing Then
                MessageBox.Show("Unable to find the Time Machine window to apply this setting.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            ' Toggle visibility on the day/month/year lights (panel elements)
            Dim visible As Boolean = Not HideLites.Checked
            mi.DayLight.Visible = visible
            mi.MonthLight.Visible = visible
            mi.YearLight.Visible = visible
        Catch ex As Exception
            MessageBox.Show("Unable to toggle day/month/year lights visibility: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

	Private Sub AboutTM_Click(sender As Object, e As EventArgs) Handles AboutTM.Click
        ' Open the About Time Machine dialog
        Dim about As New About()
        about.ShowDialog(Me)
    End Sub
End Class