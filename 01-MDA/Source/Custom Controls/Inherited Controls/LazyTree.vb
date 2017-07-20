
#Region "License Agreement"

'* DigitArq
'* Copyright 2007-2015 
'* Arquivo Distrital do Porto
'* Todos os direitos reservados.
'*  
'* Este software foi desenvolvido pelo Arquivo
'* Distrital do Porto (http://www.adporto.pt)
'* em articulação com a Direcção-Geral de Arquivos
'* (http://www.dgarq.gov.pt) e com a coordenação
'* informática da Universidade do Minho
'* (http://www.uminho.pt).
'* O desenvolvimento deste produto foi parcialmente
'* financiado pelo Programa Operacional para a 
'* Cultura (POC) promovido pelo Governo Português.
'* ---------------------------------------------------
'*
'* A redistribuição e utilização deste produto sob a
'* forma de código-fonte ou programa compilado, com ou
'* sem modificações, é permitida desde que o seguinte
'* conjunto de condições seja cumprido:
'* 
'*	* Todas as redistribuições do código-fonte 
'*	  deste produto deverão ser acompanhadas do
'*	  texto que compõe esta licença, incluindo o 
'*	  texto inicial de atribuição de autoria,
'*	  esta lista de condições e do seguinte termo
'*	  de responsabilidade.
'*
'*	* Os nomes da Direcção-Geral de Arquivos,
'*	  do Arquivo Distrital do Porto, da 
'*	  Universidade do Minho e das pessoas 
'*	  individuais que colaboraram no desenvolvimento 
'*	  deste produto não deverão ser utilizados na 
'*	  promoção de produtos derivados deste 
'*	  sem que seja obtido consentimento prévio, por
'*	  escrito, por parte dos visados.

'*	* A utilização da designação DigitArq, seus 
'*	  logótipos e nomes institucionais associados
'*	  é apenas permitida em distribuições que sejam
'*	  cópias exactas da versão oficial deste produto
'*	  aprovada e/ou distribuída pela Direcção-Geral 
'*	  de Arquivos.

'*	* O desenvolvimento de obras derivadas deste
'*	  produto é permitido desde que a designação 
'*	  DigitArq, seus logotipos e parceiros 
'*	  institucionais não sejam utilizados em todo e
'*	  qualquer tipo de distribuição e/ou promoção 
'*	  da obra derivada.
'* 
'* ESTE SOFTWARE É DISTRIBUIDO PELA DIRECÇÃO-GERAL DE
'* ARQUIVOS "NO ESTADO EM QUE SE ENCONTRA" SEM QUALQUER
'* PRESUNÇÃO DE QUALIDADE OU GARANTIA ASSOCIADAS, 
'* INCLUINDO, MAS NÃO LIMITADO A, GARANTIAS ASSOCIADAS
'* A COMÉRCIO DE PRODUTOS OU DECLARAÇÃO DE ADEQUABILIDADE
'* A DETERMINADO FIM OU OBJECTIVO. 

'* EM NENHUMA CIRCUNSTÂNCIA PODERÁ A DIRECÇÃO-GERAL DE 
'* ARQUIVOS SER CONSIDERADA RESPONSÁVEL POR QUAISQUER 
'* DANOS QUE RESULTEM DA UTILIZAÇÃO DIRECTA, INDIRECTA,
'* ACIDENTAL, ESPECIAL OU DEMONSTRATIVA DESTE PRODUTO 
'* (INCLUINDO, MAS NÃO LIMITADO A, PERDAS DE DADOS, 
'* LUCROS, FALÊNCIA, INDEVIDA PRESTAÇÃO DE SERVIÇOS
'* OU NEGLIGÊNCIA), AINDA QUE O LICENCIANTE TENHA SIDO 
'* AVISADO DA POSSIBILIDADE DA OCORRÊNCIA DE TAIS DANOS.
'*
'* ---------------------------------------------------
'* Para mais informação sobre este produto ou a sua 
'* licença, é favor consultar o endereço electrónico
'* http://www.digitarq.pt

#End Region

Imports System.Threading
Imports System.Configuration


Public Class LazyTree
    Inherits TreeViewMultiSelection        'Inherits TreeView


#Region " Component Designer generated code "

    Public Sub New()
        MyBase.New()

        ' This call is required by the Component Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        SetupToolTip()
        SetupContextMenu()
        'CheckBoxes = True

    End Sub

    'Control overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Control Designer
    Private components As System.ComponentModel.IContainer

    ' NOTE: The following procedure is required by the Component Designer
    ' It can be modified using the Component Designer.  Do not modify it
    ' using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

#End Region


#Region "Properties"
    Private Const DummyNodeText As String = "__#DUMMY#__"
    Private ToolTip As New System.Windows.Forms.ToolTip
    Private OldNodeIndex As Integer = -1
    'Private CopiedTreeNode As TreeNode = Nothing
    Private CopiedTreeNodes As New ArrayList
    Public EditOperation As EditOperations = EditOperations.Copy
    Private LastSelectedNode As TreeNode = Nothing
    Private myProcessInfoName As String

    Public Enum EditOperations
        Cut
        Copy
    End Enum



    Private WithEvents menuItemRemoveNode As MenuItem
    Private WithEvents menuItemAppendChild As MenuItem
    Private WithEvents menuItemAppendSubFonds As MenuItem
    Private WithEvents menuItemAppendSection As MenuItem
    Private WithEvents menuItemAppendSubSection As MenuItem
    Private WithEvents menuItemAppendSubSubSection As MenuItem
    Private WithEvents menuItemAppendSeries As MenuItem
    Private WithEvents menuItemAppendSubSeries As MenuItem
    Private WithEvents menuItemAppendInstalationUnit As MenuItem
    Private WithEvents menuItemAppendDocument As MenuItem
    Private WithEvents menuItemAppendComposedDocument As MenuItem
    Private WithEvents menuItemCut As MenuItem
    Private WithEvents menuItemCopy As MenuItem
    Private WithEvents menuItemPaste As MenuItem

    Private WithEvents menuItemVisibility As MenuItem
    Private WithEvents menuItemMakeVisible As MenuItem
    Private WithEvents menuItemMakeInvisible As MenuItem

    Private WithEvents menuItemValidation As MenuItem
    Private WithEvents menuItemMakeValid As MenuItem
    Private WithEvents menuItemMakeInvalid As MenuItem

    Private WithEvents menuItemAvailability As MenuItem
    Private WithEvents menuItemMakeAvailable As MenuItem
    Private WithEvents menuItemMakeUnavailable As MenuItem

    Private WithEvents menuItemPromoteToFonds As MenuItem

#End Region


#Region "Initializations"


    Public Sub New(ByVal RootNode As LazyNode)
        Me.New()
        RootLazyNode = Me.RootLazyNode
    End Sub



#End Region


#Region "Some public methods"


    Public Sub RefreshRootNode()
        If Not RootLazyNode Is Nothing Then
            CollapseAll()
            RootLazyNode.Download()
            RootLazyNode = RootLazyNode
            UpdateTreeNode(RootTreeNode)
        End If
    End Sub

    Public Property ProcessInfoName() As String
        Get
            Return myProcessInfoName
        End Get
        Set(ByVal Value As String)
            myProcessInfoName = Value
        End Set
    End Property


    Public Property RootLazyNode() As LazyNode
        Get
            If (Not RootTreeNode Is Nothing) Then Return CType(Nodes(0).Tag, LazyNode) Else Return Nothing
        End Get
        Set(ByVal Value As LazyNode)
            If Not Value Is Nothing Then
                Nodes.Clear()
                AddNode(Nodes, Value)
            End If

        End Set
    End Property


    Public ReadOnly Property RootTreeNode() As TreeNode
        Get
            Try
                Return Nodes.Item(0)
            Catch ex As ArgumentOutOfRangeException
                Return Nothing
            End Try
        End Get
    End Property

    Public Property SelectedLazyNode() As LazyNode
        Get
            If SelectedNode Is Nothing Then Return Nothing Else Return CType(SelectedNode.Tag, LazyNode)
        End Get
        Set(ByVal Value As LazyNode)
            If SelectedNode Is Nothing Then Exit Property
            Dim NodeFound As TreeNode = FindTreeNode(Me.RootTreeNode, Value)
            If Not NodeFound Is Nothing Then
                SelectedNode = NodeFound
            End If
        End Set
    End Property



    Public Shared Function GetLazyNode(ByVal TreeNode As TreeNode) As LazyNode
        Return CType(TreeNode.Tag, LazyNode)
    End Function


    Public Function FindTreeNode(ByVal StartTreeNode As TreeNode, ByVal LazyNode As LazyNode) As TreeNode
        If GetLazyNode(StartTreeNode).ID = LazyNode.ID Then Return StartTreeNode

        'Dim WasExpanded As Boolean = StartTreeNode.IsExpanded
        StartTreeNode.Expand()
        Dim TreeNode As TreeNode
        Dim NodeFound As TreeNode
        For Each TreeNode In StartTreeNode.Nodes
            NodeFound = FindTreeNode(TreeNode, LazyNode)
            If Not NodeFound Is Nothing Then
                Return NodeFound
            End If
        Next
        'If Not WasExpanded Then StartTreeNode.Collapse()
        Return Nothing
    End Function




#End Region


#Region "Auxiliary Methods "



    Private Sub SetupTreeNodeColor(ByVal Node As TreeNode)
        If Node Is Nothing Then Exit Sub
        Dim LazyNode As LazyNode = CType(Node.Tag, LazyNode)


        If LazyNode.Valid Then
            If LazyNode.Visible Then Node.ForeColor = Color.DarkGreen Else Node.ForeColor = Color.DarkRed
        Else
            If LazyNode.Visible Then Node.ForeColor = Color.DarkGreen Else Node.ForeColor = Color.DarkRed
            Node.Text = LazyNode.UnitId & "*"
        End If

    End Sub




    Private Function AddNode(ByRef treeNodes As TreeNodeCollection, ByVal lazyNode As LazyNode) As TreeNode
        Dim newNode As TreeNode
        newNode = New TreeNode(lazyNode.UnitId, lazyNode.OtherLevelIndex, lazyNode.OtherLevelIndex)
        newNode.Tag = lazyNode

        lazyNode.TreeNode = newNode

        SetupTreeNodeColor(newNode)
        If (lazyNode.HasChildren) Then ' nao adiciona filhos para os elementos folha
            newNode.Nodes.Add(DummyNodeText)
        End If
        treeNodes.Add(newNode)
        Return newNode
    End Function



    Private Sub AddNodes(ByRef treeNodes As TreeNodeCollection, ByVal lazyNodes As LazyNodeCollection)
        Dim newNode As TreeNode
        Dim lazyNode As LazyNode
        For Each lazyNode In lazyNodes
            newNode = AddNode(treeNodes, lazyNode)
            newNode.Tag = lazyNode
        Next
    End Sub



    Private Sub RefreshNode(ByVal treeNode As TreeNode)
        treeNode.Nodes.Clear()
        Dim lazyNode As LazyNode = CType(treeNode.Tag, LazyNode)

        lazyNode.Download()
        treeNode.Text = lazyNode.UnitId
        treeNode.ImageIndex = lazyNode.OtherLevelIndex
        treeNode.SelectedImageIndex = lazyNode.OtherLevelIndex
        Me.SetupTreeNodeColor(treeNode)
        If (lazyNode.HasChildren) Then  ' nao adiciona filhos para os elementos folha
            treeNode.Nodes.Add(DummyNodeText)
        End If

    End Sub
#End Region


#Region "Drag and Drop"
    '**********************************************************************
    '* Drag and Drop
    '**********************************************************************
    Public Sub LazyTree_ItemDrag(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles MyBase.ItemDrag

        If Not e.Item Is MyBase.Nodes.Item(0) AndAlso SelectedNodes.Count = 1 Then
            DoDragDrop(e.Item, DragDropEffects.Move)
        End If

    End Sub

    Public Sub LazyTree_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragEnter
        e.Effect = DragDropEffects.Move
    End Sub


    Public Sub LazyTree_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragDrop
        If e.Data.GetDataPresent("System.Windows.Forms.TreeNode", False) Then
            Cursor.Current = Cursors.WaitCursor

            Dim SourceNode As TreeNode = CType(e.Data.GetData("System.Windows.Forms.TreeNode"), TreeNode)
            Dim DestinationNode As TreeNode = GetNodeAt(PointToClient(New Point(e.X, e.Y)))

            Dim DroppedNode As TreeNode
            DroppedNode = DropTreeNode(SourceNode, DestinationNode)
            SelectedNode = DroppedNode
            Cursor.Current = Cursors.Default
        End If

    End Sub


    Private Function DropTreeNode(ByVal SourceNode As TreeNode, ByVal DestinationNode As TreeNode) As TreeNode
        Dim srcTreeNode As TreeNode = SourceNode
        Dim dstTreeNode As TreeNode = DestinationNode
        Dim srcLazyNode As LazyNode = CType(srcTreeNode.Tag, LazyNode)
        Dim dstLazyNode As LazyNode = CType(dstTreeNode.Tag, LazyNode)


        If (dstTreeNode Is srcTreeNode) Then
            MsgBox(InfoMessage("InvalidDropPlace.SelfNode"), MsgBoxStyle.Information)
        ElseIf (dstLazyNode.OtherLevelIndex >= srcLazyNode.OtherLevelIndex) Then
            MsgBox(InfoMessage("InvalidDropPlace.DisrespectsHierarchy"), MsgBoxStyle.Information)
        Else
            ' This code was removed because it was too slow!
            ' We don't need to clone the node in order to move it!
            ' That's jsut dumb!

            'Dim srcParentLazyNode As LazyNode = CType(srcTreeNode.Parent.Tag, LazyNode)
            'Dim clonedSrcLazyNode As LazyNode = srcLazyNode.Clone

            'dstTreeNode.Expand()
            'dstLazyNode.AppendChild(clonedSrcLazyNode)
            'srcParentLazyNode.RemoveChild(srcLazyNode)

            'Dim clonedSrcTreeNode As TreeNode = srcTreeNode.Clone
            'clonedSrcTreeNode.Tag = clonedSrcLazyNode

            'dstTreeNode.Nodes.Add(clonedSrcTreeNode)
            'clonedSrcTreeNode.Nodes.Clear()
            'RefreshNode(clonedSrcTreeNode)
            'Log.Append(myProcessInfoName, Log.LogActions.MoveNode, String.Format("Node {0} was moved to {1}", clonedSrcLazyNode.OtherLevel & " " & clonedSrcLazyNode.UnitId, dstLazyNode.OtherLevel & " " & dstLazyNode.UnitId))

            'srcTreeNode.Remove()
            'Return clonedSrcTreeNode


            Dim srcParentLazyNode As LazyNode = CType(srcTreeNode.Parent.Tag, LazyNode)
            Dim clonedSrcLazyNode As LazyNode = srcLazyNode

            dstTreeNode.Expand()
            dstLazyNode.AppendChild(clonedSrcLazyNode)

            Dim clonedSrcTreeNode As TreeNode = srcTreeNode.Clone
            clonedSrcTreeNode.Tag = clonedSrcLazyNode
            clonedSrcLazyNode.Visible = False
            clonedSrcLazyNode.Valid = False
            clonedSrcLazyNode.Upload()

            dstTreeNode.Nodes.Add(clonedSrcTreeNode)
            clonedSrcTreeNode.Nodes.Clear()
            RefreshNode(clonedSrcTreeNode)
            Log.Append(myProcessInfoName, Log.LogActions.MoveNode, String.Format(LogMessage("Log.MoveNode"), clonedSrcLazyNode.OtherLevel & " " & clonedSrcLazyNode.UnitId, dstLazyNode.OtherLevel & " " & dstLazyNode.UnitId))

            srcTreeNode.Remove()
            Return clonedSrcTreeNode
        End If

    End Function


#End Region


#Region "Toop Tip"

    '**********************************************************************
    '* Node tool tip
    '**********************************************************************
    Private Sub LazyTree_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        Dim tn As TreeNode = GetNodeAt(e.X, e.Y)

        If Not (tn Is Nothing) Then
            Dim currentNodeIndex As Integer = tn.Index
            If currentNodeIndex <> OldNodeIndex Then
                OldNodeIndex = currentNodeIndex
                If Not (ToolTip Is Nothing) And ToolTip.Active Then
                    ToolTip.Active = False 'turn it off 
                End If
                Dim lazyNode As LazyNode = CType(tn.Tag, LazyNode)
                Dim tip As String = lazyNode.UnitTitle
                If tip = "" Then
                    tip = "Sem título"
                End If
                ToolTip.SetToolTip(Me, tip)
                ToolTip.Active = True 'make it active so it can show 
            End If
        End If
    End Sub

    Private Sub LazyTree_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
        If e.Button = MouseButtons.Right Then
            Dim pt As Point = New Point(e.X, e.Y) ' PointToClient(
            Dim node As TreeNode = GetNodeAt(pt)
            If Not node Is Nothing Then
                SelectedNodes = New ArrayList
                SelectedNode = node
                Dim menu As ContextMenu = CreateContextMenu(node)
                menu.Show(Me, New Point(e.X, e.Y))
            End If
        End If
    End Sub




#End Region


#Region "Context Menu"

    Private Sub SetupToolTip()
        ToolTip.InitialDelay = 100
        ToolTip.ReshowDelay = 0
    End Sub


    Private Sub SetupContextMenu()
        menuItemAppendChild = New MenuItem(ContextMenuLabel("menuItemAppendChild"))
        menuItemRemoveNode = New MenuItem(ContextMenuLabel("menuItemRemoveNode"))

        menuItemAppendSubFonds = New MenuItem(ContextMenuLabel("menuItemAppendSubFonds"))

        menuItemAppendSubFonds.Break = True

        menuItemAppendSection = New MenuItem(ContextMenuLabel("menuItemAppendSection"))
        menuItemAppendSubSection = New MenuItem(ContextMenuLabel("menuItemAppendSubSection"))
        menuItemAppendSubSubSection = New MenuItem(ContextMenuLabel("menuItemAppendSubSubSection"))
        menuItemAppendSeries = New MenuItem(ContextMenuLabel("menuItemAppendSeries"))
        menuItemAppendSubSeries = New MenuItem(ContextMenuLabel("menuItemAppendSubSeries"))
        menuItemAppendInstalationUnit = New MenuItem(ContextMenuLabel("menuItemAppendInstalationUnit"))
        menuItemAppendDocument = New MenuItem(ContextMenuLabel("menuItemAppendDocument"))
        menuItemAppendComposedDocument = New MenuItem(ContextMenuLabel("menuItemAppendComposedDocument"))
        menuItemPromoteToFonds = New MenuItem(ContextMenuLabel("menuItemPromoteFonds"))

        menuItemCut = New MenuItem(ContextMenuLabel("menuItemCut"))
        menuItemCopy = New MenuItem(ContextMenuLabel("menuItemCopy"))
        menuItemPaste = New MenuItem(ContextMenuLabel("menuItemPaste"))
        menuItemPaste.Enabled = False
    End Sub

    Private Sub SetupVisibilityContextMenu()

        menuItemVisibility = New MenuItem(ContextMenuLabel("menuItemVisibility"))

        If SelectedLazyNode.Visible Then
            menuItemMakeInvisible = New MenuItem(ContextMenuLabel("menuItemMakeInvisible"))
            menuItemVisibility.MenuItems.Add(menuItemMakeInvisible)
        Else
            menuItemMakeVisible = New MenuItem(ContextMenuLabel("menuItemMakeVisible"))
            menuItemVisibility.MenuItems.Add(menuItemMakeVisible)
        End If
    End Sub


    Private Sub SetupValidationContextMenu()

        menuItemValidation = New MenuItem(ContextMenuLabel("menuItemValidation"))

        If SelectedLazyNode.Valid Then
            menuItemMakeInvalid = New MenuItem(ContextMenuLabel("menuItemMakeInvalid"))
            menuItemValidation.MenuItems.Add(menuItemMakeInvalid)
        Else
            menuItemMakeValid = New MenuItem(ContextMenuLabel("menuItemMakeValid"))
            menuItemValidation.MenuItems.Add(menuItemMakeValid)
        End If
    End Sub


    Private Sub SetupAvailabilityContextMenu()

        Me.menuItemAvailability = New MenuItem(ContextMenuLabel("menuItemAvailability"))

        If SelectedLazyNode.Available Then
            menuItemMakeUnavailable = New MenuItem(ContextMenuLabel("menuItemMakeUnavailable"))
            menuItemAvailability.MenuItems.Add(menuItemMakeUnavailable)
        Else
            menuItemMakeAvailable = New MenuItem(ContextMenuLabel("menuItemMakeAvailable"))
            menuItemAvailability.MenuItems.Add(menuItemMakeAvailable)
        End If
    End Sub


    Private Function CreateContextMenu(ByVal node As TreeNode) As ContextMenu
        Dim menu As New ContextMenu
        Dim NodeLevel = CType(node.Tag, LazyNode).OtherLevelIndex

        If NodeLevel < GetOtherLevelIndex(OTHERLEVEL_DOCUMENT) Then  ' don't show append new node for leaf nodes
            menuItemAppendChild.MenuItems.Clear()
            If NodeLevel <= GetOtherLevelIndex(OTHERLEVEL_FONDS) Then menuItemAppendChild.MenuItems.Add(Me.menuItemAppendSubFonds)
            If NodeLevel <= GetOtherLevelIndex(OTHERLEVEL_SUBFONDS) Then menuItemAppendChild.MenuItems.Add(Me.menuItemAppendSection)
            If NodeLevel <= GetOtherLevelIndex(OTHERLEVEL_SECTION) Then menuItemAppendChild.MenuItems.Add(Me.menuItemAppendSubSection)
            If NodeLevel <= GetOtherLevelIndex(OTHERLEVEL_SUBSECTION) Then menuItemAppendChild.MenuItems.Add(Me.menuItemAppendSubSubSection)
            If NodeLevel <= GetOtherLevelIndex(OTHERLEVEL_SUBSUBSECTION) Then menuItemAppendChild.MenuItems.Add(Me.menuItemAppendSeries)
            If NodeLevel <= GetOtherLevelIndex(OTHERLEVEL_SERIES) Then menuItemAppendChild.MenuItems.Add(Me.menuItemAppendSubSeries)
            If NodeLevel <= GetOtherLevelIndex(OTHERLEVEL_SUBSERIES) Then menuItemAppendChild.MenuItems.Add(Me.menuItemAppendInstalationUnit)
            If NodeLevel <= GetOtherLevelIndex(OTHERLEVEL_INSTALATIONUNIT) Then menuItemAppendChild.MenuItems.Add(Me.menuItemAppendComposedDocument)
            If NodeLevel <= GetOtherLevelIndex(OTHERLEVEL_COMPOSEDDOCUMENT) Then menuItemAppendChild.MenuItems.Add(Me.menuItemAppendDocument)
            menu.MenuItems.Add(menuItemAppendChild)
        End If


        'If NodeLevel <= GetOtherLevelIndex(OTHERLEVEL_DOCUMENT) And NodeLevel >= GetOtherLevelIndex(OTHERLEVEL_FONDS) Then   ' if both append and remove will be shown, add separator
        '    menu.MenuItems.Add(New MenuItem("-"))
        'End If

        'menu.MenuItems.Add(menuItemCut)
        'menu.MenuItems.Add(menuItemCopy)
        'menu.MenuItems.Add(menuItemPaste)

        If NodeLevel > GetOtherLevelIndex(OTHERLEVEL_FONDS) Then ' don't show option for fonds nodes
            If NodeLevel <= GetOtherLevelIndex(OTHERLEVEL_COMPOSEDDOCUMENT) Then menu.MenuItems.Add(New MenuItem("-"))
            menu.MenuItems.Add(menuItemRemoveNode)
        End If

        If ProcessInfoName = "admin" Then
            menu.MenuItems.Add(New MenuItem("-"))
            SetupValidationContextMenu()
            menu.MenuItems.Add(menuItemValidation)
            SetupVisibilityContextMenu()
            menu.MenuItems.Add(menuItemVisibility)
            SetupAvailabilityContextMenu()
            menu.MenuItems.Add(menuItemAvailability)

            'If GetLazyNode(node).Valid Then
            '    SetupVisibilityContextMenu()
            '    menu.MenuItems.Add(menuItemVisibility)
            'End If

            ' 
            If NodeLevel = GetOtherLevelIndex(OTHERLEVEL_SUBFONDS) Then
                menu.MenuItems.Add(New MenuItem("-"))
                ' TODO: colocar no fx de configuração
                menu.MenuItems.Add(menuItemPromoteToFonds)
            End If

        End If


        Return menu
    End Function
#End Region


#Region "Append and Remove Nodes"

    Private Function getNewNodeID(ByVal levelIndex As Integer, ByVal c As LazyNodeCollection) As String
        Dim lazyNode As LazyNode
        Dim newCode As String = "[novo]"


        If levelIndex = EADDefinitions.GetOtherLevelIndex(EADDefinitions.OTHERLEVEL_FONDS) Then
        ElseIf levelIndex = EADDefinitions.GetOtherLevelIndex(EADDefinitions.OTHERLEVEL_SUBFONDS) Then
        ElseIf levelIndex = EADDefinitions.GetOtherLevelIndex(EADDefinitions.OTHERLEVEL_SECTION) Then
        ElseIf levelIndex = EADDefinitions.GetOtherLevelIndex(EADDefinitions.OTHERLEVEL_SUBSECTION) Then
        ElseIf levelIndex = EADDefinitions.GetOtherLevelIndex(EADDefinitions.OTHERLEVEL_SUBSUBSECTION) Then
        ElseIf levelIndex = EADDefinitions.GetOtherLevelIndex(EADDefinitions.OTHERLEVEL_SERIES) Then
            newCode = "000"
        ElseIf levelIndex = EADDefinitions.GetOtherLevelIndex(EADDefinitions.OTHERLEVEL_SUBSERIES) Then
            newCode = "000"
        ElseIf levelIndex = EADDefinitions.GetOtherLevelIndex(EADDefinitions.OTHERLEVEL_INSTALATIONUNIT) Then
            newCode = "0000"
        ElseIf levelIndex = EADDefinitions.GetOtherLevelIndex(EADDefinitions.OTHERLEVEL_COMPOSEDDOCUMENT) Then
            newCode = "00000"
        ElseIf levelIndex = EADDefinitions.GetOtherLevelIndex(EADDefinitions.OTHERLEVEL_DOCUMENT) Then
            newCode = "00000"
        End If

        If newCode <> "[novo]" Then
            For Each lazyNode In c
                If lazyNode.OtherLevelIndex = levelIndex Then
                    If newCode.CompareTo(lazyNode.UnitId) <= 0 Then
                        newCode = lazyNode.UnitId
                    End If
                End If
            Next
            newCode = IncrementReferenceCode(newCode, levelIndex)
        End If
        Return newCode
    End Function


    Private Function IncrementReferenceCode(ByVal code As String, ByVal levelIndex As Integer) As String
        Dim iCode As Integer
        Try
            iCode = CInt(code)
        Catch ex As Exception
            iCode = 0
        End Try
        iCode += 1

        If levelIndex = EADDefinitions.GetOtherLevelIndex(EADDefinitions.OTHERLEVEL_SECTION) OrElse _
           levelIndex = EADDefinitions.GetOtherLevelIndex(EADDefinitions.OTHERLEVEL_SUBSECTION) OrElse _
           levelIndex = EADDefinitions.GetOtherLevelIndex(EADDefinitions.OTHERLEVEL_SUBSUBSECTION) Then
            Return String.Format("{0:00}", iCode)
        ElseIf levelIndex = EADDefinitions.GetOtherLevelIndex(EADDefinitions.OTHERLEVEL_SERIES) OrElse _
               levelIndex = EADDefinitions.GetOtherLevelIndex(EADDefinitions.OTHERLEVEL_SUBSERIES) Then
            Return String.Format("{0:000}", iCode)
        ElseIf levelIndex = EADDefinitions.GetOtherLevelIndex(EADDefinitions.OTHERLEVEL_INSTALATIONUNIT) Then
            Return String.Format("{0:0000}", iCode)
        ElseIf levelIndex = EADDefinitions.GetOtherLevelIndex(EADDefinitions.OTHERLEVEL_COMPOSEDDOCUMENT) OrElse _
               levelIndex = EADDefinitions.GetOtherLevelIndex(EADDefinitions.OTHERLEVEL_DOCUMENT) Then
            Return String.Format("{0:00000}", iCode)
        End If
    End Function



    Public Sub SetNewestReference(ByVal node As TreeNode)
        Dim LazyNode As LazyNode = CType(node.Tag, LazyNode)
        Dim Siblings As LazyNodeCollection = CType(node.Parent.Tag, LazyNode).Children
        LazyNode.UnitId = getNewNodeID(LazyNode.OtherLevelIndex, Siblings)
        LazyNode.Upload()
        Me.RefreshNode(node)
    End Sub


    Public Sub SetNewestReference(ByVal LazyNode As LazyNode, ByVal Siblings As LazyNodeCollection)
        If LazyNode Is Nothing Or Siblings Is Nothing Then Exit Sub
        LazyNode.UnitId = getNewNodeID(LazyNode.OtherLevelIndex, Siblings)
        LazyNode.Upload()
    End Sub


    Public Sub AppendNewChild(ByVal ParentNode As TreeNode, ByVal OtherLevel As String)
        AppendNewChild(ParentNode, OtherLevel, ProcessInfoName)
    End Sub

    Public Sub AppendNewChild(ByVal ParentNode As TreeNode, ByVal OtherLevel As String, ByVal ProcessInfoName As String)
        Dim NodeLevelIndex As Integer = GetOtherLevelIndex(OtherLevel)

        If Not ParentNode Is Nothing Then
            Dim NewNode As TreeNode
            Dim LazyNode As LazyNode = CType(ParentNode.Tag, LazyNode)
            Dim ChildNode As LazyNode = LazyNode.CreateNode
            ChildNode.ProcessInfoName = ProcessInfoName
            ChildNode.ProcessInfoDate = DateToDB(Date.Now)


            Dim Siblings As LazyNodeCollection = CType(ParentNode.Tag, LazyNode).Children
            Dim nodeid As String = getNewNodeID(NodeLevelIndex, Siblings)

            ChildNode.UnitId = nodeid
            ChildNode.UnitTitle = "Sem título"
            ChildNode.OtherLevel = OtherLevel

            ChildNode.CountryCode = LazyNode.CountryCode
            ChildNode.RepositoryCode() = LazyNode.RepositoryCode

            ChildNode.Upload()

            LazyNode.AppendChild(ChildNode)

            Log.Append(Me.ProcessInfoName, Log.LogActions.AppendNode, String.Format(LogMessage("Log.AppendNode"), LazyNode.OtherLevel & " " & LazyNode.UnitId, ChildNode.OtherLevel & " " & ChildNode.UnitId))

            NewNode = New TreeNode(nodeid, ChildNode.OtherLevelIndex, ChildNode.OtherLevelIndex)
            NewNode.Tag = ChildNode
            ChildNode.TreeNode = NewNode
            ParentNode.Nodes.Add(NewNode)
            RefreshNode(NewNode)
            ParentNode.Expand()
            SelectedNode = NewNode

        End If
    End Sub


    Private Sub AppendNewSubFonds(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemAppendSubFonds.Click
        AppendNewChild(SelectedNode, OTHERLEVEL_SUBFONDS)
    End Sub

    Private Sub AppendNewSection(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemAppendSection.Click
        AppendNewChild(SelectedNode, OTHERLEVEL_SECTION)
    End Sub

    Private Sub AppendNewSubSection(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemAppendSubSection.Click
        AppendNewChild(SelectedNode, OTHERLEVEL_SUBSECTION)
    End Sub

    Private Sub AppendNewSubSubSection(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemAppendSubSubSection.Click
        AppendNewChild(SelectedNode, OTHERLEVEL_SUBSUBSECTION)
    End Sub

    Private Sub AppendNewSeries(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemAppendSeries.Click
        AppendNewChild(SelectedNode, OTHERLEVEL_SERIES)
    End Sub

    Private Sub AppendNewSubSeries(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemAppendSubSeries.Click
        AppendNewChild(SelectedNode, OTHERLEVEL_SUBSERIES)
    End Sub

    Private Sub AppendNewInstalationUnit(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemAppendInstalationUnit.Click
        AppendNewChild(SelectedNode, OTHERLEVEL_INSTALATIONUNIT)
    End Sub

    Private Sub AppendNewComposedDocument(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemAppendComposedDocument.Click
        AppendNewChild(SelectedNode, OTHERLEVEL_COMPOSEDDOCUMENT)
    End Sub

    Private Sub AppendNewDocument(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemAppendDocument.Click
        AppendNewChild(SelectedNode, OTHERLEVEL_DOCUMENT)
    End Sub



    Private Sub PromoteToFonds(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemPromoteToFonds.Click
        Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")
        Dim ID As Integer = SelectedLazyNode.ID
        Dim Exporter As New Exporter(SQLServerSettings.Item("ServerAddress"), _
                                     SQLServerSettings.Item("Database"), _
                                     SQLServerSettings.Item("Username"), _
                                     SQLServerSettings.Item("Password"), _
                                     ID, ProcessInfoName)
        Exporter.PromoteToFonds()


        ' colocar no fx de configuracao
        MsgBox("Operação Concluída! Um novo fundo foi criado com o identificador " & SelectedLazyNode.UnitId)
    End Sub



    Private Sub RemoveNode(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemRemoveNode.Click
        If SelectedLazyNode Is Nothing Then Exit Sub

        If SelectedLazyNode.HasChildren Then
            If MsgBox(InfoMessage("RemoveNode.Confirm"), MsgBoxStyle.Critical Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.YesNo, "Remover elemento...") = MsgBoxResult.Yes Then
                RemoveNode(SelectedNode)
            End If
        Else
            RemoveNode(SelectedNode)
        End If
    End Sub



    Public Sub RemoveNodes(ByVal SelectedNodes As ArrayList)
        Dim SelectedNode As TreeNode

        If (SelectedNodes.Count > 1 AndAlso MsgBox(InfoMessage("RemoveNode.Confirm"), MsgBoxStyle.Question Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.No) Then
            Exit Sub
        ElseIf SelectedNodes.Count = 1 AndAlso SelectedLazyNode.HasChildren Then
            If MsgBox(InfoMessage("RemoveNode.Confirm"), MsgBoxStyle.Question Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        End If

        For Each SelectedNode In SelectedNodes
            RemoveNode(SelectedNode)
        Next
    End Sub




    Private Sub RemoveNode(ByVal NodeToRemove As TreeNode)
        Cursor.Current = Cursors.WaitCursor
        If (Not NodeToRemove Is Nothing) And (Not NodeToRemove Is RootTreeNode()) Then
            Dim LazyNode As LazyNode = CType(NodeToRemove.Tag, LazyNode)
            Dim parentLazyNode As LazyNode = CType(NodeToRemove.Parent.Tag, LazyNode)

            Try
                Log.Append(Me.ProcessInfoName, Log.LogActions.RemoveNode, String.Format(LogMessage("Log.RemoveNode"), LazyNode.OtherLevel & " " & LazyNode.UnitId))
                parentLazyNode.RemoveChild(LazyNode)
                NodeToRemove.Remove()
            Catch ex As Exception
            End Try
        End If
        Cursor.Current = Cursors.Default
    End Sub


#End Region


#Region "Make Visible and Valid Nodes"

    'Public Sub MakeVisible(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemMakeVisible.Click
    '    Cursor.Current = Cursors.WaitCursor
    '    SelectedLazyNode.Catamorphism(New GeneChangeVisiblility(True))
    '    SelectedNode.Collapse()
    '    RefreshNode(SelectedNode)
    '    Cursor.Current = Cursors.Default
    'End Sub

    'Public Sub MakeInvisible(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemMakeInvisible.Click
    '    Cursor.Current = Cursors.WaitCursor
    '    SelectedLazyNode.Catamorphism(New GeneChangeVisiblility(False))
    '    SelectedNode.Collapse()
    '    RefreshNode(SelectedNode)
    '    Cursor.Current = Cursors.Default
    'End Sub


    'Public Sub MakeValid(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemMakeValid.Click
    '    Cursor.Current = Cursors.WaitCursor
    '    SelectedLazyNode.Catamorphism(New GeneChangeValidation(True))
    '    SelectedNode.Collapse()
    '    RefreshNode(SelectedNode)
    '    Cursor.Current = Cursors.Default
    'End Sub

    'Public Sub MakeInvalid(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemMakeInvalid.Click
    '    Cursor.Current = Cursors.WaitCursor
    '    SelectedLazyNode.Catamorphism(New GeneChangeValidation(False))
    '    SelectedNode.Collapse()
    '    RefreshNode(SelectedNode)
    '    Cursor.Current = Cursors.Default
    'End Sub

    Public Sub MakeVisible(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemMakeVisible.Click
        Dim Iterator As New Iterator(SelectedLazyNode)
        Me.Enabled = False
        Iterator.Start(Iterator.Action.MakeVisible)
        SelectedNode.Collapse()
        RefreshNode(SelectedNode)
        Me.Enabled = True

    End Sub

    Public Sub MakeInvisible(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemMakeInvisible.Click
        Dim Iterator As New Iterator(SelectedLazyNode)
        Me.Enabled = False
        Iterator.Start(Iterator.Action.MakeInvisible)
        SelectedNode.Collapse()
        RefreshNode(SelectedNode)
        Me.Enabled = True
    End Sub


    Public Sub MakeValid(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemMakeValid.Click
        Dim Iterator As New Iterator(SelectedLazyNode)
        Me.Enabled = False
        Iterator.Start(Iterator.Action.MakeValid)
        SelectedNode.Collapse()
        RefreshNode(SelectedNode)
        Me.Enabled = True
    End Sub

    Public Sub MakeInvalid(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemMakeInvalid.Click
        Dim Iterator As New Iterator(SelectedLazyNode)
        Me.Enabled = False
        Iterator.Start(Iterator.Action.MakeInvalid)
        SelectedNode.Collapse()
        RefreshNode(SelectedNode)
        Me.Enabled = True
    End Sub


    Public Sub MakeAvailable(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemMakeAvailable.Click
        Dim Iterator As New Iterator(SelectedLazyNode)
        Me.Enabled = False
        Iterator.Start(Iterator.Action.MakeAvailable)
        SelectedNode.Collapse()
        RefreshNode(SelectedNode)
        Me.Enabled = True
    End Sub

    Public Sub MakeUnavailable(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemMakeUnavailable.Click
        Dim Iterator As New Iterator(SelectedLazyNode)
        Me.Enabled = False
        Iterator.Start(Iterator.Action.MakeUnavailable)
        SelectedNode.Collapse()
        RefreshNode(SelectedNode)
        Me.Enabled = True
    End Sub

#End Region


#Region "Copy/Cut and Paste"

    Private Sub CutNodes(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemCut.Click
        CutNodes(SelectedNodes)
    End Sub

    Private Sub PasteNodes(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemPaste.Click
        PasteNodes(SelectedNode, False)
    End Sub


    Private Sub CopyNodes(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemCopy.Click
        CopyNodes(SelectedNodes())
    End Sub


    Public Sub CutNodes(ByVal Nodes As ArrayList)
        Dim SelectedNode As TreeNode

        If Not Nodes Is Nothing Then

            CopiedTreeNodes.Clear()
            For Each SelectedNode In Nodes
                'CopiedTreeNode.ForeColor = Color.Gray
                CopiedTreeNodes.Add(SelectedNode)
            Next

            EditOperation = EditOperations.Cut
            menuItemPaste.Enabled = True
        End If
    End Sub


    Public Sub CopyNode(ByVal Node As TreeNode)
        Dim List As New ArrayList(1)
        List.Add(Node)
        CopyNodes(List)
    End Sub

    Public Sub CopyNodes(ByVal Nodes As ArrayList)
        Dim SelectedNode As TreeNode

        If Not Nodes Is Nothing Then
            CopiedTreeNodes.Clear()
            For Each SelectedNode In Nodes
                CopiedTreeNodes.Add(SelectedNode)
            Next
            EditOperation = EditOperations.Copy
            menuItemPaste.Enabled = True
        End If
    End Sub


    Public Sub PasteNodes(ByVal PasteInto As TreeNode, ByVal UseNewestReference As Boolean)
        PasteNodes(PasteInto, UseNewestReference, myProcessInfoName)
        ' bug here
    End Sub


    Public Sub PasteNodes(ByVal PasteInto As TreeNode, ByVal UseNewestReference As Boolean, ByVal ProcessInfoName As String)
        Dim CopiedTreeNode As TreeNode
        Dim PastedNode As TreeNode

        Cursor.Current = Cursors.WaitCursor
        For Each CopiedTreeNode In CopiedTreeNodes
            PastedNode = PasteNode(CopiedTreeNode, PasteInto, UseNewestReference, ProcessInfoName)
        Next
        Cursor.Current = Cursors.Default
        menuItemPaste.Enabled = False
        SelectedNode = PastedNode
    End Sub


    Public Function PasteNode(ByVal CopiedTreeNode As TreeNode, ByVal PasteInto As TreeNode, _
                              ByVal UseNewestReference As Boolean, _
                              ByVal ProcessInfoName As String) As TreeNode

        If (Not PasteInto Is Nothing) AndAlso (Not CopiedTreeNode Is Nothing) Then
            Dim srcTreeNode As TreeNode = CopiedTreeNode
            Dim dstTreeNode As TreeNode = PasteInto
            Dim srcLazyNode As LazyNode = CType(CopiedTreeNode.Tag, LazyNode)
            Dim dstLazyNode As LazyNode = CType(PasteInto.Tag, LazyNode)

            If (dstTreeNode Is srcTreeNode) Then
                MsgBox(InfoMessage("InvalidDropPlace.SelfNode"), MsgBoxStyle.Information)
            ElseIf (dstLazyNode.OtherLevelIndex >= srcLazyNode.OtherLevelIndex) Then
                MsgBox(InfoMessage("InvalidDropPlace.DisrespectsHierarchy"), MsgBoxStyle.Information)
            Else
                If EditOperation = EditOperations.Copy Then
                    Dim srcLazyNodeClone As LazyNode = srcLazyNode.Clone
                    srcLazyNodeClone.ProcessInfoName = ProcessInfoName
                    srcLazyNodeClone.ProcessInfoDate = DateToDB(Date.Now)
                    If UseNewestReference Then SetNewestReference(srcLazyNodeClone, dstLazyNode.Children)

                    dstTreeNode.Expand()
                    dstLazyNode.AppendChild(srcLazyNodeClone)

                    Dim newTreeNode As New TreeNode
                    newTreeNode.Tag = srcLazyNodeClone
                    srcLazyNodeClone.TreeNode = newTreeNode
                    dstTreeNode.Nodes.Add(newTreeNode)
                    RefreshNode(newTreeNode)
                    Log.Append(Me.ProcessInfoName, Log.LogActions.AppendNode, String.Format(LogMessage("Log.AppendNode"), dstLazyNode.OtherLevel & " " & dstLazyNode.UnitId, srcLazyNodeClone.OtherLevel & " " & srcLazyNodeClone.UnitId))

                    Return newTreeNode
                ElseIf EditOperation = EditOperations.Cut Then
                    CopiedTreeNode.Remove()
                    dstTreeNode.Expand()
                    dstLazyNode.AppendChild(srcLazyNode)
                    dstTreeNode.Nodes.Add(srcTreeNode)

                    RefreshNode(srcTreeNode)
                    srcTreeNode.Collapse()

                    Log.Append(Me.ProcessInfoName, Log.LogActions.MoveNode, String.Format(LogMessage("Log.MoveNode"), srcLazyNode.OtherLevel & " " & srcLazyNode.UnitId, dstLazyNode.OtherLevel & " " & dstLazyNode.UnitId))
                    Return srcTreeNode
                End If
            End If
        End If
    End Function


#End Region


#Region "TreeView Event Handlers"

    Private Sub LazyTree_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles MyBase.AfterSelect
        LastSelectedNode = e.Node
    End Sub


    Private Sub EADTree_BeforeExpand(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles MyBase.BeforeExpand
        If (e.Node.Nodes.Item(0).Text = DummyNodeText) Then
            Cursor.Current = Cursors.WaitCursor
            e.Node.Nodes.RemoveAt(0) ' remove dummy
            Dim lazyNode As LazyNode = CType(e.Node.Tag, LazyNode)
            AddNodes(e.Node.Nodes, lazyNode.Children)
            Cursor.Current = Cursors.Default
        End If

    End Sub

    Private Sub LazyTree_AfterCollapse(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles MyBase.AfterCollapse
        Cursor.Current = Cursors.WaitCursor
        RefreshNode(e.Node)
        Cursor.Current = Cursors.Default
    End Sub

    Private Shadows Sub LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Leave
        If Not SelectedNode Is Nothing Then
            LastSelectedNode.BackColor = Color.LightGray
            'GetLazyNode(LastSelectedNode).Upload()
            UpdateTreeNode(LastSelectedNode, SelectedLazyNode)
        End If
    End Sub


    Private Shadows Sub GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.GotFocus
        If Not LastSelectedNode Is Nothing Then
            LastSelectedNode.BackColor = Color.White
            SetupTreeNodeColor(LastSelectedNode)
        End If
    End Sub


    Private Sub UpdateTreeNode(ByVal Node As TreeNode, ByVal LazyNode As LazyNode)
        Node.ImageIndex = LazyNode.OtherLevelIndex
        Node.SelectedImageIndex = LazyNode.OtherLevelIndex
        Node.Text = LazyNode.UnitId
        SetupTreeNodeColor(Node)
    End Sub

    Public Sub UpdateTreeNode(ByVal Node As TreeNode)
        Dim LazyNode As LazyNode = GetLazyNode(Node)
        Node.ImageIndex = LazyNode.OtherLevelIndex
        Node.SelectedImageIndex = LazyNode.OtherLevelIndex
        Node.Text = LazyNode.UnitId
        SetupTreeNodeColor(Node)
    End Sub


#End Region


End Class



