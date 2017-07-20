
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

