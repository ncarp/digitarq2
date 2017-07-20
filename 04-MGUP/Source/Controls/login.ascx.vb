
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

Imports System.Data.SqlClient
Imports System.Web.Security

Public Class uc_login1
    Inherits BaseClassUC

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Protected WithEvents txtPassword As System.Web.UI.WebControls.TextBox
    Protected WithEvents lkbAux As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblError As System.Web.UI.WebControls.Label
    Protected WithEvents lnkbSubmit As System.Web.UI.WebControls.LinkButton
    Protected WithEvents rfvTxtPassword As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents hlnkRegister As System.Web.UI.WebControls.HyperLink
    Protected WithEvents btnSearch As System.Web.UI.WebControls.Button
    Protected WithEvents ddlUserName As System.Web.UI.WebControls.DropDownList

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private objIGPU As New GPU.SQLDataBase

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Me.Page.IsPostBack Then
            Dim ds As DataSet = objIGPU.loadEmployees(ConfigurationManager.AppSettings("Aplication.Code"))
            Me.ddlUserName.DataSource = ds
            Me.ddlUserName.DataValueField = "UserName"
            Me.ddlUserName.DataTextField = "Username"
            Me.ddlUserName.DataBind()

            Me.lnkbSubmit.Text = GetLabel("lnkbLogin")
        End If
    End Sub


    Private Sub lnkbSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkbSubmit.Click

        Dim strUsername As String = Me.ddlUserName.SelectedValue
        Dim strPassword As String = Me.txtPassword.Text

        Dim GPUAplicationCode As String = ConfigurationManager.AppSettings("Aplication.Code")

        Dim objI As New SQLDataBase

        Dim eReturn As GPU.SQLInterface.eReturn = objI.validateEmployee(GPUAplicationCode, strUsername, strPassword)

        Select Case eReturn
            Case eReturn.Sucess
                Dim objEmployee As Employee = objI.loadEmployee(strUsername)

                Dim authTicket As New FormsAuthenticationTicket(objEmployee.UserName, False, 15)
                Dim encryptTicket = FormsAuthentication.Encrypt(authTicket)
                Dim authCookie As HttpCookie = New HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket)
                Response.Cookies.Add(authCookie)

                Session.Add("Employee", objEmployee)

                If Me.Request.QueryString("page") = "" Or Me.Request.QueryString("page") = "logout" Then
                    Response.Redirect("defaultIn.aspx")
                Else
                    FormsAuthentication.RedirectFromLoginPage(objEmployee.UserName, False)
                End If

            Case eReturn.ErrorUsernamePass
                Me.lblError.Visible = True
                Me.lblError.Text = GetLabel("login.errorUsernamePass")

            Case eReturn.ErrorNotProfile
                Me.lblError.Visible = True
                Me.lblError.Text = GetLabel("login.errorNotProfile")

            Case eReturn.ErrorNotActive
                Me.lblError.Visible = True
                Me.lblError.Text = GetLabel("login.errorNotActive")

            Case eReturn.AplicationAccessDenied
                Me.lblError.Visible = True
                Me.lblError.Text = GetLabel("login.errorAplicationAccessDenied")

        End Select

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        lnkbSubmit_Click(sender, e)
    End Sub
End Class
