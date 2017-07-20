
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

Public Class employeesMenu2
    Inherits BaseClassUC

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents resumo As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents txtFirstName As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvTxtFirstName As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtLastName As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvTxtLastName As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtUserName As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvTxtUserName As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtPassword As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvTxtPassword As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtPassword1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents rfvTxtPassword1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents cvPassword As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents lnkbDelete As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkbSubmit As System.Web.UI.WebControls.LinkButton
    Protected WithEvents ckblActionReq As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents cvActionReq As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents cblAplications As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents cvAplications As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents txtObs As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator

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

    '======== FunctionCode: gpu-1.1.2 ======== 
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Me.Page.IsPostBack Then
            If objI.accessFunction(HttpContext.Current.User.Identity.Name, Me.Request.QueryString("select")) Then
                Me.lnkbDelete.Text = GetLabel("employeesMenu2.lnkbDelete")
                Me.lnkbSubmit.Text = GetLabel("employeesMenu2.lnkbSubmit")

                Me.rfvTxtFirstName.ErrorMessage = GetLabel("employeesMenu2.rfvTxtFirstName.ErrorMessage")
                Me.rfvTxtLastName.ErrorMessage = GetLabel("employeesMenu2.rfvTxtLastName.ErrorMessage")
                Me.rfvTxtPassword.ErrorMessage = GetLabel("employeesMenu2.rfvTxtPassword.ErrorMessage")
                Me.rfvTxtPassword1.ErrorMessage = GetLabel("employeesMenu2.rfvTxtPassword1.ErrorMessage")
                Me.cvPassword.ErrorMessage = GetLabel("employeesMenu2.cvPassword.ErrorMessage")
                Me.cvAplications.ErrorMessage = GetLabel("employeesMenu2.cvAplications.ErrorMessage")

                LoadAplications()

                If Me.Request.QueryString("eid") <> "" Then
                    loadEmployee(Me.Request.QueryString("eid"))
                    Me.txtUserName.ReadOnly = True
                End If
            Else
                Response.Redirect("defaultIn.aspx?page=gpu-0&lbl=accessDenied")
            End If
        End If
    End Sub


    Private Sub LoadAplications()
        Me.cblAplications.DataSource = objI.loadAplications
        Me.cblAplications.DataValueField = "AplicationCode"
        Me.cblAplications.DataTextField = "AplicationName"
        Me.cblAplications.DataBind()
    End Sub


    Private Sub lnkbSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkbSubmit.Click
        If Me.Page.IsValid Then
            Dim objI As New SQLDataBase

            Dim objEmployee As New Employee
            'objEmployee.UserName = Me.Request.QueryString("eid")
            objEmployee.UserName = Me.txtUserName.Text
            objEmployee.FirstName = Me.txtFirstName.Text
            objEmployee.LastName = Me.txtLastName.Text
            objEmployee.Obs = Me.txtObs.Text
            objEmployee.Password = Me.txtPassword.Text

            Dim hash As New Hashtable
            Dim strAplic As String
            For i As Integer = 0 To Me.cblAplications.Items.Count - 1
                If Me.cblAplications.Items(i).Selected Then
                    hash.Add(Me.cblAplications.Items(i).Value, 1)
                    strAplic = Me.cblAplications.Items(i).Value
                Else
                    hash.Add(Me.cblAplications.Items(i).Value, 0)
                End If
            Next
            If Me.Request.QueryString("eid") <> "" Then
                objI.updateEmployee(objEmployee)
                objI.updateAplicationsEmployee(objEmployee.UserName, hash)
            Else
                objI.storeEmployee(objEmployee)
                objI.updateAplicationsEmployee(objEmployee.UserName, hash)
            End If

            Select Case objI.Return_
                Case objI.eReturn.Sucess
                    Response.Redirect("defaultIn.aspx?page=gpu-1.1&select=gpu-1.1.1&apl=" & strAplic)
                Case objI.eReturn.ErrorDB
                    Response.Write("<script language=javascript>window.alert('" & GetLabel("popup.ErrorDB") & "');</script>")
                Case objI.eReturn.ErrorRepeatUsername
                    Response.Write("<script language=javascript>window.alert('" & GetLabel("popup.ErrorRepeatUsername") & "');</script>")
            End Select
        End If
    End Sub


    Private Sub lnkbDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkbDelete.Click
        Clean(Me.Page)
    End Sub

    Public Sub validateCheckBoxList(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Dim counter As Integer = 0

        For i As Integer = 0 To Me.cblAplications.Items.Count - 1
            If Me.cblAplications.Items(i).Selected Then
                counter += 1
            End If
        Next
        args.IsValid = (counter <> 0)
    End Sub

    Private Sub loadEmployee(ByVal strUserName As String)
        Dim objEmployee As Employee = objI.loadEmployee(strUserName)
        Me.txtFirstName.Text = objEmployee.FirstName
        Me.txtLastName.Text = objEmployee.LastName
        Me.txtUserName.Text = objEmployee.UserName
        Me.txtObs.Text = objEmployee.Obs
        Dim alst As ArrayList = objI.loadAplicationsEmployee(strUserName)
        For i As Integer = 0 To Me.cblAplications.Items.Count - 1
            If alst.Contains(Me.cblAplications.Items(i).Value) Then
                Me.cblAplications.Items(i).Selected = True
            End If
        Next
    End Sub

End Class
