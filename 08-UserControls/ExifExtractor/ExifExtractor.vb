
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

Imports System
Imports System.Text
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.Reflection
Imports System.IO
Imports System.Web.UI


Public Class EXIFextractor
    Implements System.Collections.IEnumerable

#Region "Private properties"

    Private bmp As System.Drawing.Bitmap
    Private data As String
    Private myAttributeNames As Translation
    Private myPropertyItems As Hashtable
    Private myHeight As String
    Private myWidth As String
    Private myResolution As String
    Private myBitsPerSample As String
    Private myXResolution As String
    Private myYResolution As String
    Private myFocalLength As String
    Private myFNumber As String
    Private myOrientation As String
    Private myCompression As String
    Private myColorSpace As String
    Private myDateTime As String
    Private myExposureTime As String

#End Region

#Region "Constructors"

    Public Sub New(ByVal bmp As System.Drawing.Bitmap)

        Dim myPropertyItems As Hashtable = New Hashtable
        Me.bmp = bmp

        myAttributeNames = New Translation
        buildDB(Me.bmp.PropertyItems)
    End Sub

    Public Sub New(ByVal file As String)
        myPropertyItems = New Hashtable

        Me.bmp = New Bitmap(file)
        myAttributeNames = New Translation
        buildDB(GetExifProperties(file))
    End Sub

#End Region

#Region "Methods and functions"

    Private Function Count() As Integer
        Return Me.myPropertyItems.Count
    End Function

    Public Sub setTag(ByVal id As Integer, ByVal data As String)
        Dim ascii As Encoding = Encoding.ASCII
        Me.setTag(id, data.Length, "0x2", ascii.GetBytes(data))
    End Sub

    Public Sub setTag(ByVal id As Integer, ByVal len As Integer, ByVal type As Integer, ByVal data As Byte())
        Dim p As PropertyItem = CreatePropertyItem(type, id, len, data)
        Me.bmp.SetPropertyItem(p)
        buildDB(Me.bmp.PropertyItems)
    End Sub

    Private Function CreatePropertyItem(ByVal type As Short, ByVal tag As Integer, ByVal len As Integer, ByVal value As Byte()) As PropertyItem
        Dim item As PropertyItem

        ' Loads a PropertyItem from a image stored in the assembly as a resource.
        Dim ass As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim emptyBitmapStream As Stream = ass.GetManifestResourceStream("EXIFextractor.decoy.jpg")
        Dim empty As System.Drawing.Image = System.Drawing.Image.FromStream(emptyBitmapStream)

        item = empty.PropertyItems(0)

        'Copies the data to the property item.
        item.Type = type
        item.Len = len
        item.Id = tag
        item.Value = New Byte(value.Length) {}
        value.CopyTo(item.Value, 0)

        Return item
    End Function

    Public Function GetExifProperties(ByVal fileName As String) As PropertyItem()
        Dim stream As FileStream = New FileStream(fileName, FileMode.Open, FileAccess.Read)
        Dim img As System.Drawing.Image = System.Drawing.Image.FromStream(stream, True, False)
        Return img.PropertyItems
    End Function

    Private Sub buildDB(ByVal parr As System.Drawing.Imaging.PropertyItem())
        myPropertyItems.Clear()


        Dim data As String = ""
        Dim ascii As Encoding = Encoding.ASCII

        For Each p As System.Drawing.Imaging.PropertyItem In parr
            Dim v As String = ""
            Dim name As String
            If myAttributeNames.ContainsKey(p.Id) Then
                name = myAttributeNames.Item(p.Id).ToString
            End If
            'tag not found. skip it

            If Not name Is Nothing Then
                'data = data + name + ": "

                If p.Type = &H1 Then
                    '1 = BYTE An 8-bit unsigned integer.
                    v = p.Value(0).ToString()

                ElseIf p.Type = &H2 Then
                    '2 = ASCII An 8-bit byte containing one 7-bit ASCII code. The final byte is terminated with NULL.
                    v = ascii.GetString(p.Value).ToString.Trim
                    'v = ""
                    'v = Convert.ToString(p.Value)
                ElseIf p.Type = &H3 Then
                    '3 = SHORT A 16-bit (2 -byte) unsigned integer,
                    'orientation // lookup table
                    v = ExtractU16Value(p)
                ElseIf p.Type = &H4 Then
                    '4 = LONG A 32-bit (4 -byte) unsigned integer,
                    '// orientation // lookup table					
                    v = convertToInt32U(p.Value).ToString()
                ElseIf p.Type = &H5 Then
                    '5 = RATIONAL Two LONGs. The first LONG is the numerator and the second LONG expresses the//denominator.,
                    '// rational

                    Dim n As Byte() = New Byte((p.Len / 2) - 1) {}
                    Dim d As Byte() = New Byte((p.Len / 2) - 1) {}

                    Array.Copy(p.Value, 0, n, 0, CInt(p.Len / 2))
                    Array.Copy(p.Value, CInt(p.Len / 2), d, 0, CInt(p.Len / 2))

                    Dim a As UInt32 = convertToInt32U(n)
                    Dim b As UInt32 = convertToInt32U(d)
                    Dim r As Rational = New Rational(a, b)


                    '//convert here

                    Select Case (p.Id)
                        Case &H9202 'aperture
                            v = "F/" + Math.Round(Math.Pow(Math.Sqrt(2), r.ToDouble()), 2).ToString()
                        Case &H920A
                            v = r.ToDouble().ToString()
                        Case &H829A
                            v = r.ToDouble().ToString()
                        Case &H829D 'F-number
                            v = "F/" + r.ToDouble().ToString()
                        Case Else
                            v = r.ToStr("/")
                    End Select

                ElseIf p.Type = &H7 Then
                    '7 = UNDEFINED An 8-bit byte that can take any value depending on the field definition,
                    Select Case p.Id
                        Case &HA300
                            If p.Value(0) = 3 Then
                                v = "DSC"
                            Else
                                v = "reserved"
                            End If

                        Case &HA301
                            If p.Value(0) = 1 Then
                                v = "A directly photographed image"
                            Else
                                v = "Not a directly photographed image"
                            End If
                        Case Else
                            v = "-"
                    End Select

                ElseIf p.Type = &H9 Then
                    '9 = SLONG A 32-bit (4 -byte) signed integer (2's complement notation),
                    v = convertToInt32(p.Value).ToString()
                    '10 = SRATIONAL Two SLONGs. The first SLONG is the numerator and the second SLONG is the denominator.
                ElseIf p.Type = &HA Then
                    '// rational						
                    Dim n As Byte() = New Byte((p.Len / 2) - 1) {}
                    Dim d As Byte() = New Byte((p.Len / 2) - 1) {}
                    Array.Copy(p.Value, 0, n, 0, CInt(p.Len / 2))
                    Array.Copy(p.Value, CInt(p.Len / 2), d, 0, CInt(p.Len / 2))
                    Dim a As Integer = convertToInt32(n)
                    Dim b As Integer = convertToInt32(d)
                    Dim r As Rational = New Rational(a, b)

                    'convert here
                    Select Case (p.Id)
                        Case &H9201 'shutter speed
                            v = "1/" + Math.Round(Math.Pow(2, r.ToDouble()), 2).ToString()
                        Case &H9203
                            v = Math.Round(r.ToDouble(), 4).ToString()
                        Case Else
                            v = r.ToStr("/")
                            'add it to the list
                    End Select
                End If


                If myPropertyItems(name) Is Nothing Then
                    myPropertyItems.Add(name, v)
                End If
            End If
        Next
    End Sub


    Function ExtractU16Value(ByVal p As PropertyItem) As String
        Dim v As String
        Select Case p.Id
            Case &H8827 'ISO
                v = "ISO-" + convertToInt16U(p.Value).ToString()
                Exit Select
            Case &HA217
                Select Case convertToInt16U(p.Value)
                    Case 1 : v = "Not defined"
                        Exit Select
                    Case 2 : v = "One-chip color area sensor"
                        Exit Select
                    Case 3 : v = "Two-chip color area sensor"
                        Exit Select
                    Case 4 : v = "Three-chip color area sensor"
                        Exit Select
                    Case 5 : v = "Color sequential area sensor"
                        Exit Select
                    Case 7 : v = "Trilinear sensor"
                        Exit Select
                    Case 8 : v = "Color sequential linear sensor"
                        Exit Select
                    Case Else : v = " reserved"
                        Exit Select
                End Select
                Exit Select
            Case &H8822 'aperture
                Select Case convertToInt16U(p.Value)
                    Case 0 : v = "Not defined"
                        Exit Select
                    Case 1 : v = "Manual"
                        Exit Select
                    Case 2 : v = "Normal program"
                        Exit Select
                    Case 3 : v = "Aperture priority"
                        Exit Select
                    Case 4 : v = "Shutter priority"
                        Exit Select
                    Case 5 : v = "Creative program (biased toward depth of field)"
                        Exit Select
                    Case 6 : v = "Action program (biased toward fast shutter speed)"
                        Exit Select
                    Case 7 : v = "Portrait mode (for closeup photos with the background out of focus)"
                        Exit Select
                    Case 8 : v = "Landscape mode (for landscape photos with the background in focus)"
                        Exit Select
                    Case Else : v = "reserved"
                        Exit Select
                End Select
                Exit Select
            Case &H9207 'metering mode
                Select Case convertToInt16U(p.Value)
                    Case 0 : v = "unknown"
                        Exit Select
                    Case 1 : v = "Average"
                        Exit Select
                    Case 2 : v = "CenterWeightedAverage"
                        Exit Select
                    Case 3 : v = "Spot"
                        Exit Select
                    Case 4 : v = "MultiSpot"
                        Exit Select
                    Case 5 : v = "Pattern"
                        Exit Select
                    Case 6 : v = "Partial"
                        Exit Select
                    Case 255 : v = "Other"
                        Exit Select
                    Case Else : v = "reserved"
                        Exit Select
                End Select
                Exit Select
            Case &H9208 'light source
                Select Case convertToInt16U(p.Value)
                    Case 0 : v = "unknown"
                        Exit Select
                    Case 1 : v = "Daylight"
                        Exit Select
                    Case 2 : v = "Fluorescent"
                        Exit Select
                    Case 3 : v = "Tungsten"
                        Exit Select
                    Case 17 : v = "Standard light A"
                        Exit Select
                    Case 18 : v = "Standard light B"
                        Exit Select
                    Case 19 : v = "Standard light C"
                        Exit Select
                    Case 20 : v = "D55"
                        Exit Select
                    Case 21 : v = "D65"
                        Exit Select
                    Case 22 : v = "D75"
                        Exit Select
                    Case 255 : v = "other"
                        Exit Select
                    Case Else : v = "reserved"
                        Exit Select
                End Select
                Exit Select
            Case &H9209
                Select Case convertToInt16U(p.Value)
                    Case 0 : v = "Flash did not fire"
                        Exit Select
                    Case 1 : v = "Flash fired"
                        Exit Select
                    Case 5 : v = "Strobe return light not detected"
                        Exit Select
                    Case 7 : v = "Strobe return light detected"
                        Exit Select
                    Case Else : v = "reserved"
                        Exit Select
                End Select
                Exit Select
            Case &H112 'Rotation
                Select Case convertToInt16U(p.Value)
                    Case 1 : v = "Horizontal (normal)"
                        Exit Select
                    Case 2 : v = "Mirror horizontal"
                        Exit Select
                    Case 3 : v = "Rotate 180"
                        Exit Select
                    Case 4 : v = "Mirror vertical"
                        Exit Select
                    Case 5 : v = "Mirror horizontal and rotate 270 CW"
                        Exit Select
                    Case 6 : v = "Rotate 90 CW"
                        Exit Select
                    Case 7 : v = "Mirror horizontal and rotate 90 CW"
                        Exit Select
                    Case 8 : v = "Rotate 270 CW"
                        Exit Select
                    Case Else : v = "reserved"
                        Exit Select
                End Select
                Exit Select
            Case &H103 'Compression
                Select Case convertToInt16U(p.Value)
                    Case 1 : v = "Uncompressed"
                        Exit Select
                    Case 2 : v = "CCITT 1D"
                        Exit Select
                    Case 3 : v = "T4/Group 3 Fax"
                        Exit Select
                    Case 4 : v = "T6/Group 4 Fax"
                        Exit Select
                    Case 5 : v = "LZW"
                        Exit Select
                    Case 6 : v = "JPEG (old-style)"
                        Exit Select
                    Case 7 : v = "JPEG"
                        Exit Select
                    Case 8 : v = "Adobe Deflate"
                        Exit Select
                    Case 9 : v = "JBIG B&W"
                        Exit Select
                    Case 10 : v = "JBIG Color"
                        Exit Select
                    Case 99 : v = "JPEG"
                        Exit Select
                    Case 32946 : v = "Deflate"
                        Exit Select
                    Case 34661 : v = "JBIG"
                        Exit Select
                    Case Else
                        v = "UNKNOWN"
                        Exit Select
                End Select
                Exit Select
            Case &HA001 'Color space
                Select Case Convert.ToInt16(convertToInt16U(p.Value))
                    Case 1 : v = "sRGB"
                        Exit Select
                    Case 2 : v = "Adobe RGB"
                        Exit Select
                    Case Else
                        v = "UNKNOWN"
                        Exit Select
                End Select
                Exit Select
            Case Else
                v = convertToInt16U(p.Value).ToString()
        End Select
        Return v
    End Function

#End Region

#Region "Properties"

    ReadOnly Property Height() As String
        Get
            If Not Me.bmp Is Nothing Then
                Return Me.bmp.Height
            Else : Return ""
            End If
        End Get
    End Property

    ReadOnly Property Width() As String
        Get
            If Not Me.bmp Is Nothing Then
                Return Me.bmp.Width
            Else : Return ""
            End If
        End Get
    End Property

    ReadOnly Property Format() As String
        Get
            Dim bmpFormat As ImageFormat = bmp.RawFormat
            Dim strFormat As String = "unidentified format"

            If (bmpFormat.Equals(ImageFormat.Bmp)) Then
                strFormat = "BMP"
            ElseIf (bmpFormat.Equals(ImageFormat.Emf)) Then
                strFormat = "EMF"
            ElseIf (bmpFormat.Equals(ImageFormat.Exif)) Then
                strFormat = "EXIF"
            ElseIf (bmpFormat.Equals(ImageFormat.Gif)) Then
                strFormat = "GIF"
            ElseIf (bmpFormat.Equals(ImageFormat.Icon)) Then
                strFormat = "Icon"
            ElseIf (bmpFormat.Equals(ImageFormat.Jpeg)) Then
                strFormat = "JPEG"
            ElseIf (bmpFormat.Equals(ImageFormat.MemoryBmp)) Then
                strFormat = "MemoryBMP"
            ElseIf (bmpFormat.Equals(ImageFormat.Png)) Then
                strFormat = "PNG"
            ElseIf (bmpFormat.Equals(ImageFormat.Tiff)) Then
                strFormat = "TIFF"
            ElseIf (bmpFormat.Equals(ImageFormat.Wmf)) Then
                strFormat = "WMF"
            Else
                strFormat = "UNKNOWN"
            End If
            Return strFormat
        End Get

    End Property

    ReadOnly Property Resolution() As String
        Get
            Return bmp.HorizontalResolution
            'If myPropertyItems.ContainsKey("X Resolution") Then
            'Return myPropertyItems.Item("X Resolution")
            'Else : Return ""
            'End If
        End Get
    End Property

    ReadOnly Property BitsPerPixel() As String
        Get
            Select Case bmp.PixelFormat
                Case PixelFormat.Format16bppArgb1555, PixelFormat.Format16bppGrayScale, PixelFormat.Format16bppRgb555, PixelFormat.Format16bppRgb565 : Return "16"
                Case PixelFormat.Format1bppIndexed : Return "1"
                Case PixelFormat.Format24bppRgb : Return "24"
                Case PixelFormat.Format32bppArgb, PixelFormat.Format32bppPArgb, PixelFormat.Format32bppRgb : Return "32"
                Case PixelFormat.Format48bppRgb : Return "48"
                Case PixelFormat.Format8bppIndexed : Return "8"
                Case PixelFormat.Format4bppIndexed : Return "4"
                Case Else : Return ""
            End Select

        End Get
    End Property

    ReadOnly Property BitsPerSample() As String
        Get
            If myPropertyItems.ContainsKey("Bits Per Sample") Then
                Return myPropertyItems.Item("Bits Per Sample")
            Else : Return ""
            End If
        End Get
    End Property


    ReadOnly Property XResolution() As String
        Get
            If myPropertyItems.ContainsKey("X Resolution") Then
                Return myPropertyItems.Item("X Resolution")
            Else : Return ""
            End If
        End Get
    End Property

    ReadOnly Property YResolution() As String
        Get
            If myPropertyItems.ContainsKey("Y Resolution") Then
                Return myPropertyItems.Item("Y Resolution")
            Else : Return ""
            End If
        End Get
    End Property

    ReadOnly Property Orientation() As String
        Get
            If myPropertyItems.ContainsKey("Orientation") Then
                Return myPropertyItems.Item("Orientation")
            Else : Return ""
            End If
        End Get
    End Property

    ReadOnly Property Compression() As String
        Get
            If Format.Equals("JPEG") Then
                Return "JPEG"
            ElseIf myPropertyItems.ContainsKey("Compression") Then
                Return myPropertyItems.Item("Compression")
            Else
                Return ""
            End If
        End Get
    End Property

    ReadOnly Property ColorSpace() As String
        'Get
        '    If myPropertyItems.ContainsKey("ColorSpace") Then
        '        Return myPropertyItems.Item("ColorSpace")
        '    Else : Return ""
        '    End If
        'End Get

        Get
            Select Case bmp.PixelFormat
                Case PixelFormat.Format16bppArgb1555, PixelFormat.Format32bppArgb, _
                     PixelFormat.Format32bppPArgb : Return "ARGB"
                Case PixelFormat.Format16bppGrayScale : Return "Gray"
                Case PixelFormat.Format16bppRgb555, PixelFormat.Format24bppRgb, _
                     PixelFormat.Format16bppRgb565, PixelFormat.Format48bppRgb, _
                     PixelFormat.Format32bppRgb : Return "RGB"
                Case PixelFormat.Format8bppIndexed, _
                     PixelFormat.Format4bppIndexed : Return "Indexed"
                Case PixelFormat.Format1bppIndexed : Return "Black/White"
                Case Else : Return ""
            End Select

        End Get
    End Property

    ReadOnly Property FocalLength() As String
        Get
            If myPropertyItems.ContainsKey("FocalLength") Then
                Return myPropertyItems.Item("FocalLength")
            Else : Return ""
            End If
        End Get
    End Property

    ReadOnly Property FNumber() As String
        Get
            If myPropertyItems.ContainsKey("F-Number") Then
                Return myPropertyItems.Item("F-Number")
            Else : Return ""
            End If
        End Get
    End Property

    ReadOnly Property DateTime() As String
        Get
            If myPropertyItems.ContainsKey("Date Time") Then
                Return myPropertyItems.Item("Date Time")
            Else : Return ""
            End If
        End Get
    End Property

    ReadOnly Property ExposureTime() As String
        Get
            If myPropertyItems.ContainsKey("Exposure Time") Then
                Return myPropertyItems.Item("Exposure Time")
            Else : Return ""
            End If
        End Get
    End Property

#End Region

#Region "Conversion functions"

    Public Function ToStr() As String
        Return data
    End Function

    Private Function convertToInt32(ByVal arr As Byte()) As Integer
        If arr.Length <> 4 Then
            Return 0
        Else
            Return arr(3) << 24 Or arr(2) << 16 Or arr(1) << 8 Or arr(0)
        End If
    End Function

    Private Function convertToInt16(ByVal arr As Byte()) As Integer
        If arr.Length <> 2 Then
            Return 0
        Else
            Return arr(1) << 8 Or arr(0)
        End If
    End Function

    Private Function convertToInt32U(ByVal arr As Byte()) As UInt32
        If arr.Length <> 4 Then
            Return Convert.ToUInt32(0)
        Else
            Return Convert.ToUInt32(arr(3) << 24 Or arr(2) << 16 Or arr(1) << 8 Or arr(0))
        End If
    End Function

    Private Function convertToInt16U(ByVal arr As Byte()) As Integer 'UInt16
        If arr.Length <> 2 Then
            Return Convert.ToInt32(Convert.ToUInt16(0))
        Else
            Return Convert.ToInt32(Convert.ToUInt16(arr(1) << 8 Or arr(0)))
        End If
    End Function

    Public Overridable Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
        Return (New EXIFextractorEnumerator(Me.myPropertyItems))
    End Function

#End Region

End Class

#Region "Classe EXIFextractorEnumerator"

Public Class EXIFextractorEnumerator : Implements System.Collections.IEnumerator

    Dim exifTable As Hashtable
    Dim index As IDictionaryEnumerator

    Public Sub New(ByVal exif As Hashtable)
        Me.exifTable = exif
        Me.Reset()
        index = exif.GetEnumerator()
    End Sub


#Region "IEnumerator Members"

    Public Overridable Sub Reset() Implements IEnumerator.Reset
        Me.index = Nothing
    End Sub


    Public Overridable ReadOnly Property Current() As Object Implements IEnumerator.Current
        Get
            Return (New System.Web.UI.Pair(Me.index.Key, Me.index.Value))
        End Get
    End Property

    Public Overridable Function MoveNext() As Boolean Implements IEnumerator.MoveNext
        If Not index Is Nothing And index.MoveNext() Then
            Return True
        Else
            Return False
        End If
    End Function

#End Region

End Class

#End Region

#Region "Class Rational"

Public Class Rational
    Private n As Integer
    Private d As Integer

    Public Sub New(ByVal n As Integer, ByVal d As Integer)
        Me.n = n
        Me.d = d
        simplify(Me.n, Me.d)
    End Sub

    Public Sub New(ByVal n As UInt32, ByVal d As UInt32)
        Me.n = Convert.ToInt32(n)
        Me.d = Convert.ToInt32(d)
        simplify(Me.n, Me.d)
    End Sub

    Public Sub New()
        Me.n = Me.d = 0
    End Sub

    Public Function ToStr(ByVal sp As String) As String
        If sp Is Nothing Then
            sp = "/"
        End If
        Return n.ToString() + sp + d.ToString()
    End Function

    Public Function ToDouble() As Double
        If d = 0 Then
            Return 0.0
        End If
        Return Math.Round(Convert.ToDouble(n) / Convert.ToDouble(d), 2)
    End Function

    Private Sub simplify(ByVal a As Integer, ByVal b As Integer)
        If (a = 0 Or b = 0) Then
            Return
        End If
        Dim gcd As Integer = euclid(a, b)
        a = a / gcd
        b = b / gcd
    End Sub

    Private Function euclid(ByVal a As Integer, ByVal b As Integer) As Integer
        If (b = 0) Then
            Return a
        Else
            Return euclid(b, a Mod b)
        End If
    End Function

End Class

#End Region
