<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMoleFontEditor
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
        Me.lblPreviewFont = New System.Windows.Forms.Label
        Me.btnSelectFont = New System.Windows.Forms.Button
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
        Me.Panel3.Location = New System.Drawing.Point(211, 1)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(343, 245)
        Me.Panel3.TabIndex = 3
        '
        'pbVisual
        '
        Me.pbVisual.BackColor = System.Drawing.Color.White
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
        Me.Panel2.Controls.Add(Me.lblPreviewFont)
        Me.Panel2.Controls.Add(Me.btnSelectFont)
        Me.Panel2.Location = New System.Drawing.Point(0, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(205, 245)
        Me.Panel2.TabIndex = 2
        '
        'lblPreviewFont
        '
        Me.lblPreviewFont.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPreviewFont.Location = New System.Drawing.Point(4, 33)
        Me.lblPreviewFont.Name = "lblPreviewFont"
        Me.lblPreviewFont.Size = New System.Drawing.Size(198, 129)
        Me.lblPreviewFont.TabIndex = 3
        Me.lblPreviewFont.Text = "Preview Font"
        Me.lblPreviewFont.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSelectFont
        '
        Me.btnSelectFont.Location = New System.Drawing.Point(59, 184)
        Me.btnSelectFont.Name = "btnSelectFont"
        Me.btnSelectFont.Size = New System.Drawing.Size(78, 28)
        Me.btnSelectFont.TabIndex = 2
        Me.btnSelectFont.Text = "Select Font"
        Me.btnSelectFont.UseVisualStyleBackColor = True
        '
        'frmMoleFontEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(555, 337)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmMoleFontEditor"
        Me.Text = "Mole Font Editor"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.pbVisual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents pbVisual As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnSelectFont As System.Windows.Forms.Button
    Friend WithEvents lblPreviewFont As System.Windows.Forms.Label

End Class
