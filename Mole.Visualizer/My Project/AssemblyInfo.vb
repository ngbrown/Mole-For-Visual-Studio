Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("Mole For Visual Studio")> 
<Assembly: AssemblyDescription("Mole burrows into .NET all applications while debugging.")> 
<Assembly: AssemblyCompany("JAK Productions")> 
<Assembly: AssemblyProduct("Mole.Visualizer")> 
<Assembly: AssemblyCopyright("Copyright © Karl Shifflett, Josh Smith & Andrew Smith 2007")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("765142ed-47f5-4d4a-8f1d-cb7d10adaa73")> 

' Version information for an assembly consists of the following four values:
'
'      Major Version
'      Minor Version 
'      Build Number
'      Revision
'
' You can specify all the values or you can default the Build and Revision Numbers 
' by using the '*' as shown below:
' <Assembly: AssemblyVersion("1.0.*")> 

<Assembly: AssemblyVersion("4.2.0.0")> 
<Assembly: AssemblyFileVersion("4.2.0.0")> 

'TODO developers feel free to add more Types that Mole can visualize
'     You only have to add the attribute here, Mole can handle just about ANYTHING you throw at it without changing any code.

'This attribute is the dream child of Rock Star Josh Smith.  It's called, "The Rock Star Hack of 2008"  See Mole article for full description for using the entry point method.
<Assembly: System.Diagnostics.DebuggerVisualizer(GetType(Mole.Burrow), GetType(Mole.MoleVisualizerObjectSource), Target:=GetType(System.WeakReference), Description:="Mole Anything! (Weak Reference)")> 

<Assembly: System.Diagnostics.DebuggerVisualizer(GetType(Mole.Burrow), GetType(Mole.MoleVisualizerObjectSource), Target:=GetType(System.Workflow.ComponentModel.DependencyObject), Description:="Mole (Exploring WorkFlow)")> 

<Assembly: System.Diagnostics.DebuggerVisualizer(GetType(Mole.Burrow), GetType(Mole.MoleVisualizerObjectSource), Target:=GetType(System.Workflow.Runtime.WorkflowInstance), Description:="Mole (Exploring WorkFlow Instance)")> 

<Assembly: System.Diagnostics.DebuggerVisualizer(GetType(Mole.Burrow), GetType(Mole.MoleVisualizerObjectSource), Target:=GetType(System.Windows.DependencyObject), Description:="Mole (Exploring WPF)")> 

<Assembly: System.Diagnostics.DebuggerVisualizer(GetType(Mole.Burrow), GetType(Mole.MoleVisualizerObjectSource), Target:=GetType(System.Web.UI.Control), Description:="Mole (Exploring ASP.NET)")> 

<Assembly: System.Diagnostics.DebuggerVisualizer(GetType(Mole.Burrow), GetType(Mole.MoleVisualizerObjectSource), Target:=GetType(System.Windows.Forms.Control), Description:="Mole (Exploring WinForms)")> 

<Assembly: System.Diagnostics.DebuggerVisualizer(GetType(Mole.Burrow), GetType(Mole.MoleVisualizerObjectSource), Target:=GetType(System.Data.DataSet), Description:="Mole (Exploring DataSet)")> 

<Assembly: System.Diagnostics.DebuggerVisualizer(GetType(Mole.Burrow), GetType(Mole.MoleVisualizerObjectSource), Target:=GetType(System.Data.DataTable), Description:="Mole (Exploring DataTable)")> 

<Assembly: System.Diagnostics.DebuggerVisualizer(GetType(Mole.Burrow), GetType(Mole.MoleVisualizerObjectSource), Target:=GetType(System.EventArgs), Description:="Mole (Exploring EventArgs)")> 

<Assembly: System.Diagnostics.DebuggerVisualizer(GetType(Mole.Burrow), GetType(Mole.MoleVisualizerObjectSource), Target:=GetType(System.ServiceModel.ServiceHost), Description:="Mole (Exploring WCF)")> 

<Assembly: System.Diagnostics.DebuggerVisualizer(GetType(Mole.Burrow), GetType(Mole.MoleVisualizerObjectSource), Target:=GetType(System.Data.SqlClient.SqlException), Description:="Mole (Exploring SQLException)")> 