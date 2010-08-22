
Public Class Composer

    Private _era As String
    Private _name As String
    Private _wikipediaUri As Uri

    Public Sub New(ByVal name As String, ByVal era As String, ByVal wikipediaUri As Uri)
        _name = name
        _era = era
        _wikipediaUri = wikipediaUri
    End Sub

    Public ReadOnly Property Era() As String
        Get
            Return _era
        End Get
    End Property

    Public ReadOnly Property Name() As String
        Get
            Return _name
        End Get
    End Property

    Public ReadOnly Property WikipediaUri() As Uri
        Get
            Return _wikipediaUri
        End Get
    End Property

End Class
