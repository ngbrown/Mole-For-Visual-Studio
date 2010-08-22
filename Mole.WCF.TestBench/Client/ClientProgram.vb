Imports System.ServiceModel

Module ClientProgram

    Sub Main()

        Dim ep As New EndpointAddress("http://localhost:8000/HelloIndigo/HelloIndigoService")
        Dim proxy As HelloIndigo.IHelloIndigoService = ChannelFactory(Of HelloIndigo.IHelloIndigoService).CreateChannel(New BasicHttpBinding, ep)
        Console.WriteLine(proxy.HelloIndigo)
        Console.WriteLine()
        Console.WriteLine(proxy.NewHelloIndigo("Hey"))
        Console.WriteLine()
        Console.WriteLine("Press <ENTER> to terminate the client.")
        Console.ReadLine()

    End Sub

End Module
