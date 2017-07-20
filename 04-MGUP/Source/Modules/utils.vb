
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

Public Module utils

    Public Function strConvdate(ByVal strYear As String, ByVal strMonth As String, ByVal strDay As String) As String
        Dim str As String = strYear.Trim & strMonth.Trim & strDay.Trim
        If strYear.Trim & strMonth.Trim & strDay.Trim = "" Then
            Return ""
        Else
            strYear = strYear.PadLeft(4, "0")

            strMonth = strMonth.PadLeft(2, "0")

            strDay = strDay.PadLeft(2, "0")

            Try
                Dim strDate As Date = strYear & "-" & strMonth & "-" & strDay
                Return strDate.ToString
            Catch ex As Exception
                Return "Error"
            End Try

        End If
    End Function


    Public Sub loadDdlMonth(ByVal ddl As DropDownList)
        Dim firstLI As New ListItem
        firstLI.Value = ""
        firstLI.Text = ""
        ddl.Items.Add(firstLI)
        For i As Integer = 1 To 12
            Dim li As New ListItem
            li.Value = i.ToString.PadLeft(2, "0")
            li.Text = MonthName(i)
            ddl.Items.Add(li)
        Next
    End Sub

    Public Function GetMonthName(ByVal monthValue As String) As String
        Return MonthName(monthValue)
    End Function



    Public Sub loadDdlDay(ByVal ddl As DropDownList)
        ddl.Items.Add("")
        For i As Integer = 1 To 31
            ddl.Items.Add(i.ToString.PadLeft(2, "0"))
        Next
    End Sub


    Public Sub Clean(ByVal controlP As Control)
        Dim ctl As Control
        For Each ctl In controlP.Controls
            If TypeOf ctl Is TextBox Then
                DirectCast(ctl, TextBox).Text = String.Empty
            ElseIf ctl.Controls.Count > 0 Then
                Clean(ctl)
            End If
        Next
    End Sub


    Public Function getReference(ByVal strFunctionCode As String) As String
        'Dim hshReference As Hashtable = ConfigurationSettings.GetConfig("references")
        Dim hshReference As Hashtable = ConfigurationManager.GetSection("references")
        Return hshReference(strFunctionCode)
    End Function

    Public Function getControlName(ByVal strFunctionCode As String) As String
        Dim configReader As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Return configReader.GetValue(strFunctionCode, GetType(String))
    End Function

End Module
