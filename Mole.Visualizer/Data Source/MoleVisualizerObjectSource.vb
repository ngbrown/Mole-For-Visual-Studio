'
Imports System.Windows
Imports System.Windows.Media
Imports System.Windows.Media.Media3D
Imports System.ComponentModel
Imports Microsoft.VisualStudio.DebuggerVisualizers
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Reflection

Public Class MoleVisualizerObjectSource
    Inherits VisualizerObjectSource

#Region " Declarations "

    Private Const STRING_NAME As String = "Name"
    Private Const STRING_STRING As String = "String"
    Private _dictAttachedProperties As New Dictionary(Of String, DependencyPropertyDescriptor)
    Private _dictDrillingOperations As New Dictionary(Of Integer, Object)
    Private _dictObjectTree As Dictionary(Of Integer, Object)
    Private _dictVisualTree As Dictionary(Of Integer, DependencyObject)
    Private _enumMoleMode As MoleMode
    Private _intDrillingElementIdCounter As Integer
    Private _intLogicalElementIdCounter As Integer
    Private _intVisualElementIdCounter As Integer
    Private Shared _objBinaryFormatter As New BinaryFormatter

#End Region

#Region " Overridden Methods "

    ''' <summary>
    ''' </summary>
    Public Overrides Sub GetData(ByVal target As Object, ByVal outgoingData As System.IO.Stream)

        If TypeOf target Is System.WeakReference Then
            Dim wr As WeakReference = CType(target, System.WeakReference)
            If wr.Target Is Nothing Then
                'if the target of the weakreference is null, then just close Mole
                _enumMoleMode = MoleMode.NOTSUPPORTED
            Else
                _enumMoleMode = GetMoleModeFromDataType(wr.Target)
            End If

        Else
            _enumMoleMode = GetMoleModeFromDataType(target)
        End If

        MoleVisualizerObjectSource.Serialize(outgoingData, _enumMoleMode)

    End Sub

    Private Function GetMoleModeFromDataType(ByVal target As Object) As MoleMode

        If TypeOf target Is System.Windows.DependencyObject Then
            Return MoleMode.WPF

        ElseIf TypeOf target Is System.Web.UI.Control Then
            Return MoleMode.ASPNET

        ElseIf TypeOf target Is System.Windows.Forms.Control Then
            Return MoleMode.WinForms

        ElseIf TypeOf target Is ValueType Then
            Return MoleMode.ValueType

        Else
            Return MoleMode.Class
        End If
    End Function

    '
    '
    '
    ''' <summary>
    ''' Returns the data requested by incomingData
    ''' This sub is actually called by Visual Studio when the frmMole makes the .TransferData
    ''' call to the IVisualizerObjectProvider
    ''' </summary>
    ''' <param name="target">Original object selected by developer in Visual Studio</param>
    ''' <param name="incomingData">DataRequestObject</param>
    ''' <param name="outgoingData">Stream of data requested by incomingData</param>
    ''' <exception cref="NullReferenceException">Thrown when the Visual Tree Dictionary has not been initialized.  GetData must be called before TransferData</exception>
    ''' <remarks>This sub can blow up when requesting the XAML HTML.  This is because System.Windows.Markup.XamlWriter.Save gets into a condition that causes a stack overflow.  Maybe this function will be fixed in 3.5</remarks>
    Public Overrides Sub TransferData(ByVal target As Object, ByVal incomingData As System.IO.Stream, ByVal outgoingData As System.IO.Stream)

        Dim objTransferDataRequest As TransferDataRequest = CType(MoleVisualizerObjectSource.Deserialize(incomingData), TransferDataRequest)

        'this is the traffic cop.
        If objTransferDataRequest.TransferDataTreeTarget = TransferDataTreeTarget.LogicalTree Then

            If TypeOf target Is System.WeakReference Then
                ProcessLogicalTreeTransferDataRequest(CType(target, System.WeakReference).Target, objTransferDataRequest, outgoingData)
            Else
                ProcessLogicalTreeTransferDataRequest(target, objTransferDataRequest, outgoingData)
            End If

        ElseIf objTransferDataRequest.TransferDataTreeTarget = TransferDataTreeTarget.VisualTree Then

            If TypeOf target Is System.WeakReference Then
                ProcessVisualTreeTransferDataRequest(CType(target, System.WeakReference).Target, objTransferDataRequest, outgoingData)
            Else
                ProcessVisualTreeTransferDataRequest(target, objTransferDataRequest, outgoingData)
            End If

        Else
            Throw New ArgumentOutOfRangeException("TransferDataTreeTarget", objTransferDataRequest.TransferDataTreeTarget, "This value was never programmed")
        End If

    End Sub

#End Region

#Region " TransferDataRequest Processors "

    Private Sub ClearDrillingOperation()

        If _dictDrillingOperations.Count > 0 Then
            _dictDrillingOperations.Clear()
            _intDrillingElementIdCounter = 0
        End If

    End Sub

    Private Function GetBlackOpsDrillingOperationProperties(ByVal objTransferDataRequest As TransferDataRequest, ByVal objPropertyParentObject As Object) As DrillingOperationResponse

        Dim objObject As Object = Nothing
        Dim prop As PropertyDescriptor
        Dim objNewParentObject As Object = Nothing
        Dim propertySource As Object

        'this means we are drilling into another child from at least one child, i.e. not the parent elements properties
        If objTransferDataRequest.LastDrillingOperationId <> 0 Then

            If Not _dictDrillingOperations.TryGetValue(objTransferDataRequest.LastDrillingOperationId, objObject) Then
                Throw New ArgumentOutOfRangeException("GetDrillingOperationProperties received an invalid LastDrillingOperationId.")
            End If

            propertySource = objObject

        Else

            propertySource = objPropertyParentObject
        End If

        Dim objFieldInfo As System.Reflection.FieldInfo = GetFieldInfo(propertySource, objTransferDataRequest.PropertyNameToDrill)

        If objFieldInfo IsNot Nothing Then
            objNewParentObject = objFieldInfo.GetValue(propertySource)

        Else
            prop = TypeDescriptor.GetProperties(propertySource)(objTransferDataRequest.PropertyNameToDrill)

            If prop IsNot Nothing Then
                objNewParentObject = prop.GetValue(propertySource)
            End If

        End If

        If objNewParentObject IsNot Nothing Then
            _intDrillingElementIdCounter += 1
            _dictDrillingOperations.Add(_intDrillingElementIdCounter, objNewParentObject)
            Return New DrillingOperationResponse(IsPropertyACollection(objNewParentObject), objTransferDataRequest.OriginalSelectedElementId, _intDrillingElementIdCounter, GetTreeElementProperties(objNewParentObject, objTransferDataRequest.MaxRowsInCollectionData), objNewParentObject.GetType.FullName)

        Else
            Return New DrillingOperationResponse(False, 0, 0, New List(Of TreeElementProperty), String.Empty)
        End If

    End Function

    Private Function GetCollectionItem(ByVal objCollection As Object, ByVal intIndex As Integer) As Object

        Dim objList As IList = TryCast(objCollection, IList)

        If Not objList Is Nothing Then
            Return objList(intIndex)

        ElseIf TypeOf objCollection Is IDictionary Then

            Dim intX As Integer

            For Each item As Object In DirectCast(objCollection, IDictionary)

                If intIndex = intX Then
                    Return item
                End If

                intX += 1
            Next

        ElseIf TypeOf objCollection Is ICollection Then

            Dim intX As Integer

            For Each item As Object In DirectCast(objCollection, ICollection)

                If intIndex = intX Then
                    Return item
                End If

                intX += 1
            Next

        End If

        'added this since it can drop through the If Block
        Return Nothing

    End Function

    Private Function GetDrillingOperationProperties(ByVal objTransferDataRequest As TransferDataRequest, ByVal objPropertyParentObject As Object) As DrillingOperationResponse

        Dim objObject As Object = Nothing
        Dim prop As PropertyDescriptor
        Dim objNewParentObject As Object = Nothing
        Dim propertySource As Object

        'this means we are drilling into another child from at least one child, i.e. not the parent elements properties
        If objTransferDataRequest.LastDrillingOperationId <> 0 Then

            If Not _dictDrillingOperations.TryGetValue(objTransferDataRequest.LastDrillingOperationId, objObject) Then
                Throw New ArgumentOutOfRangeException("GetDrillingOperationProperties received an invalid LastDrillingOperationId.")
            End If

            propertySource = objObject

        Else

            propertySource = objPropertyParentObject
        End If

        prop = TypeDescriptor.GetProperties(propertySource)(objTransferDataRequest.PropertyNameToDrill)

        If prop IsNot Nothing Then
            objNewParentObject = prop.GetValue(propertySource)

        ElseIf objTransferDataRequest.PropertyNameToDrill.StartsWith(STRING_LEFT_COLLECTION_INDEX_MARKER) Then

            'get the collection member
            Dim indexAsString As String = objTransferDataRequest.PropertyNameToDrill.Substring(1, objTransferDataRequest.PropertyNameToDrill.Length - 2)
            Dim index As Integer

            If Int32.TryParse(indexAsString, index) Then
                objNewParentObject = GetCollectionItem(propertySource, index)
            End If

        End If

        If objNewParentObject IsNot Nothing Then
            _intDrillingElementIdCounter += 1
            _dictDrillingOperations.Add(_intDrillingElementIdCounter, objNewParentObject)
            Return New DrillingOperationResponse(IsPropertyACollection(objNewParentObject), objTransferDataRequest.OriginalSelectedElementId, _intDrillingElementIdCounter, GetTreeElementProperties(objNewParentObject, objTransferDataRequest.MaxRowsInCollectionData), objNewParentObject.GetType.FullName)

        Else
            Return New DrillingOperationResponse(False, 0, 0, New List(Of TreeElementProperty), String.Empty)
        End If

    End Function

    Private Sub GetEditInfo(ByVal target As Object, ByVal objTransferDataRequest As TransferDataRequest, ByRef outgoingData As System.IO.Stream)

        Dim propertyDescriptor As PropertyDescriptor = Nothing
        Dim fieldInfo As FieldInfo = Nothing
        Dim converter As TypeConverter = Nothing
        Dim memberType As Type = Nothing

        If Not PrepareEditInfo(target, objTransferDataRequest, converter, propertyDescriptor, fieldInfo, memberType, outgoingData) Then
            Return
        End If

        Dim editInfo As EditInfoResponse = EditInfoResponse.Create(memberType, converter)

        If propertyDescriptor IsNot Nothing Then

            Dim depProp As DependencyPropertyDescriptor = DependencyPropertyDescriptor.FromProperty(propertyDescriptor)

            If depProp IsNot Nothing AndAlso depProp.DependencyProperty Is System.Windows.Controls.TextBlock.FontFamilyProperty Then
                editInfo.AllowNull = False
            End If

        End If

        MoleVisualizerObjectSource.Serialize(outgoingData, editInfo)

    End Sub

    Private Function GetFieldInfo(ByVal source As Object, ByVal fieldName As String) As FieldInfo

        Dim name As String() = fieldName.Split(CChar("."))
        Dim targetType As Type = source.GetType()

        While targetType.Name <> name(0)
            targetType = targetType.BaseType
        End While

        Dim objFieldInfo As System.Reflection.FieldInfo = Nothing

        If targetType IsNot Nothing Then
            objFieldInfo = targetType.GetField(name(1), BindingFlags.Instance Or BindingFlags.NonPublic)
        End If

        Return objFieldInfo

    End Function

    Private Function GetStringValue(ByVal value As Object, ByVal converter As TypeConverter) As String

        If value Is Nothing Then
            Return STRING_NULL
        End If

        'Use the type converter to get the string representation just like a property grid would.
        If converter IsNot Nothing Then

            Try
                Return converter.ConvertToString(value)

            Catch ex As Exception
            End Try

        End If

        Return value.ToString

    End Function

    Private Function PrepareEditInfo(ByRef target As Object, ByVal objTransferDataRequest As TransferDataRequest, ByRef converter As TypeConverter, ByRef propertyDescriptor As PropertyDescriptor, ByRef fieldInfo As FieldInfo, ByRef memberType As Type, ByVal outgoingData As System.IO.Stream) As Boolean

        If objTransferDataRequest.LastDrillingOperationId <> 0 Then

            If Not _dictDrillingOperations.TryGetValue(objTransferDataRequest.LastDrillingOperationId, target) Then

                Dim exception As Exception = New ArgumentOutOfRangeException(String.Format("EditValue received an invalid LastDrillingOperationId of {0}.", objTransferDataRequest.LastDrillingOperationId))
                MoleVisualizerObjectSource.Serialize(outgoingData, exception)
                Return False
            End If

        End If

        propertyDescriptor = TypeDescriptor.GetProperties(target)(objTransferDataRequest.PropertyNameToDrill)

        If propertyDescriptor IsNot Nothing Then
            converter = propertyDescriptor.Converter
            memberType = propertyDescriptor.PropertyType

        Else
            'try to get a field
            fieldInfo = GetFieldInfo(target, objTransferDataRequest.PropertyNameToDrill)
            converter = TypeDescriptor.GetConverter(fieldInfo.FieldType)
            memberType = fieldInfo.FieldType
        End If

        Return True

    End Function

    Private Sub ProcessCommonTreeTransferDataRequest(Of T)(ByVal objDict As Dictionary(Of Integer, T), ByVal target As Object, ByVal objTransferDataRequest As TransferDataRequest, ByRef outgoingData As System.IO.Stream)

        'this normally gets called when records are being read from the cache 
        'this is the entire request 
        If objTransferDataRequest.TransferDataRequestType = TransferDataRequestType.ClearDrillingOperation Then
            ClearDrillingOperation()
            Exit Sub
        End If

        'this is part of the request 
        If objTransferDataRequest.ClearDrillingOperation Then
            ClearDrillingOperation()
        End If

        Dim objElement As T = Nothing

        If Not objDict.TryGetValue(objTransferDataRequest.OriginalSelectedElementId, objElement) Then
            Throw New ArgumentOutOfRangeException("ProcessCommonTreeTransferDataRequest received an invalid TreeElement Id.")
        End If

        Select Case objTransferDataRequest.TransferDataRequestType

            Case TransferDataRequestType.GetDataSet
                MoleVisualizerObjectSource.Serialize(outgoingData, GetDataSetFromIEnumerable(objTransferDataRequest))

            Case TransferDataRequestType.BlackOpsDrillingOperation
                MoleVisualizerObjectSource.Serialize(outgoingData, GetBlackOpsDrillingOperationProperties(objTransferDataRequest, objElement))

            Case TransferDataRequestType.DrillingOperation
                MoleVisualizerObjectSource.Serialize(outgoingData, GetDrillingOperationProperties(objTransferDataRequest, objElement))

            Case TransferDataRequestType.Image
                Using objBitMap As System.Drawing.Bitmap = VisualSnapshot.TakeSnapshot(objElement)
                    MoleVisualizerObjectSource.Serialize(outgoingData, objBitMap)
                End Using

            Case TransferDataRequestType.Properties
                MoleVisualizerObjectSource.Serialize(outgoingData, GetTreeElementProperties(objElement, objTransferDataRequest.MaxRowsInCollectionData))

            Case TransferDataRequestType.XAML
                LoadXAML(objElement, outgoingData)

            Case TransferDataRequestType.EditValue
                ProcessEditValue(objElement, objTransferDataRequest, outgoingData)

            Case TransferDataRequestType.GetEditInfo
                GetEditInfo(objElement, objTransferDataRequest, outgoingData)

            Case Else
                Throw New ArgumentOutOfRangeException("DataTransferRequestType", objTransferDataRequest.TransferDataRequestType, "Received DataTransferRequestType that has not yet been programmed.")
        End Select

    End Sub

    Private Sub ProcessEditValue(ByVal target As Object, ByVal objTransferDataRequest As TransferDataRequest, ByRef outgoingData As System.IO.Stream)

        'find the property
        Dim objNewValue As Object = Nothing
        Dim propertyDescriptor As PropertyDescriptor = Nothing
        Dim fieldInfo As FieldInfo = Nothing
        Dim converter As TypeConverter = Nothing
        Dim memberType As Type = Nothing

        If Not PrepareEditInfo(target, objTransferDataRequest, converter, propertyDescriptor, fieldInfo, memberType, outgoingData) Then
            Return
        End If

        Try

            'reset
            If objTransferDataRequest.NewValue = GlobalConstants.STRING_RESET_PROPERTY_MARKER Then

                If propertyDescriptor IsNot Nothing Then

                    propertyDescriptor.ResetValue(target)
                    objNewValue = propertyDescriptor.GetValue(target)

                Else
                    objNewValue = fieldInfo.GetValue(target)
                End If

            Else 'or property change

                'try to coerce the value if its not already of the required type
                If objTransferDataRequest.NewValue IsNot Nothing AndAlso Not memberType.IsAssignableFrom(objTransferDataRequest.NewValue.GetType()) Then
                    objNewValue = converter.ConvertFromString(objTransferDataRequest.NewValue)

                Else
                    objNewValue = objTransferDataRequest.NewValue
                End If

                If propertyDescriptor IsNot Nothing Then

                    propertyDescriptor.SetValue(target, objNewValue)

                Else
                    fieldInfo.SetValue(target, objNewValue, _
                                       BindingFlags.SetField Or BindingFlags.Instance Or BindingFlags.NonPublic, _
                                       Nothing, Nothing)
                End If

            End If

        Catch ex As Exception
            MoleVisualizerObjectSource.Serialize(outgoingData, ex)
            Return
        End Try

        'serialize back a value
        Dim strNewValue As String = GetStringValue(objNewValue, converter)
        Dim strNewValueSource As String = String.Empty
        Dim canReset As Boolean = False
        Dim isDrillable As Boolean = False

        If propertyDescriptor IsNot Nothing Then
            canReset = propertyDescriptor.CanResetValue(target)

            Try
                isDrillable = IsDrillableTest(propertyDescriptor, target, objNewValue)

            Catch ex As Exception
            End Try

            Dim objDependencyPropertyDescriptor As DependencyPropertyDescriptor = DependencyPropertyDescriptor.FromProperty(propertyDescriptor)

            If objDependencyPropertyDescriptor IsNot Nothing Then
                strNewValueSource = DependencyPropertyHelper.GetValueSource(CType(target, DependencyObject), objDependencyPropertyDescriptor.DependencyProperty).BaseValueSource.ToString
            End If

        Else
            isDrillable = IsDrillableTest(fieldInfo.FieldType, objNewValue)
        End If

        MoleVisualizerObjectSource.Serialize(outgoingData, New EditOperationResponse(strNewValue, strNewValueSource, canReset, isDrillable))

    End Sub

    Private Sub ProcessLogicalTreeTransferDataRequest(ByVal target As Object, ByVal objTransferDataRequest As TransferDataRequest, ByRef outgoingData As System.IO.Stream)

        If objTransferDataRequest.TransferDataRequestType = TransferDataRequestType.LoadLogicalTree Then

            If objTransferDataRequest.ClearDrillingOperation Then
                ClearDrillingOperation()
            End If

            MoleVisualizerObjectSource.Serialize(outgoingData, BuildLogicalTree(objTransferDataRequest))
            Exit Sub
        End If

        Me.ProcessCommonTreeTransferDataRequest(_dictObjectTree, target, objTransferDataRequest, outgoingData)

    End Sub

    Private Sub ProcessVisualTreeTransferDataRequest(ByVal target As Object, ByVal objTransferDataRequest As TransferDataRequest, ByRef outgoingData As System.IO.Stream)

        If objTransferDataRequest.TransferDataRequestType = TransferDataRequestType.InitialLoadVisualTree Then
            MoleVisualizerObjectSource.Serialize(outgoingData, BuildVisualTree(target))
            Exit Sub

        ElseIf objTransferDataRequest.TransferDataRequestType = TransferDataRequestType.InitialLoadClass Then
            MoleVisualizerObjectSource.Serialize(outgoingData, BuildClassTree(target))
            Exit Sub

        ElseIf objTransferDataRequest.TransferDataRequestType = TransferDataRequestType.InitialLoadWinForms Then
            MoleVisualizerObjectSource.Serialize(outgoingData, BuildWinFormsTree(target))
            Exit Sub

        ElseIf objTransferDataRequest.TransferDataRequestType = TransferDataRequestType.InitialLoadASPNET Then
            MoleVisualizerObjectSource.Serialize(outgoingData, BuildASPNETTree(target))
            Exit Sub
        End If

        Select Case _enumMoleMode

            Case MoleMode.WPF
                Me.ProcessCommonTreeTransferDataRequest(_dictVisualTree, target, objTransferDataRequest, outgoingData)

            Case Else
                Me.ProcessCommonTreeTransferDataRequest(_dictObjectTree, target, objTransferDataRequest, outgoingData)
        End Select

    End Sub

#End Region

#Region "XAML Writter "

    Private Sub LoadXAML(ByVal target As Object, ByRef outgoingData As System.IO.Stream)

        'this code is problematic.  it normally works fine but does have issues.
        'when the user requests the run-time XAML a number of exceptions can be thrown by System.Windows.Markup.XamlWriter.Save
        '  Generic Type Serialization
        '  Stack Overflow
        '  More I don't know about yet.
        Dim objDependencyObject As DependencyObject = TryCast(target, DependencyObject)

        If objDependencyObject Is Nothing Then

            Dim strNoXMLAvailable As String = "<?xml version=|1.0|?><NoXAMLAvailable></NoXAMLAvailable>".Replace("|", Chr(34))
            outgoingData.Write(System.Text.Encoding.ASCII.GetBytes(strNoXMLAvailable), 0, strNoXMLAvailable.Length)
            Exit Sub
        End If

        Try

            Dim objXMLWriterSettings As New System.Xml.XmlWriterSettings
            'this ensures that our stream has xml document header.
            objXMLWriterSettings.OmitXmlDeclaration = False
            Using objXMLWritter As Xml.XmlWriter = Xml.XmlWriter.Create(outgoingData, objXMLWriterSettings)
                'This sub can blow up when requesting the XAML HTML.  
                'This is because System.Windows.Markup.XamlWriter.Save gets into a condition that causes a stack overflow.  
                'Maybe this function will be fixed in 3.5
                System.Windows.Markup.XamlWriter.Save(objDependencyObject, objXMLWritter)
                objXMLWritter.Close()
            End Using

        Catch ex As Exception
            'nothing we can do so just let it go
            '
            'If a StackOverFlow has happened, we won't get here any way
            '
            'If Generic Type Serialization has happend, just ignore it and use what fragment that will be returned.
            '
        End Try

    End Sub

#End Region

#Region " Logical Tree Data Builder "

    Private Function BuildLogicalElement(ByVal objCurrent As Object, ByVal objInitial As DependencyObject, ByRef intInitialId As Integer) As TreeElement
        _intLogicalElementIdCounter += 1
        _dictObjectTree.Add(_intLogicalElementIdCounter, objCurrent)

        Dim strObjectName As String = String.Empty

        If TypeOf objCurrent Is DependencyObject Then

            Dim objCurrentDepObj As DependencyObject = DirectCast(objCurrent, DependencyObject)
            strObjectName = CType(objCurrentDepObj.GetValue(FrameworkElement.NameProperty), String)
        End If

        Dim treeElem As New TreeElement(_intLogicalElementIdCounter, New List(Of TreeElement), strObjectName, objCurrent.GetType().FullName)

        If Object.ReferenceEquals(objInitial, objCurrent) Then
            intInitialId = _intLogicalElementIdCounter
        End If

        If TypeOf objCurrent Is DependencyObject Then

            For Each logicalChild As Object In LogicalTreeHelper.GetChildren(DirectCast(objCurrent, DependencyObject))
                treeElem.Children.Add(BuildLogicalElement(logicalChild, objInitial, intInitialId))
            Next

        End If

        Return treeElem

    End Function

    Private Function BuildLogicalTree(ByVal objTransferDataRequest As TransferDataRequest) As Tree
        _dictObjectTree = New Dictionary(Of Integer, Object)

        Dim objTree As New Tree
        objTree.LoadingErrorMessage = String.Empty

        Dim objOriginalElement As DependencyObject = Nothing

        If Not _dictVisualTree.TryGetValue(objTransferDataRequest.OriginalSelectedElementId, objOriginalElement) Then
            Throw New ArgumentOutOfRangeException("LogicalTree TransferData received an invalid TreeElement.Id.")
        End If

        Dim objClosestLogicalAncestor As DependencyObject = GetClosestLogicalAncestor(objOriginalElement)
        Dim intInitialLogicalId As Integer
        objTree.RootElement = BuildLogicalElement(GetLogicalTreeRoot(objClosestLogicalAncestor), objClosestLogicalAncestor, intInitialLogicalId)
        objTree.InitialElementId = intInitialLogicalId
        ' Create the extra logical tree info bundle and give it to the Tree instance.
        objTree.LogicalTreeInfo = New LogicalTreeInfo(objOriginalElement, objClosestLogicalAncestor, GetTemplatedParent(objClosestLogicalAncestor))

        'this causes the Descendant Counts to populate
        Dim intX As Integer = objTree.RootElement.DescendantCount
        Return objTree

    End Function

    Private Function GetClosestLogicalAncestor(ByVal initial As DependencyObject) As DependencyObject

        Dim current As DependencyObject = initial
        Dim result As DependencyObject = initial

        While current IsNot Nothing

            Dim logicalParent As DependencyObject = LogicalTreeHelper.GetParent(current)

            If logicalParent IsNot Nothing Then
                result = current
                Exit While
            End If

            If TypeOf current Is Visual Or TypeOf current Is Visual3D Then
                current = VisualTreeHelper.GetParent(current)

            Else
                current = Nothing
            End If

        End While

        Return result

    End Function

    Private Function GetLogicalTreeRoot(ByVal initial As DependencyObject) As DependencyObject

        Dim current As DependencyObject = initial
        Dim result As DependencyObject = initial

        While current IsNot Nothing
            result = current
            current = LogicalTreeHelper.GetParent(current)
        End While

        Return result

    End Function

    Private Function GetTemplatedParent(ByVal depObj As DependencyObject) As DependencyObject

        Dim result As DependencyObject

        If TypeOf depObj Is FrameworkElement Then
            result = DirectCast(depObj, FrameworkElement).TemplatedParent

        ElseIf TypeOf depObj Is FrameworkContentElement Then
            result = DirectCast(depObj, FrameworkContentElement).TemplatedParent

        Else
            result = Nothing
        End If

        Return result

    End Function

#End Region

#Region " Visual Tree Data Builders "

    Private Function BuildASPNETElement(ByVal root As System.Web.UI.Control, ByVal objFirstControl As System.Web.UI.Control, ByRef intInitialElementId As Integer) As TreeElement
        'this is the value used to uniquely identify each element
        'allows both sides debugger and debuggie to refer to the same
        'control across process boundaries
        _intVisualElementIdCounter += 1
        'save control for future calls to TransferData
        _dictObjectTree.Add(_intVisualElementIdCounter, root)

        Dim strControlName As String = String.Empty

        If Not String.IsNullOrEmpty(root.ID) Then
            strControlName = root.ID
        End If

        Dim obj As New TreeElement(_intVisualElementIdCounter, New List(Of TreeElement), strControlName, root.GetType.FullName)

        If root.Equals(objFirstControl) Then
            intInitialElementId = _intVisualElementIdCounter
        End If

        For Each child As System.Web.UI.Control In root.Controls
            obj.Children.Add(BuildASPNETElement(child, objFirstControl, intInitialElementId))
        Next

        Return obj

    End Function

    Private Function BuildASPNETTree(ByVal target As Object) As Tree
        _dictObjectTree = New Dictionary(Of Integer, Object)

        Dim objTree As New Tree
        objTree.LoadingErrorMessage = String.Empty

        Dim ctrl As System.Web.UI.Control = TryCast(target, System.Web.UI.Control)

        If ctrl Is Nothing Then
            'this should not happen, but...
            objTree.LoadingErrorMessage = "Objected selected in debugger is not a web ui control object."
            Return objTree
        End If

        Dim intInitialElementId As Integer
        objTree.RootElement = BuildASPNETElement(ctrl.Page, ctrl, intInitialElementId)
        objTree.InitialElementId = intInitialElementId

        'this causes the Descendant Counts to populate
        'I'm running this here because we are on the background thread, instead of making the UI thread do it later
        Dim intX As Integer = objTree.RootElement.DescendantCount
        Return objTree

    End Function

    Private Function BuildClassTree(ByVal target As Object) As Tree
        _dictObjectTree = New Dictionary(Of Integer, Object)
        _intVisualElementIdCounter += 1
        _dictObjectTree.Add(_intVisualElementIdCounter, target)

        Dim objTree As New Tree
        objTree.InitialElementId = 1
        objTree.LoadingErrorMessage = String.Empty
        objTree.RootElement = New TreeElement(_intVisualElementIdCounter, New List(Of TreeElement), String.Empty, target.GetType.Name)
        Return objTree

    End Function

    Private Function BuildElement(ByVal root As DependencyObject, ByVal objFirstVisual As DependencyObject, ByRef intInitialElementId As Integer) As TreeElement
        'this is the value used to uniquely identify each element
        'allows both sides debugger and debuggie to refer to the same
        'object across process boundaries
        _intVisualElementIdCounter += 1
        'save dependency property for future calls to TransferData
        _dictVisualTree.Add(_intVisualElementIdCounter, root)

        'root.GetValue(FrameworkElement.
        Dim obj As New TreeElement(_intVisualElementIdCounter, New List(Of TreeElement), CType(root.GetValue(FrameworkElement.NameProperty), String), root.DependencyObjectType.SystemType.FullName)

        If root.Equals(objFirstVisual) Then
            intInitialElementId = _intVisualElementIdCounter
        End If

        'only visual and visual3d's have visual children
        If TypeOf root Is Visual OrElse TypeOf root Is Visual3D Then

            Dim intCountOfChildren As Integer = VisualTreeHelper.GetChildrenCount(root) - 1

            If intCountOfChildren > -1 Then

                For intX As Integer = 0 To intCountOfChildren
                    obj.Children.Add(BuildElement(VisualTreeHelper.GetChild(root, intX), objFirstVisual, intInitialElementId))
                Next

            End If

        End If

        Return obj

    End Function

    Private Function BuildVisualTree(ByVal target As Object) As Tree
        _dictVisualTree = New Dictionary(Of Integer, DependencyObject)

        Dim objTree As New Tree
        objTree.LoadingErrorMessage = String.Empty

        Dim obj As DependencyObject = TryCast(target, DependencyObject)

        If obj Is Nothing Then
            'this should not happen, but...
            objTree.LoadingErrorMessage = "Objected selected in debugger is not a dependency object."
            Return objTree
        End If

        Dim objFirstVisual As DependencyObject = TryGetFirstVisual(obj)
        Dim intInitialElementId As Integer
        objTree.RootElement = BuildElement(GetTreeRoot(objFirstVisual), objFirstVisual, intInitialElementId)
        objTree.InitialElementId = intInitialElementId

        'this causes the Descendant Counts to populate
        'I'm running this here because we are on the background thread, instead of making the UI thread do it later
        Dim intX As Integer = objTree.RootElement.DescendantCount
        Return objTree

    End Function

    Private Function BuildWinFormsElement(ByVal root As System.Windows.Forms.Control, ByVal objFirstControl As System.Windows.Forms.Control, ByRef intInitialElementId As Integer) As TreeElement
        'this is the value used to uniquely identify each element
        'allows both sides debugger and debuggie to refer to the same
        'control across process boundaries
        _intVisualElementIdCounter += 1
        'save control for future calls to TransferData
        _dictObjectTree.Add(_intVisualElementIdCounter, root)

        Dim obj As New TreeElement(_intVisualElementIdCounter, New List(Of TreeElement), root.Name, root.GetType.FullName)

        If root.Equals(objFirstControl) Then
            intInitialElementId = _intVisualElementIdCounter
        End If

        For Each child As System.Windows.Forms.Control In root.Controls
            obj.Children.Add(BuildWinFormsElement(child, objFirstControl, intInitialElementId))
        Next

        Return obj

    End Function

    Private Function BuildWinFormsTree(ByVal target As Object) As Tree
        _dictObjectTree = New Dictionary(Of Integer, Object)

        Dim objTree As New Tree
        objTree.LoadingErrorMessage = String.Empty

        Dim ctrl As System.Windows.Forms.Control = TryCast(target, System.Windows.Forms.Control)

        If ctrl Is Nothing Then
            'this should not happen, but...
            objTree.LoadingErrorMessage = "Objected selected in debugger is not a windows forms control object."
            Return objTree
        End If

        Dim intInitialElementId As Integer
        objTree.RootElement = BuildWinFormsElement(ctrl.TopLevelControl, ctrl, intInitialElementId)
        objTree.InitialElementId = intInitialElementId

        'this causes the Descendant Counts to populate
        'I'm running this here because we are on the background thread, instead of making the UI thread do it later
        Dim intX As Integer = objTree.RootElement.DescendantCount
        Return objTree

    End Function

    Private Function CanConvertFromString(ByVal converter As TypeConverter) As Boolean
        'note, we're not going to use the CanConvertFromString method because it will give
        'false negatives and we'll end up filtering out things that can be parsed
        Return converter IsNot Nothing And converter.GetType() IsNot GetType(TypeConverter)

    End Function

    Private Function GetColumns(ByVal obj As Object) As List(Of String)

        Dim objList As New List(Of String)

        If TypeOf obj Is System.Collections.DictionaryEntry Then
            objList.Add("Key")
            objList.Add("Value")

        ElseIf obj.GetType.IsValueType Or TypeOf obj Is String Then
            objList.Add("Value")

        Else

            For Each mi As MemberInfo In obj.GetType.GetMembers(BindingFlags.Public Or BindingFlags.Instance)

                If mi.MemberType = MemberTypes.Property Then
                    objList.Add(mi.Name)
                End If

            Next

            objList.Sort()
        End If

        Return objList

    End Function

    Private Function GetDataSetFromIEnumerable(ByVal objTransferDataRequest As TransferDataRequest) As DataSet

        Dim objObject As Object = Nothing
        Dim ds As New DataSet
        Dim intX As Integer
        Dim strActiveTableName As String = String.Empty

        If objTransferDataRequest.LastDrillingOperationId = 0 Then
            Throw New ArgumentOutOfRangeException("LastDrillingOperationId", 0, "LastDrillingOperationId can't be zero.")
        End If

        If Not _dictDrillingOperations.TryGetValue(objTransferDataRequest.LastDrillingOperationId, objObject) Then
            Throw New ArgumentOutOfRangeException("LastDrillingOperationId", 0, "LastDrillingOperationId was invalid and not in the dictionary.")
        End If

        If TypeOf objObject Is IDictionary Then
            Return GetDataSetFromIDictionary(objTransferDataRequest)
        End If

        ds.RemotingFormat = SerializationFormat.Binary

        Try

            Dim objType As Type = Nothing

            For Each objItem As Object In CType(objObject, IEnumerable)

                If objType Is Nothing OrElse String.Compare(objItem.GetType.Name, strActiveTableName, StringComparison.Ordinal) <> 0 Then

                    If strActiveTableName.Length > 0 Then
                        ds.Tables(strActiveTableName).AcceptChanges()
                    End If

                    objType = objItem.GetType
                    strActiveTableName = objType.Name

                    If Not ds.Tables.Contains(strActiveTableName) Then

                        Dim dt As New DataTable(strActiveTableName)
                        dt.RemotingFormat = SerializationFormat.Binary

                        For Each s As String In GetColumns(objItem)
                            dt.Columns.Add(s)
                        Next

                        If dt.Columns.Count = 0 Then
                            objType = Nothing
                            Continue For
                        End If

                        ds.Tables.Add(dt)
                    End If

                End If

                Dim dr As DataRow = ds.Tables(strActiveTableName).NewRow

                If TypeOf objItem Is System.Collections.DictionaryEntry Then
                    dr.Item(0) = DirectCast(objItem, System.Collections.DictionaryEntry).Key.ToString
                    dr.Item(1) = DirectCast(objItem, System.Collections.DictionaryEntry).Value.ToString

                ElseIf objItem.GetType.IsValueType OrElse TypeOf objItem Is String Then
                    dr.Item(0) = objItem.ToString

                Else

                    For Each c As DataColumn In ds.Tables(strActiveTableName).Columns

                        Dim propInfo As PropertyInfo = objItem.GetType.GetProperty(c.ColumnName)

                        If propInfo IsNot Nothing Then

                            Dim value As Object = propInfo.GetValue(objItem, Nothing)
                            'Pass the type converter
                            dr.Item(c.ColumnName) = GetStringValue(value, TypeDescriptor.GetConverter(propInfo.PropertyType))
                        End If

                    Next

                End If

                ds.Tables(strActiveTableName).Rows.Add(dr)
                intX += 1

                If intX > objTransferDataRequest.MaxRowsInCollectionData Then
                    Exit For
                End If

            Next

        Catch ex As Exception
            'during debugging you can place a breakpoint here to stop and troubleshoot
            'Debug.WriteLine(ex.ToString)
        End Try

        If ds.Tables(strActiveTableName) IsNot Nothing Then
            ds.Tables(strActiveTableName).AcceptChanges()
        End If
        ds.AcceptChanges()
        Return ds

    End Function

    Private Function GetDataSetFromIDictionary(ByVal objTransferDataRequest As TransferDataRequest) As DataSet

        Dim objObject As Object = Nothing
        Dim ds As New DataSet
        Dim intX As Integer
        Dim strActiveTableName As String = String.Empty

        If objTransferDataRequest.LastDrillingOperationId = 0 Then
            Throw New ArgumentOutOfRangeException("LastDrillingOperationId", 0, "LastDrillingOperationId can't be zero.")
        End If

        If Not _dictDrillingOperations.TryGetValue(objTransferDataRequest.LastDrillingOperationId, objObject) Then
            Throw New ArgumentOutOfRangeException("LastDrillingOperationId", 0, "LastDrillingOperationId was invalid and not in the dictionary.")
        End If

        ds.RemotingFormat = SerializationFormat.Binary

        Try

            Dim objType As Type = Nothing

            For Each objItem As Object In CType(objObject, IDictionary)

                If objType Is Nothing OrElse String.Compare(objItem.GetType.Name, strActiveTableName, StringComparison.Ordinal) <> 0 Then

                    If strActiveTableName.Length > 0 Then
                        ds.Tables(strActiveTableName).AcceptChanges()
                    End If

                    objType = objItem.GetType
                    strActiveTableName = objType.Name

                    If Not ds.Tables.Contains(strActiveTableName) Then

                        Dim dt As New DataTable(strActiveTableName)
                        dt.RemotingFormat = SerializationFormat.Binary

                        For Each s As String In GetColumns(objItem)
                            dt.Columns.Add(s)
                        Next

                        If dt.Columns.Count = 0 Then
                            objType = Nothing
                            Continue For
                        End If

                        ds.Tables.Add(dt)
                    End If

                End If

                Dim dr As DataRow = ds.Tables(strActiveTableName).NewRow

                If TypeOf objItem Is System.Collections.DictionaryEntry Then
                    dr.Item(0) = DirectCast(objItem, System.Collections.DictionaryEntry).Key.ToString
                    dr.Item(1) = DirectCast(objItem, System.Collections.DictionaryEntry).Value.ToString

                ElseIf objItem.GetType.IsValueType OrElse TypeOf objItem Is String Then
                    dr.Item(0) = objItem.ToString

                Else

                    For Each c As DataColumn In ds.Tables(strActiveTableName).Columns

                        Dim propInfo As PropertyInfo = objItem.GetType.GetProperty(c.ColumnName)

                        If propInfo IsNot Nothing Then

                            Dim value As Object = propInfo.GetValue(objItem, Nothing)
                            'Pass the type converter
                            dr.Item(c.ColumnName) = GetStringValue(value, TypeDescriptor.GetConverter(propInfo.PropertyType))
                        End If

                    Next

                End If

                ds.Tables(strActiveTableName).Rows.Add(dr)
                intX += 1

                If intX > objTransferDataRequest.MaxRowsInCollectionData Then
                    Exit For
                End If

            Next

        Catch ex As Exception
            'during debugging you can place a breakpoint here to stop and troubleshoot
            'Debug.WriteLine(ex.ToString)
        End Try

        If ds.Tables(strActiveTableName) IsNot Nothing Then
            ds.Tables(strActiveTableName).AcceptChanges()
        End If
        ds.AcceptChanges()
        Return ds

    End Function

    Private Function GetTreeElementProperties(ByVal target As Object, ByVal intMaxRowsInCollection As Integer) As List(Of TreeElementProperty)

        Dim objList As New List(Of TreeElementProperty)
        Dim isTargetEditable As Boolean = True

        'some times cannot be edited - value types (e.g. structs), frozen objects, strings, etc.
        If TypeOf target Is Freezable AndAlso DirectCast(target, Freezable).IsFrozen Then
            isTargetEditable = False

        ElseIf target.GetType().IsValueType Then
            isTargetEditable = False

        ElseIf TypeOf target Is String Then
            isTargetEditable = False

        Else

            'see if it has an IsSealed boolean read-only property
            Dim pd As PropertyDescriptor = TypeDescriptor.GetProperties(target)("IsSealed")

            If pd IsNot Nothing AndAlso pd.IsReadOnly AndAlso pd.PropertyType Is GetType(Boolean) Then

                If True.Equals(pd.GetValue(target)) Then
                    isTargetEditable = False
                End If

            End If

        End If

        If TypeOf target Is IDictionary Then

            Dim intIndex As Integer
            Const STRING_DATA_CATEGORY As String = "Data"

            For Each item As Object In CType(target, IDictionary)

                'Pass the type converter
                Dim strValue As String = GetStringValue(item, Nothing)
                Dim bolIsDrillable As Boolean = False
                Dim strValueType As String = STRING_NULL
                Dim strValueFullTypeName As String = STRING_NULL

                If Not item Is Nothing Then
                    strValueType = GetTypeName(item.GetType) ' item.GetType().Name
                    strValueFullTypeName = GetFullTypeName(item.GetType)
                    bolIsDrillable = IsDrillableTest(item.GetType(), item)
                End If

                objList.Add(New TreeElementProperty(False, bolIsDrillable, STRING_DATA_CATEGORY, String.Format("{0}{1}{2}", STRING_LEFT_COLLECTION_INDEX_MARKER, intIndex.ToString.PadLeft(3, "0"c), STRING_RIGHT_COLLECTION_INDEX_MARKER), strValueType, strValueFullTypeName, strValue, String.Empty, False, False))
                intIndex += 1

                '
                ' this limits the number of rows of data that is returned
                If intIndex > intMaxRowsInCollection Then
                    Exit For
                End If

            Next item

        ElseIf TypeOf target Is ICollection Then

            Dim intIndex As Integer
            Const STRING_DATA_CATEGORY As String = "Data"

            For Each item As Object In CType(target, ICollection)

                'Pass the type converter
                Dim strValue As String = GetStringValue(item, Nothing)
                Dim bolIsDrillable As Boolean = False
                Dim strValueType As String = STRING_NULL
                Dim strValueFullTypeName As String = STRING_NULL

                If Not item Is Nothing Then
                    strValueType = GetTypeName(item.GetType) ' item.GetType().Name
                    strValueFullTypeName = GetFullTypeName(item.GetType)
                    bolIsDrillable = IsDrillableTest(item.GetType(), item)
                End If

                objList.Add(New TreeElementProperty(False, bolIsDrillable, STRING_DATA_CATEGORY, String.Format("{0}{1}{2}", STRING_LEFT_COLLECTION_INDEX_MARKER, intIndex.ToString.PadLeft(3, "0"c), STRING_RIGHT_COLLECTION_INDEX_MARKER), strValueType, strValueFullTypeName, strValue, String.Empty, False, False))
                intIndex += 1

                '
                ' this limits the number of rows of data that is returned
                If intIndex > intMaxRowsInCollection Then
                    Exit For
                End If

            Next item

        End If

        For Each objPropertyDescriptor As PropertyDescriptor In TypeDescriptor.GetProperties(target)

            Dim bolIsDepencencyProperty As Boolean = False

            'note the default value is set to null
            Dim strValue As String = STRING_NULL
            Dim strValueSource As String = String.Empty
            Dim bolIsDrillable As Boolean = False
            Dim objDependencyPropertyDescriptor As DependencyPropertyDescriptor = DependencyPropertyDescriptor.FromProperty(objPropertyDescriptor)

            If objDependencyPropertyDescriptor IsNot Nothing Then
                bolIsDepencencyProperty = True
                strValueSource = DependencyPropertyHelper.GetValueSource(CType(target, DependencyObject), objDependencyPropertyDescriptor.DependencyProperty).BaseValueSource.ToString

                Dim objValue As Object = objDependencyPropertyDescriptor.GetValue(target)
                'Pass the type converter
                strValue = GetStringValue(objValue, objDependencyPropertyDescriptor.Converter)

                If objValue IsNot Nothing Then
                    bolIsDrillable = IsDrillableTest(objPropertyDescriptor, target, objValue)
                End If

                If objDependencyPropertyDescriptor.IsAttached AndAlso Not _dictAttachedProperties.ContainsKey(objDependencyPropertyDescriptor.Name) Then
                    _dictAttachedProperties.Add(objDependencyPropertyDescriptor.Name, objDependencyPropertyDescriptor)
                End If

            Else

                Try

                    Dim objValue As Object = objPropertyDescriptor.GetValue(target)
                    'Pass the type converter
                    strValue = GetStringValue(objValue, objPropertyDescriptor.Converter)

                    If objValue IsNot Nothing Then
                        bolIsDrillable = IsDrillableTest(objPropertyDescriptor, target, objValue)
                    End If

                Catch ex As Exception
                    'just ignoring the exception
                End Try

            End If

            Dim isEditable As Boolean = isTargetEditable AndAlso Not objPropertyDescriptor.IsReadOnly AndAlso IsEditableProperty(objPropertyDescriptor)
            Dim canReset As Boolean = isEditable AndAlso objPropertyDescriptor.CanResetValue(target)
            objList.Add(New TreeElementProperty(bolIsDepencencyProperty, bolIsDrillable, objPropertyDescriptor.Category, objPropertyDescriptor.Name, GetTypeName(objPropertyDescriptor.PropertyType), GetFullTypeName(objPropertyDescriptor.PropertyType), strValue, strValueSource, isEditable, canReset))
        Next

        'Walk up the base type so we get the private fields from all the base classes
        '
        Dim targetType As Type = target.GetType

        While targetType IsNot Nothing

            For Each obj As System.Reflection.FieldInfo In targetType.GetFields(BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.DeclaredOnly)

                Dim bolIsDepencencyProperty As Boolean = False

                'note the default value is set to null
                Dim strValue As String = STRING_NULL
                Dim strValueSource As String = String.Empty
                Dim bolIsDrillable As Boolean = False

                Try

                    Dim objValue As Object = obj.GetValue(target)

                    If objValue IsNot Nothing Then
                        strValue = GetStringValue(objValue, TypeDescriptor.GetConverter(obj.FieldType))
                        bolIsDrillable = IsDrillableTest(obj.ReflectedType, objValue)
                    End If

                Catch ex As Exception
                    'just ignoring the exception
                End Try

                'Prepend the typename so we can find the appropriate type and so the user can discern
                'where the field is coming from. This would also allow favorites to work with fields.
                '
                Dim isEditable As Boolean = isTargetEditable AndAlso IsEditableProperty(obj)
                objList.Add(New TreeElementProperty(bolIsDepencencyProperty, bolIsDrillable, String.Format(STRING_BLACK_OPS_INDICATOR_FORMAT, obj.Attributes.ToString), String.Format("{0}.{1}", targetType.Name, obj.Name), GetTypeName(obj.FieldType), GetFullTypeName(obj.FieldType), strValue, strValueSource, isEditable, False))
            Next

            targetType = targetType.BaseType
        End While

        Return objList

    End Function

    Private Function GetTreeRoot(ByVal target As DependencyObject) As DependencyObject

        Dim current As DependencyObject = target
        Dim result As DependencyObject = Nothing

        While current IsNot Nothing
            result = current

            If TypeOf current Is Visual OrElse TypeOf current Is Visual3D Then
                current = VisualTreeHelper.GetParent(current)

            Else
                current = LogicalTreeHelper.GetParent(current)
            End If

        End While

        Return result

    End Function

    Private Shared Function GetTypeName(ByVal objType As Type) As String

        Dim underlyingType As Type = Nullable.GetUnderlyingType(objType)

        If underlyingType Is Nothing Then
            Return objType.Name
        End If

        Return String.Format("Nullable<{0}>", underlyingType.Name)

    End Function

    Private Shared Function GetFullTypeName(ByVal objType As Type) As String

        Dim underlyingType As Type = Nullable.GetUnderlyingType(objType)

        If underlyingType Is Nothing Then
            Return objType.FullName
        End If

        Return String.Format("Nullable<{0}>", underlyingType.FullName)

    End Function

    Private Function IsDrillableTest(ByVal objPropertyDescriptor As PropertyDescriptor, ByVal objSource As Object, ByVal objValue As Object) As Boolean

        If Object.ReferenceEquals(objValue, objSource) Then
            Return False
        End If

        If TypeOf objValue Is GeneralTransform AndAlso objPropertyDescriptor.Name = "Inverse" Then
            Return False
        End If

        'note i'm using GetType here since the object returned as the value for a property
        'could be a derived type
        Return IsDrillableTest(objValue.GetType(), objValue)

    End Function

    Private Function IsDrillableTest(ByVal propertyType As Type, ByVal objValue As Object) As Boolean

        'perform the most likely and quickest tests first
        If propertyType.IsPrimitive OrElse propertyType.IsEnum Then
            Return False

        ElseIf TypeOf objValue Is Decimal Then
            Return False

        ElseIf TypeDescriptor.GetProperties(objValue).Count = 0 Then
            Return False
        End If

        Return True

    End Function

    Private Function IsEditableProperty(ByVal propertyDescriptor As PropertyDescriptor) As Boolean

        If Not IsEditableProperty(propertyDescriptor.PropertyType) Then
            Return False
        End If

        If propertyDescriptor.PropertyType IsNot GetType(Object) AndAlso Not CanConvertFromString(propertyDescriptor.Converter) Then
            Return False
        End If

        Return True

    End Function

    Private Function IsEditableProperty(ByVal field As FieldInfo) As Boolean

        If Not IsEditableProperty(field.FieldType) Then
            Return False
        End If

        If field.FieldType IsNot GetType(Object) AndAlso Not CanConvertFromString(TypeDescriptor.GetConverter(field.FieldType)) Then
            Return False
        End If

        Return True

    End Function

    Private Function IsEditableProperty(ByVal propertyType As Type) As Boolean

        'Do not allow editing of arrays
        'we do not support editing arrays
        If propertyType.IsArray Then Return False

        If propertyType.IsEnum AndAlso propertyType.GetCustomAttributes(GetType(FlagsAttribute), True).Length > 0 Then
            Return False
        End If

        'static array of types that are considered uneditable
        'in theory, this list could be very long
        Static InvalidTypes() As Type = New Type() {GetType(System.Windows.Forms.Form), GetType(TextEffectCollection), GetType(TextDecorationCollection), GetType(ResourceDictionary), GetType(Geometry), GetType(Transform), GetType(System.Windows.Input.InputScope), GetType(System.Drawing.Image)}

        For Each type As Type In InvalidTypes

            If type.IsAssignableFrom(propertyType) Then
                Return False
            End If

        Next

        Return True

    End Function

    Private Function IsPropertyACollection(ByVal target As Object) As Boolean

        'all .Net strings are IEnumerable so bypass them
        If TypeOf target Is System.String Then
            Return False
        End If

        'this works with Generic and Non Generic types.
        Try

            'The test was broken into two tests.  First try for an IDictionary object.
            'this is here because the System.Collections.Hashtable.SyncHashtable will work when treated like a IDictionary object but
            '  fails when treated like an IEnumerable because the thing is actually not thread safe.
            'http://www.styledesign.biz/weblogs/macinnesm/archive/2004/09/21/196.aspx

            'I know this looks strange but I couldn't find a better way to do this.
            'if the data is not IEnumerable, well...
            Dim objDictionary As IDictionary = TryCast(target, IDictionary)

            If objDictionary IsNot Nothing Then

                'need to get at least one item from the collection
                Dim objEnum As IEnumerator = objDictionary.GetEnumerator
                objEnum.Reset()

                While objEnum.MoveNext

                    'NOTE : This loop only runs once just to verify that the collection has atleast one item
                    '
                    'OK, we have items, now, do our items actually have properties we can query?
                    'You have to check for this.  Example, the Rectangle.StrokeDashArray is a collection with no properties, just double structures
                    'this is the insurance policy.
                    'there are some IEnumerable objects that do not have any properties, only methods.
                    'our simple system just shows properties and values in a table
                    'so spend the time now so the user won't see an icon and then get an empty table.
                    For Each objItem As Object In objDictionary

                        'we are actually using the above objEnumerable object
                        'wanted to wait until I was sure there were items before conducting this test.
                        If objItem IsNot Nothing AndAlso (objItem.GetType.IsValueType OrElse TypeDescriptor.GetProperties(objItem).Count > 0) Then
                            'cool, we are IEnumerable, we have items, our items have properties to query
                            Return True

                        Else
                            Exit For
                        End If

                    Next

                    Exit While
                End While

            Else
                'Not an IDictionary object but may be an IEnumerable object.

                'I know this looks strange but I couldn't find a better way to do this.
                'if the data is not IEnumerable, well...
                Dim objEnumerable As IEnumerable = TryCast(target, IEnumerable)

                If objEnumerable IsNot Nothing Then

                    'need to get at least one item from the collection
                    Dim objEnum As IEnumerator = objEnumerable.GetEnumerator
                    objEnum.Reset()

                    While objEnum.MoveNext

                        'NOTE : This loop only runs once just to verify that the collection has atleast one item
                        '
                        'OK, we have items, now, do our items actually have properties we can query?
                        'You have to check for this.  Example, the Rectangle.StrokeDashArray is a collection with no properties, just double structures
                        'this is the insurance policy.
                        'there are some IEnumerable objects that do not have any properties, only methods.
                        'our simple system just shows properties and values in a table
                        'so spend the time now so the user won't see an icon and then get an empty table.
                        For Each objItem As Object In objEnumerable

                            'we are actually using the above objEnumerable object
                            'wanted to wait until I was sure there were items before conducting this test.
                            If objItem IsNot Nothing AndAlso (objItem.GetType.IsValueType OrElse TypeDescriptor.GetProperties(objItem).Count > 0) Then
                                'cool, we are IEnumerable, we have items, our items have properties to query
                                Return True

                            Else
                                Exit For
                            End If

                        Next

                        Exit While
                    End While

                End If

            End If

        Finally
            'Catch ex As Exception
            'during debugging you can place a breakpoint here to stop and troubleshoot
            'Debug.WriteLine(ex.ToString)
        End Try

        Return False

    End Function

    Private Function TryGetFirstVisual(ByVal target As DependencyObject) As DependencyObject

        If TypeOf target Is Visual OrElse TypeOf target Is Visual3D Then
            Return target
        End If

        Dim current As DependencyObject = target
        Dim result As DependencyObject = Nothing

        While current IsNot Nothing
            result = current

            If TypeOf current Is Visual OrElse TypeOf current Is Visual3D Then
                Return current

            Else
                current = LogicalTreeHelper.GetParent(current)
            End If

        End While

        Return result

    End Function

#End Region

#Region " Helpers "

    ''' <summary>
    ''' Uses binary formatter to deserialize the incoming data
    ''' </summary>
    Public Overloads Shared Function Deserialize(ByVal incomingData As System.IO.Stream) As Object
        Return _objBinaryFormatter.Deserialize(incomingData)

    End Function

    ''' <summary>
    ''' Uses binary formatter to serialize the serializationStream data
    ''' </summary>
    Public Overloads Shared Sub Serialize(ByVal serializationStream As System.IO.Stream, ByVal target As Object)
        _objBinaryFormatter.Serialize(serializationStream, target)

    End Sub

    ''' <summary>
    ''' This function makes debugging a Visualizer a snap.  
    ''' 1.  The project used to start this Visualizer will need to reference Microsoft.VisualStudio.DebuggerVisualizers (VS2005 use version 8) (VS2008 use version 9)
    ''' 2.  The project used to start this Visualizer will need a reference to this project.  Ensure that you set Copy Local to True.
    ''' 3.  Set desired breakpoints inside your Visualizer
    ''' 4.  Call this method from another project
    ''' 5.  Please see the following post if you have difficulties during debugging:
    '''     http://karlshifflett.wordpress.com/2007/12/01/systeminvalidcastexception-unable-to-cast-object-of-type-x-to-type-x/
    ''' </summary>
    Public Shared Sub TestMoleVisualizer(ByVal obj As Object)

        '
        'TODO DEVELOPERS YOU SHOULD REMOVE THIS ENTIRE METHOD FROM ANY PRODUCTION VISUALIZER
        '
        Dim vdh As VisualizerDevelopmentHost = New VisualizerDevelopmentHost(obj, GetType(Mole.Burrow), GetType(Mole.MoleVisualizerObjectSource))
        vdh.ShowVisualizer()

    End Sub

#End Region

End Class
