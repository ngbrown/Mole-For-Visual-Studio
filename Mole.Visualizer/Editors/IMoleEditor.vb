
Public Interface IMoleEditor

    Sub Dispose()
    Sub ShowDialog()
    Event WriteEdit(ByVal sender As Object, ByRef e As MoleEditorWriteEventArgs)

End Interface
