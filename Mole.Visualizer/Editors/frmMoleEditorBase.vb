Imports System.Windows.Forms

Public Class frmMoleEditorBase

#Region " Methods "

    Public Sub ApplyWindowSettings(ByVal objMoleSettings As MoleSettings, ByVal strFormName As String)

        Dim obj As MoleEditorWindowState = Nothing

        If objMoleSettings.MoleEditorWindowStates.TryGetValue(strFormName, obj) Then

            Dim objActiveScreen As Screen = Screen.PrimaryScreen

            For Each objScreen As Screen In Screen.AllScreens

                If obj.ScreenDeviceName = objScreen.DeviceName Then
                    Me.Bounds = objScreen.Bounds
                    objActiveScreen = objScreen
                    Exit For
                End If

            Next

            'if the user sets their monitor resolution smaller and the window would start off their smaller screen, just move to to 10,10
            If obj.WindowLocation.X > Me.Bounds.Right OrElse obj.WindowLocation.Y > Me.Bounds.Bottom Then
                Me.Location = New System.Drawing.Point(10, 10)

            Else
                Me.Location = obj.WindowLocation
            End If

            Me.Size = obj.WindowSize

        End If

    End Sub

    Public Sub SaveWindowSettings(ByRef objMoleSettings As MoleSettings, ByVal strFormName As String)

        Dim obj As MoleEditorWindowState = Nothing
        Dim bolIsNew As Boolean = False

        If Not objMoleSettings.MoleEditorWindowStates.TryGetValue(strFormName, obj) Then
            bolIsNew = True
            obj = New MoleEditorWindowState
        End If

        With obj
            .ScreenDeviceName = Screen.FromControl(Me).DeviceName
            .WindowLocation = Me.Location
            .WindowSize = Me.Size
        End With

        If bolIsNew Then
            objMoleSettings.MoleEditorWindowStates.Add(strFormName, obj)
        End If

    End Sub

    Public Sub SetLabelText(ByVal strPropertyName As String, ByVal strCurrentValue As String, ByVal strDataType As String)
        Me.lblPropertyBeindEdited.Text = String.Format("[Editing: {0}],  [Current Value: {1}],  [Data Type: {2}]", strPropertyName, strCurrentValue, strDataType)

    End Sub

#End Region

End Class
