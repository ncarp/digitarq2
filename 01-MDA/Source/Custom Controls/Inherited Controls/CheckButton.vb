
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
