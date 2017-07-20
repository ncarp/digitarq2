
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

Imports System.Xml

Public Class CTree

    Private xml As String
    Private database As New SqlCommands

    ' Load a TreeView control from an XML file.
    Public Sub LoadTreeViewFromXmlFile(ByVal xml As String, ByVal trv As TreeView)
        Try
            ' Load the XML document.
            Dim xml_doc As New XmlDocument
            xml_doc.LoadXml(xml)

            trv.Nodes.Clear()
            AddTreeViewChildNodes(trv.Nodes, xml_doc.DocumentElement)
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        End Try
    End Sub

    ' Add the children of this XML node 
    ' to this child nodes collection.
    Public Sub AddTreeViewChildNodes(ByVal parent_nodes As TreeNodeCollection, ByVal xml_node As XmlNode)
        Dim isDerivative As Integer
        Dim id As Integer

        For Each child_node As XmlNode In xml_node.ChildNodes
            ' Make the new TreeView node.
            Dim new_node As TreeNode
            If child_node.Attributes.Count <> 0 Then
                new_node = parent_nodes.Add(child_node.Attributes("Text").Value)

                If child_node.Attributes.Count = 3 Then
                    id = child_node.Attributes("id").Value.TrimStart("_")

                    new_node.Tag = id
                    isDerivative = database.haveDerivative(id)

                    If child_node.Attributes("Text").Value.ToLower.EndsWith("pdf") Then
                        new_node.ImageIndex = 3
                    ElseIf isDerivative = 0 And child_node.Attributes("Text").Value.ToLower.EndsWith("tif") Then
                        new_node.ImageIndex = 2
                    Else
                        new_node.ImageIndex = 1
                    End If
                ElseIf child_node.Attributes.Count = 1 Then
                    new_node.ImageIndex = 0
                End If
            Else
                new_node.ImageIndex = 1
                new_node = parent_nodes.Add(child_node.Name)
            End If

            ' Recursively make this node's descendants.
            AddTreeViewChildNodes(new_node.Nodes, child_node)

            ' If this is a leaf node, make sure it's visible.
            If new_node.Nodes.Count = 0 Then new_node.EnsureVisible()
        Next child_node
    End Sub


    Public Function IsDropAllowed(ByVal tnStart As TreeNode, _
                                  ByVal tnDrop As TreeNode) As Boolean

        '// PURPOSE: This function will determine if a drop will cause a circular
        '// reference.  A circular reference occurs when a node is dropped onto one
        '// of its children.

        'MsgBox(tnStart.Text)
        Dim start As String = tnStart.Text
        Dim drop As String = tnDrop.Text

        Dim tnCurrent As TreeNode
        tnCurrent = tnDrop

        Do Until tnCurrent Is Nothing
            Dim text As String = tnCurrent.Text
            Dim text1 As String = tnStart.Text

            If tnCurrent Is tnStart Then
                IsDropAllowed = False
                Exit Function
                'ElseIf Not tnCurrent.Tag Is Nothing Then
                '    IsDropAllowed = False
                '    Exit Function
            End If
            tnCurrent = tnCurrent.Parent
        Loop

        IsDropAllowed = True

    End Function


    Public Sub SaveNodeCollection(ByVal intDigitalObjectID As Int64, ByVal tnRootNode As TreeNode)
        '// PURPOSE;  This method will save the TreeNodeCollection to a
        '// XML string.  It uses recursion to walk through the tree.  

        '// é directoria (tem filhos)
        If Not (tnRootNode Is Nothing) Then
            xml = "<TREENODES><treenode Text=""" & tnRootNode.Text & """ Type=""directory"">"
            '// Save all records to the XML file, starting with the root node. 
            Call SaveNodeCollectionRecursive(tnRootNode)
            xml &= "</treenode></TREENODES>"
        End If

        database.setDOStructure(intDigitalObjectID, xml)
    End Sub


    Private Sub SaveNodeCollectionRecursive(ByVal tnParent As TreeNode)
        '// PURPOSE: This function will save all child nodes in a given order
        '// starting with the root node and working out towards the child nodes.
        '// This function uses recursion, and will walk through any tree structure
        '// regardless of node count or arrangement.

        Dim tn As TreeNode

        If tnParent.GetNodeCount(False) > 0 Then
            tn = tnParent.Nodes(0)
        Else
            tn = Nothing
        End If

        Do Until tn Is Nothing

            Dim str As String

            If (tn.GetNodeCount(True) = 0) Then
                ' is a transcription
                If tn.ImageIndex = 3 Then
                    xml &= "<treenode Text=""" & tn.Text & """ " & " Type=""transcription"" id=" & _
                    """" & "_" & tn.Tag & """" & " >"
                ElseIf tn.ImageIndex = 1 Or tn.ImageIndex = 2 Then ' is an image
                    xml &= "<treenode Text=""" & tn.Text & """ " & " Type=""image"" id=" & _
                    """" & "_" & tn.Tag & """" & ">"
                Else ' is a directory (without child)
                    str = "<treenode Text=""" & tn.Text & """ Type=""" & "directory" & """" & " >"
                    xml &= str
                End If
            Else
                str = "<treenode Text=""" & tn.Text & """ Type=""" & "directory" & """" & " >"
                xml &= str
            End If

            If tn.GetNodeCount(False) > 0 Then
                Call SaveNodeCollectionRecursive(tn)
            End If
            xml &= "</treenode>"
            tn = tn.NextNode
        Loop
    End Sub

    'Public Sub PopulateTree(ByRef oTv As TreeView, ByVal digitalObject As Integer)
    '    '// PURPOSE: This function will populate a TreeView control from the database.

    '    Dim res As New ArrayList
    '    res = database.SqlCommandSelectDoToTree(digitalObject, "ID_DigitalObject")

    '    '// collNodeIDs is used to store a relationship between keys (in this case uids) and Nodes.  
    '    '// The collection is used to maintain parent-child relationships when populating the TreeView.
    '    Dim collNodeKeys As New Collection
    '    Dim collItems As New Collection
    '    Dim tnNew As TreeNode
    '    Dim tnParent As TreeNode
    '    Dim i As Integer

    '    Try
    '        For i = 0 To res.Count - 1
    '            collItems = res(i)

    '            If collItems.Item(6) Then 'if is root
    '                tnNew = oTv.Nodes.Add(CType(collItems.Item(11), String))
    '                If tnNew.GetNodeCount(True) = 0 Then
    '                    With tnNew
    '                        .Tag() = CType(collItems.Item(1), String)
    '                    End With
    '                Else
    '                    With tnNew
    '                        .Tag() = CType(collItems.Item(1), String)
    '                    End With
    '                End If

    '                '// Record the relationship of id to node.  This will allow
    '                '// us to retrieve a given node by providing the uid as a key.
    '                collNodeKeys.Add(tnNew, CType(collItems.Item(1), String))

    '            Else 'if is child
    '                'Dim image As Integer = database.SqlCommandSelectImage(collItems.Item(2), collItems.Item(3))
    '                '// Get the parent node based on the relationship stored in the database.  
    '                'MsgBox("parent:" & collItems.Item(8))
    '                tnParent = CType(collNodeKeys.Item(CType(collItems.Item(8), String)), TreeNode)

    '                '// Add the child to the parent;
    '                tnNew = tnParent.Nodes.Add(CType(collItems.Item(11), String))
    '                With tnNew
    '                    .Tag() = CType(collItems.Item(1), String)
    '                End With
    '                '// Record the relationship of uid to node.  This will allow
    '                '// us to retrieve a given node by providing the uid as a key.
    '                collNodeKeys.Add(tnNew, CType(collItems.Item(1), String))

    '            End If
    '        Next
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Erro PopulateTreeView")
    '    End Try
    'End Sub
End Class
