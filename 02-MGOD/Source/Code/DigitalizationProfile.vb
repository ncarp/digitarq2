
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

Public Class DigitalizationProfile

    Private myProfileID As Integer
    Private myProfileName As String
    Private myDescription As String
    Private myResolution As String
    Private myBitDepth As String
    Private myFormat As String
    Private myCompression As String
    Private myRotation As Boolean
    Private myBrightness As String
    Private myContrast As String
    Private mySharpness As String
    Private myBlur As String


#Region "Constructors"

    Public Sub New()
    End Sub

    Public Sub New(ByVal ProfileName As String, ByVal ProfileID As Integer)
        myProfileID = ProfileID
        myProfileName = ProfileName
    End Sub

    Public Sub New(ByVal ProfileName As String, ByVal ProfileID As Integer, _
        ByVal Description As String, ByVal Resolution As Integer, _
        ByVal BitDepth As String, ByVal Format As Integer, _
        ByVal Compression As String, ByVal Rotation As Integer, _
        ByVal Brightness As String, ByVal Contrast As Integer, _
        ByVal Sharpness As String, ByVal Blur As Integer)

        myProfileID = ProfileID
        myProfileName = ProfileName
        myDescription = Description
        myResolution = Resolution
        myBitDepth = BitDepth
        myFormat = Format
        myCompression = Compression
        myRotation = Rotation
        myBrightness = Brightness
        myContrast = Contrast
        mySharpness = Sharpness
        myBlur = Blur
    End Sub

#End Region

    Public Overrides Function tostring() As String
        Return Me.myProfileName
    End Function

#Region "Properties"

    Property ProfileID() As Integer
        Get
            Return myProfileID
        End Get
        Set(ByVal Value As Integer)
            myProfileID = Value
        End Set
    End Property

    Property ProfileName() As String
        Get
            Return myProfileName
        End Get
        Set(ByVal Value As String)
            myProfileName = Value
        End Set
    End Property

    Property Description() As String
        Get
            Return myDescription
        End Get
        Set(ByVal Value As String)
            myDescription = Value
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

    Property BitDepth() As String
        Get
            Return myBitDepth
        End Get
        Set(ByVal Value As String)
            myBitDepth = Value
        End Set
    End Property

    Property Format() As String
        Get
            Return myFormat
        End Get
        Set(ByVal Value As String)
            myFormat = Value
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

    Property Rotation() As Boolean
        Get
            Return myRotation
        End Get
        Set(ByVal Value As Boolean)
            myRotation = Value
        End Set
    End Property

    Property Brightness() As String
        Get
            Return myBrightness
        End Get
        Set(ByVal Value As String)
            myBrightness = Value
        End Set
    End Property

    Property Contrast() As String
        Get
            Return myContrast
        End Get
        Set(ByVal Value As String)
            myContrast = Value
        End Set
    End Property

    Property Sharpness() As String
        Get
            Return mySharpness
        End Get
        Set(ByVal Value As String)
            mySharpness = Value
        End Set
    End Property

    Property Blur() As String
        Get
            Return myBlur
        End Get
        Set(ByVal Value As String)
            myBlur = Value
        End Set
    End Property

#End Region

End Class

Public Class DigitalizationProfileCollection
    Inherits CollectionBase


    Default Public Property Item(ByVal index As Integer) As DigitalizationProfileCollection
        Get
            Return CType(List(index), DigitalizationProfileCollection)
        End Get
        Set(ByVal Value As DigitalizationProfileCollection)
            List(index) = Value
        End Set
    End Property

    Public Function Add(ByVal ProfileName As String, ByVal ProfileID As Integer) As Integer
        Return List.Add(New DigitalizationProfile(ProfileName, ProfileID))
    End Function

    Public Function Add(ByVal value As DigitalizationProfile) As Integer
        Return List.Add(value)
    End Function

    Public Function IndexOf(ByVal value As DigitalizationProfile) As Integer
        Return List.IndexOf(value)
    End Function

    Public Sub Insert(ByVal index As Integer, ByVal value As DigitalizationProfile)
        List.Insert(index, value)
    End Sub

    Public Sub Remove(ByVal value As DigitalizationProfile)
        List.Remove(value)
    End Sub

    Public Function Contains(ByVal value As DigitalizationProfile) As Boolean
        Return List.Contains(value)
    End Function

End Class

