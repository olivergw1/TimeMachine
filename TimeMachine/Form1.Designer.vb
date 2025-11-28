<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Label1 = New Label()
        Year = New TextBox()
        Month = New TextBox()
        Day = New TextBox()
        Label2 = New Label()
        Hour = New TextBox()
        Minute = New TextBox()
        Second = New TextBox()
        TimeEntOK = New Button()
        Label3 = New Label()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(280, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(282, 32)
        Label1.TabIndex = 0
        Label1.Text = "Please enter current time"
        ' 
        ' Year
        ' 
        Year.Location = New Point(32, 80)
        Year.Name = "Year"
        Year.Size = New Size(118, 39)
        Year.TabIndex = 1
        Year.Text = "Year"
        ' 
        ' Month
        ' 
        Month.Location = New Point(156, 80)
        Month.Name = "Month"
        Month.Size = New Size(118, 39)
        Month.TabIndex = 2
        Month.Text = "Month"
        ' 
        ' Day
        ' 
        Day.Location = New Point(280, 80)
        Day.Name = "Day"
        Day.Size = New Size(118, 39)
        Day.TabIndex = 3
        Day.Text = "Day"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(404, 83)
        Label2.Name = "Label2"
        Label2.Size = New Size(24, 32)
        Label2.TabIndex = 4
        Label2.Text = "-"
        ' 
        ' Hour
        ' 
        Hour.Location = New Point(434, 80)
        Hour.Name = "Hour"
        Hour.Size = New Size(118, 39)
        Hour.TabIndex = 5
        Hour.Text = "Hour"
        ' 
        ' Minute
        ' 
        Minute.Location = New Point(558, 80)
        Minute.Name = "Minute"
        Minute.Size = New Size(118, 39)
        Minute.TabIndex = 6
        Minute.Text = "Minute"
        ' 
        ' Second
        ' 
        Second.Location = New Point(682, 80)
        Second.Name = "Second"
        Second.Size = New Size(118, 39)
        Second.TabIndex = 7
        Second.Text = "Second"
        ' 
        ' TimeEntOK
        ' 
        TimeEntOK.Location = New Point(329, 133)
        TimeEntOK.Name = "TimeEntOK"
        TimeEntOK.Size = New Size(150, 55)
        TimeEntOK.TabIndex = 8
        TimeEntOK.Text = "OK"
        TimeEntOK.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(196, 206)
        Label3.Name = "Label3"
        Label3.Size = New Size(430, 32)
        Label3.TabIndex = 9
        Label3.Text = "Click OK on default for current PC time"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(818, 256)
        Controls.Add(Label3)
        Controls.Add(TimeEntOK)
        Controls.Add(Second)
        Controls.Add(Minute)
        Controls.Add(Hour)
        Controls.Add(Label2)
        Controls.Add(Day)
        Controls.Add(Month)
        Controls.Add(Year)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "Form1"
        Text = "Time Entry"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Year As TextBox
    Friend WithEvents Month As TextBox
    Friend WithEvents Day As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Hour As TextBox
    Friend WithEvents Minute As TextBox
    Friend WithEvents Second As TextBox
    Friend WithEvents TimeEntOK As Button
    Friend WithEvents Label3 As Label

End Class
