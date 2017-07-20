Imports System.Data.SqlClient ' SQL Server Data Provider
Imports System.Object
Imports System.Collections.Hashtable


Public Class uc_advancedSearch
    Inherits BaseClassUC

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txbYearInitial As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlMonthInitial As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlDayInitial As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txbYearFinal As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlMonthFinal As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlDayFinal As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Img As System.Web.UI.WebControls.CheckBox
    Protected WithEvents lblAlertText As System.Web.UI.WebControls.Label
    Protected WithEvents ddlControlAccessTypes As System.Web.UI.WebControls.DropDownList
    Protected WithEvents summary As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents cvDate As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents lnkbSearch As System.Web.UI.WebControls.LinkButton
    Protected WithEvents cvCkbList As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents txbCompleteUnitId As System.Web.UI.WebControls.TextBox
    Protected WithEvents txbPartUnitId As System.Web.UI.WebControls.TextBox
    Protected WithEvents txbAndUnitTitle As System.Web.UI.WebControls.TextBox
    Protected WithEvents txbExactPhraseUnitTitle As System.Web.UI.WebControls.TextBox
    Protected WithEvents txbOrUnitTitle As System.Web.UI.WebControls.TextBox
    Protected WithEvents txbNotUnitTitle As System.Web.UI.WebControls.TextBox
    Protected WithEvents txbAndAuthorDestination As System.Web.UI.WebControls.TextBox
    Protected WithEvents txbExactPhraseAuthorDestination As System.Web.UI.WebControls.TextBox
    Protected WithEvents txbOrAuthorDestination As System.Web.UI.WebControls.TextBox
    Protected WithEvents txbNotAuthorDestination As System.Web.UI.WebControls.TextBox
    Protected WithEvents txbAndGeogLocal As System.Web.UI.WebControls.TextBox
    Protected WithEvents txbExactPhraseGeogLocal As System.Web.UI.WebControls.TextBox
    Protected WithEvents txbOrGeogLocal As System.Web.UI.WebControls.TextBox
    Protected WithEvents txbNotGeogLocal As System.Web.UI.WebControls.TextBox
    Protected WithEvents txbAndKeyWord As System.Web.UI.WebControls.TextBox
    Protected WithEvents txbExactPhraseKeyWord As System.Web.UI.WebControls.TextBox
    Protected WithEvents txbOrKeyWord As System.Web.UI.WebControls.TextBox
    Protected WithEvents txbNotKeyWord As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlControlAccessItems As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnSearch As System.Web.UI.WebControls.Button
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

    Private objSQLLazyNode As New SQLLazyNode
    Private strCountryCode As String = ConfigurationManager.AppSettings("CountryCode")
    Private strRepositoryCode As String = ConfigurationManager.AppSettings("RepositoryCode")

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        If Not Page.IsPostBack Then

            Me.lnkbSearch.Text = GetLabel("WS.lnkbSearch")
            Me.lnkbSearch.ToolTip = GetLabel("WS.lnkbSearch")

            loadDdlDay(Me.ddlDayInitial)
            loadDdlDay(Me.ddlDayFinal)
            loadDdlMonth(Me.ddlMonthInitial)
            loadDdlMonth(Me.ddlMonthFinal)

            lblAlertText.Visible = False

            Me.cvCkbList.ErrorMessage = GetLabel("WS.AS.messageError1")
            Me.cvDate.ErrorMessage = GetLabel("WS.AS.messageError2")
            Me.revYearInitial.ErrorMessage = GetLabel("WS.AS.emInvalidYearInitial")
            Me.revYearFinal.ErrorMessage = GetLabel("WS.AS.emInvalidYearFinal")

            Me.txbCompleteUnitId.Text = strCountryCode + "/" + strRepositoryCode + "/"

            objSQLLazyNode.loadControlAccessTypes(Me.ddlControlAccessTypes)
        End If
        'Me.btnSearch.Enabled = True
    End Sub


    '*************************************************************************************
    ' Subroutine: ibtnSearch_Click - VB default name
    ' Purpose: It will be redirected to ListShow.aspx if the form has a valid content to search
    '           in the digitarq DB.
    '*************************************************************************************
    Private Sub lnkbSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkbSearch.Click
        If Me.Page.IsValid Then
            Dim objAdvancedSearch As AdvancedSearch = CollectValues()
            Session("values") = strBdyQryAS(objAdvancedSearch)
            Session("Order") = "ASC"

            Response.Redirect("default.aspx?page=listShow&searchMode=as&sort=id&order=ASC", False)
        End If
    End Sub

    Private Function CollectValues() As AdvancedSearch
        Dim objAdvancedSearch As New AdvancedSearch

        Dim UnitTitle As New BlnSearchFields
        Dim AuthorDestination As New BlnSearchFields
        Dim GeogLocal As New BlnSearchFields
        Dim KeyWord As New BlnSearchFields
        Dim IntervalDates As New IntervalDates
        Dim CtlAccessItem As New ControlAccessItem

        Dim alst As New ArrayList
        If Not Request.Form("ckbList") Is Nothing Then
            alst.AddRange(Request.Form("ckbList").Split(","))
        End If

        UnitTitle.AndField = strRemoveText(Me.txbAndUnitTitle.Text)
        UnitTitle.ExactPhraseField = strRemoveText(Me.txbExactPhraseUnitTitle.Text)
        UnitTitle.OrField = strRemoveText(Me.txbOrUnitTitle.Text)
        UnitTitle.NotField = strRemoveText(Me.txbNotUnitTitle.Text)

        AuthorDestination.AndField = strRemoveText(Me.txbAndAuthorDestination.Text)
        AuthorDestination.ExactPhraseField = strRemoveText(Me.txbExactPhraseAuthorDestination.Text)
        AuthorDestination.OrField = strRemoveText(Me.txbOrAuthorDestination.Text)
        AuthorDestination.NotField = strRemoveText(Me.txbNotAuthorDestination.Text)

        GeogLocal.AndField = strRemoveText(Me.txbAndGeogLocal.Text)
        GeogLocal.ExactPhraseField = strRemoveText(Me.txbExactPhraseGeogLocal.Text)
        GeogLocal.OrField = strRemoveText(Me.txbOrGeogLocal.Text)
        GeogLocal.NotField = strRemoveText(Me.txbNotGeogLocal.Text)

        KeyWord.AndField = strRemoveText(Me.txbAndKeyWord.Text)
        KeyWord.ExactPhraseField = strRemoveText(Me.txbExactPhraseKeyWord.Text)
        KeyWord.OrField = strRemoveText(Me.txbOrKeyWord.Text)
        KeyWord.NotField = strRemoveText(Me.txbNotKeyWord.Text)

        IntervalDates.InitialYear = Me.txbYearInitial.Text
        IntervalDates.InitialMonth = Me.ddlMonthInitial.SelectedValue
        IntervalDates.InitialDay = Me.ddlDayInitial.SelectedItem.Text

        IntervalDates.FinalYear = Me.txbYearFinal.Text
        IntervalDates.FinalMonth = Me.ddlMonthFinal.SelectedValue
        IntervalDates.FinalDay = Me.ddlDayFinal.SelectedItem.Text

        If Me.ddlControlAccessItems.SelectedValue <> "" Then
            CtlAccessItem.ID = Me.ddlControlAccessItems.SelectedValue
            CtlAccessItem.Item = Me.ddlControlAccessItems.SelectedItem.Text
            CtlAccessItem.TypeID = Me.ddlControlAccessTypes.SelectedValue
            CtlAccessItem.Type = Me.ddlControlAccessTypes.SelectedItem.Text
        End If

        objAdvancedSearch.OtherLevel = alst
        objAdvancedSearch.SearchImages = Me.Img.Checked
        objAdvancedSearch.CompleteUnitID = strReadReference(Me.txbCompleteUnitId.Text)
        objAdvancedSearch.PartUnitID = strReadReference(Me.txbPartUnitId.Text)
        objAdvancedSearch.UnitTitle = UnitTitle
        objAdvancedSearch.AuthorDestination = AuthorDestination
        objAdvancedSearch.GeogLocal = GeogLocal
        objAdvancedSearch.KeyWord = KeyWord
        objAdvancedSearch.IntervalDates = IntervalDates
        objAdvancedSearch.ControlAccessItem = CtlAccessItem

        Return objAdvancedSearch
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

    Private Sub ddlControlAccessTypes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlControlAccessTypes.SelectedIndexChanged
        objSQLLazyNode.loadControlAccessItems(Me.ddlControlAccessItems, Me.ddlControlAccessTypes.SelectedValue)
        SetFocus(Me.ddlControlAccessItems.ClientID)
    End Sub

    '*************************************************************************************
    ' Subroutine: SetFocus 
    ' Purpose: Set focus to a given control
    '*************************************************************************************
    Private Sub SetFocus(ByVal ctrl As String)
        Dim s As String = "<script language='JavaScript'>" & _
            " if (document.getElementById) {x=document.getElementById('" & ctrl & "');" & _
            "x.focus(); } " & _
            "</script>"
        Page.RegisterStartupScript("Focus", s)
    End Sub

    '**********************************************************************************************
    ' Subroutine: ibtnInvisivelSearch_Click
    ' Purpose: This redirects on the Invisible Button click to the Shearch button subroutine.
    ' This invisible button is need to force the click in the button search when the enter key is
    ' pressed.
    '**********************************************************************************************
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        lnkbSearch_Click(sender, e)
    End Sub

End Class
