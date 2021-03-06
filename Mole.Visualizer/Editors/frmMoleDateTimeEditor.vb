Imports System.Windows.Forms

Public Class frmMoleDateTimeEditor
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
        SetValue()
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

        Dim dDate As Date = Me.dtpDate.Value

        If Me.cbIncludeTime.Checked = True Then
            dDate = New Date(Me.dtpDate.Value.Year, Me.dtpDate.Value.Month, Me.dtpDate.Value.Day, Me.dtpTime.Value.Hour, Me.dtpTime.Value.Minute, Me.dtpTime.Value.Second)
        End If

        Dim args As New MoleEditorWriteEventArgs(True, dDate.ToString, _objRow, _objEditInfoResponse, WriteOperation.ResetValue)
        RaiseEvent WriteEdit(Me, args)

        If String.IsNullOrEmpty(args.WriteErrorMessage) Then
            'success
            Me.pbVisual.Image = args.Visual
            _strCurrentValue = args.NewValue
            Me.btnReset.Enabled = _objRow.CanReset
            SetValue()
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
        Me.dtpDate.Value = Now
        SaveEdit(True, True)

    End Sub

    Private Sub cbIncludeTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbIncludeTime.CheckedChanged
        Me.dtpTime.Enabled = Me.cbIncludeTime.Checked

    End Sub

    Private Sub dtpDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpDate.ValueChanged, dtpTime.ValueChanged
        ShowDateTime()
        _bolIsDirty = True

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

    Private Sub SaveEdit(ByVal bolReturnImage As Boolean, Optional ByVal bolSetToNull As Boolean = False)

        Dim dDate As Date = Me.dtpDate.Value

        If Me.cbIncludeTime.Checked = True Then
            dDate = New Date(Me.dtpDate.Value.Year, Me.dtpDate.Value.Month, Me.dtpDate.Value.Day, Me.dtpTime.Value.Hour, Me.dtpTime.Value.Minute, Me.dtpTime.Value.Second)

        Else
            dDate = New Date(Me.dtpDate.Value.Year, Me.dtpDate.Value.Month, Me.dtpDate.Value.Day, 0, 0, 0)
        End If

        Dim strDate As String = dDate.ToString

        If bolSetToNull Then
            strDate = Nothing
        End If

        Dim args As New MoleEditorWriteEventArgs(bolReturnImage, strDate, _objRow, _objEditInfoResponse, WriteOperation.WriteValue)
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

    End Sub

    Private Sub SetValue()
        _bolIsDirty = True

        Dim dDate As Date

        If String.IsNullOrEmpty(_strCurrentValue) OrElse String.Equals(_strCurrentValue, "null") OrElse Not Date.TryParse(_strCurrentValue, dDate) Then
            dDate = New Date(Now.Year, Now.Month, Now.Day)
            Me.cbIncludeTime.Checked = False

        Else
            Me.dtpDate.Value = dDate

            If dDate.TimeOfDay.Hours > 0 OrElse dDate.TimeOfDay.Minutes > 0 OrElse dDate.TimeOfDay.Seconds > 0 Then
                Me.cbIncludeTime.Checked = True
                Me.dtpTime.Value = dDate
            End If

        End If

        ShowDateTime()

    End Sub

    Private Sub ShowDateTime()

        If Me.cbIncludeTime.Checked = True Then
            Me.lblSelectedDateTime.Text = String.Concat(Me.dtpDate.Value.ToShortDateString, " ", Me.dtpTime.Value.ToShortTimeString)

        Else
            Me.lblSelectedDateTime.Text = Me.dtpDate.Value.ToShortDateString
        End If

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
