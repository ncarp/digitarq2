
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

Public Class TreeViewMultiSelection
    Inherits TreeView

    Private m_coll As ArrayList
    Private m_lastNode, m_firstNode As TreeNode
    Private myPreviousColor As Color


#Region "Public Methods"

    Public Sub New()
        m_coll = New ArrayList
    End Sub

    Property SelectedNodes() As ArrayList
        Get
            Return m_coll
        End Get
        Set(ByVal Value As ArrayList)
            removePaintFromNodes()
            m_coll.Clear()
            m_coll = Value
            paintSelectedNodes()
        End Set
    End Property

#End Region


#Region "Event Handling"

    Protected Overrides Sub OnBeforeSelect(ByVal e As TreeViewCancelEventArgs)
        MyBase.OnBeforeSelect(e)

        Dim bControl As Boolean = (Keys.Control = ModifierKeys)
        Dim bShift As Boolean = (Keys.Shift = ModifierKeys)

        If (bControl And m_coll.Contains(e.Node)) Then ' selecting a selected node
            RemovePaintFromNode(e.Node)
            m_coll.Remove(e.Node)
            e.Cancel = True
            Exit Sub
        ElseIf (bControl Or bShift) And m_coll.Count > 0 Then
            If e.Node.ImageIndex <> CType(m_coll.Item(0), TreeNode).ImageIndex Then
                e.Cancel = True
                Exit Sub
            End If
        End If

        m_lastNode = e.Node
        If (Not bShift) Then m_firstNode = e.Node
    End Sub

    Protected Overrides Sub OnAfterSelect(ByVal e As TreeViewEventArgs)
        MyBase.OnAfterSelect(e)

        Dim bControl As Boolean = (Keys.Control = ModifierKeys)
        Dim bShift As Boolean = (Keys.Shift = ModifierKeys)

        If (bControl) Then
            If (Not m_coll.Contains(e.Node)) Then
                m_coll.Add(e.Node)
                PaintSelectedNode(e.Node)
            Else
                RemovePaintFromNode(e.Node)
                m_coll.Remove(e.Node)
            End If
        Else
            If (bShift) Then
                Dim myQueue As Queue = New Queue
                Dim uppernode As TreeNode = m_firstNode
                Dim bottomnode As TreeNode = e.Node
                Dim bParent As Boolean = isParent(m_firstNode, e.Node)
                If (Not bParent) Then
                    bParent = isParent(bottomnode, uppernode)
                    If (bParent) Then
                        Dim t As TreeNode = uppernode
                        uppernode = bottomnode
                        bottomnode = t
                    End If
                    If bParent Then
                        Dim n As TreeNode = bottomnode
                        While (Not n Is uppernode.Parent)
                            If (Not m_coll.Contains(n)) Then myQueue.Enqueue(n)
                            n = n.Parent
                        End While
                    Else
                        If ((uppernode.Parent Is Nothing And bottomnode.Parent Is Nothing) Or (Not uppernode.Parent Is Nothing And uppernode.Parent.Nodes.Contains(bottomnode))) Then
                            Dim nIndexUpper As Integer = uppernode.Index
                            Dim nIndexBottom As Integer = bottomnode.Index
                            If (nIndexBottom < nIndexUpper) Then
                                Dim t As TreeNode = uppernode
                                uppernode = bottomnode
                                bottomnode = t
                                nIndexUpper = uppernode.Index
                                nIndexBottom = bottomnode.Index
                            End If

                            Dim n As TreeNode = uppernode
                            While (nIndexUpper <= nIndexBottom)
                                If (Not m_coll.Contains(n)) Then myQueue.Enqueue(n)
                                n = n.NextNode
                                nIndexUpper += 1
                            End While
                        Else
                            If (Not m_coll.Contains(uppernode)) Then myQueue.Enqueue(uppernode)
                            If (Not m_coll.Contains(bottomnode)) Then myQueue.Enqueue(bottomnode)
                        End If
                    End If
                    m_coll.AddRange(myQueue)
                    paintSelectedNodes(myQueue)
                    m_firstNode = e.Node
                End If
            Else
                If (Not m_coll Is Nothing And m_coll.Count > 0) Then
                    removePaintFromNodes()
                    m_coll.Clear()
                End If
                m_coll.Add(e.Node)
                PaintSelectedNode(e.Node)
            End If
        End If
    End Sub

    Protected Function isParent(ByVal parentNode As TreeNode, ByVal childNode As TreeNode) As Boolean
        If (parentNode Is childNode) Then Return True
        Dim n As TreeNode = childNode
        Dim bFound As Boolean = False
        While Not bFound And Not n Is Nothing
            n = n.Parent
            bFound = (n Is parentNode)
        End While

        Return bFound
    End Function

#End Region


#Region "Auxiliary functions"

    Protected Sub paintSelectedNodes()
        Dim n As TreeNode
        For Each n In m_coll
            PaintSelectedNode(n)
        Next
    End Sub

    Protected Sub PaintSelectedNode(ByVal Node As TreeNode)
        'myPreviousColor = Node.ForeColor
        Node.BackColor = SystemColors.Highlight
        'Node.ForeColor = SystemColors.HighlightText
    End Sub

    Protected Sub RemovePaintFromNode(ByVal Node As TreeNode)
        Node.BackColor = SystemColors.Window
        'Node.ForeColor = myPreviousColor
    End Sub

    Protected Sub removePaintFromNodes()
        If (m_coll.Count = 0) Then Exit Sub

        Dim n As TreeNode
        For Each n In m_coll
            RemovePaintFromNode(n)
        Next
    End Sub

    Protected Sub PaintSelectedNodes(ByVal List As IEnumerable)
        Dim e As IEnumerator = List.GetEnumerator
        While e.MoveNext
            PaintSelectedNode(e.Current)
        End While

    End Sub

#End Region

End Class
