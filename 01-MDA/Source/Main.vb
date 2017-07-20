
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

Imports System.Configuration
Imports MDA.Log
Imports System.Threading
Imports Authentication


Module Main

    Private auth As New GPU.SQLDataBase

    Sub Main(ByVal CmdArgs() As String)

        Dim frmSplash As New Authentication.SplashScreenForm(ConfigurationManager.AppSettings("Application.Code"))
        frmSplash.Show()

        If frmSplash.CheckPrerequisites() Then
            frmSplash.TopMost = False

            Dim authresult As GPU.SQLDataBase.eReturn = auth.validateEmployee(ConfigurationManager.AppSettings("Application.Code"), ADMIN_USERNAME, ADMIN_PASSWORD)
            Dim count As Integer = auth.countEmployees
            If count = 1 AndAlso authresult = GPU.SQLInterface.eReturn.Sucess Then
                Dim myProcessInfoName As String = ADMIN_USERNAME
                USER_LOGON = myProcessInfoName
                Log.Append(myProcessInfoName, LogActions.Login, String.Format(LogMessage("Log.Login"), myProcessInfoName, Date.Now.ToString))
                Dim frmMain As New MainForm(myProcessInfoName)
                frmSplash.Close()
                frmSplash.Dispose()
                Try
                    Application.Run(frmMain)
                Catch ex As Exception
                    MsgBoxException(ex)
                End Try
            Else
                Dim frmLogin As New Authentication.LoginForm(ConfigurationManager.AppSettings("Application.Code"))
                If frmLogin.ShowDialog() = DialogResult.OK Then
                    Dim myProcessInfoName As String = frmLogin.Username
                    USER_LOGON = myProcessInfoName
                    Log.Append(myProcessInfoName, LogActions.Login, String.Format(LogMessage("Log.Login"), myProcessInfoName, Date.Now.ToString))
                    Dim frmMain As New MainForm(myProcessInfoName)
                    frmLogin.Dispose()
                    frmSplash.Close()
                    frmSplash.Dispose()
                    Try
                        Application.Run(frmMain)
                    Catch ex As Exception
                        MsgBoxException(ex)
                    End Try
                End If
            End If
        Else
            frmSplash.Hide()
            frmSplash.ShowDialog()
        End If
    End Sub

End Module
