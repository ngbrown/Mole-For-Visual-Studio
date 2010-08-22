Imports System.Windows.Forms
Imports System.ComponentModel

Public NotInheritable Class MoleCrumbs
    Inherits FlowLayoutPanel

#Region " Declarations "

    Private _bolIsBlackOps As Boolean = False
    Private _fntLabelFont As System.Drawing.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Private _intParentElementTreeDictionaryKeyId As Integer
    Private _intThisElementTreeDictionaryKeyId As Integer
    Private _objMoleTrail As New List(Of MoleCrumb)
    Private components As System.ComponentModel.IContainer
    Private _strFullTypeName As String = String.Empty

#End Region

#Region " Properties "

    Public ReadOnly Property Count() As Integer
        Get
            Return _objMoleTrail.Count
        End Get
    End Property

    Public ReadOnly Property FullTypeName() As String
        Get
            Return _strFullTypeName
        End Get
    End Property

    Public ReadOnly Property IsBlackOps() As Boolean
        Get
            Return _bolIsBlackOps
        End Get
    End Property

    Public ReadOnly Property ParentElementTreeDictionaryKeyId() As Integer
        Get
            Return _intParentElementTreeDictionaryKeyId
        End Get
    End Property

    Public ReadOnly Property ThisElementTreeDictionaryKeyId() As Integer
        Get
            Return _intThisElementTreeDictionaryKeyId
        End Get
    End Property

#End Region

#Region " Events "

    Public Event MoleCrumbClick(ByVal sender As Object, ByVal e As MoleCrumbEventArgs)
    Public Event MoleViewDataClick(ByVal sender As Object, ByVal e As MoleCrumbEventArgs)

#End Region

#Region " Methods "

    Private Sub MoleCrumb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim intIndex As Integer = CType(CType(sender, Label).Tag, Integer)
        Dim objMoleCrumb As MoleCrumb = _objMoleTrail(intIndex)

        For intX As Integer = _objMoleTrail.Count - 1 To intIndex Step -1
            _objMoleTrail.RemoveAt(intX)
        Next

        If _objMoleTrail.Count = 0 Then
            _intParentElementTreeDictionaryKeyId = 0
            _intThisElementTreeDictionaryKeyId = 0
            _strFullTypeName = String.Empty
            _bolIsBlackOps = False

        Else
            _intParentElementTreeDictionaryKeyId = _objMoleTrail(_objMoleTrail.Count - 1).ParentElementTreeDictionaryKeyId
            _intThisElementTreeDictionaryKeyId = _objMoleTrail(_objMoleTrail.Count - 1).ThisElementTreeDictionaryKeyId
            _strFullTypeName = _objMoleTrail(_objMoleTrail.Count - 1).FullTypeName
            _bolIsBlackOps = _objMoleTrail(_objMoleTrail.Count - 1).IsBlackOps
        End If

        Render()
        RaiseEvent MoleCrumbClick(Me, New MoleCrumbEventArgs(objMoleCrumb))

    End Sub

    Private Sub MoleViewData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent MoleViewDataClick(Me, New MoleCrumbEventArgs(Me.ParentElementTreeDictionaryKeyId, Me.ThisElementTreeDictionaryKeyId, _objMoleTrail(_objMoleTrail.Count - 1).Text, "", Me.IsBlackOps))

    End Sub

    Private Sub Render()
        Dim frm As frmMole = CType(Me.TopLevelControl, frmMole)

        Me.SuspendLayout()
        For Each ctrl As Control In Me.Controls
            frm.ttMoleTips.SetToolTip(ctrl, String.Empty)
        Next
        Me.Controls.Clear()

        If _objMoleTrail.Count > 0 Then

            Dim btn As New Button
            btn.Name = "btnViewMoleData"
            btn.Text = "View Data"

            If _objMoleTrail(_objMoleTrail.Count - 1).HasData Then
                btn.ForeColor = Drawing.Color.Blue
                AddHandler btn.Click, AddressOf MoleViewData_Click
                frm.ttMoleTips.SetToolTip(btn, "Click to view data in a DataGrid")
            Else
                btn.Enabled = False
            End If

            Me.Controls.Add(btn)

            For intX As Integer = 0 To _objMoleTrail.Count - 1

                If intX < _objMoleTrail.Count - 1 Then

                    Dim lbl As New LinkLabel
                    lbl.Name = String.Concat("lblMC", intX.ToString)
                    lbl.AutoSize = True
                    lbl.Padding = New Padding(2, 5, 0, 5)
                    lbl.Tag = intX
                    frm.ttMoleTips.SetToolTip(lbl, _objMoleTrail(intX).FullTypeName)


                    If intX = 0 Then
                        lbl.Text = _objMoleTrail(intX).Text

                    Else
                        lbl.Text = String.Concat(" > ", _objMoleTrail(intX).Text)
                    End If

                    AddHandler lbl.Click, AddressOf MoleCrumb_Click
                    Me.Controls.Add(lbl)

                Else

                    'this is the last item and can also be the first item with only one MoleCrumb, it is a label
                    Dim lbl As New Label
                    lbl.Name = String.Concat("lblMC", intX.ToString)
                    lbl.AutoSize = True
                    lbl.Padding = New Padding(2, 5, 0, 5)
                    lbl.Tag = intX
                    frm.ttMoleTips.SetToolTip(lbl, _objMoleTrail(intX).FullTypeName)

                    If intX = 0 Then
                        lbl.Text = _objMoleTrail(intX).Text

                    Else
                        lbl.Text = String.Concat(" > ", _objMoleTrail(intX).Text)
                    End If

                    lbl.Font = _fntLabelFont
                    Me.Controls.Add(lbl)
                End If

            Next

            Me.Margin = New Padding(8)

        Else
            Me.Margin = New Padding(0)
        End If

        Me.ResumeLayout()

    End Sub

    Public Sub Add(ByVal objNewCrumb As MoleCrumb)
        _objMoleTrail.Add(objNewCrumb)
        _intParentElementTreeDictionaryKeyId = objNewCrumb.ParentElementTreeDictionaryKeyId
        _intThisElementTreeDictionaryKeyId = objNewCrumb.ThisElementTreeDictionaryKeyId
        _strFullTypeName = objNewCrumb.FullTypeName
        _bolIsBlackOps = objNewCrumb.IsBlackOps
        Render()

    End Sub

    ''' <summary>
    ''' Pass in the name of the object type that was clicked on in either the VisualTree or LogicalTree TreeView controls
    ''' </summary>
    Public Sub Clear(ByVal strRootObjectTypeName As String, ByVal strRootObjectFullTypeName As String, ByVal strSearchText As String, ByVal bolIsBlackOps As Boolean)

        Dim strSaveSearchText As String = String.Empty

        If _objMoleTrail IsNot Nothing AndAlso _objMoleTrail.Count > 0 AndAlso _objMoleTrail(0).SearchText.Length > 0 Then
            strSaveSearchText = _objMoleTrail(0).SearchText
        End If

        _objMoleTrail.Clear()
        _intParentElementTreeDictionaryKeyId = 0
        _intThisElementTreeDictionaryKeyId = 0
        _strFullTypeName = strRootObjectFullTypeName
        _bolIsBlackOps = bolIsBlackOps
        '
        'do not set the two Id's, they must be zero's!
        _objMoleTrail.Add(New MoleCrumb(False, 0, 0, strRootObjectTypeName, strRootObjectFullTypeName, strSaveSearchText, bolIsBlackOps))
        Render()

    End Sub

    Public Sub SetSearchTextForActiveMoleCrumb(ByVal strSearchText As String)
        _objMoleTrail(_objMoleTrail.Count - 1).SearchText = strSearchText

    End Sub

#End Region

End Class
