<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMole
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If

            If Me.webXAML IsNot Nothing Then
                Me.webXAML.Dispose()
                Me.webXAML = Nothing
            End If

            If Me.BackgroundWokerLoadVisualTree IsNot Nothing Then
                Me.BackgroundWokerLoadVisualTree.Dispose()
            End If

            If Me.ttMoleTips IsNot Nothing Then
                Me.ttMoleTips.RemoveAll()
                Me.ttMoleTips.Dispose()
                Me.ttMoleTips = Nothing
            End If

            For intX As Integer = 0 To _objElementBitmaps.Count - 1
                _objElementBitmaps(intX).Dispose()
            Next
            If _editColumnImage IsNot Nothing Then
                _editColumnImage.Dispose()
                _editColumnImage = Nothing
            End If

            If _objElementBitmaps IsNot Nothing Then
                _objElementBitmaps.Clear()
                _objElementBitmaps = Nothing
            End If

            If _fontMoloscopeClickableHeader IsNot Nothing Then
                _fontMoloscopeClickableHeader.Dispose()
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ttMoleTips = New System.Windows.Forms.ToolTip(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.tcMoleTreeViews = New System.Windows.Forms.TabControl
        Me.tpVisualTree = New System.Windows.Forms.TabPage
        Me.tvVisualTree = New Mole.MoleTreeView
        Me.tpLogicalTree = New System.Windows.Forms.TabPage
        Me.tvLogicalTree = New Mole.MoleTreeView
        Me.lblLogicalTreeInfo = New System.Windows.Forms.Label
        Me.pnlZContainerTreeViewCommands = New System.Windows.Forms.Panel
        Me.btnSelectInitalVisualNode = New System.Windows.Forms.Button
        Me.btnCollapseDown = New System.Windows.Forms.Button
        Me.btnExpandDown = New System.Windows.Forms.Button
        Me.btnCollapseAll = New System.Windows.Forms.Button
        Me.btnExpandAll = New System.Windows.Forms.Button
        Me.tcProperties = New System.Windows.Forms.TabControl
        Me.tpProperties = New System.Windows.Forms.TabPage
        Me.dgvProperties = New System.Windows.Forms.DataGridView
        Me.mcMoleCrumbs = New Mole.MoleCrumbs
        Me.pnlZContainerPropertiesStatus = New System.Windows.Forms.Panel
        Me.rtbPropertiesStatus = New System.Windows.Forms.RichTextBox
        Me.pnlZContainerPropertiesCommands = New System.Windows.Forms.Panel
        Me.cbHideMatching = New System.Windows.Forms.CheckBox
        Me.btnLoadProperties = New System.Windows.Forms.Button
        Me.btnSaveProperties = New System.Windows.Forms.Button
        Me.cbShowNamespaces = New System.Windows.Forms.CheckBox
        Me.cbShowBlackOps = New System.Windows.Forms.CheckBox
        Me.btnClearSearch = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtSearchText = New System.Windows.Forms.TextBox
        Me.cboLookIn = New System.Windows.Forms.ComboBox
        Me.cbShowAttachedProperties = New System.Windows.Forms.CheckBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.tpVisual = New System.Windows.Forms.TabPage
        Me.pnlVisualPictureBoxScroller = New System.Windows.Forms.Panel
        Me.pbVisual = New System.Windows.Forms.PictureBox
        Me.pnlZContainerVisualCommands = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnCopyImageToClipBoard = New System.Windows.Forms.Button
        Me.pnlZContainerVisualStatus = New System.Windows.Forms.Panel
        Me.rtbVisualStatus = New System.Windows.Forms.RichTextBox
        Me.tpXAML = New System.Windows.Forms.TabPage
        Me.pnlZContainerWebBrowswer = New System.Windows.Forms.Panel
        Me.webXAML = New System.Windows.Forms.WebBrowser
        Me.pnlZContainerXAMLCommands = New System.Windows.Forms.Panel
        Me.rdoViewHTMLAttributesOnSingleLine = New System.Windows.Forms.RadioButton
        Me.rdoViewHTMLAttributesOnSeparateLine = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnDecreaseFontSize = New System.Windows.Forms.Button
        Me.btnIncreaseFontSize = New System.Windows.Forms.Button
        Me.pnlZContainerXAMLStatus = New System.Windows.Forms.Panel
        Me.rtbXAMLStatus = New System.Windows.Forms.RichTextBox
        Me.tpFavorites = New System.Windows.Forms.TabPage
        Me.lbFavorites = New System.Windows.Forms.ListBox
        Me.pnlZContainerClearFavorites = New System.Windows.Forms.Panel
        Me.btnClearFavorites = New System.Windows.Forms.Button
        Me.pnlZContainerFavoritesStatus = New System.Windows.Forms.Panel
        Me.lblFavoritesStatus = New System.Windows.Forms.Label
        Me.tpOptions = New System.Windows.Forms.TabPage
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.rdoVB = New System.Windows.Forms.RadioButton
        Me.rdoC = New System.Windows.Forms.RadioButton
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.trackBarMaxRowsInCollectionData = New System.Windows.Forms.TrackBar
        Me.lblMaxRowsInCollectionData = New System.Windows.Forms.Label
        Me.llSavedSettingsFile = New System.Windows.Forms.LinkLabel
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cbHideIsDependencyPropertyColumn = New System.Windows.Forms.CheckBox
        Me.cbHideValueSourceColumn = New System.Windows.Forms.CheckBox
        Me.cbHideCategoryColumn = New System.Windows.Forms.CheckBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.llAndrewsblog = New System.Windows.Forms.LinkLabel
        Me.lblVersion = New System.Windows.Forms.Label
        Me.llKarlsBlog = New System.Windows.Forms.LinkLabel
        Me.llJoshsBlog = New System.Windows.Forms.LinkLabel
        Me.llMolesHomePage = New System.Windows.Forms.LinkLabel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.trackBarToolTipInitialDelay = New System.Windows.Forms.TrackBar
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblToolTipDelay = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.BackgroundWokerLoadVisualTree = New System.ComponentModel.BackgroundWorker
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.tcMoleTreeViews.SuspendLayout()
        Me.tpVisualTree.SuspendLayout()
        Me.tpLogicalTree.SuspendLayout()
        Me.pnlZContainerTreeViewCommands.SuspendLayout()
        Me.tcProperties.SuspendLayout()
        Me.tpProperties.SuspendLayout()
        CType(Me.dgvProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlZContainerPropertiesStatus.SuspendLayout()
        Me.pnlZContainerPropertiesCommands.SuspendLayout()
        Me.tpVisual.SuspendLayout()
        Me.pnlVisualPictureBoxScroller.SuspendLayout()
        CType(Me.pbVisual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlZContainerVisualCommands.SuspendLayout()
        Me.pnlZContainerVisualStatus.SuspendLayout()
        Me.tpXAML.SuspendLayout()
        Me.pnlZContainerWebBrowswer.SuspendLayout()
        Me.pnlZContainerXAMLCommands.SuspendLayout()
        Me.pnlZContainerXAMLStatus.SuspendLayout()
        Me.tpFavorites.SuspendLayout()
        Me.pnlZContainerClearFavorites.SuspendLayout()
        Me.pnlZContainerFavoritesStatus.SuspendLayout()
        Me.tpOptions.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.trackBarMaxRowsInCollectionData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.trackBarToolTipInitialDelay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ttMoleTips
        '
        Me.ttMoleTips.IsBalloon = True
        Me.ttMoleTips.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ttMoleTips.ToolTipTitle = "Mole Says"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer1.Panel1.Controls.Add(Me.tcMoleTreeViews)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pnlZContainerTreeViewCommands)
        Me.SplitContainer1.Panel1MinSize = 263
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer1.Panel2.Controls.Add(Me.tcProperties)
        Me.SplitContainer1.Size = New System.Drawing.Size(1008, 566)
        Me.SplitContainer1.SplitterDistance = 263
        Me.SplitContainer1.SplitterWidth = 6
        Me.SplitContainer1.TabIndex = 0
        Me.ttMoleTips.SetToolTip(Me.SplitContainer1, "Resize panels with this splitter.")
        '
        'tcMoleTreeViews
        '
        Me.tcMoleTreeViews.Controls.Add(Me.tpVisualTree)
        Me.tcMoleTreeViews.Controls.Add(Me.tpLogicalTree)
        Me.tcMoleTreeViews.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcMoleTreeViews.ItemSize = New System.Drawing.Size(63, 20)
        Me.tcMoleTreeViews.Location = New System.Drawing.Point(0, 0)
        Me.tcMoleTreeViews.Name = "tcMoleTreeViews"
        Me.tcMoleTreeViews.SelectedIndex = 0
        Me.tcMoleTreeViews.Size = New System.Drawing.Size(263, 462)
        Me.tcMoleTreeViews.TabIndex = 0
        '
        'tpVisualTree
        '
        Me.tpVisualTree.BackColor = System.Drawing.SystemColors.Control
        Me.tpVisualTree.Controls.Add(Me.tvVisualTree)
        Me.tpVisualTree.ImageKey = "(none)"
        Me.tpVisualTree.Location = New System.Drawing.Point(4, 24)
        Me.tpVisualTree.Name = "tpVisualTree"
        Me.tpVisualTree.Padding = New System.Windows.Forms.Padding(3)
        Me.tpVisualTree.Size = New System.Drawing.Size(255, 434)
        Me.tpVisualTree.TabIndex = 0
        Me.tpVisualTree.Text = "Loading..."
        '
        'tvVisualTree
        '
        Me.tvVisualTree.BackColor = System.Drawing.Color.White
        Me.tvVisualTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tvVisualTree.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvVisualTree.HideSelection = False
        Me.tvVisualTree.Location = New System.Drawing.Point(3, 3)
        Me.tvVisualTree.Name = "tvVisualTree"
        Me.tvVisualTree.ShowNodeToolTips = True
        Me.tvVisualTree.Size = New System.Drawing.Size(249, 428)
        Me.tvVisualTree.TabIndex = 0
        '
        'tpLogicalTree
        '
        Me.tpLogicalTree.Controls.Add(Me.tvLogicalTree)
        Me.tpLogicalTree.Controls.Add(Me.lblLogicalTreeInfo)
        Me.tpLogicalTree.Location = New System.Drawing.Point(4, 24)
        Me.tpLogicalTree.Name = "tpLogicalTree"
        Me.tpLogicalTree.Padding = New System.Windows.Forms.Padding(3)
        Me.tpLogicalTree.Size = New System.Drawing.Size(255, 434)
        Me.tpLogicalTree.TabIndex = 1
        Me.tpLogicalTree.Text = "Logical Tree"
        Me.tpLogicalTree.UseVisualStyleBackColor = True
        '
        'tvLogicalTree
        '
        Me.tvLogicalTree.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tvLogicalTree.HideSelection = False
        Me.tvLogicalTree.Location = New System.Drawing.Point(3, 3)
        Me.tvLogicalTree.Name = "tvLogicalTree"
        Me.tvLogicalTree.ShowNodeToolTips = True
        Me.tvLogicalTree.Size = New System.Drawing.Size(249, 368)
        Me.tvLogicalTree.TabIndex = 0
        '
        'lblLogicalTreeInfo
        '
        Me.lblLogicalTreeInfo.BackColor = System.Drawing.SystemColors.ControlLight
        Me.lblLogicalTreeInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLogicalTreeInfo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblLogicalTreeInfo.Location = New System.Drawing.Point(3, 371)
        Me.lblLogicalTreeInfo.Name = "lblLogicalTreeInfo"
        Me.lblLogicalTreeInfo.Padding = New System.Windows.Forms.Padding(2)
        Me.lblLogicalTreeInfo.Size = New System.Drawing.Size(249, 60)
        Me.lblLogicalTreeInfo.TabIndex = 2
        Me.lblLogicalTreeInfo.Text = "logical tree info..."
        Me.lblLogicalTreeInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlZContainerTreeViewCommands
        '
        Me.pnlZContainerTreeViewCommands.BackColor = System.Drawing.SystemColors.Control
        Me.pnlZContainerTreeViewCommands.Controls.Add(Me.btnSelectInitalVisualNode)
        Me.pnlZContainerTreeViewCommands.Controls.Add(Me.btnCollapseDown)
        Me.pnlZContainerTreeViewCommands.Controls.Add(Me.btnExpandDown)
        Me.pnlZContainerTreeViewCommands.Controls.Add(Me.btnCollapseAll)
        Me.pnlZContainerTreeViewCommands.Controls.Add(Me.btnExpandAll)
        Me.pnlZContainerTreeViewCommands.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlZContainerTreeViewCommands.Location = New System.Drawing.Point(0, 462)
        Me.pnlZContainerTreeViewCommands.Name = "pnlZContainerTreeViewCommands"
        Me.pnlZContainerTreeViewCommands.Size = New System.Drawing.Size(263, 104)
        Me.pnlZContainerTreeViewCommands.TabIndex = 2
        '
        'btnSelectInitalVisualNode
        '
        Me.btnSelectInitalVisualNode.BackColor = System.Drawing.SystemColors.Control
        Me.btnSelectInitalVisualNode.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSelectInitalVisualNode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSelectInitalVisualNode.Location = New System.Drawing.Point(9, 8)
        Me.btnSelectInitalVisualNode.Name = "btnSelectInitalVisualNode"
        Me.btnSelectInitalVisualNode.Size = New System.Drawing.Size(101, 23)
        Me.btnSelectInitalVisualNode.TabIndex = 0
        Me.btnSelectInitalVisualNode.Text = "&Select Initial"
        Me.ttMoleTips.SetToolTip(Me.btnSelectInitalVisualNode, "Click to view the inital visual element that was selected in the debugger.")
        Me.btnSelectInitalVisualNode.UseVisualStyleBackColor = True
        '
        'btnCollapseDown
        '
        Me.btnCollapseDown.BackColor = System.Drawing.SystemColors.Control
        Me.btnCollapseDown.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCollapseDown.Location = New System.Drawing.Point(139, 70)
        Me.btnCollapseDown.Name = "btnCollapseDown"
        Me.btnCollapseDown.Size = New System.Drawing.Size(101, 23)
        Me.btnCollapseDown.TabIndex = 4
        Me.btnCollapseDown.Text = "Collapse Do&wn"
        Me.ttMoleTips.SetToolTip(Me.btnCollapseDown, "Click to collapse selected tree node and all nodes below.")
        Me.btnCollapseDown.UseVisualStyleBackColor = True
        '
        'btnExpandDown
        '
        Me.btnExpandDown.BackColor = System.Drawing.SystemColors.Control
        Me.btnExpandDown.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnExpandDown.Location = New System.Drawing.Point(139, 39)
        Me.btnExpandDown.Name = "btnExpandDown"
        Me.btnExpandDown.Size = New System.Drawing.Size(101, 23)
        Me.btnExpandDown.TabIndex = 3
        Me.btnExpandDown.Text = "Expand &Down"
        Me.ttMoleTips.SetToolTip(Me.btnExpandDown, "Click to expand selected tree node and all nodes below.")
        Me.btnExpandDown.UseVisualStyleBackColor = True
        '
        'btnCollapseAll
        '
        Me.btnCollapseAll.BackColor = System.Drawing.SystemColors.Control
        Me.btnCollapseAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCollapseAll.Location = New System.Drawing.Point(9, 70)
        Me.btnCollapseAll.Name = "btnCollapseAll"
        Me.btnCollapseAll.Size = New System.Drawing.Size(101, 23)
        Me.btnCollapseAll.TabIndex = 2
        Me.btnCollapseAll.Text = "&Collapse All"
        Me.ttMoleTips.SetToolTip(Me.btnCollapseAll, "Click to collapse all tree nodes.")
        Me.btnCollapseAll.UseVisualStyleBackColor = True
        '
        'btnExpandAll
        '
        Me.btnExpandAll.BackColor = System.Drawing.SystemColors.Control
        Me.btnExpandAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnExpandAll.Location = New System.Drawing.Point(9, 39)
        Me.btnExpandAll.Name = "btnExpandAll"
        Me.btnExpandAll.Size = New System.Drawing.Size(101, 23)
        Me.btnExpandAll.TabIndex = 1
        Me.btnExpandAll.Text = "&Expand All"
        Me.ttMoleTips.SetToolTip(Me.btnExpandAll, "Click to expand all tree nodes.")
        Me.btnExpandAll.UseVisualStyleBackColor = True
        '
        'tcProperties
        '
        Me.tcProperties.Controls.Add(Me.tpProperties)
        Me.tcProperties.Controls.Add(Me.tpVisual)
        Me.tcProperties.Controls.Add(Me.tpXAML)
        Me.tcProperties.Controls.Add(Me.tpFavorites)
        Me.tcProperties.Controls.Add(Me.tpOptions)
        Me.tcProperties.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcProperties.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tcProperties.ItemSize = New System.Drawing.Size(63, 20)
        Me.tcProperties.Location = New System.Drawing.Point(0, 0)
        Me.tcProperties.Name = "tcProperties"
        Me.tcProperties.SelectedIndex = 0
        Me.tcProperties.Size = New System.Drawing.Size(739, 566)
        Me.tcProperties.TabIndex = 0
        '
        'tpProperties
        '
        Me.tpProperties.BackColor = System.Drawing.SystemColors.Control
        Me.tpProperties.Controls.Add(Me.dgvProperties)
        Me.tpProperties.Controls.Add(Me.mcMoleCrumbs)
        Me.tpProperties.Controls.Add(Me.pnlZContainerPropertiesStatus)
        Me.tpProperties.Controls.Add(Me.pnlZContainerPropertiesCommands)
        Me.tpProperties.Controls.Add(Me.btnCancel)
        Me.tpProperties.ImageKey = "(none)"
        Me.tpProperties.Location = New System.Drawing.Point(4, 24)
        Me.tpProperties.Name = "tpProperties"
        Me.tpProperties.Padding = New System.Windows.Forms.Padding(3)
        Me.tpProperties.Size = New System.Drawing.Size(731, 538)
        Me.tpProperties.TabIndex = 0
        Me.tpProperties.Text = "Element Properties"
        '
        'dgvProperties
        '
        Me.dgvProperties.AllowUserToAddRows = False
        Me.dgvProperties.AllowUserToDeleteRows = False
        Me.dgvProperties.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.dgvProperties.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProperties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvProperties.BackgroundColor = System.Drawing.Color.Silver
        Me.dgvProperties.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProperties.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProperties.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvProperties.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProperties.GridColor = System.Drawing.SystemColors.Control
        Me.dgvProperties.Location = New System.Drawing.Point(3, 33)
        Me.dgvProperties.Name = "dgvProperties"
        Me.dgvProperties.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProperties.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvProperties.RowHeadersVisible = False
        Me.dgvProperties.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        Me.dgvProperties.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvProperties.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProperties.Size = New System.Drawing.Size(725, 398)
        Me.dgvProperties.TabIndex = 0
        '
        'mcMoleCrumbs
        '
        Me.mcMoleCrumbs.AutoSize = True
        Me.mcMoleCrumbs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.mcMoleCrumbs.BackColor = System.Drawing.Color.WhiteSmoke
        Me.mcMoleCrumbs.Dock = System.Windows.Forms.DockStyle.Top
        Me.mcMoleCrumbs.Location = New System.Drawing.Point(3, 33)
        Me.mcMoleCrumbs.Margin = New System.Windows.Forms.Padding(0)
        Me.mcMoleCrumbs.Name = "mcMoleCrumbs"
        Me.mcMoleCrumbs.Size = New System.Drawing.Size(725, 0)
        Me.mcMoleCrumbs.TabIndex = 4
        '
        'pnlZContainerPropertiesStatus
        '
        Me.pnlZContainerPropertiesStatus.BackColor = System.Drawing.Color.Transparent
        Me.pnlZContainerPropertiesStatus.Controls.Add(Me.rtbPropertiesStatus)
        Me.pnlZContainerPropertiesStatus.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlZContainerPropertiesStatus.Location = New System.Drawing.Point(3, 3)
        Me.pnlZContainerPropertiesStatus.Name = "pnlZContainerPropertiesStatus"
        Me.pnlZContainerPropertiesStatus.Size = New System.Drawing.Size(725, 30)
        Me.pnlZContainerPropertiesStatus.TabIndex = 3
        '
        'rtbPropertiesStatus
        '
        Me.rtbPropertiesStatus.BackColor = System.Drawing.SystemColors.Control
        Me.rtbPropertiesStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbPropertiesStatus.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.rtbPropertiesStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbPropertiesStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rtbPropertiesStatus.Location = New System.Drawing.Point(0, 8)
        Me.rtbPropertiesStatus.Multiline = False
        Me.rtbPropertiesStatus.Name = "rtbPropertiesStatus"
        Me.rtbPropertiesStatus.ReadOnly = True
        Me.rtbPropertiesStatus.Size = New System.Drawing.Size(725, 22)
        Me.rtbPropertiesStatus.TabIndex = 0
        Me.rtbPropertiesStatus.TabStop = False
        Me.rtbPropertiesStatus.Text = ""
        '
        'pnlZContainerPropertiesCommands
        '
        Me.pnlZContainerPropertiesCommands.BackColor = System.Drawing.Color.Transparent
        Me.pnlZContainerPropertiesCommands.Controls.Add(Me.cbHideMatching)
        Me.pnlZContainerPropertiesCommands.Controls.Add(Me.btnLoadProperties)
        Me.pnlZContainerPropertiesCommands.Controls.Add(Me.btnSaveProperties)
        Me.pnlZContainerPropertiesCommands.Controls.Add(Me.cbShowNamespaces)
        Me.pnlZContainerPropertiesCommands.Controls.Add(Me.cbShowBlackOps)
        Me.pnlZContainerPropertiesCommands.Controls.Add(Me.btnClearSearch)
        Me.pnlZContainerPropertiesCommands.Controls.Add(Me.Label4)
        Me.pnlZContainerPropertiesCommands.Controls.Add(Me.Label3)
        Me.pnlZContainerPropertiesCommands.Controls.Add(Me.txtSearchText)
        Me.pnlZContainerPropertiesCommands.Controls.Add(Me.cboLookIn)
        Me.pnlZContainerPropertiesCommands.Controls.Add(Me.cbShowAttachedProperties)
        Me.pnlZContainerPropertiesCommands.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlZContainerPropertiesCommands.Location = New System.Drawing.Point(3, 431)
        Me.pnlZContainerPropertiesCommands.Name = "pnlZContainerPropertiesCommands"
        Me.pnlZContainerPropertiesCommands.Size = New System.Drawing.Size(725, 104)
        Me.pnlZContainerPropertiesCommands.TabIndex = 0
        '
        'cbHideMatching
        '
        Me.cbHideMatching.AutoSize = True
        Me.cbHideMatching.Enabled = False
        Me.cbHideMatching.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbHideMatching.Location = New System.Drawing.Point(446, 77)
        Me.cbHideMatching.Name = "cbHideMatching"
        Me.cbHideMatching.Size = New System.Drawing.Size(95, 17)
        Me.cbHideMatching.TabIndex = 10
        Me.cbHideMatching.Text = "Hide Matching"
        Me.ttMoleTips.SetToolTip(Me.cbHideMatching, "When enabled, filters all rows in property grid to only show those that the value" & _
                " and compare value do not match")
        Me.cbHideMatching.UseVisualStyleBackColor = True
        '
        'btnLoadProperties
        '
        Me.btnLoadProperties.Location = New System.Drawing.Point(445, 42)
        Me.btnLoadProperties.Name = "btnLoadProperties"
        Me.btnLoadProperties.Size = New System.Drawing.Size(96, 22)
        Me.btnLoadProperties.TabIndex = 9
        Me.btnLoadProperties.Text = "Load Properties"
        Me.btnLoadProperties.UseVisualStyleBackColor = True
        '
        'btnSaveProperties
        '
        Me.btnSaveProperties.Location = New System.Drawing.Point(445, 14)
        Me.btnSaveProperties.Name = "btnSaveProperties"
        Me.btnSaveProperties.Size = New System.Drawing.Size(96, 22)
        Me.btnSaveProperties.TabIndex = 8
        Me.btnSaveProperties.Text = "Save Properties"
        Me.btnSaveProperties.UseVisualStyleBackColor = True
        '
        'cbShowNamespaces
        '
        Me.cbShowNamespaces.AutoSize = True
        Me.cbShowNamespaces.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbShowNamespaces.Location = New System.Drawing.Point(116, 77)
        Me.cbShowNamespaces.Name = "cbShowNamespaces"
        Me.cbShowNamespaces.Size = New System.Drawing.Size(118, 17)
        Me.cbShowNamespaces.TabIndex = 6
        Me.cbShowNamespaces.Text = "Show &Namespaces"
        Me.ttMoleTips.SetToolTip(Me.cbShowNamespaces, "Allows the namespaces to be displayed along with the Type names")
        Me.cbShowNamespaces.UseVisualStyleBackColor = True
        '
        'cbShowBlackOps
        '
        Me.cbShowBlackOps.AutoSize = True
        Me.cbShowBlackOps.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbShowBlackOps.Location = New System.Drawing.Point(11, 77)
        Me.cbShowBlackOps.Name = "cbShowBlackOps"
        Me.cbShowBlackOps.Size = New System.Drawing.Size(83, 17)
        Me.cbShowBlackOps.TabIndex = 5
        Me.cbShowBlackOps.Text = "Show &Fields"
        Me.ttMoleTips.SetToolTip(Me.cbShowBlackOps, "Allows the viewing or hiding of non-public members" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        Me.cbShowBlackOps.UseVisualStyleBackColor = True
        '
        'btnClearSearch
        '
        Me.btnClearSearch.AutoSize = True
        Me.btnClearSearch.BackColor = System.Drawing.SystemColors.Control
        Me.btnClearSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClearSearch.Location = New System.Drawing.Point(370, 14)
        Me.btnClearSearch.Name = "btnClearSearch"
        Me.btnClearSearch.Size = New System.Drawing.Size(25, 23)
        Me.btnClearSearch.TabIndex = 2
        Me.btnClearSearch.Text = "X"
        Me.ttMoleTips.SetToolTip(Me.btnClearSearch, "Click to clear the search text")
        Me.btnClearSearch.UseVisualStyleBackColor = True
        Me.btnClearSearch.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label4.Location = New System.Drawing.Point(212, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(210, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Search Text    ( filters fields and properties )"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label3.Location = New System.Drawing.Point(8, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Select Search Location"
        '
        'txtSearchText
        '
        Me.txtSearchText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchText.Location = New System.Drawing.Point(215, 14)
        Me.txtSearchText.Name = "txtSearchText"
        Me.txtSearchText.Size = New System.Drawing.Size(158, 23)
        Me.txtSearchText.TabIndex = 1
        Me.ttMoleTips.SetToolTip(Me.txtSearchText, "Enter text to search for.  The combo box on the left determines where the search " & _
                "will look." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Search does not effect favorites only normal and fields rows.")
        '
        'cboLookIn
        '
        Me.cboLookIn.BackColor = System.Drawing.Color.White
        Me.cboLookIn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLookIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLookIn.FormattingEnabled = True
        Me.cboLookIn.Items.AddRange(New Object() {"Name Beginning", "Name Anywhere", "Value Beginning", "Value Anywhere"})
        Me.cboLookIn.Location = New System.Drawing.Point(11, 14)
        Me.cboLookIn.Name = "cboLookIn"
        Me.cboLookIn.Size = New System.Drawing.Size(198, 24)
        Me.cboLookIn.TabIndex = 0
        Me.ttMoleTips.SetToolTip(Me.cboLookIn, "Select location to search.")
        '
        'cbShowAttachedProperties
        '
        Me.cbShowAttachedProperties.AutoSize = True
        Me.cbShowAttachedProperties.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbShowAttachedProperties.Location = New System.Drawing.Point(261, 77)
        Me.cbShowAttachedProperties.Name = "cbShowAttachedProperties"
        Me.cbShowAttachedProperties.Size = New System.Drawing.Size(149, 17)
        Me.cbShowAttachedProperties.TabIndex = 7
        Me.cbShowAttachedProperties.Text = "Show Attached &Properties"
        Me.ttMoleTips.SetToolTip(Me.cbShowAttachedProperties, "Allows the viewing or hiding of Attached Properteis in the above grid.")
        Me.cbShowAttachedProperties.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(14, 48)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(10, 10)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel "
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'tpVisual
        '
        Me.tpVisual.BackColor = System.Drawing.SystemColors.Control
        Me.tpVisual.Controls.Add(Me.pnlVisualPictureBoxScroller)
        Me.tpVisual.Controls.Add(Me.pnlZContainerVisualCommands)
        Me.tpVisual.Controls.Add(Me.pnlZContainerVisualStatus)
        Me.tpVisual.ForeColor = System.Drawing.Color.Silver
        Me.tpVisual.ImageKey = "(none)"
        Me.tpVisual.Location = New System.Drawing.Point(4, 24)
        Me.tpVisual.Name = "tpVisual"
        Me.tpVisual.Padding = New System.Windows.Forms.Padding(3)
        Me.tpVisual.Size = New System.Drawing.Size(731, 538)
        Me.tpVisual.TabIndex = 1
        Me.tpVisual.Text = "Element Visual"
        '
        'pnlVisualPictureBoxScroller
        '
        Me.pnlVisualPictureBoxScroller.AutoScroll = True
        Me.pnlVisualPictureBoxScroller.BackColor = System.Drawing.Color.White
        Me.pnlVisualPictureBoxScroller.Controls.Add(Me.pbVisual)
        Me.pnlVisualPictureBoxScroller.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlVisualPictureBoxScroller.ForeColor = System.Drawing.Color.Black
        Me.pnlVisualPictureBoxScroller.Location = New System.Drawing.Point(3, 33)
        Me.pnlVisualPictureBoxScroller.Name = "pnlVisualPictureBoxScroller"
        Me.pnlVisualPictureBoxScroller.Size = New System.Drawing.Size(725, 467)
        Me.pnlVisualPictureBoxScroller.TabIndex = 1
        '
        'pbVisual
        '
        Me.pbVisual.Location = New System.Drawing.Point(3, 3)
        Me.pbVisual.Name = "pbVisual"
        Me.pbVisual.Size = New System.Drawing.Size(85, 80)
        Me.pbVisual.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbVisual.TabIndex = 0
        Me.pbVisual.TabStop = False
        '
        'pnlZContainerVisualCommands
        '
        Me.pnlZContainerVisualCommands.BackColor = System.Drawing.SystemColors.Control
        Me.pnlZContainerVisualCommands.Controls.Add(Me.Label2)
        Me.pnlZContainerVisualCommands.Controls.Add(Me.btnCopyImageToClipBoard)
        Me.pnlZContainerVisualCommands.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlZContainerVisualCommands.Location = New System.Drawing.Point(3, 500)
        Me.pnlZContainerVisualCommands.Name = "pnlZContainerVisualCommands"
        Me.pnlZContainerVisualCommands.Size = New System.Drawing.Size(725, 35)
        Me.pnlZContainerVisualCommands.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label2.Location = New System.Drawing.Point(121, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(601, 35)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "This feature allows you to easily make screen prints of portions of your applicat" & _
            "ion."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCopyImageToClipBoard
        '
        Me.btnCopyImageToClipBoard.BackColor = System.Drawing.SystemColors.Control
        Me.btnCopyImageToClipBoard.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCopyImageToClipBoard.Location = New System.Drawing.Point(13, 6)
        Me.btnCopyImageToClipBoard.Name = "btnCopyImageToClipBoard"
        Me.btnCopyImageToClipBoard.Size = New System.Drawing.Size(87, 24)
        Me.btnCopyImageToClipBoard.TabIndex = 7
        Me.btnCopyImageToClipBoard.Text = "Copy Image"
        Me.ttMoleTips.SetToolTip(Me.btnCopyImageToClipBoard, "Click to copy image to clipboard")
        Me.btnCopyImageToClipBoard.UseVisualStyleBackColor = True
        '
        'pnlZContainerVisualStatus
        '
        Me.pnlZContainerVisualStatus.BackColor = System.Drawing.SystemColors.Control
        Me.pnlZContainerVisualStatus.Controls.Add(Me.rtbVisualStatus)
        Me.pnlZContainerVisualStatus.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlZContainerVisualStatus.Location = New System.Drawing.Point(3, 3)
        Me.pnlZContainerVisualStatus.Name = "pnlZContainerVisualStatus"
        Me.pnlZContainerVisualStatus.Size = New System.Drawing.Size(725, 30)
        Me.pnlZContainerVisualStatus.TabIndex = 4
        '
        'rtbVisualStatus
        '
        Me.rtbVisualStatus.BackColor = System.Drawing.SystemColors.Control
        Me.rtbVisualStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbVisualStatus.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.rtbVisualStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbVisualStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rtbVisualStatus.Location = New System.Drawing.Point(0, 8)
        Me.rtbVisualStatus.Multiline = False
        Me.rtbVisualStatus.Name = "rtbVisualStatus"
        Me.rtbVisualStatus.ReadOnly = True
        Me.rtbVisualStatus.Size = New System.Drawing.Size(725, 22)
        Me.rtbVisualStatus.TabIndex = 1
        Me.rtbVisualStatus.TabStop = False
        Me.rtbVisualStatus.Text = ""
        '
        'tpXAML
        '
        Me.tpXAML.BackColor = System.Drawing.SystemColors.Control
        Me.tpXAML.Controls.Add(Me.pnlZContainerWebBrowswer)
        Me.tpXAML.Controls.Add(Me.pnlZContainerXAMLCommands)
        Me.tpXAML.Controls.Add(Me.pnlZContainerXAMLStatus)
        Me.tpXAML.ImageKey = "(none)"
        Me.tpXAML.Location = New System.Drawing.Point(4, 24)
        Me.tpXAML.Name = "tpXAML"
        Me.tpXAML.Padding = New System.Windows.Forms.Padding(3)
        Me.tpXAML.Size = New System.Drawing.Size(731, 538)
        Me.tpXAML.TabIndex = 5
        Me.tpXAML.Text = "Element XAML"
        '
        'pnlZContainerWebBrowswer
        '
        Me.pnlZContainerWebBrowswer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlZContainerWebBrowswer.Controls.Add(Me.webXAML)
        Me.pnlZContainerWebBrowswer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlZContainerWebBrowswer.Location = New System.Drawing.Point(3, 33)
        Me.pnlZContainerWebBrowswer.Name = "pnlZContainerWebBrowswer"
        Me.pnlZContainerWebBrowswer.Size = New System.Drawing.Size(725, 428)
        Me.pnlZContainerWebBrowswer.TabIndex = 9
        '
        'webXAML
        '
        Me.webXAML.Dock = System.Windows.Forms.DockStyle.Fill
        Me.webXAML.Location = New System.Drawing.Point(0, 0)
        Me.webXAML.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webXAML.Name = "webXAML"
        Me.webXAML.Size = New System.Drawing.Size(723, 426)
        Me.webXAML.TabIndex = 3
        '
        'pnlZContainerXAMLCommands
        '
        Me.pnlZContainerXAMLCommands.Controls.Add(Me.rdoViewHTMLAttributesOnSingleLine)
        Me.pnlZContainerXAMLCommands.Controls.Add(Me.rdoViewHTMLAttributesOnSeparateLine)
        Me.pnlZContainerXAMLCommands.Controls.Add(Me.Label1)
        Me.pnlZContainerXAMLCommands.Controls.Add(Me.btnDecreaseFontSize)
        Me.pnlZContainerXAMLCommands.Controls.Add(Me.btnIncreaseFontSize)
        Me.pnlZContainerXAMLCommands.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlZContainerXAMLCommands.Location = New System.Drawing.Point(3, 461)
        Me.pnlZContainerXAMLCommands.Name = "pnlZContainerXAMLCommands"
        Me.pnlZContainerXAMLCommands.Size = New System.Drawing.Size(725, 74)
        Me.pnlZContainerXAMLCommands.TabIndex = 8
        '
        'rdoViewHTMLAttributesOnSingleLine
        '
        Me.rdoViewHTMLAttributesOnSingleLine.AutoSize = True
        Me.rdoViewHTMLAttributesOnSingleLine.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rdoViewHTMLAttributesOnSingleLine.Location = New System.Drawing.Point(422, 10)
        Me.rdoViewHTMLAttributesOnSingleLine.Name = "rdoViewHTMLAttributesOnSingleLine"
        Me.rdoViewHTMLAttributesOnSingleLine.Size = New System.Drawing.Size(225, 17)
        Me.rdoViewHTMLAttributesOnSingleLine.TabIndex = 9
        Me.rdoViewHTMLAttributesOnSingleLine.TabStop = True
        Me.rdoViewHTMLAttributesOnSingleLine.Text = "View With HTML Attributes On Single Line"
        Me.ttMoleTips.SetToolTip(Me.rdoViewHTMLAttributesOnSingleLine, "Click to display the HTML with object attributes " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "displayed on a single line." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This is collapsed view.")
        Me.rdoViewHTMLAttributesOnSingleLine.UseVisualStyleBackColor = True
        '
        'rdoViewHTMLAttributesOnSeparateLine
        '
        Me.rdoViewHTMLAttributesOnSeparateLine.AutoSize = True
        Me.rdoViewHTMLAttributesOnSeparateLine.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rdoViewHTMLAttributesOnSeparateLine.Location = New System.Drawing.Point(162, 9)
        Me.rdoViewHTMLAttributesOnSeparateLine.Name = "rdoViewHTMLAttributesOnSeparateLine"
        Me.rdoViewHTMLAttributesOnSeparateLine.Size = New System.Drawing.Size(244, 17)
        Me.rdoViewHTMLAttributesOnSeparateLine.TabIndex = 8
        Me.rdoViewHTMLAttributesOnSeparateLine.TabStop = True
        Me.rdoViewHTMLAttributesOnSeparateLine.Text = "View HTML With Attributes On Separate Lines"
        Me.ttMoleTips.SetToolTip(Me.rdoViewHTMLAttributesOnSeparateLine, "Click to display the HTML with object attributes " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "displayed on separate lines.  " & _
                "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This is expanded view.")
        Me.rdoViewHTMLAttributesOnSeparateLine.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label1.Location = New System.Drawing.Point(3, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(700, 31)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Right click enabled in the XAML viewer.  You can print or copy rendered HTML." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Us" & _
            "e view source command to view raw HTML."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnDecreaseFontSize
        '
        Me.btnDecreaseFontSize.BackColor = System.Drawing.SystemColors.Control
        Me.btnDecreaseFontSize.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDecreaseFontSize.Location = New System.Drawing.Point(82, 6)
        Me.btnDecreaseFontSize.Name = "btnDecreaseFontSize"
        Me.btnDecreaseFontSize.Size = New System.Drawing.Size(54, 24)
        Me.btnDecreaseFontSize.TabIndex = 7
        Me.btnDecreaseFontSize.Text = "Font -"
        Me.ttMoleTips.SetToolTip(Me.btnDecreaseFontSize, "Click to decrease the font size.  Minimum size is 6.")
        Me.btnDecreaseFontSize.UseVisualStyleBackColor = True
        '
        'btnIncreaseFontSize
        '
        Me.btnIncreaseFontSize.BackColor = System.Drawing.SystemColors.Control
        Me.btnIncreaseFontSize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnIncreaseFontSize.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnIncreaseFontSize.Location = New System.Drawing.Point(6, 6)
        Me.btnIncreaseFontSize.Name = "btnIncreaseFontSize"
        Me.btnIncreaseFontSize.Size = New System.Drawing.Size(54, 24)
        Me.btnIncreaseFontSize.TabIndex = 6
        Me.btnIncreaseFontSize.Text = "Font +"
        Me.ttMoleTips.SetToolTip(Me.btnIncreaseFontSize, "Click to increase the font size.  Maximum size is 36.")
        Me.btnIncreaseFontSize.UseVisualStyleBackColor = True
        '
        'pnlZContainerXAMLStatus
        '
        Me.pnlZContainerXAMLStatus.BackColor = System.Drawing.SystemColors.Control
        Me.pnlZContainerXAMLStatus.Controls.Add(Me.rtbXAMLStatus)
        Me.pnlZContainerXAMLStatus.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlZContainerXAMLStatus.Location = New System.Drawing.Point(3, 3)
        Me.pnlZContainerXAMLStatus.Name = "pnlZContainerXAMLStatus"
        Me.pnlZContainerXAMLStatus.Size = New System.Drawing.Size(725, 30)
        Me.pnlZContainerXAMLStatus.TabIndex = 4
        '
        'rtbXAMLStatus
        '
        Me.rtbXAMLStatus.BackColor = System.Drawing.SystemColors.Control
        Me.rtbXAMLStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbXAMLStatus.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.rtbXAMLStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbXAMLStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rtbXAMLStatus.Location = New System.Drawing.Point(0, 8)
        Me.rtbXAMLStatus.Multiline = False
        Me.rtbXAMLStatus.Name = "rtbXAMLStatus"
        Me.rtbXAMLStatus.ReadOnly = True
        Me.rtbXAMLStatus.Size = New System.Drawing.Size(725, 22)
        Me.rtbXAMLStatus.TabIndex = 1
        Me.rtbXAMLStatus.TabStop = False
        Me.rtbXAMLStatus.Text = ""
        '
        'tpFavorites
        '
        Me.tpFavorites.BackColor = System.Drawing.SystemColors.Control
        Me.tpFavorites.Controls.Add(Me.lbFavorites)
        Me.tpFavorites.Controls.Add(Me.pnlZContainerClearFavorites)
        Me.tpFavorites.Controls.Add(Me.pnlZContainerFavoritesStatus)
        Me.tpFavorites.ImageKey = "(none)"
        Me.tpFavorites.Location = New System.Drawing.Point(4, 24)
        Me.tpFavorites.Name = "tpFavorites"
        Me.tpFavorites.Padding = New System.Windows.Forms.Padding(3)
        Me.tpFavorites.Size = New System.Drawing.Size(731, 538)
        Me.tpFavorites.TabIndex = 2
        Me.tpFavorites.Text = "Favorites"
        '
        'lbFavorites
        '
        Me.lbFavorites.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbFavorites.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbFavorites.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFavorites.FormattingEnabled = True
        Me.lbFavorites.ItemHeight = 16
        Me.lbFavorites.Location = New System.Drawing.Point(3, 33)
        Me.lbFavorites.Name = "lbFavorites"
        Me.lbFavorites.SelectionMode = System.Windows.Forms.SelectionMode.None
        Me.lbFavorites.Size = New System.Drawing.Size(725, 450)
        Me.lbFavorites.TabIndex = 2
        '
        'pnlZContainerClearFavorites
        '
        Me.pnlZContainerClearFavorites.Controls.Add(Me.btnClearFavorites)
        Me.pnlZContainerClearFavorites.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlZContainerClearFavorites.Location = New System.Drawing.Point(3, 493)
        Me.pnlZContainerClearFavorites.Name = "pnlZContainerClearFavorites"
        Me.pnlZContainerClearFavorites.Size = New System.Drawing.Size(725, 42)
        Me.pnlZContainerClearFavorites.TabIndex = 3
        '
        'btnClearFavorites
        '
        Me.btnClearFavorites.ForeColor = System.Drawing.Color.Red
        Me.btnClearFavorites.Location = New System.Drawing.Point(12, 11)
        Me.btnClearFavorites.Name = "btnClearFavorites"
        Me.btnClearFavorites.Size = New System.Drawing.Size(154, 23)
        Me.btnClearFavorites.TabIndex = 0
        Me.btnClearFavorites.Text = "Clear Favorites"
        Me.ttMoleTips.SetToolTip(Me.btnClearFavorites, "Click to remove all saved favorites")
        Me.btnClearFavorites.UseVisualStyleBackColor = True
        '
        'pnlZContainerFavoritesStatus
        '
        Me.pnlZContainerFavoritesStatus.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlZContainerFavoritesStatus.Controls.Add(Me.lblFavoritesStatus)
        Me.pnlZContainerFavoritesStatus.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlZContainerFavoritesStatus.Location = New System.Drawing.Point(3, 3)
        Me.pnlZContainerFavoritesStatus.Name = "pnlZContainerFavoritesStatus"
        Me.pnlZContainerFavoritesStatus.Size = New System.Drawing.Size(725, 30)
        Me.pnlZContainerFavoritesStatus.TabIndex = 1
        '
        'lblFavoritesStatus
        '
        Me.lblFavoritesStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblFavoritesStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFavoritesStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFavoritesStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFavoritesStatus.Location = New System.Drawing.Point(0, 0)
        Me.lblFavoritesStatus.Name = "lblFavoritesStatus"
        Me.lblFavoritesStatus.Size = New System.Drawing.Size(725, 30)
        Me.lblFavoritesStatus.TabIndex = 0
        Me.lblFavoritesStatus.Text = "Favorite Properties"
        Me.lblFavoritesStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tpOptions
        '
        Me.tpOptions.BackColor = System.Drawing.SystemColors.Control
        Me.tpOptions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.tpOptions.Controls.Add(Me.GroupBox5)
        Me.tpOptions.Controls.Add(Me.GroupBox4)
        Me.tpOptions.Controls.Add(Me.llSavedSettingsFile)
        Me.tpOptions.Controls.Add(Me.GroupBox3)
        Me.tpOptions.Controls.Add(Me.Label10)
        Me.tpOptions.Controls.Add(Me.Label9)
        Me.tpOptions.Controls.Add(Me.GroupBox2)
        Me.tpOptions.Controls.Add(Me.GroupBox1)
        Me.tpOptions.Controls.Add(Me.Label8)
        Me.tpOptions.ForeColor = System.Drawing.SystemColors.ControlText
        Me.tpOptions.ImageKey = "(none)"
        Me.tpOptions.Location = New System.Drawing.Point(4, 24)
        Me.tpOptions.Name = "tpOptions"
        Me.tpOptions.Padding = New System.Windows.Forms.Padding(3)
        Me.tpOptions.Size = New System.Drawing.Size(731, 538)
        Me.tpOptions.TabIndex = 6
        Me.tpOptions.Text = "Options"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.rdoVB)
        Me.GroupBox5.Controls.Add(Me.rdoC)
        Me.GroupBox5.Location = New System.Drawing.Point(308, 284)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(263, 74)
        Me.GroupBox5.TabIndex = 20
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Language (used to format edit log)"
        Me.ttMoleTips.SetToolTip(Me.GroupBox5, "This setting allows the edit log to be formatted properly so that when it is past" & _
                "ed into the code editor, it will appear as comments")
        '
        'rdoVB
        '
        Me.rdoVB.AutoSize = True
        Me.rdoVB.Checked = True
        Me.rdoVB.Location = New System.Drawing.Point(34, 43)
        Me.rdoVB.Name = "rdoVB"
        Me.rdoVB.Size = New System.Drawing.Size(64, 17)
        Me.rdoVB.TabIndex = 1
        Me.rdoVB.TabStop = True
        Me.rdoVB.Text = "VB.NET"
        Me.ttMoleTips.SetToolTip(Me.rdoVB, "Select to formated code edit log using VB.NET style comments")
        Me.rdoVB.UseVisualStyleBackColor = True
        '
        'rdoC
        '
        Me.rdoC.AutoSize = True
        Me.rdoC.Location = New System.Drawing.Point(34, 20)
        Me.rdoC.Name = "rdoC"
        Me.rdoC.Size = New System.Drawing.Size(39, 17)
        Me.rdoC.TabIndex = 0
        Me.rdoC.Text = "C#"
        Me.ttMoleTips.SetToolTip(Me.rdoC, "Select to formated code edit log using C# style comments")
        Me.rdoC.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.trackBarMaxRowsInCollectionData)
        Me.GroupBox4.Controls.Add(Me.lblMaxRowsInCollectionData)
        Me.GroupBox4.Location = New System.Drawing.Point(308, 164)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(263, 109)
        Me.GroupBox4.TabIndex = 19
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Max Rows In Collection Data"
        '
        'trackBarMaxRowsInCollectionData
        '
        Me.trackBarMaxRowsInCollectionData.Location = New System.Drawing.Point(21, 32)
        Me.trackBarMaxRowsInCollectionData.Maximum = 10000
        Me.trackBarMaxRowsInCollectionData.Minimum = 1
        Me.trackBarMaxRowsInCollectionData.Name = "trackBarMaxRowsInCollectionData"
        Me.trackBarMaxRowsInCollectionData.Size = New System.Drawing.Size(219, 45)
        Me.trackBarMaxRowsInCollectionData.SmallChange = 10
        Me.trackBarMaxRowsInCollectionData.TabIndex = 2
        Me.trackBarMaxRowsInCollectionData.TickFrequency = 500
        Me.ttMoleTips.SetToolTip(Me.trackBarMaxRowsInCollectionData, "Select maximum rows that will be displayed in the Moloscope collections" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        Me.trackBarMaxRowsInCollectionData.Value = 100
        '
        'lblMaxRowsInCollectionData
        '
        Me.lblMaxRowsInCollectionData.Location = New System.Drawing.Point(51, 80)
        Me.lblMaxRowsInCollectionData.Name = "lblMaxRowsInCollectionData"
        Me.lblMaxRowsInCollectionData.Size = New System.Drawing.Size(150, 18)
        Me.lblMaxRowsInCollectionData.TabIndex = 6
        Me.lblMaxRowsInCollectionData.Text = "100"
        Me.lblMaxRowsInCollectionData.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'llSavedSettingsFile
        '
        Me.llSavedSettingsFile.AutoSize = True
        Me.llSavedSettingsFile.Location = New System.Drawing.Point(14, 422)
        Me.llSavedSettingsFile.Name = "llSavedSettingsFile"
        Me.llSavedSettingsFile.Size = New System.Drawing.Size(20, 13)
        Me.llSavedSettingsFile.TabIndex = 18
        Me.llSavedSettingsFile.TabStop = True
        Me.llSavedSettingsFile.Text = "file"
        Me.ttMoleTips.SetToolTip(Me.llSavedSettingsFile, "Click to open the directory where your settings are saved. ")
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbHideIsDependencyPropertyColumn)
        Me.GroupBox3.Controls.Add(Me.cbHideValueSourceColumn)
        Me.GroupBox3.Controls.Add(Me.cbHideCategoryColumn)
        Me.GroupBox3.Location = New System.Drawing.Point(308, 35)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(254, 112)
        Me.GroupBox3.TabIndex = 17
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Moloscope Grid Options"
        '
        'cbHideIsDependencyPropertyColumn
        '
        Me.cbHideIsDependencyPropertyColumn.AutoSize = True
        Me.cbHideIsDependencyPropertyColumn.Location = New System.Drawing.Point(18, 79)
        Me.cbHideIsDependencyPropertyColumn.Name = "cbHideIsDependencyPropertyColumn"
        Me.cbHideIsDependencyPropertyColumn.Size = New System.Drawing.Size(203, 17)
        Me.cbHideIsDependencyPropertyColumn.TabIndex = 2
        Me.cbHideIsDependencyPropertyColumn.Text = "Hide Is Dependency Property Column"
        Me.cbHideIsDependencyPropertyColumn.UseVisualStyleBackColor = True
        '
        'cbHideValueSourceColumn
        '
        Me.cbHideValueSourceColumn.AutoSize = True
        Me.cbHideValueSourceColumn.Location = New System.Drawing.Point(18, 54)
        Me.cbHideValueSourceColumn.Name = "cbHideValueSourceColumn"
        Me.cbHideValueSourceColumn.Size = New System.Drawing.Size(153, 17)
        Me.cbHideValueSourceColumn.TabIndex = 1
        Me.cbHideValueSourceColumn.Text = "Hide Value Source Column"
        Me.cbHideValueSourceColumn.UseVisualStyleBackColor = True
        '
        'cbHideCategoryColumn
        '
        Me.cbHideCategoryColumn.AutoSize = True
        Me.cbHideCategoryColumn.Location = New System.Drawing.Point(18, 29)
        Me.cbHideCategoryColumn.Name = "cbHideCategoryColumn"
        Me.cbHideCategoryColumn.Size = New System.Drawing.Size(131, 17)
        Me.cbHideCategoryColumn.TabIndex = 0
        Me.cbHideCategoryColumn.Text = "Hide Category Column"
        Me.cbHideCategoryColumn.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label10.Location = New System.Drawing.Point(14, 396)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(442, 13)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Release build stores in a different location than when running in Visual Studio i" & _
            "n debug mode"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 374)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(266, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Saved Settings File Location (click to open file locaton)"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.llAndrewsblog)
        Me.GroupBox2.Controls.Add(Me.lblVersion)
        Me.GroupBox2.Controls.Add(Me.llKarlsBlog)
        Me.GroupBox2.Controls.Add(Me.llJoshsBlog)
        Me.GroupBox2.Controls.Add(Me.llMolesHomePage)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 164)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(263, 194)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Online Resources"
        '
        'llAndrewsblog
        '
        Me.llAndrewsblog.AutoSize = True
        Me.llAndrewsblog.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llAndrewsblog.Location = New System.Drawing.Point(15, 155)
        Me.llAndrewsblog.Name = "llAndrewsblog"
        Me.llAndrewsblog.Size = New System.Drawing.Size(136, 17)
        Me.llAndrewsblog.TabIndex = 21
        Me.llAndrewsblog.TabStop = True
        Me.llAndrewsblog.Text = "Andrew Smith's Blog"
        Me.ttMoleTips.SetToolTip(Me.llAndrewsblog, "Click to vist Andrew's blog.")
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(15, 31)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(42, 13)
        Me.lblVersion.TabIndex = 20
        Me.lblVersion.Text = "Version"
        '
        'llKarlsBlog
        '
        Me.llKarlsBlog.AutoSize = True
        Me.llKarlsBlog.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llKarlsBlog.Location = New System.Drawing.Point(15, 92)
        Me.llKarlsBlog.Name = "llKarlsBlog"
        Me.llKarlsBlog.Size = New System.Drawing.Size(126, 17)
        Me.llKarlsBlog.TabIndex = 18
        Me.llKarlsBlog.TabStop = True
        Me.llKarlsBlog.Text = "Karl Shifflett's Blog"
        Me.ttMoleTips.SetToolTip(Me.llKarlsBlog, "Click to vist Karl's WPF blog, including documentation on this program.  ")
        '
        'llJoshsBlog
        '
        Me.llJoshsBlog.AutoSize = True
        Me.llJoshsBlog.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llJoshsBlog.Location = New System.Drawing.Point(15, 123)
        Me.llJoshsBlog.Name = "llJoshsBlog"
        Me.llJoshsBlog.Size = New System.Drawing.Size(119, 17)
        Me.llJoshsBlog.TabIndex = 18
        Me.llJoshsBlog.TabStop = True
        Me.llJoshsBlog.Text = "Josh Smith's Blog"
        Me.ttMoleTips.SetToolTip(Me.llJoshsBlog, "Click to vist Josh's WPF blog.")
        '
        'llMolesHomePage
        '
        Me.llMolesHomePage.AutoSize = True
        Me.llMolesHomePage.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llMolesHomePage.Location = New System.Drawing.Point(15, 59)
        Me.llMolesHomePage.Name = "llMolesHomePage"
        Me.llMolesHomePage.Size = New System.Drawing.Size(126, 17)
        Me.llMolesHomePage.TabIndex = 18
        Me.llMolesHomePage.TabStop = True
        Me.llMolesHomePage.Text = "Mole's Home Page"
        Me.ttMoleTips.SetToolTip(Me.llMolesHomePage, "Click to vist Mole's Home Page")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.trackBarToolTipInitialDelay)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lblToolTipDelay)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(263, 113)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tooltip Initial Delay"
        '
        'trackBarToolTipInitialDelay
        '
        Me.trackBarToolTipInitialDelay.Location = New System.Drawing.Point(21, 32)
        Me.trackBarToolTipInitialDelay.Maximum = 3000
        Me.trackBarToolTipInitialDelay.Name = "trackBarToolTipInitialDelay"
        Me.trackBarToolTipInitialDelay.Size = New System.Drawing.Size(219, 45)
        Me.trackBarToolTipInitialDelay.SmallChange = 200
        Me.trackBarToolTipInitialDelay.TabIndex = 2
        Me.trackBarToolTipInitialDelay.TickFrequency = 200
        Me.ttMoleTips.SetToolTip(Me.trackBarToolTipInitialDelay, "Set the tooltip delay.  0 means tooltips show instantly, 3000 means tooltips are " & _
                "super slow, translated, you won't see them")
        Me.trackBarToolTipInitialDelay.Value = 500
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Fast"
        '
        'lblToolTipDelay
        '
        Me.lblToolTipDelay.Location = New System.Drawing.Point(51, 80)
        Me.lblToolTipDelay.Name = "lblToolTipDelay"
        Me.lblToolTipDelay.Size = New System.Drawing.Size(150, 20)
        Me.lblToolTipDelay.TabIndex = 6
        Me.lblToolTipDelay.Text = "500"
        Me.lblToolTipDelay.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(210, 80)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Slow"
        '
        'Label8
        '
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(725, 28)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Mole Options"
        Me.ttMoleTips.SetToolTip(Me.Label8, "WHO puts OPTIONS is a visualizer?'")
        '
        'BackgroundWokerLoadVisualTree
        '
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.DefaultExt = "xml"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.DefaultExt = "xml"
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmMole
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(1008, 566)
        Me.Controls.Add(Me.SplitContainer1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinimizeBox = False
        Me.Name = "frmMole"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Mole For Visual Studio"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.tcMoleTreeViews.ResumeLayout(False)
        Me.tpVisualTree.ResumeLayout(False)
        Me.tpLogicalTree.ResumeLayout(False)
        Me.pnlZContainerTreeViewCommands.ResumeLayout(False)
        Me.tcProperties.ResumeLayout(False)
        Me.tpProperties.ResumeLayout(False)
        Me.tpProperties.PerformLayout()
        CType(Me.dgvProperties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlZContainerPropertiesStatus.ResumeLayout(False)
        Me.pnlZContainerPropertiesCommands.ResumeLayout(False)
        Me.pnlZContainerPropertiesCommands.PerformLayout()
        Me.tpVisual.ResumeLayout(False)
        Me.pnlVisualPictureBoxScroller.ResumeLayout(False)
        Me.pnlVisualPictureBoxScroller.PerformLayout()
        CType(Me.pbVisual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlZContainerVisualCommands.ResumeLayout(False)
        Me.pnlZContainerVisualStatus.ResumeLayout(False)
        Me.tpXAML.ResumeLayout(False)
        Me.pnlZContainerWebBrowswer.ResumeLayout(False)
        Me.pnlZContainerXAMLCommands.ResumeLayout(False)
        Me.pnlZContainerXAMLCommands.PerformLayout()
        Me.pnlZContainerXAMLStatus.ResumeLayout(False)
        Me.tpFavorites.ResumeLayout(False)
        Me.pnlZContainerClearFavorites.ResumeLayout(False)
        Me.pnlZContainerFavoritesStatus.ResumeLayout(False)
        Me.tpOptions.ResumeLayout(False)
        Me.tpOptions.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.trackBarMaxRowsInCollectionData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.trackBarToolTipInitialDelay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents tcProperties As System.Windows.Forms.TabControl ' MoleTabControl 'System.Windows.Forms.TabControl
    Friend WithEvents tpProperties As System.Windows.Forms.TabPage
    Friend WithEvents tpVisual As System.Windows.Forms.TabPage
    Friend WithEvents tcMoleTreeViews As System.Windows.Forms.TabControl '  MoleTabControl 'System.Windows.Forms.TabControl
    Friend WithEvents tpVisualTree As System.Windows.Forms.TabPage
    Friend WithEvents dgvProperties As System.Windows.Forms.DataGridView
    Friend WithEvents pnlZContainerPropertiesCommands As System.Windows.Forms.Panel
    Friend WithEvents cbShowAttachedProperties As System.Windows.Forms.CheckBox
    Friend WithEvents pnlZContainerPropertiesStatus As System.Windows.Forms.Panel
    Friend WithEvents cboLookIn As System.Windows.Forms.ComboBox
    Friend WithEvents txtSearchText As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ttMoleTips As System.Windows.Forms.ToolTip
    Private WithEvents pbVisual As System.Windows.Forms.PictureBox
    Friend WithEvents tpFavorites As System.Windows.Forms.TabPage
    Friend WithEvents pnlZContainerFavoritesStatus As System.Windows.Forms.Panel
    Friend WithEvents lblFavoritesStatus As System.Windows.Forms.Label
    Friend WithEvents btnClearSearch As System.Windows.Forms.Button
    Friend WithEvents pnlVisualPictureBoxScroller As System.Windows.Forms.Panel
    Friend WithEvents tpXAML As System.Windows.Forms.TabPage
    Friend WithEvents webXAML As System.Windows.Forms.WebBrowser
    Friend WithEvents pnlZContainerVisualStatus As System.Windows.Forms.Panel
    Friend WithEvents pnlZContainerXAMLStatus As System.Windows.Forms.Panel
    Friend WithEvents rtbPropertiesStatus As System.Windows.Forms.RichTextBox
    Friend WithEvents rtbVisualStatus As System.Windows.Forms.RichTextBox
    Friend WithEvents rtbXAMLStatus As System.Windows.Forms.RichTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BackgroundWokerLoadVisualTree As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnDecreaseFontSize As System.Windows.Forms.Button
    Friend WithEvents btnIncreaseFontSize As System.Windows.Forms.Button
    Friend WithEvents pnlZContainerXAMLCommands As System.Windows.Forms.Panel
    Friend WithEvents pnlZContainerVisualCommands As System.Windows.Forms.Panel
    Friend WithEvents btnCopyImageToClipBoard As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rdoViewHTMLAttributesOnSingleLine As System.Windows.Forms.RadioButton
    Friend WithEvents rdoViewHTMLAttributesOnSeparateLine As System.Windows.Forms.RadioButton
    Friend WithEvents pnlZContainerWebBrowswer As System.Windows.Forms.Panel
    Friend WithEvents tpOptions As System.Windows.Forms.TabPage
    Friend WithEvents trackBarToolTipInitialDelay As System.Windows.Forms.TrackBar
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblToolTipDelay As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tvVisualTree As Mole.MoleTreeView
    Friend WithEvents tpLogicalTree As System.Windows.Forms.TabPage
    Friend WithEvents tvLogicalTree As MoleTreeView 'System.Windows.Forms.TreeView
    Friend WithEvents pnlZContainerTreeViewCommands As System.Windows.Forms.Panel
    Private WithEvents btnSelectInitalVisualNode As System.Windows.Forms.Button
    Private WithEvents btnCollapseDown As System.Windows.Forms.Button
    Private WithEvents btnExpandDown As System.Windows.Forms.Button
    Private WithEvents btnCollapseAll As System.Windows.Forms.Button
    Private WithEvents btnExpandAll As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cbHideIsDependencyPropertyColumn As System.Windows.Forms.CheckBox
    Friend WithEvents cbHideValueSourceColumn As System.Windows.Forms.CheckBox
    Friend WithEvents cbHideCategoryColumn As System.Windows.Forms.CheckBox
    Friend WithEvents mcMoleCrumbs As Mole.MoleCrumbs
    Friend WithEvents llMolesHomePage As System.Windows.Forms.LinkLabel
    Friend WithEvents llJoshsBlog As System.Windows.Forms.LinkLabel
    Friend WithEvents llKarlsBlog As System.Windows.Forms.LinkLabel
    Friend WithEvents llSavedSettingsFile As System.Windows.Forms.LinkLabel
    Friend WithEvents lblLogicalTreeInfo As System.Windows.Forms.Label
    Friend WithEvents lbFavorites As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents trackBarMaxRowsInCollectionData As System.Windows.Forms.TrackBar
    Friend WithEvents lblMaxRowsInCollectionData As System.Windows.Forms.Label
    Friend WithEvents pnlZContainerClearFavorites As System.Windows.Forms.Panel
    Friend WithEvents btnClearFavorites As System.Windows.Forms.Button
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents cbShowBlackOps As System.Windows.Forms.CheckBox
    Friend WithEvents llAndrewsblog As System.Windows.Forms.LinkLabel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoVB As System.Windows.Forms.RadioButton
    Friend WithEvents rdoC As System.Windows.Forms.RadioButton
    Friend WithEvents cbShowNamespaces As System.Windows.Forms.CheckBox
    Friend WithEvents btnLoadProperties As System.Windows.Forms.Button
    Friend WithEvents btnSaveProperties As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cbHideMatching As System.Windows.Forms.CheckBox
End Class
