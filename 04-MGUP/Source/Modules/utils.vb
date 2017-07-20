
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
