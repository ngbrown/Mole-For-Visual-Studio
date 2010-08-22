Imports System.Windows.Forms

Public Class frmMoleSelectFromValues
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

        Dim args As New MoleEditorWriteEventArgs(True, GetStringValue(False), _objRow, _objEditInfoResponse, WriteOperation.ResetValue)
        RaiseEvent WriteEdit(Me, args)

        If String.IsNullOrEmpty(args.WriteErrorMessage) Then
            'success
            Me.pbVisual.Image = args.Visual
            _strCurrentValue = args.NewValue
            Me.btnReset.Enabled = _objRow.CanReset
            _bolLoadingValues = True
            Me.lbValues.SelectedIndex = -1

            Dim intIndex As Integer

            For Each s As String In Me.lbValues.Items

                If String.Compare(s, _strCurrentValue, StringComparison.InvariantCultureIgnoreCase) = 0 Then
                    Me.lbValues.SelectedIndex = intIndex
                    Exit For
                End If

                intIndex += 1
            Next

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
        Me.lbValues.SelectedIndex = -1
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

    Private Sub frmMoleSelectFromValues_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _bolLoadingValues = True
        Me.lbValues.Items.Clear()

        Dim intIndex As Integer
        Dim intSetIndex As Integer = -1

        For Each s As String In _objEditInfoResponse.Values
            intIndex = Me.lbValues.Items.Add(s)

            If String.Compare(s, _strCurrentValue, StringComparison.InvariantCultureIgnoreCase) = 0 Then
                intSetIndex = intIndex
            End If

        Next

        Me.lbValues.SelectedIndex = intSetIndex
        _bolIsDirty = False
        _bolLoadingValues = False

    End Sub

    Private Function GetStringValue(ByVal bolSetToNull As Boolean) As String

        If Not bolSetToNull Then

            Dim strValue As String = String.Empty
            strValue = Me.lbValues.SelectedItem.ToString
            Return strValue

        Else
            Return Nothing
        End If

    End Function

    Private Sub lbValues_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbValues.SelectedIndexChanged

        If Not _bolLoadingValues Then
            _bolIsDirty = True
        End If

    End Sub

    Private Sub SaveEdit(ByVal bolReturnImage As Boolean, Optional ByVal bolSetToNull As Boolean = False)

        If Me.lbValues.SelectedIndex <> -1 OrElse bolSetToNull Then

            Dim strValue As String = Nothing

            If Not bolSetToNull Then
                strValue = GetStringValue(bolSetToNull)
            End If

            Dim args As New MoleEditorWriteEventArgs(bolReturnImage, strValue, _objRow, _objEditInfoResponse, WriteOperation.WriteValue)
            RaiseEvent WriteEdit(Me, args)

            If String.IsNullOrEmpty(args.WriteErrorMessage) Then

                'success
                If bolReturnImage Then
                    Me.pbVisual.Image = args.Visual
                End If

                _strCurrentValue = args.NewValue
                Me.btnReset.Enabled = _objRow.CanReset
                _bolLoadingValues = True
                Me.lbValues.SelectedIndex = -1

                Dim intIndex As Integer

                For Each s As String In Me.lbValues.Items

                    If String.Compare(s, _strCurrentValue, StringComparison.InvariantCultureIgnoreCase) = 0 Then
                        Me.lbValues.SelectedIndex = intIndex
                        Exit For
                    End If

                    intIndex += 1
                Next

                MyBase.SetLabelText(_strPropertyName, _strCurrentValue, _objRow.Cells(INTEGER_COLUMNINDEX_PROPERTYTYPE).Value.ToString)

            Else
                'write error
                MessageBox.Show(String.Format("Unable to set value, error message: {0}", args.WriteErrorMessage), "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        End If

        _bolIsDirty = False
        _bolLoadingValues = False

    End Sub

    'NEVER change the name of the sub.  If you change it to Sub Dispose, calling this will create a stack over flow
    Public Sub Dispose1() Implements IMoleEditor.Dispose
        Me.Dispose()

    End Sub

    'NEVER change the name of the sub.  If you change it to Sub ShowDialog, calling this will create a stack over flow
    Public Sub ShowDialog1() Implements IMoleEditor.ShowDialog
        Me.ShowDialog()

    End Sub

#End Region

End Class
