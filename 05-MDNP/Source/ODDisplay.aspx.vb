
Public Class ODDisplay
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents rotateR As System.Web.UI.WebControls.Panel
    Protected WithEvents rotateL As System.Web.UI.WebControls.Panel
    Protected WithEvents hihHeight As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents tvDOImages As Microsoft.Web.UI.WebControls.TreeView
    Protected WithEvents lblColor As System.Web.UI.WebControls.Label
    Protected WithEvents lblResolution As System.Web.UI.WebControls.Label
    Protected WithEvents lblDepth As System.Web.UI.WebControls.Label
    Protected WithEvents lblWidth As System.Web.UI.WebControls.Label
    Protected WithEvents lblHeight As System.Web.UI.WebControls.Label
    Protected WithEvents lblSize As System.Web.UI.WebControls.Label
    Protected WithEvents hihUrl As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents imgDO As System.Web.UI.WebControls.Image
    Protected WithEvents hidNodeID As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents pnlMetadata As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlRotation As System.Web.UI.WebControls.Panel
    Protected WithEvents ibtPrevious As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ibtNext As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Hidden2 As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents imgPrevious As System.Web.UI.WebControls.ImageButton
    Protected WithEvents imgCurrent As System.Web.UI.WebControls.Image
    Protected WithEvents imgNext As System.Web.UI.WebControls.ImageButton
    Protected WithEvents rotateRight As System.Web.UI.WebControls.ImageButton
    Protected WithEvents rotateLeft As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lblBitDepth As System.Web.UI.WebControls.Label

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    '*************************************************************************************
    ' Subroutine: Page_Load 
    ' Purpose: Loads the Metadata page, that shows the image and its metadata. This page could 
    '   be in html extension but we are in the ASP.NET world. 
    '   This page is build by frames, it was an ADPRT option (choice).
    '*************************************************************************************
    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Protected index As String

    Private Enum Move
        MovePrevious
        MoveNext
        None
    End Enum

    Public Enum ImageType
        Derivative
        Thumb
    End Enum


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If Not IsPostBack Then
        Dim DOId As String = Me.Request.QueryString("DOId")
        Dim NodeID As String = Me.Request.QueryString("NodeID")

        Dim url As String = Me.Request.Url.ToString

        LoadTree(DOId)

        If NodeID Is Nothing Then
            Dim DigitalObject As New DigitalObject
            NodeID = "_" & CStr(DigitalObject.GetFirstImage(DOId))
        End If
        Dim hash As Hashtable = findNodeIndex(Me.tvDOImages.Nodes, NodeID)
        SelectTreeNode(hash, NodeID)
        LoadImages(DOId, hash)
        'End If
    End Sub

    Private Sub LoadImages(ByVal DOId As Int64, ByVal hash As Hashtable)
        Dim indexPrevious, indexCurrent, indexNext As String

        If Me.Request.QueryString("move") = "previous" Then
            indexPrevious = hash("previous")
            hash = findNodeIndex(Me.tvDOImages.Nodes, Me.tvDOImages.GetNodeFromIndex(indexPrevious).ID)
        ElseIf Me.Request.QueryString("move") = "next" Then
            indexNext = hash("next")
            hash = findNodeIndex(Me.tvDOImages.Nodes, Me.tvDOImages.GetNodeFromIndex(indexNext).ID)
        End If

        indexPrevious = hash("previous")
        indexCurrent = hash("current")
        indexNext = hash("next")

        If Me.tvDOImages.GetNodeFromIndex(indexCurrent).Type.Trim = "image" Then
            loadMetadata(DOId, Me.tvDOImages.GetNodeFromIndex(indexCurrent).ID)
            imgDO.ImageUrl = loadImage(DOId, Me.tvDOImages.GetNodeFromIndex(indexCurrent).ID, 0, True)
            Me.imgCurrent.Visible = True
            imgCurrent.Width = New Unit(100)
            imgCurrent.ImageUrl = loadImage(DOId, Me.tvDOImages.GetNodeFromIndex(indexCurrent).ID, 1, True)
        End If
        If Not indexPrevious Is Nothing Then
            Me.ibtPrevious.Visible = True
            If Me.tvDOImages.GetNodeFromIndex(indexPrevious).Type.Trim = "image" Then
                Me.imgPrevious.Visible = True
                Me.imgPrevious.ImageUrl = loadImage(DOId, Me.tvDOImages.GetNodeFromIndex(indexPrevious).ID, 1)
                Me.imgPrevious.Width = New Unit(100)
            End If
        End If
        If Not indexNext Is Nothing Then
            Me.ibtNext.Visible = True
            If Me.tvDOImages.GetNodeFromIndex(indexNext).Type.Trim = "image" Then
                Me.imgNext.Visible = True
                Me.imgNext.ImageUrl = loadImage(DOId, Me.tvDOImages.GetNodeFromIndex(indexNext).ID, 1)
                Me.imgNext.Width = New Unit(100)
            End If
        End If
    End Sub

    Private Sub LoadTree(ByVal DOId As Int64)

        Dim xmlStructure As New System.Xml.XmlDocument
        Dim objDO As New DigitalObject(DOId)

        Dim strStructure As String = "<?xml version=""1.0"" encoding=""ISO-8859-1"" ?>" & _
                                     objDO.DOStructure

        xmlStructure.LoadXml(strStructure)
        Me.tvDOImages.TreeNodeSrc = xmlStructure.OuterXml
        Me.tvDOImages.DataBind()

        formatTree(Me.tvDOImages.Nodes, 0)

        Dim index As String

        'set styles
        Me.tvDOImages.DefaultStyle = Microsoft.Web.UI.WebControls.CssCollection.FromString("font-family:arial;color:#555555;font-size:11px;")
        Me.tvDOImages.HoverStyle = Microsoft.Web.UI.WebControls.CssCollection.FromString("text-decoration:underline;background-color=#ffffff;color:#555555")
        Me.tvDOImages.SelectedStyle = Microsoft.Web.UI.WebControls.CssCollection.FromString("color:#ff0000;background-color=#ffffff;font-weight:bold;")
    End Sub

    Private Sub SelectTreeNode(ByVal hash As Hashtable, ByVal NodeID As String)
        'Dim index As String

        If Me.Request.QueryString("move") = "previous" Then
            index = hash("previous")
        ElseIf Me.Request.QueryString("move") = "next" Then
            index = hash("next")
        ElseIf Not NodeID Is Nothing Then
            index = hash("current")
        Else
            hash = findNodeIndex(Me.tvDOImages.Nodes, Me.tvDOImages.Nodes(0).ID)
            index = Me.tvDOImages.Nodes(0).GetNodeIndex
        End If

        'expande todos os nós parent do nó referenciado
        Dim obj As Object = Split(index, ".")
        Dim i As Integer
        For i = 0 To UBound(obj)
            If i > 0 Then obj(i) = obj(i - 1) + "." + obj(i)
            Me.tvDOImages.GetNodeFromIndex(obj(i)).Expanded = True
            Me.tvDOImages.ToolTip = Me.tvDOImages.GetNodeFromIndex(obj(i)).Text
        Next
        'selecciona o nó referenciado em DefaultNode
        Me.tvDOImages.SelectedNodeIndex = index

    End Sub

    Private Sub loadMetadata(ByVal DOId As String, ByVal FileID As String)
        Me.pnlMetadata.Visible = True
        Dim DOimage As New DOImage(DOId, FileID.TrimStart("_"), DOimage.Capacities.Description)
        lblColor.Text = DOimage.ColorSpace
        lblResolution.Text = DOimage.Resolution
        lblBitDepth.Text = DOimage.BitDepth
        lblWidth.Text = DOimage.ImageWidth
        lblHeight.Text = DOimage.ImageHeight
        lblSize.Text = DOimage.ImageSize + " KB"
        hihHeight.Value = DOimage.ImageHeight
    End Sub

    Private Function loadImage(ByVal DOId As String, ByVal FileID As String, ByVal ImageType As Integer, Optional ByVal rotate As Boolean = False) As String
        Me.imgDO.Visible = True
        Dim strImageUrl As String
        If rotate Then
            strImageUrl = String.Format("./ShowFile.aspx?DOId={0}&FileId={1}&imageType={2}&rotate={3}", DOId, FileID.TrimStart("_"), ImageType, Me.Request.QueryString("rotate"))
        Else
            strImageUrl = String.Format("./ShowFile.aspx?DOId={0}&FileId={1}&imageType={2}", DOId, FileID.TrimStart("_"), ImageType)
        End If
        Return strImageUrl
    End Function

    Private _defaultnode As String

    Public Property DefaultNode() As String
        Get
            Return Me._defaultnode
        End Get
        Set(ByVal Value As String)
            Me._defaultnode = Value
        End Set
    End Property

    Private Function findNodeIndex(ByRef TreeNodeCollection As Microsoft.Web.UI.WebControls.TreeNodeCollection, ByVal id As String, Optional ByVal hash As Hashtable = Nothing) As Hashtable
        Dim i As System.Collections.IEnumerator = TreeNodeCollection.GetEnumerator
        Dim CurNode, NextNode As Microsoft.Web.UI.WebControls.TreeNode
        'enquanto existem nós no presente nível da árvore passa ao nó seguinte
        If hash Is Nothing Then
            hash = New Hashtable
            hash("previous") = Nothing
            hash("current") = Nothing
            hash("next") = Nothing
        End If
        While i.MoveNext
            CurNode = i.Current

            'se o nó corrente tem o 'ID' que procuramos entao o indice que queremos é o indice do nó corrente 
            'Me.hidNodeID.Value = CurNode.ID
            hash("previous") = hash("current")
            hash("current") = CurNode.GetNodeIndex
            If CurNode.ID = id Then
                If CurNode.Nodes.Count > 0 Then
                    NextNode = CurNode.Nodes.Item(0)
                    hash("next") = NextNode.GetNodeIndex
                ElseIf i.MoveNext Then
                    NextNode = i.Current
                    hash("next") = NextNode.GetNodeIndex
                End If
                Return hash
            End If
            'senão, se o nó corrente tem sub-nós
            If CurNode.Nodes.Count > 0 Then
                'procurar nos sub-nós
                hash = findNodeIndex(CurNode.Nodes, id, hash)
                'se o indice devolvido pela procura nos sub-nós é diferente de 'Nothing' então encntramos o indice que queremos 
                If Not IsNothing(hash) Then Return hash
            End If
        End While
        'se chegamos aqui então o 'ID' não foi encontrado
        Return Nothing
    End Function

    
    Private Sub formatTree(ByRef TreeNodeCollection As Microsoft.Web.UI.WebControls.TreeNodeCollection, ByVal count As Integer)
        Dim i As System.Collections.IEnumerator = TreeNodeCollection.GetEnumerator
        Dim index As String
        Dim previousIndex As String
        Dim CurNode As Microsoft.Web.UI.WebControls.TreeNode
        'enquanto existem nós no presente nível da árvore passa ao nó seguinte
        While i.MoveNext
            CurNode = i.Current
            'se o nó corrente tem o 'ID' que procuramos entao o indice que queremos é o indice do nó corrente 

            If CurNode.Type <> "directory" Then
                CurNode.Text = "<span onmouseover=""showFriendInfo('friend_1','" & loadImage(Me.Request.QueryString("DOId"), CStr(CurNode.ID).TrimStart("_"), 1) & "')"" onmouseout=""hideFriendInfo('friend_1')"" title=""" & CurNode.Text & """>" & CurNode.Text & "</span>"
                CurNode.NavigateUrl = "ODdisplay.aspx?DOId=" & Me.Request.QueryString("DOId") & "&NodeID=" & CurNode.ID
                CurNode.ImageUrl = "Images/image.gif"
            Else
                count += 1
                CurNode.ID = "DirID" & count
                CurNode.NavigateUrl = "ODdisplay.aspx?DOId=" & Me.Request.QueryString("DOId") & "&NodeID=" & CurNode.ID
            End If
            'senão, se o nó corrente tem sub-nós
            If CurNode.Nodes.Count > 0 Then
                'procurar nos sub-nós
                formatTree(CurNode.Nodes, count)
                'se o indice devolvido pela procura nos sub-nós é diferente de 'Nothing' então encntramos o indice que queremos 
            End If
        End While
        'se chegamos aqui então o 'ID' não foi encontrado
    End Sub

    Private Sub ibtPrevious_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtPrevious.Click
        Response.Redirect("ODDisplay.aspx?move=previous&DOId=" & Me.Request.QueryString("DOId") & "&NodeID=" & Me.tvDOImages.GetNodeFromIndex(Me.tvDOImages.SelectedNodeIndex).ID)
    End Sub

    Private Sub ibtNext_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtNext.Click
        Response.Redirect("ODDisplay.aspx?move=next&DOId=" & Me.Request.QueryString("DOId") & "&NodeID=" & Me.tvDOImages.GetNodeFromIndex(Me.tvDOImages.SelectedNodeIndex).ID)
    End Sub

    Private Sub imgPrevious_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgPrevious.Click
        Response.Redirect("ODDisplay.aspx?move=previous&DOId=" & Me.Request.QueryString("DOId") & "&NodeID=" & Me.tvDOImages.GetNodeFromIndex(Me.tvDOImages.SelectedNodeIndex).ID)
    End Sub

    Private Sub imgNext_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgNext.Click
        Response.Redirect("ODDisplay.aspx?move=next&DOId=" & Me.Request.QueryString("DOId") & "&NodeID=" & Me.tvDOImages.GetNodeFromIndex(Me.tvDOImages.SelectedNodeIndex).ID)
    End Sub

    Private Sub rotateRight_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles rotateRight.Click
        Dim rotate As Integer
        If Me.Request.QueryString("rotate") = "" Then
            rotate = 1
        Else
            rotate = Me.Request.QueryString("rotate")
            rotate = rotate + 1
            If rotate > 3 Then
                rotate = 0
            End If
        End If
        Response.Redirect(String.Format("ODDisplay.aspx?DOId={0}&NodeID={1}&rotate={2}", Me.Request.QueryString("DOId"), Me.tvDOImages.GetNodeFromIndex(Me.tvDOImages.SelectedNodeIndex).ID, CStr(rotate)))
    End Sub

    Private Sub rotateLeft_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles rotateLeft.Click
        Dim rotate As Integer
        If Me.Request.QueryString("rotate") = "" Then
            rotate = 3
        Else
            rotate = Me.Request.QueryString("rotate")
            rotate = rotate - 1
            If rotate < 0 Then
                rotate = 3
            End If
        End If
        Response.Redirect(String.Format("ODDisplay.aspx?DOId={0}&NodeID={1}&rotate={2}", Me.Request.QueryString("DOId"), Me.tvDOImages.GetNodeFromIndex(Me.tvDOImages.SelectedNodeIndex).ID, CStr(rotate)))
    End Sub
End Class
