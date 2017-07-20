
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
