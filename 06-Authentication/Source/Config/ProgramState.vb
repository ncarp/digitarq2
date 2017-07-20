
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

Imports System.Xml
Imports System.IO

Public Class ProgramState
    Private myConfigXml As XmlDocument
    Private myAplicationCode As String

    Public Sub New()
        myConfigXml = New XmlDocument
        If Not File.Exists(STATECONFIG_FILENAME) Then
            myConfigXml.LoadXml("<?xml version='1.0' encoding='utf-8'?><configuration> <appSettings> <LastLoginUsername></LastLoginUsername> <LastOpenedFonds></LastOpenedFonds> <LastUsedNode></LastUsedNode> <AskBeforeSave>True</AskBeforeSave> <LastFondsSearched></LastFondsSearched> </appSettings></configuration>")
        Else
            myConfigXml.Load(STATECONFIG_FILENAME)
        End If
    End Sub

    Public Sub New(ByVal AplicationCode As String)
        myAplicationCode = AplicationCode
        myConfigXml = New XmlDocument
        Dim ConfigFileName As String = String.Format(STATECONFIG_FILENAME, myAplicationCode)
        If Not File.Exists(ConfigFileName) Then
            myConfigXml.LoadXml("<?xml version='1.0' encoding='utf-8'?><configuration> <appSettings> <LastLoginUsername></LastLoginUsername> <LastOpenedFonds></LastOpenedFonds> <LastUsedNode></LastUsedNode> <AskBeforeSave>True</AskBeforeSave> <LastFondsSearched></LastFondsSearched> </appSettings></configuration>")
        Else
            myConfigXml.Load(ConfigFileName)
        End If
    End Sub

    Property AskBeforeSave() As Boolean
        Get
            Return StrToBool(GetConfigValue("AskBeforeSave"))
        End Get
        Set(ByVal Value As Boolean)
            SetConfigValue("AskBeforeSave", Value.ToString)
        End Set
    End Property

    Property LastFondsSearched() As String
        Get
            Return GetConfigValue("LastFondsSearched")
        End Get
        Set(ByVal Value As String)
            SetConfigValue("LastFondsSearched", Value)
        End Set
    End Property


    Property LastUsedNode() As Integer
        Get
            Return StrToInt(GetConfigValue("LastUsedNode"))
        End Get
        Set(ByVal Value As Integer)
            SetConfigValue("LastUsedNode", Value)
        End Set
    End Property


    Property LastOpenedFonds() As Integer
        Get
            Return StrToInt(GetConfigValue("LastOpenedFonds"))
        End Get
        Set(ByVal Value As Integer)
            SetConfigValue("LastOpenedFonds", Value)
        End Set
    End Property


    Property LastLoginUsername() As String
        Get
            Return GetConfigValue("LastLoginUsername")
        End Get
        Set(ByVal Value As String)
            SetConfigValue("LastLoginUsername", Value)
        End Set
    End Property


    Public Sub Save()
        myConfigXml.Save(String.Format(STATECONFIG_FILENAME, myAplicationCode))
    End Sub


    Private Function GetConfigValue(ByVal NodeName As String) As String
        Dim Node As XmlNode = myConfigXml.SelectSingleNode(String.Format("/configuration/appSettings/{0}", NodeName))
        If Not Node Is Nothing Then
            Return Node.InnerText
        Else
            Return ""
        End If
    End Function


    Private Sub SetConfigValue(ByVal NodeName As String, ByVal Value As String)
        Dim Node As XmlNode = myConfigXml.SelectSingleNode(String.Format("/configuration/appSettings/{0}", NodeName))
        If Not Node Is Nothing Then
            Node.InnerText = Value
        Else
            Node = myConfigXml.SelectSingleNode("/configuration/appSettings")
            Dim NewNode As XmlNode = myConfigXml.CreateNode(XmlNodeType.Element, NodeName, "")
            NewNode.InnerText = Value
            Node.AppendChild(NewNode)
        End If
    End Sub

End Class
