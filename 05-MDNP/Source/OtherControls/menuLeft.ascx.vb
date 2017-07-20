'Imports CRAVDataBaseAccess

Public Class uc_menuLeft
    Inherits BaseClassUC

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

    Public strUrlBasicSearch As String
    Public strUrlAdvancedSearch As String
    Public strUrlConsultationRequest As String
    Public strUrlReservationRequest As String
    Public strUrlReproductionRequest As String


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Me.Page.IsPostBack Then
            strUrlBasicSearch = ConfigurationManager.AppSettings("UrlBasicSearch")
            strUrlAdvancedSearch = ConfigurationManager.AppSettings("UrlAdvancedSearch")
            strUrlConsultationRequest = "http://" & Me.Context.Request.ServerVariables("HTTP_HOST") & "/" & ConfigurationManager.AppSettings("UrlConsultationRequest")
            strUrlReservationRequest = "http://" & Me.Context.Request.ServerVariables("HTTP_HOST") & "/" & ConfigurationManager.AppSettings("UrlReservationRequest")
            strUrlReproductionRequest = "http://" & Me.Context.Request.ServerVariables("HTTP_HOST") & "/" & ConfigurationManager.AppSettings("UrlReproductionRequest")
        End If
    End Sub

End Class
