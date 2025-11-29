Public Class Settings
    Public Sub New()
        Try
            ' Required by the Windows Form Designer
            InitializeComponent()

            ' Ensure the form appears in front for debugging/normal use
            Me.StartPosition = FormStartPosition.CenterParent
        Catch ex As Exception
            ' Surface initialization errors so you can see what's failing
            MessageBox.Show("Settings initialization failed:" & Environment.NewLine & ex.ToString(),
                            "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SettingsOK_Click(sender As Object, e As EventArgs) Handles SettingsOK.Click
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
End Class