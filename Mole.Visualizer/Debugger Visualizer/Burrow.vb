Imports Microsoft.VisualStudio.DebuggerVisualizers
Public Class Burrow
    Inherits DialogDebuggerVisualizer

    Protected Overrides Sub Show(ByVal windowService As Microsoft.VisualStudio.DebuggerVisualizers.IDialogVisualizerService, ByVal objectProvider As Microsoft.VisualStudio.DebuggerVisualizers.IVisualizerObjectProvider)
        '
        'rather than following the normal pattern of calling GetData or 
        'GetObject at this point, we will defer these calls to frmMole
        'by passing the objectProvider to the form
        '
        Using frm As New frmMole(objectProvider)
            frm.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
            windowService.ShowDialog(frm)
        End Using
    End Sub

End Class