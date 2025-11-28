Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TimeEntOK_Click(sender As Object, e As EventArgs) Handles TimeEntOK.Click
        Dim mi As New MachineInterface()
        mi.Show()
        Me.Close()
    End Sub
End Class
