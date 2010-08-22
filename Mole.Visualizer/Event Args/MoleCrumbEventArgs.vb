
Public Class MoleCrumbEventArgs
    Inherits EventArgs

#Region " Declarations "

    Private _bolIsBlackOps As Boolean = False
    Private _intParentElementTreeDictionaryKeyId As Integer
    Private _intThisElementTreeDictionaryKeyId As Integer
    Private _strSearchText As String = String.Empty
    Private _strText As String = String.Empty

#End Region

#Region " Properties "

    Public Property IsBlackOps() As Boolean
        Get
            Return _bolIsBlackOps
        End Get
        Set(ByVal Value As Boolean)
            _bolIsBlackOps = Value
        End Set
    End Property

    Public Property ParentElementTreeDictionaryKeyId() As Integer
        Get
            Return _intParentElementTreeDictionaryKeyId
        End Get
        Set(ByVal Value As Integer)
            _intParentElementTreeDictionaryKeyId = Value
        End Set
    End Property

    Public Property SearchText() As String
        Get
            Return _strSearchText
        End Get
        Set(ByVal Value As String)
            _strSearchText = Value
        End Set
    End Property

    Public Property Text() As String
        Get
            Return _strText
        End Get
        Set(ByVal Value As String)
            _strText = Value
        End Set
    End Property

    Public Property ThisElementTreeDictionaryKeyId() As Integer
        Get
            Return _intThisElementTreeDictionaryKeyId
        End Get
        Set(ByVal Value As Integer)
            _intThisElementTreeDictionaryKeyId = Value
        End Set
    End Property

#End Region

#Region " Constructors "

    Public Sub New(ByVal intParentElementTreeDictionaryKeyId As Integer, ByVal intThisElementTreeDictionaryKeyId As Integer, ByVal strText As String, ByVal strSearchText As String, ByVal bolIsBlackOps As Boolean)
        _intParentElementTreeDictionaryKeyId = intParentElementTreeDictionaryKeyId
        _intThisElementTreeDictionaryKeyId = intThisElementTreeDictionaryKeyId
        _strText = strText
        _strSearchText = strSearchText
        _bolIsBlackOps = IsBlackOps

    End Sub

    Public Sub New(ByVal obj As MoleCrumb)
        _intParentElementTreeDictionaryKeyId = obj.ParentElementTreeDictionaryKeyId
        _intThisElementTreeDictionaryKeyId = obj.ThisElementTreeDictionaryKeyId
        _strText = obj.Text
        _strSearchText = obj.SearchText
        _bolIsBlackOps = obj.IsBlackOps

    End Sub

#End Region

End Class
