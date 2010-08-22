
' simple façade
Public Class MoleEditor

#Region " Declarations "

    Private WithEvents _objIMoleEditor As IMoleEditor

#End Region

#Region " Events "

    Public Event WriteEdit(ByVal sender As Object, ByVal e As MoleEditorWriteEventArgs)

#End Region

#Region " Methods "

    Private Sub _objIMoleEditor_WriteEdit(ByVal sender As Object, ByRef e As MoleEditorWriteEventArgs) Handles _objIMoleEditor.WriteEdit
        RaiseEvent WriteEdit(sender, e)

    End Sub

    Public Sub ShowDialog(ByVal strCurrentValue As String, ByVal strPropertyName As String, ByVal objEditInfoResponse As EditInfoResponse, ByVal row As Mole.MoleDataGridViewRow, ByVal objVisual As System.Drawing.Bitmap, ByRef objMoleSettings As MoleSettings)

        Try

            Dim objMoleEditorFactory As New MoleEditorFactory
            _objIMoleEditor = objMoleEditorFactory.Create(strCurrentValue, strPropertyName, objEditInfoResponse, row, objVisual, objMoleSettings)
            _objIMoleEditor.ShowDialog()

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show("Exception during editing.  Please submit a bug report to moleproject@yahoo.com." & vbCrLf & vbCrLf & "The exception text has been copied to the ClipBoard so you can send it to us." & vbCrLf & vbCrLf & ex.ToString, "Editing Exception", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
            My.Computer.Clipboard.Clear()
            My.Computer.Clipboard.SetText(ex.ToString)

        Finally

            If _objIMoleEditor IsNot Nothing Then
                _objIMoleEditor.Dispose()
            End If

        End Try

    End Sub

#End Region

#Region " Mole Editor Factory "

    'simple factory
    Private Class MoleEditorFactory

        Function Create(ByVal strCurrentValue As String, ByVal strPropertyName As String, ByVal objEditInfoResponse As EditInfoResponse, ByVal row As Mole.MoleDataGridViewRow, ByVal objVisual As System.Drawing.Bitmap, ByRef objMoleSettings As MoleSettings) As IMoleEditor

            Select Case objEditInfoResponse.EditorType

                Case PropertyEditorType.DrawingColor, PropertyEditorType.MediaColor
                    Return New frmMoleColorEditor(strCurrentValue, strPropertyName, objEditInfoResponse, row, objVisual, objMoleSettings)

                Case PropertyEditorType.DateTime
                    Return New frmMoleDateTimeEditor(strCurrentValue, strPropertyName, objEditInfoResponse, row, objVisual, objMoleSettings)

                Case PropertyEditorType.Font
                    Return New frmMoleFontEditor(strCurrentValue, strPropertyName, objEditInfoResponse, row, objVisual, objMoleSettings)

                Case PropertyEditorType.RectDouble, PropertyEditorType.RectInt, PropertyEditorType.Thickness
                    Return New frmMoleThicknessRectangleEditor(strCurrentValue, strPropertyName, objEditInfoResponse, row, objVisual, objMoleSettings)

                Case PropertyEditorType.TimeSpan
                    Return New frmMoleTimeSpanEditor(strCurrentValue, strPropertyName, objEditInfoResponse, row, objVisual, objMoleSettings)

                Case PropertyEditorType.FontName
                    Return New frmMoleFontNameEditor(strCurrentValue, strPropertyName, objEditInfoResponse, row, objVisual, objMoleSettings)
            End Select

            If objEditInfoResponse.Values.Length > 1 Then
                Return New frmMoleSelectFromValues(strCurrentValue, strPropertyName, objEditInfoResponse, row, objVisual, objMoleSettings)
            End If

            Select Case objEditInfoResponse.EditorType

                'Case PropertyEditorType.BoolValue is not required.  It's handled above by objEditInfoResponse.Values.Length > 1 code     
                Case PropertyEditorType.ByteValue, PropertyEditorType.CharValue, PropertyEditorType.DecimalValue, PropertyEditorType.DoubleValue, PropertyEditorType.FloatValue, PropertyEditorType.Int16Value, PropertyEditorType.Int32Value, PropertyEditorType.Int64Value, PropertyEditorType.Text
                    Return New frmMoleTextAndNumberEditor(strCurrentValue, strPropertyName, objEditInfoResponse, row, objVisual, objMoleSettings)

                Case Else
                    Throw New ArgumentOutOfRangeException("EditorType", objEditInfoResponse.EditorType, "This editor type has not yet been programmed")
            End Select

        End Function

    End Class

#End Region

End Class
