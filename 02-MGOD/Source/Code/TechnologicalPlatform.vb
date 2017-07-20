
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

Public Class TechnologicalPlatform

    Private myTPlatformID As Integer
    Private myScannerModelName As String
    Private myDeviceSource As String
    Private myScannerManufacturer As String
    Private myScanningSoftware As String
    Private myScanningSoftwareVersionNo As String
    Private myOperatingSystem As String
    Private myOperatingSystemVersion As String

#Region "Constructors"

    Public Sub New(ByVal ScannerModelName As String, ByVal TPlatformID As Integer)
        myTPlatformID = TPlatformID
        myScannerModelName = ScannerModelName
    End Sub

    Public Sub New(ByVal TPlatformID As Integer, ByVal ScannerModelName As String, _
        ByVal DeviceSource As String, ByVal ScannerManufacturer As String, _
        ByVal ScanningSoftware As String, ByVal ScanningSoftwareVersionNo As String, _
        ByVal OperatingSystem As String, ByVal OperatingSystemVersion As String)

        myTPlatformID = TPlatformID
        myScannerModelName = ScannerModelName
        myDeviceSource = DeviceSource
        myScannerManufacturer = ScannerManufacturer
        myScanningSoftware = ScanningSoftware
        myScanningSoftwareVersionNo = ScanningSoftwareVersionNo
        myOperatingSystem = OperatingSystem
        myOperatingSystemVersion = OperatingSystemVersion
    End Sub

#End Region

    Public Overrides Function tostring() As String
        Return Me.myScannerModelName
    End Function

#Region "Properties"

    Property TPlatformID() As Integer
        Get
            Return myTPlatformID
        End Get
        Set(ByVal Value As Integer)
            myTPlatformID = Value
        End Set
    End Property

    Property ScannerModelName() As String
        Get
            Return myScannerModelName
        End Get
        Set(ByVal Value As String)
            myScannerModelName = Value
        End Set
    End Property

    Property DeviceSource() As String
        Get
            Return myDeviceSource
        End Get
        Set(ByVal Value As String)
            myDeviceSource = Value
        End Set
    End Property

    Property ScannerManufacturer() As String
        Get
            Return myScannerManufacturer
        End Get
        Set(ByVal Value As String)
            myScannerManufacturer = Value
        End Set
    End Property

    Property ScanningSoftware() As String
        Get
            Return myScanningSoftware
        End Get
        Set(ByVal Value As String)
            myScanningSoftware = Value
        End Set
    End Property

    Property ScanningSoftwareVersionNo() As String
        Get
            Return myScanningSoftwareVersionNo
        End Get
        Set(ByVal Value As String)
            myScanningSoftwareVersionNo = Value
        End Set
    End Property

    Property OperatingSystem() As String
        Get
            Return myOperatingSystem
        End Get
        Set(ByVal Value As String)
            myOperatingSystem = Value
        End Set
    End Property

    Property Description() As String
        Get
            Return myOperatingSystemVersion
        End Get
        Set(ByVal Value As String)
            myOperatingSystemVersion = Value
        End Set
    End Property

#End Region

End Class


Public Class TechnologicalPlatformCollection
    Inherits CollectionBase


    Default Public Property Item(ByVal index As Integer) As TechnologicalPlatformCollection
        Get
            Return CType(List(index), TechnologicalPlatformCollection)
        End Get
        Set(ByVal Value As TechnologicalPlatformCollection)
            List(index) = Value
        End Set
    End Property

    Public Function Add(ByVal ScannerModelName As String, ByVal TPlatformID As Integer) As Integer
        Return List.Add(New TechnologicalPlatform(ScannerModelName, TPlatformID))
    End Function

    Public Function Add(ByVal TPlatformID As Integer, ByVal ScannerModelName As String, _
            ByVal DeviceSource As String, ByVal ScannerManufacturer As String, _
            ByVal ScanningSoftware As String, ByVal ScanningSoftwareVersionNo As String, _
            ByVal OperatingSystem As String, ByVal OperatingSystemVersion As String) As Integer
        Return List.Add(New TechnologicalPlatform(TPlatformID, ScannerModelName, DeviceSource, ScannerManufacturer, _
            ScanningSoftware, ScanningSoftwareVersionNo, OperatingSystem, OperatingSystemVersion))
    End Function

    Public Function IndexOf(ByVal value As TechnologicalPlatform) As Integer
        Return List.IndexOf(value)
    End Function

    Public Sub Insert(ByVal index As Integer, ByVal value As TechnologicalPlatform)
        List.Insert(index, value)
    End Sub

    Public Sub Remove(ByVal value As TechnologicalPlatform)
        List.Remove(value)
    End Sub

    Public Function Contains(ByVal value As TechnologicalPlatform) As Boolean
        Return List.Contains(value)
    End Function

End Class

