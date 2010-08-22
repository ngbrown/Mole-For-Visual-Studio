Imports System.Windows.Forms
Imports System.ComponentModel

Public Class MoleTreeView
    Inherits TreeView

#Region " Declarations "

    Private _bolShowNamespaces As Boolean = False
    Private _objInitialNode As MoleTreeNode
    Private _objTree As Tree

#End Region

#Region " Properties "

    <Description("Enable to display the full type names in the tree view"), Category("Custom"), DefaultValue(False)> _
    Public Property ShowNamespaces() As Boolean
        Get
            Return _bolShowNamespaces
        End Get
        Set(ByVal Value As Boolean)
            _bolShowNamespaces = Value
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), _
     Browsable(False)> _
    Public Property TreeData() As Tree
        Get
            Return _objTree
        End Get
        Set(ByVal value As Tree)

            If value Is Nothing Then
                Throw New ArgumentNullException("TreeData")
            End If

            _objTree = value
            Me.Nodes.Clear()

            Dim objRootMoleTreeNode As MoleTreeNode = New MoleTreeNode(_objTree.RootElement, Me.ShowNamespaces)
            Me.Nodes.Add(objRootMoleTreeNode)
            LocateInitialNode(objRootMoleTreeNode, _objTree.InitialElementId)

            If _objInitialNode IsNot Nothing Then
                _objInitialNode.BackColor = Drawing.Color.LightGreen
                SelectInitialNode()
            End If

            SelectInitialNode()
        End Set
    End Property

#End Region

#Region " Methods "

    ''' <summary>
    ''' This is Josh Smith's awesome lazy load code.  I was using a different approach but his is just better so I'm going Josh here.
    ''' </summary>
    Private Sub LazyLoadChildNodes(ByVal objParentMoleTreeNode As MoleTreeNode)
        objParentMoleTreeNode.Nodes.Clear()

        For Each objTreeElement As TreeElement In objParentMoleTreeNode.TreeElement.Children
            objParentMoleTreeNode.Nodes.Add(New MoleTreeNode(objTreeElement, Me.ShowNamespaces))
        Next

    End Sub

    ''' <summary>
    ''' This is Josh Smith's awesome lazy load code.  I was using a different approach but his is just better so I'm going Josh here.
    ''' </summary>
    Private Sub LocateInitialNode(ByVal objMoleTreeNode As MoleTreeNode, ByVal intInitialElementID As Integer)

        If objMoleTreeNode.TreeElement.Id = intInitialElementID Then
            _objInitialNode = objMoleTreeNode

        Else
            LazyLoadChildNodes(objMoleTreeNode)

            Dim objTargetMoleTreeNode As MoleTreeNode = Nothing

            For Each objChildNode As MoleTreeNode In objMoleTreeNode.Nodes

                If intInitialElementID < objChildNode.TreeElement.Id Then
                    Exit For
                End If

                objTargetMoleTreeNode = objChildNode
            Next

            If objTargetMoleTreeNode IsNot Nothing Then
                LocateInitialNode(objTargetMoleTreeNode, intInitialElementID)
            End If

        End If

    End Sub

    Private Sub SetText(ByVal objMoleTreeNode As MoleTreeNode, ByVal bolShowNamespaces As Boolean)
        objMoleTreeNode.SetText(bolShowNamespaces)

        For Each obj As TreeNode In objMoleTreeNode.Nodes

            If obj.Text <> STRING_MOLE_DUMMY_TREENODE_MARKER AndAlso TypeOf obj Is MoleTreeNode Then
                SetText(DirectCast(obj, MoleTreeNode), bolShowNamespaces)
            End If

        Next

    End Sub

    Public Sub SelectFirstNode()

        If Me.Nodes.Count <> 0 Then
            Me.SelectedNode = Me.Nodes(0)
            Me.SelectedNode.EnsureVisible()
            Me.Focus()
        End If

    End Sub

    Public Sub SelectInitialNode()

        If _objInitialNode IsNot Nothing Then
            Me.SelectedNode = _objInitialNode
            Me.SelectedNode.EnsureVisible()
            Me.Focus()
        End If

    End Sub

    Public Sub SetShowNamespaces(ByVal bolShowNamespaces As Boolean)
        Me.ShowNamespaces = bolShowNamespaces

        If Me.Nodes.Count > 0 Then

            For Each obj As MoleTreeNode In Me.Nodes
                SetText(obj, bolShowNamespaces)
            Next

        End If

    End Sub

    Protected Overrides Sub OnBeforeExpand(ByVal e As System.Windows.Forms.TreeViewCancelEventArgs)
        MyBase.OnBeforeExpand(e)

        If e.Node IsNot Nothing AndAlso e.Node.Nodes.Count = 1 AndAlso String.Compare(e.Node.Nodes(0).Text, STRING_MOLE_DUMMY_TREENODE_MARKER, StringComparison.Ordinal) = 0 Then
            LazyLoadChildNodes(DirectCast(e.Node, MoleTreeNode))
        End If

    End Sub

#End Region

End Class
