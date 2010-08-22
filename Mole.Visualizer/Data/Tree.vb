'
<Serializable()> _
Public NotInheritable Class Tree

#Region " Declarations "

    Private _intInitialElementId As Integer
    Private _objLogicalTreeInfo As LogicalTreeInfo
    Private _objRootElement As TreeElement
    Private _strLoadingErrorMessage As String = String.Empty

#End Region

#Region " Properties "

    ''' <summary>
    ''' Unique TreeElementId of the object that was selected in the debugger.
    ''' </summary>
    Public Property InitialElementId() As Integer
        Get
            Return _intInitialElementId
        End Get
        Set(ByVal Value As Integer)
            _intInitialElementId = Value
        End Set
    End Property

    ''' <summary>
    ''' If an error occurs when the inital GetData method is called, an error message will be returned here.  (Developers, simply display this message and close the visualizer.)
    ''' </summary>
    Public Property LoadingErrorMessage() As String
        Get
            Return _strLoadingErrorMessage
        End Get
        Set(ByVal Value As String)
            _strLoadingErrorMessage = Value
        End Set
    End Property

    ''' <summary>
    ''' Extra information related to the logical tree.  If this Tree represents a visual tree, the property returns null.
    ''' </summary>
    Public Property LogicalTreeInfo() As LogicalTreeInfo
        Get
            Return _objLogicalTreeInfo
        End Get
        Set(ByVal Value As LogicalTreeInfo)
            _objLogicalTreeInfo = Value
        End Set
    End Property

    ''' <summary>
    ''' Represents the entire WPF Visual Tree of the program being debugged.
    ''' </summary>
    Public Property RootElement() As TreeElement
        Get
            Return _objRootElement
        End Get
        Set(ByVal Value As TreeElement)
            _objRootElement = Value
        End Set
    End Property

#End Region

End Class
