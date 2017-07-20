Imports System.Resources
Imports System.Globalization
Imports System.Threading

Public Class BaseClassUC
    Inherits System.Web.UI.UserControl

    Private objRm As New ResourceManager("WebSearch2.res", System.Reflection.Assembly.GetExecutingAssembly)

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Dim strLanguage As String = Session("language")
        Thread.CurrentThread.CurrentUICulture = GetCultureInfo()
    End Sub

    Public Function GetCultureInfo() As System.Globalization.CultureInfo
        Dim strLanguage As String = Me.Session("language")
        If IsNothing(Session("language")) Then
            'strLanguage = ConfigurationSettings.AppSettings("DefaultLanguage")
            strLanguage = ConfigurationManager.AppSettings("DefaultLanguage")
        End If
        Return New CultureInfo(strLanguage)
    End Function


    '   get the session culture name
    Public Function GetCulture() As String
        Return Me.GetCultureInfo.Name
    End Function


    Public Function GetLabel(ByVal strLabel As String) As String
        Try
            Return objRm.GetString(strLabel)
        Catch ex As Exception
            Response.Write("<script language=javascript>window.alert('" & strLabel & " não traduzido!');</script>")
        End Try
    End Function


    Public Sub GetThread()
        Thread.CurrentThread.CurrentUICulture = GetCultureInfo()
    End Sub


    Public Function GetConfig(ByVal strKey As String) As String
        'Return ConfigurationSettings.AppSettings(strKey)
        Return ConfigurationManager.AppSettings(strKey)
    End Function


    Public Function TruncateUrl(ByVal url As String) As String
        Dim index As Integer = url.IndexOfAny("&")
        If index > 0 Then
            url = url.Remove(index, url.Length - index)
        End If
        Return url
    End Function

    Public Function RemoveQueryString(ByVal url As String, ByVal str As String, ByVal len As Integer) As String
        Dim index As Integer = url.IndexOf(str)
        If index > 0 Then
            url = url.Remove(index, len)
        End If
        Return url
    End Function


End Class
