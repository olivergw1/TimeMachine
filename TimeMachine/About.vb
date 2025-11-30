Public Class About
	Private Sub About_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		' Set the version label (VerBuild) to show current version info
		Dim version As Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version
		VerBuild.Text = String.Format("Version {0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision)
	End Sub
	Private Sub AboutOK_Click(sender As Object, e As EventArgs) Handles AboutOK.Click
		' Close the About box when OK clicked
		Me.Close()
	End Sub
End Class