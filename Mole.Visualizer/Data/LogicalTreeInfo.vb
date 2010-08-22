Imports System.Windows

' This class stores data used in the Logical Tree tab.
<Serializable()> _
Public NotInheritable Class LogicalTreeInfo

#Region " Public Declarations "

    ''' <summary>
    ''' The type name of the ancestor element of the original element, which is
    ''' in a logical tree.  It is possible that this element is the same as the
    ''' original element, provided that the original element is in a logical tree.
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly ClosestLogicalAncestor As String

    ''' <summary>
    ''' The type name of the element whose logical tree was requested.  Note,
    ''' this element is not necessarily in a logical tree, but it has an
    ''' ancestor element that is in a logical tree.
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly OriginalElement As String

    ''' <summary>
    ''' The type name of the element returned by the TemplatedParent property of the original element.
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly TemplatedParentOfClosestLogicalAncestor As String

#End Region

#Region " Constructor "

    Public Sub New(ByVal depObjOriginalElement As DependencyObject, ByVal depObjClosestLogicalAncestorOfOriginalElement As DependencyObject, ByVal depObjTemplatedParentOfClosestLogicalAncestor As DependencyObject)

        If depObjOriginalElement IsNot Nothing Then
            OriginalElement = depObjOriginalElement.GetType().Name

        Else
            OriginalElement = "(null)"
        End If

        If depObjClosestLogicalAncestorOfOriginalElement IsNot Nothing Then

            If depObjClosestLogicalAncestorOfOriginalElement Is depObjOriginalElement Then
                ClosestLogicalAncestor = "(self)"

            Else
                ClosestLogicalAncestor = depObjClosestLogicalAncestorOfOriginalElement.GetType().Name
            End If

        Else
            ClosestLogicalAncestor = "(null)"
        End If

        If depObjTemplatedParentOfClosestLogicalAncestor IsNot Nothing Then
            TemplatedParentOfClosestLogicalAncestor = depObjTemplatedParentOfClosestLogicalAncestor.GetType().Name

        Else
            TemplatedParentOfClosestLogicalAncestor = "(null)"
        End If

    End Sub

#End Region

End Class
