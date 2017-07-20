
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

Imports System.IO
Imports System.Management


Public Class systemResources
    Inherits BaseClassUC

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    'Protected WithEvents ddlListType As System.Web.UI.WebControls.DropDownList
    'Protected WithEvents ddlAplication As System.Web.UI.WebControls.DropDownList
    Protected WithEvents rblChoice As System.Web.UI.WebControls.RadioButtonList
    'Protected WithEvents dgArchive As System.Web.UI.WebControls.DataGrid
    'Protected WithEvents dgEmployees As System.Web.UI.WebControls.DataGrid
    'Protected WithEvents ddlYears As System.Web.UI.WebControls.DropDownList
    Protected WithEvents chartCountLogsByYear As blong.WebControls.WebChart
    Protected WithEvents chartCountLogsByUsername As blong.WebControls.WebChart
    Protected WithEvents pnlCountLogs As System.Web.UI.WebControls.Panel
    Protected WithEvents dgCountLogsByYear As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblTotalLogsCount1 As System.Web.UI.WebControls.Label
    Protected WithEvents dgCountLogsByUsername As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblTotalLogsCount2 As System.Web.UI.WebControls.Label
    Protected WithEvents Datagrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents pnlBackups As System.Web.UI.WebControls.Panel
    Protected WithEvents dgBackups As System.Web.UI.WebControls.DataGrid
    Protected WithEvents pnlDBSize As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlDiskSize As System.Web.UI.WebControls.Panel
    Protected WithEvents dgDiskSize As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblDBLocation As System.Web.UI.WebControls.Label
    Protected WithEvents dgDBSize As System.Web.UI.WebControls.DataGrid
    Protected WithEvents chartDBSize As blong.WebControls.WebChart

    Protected WithEvents chartDrive As blong.WebControls.WebChart

    'Protected WithEvents chart2 As blong.WebControls.WebChart
    'Protected WithEvents pnlChart1 As System.Web.UI.WebControls.Panel
    'Protected WithEvents pnlChart2 As System.Web.UI.WebControls.Panel
    'Protected WithEvents lblTotalArchive As System.Web.UI.WebControls.Label
    'Protected WithEvents pnlTotalArchive As System.Web.UI.WebControls.Panel
    'Protected WithEvents lblTotalEmployees As System.Web.UI.WebControls.Label
    'Protected WithEvents pnlTotalEmployees As System.Web.UI.WebControls.Panel

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Me.Page.IsPostBack Then
            If objI.accessFunction(HttpContext.Current.User.Identity.Name, Me.Request.QueryString("page")) Then
                LoadChoices()
                If Not Me.Request.QueryString("op") Is Nothing Then
                    Me.rblChoice.SelectedValue = Me.Request.QueryString("op")
                Else
                    Me.rblChoice.SelectedValue = "logCount"
                End If

                BindData()
            Else
                Response.Redirect("defaultIn.aspx?page=gpu-0&lbl=accessDenied")
            End If
        End If
    End Sub

    Private Sub LoadChoices()
        Dim l1, l2, l3, l4 As ListItem
        l1 = New ListItem(GetLabel("systemResources.op1"), "logCount")
        l2 = New ListItem(GetLabel("systemResources.op2"), "backups")
        l3 = New ListItem(GetLabel("systemResources.op3"), "dbSize")
        l4 = New ListItem(GetLabel("systemResources.op4"), "diskSize")
        Me.rblChoice.Items.Add(l1)
        Me.rblChoice.Items.Add(l2)
        Me.rblChoice.Items.Add(l3)
        Me.rblChoice.Items.Add(l4)
    End Sub

    Public Sub BindData()
        Select Case Me.rblChoice.SelectedValue
            Case "logCount"
                Me.pnlCountLogs.Visible = True
                Me.pnlBackups.Visible = False
                Me.pnlDBSize.Visible = False
                Me.pnlDiskSize.Visible = False
                ShowLogCount()
            Case "backups"
                Me.pnlBackups.Visible = True
                Me.pnlCountLogs.Visible = False
                Me.pnlDBSize.Visible = False
                Me.pnlDiskSize.Visible = False
                ShowBackups()
            Case "dbSize"
                Me.pnlDBSize.Visible = True
                Me.pnlBackups.Visible = False
                Me.pnlCountLogs.Visible = False
                Me.pnlDiskSize.Visible = False
                ShowDBSize()
            Case "diskSize"
                Me.pnlDiskSize.Visible = True
                Me.pnlDBSize.Visible = False
                Me.pnlBackups.Visible = False
                Me.pnlCountLogs.Visible = False
                ShowDiskSize()
        End Select
    End Sub

    Private Sub ShowLogCount()
        Me.dgCountLogsByYear.Columns(0).HeaderText = GetLabel("systemResources.dgCountLogsByYear.column0HeaderText")
        Me.dgCountLogsByYear.Columns(1).HeaderText = GetLabel("systemResources.dgCountLogsByYear.column1HeaderText")
        Me.dgCountLogsByUsername.Columns(0).HeaderText = GetLabel("systemResources.dgCountLogsByUsername.column0HeaderText")
        Me.dgCountLogsByUsername.Columns(1).HeaderText = GetLabel("systemResources.dgCountLogsByUsername.column1HeaderText")

        Dim ds1 As DataSet = objI.countLogsByYear
        Dim ds2 As DataSet = objI.countLogsByUsername
        Me.dgCountLogsByYear.DataSource = ds1
        Me.dgCountLogsByYear.DataBind()
        Me.dgCountLogsByUsername.DataSource = ds2
        Me.dgCountLogsByUsername.DataBind()

        Me.objM.MakeChart(ds1, Me.chartCountLogsByYear, GetLabel("systemResources.percentLogsByYear"), True, 0, 1)
        Me.objM.MakeChart(ds2, Me.chartCountLogsByUsername, GetLabel("systemResources.percentLogsByUser"), True, 0, 1)
        Dim total As Integer = CalcTotal(ds1, 1)
        Me.lblTotalLogsCount1.Text = total.ToString
        Me.lblTotalLogsCount2.Text = total.ToString
    End Sub

    Private Sub ShowBackups()
        Me.dgBackups.Columns(0).HeaderText = GetLabel("systemResources.dgBackups.column0HeaderText")
        Me.dgBackups.Columns(1).HeaderText = GetLabel("systemResources.dgBackups.column1HeaderText")
        Me.dgBackups.Columns(2).HeaderText = GetLabel("systemResources.dgBackups.column2HeaderText")

        Dim dir As Directory
        Dim file As File
        Dim dt As New DataTable
        'Dim BackupDirectory As String = ConfigurationSettings.AppSettings("BackupDirectory")
        Dim BackupDirectory As String = ConfigurationManager.AppSettings("BackupDirectory")
        dt.Columns.Add("FileName")
        dt.Columns.Add("FileLength")
        dt.Columns.Add("FileCreationTime")
        Dim filenames As String()
        If dir.Exists(BackupDirectory) Then
            filenames = dir.GetFiles(BackupDirectory)
            For Each filename As String In filenames
                Dim fs As New FileStream(filename, FileMode.Open, FileAccess.Read)
                Dim row As DataRow = dt.NewRow
                row(0) = Path.GetFileName(filename)
                row(1) = String.Format("{0:#.00}", fs.Length / 1024 / 1024) + " MB"
                row(2) = file.GetLastWriteTime(filename)
                dt.Rows.Add(row)
                fs.Close()
            Next
        End If
        Me.dgBackups.DataSource = dt
        Me.dgBackups.DataBind()
    End Sub

    Private Sub ShowDBSize()
        Dim DBSize, DriveSize, OtherSize, FreeSpace As String
        Dim Ret(2) As String
        Ret = objI.getDBFilesLocation
        Dim DBDataLocation As String = Ret(0)
        Dim DBLogLocation As String = Ret(1)
        Dim DBDrive As String = DBDataLocation.Substring(0, 2)

        Me.dgDBSize.Columns(0).HeaderText = GetLabel("systemResources.dgDBSize.column0HeaderText") & " " & DBDrive
        Me.dgDBSize.Columns(1).HeaderText = GetLabel("systemResources.dgDBSize.column1HeaderText")
        Me.dgDBSize.Columns(2).HeaderText = GetLabel("systemResources.dgDBSize.column2HeaderText")

        Dim dt As New DataTable
        dt.Columns.Add("SpaceTitle")
        dt.Columns.Add("Size")
        dt.Columns.Add("Percent")
        dt.Columns.Add("SizeBytes")

        Me.lblDBLocation.Text = "<br>" + DBDataLocation + "<br>" + DBLogLocation

        Dim FileInfoData As FileInfo = New FileInfo(DBDataLocation)
        Dim FileInfoLog As FileInfo = New FileInfo(DBLogLocation)

        Dim mo As ManagementObject
        Dim mos As ManagementObjectSearcher
        mos = New ManagementObjectSearcher("SELECT * FROM Win32_LogicalDisk")
        For Each mo In mos.Get
            If mo("DeviceID").ToString = DBDrive Then
                DriveSize = mo("Size").ToString
                FreeSpace = mo("FreeSpace").ToString
            End If
        Next

        DBSize = (FileInfoData.Length + FileInfoLog.Length).ToString
        OtherSize = (DriveSize - DBSize - FreeSpace).ToString

        Dim row1 As DataRow = dt.NewRow
        Dim row2 As DataRow = dt.NewRow
        Dim row3 As DataRow = dt.NewRow
        row1(0) = "Base de dados"
        row2(0) = "Outros dados"
        row3(0) = "Espaço livre"
        row1(1) = String.Format("{0:#.00}", (DBSize / 1024 / 1024)) & " MB"
        row2(1) = String.Format("{0:#.00}", (OtherSize / 1024 / 1024)) & " MB"
        row3(1) = String.Format("{0:#.00}", (FreeSpace / 1024 / 1024)) & " MB"
        row1(2) = String.Format("{0:#.00}", DBSize * 100 / DriveSize) & " %"
        row2(2) = String.Format("{0:#.00}", OtherSize * 100 / DriveSize) & " %"
        row3(2) = String.Format("{0:#.00}", FreeSpace * 100 / DriveSize) & " %"
        row1(3) = DBSize
        row2(3) = OtherSize
        row3(3) = FreeSpace
        dt.Rows.Add(row1)
        dt.Rows.Add(row2)
        dt.Rows.Add(row3)

        Me.dgDBSize.DataSource = dt
        Me.dgDBSize.DataBind()

        Me.objM.MakeChart(dt, Me.chartDBSize, GetLabel("systemResources.dbSize"), False, 0, 3)
    End Sub

    Private Sub ShowDiskSize()
        Me.dgDiskSize.Columns(0).HeaderText = GetLabel("systemResources.dgDiskSize.column0HeaderText")
        Me.dgDiskSize.Columns(1).HeaderText = GetLabel("systemResources.dgDiskSize.column1HeaderText")
        Me.dgDiskSize.Columns(2).HeaderText = GetLabel("systemResources.dgDiskSize.column2HeaderText")
        Me.dgDiskSize.Columns(3).HeaderText = GetLabel("systemResources.dgDiskSize.column3HeaderText")
        Me.dgDiskSize.Columns(4).HeaderText = GetLabel("systemResources.dgDiskSize.column4HeaderText")
        Me.dgDiskSize.Columns(5).HeaderText = GetLabel("systemResources.dgDiskSize.column5HeaderText")

        Dim ShowChart As Boolean = False
        Dim dt As New DataTable
        Dim dtChart As New DataTable
        dt.Columns.Add("DriveName")
        dt.Columns.Add("Size")
        dt.Columns.Add("BusySpace")
        dt.Columns.Add("PercentBusySpace")
        dt.Columns.Add("FreeSpace")
        dt.Columns.Add("PercentFreeSpace")

        Dim mo As ManagementObject
        Dim mos As ManagementObjectSearcher
        mos = New ManagementObjectSearcher("SELECT * FROM Win32_LogicalDisk")
        For Each mo In mos.Get
            Dim row As DataRow = dt.NewRow
            row(0) = mo("DeviceID")
            If Not mo("Size") Is Nothing Then
                Dim div As Integer = 1024
                Dim size As String = mo("Size").ToString
                Dim freeSpace As String = mo("FreeSpace").ToString

                row(1) = String.Format("{0:#.00}", size / div / div) & " MB"
                row(2) = String.Format("{0:#.00}", (size - freeSpace) / div / div) & " MB"
                row(3) = String.Format("{0:#.00}", (size - freeSpace) * 100 / size) & " %"
                row(4) = String.Format("{0:#.00}", freeSpace / div / div) & " MB"
                row(5) = String.Format("{0:#.00}", freeSpace * 100 / size) & " %"

                If mo("DeviceID").ToString = Me.Request.QueryString("deviceID") And size > 0 Then
                    dtChart.Columns.Add("Title")
                    dtChart.Columns.Add("Size")
                    Dim row1 As DataRow = dtChart.NewRow
                    Dim row2 As DataRow = dtChart.NewRow
                    row1(0) = "Espaço ocupado"
                    row2(0) = "Espaço livre"
                    row1(1) = size - freeSpace
                    row2(1) = freeSpace
                    dtChart.Rows.Add(row1)
                    dtChart.Rows.Add(row2)
                    Me.chartDrive.Visible = True
                    ShowChart = True
                End If
            End If
            dt.Rows.Add(row)
        Next

        If ShowChart Then
            Me.chartDrive.Visible = True
            Me.objM.MakeChart(dtChart, Me.chartDrive, String.Format(GetLabel("systemResources.deviceID"), Me.Request.QueryString("deviceID")), True, 0, 1)
        Else
            Me.chartDrive.Visible = False
        End If


        Me.dgDiskSize.DataSource = dt
        Me.dgDiskSize.DataBind()
    End Sub

    Private Function FormatNumber(ByVal str As String) As String
        Dim strRet As String
        Dim count As Integer = 0
        For i As Integer = str.Length - 1 To 0 Step -1
            count += 1
            strRet = str.Chars(i) + strRet
            If count Mod 3 = 0 And count <> str.Length Then
                strRet = " " + strRet
            End If
        Next
        Return strRet
    End Function

    Private Function CalcTotal(ByVal ds As DataSet, ByVal column As Integer) As Integer
        Dim total As Integer = 0
        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            total = total + CInt(ds.Tables(0).Rows(i).Item(column))
        Next
        Return total
    End Function


    Private Sub rblChoice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblChoice.SelectedIndexChanged
        BindData()
    End Sub
End Class
