
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

Public Class VisualFieldPhysTech
    Inherits VisualField

    Private WithEvents myTextField As VisualTextField
    Private WithEvents myContextButton As Button

    Private WithEvents myContextMenu As ContextMenu
    Private WithEvents myContextNenuItemGood As MenuItem
    Private WithEvents myContextNenuItemOk As MenuItem
    Private WithEvents myContextNenuItemBad As MenuItem

    Public Sub New(ByVal LazyNode As LazyNode)
        Me.LazyNode = LazyNode
        CreateContextMenu()

        myTextField = New VisualTextField(VisualFieldLabel("PhysTech"), VisualTextField.TextBoxWidthExtraLarge - 25)
        myTextField.Value = LazyNode.PhysTech

        myContextButton = New Button
        With myContextButton
            .Text = "<"
            .Location = New Point(myTextField.Location.X + myTextField.Width + 5, myTextField.Location.Y)
            .Height = myTextField.Height
            .Width = 20
            .FlatStyle = FlatStyle.Flat
        End With

        Me.Size = New Size(myContextButton.Location.X + myContextButton.Width, myContextButton.Height)
        Me.Controls.Add(myTextField)
        Me.Controls.Add(myContextButton)
    End Sub



    'Private Sub ShowContextMenu(ByVal sender As Object, ByVal e As MouseEventArgs) Handles myTextField.ShowContextBox
    '    myContextMenu.Show(Me, New Point(e.X, e.Y))
    'End Sub

    Private Sub myContextButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles myContextButton.Click
        myContextMenu.Show(Me, myContextButton.Location)
    End Sub

    Private Sub CreateContextMenu()
        myContextMenu = New ContextMenu
        myContextNenuItemGood = New MenuItem(ContextMenuLabel("menuItemPhystechGood"))
        myContextNenuItemOk = New MenuItem(ContextMenuLabel("menuItemPhystechOk"))
        myContextNenuItemBad = New MenuItem(ContextMenuLabel("menuItemPhystechBad"))

        myContextMenu.MenuItems.Add(myContextNenuItemGood)
        myContextMenu.MenuItems.Add(myContextNenuItemOk)
        myContextMenu.MenuItems.Add(myContextNenuItemBad)
    End Sub



    Private Sub InsertAutoText(ByVal sender As Object, ByVal e As System.EventArgs) Handles myContextNenuItemGood.Click, myContextNenuItemOk.Click, myContextNenuItemBad.Click
        myTextField.Value = CType(sender, MenuItem).Text
        RaiseEventDataChanged(Me, myTextField.Value)
    End Sub




    Private Sub Upload(ByVal EventCode As Integer, ByVal Value As Object) Handles myTextField.ValueChanged
        LazyNode.PhysTech = CStr(Value)
        RaiseEventDataChanged(Me, Value)
    End Sub

End Class
