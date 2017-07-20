
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

Option Strict On

Public Class AddNodeForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lblNewItem As System.Windows.Forms.Label
    Friend WithEvents lblAddToNode As System.Windows.Forms.Label
    Friend WithEvents lblSelectedNode As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents txtNodeName As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AddNodeForm))
        Me.txtNodeName = New System.Windows.Forms.TextBox
        Me.lblNewItem = New System.Windows.Forms.Label
        Me.lblAddToNode = New System.Windows.Forms.Label
        Me.lblSelectedNode = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOk = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtNodeName
        '
        Me.txtNodeName.AutoSize = False
        Me.txtNodeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNodeName.Location = New System.Drawing.Point(80, 56)
        Me.txtNodeName.MaxLength = 50
        Me.txtNodeName.Name = "txtNodeName"
        Me.txtNodeName.Size = New System.Drawing.Size(224, 20)
        Me.txtNodeName.TabIndex = 1
        Me.txtNodeName.Text = ""
        '
        'lblNewItem
        '
        Me.lblNewItem.BackColor = System.Drawing.Color.Transparent
        Me.lblNewItem.ForeColor = System.Drawing.Color.Red
        Me.lblNewItem.Location = New System.Drawing.Point(7, 56)
        Me.lblNewItem.Name = "lblNewItem"
        Me.lblNewItem.Size = New System.Drawing.Size(73, 20)
        Me.lblNewItem.TabIndex = 2
        Me.lblNewItem.Text = "Nome Nodo:"
        Me.lblNewItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAddToNode
        '
        Me.lblAddToNode.BackColor = System.Drawing.Color.Transparent
        Me.lblAddToNode.Location = New System.Drawing.Point(7, 14)
        Me.lblAddToNode.Name = "lblAddToNode"
        Me.lblAddToNode.Size = New System.Drawing.Size(93, 21)
        Me.lblAddToNode.TabIndex = 0
        '
        'lblSelectedNode
        '
        Me.lblSelectedNode.BackColor = System.Drawing.Color.Transparent
        Me.lblSelectedNode.Location = New System.Drawing.Point(96, 14)
        Me.lblSelectedNode.Name = "lblSelectedNode"
        Me.lblSelectedNode.Size = New System.Drawing.Size(208, 34)
        Me.lblSelectedNode.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.btnOk)
        Me.Panel1.Location = New System.Drawing.Point(-33, 88)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(360, 62)
        Me.Panel1.TabIndex = 4
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Location = New System.Drawing.Point(272, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(64, 20)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "&Cancelar"
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.Color.Transparent
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Location = New System.Drawing.Point(206, 4)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(60, 20)
        Me.btnOk.TabIndex = 4
        Me.btnOk.Text = "&OK"
        '
        'AddNodeForm
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(313, 120)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblSelectedNode)
        Me.Controls.Add(Me.lblAddToNode)
        Me.Controls.Add(Me.lblNewItem)
        Me.Controls.Add(Me.txtNodeName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddNodeForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public FullPath As String
    Public NodeName As String = ""
    Public Op As String = "New"

    Private Sub AddNodeForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Op = "New" Then
            Me.Text = "Novo nodo"
            Me.lblAddToNode.Text = "Adicionar nodo a:"
            Me.lblSelectedNode.Text = FullPath
        ElseIf Op = "Rename" Then
            Me.Text = "Renomear nodo"
            Me.lblAddToNode.Text = "Renomear nodo:"
            Me.lblSelectedNode.Text = FullPath
            Me.txtNodeName.Text = NodeName
        End If
        Me.btnOk.Enabled = False
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        NodeName = Trim(txtNodeName.Text)
    End Sub

    Private Sub txtNodeName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNodeName.TextChanged
        btnOk.Enabled = Me.txtNodeName.Text.Length > 0
    End Sub

End Class
