Module Module1
    Class Program

        Shared WaitHandle As New AutoResetEvent(False)

        Shared Sub Main(ByVal args() As String)

            Dim objDictionary As Dictionary(Of String, Object)
            If args.Length = 1 AndAlso args(0).Trim.Length = 2 Then
                objDictionary = New Dictionary(Of String, Object)
                objDictionary.Add("StateAbbreviation", args(0).Trim.ToUpper)
            Else
                Console.WriteLine("you must enter a two character state abbreviation to validate")
                Exit Sub
            End If

            Using objWorkFlowRuntime As New WorkflowRuntime()
                AddHandler objWorkFlowRuntime.WorkflowCompleted, AddressOf OnWorkflowCompleted
                AddHandler objWorkFlowRuntime.WorkflowTerminated, AddressOf OnWorkflowTerminated

                Dim objWorkFlowInstance As WorkflowInstance = objWorkFlowRuntime.CreateWorkflow(GetType(Workflow1), objDictionary)
                objWorkFlowInstance.Start()
                WaitHandle.WaitOne()

                'TODO developers place your first breakpoint here
                'Place breakpoint on the next line of code
                'Then use Mole to investigate objWorkFlowInstance above.  Make sure you use the "Show Fields" option to drill around the objWorkFlowInstance.
                Dim dummy As Object = Nothing

            End Using
        End Sub

        Shared Sub OnWorkflowCompleted(ByVal sender As Object, ByVal e As WorkflowCompletedEventArgs)
            WaitHandle.Set()
        End Sub

        Shared Sub OnWorkflowTerminated(ByVal sender As Object, ByVal e As WorkflowTerminatedEventArgs)
            Console.WriteLine(e.Exception.Message)
            WaitHandle.Set()
        End Sub

    End Class
End Module

