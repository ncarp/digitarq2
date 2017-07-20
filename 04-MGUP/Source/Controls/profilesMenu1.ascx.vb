
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



