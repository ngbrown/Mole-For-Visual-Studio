Imports System.Drawing
Imports system.Windows.Forms

Public Class frmMoleFontNameEditor
    Implements IMoleEditor

#Region " Declarations "

    Private _bolIsDirty As Boolean = False
    Private _bolLoadingValues As Boolean = False
    Private _objEditInfoResponse As EditInfoResponse
    Private _objMoleSettings As MoleSettings
    Private _objRow As Mole.MoleDataGridViewRow
    Private _objVisual As System.Drawing.Bitmap
    Private _strCurrentValue As String = String.Empty
    Private _strPropertyName As String = String.Empty

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
        MyBase.SetLabelText(_strPropertyName, _strCurrentValue, _objRow.Cells(INTEGER_COLUMNINDEX_PROPERTYTYPE).Value.ToString)

        If objVisual IsNot Nothing Then
            Me.pbVisual.Image = objVisual
        End If

        Me.btnReset.Enabled = _objRow.CanReset
        Me.btnSetToNull.Enabled = objEditInfoResponse.AllowNull
        _bolIsDirty = False

    End Sub

#End Region

#Region " Methods "

    Private Sub bntSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntSave.Click
        SaveEdit(True)

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()

    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click

        Dim args As New MoleEditorWriteEventArgs(True, Me.lstFont.SelectedItem.ToString, _objRow, _objEditInfoResponse, WriteOperation.ResetValue)
        RaiseEvent WriteEdit(Me, args)

        If String.IsNullOrEmpty(args.WriteErrorMessage) Then
            'success
            Me.pbVisual.Image = args.Visual
            _strCurrentValue = args.NewValue
            Me.btnReset.Enabled = _objRow.CanReset
            Me.lstFont.SelectedIndex = Me.lstFont.FindString(_strCurrentValue)
            MyBase.SetLabelText(_strPropertyName, _strCurrentValue, _objRow.Cells(INTEGER_COLUMNINDEX_PROPERTYTYPE).Value.ToString)

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
        Me.lstFont.SelectedIndex = -1
        SaveEdit(True, True)

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

    Private Sub frmMoleFontNameEditor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _bolLoadingValues = True
        lstFont.Items.Clear()

        Dim intIndex As Integer
        Dim intSetIndex As Integer = -1

        For Each objFontFamily As FontFamily In (New System.Drawing.Text.InstalledFontCollection).Families
            intIndex = Me.lstFont.Items.Add(New MoleFontFamily(objFontFamily))

            If String.Compare(objFontFamily.Name, _strCurrentValue, StringComparison.InvariantCultureIgnoreCase) = 0 Then
                intSetIndex = intIndex
            End If

        Next

        Me.lstFont.SelectedIndex = intSetIndex
        _bolIsDirty = False
        _bolLoadingValues = False

    End Sub

    Private Sub lstFont_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstFont.SelectedIndexChanged
        UpdateText()

        If Not _bolLoadingValues Then
            _bolIsDirty = True
        End If

    End Sub

    Private Sub SaveEdit(ByVal bolReturnImage As Boolean, Optional ByVal bolSetToNull As Boolean = False)

        If Me.lstFont.SelectedIndex <> -1 OrElse bolSetToNull Then

            If bolSetToNull OrElse _strCurrentValue <> Me.lstFont.SelectedItem.ToString Then

                Dim strFontName As String = Nothing

                If Not bolSetToNull AndAlso Me.lstFont.SelectedIndex <> -1 Then
                    strFontName = Me.lstFont.SelectedItem.ToString()
                End If

                Dim args As New MoleEditorWriteEventArgs(bolReturnImage, strFontName, _objRow, _objEditInfoResponse, WriteOperation.WriteValue)
                RaiseEvent WriteEdit(Me, args)

                If String.IsNullOrEmpty(args.WriteErrorMessage) Then

                    'success
                    If bolReturnImage Then
                        Me.pbVisual.Image = args.Visual
                    End If

                    _strCurrentValue = args.NewValue
                    Me.btnReset.Enabled = _objRow.CanReset
                    MyBase.SetLabelText(_strPropertyName, _strCurrentValue, _objRow.Cells(INTEGER_COLUMNINDEX_PROPERTYTYPE).Value.ToString)

                Else
                    'write error
                    MessageBox.Show(String.Format("Unable to set value, error message: {0}", args.WriteErrorMessage), "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If

            End If

        Else
            MessageBox.Show("You must select a font before saving your changes.", "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        _bolIsDirty = False

    End Sub

    Private Sub tbFontSize_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbFontSize.ValueChanged
        Me.lblFontSize.Text = String.Format("Preview Font Size: {0}", Me.tbFontSize.Value.ToString)
        UpdateText()

    End Sub

    Private Sub UpdateText()

        If Me.lstFont.SelectedIndex = -1 Then
            Exit Sub
        End If

        txtSample.Font = CType(Me.lstFont.SelectedItem, MoleFontFamily).MakeFont(Me.tbFontSize.Value)

    End Sub

    'NEVER change the name of the sub.  If you change it to Sub Dispose, calling this will create a stack over flow
    Public Sub Dispose1() Implements IMoleEditor.Dispose
        Me.Dispose()

    End Sub

    'NEVER change the name of the sub.  If you change it to Sub ShowDialog, calling this will create a stack over flow
    Public Overloads Sub ShowDialog1() Implements IMoleEditor.ShowDialog
        Me.ShowDialog()

    End Sub

    Private Class MoleFontFamily
        Private _objFontFamily As FontFamily

        Public ReadOnly Property FontFamily() As FontFamily
            Get
                Return _objFontFamily
            End Get
        End Property

        Public Sub New(ByVal objFontFamily As FontFamily)
            _objFontFamily = objFontFamily

        End Sub

        'this code is necessary because a good number of fonts to not support FontStyle.Regular
        Public Function MakeFont(ByVal intSize As Integer) As Font

            Dim objNewFont As Font = Nothing

            If _objFontFamily.IsStyleAvailable(FontStyle.Regular) Then
                objNewFont = New Font(_objFontFamily.Name, intSize, FontStyle.Regular)

            ElseIf _objFontFamily.IsStyleAvailable(FontStyle.Bold) Then
                objNewFont = New Font(_objFontFamily.Name, intSize, FontStyle.Bold)

            ElseIf _objFontFamily.IsStyleAvailable(FontStyle.Italic) Then
                objNewFont = New Font(_objFontFamily.Name, intSize, FontStyle.Italic)

            ElseIf _objFontFamily.IsStyleAvailable(FontStyle.Underline) Then
                objNewFont = New Font(_objFontFamily.Name, intSize, FontStyle.Underline)

            ElseIf _objFontFamily.IsStyleAvailable(FontStyle.Strikeout) Then
                objNewFont = New Font(_objFontFamily.Name, intSize, FontStyle.Strikeout)
            End If

            Return objNewFont

        End Function

        Public Overrides Function ToString() As String
            Return _objFontFamily.Name

        End Function

    End Class

#End Region

End Class
