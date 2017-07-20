
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

Public Class employeesMenu1
    Inherits BaseClassUC

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ddlListType As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgProfiles As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ddlAplication As System.Web.UI.WebControls.DropDownList

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


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Me.Page.IsPostBack Then
            If objI.accessFunction(HttpContext.Current.User.Identity.Name, Me.Request.QueryString("select")) Then
                LoadAplications()
                Me.ddlAplication.SelectedValue = Request.QueryString("apl")
                BindData(Me.ddlListType.SelectedValue, Me.ddlAplication.SelectedValue)

                Me.ddlListType.Items(0).Text = GetLabel("employeesMenu1.ddlListType0")
                Me.ddlListType.Items(1).Text = GetLabel("employeesMenu1.ddlListType1")
                Me.ddlListType.Items(2).Text = GetLabel("employeesMenu1.ddlListType2")
            Else
                Response.Redirect("defaultIn.aspx?page=gpu-0&lbl=accessDenied")
            End If
        End If
    End Sub

    Private Sub LoadAplications()
        Me.ddlAplication.DataSource = objI.loadAplications
        Me.ddlAplication.DataValueField = "AplicationCode"
        Me.ddlAplication.DataTextField = "AplicationName"
        Me.ddlAplication.DataBind()
    End Sub

    Public Sub BindData(ByVal intListType As Integer, ByVal strAplicationCode As String)
        Dim c0 As HyperLinkColumn = Me.dgProfiles.Columns(0)
        c0.Text = String.Format("<img src='Images/editUser.png' alt='{0}' border='0'", GetLabel("alt.PersonalData"))

        Dim c1 As EditCommandColumn = Me.dgProfiles.Columns(1)
        c1.EditText = String.Format("<img src='Images/edit.png' alt='{0}' border='0'", GetLabel("alt.Edit"))
        c1.UpdateText = String.Format("<img src='Images/save.png' alt='{0}' border='0'>", GetLabel("alt.Update"))
        c1.CancelText = String.Format("<img src='Images/cancel.png' alt='{0}' border='0'", GetLabel("alt.Cancel"))

        Me.dgProfiles.Columns(2).HeaderText = GetLabel("employeesMenu1.dgProfiles.column2HeaderText")
        Me.dgProfiles.Columns(3).HeaderText = GetLabel("employeesMenu1.dgProfiles.column3HeaderText")
        Me.dgProfiles.Columns(4).HeaderText = GetLabel("employeesMenu1.dgProfiles.column4HeaderText")
        Me.dgProfiles.Columns(5).HeaderText = GetLabel("employeesMenu1.dgProfiles.column5HeaderText")

        objI.loadEmployees(Me.dgProfiles, intListType, strAplicationCode)
    End Sub

    Sub dgProfiles_Paged(ByVal sender As Object, ByVal e As DataGridPageChangedEventArgs)
        Me.dgProfiles.CurrentPageIndex = e.NewPageIndex
        BindData(Me.ddlListType.SelectedValue, Me.ddlAplication.SelectedValue)
    End Sub

    Private Sub ddlListType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlListType.SelectedIndexChanged
        BindData(Me.ddlListType.SelectedValue, Me.ddlAplication.SelectedValue)
    End Sub

    Private Sub dgProfiles_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgProfiles.CancelCommand
        Me.dgProfiles.EditItemIndex = -1
        BindData(Me.ddlListType.SelectedValue, Me.ddlAplication.SelectedValue)
    End Sub

    Private Sub dgProfiles_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgProfiles.PageIndexChanged
        Me.dgProfiles.CurrentPageIndex = e.NewPageIndex
        BindData(Me.ddlListType.SelectedValue, Me.ddlAplication.SelectedValue)
    End Sub

    Private Sub dgProfiles_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgProfiles.EditCommand
        Me.dgProfiles.EditItemIndex = e.Item.ItemIndex
        BindData(Me.ddlListType.SelectedValue, Me.ddlAplication.SelectedValue)
    End Sub


    Private Sub dgProfiles_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgProfiles.UpdateCommand
        Dim strUserName As String = dgProfiles.DataKeys(e.Item.ItemIndex)
        Dim ddlProfiles As DropDownList = CType(e.Item.FindControl("ddlProfile"), DropDownList)
        Dim ckbActiveE As CheckBox = CType(e.Item.FindControl("ckbActiveE"), CheckBox)
        Dim intProfileID As Integer = ddlProfiles.SelectedValue
        Dim bolActive As Boolean = ckbActiveE.Checked
        objI.updateEmployee(strUserName, intProfileID, Me.ddlAplication.SelectedValue, bolActive)

        dgProfiles.EditItemIndex = -1
        BindData(Me.ddlListType.SelectedValue, Me.ddlAplication.SelectedValue)
    End Sub

    Private Sub dgProfiles_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgProfiles.ItemDataBound

        If e.Item.ItemType = ListItemType.EditItem Then 'ListItemType.Header And e.Item.ItemType <> ListItemType.Footer And e.Item.ItemType <> ListItemType.Item Then
            'Dim strUserName As Integer = dgProfiles.DataKeys(e.Item.ItemIndex)
            Dim strAplicationCode As String = Me.ddlAplication.SelectedValue
            Dim ddlProfiles As DropDownList = CType(e.Item.FindControl("ddlProfile"), DropDownList)
            objI.loadProfiles(ddlProfiles, strAplicationCode)
        End If
    End Sub

    Private Sub ddlAplication_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlAplication.SelectedIndexChanged
        BindData(Me.ddlListType.SelectedValue, Me.ddlAplication.SelectedValue)
    End Sub

End Class
