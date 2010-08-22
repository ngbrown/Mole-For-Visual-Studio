<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMoleDateTimeEditor
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblSelectedDateTime = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbIncludeTime = New System.Windows.Forms.CheckBox
        Me.dtpTime = New System.Windows.Forms.DateTimePicker
        Me.dtpDate = New System.Windows.Forms.DateTimePicker
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.pbVisual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
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
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 39)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(591, 247)
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
        Me.Panel3.Location = New System.Drawing.Point(259, 2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(331, 243)
        Me.Panel3.TabIndex = 1
        '
        'pbVisual
        '
        Me.pbVisual.BackColor = System.Drawing.Color.White
        Me.pbVisual.Location = New System.Drawing.Point(3, 0)
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
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.lblSelectedDateTime)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.cbIncludeTime)
        Me.Panel2.Controls.Add(Me.dtpTime)
        Me.Panel2.Controls.Add(Me.dtpDate)
        Me.Panel2.Location = New System.Drawing.Point(0, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(253, 245)
        Me.Panel2.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 173)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Date/Time"
        '
        'lblSelectedDateTime
        '
        Me.lblSelectedDateTime.Location = New System.Drawing.Point(9, 196)
        Me.lblSelectedDateTime.Name = "lblSelectedDateTime"
        Me.lblSelectedDateTime.Size = New System.Drawing.Size(225, 25)
        Me.lblSelectedDateTime.TabIndex = 4
        Me.lblSelectedDateTime.Text = "Label2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Select Date"
        '
        'cbIncludeTime
        '
        Me.cbIncludeTime.AutoSize = True
        Me.cbIncludeTime.Location = New System.Drawing.Point(12, 88)
        Me.cbIncludeTime.Name = "cbIncludeTime"
        Me.cbIncludeTime.Size = New System.Drawing.Size(87, 17)
        Me.cbIncludeTime.TabIndex = 2
        Me.cbIncludeTime.Text = "Include Time"
        Me.cbIncludeTime.UseVisualStyleBackColor = True
        '
        'dtpTime
        '
        Me.dtpTime.Enabled = False
        Me.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpTime.Location = New System.Drawing.Point(12, 111)
        Me.dtpTime.Name = "dtpTime"
        Me.dtpTime.ShowUpDown = True
        Me.dtpTime.Size = New System.Drawing.Size(110, 20)
        Me.dtpTime.TabIndex = 1
        '
        'dtpDate
        '
        Me.dtpDate.Location = New System.Drawing.Point(12, 54)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(222, 20)
        Me.dtpDate.TabIndex = 0
        '
        'frmMoleDateTimeEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(591, 337)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmMoleDateTimeEditor"
        Me.Text = "Mole Date Time Editor"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.pbVisual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents pbVisual As System.Windows.Forms.PictureBox
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblSelectedDateTime As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbIncludeTime As System.Windows.Forms.CheckBox
    Friend WithEvents dtpTime As System.Windows.Forms.DateTimePicker

End Class
