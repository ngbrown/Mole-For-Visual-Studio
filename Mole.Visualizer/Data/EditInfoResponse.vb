Imports System.Runtime.Serialization
'
<Serializable()> _
Public Class EditInfoResponse

#Region " Declarations "

    Private _allowNull As Boolean
    Private _editorType As PropertyEditorType
    Private _limitToValues As Boolean
    Private _values() As String

#End Region

#Region " Properties "

    Public Property AllowNull() As Boolean
        Get
            Return _allowNull
        End Get
        Set(ByVal value As Boolean)
            _allowNull = value
        End Set
    End Property

    Public ReadOnly Property EditorType() As PropertyEditorType
        Get
            Return _editorType
        End Get
    End Property

    Public ReadOnly Property LimitToValues() As Boolean
        Get
            Return _limitToValues
        End Get
    End Property

    Public ReadOnly Property Values() As String()
        Get
            Return _values
        End Get
    End Property

#End Region

#Region " Constructors "

    Public Sub New(ByVal editorType As PropertyEditorType, ByVal values() As String, ByVal limitToValues As Boolean, ByVal allowNull As Boolean)
        _editorType = editorType
        _limitToValues = limitToValues
        _values = values
        _allowNull = allowNull

    End Sub

#End Region

#Region " Methods "

    Private Shared Function GetPrimitiveType(ByVal memberType As Type) As PropertyEditorType

        If GetType(Boolean) Is memberType Then
            Return Mole.PropertyEditorType.BoolValue

        ElseIf GetType(Double) Is memberType Then
            Return Mole.PropertyEditorType.DoubleValue

        ElseIf GetType(Single) Is memberType Then
            Return Mole.PropertyEditorType.FloatValue

        ElseIf GetType(Integer) Is memberType Then
            Return Mole.PropertyEditorType.Int32Value

        ElseIf GetType(Long) Is memberType Then
            Return Mole.PropertyEditorType.Int64Value

        ElseIf GetType(Short) Is memberType Then
            Return Mole.PropertyEditorType.Int16Value

        ElseIf GetType(Byte) Is memberType Then
            Return Mole.PropertyEditorType.ByteValue

        ElseIf GetType(Char) Is memberType Then
            Return Mole.PropertyEditorType.CharValue

        Else
            Return PropertyEditorType.Text
        End If

    End Function

    Private Shared Sub PopulateItems(ByVal values As List(Of String), ByVal valuesType As Type)

        Dim props As Reflection.PropertyInfo() = valuesType.GetProperties(Reflection.BindingFlags.Public Or Reflection.BindingFlags.Static)

        For Each prop As Reflection.PropertyInfo In props
            Values.Add(prop.Name)
        Next

    End Sub

    '=================================================================================
    '
    'NOTE IF YOU CHANGE THIS CODE - YOU MUST ALSO CHANGE MoleEditorFactory.Create
    '
    '=================================================================================
    Public Shared Function Create(ByVal memberType As Type, ByVal converter As ComponentModel.TypeConverter) As EditInfoResponse

        Dim hasStandardValues As Boolean = converter.GetStandardValuesSupported
        Dim requiresStandardValue As Boolean = hasStandardValues AndAlso converter.GetStandardValuesExclusive
        Dim values As List(Of String) = New List(Of String)

        If hasStandardValues Then

            Dim collection As ICollection = converter.GetStandardValues()

            If Collection IsNot Nothing Then

                For Each obj As Object In Collection

                    If obj IsNot Nothing Then
                        Values.Add(obj.ToString())
                    End If

                Next

            End If

        ElseIf memberType Is GetType(Windows.FontStyle) Then
            PopulateItems(Values, GetType(Windows.FontStyles))

        ElseIf memberType Is GetType(Windows.FontStretch) Then
            PopulateItems(Values, GetType(Windows.FontStretches))

        ElseIf memberType Is GetType(Windows.FontWeight) Then
            PopulateItems(Values, GetType(Windows.FontWeights))
        End If

        'objects and nullable properties allow nulls
        Dim underlyingType As Type = Nullable.GetUnderlyingType(memberType)
        Dim allowNull As Boolean = Not memberType.IsValueType OrElse underlyingType IsNot Nothing

        If underlyingType IsNot Nothing Then
            memberType = underlyingType
        End If

        Dim editorType As PropertyEditorType

        '=================================================================================
        '
        'NOTE IF YOU CHANGE THIS CODE - YOU MUST ALSO CHANGE MoleEditorFactory.Create
        '
        '=================================================================================
        'primitives
        If memberType.IsPrimitive Then
            EditorType = GetPrimitiveType(memberType)                   'done

        ElseIf memberType.IsEnum Then
            EditorType = GetPrimitiveType(System.Enum.GetUnderlyingType(memberType))

        ElseIf GetType(Decimal) Is memberType Then
            EditorType = Mole.PropertyEditorType.DecimalValue           'done

            'color
        ElseIf GetType(Drawing.Color) Is memberType Then
            EditorType = Mole.PropertyEditorType.DrawingColor           'done

            'color & brush
        ElseIf GetType(Windows.Media.Color) Is memberType OrElse GetType(Windows.Media.Brush) Is memberType Then
            EditorType = Mole.PropertyEditorType.MediaColor            'done

            'font name
        ElseIf GetType(Windows.Media.FontFamily) Is memberType Then
            EditorType = Mole.PropertyEditorType.FontName               'done

        ElseIf GetType(Drawing.FontFamily) Is memberType Then
            EditorType = Mole.PropertyEditorType.FontName               'done

            'font
        ElseIf GetType(Drawing.Font) Is memberType Then
            EditorType = Mole.PropertyEditorType.Font

            'date/time
        ElseIf GetType(DateTime) Is memberType Then
            EditorType = Mole.PropertyEditorType.DateTime               'done

        ElseIf GetType(TimeSpan) Is memberType Then
            EditorType = Mole.PropertyEditorType.TimeSpan               'done

            'Rects
        ElseIf GetType(Windows.Rect) Is memberType Then
            EditorType = Mole.PropertyEditorType.RectDouble             'done

        ElseIf GetType(Drawing.Rectangle) Is memberType Then
            EditorType = Mole.PropertyEditorType.RectInt                'done

            'misc
        ElseIf GetType(Windows.Thickness) Is memberType Then
            EditorType = Mole.PropertyEditorType.Thickness              'done

            'default to text
        Else
            EditorType = Mole.PropertyEditorType.Text                   'done
        End If

        Return New EditInfoResponse(EditorType, Values.ToArray(), requiresStandardValue, AllowNull)

    End Function

#End Region

End Class
