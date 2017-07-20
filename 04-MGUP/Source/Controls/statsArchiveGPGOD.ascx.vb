
#Region "License Agreement"

'* DigitArq
'* Copyright 2007-2015 
'* Arquivo Distrital do Porto
'* Todos os direitos reservados.
'*  
'* Este software foi desenvolvido pelo Arquivo
'* Distrital do Porto (http://www.adporto.pt)
'* em articulação com a Direcção-Geral de Arquivos
'* (http://www.dgarq.gov.pt) e com a coordenação
'* informática da Universidade do Minho
'* (http://www.uminho.pt).
'* O desenvolvimento deste produto foi parcialmente
'* financiado pelo Programa Operacional para a 
'* Cultura (POC) promovido pelo Governo Português.
'* ---------------------------------------------------
'*
'* A redistribuição e utilização deste produto sob a
'* forma de código-fonte ou programa compilado, com ou
'* sem modificações, é permitida desde que o seguinte
'* conjunto de condições seja cumprido:
'* 
'*	* Todas as redistribuições do código-fonte 
'*	  deste produto deverão ser acompanhadas do
'*	  texto que compõe esta licença, incluindo o 
'*	  texto inicial de atribuição de autoria,
'*	  esta lista de condições e do seguinte termo
'*	  de responsabilidade.
'*
'*	* Os nomes da Direcção-Geral de Arquivos,
'*	  do Arquivo Distrital do Porto, da 
'*	  Universidade do Minho e das pessoas 
'*	  individuais que colaboraram no desenvolvimento 
'*	  deste produto não deverão ser utilizados na 
'*	  promoção de produtos derivados deste 
'*	  sem que seja obtido consentimento prévio, por
'*	  escrito, por parte dos visados.

'*	* A utilização da designação DigitArq, seus 
'*	  logótipos e nomes institucionais associados
'*	  é apenas permitida em distribuições que sejam
'*	  cópias exactas da versão oficial deste produto
'*	  aprovada e/ou distribuída pela Direcção-Geral 
'*	  de Arquivos.

'*	* O desenvolvimento de obras derivadas deste
'*	  produto é permitido desde que a designação 
'*	  DigitArq, seus logotipos e parceiros 
'*	  institucionais não sejam utilizados em todo e
'*	  qualquer tipo de distribuição e/ou promoção 
'*	  da obra derivada.
'* 
'* ESTE SOFTWARE É DISTRIBUIDO PELA DIRECÇÃO-GERAL DE
'* ARQUIVOS "NO ESTADO EM QUE SE ENCONTRA" SEM QUALQUER
'* PRESUNÇÃO DE QUALIDADE OU GARANTIA ASSOCIADAS, 
'* INCLUINDO, MAS NÃO LIMITADO A, GARANTIAS ASSOCIADAS
'* A COMÉRCIO DE PRODUTOS OU DECLARAÇÃO DE ADEQUABILIDADE
'* A DETERMINADO FIM OU OBJECTIVO. 

'* EM NENHUMA CIRCUNSTÂNCIA PODERÁ A DIRECÇÃO-GERAL DE 
'* ARQUIVOS SER CONSIDERADA RESPONSÁVEL POR QUAISQUER 
'* DANOS QUE RESULTEM DA UTILIZAÇÃO DIRECTA, INDIRECTA,
'* ACIDENTAL, ESPECIAL OU DEMONSTRATIVA DESTE PRODUTO 
'* (INCLUINDO, MAS NÃO LIMITADO A, PERDAS DE DADOS, 
'* LUCROS, FALÊNCIA, INDEVIDA PRESTAÇÃO DE SERVIÇOS
'* OU NEGLIGÊNCIA), AINDA QUE O LICENCIANTE TENHA SIDO 
'* AVISADO DA POSSIBILIDADE DA OCORRÊNCIA DE TAIS DANOS.
'*
'* ---------------------------------------------------
'* Para mais informação sobre este produto ou a sua 
'* licença, é favor consultar o endereço electrónico
'* http://www.digitarq.pt

#End Region

Public Class statsArchiveGPGOD
    Inherits BaseClassUC

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ddlListType As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlAplication As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rblChoice As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents dgArchive As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgEmployees As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ddlYears As System.Web.UI.WebControls.DropDownList
    Protected WithEvents chart1 As blong.WebControls.WebChart
    Protected WithEvents chart2 As blong.WebControls.WebChart
    Protected WithEvents pnlChart1 As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlChart2 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblTotalArchive As System.Web.UI.WebControls.Label
    Protected WithEvents pnlTotalArchive As System.Web.UI.WebControls.Panel
    Protected WithEvents lblTotalEmployees As System.Web.UI.WebControls.Label
    Protected WithEvents pnlTotalEmployees As System.Web.UI.WebControls.Panel

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private objI As New SQLDataBase
    Private flag As Boolean = False
    Private objM As Misc = New Misc
    Private ARCHIVE_MONTHSPERYEAR As Integer = 12
    Private ARCHIVE_DAYSPERMONTH As Integer = 20
    Private EMPLOYEES_MONTHSPERYEAR As Integer = 11
    Private EMPLOYEES_DAYSPERMONTH As Integer = 20


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Me.Page.IsPostBack Then
            If objI.accessFunction(HttpContext.Current.User.Identity.Name, Me.Request.QueryString("page")) Then
                LoadChoices()
                LoadDOFilesYears()
                If Not Me.ddlYears.Items.FindByText(Date.Now.Year) Is Nothing Then
                    Me.ddlYears.Items.FindByText(Date.Now.Year).Selected = True
                End If
                Me.rblChoice.SelectedValue = "archive"
                If Me.ddlYears.Items.Count > 0 Then
                    BindData()
                Else
                    Me.lblTotalEmployees.Text = CStr(0)
                    Me.lblTotalArchive.Text = CStr(0)
                End If
            Else
                Response.Redirect("defaultIn.aspx?page=gpu-0&lbl=accessDenied")
            End If
        End If
    End Sub

    Private Sub LoadChoices()
        Dim l1, l2 As ListItem
        l1 = New ListItem(GetLabel("statsArchiveGPGOD.rblChoice.item1"), "archive")
        l2 = New ListItem(GetLabel("statsArchiveGPGOD.rblChoice.item2"), "employees")
        Me.rblChoice.Items.Add(l1)
        Me.rblChoice.Items.Add(l2)
    End Sub

    Private Sub LoadDOFilesYears()
        Dim myData As ArrayList = objI.getDOFilesYears
        For i As Integer = 0 To myData.Count - 1
            Me.ddlYears.Items.Add(myData.Item(i))
        Next
    End Sub

    Private Sub LoadArchiveProduction(ByVal year As String)
        Me.dgArchive.Columns(0).HeaderText = GetLabel("statsArchiveGPGOD.dgArchive.column0HeaderText")
        Me.dgArchive.Columns(1).HeaderText = GetLabel("statsArchiveGPGOD.dgArchive.column1HeaderText")
        Me.dgArchive.Columns(2).HeaderText = GetLabel("statsArchiveGPGOD.dgArchive.column2HeaderText")

        Dim ds As DataSet = objI.loadArchiveProduction(year)
        Me.dgArchive.DataSource = ds
        Me.dgArchive.DataBind()
        Me.pnlChart1.Visible = True
        Me.pnlChart2.Visible = False
        Me.objM.MakeChartMonths(ds, chart1, GetLabel("statsArchiveGPGOD.chartArchiveProduction.title"), True, 0, 1)
        Me.pnlTotalArchive.Visible = True
        Me.pnlTotalEmployees.Visible = False
        Me.lblTotalArchive.Text = CStr(CalcTotal(ds))
    End Sub

    Private Function CalcTotal(ByVal ds As DataSet) As Integer
        Dim total As Integer = 0
        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            total = total + CInt(ds.Tables(0).Rows(i).Item(1))
        Next
        Return total
    End Function

    Private Sub LoadEmployeesProduction(ByVal year As String)
        Me.dgEmployees.Columns(0).HeaderText = GetLabel("statsArchiveGPGOD.dgEmployees.column0HeaderText")
        Me.dgEmployees.Columns(1).HeaderText = GetLabel("statsArchiveGPGOD.dgEmployees.column1HeaderText")
        Me.dgEmployees.Columns(2).HeaderText = GetLabel("statsArchiveGPGOD.dgEmployees.column2HeaderText")
        Me.dgEmployees.Columns(3).HeaderText = GetLabel("statsArchiveGPGOD.dgEmployees.column3HeaderText")
        Me.dgEmployees.Columns(4).HeaderText = GetLabel("statsArchiveGPGOD.dgEmployees.column4HeaderText")

        Dim ds As DataSet = objI.loadEmployeesProduction(year)

        Me.pnlTotalArchive.Visible = False
        Me.pnlTotalEmployees.Visible = True
        Me.lblTotalEmployees.Text = CStr(CalcTotal(ds))

        Me.dgEmployees.DataSource = ds
        Me.dgEmployees.DataBind()
        Me.pnlChart1.Visible = False
        Me.pnlChart2.Visible = True
        Me.objM.MakeChart(ds, chart2, GetLabel("statsArchiveGPGOD.chartEmployeesProduction.title"), True, 0, 1)
    End Sub

    Public Sub BindData()
        If Me.ddlYears.Items.Count > 0 Then
            If Me.rblChoice.SelectedValue = "archive" Then
                Me.dgArchive.Visible = True
                Me.dgEmployees.Visible = False
                Me.LoadArchiveProduction(Me.ddlYears.SelectedItem.Text)
            ElseIf Me.rblChoice.SelectedValue = "employees" Then
                Me.dgEmployees.Visible = True
                Me.dgArchive.Visible = False
                Me.LoadEmployeesProduction(Me.ddlYears.SelectedItem.Text)
            End If
        End If
    End Sub

    Private Sub rblChoice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblChoice.SelectedIndexChanged
        BindData()
    End Sub

    Private Sub ddlYears_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlYears.SelectedIndexChanged
        BindData()
    End Sub

    Public Function CalcMonthlyAvgEmployee(ByVal total As Integer) As String
        Dim months As Integer
        If Me.ddlYears.SelectedItem.Text = CStr(Date.Now.Year) Then
            months = Date.Now.Month
        Else
            months = EMPLOYEES_MONTHSPERYEAR
        End If
        Return String.Format("{0:#.00}", total / months)
    End Function

    Public Function CalcDaylyAvgEmployee(ByVal total As Integer) As String
        Dim days As Integer
        If Me.ddlYears.SelectedItem.Text = CStr(Date.Now.Year) Then
            days = Date.Now.Month * EMPLOYEES_DAYSPERMONTH
        Else
            days = EMPLOYEES_MONTHSPERYEAR * EMPLOYEES_DAYSPERMONTH
        End If
        Return String.Format("{0:#.00}", total / days)
    End Function

    Public Function CalcAvgEmployee(ByVal total As Integer) As String
        Return String.Format("{0:#.00}", total * 100 / CInt(Me.lblTotalEmployees.Text))
    End Function

    Public Function CalcMonthlyAvgArchive(ByVal total As Integer) As String
        Dim months As Integer
        If Me.ddlYears.SelectedItem.Text = CStr(Date.Now.Year) Then
            months = Date.Now.Month
        Else
            months = ARCHIVE_MONTHSPERYEAR
        End If
        Return String.Format("{0:#.00}", total / months)
    End Function

    Public Function CalcDaylyAvgArchive(ByVal total As Integer) As String
        Dim days As Integer
        If Me.ddlYears.SelectedItem.Text = CStr(Date.Now.Year) Then
            days = Date.Now.Month * ARCHIVE_DAYSPERMONTH
        Else
            days = ARCHIVE_MONTHSPERYEAR * ARCHIVE_DAYSPERMONTH
        End If
        Return String.Format("{0:#.00}", total / days)
    End Function

End Class
