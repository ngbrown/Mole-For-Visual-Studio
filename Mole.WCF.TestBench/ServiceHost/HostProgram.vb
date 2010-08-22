Imports System.ServiceModel

Module HostProgram

    Sub Main()

        Using host As New ServiceModel.ServiceHost(GetType(HelloIndigo.HelloIndigoService), New Uri("http://localhost:8000/HelloIndigo"))

            host.AddServiceEndpoint(GetType(HelloIndigo.IHelloIndigoService), New BasicHttpBinding, "HelloIndigoService")

            ' IMPORTANT!
            ' Put a breakpoint on the following line of code.  When the
            ' debugger stops here, hover the mouse cursor over the
            ' host object, and select the menu item called
            ' "Mole (Exploring WCF)" from the datatip.		

            host.Open()

            Console.WriteLine("Press <ENTER> to terminate the service host.")
            Console.ReadLine()

        End Using

    End Sub

End Module
