Public Class horizontalMenu
    Inherits BaseClassUC

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents liBasicSearch As System.Web.UI.HtmlControls.HtmlControl
    Protected WithEvents liAdvancedSearch As System.Web.UI.HtmlControls.HtmlControl
    Protected WithEvents liHelp As System.Web.UI.HtmlControls.HtmlControl

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
        Dim mySearchMode As String = Me.Request.QueryString("searchMode")
        If Not Me.Page.IsPostBack Then
            Select Case mySearchMode
                Case "bs"
                    Me.liBasicSearch.Attributes.Add("class", "selected")
                Case "as"
                    Me.liAdvancedSearch.Attributes.Add("class", "selected")
                Case "hlp"
                    Me.liHelp.Attributes.Add("class", "selected")
                Case Else
                    Me.liBasicSearch.Attributes.Add("class", "selected")
            End Select
        End If
    End Sub

End Class
