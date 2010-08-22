'
<Serializable()> _
Public Class MoleSettings

#Region " Declarations "

    Private _bolHideCategoryColumn As Boolean = False
    Private _bolHideIsDependencyPropertyColumn As Boolean = False
    Private _bolHideValueSourceColumn As Boolean = False
    Private _bolShowAttachedProperties As Boolean = True
    Private _bolShowBlackOps As Boolean = False
    Private _bolShowNamespaces As Boolean = False
    Private _enumHTMLFormat As HTMLFormat = HTMLFormat.Expanded
    Private _enumLanguage As Language = Language.VB
    Private _enumSortByColumn As SortByColumn = SortByColumn.Name
    Private _enumSortOrder As System.ComponentModel.ListSortDirection = ComponentModel.ListSortDirection.Ascending
    Private _enumWindowState As System.Windows.Forms.FormWindowState = Windows.Forms.FormWindowState.Normal
    Private _htFavorites As Hashtable
    Private _intMaxRowsInCollectionData As Integer = 100
    Private _intSearchLocationIndex As Integer = 0
    Private _intSplitterDistance As Integer = 265
    Private _intToolTipInitialDelay As Integer = 500
    Private _intXAMLTextFontSize As Integer = 12
    Private _objMoleEditorWindowStates As Dictionary(Of String, MoleEditorWindowState)
    Private _ptWindowLocation As System.Drawing.Point
    Private _strScreenDeviceName As String = String.Empty
    Private _szWindowSize As System.Drawing.Size = New System.Drawing.Size(1020, 570)

#End Region

#Region " Properties "

    Public Property Favorites() As Hashtable
        Get

            If _htFavorites Is Nothing Then
                _htFavorites = New Hashtable
            End If

            Return _htFavorites
        End Get
        Set(ByVal Value As Hashtable)
            _htFavorites = Value
        End Set
    End Property

    Public Property HideCategoryColumn() As Boolean
        Get
            Return _bolHideCategoryColumn
        End Get
        Set(ByVal Value As Boolean)
            _bolHideCategoryColumn = Value
        End Set
    End Property

    Public Property HideIsDependencyPropertyColumn() As Boolean
        Get
            Return _bolHideIsDependencyPropertyColumn
        End Get
        Set(ByVal Value As Boolean)
            _bolHideIsDependencyPropertyColumn = Value
        End Set
    End Property

    Public Property HideValueSourceColumn() As Boolean
        Get
            Return _bolHideValueSourceColumn
        End Get
        Set(ByVal Value As Boolean)
            _bolHideValueSourceColumn = Value
        End Set
    End Property

    Public Property HTMLFormat() As HTMLFormat
        Get
            Return _enumHTMLFormat
        End Get
        Set(ByVal Value As HTMLFormat)
            _enumHTMLFormat = Value
        End Set
    End Property

    Public Property Language() As Language
        Get
            Return _enumLanguage
        End Get
        Set(ByVal Value As Language)
            _enumLanguage = Value
        End Set
    End Property

    Public Property MaxRowsInCollectionData() As Integer
        Get
            Return _intMaxRowsInCollectionData
        End Get
        Set(ByVal Value As Integer)
            _intMaxRowsInCollectionData = Value
        End Set
    End Property

    Public Property MoleEditorWindowStates() As Dictionary(Of String, MoleEditorWindowState)
        Get

            If _objMoleEditorWindowStates Is Nothing Then
                _objMoleEditorWindowStates = New Dictionary(Of String, MoleEditorWindowState)
            End If

            Return _objMoleEditorWindowStates
        End Get
        Set(ByVal Value As Dictionary(Of String, MoleEditorWindowState))
            _objMoleEditorWindowStates = Value
        End Set
    End Property

    Public Property ScreenDeviceName() As String
        Get
            Return _strScreenDeviceName
        End Get
        Set(ByVal Value As String)
            _strScreenDeviceName = Value
        End Set
    End Property

    Public Property SearchLocationIndex() As Integer
        Get
            Return _intSearchLocationIndex
        End Get
        Set(ByVal Value As Integer)
            _intSearchLocationIndex = Value
        End Set
    End Property

    Public Property ShowAttachedProperties() As Boolean
        Get
            Return _bolShowAttachedProperties
        End Get
        Set(ByVal Value As Boolean)
            _bolShowAttachedProperties = Value
        End Set
    End Property

    Public Property ShowBlackOps() As Boolean
        Get
            Return _bolShowBlackOps
        End Get
        Set(ByVal Value As Boolean)
            _bolShowBlackOps = Value
        End Set
    End Property

    Public Property ShowNamespaces() As Boolean
        Get
            Return _bolShowNamespaces
        End Get
        Set(ByVal Value As Boolean)
            _bolShowNamespaces = Value
        End Set
    End Property

    Public Property SortByColumn() As SortByColumn
        Get
            Return _enumSortByColumn
        End Get
        Set(ByVal Value As SortByColumn)
            _enumSortByColumn = Value
        End Set
    End Property

    Public Property SortOrder() As System.ComponentModel.ListSortDirection
        Get
            Return _enumSortOrder
        End Get
        Set(ByVal Value As System.ComponentModel.ListSortDirection)
            _enumSortOrder = Value
        End Set
    End Property

    Public Property SplitterDistance() As Integer
        Get
            Return _intSplitterDistance
        End Get
        Set(ByVal Value As Integer)
            _intSplitterDistance = Value
        End Set
    End Property

    Public Property ToolTipInitialDelay() As Integer
        Get
            Return _intToolTipInitialDelay
        End Get
        Set(ByVal Value As Integer)
            _intToolTipInitialDelay = Value
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

    Public Property WindowState() As System.Windows.Forms.FormWindowState
        Get
            Return _enumWindowState
        End Get
        Set(ByVal Value As System.Windows.Forms.FormWindowState)
            _enumWindowState = Value
        End Set
    End Property

    Public Property XAMLTextFontSize() As Integer
        Get
            Return _intXAMLTextFontSize
        End Get
        Set(ByVal Value As Integer)
            _intXAMLTextFontSize = Value
        End Set
    End Property

#End Region

End Class
