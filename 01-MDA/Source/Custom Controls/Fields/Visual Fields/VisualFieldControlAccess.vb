
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

Public Class VisualFieldControlAccess
    Inherits VisualField


    Private myLabel As Label
    Private WithEvents myListView As ListView
    Private WithEvents myAddButton As mkccontrols.windows.forms.control.mkc_Button
    Private WithEvents myRemoveButton As mkccontrols.windows.forms.control.mkc_Button

    Private myFondsID As Integer


    Public Sub New(ByVal LazyNode As LazyNode, ByVal ButtonImages As ImageList, ByVal FondsID As Integer)
        Me.LazyNode = LazyNode
        myFondsID = FondsID ' used to make list of available items



        myLabel = New Label
        With myLabel
            .Location = New Point(0, 0)
            .Text = VisualFieldLabel("ControlAccess")
            .AutoSize = True
        End With


        Dim chID As New ColumnHeader
        chID.Text = VisualFieldLabel("ControlAccessIDHeader")
        chID.Width = 0

        Dim chItem As New ColumnHeader
        chItem.Text = VisualFieldLabel("ControlAccessItemHeader")
        chItem.Width = 200

        Dim chType As New ColumnHeader
        chType.Text = VisualFieldLabel("ControlAccessTypeHeader")
        chType.Width = 100


        myListView = New ListView
        With myListView
            .Location = New Point(VisualTextField.DefaultLabelWidth + VisualTextField.DefaultLabelTextBoxGap, 0)
            .Width = VisualTextField.TextBoxWidthExtraLarge - 15
            .Alignment = System.Windows.Forms.ListViewAlignment.Default
            .AllowColumnReorder = True
            .AutoArrange = False
            .BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            .Columns.AddRange(New System.Windows.Forms.ColumnHeader() {chID, chItem, chType})
            .FullRowSelect = True
            .HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
            .LabelWrap = False
            .MultiSelect = False
            .Sorting = System.Windows.Forms.SortOrder.Ascending
            .View = System.Windows.Forms.View.Details
            .Items.Clear()
        End With


        LoadList()


        myAddButton = New mkccontrols.windows.forms.control.mkc_Button
        With myAddButton
            .Text = ""
            .ButtonText = ""
            .ButtonImage = ButtonImages.Images(0)
            .ButtonImageAlignment = ContentAlignment.MiddleCenter
            .BorderColor = System.Drawing.Color.WhiteSmoke
            .BackColor = System.Drawing.Color.WhiteSmoke
            .HighlightBackgroundColor = System.Drawing.Color.WhiteSmoke
            .Size = New Size(ButtonImages.ImageSize.Width + 1, ButtonImages.ImageSize.Height + 1)
            .Location = New Point(myListView.Location.X + myListView.Width + 3, myListView.Location.Y)
            '.FlatStyle = FlatStyle.Flat
            .Cursor = Cursors.Hand
        End With


        myRemoveButton = New mkccontrols.windows.forms.control.mkc_Button
        With myRemoveButton
            .Text = ""
            .ButtonText = ""
            .ButtonImage = ButtonImages.Images(1)
            .ButtonImageAlignment = ContentAlignment.MiddleCenter
            .BorderColor = System.Drawing.Color.WhiteSmoke
            .BackColor = System.Drawing.Color.WhiteSmoke
            .HighlightBackgroundColor = System.Drawing.Color.WhiteSmoke
            .Size = New Size(ButtonImages.ImageSize.Width + 1, ButtonImages.ImageSize.Height + 1)
            .Location = New Point(myAddButton.Location.X, myAddButton.Location.Y + myAddButton.Height + 5)
            '.FlatStyle = FlatStyle.Flat
            .Cursor = Cursors.Hand
        End With



        'New VisualTextField(VisualFieldLabel("BiogHist"), VisualTextField.TextBoxWidthExtraLarge, VisualTextField.TextBoxHeightLarge)

        Me.Size = New Size(myAddButton.Location.X + myAddButton.Width, myListView.Location.Y + myListView.Height)

        Me.Controls.Add(myLabel)
        Me.Controls.Add(myListView)
        Me.Controls.Add(myAddButton)
        Me.Controls.Add(myRemoveButton)
    End Sub




    Private Sub myAddButton_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myAddButton.Click
        Dim frmControlAccessAssociation As New ControlAccessItemsComponentForm(myFondsID, LazyNode.ControlAccess)
        If frmControlAccessAssociation.ShowDialog() = DialogResult.OK Then
            LoadList()
        End If
        RaiseEventDataChanged(Me, LazyNode.ControlAccess)

    End Sub

    Private Sub myRemoveButton_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myRemoveButton.Click
        If Me.myListView.SelectedItems.Count = 0 Then Exit Sub
        Dim SelectedItem As ListViewItem

        For Each SelectedItem In myListView.SelectedItems
            Dim ID As Integer = StrToInt(SelectedItem.SubItems(0).Text)
            LazyNode.ControlAccess.Remove(New ControlAccessItem(ID))
        Next
        LoadList()
        RaiseEventDataChanged(Me, LazyNode.ControlAccess)
    End Sub



    Private Sub LoadList()
        Dim Item As ControlAccessItem

        myListView.Items.Clear()
        For Each Item In LazyNode.ControlAccess
            Dim iID As New ListViewItem(Item.ID)
            Dim iItem As New ListViewItem.ListViewSubItem(iID, Item.Item)
            Dim iType As New ListViewItem.ListViewSubItem(iID, Item.Type)
            iID.SubItems.Add(iItem)
            iID.SubItems.Add(iType)

            myListView.Items.Add(iID)
        Next
    End Sub


End Class
