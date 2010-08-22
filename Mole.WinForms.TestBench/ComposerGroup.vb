
Public Class ComposerGroup

    Private _objComposers As New List(Of Composer)
    Private _strGroupName As String = String.Empty

    Public Property Composers() As List(Of Composer)
        Get
            Return _objComposers
        End Get
        Set(ByVal Value As List(Of Composer))
            _objComposers = Value
        End Set
    End Property

    Public ReadOnly Property GroupCount() As Integer
        Get
            Return _objComposers.Count
        End Get
    End Property

    Public Property GroupName() As String
        Get
            Return _strGroupName
        End Get
        Set(ByVal Value As String)
            _strGroupName = Value
        End Set
    End Property

    Public Sub New(ByVal strGroupName As String)
        _strGroupName = strGroupName

    End Sub

    Public Sub New(ByVal objComposers As List(Of Composer), ByVal strGroupName As String)
        _objComposers = objComposers
        _strGroupName = strGroupName

    End Sub

End Class
