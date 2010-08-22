Public Class HelloIndigoService
    Implements IHelloIndigoService

    Public Function HelloIndigo() As String Implements IHelloIndigoService.HelloIndigo
        Return "Hello Indigo"
    End Function

    Public Function NewHelloIndigo(ByVal s As String) As String Implements IHelloIndigoService.NewHelloIndigo
        Return s
    End Function
End Class
