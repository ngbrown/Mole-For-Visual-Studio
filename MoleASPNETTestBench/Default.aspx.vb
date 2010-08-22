Partial Public Class _Default
    Inherits System.Web.UI.Page

    'this was moved up here to module level scope to demonstrate the new fields features.
    Private _objComposerGroup As ComposerGroup

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            _objComposerGroup = New ComposerGroup("Team Mole")
            _objComposerGroup.Composers.Add(New Composer("Johann Sebastian Bach", "Baroque", New Uri("http://en.wikipedia.org/wiki/Bach")))
            _objComposerGroup.Composers.Add(New Composer("Gustav Mahler", "Late-Romantic", New Uri("http://en.wikipedia.org/wiki/Mahler")))
            _objComposerGroup.Composers.Add(New Composer("Sergei Prokofiev", "20th Century", New Uri("http://en.wikipedia.org/wiki/Prokofiev")))

            Me.GridView1.DataSource = _objComposerGroup.Composers
            Me.GridView1.DataBind()

            Me.DropDownList1.Items.Add("Use Mole Now")
            Me.DropDownList1.Items.Add("Use Mole Later")

            'TODO developers use this tool to fully understand the ASP.NET page lifecycle.
            '1.  when you open the Mole visualizer from here, you will be able to drill all around the
            '    Me.GridView control.  Drill into it's DataSource property
            '    Now navigate up to the top level page object and drill into _objComposerGroup
            '
            '2.  After allowing the page to load, place your breakpoint in the Button1_Click event hander.
            '    Notice how different your results are.  Do you know why?
            '

            ' IMPORTANT!
            ' Put a breakpoint on the following line of code.  When the
            ' debugger stops here, hover the mouse cursor over the 
            ' Me.GridView1, and select the menu item called
            ' "Mole (Exploring ASP.NET)" from the datatip.
            '
            'You can also launch Mole from the Watch window
            Dim obj As GridView = Me.GridView1

        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        'Your drilling results will be different in this event handler than in the Page_Load event handler.
        'Do you know why?

        ' IMPORTANT!
        ' Put a breakpoint on the following line of code.  When the
        ' debugger stops here, hover the mouse cursor over the 
        ' Me.GridView1, and select the menu item called
        ' "Mole (Exploring ASP.NET)" from the datatip.
        '
        'You can also launch Mole from the Watch window

        Dim obj As GridView = Me.GridView1
    End Sub
End Class