<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Button1 = New Button()
        Button2 = New Button()
        Label1 = New Label()
        Label3 = New Label()
        PlotView1 = New OxyPlot.WindowsForms.PlotView()
        PlotView2 = New OxyPlot.WindowsForms.PlotView()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        samplingRate = New TextBox()
        hopLength = New TextBox()
        frame = New TextBox()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(16, 18)
        Button1.Margin = New Padding(4, 5, 4, 5)
        Button1.Name = "Button1"
        Button1.Size = New Size(147, 35)
        Button1.TabIndex = 0
        Button1.Text = "Load Data"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(16, 63)
        Button2.Margin = New Padding(4, 5, 4, 5)
        Button2.Name = "Button2"
        Button2.Size = New Size(147, 35)
        Button2.TabIndex = 1
        Button2.Text = "Compute STFT"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(171, 26)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(89, 20)
        Label1.TabIndex = 3
        Label1.Text = "Loaded File:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(268, 26)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(0, 20)
        Label3.TabIndex = 5
        ' 
        ' PlotView1
        ' 
        PlotView1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        PlotView1.Location = New Point(16, 108)
        PlotView1.Margin = New Padding(4, 5, 4, 5)
        PlotView1.Name = "PlotView1"
        PlotView1.PanCursor = Cursors.Hand
        PlotView1.Size = New Size(1035, 242)
        PlotView1.TabIndex = 6
        PlotView1.Text = "PlotView1"
        PlotView1.ZoomHorizontalCursor = Cursors.SizeWE
        PlotView1.ZoomRectangleCursor = Cursors.SizeNWSE
        PlotView1.ZoomVerticalCursor = Cursors.SizeNS
        ' 
        ' PlotView2
        ' 
        PlotView2.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        PlotView2.Location = New Point(16, 108)
        PlotView2.Margin = New Padding(4, 5, 4, 5)
        PlotView2.Name = "PlotView2"
        PlotView2.PanCursor = Cursors.Hand
        PlotView2.Size = New Size(1035, 669)
        PlotView2.TabIndex = 7
        PlotView2.Text = "PlotView2"
        PlotView2.ZoomHorizontalCursor = Cursors.SizeWE
        PlotView2.ZoomRectangleCursor = Cursors.SizeNWSE
        PlotView2.ZoomVerticalCursor = Cursors.SizeNS
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(176, 71)
        Label4.Name = "Label4"
        Label4.Size = New Size(109, 20)
        Label4.TabIndex = 8
        Label4.Text = "Sampling Rate:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(446, 71)
        Label5.Name = "Label5"
        Label5.Size = New Size(80, 20)
        Label5.TabIndex = 9
        Label5.Text = "frame size:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(698, 71)
        Label6.Name = "Label6"
        Label6.Size = New Size(70, 20)
        Label6.TabIndex = 10
        Label6.Text = "Hop size:"
        ' 
        ' samplingRate
        ' 
        samplingRate.Location = New Point(291, 71)
        samplingRate.Name = "samplingRate"
        samplingRate.Size = New Size(125, 27)
        samplingRate.TabIndex = 11
        samplingRate.Text = "16000"
        ' 
        ' hopLength
        ' 
        hopLength.Location = New Point(774, 68)
        hopLength.Name = "hopLength"
        hopLength.Size = New Size(125, 27)
        hopLength.TabIndex = 12
        hopLength.Text = "80"
        ' 
        ' frame
        ' 
        frame.Location = New Point(532, 71)
        frame.Name = "frame"
        frame.Size = New Size(125, 27)
        frame.TabIndex = 13
        frame.Text = "320"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1067, 797)
        Controls.Add(frame)
        Controls.Add(hopLength)
        Controls.Add(samplingRate)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(PlotView2)
        Controls.Add(PlotView1)
        Controls.Add(Label3)
        Controls.Add(Label1)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Margin = New Padding(4, 5, 4, 5)
        Name = "Form1"
        Text = "STFT"
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents PlotView1 As OxyPlot.WindowsForms.PlotView
    Friend WithEvents PlotView2 As OxyPlot.WindowsForms.PlotView
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents samplingRate As TextBox
    Friend WithEvents hopLength As TextBox
    Friend WithEvents frame As TextBox
End Class
