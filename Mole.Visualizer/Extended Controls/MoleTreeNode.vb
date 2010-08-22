Imports System.Windows.Forms

Public Class MoleTreeNode
    Inherits System.Windows.Forms.TreeNode

#Region " Declrations "

    Private _objTreeElement As TreeElement

#End Region

#Region " Properties "

    Public Property TreeElement() As TreeElement
        Get
            Return _objTreeElement
        End Get
        Set(ByVal value As TreeElement)
            _objTreeElement = value
        End Set
    End Property

#End Region

#Region " Constructor "

    'this was modified to be sensitive to the ShowNamespaces checkbox
    Public Sub New(ByVal objTreeElement As TreeElement, ByVal bolShowNamespaces As Boolean)
        MyBase.New()
        _objTreeElement = objTreeElement

        Dim strTypeName As String = _objTreeElement.TypeName

        If bolShowNamespaces Then
            strTypeName = _objTreeElement.TypeFullName
        End If

        Me.ToolTipText = _objTreeElement.TypeFullName

        If _objTreeElement.ObjectName.Length > 0 AndAlso _objTreeElement.DescendantCount > 0 Then
            Me.Text = String.Format("{0} - {1} ({2})", strTypeName, _objTreeElement.ObjectName, _objTreeElement.DescendantCount)
            'this is part of the lazy loading system, it ensures that Tree Nodes with descendents get the (+) indicator
            Me.Nodes.Add(STRING_MOLE_DUMMY_TREENODE_MARKER)

        ElseIf _objTreeElement.ObjectName.Length > 0 Then
            Me.Text = String.Format("{0} - {1}", strTypeName, _objTreeElement.ObjectName)

        ElseIf _objTreeElement.DescendantCount > 0 Then
            Me.Text = String.Format("{0} ({1})", strTypeName, _objTreeElement.DescendantCount)
            'this is part of the lazy loading system, it ensures that Tree Nodes with descendents get the (+) indicator
            Me.Nodes.Add(STRING_MOLE_DUMMY_TREENODE_MARKER)

        Else
            Me.Text = strTypeName
        End If

    End Sub

#End Region

#Region " Methods "

    ''' <summary>
    ''' Called by MoleTreeView in response to the user clicking the ShowNamespaces checkbox.
    ''' </summary>
    Public Sub SetText(ByVal bolShowNamespaces As Boolean)

        Dim strTypeName As String = _objTreeElement.TypeName

        If bolShowNamespaces Then
            strTypeName = _objTreeElement.TypeFullName
        End If

        If _objTreeElement.ObjectName.Length > 0 AndAlso _objTreeElement.DescendantCount > 0 Then
            Me.Text = String.Format("{0} - {1} ({2})", strTypeName, _objTreeElement.ObjectName, _objTreeElement.DescendantCount)

        ElseIf _objTreeElement.ObjectName.Length > 0 Then
            Me.Text = String.Format("{0} - {1}", strTypeName, _objTreeElement.ObjectName)

        ElseIf _objTreeElement.DescendantCount > 0 Then
            Me.Text = String.Format("{0} ({1})", strTypeName, _objTreeElement.DescendantCount)

        Else
            Me.Text = strTypeName
        End If

    End Sub

#End Region

End Class
