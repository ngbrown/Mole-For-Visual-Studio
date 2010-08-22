'
<Serializable()> _
Public Class ExportProperties

#Region " Declarations "

    Private _strObjectName As String = String.Empty
    Private _strTypeFullName As String = String.Empty
    Private _strTypeName As String = String.Empty
    Private _objExportProperty As New List(Of ExportProperty)

#End Region

#Region " Properties "

    Public Property ObjectName() As String
        Get
            Return _strObjectName
        End Get
        Set(ByVal Value As String)
            _strObjectName = Value
        End Set
    End Property

    Public Property TypeFullName() As String
        Get
            Return _strTypeFullName
        End Get
        Set(ByVal Value As String)
            _strTypeFullName = Value
        End Set
    End Property

    Public Property TypeName() As String
        Get
            Return _strTypeName
        End Get
        Set(ByVal Value As String)
            _strTypeName = Value
        End Set
    End Property

    Public ReadOnly Property FileName() As String
        Get

            If Me.ObjectName.Length > 0 Then
                Return String.Format("Mole-{0}-{1}.xml", Me.TypeFullName, Me.ObjectName)

            Else
                Return String.Format("Mole-{0}.xml", Me.TypeFullName)
            End If

        End Get
    End Property

    Public Property ExportProperty() As List(Of ExportProperty)
        Get
            Return _objExportProperty
        End Get
        Set(ByVal Value As List(Of ExportProperty))
            _objExportProperty = Value
        End Set
    End Property

#End Region

#Region " Constructors "

    Public Sub New()

    End Sub

    Public Sub New(ByVal strObjectName As String, ByVal strTypeFullName As String, ByVal strTypeName As String)
        _strObjectName = strObjectName
        _strTypeFullName = strTypeFullName
        _strTypeName = strTypeName

    End Sub

#End Region

#Region " Methods "

    Public Overloads Sub Sort()
        ExportProperty.Sort(New SortExportPropertyByName)

    End Sub

#End Region

#Region " Private IComparer "

    Private Class SortExportPropertyByName
        Implements IComparer(Of ExportProperty)

        Public Function Compare(ByVal x As ExportProperty, ByVal y As ExportProperty) As Integer Implements System.Collections.Generic.IComparer(Of ExportProperty).Compare
            Return x.Name.CompareTo(y.Name)

        End Function

    End Class

#End Region

End Class
