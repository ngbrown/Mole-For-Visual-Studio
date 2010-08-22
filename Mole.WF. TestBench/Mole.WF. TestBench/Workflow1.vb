Public class Workflow1
    Inherits SequentialWorkflowActivity

    Private _strStateAbbreviation As String = String.Empty

    Public Property StateAbbreviation() As String
        Get
            Return _strStateAbbreviation
        End Get
        Set(ByVal Value As String)
            _strStateAbbreviation = Value
        End Set
    End Property

    Private Sub EvaluateStateCode(ByVal sender As System.Object, ByVal e As System.Workflow.Activities.ConditionalEventArgs)
        'TODO developers place your second breakpoint here
        'Place breakpoint on the second line of code
        'Then use Mole to investigate objSequentialWorkflowActivity variable
        '
        Dim objSequentialWorkflowActivity As SequentialWorkflowActivity = Me

        e.Result = StateAbbreviationValidator.GetInstance.IsValid(Me.StateAbbreviation)
    End Sub

    Private Sub StateCodeIsValid(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Console.WriteLine(String.Format("{0} is {1}", Me.StateAbbreviation, StateAbbreviationValidator.GetInstance.GetStateName(Me.StateAbbreviation)))
    End Sub

    Private Sub StateCodeInValid(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Console.WriteLine(String.Format("State abbreviation: {0}, is not valid", Me.StateAbbreviation))
    End Sub
End Class
