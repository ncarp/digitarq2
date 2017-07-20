
#Region "License Agreement"

'* DigitArq
'* Copyright 2007-2015 
'* Arquivo Distrital do Porto
'* Todos os direitos reservados.
'*  
'* Este software foi desenvolvido pelo Arquivo
'* Distrital do Porto (http://www.adporto.pt)
'* em articula��o com a Direc��o-Geral de Arquivos
'* (http://www.dgarq.gov.pt) e com a coordena��o
'* inform�tica da Universidade do Minho
'* (http://www.uminho.pt).
'* O desenvolvimento deste produto foi parcialmente
'* financiado pelo Programa Operacional para a 
'* Cultura (POC) promovido pelo Governo Portugu�s.
'* ---------------------------------------------------
'*
'* A redistribui��o e utiliza��o deste produto sob a
'* forma de c�digo-fonte ou programa compilado, com ou
'* sem modifica��es, � permitida desde que o seguinte
'* conjunto de condi��es seja cumprido:
'* 
'*	* Todas as redistribui��es do c�digo-fonte 
'*	  deste produto dever�o ser acompanhadas do
'*	  texto que comp�e esta licen�a, incluindo o 
'*	  texto inicial de atribui��o de autoria,
'*	  esta lista de condi��es e do seguinte termo
'*	  de responsabilidade.
'*
'*	* Os nomes da Direc��o-Geral de Arquivos,
'*	  do Arquivo Distrital do Porto, da 
'*	  Universidade do Minho e das pessoas 
'*	  individuais que colaboraram no desenvolvimento 
'*	  deste produto n�o dever�o ser utilizados na 
'*	  promo��o de produtos derivados deste 
'*	  sem que seja obtido consentimento pr�vio, por
'*	  escrito, por parte dos visados.

'*	* A utiliza��o da designa��o DigitArq, seus 
'*	  log�tipos e nomes institucionais associados
'*	  � apenas permitida em distribui��es que sejam
'*	  c�pias exactas da vers�o oficial deste produto
'*	  aprovada e/ou distribu�da pela Direc��o-Geral 
'*	  de Arquivos.

'*	* O desenvolvimento de obras derivadas deste
'*	  produto � permitido desde que a designa��o 
'*	  DigitArq, seus logotipos e parceiros 
'*	  institucionais n�o sejam utilizados em todo e
'*	  qualquer tipo de distribui��o e/ou promo��o 
'*	  da obra derivada.
'* 
'* ESTE SOFTWARE � DISTRIBUIDO PELA DIREC��O-GERAL DE
'* ARQUIVOS "NO ESTADO EM QUE SE ENCONTRA" SEM QUALQUER
'* PRESUN��O DE QUALIDADE OU GARANTIA ASSOCIADAS, 
'* INCLUINDO, MAS N�O LIMITADO A, GARANTIAS ASSOCIADAS
'* A COM�RCIO DE PRODUTOS OU DECLARA��O DE ADEQUABILIDADE
'* A DETERMINADO FIM OU OBJECTIVO. 

'* EM NENHUMA CIRCUNST�NCIA PODER� A DIREC��O-GERAL DE 
'* ARQUIVOS SER CONSIDERADA RESPONS�VEL POR QUAISQUER 
'* DANOS QUE RESULTEM DA UTILIZA��O DIRECTA, INDIRECTA,
'* ACIDENTAL, ESPECIAL OU DEMONSTRATIVA DESTE PRODUTO 
'* (INCLUINDO, MAS N�O LIMITADO A, PERDAS DE DADOS, 
'* LUCROS, FAL�NCIA, INDEVIDA PRESTA��O DE SERVI�OS
'* OU NEGLIG�NCIA), AINDA QUE O LICENCIANTE TENHA SIDO 
'* AVISADO DA POSSIBILIDADE DA OCORR�NCIA DE TAIS DANOS.
'*
'* ---------------------------------------------------
'* Para mais informa��o sobre este produto ou a sua 
'* licen�a, � favor consultar o endere�o electr�nico
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
