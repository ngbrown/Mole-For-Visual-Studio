Imports System.Windows.Forms

Public Class frmMoleTextAndNumberEditor
    Implements IMoleEditor

#Region " Declarations "

    Private _bolIsDirty As Boolean = False
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

        If strCurrentValue.IndexOf(vbCrLf) > 0 OrElse strCurrentValue.IndexOf(Environment.NewLine) > 0 OrElse strCurrentValue.IndexOf("<LineBreak") > 0 Then
            Me.txtValue.Multiline = True

            'TextBox height already set
        ElseIf _objEditInfoResponse.EditorType = PropertyEditorType.CharValue Then
            Me.txtValue.MaxLength = 1

        ElseIf _objEditInfoResponse.EditorType = PropertyEditorType.ByteValue Then
            Me.txtValue.MaxLength = 3
        End If

        Me.txtValue.Text = strCurrentValue
        _bolIsDirty = False
        Me.txtValue.Focus()

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

        Dim args As New MoleEditorWriteEventArgs(True, Me.txtValue.Text, _objRow, _objEditInfoResponse, WriteOperation.ResetValue)
        RaiseEvent WriteEdit(Me, args)

        If String.IsNullOrEmpty(args.WriteErrorMessage) Then
            'success
            Me.pbVisual.Image = args.Visual
            _strCurrentValue = args.NewValue
            Me.btnReset.Enabled = _objRow.CanReset
            Me.txtValue.Text = _strCurrentValue
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

    Private Function IsValid() As Boolean

        Select Case _objEditInfoResponse.EditorType

            Case PropertyEditorType.ByteValue

                Dim byt As Byte
                Return Byte.TryParse(Me.txtValue.Text, byt)

            Case PropertyEditorType.CharValue

                Dim c As Char
                Return Char.TryParse(Me.txtValue.Text, c)

            Case Else
                Return True
        End Select

    End Function

    Private Sub SaveEdit(ByVal bolReturnImage As Boolean, Optional ByVal bolSetToNull As Boolean = False)

        If Not IsValid() AndAlso Not bolSetToNull Then
            MessageBox.Show("Could not parse the value you entered.  Please enter a different value.", "Parse Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim strValue As String = Me.txtValue.Text

        If bolSetToNull Then
            Me.txtValue.Text = String.Empty
            strValue = Nothing
        End If

        If Me.txtValue.Text <> _strCurrentValue OrElse bolSetToNull Then

            Dim args As New MoleEditorWriteEventArgs(bolReturnImage, strValue, _objRow, _objEditInfoResponse, WriteOperation.WriteValue)
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

            _bolIsDirty = False
        End If

    End Sub

    Private Sub txtValue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValue.TextChanged
        _bolIsDirty = True

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
