Imports System.ServiceModel

<ServiceContract(Namespace:="http://http://www.thatindigogirl.com//Chapter1")> _
Public Interface IHelloIndigoService

    <OperationContract()> _
    Function HelloIndigo() As String

    <OperationContract()> _
    Function NewHelloIndigo(ByVal s As String) As String


End Interface

