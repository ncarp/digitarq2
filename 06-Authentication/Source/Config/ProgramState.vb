
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
