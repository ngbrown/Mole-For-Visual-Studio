Imports System.Runtime.Serialization
'
<Serializable()> _
Public NotInheritable Class TreeElementProperty
    Implements ISerializable

#Region " Declarations "

    Private _flags As TreeElementPropertyFlags = 0

    ' NOTE:  When you add/remove a field, be sure to update the serialization logic!
    Private _strCategory As String = String.Empty
    Private _strName As String = String.Empty
    Private _strPropertyType As String = String.Empty
    Private _strValue As String = String.Empty
    Private _strValueSource As String = String.Empty
    Private _strPropertyTypeFullName As String = String.Empty

#End Region

#Region " Properties "

    ''' <summary>
    ''' Can this property be edited
    ''' </summary>
    Public ReadOnly Property CanReset() As Boolean
        Get
            Return GetFlag(TreeElementPropertyFlags.CanReset)
        End Get
    End Property

    ''' <summary>
    ''' Category assigned to the property by the creator of the property.  Is value from the System.ComponentModel.Category attribute.
    ''' </summary>
    Public ReadOnly Property Category() As String
        Get
            Return _strCategory
        End Get
    End Property

    ''' <summary>
    ''' Is this property a dependency property?
    ''' </summary>
    Public ReadOnly Property IsDependencyProperty() As Boolean
        Get
            Return GetFlag(TreeElementPropertyFlags.IsDependencyProperty)
        End Get
    End Property

    ''' <summary>
    ''' Can this property participate in the Molodrilling operations inside the Moloscope?
    ''' </summary>
    Public ReadOnly Property IsDrillable() As Boolean
        Get
            Return GetFlag(TreeElementPropertyFlags.IsDrillable)
        End Get
    End Property

    'AS 12/16/07
    ''' <summary>
    ''' Can this property be edited
    ''' </summary>
    Public ReadOnly Property IsEditable() As Boolean
        Get
            Return GetFlag(TreeElementPropertyFlags.IsEditable)
        End Get
    End Property

    ''' <summary>
    ''' Property name
    ''' </summary>
    Public ReadOnly Property Name() As String
        Get
            Return _strName
        End Get
    End Property

    ''' <summary>
    ''' Property type name.  The name space is not included.
    ''' </summary>
    Public ReadOnly Property PropertyType() As String
        Get
            Return _strPropertyType
        End Get
    End Property

    ''' <summary>
    ''' Property full type name.  The name space is included.
    ''' </summary>
    Public Property PropertyTypeFullName() As String
        Get
            Return _strPropertyTypeFullName
        End Get
        Set(ByVal Value As String)
            _strPropertyTypeFullName = Value
        End Set
    End Property

    ''' <summary>
    ''' Property value cast as a string.
    ''' This needs to be read/write because we may allow the value to be changed in the UI and sent back to the visual tree
    ''' </summary>
    Public Property Value() As String
        Get
            Return _strValue
        End Get
        Set(ByVal Value As String)
            _strValue = Value
        End Set
    End Property

    ''' <summary>
    ''' Source of the WPF dependency property value.
    ''' </summary>
    Public ReadOnly Property ValueSource() As String
        Get
            Return _strValueSource
        End Get
    End Property

#End Region

#Region " Initialization and Serialization "

    ' This protectged constructor is required when you implement ISerializable.
    Private Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        _strCategory = info.GetString("_strCategory")
        _strName = info.GetString("_strName")
        _strPropertyType = info.GetString("_strPropertyType")
        _strValue = info.GetString("_strValue")
        _strValueSource = info.GetString("_strValueSource")
        _flags = CType(info.GetValue("_flags", GetType(Object)), TreeElementPropertyFlags)
        _strPropertyTypeFullName = info.GetString("_strPropertyTypeFullName")

    End Sub

    Public Sub New(ByVal bolIsDependencyProperty As Boolean, ByVal bolIsDrillable As Boolean, ByVal strCategory As String, ByVal strName As String, ByVal strPropertyType As String, ByVal strPropertyTypeFullName As String, ByVal strValue As String, ByVal strValueSource As String, ByVal bolIsEditable As Boolean, ByVal bolCanReset As Boolean)
        _strCategory = strCategory
        _strName = strName
        _strPropertyType = strPropertyType
        _strPropertyTypeFullName = strPropertyTypeFullName
        _strValue = strValue
        _strValueSource = strValueSource
        SetFlag(TreeElementPropertyFlags.IsDependencyProperty, bolIsDependencyProperty)
        SetFlag(TreeElementPropertyFlags.IsDrillable, bolIsDrillable)
        SetFlag(TreeElementPropertyFlags.IsEditable, bolIsEditable)
        SetFlag(TreeElementPropertyFlags.CanReset, bolCanReset)

    End Sub

    ' Required for the implementation of ISerializable.
    Private Sub GetObjectData(ByVal info As System.Runtime.Serialization.SerializationInfo, ByVal context As System.Runtime.Serialization.StreamingContext) Implements System.Runtime.Serialization.ISerializable.GetObjectData
        info.AddValue("_strCategory", _strCategory)
        info.AddValue("_strName", _strName)
        info.AddValue("_strPropertyType", _strPropertyType)
        info.AddValue("_strValue", _strValue)
        info.AddValue("_strValueSource", _strValueSource)
        info.AddValue("_flags", _flags)
        info.AddValue("_strPropertyTypeFullName", _strPropertyTypeFullName)

    End Sub

#End Region

#Region " Methods "

    Public Function GetTypeName(ByVal bolShowNamespaces As Boolean) As String

        If bolShowNamespaces Then
            Return Me.PropertyTypeFullName

        Else
            Return Me.PropertyType
        End If

    End Function

#End Region

#Region "Get/SetFlag"

    Private Function GetFlag(ByVal flag As TreeElementPropertyFlags) As Boolean
        Return flag = (Me._flags And flag)

    End Function

    Private Sub SetFlag(ByVal flag As TreeElementPropertyFlags, ByVal state As Boolean)

        If state Then
            Me._flags = Me._flags Or flag

        Else
            Me._flags = Me._flags And Not flag
        End If

    End Sub

#End Region

End Class
