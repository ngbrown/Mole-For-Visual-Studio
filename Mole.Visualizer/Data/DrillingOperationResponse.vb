Imports System.Runtime.Serialization
'
<Serializable()> _
Public NotInheritable Class DrillingOperationResponse
    Implements ISerializable

#Region " Declarations "

    Private _bolHasData As Boolean = False
    Private _intParentElementTreeDictionaryKeyId As Integer
    Private _intThisElementTreeDictionaryKeyId As Integer
    Private _objProperties As List(Of TreeElementProperty)
    Private _strFullTypeName As String = String.Empty

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

    Public ReadOnly Property ParentElementTreeDictionaryKeyId() As Integer
        Get
            Return _intParentElementTreeDictionaryKeyId
        End Get
    End Property

    Public ReadOnly Property Properties() As List(Of TreeElementProperty)
        Get
            Return _objProperties
        End Get
    End Property

    Public ReadOnly Property ThisElementTreeDictionaryKeyId() As Integer
        Get
            Return _intThisElementTreeDictionaryKeyId
        End Get
    End Property

#End Region

#Region " Initialization and Serialization "

    ' This constructor is required when you implement ISerializable.
    Private Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        _bolHasData = info.GetBoolean("_bolHasData")
        _intParentElementTreeDictionaryKeyId = info.GetInt32("_intParentElementTreeDictionaryKeyId")
        _intThisElementTreeDictionaryKeyId = info.GetInt32("_intThisElementTreeDictionaryKeyId")
        _objProperties = CType(info.GetValue("_objProperties", GetType(List(Of TreeElementProperty))), List(Of TreeElementProperty))
        _strFullTypeName = info.GetString("_strFullTypeName")

    End Sub

    Public Sub New(ByVal bolHasData As Boolean, ByVal intParentElementTreeDictionaryKeyId As Integer, ByVal intThisElementTreeDictionaryKeyId As Integer, ByVal objProperties As List(Of TreeElementProperty), ByVal strFullTypeName As String)
        _bolHasData = bolHasData
        _intParentElementTreeDictionaryKeyId = intParentElementTreeDictionaryKeyId
        _intThisElementTreeDictionaryKeyId = intThisElementTreeDictionaryKeyId
        _objProperties = objProperties
        _strFullTypeName = strFullTypeName

    End Sub

    ' Required for the implementation of ISerializable.
    Private Sub GetObjectData(ByVal info As SerializationInfo, ByVal context As StreamingContext) Implements ISerializable.GetObjectData
        info.AddValue("_bolHasData", _bolHasData)
        info.AddValue("_intParentElementTreeDictionaryKeyId", _intParentElementTreeDictionaryKeyId)
        info.AddValue("_intThisElementTreeDictionaryKeyId", _intThisElementTreeDictionaryKeyId)
        info.AddValue("_objProperties", _objProperties)
        info.AddValue("_strFullTypeName", _strFullTypeName)

    End Sub

#End Region

End Class
