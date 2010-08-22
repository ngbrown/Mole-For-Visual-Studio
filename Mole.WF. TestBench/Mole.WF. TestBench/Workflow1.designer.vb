<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial class Workflow1

    'NOTE: The following procedure is required by the Workflow Designer
    'It can be modified using the Workflow Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Private Sub InitializeComponent()
        Me.CanModifyActivities = True
        Dim codecondition1 As System.Workflow.Activities.CodeCondition = New System.Workflow.Activities.CodeCondition
        Me.codeActivity2 = New System.Workflow.Activities.CodeActivity
        Me.codeActivity1 = New System.Workflow.Activities.CodeActivity
        Me.ifElseBranchActivity2 = New System.Workflow.Activities.IfElseBranchActivity
        Me.ifElseBranchActivity1 = New System.Workflow.Activities.IfElseBranchActivity
        Me.ifElseActivity1 = New System.Workflow.Activities.IfElseActivity
        '
        'codeActivity2
        '
        Me.codeActivity2.Name = "codeActivity2"
        AddHandler Me.codeActivity2.ExecuteCode, AddressOf Me.StateCodeInValid
        '
        'codeActivity1
        '
        Me.codeActivity1.Name = "codeActivity1"
        AddHandler Me.codeActivity1.ExecuteCode, AddressOf Me.StateCodeIsValid
        '
        'ifElseBranchActivity2
        '
        Me.ifElseBranchActivity2.Activities.Add(Me.codeActivity2)
        Me.ifElseBranchActivity2.Name = "ifElseBranchActivity2"
        '
        'ifElseBranchActivity1
        '
        Me.ifElseBranchActivity1.Activities.Add(Me.codeActivity1)
        AddHandler codecondition1.Condition, AddressOf Me.EvaluateStateCode
        Me.ifElseBranchActivity1.Condition = codecondition1
        Me.ifElseBranchActivity1.Name = "ifElseBranchActivity1"
        '
        'ifElseActivity1
        '
        Me.ifElseActivity1.Activities.Add(Me.ifElseBranchActivity1)
        Me.ifElseActivity1.Activities.Add(Me.ifElseBranchActivity2)
        Me.ifElseActivity1.Name = "ifElseActivity1"
        '
        'Workflow1
        '
        Me.Activities.Add(Me.ifElseActivity1)
        Me.Name = "Workflow1"
        Me.CanModifyActivities = False

    End Sub
    Private ifElseBranchActivity2 As System.Workflow.Activities.IfElseBranchActivity
    Private ifElseBranchActivity1 As System.Workflow.Activities.IfElseBranchActivity
    Private codeActivity1 As System.Workflow.Activities.CodeActivity
    Private codeActivity2 As System.Workflow.Activities.CodeActivity
    Private ifElseActivity1 As System.Workflow.Activities.IfElseActivity

End Class
