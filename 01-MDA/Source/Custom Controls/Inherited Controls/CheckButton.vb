
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

Public Class CheckButton
    Inherits System.Windows.Forms.Label

    Private myCheckedState As Boolean


    Public Sub New()
        MyBase.New()

        Checked = False
        AutoSize = True
        TabStop = True
        Cursor = Cursors.Hand
    End Sub


    Public Property Checked() As Boolean
        Get
            Return myCheckedState
        End Get
        Set(ByVal Value As Boolean)
            myCheckedState = Value
        End Set
    End Property


    Private Shadows Sub OnClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
        Checked = Not Checked
        Refresh()
    End Sub



    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Checked Then
            e.Graphics.DrawLine(Pens.DarkGray, 0, 0, Width - 1, 0)
            e.Graphics.DrawLine(Pens.DarkGray, 0, 0, 0, Height - 1)

            e.Graphics.DrawLine(Pens.WhiteSmoke, 0, Height - 1, Width - 1, Height - 1)
            e.Graphics.DrawLine(Pens.WhiteSmoke, Width - 1, 0, Width - 1, Height - 1)
            e.Graphics.DrawString(Text, Font, Brushes.Green, 1, 1)
        Else
            e.Graphics.DrawLine(Pens.WhiteSmoke, 0, 0, Width - 1, 0)
            e.Graphics.DrawLine(Pens.WhiteSmoke, 0, 0, 0, Height - 1)

            e.Graphics.DrawLine(Pens.DarkGray, 0, Height - 1, Width - 1, Height - 1)
            e.Graphics.DrawLine(Pens.DarkGray, Width - 1, 0, Width - 1, Height - 1)
            e.Graphics.DrawString(Text, Font, Brushes.DarkRed, 0, 0)
        End If

    End Sub





End Class
