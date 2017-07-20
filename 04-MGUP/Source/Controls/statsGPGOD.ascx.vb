
#Region "License Agreement"

'* DigitArq
'* Copyright 2007-2015 
'* Arquivo Distrital do Porto
'* Todos os direitos reservados.
'*  
'* Este software foi desenvolvido pelo Arquivo
'* Distrital do Porto (http://www.adporto.pt)
'* em articula��o com a Direc��o-Geral de Arquivos
'* (http://www.dgarq.gov.pt) e com a coordena��o
'* inform�tica da Universidade do Minho
'* (http://www.uminho.pt).
'* O desenvolvimento deste produto foi parcialmente
'* financiado pelo Programa Operacional para a 
'* Cultura (POC) promovido pelo Governo Portugu�s.
'* ---------------------------------------------------
'*
'* A redistribui��o e utiliza��o deste produto sob a
'* forma de c�digo-fonte ou programa compilado, com ou
'* sem modifica��es, � permitida desde que o seguinte
'* conjunto de condi��es seja cumprido:
'* 
'*	* Todas as redistribui��es do c�digo-fonte 
'*	  deste produto dever�o ser acompanhadas do
'*	  texto que comp�e esta licen�a, incluindo o 
'*	  texto inicial de atribui��o de autoria,
'*	  esta lista de condi��es e do seguinte termo
'*	  de responsabilidade.
'*
'*	* Os nomes da Direc��o-Geral de Arquivos,
'*	  do Arquivo Distrital do Porto, da 
'*	  Universidade do Minho e das pessoas 
'*	  individuais que colaboraram no desenvolvimento 
'*	  deste produto n�o dever�o ser utilizados na 
'*	  promo��o de produtos derivados deste 
'*	  sem que seja obtido consentimento pr�vio, por
'*	  escrito, por parte dos visados.

'*	* A utiliza��o da designa��o DigitArq, seus 
'*	  log�tipos e nomes institucionais associados
'*	  � apenas permitida em distribui��es que sejam
'*	  c�pias exactas da vers�o oficial deste produto
'*	  aprovada e/ou distribu�da pela Direc��o-Geral 
'*	  de Arquivos.

'*	* O desenvolvimento de obras derivadas deste
'*	  produto � permitido desde que a designa��o 
'*	  DigitArq, seus logotipos e parceiros 
'*	  institucionais n�o sejam utilizados em todo e
'*	  qualquer tipo de distribui��o e/ou promo��o 
'*	  da obra derivada.
'* 
'* ESTE SOFTWARE � DISTRIBUIDO PELA DIREC��O-GERAL DE
'* ARQUIVOS "NO ESTADO EM QUE SE ENCONTRA" SEM QUALQUER
'* PRESUN��O DE QUALIDADE OU GARANTIA ASSOCIADAS, 
'* INCLUINDO, MAS N�O LIMITADO A, GARANTIAS ASSOCIADAS
'* A COM�RCIO DE PRODUTOS OU DECLARA��O DE ADEQUABILIDADE
'* A DETERMINADO FIM OU OBJECTIVO. 

'* EM NENHUMA CIRCUNST�NCIA PODER� A DIREC��O-GERAL DE 
'* ARQUIVOS SER CONSIDERADA RESPONS�VEL POR QUAISQUER 
'* DANOS QUE RESULTEM DA UTILIZA��O DIRECTA, INDIRECTA,
'* ACIDENTAL, ESPECIAL OU DEMONSTRATIVA DESTE PRODUTO 
'* (INCLUINDO, MAS N�O LIMITADO A, PERDAS DE DADOS, 
'* LUCROS, FAL�NCIA, INDEVIDA PRESTA��O DE SERVI�OS
'* OU NEGLIG�NCIA), AINDA QUE O LICENCIANTE TENHA SIDO 
'* AVISADO DA POSSIBILIDADE DA OCORR�NCIA DE TAIS DANOS.
'*
'* ---------------------------------------------------
'* Para mais informa��o sobre este produto ou a sua 
'* licen�a, � favor consultar o endere�o electr�nico
'* http://www.digitarq.pt

#End Region

Public Class statsGPGOD
    Inherits BaseClassUC

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ddlListType As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlAplication As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgImages As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblTotalProjects As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotalOD As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotalImages As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotalDerivatives As System.Web.UI.WebControls.Label
    Protected WithEvents chart1 As blong.WebControls.WebChart

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

    '======== FunctionCode: gpu-1.1.1 ======== 
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Me.Page.IsPostBack Then
            If objI.accessFunction(HttpContext.Current.User.Identity.Name, Me.Request.QueryString("page")) Then
                BindData()
            Else
                Response.Redirect("defaultIn.aspx?page=gpu-0&lbl=accessDenied")
            End If
        End If
    End Sub

    Public Sub BindData()
        Me.dgImages.Columns(0).HeaderText = GetLabel("statsGPGOD.dgImages.column0HeaderText")
        Me.dgImages.Columns(1).HeaderText = GetLabel("statsGPGOD.dgImages.column1HeaderText")
        Dim ds As DataSet = objI.loadTotalImagesByOtherLevel()
        Me.dgImages.DataSource = ds
        Me.dgImages.DataBind()

        Me.lblTotalProjects.Text = objI.countProjects
        Me.lblTotalOD.Text = objI.countDigitalObjects
        Me.lblTotalImages.Text = objI.countImages
        Me.lblTotalDerivatives.Text = objI.countDerivatives

        Me.objM.MakeChart(ds, chart1, "Imagens por n�vel descri��o", True, 1, 2)
    End Sub

    'Sub dgProfiles_Paged(ByVal sender As Object, ByVal e As DataGridPageChangedEventArgs)
    '    Me.dgProfiles.CurrentPageIndex = e.NewPageIndex
    '    BindData(Me.ddlListType.SelectedValue, Me.ddlAplication.SelectedValue)
    'End Sub

    'Private Sub ddlListType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlListType.SelectedIndexChanged
    '    BindData(Me.ddlListType.SelectedValue, Me.ddlAplication.SelectedValue)
    'End Sub

    'Private Sub dgProfiles_CancelCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
    '    Me.dgProfiles.EditItemIndex = -1
    '    BindData(Me.ddlListType.SelectedValue, Me.ddlAplication.SelectedValue)
    'End Sub

    'Private Sub dgProfiles_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
    '    Me.dgProfiles.CurrentPageIndex = e.NewPageIndex
    '    BindData(Me.ddlListType.SelectedValue, Me.ddlAplication.SelectedValue)
    'End Sub

    'Private Sub dgProfiles_EditCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
    '    Me.dgProfiles.EditItemIndex = e.Item.ItemIndex
    '    BindData(Me.ddlListType.SelectedValue, Me.ddlAplication.SelectedValue)
    'End Sub


    'Private Sub dgProfiles_UpdateCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
    '    Dim strUserName As String = dgProfiles.DataKeys(e.Item.ItemIndex)
    '    Dim ddlProfiles As DropDownList = CType(e.Item.FindControl("ddlProfile"), DropDownList)
    '    Dim ckbActiveE As CheckBox = CType(e.Item.FindControl("ckbActiveE"), CheckBox)
    '    Dim intProfileID As Integer = ddlProfiles.SelectedValue
    '    Dim bolActive As Boolean = ckbActiveE.Checked
    '    objI.updateEmployee(strUserName, intProfileID, Me.ddlAplication.SelectedValue, bolActive)

    '    dgProfiles.EditItemIndex = -1
    '    BindData(Me.ddlListType.SelectedValue, Me.ddlAplication.SelectedValue)
    'End Sub

    'Private Sub dgProfiles_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)

    '    If e.Item.ItemType = ListItemType.EditItem Then 'ListItemType.Header And e.Item.ItemType <> ListItemType.Footer And e.Item.ItemType <> ListItemType.Item Then
    '        'Dim strUserName As Integer = dgProfiles.DataKeys(e.Item.ItemIndex)
    '        Dim strAplicationCode As String = Me.ddlAplication.SelectedValue
    '        Dim ddlProfiles As DropDownList = CType(e.Item.FindControl("ddlProfile"), DropDownList)
    '        objI.loadProfiles(ddlProfiles, strAplicationCode)
    '    End If
    'End Sub

    'Private Sub ddlAplication_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlAplication.SelectedIndexChanged
    '    BindData(Me.ddlListType.SelectedValue, Me.ddlAplication.SelectedValue)
    'End Sub

End Class
