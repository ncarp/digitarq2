'Imports CRAVDataBaseAccess
'Imports GPU

Public Class header
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents hlnkInitialPage As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hlnkClose As System.Web.UI.WebControls.HyperLink
    Protected WithEvents lblUserName As System.Web.UI.WebControls.Label
    Protected WithEvents lblMsg As System.Web.UI.WebControls.Label

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
            Me.hlnkInitialPage.NavigateUrl = "../default.aspx?page=logout"
            Me.hlnkClose.NavigateUrl = "javascript:window.close();"

            'Dim objUser As User = Session("User")
            'If Not objUser Is Nothing And Me.Request.QueryString("page") <> "" Then
            '    Me.lblMsg.Text = GetLabel("FO.header.lblMsg")
            '    Me.lblUserName.Text = objUser.FullName
            'End If
        End If

    End Sub

End Class
