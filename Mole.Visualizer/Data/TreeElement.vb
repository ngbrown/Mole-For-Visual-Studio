Imports System.Runtime.Serialization
'
<Serializable()> _
Public NotInheritable Class TreeElement
    Implements ISerializable

#Region " Declarations "

    ' NOTE:  When you add/remove a field, be sure to update the serialization logic!
    Private _intDescendantCount As Integer
    Private _intId As Integer
    Private _objChildren As List(Of TreeElement)
    Private _objProperties As List(Of TreeElementProperty)
    Private _strObjectName As String = String.Empty
    Private _strTypeFullName As String = String.Empty
    Private _strTypeName As String = String.Empty
    Private _strVisualImage As System.Drawing.Bitmap

#End Region

#Region " Properties "

    ''' <summary>
    ''' Elements visual children.  These are populated when this element is created.
    ''' </summary>
    Public ReadOnly Property Children() As List(Of TreeElement)
        Get
            Return _objChildren
        End Get
    End Property

    ''' <summary>
    ''' Elements total number of descendant children (includes immediate children and all their children also.  
    ''' </summary>
    Public ReadOnly Property DescendantCount() As Integer
        Get

            If Me.Children.Count = 0 Then
                Return 0

            ElseIf _intDescendantCount > 0 Then
                Return _intDescendantCount

            Else

                Dim intCount As Integer = Me.Children.Count

                For Each objChild As TreeElement In Me.Children
                    intCount += objChild.DescendantCount
                Next

                _intDescendantCount = intCount
                Return _intDescendantCount
            End If

        End Get
    End Property

    ''' <summary>
    ''' Unique Id assigned when element is created.
    ''' </summary>
    Public ReadOnly Property Id() As Integer
        Get
            Return _intId
        End Get
    End Property

    ''' <summary>
    ''' What is the Name of the object in the code that is being debugged.  Could be empty.
    ''' </summary>
    Public ReadOnly Property ObjectName() As String
        Get
            Return _strObjectName
        End Get
    End Property

    ''' <summary>
    ''' Elements property collection.  These are populated using the lazy load pattern.
    ''' </summary>
    Public Property Properties() As List(Of TreeElementProperty)
        Get
            Return _objProperties
        End Get
        Set(ByVal Value As List(Of TreeElementProperty))
            _objProperties = Value
        End Set
    End Property

    ''' <summary>
    ''' Type this element represents.  Full Type name contain the name space.
    ''' </summary>
    Public ReadOnly Property TypeFullName() As String
        Get
            Return _strTypeFullName
        End Get
    End Property

    ''' <summary>
    ''' Type this element represents.  Type name does not contain the name space.
    ''' </summary>
    Public ReadOnly Property TypeName() As String
        Get
            Return _strTypeName
        End Get
    End Property

    ''' <summary>
    ''' Elements run-time visual snapshot.  This is populated using the lazy load pattern.
    ''' </summary>
    Public Property VisualImage() As System.Drawing.Bitmap
        Get
            Return _strVisualImage
        End Get
        Set(ByVal Value As System.Drawing.Bitmap)
            _strVisualImage = Value
        End Set
    End Property

#End Region

#Region " Initialization and Serialization "

    ' This constructor is required when you implement ISerializable.
    Private Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        _intDescendantCount = info.GetInt32("_intDescendantCount")
        _intId = info.GetInt32("_intId")
        _objChildren = CType(info.GetValue("_objChildren", GetType(List(Of TreeElement))), List(Of TreeElement))
        _strObjectName = info.GetString("_strObjectName")
        _strTypeFullName = info.GetString("_strTypeFullName")
        _strTypeName = GetTypeNameFromTypeFullName(_strTypeFullName)

    End Sub

    Public Sub New(ByVal intId As Integer, ByVal objChildren As List(Of TreeElement), ByVal strObjectName As String, ByVal strTypeFullName As String)
        _intId = intId
        _objChildren = objChildren
        _strObjectName = strObjectName
        _strTypeFullName = strTypeFullName
        _strTypeName = GetTypeNameFromTypeFullName(strTypeFullName)

    End Sub

    ' Required for the implementation of ISerializable.
    Private Sub GetObjectData(ByVal info As SerializationInfo, ByVal context As StreamingContext) Implements ISerializable.GetObjectData
        info.AddValue("_intDescendantCount", _intDescendantCount)
        info.AddValue("_intId", _intId)
        info.AddValue("_objChildren", _objChildren)
        info.AddValue("_strObjectName", _strObjectName)
        info.AddValue("_strTypeFullName", _strTypeFullName)

    End Sub

#End Region

#Region " Helper "

    Private Function GetTypeNameFromTypeFullName(ByVal strFullTypeName As String) As String

        Dim strParts() As String = strFullTypeName.Split("."c)
        Return strParts(strParts.Length - 1)

    End Function

#End Region

End Class
