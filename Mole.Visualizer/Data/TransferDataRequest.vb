Imports System.Runtime.Serialization
'
<Serializable()> _
Public NotInheritable Class TransferDataRequest

#Region " Declarations "

    Private _bolClearDrillingOperation As Boolean = False
    Private _enumTransferDataRequestType As TransferDataRequestType
    Private _enumTransferDataTreeTarget As TransferDataTreeTarget
    Private _intLastDrillingOperationId As Integer
    Private _intMaxRowsInCollectionData As Integer = 1000  'karl set this default here because when class drilling, we need to look for properties and not data
    Private _intOriginalSelectedElementId As Integer
    Private _strNewValue As String = Nothing
    Private _strPropertyNameToDrill As String = String.Empty

#End Region

#Region " Properties "

    ''' <summary>
    ''' Allows this request to clear previous drilling operations as part of this request.
    ''' </summary>
    Public ReadOnly Property ClearDrillingOperation() As Boolean
        Get
            Return _bolClearDrillingOperation
        End Get
    End Property

    ''' <summary>
    ''' This is the Id that was returned from the last drilling operation.  This is only used when continual drilling operations are being requested.
    ''' </summary>
    Public Property LastDrillingOperationId() As Integer
        Get
            Return _intLastDrillingOperationId
        End Get
        Set(ByVal Value As Integer)
            _intLastDrillingOperationId = Value
        End Set
    End Property

    ''' <summary>
    ''' Maximum rows that will be returned from the data source for all collections
    ''' </summary>
    Public ReadOnly Property MaxRowsInCollectionData() As Integer
        Get
            Return _intMaxRowsInCollectionData
        End Get
    End Property

    ''' <summary>
    ''' The string representation of the new value.
    ''' </summary>
    Public ReadOnly Property NewValue() As String
        Get
            Return _strNewValue
        End Get
    End Property

    ''' <summary>
    ''' This is the Id of the element that was selected in the Visual Tree or Logical Tree view control.
    ''' </summary>
    Public Property OriginalSelectedElementId() As Integer
        Get
            Return _intOriginalSelectedElementId
        End Get
        Set(ByVal Value As Integer)
            _intOriginalSelectedElementId = Value
        End Set
    End Property

    ''' <summary>
    ''' What property name should be looked up.
    ''' </summary>
    Public ReadOnly Property PropertyNameToDrill() As String
        Get
            Return _strPropertyNameToDrill
        End Get
    End Property

    ''' <summary>
    ''' What type of transfer request is this
    ''' </summary>
    Public ReadOnly Property TransferDataRequestType() As TransferDataRequestType
        Get
            Return _enumTransferDataRequestType
        End Get
    End Property

    ''' <summary>
    ''' What is the target of this request.  This value determines which object lookup dictionary the visualizer object source will use.
    ''' </summary>
    Public ReadOnly Property TransferDataTreeTarget() As TransferDataTreeTarget
        Get
            Return _enumTransferDataTreeTarget
        End Get
    End Property

#End Region

#Region " Constructor "

    Public Sub New(ByVal bolClearDrillingOperation As Boolean, ByVal enumTransferDataRequestType As TransferDataRequestType, ByVal enumTransferDataTreeTarget As TransferDataTreeTarget, ByVal intOriginalSelectedElementId As Integer)
        _bolClearDrillingOperation = bolClearDrillingOperation
        _enumTransferDataRequestType = enumTransferDataRequestType
        _enumTransferDataTreeTarget = enumTransferDataTreeTarget
        _intOriginalSelectedElementId = intOriginalSelectedElementId

    End Sub

    Public Sub New(ByVal bolClearDrillingOperation As Boolean, ByVal enumTransferDataRequestType As TransferDataRequestType, ByVal enumTransferDataTreeTarget As TransferDataTreeTarget, ByVal intOriginalSelectedElementId As Integer, ByVal intLastDrillingOperationId As Integer, ByVal strPropertyNameToDrill As String, ByVal intMaxRowsInCollectionData As Integer)
        _bolClearDrillingOperation = bolClearDrillingOperation
        _enumTransferDataRequestType = enumTransferDataRequestType
        _enumTransferDataTreeTarget = enumTransferDataTreeTarget
        _intOriginalSelectedElementId = intOriginalSelectedElementId
        _intLastDrillingOperationId = intLastDrillingOperationId
        _strPropertyNameToDrill = strPropertyNameToDrill
        _intMaxRowsInCollectionData = intMaxRowsInCollectionData

    End Sub

    Public Sub New(ByVal enumTransferDataTreeTarget As TransferDataTreeTarget, ByVal intOriginalSelectedElementId As Integer, ByVal intLastDrillingOperationId As Integer, ByVal strPropertyName As String)
        _enumTransferDataRequestType = Mole.TransferDataRequestType.GetEditInfo
        _enumTransferDataTreeTarget = enumTransferDataTreeTarget
        _intOriginalSelectedElementId = intOriginalSelectedElementId
        _intLastDrillingOperationId = intLastDrillingOperationId
        _strPropertyNameToDrill = strPropertyName

    End Sub

    Public Sub New(ByVal enumTransferDataTreeTarget As TransferDataTreeTarget, ByVal intOriginalSelectedElementId As Integer, ByVal intLastDrillingOperationId As Integer, ByVal strPropertyName As String, ByVal strNewValue As String)
        _enumTransferDataRequestType = Mole.TransferDataRequestType.EditValue
        _enumTransferDataTreeTarget = enumTransferDataTreeTarget
        _intOriginalSelectedElementId = intOriginalSelectedElementId
        _intLastDrillingOperationId = intLastDrillingOperationId
        _strPropertyNameToDrill = strPropertyName
        _strNewValue = strNewValue

    End Sub

#End Region

End Class
