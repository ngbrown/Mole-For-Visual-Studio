<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
    Me.PictureBox1 = New System.Windows.Forms.PictureBox
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.GroupBox1 = New System.Windows.Forms.GroupBox
    Me.RadioButton3 = New System.Windows.Forms.RadioButton
    Me.RadioButton2 = New System.Windows.Forms.RadioButton
    Me.RadioButton1 = New System.Windows.Forms.RadioButton
    Me.ComboBox1 = New System.Windows.Forms.ComboBox
    Me.Button1 = New System.Windows.Forms.Button
    Me.DataGridView1 = New System.Windows.Forms.DataGridView
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.Panel1.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'PictureBox1
    '
    Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
    Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
    Me.PictureBox1.Location = New System.Drawing.Point(16, 19)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(188, 127)
    Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
    Me.PictureBox1.TabIndex = 0
    Me.PictureBox1.TabStop = False
    '
    'Panel1
    '
    Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
    Me.Panel1.Controls.Add(Me.GroupBox1)
    Me.Panel1.Controls.Add(Me.Button1)
    Me.Panel1.Controls.Add(Me.DataGridView1)
    Me.Panel1.Controls.Add(Me.PictureBox1)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Panel1.Location = New System.Drawing.Point(10, 10)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(500, 390)
    Me.Panel1.TabIndex = 1
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.RadioButton3)
    Me.GroupBox1.Controls.Add(Me.RadioButton2)
    Me.GroupBox1.Controls.Add(Me.RadioButton1)
    Me.GroupBox1.Controls.Add(Me.ComboBox1)
    Me.GroupBox1.ForeColor = System.Drawing.Color.Red
    Me.GroupBox1.Location = New System.Drawing.Point(219, 19)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(265, 127)
    Me.GroupBox1.TabIndex = 5
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Top Secret Data"
    '
    'RadioButton3
    '
    Me.RadioButton3.AutoSize = True
    Me.RadioButton3.Location = New System.Drawing.Point(17, 81)
    Me.RadioButton3.Name = "RadioButton3"
    Me.RadioButton3.Size = New System.Drawing.Size(90, 17)
    Me.RadioButton3.TabIndex = 2
    Me.RadioButton3.TabStop = True
    Me.RadioButton3.Text = "RadioButton3"
    Me.RadioButton3.UseVisualStyleBackColor = True
    '
    'RadioButton2
    '
    Me.RadioButton2.AutoSize = True
    Me.RadioButton2.Location = New System.Drawing.Point(17, 50)
    Me.RadioButton2.Name = "RadioButton2"
    Me.RadioButton2.Size = New System.Drawing.Size(90, 17)
    Me.RadioButton2.TabIndex = 1
    Me.RadioButton2.TabStop = True
    Me.RadioButton2.Text = "RadioButton2"
    Me.RadioButton2.UseVisualStyleBackColor = True
    '
    'RadioButton1
    '
    Me.RadioButton1.AutoSize = True
    Me.RadioButton1.Location = New System.Drawing.Point(17, 19)
    Me.RadioButton1.Name = "RadioButton1"
    Me.RadioButton1.Size = New System.Drawing.Size(90, 17)
    Me.RadioButton1.TabIndex = 0
    Me.RadioButton1.TabStop = True
    Me.RadioButton1.Text = "RadioButton1"
    Me.RadioButton1.UseVisualStyleBackColor = True
    '
    'ComboBox1
    '
    Me.ComboBox1.FormattingEnabled = True
    Me.ComboBox1.Items.AddRange(New Object() {"Use Mole Now", "Use Mole Later"})
    Me.ComboBox1.Location = New System.Drawing.Point(147, 50)
    Me.ComboBox1.Name = "ComboBox1"
    Me.ComboBox1.Size = New System.Drawing.Size(100, 21)
    Me.ComboBox1.TabIndex = 2
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(109, 331)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(272, 38)
    Me.Button1.TabIndex = 4
    Me.Button1.Text = "Click To Molenate"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'DataGridView1
    '
    Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DataGridView1.Location = New System.Drawing.Point(16, 171)
    Me.DataGridView1.Name = "DataGridView1"
    Me.DataGridView1.Size = New System.Drawing.Size(468, 141)
    Me.DataGridView1.TabIndex = 3
    '
    'Form1
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.SystemColors.ActiveCaption
    Me.ClientSize = New System.Drawing.Size(520, 410)
    Me.Controls.Add(Me.Panel1)
    Me.Name = "Form1"
    Me.Padding = New System.Windows.Forms.Padding(10)
    Me.Text = "Mole For Visual Studio - WinForms Test Bench"
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView

End Class
