'
<Serializable()> _
Public Class ExportProperty

#Region " Declarations "

    Private _bolCanReset As Boolean = False
    Private _bolIsDependencyProperty As Boolean = False
    Private _bolIsDrillable As Boolean = False
    Private _bolIsEditable As Boolean = False
    Private _bolIsFieldData As Boolean = False
    Private _strCategory As String = String.Empty
    Private _strName As String = String.Empty
    Private _strPropertyType As String = String.Empty
    Private _strPropertyTypeFullName As String = String.Empty
    Private _strValue As String = String.Empty
    Private _strValueSource As String = String.Empty

#End Region

#Region " Properties "

    Public Property CanReset() As Boolean
        Get
            Return _bolCanReset
        End Get
        Set(ByVal Value As Boolean)
            _bolCanReset = Value
        End Set
    End Property

    Public Property Category() As String
        Get
            Return _strCategory
        End Get
        Set(ByVal Value As String)
            _strCategory = Value
        End Set
    End Property

    Public Property IsDependencyProperty() As Boolean
        Get
            Return _bolIsDependencyProperty
        End Get
        Set(ByVal Value As Boolean)
            _bolIsDependencyProperty = Value
        End Set
    End Property

    Public Property IsDrillable() As Boolean
        Get
            Return _bolIsDrillable
        End Get
        Set(ByVal Value As Boolean)
            _bolIsDrillable = Value
        End Set
    End Property

    Public Property IsEditable() As Boolean
        Get
            Return _bolIsEditable
        End Get
        Set(ByVal Value As Boolean)
            _bolIsEditable = Value
        End Set
    End Property

    Public Property IsFieldData() As Boolean
        Get
            Return _bolIsFieldData
        End Get
        Set(ByVal Value As Boolean)
            _bolIsFieldData = Value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return _strName
        End Get
        Set(ByVal Value As String)
            _strName = Value
        End Set
    End Property

    Public Property PropertyType() As String
        Get
            Return _strPropertyType
        End Get
        Set(ByVal Value As String)
            _strPropertyType = Value
        End Set
    End Property

    Public Property PropertyTypeFullName() As String
        Get
            Return _strPropertyTypeFullName
        End Get
        Set(ByVal Value As String)
            _strPropertyTypeFullName = Value
        End Set
    End Property

    Public Property Value() As String
        Get
            Return _strValue
        End Get
        Set(ByVal Value As String)
            _strValue = Value
        End Set
    End Property

    Public Property ValueSource() As String
        Get
            Return _strValueSource
        End Get
        Set(ByVal Value As String)
            _strValueSource = Value
        End Set
    End Property

#End Region

#Region " Constructors "

    Public Sub New()

    End Sub

    Public Sub New(ByVal bolCanReset As Boolean, ByVal bolIsDependencyProperty As Boolean, ByVal bolIsDrillable As Boolean, ByVal bolIsEditable As Boolean, ByVal bolIsFieldData As Boolean, ByVal strCategory As String, ByVal strName As String, ByVal strPropertyType As String, ByVal strPropertyTypeFullName As String, ByVal strValue As String, ByVal strValueSource As String)
        _bolCanReset = bolCanReset
        _bolIsDependencyProperty = bolIsDependencyProperty
        _bolIsDrillable = bolIsDrillable
        _bolIsEditable = bolIsEditable
        _bolIsFieldData = bolIsFieldData
        _strCategory = strCategory
        _strName = strName
        _strPropertyType = strPropertyType
        _strPropertyTypeFullName = strPropertyTypeFullName
        _strValue = strValue
        _strValueSource = strValueSource

    End Sub

#End Region

End Class
