
Public Class MoleEditorWriteEventArgs
    Inherits EventArgs

#Region " Declarations "

    Private _bolReturnImage As Boolean = False
    Private _enumWriteOperation As WriteOperation = WriteOperation.WriteValue
    Private _objEditInfoResponse As EditInfoResponse
    Private _objRow As Mole.MoleDataGridViewRow
    Private _objVisual As System.Drawing.Bitmap
    Private _strNewValue As String = String.Empty
    Private _strWriteErrorMessage As String = String.Empty

#End Region

#Region " Properties "

    Public Property EditInfoResponse() As EditInfoResponse
        Get
            Return _objEditInfoResponse
        End Get
        Set(ByVal Value As EditInfoResponse)
            _objEditInfoResponse = Value
        End Set
    End Property

    Public Property NewValue() As String
        Get
            Return _strNewValue
        End Get
        Set(ByVal Value As String)
            _strNewValue = Value
        End Set
    End Property

    Public Property ReturnImage() As Boolean
        Get
            Return _bolReturnImage
        End Get
        Set(ByVal Value As Boolean)
            _bolReturnImage = Value
        End Set
    End Property

    Public Property Row() As Mole.MoleDataGridViewRow
        Get
            Return _objRow
        End Get
        Set(ByVal Value As Mole.MoleDataGridViewRow)
            _objRow = Value
        End Set
    End Property

    Public Property Visual() As System.Drawing.Bitmap
        Get
            Return _objVisual
        End Get
        Set(ByVal Value As System.Drawing.Bitmap)
            _objVisual = Value
        End Set
    End Property

    Public Property WriteErrorMessage() As String
        Get
            Return _strWriteErrorMessage
        End Get
        Set(ByVal Value As String)
            _strWriteErrorMessage = Value
        End Set
    End Property

    Public Property WriteOperation() As WriteOperation
        Get
            Return _enumWriteOperation
        End Get
        Set(ByVal Value As WriteOperation)
            _enumWriteOperation = Value
        End Set
    End Property

#End Region

#Region " Constructors "

    Public Sub New(ByVal bolReturnImage As Boolean, ByVal strNewValue As String, ByVal objRow As Mole.MoleDataGridViewRow, ByVal objEditInfoResponse As EditInfoResponse, ByVal enumWriteOperation As WriteOperation)
        _bolReturnImage = bolReturnImage
        _strNewValue = strNewValue
        _objRow = objRow
        _objEditInfoResponse = objEditInfoResponse
        _enumWriteOperation = enumWriteOperation

    End Sub

#End Region

End Class
