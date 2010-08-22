Partial Public Class MoleTestBench
    Inherits System.Windows.Window

#Region " Declarations "


    Private _objComposers As New List(Of Composer)
    Private _datToday As Date = Now
    Private _datTodayNullable As Nullable(Of Date)
    Private _tsEndOfTheWorld As New TimeSpan(140, 6, 0)
    Private _rectRectangle As New System.Drawing.Rectangle(5, 5, 10, 10)
    Private _objEnviornmentVariables As IDictionary = Environment.GetEnvironmentVariables

#End Region

    'developers, please check out these properties.  I put them here to demonstrate Mole's editing and viewing capabilities.
    'notice the last property, EnviornmentVariables

#Region " Properties "

    Public Property Today() As Date
        Get
            Return _datToday
        End Get
        Set(ByVal Value As Date)
            _datToday = Value
        End Set
    End Property

    Public Property TodayNullable() As Nullable(Of Date)
        Get
            Return _datTodayNullable
        End Get
        Set(ByVal Value As Nullable(Of Date))
            _datTodayNullable = Value
        End Set
    End Property

    Public Property EndOfTheWorld() As TimeSpan
        Get
            Return _tsEndOfTheWorld
        End Get
        Set(ByVal Value As TimeSpan)
            _tsEndOfTheWorld = Value
        End Set
    End Property

    Public Property Rectangle() As System.Drawing.Rectangle
        Get
            Return _rectRectangle
        End Get
        Set(ByVal Value As System.Drawing.Rectangle)
            _rectRectangle = Value
        End Set
    End Property

    Public ReadOnly Property EnviornmentVariables() As IDictionary
        Get
            Return _objEnviornmentVariables
        End Get
    End Property

#End Region

#Region " Constructors "


    Public Sub New()
        InitializeComponent()
        Me.InitListView()
    End Sub
#End Region


    Private Sub MoleTestBench_PreviewMouseLeftButtonDown(ByVal sender As Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles Me.PreviewMouseLeftButtonDown

        If Keyboard.PrimaryDevice.Modifiers = ModifierKeys.Control Then

            Dim objToVisualizer As Object = e.OriginalSource
            ' IMPORTANT!
            ' Put a breakpoint on the following line of code.  When the
            ' debugger stops here, hover the mouse cursor over the
            ' e.OriginalSource property, and select the menu item called
            ' "Mole (Exploring WPF)" from the datatip.	

            objToVisualizer = e.OriginalSource

        End If

    End Sub

#Region " Methods "

    Private Sub InitListView()

        Dim bach As New Composer("Johann Sebastian Bach", "Baroque", New Uri("http://en.wikipedia.org/wiki/Bach"))
        _objComposers.Add(bach)

        Dim mahler As New Composer("Gustav Mahler", "Late-Romantic", New Uri("http://en.wikipedia.org/wiki/Mahler"))
        _objComposers.Add(mahler)

        Dim prokofiev As New Composer("Sergei Prokofiev", "20th Century", New Uri("http://en.wikipedia.org/wiki/Prokofiev"))
        _objComposers.Add(prokofiev)
        Me.listView.DataContext = _objComposers
        Me.listView.AddHandler(Hyperlink.RequestNavigateEvent, New RequestNavigateEventHandler(AddressOf OpenWebBrowser))
    End Sub

    Private Sub OpenWebBrowser(ByVal sender As Object, ByVal e As RequestNavigateEventArgs)
        Process.Start(e.Uri.OriginalString)
    End Sub
#End Region
End Class

