
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

Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml
'Imports LEAD


Public Class DOTreeView

    Private myTv As TreeView
    Private myDigitalObjectID As Int64
    Private myDOStructure As String

    Private database As New database


    Public Sub New(ByVal tv As TreeView, ByVal intDigitalObjectID As Int64)
        myTv = tv
        myDigitalObjectID = intDigitalObjectID
    End Sub

    Public Sub LoadTreeDO()
        Try
            myTv.Nodes.Clear()
            myDOStructure = getDOStructure(Me.myDigitalObjectID)

            If Not myDOStructure Is Nothing Then
                LoadTreeViewFromXmlFile(myDOStructure, myTv)
                myTv.ExpandAll()
            End If
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    Public Function getDOStructure(ByVal DigitalObjectID As Int64) As String
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim xml As String
        Try
            myConnection.ConnectionString = Constants.DigitArqConnectionString
            myCommand.Connection = myConnection
            myConnection.Open()
            myCommand.CommandText = "SELECT Structure FROM DigitalObjects WHERE DigitalObjectID=" & DigitalObjectID
            xml = CStr(myCommand.ExecuteScalar)
        Catch ex As Exception
            'MessageBoxes.MsgBoxException(ex)
        Finally
            myConnection.Close()
        End Try
        Return xml
    End Function

    Public Sub LoadTreeViewFromXmlFile(ByVal xml As String, ByVal trv As TreeView)
        Try
            ' Load the XML document.
            Dim xml_doc As New XmlDocument
            xml_doc.LoadXml(xml)

            trv.Nodes.Clear()
            AddTreeViewChildNodes(trv.Nodes, xml_doc.DocumentElement)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Sub AddTreeViewChildNodes(ByVal parent_nodes As TreeNodeCollection, ByVal xml_node As XmlNode)
        Dim isDerivative As Integer
        Dim id As Integer

        For Each child_node As XmlNode In xml_node.ChildNodes
            ' Make the new TreeView node.
            Dim new_node As TreeNode
            If child_node.Attributes.Count <> 0 Then
                new_node = parent_nodes.Add(child_node.Attributes("Text").Value)

                If child_node.Attributes.Count = 3 Then
                    id = child_node.Attributes("id").Value.TrimStart("_").ToString

                    new_node.Tag = id
                    isDerivative = haveDerivative(id)

                    If child_node.Attributes("Text").Value.ToLower.EndsWith("pdf") Then
                        new_node.ImageIndex = 3
                    ElseIf haveDerivative(id) And child_node.Attributes("Text").Value.ToLower.EndsWith("tif") Then
                        new_node.ImageIndex = 2
                    Else
                        new_node.ImageIndex = 1
                    End If
                    If haveAssociation(id) Then
                        new_node.ForeColor = Color.Blue
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

    Public Function haveDerivative(ByVal FileID As Int64) As Boolean
        Dim cn As New SqlConnection
        cn.ConnectionString = Constants.DigitArqConnectionString
        Dim myCommand As New SqlCommand
        Try
            cn.Open()
            myCommand.Connection = cn
            myCommand.CommandText = "SELECT COUNT(FileID) FROM DOFiles WHERE FileID = " & FileID & " AND IMAGE IS NOT NULL"

            Dim count As Integer = myCommand.ExecuteScalar
            If (count > 0) Then
                Return True
            Else
                Return False
            End If
        Catch e As SqlException
        Finally
            cn.Close()
            myCommand = Nothing
        End Try
    End Function

    Public Function haveAssociation(ByVal FileID As Int64) As Boolean
        Dim cn As New SqlConnection
        cn.ConnectionString = Constants.DigitArqConnectionString
        Dim myCommand As New SqlCommand
        Try
            cn.Open()
            myCommand.Connection = cn
            myCommand.CommandText = "SELECT COUNT(FileID) FROM DaoGrp WHERE FileID = " & FileID

            Dim count As Integer = myCommand.ExecuteScalar
            If (count > 0) Then
                Return True
            Else
                Return False
            End If
        Catch e As SqlException
        Finally
            cn.Close()
            myCommand = Nothing
        End Try
    End Function

End Class
