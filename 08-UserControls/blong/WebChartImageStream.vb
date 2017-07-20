Option Strict On
Option Explicit On 

Imports System
Imports System.Web
Imports Microsoft.VisualBasic

Public Class WebChartImageStream
    Implements IHttpModule

    Friend Const HandlerFileName As String = "webchart_image_processor.aspx"
    Friend Const ChartNamePrefixInApplication As String = "C#H#R#"
    Public Delegate Sub WebChartEventHandler(ByVal s As Object, ByVal e As EventArgs)

    Public Sub Init(ByVal app As HttpApplication) Implements IHttpModule.Init
        AddHandler app.BeginRequest, AddressOf Me.OnBeginRequest
    End Sub

    Public Sub Dispose() Implements IHttpModule.Dispose
        'Required Implementation
    End Sub

    Public Event WebChartEvent As WebChartEventHandler

    Public Sub OnBeginRequest(ByVal s As Object, ByVal e As EventArgs)
        Dim webApp As HttpApplication = CType(s, HttpApplication)

        If InStr(webApp.Request.Path.ToLower, HandlerFileName, CompareMethod.Binary) <> 0 Then
            'Getting the WebChart object
            Dim webChartToDraw As WebChart = _
                CType(webApp.Application.Item(ChartNamePrefixInApplication & _
                CStr(webApp.Request.QueryString("id"))), WebChart)
            If webChartToDraw Is Nothing Then
                'WebChart was removed or not found 
                'Do nothing.  404 will be returned 
            Else
                Try
                    'Draw the WebChart to browser
                    With webChartToDraw
                        Dim memStream As System.IO.MemoryStream
                        memStream = .RenderWebChartImage()
                        memStream.WriteTo(webApp.Context.Response.OutputStream)
                        .Dispose()
                        memStream.Close()
                    End With
                    'Stream properties of the WebChart
                    With webApp
                        .Context.ClearError()
                        .Response.ContentType = webChartToDraw.HtmlContentType
                        .Response.StatusCode = 200
                        'Remove reference to WebChart
                        .Application.Remove(ChartNamePrefixInApplication & _
                            CStr(.Request.QueryString("id")))
                        .Response.End()
                    End With
                Catch WebChartException As Exception
                    'Error occurred
                End Try
            End If
        End If

    End Sub

End Class