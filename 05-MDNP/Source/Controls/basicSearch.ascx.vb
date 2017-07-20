Imports System.Data.SqlClient ' SQL Server Data Provider
Imports System.Object
Imports System.Collections.Hashtable

Public Class uc_basicSearch
    Inherits BaseClassUC

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtYearInitial As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Dropdownlist1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Dropdownlist2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblAlertText As System.Web.UI.WebControls.Label
    Protected WithEvents txtName As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLocal As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtOtherTerms As System.Web.UI.WebControls.TextBox
    Protected WithEvents txbYearInitial As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlMonthInitial As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlDayInitial As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txbYearFinal As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlMonthFinal As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlDayFinal As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnSearch As System.Web.UI.WebControls.Button
    Protected WithEvents lnkbSearch As System.Web.UI.WebControls.LinkButton
    Protected WithEvents cvDate As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents summary As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents revYearInitial As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents revYearFinal As System.Web.UI.WebControls.RegularExpressionValidator

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

        If Not Page.IsPostBack Then

            loadDdlDay(Me.ddlDayInitial)
            loadDdlDay(Me.ddlDayFinal)
            loadDdlMonth(Me.ddlMonthInitial)
            loadDdlMonth(Me.ddlMonthFinal)

            Me.cvDate.ErrorMessage = GetLabel("WS.BS.messageError1")
            Me.revYearInitial.ErrorMessage = GetLabel("WS.BS.emInvalidYearInitial")
            Me.revYearFinal.ErrorMessage = GetLabel("WS.BS.emInvalidYearFinal")

            Me.lnkbSearch.Text = GetLabel("WS.lnkbSearch")
            Me.lnkbSearch.ToolTip = GetLabel("WS.lnkbSearch")
        End If
    End Sub


    '*************************************************************************************
    ' Subroutine: ibtnSearch_Click - VB default name
    ' Purpose: It will be redirected to ListShow.aspx if the form has a valid content to search    
    '           in the digitarq DB.
    '*************************************************************************************
    Private Sub lnkbSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkbSearch.Click

        If Me.Page.IsValid Then
            Dim objBasicSearch As BasicSearch = hshCollectValues()
            Session("values") = strBdyQryBS(objBasicSearch)
            Session("Order") = "ASC"

            If Session("values") = "" Then
                lblAlertText.Text = GetLabel("WS.BS.messageError2")
            Else
                Response.Redirect("default.aspx?page=listShow&searchMode=bs&sort=id&order=ASC", True)
            End If
        End If
    End Sub


    Private Function hshCollectValues() As BasicSearch
        Dim objBasicSearch As New BasicSearch
        Dim objIntervaldates As New IntervalDates

        objIntervaldates.InitialYear = Me.txbYearInitial.Text
        objIntervaldates.InitialMonth = Me.ddlMonthInitial.SelectedValue
        objIntervaldates.InitialDay = Me.ddlDayInitial.SelectedItem.Text

        objIntervaldates.FinalYear = Me.txbYearFinal.Text
        objIntervaldates.FinalMonth = Me.ddlMonthFinal.SelectedValue
        objIntervaldates.FinalDay = Me.ddlDayFinal.SelectedItem.Text

        objBasicSearch.Name = Me.txtName.Text
        objBasicSearch.Local = Me.txtLocal.Text
        objBasicSearch.OtherTerms = Me.txtOtherTerms.Text
        objBasicSearch.IntervalDates = objIntervaldates

        Return objBasicSearch
    End Function

    Public Sub validateDate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Try
            If Me.txbYearInitial.Text <> "" And Me.txbYearFinal.Text <> "" Then
                args.IsValid = (CInt(Me.txbYearFinal.Text) >= CInt(Me.txbYearInitial.Text))
            End If
        Catch ex As Exception
            args.IsValid = False
        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        lnkbSearch_Click(sender, e)
    End Sub

End Class


