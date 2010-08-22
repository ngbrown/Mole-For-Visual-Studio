'
Public Class MoleCrumb

#Region " Declarations "

    Private _bolHasData As Boolean = False
    Private _bolIsBlackOps As Boolean = False
    Private _intParentElementTreeDictionaryKeyId As Integer
    Private _intThisElementTreeDictionaryKeyId As Integer
    Private _strFullTypeName As String = String.Empty
    Private _strSearchText As String = String.Empty
    Private _strText As String = String.Empty

#End Region

#Region " Properties "

    Public ReadOnly Property FullTypeName() As String
        Get
            Return _strFullTypeName
        End Get
    End Property

    Public ReadOnly Property HasData() As Boolean
        Get
            Return _bolHasData
        End Get
    End Property

    Public ReadOnly Property IsBlackOps() As Boolean
        Get
            Return _bolIsBlackOps
        End Get
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

#Region " Constructor "

    Public Sub New(ByVal bolHasData As Boolean, ByVal intParentElementTreeDictionaryKeyId As Integer, ByVal intThisElementTreeDictionaryKeyId As Integer, ByVal strText As String, ByVal strFullTypeName As String, ByVal strSearchText As String, ByVal bolIsBlackOps As Boolean)
        _bolHasData = bolHasData
        _intParentElementTreeDictionaryKeyId = intParentElementTreeDictionaryKeyId
        _intThisElementTreeDictionaryKeyId = intThisElementTreeDictionaryKeyId
        _strText = strText
        _strFullTypeName = strFullTypeName
        _strSearchText = strSearchText
        _bolIsBlackOps = bolIsBlackOps
    End Sub

#End Region

End Class
