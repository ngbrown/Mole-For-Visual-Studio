Public Class Form1

    'this was moved up here to module level scope to demonstrate the new fields features.
    Private _objComposerGroup As ComposerGroup

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        _objComposerGroup = New ComposerGroup("Team Mole")
        _objComposerGroup.Composers.Add(New Composer("Johann Sebastian Bach", "Baroque", New Uri("http://en.wikipedia.org/wiki/Bach")))
        _objComposerGroup.Composers.Add(New Composer("Gustav Mahler", "Late-Romantic", New Uri("http://en.wikipedia.org/wiki/Mahler")))
        _objComposerGroup.Composers.Add(New Composer("Sergei Prokofiev", "20th Century", New Uri("http://en.wikipedia.org/wiki/Prokofiev")))

        Me.DataGridView1.DataSource = _objComposerGroup.Composers

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        ' IMPORTANT!
        ' Put a breakpoint on the following line of code.  When the
        ' debugger stops here, hover the mouse cursor over the 
        ' Me.DataGridView1, and select the menu item called
        ' "Mole (Exploring WinForms)" from the datatip.
        '
        'You can also launch Mole from the Watch window

        Dim obj As DataGridView = Me.DataGridView1

        'To test using Mole to drilling around an exception, uncomment the following try catch block.
        'Remember that the SqlException contains a collection of Sql Errors.  You can drill into this as
        'well as other properties.

        'Try
        '    'NOTE: when calling BlowUp, .NET will try a few times before throwing the exception.  Give it 10 seconds or so.
        '    BlowUp()
        'Catch ex As SqlClient.SqlException
        '    'Put a break point on the following line of code
        '    'when Visual Studio breaks, hover over "ex" and use Mole to drill into it.
        '    Dim s As String = ex.ToString

        'Catch ex As Exception
        '    'Put a break point on the following line of code
        '    'when Visual Studio breaks, hover over "ex" and use Mole to drill into it.
        '    Dim s As String = ex.ToString
        'End Try

    End Sub

    Private Sub BlowUp()
        Dim cn As New SqlClient.SqlConnection("Data Source=SERVERNAME;Initial Catalog=DataBaseName;User ID=BIFF;Password=PASSWORD;")
        cn.Open()
    End Sub

End Class