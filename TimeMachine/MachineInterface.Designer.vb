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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MachineInterface))
        StatusStrip1 = New StatusStrip()
        MachineStatus = New ToolStripStatusLabel()
        Timer1 = New Timer(components)
        TimeControl = New TrackBar()
        HLabel = New Label()
        MLabel = New Label()
        DLabel = New Label()
        SLabel = New Label()
        MoLabel = New Label()
        YLabel = New Label()
        PictureBox1 = New PictureBox()
        clickspot = New Label()
        YearLight = New Panel()
        MonthLight = New Panel()
        DayLight = New Panel()
        StatusStrip1.SuspendLayout()
        CType(TimeControl, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.ImageScalingSize = New Size(32, 32)
        StatusStrip1.Items.AddRange(New ToolStripItem() {MachineStatus})
        StatusStrip1.Location = New Point(0, 649)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Size = New Size(1095, 22)
        StatusStrip1.TabIndex = 7
        StatusStrip1.Text = "Status: Travelling @1x real time"
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
        TimeControl.Location = New Point(1022, 90)
        TimeControl.Maximum = 5
        TimeControl.Minimum = -5
        TimeControl.Name = "TimeControl"
        TimeControl.Orientation = Orientation.Vertical
        TimeControl.Size = New Size(90, 527)
        TimeControl.TabIndex = 8
        ' 
        ' HLabel
        ' 
        HLabel.AutoSize = True
        HLabel.Location = New Point(738, 9)
        HLabel.Name = "HLabel"
        HLabel.Size = New Size(67, 32)
        HLabel.TabIndex = 0
        HLabel.Text = "Hour"
        ' 
        ' MLabel
        ' 
        MLabel.AutoSize = True
        MLabel.Location = New Point(811, 9)
        MLabel.Name = "MLabel"
        MLabel.Size = New Size(91, 32)
        MLabel.TabIndex = 1
        MLabel.Text = "Minute"
        ' 
        ' DLabel
        ' 
        DLabel.AutoSize = True
        DLabel.BackColor = Color.Transparent
        DLabel.Font = New Font("Bodoni MT Condensed", 28.125F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DLabel.Location = New Point(770, 201)
        DLabel.Name = "DLabel"
        DLabel.Size = New Size(130, 89)
        DLabel.TabIndex = 5
        DLabel.Text = "Day"
        DLabel.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' SLabel
        ' 
        SLabel.AutoSize = True
        SLabel.Location = New Point(908, 9)
        SLabel.Name = "SLabel"
        SLabel.Size = New Size(93, 32)
        SLabel.TabIndex = 2
        SLabel.Text = "Second"
        ' 
        ' MoLabel
        ' 
        MoLabel.AutoSize = True
        MoLabel.BackColor = Color.Transparent
        MoLabel.Font = New Font("Bodoni MT Condensed", 28.125F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        MoLabel.Location = New Point(136, 189)
        MoLabel.Name = "MoLabel"
        MoLabel.Size = New Size(190, 89)
        MoLabel.TabIndex = 4
        MoLabel.Text = "Month"
        MoLabel.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' YLabel
        ' 
        YLabel.AutoSize = True
        YLabel.BackColor = Color.Transparent
        YLabel.Font = New Font("Bodoni MT Condensed", 48F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        YLabel.Location = New Point(363, 375)
        YLabel.Name = "YLabel"
        YLabel.Size = New Size(266, 151)
        YLabel.TabIndex = 3
        YLabel.Text = "Year"
        YLabel.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.TimeMachine_Panel
        PictureBox1.Location = New Point(0, 56)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(1000, 561)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 9
        PictureBox1.TabStop = False
        ' 
        ' clickspot
        ' 
        clickspot.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        clickspot.AutoSize = True
        clickspot.BackColor = Color.Transparent
        clickspot.Font = New Font("Segoe UI", 28.125F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        clickspot.ForeColor = Color.Transparent
        clickspot.Location = New Point(373, 201)
        clickspot.Name = "clickspot"
        clickspot.Size = New Size(256, 100)
        clickspot.TabIndex = 10
        clickspot.Text = "Label1"
        clickspot.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' YearLight
        ' 
        YearLight.Location = New Point(458, 9)
        YearLight.Name = "YearLight"
        YearLight.Size = New Size(66, 41)
        YearLight.TabIndex = 11
        ' 
        ' MonthLight
        ' 
        MonthLight.Location = New Point(336, 9)
        MonthLight.Name = "MonthLight"
        MonthLight.Size = New Size(66, 41)
        MonthLight.TabIndex = 12
        ' 
        ' DayLight
        ' 
        DayLight.Location = New Point(582, 9)
        DayLight.Name = "DayLight"
        DayLight.Size = New Size(66, 41)
        DayLight.TabIndex = 13
        ' 
        ' MachineInterface
        ' 
        AutoScaleMode = AutoScaleMode.None
        ClientSize = New Size(1095, 671)
        Controls.Add(DayLight)
        Controls.Add(MonthLight)
        Controls.Add(YearLight)
        Controls.Add(clickspot)
        Controls.Add(SLabel)
        Controls.Add(YLabel)
        Controls.Add(MLabel)
        Controls.Add(TimeControl)
        Controls.Add(HLabel)
        Controls.Add(MoLabel)
        Controls.Add(StatusStrip1)
        Controls.Add(DLabel)
        Controls.Add(PictureBox1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        Name = "MachineInterface"
        SizeGripStyle = SizeGripStyle.Hide
        Text = "Time Machine Control Panel"
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        CType(TimeControl, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents Timer1 As Timer
    Friend WithEvents TimeControl As TrackBar
    Friend WithEvents MachineStatus As ToolStripStatusLabel
    Friend WithEvents HLabel As Label
    Friend WithEvents MLabel As Label
    Friend WithEvents DLabel As Label
    Friend WithEvents SLabel As Label
    Friend WithEvents MoLabel As Label
    Friend WithEvents YLabel As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents clickspot As Label
    Friend WithEvents YearLight As Panel
    Friend WithEvents MonthLight As Panel
    Friend WithEvents DayLight As Panel
End Class
