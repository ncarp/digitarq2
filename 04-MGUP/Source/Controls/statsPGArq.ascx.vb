
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

Public Class statsPGArq
    Inherits BaseClassUC

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents rblChoice As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents Table1 As System.Web.UI.WebControls.Table
    Protected WithEvents Table2 As System.Web.UI.WebControls.Table
    Protected WithEvents Table3 As System.Web.UI.WebControls.Table
    Protected WithEvents Table4 As System.Web.UI.WebControls.Table
    Protected WithEvents Table5 As System.Web.UI.WebControls.Table
    Protected WithEvents Table6 As System.Web.UI.WebControls.Table
    Protected WithEvents Table7 As System.Web.UI.WebControls.Table
    Protected WithEvents Table8 As System.Web.UI.WebControls.Table
    Protected WithEvents Table9 As System.Web.UI.WebControls.Table
    Protected WithEvents Table10 As System.Web.UI.WebControls.Table
    Protected WithEvents Table11 As System.Web.UI.WebControls.Table
    Protected WithEvents Table12 As System.Web.UI.WebControls.Table
    Protected WithEvents lnkbExecuta As System.Web.UI.WebControls.LinkButton
    Protected WithEvents ddlYear As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlMonth As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlDay As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlYear2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlMonth2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlDay2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblTypeOp As System.Web.UI.WebControls.Label
    Protected WithEvents lblFrom As System.Web.UI.WebControls.Label
    Protected WithEvents lblTo As System.Web.UI.WebControls.Label
    Protected WithEvents lblDay As System.Web.UI.WebControls.Label
    Protected WithEvents lblMon As System.Web.UI.WebControls.Label
    Protected WithEvents lblYea As System.Web.UI.WebControls.Label
    Protected WithEvents lblDay2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMon2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblYea2 As System.Web.UI.WebControls.Label
    Protected WithEvents lnkbExport As System.Web.UI.WebControls.LinkButton
    Protected WithEvents chart1 As blong.WebControls.WebChart
    Protected WithEvents chart2 As blong.WebControls.WebChart
    Protected WithEvents chart3 As blong.WebControls.WebChart
    Protected WithEvents lblDateTo As System.Web.UI.WebControls.Label
    Protected WithEvents lblDate1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblDate2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblDate3 As System.Web.UI.WebControls.Label
    Protected WithEvents lblDate4 As System.Web.UI.WebControls.Label
    Protected WithEvents lblDate5 As System.Web.UI.WebControls.Label
    Protected WithEvents lblDate6 As System.Web.UI.WebControls.Label
    Protected WithEvents lblDate7 As System.Web.UI.WebControls.Label
    Protected WithEvents lblDate8 As System.Web.UI.WebControls.Label
    Protected WithEvents lblDate9 As System.Web.UI.WebControls.Label
    Protected WithEvents lblDate10 As System.Web.UI.WebControls.Label
    Protected WithEvents lblDate11 As System.Web.UI.WebControls.Label
    Protected WithEvents lblDate12 As System.Web.UI.WebControls.Label

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    'Dim hshDatabase As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")
    Dim hshDatabase As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")

    Private ServerAddress As String = hshDatabase("ServerAddress")
    Private GPUDatabase As String = hshDatabase("Database")
    Private SA_Username As String = hshDatabase("SA_Username")
    Private SA_Password As String = hshDatabase("SA_Password")
    Private Username As String = hshDatabase("Username")
    Private Password As String = hshDatabase("Password")

    Private objI As SQLDataBase = New SQLDataBase
    Private objM As Misc = New Misc
    Private htMonth As Hashtable = objM.loadHTMonth()
    Private TableT As New Table

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Me.Page.IsPostBack Then
            ddlYear.DataSource = objI.stGetYears()
            ddlYear.DataBind()
            ddlYear2.DataSource = objI.stGetYears()
            ddlYear2.DataBind()

            ddlMonth.DataSource() = objM.loadMonthNames()
            ddlMonth.DataBind()
            ddlMonth2.DataSource() = objM.loadMonthNames()
            ddlMonth2.DataBind()

            objM.loadDays(ddlYear, ddlMonth, ddlDay)
            objM.loadDays(ddlYear2, ddlMonth2, ddlDay2)

            lblDay.Text = GetLabel("statsPGFunc.lblDay")
            lblMon.Text = GetLabel("statsPGFunc.lblMon")
            lblYea.Text = GetLabel("statsPGFunc.lblYea")
            lblDay2.Text = GetLabel("statsPGFunc.lblDay")
            lblMon2.Text = GetLabel("statsPGFunc.lblMon")
            lblYea2.Text = GetLabel("statsPGFunc.lblYea")
            lblFrom.Text = GetLabel("statsPGFunc.lblFrom")
            lblTo.Text = GetLabel("statsPGFunc.lblTo")
            lnkbExecuta.Text = GetLabel("button.Execute")
            lnkbExport.Text = GetLabel("statsButton.lblExport")
            rblChoice.SelectedIndex = 0
        End If
        loadChoices(rblChoice)
        lnkbExport.Visible = False
        chart1.Visible = False
        chart2.Visible = False
        chart3.Visible = False
        Table2.Visible = False
        Table3.Visible = False
        Table4.Visible = False
        Table5.Visible = False
        Table6.Visible = False
        Table7.Visible = False
        Table8.Visible = False
        Table9.Visible = False
        Table10.Visible = False
        Table11.Visible = False
        Table12.Visible = False
        clean()
        ddlDay.Visible = False
        lblDay.Visible = False
        ddlYear2.Visible = False
        lblYea2.Visible = False
        ddlMonth2.Visible = False
        lblMon2.Visible = False
        ddlDay2.Visible = False
        lblDay2.Visible = False
        lblFrom.Visible = False
        lblTo.Visible = False
    End Sub

    Private Sub ddlMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMonth.SelectedIndexChanged
        objM.loadDays(ddlYear, ddlMonth, ddlDay)
        clean()
    End Sub

    Private Sub ddlMonth2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlMonth2.SelectedIndexChanged
        objM.loadDays(ddlYear2, ddlMonth2, ddlDay2)
        clean()
    End Sub

    Private Sub clean()
        lblTypeOp.Text = ""
        lblDateTo.Text = ""
        lblDate1.Text = ""
        lblDate2.Text = ""
        lblDate3.Text = ""
        lblDate4.Text = ""
        lblDate5.Text = ""
        lblDate6.Text = ""
        lblDate7.Text = ""
        lblDate8.Text = ""
        lblDate9.Text = ""
        lblDate10.Text = ""
        lblDate11.Text = ""
        lblDate12.Text = ""
    End Sub

    Private Sub loadChoices(ByVal rbl As RadioButtonList)
        Dim al As ArrayList = New ArrayList
        al.Add(GetLabel("statsPGFunc.rblTotMon"))
        al.Add(GetLabel("statsPGFunc.rblTotYear"))
        al.Add(GetLabel("statsPGFunc.rblTotalPer"))
        al.Add(GetLabel("statsPGFunc.rblTotMontYear"))
        al.Add(GetLabel("statsPGFunc.rblTotMontYearNiv"))
        al.Add(GetLabel("statsPGFunc.rblAvDayM"))
        al.Add(GetLabel("statsPGFunc.rblAvDayY"))
        al.Add(GetLabel("statsPGFunc.rblAvMonY"))
        al.Add(GetLabel("statsPGFunc.rblAveraPer"))
        al.Add(GetLabel("statsPGArq.rblPercFunc"))
        rbl.DataSource = al
        rbl.DataBind()
    End Sub

    Private Sub lnkbExecuta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkbExecuta.Click
        If rblChoice.SelectedValue = GetLabel("statsPGFunc.rblAvDayM") Then
            lblTypeOp.Text = GetLabel("statsPGFunc.TypeOp") & GetLabel("statsPGFunc.rblAvDayM")
            lblDate1.Text = GetLabel("statsPGFunc.lblDate") & ddlYear.SelectedValue & "-" & ddlMonth.SelectedValue
            Calc_Avg_MY(20)
        ElseIf rblChoice.SelectedValue = GetLabel("statsPGFunc.rblAvDayY") Then
            lblTypeOp.Text = GetLabel("statsPGFunc.TypeOp") & GetLabel("statsPGFunc.rblAvDayY")
            lblDate1.Text = GetLabel("statsPGFunc.lblDate") & ddlYear.SelectedValue
            Calc_Avg_Y(220)
        ElseIf rblChoice.SelectedValue = GetLabel("statsPGFunc.rblAvMonY") Then
            lblTypeOp.Text = GetLabel("statsPGFunc.TypeOp") & GetLabel("statsPGFunc.rblAvMonY")
            lblDate1.Text = GetLabel("statsPGFunc.lblDate") & ddlYear.SelectedValue
            Calc_Avg_Y(12)
        ElseIf rblChoice.SelectedValue = GetLabel("statsPGFunc.rblTotMon") Then
            lblTypeOp.Text = GetLabel("statsPGFunc.TypeOp") & GetLabel("statsPGFunc.rblTotMon")
            lblDate1.Text = GetLabel("statsPGFunc.lblDate") & ddlYear.SelectedValue & "-" & ddlMonth.SelectedValue
            Calc_Tot_Mon(Table1, htMonth.Item(ddlMonth.SelectedValue), 0)
        ElseIf rblChoice.SelectedValue = GetLabel("statsPGFunc.rblTotYear") Then
            lblTypeOp.Text = GetLabel("statsPGFunc.TypeOp") & GetLabel("statsPGFunc.rblTotYear")
            lblDate1.Text = GetLabel("statsPGFunc.lblDate") & ddlYear.SelectedValue
            Calc_Tot_Year()
        ElseIf rblChoice.SelectedValue = GetLabel("statsPGFunc.rblTotMontYear") Then
            lblTypeOp.Text = GetLabel("statsPGFunc.TypeOp") & GetLabel("statsPGFunc.rblTotMontYear")
            lblDate1.Text = GetLabel("statsPGFunc.lblDate") & ddlYear.SelectedValue
            Calc_Tot_Months_Year()
        ElseIf rblChoice.SelectedValue = GetLabel("statsPGFunc.rblTotMontYearNiv") Then
            lblTypeOp.Text = GetLabel("statsPGFunc.TypeOp") & GetLabel("statsPGFunc.rblTotMontYearNiv")
            lblDate1.Text = GetLabel("statsPGFunc.lblDate") & ddlYear.SelectedValue & "-" & GetLabel("statsPGFunc.ddlJan")
            lblDate2.Text = GetLabel("statsPGFunc.lblDate") & ddlYear.SelectedValue & "-" & GetLabel("statsPGFunc.ddlFev")
            lblDate3.Text = GetLabel("statsPGFunc.lblDate") & ddlYear.SelectedValue & "-" & GetLabel("statsPGFunc.ddlMar")
            lblDate4.Text = GetLabel("statsPGFunc.lblDate") & ddlYear.SelectedValue & "-" & GetLabel("statsPGFunc.ddlApr")
            lblDate5.Text = GetLabel("statsPGFunc.lblDate") & ddlYear.SelectedValue & "-" & GetLabel("statsPGFunc.ddlMay")
            lblDate6.Text = GetLabel("statsPGFunc.lblDate") & ddlYear.SelectedValue & "-" & GetLabel("statsPGFunc.ddlJun")
            lblDate7.Text = GetLabel("statsPGFunc.lblDate") & ddlYear.SelectedValue & "-" & GetLabel("statsPGFunc.ddlJul")
            lblDate8.Text = GetLabel("statsPGFunc.lblDate") & ddlYear.SelectedValue & "-" & GetLabel("statsPGFunc.ddlAug")
            lblDate9.Text = GetLabel("statsPGFunc.lblDate") & ddlYear.SelectedValue & "-" & GetLabel("statsPGFunc.ddlSep")
            lblDate10.Text = GetLabel("statsPGFunc.lblDate") & ddlYear.SelectedValue & "-" & GetLabel("statsPGFunc.ddlOct")
            lblDate11.Text = GetLabel("statsPGFunc.lblDate") & ddlYear.SelectedValue & "-" & GetLabel("statsPGFunc.ddlNov")
            lblDate12.Text = GetLabel("statsPGFunc.lblDate") & ddlYear.SelectedValue & "-" & GetLabel("statsPGFunc.ddlDec")
            Table2.Visible = True
            Table3.Visible = True
            Table4.Visible = True
            Table5.Visible = True
            Table6.Visible = True
            Table7.Visible = True
            Table8.Visible = True
            Table9.Visible = True
            Table10.Visible = True
            Table11.Visible = True
            Table12.Visible = True
            Calc_Tot_Months_Year_Niv()
        ElseIf rblChoice.SelectedValue = GetLabel("statsPGArq.rblPercFunc") Then
            lblTypeOp.Text = GetLabel("statsPGFunc.TypeOp") & GetLabel("statsPGArq.rblPercFunc")
            lblDate1.Text = GetLabel("statsPGFunc.lblDate") & ddlYear.SelectedValue
            Calc_Perc_Func()
            chart1.Visible = True
            chart2.Visible = True
            chart3.Visible = True
        ElseIf rblChoice.SelectedValue = GetLabel("statsPGFunc.rblTotalPer") Then
            lblTypeOp.Text = GetLabel("statsPGFunc.TypeOp") & GetLabel("statsPGFunc.rblTotalPer")
            lblDate1.Text = GetLabel("statsPGFunc.lblFrom") & ddlYear.SelectedValue & "-" & ddlMonth.SelectedValue & "-" & ddlDay.SelectedValue
            lblDateTo.Text = GetLabel("statsPGFunc.lblTo") & ddlYear2.SelectedValue & "-" & ddlMonth2.SelectedValue & "-" & ddlDay2.SelectedValue
            Calc_Tot_Period()
        ElseIf rblChoice.SelectedValue = GetLabel("statsPGFunc.rblAveraPer") Then
            lblTypeOp.Text = GetLabel("statsPGFunc.TypeOp") & GetLabel("statsPGFunc.rblAveraPer")
            lblDate1.Text = GetLabel("statsPGFunc.lblFrom") & ddlYear.SelectedValue & "-" & ddlMonth.SelectedValue & "-" & ddlDay.SelectedValue
            lblDateTo.Text = GetLabel("statsPGFunc.lblTo") & ddlYear2.SelectedValue & "-" & ddlMonth2.SelectedValue & "-" & ddlDay2.SelectedValue
            Calc_Avg_Period()
        End If
        lnkbExport.Visible = True
    End Sub

    Private Sub rblChoice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblChoice.SelectedIndexChanged
        If rblChoice.SelectedValue = GetLabel("statsPGFunc.rblAvDayM") Or rblChoice.SelectedValue = GetLabel("statsPGFunc.rblTotMon") Then
            ddlMonth.Visible = True
            lblMon.Visible = True
        ElseIf rblChoice.SelectedValue = GetLabel("statsPGFunc.rblAvDayY") Or rblChoice.SelectedValue = GetLabel("statsPGFunc.rblAvMonY") Or rblChoice.SelectedValue = GetLabel("statsPGFunc.rblTotYear") Or rblChoice.SelectedValue = GetLabel("statsPGArq.rblPercFunc") Or rblChoice.SelectedValue = GetLabel("statsPGFunc.rblTotMontYear") Or rblChoice.SelectedValue = GetLabel("statsPGFunc.rblTotMontYearNiv") Then
            ddlMonth.Visible = False
            lblMon.Visible = False
        End If
        If rblChoice.SelectedValue = GetLabel("statsPGFunc.rblTotalPer") Or rblChoice.SelectedValue = GetLabel("statsPGFunc.rblAveraPer") Then
            ddlMonth.Visible = True
            lblMon.Visible = True
            lblMon.Visible = True
            ddlDay.Visible = True
            lblDay.Visible = True
            ddlYear2.Visible = True
            lblYea2.Visible = True
            ddlMonth2.Visible = True
            lblMon2.Visible = True
            ddlDay2.Visible = True
            lblDay2.Visible = True
            lblFrom.Visible = True
            lblTo.Visible = True
        Else
            ddlDay.Visible = False
            lblDay.Visible = False
            ddlYear2.Visible = False
            lblYea2.Visible = False
            ddlMonth2.Visible = False
            lblMon2.Visible = False
            ddlDay2.Visible = False
            lblDay2.Visible = False
            lblFrom.Visible = False
            lblTo.Visible = False
        End If
        clean()
    End Sub

    Private Sub Create_Table(ByVal Tabl As Table, ByVal param As ArrayList, ByVal sav As Int16)
        Dim r As TableRow = New TableRow
        Dim c As TableCell = New TableCell
        Dim i As Int16 = 1
        Dim x As Int16 = 0
        Do While i < param(0)
            r = New TableRow
            c = New TableCell
            c.Text = param.Item(i)
            i += 1
            c.Width = New Unit("140px")
            If i < 7 Then
                objM.setHeaderCell(c)
            Else : c.HorizontalAlign = HorizontalAlign.Left
            End If
            r.Cells.Add(c)
            For x = 1 To 4 Step 1
                c = New TableCell
                c.Text = param.Item(i)
                i += 1
                c.Width = New Unit("60px")
                If i < 7 Then
                    objM.setHeaderCell(c)
                Else : c.HorizontalAlign = HorizontalAlign.Right
                End If
                r.Cells.Add(c)
            Next
            Tabl.Rows.Add(r)
        Loop

        Session("typeOpReturn") = lblTypeOp.Text
        If sav = 0 Then
            Session("tblReturn") = Tabl
            Session("dateReturn") = lblDate1.Text
        ElseIf sav = 1 Then
            Dim tmp As New ArrayList
            tmp.Add(Tabl)
            Session("tblReturn") = tmp
            Dim tempD As New ArrayList
            tempD.Add(lblDate1.Text)
            tempD.Add(lblDate2.Text)
            tempD.Add(lblDate3.Text)
            tempD.Add(lblDate4.Text)
            tempD.Add(lblDate5.Text)
            tempD.Add(lblDate6.Text)
            tempD.Add(lblDate7.Text)
            tempD.Add(lblDate8.Text)
            tempD.Add(lblDate9.Text)
            tempD.Add(lblDate10.Text)
            tempD.Add(lblDate11.Text)
            tempD.Add(lblDate12.Text)
            Session("dateReturn") = tempD
        ElseIf sav = 2 Then
            Dim tmp As ArrayList = Session("tblReturn")
            tmp.Add(Tabl)
            Session("tblReturn") = tmp
        Else
            Session("tblReturn") = Tabl
            Dim tempD As New ArrayList
            tempD.Add(lblDate1.Text)
            tempD.Add(lblDateTo.Text)
            Session("dateReturn") = tempD
        End If
    End Sub

    Private Sub Create_Table3(ByVal Tabl As Table, ByVal param As ArrayList)
        Dim r As TableRow = New TableRow
        Dim c As TableCell = New TableCell
        Dim i As Int16 = 1
        Dim x As Int16 = 0
        Do While i < param(0)
            r = New TableRow
            c = New TableCell
            c.Text = param.Item(i)
            i += 1
            c.Width = New Unit("140px")
            If i < 6 Then
                objM.setHeaderCell(c)
            Else : c.HorizontalAlign = HorizontalAlign.Left
            End If
            r.Cells.Add(c)
            For x = 1 To 3 Step 1
                c = New TableCell
                c.Text = param.Item(i)
                i += 1
                c.Width = New Unit("60px")
                If i < 6 Then
                    objM.setHeaderCell(c)
                Else : c.HorizontalAlign = HorizontalAlign.Right
                End If
                r.Cells.Add(c)
            Next
            Tabl.Rows.Add(r)
        Loop

        Session("typeOpReturn") = lblTypeOp.Text
        Session("tblReturn") = Tabl
        Session("dateReturn") = lblDate1.Text
    End Sub

    Private Sub Calc_Avg_MY(ByVal div As Int16)
        Dim m As String = htMonth.Item(ddlMonth.SelectedValue)
        Dim y As String = ddlYear.SelectedValue
        Dim param As ArrayList = New ArrayList

        Dim totC As Double = 0
        Dim totE As Double = 0
        Dim totAl As Double = 0
        Dim totAm As Double = 0
        Dim vc As Double = 0
        Dim ve As Double = 0
        Dim val As Double = 0
        Dim vam As Double = 0

        Dim arDesc As Hashtable = objM.loadDescr()

        param.Add(60)
        param.Add(GetLabel("statsPGFunc.lblNivDesc"))
        param.Add(GetLabel("statsPGFunc.lblCr"))
        param.Add(GetLabel("statsPGFunc.lblAlL"))
        param.Add(GetLabel("statsPGFunc.lblAlM"))
        param.Add(GetLabel("statsPGFunc.lblEl"))

        Dim tmp As ArrayList
        For Each desc As String In objM.loadNivDescr
            param.Add(GetLabel("statsPGFunc.lbl" & desc))
            vc = objI.stCalcTotMonAll(arDesc(desc), 1, m, y)
            totC += vc
            param.Add(String.Format(objM.formatString, vc / div))

            tmp = objI.stCalcTotMonAllAl(arDesc(desc), m, y)
            val = tmp(0)
            vam = tmp(1)
            totAl += val
            totAm += vam
            param.Add(String.Format(objM.formatString, val / div))
            param.Add(String.Format(objM.formatString, vam / div))

            ve = objI.stCalcTotMonAll(arDesc(desc), 3, m, y)
            totE += ve
            param.Add(String.Format(objM.formatString, ve / div))
        Next

        param.Add(GetLabel("statsPGFunc.lblAvOp"))
        param.Add(String.Format(objM.formatString, totC / div))
        param.Add(String.Format(objM.formatString, totAl / div))
        param.Add(String.Format(objM.formatString, totAm / div))
        param.Add(String.Format(objM.formatString, totE / div))

        Create_Table(Table1, param, 0)
    End Sub

    Private Sub Calc_Avg_Y(ByVal div As Int16)
        Dim y As String = ddlYear.SelectedValue
        Dim param As ArrayList = New ArrayList

        Dim totC As Double = 0
        Dim totE As Double = 0
        Dim totAl As Double = 0
        Dim totAm As Double = 0
        Dim vc As Double = 0
        Dim ve As Double = 0
        Dim val As Double = 0
        Dim vam As Double = 0

        Dim arDesc As Hashtable = objM.loadDescr()

        param.Add(60)
        param.Add(GetLabel("statsPGFunc.lblNivDesc"))
        param.Add(GetLabel("statsPGFunc.lblCr"))
        param.Add(GetLabel("statsPGFunc.lblAlL"))
        param.Add(GetLabel("statsPGFunc.lblAlM"))
        param.Add(GetLabel("statsPGFunc.lblEl"))

        Dim tmp As New ArrayList
        For Each desc As String In objM.loadNivDescr
            param.Add(GetLabel("statsPGFunc.lbl" & desc))
            vc = objI.stCalcTotYearAll(arDesc(desc), 1, y)
            totC += vc
            param.Add(String.Format(objM.formatString, vc / div))

            tmp = objI.stCalcTotYearAllAl(arDesc(desc), y)
            val = tmp(0)
            vam = tmp(1)
            totAl += val
            totAm += vam
            param.Add(String.Format(objM.formatString, val / div))
            param.Add(String.Format(objM.formatString, vam / div))

            ve = objI.stCalcTotYearAll(arDesc(desc), 3, y)
            totE += ve
            param.Add(String.Format(objM.formatString, ve / div))
        Next

        param.Add(GetLabel("statsPGFunc.lblAvOp"))
        param.Add(String.Format(objM.formatString, totC / div))
        param.Add(String.Format(objM.formatString, totAl / div))
        param.Add(String.Format(objM.formatString, totAm / div))
        param.Add(String.Format(objM.formatString, totE / div))

        Create_Table(Table1, param, 0)
    End Sub

    Private Sub Calc_Tot_Mon(ByVal Tabl As Table, ByVal m As String, ByVal sav As Int16)
        Dim y As String = ddlYear.SelectedValue
        Dim param As ArrayList = New ArrayList

        Dim totC As Double = 0
        Dim totE As Double = 0
        Dim totAl As Double = 0
        Dim totAm As Double = 0
        Dim vc As Double = 0
        Dim ve As Double = 0
        Dim val As Double = 0
        Dim vam As Double = 0

        Dim arDesc As Hashtable = objM.loadDescr()

        param.Add(60)
        param.Add(GetLabel("statsPGFunc.lblNivDesc"))
        param.Add(GetLabel("statsPGFunc.lblCr"))
        param.Add(GetLabel("statsPGFunc.lblAlL"))
        param.Add(GetLabel("statsPGFunc.lblAlM"))
        param.Add(GetLabel("statsPGFunc.lblEl"))

        Dim tmp As New ArrayList
        For Each desc As String In objM.loadNivDescr
            param.Add(GetLabel("statsPGFunc.lbl" & desc))
            vc = objI.stCalcTotMonAll(arDesc(desc), 1, m, y)
            totC += vc
            param.Add(vc)

            tmp = objI.stCalcTotMonAllAl(arDesc(desc), m, y)
            val = tmp(0)
            vam = tmp(1)
            totAl += val
            totAm += vam
            param.Add(val)
            param.Add(vam)

            ve = objI.stCalcTotMonAll(arDesc(desc), 3, m, y)
            totE += ve
            param.Add(ve)
        Next

        param.Add(GetLabel("statsPGFunc.lblTotOp"))
        param.Add(totC)
        param.Add(totAl)
        param.Add(totAm)
        param.Add(totE)

        Create_Table(Tabl, param, sav)
    End Sub

    Private Sub Calc_Tot_Year()
        Dim y As String = ddlYear.SelectedValue
        Dim param As ArrayList = New ArrayList

        Dim totC As Double = 0
        Dim totE As Double = 0
        Dim totAl As Double = 0
        Dim totAm As Double = 0
        Dim vc As Double = 0
        Dim ve As Double = 0
        Dim val As Double = 0
        Dim vam As Double = 0

        Dim arDesc As Hashtable = objM.loadDescr()

        param.Add(60)
        param.Add(GetLabel("statsPGFunc.lblNivDesc"))
        param.Add(GetLabel("statsPGFunc.lblCr"))
        param.Add(GetLabel("statsPGFunc.lblAlL"))
        param.Add(GetLabel("statsPGFunc.lblAlM"))
        param.Add(GetLabel("statsPGFunc.lblEl"))

        Dim tmp As New ArrayList
        For Each desc As String In objM.loadNivDescr
            param.Add(GetLabel("statsPGFunc.lbl" & desc))
            vc = objI.stCalcTotYearAll(arDesc(desc), 1, y)
            totC += vc
            param.Add(vc)

            tmp = objI.stCalcTotYearAllAl(arDesc(desc), y)
            val = tmp(0)
            vam = tmp(1)
            totAl += val
            totAm += vam
            param.Add(val)
            param.Add(vam)

            ve = objI.stCalcTotYearAll(arDesc(desc), 3, y)
            totE += ve
            param.Add(ve)
        Next

        param.Add(GetLabel("statsPGFunc.lblTotOp"))
        param.Add(totC)
        param.Add(totAl)
        param.Add(totAm)
        param.Add(totE)

        Create_Table(Table1, param, 0)
    End Sub

    Private Sub Calc_Tot_Months_Year_Niv()
        Calc_Tot_Mon(Table1, "1", 1)
        Calc_Tot_Mon(Table2, "2", 2)
        Calc_Tot_Mon(Table3, "3", 2)
        Calc_Tot_Mon(Table4, "4", 2)
        Calc_Tot_Mon(Table5, "5", 2)
        Calc_Tot_Mon(Table6, "6", 2)
        Calc_Tot_Mon(Table7, "7", 2)
        Calc_Tot_Mon(Table8, "8", 2)
        Calc_Tot_Mon(Table9, "9", 2)
        Calc_Tot_Mon(Table10, "10", 2)
        Calc_Tot_Mon(Table11, "11", 2)
        Calc_Tot_Mon(Table12, "12", 2)
    End Sub

    Private Sub Calc_Tot_Months_Year()
        Dim y As String = ddlYear.SelectedValue
        Dim param As ArrayList = New ArrayList

        Dim totC As Double = 0
        Dim totE As Double = 0
        Dim totAl As Double = 0
        Dim totAm As Double = 0
        Dim vc As Double = 0
        Dim ve As Double = 0
        Dim val As Double = 0
        Dim vam As Double = 0

        param.Add(70)
        param.Add(GetLabel("statsPGFunc.lblNivDesc"))
        param.Add(GetLabel("statsPGFunc.lblCr"))
        param.Add(GetLabel("statsPGFunc.lblAlL"))
        param.Add(GetLabel("statsPGFunc.lblAlM"))
        param.Add(GetLabel("statsPGFunc.lblEl"))

        Dim hshM As Hashtable = objM.loadHTMonth2()
        Dim m As Integer
        Dim tmp As New ArrayList
        For m = 1 To 12 Step 1
            param.Add(hshM(m))
            vc = objI.stCalcTotMonAll(1, m.ToString, y)
            totC += vc
            param.Add(vc)

            tmp = objI.stCalcTotMonAllAl(m.ToString, y)
            val = tmp(0)
            vam = tmp(1)
            totAl += val
            totAm += vam
            param.Add(val)
            param.Add(vam)

            ve = objI.stCalcTotMonAll(3, m.ToString, y)
            totE += ve
            param.Add(ve)
        Next

        param.Add(GetLabel("statsPGFunc.lblTotOp"))
        param.Add(totC)
        param.Add(totAl)
        param.Add(totAm)
        param.Add(totE)

        Create_Table(Table1, param, 0)
    End Sub

    Private Sub Calc_Perc_Func()
        Dim year As String = ddlYear.SelectedValue

        Dim htFunc_C As Hashtable = objI.stGetOpsPerUser(year, 1)
        Dim htFunc_A1 As Hashtable = objI.stGetOpsPerUser(year, 4)
        Dim htFunc_A2 As Hashtable = objI.stGetOpsPerUser(year, 8)
        Dim htFunc_E As Hashtable = objI.stGetOpsPerUser(year, 3)
        Dim totalC As Double = objI.stCalcNumOps(year, 1)
        Dim totalA As Double = objI.stCalcNumOps(year, 8)
        totalA += objI.stCalcNumOps(year, 4)
        Dim totalE As Double = objI.stCalcNumOps(year, 3)
        Dim hshFunc As Hashtable = objI.stLoadEmployeesNames()
        Dim htFunc_A As New Hashtable

        Dim keys As SortedList = objM.SortedListFromHashtables(htFunc_A1, htFunc_A2)

        Dim count As Int32
        For Each key As DictionaryEntry In keys
            count = 0
            If htFunc_A1.Contains(key.Value) Then
                count += htFunc_A1(key.Value)
            End If
            If htFunc_A2.Contains(key.Value) Then
                count += htFunc_A2(key.Value)
            End If
            htFunc_A.Add(key.Value, count)
        Next

        Dim param As ArrayList = New ArrayList
        param.Add((hshFunc.Count + 1) * 4)
        param.Add(GetLabel("statsPGArq.lblFunc"))
        param.Add(GetLabel("statsPGFunc.lblCr"))
        param.Add(GetLabel("statsPGFunc.lblAl"))
        param.Add(GetLabel("statsPGFunc.lblEl"))

        Dim c As New TableCell
        Dim r As New TableRow
        c.Text = "Nada"
        r.Cells.Add(c)
        c = New TableCell
        c.Text = GetLabel("statsPGFunc.lblCr")
        r.Cells.Add(c)
        c = New TableCell
        c.Text = GetLabel("statsPGFunc.lblAl")
        r.Cells.Add(c)
        c = New TableCell
        c.Text = GetLabel("statsPGFunc.lblEl")
        r.Cells.Add(c)
        TableT.Rows.Add(r)

        Dim arTmp As ArrayList = New ArrayList(hshFunc.Keys)
        arTmp.Sort()
        For Each usrn As String In arTmp
            r = New TableRow
            c = New TableCell
            param.Add(hshFunc(usrn))
            c.Text = hshFunc(usrn)
            r.Cells.Add(c)
            c = New TableCell
            If (htFunc_C.Contains(usrn)) Then
                param.Add(String.Format(objM.formatStringPerc, Convert.ToDouble(htFunc_C(usrn)) / totalC))
                c.Text = htFunc_C(usrn)
            Else
                param.Add("0,00%")
                c.Text = 0
            End If
            r.Cells.Add(c)
            c = New TableCell
            If (htFunc_A.Contains(usrn)) Then
                param.Add(String.Format(objM.formatStringPerc, Convert.ToDouble(htFunc_A(usrn)) / totalA))
                c.Text = htFunc_A(usrn)
            Else
                param.Add("0,00%")
                c.Text = 0
            End If
            r.Cells.Add(c)
            c = New TableCell
            If (htFunc_E.Contains(usrn)) Then
                param.Add(String.Format(objM.formatStringPerc, Convert.ToDouble(htFunc_E(usrn)) / totalE))
                c.Text = htFunc_E(usrn)
            Else
                param.Add("0,00%")
                c.Text = 0
            End If
            r.Cells.Add(c)
            TableT.Rows.Add(r)
        Next

        Create_Table3(Table1, param)
        objM.MakeChartNT(TableT, chart1, GetLabel("statsPGArq.lblChPercCr"), 1)
        objM.MakeChartNT(TableT, chart2, GetLabel("statsPGArq.lblChPercAl"), 2)
        objM.MakeChartNT(TableT, chart3, GetLabel("statsPGArq.lblChPercEl"), 3)
    End Sub

    Private Sub Calc_Tot_Period()
        Dim from As String = ddlYear.SelectedValue & "-" & htMonth.Item(ddlMonth.SelectedValue) & "-" & ddlDay.SelectedValue
        Dim t As String = ddlYear2.SelectedValue & "-" & htMonth.Item(ddlMonth2.SelectedValue) & "-" & ddlDay2.SelectedValue
        Dim param As ArrayList = New ArrayList

        Dim totC As Double = 0
        Dim totE As Double = 0
        Dim totAl As Double = 0
        Dim totAm As Double = 0
        Dim vc As Double = 0
        Dim ve As Double = 0
        Dim val As Double = 0
        Dim vam As Double = 0

        Dim arDesc As Hashtable = objM.loadDescr()

        param.Add(60)
        param.Add(GetLabel("statsPGFunc.lblNivDesc"))
        param.Add(GetLabel("statsPGFunc.lblCr"))
        param.Add(GetLabel("statsPGFunc.lblAlL"))
        param.Add(GetLabel("statsPGFunc.lblAlM"))
        param.Add(GetLabel("statsPGFunc.lblEl"))

        Dim tmp As New ArrayList
        For Each desc As String In objM.loadNivDescr
            param.Add(GetLabel("statsPGFunc.lbl" & desc))
            vc = objI.stCalcTotPeriodAll(arDesc(desc), 1, from, t)
            totC += vc
            param.Add(vc)

            tmp = objI.stCalcTotPeriodAllAl(arDesc(desc), from, t)
            val = tmp(0)
            vam = tmp(1)
            totAl += val
            totAm += vam
            param.Add(val)
            param.Add(vam)

            ve = objI.stCalcTotPeriodAll(arDesc(desc), 3, from, t)
            totE += ve
            param.Add(ve)
        Next

        param.Add(GetLabel("statsPGFunc.lblTotOp"))
        param.Add(totC)
        param.Add(totAl)
        param.Add(totAm)
        param.Add(totE)

        Create_Table(Table1, param, 3)
    End Sub

    Private Sub Calc_Avg_Period()
        Dim from As String = ddlYear.SelectedValue & "/" & htMonth.Item(ddlMonth.SelectedValue) & "/" & ddlDay.SelectedValue
        Dim t As String = ddlYear2.SelectedValue & "/" & htMonth.Item(ddlMonth2.SelectedValue) & "/" & ddlDay2.SelectedValue
        Dim param As ArrayList = New ArrayList
        Dim div As Double = (DateDiff("d", from, t) / 7) * 5

        Dim totC As Double = 0
        Dim totE As Double = 0
        Dim totAl As Double = 0
        Dim totAm As Double = 0
        Dim vc As Double = 0
        Dim ve As Double = 0
        Dim val As Double = 0
        Dim vam As Double = 0

        Dim arDesc As Hashtable = objM.loadDescr()

        param.Add(60)
        param.Add(GetLabel("statsPGFunc.lblNivDesc"))
        param.Add(GetLabel("statsPGFunc.lblCr"))
        param.Add(GetLabel("statsPGFunc.lblAlL"))
        param.Add(GetLabel("statsPGFunc.lblAlM"))
        param.Add(GetLabel("statsPGFunc.lblEl"))

        Dim tmp As New ArrayList
        For Each desc As String In objM.loadNivDescr
            param.Add(GetLabel("statsPGFunc.lbl" & desc))
            vc = objI.stCalcTotPeriodAll(arDesc(desc), 1, from, t)
            totC += vc
            param.Add(String.Format(objM.formatString, vc / div))

            tmp = objI.stCalcTotPeriodAllAl(arDesc(desc), from, t)
            val = tmp(0)
            vam = tmp(1)
            totAl += val
            totAm += vam
            param.Add(String.Format(objM.formatString, val / div))
            param.Add(String.Format(objM.formatString, vam / div))

            ve = objI.stCalcTotPeriodAll(arDesc(desc), 3, from, t)
            totE += ve
            param.Add(String.Format(objM.formatString, ve / div))
        Next

        param.Add(GetLabel("statsPGFunc.lblTotOp"))
        param.Add(String.Format(objM.formatString, totC / div))
        param.Add(String.Format(objM.formatString, totAl / div))
        param.Add(String.Format(objM.formatString, totAm / div))
        param.Add(String.Format(objM.formatString, totE / div))

        Create_Table(Table1, param, 3)
    End Sub

    Private Sub lnkbExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkbExport.Click
        Dim sw As New StringWriter
        sw.Write(GetLabel("stats.lblExecutionTime"))
        sw.WriteLine(Date.Now)
        sw.WriteLine()
        sw.WriteLine(Session("typeOpReturn"))
        If rblChoice.SelectedValue = GetLabel("statsPGFunc.rblTotMontYearNiv") Then
            Dim am As ArrayList = Session("dateReturn")
            Dim ar As ArrayList = Session("tblReturn")
            sw.WriteLine(lblTypeOp.Text)
            sw.WriteLine()
            sw.WriteLine(am(0))
            sw.WriteLine(objM.exportCSV5(ar(0)).ToString)
            sw.WriteLine()
            sw.WriteLine(am(1))
            sw.WriteLine(objM.exportCSV5(ar(1)).ToString)
            sw.WriteLine()
            sw.WriteLine(am(2))
            sw.WriteLine(objM.exportCSV5(ar(2)).ToString)
            sw.WriteLine()
            sw.WriteLine(am(3))
            sw.WriteLine(objM.exportCSV5(ar(3)).ToString)
            sw.WriteLine()
            sw.WriteLine(am(4))
            sw.WriteLine(objM.exportCSV5(ar(4)).ToString)
            sw.WriteLine()
            sw.WriteLine(am(5))
            sw.WriteLine(objM.exportCSV5(ar(5)).ToString)
            sw.WriteLine()
            sw.WriteLine(am(6))
            sw.WriteLine(objM.exportCSV5(ar(6)).ToString)
            sw.WriteLine()
            sw.WriteLine(am(7))
            sw.WriteLine(objM.exportCSV5(ar(7)).ToString)
            sw.WriteLine()
            sw.WriteLine(am(8))
            sw.WriteLine(objM.exportCSV5(ar(8)).ToString)
            sw.WriteLine()
            sw.WriteLine(am(9))
            sw.WriteLine(objM.exportCSV5(ar(9)).ToString)
            sw.WriteLine()
            sw.WriteLine(am(10))
            sw.WriteLine(objM.exportCSV5(ar(10)).ToString)
            sw.WriteLine()
            sw.WriteLine(am(11))
            sw.WriteLine(objM.exportCSV5(ar(11)).ToString)
        ElseIf rblChoice.SelectedValue = GetLabel("statsPGFunc.rblAveraPer") Or rblChoice.SelectedValue = GetLabel("statsPGFunc.rblTotalPer") Then
            Table1 = Session("tblReturn")
            Dim am As ArrayList = Session("dateReturn")
            sw.WriteLine(lblTypeOp.Text)
            sw.WriteLine()
            sw.WriteLine(am(0))
            sw.WriteLine(am(1))
            sw.WriteLine(objM.exportCSV5(Table1).ToString)
        Else
            Table1 = Session("tblReturn")
            sw.WriteLine(lblTypeOp.Text)
            sw.WriteLine()
            sw.WriteLine(Session("dateReturn"))
            If rblChoice.SelectedValue = GetLabel("statsPGArq.rblPercFunc") Then
                sw.WriteLine(objM.exportCSV4(Table1).ToString)
            Else : sw.WriteLine(objM.exportCSV5(Table1).ToString)
            End If
        End If

        Response.AddHeader("content-disposition", "attachment;filename=pgDefault.csv")
        Response.ContentType = "application/vnd.csv"
        Response.ContentEncoding = System.Text.Encoding.Default
        ' Remove the charset from the Content-Type header.
        Response.Charset = ""
        ' Turn off the view state.
        'Me.EnableViewState = False

        ' Write the HTML back to the browser.
        Response.Write(sw.ToString)
        ' End the response.
        Response.End()
    End Sub

End Class