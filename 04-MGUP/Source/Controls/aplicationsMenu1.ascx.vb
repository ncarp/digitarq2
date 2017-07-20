
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

Public Class aplicationsMenu1
    Inherits BaseClassUC

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents rblAplications As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents pnlEditFunction As System.Web.UI.WebControls.Panel
    Protected WithEvents txbFunctionCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents txbParentCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents txbFunctionName As System.Web.UI.WebControls.TextBox
    Protected WithEvents lnkbNewFunction As System.Web.UI.WebControls.LinkButton
    Protected WithEvents txbNewFunctionCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents txbNewParentCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents txbNewFunctionName As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlNewFunction As System.Web.UI.WebControls.Panel
    Protected WithEvents lnkbSave As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkbDeleteFunction As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkbSaveNewFunction As System.Web.UI.WebControls.LinkButton
    Protected WithEvents ltlAplFunctions As System.Web.UI.WebControls.Literal

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

    '======== FunctionCode: gpu-2.1.1 ======== 
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Me.Page.IsPostBack Then
            If objI.accessFunction(HttpContext.Current.User.Identity.Name, Me.Request.QueryString("select")) Then
                Me.lnkbNewFunction.Text = GetLabel("lnkbNewFunction")
                Me.lnkbDeleteFunction.Text = GetLabel("lnkbDeleteFunction")
                Me.lnkbSaveNewFunction.Text = GetLabel("lnkbSave")

                Dim qs_aid As String = Me.Request.QueryString("aid")
                Dim qs_fid As String = Me.Request.QueryString("fid")

                LoadAplications()
                If Not Me.Request.QueryString("aid") Is Nothing Then
                    Me.rblAplications.SelectedValue = qs_aid
                Else
                    Me.rblAplications.SelectedValue = Me.rblAplications.Items(0).Value
                End If

                If Me.Request.QueryString("level") = "last" Then
                    Me.lnkbNewFunction.Visible = False
                Else
                    Me.lnkbNewFunction.Visible = True
                End If

                loadAplicationFunctions(qs_fid)

                If Not objI.hasFunctionsChildren(qs_fid) Then
                    Me.lnkbDeleteFunction.Attributes.Add("onClick", "return confirm('" & GetLabel("aplicationsMenu1.confirm1") & "');")

                Else
                    Me.lnkbDeleteFunction.Attributes.Add("onClick", "return confirm('" & GetLabel("aplicationsMenu1.confirm2") & "');")

                End If
            Else
                Response.Redirect("defaultIn.aspx?page=gpu-0&lbl=accessDenied")
            End If
        End If
    End Sub


    Private Sub LoadAplications()
        Me.rblAplications.DataSource = objI.loadAplications
        Me.rblAplications.DataValueField = "AplicationCode"
        Me.rblAplications.DataTextField = "AplicationName"
        Me.rblAplications.DataBind()
        Me.rblAplications.SelectedValue = Me.rblAplications.Items(0).Value
    End Sub


    Private Sub rblAplications_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rblAplications.SelectedIndexChanged
        loadAplicationFunctions(Me.Request.QueryString("fid"))
    End Sub

    Private Sub lnkbNewFunction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkbNewFunction.Click
        Me.pnlNewFunction.Visible = True
        loadAplicationFunctions(Me.Request.QueryString("fid"))
    End Sub

    Private Sub lnkbDeleteFunction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkbDeleteFunction.Click
        Dim strAplicationCode As String = Me.Request.QueryString("aid")
        If Not Me.Request.QueryString("fid") Is Nothing Then
            Dim strFunctionCode = Me.Request.QueryString("fid")
            objI.deleteFunction(strFunctionCode, strAplicationCode)
            loadAplicationFunctions()
        Else
            Response.Write("<script language=javascript>window.alert('Seleccione um nodo da �rvore!');</script>")
        End If
    End Sub

    Private Sub lnkbSaveNewFunction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkbSaveNewFunction.Click
        Dim objFunction As New _Function

        Dim qs_fid As String = Me.Request.QueryString("fid")

        If Not Me.Request.QueryString("fid") Is Nothing Then
            objFunction.FunctionCode = Me.txbNewFunctionCode.Text
            objFunction.ParentCode = qs_fid
            objFunction.FunctionName = Me.txbNewFunctionName.Text
            objFunction.AplicationCode = Me.rblAplications.SelectedValue

            objI.storeFunction(objFunction)

            loadAplicationFunctions(qs_fid)
        Else
            Response.Write("<script language=javascript>window.alert('Seleccione um nodo da �rvore!');</script>")
        End If

    End Sub

    Private Sub loadAplicationFunctions(Optional ByVal functionCodeSelected As String = "null")
        Me.ltlAplFunctions.Text = strAplicationFunctions(Me.rblAplications.SelectedValue, functionCodeSelected)
    End Sub

End Class


