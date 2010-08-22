Imports System.Windows.Forms

Public Class MoleDataGridViewRow
    Inherits System.Windows.Forms.DataGridViewRow

#Region " Declrations "

    Private _bolCanReset As Boolean = False
    Private _bolIsDrillable As Boolean = False
    Private _bolIsEditable As Boolean = False
    Private _bolIsFavorite As Boolean = False
    Private _enumMoleRowRole As MoleRowRole = MoleRowRole.NormalRow
    Private _strAscendingSortKey As String = String.Empty
    Private _strDescendingSortKey As String = String.Empty
    Private _strTypeFullName As String = String.Empty
    Private _strTypeName As String = String.Empty

#End Region

#Region " Properteis "

    Public ReadOnly Property AscendingSortKey() As String
        Get
            Return _strAscendingSortKey
        End Get
    End Property

    Public Property CanReset() As Boolean
        Get
            Return _bolCanReset
        End Get
        Set(ByVal value As Boolean)
            _bolCanReset = value
        End Set
    End Property

    Public ReadOnly Property DescendingSortKey() As String
        Get
            Return _strDescendingSortKey
        End Get
    End Property

    Public Property IsDrillable() As Boolean
        Get
            Return _bolIsDrillable
        End Get
        Set(ByVal value As Boolean)
            _bolIsDrillable = value
        End Set
    End Property

    Public ReadOnly Property IsEditable() As Boolean
        Get
            Return _bolIsEditable
        End Get
    End Property

    Public ReadOnly Property IsFavorite() As Boolean
        Get
            Return _bolIsFavorite
        End Get
    End Property

    'this must be read/write
    Public Property MoleRowRole() As MoleRowRole
        Get
            Return _enumMoleRowRole
        End Get
        Set(ByVal Value As MoleRowRole)
            _enumMoleRowRole = Value

            If _enumMoleRowRole = Mole.MoleRowRole.Favorite OrElse _enumMoleRowRole = Mole.MoleRowRole.FavoriteHeader OrElse _enumMoleRowRole = Mole.MoleRowRole.FavoriteFooter Then
                _bolIsFavorite = True

            Else
                _bolIsFavorite = False
            End If

            MakeSortKey()
        End Set
    End Property

    Public ReadOnly Property TypeFullName() As String
        Get
            Return _strTypeFullName
        End Get
    End Property

    Public ReadOnly Property TypeName() As String
        Get
            Return _strTypeName
        End Get
    End Property

#End Region

#Region " Constructor and Helper "

    Public Sub New(ByVal objDataGridView As DataGridView, ByVal strTypeName As String, ByVal strTypeFullName As String, ByVal bolIsDrillable As Boolean, ByVal enumMoleRowRole As MoleRowRole, ByVal bolIsValueEditable As Boolean, ByVal bolCanReset As Boolean, ByVal ParamArray values As Object())

        Me.CreateCells(objDataGridView, values)
        _bolIsDrillable = bolIsDrillable
        _bolIsEditable = bolIsValueEditable
        _bolCanReset = bolCanReset
        Me.MoleRowRole = enumMoleRowRole
        _strTypeFullName = strTypeFullName
        _strTypeName = strTypeName

    End Sub

    Private Sub MakeSortKey()

        Dim int As Integer = _enumMoleRowRole

        If _bolIsFavorite Then
            _strAscendingSortKey = String.Concat(int, "1")
            _strDescendingSortKey = String.Concat(9 - int, "1")

        Else
            _strAscendingSortKey = String.Concat(int, "0")
            _strDescendingSortKey = String.Concat(9 - int, "0")
        End If

    End Sub

#End Region

End Class
