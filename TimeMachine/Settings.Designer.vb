<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        GroupBox1 = New GroupBox()
        HideLites = New CheckBox()
        HideHMS = New CheckBox()
        HideBG = New CheckBox()
        ResetTime = New Button()
        AboutTM = New Button()
        SettingsOK = New Button()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(HideLites)
        GroupBox1.Controls.Add(HideHMS)
        GroupBox1.Controls.Add(HideBG)
        GroupBox1.Location = New Point(12, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(304, 189)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "Aesthetics"
        ' 
        ' HideLites
        ' 
        HideLites.AutoSize = True
        HideLites.Location = New Point(34, 137)
        HideLites.Name = "HideLites"
        HideLites.Size = New Size(166, 36)
        HideLites.TabIndex = 2
        HideLites.Text = "Hide Lights"
        HideLites.UseVisualStyleBackColor = True
        ' 
        ' HideHMS
        ' 
        HideHMS.AutoSize = True
        HideHMS.Location = New Point(34, 95)
        HideHMS.Name = "HideHMS"
        HideHMS.Size = New Size(165, 36)
        HideHMS.TabIndex = 1
        HideHMS.Text = "Hide H:M:S"
        HideHMS.UseVisualStyleBackColor = True
        ' 
        ' HideBG
        ' 
        HideBG.AutoSize = True
        HideBG.Location = New Point(34, 53)
        HideBG.Name = "HideBG"
        HideBG.Size = New Size(230, 36)
        HideBG.TabIndex = 0
        HideBG.Text = "Hide Background"
        HideBG.UseVisualStyleBackColor = True
        ' 
        ' ResetTime
        ' 
        ResetTime.Location = New Point(12, 268)
        ResetTime.Name = "ResetTime"
        ResetTime.Size = New Size(304, 55)
        ResetTime.TabIndex = 2
        ResetTime.Text = "Time Reset"
        ResetTime.UseVisualStyleBackColor = True
        ' 
        ' AboutTM
        ' 
        AboutTM.Location = New Point(12, 329)
        AboutTM.Name = "AboutTM"
        AboutTM.Size = New Size(304, 55)
        AboutTM.TabIndex = 3
        AboutTM.Text = "About Time Machine"
        AboutTM.UseVisualStyleBackColor = True
        ' 
        ' SettingsOK
        ' 
        SettingsOK.Location = New Point(12, 390)
        SettingsOK.Name = "SettingsOK"
        SettingsOK.Size = New Size(304, 55)
        SettingsOK.TabIndex = 4
        SettingsOK.Text = "OK"
        SettingsOK.UseVisualStyleBackColor = True
        ' 
        ' Settings
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(330, 464)
        ControlBox = False
        Controls.Add(SettingsOK)
        Controls.Add(AboutTM)
        Controls.Add(ResetTime)
        Controls.Add(GroupBox1)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "Settings"
        Text = "Time Machine Settings"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents HideLites As CheckBox
    Friend WithEvents HideHMS As CheckBox
    Friend WithEvents HideBG As CheckBox
    Friend WithEvents ResetTime As Button
    Friend WithEvents AboutTM As Button
    Friend WithEvents SettingsOK As Button
End Class
