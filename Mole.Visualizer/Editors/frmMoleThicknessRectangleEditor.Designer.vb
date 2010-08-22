<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMoleThicknessRectangleEditor
    Inherits Mole.frmMoleEditorBase

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.pbVisual = New System.Windows.Forms.PictureBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.lblFour = New System.Windows.Forms.Label
        Me.nudFour = New System.Windows.Forms.NumericUpDown
        Me.lblThree = New System.Windows.Forms.Label
        Me.nudThree = New System.Windows.Forms.NumericUpDown
        Me.lblTwo = New System.Windows.Forms.Label
        Me.nudTwo = New System.Windows.Forms.NumericUpDown
        Me.lblOne = New System.Windows.Forms.Label
        Me.nudOne = New System.Windows.Forms.NumericUpDown
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.pbVisual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.nudFour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudThree, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTwo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudOne, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        '
        'btnSaveClose
        '
        '
        'bntSave
        '
        '
        'btnReset
        '
        '
        'btnSetToNull
        '
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 39)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(555, 247)
        Me.Panel1.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.AutoScroll = True
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.pbVisual)
        Me.Panel3.Location = New System.Drawing.Point(169, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(390, 245)
        Me.Panel3.TabIndex = 2
        '
        'pbVisual
        '
        Me.pbVisual.Location = New System.Drawing.Point(3, 3)
        Me.pbVisual.Name = "pbVisual"
        Me.pbVisual.Size = New System.Drawing.Size(103, 73)
        Me.pbVisual.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbVisual.TabIndex = 2
        Me.pbVisual.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.lblFour)
        Me.Panel2.Controls.Add(Me.nudFour)
        Me.Panel2.Controls.Add(Me.lblThree)
        Me.Panel2.Controls.Add(Me.nudThree)
        Me.Panel2.Controls.Add(Me.lblTwo)
        Me.Panel2.Controls.Add(Me.nudTwo)
        Me.Panel2.Controls.Add(Me.lblOne)
        Me.Panel2.Controls.Add(Me.nudOne)
        Me.Panel2.Location = New System.Drawing.Point(4, 37)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(159, 246)
        Me.Panel2.TabIndex = 1
        '
        'lblFour
        '
        Me.lblFour.AutoSize = True
        Me.lblFour.Location = New System.Drawing.Point(15, 138)
        Me.lblFour.Name = "lblFour"
        Me.lblFour.Size = New System.Drawing.Size(40, 13)
        Me.lblFour.TabIndex = 7
        Me.lblFour.Text = "Bottom"
        '
        'nudFour
        '
        Me.nudFour.Location = New System.Drawing.Point(70, 136)
        Me.nudFour.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        Me.nudFour.Minimum = New Decimal(New Integer() {59, 0, 0, -2147483648})
        Me.nudFour.Name = "nudFour"
        Me.nudFour.Size = New System.Drawing.Size(68, 20)
        Me.nudFour.TabIndex = 6
        '
        'lblThree
        '
        Me.lblThree.AutoSize = True
        Me.lblThree.Location = New System.Drawing.Point(15, 103)
        Me.lblThree.Name = "lblThree"
        Me.lblThree.Size = New System.Drawing.Size(32, 13)
        Me.lblThree.TabIndex = 5
        Me.lblThree.Text = "Right"
        '
        'nudThree
        '
        Me.nudThree.Location = New System.Drawing.Point(70, 101)
        Me.nudThree.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
        Me.nudThree.Minimum = New Decimal(New Integer() {59, 0, 0, -2147483648})
        Me.nudThree.Name = "nudThree"
        Me.nudThree.Size = New System.Drawing.Size(68, 20)
        Me.nudThree.TabIndex = 4
        '
        'lblTwo
        '
        Me.lblTwo.AutoSize = True
        Me.lblTwo.Location = New System.Drawing.Point(15, 68)
        Me.lblTwo.Name = "lblTwo"
        Me.lblTwo.Size = New System.Drawing.Size(26, 13)
        Me.lblTwo.TabIndex = 3
        Me.lblTwo.Text = "Top"
        '
        'nudTwo
        '
        Me.nudTwo.Location = New System.Drawing.Point(70, 66)
        Me.nudTwo.Maximum = New Decimal(New Integer() {23, 0, 0, 0})
        Me.nudTwo.Minimum = New Decimal(New Integer() {23, 0, 0, -2147483648})
        Me.nudTwo.Name = "nudTwo"
        Me.nudTwo.Size = New System.Drawing.Size(68, 20)
        Me.nudTwo.TabIndex = 2
        '
        'lblOne
        '
        Me.lblOne.AutoSize = True
        Me.lblOne.Location = New System.Drawing.Point(15, 32)
        Me.lblOne.Name = "lblOne"
        Me.lblOne.Size = New System.Drawing.Size(25, 13)
        Me.lblOne.TabIndex = 1
        Me.lblOne.Text = "Left"
        '
        'nudOne
        '
        Me.nudOne.Location = New System.Drawing.Point(70, 30)
        Me.nudOne.Name = "nudOne"
        Me.nudOne.Size = New System.Drawing.Size(68, 20)
        Me.nudOne.TabIndex = 0
        '
        'frmMoleThicknessRectangleEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(555, 337)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmMoleThicknessRectangleEditor"
        Me.Text = "Mole Editor"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.pbVisual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.nudFour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudThree, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTwo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudOne, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblFour As System.Windows.Forms.Label
    Friend WithEvents nudFour As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblThree As System.Windows.Forms.Label
    Friend WithEvents nudThree As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblTwo As System.Windows.Forms.Label
    Friend WithEvents nudTwo As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblOne As System.Windows.Forms.Label
    Friend WithEvents nudOne As System.Windows.Forms.NumericUpDown
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents pbVisual As System.Windows.Forms.PictureBox

End Class
