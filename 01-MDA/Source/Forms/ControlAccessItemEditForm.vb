
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

Public Class ControlAccessItemEditForm
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
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnCancelControlAccessTypeEdit As System.Windows.Forms.Button
    Friend WithEvents btnOkControlAccessTypeEdit As System.Windows.Forms.Button
    Friend WithEvents txtItem As System.Windows.Forms.TextBox
    Friend WithEvents TypeComboBox As ComboBoxImage
    Friend WithEvents lblControlAccessItemEditType As System.Windows.Forms.Label
    Friend WithEvents lblControlAccessItemEditItem As System.Windows.Forms.Label
    Friend WithEvents imglButtons As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ControlAccessItemEditForm))
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnOkControlAccessTypeEdit = New System.Windows.Forms.Button
        Me.btnCancelControlAccessTypeEdit = New System.Windows.Forms.Button
        Me.imglButtons = New System.Windows.Forms.ImageList(Me.components)
        Me.txtItem = New System.Windows.Forms.TextBox
        Me.TypeComboBox = New MDA.ComboBoxImage
        Me.lblControlAccessItemEditType = New System.Windows.Forms.Label
        Me.lblControlAccessItemEditItem = New System.Windows.Forms.Label
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnOkControlAccessTypeEdit)
        Me.Panel2.Controls.Add(Me.btnCancelControlAccessTypeEdit)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 71)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(386, 40)
        Me.Panel2.TabIndex = 5
        '
        'btnOkControlAccessTypeEdit
        '
        Me.btnOkControlAccessTypeEdit.BackColor = System.Drawing.Color.White
        Me.btnOkControlAccessTypeEdit.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOkControlAccessTypeEdit.Enabled = False
        Me.btnOkControlAccessTypeEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOkControlAccessTypeEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOkControlAccessTypeEdit.ImageIndex = 1
        Me.btnOkControlAccessTypeEdit.ImageList = Me.imglButtons
        Me.btnOkControlAccessTypeEdit.Location = New System.Drawing.Point(209, 8)
        Me.btnOkControlAccessTypeEdit.Name = "btnOkControlAccessTypeEdit"
        Me.btnOkControlAccessTypeEdit.Size = New System.Drawing.Size(75, 25)
        Me.btnOkControlAccessTypeEdit.TabIndex = 3
        Me.btnOkControlAccessTypeEdit.Text = CType(configurationAppSettings.GetValue("btnOkControlAccessTypeEdit.Text", GetType(System.String)), String)
        Me.btnOkControlAccessTypeEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelControlAccessTypeEdit
        '
        Me.btnCancelControlAccessTypeEdit.BackColor = System.Drawing.Color.White
        Me.btnCancelControlAccessTypeEdit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelControlAccessTypeEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelControlAccessTypeEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelControlAccessTypeEdit.ImageIndex = 0
        Me.btnCancelControlAccessTypeEdit.ImageList = Me.imglButtons
        Me.btnCancelControlAccessTypeEdit.Location = New System.Drawing.Point(291, 8)
        Me.btnCancelControlAccessTypeEdit.Name = "btnCancelControlAccessTypeEdit"
        Me.btnCancelControlAccessTypeEdit.Size = New System.Drawing.Size(85, 25)
        Me.btnCancelControlAccessTypeEdit.TabIndex = 2
        Me.btnCancelControlAccessTypeEdit.Text = CType(configurationAppSettings.GetValue("btnCancelControlAccessTypeEdit.Text", GetType(System.String)), String)
        Me.btnCancelControlAccessTypeEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'imglButtons
        '
        Me.imglButtons.ImageSize = New System.Drawing.Size(18, 18)
        Me.imglButtons.ImageStream = CType(resources.GetObject("imglButtons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglButtons.TransparentColor = System.Drawing.Color.Transparent
        '
        'txtItem
        '
        Me.txtItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItem.Location = New System.Drawing.Point(152, 32)
        Me.txtItem.Name = "txtItem"
        Me.txtItem.Size = New System.Drawing.Size(224, 20)
        Me.txtItem.TabIndex = 24
        Me.txtItem.Text = ""
        '
        'TypeComboBox
        '
        Me.TypeComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.TypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TypeComboBox.ImageList = Nothing
        Me.TypeComboBox.ItemHeight = 13
        Me.TypeComboBox.Location = New System.Drawing.Point(8, 32)
        Me.TypeComboBox.MaxDropDownItems = 12
        Me.TypeComboBox.Name = "TypeComboBox"
        Me.TypeComboBox.Size = New System.Drawing.Size(136, 19)
        Me.TypeComboBox.Sorted = True
        Me.TypeComboBox.TabIndex = 23
        '
        'lblControlAccessItemEditType
        '
        Me.lblControlAccessItemEditType.Location = New System.Drawing.Point(8, 16)
        Me.lblControlAccessItemEditType.Name = "lblControlAccessItemEditType"
        Me.lblControlAccessItemEditType.Size = New System.Drawing.Size(100, 16)
        Me.lblControlAccessItemEditType.TabIndex = 25
        Me.lblControlAccessItemEditType.Text = CType(configurationAppSettings.GetValue("lblControlAccessItemEditType.Text", GetType(System.String)), String)
        '
        'lblControlAccessItemEditItem
        '
        Me.lblControlAccessItemEditItem.Location = New System.Drawing.Point(152, 16)
        Me.lblControlAccessItemEditItem.Name = "lblControlAccessItemEditItem"
        Me.lblControlAccessItemEditItem.Size = New System.Drawing.Size(144, 16)
        Me.lblControlAccessItemEditItem.TabIndex = 26
        Me.lblControlAccessItemEditItem.Text = CType(configurationAppSettings.GetValue("lblControlAccessItemEditItem.Text", GetType(System.String)), String)
        '
        'ControlAccessItemEditForm
        '
        Me.AcceptButton = Me.btnOkControlAccessTypeEdit
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancelControlAccessTypeEdit
        Me.ClientSize = New System.Drawing.Size(386, 111)
        Me.Controls.Add(Me.lblControlAccessItemEditItem)
        Me.Controls.Add(Me.lblControlAccessItemEditType)
        Me.Controls.Add(Me.txtItem)
        Me.Controls.Add(Me.TypeComboBox)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ControlAccessItemEditForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = CType(configurationAppSettings.GetValue("ControlAccessTypeEditForm.Text", GetType(System.String)), String)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public WriteOnly Property Types() As ControlAccessTypeCollection
        Set(ByVal Value As ControlAccessTypeCollection)
            TypeComboBox.Items.Clear()

            Dim Item As ControlAccessTypeItem
            For Each Item In Value
                TypeComboBox.Items.Add(New ComboBoxImageItem(Item.Type, Item.ID.ToString, -1))
            Next
        End Set
    End Property

    Public ReadOnly Property TypeID() As Integer
        Get
            Return CInt(TypeComboBox.SelectedValue)
        End Get
    End Property

    Public Sub SelectType(ByVal Type As String)
        TypeComboBox.SelectedText = Type
    End Sub



    Public Property Item() As String
        Get
            Return txtItem.Text
        End Get
        Set(ByVal Value As String)
            txtItem.Text = Value
        End Set
    End Property


    Private Sub txtItem_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItem.TextChanged
        Me.btnOkControlAccessTypeEdit.Enabled = True
    End Sub

    Private Sub TypeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TypeComboBox.SelectedIndexChanged
        Me.btnOkControlAccessTypeEdit.Enabled = True
    End Sub
End Class
