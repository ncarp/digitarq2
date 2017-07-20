Imports System.Data.SqlClient ' SQL Server Data Provider
Imports System.Object
Imports System.Collections.Hashtable
Imports System.MarshalByRefObject
Imports System.ComponentModel.Component
Imports System.Data.Common.DataAdapter
Imports System.Data.Common.DbDataAdapter
Imports System.Data.OleDb.OleDbDataAdapter

Public Class listShow
    Inherits BaseClassUC

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblNumberOfRegisters As System.Web.UI.WebControls.Label
    Protected WithEvents repShowRecordList As System.Web.UI.WebControls.Repeater
    Protected WithEvents repFooterPageMenu As System.Web.UI.WebControls.Repeater
    Protected WithEvents btnSearch As System.Web.UI.WebControls.Button
    Protected WithEvents lnkbSearch As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblTextAlert As System.Web.UI.WebControls.Label
    Protected WithEvents lblInformationMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lnkbBack As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hlnkBack As System.Web.UI.WebControls.HyperLink
    Protected WithEvents htcBlueBar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents liOrderByDate As System.Web.UI.HtmlControls.HtmlControl
    Protected WithEvents liOrderByTitle As System.Web.UI.HtmlControls.HtmlControl
    Protected WithEvents liOrderByLevel As System.Web.UI.HtmlControls.HtmlControl
    Protected WithEvents ulOrder As System.Web.UI.HtmlControls.HtmlControl
    Protected WithEvents lblOrderBy As System.Web.UI.WebControls.Label
    Protected WithEvents pnlWithResults As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlWithoutResults As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlOrderASC As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlOrderDESC As System.Web.UI.WebControls.Panel
    Protected WithEvents repFooterPageMenu1 As System.Web.UI.WebControls.Repeater
    Protected WithEvents repFooterPageMenu2 As System.Web.UI.WebControls.Repeater

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
    Protected mySearchMode As String
    Protected mySortBy As String
    Protected myOrder As String
    Protected myPageCurrent As Integer
    Protected RecordCounter As Integer
    Public intLinkCount As Integer = 0


    '*************************************************************************************
    ' Subroutine: Page_Load 
    ' Purpose: Loads the list of records returned by search
    '*************************************************************************************
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' When initializang the page for the first time it has to read the field			
        ' values from the previous pages.										
        ' That, if it came from BasicSearch or AdvancedSerach.

        If Not Me.Page.IsPostBack Then
            Try
                Dim intPageSize As Integer = ConfigurationManager.AppSettings("NumberRecordsPerPage") 'Define the number of records to use in this page

                Dim intRecordNumberFirst As Integer ' Number of First record showed
                Dim intRecordNumberLast As Integer  ' Number of the Last Record showed 

                Dim strQry As String

                mySortBy = Me.Request.QueryString("sort")
                mySearchMode = Me.Request.QueryString("searchMode")
                myOrder = Me.Request.QueryString("order")

                Select Case mySortBy
                    Case "date"
                        Me.liOrderByDate.Attributes.Add("class", "selected")
                    Case "title"
                        Me.liOrderByTitle.Attributes.Add("class", "selected")
                    Case "level"
                        Me.liOrderByLevel.Attributes.Add("class", "selected")
                End Select

                If Me.Request.QueryString("offset") Is Nothing Then 'And Me.Request.QueryString("addDocID") Is Nothing Then
                    strQry = Session("values")
                    myPageCurrent = 1

                    Me.ulOrder.Attributes.Add("class", "basictabO" & myOrder.ToUpper)
                    Records = objSQLLazyNode.objQryRecs(strQry, mySortBy, myOrder)
                Else
                    Me.ulOrder.Attributes.Add("class", "basictabO" & myOrder.ToUpper)
                    myPageCurrent = CInt(Me.Request.QueryString("offset"))
                End If

                Select Case myOrder.ToUpper
                    Case "ASC"
                        myOrder = "DESC"
                    Case "DESC"
                        myOrder = "ASC"
                End Select

                Dim intRecordsNumber As Integer = Records.Count

                If intRecordsNumber = 0 Then
                    Me.pnlWithoutResults.Visible = True
                    lblTextAlert.Text = GetLabel("WS.listShow.messageError1")
                    lblInformationMessage.Text = GetLabel("WS.listShow.messageError2")
                    Me.hlnkBack.Text = "Voltar"
                    Me.hlnkBack.NavigateUrl = "javascript:history.back()"
                Else
                    ' The Order By Menu
                    Me.pnlWithResults.Visible = True

                    intRecordNumberFirst = ((myPageCurrent - 1) * intPageSize) + 1
                    intRecordNumberLast = intRecordNumberFirst + intPageSize - 1
                    If intRecordNumberLast > intRecordsNumber Then
                        intRecordNumberLast = intRecordsNumber
                    End If

                    RecordCounter = intRecordNumberFirst - 1

                    Me.CreateDataSource(intRecordNumberFirst, intRecordNumberLast)
                    Me.CreateHeaderLabel(intRecordNumberFirst, intRecordNumberLast)
                    Me.CreateFooter(intRecordsNumber, myPageCurrent)

                End If
            Catch ex As Exception
                Dim erro As String = ex.ToString
                Select Case Me.Request.QueryString("searchMode")
                    Case "bs"
                        Response.Redirect("./default.aspx?page=basicSearch&searchMode=bs")
                    Case "as"
                        Response.Redirect("./default.aspx?page=advancedSearch&searchMode=as")
                End Select
            End Try
        End If
    End Sub

    Private Sub CreateDataSource(ByVal intRecordNumberFirst As Integer, ByVal intRecordNumberLast As Integer)
        Dim colResults As New Collection
        Dim daoGrpResults As New DaoGrpCollection
        Dim objResult As LazyNode
        For i As Integer = intRecordNumberFirst - 1 To intRecordNumberLast - 1
            objResult = New SQLLazyNode(CInt(Records.Item(i).ID), SQLLazyNode.Capacities.Medium)
            colResults.Add(objResult)
        Next

        repShowRecordList.DataSource = colResults
        repShowRecordList.DataBind()

        For i As Integer = 0 To repShowRecordList.Items.Count - 1
            Dim LazyNode As LazyNode = colResults(i + 1)
            daoGrpResults = LazyNode.DaoGrp
            If LazyNode.DigitalObjectExists Then
                Dim repDaoGrp As Repeater = CType(repShowRecordList.Items(i).FindControl("repDaoGrp"), Repeater)
                repDaoGrp.DataSource = daoGrpResults
                repDaoGrp.DataBind()
            End If
        Next
    End Sub

    Private Sub CreateHeaderLabel(ByVal intRecordNumberFirst As Integer, ByVal intRecordNumberLast As Integer)

        Dim intRecordsNumber As Integer = Records.Count

        If intRecordsNumber = 1 Then
            lblNumberOfRegisters.Text = GetLabel("WS.listShow.lblNumberRecords1")
        Else
            lblNumberOfRegisters.Text = String.Format(GetLabel("WS.listShow.lblNumberRecords2"), intRecordNumberFirst, intRecordNumberLast, intRecordsNumber)
        End If
    End Sub


    Private Sub CreateFooter(ByVal intRecordsNumber, ByVal intPageCurrent)
        'PAGES
        Dim intPageCount As Integer  'Number of pages
        Dim intPageSize As Integer = ConfigurationManager.AppSettings("NumberRecordsPerPage") 'Define the number of records to use in this page

        'FOOTNOTE
        Dim First As Integer '  first page number which appears at the footnote
        Dim Last As Integer ' last page number which appears at the footnote 
        Dim intRange As Integer = ConfigurationManager.AppSettings("NumberPagesFootNote") 'Number of pages visible at the footnote


        'Dim intRecordsNumber As Integer = Records.Count

        intPageCount = CInt(intRecordsNumber \ intPageSize)
        If (intRecordsNumber Mod intPageSize) <> 0 Then
            intPageCount = intPageCount + 1
        End If

        Dim PageUrls As New Collection
        If intPageCount > 1 Then
            If intPageCurrent > 1 Then
                PageUrls.Add(New URLS("<span title='" & GetLabel("alt.First") & "'><img border='0' align='top' src='Images/setafinal_esq.gif'/></span> ", "../default.aspx?page=listShow&searchMode=as&sort=" & mySortBy & "&order=" & Me.Request.QueryString("order") & "&offset=" & 1, "NextPrev"))
                PageUrls.Add(New URLS("<span title='" & GetLabel("alt.Previous") & "'><img border='0' align='top' src='Images/seta_esq.gif' /> Anterior</span> ", "../default.aspx?page=listShow&searchMode=as&sort=" & mySortBy & "&order=" & Me.Request.QueryString("order") & "&offset=" & intPageCurrent - 1, "NextPrev"))
            End If


            First = intPageCurrent - ((intPageCurrent - 1) Mod intPageSize)
            Last = First + intRange - 1
            If Last >= intPageCount Then
                Last = intPageCount
            End If

            ' You can also show page
            For x As Integer = First To Last
                If x = intPageCurrent Then
                    PageUrls.Add(New URLS(x, "../default.aspx?page=listShow&searchMode=as&sort=" & mySortBy & "&order=" & myOrder & "&offset=" & x, "Actual"))
                Else
                    PageUrls.Add(New URLS(x, "../default.aspx?page=listShow&searchMode=as&sort=" & mySortBy & "&order=" & myOrder & "&offset=" & x, "Index"))
                End If
            Next 'I

            If intPageCurrent < intPageCount Then
                PageUrls.Add(New URLS(" <span title='" & GetLabel("alt.Next") & "'>Seguinte <img border='0' align='top' src='Images/seta_dir.gif' /></span>", "../default.aspx?page=listShow&searchMode=as&sort=" & mySortBy & "&order=" & Me.Request.QueryString("order") & "&offset=" & intPageCurrent + 1, "NextPrev"))
                PageUrls.Add(New URLS(" <span title='" & GetLabel("alt.Last") & "'><img border='0' align='top' src='Images/setafinal_dir.gif'/></span>", "../default.aspx?page=listShow&searchMode=as&sort=" & mySortBy & "&order=" & Me.Request.QueryString("order") & "&offset=" & intPageCount, "NextPrev"))
            End If

            repFooterPageMenu1.DataSource = PageUrls
            repFooterPageMenu1.DataBind()
            repFooterPageMenu2.DataSource = PageUrls
            repFooterPageMenu2.DataBind()
        End If
    End Sub

    Protected Function intGetRecordNumber() As Integer
        RecordCounter += 1
        Return RecordCounter
    End Function

    Public Function strDrawListDocs(ByVal strDescription As String, ByVal blnEac As Boolean) As String
        If blnEac And CBool(GetConfig("ListDocsVisible")) Then
            Return "<tr width='450px'><td valign=top></td>" & _
               "<td align='left'width='140px' valign=top><font face='Verdana, Arial, Helvetica, sans-serif' color='#000066' size='1'>" & strDescription & "</font></td>" & _
               "<td align='left' colspan='3'valign=center></td></tr>"
        End If
        Return ""
    End Function

    '============= PROPERTIES ================================================================
    Public Property Records() As RecordsIDCollection
        Get
            Return Session("Records")
        End Get
        Set(ByVal Value As RecordsIDCollection)
            Session("Records") = Value
        End Set
    End Property

End Class
