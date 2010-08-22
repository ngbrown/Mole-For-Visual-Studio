Imports System.Runtime.Serialization
'
<Serializable()> _
Public Class EditOperationResponse

#Region " Declarations "

    Private _canReset As Boolean
    Private _isDrillable As Boolean
    Private _value As String
    Private _valueSource As String

#End Region

#Region " Properties "

    Public ReadOnly Property CanReset() As Boolean
        Get
            Return _canReset
        End Get
    End Property

    Public ReadOnly Property IsDrillable() As Boolean
        Get
            Return _isDrillable
        End Get
    End Property

    Public ReadOnly Property Value() As String
        Get
            Return _value
        End Get
    End Property

    Public ReadOnly Property ValueSource() As String
        Get
            Return _valueSource
        End Get
    End Property

#End Region

#Region " Constructors "

    Public Sub New(ByVal value As String, ByVal valueSource As String, ByVal canReset As Boolean, ByVal isDrillable As Boolean)
        _value = value
        _valueSource = valueSource
        _canReset = canReset
        _isDrillable = isDrillable

    End Sub

#End Region

End Class
