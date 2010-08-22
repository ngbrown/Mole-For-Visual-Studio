<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMoleEditorBase
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
        Me.lblPropertyBeindEdited = New System.Windows.Forms.Label
        Me.pnlZContainerCommands = New System.Windows.Forms.Panel
        Me.btnSetToNull = New System.Windows.Forms.Button
        Me.btnReset = New System.Windows.Forms.Button
        Me.btnSaveClose = New System.Windows.Forms.Button
        Me.bntSave = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.pnlZContainerCommands.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblPropertyBeindEdited
        '
        Me.lblPropertyBeindEdited.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblPropertyBeindEdited.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblPropertyBeindEdited.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPropertyBeindEdited.Location = New System.Drawing.Point(0, 0)
        Me.lblPropertyBeindEdited.Name = "lblPropertyBeindEdited"
        Me.lblPropertyBeindEdited.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.lblPropertyBeindEdited.Size = New System.Drawing.Size(555, 39)
        Me.lblPropertyBeindEdited.TabIndex = 1
        Me.lblPropertyBeindEdited.Text = "Label1"
        Me.lblPropertyBeindEdited.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlZContainerCommands
        '
        Me.pnlZContainerCommands.Controls.Add(Me.btnSetToNull)
        Me.pnlZContainerCommands.Controls.Add(Me.btnReset)
        Me.pnlZContainerCommands.Controls.Add(Me.btnSaveClose)
        Me.pnlZContainerCommands.Controls.Add(Me.bntSave)
        Me.pnlZContainerCommands.Controls.Add(Me.btnClose)
        Me.pnlZContainerCommands.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlZContainerCommands.Location = New System.Drawing.Point(0, 286)
        Me.pnlZContainerCommands.Name = "pnlZContainerCommands"
        Me.pnlZContainerCommands.Size = New System.Drawing.Size(555, 51)
        Me.pnlZContainerCommands.TabIndex = 0
        '
        'btnSetToNull
        '
        Me.btnSetToNull.Location = New System.Drawing.Point(330, 13)
        Me.btnSetToNull.Name = "btnSetToNull"
        Me.btnSetToNull.Size = New System.Drawing.Size(87, 26)
        Me.btnSetToNull.TabIndex = 3
        Me.btnSetToNull.Text = "Set To &Null"
        Me.btnSetToNull.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(224, 13)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(87, 26)
        Me.btnReset.TabIndex = 2
        Me.btnReset.Text = "&Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnSaveClose
        '
        Me.btnSaveClose.Location = New System.Drawing.Point(118, 13)
        Me.btnSaveClose.Name = "btnSaveClose"
        Me.btnSaveClose.Size = New System.Drawing.Size(87, 26)
        Me.btnSaveClose.TabIndex = 1
        Me.btnSaveClose.Text = "Save && C&lose"
        Me.btnSaveClose.UseVisualStyleBackColor = True
        '
        'bntSave
        '
        Me.bntSave.Location = New System.Drawing.Point(12, 13)
        Me.bntSave.Name = "bntSave"
        Me.bntSave.Size = New System.Drawing.Size(87, 26)
        Me.bntSave.TabIndex = 0
        Me.bntSave.Text = "&Save"
        Me.bntSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(436, 13)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(87, 26)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmMoleEditorBase
        '
        Me.AcceptButton = Me.bntSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(555, 337)
        Me.Controls.Add(Me.pnlZContainerCommands)
        Me.Controls.Add(Me.lblPropertyBeindEdited)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmMoleEditorBase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmMoleEditorBase"
        Me.pnlZContainerCommands.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlZContainerCommands As System.Windows.Forms.Panel
    Protected Friend WithEvents btnClose As System.Windows.Forms.Button
    Protected Friend WithEvents btnSaveClose As System.Windows.Forms.Button
    Protected Friend WithEvents bntSave As System.Windows.Forms.Button
    Protected Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents lblPropertyBeindEdited As System.Windows.Forms.Label
    Protected Friend WithEvents btnSetToNull As System.Windows.Forms.Button
End Class
