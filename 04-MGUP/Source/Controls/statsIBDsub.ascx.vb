
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
Imports blong.WebControls

Public Class statsIBDsub
    Inherits BaseClassUC

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents rblChoice As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblTypeOp1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblTypeOp2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblTypeOp3 As System.Web.UI.WebControls.Label
    Protected WithEvents lblWarn As System.Web.UI.WebControls.Label
    Protected WithEvents Tabl1 As System.Web.UI.WebControls.Table
    Protected WithEvents Tabl2 As System.Web.UI.WebControls.Table
    Protected WithEvents Tabl3 As System.Web.UI.WebControls.Table
    Protected WithEvents chart1 As blong.WebControls.WebChart
    Protected WithEvents chart2 As blong.WebControls.WebChart
    Protected WithEvents chart3 As blong.WebControls.WebChart
    Protected WithEvents lnkbExport As System.Web.UI.WebControls.LinkButton

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Me.Page.IsPostBack Then
            lnkbExport.Text = GetLabel("statsButton.lblExport")
            LoadChoices()
        End If
        chart1.Visible = False
        chart2.Visible = False
        chart3.Visible = False
        'End if (Não permite exportar pois apaga a tabela)
    End Sub

    Private Sub LoadChoices()
        Dim al As ArrayList = New ArrayList
        al.Add(GetLabel("statsIBD.rblArqGrup"))
        al.Add(GetLabel("statsIBD.rblFund"))
        al.Add(GetLabel("statsIBD.rblReg"))
        Me.rblChoice.DataSource = al
        Me.rblChoice.DataBind()
    End Sub

    Private Sub execute()
        If rblChoice.SelectedValue = GetLabel("statsIBD.rblArqGrup") Then
            lblTypeOp1.Text = GetLabel("statsPGFunc.TypeOp") & GetLabel("statsIBD.rblArqGrup")
            Calc_Grup_Arq()
        Else
            If rblChoice.SelectedValue = GetLabel("statsIBD.rblFund") Then
                lblTypeOp1.Text = GetLabel("statsPGFunc.TypeOp") & GetLabel("statsIBD.lblNivTreat")
                lblTypeOp2.Text = GetLabel("statsPGFunc.TypeOp") & GetLabel("statsIBD.lblFundRev")
                lblTypeOp3.Text = GetLabel("statsPGFunc.TypeOp") & GetLabel("statsIBD.lblFundVis")
                Calc_Fund()
            ElseIf rblChoice.SelectedValue = GetLabel("statsIBD.rblReg") Then
                lblTypeOp1.Text = GetLabel("statsPGFunc.TypeOp") & GetLabel("statsIBD.lblRefReg")
                lblTypeOp2.Text = GetLabel("statsPGFunc.TypeOp") & GetLabel("statsIBD.lblRegRev")
                lblTypeOp3.Text = GetLabel("statsPGFunc.TypeOp") & GetLabel("statsIBD.lblRegVis")
                Calc_Reg()
            End If
            chart2.Visible = True
            chart3.Visible = True
        End If
        lnkbExport.Visible = True
        chart1.Visible = True
    End Sub

    Private Sub rblChoice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblChoice.SelectedIndexChanged
        lblTypeOp2.Text = ""
        lblTypeOp3.Text = ""
        lblWarn.Text = ""
        execute()
    End Sub

    Private Sub Calc_Grup_Arq()
        Dim ht As Hashtable = objI.stLoadCUIDF()
        Dim ar As ArrayList = New ArrayList(ht.Keys)
        Dim x As Integer
        Dim total As Double = 0
        For Each arq As ArquiveGroup In ht.Values
            total += arq.getNumber()
        Next
        Create_Tabl_Arq(ht, total)

        objM.MakeChart(Tabl1, chart1, GetLabel("statsIBD.rblArqGrup"), True, 1)
    End Sub

    Private Sub Calc_Fund()
        Dim param As ArrayList = New ArrayList

        Dim dF As Double = objI.stGetNDescr("F")
        Dim dSC As Double = objI.stGetNDescr("SC")
        Dim dSR As Double = objI.stGetNDescr("SR")
        Dim dUI As Double = objI.stGetNDescr("UI")
        Dim dD As Double = objI.stGetNDescr("D")

        Dim doTF As Double = dF + dSC + dSR + dUI + dD

        Dim dFR As Double = objI.stCalcNumFundRev()
        Dim dFV As Double = objI.stCalcNumFundVis()

        param.Add(GetLabel("statsPGFunc.lblNivDesc"))
        param.Add(GetLabel("statsIBD.lblNumFund"))
        param.Add(GetLabel("statsIBD.lblPercFund"))
        param.Add(GetLabel("statsIBD.lblDescF"))
        param.Add(dF)
        param.Add(String.Format(objM.formatStringPerc, (Convert.ToDouble(dF / doTF))))
        param.Add(GetLabel("statsIBD.lblDescSC"))
        param.Add(dSC)
        param.Add(String.Format(objM.formatStringPerc, (Convert.ToDouble(dSC / doTF))))
        param.Add(GetLabel("statsIBD.lblDescSR"))
        param.Add(dSR)
        param.Add(String.Format(objM.formatStringPerc, (Convert.ToDouble(dSR / doTF))))
        param.Add(GetLabel("statsIBD.lblDescUI"))
        param.Add(dUI)
        param.Add(String.Format(objM.formatStringPerc, (Convert.ToDouble(dUI / doTF))))
        param.Add(GetLabel("statsIBD.lblDescD"))
        param.Add(dD)
        param.Add(String.Format(objM.formatStringPerc, (Convert.ToDouble(dD / doTF))))
        param.Add(GetLabel("statsIBD.lblNumTotFund"))
        param.Add(doTF)
        param.Add("")

        If objI.stCalcWarn() <> 0 Then
            lblWarn.Text = GetLabel("statsIBD.Warning")
        End If

        Create_Tabl1_Fund(param)
        Create_Tabl_2_3(Tabl2, dFR, doTF, 0)
        Create_Tabl_2_3(Tabl3, dFV, doTF, 1)

        objM.MakeChart(Tabl1, chart1, GetLabel("statsIBD.lblNivTreat"), 1, 1)
        objM.MakeChart(Tabl2, chart2, GetLabel("statsIBD.lblFundRev"), 0, 1)
        objM.MakeChart(Tabl3, chart3, GetLabel("statsIBD.lblFundVis"), 0, 1)
    End Sub

    Private Sub Calc_Reg()
        Dim dTR As Double = objI.stCalcTotReg()
        Dim dRR As Double = objI.stCalcTotRegRev()
        Dim dRV As Double = objI.stCalcTotRegVis()

        Dim rc As Int32 = objI.stChkRegC()
        Create_Tabl1_Reg(rc, dTR)
        Create_Tabl_2_3(Tabl2, dRR, dTR, 2)
        Create_Tabl_2_3(Tabl3, dRV, dTR, 3)

        objM.MakeChart(Tabl1, chart1, GetLabel("statsIBD.lblRefReg"), 0, 1)
        objM.MakeChart(Tabl2, chart2, GetLabel("statsIBD.lblRegRev"), 0, 1)
        objM.MakeChart(Tabl3, chart3, GetLabel("statsIBD.lblRegVis"), 0, 1)
    End Sub

    Private Sub Create_Tabl_Arq(ByVal ht As Hashtable, ByVal total As Double)
        Dim tF As Int32 = 0
        Dim tML As Double = 0
        Dim r As TableRow = New TableRow
        Dim c As TableCell = New TableCell
        c.Text = GetLabel("statsIBD.lblArquive")
        c.Width = New Unit("110px")
        objM.setHeaderCell(c)
        r.Cells.Add(c)
        c = New TableCell
        c.Text = GetLabel("statsIBD.lblNumArquive")
        c.Width = New Unit("90px")
        objM.setHeaderCell(c)
        r.Cells.Add(c)
        c = New TableCell
        c.Text = GetLabel("statsIBD.lblPercArquive")
        c.Width = New Unit("80px")
        objM.setHeaderCell(c)
        r.Cells.Add(c)
        c = New TableCell
        c.Text = GetLabel("statsIBD.lblExtentMlArquive")
        c.Width = New Unit("90px")
        objM.setHeaderCell(c)
        r.Cells.Add(c)
        Tabl1.Rows.Add(r)

        Dim num As Double
        Dim keys As ArrayList = New ArrayList(ht.Keys)
        keys.Sort()
        For Each st As String In keys
            r = New TableRow
            c = New TableCell
            c.Text = st
            c.Width = New Unit("110px")
            c.HorizontalAlign = HorizontalAlign.Left
            r.Cells.Add(c)
            c = New TableCell
            num = ht(st).getNumber()
            tF += num
            c.Text = num.ToString
            c.Width = New Unit("90px")
            r.Cells.Add(c)
            c = New TableCell
            c.Text = String.Format(objM.formatStringPerc, num / total)
            c.Width = New Unit("80px")
            r.Cells.Add(c)
            c = New TableCell
            tML += ht(st).getExtentMl()
            c.Text = ht(st).getExtentMl()
            c.Width = New Unit("90px")
            r.Cells.Add(c)
            Tabl1.Rows.Add(r)
        Next

        r = New TableRow
        c = New TableCell
        c.Text = GetLabel("statsIBDsub.lblTotal")
        c.Width = New Unit("110px")
        c.HorizontalAlign = HorizontalAlign.Left
        r.Cells.Add(c)
        c = New TableCell
        c.Text = tF
        c.Width = New Unit("90px")
        r.Cells.Add(c)
        c = New TableCell
        c.Text = String.Format(objM.formatStringPerc, tF / total)
        c.Width = New Unit("80px")
        r.Cells.Add(c)
        c = New TableCell
        c.Text = tML
        c.Width = New Unit("90px")
        r.Cells.Add(c)
        Tabl1.Rows.Add(r)

        Session("tblReturn") = Tabl1
    End Sub

    Private Sub Create_Tabl1_Fund(ByVal param As ArrayList)
        Dim r As TableRow = New TableRow
        Dim c As TableCell = New TableCell

        Dim i As Int16 = 0
        Do While i < 21
            r = New TableRow
            c = New TableCell
            c.Text = param.Item(i)
            i += 1
            c.Width = New Unit("151px")
            If i < 2 Then
                objM.setHeaderCell(c)
            Else : c.HorizontalAlign = HorizontalAlign.Left
            End If
            r.Cells.Add(c)
            c = New TableCell
            c.Text = param.Item(i)
            i += 1
            c.Width = New Unit("100px")
            If i < 3 Then
                objM.setHeaderCell(c)
            End If
            r.Cells.Add(c)
            c = New TableCell
            c.Text = param.Item(i)
            i += 1
            c.Width = New Unit("100px")
            If i < 4 Then
                objM.setHeaderCell(c)
            End If
            r.Cells.Add(c)
            Tabl1.Rows.Add(r)
        Loop

        Session("tblReturn") = Tabl1
    End Sub

    Private Sub Create_Tabl1_Reg(ByVal dRC As Double, ByVal doTR As Double)
        'NUMERO DE REGISTOS COM REFERENCIAS COMPLETAS
        Dim r As TableRow = New TableRow
        Dim c As TableCell = New TableCell
        c.Text = GetLabel("statsIBD.lblNumRegRefC")
        c.Width = New Unit("260px")
        objM.setHeaderCell(c)
        r.Cells.Add(c)
        c = New TableCell
        c.Text = dRC.ToString
        c.Width = New Unit("100px")
        r.Cells.Add(c)
        Tabl1.Rows.Add(r)

        'NUMERO DE REGISTOS COM REFERENCIAS INCOMPLETAS
        r = New TableRow
        c = New TableCell
        c.Text = GetLabel("statsIBD.lblNumRegRefI")
        c.Width = New Unit("260px")
        objM.setHeaderCell(c)
        r.Cells.Add(c)
        c = New TableCell
        c.Text = Convert.ToString(doTR - dRC)
        c.Width = New Unit("100px")
        r.Cells.Add(c)
        Tabl1.Rows.Add(r)

        'NUMERO TOTAL DE REGISTOS
        r = New TableRow
        c = New TableCell
        c.Text = GetLabel("statsIBD.lblNumTotReg")
        c.Width = New Unit("260px")
        objM.setHeaderCell(c)
        r.Cells.Add(c)
        c = New TableCell
        c.Text = doTR.ToString
        c.Width = New Unit("100px")
        r.Cells.Add(c)
        Tabl1.Rows.Add(r)

        Session("tblReturn") = Tabl1
    End Sub

    Private Sub Create_Tabl_2_3(ByVal tab As Table, ByVal dFR As Double, ByVal doTF As Double, ByVal flag As Int16)
        Dim r As TableRow = New TableRow
        Dim c As TableCell = New TableCell
        r = New TableRow
        c = New TableCell
        If flag = 0 Then
            c.Text = GetLabel("statsIBD.lblNumFundRev")
        ElseIf flag = 1 Then
            c.Text = GetLabel("statsIBD.lblNumFundVis")
        ElseIf flag = 2 Then
            c.Text = GetLabel("statsIBD.lblNumRegRev")
        Else : c.Text = GetLabel("statsIBD.lblNumRegVis")
        End If
        c.Width = New Unit("260px")
        objM.setHeaderCell(c)
        r.Cells.Add(c)
        c = New TableCell
        c.Text = dFR.ToString
        c.Width = New Unit("100px")
        r.Cells.Add(c)
        tab.Rows.Add(r)

        r = New TableRow
        c = New TableCell
        If flag = 0 Then
            c.Text = GetLabel("statsIBD.lblNumFundNRev")
        ElseIf flag = 1 Then
            c.Text = GetLabel("statsIBD.lblNumFundNVis")
        ElseIf flag = 2 Then
            c.Text = GetLabel("statsIBD.lblNumRegNRev")
        Else : c.Text = GetLabel("statsIBD.lblNumRegNVis")
        End If
        c.Width = New Unit("260px")
        objM.setHeaderCell(c)
        r.Cells.Add(c)
        c = New TableCell
        c.Text = Convert.ToString(doTF - dFR)
        c.Width = New Unit("100px")
        r.Cells.Add(c)
        tab.Rows.Add(r)

        r = New TableRow
        c = New TableCell
        If flag = 0 Or flag = 1 Then
            c.Text = GetLabel("statsIBD.lblNumTotFund")
        Else : c.Text = GetLabel("statsIBD.lblNumTotReg")
        End If
        c.Width = New Unit("260px")
        objM.setHeaderCell(c)
        r.Cells.Add(c)
        c = New TableCell
        c.Text = doTF.ToString
        c.Width = New Unit("100px")
        r.Cells.Add(c)
        tab.Rows.Add(r)
        If flag = 0 Or flag = 2 Then
            Session("tbl2Return") = tab
        Else : Session("tbl3Return") = tab
        End If
    End Sub

    Private Sub lnkbExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkbExport.Click
        Dim sw As New StringWriter
        sw.Write(GetLabel("stats.lblExecutionTime"))
        sw.WriteLine(Date.Now)
        sw.WriteLine()
        sw.WriteLine(lblTypeOp1.Text)
        sw.WriteLine()
        If rblChoice.SelectedValue = GetLabel("statsIBD.rblArqGrup") Then
            sw.WriteLine(objM.exportCSV4(Session("tblReturn")).ToString)
        Else
            If rblChoice.SelectedValue = GetLabel("statsIBD.rblFund") Then
                sw.WriteLine(objM.exportCSV3(Session("tblReturn")))
                sw.WriteLine()
            ElseIf rblChoice.SelectedValue = GetLabel("statsIBD.rblReg") Then
                sw.WriteLine(objM.exportCSV2(Session("tblReturn")))
                sw.WriteLine()
            End If
            sw.WriteLine(lblTypeOp2.Text)
            sw.WriteLine()
            sw.WriteLine(objM.exportCSV2(Session("tbl2Return")))
            sw.WriteLine()
            sw.WriteLine(lblTypeOp3.Text)
            sw.WriteLine()
            sw.WriteLine(objM.exportCSV2(Session("tbl3Return")))
        End If

        Response.AddHeader("content-disposition", "attachment;filename=default.csv")
        Response.ContentType = "application/vnd.csv"
        Response.ContentEncoding = System.Text.Encoding.Default
        ' Remove the charset from the Content-Type header.
        Response.Charset = ""
        ' Turn off the view state.
        Me.EnableViewState = False

        ' Write the HTML back to the browser.
        Response.Write(sw.ToString)
        ' End the response.
        Response.End()
    End Sub

End Class