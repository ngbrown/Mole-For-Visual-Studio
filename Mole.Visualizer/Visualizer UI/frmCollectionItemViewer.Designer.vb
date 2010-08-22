<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCollectionItemViewer
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
        Me.lblObjectDataType = New System.Windows.Forms.Label
        Me.pnlContainer = New System.Windows.Forms.Panel
        Me.SuspendLayout()
        '
        'lblObjectDataType
        '
        Me.lblObjectDataType.AutoSize = True
        Me.lblObjectDataType.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblObjectDataType.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObjectDataType.Location = New System.Drawing.Point(0, 0)
        Me.lblObjectDataType.Margin = New System.Windows.Forms.Padding(0)
        Me.lblObjectDataType.Name = "lblObjectDataType"
        Me.lblObjectDataType.Padding = New System.Windows.Forms.Padding(5)
        Me.lblObjectDataType.Size = New System.Drawing.Size(10, 27)
        Me.lblObjectDataType.TabIndex = 3
        '
        'pnlContainer
        '
        Me.pnlContainer.AutoScroll = True
        Me.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContainer.Location = New System.Drawing.Point(0, 27)
        Me.pnlContainer.Name = "pnlContainer"
        Me.pnlContainer.Size = New System.Drawing.Size(884, 437)
        Me.pnlContainer.TabIndex = 4
        '
        'frmCollectionItemViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 464)
        Me.Controls.Add(Me.pnlContainer)
        Me.Controls.Add(Me.lblObjectDataType)
        Me.MinimizeBox = False
        Me.Name = "frmCollectionItemViewer"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mole For Visual Studio - Collection Items Viewer"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblObjectDataType As System.Windows.Forms.Label
    Friend WithEvents pnlContainer As System.Windows.Forms.Panel
End Class
