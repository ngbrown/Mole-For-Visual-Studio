Imports System.Windows.Forms

Public Class frmMoleThicknessRectangleEditor
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
        _bolLoadingValues = True
        Me.nudOne.Maximum = Integer.MaxValue
        Me.nudOne.Minimum = Integer.MinValue
        Me.nudTwo.Maximum = Integer.MaxValue
        Me.nudTwo.Minimum = Integer.MinValue
        Me.nudThree.Maximum = Integer.MaxValue
        Me.nudThree.Minimum = Integer.MinValue
        Me.nudFour.Maximum = Integer.MaxValue
        Me.nudFour.Minimum = Integer.MinValue

        Select Case _objEditInfoResponse.EditorType

            Case PropertyEditorType.Thickness
                Me.nudOne.DecimalPlaces = 4
                Me.nudTwo.DecimalPlaces = 4
                Me.nudThree.DecimalPlaces = 4
                Me.nudFour.DecimalPlaces = 4
                Me.Text = "Mole Thickness Editor"
                Me.lblOne.Text = "Left"
                Me.lblTwo.Text = "Top"
                Me.lblThree.Text = "Right"
                Me.lblFour.Text = "Bottom"

            Case PropertyEditorType.RectDouble
                Me.nudOne.DecimalPlaces = 4
                Me.nudTwo.DecimalPlaces = 4
                Me.nudThree.DecimalPlaces = 4
                Me.nudFour.DecimalPlaces = 4
                Me.Text = "Mole Rectangle Editor"
                Me.lblOne.Text = "Left X"
                Me.lblTwo.Text = "Left Y"
                Me.lblThree.Text = "Width"
                Me.lblFour.Text = "Height"

            Case PropertyEditorType.RectInt
                Me.Text = "Mole Rectangle Editor"
                Me.lblOne.Text = "Left X"
                Me.lblTwo.Text = "Left Y"
                Me.lblThree.Text = "Width"
                Me.lblFour.Text = "Height"
        End Select

        If String.IsNullOrEmpty(_strCurrentValue) OrElse String.Equals(_strCurrentValue, "null") Then

            'use 0,0,0,0
        Else

            Dim strPieces() As String = _strCurrentValue.Split(","c)

            If strPieces.Length = 4 Then
                Decimal.TryParse(strPieces(0), Me.nudOne.Value)
                Decimal.TryParse(strPieces(1), Me.nudTwo.Value)
                Decimal.TryParse(strPieces(2), Me.nudThree.Value)
                Decimal.TryParse(strPieces(3), Me.nudFour.Value)

            ElseIf _objEditInfoResponse.EditorType = PropertyEditorType.Thickness AndAlso strPieces.Length = 1 Then
                Decimal.TryParse(strPieces(0), Me.nudOne.Value)
                Decimal.TryParse(strPieces(0), Me.nudTwo.Value)
                Decimal.TryParse(strPieces(0), Me.nudThree.Value)
                Decimal.TryParse(strPieces(0), Me.nudFour.Value)
            End If

        End If

        _bolIsDirty = False
        _bolLoadingValues = False

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

        Dim strValue As String = String.Concat(Me.nudOne.Value.ToString, ",", Me.nudTwo.Value.ToString, ",", Me.nudThree.Value.ToString, ",", Me.nudFour.Value.ToString)
        Dim args As New MoleEditorWriteEventArgs(True, strValue, _objRow, _objEditInfoResponse, WriteOperation.ResetValue)
        RaiseEvent WriteEdit(Me, args)

        If String.IsNullOrEmpty(args.WriteErrorMessage) Then
            'success
            Me.pbVisual.Image = args.Visual
            _strCurrentValue = args.NewValue
            Me.btnReset.Enabled = _objRow.CanReset
            _bolLoadingValues = True

            If String.IsNullOrEmpty(_strCurrentValue) OrElse String.Equals(_strCurrentValue, "null") Then
                Me.nudOne.Value = 0
                Me.nudTwo.Value = 0
                Me.nudThree.Value = 0
                Me.nudFour.Value = 0

            Else

                Dim strPieces() As String = _strCurrentValue.Split(","c)

                If strPieces.Length = 4 Then
                    Decimal.TryParse(strPieces(0), Me.nudOne.Value)
                    Decimal.TryParse(strPieces(1), Me.nudTwo.Value)
                    Decimal.TryParse(strPieces(2), Me.nudThree.Value)
                    Decimal.TryParse(strPieces(3), Me.nudFour.Value)

                ElseIf _objEditInfoResponse.EditorType = PropertyEditorType.Thickness AndAlso strPieces.Length = 1 Then
                    Decimal.TryParse(strPieces(0), Me.nudOne.Value)
                    Decimal.TryParse(strPieces(0), Me.nudTwo.Value)
                    Decimal.TryParse(strPieces(0), Me.nudThree.Value)
                    Decimal.TryParse(strPieces(0), Me.nudFour.Value)

                Else
                    Me.nudOne.Value = 0
                    Me.nudTwo.Value = 0
                    Me.nudThree.Value = 0
                    Me.nudFour.Value = 0
                End If

            End If

            MyBase.SetLabelText(_strPropertyName, _strCurrentValue, _objRow.Cells(INTEGER_COLUMNINDEX_PROPERTYTYPE).Value.ToString)

        Else
            'write error
            MessageBox.Show(String.Format("Unable to reset value, error message: {0}", args.WriteErrorMessage), "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        _bolIsDirty = False
        _bolLoadingValues = False

    End Sub

    Private Sub btnSaveClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveClose.Click
        SaveEdit(False)
        Me.Close()

    End Sub

    Private Sub btnSetToNull_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetToNull.Click
        Me.nudOne.Value = 0
        Me.nudTwo.Value = 0
        Me.nudThree.Value = 0
        Me.nudFour.Value = 0
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

    Private Sub nud_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudOne.ValueChanged, nudTwo.ValueChanged, nudThree.ValueChanged, nudFour.ValueChanged

        If Not _bolLoadingValues Then
            _bolIsDirty = True
        End If

    End Sub

    Private Sub SaveEdit(ByVal bolReturnImage As Boolean, Optional ByVal bolSetToNull As Boolean = False)

        Dim strValue As String = Nothing

        If Not bolSetToNull Then
            strValue = String.Concat(Me.nudOne.Value.ToString, ",", Me.nudTwo.Value.ToString, ",", Me.nudThree.Value.ToString, ",", Me.nudFour.Value.ToString)
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
            MyBase.SetLabelText(_strPropertyName, _strCurrentValue, _objRow.Cells(INTEGER_COLUMNINDEX_PROPERTYTYPE).Value.ToString)

        Else
            'write error
            MessageBox.Show(String.Format("Unable to set value, error message: {0}", args.WriteErrorMessage), "Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        _bolIsDirty = False

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
