<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMoleColorEditor
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
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.txtHexColor = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.nudA = New System.Windows.Forms.NumericUpDown
        Me.nudB = New System.Windows.Forms.NumericUpDown
        Me.nudG = New System.Windows.Forms.NumericUpDown
        Me.nudR = New System.Windows.Forms.NumericUpDown
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboKnownColors = New System.Windows.Forms.ComboBox
        Me.rdoBrightness = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.rdoSortSaturation = New System.Windows.Forms.RadioButton
        Me.cboSystemColors = New System.Windows.Forms.ComboBox
        Me.rdoSortHue = New System.Windows.Forms.RadioButton
        Me.rdoSortName = New System.Windows.Forms.RadioButton
        Me.btnChangeColor = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.pnlColorSample = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.pbVisual = New System.Windows.Forms.PictureBox
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.nudA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.pbVisual, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 39)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(747, 408)
        Me.Panel1.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.txtHexColor)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.nudA)
        Me.Panel2.Controls.Add(Me.nudB)
        Me.Panel2.Controls.Add(Me.nudG)
        Me.Panel2.Controls.Add(Me.nudR)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.btnChangeColor)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.pnlColorSample)
        Me.Panel2.Location = New System.Drawing.Point(0, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(280, 405)
        Me.Panel2.TabIndex = 0
        '
        'txtHexColor
        '
        Me.txtHexColor.Location = New System.Drawing.Point(69, 81)
        Me.txtHexColor.Name = "txtHexColor"
        Me.txtHexColor.Size = New System.Drawing.Size(136, 20)
        Me.txtHexColor.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(35, 83)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(26, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Hex"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(42, 379)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(15, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "A"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(206, 379)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "B"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Lime
        Me.Label4.Location = New System.Drawing.Point(148, 379)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(16, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "G"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(95, 379)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "R"
        '
        'nudA
        '
        Me.nudA.ContextMenu = Nothing
        Me.nudA.Location = New System.Drawing.Point(31, 356)
        Me.nudA.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudA.Name = "nudA"
        Me.nudA.Size = New System.Drawing.Size(43, 20)
        Me.nudA.TabIndex = 6
        '
        'nudB
        '
        Me.nudB.ContextMenu = Nothing
        Me.nudB.Location = New System.Drawing.Point(197, 356)
        Me.nudB.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudB.Name = "nudB"
        Me.nudB.Size = New System.Drawing.Size(43, 20)
        Me.nudB.TabIndex = 9
        '
        'nudG
        '
        Me.nudG.ContextMenu = Nothing
        Me.nudG.Location = New System.Drawing.Point(139, 356)
        Me.nudG.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudG.Name = "nudG"
        Me.nudG.Size = New System.Drawing.Size(43, 20)
        Me.nudG.TabIndex = 8
        '
        'nudR
        '
        Me.nudR.ContextMenu = Nothing
        Me.nudR.Location = New System.Drawing.Point(85, 356)
        Me.nudR.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudR.Name = "nudR"
        Me.nudR.Size = New System.Drawing.Size(43, 20)
        Me.nudR.TabIndex = 7
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboKnownColors)
        Me.GroupBox1.Controls.Add(Me.rdoBrightness)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.rdoSortSaturation)
        Me.GroupBox1.Controls.Add(Me.cboSystemColors)
        Me.GroupBox1.Controls.Add(Me.rdoSortHue)
        Me.GroupBox1.Controls.Add(Me.rdoSortName)
        Me.GroupBox1.Location = New System.Drawing.Point(27, 132)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(216, 167)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select Color"
        '
        'cboKnownColors
        '
        Me.cboKnownColors.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboKnownColors.FormattingEnabled = True
        Me.cboKnownColors.Location = New System.Drawing.Point(6, 46)
        Me.cboKnownColors.Name = "cboKnownColors"
        Me.cboKnownColors.Size = New System.Drawing.Size(199, 21)
        Me.cboKnownColors.TabIndex = 1
        '
        'rdoBrightness
        '
        Me.rdoBrightness.AutoSize = True
        Me.rdoBrightness.Location = New System.Drawing.Point(125, 136)
        Me.rdoBrightness.Name = "rdoBrightness"
        Me.rdoBrightness.Size = New System.Drawing.Size(74, 17)
        Me.rdoBrightness.TabIndex = 6
        Me.rdoBrightness.Text = "Brightness"
        Me.rdoBrightness.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(66, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Sort Colors By"
        '
        'rdoSortSaturation
        '
        Me.rdoSortSaturation.AutoSize = True
        Me.rdoSortSaturation.Location = New System.Drawing.Point(126, 104)
        Me.rdoSortSaturation.Name = "rdoSortSaturation"
        Me.rdoSortSaturation.Size = New System.Drawing.Size(73, 17)
        Me.rdoSortSaturation.TabIndex = 5
        Me.rdoSortSaturation.Text = "Saturation"
        Me.rdoSortSaturation.UseVisualStyleBackColor = True
        '
        'cboSystemColors
        '
        Me.cboSystemColors.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboSystemColors.FormattingEnabled = True
        Me.cboSystemColors.Location = New System.Drawing.Point(6, 19)
        Me.cboSystemColors.Name = "cboSystemColors"
        Me.cboSystemColors.Size = New System.Drawing.Size(199, 21)
        Me.cboSystemColors.TabIndex = 0
        '
        'rdoSortHue
        '
        Me.rdoSortHue.AutoSize = True
        Me.rdoSortHue.Location = New System.Drawing.Point(17, 136)
        Me.rdoSortHue.Name = "rdoSortHue"
        Me.rdoSortHue.Size = New System.Drawing.Size(45, 17)
        Me.rdoSortHue.TabIndex = 4
        Me.rdoSortHue.Text = "Hue"
        Me.rdoSortHue.UseVisualStyleBackColor = True
        '
        'rdoSortName
        '
        Me.rdoSortName.AutoSize = True
        Me.rdoSortName.Checked = True
        Me.rdoSortName.Location = New System.Drawing.Point(17, 104)
        Me.rdoSortName.Name = "rdoSortName"
        Me.rdoSortName.Size = New System.Drawing.Size(53, 17)
        Me.rdoSortName.TabIndex = 3
        Me.rdoSortName.TabStop = True
        Me.rdoSortName.Text = "Name"
        Me.rdoSortName.UseVisualStyleBackColor = True
        '
        'btnChangeColor
        '
        Me.btnChangeColor.Location = New System.Drawing.Point(27, 315)
        Me.btnChangeColor.Name = "btnChangeColor"
        Me.btnChangeColor.Size = New System.Drawing.Size(216, 25)
        Me.btnChangeColor.TabIndex = 5
        Me.btnChangeColor.Text = "Select Color Using Color Picker"
        Me.btnChangeColor.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(115, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Color"
        '
        'pnlColorSample
        '
        Me.pnlColorSample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlColorSample.Location = New System.Drawing.Point(27, 36)
        Me.pnlColorSample.Name = "pnlColorSample"
        Me.pnlColorSample.Size = New System.Drawing.Size(213, 28)
        Me.pnlColorSample.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.AutoScroll = True
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.pbVisual)
        Me.Panel3.Location = New System.Drawing.Point(286, 39)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(461, 408)
        Me.Panel3.TabIndex = 2
        '
        'pbVisual
        '
        Me.pbVisual.BackColor = System.Drawing.Color.White
        Me.pbVisual.Location = New System.Drawing.Point(3, 0)
        Me.pbVisual.Name = "pbVisual"
        Me.pbVisual.Size = New System.Drawing.Size(103, 73)
        Me.pbVisual.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbVisual.TabIndex = 1
        Me.pbVisual.TabStop = False
        '
        'frmMoleColorEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(747, 498)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmMoleColorEditor"
        Me.Text = "Mole Color Editor"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Panel3, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.nudA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.pbVisual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents pbVisual As System.Windows.Forms.PictureBox
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents btnChangeColor As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlColorSample As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoSortSaturation As System.Windows.Forms.RadioButton
    Friend WithEvents rdoSortHue As System.Windows.Forms.RadioButton
    Friend WithEvents rdoSortName As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents nudA As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudB As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudG As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudR As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtHexColor As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents rdoBrightness As System.Windows.Forms.RadioButton
    Friend WithEvents cboKnownColors As System.Windows.Forms.ComboBox
    Friend WithEvents cboSystemColors As System.Windows.Forms.ComboBox

End Class
