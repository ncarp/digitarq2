
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

Imports System.Windows.Forms
Imports System.Data.SqlClient


Public Class CTreeView

    '// m_collDeletedNodes is used to store node deletions in memory.  A call to 
    '// CTreeView.SaveNodeCollection() will commit the deletions, and other changes,
    '// to the database.  
    Dim m_collDeletedNodes As Collection
    Private database As New database


    Public Sub New()

        '// Initialize the DeletedNodes collection.
        m_collDeletedNodes = New Collection

    End Sub


    Public Sub DeleteNode(ByVal tnStart As TreeNode)

        '// PURPOSE: This function will delete the designated node (tnStart) and all
        '// of its children.  The deletions will be stored in a collection.  This will
        '// keep the deletions in memory, which configuration will allow us to rollback
        '// deletions.  

        '// Get a reference to the start node parent.
        Dim tnParent As TreeNode = tnStart.Parent

        '// Delete the start node's children.  This is performed via
        '// recursion, which will walk through all children regardless of number or
        '// arrangement.  Walking through each and every child of the start node will
        '// allow us to synchronize node deletions with the database.  Simply calling
        '// the remove function will remove the node and its children, but 
        '// will leave orphan records in the database.
        DeleteNodeRecursive(tnStart)

        '// Record the deletion of the start node.
        m_collDeletedNodes.Add(tnStart)

        '// Remove the start node from the TreeNodeCollection.
        tnStart.Nodes.Remove(tnStart)

        '// Update the image of the start node's parent if the start node parent status 
        '// changed from a branch to a leaf node.
        If Not (tnParent Is Nothing) Then
            If tnParent.GetNodeCount(False) = 0 Then
                If Not (tnParent.Parent Is Nothing) Then
                    tnParent.ImageIndex = 3
                    tnParent.SelectedImageIndex = 3
                End If
            End If
        End If

    End Sub


    Private Sub DeleteNodeRecursive(ByVal tnParent As TreeNode)

        '// PURPOSE: This function will walk through all the child nodes for a given
        '// node.  It will remove all the nodes from the TreeNodeCollection and will
        '// record all deletions in memory.  Deletions will be committed to the
        '// database when the user calls the CTreeView.SaveNodeCollection() method.

        Dim tn As TreeNode = Nothing
        Try
            If tnParent.GetNodeCount(False) > 0 Then
                tn = tnParent.Nodes(0)
                Do Until tn Is Nothing
                    If tn.GetNodeCount(False) > 0 Then
                        Call DeleteNodeRecursive(tn)
                    End If
                    m_collDeletedNodes.Add(tn)
                    tn = tn.NextNode
                Loop
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical) ', g_myAppConsts.MsgCaption)
        End Try

    End Sub


    Public Function IsDropAllowed(ByVal tnStart As TreeNode, _
                                  ByVal tnDrop As TreeNode) As Boolean
        '// PURPOSE: This function will determine if a drop will cause a circular
        '// reference.  A circular reference occurs when a node is dropped onto one
        '// of its children.

        Dim tnCurrent As TreeNode
        tnCurrent = tnDrop

        Do Until tnCurrent Is Nothing
            If tnCurrent Is tnStart Then
                IsDropAllowed = False
                Exit Function
            End If
            tnCurrent = tnCurrent.Parent
        Loop
        IsDropAllowed = True
    End Function


    Public Function EscapeSpecialChars(ByVal sInput As String) As String

        '// PURPOSE: The following function will escape special characters that can
        '// cause SQL statements to error.

        Dim chrCurrent As Char
        Dim chrSingleQuote As Char = Chr(39)
        Dim iCntr As Integer
        Dim sOutput As String = ""

        Try
            For iCntr = 0 To sInput.Length - 1
                chrCurrent = CType(sInput.Substring(iCntr, 1), Char)
                Select Case chrCurrent
                    Case CType(chrSingleQuote, Char)
                        sOutput = sOutput & chrSingleQuote & chrSingleQuote
                    Case Else
                        sOutput = sOutput & chrCurrent
                End Select
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        Return sOutput

    End Function

    Public Function PopulateDigitarqTree(ByRef tvw As TreeView, ByVal FondID As Int64) As Integer
        Dim tnInfo As TreeNodeInfo = database.SqlCommandSelectDigitArqToTree(FondID)
        If tnInfo Is Nothing Then
            Exit Function
        Else
            Try
                Dim tnNew As TreeNode = tvw.Nodes.Add(tnInfo.ID)
                With tnNew
                    .Tag = tnInfo.ID
                    .Text = tnInfo.UnitID & " " & tnInfo.UnitTitle
                    .ImageIndex = getImageIndex(tnInfo.OtherLevel)
                    .SelectedImageIndex = .ImageIndex
                    If Not tnInfo.Associated Then
                        .ForeColor = Color.Black
                    Else
                        .ForeColor = Color.Blue
                    End If
                End With
                GetChildren(tnNew)

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Populate DigitArqTreeView")
            End Try
        End If
    End Function

    Public Function GetChildren(ByVal tnParent As TreeNode) As TreeNode
        Dim tnNew As TreeNode
        Dim tnInfoCollection As TreeNodeInfoCollection = database.Children(tnParent.Tag)

        For Each tnInfo As TreeNodeInfo In tnInfoCollection
            tnNew = tnParent.Nodes.Add(tnInfo.ID)
            With tnNew
                .Tag = tnInfo.ID
                .Text = tnInfo.UnitID & " " & tnInfo.UnitTitle
                .ImageIndex = getImageIndex(tnInfo.OtherLevel)
                .SelectedImageIndex = .ImageIndex
                If Not tnInfo.Associated Then
                    .ForeColor = Color.Black
                Else
                    .ForeColor = Color.Blue
                End If
            End With
            If tnInfo.HasChildren Then
                tnNew.Nodes.Add("")
            End If
            tnInfo = Nothing
        Next
        tnInfoCollection = Nothing
        Return tnNew
    End Function

    Private Function TruncateStr(ByVal str As String, ByVal num As Integer) As String
        Dim retStr As String
        If str.Length > num Then
            retStr = str.Substring(0, num)
            retStr = retStr + "..."
        End If
        Return retStr
    End Function

    Function getImageIndex(ByVal level As String) As Integer
        If level = "F" Then
            Return 0
        End If
        If level = "SF" Then
            Return 1
        End If
        If level = "UI" Then
            Return 2
        End If
        If level = "SR" Then
            Return 3
        End If
        If level = "SSR" Then
            Return 4
        End If
        If level = "SC" Then
            Return 5
        End If
        If level = "SSC" Then
            Return 6
        End If
        If level = "SSSC" Then
            Return 7
        End If
        If level = "DC" Then
            Return 8
        End If
        If level = "D" Then
            Return 9
        End If
    End Function


End Class

