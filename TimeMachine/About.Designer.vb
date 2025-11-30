<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Label1 = New Label()
        Label2 = New Label()
        VerBuild = New Label()
        RichTextBox1 = New RichTextBox()
        AboutOK = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Engravers MT", 28.125F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(33, 32)
        Label1.Name = "Label1"
        Label1.Size = New Size(855, 87)
        Label1.TabIndex = 0
        Label1.Text = "Time Machine I"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Engravers MT", 16.125F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(33, 214)
        Label2.Name = "Label2"
        Label2.Size = New Size(783, 50)
        Label2.TabIndex = 1
        Label2.Text = "Developed by: Oliver K"
        ' 
        ' VerBuild
        ' 
        VerBuild.AutoSize = True
        VerBuild.Font = New Font("Engravers MT", 16.125F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        VerBuild.Location = New Point(33, 141)
        VerBuild.Name = "VerBuild"
        VerBuild.Size = New Size(208, 50)
        VerBuild.TabIndex = 2
        VerBuild.Text = "Label"
        ' 
        ' RichTextBox1
        ' 
        RichTextBox1.Font = New Font("Courier New", 10.875F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RichTextBox1.Location = New Point(33, 284)
        RichTextBox1.Name = "RichTextBox1"
        RichTextBox1.Size = New Size(855, 115)
        RichTextBox1.TabIndex = 4
        RichTextBox1.Text = "Disclaimer: This software is not associated or afiliated with H.G Wells or George Pal's ""The Time Machine"" (1960)"
        ' 
        ' AboutOK
        ' 
        AboutOK.Location = New Point(374, 419)
        AboutOK.Name = "AboutOK"
        AboutOK.Size = New Size(150, 46)
        AboutOK.TabIndex = 5
        AboutOK.Text = "OK"
        AboutOK.UseVisualStyleBackColor = True
        ' 
        ' About
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(927, 486)
        ControlBox = False
        Controls.Add(AboutOK)
        Controls.Add(RichTextBox1)
        Controls.Add(VerBuild)
        Controls.Add(Label2)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "About"
        StartPosition = FormStartPosition.CenterScreen
        Text = "About"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents VerBuild As Label
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents AboutOK As Button
End Class
