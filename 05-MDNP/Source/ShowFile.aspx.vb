Imports System
Imports System.Drawing
Imports System.Drawing.Imaging

Imports System.IO

Public Class ShowFile
    Inherits System.Web.UI.Page


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Public myImageURL As String

    '*************************************************************************************
    ' Subroutine: Page_Load 
    ' Purpose: Loads the page that will browse the db image in a Jpg Format
    '*************************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim DOId As Int64 = CType(Request.QueryString("DOId"), Int64)
        Dim FileId As Int64 = CType(Request.QueryString("FileId"), Int64)
        Dim ImageType As Integer = Request.QueryString("imageType")

        Dim DOImage As New DOImage(DOId, FileId, DOImage.Capacities.Image, ImageType)
        Dim ContextCurrent As System.Web.HttpContext = System.Web.HttpContext.Current

        Dim ImageDraw() As Byte = DOImage.Image
        Dim imgToDraw As System.Drawing.Image
        Dim stream As New MemoryStream(ImageDraw)

        imgToDraw = imgToDraw.FromStream(stream)

        myImageURL = Me.Request.Url.ToString

        If Me.Request.QueryString("rotate") <> "" Then
            Dim rotate As RotateFlipType = CType(Request.QueryString("rotate"), RotateFlipType)
            imgToDraw.RotateFlip(rotate)
        End If

        Dim Format As Imaging.ImageFormat = imgToDraw.RawFormat
        Dim strContentType As String
        Dim Name() As String = DOImage.FileName.Split(".")
        Dim strFileName As String = Name(0)
        Session("OriginalImageHeight") = imgToDraw.Height

        strContentType = "image/jpeg"
        Format = Imaging.ImageFormat.Jpeg

        ContextCurrent.Response.ClearContent()
        ContextCurrent.Response.ContentType = strContentType
        ContextCurrent.Response.AppendHeader("Content-Disposition", _
        "inline; filename=""" & strFileName & """")
        imgToDraw.Save(ContextCurrent.Response.OutputStream, Format)

    End Sub

    Public Function GetImage(ByVal DOId As Int64, ByVal FileID As Int64) As System.Drawing.Image
        Dim DOImage As New DOImage(DOId, FileID, DOImage.Capacities.Image)
        Dim ImageDraw() As Byte = DOImage.Image
        Dim imgToDraw As System.Drawing.Image

        Dim stream As New MemoryStream(ImageDraw)

        imgToDraw = imgToDraw.FromStream(stream)
        Return imgToDraw
    End Function

End Class
