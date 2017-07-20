
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

Public Class aplicationsMenu2
    Inherits BaseClassUC

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents Panel3 As System.Web.UI.WebControls.Panel
    Protected WithEvents lnkbSave As System.Web.UI.WebControls.LinkButton
    Protected WithEvents dgAplications As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txbNewAplication As System.Web.UI.WebControls.TextBox
    Protected WithEvents txbNewVersion As System.Web.UI.WebControls.TextBox
    Protected WithEvents txbNewAplicationCode As System.Web.UI.WebControls.TextBox

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
                Me.lnkbSave.Text = GetLabel("profilesMenu2.lnkbSave")
                BindData()
            Else
                Response.Redirect("defaultIn.aspx?page=gpu-0&lbl=accessDenied")
            End If
        End If
    End Sub

    Private Sub BindData()
        Dim c0 As ButtonColumn = Me.dgAplications.Columns(0)
        c0.Text = String.Format("<img src='Images/delete.png' alt='{0}' border='0'", GetLabel("alt.Delete"))

        Dim c1 As EditCommandColumn = Me.dgAplications.Columns(1)
        c1.EditText = String.Format("<img src='Images/edit.png' alt='{0}' border='0'", GetLabel("alt.Edit"))
        c1.UpdateText = String.Format("<img src='Images/save.png' alt='{0}' border='0'>", GetLabel("alt.Update"))
        c1.CancelText = String.Format("<img src='Images/cancel.png' alt='{0}' border='0'", GetLabel("alt.Cancel"))

        Me.dgAplications.Columns(2).HeaderText = GetLabel("aplicationsMenu2.dgAplications.column2HeaderText")
        Me.dgAplications.Columns(3).HeaderText = GetLabel("aplicationsMenu2.dgAplications.column3HeaderText")
        Me.dgAplications.Columns(4).HeaderText = GetLabel("aplicationsMenu2.dgAplications.column4HeaderText")

        Me.dgAplications.DataSource = objI.loadAplications()
        Me.dgAplications.DataBind()
    End Sub

    Private Sub lnkbSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkbSave.Click
        Dim strNewProfile As String = Me.txbNewAplication.Text.Trim
        Dim objAplication As New Aplication
        objAplication.AplicationCode = Me.txbNewAplicationCode.Text.Trim
        objAplication.AplicationName = Me.txbNewAplication.Text.Trim
        objAplication.Version = Me.txbNewVersion.Text.Trim
        objI.storeAplication(objAplication)
        BindData()
        Me.txbNewAplicationCode.Text = ""
        Me.txbNewAplication.Text = ""
        Me.txbNewVersion.Text = ""
    End Sub

    Private Sub dgAplications_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgAplications.DeleteCommand
        Dim strAplicationCode As String = Me.dgAplications.DataKeys(e.Item.ItemIndex)
        objI.deleteAplication(strAplicationCode)
        BindData()
    End Sub

    Private Sub dgAplications_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgAplications.UpdateCommand
        Dim objAplication As New Aplication
        objAplication.AplicationCode = Me.dgAplications.DataKeys(e.Item.ItemIndex)
        objAplication.AplicationName = (CType(e.Item.Cells(3).Controls(0), TextBox).Text).ToString
        objAplication.Version = (CType(e.Item.Cells(4).Controls(0), TextBox).Text).ToString

        objI.updateAplication(objAplication)
        Me.dgAplications.EditItemIndex = -1
        BindData()
    End Sub

    Private Sub dgAplications_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgAplications.CancelCommand
        Me.dgAplications.EditItemIndex = -1
        BindData()
    End Sub

    Private Sub dgAplications_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgAplications.EditCommand
        Me.dgAplications.EditItemIndex = e.Item.ItemIndex
        BindData()
    End Sub

    Private Sub dgAplications_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgAplications.ItemDataBound
        If e.Item.ItemType = ListItemType.EditItem Then
            DirectCast(e.Item.Cells(3).Controls(0), TextBox).Attributes.Add("Class", "txb")
            DirectCast(e.Item.Cells(4).Controls(0), TextBox).Attributes.Add("Class", "txb")
        End If

        If e.Item.ItemType = ListItemType.Item Or _
            e.Item.ItemType = ListItemType.AlternatingItem Or _
            e.Item.ItemType = ListItemType.EditItem Then
            With DirectCast(e.Item.Cells(0).Controls(0), LinkButton)
                .Attributes.Add("onClick", "return confirm('" & GetLabel("popup.delete") & "');")
            End With
        End If
    End Sub
End Class
