
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

Public Class DOFile

    Private myFileID As Int64
    Private myDigitalObjectID As Int64
    Private myCreationDateTime As String
    Private myName As String
    Private myTPlatformID As String
    Private myColorSpace As String
    Private myLampTypeID As String
    Private myImageWidth As String
    Private myImageHeight As String
    Private myResolution As String
    Private myBitsPerPixel As String
    Private myCompression As String
    Private myMIMEType As String
    Private myFNumber As String
    Private myExposureTime As String
    Private myMeteringModeID As String
    Private myFocalLength As String
    Private myAutoFocusID As String
    Private myCheckSumCreationDateTime As String
    Private myCheckSumValue As String
    Private myImageSize As String
    Private myProfileID As String
    Private myProcessingDateTime As String
    Private myProcessingActions As String
    Private myProcessingSoftwareName As String
    Private myProcessingSoftwareVersion As String
    Private myProcessingOSName As String
    Private myProcessingOSVersion As String
    Private myColorManager As String
    Private myImage As Image
    Private myUserName As String


#Region "Constructors"

    Public Sub New()

    End Sub

#End Region


#Region "Properties"

    Property FileID() As Int64
        Get
            Return myFileID
        End Get
        Set(ByVal Value As Int64)
            myFileID = Value
        End Set
    End Property

    Property DigitalObjectID() As Int64
        Get
            Return myDigitalObjectID
        End Get
        Set(ByVal Value As Int64)
            myDigitalObjectID = Value
        End Set
    End Property

    Property CreationDateTime() As String
        Get
            Return myCreationDateTime
        End Get
        Set(ByVal Value As String)
            myCreationDateTime = Value
        End Set
    End Property

    Property Name() As String
        Get
            Return myName
        End Get
        Set(ByVal Value As String)
            myName = Value
        End Set
    End Property

    Property TPlatformID() As String
        Get
            Return myTPlatformID
        End Get
        Set(ByVal Value As String)
            myTPlatformID = Value
        End Set
    End Property

    Property ColorSpace() As String
        Get
            Return myColorSpace
        End Get
        Set(ByVal Value As String)
            myColorSpace = Value
        End Set
    End Property

    Property LampTypeID() As String
        Get
            Return myLampTypeID
        End Get
        Set(ByVal Value As String)
            myLampTypeID = Value
        End Set
    End Property

    Property ImageWidth() As String
        Get
            Return myImageWidth
        End Get
        Set(ByVal Value As String)
            myImageWidth = Value
        End Set
    End Property

    Property ImageHeight() As String
        Get
            Return myImageHeight
        End Get
        Set(ByVal Value As String)
            myImageHeight = Value
        End Set
    End Property

    Property Resolution() As String
        Get
            Return myResolution
        End Get
        Set(ByVal Value As String)
            myResolution = Value
        End Set
    End Property

    Property BitsPerPixel() As String
        Get
            Return myBitsPerPixel
        End Get
        Set(ByVal Value As String)
            myBitsPerPixel = Value
        End Set
    End Property

    Property Compression() As String
        Get
            Return myCompression
        End Get
        Set(ByVal Value As String)
            myCompression = Value
        End Set
    End Property

    Property MIMEType() As String
        Get
            Return myMIMEType
        End Get
        Set(ByVal Value As String)
            myMIMEType = Value
        End Set
    End Property

    Property FNumber() As String
        Get
            Return myFNumber
        End Get
        Set(ByVal Value As String)
            myFNumber = Value
        End Set
    End Property

    Property ExposureTime() As String
        Get
            Return myExposureTime
        End Get
        Set(ByVal Value As String)
            myExposureTime = Value
        End Set
    End Property

    Property MeteringModeID() As String
        Get
            Return myMeteringModeID
        End Get
        Set(ByVal Value As String)
            myMeteringModeID = Value
        End Set
    End Property

    Property FocalLength() As String
        Get
            Return myFocalLength
        End Get
        Set(ByVal Value As String)
            myFocalLength = Value
        End Set
    End Property

    Property AutoFocusID() As String
        Get
            Return myAutoFocusID
        End Get
        Set(ByVal Value As String)
            myAutoFocusID = Value
        End Set
    End Property

    Property CheckSumCreationDateTime() As String
        Get
            Return myCheckSumCreationDateTime
        End Get
        Set(ByVal Value As String)
            myCheckSumCreationDateTime = Value
        End Set
    End Property

    Property CheckSumValue() As String
        Get
            Return myCheckSumValue
        End Get
        Set(ByVal Value As String)
            myCheckSumValue = Value
        End Set
    End Property

    Property ImageSize() As String
        Get
            Return myImageSize
        End Get
        Set(ByVal Value As String)
            myImageSize = Value
        End Set
    End Property

    Property ProfileID() As String
        Get
            Return myProfileID
        End Get
        Set(ByVal Value As String)
            myProfileID = Value
        End Set
    End Property

    Property ProcessingDateTime() As String
        Get
            Return myProcessingDateTime
        End Get
        Set(ByVal Value As String)
            myProcessingDateTime = Value
        End Set
    End Property

    Property ProcessingActions() As String
        Get
            Return myProcessingActions
        End Get
        Set(ByVal Value As String)
            myProcessingActions = Value
        End Set
    End Property

    Property ProcessingSoftwareName() As String
        Get
            Return myProcessingSoftwareName
        End Get
        Set(ByVal Value As String)
            myProcessingSoftwareName = Value
        End Set
    End Property

    Property ProcessingSoftwareVersion() As String
        Get
            Return myProcessingSoftwareVersion
        End Get
        Set(ByVal Value As String)
            myProcessingSoftwareVersion = Value
        End Set
    End Property

    Property ProcessingOSName() As String
        Get
            Return myProcessingOSName
        End Get
        Set(ByVal Value As String)
            myProcessingOSName = Value
        End Set
    End Property

    Property ProcessingOSVersion() As String
        Get
            Return myProcessingOSVersion
        End Get
        Set(ByVal Value As String)
            myProcessingOSVersion = Value
        End Set
    End Property

    Property ColorManager() As String
        Get
            Return myColorManager
        End Get
        Set(ByVal Value As String)
            myColorManager = Value
        End Set
    End Property

    Property Image() As Image
        Get
            Return myImage
        End Get
        Set(ByVal Value As Image)
            myImage = Value
        End Set
    End Property

    Property UserName() As String
        Get
            Return myUserName
        End Get
        Set(ByVal Value As String)
            myUserName = Value
        End Set
    End Property

#End Region


End Class
