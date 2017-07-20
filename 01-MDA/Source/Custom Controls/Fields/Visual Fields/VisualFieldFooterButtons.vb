
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

Imports System.Configuration

Public Class VisualFieldFooterButtons
    Inherits VisualField

    Public Event NewNode()
    Public Event ReplicateNode()
    Public Event SaveNode()

    Private WithEvents myReplicateButton As Button
    Private WithEvents myNewButton As Button
    Public WithEvents mySaveButton As Button

    Private Edited As Boolean = False

    Public Sub New(ByVal LazyNode As LazyNode, ByVal ImageList As ImageList)
        Me.LazyNode = LazyNode

        myNewButton = New Button
        myReplicateButton = New Button
        mySaveButton = New Button

        With myNewButton
            .Location = New Point(0, 0)
            .Text = VisualFieldLabel("NewButton")
            .TextAlign = ContentAlignment.MiddleRight
            .ImageList = ImageList
            .ImageIndex = 0
            .ImageAlign = ContentAlignment.MiddleLeft
            .FlatStyle = FlatStyle.Flat
            .Visible = LazyNode.OtherLevel <> EADDefinitions.OTHERLEVEL_FONDS
        End With

        With myReplicateButton
            .Location = New Point(myNewButton.Location.X + myNewButton.Width + 5, 0)
            .Text = VisualFieldLabel("NewButton")
            .TextAlign = ContentAlignment.MiddleRight
            .ImageList = ImageList
            .ImageIndex = 1
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = VisualFieldLabel("ReplicateButton")
            .FlatStyle = FlatStyle.Flat
            .Visible = LazyNode.OtherLevel <> EADDefinitions.OTHERLEVEL_FONDS
        End With

        With mySaveButton
            .Location = New Point(myReplicateButton.Location.X + myReplicateButton.Width + 245, 0)
            .Text = VisualFieldLabel("NewButton")
            .TextAlign = ContentAlignment.MiddleRight
            .ImageList = ImageList
            .ImageIndex = 2
            .ImageAlign = ContentAlignment.MiddleLeft
            .Text = VisualFieldLabel("SaveButton")
            .FlatStyle = FlatStyle.Flat
        End With


        Me.Size = New Size(mySaveButton.Location.X + mySaveButton.Width, mySaveButton.Height)
        Me.Controls.Add(myNewButton)
        Me.Controls.Add(myReplicateButton)
        Me.Controls.Add(mySaveButton)
    End Sub


    Private Sub NewButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles myNewButton.Click
        RaiseEvent NewNode()
    End Sub


    Private Sub ReplicateButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles myReplicateButton.Click
        RaiseEvent ReplicateNode()
    End Sub

    Private Sub SaveButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mySaveButton.Click
        RaiseEvent SaveNode()
    End Sub


    Public Sub EnableSaveButton(ByVal Enabled As Boolean)
        mySaveButton.Enabled = Enabled
        If Enabled Then
            Me.mySaveButton.BackColor = Color.FromArgb(255, 230, 255, 230)
            Me.mySaveButton.ForeColor = Color.Black
        Else
            Me.mySaveButton.BackColor = Color.FromArgb(255, 245, 220, 220)
            Me.mySaveButton.ForeColor = Color.Black
        End If
    End Sub



End Class
