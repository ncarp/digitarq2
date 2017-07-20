
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


Module MessageBoxes



    Public Sub MsgBoxNetworkError()
        MsgBox(ErrorMessage("DatabaseAccess.Error"), MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly)
    End Sub

    Public Sub MsgBoxCustomError(ByVal ErrorMessage As String)
        MsgBox(ErrorMessage, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly)
    End Sub


    Public Sub MsgBoxSqlException(ByVal ex As SqlException)
        If ex.Number = 511 Then ' record overflow error. Record size is limited to 8060 chars
            MsgBoxCustomError(ErrorMessage("MsgBoxCustomError.RecordOverflow"))
        Else ' Generic error message
            MsgBox(ErrorMessage("MsgBoxCustomError.SqlException") & ControlChars.NewLine & ControlChars.NewLine & _
                   ErrorMessage("MsgBoxCustomError.AdvancedErrorDescription") & ControlChars.NewLine & _
                   "Description: " & ex.Message & ControlChars.NewLine & _
                   "Error type: " & ex.Number & ControlChars.NewLine & _
                   "Server: " & ex.Server & ControlChars.NewLine & _
                   "Source: " & ex.Source & ControlChars.NewLine & _
                   "State: " & ex.State & ControlChars.NewLine & _
                   "Method: " & ex.TargetSite.Name & ControlChars.NewLine & _
                   "Stack trace: " & ex.StackTrace & ControlChars.NewLine, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly)
        End If
    End Sub


    Public Sub MsgBoxException(ByVal ex As Exception)
        If TypeOf ex Is SqlException Then
            MsgBoxSqlException(ex)
        Else
            MsgBox(ErrorMessage("MsgBoxCustomError.Exception") & ControlChars.NewLine & ControlChars.NewLine & _
                   ErrorMessage("MsgBoxCustomError.AdvancedErrorDescription") & ControlChars.NewLine & _
                   "Description: " & ex.Message & ControlChars.NewLine & _
                   "Source: " & ex.Source & ControlChars.NewLine & _
                   "Method: " & ex.TargetSite.Name & ControlChars.NewLine & _
                   "Stack trace: " & ex.StackTrace & ControlChars.NewLine, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly)
        End If
    End Sub


End Module
