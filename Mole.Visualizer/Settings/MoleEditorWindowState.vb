'
<Serializable()> _
Public Class MoleEditorWindowState

#Region " Declarations "

    Private _ptWindowLocation As System.Drawing.Point
    Private _strScreenDeviceName As String = String.Empty
    Private _szWindowSize As System.Drawing.Size = New System.Drawing.Size(600, 400)

#End Region

#Region " Properties "

    Public Property ScreenDeviceName() As String
        Get
            Return _strScreenDeviceName
        End Get
        Set(ByVal Value As String)
            _strScreenDeviceName = Value
        End Set
    End Property

    Public Property WindowLocation() As System.Drawing.Point
        Get
            Return _ptWindowLocation
        End Get
        Set(ByVal Value As System.Drawing.Point)
            _ptWindowLocation = Value
        End Set
    End Property

    Public Property WindowSize() As System.Drawing.Size
        Get
            Return _szWindowSize
        End Get
        Set(ByVal Value As System.Drawing.Size)
            _szWindowSize = Value
        End Set
    End Property

#End Region

#Region " Constructors "

    Public Sub New()

    End Sub

#End Region

End Class
