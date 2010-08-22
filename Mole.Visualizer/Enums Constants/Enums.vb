'

Public Enum HTMLFormat
    Compressed
    Expanded
End Enum

Public Enum Language
    C
    VB
End Enum

Public Enum MoleMode
    ASPNET
    [Class]
    NOTSUPPORTED
    ValueType
    WinForms
    WPF
End Enum

'NEVER!!! Change these values
'TODO developers when adding values MUST CHANGE, (dgvProperties_RowPrePaint, AND MakeSortKey)
Public Enum MoleRowRole
    FavoriteHeader = 0
    Favorite = 1
    FavoriteFooter = 2
    DataHeader = 3
    Data = 4
    DataFooter = 5
    BlackOpsHeader = 6
    BlackOpsRow = 7
    BlackOpsFooter = 8
    NormalRow = 9
End Enum

Public Enum ObjectReadMode
    Cache
    Fetch
    NotRead
End Enum

'=================================================================================
'
'NOTE IF YOU CHANGE THIS ENUM - YOU MUST ALSO CHANGE MoleEditorFactory.Create AND EditInfoResponse.Create
'
'=================================================================================
Public Enum PropertyEditorType
    RectDouble
    RectInt
    DateTime
    TimeSpan
    Text
    DrawingColor
    MediaColor
    FontName
    Thickness
    BoolValue
    FloatValue
    DoubleValue
    Int32Value
    Int64Value
    Int16Value
    ByteValue
    DecimalValue
    CharValue
    Font
End Enum

Public Enum SortByColumn
    IsFavorite
    Name
    Value
    CompareValue
    PropertyType
    ValueSource
    Category
    IsDependencyProperty
End Enum

Public Enum TransferDataRequestType
    BlackOpsDrillingOperation
    ClearDrillingOperation
    DrillingOperation
    GetDataSet
    Image
    InitialLoadASPNET
    InitialLoadClass
    InitialLoadWinForms
    InitialLoadVisualTree
    LoadLogicalTree
    Properties
    XAML
    EditValue
    GetEditInfo
End Enum

'if values are added to this enum you MUST edit the TransferData sub in MoleVisualizerObjectSource
Public Enum TransferDataTreeTarget
    LogicalTree
    VisualTree
End Enum

<Flags()> _
Public Enum TreeElementPropertyFlags As Byte
    None = 0
    IsDependencyProperty = &H1
    IsDrillable = &H2
    IsEditable = &H4
    CanReset = &H8
End Enum

Public Enum TreeItemAction
    Collapse
    Expand
End Enum

Public Enum WriteOperation
    ResetValue
    WriteValue
End Enum
