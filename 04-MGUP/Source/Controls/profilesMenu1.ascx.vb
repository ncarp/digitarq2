
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

Public Class profilesMenu1
    Inherits BaseClassUC

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ddlListType As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgProfiles As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lnkbSave As System.Web.UI.WebControls.LinkButton
    Protected WithEvents rblAplications As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents rblProfiles As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents pnlFunctions As System.Web.UI.WebControls.Panel
    Protected WithEvents ltlAllProfileFunctions As System.Web.UI.WebControls.Literal

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


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Me.Page.IsPostBack Then
            If objI.accessFunction(HttpContext.Current.User.Identity.Name, Me.Request.QueryString("select")) Then
                LoadAplications()

                objI.loadProfiles(Me.rblProfiles, Me.rblAplications.SelectedValue)
                LoadFunctions()

                Me.lnkbSave.Text = GetLabel("profilesMenu1.lnkbSave")
            Else
                Response.Redirect("defaultIn.aspx?page=gpu-0&lbl=accessDenied")
            End If
        End If

    End Sub

    Private Sub LoadFunctions()
        If Not Me.rblProfiles.SelectedValue = "" Then
            Me.ltlAllProfileFunctions.Text = strAllProfileFunctions(Me.rblAplications.SelectedValue, CInt(Me.rblProfiles.SelectedValue))
            If Me.ltlAllProfileFunctions.Text = "" Then
                Me.pnlFunctions.Visible = False
                Me.ltlAllProfileFunctions.Visible = False
            Else
                Me.pnlFunctions.Visible = True
                Me.ltlAllProfileFunctions.Visible = True
            End If
        Else
            Me.pnlFunctions.Visible = False
            Me.ltlAllProfileFunctions.Visible = False
        End If
    End Sub

    Private Sub LoadAplications()
        Me.rblAplications.DataSource = objI.loadAplications
        Me.rblAplications.DataValueField = "AplicationCode"
        Me.rblAplications.DataTextField = "AplicationName"
        Me.rblAplications.DataBind()
        Me.rblAplications.SelectedValue = Me.rblAplications.Items(0).Value
    End Sub

    Private Sub LoadProfiles()
        Me.rblProfiles.DataSource = objI.loadProfiles(Me.rblAplications.SelectedValue)
        Me.rblProfiles.DataValueField = "ProfileID"
        Me.rblProfiles.DataTextField = "Profile"
        Me.rblProfiles.DataBind()
    End Sub


    Private Sub lnkbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkbSave.Click
        Dim alst As New ArrayList
        If Not Request.Form("functions") Is Nothing Then
            alst.AddRange(Request.Form("functions").Split(","))
        End If
        If Not Request.Form("subFunctions") Is Nothing Then
            alst.AddRange(Request.Form("subFunctions").Split(","))
        End If
        If Not Request.Form("subSubFunctions") Is Nothing Then
            alst.AddRange(Request.Form("subSubFunctions").Split(","))
        End If

        objI.updateProfileFunctions(CInt(Me.rblProfiles.SelectedValue), alst)
        LoadFunctions()

    End Sub


    Private Sub rblAplications_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblAplications.SelectedIndexChanged
        objI.loadProfiles(Me.rblProfiles, Me.rblAplications.SelectedValue)
        LoadFunctions()
    End Sub

    Private Sub ddlProfiles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblProfiles.SelectedIndexChanged
        LoadFunctions()
    End Sub

End Class



