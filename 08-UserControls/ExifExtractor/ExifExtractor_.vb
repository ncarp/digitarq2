' Source: 
' http://www.codeproject.com/csharp/exifextractor.asp 

' Add a .NET reference to the System.Web.dll to the project. 

Imports System
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Reflection
Imports System.IO
Imports System.Collections
Imports System.Text
Imports System.Web.UI

Public Class ExifExtractor_
    Implements IEnumerable

    ''' <summary> 
    ''' Get the individual property value by supplying property name 
    ''' These are the valid property names : 
    ''' 
    ''' "Exif IFD" 
    ''' "Gps IFD" 
    ''' "New Subfile Type" 
    ''' "Subfile Type" 
    ''' "Image Width" 
    ''' "Image Height" 
    ''' "Bits Per Sample" 
    ''' "Compression" 
    ''' "Photometric Interp" 
    ''' "Thresh Holding" 
    ''' "Cell Width" 
    ''' "Cell Height" 
    ''' "Fill Order" 
    ''' "Document Name" 
    ''' "Image Description" 
    ''' "Equip Make" 
    ''' "Equip Model" 
    ''' "Strip Offsets" 
    ''' "Orientation" 
    ''' "Samples PerPixel" 
    ''' "Rows Per Strip" 
    ''' "Strip Bytes Count" 
    ''' "Min Sample Value" 
    ''' "Max Sample Value" 
    ''' "X Resolution" 
    ''' "Y Resolution" 
    ''' "Planar Config" 
    ''' "Page Name" 
    ''' "X Position" 
    ''' "Y Position" 
    ''' "Free Offset" 
    ''' "Free Byte Counts" 
    ''' "Gray Response Unit" 
    ''' "Gray Response Curve" 
    ''' "T4 Option" 
    ''' "T6 Option" 
    ''' "Resolution Unit" 
    ''' "Page Number" 
    ''' "Transfer Funcition" 
    ''' "Software Used" 
    ''' "Date Time" 
    ''' "Artist" 
    ''' "Host Computer" 
    ''' "Predictor" 
    ''' "White Point" 
    ''' "Primary Chromaticities" 
    ''' "ColorMap" 
    ''' "Halftone Hints" 
    ''' "Tile Width" 
    ''' "Tile Length" 
    ''' "Tile Offset" 
    ''' "Tile ByteCounts" 
    ''' "InkSet" 
    ''' "Ink Names" 
    ''' "Number Of Inks" 
    ''' "Dot Range" 
    ''' "Target Printer" 
    ''' "Extra Samples" 
    ''' "Sample Format" 
    ''' "S Min Sample Value" 
    ''' "S Max Sample Value" 
    ''' "Transfer Range" 
    ''' "JPEG Proc" 
    ''' "JPEG InterFormat" 
    ''' "JPEG InterLength" 
    ''' "JPEG RestartInterval" 
    ''' "JPEG LosslessPredictors" 
    ''' "JPEG PointTransforms" 
    ''' "JPEG QTables" 
    ''' "JPEG DCTables" 
    ''' "JPEG ACTables" 
    ''' "YCbCr Coefficients" 
    ''' "YCbCr Subsampling" 
    ''' "YCbCr Positioning" 
    ''' "REF Black White" 
    ''' "ICC Profile" 
    ''' "Gamma" 
    ''' "ICC Profile Descriptor" 
    ''' "SRGB RenderingIntent" 
    ''' "Image Title" 
    ''' "Copyright" 
    ''' "Resolution X Unit" 
    ''' "Resolution Y Unit" 
    ''' "Resolution X LengthUnit" 
    ''' "Resolution Y LengthUnit" 
    ''' "Print Flags" 
    ''' "Print Flags Version" 
    ''' "Print Flags Crop" 
    ''' "Print Flags Bleed Width" 
    ''' "Print Flags Bleed Width Scale" 
    ''' "Halftone LPI" 
    ''' "Halftone LPIUnit" 
    ''' "Halftone Degree" 
    ''' "Halftone Shape" 
    ''' "Halftone Misc" 
    ''' "Halftone Screen" 
    ''' "JPEG Quality" 
    ''' "Grid Size" 
    ''' "Thumbnail Format" 
    ''' "Thumbnail Width" 
    ''' "Thumbnail Height" 
    ''' "Thumbnail ColorDepth" 
    ''' "Thumbnail Planes" 
    ''' "Thumbnail RawBytes" 
    ''' "Thumbnail Size" 
    ''' "Thumbnail CompressedSize" 
    ''' "Color Transfer Function" 
    ''' "Thumbnail Data" 
    ''' "Thumbnail ImageWidth" 
    ''' "Thumbnail ImageHeight" 
    ''' "Thumbnail BitsPerSample" 
    ''' "Thumbnail Compression" 
    ''' "Thumbnail PhotometricInterp" 
    ''' "Thumbnail ImageDescription" 
    ''' "Thumbnail EquipMake" 
    ''' "Thumbnail EquipModel" 
    ''' "Thumbnail StripOffsets" 
    ''' "Thumbnail Orientation" 
    ''' "Thumbnail SamplesPerPixel" 
    ''' "Thumbnail RowsPerStrip" 
    ''' "Thumbnail StripBytesCount" 
    ''' "Thumbnail ResolutionX" 
    ''' "Thumbnail ResolutionY" 
    ''' "Thumbnail PlanarConfig" 
    ''' "Thumbnail ResolutionUnit" 
    ''' "Thumbnail TransferFunction" 
    ''' "Thumbnail SoftwareUsed" 
    ''' "Thumbnail DateTime" 
    ''' "Thumbnail Artist" 
    ''' "Thumbnail WhitePoint" 
    ''' "Thumbnail PrimaryChromaticities" 
    ''' "Thumbnail YCbCrCoefficients" 
    ''' "Thumbnail YCbCrSubsampling" 
    ''' "Thumbnail YCbCrPositioning" 
    ''' "Thumbnail RefBlackWhite" 
    ''' "Thumbnail CopyRight" 
    ''' "Luminance Table" 
    ''' "Chrominance Table" 
    ''' "Frame Delay" 
    ''' "Loop Count" 
    ''' "Pixel Unit" 
    ''' "Pixel PerUnit X" 
    ''' "Pixel PerUnit Y" 
    ''' "Palette Histogram" 
    ''' "Exposure Time" 
    ''' "F-Number" 
    ''' "Exposure Prog" 
    ''' "Spectral Sense" 
    ''' "ISO Speed" 
    ''' "OECF" 
    ''' "Ver" 
    ''' "DTOrig" 
    ''' "DTDigitized" 
    ''' "CompConfig" 
    ''' "CompBPP" 
    ''' "Shutter Speed" 
    ''' "Aperture" 
    ''' "Brightness" 
    ''' "Exposure Bias" 
    ''' "MaxAperture" 
    ''' "SubjectDist" 
    ''' "Metering Mode" 
    ''' "LightSource" 
    ''' "Flash" 
    ''' "FocalLength" 
    ''' "Maker Note" 
    ''' "User Comment" 
    ''' "DTSubsec" 
    ''' "DTOrigSS" 
    ''' "DTDigSS" 
    ''' "FPXVer" 
    ''' "ColorSpace" 
    ''' "PixXDim" 
    ''' "PixYDim" 
    ''' "RelatedWav" 
    ''' "Interop" 
    ''' "FlashEnergy" 
    ''' "SpatialFR" 
    ''' "FocalXRes" 
    ''' "FocalYRes" 
    ''' "FocalResUnit" 
    ''' "Subject Loc" 
    ''' "Exposure Index" 
    ''' "Sensing Method" 
    ''' "FileSource" 
    ''' "SceneType" 
    ''' "CfaPattern" 
    ''' "Gps Ver" 
    ''' "Gps LatitudeRef" 
    ''' "Gps Latitude" 
    ''' "Gps LongitudeRef" 
    ''' "Gps Longitude" 
    ''' "Gps AltitudeRef" 
    ''' "Gps Altitude" 
    ''' "Gps GpsTime" 
    ''' "Gps GpsSatellites" 
    ''' "Gps GpsStatus" 
    ''' "Gps GpsMeasureMode" 
    ''' "Gps GpsDop" 
    ''' "Gps SpeedRef" 
    ''' "Gps Speed" 
    ''' "Gps TrackRef" 
    ''' "Gps Track" 
    ''' "Gps ImgDirRef" 
    ''' "Gps ImgDir" 
    ''' "Gps MapDatum" 
    ''' "Gps DestLatRef" 
    ''' "Gps DestLat" 
    ''' "Gps DestLongRef" 
    ''' "Gps DestLong" 
    ''' "Gps DestBearRef" 
    ''' "Gps DestBear" 
    ''' "Gps DestDistRef" 
    ''' "Gps DestDist" 
    ''' </summary> 
    Default Public ReadOnly Property Item(ByVal index As String) As Object
        Get
            Return _properties(index)
        End Get
    End Property

    Private _bitmap As Bitmap
    Private _data As String
    Private _myHash As Translation
    Private _properties As Hashtable
    Private _msp As String = ""
    Private _sp As String

    Friend ReadOnly Property Count() As Integer
        Get
            Return Me._properties.Count
        End Get
    End Property

    Public Sub SetTag(ByVal id As Integer, ByVal data As String)
        Dim ascii As Encoding = Encoding.ASCII
        Me.SetTag(id, data.Length, 2, ascii.GetBytes(data))
    End Sub

    Public Sub SetTag(ByVal id As Integer, ByVal len As Integer, ByVal type As Short, ByVal data As Byte())
        Dim p As PropertyItem = CreatePropertyItem(type, id, len, data)
        Me._bitmap.SetPropertyItem(p)
        BuildDatabase(Me._bitmap.PropertyItems)
    End Sub

    Private Shared Function CreatePropertyItem(ByVal type As Short, ByVal tag As Integer, ByVal len As Integer, ByVal value As Byte()) As PropertyItem
        ' Loads a PropertyItem from a Jpeg image stored in the assembly as a resource. 
        Dim ass As System.Reflection.Assembly = ass.GetExecutingAssembly()
        Dim emptyBitmapStream As Stream = ass.GetManifestResourceStream("EXIFextractor.decoy.jpg")
        Dim empty As Image = Image.FromStream(emptyBitmapStream)

        Dim item As PropertyItem = empty.PropertyItems(0)

        ' Copies the data to the property item. 
        item.Type = type
        item.Len = len
        item.Id = tag
        item.Value = New Byte(value.Length - 1) {}
        value.CopyTo(item.Value, 0)

        Return item
    End Function

    Public Sub New(ByRef bmp As Bitmap, ByVal sp As String)
        _properties = New Hashtable
        ' 
        Me._bitmap = bmp
        Me._sp = sp
        ' 
        _myHash = New Translation
        BuildDatabase(Me._bitmap.PropertyItems)
    End Sub

    Public Sub New(ByRef bmp As Bitmap, ByVal sp As String, ByVal msp As String)
        _properties = New Hashtable
        Me._sp = sp
        Me._msp = msp
        Me._bitmap = bmp
        ' 
        _myHash = New Translation

        Me.BuildDatabase(bmp.PropertyItems)
    End Sub
    Public Shared Function GetExifProperties(ByVal fileName As String) As PropertyItem()
        Dim stream As New FileStream(fileName, FileMode.Open, FileAccess.Read)
        Dim image As Image = image.FromStream(stream, True, False)
        Return image.PropertyItems
    End Function

    Public Sub New(ByVal file As String, ByVal sp As String, ByVal msp As String)
        _properties = New Hashtable
        Me._sp = sp
        Me._msp = msp

        _myHash = New Translation

        Me.BuildDatabase(GetExifProperties(file))
    End Sub

    Private Sub BuildDatabase(ByVal parr As PropertyItem())
        _properties.Clear()
        _data = ""
        Dim ascii As Encoding = Encoding.ASCII

        For Each p As System.Drawing.Imaging.PropertyItem In parr
            Dim v As String = ""
            Dim name As String = DirectCast(_myHash(p.Id), String)
            ' tag not found. skip it 
            If Not name Is Nothing Then
                _data += name + ": "
                ' 
                '1 = BYTE An 8-bit unsigned integer., 
                If p.Type = 1 Then
                    v = p.Value(0).ToString()
                ElseIf p.Type = 2 Then
                    '2 = ASCII An 8-bit byte containing one 7-bit ASCII code. The final byte is terminated with NULL., 
                    ' string 
                    v = ascii.GetString(p.Value)
                ElseIf p.Type = 3 Then
                    '3 = SHORT A 16-bit (2 -byte) unsigned integer, 
                    ' orientation // lookup table 
                    Select Case p.Id
                        Case 34855
                            ' ISO 
                            v = "ISO-" + convertToInt16U(p.Value).ToString()
                            Exit Select
                        Case 41495
                            ' sensing method 
                            Select Case Convert.ToInt16(convertToInt16U(p.Value))
                                Case 1
                                    v = "Not defined"
                                    Exit Select
                                Case 2
                                    v = "One-chip color area sensor"
                                    Exit Select
                                Case 3
                                    v = "Two-chip color area sensor"
                                    Exit Select
                                Case 4
                                    v = "Three-chip color area sensor"
                                    Exit Select
                                Case 5
                                    v = "Color sequential area sensor"
                                    Exit Select
                                Case 7
                                    v = "Trilinear sensor"
                                    Exit Select
                                Case 8
                                    v = "Color sequential linear sensor"
                                    Exit Select
                                Case Else
                                    v = " reserved"
                                    Exit Select
                            End Select
                            Exit Select
                        Case 34850
                            ' aperture 
                            Select Case Convert.ToInt16(convertToInt16U(p.Value))
                                Case 0
                                    v = "Not defined"
                                    Exit Select
                                Case 1
                                    v = "Manual"
                                    Exit Select
                                Case 2
                                    v = "Normal program"
                                    Exit Select
                                Case 3
                                    v = "Aperture priority"
                                    Exit Select
                                Case 4
                                    v = "Shutter priority"
                                    Exit Select
                                Case 5
                                    v = "Creative program (biased toward depth of field)"
                                    Exit Select
                                Case 6
                                    v = "Action program (biased toward fast shutter speed)"
                                    Exit Select
                                Case 7
                                    v = "Portrait mode (for closeup photos with the background out of focus)"
                                    Exit Select
                                Case 8
                                    v = "Landscape mode (for landscape photos with the background in focus)"
                                    Exit Select
                                Case Else
                                    v = "reserved"
                                    Exit Select
                            End Select
                            Exit Select
                        Case 37383
                            ' metering mode 
                            Select Case Convert.ToInt16(convertToInt16U(p.Value))
                                Case 0
                                    v = "unknown"
                                    Exit Select
                                Case 1
                                    v = "Average"
                                    Exit Select
                                Case 2
                                    v = "CenterWeightedAverage"
                                    Exit Select
                                Case 3
                                    v = "Spot"
                                    Exit Select
                                Case 4
                                    v = "MultiSpot"
                                    Exit Select
                                Case 5
                                    v = "Pattern"
                                    Exit Select
                                Case 6
                                    v = "Partial"
                                    Exit Select
                                Case 255
                                    v = "Other"
                                    Exit Select
                                Case Else
                                    v = "reserved"
                                    Exit Select
                            End Select
                            Exit Select
                        Case 37384
                            ' light source 
                            Select Case Convert.ToInt16(convertToInt16U(p.Value))
                                Case 0
                                    v = "unknown"
                                    Exit Select
                                Case 1
                                    v = "Daylight"
                                    Exit Select
                                Case 2
                                    v = "Fluorescent"
                                    Exit Select
                                Case 3
                                    v = "Tungsten"
                                    Exit Select
                                Case 17
                                    v = "Standard light A"
                                    Exit Select
                                Case 18
                                    v = "Standard light B"
                                    Exit Select
                                Case 19
                                    v = "Standard light C"
                                    Exit Select
                                Case 20
                                    v = "D55"
                                    Exit Select
                                Case 21
                                    v = "D65"
                                    Exit Select
                                Case 22
                                    v = "D75"
                                    Exit Select
                                Case 255
                                    v = "other"
                                    Exit Select
                                Case Else
                                    v = "reserved"
                                    Exit Select
                            End Select
                            Exit Select
                        Case 37385
                            Select Case Convert.ToInt16(convertToInt16U(p.Value))
                                Case 0
                                    v = "Flash did not fire"
                                    Exit Select
                                Case 1
                                    v = "Flash fired"
                                    Exit Select
                                Case 5
                                    v = "Strobe return light not detected"
                                    Exit Select
                                Case 7
                                    v = "Strobe return light detected"
                                    Exit Select
                                Case Else
                                    v = "reserved"
                                    Exit Select
                            End Select
                            Exit Select
                        Case Else
                            v = convertToInt16U(p.Value).ToString()
                            Exit Select
                    End Select
                ElseIf p.Type = 4 Then
                    '4 = LONG A 32-bit (4 -byte) unsigned integer, 
                    ' orientation // lookup table 
                    v = convertToInt32U(p.Value).ToString()
                ElseIf p.Type = 5 Then
                    '5 = RATIONAL Two LONGs. The first LONG is the numerator and the second LONG expresses the//denominator., 
                    ' rational 
                    Dim n As Byte() = New Byte(CInt(p.Len / 2 - 1)) {}
                    Dim d As Byte() = New Byte(CInt(p.Len / 2 - 1)) {}
                    Array.Copy(p.Value, 0, n, 0, CLng(p.Len / 2))
                    Array.Copy(p.Value, CLng(p.Len / 2), d, 0, CLng(p.Len / 2))
                    Dim a As UInt32 = convertToInt32U(n)
                    Dim b As UInt32 = convertToInt32U(d)
                    Dim r As New Rational(a, b)
                    ' 
                    'convert here 
                    ' 
                    Select Case p.Id
                        Case 37378
                            ' aperture 
                            v = "F/" + Math.Round(Math.Pow(Math.Sqrt(2), r.ToDouble()), 2).ToString()
                            Exit Select
                        Case 37386
                            v = r.ToDouble().ToString()
                            Exit Select
                        Case 33434
                            v = r.ToDouble().ToString()
                            Exit Select
                        Case 33437
                            ' F-number 
                            v = "F/" + r.ToDouble().ToString()
                            Exit Select
                        Case Else
                            v = r.ToStr("/")
                            Exit Select

                    End Select
                ElseIf p.Type = 7 Then
                    '7 = UNDEFINED An 8-bit byte that can take any value depending on the field definition, 
                    Select Case p.Id
                        Case 41728
                            If p.Value(0) = 3 Then
                                v = "DSC"
                            Else
                                v = "reserved"
                            End If
                            Exit Select
                        Case 41729
                            If p.Value(0) = 1 Then
                                v = "A directly photographed image"
                            Else
                                v = "Not a directly photographed image"
                            End If
                            Exit Select
                        Case Else
                            v = "-"
                            Exit Select
                    End Select
                ElseIf p.Type = 9 Then
                    '9 = SLONG A 32-bit (4 -byte) signed integer (2's complement notation), 
                    v = convertToInt32(p.Value).ToString()
                ElseIf p.Type = 10 Then
                    '10 = SRATIONAL Two SLONGs. The first SLONG is the numerator and the second SLONG is the 
                    'denominator. 

                    ' rational 
                    Dim n As Byte() = New Byte(CInt(p.Len / 2 - 1)) {}
                    Dim d As Byte() = New Byte(CInt(p.Len / 2 - 1)) {}
                    Array.Copy(p.Value, 0, n, 0, CLng(p.Len / 2))
                    Array.Copy(p.Value, CLng(p.Len / 2), d, 0, CLng(p.Len / 2))
                    Dim a As Integer = convertToInt32(n)
                    Dim b As Integer = convertToInt32(d)
                    Dim r As New Rational(a, b)
                    ' 
                    ' convert here 
                    ' 
                    Select Case p.Id
                        Case 37377
                            ' shutter speed 
                            v = "1/" + Math.Round(Math.Pow(2, r.ToDouble()), 2).ToString()
                            Exit Select
                        Case 37379
                            v = Math.Round(r.ToDouble(), 4).ToString()
                            Exit Select
                        Case Else
                            v = r.ToStr("/")
                            Exit Select
                    End Select
                End If
                ' add it to the list 
                If _properties(name) Is Nothing Then
                    _properties.Add(name, v)
                End If
                ' cat it too 
                _data += v
                _data += Me._sp

            End If
            ' 
        Next

    End Sub

    Public Function ToStr(ByVal str As String) As String
        Return _data
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

    Private Function convertToInt16U(ByVal arr As Byte()) As UInt16
        If arr.Length <> 2 Then
            Return Convert.ToUInt16(0)
        Else
            Return Convert.ToUInt16(arr(1) << 8 Or arr(0))
        End If
    End Function

    Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
        Return (New EXIFextractorEnumerator(Me._properties))
    End Function

End Class

Public Class EXIFextractorEnumerator
    Implements IEnumerator

    Private exifTable As Hashtable
    Private index As IDictionaryEnumerator

    Friend Sub New(ByVal exif As Hashtable)
        Me.exifTable = exif
        Me.Reset()
        index = exif.GetEnumerator()
    End Sub

#Region "IEnumerator Members"

    Public Sub Reset() Implements IEnumerator.Reset
        Me.index = Nothing
    End Sub

    Public ReadOnly Property Current() As Object Implements IEnumerator.Current
        Get
            Return (New Pair(Me.index.Key, Me.index.Value))
        End Get
    End Property

    Public Function MoveNext() As Boolean Implements IEnumerator.MoveNext
        If Not index Is Nothing AndAlso index.MoveNext() Then
            Return True
        Else
            Return False
        End If
    End Function

#End Region

End Class

Public Class Translation_
    Inherits Hashtable
    ''' <summary> 
    ''' 
    ''' </summary> 
    Public Sub New()
        Me.Add(34665, "Exif IFD")
        Me.Add(34853, "Gps IFD")
        Me.Add(254, "New Subfile Type")
        Me.Add(255, "Subfile Type")
        Me.Add(256, "Image Width")
        Me.Add(257, "Image Height")
        Me.Add(258, "Bits Per Sample")
        Me.Add(259, "Compression")
        Me.Add(262, "Photometric Interp")
        Me.Add(263, "Thresh Holding")
        Me.Add(264, "Cell Width")
        Me.Add(265, "Cell Height")
        Me.Add(266, "Fill Order")
        Me.Add(269, "Document Name")
        Me.Add(270, "Image Description")
        Me.Add(271, "Equip Make")
        Me.Add(272, "Equip Model")
        Me.Add(273, "Strip Offsets")
        Me.Add(274, "Orientation")
        Me.Add(277, "Samples PerPixel")
        Me.Add(278, "Rows Per Strip")
        Me.Add(279, "Strip Bytes Count")
        Me.Add(280, "Min Sample Value")
        Me.Add(281, "Max Sample Value")
        Me.Add(282, "X Resolution")
        Me.Add(283, "Y Resolution")
        Me.Add(284, "Planar Config")
        Me.Add(285, "Page Name")
        Me.Add(286, "X Position")
        Me.Add(287, "Y Position")
        Me.Add(288, "Free Offset")
        Me.Add(289, "Free Byte Counts")
        Me.Add(290, "Gray Response Unit")
        Me.Add(291, "Gray Response Curve")
        Me.Add(292, "T4 Option")
        Me.Add(293, "T6 Option")
        Me.Add(296, "Resolution Unit")
        Me.Add(297, "Page Number")
        Me.Add(301, "Transfer Funcition")
        Me.Add(305, "Software Used")
        Me.Add(306, "Date Time")
        Me.Add(315, "Artist")
        Me.Add(316, "Host Computer")
        Me.Add(317, "Predictor")
        Me.Add(318, "White Point")
        Me.Add(319, "Primary Chromaticities")
        Me.Add(320, "ColorMap")
        Me.Add(321, "Halftone Hints")
        Me.Add(322, "Tile Width")
        Me.Add(323, "Tile Length")
        Me.Add(324, "Tile Offset")
        Me.Add(325, "Tile ByteCounts")
        Me.Add(332, "InkSet")
        Me.Add(333, "Ink Names")
        Me.Add(334, "Number Of Inks")
        Me.Add(336, "Dot Range")
        Me.Add(337, "Target Printer")
        Me.Add(338, "Extra Samples")
        Me.Add(339, "Sample Format")
        Me.Add(340, "S Min Sample Value")
        Me.Add(341, "S Max Sample Value")
        Me.Add(342, "Transfer Range")
        Me.Add(512, "JPEG Proc")
        Me.Add(513, "JPEG InterFormat")
        Me.Add(514, "JPEG InterLength")
        Me.Add(515, "JPEG RestartInterval")
        Me.Add(517, "JPEG LosslessPredictors")
        Me.Add(518, "JPEG PointTransforms")
        Me.Add(519, "JPEG QTables")
        Me.Add(520, "JPEG DCTables")
        Me.Add(521, "JPEG ACTables")
        Me.Add(529, "YCbCr Coefficients")
        Me.Add(530, "YCbCr Subsampling")
        Me.Add(531, "YCbCr Positioning")
        Me.Add(532, "REF Black White")
        Me.Add(34675, "ICC Profile")
        Me.Add(769, "Gamma")
        Me.Add(770, "ICC Profile Descriptor")
        Me.Add(771, "SRGB RenderingIntent")
        Me.Add(800, "Image Title")
        Me.Add(33432, "Copyright")
        Me.Add(20481, "Resolution X Unit")
        Me.Add(20482, "Resolution Y Unit")
        Me.Add(20483, "Resolution X LengthUnit")
        Me.Add(20484, "Resolution Y LengthUnit")
        Me.Add(20485, "Print Flags")
        Me.Add(20486, "Print Flags Version")
        Me.Add(20487, "Print Flags Crop")
        Me.Add(20488, "Print Flags Bleed Width")
        Me.Add(20489, "Print Flags Bleed Width Scale")
        Me.Add(20490, "Halftone LPI")
        Me.Add(20491, "Halftone LPIUnit")
        Me.Add(20492, "Halftone Degree")
        Me.Add(20493, "Halftone Shape")
        Me.Add(20494, "Halftone Misc")
        Me.Add(20495, "Halftone Screen")
        Me.Add(20496, "JPEG Quality")
        Me.Add(20497, "Grid Size")
        Me.Add(20498, "Thumbnail Format")
        Me.Add(20499, "Thumbnail Width")
        Me.Add(20500, "Thumbnail Height")
        Me.Add(20501, "Thumbnail ColorDepth")
        Me.Add(20502, "Thumbnail Planes")
        Me.Add(20503, "Thumbnail RawBytes")
        Me.Add(20504, "Thumbnail Size")
        Me.Add(20505, "Thumbnail CompressedSize")
        Me.Add(20506, "Color Transfer Function")
        Me.Add(20507, "Thumbnail Data")
        Me.Add(20512, "Thumbnail ImageWidth")
        Me.Add(1282, "Thumbnail ImageHeight")
        Me.Add(20514, "Thumbnail BitsPerSample")
        Me.Add(20515, "Thumbnail Compression")
        Me.Add(20516, "Thumbnail PhotometricInterp")
        Me.Add(20517, "Thumbnail ImageDescription")
        Me.Add(20518, "Thumbnail EquipMake")
        Me.Add(20519, "Thumbnail EquipModel")
        Me.Add(20520, "Thumbnail StripOffsets")
        Me.Add(20521, "Thumbnail Orientation")
        Me.Add(20522, "Thumbnail SamplesPerPixel")
        Me.Add(20523, "Thumbnail RowsPerStrip")
        Me.Add(20524, "Thumbnail StripBytesCount")
        Me.Add(20525, "Thumbnail ResolutionX")
        Me.Add(20526, "Thumbnail ResolutionY")
        Me.Add(20527, "Thumbnail PlanarConfig")
        Me.Add(20528, "Thumbnail ResolutionUnit")
        Me.Add(20529, "Thumbnail TransferFunction")
        Me.Add(20530, "Thumbnail SoftwareUsed")
        Me.Add(20531, "Thumbnail DateTime")
        Me.Add(20532, "Thumbnail Artist")
        Me.Add(20533, "Thumbnail WhitePoint")
        Me.Add(20534, "Thumbnail PrimaryChromaticities")
        Me.Add(20535, "Thumbnail YCbCrCoefficients")
        Me.Add(20536, "Thumbnail YCbCrSubsampling")
        Me.Add(20537, "Thumbnail YCbCrPositioning")
        Me.Add(20538, "Thumbnail RefBlackWhite")
        Me.Add(20539, "Thumbnail CopyRight")
        Me.Add(20624, "Luminance Table")
        Me.Add(20625, "Chrominance Table")
        Me.Add(20736, "Frame Delay")
        Me.Add(20737, "Loop Count")
        Me.Add(20752, "Pixel Unit")
        Me.Add(20753, "Pixel PerUnit X")
        Me.Add(20754, "Pixel PerUnit Y")
        Me.Add(20755, "Palette Histogram")
        Me.Add(33434, "Exposure Time")
        Me.Add(33437, "F-Number")
        Me.Add(34850, "Exposure Prog")
        Me.Add(34852, "Spectral Sense")
        Me.Add(34855, "ISO Speed")
        Me.Add(34856, "OECF")
        Me.Add(36864, "Ver")
        Me.Add(36867, "DTOrig")
        Me.Add(36868, "DTDigitized")
        Me.Add(37121, "CompConfig")
        Me.Add(37122, "CompBPP")
        Me.Add(37377, "Shutter Speed")
        Me.Add(37378, "Aperture")
        Me.Add(37379, "Brightness")
        Me.Add(37380, "Exposure Bias")
        Me.Add(37381, "MaxAperture")
        Me.Add(37382, "SubjectDist")
        Me.Add(37383, "Metering Mode")
        Me.Add(37384, "LightSource")
        Me.Add(37385, "Flash")
        Me.Add(37386, "FocalLength")
        Me.Add(37500, "Maker Note")
        Me.Add(37510, "User Comment")
        Me.Add(37520, "DTSubsec")
        Me.Add(37521, "DTOrigSS")
        Me.Add(37522, "DTDigSS")
        Me.Add(40960, "FPXVer")
        Me.Add(40961, "ColorSpace")
        Me.Add(40962, "PixXDim")
        Me.Add(40963, "PixYDim")
        Me.Add(40964, "RelatedWav")
        Me.Add(40965, "Interop")
        Me.Add(41483, "FlashEnergy")
        Me.Add(41484, "SpatialFR")
        Me.Add(41486, "FocalXRes")
        Me.Add(41487, "FocalYRes")
        Me.Add(41488, "FocalResUnit")
        Me.Add(41492, "Subject Loc")
        Me.Add(41493, "Exposure Index")
        Me.Add(41495, "Sensing Method")
        Me.Add(41728, "FileSource")
        Me.Add(41729, "SceneType")
        Me.Add(41730, "CfaPattern")
        Me.Add(0, "Gps Ver")
        Me.Add(1, "Gps LatitudeRef")
        Me.Add(2, "Gps Latitude")
        Me.Add(3, "Gps LongitudeRef")
        Me.Add(4, "Gps Longitude")
        Me.Add(5, "Gps AltitudeRef")
        Me.Add(6, "Gps Altitude")
        Me.Add(7, "Gps GpsTime")
        Me.Add(8, "Gps GpsSatellites")
        Me.Add(9, "Gps GpsStatus")
        Me.Add(10, "Gps GpsMeasureMode")
        Me.Add(11, "Gps GpsDop")
        Me.Add(12, "Gps SpeedRef")
        Me.Add(13, "Gps Speed")
        Me.Add(14, "Gps TrackRef")
        Me.Add(15, "Gps Track")
        Me.Add(16, "Gps ImgDirRef")
        Me.Add(17, "Gps ImgDir")
        Me.Add(18, "Gps MapDatum")
        Me.Add(19, "Gps DestLatRef")
        Me.Add(20, "Gps DestLat")
        Me.Add(21, "Gps DestLongRef")
        Me.Add(22, "Gps DestLong")
        Me.Add(23, "Gps DestBearRef")
        Me.Add(24, "Gps DestBear")
        Me.Add(25, "Gps DestDistRef")
        Me.Add(26, "Gps DestDist")
    End Sub
End Class

''' <summary> 
''' private class 
''' </summary> 
Friend Class Rational_
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
        Me.n = CInt(Me.d = 0)
    End Sub

    Public Shadows Function ToString(ByVal sp As String) As String
        If sp Is Nothing Then
            sp = "/"
        End If
        Return n.ToString() + sp + d.ToString()
    End Function

    Public Function ToDouble() As Double
        If d = 0 Then
            Return 0
        End If

        Return Math.Round(Convert.ToDouble(n) / Convert.ToDouble(d), 2)
    End Function

    Private Sub simplify(ByRef a As Integer, ByRef b As Integer)
        If a = 0 OrElse b = 0 Then
            Return
        End If

        Dim gcd As Integer = euclid(a, b)
        a = CInt(a / gcd)
        b = CInt(b / gcd)
    End Sub

    Private Function euclid(ByVal a As Integer, ByVal b As Integer) As Integer
        If b = 0 Then
            Return a
        Else
            Return euclid(b, a Mod b)
        End If
    End Function

End Class

