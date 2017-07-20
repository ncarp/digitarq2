
Public Class authorityRecord
    Inherits BaseClassUC

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblContent As System.Web.UI.WebControls.Label
    Protected WithEvents hlnkBackHeader As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hlnkBackFooter As System.Web.UI.WebControls.HyperLink

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

    Dim myPagenumber As Integer

    Property Pagenumber() As Integer

        Get
            Return myPagenumber
        End Get
        Set(ByVal Value As Integer)
            myPagenumber = Value
        End Set
    End Property


#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        'Dim strValues As String = Session("values")

        If Not Me.Page.IsPostBack Then
            Me.hlnkBackFooter.Text = GetLabel("WS.hlnkBack")
            Me.hlnkBackFooter.NavigateUrl = "javascript:history.back();"

            Dim FondsID As Integer = CInt(MyBase.Request.Params.Get("ID"))
            Dim result As New EAC(FondsID)

            lblContent.Text = result.toHtml
            Pagenumber = Session("pagenumber")
        End If
    End Sub

End Class
