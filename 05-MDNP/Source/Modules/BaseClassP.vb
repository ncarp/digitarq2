Imports System.Resources
Imports System.Globalization
Imports System.Threading

Public Class BaseClassP
    Inherits System.Web.UI.Page

    Private objRm As New ResourceManager("WebSearch2.res", System.Reflection.Assembly.GetExecutingAssembly)

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
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
            Dim erro As String = ex.ToString
            Me.Page.RegisterStartupScript("xx", "<script language=javascript>window.alert('" & strLabel & " não traduzido!');</script>")
        End Try

    End Function


    Public Sub GetThread()
        Thread.CurrentThread.CurrentUICulture = GetCultureInfo()
    End Sub

End Class
