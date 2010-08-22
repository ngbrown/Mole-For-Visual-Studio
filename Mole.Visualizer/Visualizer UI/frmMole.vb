Imports System.Xml
Imports System.Xml.Xsl
Imports System.Windows.Forms

Public Class frmMole

#Region " Private Declarations "

    Private ReadOnly _strSaveSettingsFileName As String = Application.LocalUserAppDataPath & "\MoleIIVisualizer.SavedSettings"
    Private Const INTEGER_COLUMNINDEX_CATEGORY As Integer = 7
    Private Const INTEGER_COLUMNINDEX_COMPAREVALUE As Integer = 2
    Private Const INTEGER_COLUMNINDEX_EDIT As Integer = 4
    Private Const INTEGER_COLUMNINDEX_ID As Integer = 9
    Private Const INTEGER_COLUMNINDEX_IS_DEPENDENCY_PROPERTY As Integer = 8
    Private Const INTEGER_COLUMNINDEX_IS_FAVORITE As Integer = 0
    Private Const INTEGER_COLUMNINDEX_NAME As Integer = 1

    '
    'INTEGER_COLUMNINDEX_PROPERTYTYPE has moved to GLOBAL scope
    'Private Const INTEGER_COLUMNINDEX_PROPERTYTYPE As Integer = 5
    '
    Private Const INTEGER_COLUMNINDEX_VALUE As Integer = 3
    Private Const INTEGER_COLUMNINDEX_VALUESOURCE As Integer = 6
    Private Const INTEGER_SEARCH_PROPERTY_NAME_ANYWHERE As Integer = 1
    Private Const INTEGER_SEARCH_PROPERTY_NAME_BEGINNING As Integer = 0
    Private Const INTEGER_SEARCH_VALUE_ANYWHERE As Integer = 3
    Private Const INTEGER_SEARCH_VALUE_BEGINNING As Integer = 2
    Private Const INTEGER_TAB_PAGE_VIEW_SELECTED_ELEMENT_PROPERTIES As Integer = 0
    Private Const INTEGER_TAB_PAGE_VIEW_VISUAL_TREE As Integer = 0
    Private Const STRING_APPLICATION_TREE As String = "Application Tree"
    Private Const STRING_ELEMENT_SELECTED_LABEL_CACHED_NO_NAME As String = "{0} object of type {1}"
    Private Const STRING_ELEMENT_SELECTED_LABEL_CACHED_WITH_NAME As String = "{0} object of type {1} named {2}"
    Private Const STRING_ELEMENT_SELECTED_LABEL_FETCHED_NO_NAME As String = "{0} object of type {1}"
    Private Const STRING_ELEMENT_SELECTED_LABEL_FETCHED_WITH_NAME As String = "{0} object of type {1} named {2}"
    Private Const STRING_ELEMENT_SELECTED_LABEL_RENDERED_NO_NAME As String = "{0} object of type {1} rendered using the {2} format"
    Private Const STRING_ELEMENT_SELECTED_LABEL_RENDERED_WITH_NAME As String = "{0} object of type {1} named {2} rendered using the {3} format"
    Private Const STRING_HIDE_BLACK_OPS_DATA As String = "Hide Field Data"
    Private Const STRING_HIDE_COLLECTION_DATA As String = "Hide Collection Data"
    Private Const STRING_HIDE_FAVORITES As String = "Hide Favorites"
    Private Const STRING_HTML_FORMAT As String = "HTMLFormat"
    Private Const STRING_LOGICALTREE As String = "Logical Tree"
    Private Const STRING_LOOKIN As String = "Lookin"
    Private Const STRING_NAME As String = "Name"
    Private Const STRING_NO_XAML_AVAILABLE_HTML As String = "<html><body><h3>No XAML Available</3></body></html>"
    Private Const STRING_SHOW_BLACK_OPS_DATA As String = "Show Field Data"
    Private Const STRING_SHOW_COLLECTION_DATA As String = "Show Collection Data"
    Private Const STRING_SHOW_FAVORITES As String = "Show Favorites"
    Private Const STRING_TRUE As String = "True"
    Private Const STRING_VISUALTREE As String = "Visual Tree"
    Private _bolAllowEditing As Boolean = True
    Private _bolApplyingFilter As Boolean = False
    Private _bolBackGroundLoadingInProgress As Boolean = True
    Private _bolByPassBatchOfApplyFilterCalls As Boolean = False
    Private _bolConductingDrillingOperation As Boolean = False
    Private _bolShowingBlackOps As Boolean = True
    Private _bolShowingCollectionData As Boolean = True
    Private _bolShowingFavorites As Boolean = True
    Private _cellUnderMouse As DataGridViewCell

    '==============================================================================================================
    'TODO developers you can change the properties grid colors here
    Private _clrDataAlternateRow As System.Drawing.Color = System.Drawing.Color.FromArgb(&HFFEAFFFD)
    Private _clrDataHeaderGradientBottom As System.Drawing.Color = System.Drawing.Color.FromArgb(&HFFDEFFFC)
    Private _clrDataHeaderGradientTop As System.Drawing.Color = System.Drawing.Color.FromArgb(&HFF7ED9D0)
    Private _clrDataNormalRow As System.Drawing.Color = System.Drawing.Color.FromArgb(&HFFF4FDFC)

    '
    Private _clrFavoriteAlternateRow As System.Drawing.Color = System.Drawing.Color.FromArgb(&HFFFFF0D8)
    Private _clrFavoriteHeaderGradientBottom As System.Drawing.Color = System.Drawing.Color.FromArgb(&HFFFFECD2)
    Private _clrFavoriteHeaderGradientTop As System.Drawing.Color = System.Drawing.Color.FromArgb(&HFFFFDCA0)
    Private _clrFavoriteNormalRow As System.Drawing.Color = System.Drawing.Color.FromArgb(&HFFFFFEEA)
    Private _editColumnContextMenu As ContextMenuStrip
    Private Shared _editColumnImage As System.Drawing.Image
    Private _editMenuToolEdit As ToolStripButton
    Private _editMenuToolReset As ToolStripButton

    'using a lot of string constants because they are faster than resources
    Private _enumMoleMode As MoleMode = MoleMode.Class

    '==============================================================================================================
    Private _fontMoloscopeClickableHeader As System.Drawing.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Private _intTabPageViewFavorites As Integer = -1
    Private _intTabPageViewSelectedElementVisual As Integer = -1
    Private _intTabPageViewSelectedElementXAML As Integer = -1
    Private _objApp As MoleSettings
    Private _objectProvider As Microsoft.VisualStudio.DebuggerVisualizers.IVisualizerObjectProvider
    Private _objElementBitmaps As New List(Of System.Drawing.Bitmap)
    Private _objVisualTreeNodeWhoseLogicalTreeIsCurrentlyLoaded As TreeNode
    Private _sbEditLog As New System.Text.StringBuilder
    Private _strLastRichTextMessage As String
    Private _strLastRichTextBoldWords() As String
#End Region

#Region " Properties "

    Private ReadOnly Property ActiveMoleTreeView() As MoleTreeView
        Get

            If tpVisualTree.Equals(Me.tcMoleTreeViews.SelectedTab) Then
                Return Me.tvVisualTree

            Else
                Return Me.tvLogicalTree
            End If

        End Get
    End Property

    Private ReadOnly Property ActiveMoleTreeViewSelectedNode() As MoleTreeNode
        Get

            Dim objSelectedMoleTreeNode As MoleTreeNode = Nothing

            Try

                If tpVisualTree.Equals(Me.tcMoleTreeViews.SelectedTab) Then

                    If Me.tvVisualTree.SelectedNode Is Nothing Then
                        Me.tvVisualTree.SelectedNode = Me.tvVisualTree.Nodes(0)
                    End If

                    objSelectedMoleTreeNode = DirectCast(Me.tvVisualTree.SelectedNode, MoleTreeNode)

                Else

                    If Me.tvLogicalTree.SelectedNode Is Nothing Then
                        Me.tvLogicalTree.SelectedNode = Me.tvVisualTree.Nodes(0)
                    End If

                    objSelectedMoleTreeNode = DirectCast(Me.tvLogicalTree.SelectedNode, MoleTreeNode)
                End If

            Catch ex As Exception
                'bummer, just ignore
            End Try

            Return objSelectedMoleTreeNode
        End Get
    End Property

    Private ReadOnly Property ActiveSourceTree() As String
        Get

            Select Case Me.MoleMode

                Case MoleMode.WPF

                    If tpVisualTree.Equals(Me.tcMoleTreeViews.SelectedTab) Then
                        Return STRING_VISUALTREE

                    Else
                        Return STRING_LOGICALTREE
                    End If

                Case Else
                    Return STRING_APPLICATION_TREE
            End Select

        End Get
    End Property

    Private ReadOnly Property ActiveTransferDataTreeTarget() As TransferDataTreeTarget
        Get

            If tpVisualTree.Equals(Me.tcMoleTreeViews.SelectedTab) Then
                Return TransferDataTreeTarget.VisualTree

            Else
                Return TransferDataTreeTarget.LogicalTree
            End If

        End Get
    End Property

    Private ReadOnly Property EditColumnContextMenu() As ContextMenuStrip
        Get

            If _editColumnContextMenu Is Nothing Then
                _editColumnContextMenu = New ContextMenuStrip()
                AddHandler _editColumnContextMenu.Opening, AddressOf OnEditColumnContextMenuOpening
                _editColumnContextMenu.Items.Add(Me.EditMenuToolEdit)
                _editColumnContextMenu.Items.Add(Me.EditMenuToolReset)
            End If

            Return _editColumnContextMenu
        End Get
    End Property

    Private Shared ReadOnly Property EditColumnImage() As System.Drawing.Image
        Get

            If _editColumnImage Is Nothing Then

                Dim stream As System.IO.Stream = GetType(frmMole).Assembly.GetManifestResourceStream(GetType(frmMole), "Edit.ico")
                _editColumnImage = System.Drawing.Image.FromStream(stream)
            End If

            Return _editColumnImage
        End Get
    End Property

    Private ReadOnly Property EditMenuToolEdit() As ToolStripButton
        Get

            If _editMenuToolEdit Is Nothing Then
                _editMenuToolEdit = New ToolStripButton("Edit...")
                AddHandler _editMenuToolEdit.Click, AddressOf OnEditMenuToolEdit
            End If

            Return _editMenuToolEdit
        End Get
    End Property

    Private ReadOnly Property EditMenuToolReset() As ToolStripButton
        Get

            If _editMenuToolReset Is Nothing Then
                _editMenuToolReset = New ToolStripButton("Reset/Clear")
                AddHandler _editMenuToolReset.Click, AddressOf OnEditMenuToolReset
            End If

            Return _editMenuToolReset
        End Get
    End Property

    ''' <summary>
    ''' This is a sanity check for the frmMole UI elements.  For example, this prevents issues when a user might start clicking on buttons
    ''' while the background process is loading or the element tree is loaded.
    ''' </summary>
    Private ReadOnly Property ObjectTreeViewReady() As Boolean
        Get

            If _bolBackGroundLoadingInProgress Then
                Return False

            ElseIf Me.ActiveMoleTreeView.Nodes.Count > 0 Then
                Return True

            Else
                Return False
            End If

        End Get
    End Property

    Public ReadOnly Property App() As MoleSettings
        Get
            Return _objApp
        End Get
    End Property

    Public ReadOnly Property MoleMode() As MoleMode
        Get
            Return _enumMoleMode
        End Get
    End Property

    ReadOnly Property SelectedElementTypeName() As String
        Get

            If Me.ActiveMoleTreeView.SelectedNode IsNot Nothing Then
                Return DirectCast(Me.ActiveMoleTreeView.SelectedNode, MoleTreeNode).TreeElement.TypeName

            Else
                Return String.Empty
            End If

        End Get
    End Property

#End Region

#Region " ContextMenu Commands "

    Private Sub OnEditColumnContextMenuOpening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)

        Dim indexes() As Integer = New Integer() {INTEGER_COLUMNINDEX_EDIT, INTEGER_COLUMNINDEX_VALUE}

        If Me._cellUnderMouse IsNot Nothing AndAlso Array.IndexOf(indexes, Me._cellUnderMouse.ColumnIndex) >= 0 Then

            Dim grid As DataGridView = DirectCast(Me._cellUnderMouse.DataGridView, DataGridView)
            Dim cell As DataGridViewCell = Me._cellUnderMouse
            Dim row As Mole.MoleDataGridViewRow = DirectCast(grid.Rows(cell.RowIndex), Mole.MoleDataGridViewRow)
            Dim isEditable As Boolean = row.IsEditable
            Dim canReset As Boolean = row.CanReset
            Me.EditMenuToolReset.Enabled = canReset
            Me.EditMenuToolEdit.Enabled = isEditable

            If isEditable OrElse canReset Then
                Me.EditColumnContextMenu.Tag = cell
                Return
            End If

        End If

        e.Cancel = True

    End Sub

    Private Sub OnEditMenuToolEdit(ByVal sender As Object, ByVal e As EventArgs)

        Dim cell As DataGridViewCell = DirectCast(Me.EditColumnContextMenu.Tag, DataGridViewCell)
        Dim row As Mole.MoleDataGridViewRow = DirectCast(cell.DataGridView.Rows(cell.RowIndex), Mole.MoleDataGridViewRow)
        EditPropertyValue(row)

    End Sub

    Private Sub OnEditMenuToolReset(ByVal sender As Object, ByVal e As EventArgs)

        Dim cell As DataGridViewCell = DirectCast(Me.EditColumnContextMenu.Tag, DataGridViewCell)
        Dim row As Mole.MoleDataGridViewRow = DirectCast(cell.DataGridView.Rows(cell.RowIndex), Mole.MoleDataGridViewRow)
        Dim strErrorMessage As String = String.Empty

        If Not UpdatePropertyValue(row, GlobalConstants.STRING_RESET_PROPERTY_MARKER, strErrorMessage) Then
            MessageBox.Show(String.Format("Unable to reset value, error message: {0}", strErrorMessage), "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

#End Region

#Region " Constructor "

    Public Sub New(ByVal objectProvider As Microsoft.VisualStudio.DebuggerVisualizers.IVisualizerObjectProvider)
        Me.InitializeComponent()
        _objectProvider = objectProvider
        Me.tcMoleTreeViews.SelectedIndex = INTEGER_TAB_PAGE_VIEW_VISUAL_TREE
        Me.tcProperties.SelectedIndex = INTEGER_TAB_PAGE_VIEW_SELECTED_ELEMENT_PROPERTIES

    End Sub

#End Region

#Region " Form Load & Closing "

    Private Sub ConfigureMoleUI()

        Select Case Me.MoleMode

            Case MoleMode.ASPNET
                Me.tcProperties.TabPages.RemoveAt(1)
                Me.tcProperties.TabPages.RemoveAt(1)
                Me.tcMoleTreeViews.TabPages.RemoveAt(1)
                _intTabPageViewSelectedElementVisual = -1
                _intTabPageViewSelectedElementXAML = -1
                _intTabPageViewFavorites = 1
                Me.cbShowAttachedProperties.Visible = False

            Case MoleMode.Class, MoleMode.ValueType
                Me.tcProperties.TabPages.RemoveAt(1)
                Me.tcProperties.TabPages.RemoveAt(1)
                Me.tcMoleTreeViews.TabPages.RemoveAt(1)
                _intTabPageViewSelectedElementVisual = -1
                _intTabPageViewSelectedElementXAML = -1
                _intTabPageViewFavorites = 1
                Me.cbShowAttachedProperties.Visible = False

            Case MoleMode.WinForms
                Me.tcProperties.TabPages.RemoveAt(2)
                Me.tcMoleTreeViews.TabPages.RemoveAt(1)
                _intTabPageViewSelectedElementVisual = 1
                _intTabPageViewSelectedElementXAML = -1
                _intTabPageViewFavorites = 2
                Me.cbShowAttachedProperties.Visible = False

            Case MoleMode.WPF
                _intTabPageViewSelectedElementVisual = 1
                _intTabPageViewSelectedElementXAML = 2
                _intTabPageViewFavorites = 3
                Me.cbShowAttachedProperties.Visible = True

            Case Mole.MoleMode.NOTSUPPORTED
                MessageBox.Show("You tried to wrap a Value type in a WeakReference object.  You can't do this. Mole will close now.  When using the WeakReferece hack to open Mole, please us a reference type.", "Invalid Use Of WeakReference", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.Close()

            Case Else
                Throw New ArgumentOutOfRangeException("MoleMode", Me.MoleMode, "MoleMode value not programmed")
        End Select

    End Sub

    Private Sub frmMole_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SaveSettings(_strSaveSettingsFileName)

        If _sbEditLog.Length > 0 Then
            My.Computer.Clipboard.Clear()
            My.Computer.Clipboard.SetText(_sbEditLog.ToString)
            _sbEditLog = Nothing
        End If

    End Sub

    Private Sub frmMole_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Cursor = Cursors.AppStarting
        '
        'NEVER CHANGE THE ORDER OF THIS CODE
        '
        LoadApplySettings(_strSaveSettingsFileName)
        '
        '
        'Query the object source and find out what object was selected in Visual Studio
        _enumMoleMode = CType(_objectProvider.GetObject, MoleMode)
        '
        '
        ConfigureMoleUI()

        '
        '
        '
        '*************************************************************************************************************
        'your code will now either call LoadItemsOnUIThread of fire up the background worker
        '
#If DEBUG Then

        '==============================================================================================================
        'YOU CAN NOT DEBUG THIS APPLICATION WHEN A BACKGROUND PROCESS IS BEING USED TO LOAD THE ITEMS.
        'use this when testing this applicaiton and debugging it.
        'The following post explains how to set your system up with regarding to project relationships when debugging
        'http://karlshifflett.wordpress.com/2007/12/01/systeminvalidcastexception-unable-to-cast-object-of-type-x-to-type-x/
        'to debug this Visualizer, call this from another project :
        '
        '   obj = is the DependencyObject you want to Visualizer
        '   Mole.MoleVisualizerObjectSource.TestMoleVisualizer( obj )
        '
        'complete load items on UI thread
        Dim objTree As Tree = Nothing
        Using objRequestData As New System.IO.MemoryStream
            MoleVisualizerObjectSource.Serialize(objRequestData, New TransferDataRequest(False, GetInitialDataTransferType, TransferDataTreeTarget.VisualTree, 0))
            Using objReturnData As System.IO.Stream = _objectProvider.TransferData(objRequestData)
                objTree = CType(MoleVisualizerObjectSource.Deserialize(objReturnData), Tree)
                objRequestData.Close()
            End Using
            objRequestData.Close()
        End Using
        CompleteLoading(objTree)

#Else
        '==============================================================================================================
        'Only use BackgroundWorker when in release mode
        '
        'spawn background process to load tree
        Me.BackgroundWokerLoadVisualTree.RunWorkerAsync()
        '
#End If

        '
        Me.lblVersion.Text = String.Format("Version: {0}", My.Application.Info.Version)
        '
        Application.DoEvents()
        '
        'finish the load
        'manually adding this handler is a fix for phantom mouse hits that Josh discovered during testing.  
        'Yes, mouse clicks are buffered and can click on things when the UI has not even displayed yet!
        '
        AddHandler dgvProperties.CellContentClick, AddressOf dgvProperties_CellContentClick

        '
    End Sub

    Private Function GetInitialDataTransferType() As TransferDataRequestType

        Select Case Me.MoleMode

            Case MoleMode.ASPNET
                Return TransferDataRequestType.InitialLoadASPNET

            Case MoleMode.Class
                Return TransferDataRequestType.InitialLoadClass

            Case MoleMode.ValueType
                Return TransferDataRequestType.InitialLoadClass

            Case MoleMode.WinForms
                Return TransferDataRequestType.InitialLoadWinForms

            Case MoleMode.WPF
                Return TransferDataRequestType.InitialLoadVisualTree

            Case Else
                Throw New ArgumentOutOfRangeException("MoleMode", Me.MoleMode, "MoleMode value not programmed")
        End Select

    End Function

#End Region

#Region " Misc Form Events "

    Private Sub btnClearFavorites_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearFavorites.Click

        If MessageBox.Show("Are you sure you want to remove all saved favorites?", "Clear Favorites", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            App.Favorites.Clear()
            Me.lbFavorites.Items.Clear()
        End If

    End Sub

    Private Sub cbHideCategoryColumn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbHideCategoryColumn.CheckedChanged

        If Me.dgvProperties.Columns.Count > 0 Then
            Me.dgvProperties.Columns(INTEGER_COLUMNINDEX_CATEGORY).Visible = Not Me.cbHideCategoryColumn.Checked
        End If

    End Sub

    Private Sub cbHideIsDependencyPropertyColumn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbHideIsDependencyPropertyColumn.CheckedChanged

        If Me.MoleMode = MoleMode.WPF Then

            If Me.dgvProperties.Columns.Count > 0 Then
                Me.dgvProperties.Columns(INTEGER_COLUMNINDEX_IS_DEPENDENCY_PROPERTY).Visible = Not Me.cbHideIsDependencyPropertyColumn.Checked
            End If

        End If

    End Sub

    Private Sub cbHideValueSourceColumn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbHideValueSourceColumn.CheckedChanged

        If Me.MoleMode = MoleMode.WPF Then

            If Me.dgvProperties.Columns.Count > 0 Then
                Me.dgvProperties.Columns(INTEGER_COLUMNINDEX_VALUESOURCE).Visible = Not Me.cbHideValueSourceColumn.Checked
            End If

        End If

    End Sub

    Private Sub llAndrewsblog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles llAndrewsblog.Click
        StartProcessWithFileName("http://agsmith.wordpress.com/")

    End Sub

    Private Sub llJoshsBlog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles llJoshsBlog.Click
        StartProcessWithFileName("http://joshsmithonwpf.wordpress.com/")

    End Sub

    Private Sub llKarlsBlog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles llKarlsBlog.Click
        StartProcessWithFileName("http://karlshifflett.wordpress.com/")

    End Sub

    Private Sub llMolesHomePage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles llMolesHomePage.Click
        StartProcessWithFileName("http://karlshifflett.wordpress.com/mole-for-visual-studio/")

    End Sub

    Private Sub llSavedSettingsFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles llSavedSettingsFile.Click
        StartProcessWithFileName(Application.LocalUserAppDataPath)

    End Sub

    Private Sub rdoC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoC.CheckedChanged

        If Me.rdoC.Checked AndAlso App IsNot Nothing Then
            App.Language = Language.C
        End If

    End Sub

    Private Sub rdoVB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoVB.CheckedChanged

        If Me.rdoVB.Checked AndAlso App IsNot Nothing Then
            App.Language = Language.VB
        End If

    End Sub

    Private Sub trackBarMaxRowsInCollectionData_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trackBarMaxRowsInCollectionData.Scroll
        Me.lblMaxRowsInCollectionData.Text = Me.trackBarMaxRowsInCollectionData.Value.ToString

    End Sub

    Private Sub trackBarToolTipInitialDelay_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trackBarToolTipInitialDelay.Scroll
        Me.lblToolTipDelay.Text = Me.trackBarToolTipInitialDelay.Value.ToString
        Me.ttMoleTips.InitialDelay = Me.trackBarToolTipInitialDelay.Value
        Me.ttMoleTips.ReshowDelay = Me.trackBarToolTipInitialDelay.Value

    End Sub

#End Region

#Region " Tree Loaders Sync and Async "

    Private Sub BackgroundWokerLoadVisualTree_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWokerLoadVisualTree.DoWork

        ' Get the BackgroundWorker object that raised this event.
        Dim worker As System.ComponentModel.BackgroundWorker = CType(sender, System.ComponentModel.BackgroundWorker)

        ' Assign the result of the computation to the Result property of the DoWorkEventArgs object. 
        'This is will be available to the RunWorkerCompleted eventhandler.
        Dim objTree As Tree = Nothing
        Using objRequestData As New System.IO.MemoryStream
            MoleVisualizerObjectSource.Serialize(objRequestData, New TransferDataRequest(False, GetInitialDataTransferType, TransferDataTreeTarget.VisualTree, 0))
            Using objReturnData As System.IO.Stream = _objectProvider.TransferData(objRequestData)
                objTree = CType(MoleVisualizerObjectSource.Deserialize(objReturnData), Tree)
                objRequestData.Close()
            End Using
            objRequestData.Close()
        End Using
        e.Result = objTree

    End Sub

    Private Sub BackgroundWokerLoadVisualTree_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWokerLoadVisualTree.RunWorkerCompleted

        If e.Error IsNot Nothing Then
            MessageBox.Show("Bummer.  Exception while loading data." & vbCrLf & vbCrLf & e.Error.ToString, "Problems...", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
            Exit Sub
        End If

        CompleteLoading(CType(e.Result, Tree))

    End Sub

    Private Sub CompleteLoading(ByVal objTree As Tree)

        'used by both the sync and async loaders after they call and complete _objectProvider.GetObject
        If objTree.LoadingErrorMessage.Length > 0 Then
            MessageBox.Show(String.Format("Bummer.  {0}, please select a different object or one that is in the visual tree.", objTree.LoadingErrorMessage), "Problems...", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
            Exit Sub
        End If

        Me.tvVisualTree.TreeData = objTree
        _bolBackGroundLoadingInProgress = False
        Me.tvVisualTree.SelectInitialNode()

        If Me.MoleMode = MoleMode.WPF Then
            Me.tpVisualTree.Text = STRING_VISUALTREE

        Else
            Me.tpVisualTree.Text = STRING_APPLICATION_TREE
        End If

        Me.Cursor = Cursors.Arrow

        If Me.tvVisualTree.Nodes.Count = 0 Or Me.tvVisualTree.Nodes(0).Nodes.Count = 0 Then
            Me.pnlZContainerTreeViewCommands.Enabled = False
        End If

    End Sub

#End Region

#Region " TreeView "

    Private Sub btnSelectInitalVisualNode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectInitalVisualNode.Click

        If Not ObjectTreeViewReady Then
            Exit Sub
        End If

        ActiveMoleTreeView.SelectInitialNode()

    End Sub

    Private Function CreateLogicalTreeInfoDisplayText(ByVal objLogicalTreeInfo As LogicalTreeInfo) As String
        Return String.Format("Original Element:  {1}{0}Closest Logical Ancestor:  {2}{0}Templated Parent of CLA:  {3}", Environment.NewLine, objLogicalTreeInfo.OriginalElement, objLogicalTreeInfo.ClosestLogicalAncestor, objLogicalTreeInfo.TemplatedParentOfClosestLogicalAncestor)

    End Function

    Private Sub OnMoleTreeViews_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvVisualTree.AfterSelect, tvLogicalTree.AfterSelect

        Dim objSelectedMoleTreeNode As MoleTreeNode = ActiveMoleTreeViewSelectedNode

        If objSelectedMoleTreeNode IsNot Nothing Then
            Me.mcMoleCrumbs.Clear(objSelectedMoleTreeNode.TreeElement.TypeName, objSelectedMoleTreeNode.TreeElement.TypeFullName, Me.txtSearchText.Text, False)

        Else
            Me.mcMoleCrumbs.Clear(String.Empty, String.Empty, String.Empty, False)
        End If

        DisplayTreeElementData(CType(e.Node, MoleTreeNode))

    End Sub

    Private Sub tcMoleTreeViews_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcMoleTreeViews.SelectedIndexChanged
        Me.CleanDrillingOperation()

        If tpVisualTree.Equals(Me.tcMoleTreeViews.SelectedTab) Then
            DisplayTreeElementData(CType(Me.tvVisualTree.SelectedNode, MoleTreeNode))
            Exit Sub
        End If

        If Me.tvVisualTree.SelectedNode Is Nothing Then
            Exit Sub
        End If

        Dim objTreeNode As MoleTreeNode = ActiveMoleTreeViewSelectedNode

        If objTreeNode IsNot Nothing Then

            Dim strNoNameFormat As String
            Dim strNamedFormat As String

            If objTreeNode.TreeElement.Properties Is Nothing OrElse objTreeNode.TreeElement.Properties.Count = 0 Then
                strNoNameFormat = STRING_ELEMENT_SELECTED_LABEL_FETCHED_NO_NAME
                strNamedFormat = STRING_ELEMENT_SELECTED_LABEL_FETCHED_WITH_NAME

            Else
                strNoNameFormat = STRING_ELEMENT_SELECTED_LABEL_CACHED_NO_NAME
                strNamedFormat = STRING_ELEMENT_SELECTED_LABEL_CACHED_WITH_NAME
            End If

            Dim strTypeName As String = objTreeNode.TreeElement.TypeName

            If Me.cbShowNamespaces.Checked Then
                strTypeName = objTreeNode.TreeElement.TypeFullName
            End If

            If objTreeNode.TreeElement.ObjectName.Length = 0 Then

                Dim strBoldWords() As String = {strTypeName}
                SetRTFLableMessage(rtbPropertiesStatus, String.Format(strNoNameFormat, Me.ActiveSourceTree, strTypeName), strBoldWords)

            Else

                Dim strBoldWords() As String = {strTypeName, objTreeNode.TreeElement.ObjectName}
                SetRTFLableMessage(rtbPropertiesStatus, String.Format(strNamedFormat, Me.ActiveSourceTree, strTypeName, objTreeNode.TreeElement.ObjectName), strBoldWords)
            End If

        End If

        Me.tvLogicalTree.SuspendLayout()
        Using objRequestData As New System.IO.MemoryStream
            MoleVisualizerObjectSource.Serialize(objRequestData, New TransferDataRequest(True, TransferDataRequestType.LoadLogicalTree, TransferDataTreeTarget.LogicalTree, CType(tvVisualTree.SelectedNode, MoleTreeNode).TreeElement.Id))
            Using objReturnData As System.IO.Stream = _objectProvider.TransferData(objRequestData)
                Me.tvLogicalTree.TreeData = CType(MoleVisualizerObjectSource.Deserialize(objReturnData), Tree)
                Me.lblLogicalTreeInfo.Text = Me.CreateLogicalTreeInfoDisplayText(Me.tvLogicalTree.TreeData.LogicalTreeInfo)
                objReturnData.Close()
            End Using
            objRequestData.Close()
        End Using
        Me.tvLogicalTree.ResumeLayout()
        _objVisualTreeNodeWhoseLogicalTreeIsCurrentlyLoaded = tvVisualTree.SelectedNode

    End Sub

    Private Sub tcProperties_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tcProperties.SelectedIndexChanged

        If Me.tcProperties.SelectedIndex = _intTabPageViewFavorites Then
            Me.lbFavorites.Items.Clear()

            Dim ary As New ArrayList

            For Each obj As Object In App.Favorites.Keys
                ary.Add(CType(obj, String))
            Next

            ary.Sort()

            For Each s As String In ary
                Me.lbFavorites.Items.Add(s)
            Next

        Else

            If Me.ActiveMoleTreeView.SelectedNode IsNot Nothing Then

                If Me.tcProperties.SelectedIndex = INTEGER_TAB_PAGE_VIEW_SELECTED_ELEMENT_PROPERTIES Then
                    Me.mcMoleCrumbs.Clear(CType(Me.ActiveMoleTreeView.SelectedNode, MoleTreeNode).TreeElement.TypeName, CType(Me.ActiveMoleTreeView.SelectedNode, MoleTreeNode).TreeElement.TypeFullName, String.Empty, False)

                Else
                    Me.mcMoleCrumbs.Clear(String.Empty, String.Empty, String.Empty, False)
                End If

                DisplayTreeElementData(ActiveMoleTreeView.SelectedNode)
            End If

        End If

    End Sub

#End Region

#Region " ShowNamespaces "

    Private Sub ShowNamespaces()
        Me.tvLogicalTree.SetShowNamespaces(Me.cbShowNamespaces.Checked)
        Me.tvVisualTree.SetShowNamespaces(Me.cbShowNamespaces.Checked)

        For Each obj As MoleDataGridViewRow In Me.dgvProperties.Rows
            If Me.cbShowNamespaces.Checked Then
                obj.Cells(INTEGER_COLUMNINDEX_PROPERTYTYPE).Value = obj.TypeFullName
            Else
                obj.Cells(INTEGER_COLUMNINDEX_PROPERTYTYPE).Value = obj.TypeName
            End If
        Next

    End Sub

#End Region

#Region " Property Grid "

    'this is called when the two treeviews are clicked and new element selected but the new data was retrieved from cache
    Private Sub CleanDrillingOperation()

        Dim objSelectedMoleTreeNode As MoleTreeNode = ActiveMoleTreeViewSelectedNode

        If objSelectedMoleTreeNode IsNot Nothing Then
            Me.mcMoleCrumbs.Clear(objSelectedMoleTreeNode.TreeElement.TypeName, objSelectedMoleTreeNode.TreeElement.TypeFullName, Me.txtSearchText.Text, False)

        Else
            Me.mcMoleCrumbs.Clear(String.Empty, String.Empty, String.Empty, False)
        End If

        Using objRequestData As New System.IO.MemoryStream
            MoleVisualizerObjectSource.Serialize(objRequestData, New TransferDataRequest(True, TransferDataRequestType.ClearDrillingOperation, ActiveTransferDataTreeTarget, 0))
            Using objReturnData As System.IO.Stream = _objectProvider.TransferData(objRequestData)
                objReturnData.Close()
            End Using
            objRequestData.Close()
        End Using

    End Sub

    Private Sub ConductDrillingOperation(ByVal intParentElementTreeDictionaryKeyId As Integer, ByVal strPropertyName As String, ByVal strSearchText As String, ByVal bolIsDrillBackOperation As Boolean, ByVal bolIsBlackOps As Boolean)
        _bolConductingDrillingOperation = True
        Me.cbHideMatching.Enabled = False
        Me.dgvProperties.Columns(INTEGER_COLUMNINDEX_COMPAREVALUE).Visible = False

        Dim enumTransferDataRequestType As TransferDataRequestType = TransferDataRequestType.DrillingOperation

        If bolIsBlackOps Then

            enumTransferDataRequestType = TransferDataRequestType.BlackOpsDrillingOperation
        End If

        Dim objDrillingOperationResponse As DrillingOperationResponse = Nothing
        Using objRequestData As New System.IO.MemoryStream
            MoleVisualizerObjectSource.Serialize(objRequestData, New TransferDataRequest(False, enumTransferDataRequestType, Me.ActiveTransferDataTreeTarget, intParentElementTreeDictionaryKeyId, Me.mcMoleCrumbs.ThisElementTreeDictionaryKeyId, strPropertyName, Me.trackBarMaxRowsInCollectionData.Value))
            Using objReturnData As System.IO.Stream = _objectProvider.TransferData(objRequestData)
                objDrillingOperationResponse = CType(MoleVisualizerObjectSource.Deserialize(objReturnData), DrillingOperationResponse)
                Me.mcMoleCrumbs.Add(New MoleCrumb(objDrillingOperationResponse.HasData, intParentElementTreeDictionaryKeyId, objDrillingOperationResponse.ThisElementTreeDictionaryKeyId, strPropertyName, objDrillingOperationResponse.FullTypeName, strSearchText, bolIsBlackOps))
                objReturnData.Close()
            End Using
            objRequestData.Close()
        End Using

        If bolIsDrillBackOperation Then
            Me.txtSearchText.Text = strSearchText

        Else
            Me.txtSearchText.Text = String.Empty
        End If

        Me.btnClearSearch.Visible = Me.txtSearchText.Text.Length > 0

        If objDrillingOperationResponse.Properties IsNot Nothing AndAlso objDrillingOperationResponse.Properties.Count > 0 Then
            With Me.dgvProperties
                .SuspendLayout()
                .ScrollBars = ScrollBars.None
                .Rows.Clear()

                Dim intRowIndex As Integer
                Dim bolIsFavorite As Boolean = False
                Dim bolHasFavorite As Boolean = False
                Dim bolHasCollectionDataInPackage As Boolean = False
                Dim enumMoleRowRole As MoleRowRole = MoleRowRole.NormalRow

                For Each obj As TreeElementProperty In objDrillingOperationResponse.Properties

                    If obj.Name.StartsWith(STRING_LEFT_COLLECTION_INDEX_MARKER) Then
                        bolHasCollectionDataInPackage = True

                        enumMoleRowRole = MoleRowRole.Data

                    Else
                        bolIsFavorite = App.Favorites.ContainsKey(obj.Name)

                        enumMoleRowRole = MoleRowRole.NormalRow

                        If bolIsFavorite Then
                            bolHasFavorite = True

                            enumMoleRowRole = MoleRowRole.Favorite

                        ElseIf obj.Category.StartsWith(STRING_LEFT_BLACK_OPS_MARKER) Then

                            enumMoleRowRole = MoleRowRole.BlackOpsRow
                        End If

                    End If

                    Dim objEditColumnValue As Object = IIf(obj.IsEditable, EditColumnImage, Nothing)
                    intRowIndex = .Rows.Add(New MoleDataGridViewRow(Me.dgvProperties, obj.PropertyType, obj.PropertyTypeFullName, obj.IsDrillable, enumMoleRowRole, obj.IsEditable, obj.CanReset, bolIsFavorite, obj.Name, String.Empty, obj.Value, objEditColumnValue, obj.GetTypeName(Me.cbShowNamespaces.Checked), obj.ValueSource, obj.Category, obj.IsDependencyProperty, Me.mcMoleCrumbs.ParentElementTreeDictionaryKeyId))

                    CType(.Rows(intRowIndex).Cells(INTEGER_COLUMNINDEX_PROPERTYTYPE), DataGridViewCell).ToolTipText = obj.PropertyTypeFullName

                    Dim row As MoleDataGridViewRow = DirectCast(.Rows(intRowIndex), MoleDataGridViewRow)

                    If row.MoleRowRole = MoleRowRole.Data OrElse row.MoleRowRole = MoleRowRole.BlackOpsRow Then

                        Dim objNameCell As DataGridViewLinkCell = CType(row.Cells(INTEGER_COLUMNINDEX_NAME), DataGridViewLinkCell)
                        With objNameCell
                            .Style.ForeColor = Drawing.Color.Black
                            .ActiveLinkColor = Drawing.Color.Black
                            .LinkBehavior = LinkBehavior.NeverUnderline
                            .LinkColor = Drawing.Color.Black
                            .LinkVisited = False
                            .TrackVisitedState = False
                            .VisitedLinkColor = Drawing.Color.Black
                            .ToolTipText = String.Empty
                        End With

                        If row.MoleRowRole = MoleRowRole.Data Then

                            Dim objIsFavoriteCell As DataGridViewCheckBoxCell = CType(row.Cells(INTEGER_COLUMNINDEX_IS_FAVORITE), DataGridViewCheckBoxCell)
                            objIsFavoriteCell.ReadOnly = True
                        End If

                    End If

                    Dim objValueCell As DataGridViewLinkCell = CType(row.Cells(INTEGER_COLUMNINDEX_VALUE), DataGridViewLinkCell)
                    InitializeDrillableCell(objValueCell, obj.IsDrillable)
                Next

                'never change this code
                intRowIndex = .Rows.Add(New MoleDataGridViewRow(Me.dgvProperties, "", "", False, MoleRowRole.BlackOpsHeader, False, False, False, "WWWWWWWWWWWWWWWWWWWWWWWWW", "", "", Nothing, "", "", "", False, 0))
                .Rows(intRowIndex).Cells(INTEGER_COLUMNINDEX_NAME).ToolTipText = "Click to show/hide fields"
                .Rows(intRowIndex).Cells(INTEGER_COLUMNINDEX_IS_FAVORITE).ReadOnly = True
                '
                intRowIndex = .Rows.Add(New MoleDataGridViewRow(Me.dgvProperties, "", "", False, MoleRowRole.BlackOpsFooter, False, False, False, "", "", "", Nothing, "", "", "", False, 0))
                .Rows(intRowIndex).Cells(INTEGER_COLUMNINDEX_IS_FAVORITE).ReadOnly = True
                .Rows(intRowIndex).Height = 5
                '
                intRowIndex = .Rows.Add(New MoleDataGridViewRow(Me.dgvProperties, "", "", False, MoleRowRole.FavoriteHeader, False, False, False, "WWWWWWWWWWWWWWWWWWWWWWWWW", "", "", Nothing, "", "", "", False, 0))
                .Rows(intRowIndex).Cells(INTEGER_COLUMNINDEX_NAME).ToolTipText = "Click to show/hide favorites"
                .Rows(intRowIndex).Cells(INTEGER_COLUMNINDEX_IS_FAVORITE).ReadOnly = True
                '
                intRowIndex = .Rows.Add(New MoleDataGridViewRow(Me.dgvProperties, "", "", False, MoleRowRole.FavoriteFooter, False, False, False, "", "", "", Nothing, "", "", "", False, 0))
                .Rows(intRowIndex).Cells(INTEGER_COLUMNINDEX_IS_FAVORITE).ReadOnly = True
                .Rows(intRowIndex).Height = 5

                If bolHasCollectionDataInPackage Then
                    'never change this code
                    intRowIndex = .Rows.Add(New MoleDataGridViewRow(Me.dgvProperties, "", "", False, MoleRowRole.DataHeader, False, False, False, "WWWWWWWWWWWWWWWWWWWWWWWWW", "", "", Nothing, "", "", "", False, 0))
                    .Rows(intRowIndex).Cells(INTEGER_COLUMNINDEX_NAME).ToolTipText = "Click to show/hide collection data"
                    .Rows(intRowIndex).Cells(INTEGER_COLUMNINDEX_IS_FAVORITE).ReadOnly = True
                    intRowIndex = .Rows.Add(New MoleDataGridViewRow(Me.dgvProperties, "", "", False, MoleRowRole.DataFooter, False, False, False, "", "", "", Nothing, "", "", "", False, 0))
                    .Rows(intRowIndex).Cells(INTEGER_COLUMNINDEX_IS_FAVORITE).ReadOnly = True
                    .Rows(intRowIndex).Height = 5
                End If

                .Sort(.Columns(App.SortByColumn), System.ComponentModel.ListSortDirection.Ascending)
                ApplyFilters()
                .ResumeLayout()
                .ScrollBars = ScrollBars.Both

                For Each obj As DataGridViewRow In Me.dgvProperties.SelectedRows
                    obj.Selected = False
                Next

            End With

            If Not Me.rtbPropertiesStatus.Text.StartsWith("Drilling into") Then
                Me.SetRTFLableMessage(Me.rtbPropertiesStatus, String.Concat("Drilling into ", _strLastRichTextMessage), _strLastRichTextBoldWords)
            End If

        Else

            If Me.rtbPropertiesStatus.Text.StartsWith("Drilling into") Then
                Me.SetRTFLableMessage(Me.rtbPropertiesStatus, _strLastRichTextMessage.Replace("Drilling into", ""), _strLastRichTextBoldWords)
            End If

        End If

        _bolConductingDrillingOperation = False

    End Sub

    Private Sub dgvProperties_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProperties.CellClick

        If e.RowIndex = -1 Then
            Exit Sub
        End If

        Dim row As Mole.MoleDataGridViewRow = CType(Me.dgvProperties.Rows(e.RowIndex), MoleDataGridViewRow)
        Dim role As Mole.MoleRowRole = row.MoleRowRole

        If e.ColumnIndex = INTEGER_COLUMNINDEX_NAME AndAlso role = MoleRowRole.DataHeader Then

            If _bolShowingCollectionData Then
                Me.dgvProperties.Item(INTEGER_COLUMNINDEX_NAME, e.RowIndex).Value = STRING_HIDE_COLLECTION_DATA
                _bolShowingCollectionData = False

            Else
                Me.dgvProperties.Item(INTEGER_COLUMNINDEX_NAME, e.RowIndex).Value = STRING_SHOW_COLLECTION_DATA
                _bolShowingCollectionData = True
            End If

            ApplyFilters()

        ElseIf e.ColumnIndex = INTEGER_COLUMNINDEX_NAME AndAlso role = MoleRowRole.FavoriteHeader Then

            If _bolShowingFavorites Then
                Me.dgvProperties.Item(INTEGER_COLUMNINDEX_NAME, e.RowIndex).Value = STRING_HIDE_FAVORITES
                _bolShowingFavorites = False

            Else
                Me.dgvProperties.Item(INTEGER_COLUMNINDEX_NAME, e.RowIndex).Value = STRING_SHOW_FAVORITES
                _bolShowingFavorites = True
            End If

            ApplyFilters()

        ElseIf e.ColumnIndex = INTEGER_COLUMNINDEX_NAME AndAlso role = MoleRowRole.BlackOpsHeader Then

            If _bolShowingBlackOps Then
                Me.dgvProperties.Item(INTEGER_COLUMNINDEX_NAME, e.RowIndex).Value = STRING_HIDE_BLACK_OPS_DATA
                _bolShowingBlackOps = False

            Else
                Me.dgvProperties.Item(INTEGER_COLUMNINDEX_NAME, e.RowIndex).Value = STRING_SHOW_BLACK_OPS_DATA
                _bolShowingBlackOps = True
            End If

            ApplyFilters()

        ElseIf e.ColumnIndex = INTEGER_COLUMNINDEX_EDIT Then

            Select Case role

                Case MoleRowRole.Data, MoleRowRole.Favorite, MoleRowRole.NormalRow, MoleRowRole.BlackOpsRow
                    EditPropertyValue(row)
            End Select

        End If

    End Sub

    Private Sub dgvProperties_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

        'this event fires before dgvProperties_ColumnHeaderMouseClick.  
        If e.RowIndex = -1 Then
            Exit Sub
        End If

        Dim enumMoleRowRole As MoleRowRole = CType(Me.dgvProperties.Rows(e.RowIndex), MoleDataGridViewRow).MoleRowRole

        If e.ColumnIndex = INTEGER_COLUMNINDEX_NAME Then

            If enumMoleRowRole = MoleRowRole.NormalRow OrElse enumMoleRowRole = MoleRowRole.Favorite Then

                'TODO developers you can modify this code to change the query passed to Google.com
                Dim intLastIndex As Integer = Me.mcMoleCrumbs.FullTypeName.LastIndexOf(".")

                If intLastIndex > 0 Then

                    Dim strFullTypeNameNamespace As String = Me.mcMoleCrumbs.FullTypeName.Substring(0, intLastIndex)
                    Dim strTypeName As String = Me.mcMoleCrumbs.FullTypeName.Substring(intLastIndex + 1)
                    StartProcessWithFileName(String.Format("http://www.google.com/search?q={0}+{1}+{2}", strFullTypeNameNamespace, strTypeName, Me.dgvProperties.Item(INTEGER_COLUMNINDEX_NAME, e.RowIndex).Value))

                Else
                    StartProcessWithFileName(String.Format("http://www.google.com/search?q={0}+{1}", Me.mcMoleCrumbs.FullTypeName, Me.dgvProperties.Item(INTEGER_COLUMNINDEX_NAME, e.RowIndex).Value))
                End If

            End If

        ElseIf e.ColumnIndex = INTEGER_COLUMNINDEX_VALUE AndAlso CType(Me.dgvProperties.Rows(e.RowIndex), MoleDataGridViewRow).IsDrillable Then
            Me.mcMoleCrumbs.SetSearchTextForActiveMoleCrumb(Me.txtSearchText.Text)
            ConductDrillingOperation(CType(Me.dgvProperties(INTEGER_COLUMNINDEX_ID, e.RowIndex).Value, Integer), Me.dgvProperties(INTEGER_COLUMNINDEX_NAME, e.RowIndex).Value.ToString, Me.txtSearchText.Text, False, Me.dgvProperties(INTEGER_COLUMNINDEX_CATEGORY, e.RowIndex).Value.ToString.StartsWith(STRING_LEFT_BLACK_OPS_MARKER))
        End If

    End Sub

    Private Sub dgvProperties_CellMouseEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProperties.CellMouseEnter

        If e.RowIndex >= 0 Then
            Me._cellUnderMouse = Me.dgvProperties(e.ColumnIndex, e.RowIndex)
        End If

    End Sub

    Private Sub dgvProperties_CellMouseLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProperties.CellMouseLeave
        Me._cellUnderMouse = Nothing

    End Sub

    Private Sub dgvProperties_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvProperties.ColumnHeaderMouseClick

        If Not ObjectTreeViewReady Then
            Exit Sub
        End If

        If Me.dgvProperties.Columns(e.ColumnIndex).SortMode <> DataGridViewColumnSortMode.NotSortable Then
            App.SortByColumn = CType(e.ColumnIndex, SortByColumn)
            ApplyFilters()

            If Me.dgvProperties.SortOrder = SortOrder.Ascending Then
                App.SortOrder = System.ComponentModel.ListSortDirection.Ascending

            Else
                App.SortOrder = System.ComponentModel.ListSortDirection.Descending
            End If

        End If

    End Sub

    Private Sub dgvProperties_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvProperties.CurrentCellDirtyStateChanged

        If Me.dgvProperties.CurrentCell.ColumnIndex = INTEGER_COLUMNINDEX_IS_FAVORITE Then

            Dim strKey As String = Me.dgvProperties.Item(INTEGER_COLUMNINDEX_NAME, Me.dgvProperties.CurrentCell.RowIndex).Value.ToString
            Dim bolHasChanged As Boolean = False
            Dim bolWasRemoved As Boolean = False

            If CType(Me.dgvProperties.CurrentCell.EditedFormattedValue, Boolean) Then

                'new value is true
                If Not App.Favorites.ContainsKey(strKey) Then
                    App.Favorites.Add(strKey, Nothing)
                    bolHasChanged = True
                    CType(Me.dgvProperties.CurrentRow, MoleDataGridViewRow).MoleRowRole = MoleRowRole.Favorite
                End If

            Else

                'new value is false
                If App.Favorites.ContainsKey(strKey) Then
                    App.Favorites.Remove(strKey)
                    bolHasChanged = True
                    bolWasRemoved = True
                    CType(Me.dgvProperties.CurrentRow, MoleDataGridViewRow).MoleRowRole = MoleRowRole.NormalRow
                End If

            End If

            If bolHasChanged Then
                'shutdown event handling, otherwise this sub gets called recursivly
                RemoveHandler dgvProperties.CurrentCellDirtyStateChanged, AddressOf dgvProperties_CurrentCellDirtyStateChanged
                'save changes to the row
                Me.dgvProperties.CommitEdit(DataGridViewDataErrorContexts.Commit)
                'resort the rows
                Me.dgvProperties.Sort(Me.dgvProperties.Columns(App.SortByColumn), System.ComponentModel.ListSortDirection.Ascending)
                'refilter the rows
                ApplyFilters()
                'crank up event handling back up
                AddHandler dgvProperties.CurrentCellDirtyStateChanged, AddressOf dgvProperties_CurrentCellDirtyStateChanged
            End If

        End If

    End Sub

    Private Sub dgvProperties_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles dgvProperties.RowPrePaint

        Select Case DirectCast(Me.dgvProperties.Rows(e.RowIndex), MoleDataGridViewRow).MoleRowRole

            Case MoleRowRole.NormalRow, MoleRowRole.Favorite, MoleRowRole.Data, MoleRowRole.BlackOpsRow
                Exit Sub

            Case MoleRowRole.FavoriteHeader

                Dim rect As New System.Drawing.Rectangle(0, e.RowBounds.Top, Me.dgvProperties.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) - Me.dgvProperties.HorizontalScrollingOffset + 1, e.RowBounds.Height)
                Using paintBrush As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _clrFavoriteHeaderGradientTop, _clrFavoriteHeaderGradientBottom, System.Drawing.Drawing2D.LinearGradientMode.Vertical)
                    e.Graphics.FillRectangle(paintBrush, rect)

                    If _bolShowingFavorites Then
                        e.Graphics.DrawString(STRING_HIDE_FAVORITES, _fontMoloscopeClickableHeader, Drawing.Brushes.Blue, 40, e.RowBounds.Top + 3)

                    Else
                        e.Graphics.DrawString(STRING_SHOW_FAVORITES, _fontMoloscopeClickableHeader, Drawing.Brushes.Blue, 40, e.RowBounds.Top + 3)
                    End If

                End Using
                e.Handled = True

            Case MoleRowRole.FavoriteFooter

                Dim rect As New System.Drawing.Rectangle(0, e.RowBounds.Top, Me.dgvProperties.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) - Me.dgvProperties.HorizontalScrollingOffset + 1, e.RowBounds.Height)
                Using paintBrush As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _clrFavoriteHeaderGradientTop, _clrFavoriteHeaderGradientTop, System.Drawing.Drawing2D.LinearGradientMode.Vertical)
                    e.Graphics.FillRectangle(paintBrush, rect)
                End Using
                e.Handled = True

            Case MoleRowRole.DataHeader

                Dim rect As New System.Drawing.Rectangle(0, e.RowBounds.Top, Me.dgvProperties.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) - Me.dgvProperties.HorizontalScrollingOffset + 1, e.RowBounds.Height)
                Using paintBrush As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _clrDataHeaderGradientTop, _clrDataHeaderGradientBottom, System.Drawing.Drawing2D.LinearGradientMode.Vertical)
                    e.Graphics.FillRectangle(paintBrush, rect)

                    If _bolShowingCollectionData Then
                        e.Graphics.DrawString(STRING_HIDE_COLLECTION_DATA, _fontMoloscopeClickableHeader, Drawing.Brushes.Blue, 40, e.RowBounds.Top + 3)

                    Else
                        e.Graphics.DrawString(STRING_SHOW_COLLECTION_DATA, _fontMoloscopeClickableHeader, Drawing.Brushes.Blue, 40, e.RowBounds.Top + 3)
                    End If

                End Using
                e.Handled = True

            Case MoleRowRole.DataFooter

                Dim rect As New System.Drawing.Rectangle(0, e.RowBounds.Top, Me.dgvProperties.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) - Me.dgvProperties.HorizontalScrollingOffset + 1, e.RowBounds.Height)
                Using paintBrush As New System.Drawing.Drawing2D.LinearGradientBrush(rect, _clrDataHeaderGradientBottom, _clrDataHeaderGradientTop, System.Drawing.Drawing2D.LinearGradientMode.Vertical)
                    e.Graphics.FillRectangle(paintBrush, rect)
                End Using
                e.Handled = True

            Case MoleRowRole.BlackOpsHeader

                Dim rect As New System.Drawing.Rectangle(0, e.RowBounds.Top, Me.dgvProperties.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) - Me.dgvProperties.HorizontalScrollingOffset + 1, e.RowBounds.Height)
                Using paintBrush As New System.Drawing.Drawing2D.LinearGradientBrush(rect, Drawing.Color.Black, Drawing.Color.Gray, System.Drawing.Drawing2D.LinearGradientMode.Vertical)
                    e.Graphics.FillRectangle(paintBrush, rect)

                    If _bolShowingBlackOps Then
                        e.Graphics.DrawString(STRING_HIDE_BLACK_OPS_DATA, _fontMoloscopeClickableHeader, Drawing.Brushes.White, 40, e.RowBounds.Top + 3)

                    Else
                        e.Graphics.DrawString(STRING_SHOW_BLACK_OPS_DATA, _fontMoloscopeClickableHeader, Drawing.Brushes.White, 40, e.RowBounds.Top + 3)
                    End If

                End Using
                e.Handled = True

            Case MoleRowRole.BlackOpsFooter

                Dim rect As New System.Drawing.Rectangle(0, e.RowBounds.Top, Me.dgvProperties.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) - Me.dgvProperties.HorizontalScrollingOffset + 1, e.RowBounds.Height)
                Using paintBrush As New System.Drawing.Drawing2D.LinearGradientBrush(rect, Drawing.Color.Black, Drawing.Color.DarkGray, System.Drawing.Drawing2D.LinearGradientMode.Vertical)
                    e.Graphics.FillRectangle(paintBrush, rect)
                End Using
                e.Handled = True

            Case Else
                Throw New ArgumentException("The MoleRowRole was invalid, the programmer changed the Enum but didn't program it here!")
        End Select

    End Sub

    Private Sub dgvProperties_SortCompare(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewSortCompareEventArgs) Handles dgvProperties.SortCompare

        Dim objRow1 As MoleDataGridViewRow = DirectCast(Me.dgvProperties.Rows(e.RowIndex1), MoleDataGridViewRow)
        Dim objRow2 As MoleDataGridViewRow = DirectCast(Me.dgvProperties.Rows(e.RowIndex2), MoleDataGridViewRow)

        If CType(sender, DataGridView).SortOrder = SortOrder.Descending Then
            e.SortResult = String.Compare(String.Concat(objRow1.DescendingSortKey, e.CellValue1), String.Concat(objRow2.DescendingSortKey, e.CellValue2), StringComparison.Ordinal)

        Else
            e.SortResult = String.Compare(String.Concat(objRow1.AscendingSortKey, e.CellValue1), String.Concat(objRow2.AscendingSortKey, e.CellValue2), StringComparison.Ordinal)
        End If

        e.Handled = True

    End Sub

    Private Sub DisplayTreeElementData(ByVal objTreeNode As TreeNode)

        Dim objMoleTreeNode As MoleTreeNode = CType(objTreeNode, MoleTreeNode)

        Select Case Me.tcProperties.SelectedIndex

            Case INTEGER_TAB_PAGE_VIEW_SELECTED_ELEMENT_PROPERTIES
                LoadGrid(objMoleTreeNode)

            Case _intTabPageViewSelectedElementVisual
                LoadImage(objMoleTreeNode)

            Case _intTabPageViewSelectedElementXAML
                LoadXAML(objMoleTreeNode)
        End Select

    End Sub

    Private Sub EditPropertyValue(ByVal row As Mole.MoleDataGridViewRow)

        If Not row.IsEditable Then
            Exit Sub
        End If

        Dim strCurrentValue As String = DirectCast(row.Cells(INTEGER_COLUMNINDEX_VALUE).Value, String)

        If String.Equals(strCurrentValue, STRING_NULL) Then
            strCurrentValue = String.Empty
        End If

        Dim objEditor As New MoleEditor()
        Dim editInfo As Mole.EditInfoResponse

        Try
            editInfo = GetEditInfo(row)

        Catch ex As Exception
            MessageBox.Show(String.Format("Cannot perform edit operation. {0}{1}", Environment.NewLine, ex.Message), "Edit Property", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        AddHandler objEditor.WriteEdit, AddressOf WriteMoleEdits
        objEditor.ShowDialog(strCurrentValue, row.Cells(INTEGER_COLUMNINDEX_NAME).Value.ToString(), editInfo, row, GetCurrentTreeNodeVisual, App)
        RemoveHandler objEditor.WriteEdit, AddressOf WriteMoleEdits

    End Sub

    Private Function GetCurrentTreeNodeVisual() As System.Drawing.Bitmap

        Dim objTreeNode As MoleTreeNode = ActiveMoleTreeViewSelectedNode

        If objTreeNode Is Nothing Then
            Return Nothing
        End If

        Dim objVisual As System.Drawing.Bitmap = Nothing
        Using objRequestData As New System.IO.MemoryStream
            MoleVisualizerObjectSource.Serialize(objRequestData, New TransferDataRequest(False, TransferDataRequestType.Image, ActiveTransferDataTreeTarget, objTreeNode.TreeElement.Id))
            Using objReturnData As System.IO.Stream = _objectProvider.TransferData(objRequestData)
                objVisual = CType(MoleVisualizerObjectSource.Deserialize(objReturnData), System.Drawing.Bitmap)
                objRequestData.Close()
            End Using
            objRequestData.Close()
        End Using
        Return objVisual

    End Function

    Private Function GetEditInfo(ByVal row As Mole.MoleDataGridViewRow) As EditInfoResponse

        Dim strPropertyName As String = row.Cells(INTEGER_COLUMNINDEX_NAME).Value.ToString()
        Dim intParentElementTreeDictionaryKeyId As Integer = CType(row.Cells(INTEGER_COLUMNINDEX_ID).Value, Integer)
        Dim response As Object = Nothing
        Using objRequestData As New System.IO.MemoryStream
            MoleVisualizerObjectSource.Serialize(objRequestData, New TransferDataRequest(Me.ActiveTransferDataTreeTarget, intParentElementTreeDictionaryKeyId, Me.mcMoleCrumbs.ThisElementTreeDictionaryKeyId, strPropertyName))
            Using objReturnData As System.IO.Stream = _objectProvider.TransferData(objRequestData)
                response = MoleVisualizerObjectSource.Deserialize(objReturnData)
                objReturnData.Close()
            End Using
            objRequestData.Close()
        End Using

        If TypeOf response Is Exception Then
            Throw DirectCast(response, Exception)
        End If

        Return CType(response, EditInfoResponse)

    End Function

    Private Sub InitializeDrillableCell(ByVal cell As DataGridViewLinkCell, ByVal isDrillable As Boolean)
        With cell

            If isDrillable Then
                .ToolTipText = "Drill into"
                .LinkBehavior = LinkBehavior.SystemDefault
                .LinkVisited = False
                .TrackVisitedState = True

            Else
                .ToolTipText = String.Empty
                .Style.ForeColor = Drawing.Color.Black
                .ActiveLinkColor = Drawing.Color.Black
                .LinkBehavior = LinkBehavior.NeverUnderline
                .LinkColor = Drawing.Color.Black
                .LinkVisited = False
                .TrackVisitedState = False
                .VisitedLinkColor = Drawing.Color.Black
            End If

        End With

    End Sub

    Private Sub LazyLoadElementProperties(ByRef objTreeElement As TreeElement)
        Using objRequestData As New System.IO.MemoryStream
            MoleVisualizerObjectSource.Serialize(objRequestData, New TransferDataRequest(True, TransferDataRequestType.Properties, ActiveTransferDataTreeTarget, objTreeElement.Id))
            Using objReturnData As System.IO.Stream = _objectProvider.TransferData(objRequestData)
                objTreeElement.Properties = CType(MoleVisualizerObjectSource.Deserialize(objReturnData), List(Of TreeElementProperty))
                objReturnData.Close()
            End Using
            objRequestData.Close()
        End Using

    End Sub

    Private Sub LoadGrid(ByVal objTreeNode As MoleTreeNode)

        'uses lazy load for element properteis
        '
        'Always retreive the properties when editing is allowed since property values can change.
        '
        Dim strTypeName As String = objTreeNode.TreeElement.TypeName

        If Me.cbShowNamespaces.Checked Then
            strTypeName = objTreeNode.TreeElement.TypeFullName
        End If

        If _bolAllowEditing OrElse objTreeNode.TreeElement.Properties Is Nothing OrElse objTreeNode.TreeElement.Properties.Count = 0 Then
            LazyLoadElementProperties(objTreeNode.TreeElement)

            If objTreeNode.TreeElement.ObjectName.Length = 0 Then

                Dim strBoldWords() As String = {strTypeName}
                SetRTFLableMessage(rtbPropertiesStatus, String.Format(STRING_ELEMENT_SELECTED_LABEL_FETCHED_NO_NAME, Me.ActiveTransferDataTreeTarget.ToString, strTypeName), strBoldWords)

            Else

                Dim strBoldWords() As String = {strTypeName, objTreeNode.TreeElement.ObjectName}
                SetRTFLableMessage(rtbPropertiesStatus, String.Format(STRING_ELEMENT_SELECTED_LABEL_FETCHED_WITH_NAME, Me.ActiveTransferDataTreeTarget.ToString, strTypeName, objTreeNode.TreeElement.ObjectName), strBoldWords)
            End If

        Else
            CleanDrillingOperation()

            If objTreeNode.TreeElement.ObjectName.Length = 0 Then

                Dim strBoldWords() As String = {strTypeName}
                SetRTFLableMessage(rtbPropertiesStatus, String.Format(STRING_ELEMENT_SELECTED_LABEL_CACHED_NO_NAME, Me.ActiveTransferDataTreeTarget.ToString, strTypeName), strBoldWords)

            Else

                Dim strBoldWords() As String = {strTypeName, objTreeNode.TreeElement.ObjectName}
                SetRTFLableMessage(rtbPropertiesStatus, String.Format(STRING_ELEMENT_SELECTED_LABEL_CACHED_WITH_NAME, Me.ActiveTransferDataTreeTarget.ToString, strTypeName, objTreeNode.TreeElement.ObjectName), strBoldWords)
            End If

        End If

        With Me.dgvProperties
            .SuspendLayout()
            .ScrollBars = ScrollBars.None
            .Rows.Clear()

            If .Columns.Count = 0 Then

                '
                'column 0
                Dim objIsFavoriteColumn As New DataGridViewCheckBoxColumn
                With objIsFavoriteColumn
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .Width = 35
                    .HeaderText = "Fav"
                    .Name = "IsFavoriteColumn"
                    .SortMode = DataGridViewColumnSortMode.Automatic
                    .ReadOnly = False
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Resizable = DataGridViewTriState.False
                End With
                .Columns.Add(objIsFavoriteColumn)

                '
                'column 1
                Dim objNameLinkColumn As New DataGridViewLinkColumn
                With objNameLinkColumn
                    .Name = "Name"
                    .HeaderText = "Name"
                    .CellTemplate.ToolTipText = "Search property on Google.com"
                    .SortMode = DataGridViewColumnSortMode.Automatic
                End With
                .Columns.Add(objNameLinkColumn)

                '
                'column 2
                .Columns.Add("CompareValue", "Compare Value")
                .Columns(INTEGER_COLUMNINDEX_COMPAREVALUE).Visible = False

                '
                'column 3
                Dim objValueLinkColumn As New DataGridViewLinkColumn
                With objValueLinkColumn
                    .Name = "Value"
                    .HeaderText = "Value"
                    .Width = 150
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .SortMode = DataGridViewColumnSortMode.Automatic
                    .ContextMenuStrip = Me.EditColumnContextMenu
                End With
                .Columns.Add(objValueLinkColumn)

                'column 4
                Dim objEditColumn As New DataGridViewImageColumn
                With objEditColumn
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .DefaultCellStyle.NullValue = Nothing
                    .Width = 30
                    .HeaderText = "Edit"
                    .Name = "EditValue"
                    .SortMode = DataGridViewColumnSortMode.Automatic
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Visible = Me._bolAllowEditing
                    .Resizable = DataGridViewTriState.False
                    .ContextMenuStrip = Me.EditColumnContextMenu
                End With
                .Columns.Add(objEditColumn)
                '
                'column 5
                .Columns.Add("PropertyType", "Type")
                '
                'column 6
                .Columns.Add("ValueSource", "Value Source")

                If Me.MoleMode = MoleMode.WPF Then
                    .Columns(INTEGER_COLUMNINDEX_VALUESOURCE).Visible = Not App.HideValueSourceColumn

                Else
                    .Columns(INTEGER_COLUMNINDEX_VALUESOURCE).Visible = False
                End If

                '
                'column 7
                .Columns.Add("Category", "Category Name")
                .Columns(INTEGER_COLUMNINDEX_CATEGORY).Visible = Not App.HideCategoryColumn

                '
                'column 8
                Dim objIsDependencyPropertyColumn As New DataGridViewCheckBoxColumn
                With objIsDependencyPropertyColumn
                    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    .Width = 35
                    .HeaderText = "Is DP"
                    .Name = "IsDependencyProperty"
                    .SortMode = DataGridViewColumnSortMode.Automatic
                    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Visible = Not App.HideIsDependencyPropertyColumn
                    .Resizable = DataGridViewTriState.False
                End With
                .Columns.Add(objIsDependencyPropertyColumn)

                If Me.MoleMode = MoleMode.WPF Then
                    .Columns(INTEGER_COLUMNINDEX_IS_DEPENDENCY_PROPERTY).Visible = Not App.HideIsDependencyPropertyColumn

                Else
                    .Columns(INTEGER_COLUMNINDEX_IS_DEPENDENCY_PROPERTY).Visible = False
                End If

                '
                'column 9
                .Columns.Add("ID", "")
                .Columns(INTEGER_COLUMNINDEX_ID).Visible = False

                '
                For Each obj As DataGridViewColumn In .Columns

                    If obj.Index <> INTEGER_COLUMNINDEX_IS_FAVORITE Then
                        obj.ReadOnly = True
                    End If

                Next

            End If

            Me.cbHideMatching.Enabled = False
            Me.dgvProperties.Columns(INTEGER_COLUMNINDEX_COMPAREVALUE).Visible = False

            Dim intRowIndex As Integer

            For Each obj As TreeElementProperty In objTreeNode.TreeElement.Properties

                Dim bolIsFavorite As Boolean = App.Favorites.ContainsKey(obj.Name)
                Dim enumMoleRowRole As MoleRowRole = MoleRowRole.NormalRow

                If bolIsFavorite Then

                    enumMoleRowRole = MoleRowRole.Favorite

                ElseIf obj.Category.StartsWith(STRING_LEFT_BLACK_OPS_MARKER) Then

                    enumMoleRowRole = MoleRowRole.BlackOpsRow
                End If

                Dim objEditColumnValue As Object = IIf(obj.IsEditable, EditColumnImage, Nothing)
                intRowIndex = .Rows.Add(New MoleDataGridViewRow(Me.dgvProperties, obj.PropertyType, obj.PropertyTypeFullName, obj.IsDrillable, enumMoleRowRole, obj.IsEditable, obj.CanReset, bolIsFavorite, obj.Name, String.Empty, obj.Value, objEditColumnValue, obj.GetTypeName(Me.cbShowNamespaces.Checked), obj.ValueSource, obj.Category, obj.IsDependencyProperty, objTreeNode.TreeElement.Id))

                CType(.Rows(intRowIndex).Cells(INTEGER_COLUMNINDEX_PROPERTYTYPE), DataGridViewCell).ToolTipText = obj.PropertyTypeFullName

                Dim objValueCell As DataGridViewLinkCell = CType(.Rows(intRowIndex).Cells(INTEGER_COLUMNINDEX_VALUE), DataGridViewLinkCell)
                InitializeDrillableCell(objValueCell, obj.IsDrillable)

                If enumMoleRowRole = MoleRowRole.BlackOpsRow Then

                    Dim objNameCell As DataGridViewLinkCell = CType(.Rows(intRowIndex).Cells(INTEGER_COLUMNINDEX_NAME), DataGridViewLinkCell)
                    With objNameCell
                        .Style.ForeColor = Drawing.Color.Black
                        .ActiveLinkColor = Drawing.Color.Black
                        .LinkBehavior = LinkBehavior.NeverUnderline
                        .LinkColor = Drawing.Color.Black
                        .LinkVisited = False
                        .TrackVisitedState = False
                        .VisitedLinkColor = Drawing.Color.Black
                        .ToolTipText = String.Empty
                    End With
                End If

            Next

            'never change this code
            intRowIndex = .Rows.Add(New MoleDataGridViewRow(Me.dgvProperties, "", "", False, MoleRowRole.BlackOpsHeader, False, False, False, "WWWWWWWWWWWWWWWWWWWWWWWWW", "", "", Nothing, "", "", "", False, 0))
            .Rows(intRowIndex).Cells(INTEGER_COLUMNINDEX_NAME).ToolTipText = "Click to show/hide fields"
            .Rows(intRowIndex).Cells(INTEGER_COLUMNINDEX_IS_FAVORITE).ReadOnly = True
            '
            intRowIndex = .Rows.Add(New MoleDataGridViewRow(Me.dgvProperties, "", "", False, MoleRowRole.BlackOpsFooter, False, False, False, "", "", "", Nothing, "", "", "", False, 0))
            .Rows(intRowIndex).Cells(INTEGER_COLUMNINDEX_IS_FAVORITE).ReadOnly = True
            .Rows(intRowIndex).Height = 5
            '
            intRowIndex = .Rows.Add(New MoleDataGridViewRow(Me.dgvProperties, "", "", False, MoleRowRole.FavoriteHeader, False, False, False, "WWWWWWWWWWWWWWWWWWWWWWWWW", "", "", Nothing, "", "", "", False, 0))
            .Rows(intRowIndex).Cells(INTEGER_COLUMNINDEX_NAME).ToolTipText = "Click to show/hide favorites"
            .Rows(intRowIndex).Cells(INTEGER_COLUMNINDEX_IS_FAVORITE).ReadOnly = True
            '
            intRowIndex = .Rows.Add(New MoleDataGridViewRow(Me.dgvProperties, "", "", False, MoleRowRole.FavoriteFooter, False, False, False, "", "", "", Nothing, "", "", "", False, 0))
            .Rows(intRowIndex).Cells(INTEGER_COLUMNINDEX_IS_FAVORITE).ReadOnly = True
            .Rows(intRowIndex).Height = 5
            .Sort(.Columns(App.SortByColumn), App.SortOrder)
            ApplyFilters()
            .ResumeLayout()
            .ScrollBars = ScrollBars.Both

            For Each obj As DataGridViewRow In Me.dgvProperties.SelectedRows
                obj.Selected = False
            Next

        End With

    End Sub

    Private Sub LoadImage(ByVal objTreeNode As MoleTreeNode)

        'uses lazy load for element image
        '
        'Always get the image when editing is allowed since the visual can change when a descendant
        'or ancestor property has changed.
        '
        If _bolAllowEditing OrElse objTreeNode.TreeElement.VisualImage Is Nothing Then
            Using objRequestData As New System.IO.MemoryStream
                MoleVisualizerObjectSource.Serialize(objRequestData, New TransferDataRequest(True, TransferDataRequestType.Image, ActiveTransferDataTreeTarget, objTreeNode.TreeElement.Id))
                Using objReturnData As System.IO.Stream = _objectProvider.TransferData(objRequestData)

                    'If there was an image dispose it now.
                    '
                    If objTreeNode.TreeElement.VisualImage IsNot Nothing Then
                        objTreeNode.TreeElement.VisualImage.Dispose()
                    End If

                    objTreeNode.TreeElement.VisualImage = CType(MoleVisualizerObjectSource.Deserialize(objReturnData), System.Drawing.Bitmap)
                    Me.pbVisual.Image = objTreeNode.TreeElement.VisualImage

                    If objTreeNode.TreeElement.ObjectName.Length = 0 Then

                        Dim strBoldWords() As String = {objTreeNode.TreeElement.TypeName}
                        SetRTFLableMessage(rtbVisualStatus, String.Format(STRING_ELEMENT_SELECTED_LABEL_FETCHED_NO_NAME, Me.ActiveSourceTree, objTreeNode.TreeElement.TypeName), strBoldWords)

                    Else

                        Dim strBoldWords() As String = {objTreeNode.TreeElement.TypeName, objTreeNode.TreeElement.ObjectName}
                        SetRTFLableMessage(rtbVisualStatus, String.Format(STRING_ELEMENT_SELECTED_LABEL_FETCHED_WITH_NAME, Me.ActiveSourceTree, objTreeNode.TreeElement.TypeName, objTreeNode.TreeElement.ObjectName), strBoldWords)
                    End If

                    objReturnData.Close()
                End Using
                objRequestData.Close()
            End Using

        Else
            CleanDrillingOperation()
            Me.pbVisual.Image = objTreeNode.TreeElement.VisualImage

            If objTreeNode.TreeElement.ObjectName.Length = 0 Then

                Dim strBoldWords() As String = {objTreeNode.TreeElement.TypeName}
                SetRTFLableMessage(rtbVisualStatus, String.Format(STRING_ELEMENT_SELECTED_LABEL_CACHED_NO_NAME, Me.ActiveSourceTree, objTreeNode.TreeElement.TypeName), strBoldWords)

            Else

                Dim strBoldWords() As String = {objTreeNode.TreeElement.TypeName, objTreeNode.TreeElement.ObjectName}
                SetRTFLableMessage(rtbVisualStatus, String.Format(STRING_ELEMENT_SELECTED_LABEL_CACHED_WITH_NAME, Me.ActiveSourceTree, objTreeNode.TreeElement.TypeName, objTreeNode.TreeElement.ObjectName), strBoldWords)
            End If

        End If

    End Sub

    ''' <summary>
    ''' Processes both WPF XAML and ASP.NET HTML requests
    ''' </summary>
    Private Sub LoadXAML(ByVal objTreeNode As MoleTreeNode)
        '
        'this sub was a real challenge for me because I had to learn how to do all of this.
        'maybe in the future, the WebBrowswer control and do this without developers having to feed it a stylesheet that it ALREADY has access to, but we can't use.  :-(
        '   1.  web browswer control transforms xml
        '   2.  finally found out about defaultss.xml and defaultss.xslt.  
        '   3.  learned to edit the xslt which I have never done.  The defaultss.xslt I downloaded didn't indent property, so I did some editing so the transformation would look OK. 
        '   4.  learned to use XslCompiledTransform
        '   5.  learned to feed the web browser control a stream of previously transformed xml
        '
        'because so much work went into getting this to work, I've actually placed some comments in here.
        Me.Cursor = Cursors.WaitCursor
        Me.webXAML.DocumentText = "<html><body></body></html>"
        Application.DoEvents()

        Try
            'conversation with the Visualzier Data Source
            '
            '1. need a stream
            Using objRequestData As New System.IO.MemoryStream
                '2. serialize request to stream
                MoleVisualizerObjectSource.Serialize(objRequestData, New TransferDataRequest(True, TransferDataRequestType.XAML, ActiveTransferDataTreeTarget, objTreeNode.TreeElement.Id))
                '3.  using request, ask Visualizer Data Source for XAML that represents the dependency object in the request
                Using objReturnData As System.IO.Stream = _objectProvider.TransferData(objRequestData)
                    '4.  read the response from Visualizer Data Source
                    Using objStreamReader As New System.IO.StreamReader(objReturnData)

                        '5.  read the XSLT stylesheet from project resources
                        '    this code allows the user to select the format that the XAML is displayed in the browser
                        Dim strXSLT As String

                        If App.HTMLFormat = HTMLFormat.Compressed Then
                            strXSLT = My.Resources.defaultssnotree

                        Else
                            strXSLT = My.Resources.defaultss
                        End If

                        Using sr As New System.IO.StringReader(strXSLT)

                            '6.  create xpath doc from XSLT stylesheet
                            Dim docXSLT As New XPath.XPathDocument(sr)

                            '7.  fire up the xsl transformer and load the xslt document
                            Dim objXslTransform As New Xml.Xsl.XslCompiledTransform
                            objXslTransform.Load(docXSLT)

                            '8.  need another stream
                            Dim ms As New System.IO.MemoryStream

                            '9.  need an xmlreader.  Created from the Visualizer Data Source response
                            Dim xmlReader As XmlReader = xmlReader.Create(objStreamReader)
                            '10.  perform the transform using XML(XAML) and XSLT
                            objXslTransform.Transform(xmlReader, Nothing, ms)
                            '11.  clean up
                            xmlReader.Close()
                            '12.  must move memory stream to the beginning of the stream
                            ms.Position = 0
                            '13.  feed web browser control our stream
                            Me.webXAML.DocumentStream = ms

                            '14.  See the WebBrowser.DocumentCompleted event for the rest of the code required to make lazy loading work
                            If objTreeNode.TreeElement.ObjectName.Length = 0 Then

                                Dim strBoldWords() As String = {objTreeNode.TreeElement.TypeName}
                                SetRTFLableMessage(rtbXAMLStatus, String.Format(STRING_ELEMENT_SELECTED_LABEL_RENDERED_NO_NAME, Me.ActiveSourceTree, objTreeNode.TreeElement.TypeName, [Enum].GetName(GetType(HTMLFormat), App.HTMLFormat).ToLower), strBoldWords)

                            Else

                                Dim strBoldWords() As String = {objTreeNode.TreeElement.TypeName, objTreeNode.TreeElement.ObjectName}
                                SetRTFLableMessage(rtbXAMLStatus, String.Format(STRING_ELEMENT_SELECTED_LABEL_RENDERED_WITH_NAME, Me.ActiveSourceTree, objTreeNode.TreeElement.TypeName, objTreeNode.TreeElement.ObjectName, [Enum].GetName(GetType(HTMLFormat), App.HTMLFormat).ToLower), strBoldWords)
                            End If

                            sr.Close()
                            objStreamReader.Close()
                            objReturnData.Close()
                            objRequestData.Close()
                        End Using
                    End Using
                End Using
            End Using

        Catch ex As Exception

            If ex.Message.StartsWith("Function evaluation was aborted") Then
                MessageBox.Show("Bummer.  When you attemped to view the XAML, System.Windows.Markup.XamlWriter.Save function corrupted the stack.  This issue is with XamlWriter.Save.  This program will now close.  Please reopen and select an element down the element tree.  Maybe this will be fixed in 3.5?" & vbCrLf & vbCrLf & ex.ToString, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Close()
                Exit Sub

            Else
                MessageBox.Show("Bummer.  " & ex.ToString, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Finally
            Me.Cursor = Cursors.Arrow
        End Try

    End Sub

    Private Sub mcMoleCrumbs_MoleCrumbClick(ByVal sender As Object, ByVal e As MoleCrumbEventArgs) Handles mcMoleCrumbs.MoleCrumbClick
        _bolConductingDrillingOperation = True
        Me.txtSearchText.Text = e.SearchText
        _bolConductingDrillingOperation = False

        If e.ParentElementTreeDictionaryKeyId = 0 Then

            'this means the root MoleCrumb was clicked
            Dim objSelectedMoleTreeNode As MoleTreeNode = ActiveMoleTreeViewSelectedNode

            If objSelectedMoleTreeNode IsNot Nothing Then
                Me.mcMoleCrumbs.Clear(objSelectedMoleTreeNode.TreeElement.TypeName, objSelectedMoleTreeNode.TreeElement.TypeFullName, e.SearchText, False)

            Else
                Me.mcMoleCrumbs.Clear(String.Empty, String.Empty, String.Empty, False)
            End If

            If Me.rtbPropertiesStatus.Text.StartsWith("Drilling into") Then
                Me.rtbPropertiesStatus.Text.Replace("Drilling into", "")
            End If

            DisplayTreeElementData(CType(Me.ActiveMoleTreeView.SelectedNode, MoleTreeNode))

        Else
            'non-root MoleCrumb clicked
            ConductDrillingOperation(e.ParentElementTreeDictionaryKeyId, e.Text, e.SearchText, True, e.IsBlackOps)
        End If

        Me.btnClearSearch.Visible = Me.txtSearchText.Text.Length > 0

    End Sub

    Private Sub mcMoleCrumbs_MoleViewDataClick(ByVal sender As Object, ByVal e As MoleCrumbEventArgs) Handles mcMoleCrumbs.MoleViewDataClick

        Dim ds As DataSet
        Using objRequestData As New System.IO.MemoryStream
            MoleVisualizerObjectSource.Serialize(objRequestData, New TransferDataRequest(False, TransferDataRequestType.GetDataSet, ActiveTransferDataTreeTarget, Me.mcMoleCrumbs.ParentElementTreeDictionaryKeyId, Me.mcMoleCrumbs.ThisElementTreeDictionaryKeyId, String.Empty, Me.trackBarMaxRowsInCollectionData.Value))
            Using objReturnData As System.IO.Stream = _objectProvider.TransferData(objRequestData)
                ds = CType(MoleVisualizerObjectSource.Deserialize(objReturnData), DataSet)
            End Using
        End Using

        If ds IsNot Nothing Then
            Using frm As New frmCollectionItemViewer
                frm.lblObjectDataType.Text = String.Format("Viewing {0} data.", e.Text)
                frm.BuildGrid(ds)
                frm.ShowDialog()
            End Using
        End If

    End Sub

    Private Sub SetRTFLableMessage(ByVal objRichTextBox As System.Windows.Forms.RichTextBox, ByVal strMessage As String, ByVal strBoldWords() As String)
        objRichTextBox.Clear()
        objRichTextBox.Text = strMessage
        _strLastRichTextMessage = strMessage
        ReDim _strLastRichTextBoldWords(strBoldWords.GetUpperBound(0))
        Array.Copy(strBoldWords, _strLastRichTextBoldWords, strBoldWords.Length)

        For Each s As String In strBoldWords

            Dim intX As Integer = objRichTextBox.Find(s, RichTextBoxFinds.WholeWord)

            While intX > -1
                objRichTextBox.SelectionFont = New System.Drawing.Font(objRichTextBox.Font, System.Drawing.FontStyle.Bold)
                intX = objRichTextBox.Find(s, intX + 1, RichTextBoxFinds.WholeWord)
            End While

        Next

    End Sub

    Private Function UpdatePropertyValue(ByVal row As Mole.MoleDataGridViewRow, ByRef strNewValue As String, ByRef strErrorMessage As String) As Boolean

        Dim strPropertyName As String = row.Cells(INTEGER_COLUMNINDEX_NAME).Value.ToString()
        Dim intParentElementTreeDictionaryKeyId As Integer = CType(row.Cells(INTEGER_COLUMNINDEX_ID).Value, Integer)
        Dim valueCell As DataGridViewCell = row.Cells(INTEGER_COLUMNINDEX_VALUE)
        Dim valueSourceCell As DataGridViewCell = row.Cells(INTEGER_COLUMNINDEX_VALUESOURCE)
        Dim bolSuccess As Boolean = True
        Using objRequestData As New System.IO.MemoryStream
            MoleVisualizerObjectSource.Serialize(objRequestData, New TransferDataRequest(Me.ActiveTransferDataTreeTarget, intParentElementTreeDictionaryKeyId, Me.mcMoleCrumbs.ThisElementTreeDictionaryKeyId, strPropertyName, strNewValue))
            Using objReturnData As System.IO.Stream = _objectProvider.TransferData(objRequestData)

                Dim objResponse As Object = MoleVisualizerObjectSource.Deserialize(objReturnData)

                If TypeOf objResponse Is Exception Then
                    bolSuccess = False
                    strErrorMessage = DirectCast(objResponse, Exception).Message

                Else

                    Dim editResponse As EditOperationResponse = DirectCast(objResponse, EditOperationResponse)
                    valueCell.Value = editResponse.Value
                    strNewValue = editResponse.Value
                    valueSourceCell.Value = editResponse.ValueSource
                    row.CanReset = editResponse.CanReset

                    If row.IsDrillable <> editResponse.IsDrillable Then
                        row.IsDrillable = editResponse.IsDrillable
                        InitializeDrillableCell(CType(valueCell, DataGridViewLinkCell), editResponse.IsDrillable)
                    End If

                End If

                objReturnData.Close()
            End Using
            objRequestData.Close()
        End Using
        Return bolSuccess

    End Function

    Private Sub WriteMoleEdits(ByVal sender As Object, ByVal e As MoleEditorWriteEventArgs)

        Dim strNewValue As String = String.Empty

        If e.WriteOperation = WriteOperation.WriteValue Then
            strNewValue = e.NewValue

        Else
            strNewValue = GlobalConstants.STRING_RESET_PROPERTY_MARKER
        End If

        'FYI: editors do not raise event if value has not changed, so just change away
        If UpdatePropertyValue(e.Row, strNewValue, e.WriteErrorMessage) AndAlso e.ReturnImage Then
            e.Visual = GetCurrentTreeNodeVisual()
            e.NewValue = strNewValue
        End If

        Dim strComment As String = "'"

        If App.Language = Language.C Then
            strComment = "//"
        End If

        _sbEditLog.AppendFormat("{0}-----------------------------------------------------{1}", strComment, vbCrLf)
        _sbEditLog.AppendFormat("{0}Tree View Object Name   : {1}{2}", strComment, ActiveMoleTreeViewSelectedNode.TreeElement.ObjectName, vbCrLf)
        _sbEditLog.AppendFormat("{0}Tree View Type Full Name: {1}{2}", strComment, ActiveMoleTreeViewSelectedNode.TreeElement.TypeFullName, vbCrLf)
        _sbEditLog.AppendFormat("{0}New Value               : {1}{2}", strComment, e.NewValue, vbCrLf)
        _sbEditLog.AppendFormat("{0}Editor Type             : {1}{2}", strComment, e.EditInfoResponse.EditorType.ToString, vbCrLf)
        _sbEditLog.AppendFormat("{0}Write Operation Type    : {1}{2}", strComment, e.WriteOperation.ToString, vbCrLf)
        _sbEditLog.AppendFormat("{0}Write Error Message     : {1}{2}", strComment, e.WriteErrorMessage, vbCrLf)
        _sbEditLog.AppendLine(String.Empty)
        _sbEditLog.AppendLine(String.Empty)

    End Sub

#End Region

#Region " Property Grid Commands "

    Private Sub ApplyFilters()

        If _bolApplyingFilter Then
            Exit Sub
        End If

        If _bolByPassBatchOfApplyFilterCalls Then
            Exit Sub
        End If

        If Me.dgvProperties.RowCount = 0 Then
            Exit Sub
        End If

        _bolApplyingFilter = True
        Me.dgvProperties.SuspendLayout()

        Dim bolHasBlackOps As Boolean = False
        Dim bolHasFavorites As Boolean = False
        Dim bolIsAlternateRow As Boolean = False
        Dim bolShowOnlyCollection As Boolean = False
        Dim intFavoritesHeaderRowIndex As Integer
        Dim intFavoritesFooterRowIndex As Integer
        Dim intBlackOpsFooterRowIndex As Integer
        Dim intBlackOpsHeaderRowIndex As Integer

        For Each row As MoleDataGridViewRow In Me.dgvProperties.Rows
            row.Selected = False
            row.Frozen = False

            If Me.txtSearchText.Text.Length > 0 AndAlso (row.MoleRowRole = MoleRowRole.NormalRow OrElse row.MoleRowRole = MoleRowRole.BlackOpsRow) Then

                Select Case Me.cboLookIn.SelectedIndex

                    Case INTEGER_SEARCH_PROPERTY_NAME_BEGINNING

                        If Not row.Cells(INTEGER_COLUMNINDEX_NAME).Value.ToString.StartsWith(Me.txtSearchText.Text, StringComparison.InvariantCultureIgnoreCase) Then
                            row.Visible = False
                            Continue For
                        End If

                    Case INTEGER_SEARCH_PROPERTY_NAME_ANYWHERE

                        If row.Cells(INTEGER_COLUMNINDEX_NAME).Value.ToString.IndexOf(Me.txtSearchText.Text, StringComparison.InvariantCultureIgnoreCase) = -1 Then
                            row.Visible = False
                            Continue For
                        End If

                    Case INTEGER_SEARCH_VALUE_BEGINNING

                        If Not row.Cells(INTEGER_COLUMNINDEX_VALUE).Value.ToString.StartsWith(Me.txtSearchText.Text, StringComparison.InvariantCultureIgnoreCase) Then
                            row.Visible = False
                            Continue For
                        End If

                    Case INTEGER_SEARCH_VALUE_ANYWHERE

                        If row.Cells(INTEGER_COLUMNINDEX_VALUE).Value.ToString.IndexOf(Me.txtSearchText.Text, StringComparison.InvariantCultureIgnoreCase) = -1 Then
                            row.Visible = False
                            Continue For
                        End If

                    Case Else
                        MessageBox.Show("You must have changed the code and didn't program for this search location.", "Programmer Didn't Program This Value", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Select

            End If

            If Not Me.cbShowAttachedProperties.Checked AndAlso row.Cells(INTEGER_COLUMNINDEX_NAME).Value.ToString.Contains(".") AndAlso row.MoleRowRole = MoleRowRole.NormalRow Then
                row.Visible = False
                Continue For
            End If

            If row.MoleRowRole <> MoleRowRole.NormalRow Then

                If Not Me.cbShowBlackOps.Checked AndAlso row.MoleRowRole = MoleRowRole.BlackOpsRow Then
                    row.Visible = False
                    Continue For

                ElseIf Me.cbShowBlackOps.Checked AndAlso row.MoleRowRole = MoleRowRole.BlackOpsRow Then
                    bolHasBlackOps = True
                End If

                If row.IsFavorite AndAlso row.MoleRowRole <> MoleRowRole.FavoriteHeader AndAlso row.MoleRowRole <> MoleRowRole.FavoriteFooter Then
                    bolHasFavorites = True
                End If

                If Not _bolShowingCollectionData AndAlso row.MoleRowRole = MoleRowRole.Data Then
                    row.Visible = False
                    Continue For
                End If

                If Not _bolShowingFavorites AndAlso row.MoleRowRole = MoleRowRole.Favorite Then
                    row.Visible = False
                    Continue For
                End If

                If Not _bolShowingBlackOps AndAlso row.MoleRowRole = MoleRowRole.BlackOpsRow Then
                    row.Visible = False
                    Continue For
                End If

                If row.MoleRowRole = MoleRowRole.FavoriteHeader Then
                    intFavoritesHeaderRowIndex = row.Index
                End If

                If row.MoleRowRole = MoleRowRole.BlackOpsFooter Then
                    intBlackOpsFooterRowIndex = row.Index
                End If

                If row.MoleRowRole = MoleRowRole.BlackOpsHeader Then
                    intBlackOpsHeaderRowIndex = row.Index
                End If

                If row.MoleRowRole = MoleRowRole.FavoriteFooter Then
                    intFavoritesFooterRowIndex = row.Index
                End If

            End If

            If bolIsAlternateRow Then

                Select Case row.MoleRowRole

                    Case MoleRowRole.NormalRow
                        row.DefaultCellStyle.BackColor = Drawing.Color.WhiteSmoke

                    Case MoleRowRole.Favorite
                        row.DefaultCellStyle.BackColor = _clrFavoriteAlternateRow
                        row.Frozen = True

                    Case MoleRowRole.Data
                        row.DefaultCellStyle.BackColor = _clrDataAlternateRow

                    Case MoleRowRole.BlackOpsRow
                        row.DefaultCellStyle.BackColor = Drawing.Color.LightGray
                End Select

            Else

                Select Case row.MoleRowRole

                    Case MoleRowRole.NormalRow
                        row.DefaultCellStyle.BackColor = Drawing.Color.White

                    Case MoleRowRole.Favorite
                        row.DefaultCellStyle.BackColor = _clrFavoriteNormalRow
                        row.Frozen = True

                    Case MoleRowRole.Data
                        row.DefaultCellStyle.BackColor = _clrDataNormalRow

                    Case MoleRowRole.BlackOpsRow
                        row.DefaultCellStyle.BackColor = Drawing.Color.WhiteSmoke
                End Select

            End If

            bolIsAlternateRow = Not bolIsAlternateRow
            row.Visible = True
        Next

        '
        Me.dgvProperties.Rows(intFavoritesHeaderRowIndex).Frozen = bolHasFavorites
        Me.dgvProperties.Rows(intFavoritesHeaderRowIndex).Visible = bolHasFavorites
        Me.dgvProperties.Rows(intFavoritesFooterRowIndex).Frozen = bolHasFavorites
        Me.dgvProperties.Rows(intFavoritesFooterRowIndex).Visible = bolHasFavorites
        '
        Me.dgvProperties.Rows(intBlackOpsFooterRowIndex).Visible = bolHasBlackOps
        Me.dgvProperties.Rows(intBlackOpsHeaderRowIndex).Visible = bolHasBlackOps
        '
        Me.dgvProperties.ResumeLayout()
        _bolApplyingFilter = False

    End Sub

    Private Sub btnClearSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearSearch.Click

        If Not ObjectTreeViewReady Then
            Exit Sub
        End If

        _bolByPassBatchOfApplyFilterCalls = True
        Me.txtSearchText.Text = String.Empty
        Me.btnClearSearch.Visible = False
        _bolByPassBatchOfApplyFilterCalls = False
        ApplyFilters()

    End Sub

    Private Sub cboLookIn_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLookIn.SelectedIndexChanged

        If Not ObjectTreeViewReady Then
            Exit Sub
        End If

        App.SearchLocationIndex = Me.cboLookIn.SelectedIndex

        If Me.txtSearchText.Text.Length > 0 Then
            ApplyFilters()
        End If

    End Sub

    Private Sub cbShowAttachedProperties_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbShowAttachedProperties.CheckedChanged

        If Not ObjectTreeViewReady Then
            Exit Sub
        End If

        App.ShowAttachedProperties = Me.cbShowAttachedProperties.Checked
        ApplyFilters()

    End Sub

    Private Sub cbShowBlackOps_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbShowBlackOps.CheckedChanged

        If Not ObjectTreeViewReady Then
            Exit Sub
        End If

        App.ShowBlackOps = Me.cbShowBlackOps.Checked
        ApplyFilters()

    End Sub

    Private Sub cbShowNamespaces_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbShowNamespaces.CheckedChanged
        App.ShowNamespaces = Me.cbShowNamespaces.Checked
        ShowNamespaces()

    End Sub

    Private Sub txtSearchText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearchText.TextChanged

        If Not ObjectTreeViewReady OrElse _bolConductingDrillingOperation Then
            Exit Sub
        End If

        Me.btnClearSearch.Visible = Me.txtSearchText.Text.Length > 0
        Me.mcMoleCrumbs.SetSearchTextForActiveMoleCrumb(Me.txtSearchText.Text)
        ApplyFilters()

    End Sub

#End Region

#Region " Visual Commands "

    Private Sub btnCopyImageToClipBoard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyImageToClipBoard.Click

        If Me.pbVisual.Image IsNot Nothing Then
            My.Computer.Clipboard.Clear()
            My.Computer.Clipboard.SetImage(Me.pbVisual.Image)
        End If

    End Sub

#End Region

#Region " XAML Commands "

    Private Sub btnDecreaseFontSize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDecreaseFontSize.Click
        App.XAMLTextFontSize -= 2

        If App.XAMLTextFontSize < 6 Then
            App.XAMLTextFontSize = 6
        End If

        Me.webXAML.Document.Body.Style = String.Format("font-size:{0}pt;", App.XAMLTextFontSize)

    End Sub

    Private Sub btnIncreaseFontSize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIncreaseFontSize.Click
        App.XAMLTextFontSize += 2

        If App.XAMLTextFontSize > 36 Then
            App.XAMLTextFontSize = 36
        End If

        Me.webXAML.Document.Body.Style = String.Format("font-size:{0}pt;", App.XAMLTextFontSize)

    End Sub

    Private Sub rdoViewHTMLAttributesOnSeparateLine_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoViewHTMLAttributesOnSeparateLine.CheckedChanged

        If Me.rdoViewHTMLAttributesOnSeparateLine.Checked Then
            App.HTMLFormat = HTMLFormat.Expanded

            If Me.ActiveMoleTreeView.SelectedNode IsNot Nothing Then
                LoadXAML(CType(Me.ActiveMoleTreeView.SelectedNode, MoleTreeNode))
            End If

        End If

    End Sub

    Private Sub rdoViewHTMLAttributesOnSingleLine_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoViewHTMLAttributesOnSingleLine.CheckedChanged

        If Me.rdoViewHTMLAttributesOnSingleLine.Checked Then
            App.HTMLFormat = HTMLFormat.Compressed

            If Me.ActiveMoleTreeView.SelectedNode IsNot Nothing Then
                LoadXAML(CType(Me.ActiveMoleTreeView.SelectedNode, MoleTreeNode))
            End If

        End If

    End Sub

    Private Sub webXAML_DocumentCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles webXAML.DocumentCompleted
        'HACK developers how to change the font size of the WebBrowswer control
        Me.webXAML.Document.Body.Style = String.Format("font-size:{0}pt;", App.XAMLTextFontSize)

    End Sub

#End Region

#Region " Element Tree Commands "

    Private Sub ApplyTreeItemAction(ByVal objNode As TreeNode, ByVal enumAction As TreeItemAction)

        If enumAction = TreeItemAction.Expand Then
            objNode.Expand()

        Else
            objNode.Collapse()
        End If

        For Each obj As TreeNode In objNode.Nodes
            ApplyTreeItemAction(obj, enumAction)
        Next

        Me.ActiveMoleTreeView.Focus()

    End Sub

    Private Sub btnCollapseAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCollapseAll.Click

        If Not ObjectTreeViewReady Then
            Exit Sub
        End If

        ActiveMoleTreeView.CollapseAll()
        ActiveMoleTreeView.SelectFirstNode()

        Dim objSelectedMoleTreeNode As MoleTreeNode = ActiveMoleTreeViewSelectedNode

        If objSelectedMoleTreeNode IsNot Nothing Then
            Me.mcMoleCrumbs.Clear(objSelectedMoleTreeNode.TreeElement.TypeName, objSelectedMoleTreeNode.TreeElement.TypeFullName, Me.txtSearchText.Text, False)

        Else
            Me.mcMoleCrumbs.Clear(String.Empty, String.Empty, String.Empty, False)
        End If

        DisplayTreeElementData(ActiveMoleTreeViewSelectedNode)
        ActiveMoleTreeView.Focus()

    End Sub

    Private Sub btnCollapseDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCollapseDown.Click

        If Not ObjectTreeViewReady Then
            Exit Sub
        End If

        If ActiveMoleTreeView.SelectedNode IsNot Nothing Then
            ApplyTreeItemAction(ActiveMoleTreeView.SelectedNode, TreeItemAction.Collapse)
        End If

    End Sub

    Private Sub btnExpandAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpandAll.Click

        If Not ObjectTreeViewReady Then
            Exit Sub
        End If

        ActiveMoleTreeView.ExpandAll()

        If ActiveMoleTreeView.SelectedNode IsNot Nothing Then
            ActiveMoleTreeView.SelectedNode.EnsureVisible()
        End If

        ActiveMoleTreeView.Focus()

    End Sub

    Private Sub btnExpandDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpandDown.Click

        If Not ObjectTreeViewReady Then
            Exit Sub
        End If

        If ActiveMoleTreeView.SelectedNode IsNot Nothing Then
            ApplyTreeItemAction(ActiveMoleTreeView.SelectedNode, TreeItemAction.Expand)
        End If

    End Sub

#End Region

#Region " Saved Settings "

    Private Sub LoadApplySettings(ByVal strFileName As String)

        If Not IO.File.Exists(strFileName) Then
            _objApp = New MoleSettings

        Else

            Try
                Using fs As New System.IO.FileStream(strFileName, System.IO.FileMode.Open)
                    _objApp = CType(Mole.MoleVisualizerObjectSource.Deserialize(fs), MoleSettings)
                End Using

            Catch ex As Exception
                _objApp = New MoleSettings
                MessageBox.Show("Bummer.  Exception while loading saved settings.  Creating new settings." & vbCrLf & vbCrLf & ex.ToString, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If

        If App.HTMLFormat = HTMLFormat.Compressed Then
            Me.rdoViewHTMLAttributesOnSingleLine.Checked = True

        Else
            Me.rdoViewHTMLAttributesOnSeparateLine.Checked = True
        End If

        If App.Language = Language.C Then
            Me.rdoC.Checked = True

        Else
            Me.rdoVB.Checked = True
        End If

        Me.cbShowNamespaces.Checked = App.ShowNamespaces

        If App.ShowNamespaces Then
            Me.tvLogicalTree.ShowNamespaces = True
            Me.tvVisualTree.ShowNamespaces = True
        End If

        Me.llSavedSettingsFile.Text = _strSaveSettingsFileName
        Me.cboLookIn.SelectedIndex = App.SearchLocationIndex
        Me.cbShowAttachedProperties.Checked = App.ShowAttachedProperties
        Me.cbShowBlackOps.Checked = App.ShowBlackOps
        ' form does not need this set: App.SortByColumn
        Me.trackBarToolTipInitialDelay.Value = App.ToolTipInitialDelay
        Me.lblToolTipDelay.Text = App.ToolTipInitialDelay.ToString
        Me.ttMoleTips.InitialDelay = App.ToolTipInitialDelay
        Me.ttMoleTips.ReshowDelay = App.ToolTipInitialDelay
        Me.cbHideCategoryColumn.Checked = App.HideCategoryColumn
        Me.cbHideIsDependencyPropertyColumn.Checked = App.HideIsDependencyPropertyColumn
        Me.cbHideValueSourceColumn.Checked = App.HideValueSourceColumn

        If App.MaxRowsInCollectionData = 0 Then
            App.MaxRowsInCollectionData = 100
        End If

        Me.trackBarMaxRowsInCollectionData.Value = App.MaxRowsInCollectionData

        'form does not need this set: Me.App.XAMLTextFontSize
        '
        'HACK developers here is how you can save the position of your application, multi-monitor aware.
        'if the user closed Mole on a non primary screen set that screen by matching the name.
        'if that screen is no longer part of the system, then just use the primary screen
        Dim objActiveScreen As Screen = Screen.PrimaryScreen

        For Each objScreen As Screen In Screen.AllScreens

            If App.ScreenDeviceName = objScreen.DeviceName Then
                Me.Bounds = objScreen.Bounds
                objActiveScreen = objScreen
                Exit For
            End If

        Next

        'if the user sets their monitor resolution smaller and the window would start off their smaller screen, just move to to 10,10
        If App.WindowLocation.X > Me.Bounds.Right OrElse App.WindowLocation.Y > Me.Bounds.Bottom Then
            Me.Location = New System.Drawing.Point(10, 10)

        Else
            Me.Location = App.WindowLocation
        End If

        Me.Size = App.WindowSize
        Me.WindowState = App.WindowState
        'must be set last
        Me.SplitContainer1.SplitterDistance = App.SplitterDistance

    End Sub

    Public Sub SaveSettings(ByVal strFileName As String)

        Try

            'if the object source throws a stack over flow and somehow gets here, this code will get us out without corrupting our settings
            Dim intStackOverFlowTest As Integer = 10

        Catch ex As Exception
            Exit Sub
        End Try

        'save the screen Mole is displayed in
        App.ScreenDeviceName = Screen.FromControl(Me).DeviceName
        App.SplitterDistance = Me.SplitContainer1.SplitterDistance
        App.ToolTipInitialDelay = Me.ttMoleTips.InitialDelay
        App.HideCategoryColumn = Me.cbHideCategoryColumn.Checked
        App.HideIsDependencyPropertyColumn = Me.cbHideIsDependencyPropertyColumn.Checked
        App.HideValueSourceColumn = Me.cbHideValueSourceColumn.Checked

        'if window is maximized do not overwrite the window size, this way a window restore survives on Mole restart
        If Me.WindowState <> FormWindowState.Maximized Then
            App.WindowLocation = Me.Location
            App.WindowSize = Me.Size
        End If

        App.WindowState = Me.WindowState
        App.MaxRowsInCollectionData = Me.trackBarMaxRowsInCollectionData.Value

        Try
            Using fs As New System.IO.FileStream(strFileName, System.IO.FileMode.Create)
                Mole.MoleVisualizerObjectSource.Serialize(fs, _objApp)
            End Using

        Catch ex As Exception
            MessageBox.Show("Bummer.  Exception while saving settings." & vbCrLf & vbCrLf & ex.ToString, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

#Region " Helpers "

    Private Sub StartProcessWithFileName(ByVal strFileName As String)

        Dim psi As New System.Diagnostics.ProcessStartInfo
        psi.FileName = strFileName
        psi.UseShellExecute = True
        System.Diagnostics.Process.Start(psi)

    End Sub

#End Region

#Region " Save & Load Properties "

    Private Sub btnLoadProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadProperties.Click
        Me.OpenFileDialog1.FileName = "*.xml"

        If Me.OpenFileDialog1.ShowDialog <> Windows.Forms.DialogResult.OK Then
            Exit Sub
        End If

        Dim objExport As ExportProperties = Nothing
        Dim _objFormatter As New System.Xml.Serialization.XmlSerializer(GetType(ExportProperties))

        Try
            Using fs As New System.IO.FileStream(Me.OpenFileDialog1.FileName, System.IO.FileMode.Open)
                objExport = CType(_objFormatter.Deserialize(fs), ExportProperties)
            End Using

        Catch ex As Exception
            MessageBox.Show(String.Format("Error opening file.  Error message: {0}", ex.ToString), "File Open Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If objExport Is Nothing Then
            Exit Sub
        End If

        Me.cbHideMatching.Enabled = True
        Me.dgvProperties.Columns(INTEGER_COLUMNINDEX_COMPAREVALUE).Visible = True

        Dim ht As New Hashtable

        For Each obj As ExportProperty In objExport.ExportProperty
            ht.Add(obj.Name, obj.Value)
        Next

        For Each obj As DataGridViewRow In Me.dgvProperties.Rows

            Dim strName As String = CType(obj.Cells(INTEGER_COLUMNINDEX_NAME).Value, String)

            If ht.ContainsKey(strName) Then
                obj.Cells(INTEGER_COLUMNINDEX_COMPAREVALUE).Value = ht(strName)

                If String.Compare(obj.Cells(INTEGER_COLUMNINDEX_VALUE).Value.ToString, obj.Cells(INTEGER_COLUMNINDEX_COMPAREVALUE).Value.ToString) <> 0 Then
                    obj.Cells(INTEGER_COLUMNINDEX_COMPAREVALUE).Style.ForeColor = Drawing.Color.Red

                Else
                    obj.Cells(INTEGER_COLUMNINDEX_COMPAREVALUE).Style.ForeColor = Drawing.Color.Black
                End If

            End If

        Next

    End Sub

    Private Sub btnSaveProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveProperties.Click

        Dim objExport As New ExportProperties(Me.ActiveMoleTreeViewSelectedNode.TreeElement.ObjectName, Me.ActiveMoleTreeViewSelectedNode.TreeElement.TypeFullName, Me.ActiveMoleTreeViewSelectedNode.TreeElement.TypeName)
        Me.SaveFileDialog1.FileName = objExport.FileName

        If Me.SaveFileDialog1.ShowDialog <> Windows.Forms.DialogResult.OK Then
            Exit Sub
        End If

        For Each obj As TreeElementProperty In Me.ActiveMoleTreeViewSelectedNode.TreeElement.Properties
            objExport.ExportProperty.Add(New ExportProperty(obj.CanReset, obj.IsDependencyProperty, obj.IsDrillable, obj.IsEditable, obj.Category.StartsWith(STRING_LEFT_BLACK_OPS_MARKER), obj.Category, obj.Name, obj.PropertyType, obj.PropertyTypeFullName, obj.Value, obj.ValueSource))
        Next

        objExport.Sort()

        Dim _objFormatter As New System.Xml.Serialization.XmlSerializer(GetType(ExportProperties))

        Try
            Using fs As New System.IO.FileStream(Me.SaveFileDialog1.FileName, System.IO.FileMode.Create)
                _objFormatter.Serialize(fs, objExport)
            End Using

        Catch ex As Exception
            MessageBox.Show(String.Format("Error saving file.  Error message: {0}", ex.ToString), "File Save Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub cbHideMatching_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbHideMatching.CheckedChanged

        If Me.cbHideMatching.Checked Then

            For Each obj As MoleDataGridViewRow In Me.dgvProperties.Rows

                If String.Compare(obj.Cells(INTEGER_COLUMNINDEX_VALUE).Value.ToString, obj.Cells(INTEGER_COLUMNINDEX_COMPAREVALUE).Value.ToString) = 0 Then
                    obj.Visible = False
                End If

            Next

        Else
            ApplyFilters()
        End If

    End Sub

#End Region

End Class
