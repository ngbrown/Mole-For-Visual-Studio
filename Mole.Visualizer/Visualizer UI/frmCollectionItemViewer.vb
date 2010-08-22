Imports System.Windows.Forms

Public Class frmCollectionItemViewer

    Public Sub BuildGrid(ByVal ds As DataSet)
        For Each dt As DataTable In ds.Tables
            If dt.Rows.Count > 0 Then
                Dim ctl As New DataTableDisplay
                ctl.Dock = DockStyle.Top
                ctl.TableName.Text = String.Concat("Viewing data of Type ", dt.TableName)
                ctl.DataGridView.DataSource = dt
                Me.pnlContainer.Controls.Add(ctl)
            End If
        Next
    End Sub

End Class
