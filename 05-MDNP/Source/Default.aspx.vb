Imports System.Web.Security

Public Class WSDefault
    Inherits BaseClassP

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Hyperlink1 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents pnlIntroduction As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlBasicSearch As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlAdvancedSearch As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlHelp As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlRegShow As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlListShow As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlBody As System.Web.UI.WebControls.Panel
    Protected WithEvents ltlTitle As System.Web.UI.WebControls.Literal
    Protected WithEvents lblTitleMenuLeft As System.Web.UI.WebControls.Label
    Protected WithEvents pnlLogin As System.Web.UI.WebControls.Panel
    Protected WithEvents lblTitleBody As System.Web.UI.WebControls.Label

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

        Dim x As System.Web.UI.Control

        Select Case Me.Request.QueryString("page")
            Case "basicSearch"
                x = Me.LoadControl("Controls/basicSearch.ascx")
            Case "advancedSearch"
                x = Me.LoadControl("Controls/advancedSearch.ascx")
            Case "help"
                x = Me.LoadControl("Controls/help.ascx")
            Case "listShow"
                x = Me.LoadControl("Controls/listShow.ascx")
            Case "regShow"
                x = Me.LoadControl("Controls/regShow.ascx")
            Case "authorityRecord"
                x = Me.LoadControl("Controls/authorityRecord.ascx")
            Case Else
                x = Me.LoadControl("Controls/introduction.ascx")
        End Select
        Me.ltlTitle.Text = GetLabel("WS.ltlTitle." & Me.Request.QueryString("page"))
        Me.pnlBody.Controls.Add(x)
    End Sub

End Class
