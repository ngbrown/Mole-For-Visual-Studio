
Public Class DataTableDisplay

#Region " Properties "

    Public ReadOnly Property DataGridView() As System.Windows.Forms.DataGridView
        Get
            Return Me.dgv
        End Get
    End Property

    Public ReadOnly Property TableName() As System.Windows.Forms.Label
        Get
            Return Me.lblTableName
        End Get
    End Property

#End Region

End Class
