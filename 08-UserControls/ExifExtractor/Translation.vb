
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

Imports System
Imports System.Collections


Public Class Translation
    Inherits Hashtable

    Public Sub New()
        Mapping()
    End Sub

    Public Sub Mapping()
        Me.Add(&H8769, "Exif IFD")
        Me.Add(&H8825, "Gps IFD")
        Me.Add(&HFE, "New Subfile Type")
        Me.Add(&HFF, "Subfile Type")
        Me.Add(&H100, "Image Width")
        Me.Add(&H101, "Image Height")
        Me.Add(&H102, "Bits Per Sample")
        Me.Add(&H103, "Compression")
        Me.Add(&H106, "Photometric Interp")
        Me.Add(&H107, "Thresh Holding")
        Me.Add(&H108, "Cell Width")
        Me.Add(&H109, "Cell Height")
        Me.Add(&H10A, "Fill Order")
        Me.Add(&H10D, "Document Name")
        Me.Add(&H10E, "Image Description")
        Me.Add(&H10F, "Equip Make")
        Me.Add(&H110, "Equip Model")
        Me.Add(&H111, "Strip Offsets")
        Me.Add(&H112, "Orientation")
        Me.Add(&H115, "Samples PerPixel")
        Me.Add(&H116, "Rows Per Strip")
        Me.Add(&H117, "Strip Bytes Count")
        Me.Add(&H118, "Min Sample Value")
        Me.Add(&H119, "Max Sample Value")
        Me.Add(&H11A, "X Resolution")
        Me.Add(&H11B, "Y Resolution")
        Me.Add(&H11C, "Planar Config")
        Me.Add(&H11D, "Page Name")
        Me.Add(&H11E, "X Position")
        Me.Add(&H11F, "Y Position")
        Me.Add(&H120, "Free Offset")
        Me.Add(&H121, "Free Byte Counts")
        Me.Add(&H122, "Gray Response Unit")
        Me.Add(&H123, "Gray Response Curve")
        Me.Add(&H124, "T4 Option")
        Me.Add(&H125, "T6 Option")
        Me.Add(&H128, "Resolution Unit")
        Me.Add(&H129, "Page Number")
        Me.Add(&H12D, "Transfer Funcition")
        Me.Add(&H131, "Software Used")
        Me.Add(&H132, "Date Time")
        Me.Add(&H13B, "Artist")
        Me.Add(&H13C, "Host Computer")
        Me.Add(&H13D, "Predictor")
        Me.Add(&H13E, "White Point")
        Me.Add(&H13F, "Primary Chromaticities")
        Me.Add(&H140, "ColorMap")
        Me.Add(&H141, "Halftone Hints")
        Me.Add(&H142, "Tile Width")
        Me.Add(&H143, "Tile Length")
        Me.Add(&H144, "Tile Offset")
        Me.Add(&H145, "Tile ByteCounts")
        Me.Add(&H14C, "InkSet")
        Me.Add(&H14D, "Ink Names")
        Me.Add(&H14E, "Number Of Inks")
        Me.Add(&H150, "Dot Range")
        Me.Add(&H151, "Target Printer")
        Me.Add(&H152, "Extra Samples")
        Me.Add(&H153, "Sample Format")
        Me.Add(&H154, "S Min Sample Value")
        Me.Add(&H155, "S Max Sample Value")
        Me.Add(&H156, "Transfer Range")
        Me.Add(&H200, "JPEG Proc")
        Me.Add(&H201, "JPEG InterFormat")
        Me.Add(&H202, "JPEG InterLength")
        Me.Add(&H203, "JPEG RestartInterval")
        Me.Add(&H205, "JPEG LosslessPredictors")
        Me.Add(&H206, "JPEG PointTransforms")
        Me.Add(&H207, "JPEG QTables")
        Me.Add(&H208, "JPEG DCTables")
        Me.Add(&H209, "JPEG ACTables")
        Me.Add(&H211, "YCbCr Coefficients")
        Me.Add(&H212, "YCbCr Subsampling")
        Me.Add(&H213, "YCbCr Positioning")
        Me.Add(&H214, "REF Black White")
        Me.Add(&H8773, "ICC Profile")
        Me.Add(&H301, "Gamma")
        Me.Add(&H302, "ICC Profile Descriptor")
        Me.Add(&H303, "SRGB RenderingIntent")
        Me.Add(&H320, "Image Title")
        Me.Add(&H8298, "Copyright")
        Me.Add(&H5001, "Resolution X Unit")
        Me.Add(&H5002, "Resolution Y Unit")
        Me.Add(&H5003, "Resolution X LengthUnit")
        Me.Add(&H5004, "Resolution Y LengthUnit")
        Me.Add(&H5005, "Print Flags")
        Me.Add(&H5006, "Print Flags Version")
        Me.Add(&H5007, "Print Flags Crop")
        Me.Add(&H5008, "Print Flags Bleed Width")
        Me.Add(&H5009, "Print Flags Bleed Width Scale")
        Me.Add(&H500A, "Halftone LPI")
        Me.Add(&H500B, "Halftone LPIUnit")
        Me.Add(&H500C, "Halftone Degree")
        Me.Add(&H500D, "Halftone Shape")
        Me.Add(&H500E, "Halftone Misc")
        Me.Add(&H500F, "Halftone Screen")
        Me.Add(&H5010, "JPEG Quality")
        Me.Add(&H5011, "Grid Size")
        Me.Add(&H5012, "Thumbnail Format")
        Me.Add(&H5013, "Thumbnail Width")
        Me.Add(&H5014, "Thumbnail Height")
        Me.Add(&H5015, "Thumbnail ColorDepth")
        Me.Add(&H5016, "Thumbnail Planes")
        Me.Add(&H5017, "Thumbnail RawBytes")
        Me.Add(&H5018, "Thumbnail Size")
        Me.Add(&H5019, "Thumbnail CompressedSize")
        Me.Add(&H501A, "Color Transfer Function")
        Me.Add(&H501B, "Thumbnail Data")
        Me.Add(&H5020, "Thumbnail ImageWidth")
        Me.Add(&H502, "Thumbnail ImageHeight")
        Me.Add(&H5022, "Thumbnail BitsPerSample")
        Me.Add(&H5023, "Thumbnail Compression")
        Me.Add(&H5024, "Thumbnail PhotometricInterp")
        Me.Add(&H5025, "Thumbnail ImageDescription")
        Me.Add(&H5026, "Thumbnail EquipMake")
        Me.Add(&H5027, "Thumbnail EquipModel")
        Me.Add(&H5028, "Thumbnail StripOffsets")
        Me.Add(&H5029, "Thumbnail Orientation")
        Me.Add(&H502A, "Thumbnail SamplesPerPixel")
        Me.Add(&H502B, "Thumbnail RowsPerStrip")
        Me.Add(&H502C, "Thumbnail StripBytesCount")
        Me.Add(&H502D, "Thumbnail ResolutionX")
        Me.Add(&H502E, "Thumbnail ResolutionY")
        Me.Add(&H502F, "Thumbnail PlanarConfig")
        Me.Add(&H5030, "Thumbnail ResolutionUnit")
        Me.Add(&H5031, "Thumbnail TransferFunction")
        Me.Add(&H5032, "Thumbnail SoftwareUsed")
        Me.Add(&H5033, "Thumbnail DateTime")
        Me.Add(&H5034, "Thumbnail Artist")
        Me.Add(&H5035, "Thumbnail WhitePoint")
        Me.Add(&H5036, "Thumbnail PrimaryChromaticities")
        Me.Add(&H5037, "Thumbnail YCbCrCoefficients")
        Me.Add(&H5038, "Thumbnail YCbCrSubsampling")
        Me.Add(&H5039, "Thumbnail YCbCrPositioning")
        Me.Add(&H503A, "Thumbnail RefBlackWhite")
        Me.Add(&H503B, "Thumbnail CopyRight")
        Me.Add(&H5090, "Luminance Table")
        Me.Add(&H5091, "Chrominance Table")
        Me.Add(&H5100, "Frame Delay")
        Me.Add(&H5101, "Loop Count")
        Me.Add(&H5110, "Pixel Unit")
        Me.Add(&H5111, "Pixel PerUnit X")
        Me.Add(&H5112, "Pixel PerUnit Y")
        Me.Add(&H5113, "Palette Histogram")
        Me.Add(&H829A, "Exposure Time")
        Me.Add(&H829D, "F-Number")
        Me.Add(&H8822, "Exposure Prog")
        Me.Add(&H8824, "Spectral Sense")
        Me.Add(&H8827, "ISO Speed")
        Me.Add(&H8828, "OECF")
        Me.Add(&H9000, "Ver")
        Me.Add(&H9003, "DTOrig")
        Me.Add(&H9004, "DTDigitized")
        Me.Add(&H9101, "CompConfig")
        Me.Add(&H9102, "CompBPP")
        Me.Add(&H9201, "Shutter Speed")
        Me.Add(&H9202, "Aperture")
        Me.Add(&H9203, "Brightness")
        Me.Add(&H9204, "Exposure Bias")
        Me.Add(&H9205, "MaxAperture")
        Me.Add(&H9206, "SubjectDist")
        Me.Add(&H9207, "Metering Mode")
        Me.Add(&H9208, "LightSource")
        Me.Add(&H9209, "Flash")
        Me.Add(&H920A, "FocalLength")
        Me.Add(&H927C, "Maker Note")
        Me.Add(&H9286, "User Comment")
        Me.Add(&H9290, "DTSubsec")
        Me.Add(&H9291, "DTOrigSS")
        Me.Add(&H9292, "DTDigSS")
        Me.Add(&HA000, "FPXVer")
        Me.Add(&HA001, "ColorSpace")
        Me.Add(&HA002, "PixXDim")
        Me.Add(&HA003, "PixYDim")
        Me.Add(&HA004, "RelatedWav")
        Me.Add(&HA005, "Interop")
        Me.Add(&HA20B, "FlashEnergy")
        Me.Add(&HA20C, "SpatialFR")
        Me.Add(&HA20E, "FocalXRes")
        Me.Add(&HA20F, "FocalYRes")
        Me.Add(&HA210, "FocalResUnit")
        Me.Add(&HA214, "Subject Loc")
        Me.Add(&HA215, "Exposure Index")
        Me.Add(&HA217, "Sensing Method")
        Me.Add(&HA300, "FileSource")
        Me.Add(&HA301, "SceneType")
        Me.Add(&HA302, "CfaPattern")
        Me.Add(&H0, "Gps Ver")
        Me.Add(&H1, "Gps LatitudeRef")
        Me.Add(&H2, "Gps Latitude")
        Me.Add(&H3, "Gps LongitudeRef")
        Me.Add(&H4, "Gps Longitude")
        Me.Add(&H5, "Gps AltitudeRef")
        Me.Add(&H6, "Gps Altitude")
        Me.Add(&H7, "Gps GpsTime")
        Me.Add(&H8, "Gps GpsSatellites")
        Me.Add(&H9, "Gps GpsStatus")
        Me.Add(&HA, "Gps GpsMeasureMode")
        Me.Add(&HB, "Gps GpsDop")
        Me.Add(&HC, "Gps SpeedRef")
        Me.Add(&HD, "Gps Speed")
        Me.Add(&HE, "Gps TrackRef")
        Me.Add(&HF, "Gps Track")
        Me.Add(&H10, "Gps ImgDirRef")
        Me.Add(&H11, "Gps ImgDir")
        Me.Add(&H12, "Gps MapDatum")
        Me.Add(&H13, "Gps DestLatRef")
        Me.Add(&H14, "Gps DestLat")
        Me.Add(&H15, "Gps DestLongRef")
        Me.Add(&H16, "Gps DestLong")
        Me.Add(&H17, "Gps DestBearRef")
        Me.Add(&H18, "Gps DestBear")
        Me.Add(&H19, "Gps DestDistRef")
        Me.Add(&H1A, "Gps DestDist")
    End Sub

End Class





			