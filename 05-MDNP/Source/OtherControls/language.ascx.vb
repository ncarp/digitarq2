Public Class uc_language
    Inherits BaseClassUC

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents imgPt As System.Web.UI.WebControls.ImageButton
    Protected WithEvents imgEn As System.Web.UI.WebControls.ImageButton

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        If Not Me.Page.IsPostBack Then
            Me.imgPt.AlternateText = GetLabel("WS.language.pt-PT")
            Me.imgEn.AlternateText = GetLabel("WS.language.en-GB")

            If Session("language") = "" Then
                Me.imgPt.BorderStyle = BorderStyle.Solid
                Session("language") = ConfigurationManager.AppSettings("DefaultLanguage")
            Else
                Select Case Session("language")
                    Case "pt-PT"
                        Me.imgPt.BorderStyle = BorderStyle.Solid
                    Case "en-GB"
                        Me.imgEn.BorderStyle = BorderStyle.Solid
                End Select
            End If
        End If
    End Sub

    Private Sub imgEn_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgEn.Click
        Session("language") = "en-GB"
        Me.imgEn.BorderStyle = BorderStyle.Solid
        Dim url As String = Request.Url.ToString
        Me.Response.Redirect(url)
    End Sub

    Private Sub imgPt_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgPt.Click
        Session("language") = "pt-PT"
        Me.imgPt.BorderStyle = BorderStyle.Solid
        Dim url As String = Request.Url.ToString
        Me.Response.Redirect(url)
    End Sub
End Class
