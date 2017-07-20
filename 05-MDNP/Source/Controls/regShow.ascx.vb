Imports System.Data.SqlClient ' SQL Server Data Provider
Imports System.Object
Imports Microsoft.Web.UI.WebControls
Imports System.Configuration

Public Class regShow
    Inherits BaseClassUC


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Protected WithEvents repRecordUnitProprieties As System.Web.UI.WebControls.Repeater
    Protected WithEvents tvRecordParentsAndChildren As Microsoft.Web.UI.WebControls.TreeView
    Protected WithEvents ibtnCarDocs As System.Web.UI.WebControls.ImageButton
    Protected WithEvents hlnkBack As System.Web.UI.WebControls.HyperLink
    Protected WithEvents pnlContents As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlAlert As System.Web.UI.WebControls.Panel
    Protected WithEvents lblAlert As System.Web.UI.WebControls.Label
    Protected WithEvents ibtnAuthorityRecord As System.Web.UI.WebControls.ImageButton


    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private qsID As Integer
    Private mySearchMode As String
    Public intLinkCount As Integer = 0

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        qsID = Me.Request.QueryString("ID")
        mySearchMode = Me.Request.QueryString("searchMode")

        If Not IsPostBack Then

            If Me.Request.QueryString("addDocID") Is Nothing Then
                Try
                    Session("UrlReferrer") = Me.Request.UrlReferrer.ToString
                Catch ex As Exception
                    Session("UrlReferrer") = Me.Request.Url.ToString
                End Try
            End If
            Me.hlnkBack.NavigateUrl = Session("UrlReferrer")

            Me.ibtnAuthorityRecord.AlternateText = GetLabel("WS.regShow.hlnkAuthorityRecord")
            Me.hlnkBack.Text = GetLabel("WS.hlnkBack")

            Dim LazyNode As LazyNode = New SQLLazyNode(CInt(qsID), SQLLazyNode.Capacities.Full)

            If Not LazyNode.Visible Then
                Me.pnlAlert.Visible = True
                Me.pnlContents.Visible = False
                Me.lblAlert.Text = GetLabel("WS.regShow.lblAlert1")
            Else
                Me.pnlAlert.Visible = False
                Me.pnlContents.Visible = True
            End If

            LoadRegister(LazyNode)
            LoadTree(LazyNode)

            'If the register have authoritie register
            If LazyNode.Eac And LazyNode.Visible Then
                Me.ibtnAuthorityRecord.Visible = True
            Else
                Me.ibtnAuthorityRecord.Visible = False
            End If
        End If
    End Sub


    Private Sub LoadRegister(ByVal LazyNode As LazyNode)
        Dim colResults As New Collection ' col from collection
        Dim daoGrpResults As New DaoGrpCollection
        colResults.Add(LazyNode)
        repRecordUnitProprieties.DataSource = colResults
        repRecordUnitProprieties.DataBind()

        For i As Integer = 0 To repRecordUnitProprieties.Items.Count - 1
            Dim objLazyNode As LazyNode = colResults(i + 1)
            daoGrpResults = LazyNode.DaoGrp
            If LazyNode.DigitalObjectExists Then
                Dim repDaoGrp As Repeater = CType(Me.repRecordUnitProprieties.Items(i).FindControl("repDaoGrp"), Repeater)
                repDaoGrp.DataSource = daoGrpResults
                repDaoGrp.DataBind()

                Dim repDigitalObjectLoc As Repeater = CType(Me.repRecordUnitProprieties.Items(i).FindControl("repDigitalObjectLoc"), Repeater)
                repDigitalObjectLoc.DataSource = daoGrpResults
                repDigitalObjectLoc.DataBind()
            End If
        Next
    End Sub


    Private Sub LoadTree(ByVal LazyNode As LazyNode)

        Dim strSelectedNodeIndex As String = Session("strSelectedNodeIndex")
        Dim strUnitID, strUnitTitle, strUnitTitleType, strDate As String
        Dim colParentsToNodeItself As LazyNodeCollection = LazyNode.colParentsToNItself()
        Dim colChildren As LazyNodeCollection = LazyNode.Children()

        Dim objType As New TreeNodeType
        objType = New TreeNodeType
        objType.Type = "Parent"
        tvRecordParentsAndChildren.TreeNodeTypes.Add(objType)
        objType = New TreeNodeType
        objType.Type = "Child"
        tvRecordParentsAndChildren.TreeNodeTypes.Add(objType)

        Dim objTreeNode As TreeNodeCollection
        objTreeNode = tvRecordParentsAndChildren.Nodes
        Dim intFirst As Integer = colParentsToNodeItself.Count - 1
        Dim intLast As Integer = 0
        Dim intCountTreeNode As Integer = 0
        Dim strTreeNodeName As String
        Dim strTreeNodeImageUrl As String
        Dim strTreeNodeNavegationUrlID As String
        Dim boolVisible As String

        While intFirst >= intLast
            strUnitID = colParentsToNodeItself.Item(intFirst).UnitId
            strUnitTitleType = colParentsToNodeItself.Item(intFirst).UnitTitleType
            strUnitTitle = colParentsToNodeItself.Item(intFirst).UnitTitle

            strTreeNodeName = strWriteTreeNodeName(strUnitID, strUnitTitle, strUnitTitleType)
            strTreeNodeImageUrl = strGetImgPth(colParentsToNodeItself.Item(intFirst).OtherLevel)
            strTreeNodeNavegationUrlID = colParentsToNodeItself.Item(intFirst).ID
            objTreeNode.Add(tvnNodeOdd(strTreeNodeName, "Parent", strTreeNodeImageUrl, strTreeNodeNavegationUrlID))
            objTreeNode = objTreeNode(0).Nodes
            intFirst = intFirst - 1
            intCountTreeNode += 1
        End While

        Dim intIndex As Integer = 0
        For intIndex = 0 To colChildren.Count - 1
            strUnitID = colChildren.Item(intIndex).UnitId
            strUnitTitle = colChildren.Item(intIndex).UnitTitle
            strUnitTitleType = colChildren.Item(intIndex).UnitTitleType
            strDate = strWriteDate(colChildren.Item(intIndex).UnitDateInitialCertainty, colChildren.Item(intIndex).UnitDateInitial, colChildren.Item(intIndex).UnitDateFinalCertainty, colChildren.Item(intIndex).UnitDateFinal)

            strTreeNodeName = strWriteTreeNodeName(strUnitID, strUnitTitle, strUnitTitleType, strDate)
            strTreeNodeImageUrl = strGetImgPth(colChildren.Item(intIndex).OtherLevel)
            strTreeNodeNavegationUrlID = colChildren.Item(intIndex).ID
            boolVisible = colChildren.Item(intIndex).Visible

            If (intIndex Mod 2) = 0 Then
                'Even
                objTreeNode.Add(tvnNodeEven(strTreeNodeName, "Child", strTreeNodeImageUrl, strTreeNodeNavegationUrlID, boolVisible))
            Else
                'odd
                objTreeNode.Add(tvnNodeOdd(strTreeNodeName, "Child", strTreeNodeImageUrl, strTreeNodeNavegationUrlID, boolVisible))
            End If
        Next

        Dim intNodeIndex As Integer

        strSelectedNodeIndex = ""
        For intNodeIndex = 1 To intCountTreeNode - 1
            strSelectedNodeIndex &= "0."
            If intNodeIndex = intCountTreeNode - 1 Then
                strSelectedNodeIndex &= "0"
            End If
        Next
        Dim CssStyle As New CssCollection("TEXT-DECORATION: none; font-size:xx-small;font-family:Verdana, Arial, Helvetica, sans-serif; ")


        tvRecordParentsAndChildren.DefaultStyle = CssStyle

        tvRecordParentsAndChildren.SelectedNodeIndex = strSelectedNodeIndex

        tvRecordParentsAndChildren.ShowPlus = False

        Session("sSelectedNodeIndex") = strSelectedNodeIndex
    End Sub


    ' Create Tree Node without background-color	
    Private Function tvnNodeOdd(ByVal pName As String, ByVal pType As String, ByVal pImageUrl As String, ByVal pID As String, Optional ByVal visible As Boolean = True) As TreeNode

        Dim n As New TreeNode
        n.Type = pType
        n.ImageUrl = pImageUrl

        n.Text = pName

        n.NavigateUrl = "default.aspx?page=regShow&ID=" & pID & "&searchMode=" & mySearchMode

        'expand node
        n.Expanded = True
        n.DefaultStyle = New CssCollection("font-size:xx-small;font-family:Verdana, Arial, Helvetica, sans-serif;")
        Return n

    End Function

    ' Create Tree Node with background-color
    Private Function tvnNodeEven(ByVal pName As String, ByVal pType As String, ByVal pImageUrl As String, ByVal pID As String, Optional ByVal visible As Boolean = True) As TreeNode

        Dim n As New TreeNode
        n.Type = pType
        n.ImageUrl = pImageUrl

        n.Text = pName

        n.NavigateUrl = "default.aspx?page=regShow&ID=" & pID & "&searchMode=" & mySearchMode

        'expand node
        n.Expanded = True

        n.DefaultStyle = New CssCollection(" background-color: #E7E7E7; font-size:xx-small;font-family:Verdana, Arial, Helvetica, sans-serif;")
        Return n

    End Function

    Private Sub ibtnCarDocs_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnCarDocs.Click
        Dim strUrl As String = Me.Request.Url.ToString
        If Me.Request.QueryString("addDocID") Is Nothing Then
            Me.Response.Redirect(strUrl & "&addDocID=" & qsID)
        End If
    End Sub

    Private Sub ibtnAuthorityRecord_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnAuthorityRecord.Click
        qsID = Me.Request.QueryString("ID")
        mySearchMode = Me.Request.QueryString("searchMode")
        Response.Redirect("./default.aspx?page=authorityRecord&ID=" & qsID & "&searchMode=" & mySearchMode)
    End Sub
End Class
