
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

Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Configuration
Imports System.Globalization

Imports System.IO

Public Class MyImageProcessing 'Filters
    ' processamento de imagem

    Private database As New SqlCommands

    'construtor
    Public Sub New()
        MyBase.New()
    End Sub

    ''aplica o efeito Sharpen sobre a imagem 
    'Public Sub DoSharpen(ByVal ip As LEAD.Drawing.Imaging.ImageProcessing.ImageProcessing, ByVal img As LEAD.Drawing.Image, ByVal value As Double)
    '    ip.Sharpen(img, value * 10)
    'End Sub

    ''aplica o efeito Blur sobre a imagem 
    'Public Sub DoBlur(ByVal ip As LEAD.Drawing.Imaging.ImageProcessing.ImageProcessing, ByVal img As LEAD.Drawing.Image, ByVal value As Double)
    '    ip.Average(img, value)
    'End Sub
    'Public Sub DoBlur1(ByVal ip As LEAD.Drawing.Imaging.ImageProcessing.ImageProcessing, ByVal img As LEAD.Drawing.Image, ByVal value As Double)
    '    ip.Sharpen(img, value * 10)
    'End Sub

    ''aplica uma rotaçãp de 90 graus sobre a imagem 
    'Public Sub DoRotate(ByVal ip As LEAD.Drawing.Imaging.ImageProcessing.ImageProcessing, ByVal img As LEAD.Drawing.Image, ByVal angle As Integer)
    '    Dim flags As LEAD.Drawing.Imaging.ImageProcessing.ImageProcessing.RotateConstants
    '    Dim fillColor As Color

    '    flags = LEAD.Drawing.Imaging.ImageProcessing.ImageProcessing.RotateConstants.None
    '    fillColor = Color.White
    '    ip.Rotate(img, angle * 100, flags, fillColor)
    'End Sub

    ''aplica o efeito Brilho sobre a imagem 
    'Public Sub DoBrightness(ByVal ip As LEAD.Drawing.Imaging.ImageProcessing.ImageProcessing, ByVal img As LEAD.Drawing.Image, ByVal value As Double)
    '    ip.Intensity(img, value)
    'End Sub

    ''aplica o efeito Contraste sobre a imagem 
    'Public Sub DoContrast(ByVal ip As LEAD.Drawing.Imaging.ImageProcessing.ImageProcessing, ByVal img As LEAD.Drawing.Image, ByVal value As Double)
    '    ip.Contrast(img, value)
    'End Sub


    Public Function GeneDerivative(ByVal strFilePath As String, ByVal strDOName As String, _
        ByVal intFileID As Int64, ByVal intProjectID As Int64, ByVal intQuality As Integer) As String()

        'Dim img As LEAD.Drawing.Image = Nothing

        Dim Ret(2) As String
        Dim tifImage As Bitmap = New Bitmap(strFilePath)

        Dim strFileName As String = Path.GetFileName(strFilePath)
        Dim strProjectLocation As String = database.getLocationProject(intProjectID)
        Dim strProjectName As String = database.getProjectName(intProjectID)
        Dim strProjectDir As String

        If strProjectLocation.Length <> 0 Then
            strProjectDir = strProjectLocation & "\" & strProjectName & "\" & strDOName & "\" & strFileName
        Else
            strProjectDir = "C:\Projectos de Digitalização\" & strProjectName & "\" & strDOName & "\" & strFileName
        End If

        Dim strTargetPath As String = Path.GetDirectoryName(strProjectDir)

        Dim dirProjectDir As Directory

        If dirProjectDir.Exists(strTargetPath) Then
            tifImage.Save(strProjectDir)
        Else
            dirProjectDir.CreateDirectory(strTargetPath)
            dirProjectDir.CreateDirectory(strTargetPath & "_Derivadas")
            tifImage.Save(strProjectDir)
        End If

        Dim strDerivativeFileName As String = strTargetPath & "_Derivadas" & "\" & Path.GetFileNameWithoutExtension(strFilePath)
        Dim strThumbFileName As String = strTargetPath & "_Derivadas" & "\" & Path.GetFileNameWithoutExtension(strFilePath)

        Dim count As Integer = tifImage.GetFrameCount(FrameDimension.Page)

        Dim sDerivativeFile, sThumbFile As String

        sDerivativeFile = strDerivativeFileName + "_D.jpeg"
        sThumbFile = strThumbFileName + "_T.jpeg"

        tifImage.Save(sDerivativeFile, ImageFormat.Jpeg)
        tifImage.Save(sThumbFile, ImageFormat.Jpeg)

        InsertWatermark(sDerivativeFile, intQuality, Constants.WaterMarkText)
        GenerateThumb(sThumbFile, CInt(Constants.ThumbImageQuality))

        Ret(1) = sDerivativeFile
        Ret(2) = sThumbFile

        Return Ret
    End Function


    Private Sub InsertWatermark(ByVal ImageFile As String, ByVal intQuality As Integer, Optional ByVal strLine As String = "")
        Dim width As Integer = 0
        Dim height As Integer = 0

        Dim ciClone As CultureInfo = CType(CultureInfo.InvariantCulture.Clone(), CultureInfo)
        ciClone.NumberFormat.NumberDecimalSeparator = "."

        Dim img As System.Drawing.Image = System.Drawing.Image.FromFile(ImageFile)

        If img.Height > Constants.DerivativeImageHeight Then
            height = Constants.DerivativeImageHeight
        Else
            height = img.Height
        End If
        width = height * img.Width / img.Height

        Dim baseMap As System.Drawing.Bitmap = New System.Drawing.Bitmap(width, height)
        Dim myGraphic As Graphics = Graphics.FromImage(baseMap)
        Dim stringFormat As StringFormat = New StringFormat
        stringFormat.FormatFlags = StringFormatFlags.DirectionVertical
        myGraphic.DrawImage(img, 0, 0, width, height)

        'TAKE WATER MARK
        If Not Constants.WaterMarkImagePath.Equals("") Then
            Dim WaterMarkImage As System.Drawing.Image = WaterMarkImage.FromFile(Application.StartupPath + Constants.WaterMarkImagePath)

            Dim WaterMarkWidth As Integer = width * Convert.ToDouble(Constants.WaterMarkPercentWidth, ciClone)
            Dim WaterMarkHeight As Integer = WaterMarkWidth * WaterMarkImage.Height / WaterMarkImage.Width

            Dim WaterMarkXPosition As Integer = width / 2 - WaterMarkWidth / 2
            Dim WaterMarkYPosition As Integer = height * Convert.ToDouble(Constants.WaterMarkPercentXPosition, ciClone) - WaterMarkHeight / 2

            myGraphic.DrawImage(WaterMarkImage, WaterMarkXPosition, WaterMarkYPosition, WaterMarkWidth, WaterMarkHeight)

            WaterMarkImage.Dispose()
            WaterMarkImage = Nothing

        ElseIf Not strLine.Equals("") Then
            Dim letterBrush As SolidBrush = New SolidBrush(Color.FromArgb(100, 255, 255, 255))
            Dim shadowBrush As SolidBrush = New SolidBrush(Color.FromArgb(100, 0, 0, 0))
            Dim fontTitle As Font = New Font("Times New Roman", 20, FontStyle.Bold)

            myGraphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
            myGraphic.RotateTransform(-45)
            myGraphic.DrawString(strLine, fontTitle, shadowBrush, CInt(Constants.WaterMarkTextXPosition), CInt(Constants.WaterMarkTextYPosition))
            myGraphic.DrawString(strLine, fontTitle, letterBrush, CInt(Constants.WaterMarkTextXPosition), CInt(Constants.WaterMarkTextYPosition))
        End If


        img.Dispose()
        img = Nothing


        'cria um objeto encoder que será utilizado para compactar 
        'o arquivo JPEG. o objeto EncoderParameter recebe dois 
        'parâmetros (o objeto myEncoder e o percentual de compactação
        'que pode variar entre 0 e 100

        Dim myEncoder As Encoder = Encoder.Quality

        Dim myEncoderParameter As EncoderParameter
        Dim myEncoderParameters As EncoderParameters

        myEncoderParameters = New EncoderParameters(1)

        myEncoderParameter = New EncoderParameter(myEncoder, intQuality)
        myEncoderParameters.Param(0) = myEncoderParameter

        'obtém a coleção de encoders do arquivo de imagem

        Dim myImageCodecInfo As ImageCodecInfo
        myImageCodecInfo = GetEncoderInfo("image/jpeg")

        'salva o arquivo sobrescrevendo o original com a nova imagem
        'acrescida da marca d'água e compactada
        baseMap.Save(ImageFile, myImageCodecInfo, myEncoderParameters)

        'libera os recursos utilizados pelo objeto Bitmap
        baseMap.Dispose()
        baseMap = Nothing
    End Sub

    Private Sub GenerateThumb(ByVal ImageFile As String, ByVal intQuality As Integer)
        Dim width As Integer = 0
        Dim height As Integer = 0

        Dim img As System.Drawing.Image = System.Drawing.Image.FromFile(ImageFile)

        If img.Width > Constants.ThumbImageWidth Then
            width = Constants.ThumbImageWidth
        Else
            width = img.Width
        End If
        height = width * img.Height / img.Width

        Dim baseMap As System.Drawing.Bitmap = New System.Drawing.Bitmap(width, height)
        Dim myGraphic As Graphics = Graphics.FromImage(baseMap)
        Dim stringFormat As StringFormat = New StringFormat
        stringFormat.FormatFlags = StringFormatFlags.DirectionVertical
        myGraphic.DrawImage(img, 0, 0, width, height)

        img.Dispose()
        img = Nothing

        Dim myEncoder As Encoder = Encoder.Quality
        Dim myEncoderParameter As EncoderParameter
        Dim myEncoderParameters As EncoderParameters
        myEncoderParameters = New EncoderParameters(1)

        myEncoderParameter = New EncoderParameter(myEncoder, intQuality)
        myEncoderParameters.Param(0) = myEncoderParameter

        'obtém a coleção de encoders do arquivo de imagem

        Dim myImageCodecInfo As ImageCodecInfo
        myImageCodecInfo = GetEncoderInfo("image/jpeg")

        'salva o arquivo sobrescrevendo o original com a nova imagem
        'acrescida da marca d'água e compactada
        baseMap.Save(ImageFile, myImageCodecInfo, myEncoderParameters)

        'libera os recursos utilizados pelo objeto Bitmap
        baseMap.Dispose()
        baseMap = Nothing
    End Sub

    Private Function GetEncoderInfo(ByVal mimeType As String) As ImageCodecInfo
        Dim j As Integer
        Dim codecs() As ImageCodecInfo
        codecs = ImageCodecInfo.GetImageEncoders()

        For Each codec As ImageCodecInfo In codecs
            If codec.MimeType = mimeType Then
                Return codec
            End If
        Next
        Return Nothing
    End Function

End Class
