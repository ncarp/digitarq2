Option Strict On
Option Explicit On 

Imports System
Imports System.IO
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.DateTime
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.ComponentModel.Design.Serialization
Imports System.Globalization
Imports Microsoft.VisualBasic

' Assign Tag Prefix to WebControls
<Assembly: TagPrefix("blong.WebControls", "blong")> 

<DefaultProperty("Type"), _
ToolboxData("<{0}:WebChart runat=server></{0}:WebChart>"), _
ParseChildren(True, "WebChartItems"), ToolboxBitmapAttribute(GetType(Bitmap))> _
Public Class WebChart
    Inherits WebControl

#Region " Chart Constructors "

    Public Sub New()
        MyBase.New()
        Me.Font.Name = "Tahoma"
        Me.ForeColor = Color.Black
        Me.BackColor = Color.White
    End Sub

    Public Sub New(ByVal CopyRight As String)
        MyClass.New()
        mCopyright = CopyRight
    End Sub

    Public Sub New(ByVal Type As ChartType, ByVal ChartTitle As String)
        MyClass.New()
        mChartType = Type
        mChartTitle = ChartTitle
    End Sub

#End Region

#Region " Chart Rendering Methods "

    'Initial request for WebChart object
    Protected Overrides Sub Render(ByVal output As HtmlTextWriter)
        If Not Site Is Nothing AndAlso Site.DesignMode Then
            Dim sType As String
            If Type = ChartType.Bar Then sType = "Bar"
            If Type = ChartType.Pie Then sType = "Pie"

            output.Write("<font size='2' color='navy' face='arial'>[" & sType & " Chart: """ & Me.ID & """ ]</font><br>")
            output.Write("<font size='1'  color='SeaGreen' face='arial'>&nbsp;WebChart not visible in VS.NET designer!</font><br>")
        Else
            Dim WebSource As String = GenerateNameAndRegisterForCall()
            'Write relative URL for image stream request
            output.Write("<img src='" & WebChartImageStream.HandlerFileName & "?id=" & WebSource & "' border='0'></img><br>")
            MyClass.Dispose()
        End If
    End Sub

    'RenderWebChartImage() is called by <img> tag
    Public Function RenderWebChartImage() As MemoryStream
        Try
            If Site.DesignMode Then
                Dim sType As String
                If Type = ChartType.Bar Then sType = "Bar"
                If Type = ChartType.Pie Then sType = "Pie"
            End If
        Catch WebChartException As Exception
            'Not in design mode, return WebChart stream
            Select Case Type
                Case ChartType.Bar
                    RenderWebChartImage = makeBarChart()
                Case ChartType.Pie
                    RenderWebChartImage = makePieChart()
                Case Else
                    Exit Function
            End Select
            Return RenderWebChartImage
            MyClass.Dispose()
        End Try
    End Function

    'Generates a new name for this control & registers 
    'application level object
    Function GenerateNameAndRegisterForCall() As String
        Dim sControlName As String = System.Guid.NewGuid.ToString
        'Identifies requested WebChart image
        Me.Page.Application(WebChartImageStream.ChartNamePrefixInApplication & sControlName) = Me
        Return sControlName
    End Function

#End Region

#Region " Chart Enumerations "

    Public Enum LineStyle
        None
        Horizontal
        Numbered
        Both
    End Enum

    Public Enum ChartType
        Pie
        Bar
    End Enum

    Public Enum PieDiameter
        Smallest = 50
        Smaller = 100
        Small = 150
        Medium = 200
        Large = 250
        Larger = 350
        Largest = 450
    End Enum

    Public Enum PieThickness
        None = 0
        Wafer = 2
        Thin = 4
        Medium = 8
        Thick = 16
        Thickest = 32
    End Enum

    'Corresponds to System.Drawing.Imaging.ImageFormat
    Public Enum ChartFormat
        Gif
        Jpeg
        Png
        Bmp
    End Enum

#End Region

#Region " Chart Private Members and Events "

    'Chart data fields - All Types
    Private mWebChartItems As New WebChartItemCollection(Me)

    'Chart layout fields 
    Private mChartTitle As String = "Chart Title"
    Private mChartShowValues As Boolean = False
    Private mChartBarOutline As Boolean = True
    Private mChartShowTitle As Boolean = True
    Private mChartType As ChartType = ChartType.Bar
    Private mChartLineStyle As LineStyle = LineStyle.Both
    Private mChartPrimaryColor As Color = Color.DarkBlue
    Private mChartAltColor As Color = Color.CornflowerBlue
    Private mImageFormat As ChartFormat = ChartFormat.Gif
    Private mChartLegend As Boolean = True
    Private mPrimaryLabel As String = "Label A"
    Private mAltLabel As String = "Label B"

    'Exposed in overloaded constructor
    Private mCopyright As String = "Copyright © " & Today.Year.ToString & " YOU"

    'Chart data fields - Pie Chart
    Private mColorIndex As Int32 = 0
    Private mPieDiameter As PieDiameter = PieDiameter.Medium
    Private mPieRotation As Single = 70.0F
    Private mPieThickness As PieThickness = PieThickness.Medium
    Private mPieExplode As Boolean = False
    Private mPieExplodeOffset As Single = 25.0F

#End Region

#Region " Chart Public Properties "

    <Category("Chart Common"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), PersistenceMode(PersistenceMode.InnerDefaultProperty), Description("Supply data values for selected chart.")> _
    Public ReadOnly Property WebChartItems() As WebChartItemCollection
        Get
            If mWebChartItems Is Nothing Then
                mWebChartItems = New WebChartItemCollection(Me)
            End If
            Return mWebChartItems
        End Get
    End Property

    <DefaultValue("Primary"), Category("Chart Bar"), Description("Primary label for bar chart legend."), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Public Property LabelPrimary() As String
        Get
            Return mPrimaryLabel
        End Get
        Set(ByVal Value As String)
            If Value = String.Empty Then
                mPrimaryLabel = "Primary"
            Else
                mPrimaryLabel = Value
            End If
        End Set
    End Property

    <DefaultValue("Alternate"), Category("Chart Bar"), Description("Alternate label for bar chart legend."), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
   Public Property LabelAlternate() As String
        Get
            Return mAltLabel
        End Get
        Set(ByVal Value As String)
            If Value = String.Empty Then
                mAltLabel = "Alternate"
            Else
                mAltLabel = Value
            End If

        End Set
    End Property

    <Category("Chart Common"), DefaultValue("Chart Title"), Description("Title displayed on top of chart.")> _
    Public Property Title() As String
        Get
            Return mChartTitle
        End Get
        Set(ByVal Value As String)
            If Value <> String.Empty Then
                mChartTitle = Value
            Else
                mChartShowTitle = False
                mChartTitle = String.Empty
            End If
        End Set
    End Property

    <Category("Chart Common"), DefaultValue(True), Description("Show or hide chart title.")> _
    Public Property ShowTitle() As Boolean
        Get
            Return mChartShowTitle
        End Get
        Set(ByVal value As Boolean)
            If Title = String.Empty Then
                Throw New Exception("Title cannot be displayed as an empty value.")
                mChartShowTitle = False
            Else
                mChartShowTitle = value
            End If
        End Set
    End Property

    <Category("Chart Bar"), DefaultValue(False), Description("Show or hide chart numerical values.")> _
    Public Property ShowValues() As Boolean
        Get
            Return mChartShowValues
        End Get
        Set(ByVal value As Boolean)
            mChartShowValues = value
        End Set
    End Property

    <DefaultValue(GetType(ChartFormat), "Gif"), Category("Chart Common"), Description("Compression format for image.")> _
    Public Property Format() As ChartFormat
        Get
            Return mImageFormat
        End Get
        Set(ByVal Value As ChartFormat)
            mImageFormat = Value
        End Set
    End Property

    <DefaultValue(GetType(ChartType), "Bar"), Category("Chart Common"), Description("Type of chart to generate.")> _
    Public Property Type() As ChartType
        Get
            Return mChartType
        End Get
        Set(ByVal Value As ChartType)
            mChartType = Value
        End Set
    End Property

    <DefaultValue(GetType(LineStyle), "Both"), Category("Chart Bar"), Description("Show horizontal,numbered or no grid lines.")> _
    Public Property GridLines() As LineStyle
        Get
            Return mChartLineStyle
        End Get
        Set(ByVal Value As LineStyle)
            mChartLineStyle = Value
        End Set
    End Property

    <DefaultValue(GetType(Color), "DarkBlue"), Category("Chart Bar"), Description("Color of primary chart values.")> _
    Public Property ColorPrimary() As Color
        Get
            Return mChartPrimaryColor
        End Get
        Set(ByVal Value As Color)
            mChartPrimaryColor = Value
        End Set
    End Property

    <DefaultValue(GetType(Color), "CornFlowerBlue"), Category("Chart Bar"), Description("Color of alternate chart values.")> _
    Public Property ColorAlternate() As Color
        Get
            Return mChartAltColor
        End Get
        Set(ByVal Value As Color)
            mChartAltColor = Value
        End Set
    End Property

    <DefaultValue(True), Category("Chart Common"), Description("Show or hide chart legend.")> _
    Public Property ShowLegend() As Boolean
        Get
            Return mChartLegend
        End Get
        Set(ByVal Value As Boolean)
            mChartLegend = Value
        End Set
    End Property

    <DefaultValue(GetType(PieThickness), "Medium"), Category("Chart Pie"), Description("Thickness of 3D image.  Use none for 2D effect.")> _
    Public Property Thickness() As PieThickness
        Get
            Return mPieThickness
        End Get
        Set(ByVal Value As PieThickness)
            mPieThickness = Value
        End Set
    End Property

    <DefaultValue(25.0F), Category("Chart Pie"), Description("Offset value for exploded pie sections.")> _
    Public Property ExplodeOffset() As Single
        Get
            Return mPieExplodeOffset
        End Get
        Set(ByVal Value As Single)
            mPieExplodeOffset = Value
        End Set
    End Property

    <DefaultValue(GetType(PieDiameter), "Medium"), Category("Chart Pie"), Description("Total diameter of pie chart.")> _
    Public Property Diameter() As PieDiameter
        Get
            Return mPieDiameter
        End Get
        Set(ByVal Value As PieDiameter)
            mPieDiameter = Value
        End Set
    End Property

    <DefaultValue(70.0F), Category("Chart Pie"), Description("Rotate pie chart forward on Y-Axis.")> _
    Public Property Rotate() As Single
        Get
            Return mPieRotation
        End Get
        Set(ByVal Value As Single)
            mPieRotation = Value
        End Set
    End Property

    <DefaultValue(True), Category("Chart Bar"), Description("Outline charted bar values.")> _
    Public Property OutlineBars() As Boolean
        Get
            Return mChartBarOutline
        End Get
        Set(ByVal Value As Boolean)
            mChartBarOutline = Value
        End Set
    End Property

    <Browsable(False)> _
    Public ReadOnly Property HtmlContentType() As String
        Get
            Return "image/" & ChartFormat.GetName(GetType(ChartFormat), Me.Format).ToString.ToLower
        End Get
    End Property

#End Region

#Region " Chart Private Properties "

    Private Property CopyRight() As String
        Get
            Return mCopyright
        End Get
        Set(ByVal Value As String)
            mCopyright = Value
        End Set
    End Property

    'Pie Chart Properties
    Private ReadOnly Property PieColors() As Color()
        Get
            'Assign colors to array
            Dim mPieColors() As Color = _
            { _
            Color.FromArgb(204, 0, 0), _
            Color.FromArgb(204, 0, 255), _
            Color.FromArgb(204, 153, 255), _
            Color.FromArgb(51, 0, 153), _
            Color.FromArgb(51, 102, 153), _
            Color.FromArgb(102, 153, 255), _
            Color.FromArgb(51, 102, 0), _
            Color.FromArgb(51, 153, 0), _
            Color.FromArgb(51, 204, 0), _
            Color.FromArgb(255, 102, 0), _
            Color.FromArgb(255, 153, 0), _
            Color.FromArgb(255, 204, 0), _
            Color.FromArgb(255, 255, 0) _
            }
            Return mPieColors
        End Get
    End Property

#End Region

#Region " Chart Functions and Subroutines "

    Private Function getBarData() As CommonData
        Dim i As Int32
        Dim item As WebChartItem
        Dim barData As New CommonData()
        Dim barHeight As Single = 185
        Dim barWidth As Single
        Dim titleWidth, legendWidth As Single
        Dim HighVal As Single = 0.0

        'Determine high value for chart
        For Each item In WebChartItems
            If item.PrimaryValue > HighVal Then
                HighVal = item.PrimaryValue
            End If
            If item.AlternateValue > HighVal Then
                HighVal = item.AlternateValue
            End If
        Next

        For Each item In WebChartItems
            barWidth += 20
            If item.AlternateValue <> 0 Then
                barWidth += 10
            End If
        Next

        'Generate temp Graphics Object
        Dim tmpGraphics As Graphics = Graphics.FromImage(New Bitmap(1, 1))

        'Determine width of graph title
        If ShowTitle Then
            'Measure Title Width
            titleWidth = tmpGraphics.MeasureString(Title, New Font(Me.Font.Name, 14, FontStyle.Bold)).Width
            titleWidth += 40
        End If

        'Measure value left label width
        Dim maxValWidth, tmpLabelWidth As Single
        If GridLines = LineStyle.Both Or GridLines = LineStyle.Numbered Then
            For i = 0 To 100 Step 10
                tmpLabelWidth = tmpGraphics.MeasureString(CType(Math.Round((HighVal / 100 * i)), String), New Font(Me.Font.Name, 7)).Width
                If tmpLabelWidth > maxValWidth Then
                    maxValWidth = tmpLabelWidth
                End If
            Next
        End If

        'Calculate legend width
        If ShowLegend Then
            Dim tmpLabels As Single
            tmpLabels = tmpGraphics.MeasureString(LabelPrimary, New Font(Me.Font.Name, 7)).Width
            tmpLabels += tmpGraphics.MeasureString(LabelAlternate, New Font(Me.Font.Name, 7)).Width
            legendWidth = tmpLabels + 30
        End If

        tmpGraphics.Dispose()
        barWidth += maxValWidth + 15

        If titleWidth > barWidth Then
            barWidth = titleWidth
        Else
            If legendWidth > barWidth Then
                barWidth = legendWidth
            End If
        End If

        barWidth += 10

        With barData
            .imgHeight = barHeight
            .imgWidth = barWidth
            .valWidth = maxValWidth + 2
        End With

        Return barData
    End Function

    Private Function makeBarChart() As MemoryStream
        Dim i As Int32
        Dim barData As CommonData = getBarData()
        Dim Item As WebChartItem
        Dim HighVal As Single = 0.0
        Dim barHeight As Single = barData.imgHeight
        Dim barWidth As Single = barData.imgWidth

        'Determine high value for chart
        For Each Item In WebChartItems
            If Item.PrimaryValue > HighVal Then
                HighVal = Item.PrimaryValue
            End If
            If Item.AlternateValue > HighVal Then
                HighVal = Item.AlternateValue
            End If
        Next

        'Declare object variables
        Dim objBitMap As New Bitmap(CType(barWidth, Int32), CType(barHeight, Int32))
        Dim objGraphics As Graphics
        Dim rPrimary As Rectangle
        Dim bPrimary As Brush
        Dim rAlternate As Rectangle
        Dim bAlternate As Brush

        objGraphics = Graphics.FromImage(objBitMap)
        objGraphics.Clear(Me.BackColor)
        objGraphics.SmoothingMode = SmoothingMode.AntiAlias
        objGraphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit

        Dim fBrush As New SolidBrush(Me.ForeColor)
        Dim oPen As New Pen(Me.ForeColor)

        'Write out shaded graph title
        If ShowTitle Then
            objGraphics.DrawString(Title, New Font(Me.Font.Name, 14, FontStyle.Bold), Brushes.Gainsboro, New PointF((barData.valWidth + 1) / 2, 7))
            objGraphics.DrawString(Title, New Font(Me.Font.Name, 14, FontStyle.Bold), fBrush, New PointF(barData.valWidth / 2, 5))
        End If

        'Build Legend if specified
        If ShowLegend Then
            Dim blnAlternates As Boolean = False
            Dim pSymbol As PointF = New PointF(barData.valWidth + 10, barHeight - 40)
            Dim pSymbolDesc As PointF = New PointF(pSymbol.X + 12, pSymbol.Y)

            For Each Item In WebChartItems
                If Item.AlternateValue <> 0 Then
                    blnAlternates = True
                End If
            Next

            'Primary Symbol
            rPrimary = New Rectangle(CType(pSymbol.X, Int32), CType(pSymbol.Y, Int32), 10, 10)
            'No gradients for gif format
            If Format = ChartFormat.Gif Then
                bPrimary = New SolidBrush(ColorPrimary)
            Else
                bPrimary = New LinearGradientBrush(rPrimary, getLightColor(ColorPrimary, 55), getDarkColor(ColorPrimary, 55), LinearGradientMode.ForwardDiagonal)
            End If
            objGraphics.FillRectangle(bPrimary, rPrimary)
            objGraphics.DrawString(LabelPrimary, New Font(Me.Font.Name, 7), Brushes.Black, pSymbolDesc)
            'Primary Symbol Outline
            If OutlineBars Then
                Dim rPrimaryOutline As New Rectangle(CType(pSymbol.X, Int32), CType(pSymbol.Y, Int32), 10, 10)
                objGraphics.DrawRectangle(New Pen(Me.ForeColor), rPrimaryOutline)
            End If

            If blnAlternates Then
                'Estimate Coordinates for Alternate Symbol
                'MeasureString doesn't return accurate string width
                pSymbol.X += objGraphics.MeasureString(LabelPrimary, New Font(Me.Font.Name, 7)).ToPointF.X
                pSymbol.X += 20
                pSymbolDesc.X = pSymbol.X + 12

                'Alternate Symbol
                rAlternate = New Rectangle(CType(pSymbol.X, Int32), CType(pSymbol.Y, Int32), 10, 10)
                'No gradients for gif format
                If Format = ChartFormat.Gif Then
                    bAlternate = New SolidBrush(ColorAlternate)
                Else
                    bAlternate = New LinearGradientBrush(rAlternate, getLightColor(ColorAlternate, 55), getDarkColor(ColorAlternate, 55), LinearGradientMode.ForwardDiagonal)
                End If
                objGraphics.FillRectangle(bAlternate, rAlternate)
                objGraphics.DrawString(LabelAlternate, New Font(Me.Font.Name, 7), Brushes.Black, pSymbolDesc)
                'Alternate Symbol Outline
                If OutlineBars Then
                    Dim rAlternateOutline As New Rectangle(CType(pSymbol.X, Int32), CType(pSymbol.Y, Int32), 10, 10)
                    objGraphics.DrawRectangle(New Pen(Me.ForeColor), rAlternateOutline)
                End If
            End If
        End If

        'Draw major horizontal lines
        If GridLines <> LineStyle.None Then
            Dim gPen As New Pen(Color.Gainsboro)
            For i = 0 To 100 Step 10
                If GridLines = LineStyle.Horizontal Or GridLines = LineStyle.Both Then
                    'Horizontal lines
                    objGraphics.DrawLine( _
                                         gPen, _
                                         New Point(CType(barData.valWidth + 10, Int32), CType((barHeight - i) - 45, Int32)), _
                                         New Point(CType(barWidth - 10, Int32), CType((barHeight - i) - 45, Int32)) _
                                         )

                    'Vertical Left
                    objGraphics.DrawLine(gPen, _
                                         New Point(CType(barData.valWidth + 10, Int32), CType((barHeight - i) - 45, Int32)), _
                                         New Point(CType(barData.valWidth + 10, Int32), 40) _
                                         )
                    'Vertical Right
                    objGraphics.DrawLine(gPen, _
                                         New Point(CType(barWidth - 10, Int32), CType((barHeight - i) - 45, Int32)), _
                                         New Point(CType(barWidth - 10, Int32), 40) _
                                         )
                End If
                If GridLines = LineStyle.Numbered Or GridLines = LineStyle.Both Then
                    objGraphics.DrawString(CType(Math.Round((HighVal / 100 * i)), String), _
                                           New Font(Me.Font.Name, 7), _
                                           Brushes.Black, _
                                           New PointF(10, CType((barHeight - i) - 51, Int32)) _
                                           )
                End If
            Next
        End If

        'Loop through the values to create the Bar Chart.
        i = 0
        Dim bVal As New SolidBrush(Me.ForeColor)
        For Each Item In WebChartItems
            If Item.AlternateValue <> 0 Then
                Try
                    'Primary bar
                    rPrimary = New Rectangle _
                    ( _
                    CType((i * 30) + barData.valWidth + 20, Int32), CType((((HighVal - Item.PrimaryValue) / HighVal) * 100) + 40, Int32), _
                    10, CType(Math.Round((Item.PrimaryValue / HighVal) * 100), Int32) _
                    )
                    'No gradients for gif format
                    If Format = ChartFormat.Gif Then
                        bPrimary = New SolidBrush(ColorPrimary)
                    Else
                        bPrimary = New LinearGradientBrush(rPrimary, getLightColor(ColorPrimary, 55), getDarkColor(ColorPrimary, 55), LinearGradientMode.ForwardDiagonal)
                    End If
                    objGraphics.FillRectangle(bPrimary, rPrimary)
                    If ShowValues Then
                        objGraphics.DrawString(Item.PrimaryValue.ToString, New Font(Me.Font.Name, 6), bVal, New PointF((i * 30) + barData.valWidth + 20, (((HighVal - Item.PrimaryValue) / HighVal) * 100) + 30))
                    End If
                    'Primary Bar Outline
                    If OutlineBars Then
                        Dim rPrimaryOutline As New Rectangle _
                        ( _
                        CType((i * 30) + barData.valWidth + 20, Int32), CType((((HighVal - Item.PrimaryValue) / HighVal) * 100) + 40, Int32), _
                        10, CType(((Item.PrimaryValue / HighVal) * 100), Int32) _
                        )
                        objGraphics.DrawRectangle(oPen, rPrimaryOutline)
                    End If
                Catch
                    'Primary Bar - Negligable Scaled Value
                    Dim pPen As New Pen(Me.ColorPrimary)
                    Dim pX As Int32 = CType((i * 30) + barData.valWidth + 20, Int32)
                    Dim pY As Int32 = CType((((HighVal - Item.PrimaryValue) / HighVal) * 100) + 40, Int32)
                    objGraphics.DrawLine(pPen, pX, pY, pX + 10, pY)
                    If ShowValues Then
                        objGraphics.DrawString(Item.PrimaryValue.ToString, New Font(Me.Font.Name, 6), bVal, New PointF((i * 30) + barData.valWidth + 20, (((HighVal - Item.PrimaryValue) / HighVal) * 100) + 30))
                    End If
                End Try
                Try
                    'Alternate bar
                    rAlternate = New Rectangle _
                    ( _
                    CType((i * 30) + barData.valWidth + 25, Int32), CType((((HighVal - Item.AlternateValue) / HighVal) * 100) + 40, Int32), _
                    10, CType((Item.AlternateValue / HighVal) * 100, Int32) _
                    )
                    'No gradients for gif format
                    If Format = ChartFormat.Gif Then
                        bAlternate = New SolidBrush(ColorAlternate)
                    Else
                        bAlternate = New LinearGradientBrush(rAlternate, getLightColor(ColorAlternate, 55), getDarkColor(ColorAlternate, 55), LinearGradientMode.ForwardDiagonal)
                    End If
                    objGraphics.FillRectangle(bAlternate, rAlternate)
                    If ShowValues Then
                        objGraphics.DrawString(Item.AlternateValue.ToString, New Font(Me.Font.Name, 6), bVal, New PointF((i * 30) + barData.valWidth + 30, (((HighVal - Item.AlternateValue) / HighVal) * 100) + 30))
                    End If
                    'Alternate Bar Outline
                    If OutlineBars Then
                        Dim rAlternateOutline As New Rectangle( _
                        CType((i * 30) + barData.valWidth + 25, Int32), CType((((HighVal - Item.AlternateValue) / HighVal) * 100) + 40, Int32), _
                        10, CType(((Item.AlternateValue / HighVal) * 100), Int32) _
                        )
                        objGraphics.DrawRectangle(oPen, rAlternateOutline)
                    End If
                Catch
                    'Alternate Bar - Negligable Scaled Value
                    Dim aPen As New Pen(Me.ColorAlternate)
                    Dim aX As Int32 = CType((i * 30) + barData.valWidth + 25, Int32)
                    Dim aY As Int32 = CType((((HighVal - Item.AlternateValue) / HighVal) * 100) + 40, Int32)
                    objGraphics.DrawLine(aPen, aX, aY, aX + 10, aY)
                    If ShowValues Then
                        objGraphics.DrawString(Item.AlternateValue.ToString, New Font(Me.Font.Name, 6), bVal, New PointF((i * 30) + barData.valWidth + 30, (((HighVal - Item.AlternateValue) / HighVal) * 100) + 30))
                    End If
                End Try
            Else
                Try
                    'Primary bar
                    rPrimary = New Rectangle _
                    ( _
                    CType((i * 20) + barData.valWidth + 20, Int32), CType((((HighVal - Item.PrimaryValue) / HighVal) * 100) + 40, Int32), _
                    10, CType(Math.Round((Item.PrimaryValue / HighVal) * 100), Int32) _
                    )
                    'No gradients for gif format
                    If Format = ChartFormat.Gif Then
                        bPrimary = New SolidBrush(ColorPrimary)
                    Else
                        bPrimary = New LinearGradientBrush(rPrimary, getLightColor(ColorPrimary, 55), getDarkColor(ColorPrimary, 55), LinearGradientMode.ForwardDiagonal)
                    End If
                    objGraphics.FillRectangle(bPrimary, rPrimary)
                    If ShowValues Then
                        objGraphics.DrawString(Item.PrimaryValue.ToString, New Font(Me.Font.Name, 6), bVal, New PointF((i * 20) + barData.valWidth + 20, (((HighVal - Item.PrimaryValue) / HighVal) * 100) + 30))
                    End If
                    'Primary Bar Outline
                    If OutlineBars Then
                        Dim rPrimaryOutline As New Rectangle _
                        ( _
                        CType((i * 20) + barData.valWidth + 20, Int32), CType((((HighVal - Item.PrimaryValue) / HighVal) * 100) + 40, Int32), _
                        10, CType(((Item.PrimaryValue / HighVal) * 100), Int32) _
                        )
                        objGraphics.DrawRectangle(oPen, rPrimaryOutline)
                    End If
                Catch
                    'Primary Bar - Negligable Value
                    Dim pPen As New Pen(Me.ColorPrimary)
                    Dim pX As Int32 = CType((i * 20) + barData.valWidth + 20, Int32)
                    Dim pY As Int32 = CType((((HighVal - Item.PrimaryValue) / HighVal) * 100) + 40, Int32)
                    objGraphics.DrawLine(pPen, pX, pY, pX + 10, pY)
                    If ShowValues Then
                        objGraphics.DrawString(Item.PrimaryValue.ToString, New Font(Me.Font.Name, 6), bVal, New PointF((i * 20) + barData.valWidth + 20, (((HighVal - Item.PrimaryValue) / HighVal) * 100) + 30))
                    End If
                End Try
            End If
            i += 1
        Next

        'Draw Copyright info
        objGraphics.DrawString(CopyRight, New Font(Me.Font.Name, 7), Brushes.Silver, 10, barData.imgHeight - 15)
        'Copy WebChart to MemoryStream
        Dim memStream As New MemoryStream()
        objBitMap.Save(memStream, ImageFormat(Format))
        objBitMap.Dispose()
        objGraphics.Dispose()

        Return memStream
    End Function

    Private Function getPieData() As CommonData
        Dim pieData As New CommonData()
        Dim Item As WebChartItem
        Dim ChartElements As Int32 = WebChartItems.Count - 1
        Dim rPie As Rectangle()
        Dim bPie As Brush

        Dim i, ColorIndex As Int32
        Dim xShift, yShift, PercentVal, StartAngle, SweepAngle As Single()
        Dim CenterAngle, maxXS, maxYS, minXS, minYS As Single
        Dim Total As Single
        Dim Color As Color()

        'Resize local arrays
        ReDim rPie(ChartElements)
        ReDim xShift(ChartElements)
        ReDim yShift(ChartElements)
        ReDim StartAngle(ChartElements)
        ReDim SweepAngle(ChartElements)
        ReDim PercentVal(ChartElements)
        ReDim Color(ChartElements)

        'Loop through the values to create the Pie Chart.
        Dim Sum As Single = 0
        Dim sglCurrentAngle As Single = 0
        Dim sglTotalAngle As Single = 0

        'Sum of Primary Values
        For Each Item In WebChartItems
            Sum += Item.PrimaryValue
        Next

        'Calculate start, sweep, percent and color
        For Each Item In WebChartItems
            StartAngle(i) = CSng(Total)
            SweepAngle(i) = CSng((Item.PrimaryValue * 360) / Sum)
            PercentVal(i) = CSng(Math.Round((Item.PrimaryValue * 10000 / Sum) / 100, 2))
            Total += (Item.PrimaryValue * 360) / Sum
            If (ColorIndex + 1) >= PieColors.Length Then
                ColorIndex = 0
            End If
            Color(i) = PieColors(ColorIndex)
            ColorIndex += 1
            i += 1
        Next

        'Calculate Exploding Section
        For i = 0 To WebChartItems.Count - 1
            If WebChartItems(i).Explode = True Then
                CenterAngle = (StartAngle(i) + (SweepAngle(i) / 2)) * CSng(Math.PI) / 180
                xShift(i) = CSng(Math.Cos(CenterAngle)) * CSng(Diameter) * ExplodeOffset * 0.5F * 0.01F
                yShift(i) = CSng(Math.Sin(CenterAngle)) * CSng(Diameter) * Rotate * ExplodeOffset * 0.5F * 0.01F * 0.01F

                If (xShift(i) > maxXS) Then maxXS = xShift(i)
                If (yShift(i) > maxYS) Then maxYS = yShift(i)
                If (xShift(i) < minXS) Then minXS = xShift(i)
                If (yShift(i) < minYS) Then minYS = yShift(i)
            End If
        Next

        For i = 0 To WebChartItems.Count - 1
            If WebChartItems(i).Explode = True Then
                CenterAngle = (StartAngle(i) + (SweepAngle(i) / 2)) * CSng(Math.PI) / 180
                xShift(i) = CSng(Math.Cos(CenterAngle)) * CSng(Diameter) * ExplodeOffset * 0.5F * 0.01F
                yShift(i) = CSng(Math.Sin(CenterAngle)) * CSng(Diameter) * Rotate * ExplodeOffset * 0.5F * 0.01F * 0.01F

                If (xShift(i) > maxXS) Then maxXS = xShift(i)
                If (yShift(i) > maxYS) Then maxYS = yShift(i)
                If (xShift(i) < minXS) Then minXS = xShift(i)
                If (yShift(i) < minYS) Then minYS = yShift(i)
            Else
                xShift(i) = 0
                yShift(i) = 0
            End If
            ' Concentric circles
            rPie(i) = New Rectangle(CType(10 + xShift(i) - minXS, Int32), CType(40 + yShift(i) - minYS, Int32), _
                                 Diameter, CType(Diameter * Rotate * 0.01F, Int32))
        Next

        'Get size of image
        Dim imgHeight, imgWidth, imgLegendHeight As Single
        imgHeight = (CSng(Diameter) * (Rotate * 0.01F) + maxYS - minYS + 40 + 10 + CSng(Diameter) * CSng(Thickness) * 0.01F + 15)
        imgLegendHeight += CSng(ChartElements) * 15 + 75

        If imgLegendHeight > imgHeight And ShowLegend Then
            imgHeight = imgLegendHeight
        End If

        Dim tmpGraphics As Graphics = Graphics.FromImage(New Bitmap(1, 1))
        Dim maxNameWidth, maxValsWidth, maxPercWidth As Single
        Dim tmpNameWidth, tmpValsWidth, tmpPercWidth As Single

        i = 0
        For Each Item In WebChartItems
            tmpNameWidth = tmpGraphics.MeasureString(Item.PieLabel, New Font(Me.Font.Name, 7)).Width
            tmpValsWidth = tmpGraphics.MeasureString(CType(Item.PrimaryValue, String), New Font(Me.Font.Name, 7)).Width
            tmpPercWidth = tmpGraphics.MeasureString(PercentVal(i) & Space(5), New Font(Me.Font.Name, 7)).Width
            i += 1
        Next

        If tmpNameWidth > maxNameWidth Then maxNameWidth = tmpNameWidth
        If tmpValsWidth > maxValsWidth Then maxValsWidth = tmpValsWidth
        If tmpPercWidth > maxPercWidth Then maxPercWidth = tmpPercWidth

        imgWidth = CSng(Diameter) + ExplodeOffset + 20
        Dim pieWidth As Single = CSng(Diameter) + maxXS - minXS
        If ShowLegend Then
            imgWidth = (CType(pieWidth + 7 * 2.75 + _
                        12 + maxValsWidth + maxNameWidth + maxPercWidth + 35, Single))
        Else

        End If

        tmpGraphics.Dispose()

        With pieData
            .imgHeight = imgHeight
            .imgWidth = imgWidth
            .legendWidth = maxNameWidth
            .percentWidth = maxPercWidth
            .pieRect = rPie
            .pieWidth = pieWidth
            .valWidth = maxValsWidth
            .startAngle = StartAngle
            .sweepAngle = SweepAngle
            .percentVal = PercentVal
            .secColor = Color
        End With

        Return pieData
    End Function

    Private Function makePieChart() As MemoryStream
        Dim pieData As CommonData = getPieData()
        Dim Item As WebChartItem
        Dim ChartVals As Single = CType(WebChartItems.Count - 1, Int32)
        Dim objBitMap As New Bitmap(CType(pieData.imgWidth, Int32), CType(pieData.imgHeight, Int32), PixelFormat.Format24bppRgb)
        Dim objGraphics As Graphics
        Dim bPie As Brush


        'Pre-render
        objGraphics = Graphics.FromImage(objBitMap)
        objGraphics.Clear(Me.BackColor)
        objGraphics.SmoothingMode = SmoothingMode.AntiAlias
        objGraphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit

        Dim fBrush As New SolidBrush(Me.ForeColor)

        'Write out shaded graph title
        If ShowTitle Then
            objGraphics.DrawString(Title, New Font(Me.Font.Name, 14, FontStyle.Bold), Brushes.Gainsboro, New PointF(11, 7))
            objGraphics.DrawString(Title, New Font(Me.Font.Name, 14, FontStyle.Bold), fBrush, New PointF(10, 5))
        End If

        Dim pieRect As Rectangle
        Dim i As Int32 = 0
        Dim j As Int32 = 0

        'Concentric Circles for 3D depth
        If Thickness <> PieThickness.None Then
            For j = CInt(Diameter * Thickness * 0.01F) To 0 Step -1
                For i = 0 To WebChartItems.Count - 1
                    pieRect = New Rectangle(pieData.pieRect(i).X, _
                                       CInt(pieData.pieRect(i).Y + CSng(j)), _
                                       pieData.pieRect(i).Width, _
                                       pieData.pieRect(i).Height)
                    objGraphics.FillPie(New HatchBrush(HatchStyle.Percent50, _
                                        pieData.secColor(i)), pieRect, pieData.startAngle(i), pieData.sweepAngle(i))
                Next
            Next
        End If

        'Top Layer of Circle
        For j = CInt(Diameter * 0.01F) To 0 Step -1
            For i = 0 To WebChartItems.Count - 1
                pieRect = New Rectangle(pieData.pieRect(i).X, _
                                   CInt(pieData.pieRect(i).Y + CSng(j)), _
                                   pieData.pieRect(i).Width, _
                                   pieData.pieRect(i).Height)
                If Format = ChartFormat.Gif Then
                    bPie = New SolidBrush(pieData.secColor(i))
                Else
                    bPie = New LinearGradientBrush( _
                                                   pieRect, _
                                                   getLightColor(pieData.secColor(i), 55), _
                                                   getDarkColor(pieData.secColor(i), 55), _
                                                   LinearGradientMode.ForwardDiagonal _
                                                   )
                End If
                objGraphics.FillPie(bPie, pieRect, pieData.startAngle(i), pieData.sweepAngle(i))
            Next
        Next

        'Build Legend if specified
        If ShowLegend Then
            Dim rPrimary As Rectangle
            Dim bPrimary As Brush
            Dim pSymbol As PointF = New PointF(pieData.pieWidth + 40, 40)
            Dim pSymbolDesc As PointF = New PointF(pieData.pieWidth + 55, 40)
            i = 0 'Reset Counter
            For Each Item In WebChartItems
                'Primary Symbol
                rPrimary = New Rectangle(CType(pSymbol.X, Int32), CType(pSymbol.Y, Int32), 10, 10)
                If Format = ChartFormat.Gif Then
                    bPrimary = New SolidBrush(pieData.secColor(i))
                Else
                    bPrimary = New LinearGradientBrush(rPrimary, getLightColor(pieData.secColor(i), 55), getDarkColor(pieData.secColor(i), 55), LinearGradientMode.ForwardDiagonal)
                End If
                objGraphics.FillRectangle(bPrimary, rPrimary)
                objGraphics.DrawString(Item.PieLabel & " (" & pieData.percentVal(i) & "%)", New Font(Me.Font.Name, 7), Brushes.Black, pSymbolDesc)
                'Primary Symbol Outline
                If OutlineBars Then
                    Dim rPrimaryOutline As New Rectangle(CType(pSymbol.X, Int32), CType(pSymbol.Y, Int32), 10, 10)
                    objGraphics.DrawRectangle(New Pen(Me.ForeColor), rPrimaryOutline)
                End If
                pSymbol.Y += 15
                pSymbolDesc.Y += 15
                i += 1
            Next
        End If

        'Draw Copyright info
        objGraphics.DrawString(CopyRight, New Font(Me.Font.Name, 7), Brushes.Silver, 10, pieData.imgHeight - 15)
        'Copy WebChart to MemoryStream
        Dim memStream As New MemoryStream()
        objBitMap.Save(memStream, ImageFormat(Format))
        objBitMap.Dispose()
        objGraphics.Dispose()

        Return memStream
    End Function

    Private Function getDarkColor(ByVal c As Color, ByVal d As Byte) As Color
        Dim r As Byte = 0
        Dim g As Byte = 0
        Dim b As Byte = 0

        If (c.R > d) Then r = (c.R - d)
        If (c.G > d) Then g = (c.G - d)
        If (c.B > d) Then b = (c.B - d)

        Dim c1 As Color = Color.FromArgb(r, g, b)
        Return c1
    End Function

    Private Function getLightColor(ByVal c As Color, ByVal d As Byte) As Color
        Dim r As Byte = 255
        Dim g As Byte = 255
        Dim b As Byte = 255

        If (CInt(c.R) + CInt(d) <= 255) Then r = (c.R + d)
        If (CInt(c.G) + CInt(d) <= 255) Then g = (c.G + d)
        If (CInt(c.B) + CInt(d) <= 255) Then b = (c.B + d)

        Dim c2 As Color = Color.FromArgb(r, g, b)
        Return c2
    End Function

    Private Function ImageFormat(ByVal enumFormat As ChartFormat) As ImageFormat
        Dim imgFormat As ImageFormat
        Select Case enumFormat
            Case ChartFormat.Bmp
                imgFormat = ImageFormat.Bmp
            Case ChartFormat.Gif
                imgFormat = ImageFormat.Gif
            Case ChartFormat.Jpeg
                imgFormat = ImageFormat.Jpeg
            Case ChartFormat.Png
                imgFormat = ImageFormat.Png
            Case Else
                imgFormat = ImageFormat.Gif
        End Select
        Return imgFormat
    End Function

#End Region

End Class