
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

Public Class statsIBDGerRelD
    Inherits BaseClassUC

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Protected WithEvents rblChoice As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents lblTypeOp As System.Web.UI.WebControls.Label
    Protected WithEvents lblInfo As System.Web.UI.WebControls.Label
    Protected WithEvents lnkbExport As System.Web.UI.WebControls.LinkButton
    Protected WithEvents dgRel As System.Web.UI.WebControls.DataGrid

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

    Private myConnString As String = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; password={3}", ServerAddress, GPUDatabase, Username, Password)

    Private objI As SQLDataBase = New SQLDataBase
    Private objM As Misc = New Misc

    Public count As Int32 = 0

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Me.Page.IsPostBack Then
            lnkbExport.Text = GetLabel("statsButton.lblExport")
            loadChoices(rblChoice)
        End If
    End Sub

    Private Sub rblChoice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblChoice.SelectedIndexChanged
        Me.dgRel.CurrentPageIndex() = 0
        Dim ds As New DataSet
        Dim tF As Int32 = objI.stCalcTotFunds()
        Dim tFDescr As New Int32

        If rblChoice.SelectedValue = GetLabel("statsIBDGerRel.rblF") Then
            lblTypeOp.Text = GetLabel("statsIBDGerRel.lblTypeOp") & GetLabel("statsIBDGerRel.lblF")
            ds = objI.stGetDescr("F")
            tFDescr = ds.Tables(0).Rows.Count()
            lblInfo.Text = tFDescr & GetLabel("statsIBDGerRel.lblFde") & tF & " (" & String.Format(objM.formatStringPerc, tFDescr / tF) & ")"
        ElseIf rblChoice.SelectedValue = GetLabel("statsIBDGerRel.rblSC") Then
            lblTypeOp.Text = GetLabel("statsIBDGerRel.lblTypeOp") & GetLabel("statsIBDGerRel.lblSC")
            ds = objI.stGetDescr("SC")
            tFDescr = ds.Tables(0).Rows.Count()
            lblInfo.Text = tFDescr & GetLabel("statsIBDGerRel.lblFde") & tF & " (" & String.Format(objM.formatStringPerc, tFDescr / tF) & ")"
        ElseIf rblChoice.SelectedValue = GetLabel("statsIBDGerRel.rblSR") Then
            lblTypeOp.Text = GetLabel("statsIBDGerRel.lblTypeOp") & GetLabel("statsIBDGerRel.lblSR")
            ds = objI.stGetDescr("SR")
            tFDescr = ds.Tables(0).Rows.Count()
            lblInfo.Text = tFDescr & GetLabel("statsIBDGerRel.lblFde") & tF & " (" & String.Format(objM.formatStringPerc, tFDescr / tF) & ")"
        ElseIf rblChoice.SelectedValue = GetLabel("statsIBDGerRel.rblUI") Then
            lblTypeOp.Text = GetLabel("statsIBDGerRel.lblTypeOp") & GetLabel("statsIBDGerRel.lblUI")
            ds = objI.stGetDescr("UI")
            tFDescr = ds.Tables(0).Rows.Count()
            lblInfo.Text = tFDescr & GetLabel("statsIBDGerRel.lblFde") & tF & " (" & String.Format(objM.formatStringPerc, tFDescr / tF) & ")"
        ElseIf rblChoice.SelectedValue = GetLabel("statsIBDGerRel.rblD") Then
            lblTypeOp.Text = GetLabel("statsIBDGerRel.lblTypeOp") & GetLabel("statsIBDGerRel.lblDDC")
            ds = objI.stGetDescr("D")
            tFDescr = ds.Tables(0).Rows.Count()
            lblInfo.Text = tFDescr & GetLabel("statsIBDGerRel.lblFde") & tF & " (" & String.Format(objM.formatStringPerc, tFDescr / tF) & ")"
        End If

        Dim dt As DataTable = ds.Tables(0)
        Session("tblReturn") = dt
        dgRel.DataSource = dt
        dgRel.DataBind()

        lnkbExport.Visible = True
    End Sub

    Private Sub loadChoices(ByVal rbl As RadioButtonList)
        Dim al As ArrayList = New ArrayList
        al.Add(GetLabel("statsIBDGerRel.rblF"))
        al.Add(GetLabel("statsIBDGerRel.rblSC"))
        al.Add(GetLabel("statsIBDGerRel.rblSR"))
        al.Add(GetLabel("statsIBDGerRel.rblUI"))
        al.Add(GetLabel("statsIBDGerRel.rblD"))
        rbl.DataSource = al
        rbl.DataBind()
    End Sub

    Private Sub lnkbExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkbExport.Click

        Dim sw As New StringWriter
        sw.Write(GetLabel("stats.lblExecutionTime"))
        sw.WriteLine(Date.Now)
        sw.WriteLine()
        sw.WriteLine(lblTypeOp.Text)
        sw.WriteLine(objM.exportDG(Session("tblReturn")).ToString)

        Response.AddHeader("content-disposition", "attachment;filename=rel.csv")
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

    Private Sub dgRel_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgRel.PageIndexChanged
        Me.dgRel.CurrentPageIndex = e.NewPageIndex
        dgRel.DataSource = Session("tblReturn")
        dgRel.DataBind()
    End Sub

End Class
