
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
