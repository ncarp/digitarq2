
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
