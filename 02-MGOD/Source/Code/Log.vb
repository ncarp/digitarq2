
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

Imports System.Data.SqlClient ' SQL Server Data Provider
Imports System.Configuration

Public Class Log

    Public Shared Function AppendNode() As String
        Return "GOD-01"
    End Function

    Public Shared Function EditNode() As String
        Return "GOD-02"
    End Function

    Public Shared Function RemoveNode() As String
        Return "GOD-03"
    End Function

    Public Shared Function LogInOut() As String
        Return "GOD-021"
    End Function

    Public Shared Sub Append(ByVal LogUsername As String, _
                         ByVal LogAction As String, ByVal LogDescription As String)

        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = Constants.DigitArqConnectionString

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Try
            SQLConnection.Open()
            SQLCommand.CommandText = String.Format("INSERT INTO Logs (Description, Date, Username, FunctionCode) VALUES ('{0}', GetDate(), '{1}', '{2}')", _
            LogDescription, LogUsername, LogAction)
            SQLCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBoxException(ex)
        Finally
            SQLCommand = Nothing
            SQLConnection.Close()
        End Try
    End Sub


    Public Shared Sub Clear(ByVal ServerAddress As String, ByVal Database As String, ByVal Username As String, _
                         ByVal Password As String, ByVal DeleteUntil As String)

        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", ServerAddress, Database, Username, Password)

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection
        Dim Result As Integer

        Try

            SQLConnection.Open()
            SQLCommand.CommandText = String.Format("DELETE FROM Logs Where DateTime < '{0}'", DeleteUntil)
            SQLCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBoxException(ex)
        Finally
            SQLConnection.Close()
        End Try
    End Sub

    Public Shared Sub Clear(ByVal DeleteUntil As String)
        Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")
        Clear(SQLServerSettings.Item("ServerAddress"), _
               SQLServerSettings.Item("Database"), _
               SQLServerSettings.Item("Username"), _
               SQLServerSettings.Item("Password"), DeleteUntil)
    End Sub
End Class
