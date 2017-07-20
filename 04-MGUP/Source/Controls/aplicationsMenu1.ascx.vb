
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
            Response.Write("<script language=javascript>window.alert('Seleccione um nodo da árvore!');</script>")
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
            Response.Write("<script language=javascript>window.alert('Seleccione um nodo da árvore!');</script>")
        End If

    End Sub

    Private Sub loadAplicationFunctions(Optional ByVal functionCodeSelected As String = "null")
        Me.ltlAplFunctions.Text = strAplicationFunctions(Me.rblAplications.SelectedValue, functionCodeSelected)
    End Sub

End Class


