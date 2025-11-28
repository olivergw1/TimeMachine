<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MachineInterface
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
        components = New ComponentModel.Container()
        HLabel = New Label()
        MLabel = New Label()
        SLabel = New Label()
        YLabel = New Label()
        MoLabel = New Label()
        DLabel = New Label()
        GroupBox1 = New GroupBox()
        StatusStrip1 = New StatusStrip()
        MachineStatus = New ToolStripStatusLabel()
        Timer1 = New Timer(components)
        TimeControl = New TrackBar()
        GroupBox1.SuspendLayout()
        StatusStrip1.SuspendLayout()
        CType(TimeControl, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' HLabel
        ' 
        HLabel.AutoSize = True
        HLabel.Location = New Point(251, 124)
        HLabel.Name = "HLabel"
        HLabel.Size = New Size(67, 32)
        HLabel.TabIndex = 0
        HLabel.Text = "Hour"
        ' 
        ' MLabel
        ' 
        MLabel.AutoSize = True
        MLabel.Location = New Point(324, 124)
        MLabel.Name = "MLabel"
        MLabel.Size = New Size(91, 32)
        MLabel.TabIndex = 1
        MLabel.Text = "Minute"
        ' 
        ' SLabel
        ' 
        SLabel.AutoSize = True
        SLabel.Location = New Point(420, 124)
        SLabel.Name = "SLabel"
        SLabel.Size = New Size(93, 32)
        SLabel.TabIndex = 2
        SLabel.Text = "Second"
        ' 
        ' YLabel
        ' 
        YLabel.AutoSize = True
        YLabel.Location = New Point(164, 124)
        YLabel.Name = "YLabel"
        YLabel.Size = New Size(58, 32)
        YLabel.TabIndex = 3
        YLabel.Text = "Year"
        ' 
        ' MoLabel
        ' 
        MoLabel.AutoSize = True
        MoLabel.Location = New Point(72, 124)
        MoLabel.Name = "MoLabel"
        MoLabel.Size = New Size(86, 32)
        MoLabel.TabIndex = 4
        MoLabel.Text = "Month"
        ' 
        ' DLabel
        ' 
        DLabel.AutoSize = True
        DLabel.Location = New Point(11, 124)
        DLabel.Name = "DLabel"
        DLabel.Size = New Size(55, 32)
        DLabel.TabIndex = 5
        DLabel.Text = "Day"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(YLabel)
        GroupBox1.Controls.Add(MoLabel)
        GroupBox1.Controls.Add(SLabel)
        GroupBox1.Controls.Add(DLabel)
        GroupBox1.Controls.Add(MLabel)
        GroupBox1.Controls.Add(HLabel)
        GroupBox1.Location = New Point(28, 33)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(527, 292)
        GroupBox1.TabIndex = 6
        GroupBox1.TabStop = False
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.ImageScalingSize = New Size(32, 32)
        StatusStrip1.Items.AddRange(New ToolStripItem() {MachineStatus})
        StatusStrip1.Location = New Point(0, 475)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Size = New Size(594, 22)
        StatusStrip1.TabIndex = 7
        StatusStrip1.Text = "StatusStrip1"
        ' 
        ' MachineStatus
        ' 
        MachineStatus.Name = "MachineStatus"
        MachineStatus.Size = New Size(0, 12)
        ' 
        ' Timer1
        ' 
        ' 
        ' TimeControl
        ' 
        TimeControl.Location = New Point(28, 354)
        TimeControl.Maximum = 5
        TimeControl.Minimum = -5
        TimeControl.Name = "TimeControl"
        TimeControl.Size = New Size(527, 90)
        TimeControl.TabIndex = 8
        ' 
        ' MachineInterface
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(594, 497)
        Controls.Add(TimeControl)
        Controls.Add(StatusStrip1)
        Controls.Add(GroupBox1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "MachineInterface"
        SizeGripStyle = SizeGripStyle.Hide
        Text = "Time Machine"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        CType(TimeControl, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents HLabel As Label
    Friend WithEvents MLabel As Label
    Friend WithEvents SLabel As Label
    Friend WithEvents YLabel As Label
    Friend WithEvents MoLabel As Label
    Friend WithEvents DLabel As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents Timer1 As Timer
    Friend WithEvents TimeControl As TrackBar
    Friend WithEvents MachineStatus As ToolStripStatusLabel
End Class
