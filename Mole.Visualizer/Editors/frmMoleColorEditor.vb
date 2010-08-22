Imports System.Windows.Forms
Imports System.Drawing
Imports System.Reflection

Public Class frmMoleColorEditor
    Implements IMoleEditor

#Region " Declarations "

    Private _bolIsDirty As Boolean = False
    Private _bolSettingColors As Boolean = False
    Private _objEditInfoResponse As EditInfoResponse
    Private _objKnownColorList As New List(Of ColorComboBoxItem)
    Private _objMoleSettings As MoleSettings
    Private _objRow As Mole.MoleDataGridViewRow
    Private _objSystemColorList As New List(Of ColorComboBoxItem)
    Private _objVisual As System.Drawing.Bitmap
    Private _strCurrentValue As String = String.Empty
    Private _strPropertyName As String = String.Empty
    Private _strTextBoxValue As String = String.Empty

#End Region

#Region " Events "

    Public Event WriteEdit(ByVal sender As Object, ByRef e As MoleEditorWriteEventArgs) Implements IMoleEditor.WriteEdit

#End Region

#Region " Constructors "

    Public Sub New(ByVal strCurrentValue As String, ByVal strPropertyName As String, ByVal objEditInfoResponse As EditInfoResponse, ByVal row As Mole.MoleDataGridViewRow, ByVal objVisual As System.Drawing.Bitmap, ByRef objMoleSettings As MoleSettings)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        _objMoleSettings = objMoleSettings
        MyBase.ApplyWindowSettings(objMoleSettings, Me.Name)
        _strCurrentValue = strCurrentValue
        _strPropertyName = strPropertyName
        _objEditInfoResponse = objEditInfoResponse
        _objRow = row
        _objVisual = objVisual
        SetMyBaseLabelText(strPropertyName, strCurrentValue, row.Cells(INTEGER_COLUMNINDEX_PROPERTYTYPE).Value.ToString)

        If objVisual IsNot Nothing Then
            Me.pbVisual.Image = objVisual
        End If

        Me.btnReset.Enabled = _objRow.CanReset
        Me.btnSetToNull.Enabled = objEditInfoResponse.AllowNull
        _bolIsDirty = False
        _objKnownColorList.Add(New ColorComboBoxItem("-- Known Colors --", Color.Transparent))

        For Each strName As String In System.Enum.GetNames(GetType(System.Drawing.KnownColor))
            _objKnownColorList.Add(New ColorComboBoxItem(strName, Color.FromName(strName)))
        Next

        If _objEditInfoResponse.EditorType = PropertyEditorType.DrawingColor Then
            _objSystemColorList.Add(New ColorComboBoxItem("-- Drawing Colors --", Color.Transparent))

            For Each pi As PropertyInfo In GetType(System.Drawing.Color).GetProperties(BindingFlags.Static Or BindingFlags.Public Or BindingFlags.DeclaredOnly)
                _objSystemColorList.Add(New ColorComboBoxItem(pi.Name, CType(pi.GetValue(Nothing, Nothing), Color)))
            Next

        Else
            _objSystemColorList.Add(New ColorComboBoxItem("-- Media Colors --", Color.Transparent))

            For Each pi As PropertyInfo In GetType(System.Windows.Media.Colors).GetProperties(BindingFlags.Static Or BindingFlags.Public Or BindingFlags.DeclaredOnly)

                Dim mediaClr As System.Windows.Media.Color = CType(pi.GetValue(Nothing, Nothing), System.Windows.Media.Color)
                _objSystemColorList.Add(New ColorComboBoxItem(pi.Name, Color.FromArgb(mediaClr.A, mediaClr.R, mediaClr.G, mediaClr.B)))
            Next

        End If

        Me.cboKnownColors.DisplayMember = "Name"
        Me.cboKnownColors.ValueMember = "Color"
        Me.cboSystemColors.DisplayMember = "Name"
        Me.cboSystemColors.ValueMember = "Color"
        FillColorComboBoxes(New ColorSortByName)
        SetColor(_strCurrentValue)
        Me.txtHexColor.Focus()

    End Sub

#End Region

#Region " Methods "

    Private Sub bntSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntSave.Click
        SaveEdit(True)

    End Sub

    Private Sub btnChangeColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeColor.Click
        Me.ColorDialog1.Color = Me.pnlColorSample.BackColor
        Me.ColorDialog1.AllowFullOpen = True
        Me.ColorDialog1.FullOpen = True
        Me.ColorDialog1.AnyColor = True
        Me.ColorDialog1.ShowHelp = False
        Me.ColorDialog1.SolidColorOnly = False

        If Me.ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            SetColor(Me.ColorDialog1.Color)
            _bolIsDirty = True
        End If

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()

    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click

        Dim args As New MoleEditorWriteEventArgs(True, Me.txtHexColor.Text, _objRow, _objEditInfoResponse, WriteOperation.ResetValue)
        RaiseEvent WriteEdit(Me, args)

        If String.IsNullOrEmpty(args.WriteErrorMessage) Then
            'success
            Me.pbVisual.Image = args.Visual
            _strCurrentValue = args.NewValue
            Me.btnReset.Enabled = _objRow.CanReset
            SetColor(_strCurrentValue)
            SetMyBaseLabelText(_strPropertyName, _strCurrentValue, _objRow.Cells(INTEGER_COLUMNINDEX_PROPERTYTYPE).Value.ToString)

        Else
            'write error
            MessageBox.Show(String.Format("Unable to reset value, error message: {0}", args.WriteErrorMessage), "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        _bolIsDirty = False

    End Sub

    Private Sub btnSaveClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveClose.Click
        SaveEdit(False)
        Me.Close()

    End Sub

    Private Sub btnSetToNull_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetToNull.Click

        Dim args As New MoleEditorWriteEventArgs(True, Nothing, _objRow, _objEditInfoResponse, WriteOperation.WriteValue)
        RaiseEvent WriteEdit(Me, args)

        If String.IsNullOrEmpty(args.WriteErrorMessage) Then
            'success
            Me.pbVisual.Image = args.Visual
            _strCurrentValue = args.NewValue
            Me.btnReset.Enabled = _objRow.CanReset
            SetColor(_strCurrentValue)
            SetMyBaseLabelText(_strPropertyName, _strCurrentValue, _objRow.Cells(INTEGER_COLUMNINDEX_PROPERTYTYPE).Value.ToString)

        Else
            'write error
            MessageBox.Show(String.Format("Unable to set value, error message: {0}", args.WriteErrorMessage), "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        _bolIsDirty = False

    End Sub

    Private Sub cboKnownColors_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboKnownColors.SelectedIndexChanged

        If Me.cboKnownColors.SelectedIndex > 0 Then
            SetColor(CType(Me.cboKnownColors.SelectedItem, ColorComboBoxItem).Color)
        End If

    End Sub

    Private Sub cboSystemColors_MeasureItem(ByVal sender As Object, ByVal e As System.Windows.Forms.MeasureItemEventArgs) Handles cboSystemColors.MeasureItem, cboKnownColors.MeasureItem
        e.ItemHeight = 60

    End Sub

    Private Sub cboSystemColors_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSystemColors.SelectedIndexChanged

        If Me.cboSystemColors.SelectedIndex > 0 Then
            SetColor(CType(Me.cboSystemColors.SelectedItem, ColorComboBoxItem).Color)
            _bolIsDirty = True
        End If

    End Sub

    Private Sub FillColorComboBoxes(ByVal objColorSorter As IComparer(Of ColorComboBoxItem))

        If _objKnownColorList.Count < 1 Then
            Exit Sub
        End If

        Me.cboKnownColors.DataSource = Nothing
        Me.cboSystemColors.DataSource = Nothing
        Me.cboKnownColors.Items.Clear()
        Me.cboSystemColors.Items.Clear()
        _objKnownColorList.Sort(objColorSorter)
        _objSystemColorList.Sort(objColorSorter)
        Me.cboKnownColors.DataSource = _objKnownColorList
        Me.cboSystemColors.DataSource = _objSystemColorList

    End Sub

    Private Sub frm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If _bolIsDirty Then

            If MessageBox.Show("You have not yet saved your changes.  Are you sure you want to exit without saving?", "Changes Not Saved", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Exit Sub
            End If

        End If

        MyBase.SaveWindowSettings(_objMoleSettings, Me.Name)

    End Sub

    Private Function GetHexFromColorValue(ByVal b As Byte) As String
        Return Microsoft.VisualBasic.Right(String.Concat("0", Hex(b)), 2)

    End Function

    Private Sub nud_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudA.ValueChanged, nudB.ValueChanged, nudG.ValueChanged, nudR.ValueChanged

        If _bolSettingColors Then
            Exit Sub
        End If

        _bolIsDirty = True
        SetColor(Color.FromArgb(Decimal.ToInt32(Me.nudA.Value), Decimal.ToInt32(Me.nudR.Value), Decimal.ToInt32(Me.nudG.Value), Decimal.ToInt32(Me.nudB.Value)))

    End Sub

    Private Sub rdoBrightness_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoBrightness.CheckedChanged
        FillColorComboBoxes(New ColorSortByBrightness)

    End Sub

    Private Sub rdoSortHue_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoSortHue.CheckedChanged
        FillColorComboBoxes(New ColorSortByHue)

    End Sub

    Private Sub rdoSortName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoSortName.CheckedChanged
        FillColorComboBoxes(New ColorSortByName)

    End Sub

    Private Sub rdoSortSaturation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoSortSaturation.CheckedChanged
        FillColorComboBoxes(New ColorSortBySaturation)

    End Sub

    Private Sub SaveEdit(ByVal bolReturnImage As Boolean)

        Dim args As New MoleEditorWriteEventArgs(bolReturnImage, Me.txtHexColor.Text, _objRow, _objEditInfoResponse, WriteOperation.WriteValue)
        RaiseEvent WriteEdit(Me, args)

        If String.IsNullOrEmpty(args.WriteErrorMessage) Then

            'success
            If bolReturnImage Then
                Me.pbVisual.Image = args.Visual
            End If

            _strCurrentValue = args.NewValue
            Me.btnReset.Enabled = _objRow.CanReset
            SetMyBaseLabelText(_strPropertyName, _strCurrentValue, _objRow.Cells(INTEGER_COLUMNINDEX_PROPERTYTYPE).Value.ToString)

        Else
            'write error
            MessageBox.Show(String.Format("Unable to set value, error message: {0}", args.WriteErrorMessage), "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        _bolIsDirty = False

    End Sub

    Private Sub SetColor(ByVal strColor As String)

        Try

            If String.IsNullOrEmpty(_strCurrentValue) OrElse String.Equals(strColor, "null") Then
                SetColor(Color.White)

            ElseIf _objEditInfoResponse.EditorType = PropertyEditorType.MediaColor Then

                Dim objColor As Object = System.Windows.Media.ColorConverter.ConvertFromString(_strCurrentValue)

                If objColor IsNot Nothing Then

                    Dim clrMedia As System.Windows.Media.Color = CType(objColor, System.Windows.Media.Color)
                    SetColor(System.Drawing.Color.FromArgb(clrMedia.A, clrMedia.R, clrMedia.G, clrMedia.B))

                Else
                    MessageBox.Show("Unable to translate color to System.Windows.Media.Color, setting color to White", "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    SetColor(Color.White)
                End If

            Else

                If _strCurrentValue.StartsWith("#") Then
                    SetColor(System.Drawing.ColorTranslator.FromHtml(_strCurrentValue))

                Else
                    SetColor(System.Drawing.Color.FromName(_strCurrentValue))
                End If

            End If

        Catch ex As Exception
            MessageBox.Show("Unable to translate color.  Message: " & ex.Message & ", setting color to White", "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            SetColor(Color.White)
        End Try

    End Sub

    Private Sub SetColor(ByVal clr As Color)
        _bolSettingColors = True
        Me.cboSystemColors.SelectedIndex = 0
        Me.cboKnownColors.SelectedIndex = 0
        Me.nudA.Value = clr.A
        Me.nudB.Value = clr.B
        Me.nudG.Value = clr.G
        Me.nudR.Value = clr.R
        Me.txtHexColor.Text = String.Concat("#", Microsoft.VisualBasic.Right(String.Concat("0", Hex(clr.A)), 2), Microsoft.VisualBasic.Right(String.Concat("0", Hex(clr.R)), 2), Microsoft.VisualBasic.Right(String.Concat("0", Hex(clr.G)), 2), Microsoft.VisualBasic.Right(String.Concat("0", Hex(clr.B)), 2))
        Me.pnlColorSample.BackColor = clr
        _bolSettingColors = False
        SetMyBaseLabelText(_strPropertyName, Me.txtHexColor.Text, _objRow.Cells(INTEGER_COLUMNINDEX_PROPERTYTYPE).Value.ToString)

    End Sub

    Private Sub SetMyBaseLabelText(ByVal strPropertyName As String, ByVal strCurrentValue As String, ByVal strDataType As String)

        If String.IsNullOrEmpty(strCurrentValue) Then
            MyBase.SetLabelText(strPropertyName, "NULL", strDataType)

        Else
            MyBase.SetLabelText(strPropertyName, strCurrentValue, strDataType)
        End If

    End Sub

    Private Sub txtHexColor_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHexColor.GotFocus
        _strTextBoxValue = Me.txtHexColor.Text

    End Sub

    Private Sub txtHexColor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHexColor.LostFocus

        If _bolSettingColors Then
            Exit Sub
        End If

        Try
            SetColor(ColorTranslator.FromHtml(Me.txtHexColor.Text))

            If String.Compare(_strTextBoxValue, Me.txtHexColor.Text, StringComparison.CurrentCultureIgnoreCase) <> 0 Then
                _bolIsDirty = True
            End If

        Catch ex As Exception
            MessageBox.Show("Unable to translate color.  Message: " & ex.Message & ", resetting color to White", "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txtHexColor.Text = _strTextBoxValue
        End Try

    End Sub

    'NEVER change the name of the sub.  If you change it to Sub Dispose, calling this will create a stack over flow
    Public Sub Dispose1() Implements IMoleEditor.Dispose
        Me.Dispose()

    End Sub

    'NEVER change the name of the sub.  If you change it to Sub ShowDialog, calling this will create a stack over flow
    Public Sub ShowDialog1() Implements IMoleEditor.ShowDialog
        Me.ShowDialog()

    End Sub

    Protected Sub cboSystemColors_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles cboSystemColors.DrawItem, cboKnownColors.DrawItem

        If e.Index < 0 Then
            e.DrawBackground()
            e.DrawFocusRectangle()
            Exit Sub
        End If

        Dim cbo As ComboBox = CType(sender, ComboBox)
        Dim clrCurrent As ColorComboBoxItem = CType(cbo.Items(e.Index), ColorComboBoxItem)
        Dim rect As Rectangle = New Rectangle(2, e.Bounds.Top, 16, e.Bounds.Height)
        e.DrawBackground()
        e.DrawFocusRectangle()

        If Not clrCurrent.Name.StartsWith("-") Then
            e.Graphics.DrawRectangle(New Pen(clrCurrent.Color), rect)
            e.Graphics.FillRectangle(New SolidBrush(clrCurrent.Color), rect)
            e.Graphics.DrawRectangle(Pens.Black, rect)
        End If

        e.Graphics.DrawString(clrCurrent.Name, cbo.Font, Brushes.Black, 25, ((e.Bounds.Height - cbo.Font.Height) \ 2) + e.Bounds.Top)

    End Sub

    Private Class ColorComboBoxItem
        Private _clrColor As Color
        Private _strName As String = String.Empty

        Public ReadOnly Property Color() As Color
            Get
                Return _clrColor
            End Get
        End Property

        Public ReadOnly Property Name() As String
            Get
                Return _strName
            End Get
        End Property

        Public Sub New(ByVal strName As String, ByVal clrColor As Color)
            _strName = strName
            _clrColor = clrColor

        End Sub

        Public Overrides Function ToString() As String
            Return _strName

        End Function

    End Class

    Private Class ColorSortByBrightness
        Implements IComparer(Of ColorComboBoxItem)

        Public Function Compare(ByVal x As ColorComboBoxItem, ByVal y As ColorComboBoxItem) As Integer Implements System.Collections.Generic.IComparer(Of ColorComboBoxItem).Compare

            If x.Name.CompareTo(y.Name) = 0 Then
                Return 0

            ElseIf x.Name.StartsWith("-") Then
                Return -1

            ElseIf y.Name.StartsWith("-") Then
                Return 1

            Else
                Return x.Color.GetBrightness.CompareTo(y.Color.GetBrightness)
            End If

        End Function

    End Class

    Private Class ColorSortByHue
        Implements IComparer(Of ColorComboBoxItem)

        Public Function Compare(ByVal x As ColorComboBoxItem, ByVal y As ColorComboBoxItem) As Integer Implements System.Collections.Generic.IComparer(Of ColorComboBoxItem).Compare

            If x.Name.CompareTo(y.Name) = 0 Then
                Return 0

            ElseIf x.Name.StartsWith("-") Then
                Return -1

            ElseIf y.Name.StartsWith("-") Then
                Return 1

            Else
                Return x.Color.GetHue.CompareTo(y.Color.GetHue)
            End If

        End Function

    End Class

    Private Class ColorSortByName
        Implements IComparer(Of ColorComboBoxItem)

        Public Function Compare(ByVal x As ColorComboBoxItem, ByVal y As ColorComboBoxItem) As Integer Implements System.Collections.Generic.IComparer(Of ColorComboBoxItem).Compare
            Return x.Name.CompareTo(y.Name)

        End Function

    End Class

    Private Class ColorSortBySaturation
        Implements IComparer(Of ColorComboBoxItem)

        Public Function Compare(ByVal x As ColorComboBoxItem, ByVal y As ColorComboBoxItem) As Integer Implements System.Collections.Generic.IComparer(Of ColorComboBoxItem).Compare

            If x.Name.CompareTo(y.Name) = 0 Then
                Return 0

            ElseIf x.Name.StartsWith("-") Then
                Return -1

            ElseIf y.Name.StartsWith("-") Then
                Return 1

            Else
                Return x.Color.GetSaturation.CompareTo(y.Color.GetSaturation)
            End If

        End Function

    End Class

#End Region

End Class
