
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

Public Class VisualFieldChronList
    Inherits VisualField


    Private myLabel As Label
    Private WithEvents myDate As VisualTextField
    Private WithEvents myEvent As VisualTextField
    Private WithEvents myListView As ListView
    Private WithEvents myAddButton As mkccontrols.windows.forms.control.mkc_Button
    Private WithEvents myRemoveButton As mkccontrols.windows.forms.control.mkc_Button


    Public Sub New(ByVal LazyNode As LazyNode, ByVal ButtonImages As ImageList)
        Me.LazyNode = LazyNode



        myLabel = New Label
        With myLabel
            .Location = New Point(0, 0)
            .Text = VisualFieldLabel("ChronList")
            .AutoSize = True
        End With


        myDate = New VisualTextField("", 0, VisualTextField.TextBoxWidthSmall, 1, ValidTextBox.FieldTypes.DefaultField)
        With myDate
            .Location = New Point(VisualTextField.DefaultLabelWidth + VisualTextField.DefaultLabelTextBoxGap, 0)
            .Value = ""
        End With


        myEvent = New VisualTextField("", 0, VisualTextField.TextBoxWidthExtraLarge - 15 - myDate.Width - VisualTextField.DefaultLabelTextBoxGap, 1, ValidTextBox.FieldTypes.DefaultField)
        With myEvent
            .Location = New Point(myDate.Location.X + myDate.Width + VisualTextField.DefaultLabelTextBoxGap, 0)
            .Value = ""
        End With





        Dim chDate As New ColumnHeader
        chDate.Text = VisualFieldLabel("DateHeader")
        chDate.Width = VisualTextField.TextBoxWidthSmall + VisualTextField.DefaultLabelTextBoxGap


        Dim chEvent As New ColumnHeader
        chEvent.Text = VisualFieldLabel("EventHeader")
        chEvent.Width = VisualTextField.TextBoxWidthExtraLarge - 15 - myDate.Width - VisualTextField.DefaultLabelTextBoxGap


        myListView = New ListView
        With myListView
            .Location = New Point(VisualTextField.DefaultLabelWidth + VisualTextField.DefaultLabelTextBoxGap, myEvent.Location.Y + myEvent.Height + 5)
            .Width = VisualTextField.TextBoxWidthExtraLarge - 15
            .Alignment = System.Windows.Forms.ListViewAlignment.Default
            .AllowColumnReorder = True
            .AutoArrange = False
            .BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            .Columns.AddRange(New System.Windows.Forms.ColumnHeader() {chDate, chEvent})
            .FullRowSelect = True
            .HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
            .LabelWrap = False
            .MultiSelect = False
            .Sorting = System.Windows.Forms.SortOrder.Ascending
            .View = System.Windows.Forms.View.Details
            .Items.Clear()
        End With


        Dim Item As ChronListItem
        For Each Item In LazyNode.ChronList
            Dim iDate As New ListViewItem(Item.EventDate)
            Dim iEvent As New ListViewItem.ListViewSubItem(iDate, Item.EventDescription)
            iDate.SubItems.Add(iEvent)

            myListView.Items.Add(iDate)
        Next


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
            .Location = New Point(myAddButton.Location.X, myAddButton.Location.Y + myAddButton.Height + 3)
            '.FlatStyle = FlatStyle.Flat
            .Cursor = Cursors.Hand
        End With



        'New VisualTextField(VisualFieldLabel("BiogHist"), VisualTextField.TextBoxWidthExtraLarge, VisualTextField.TextBoxHeightLarge)

        Me.Size = New Size(myAddButton.Location.X + myAddButton.Width, myListView.Location.Y + myListView.Height)

        Me.Controls.Add(myLabel)
        Me.Controls.Add(myDate)
        Me.Controls.Add(myEvent)
        Me.Controls.Add(myListView)
        Me.Controls.Add(myAddButton)
        Me.Controls.Add(myRemoveButton)
    End Sub



    Private Sub myAddButton_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myAddButton.Click
        If myDate.Value = "" Or myEvent.Value = "" Then Exit Sub

        Dim iDate As New ListViewItem(CStr(myDate.Value))
        Dim iEvent As New ListViewItem.ListViewSubItem(iDate, CStr(myEvent.Value))
        iDate.SubItems.Add(iEvent)

        myListView.Items.Add(iDate)

        myDate.Value = ""
        myEvent.Value = ""

        myDate.Focus()
        Upload()
    End Sub



    Private Sub myRemoveButton_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myRemoveButton.Click
        If myListView.SelectedIndices.Count = 1 Then
            Dim iDate As ListViewItem = myListView.SelectedItems(0)
            myDate.Value = iDate.Text
            myEvent.Value = iDate.SubItems(1).Text
            myDate.Focus()
            myListView.Items.Remove(iDate)
            Upload()
        End If
    End Sub



    'Private Sub EnterPressed(ByVal sender As Object, ByVal e As KeyEventArgs) Handles myEvent.KeyDown
    '    MsgBox("ola")
    '    If e.KeyCode = Keys.Enter Then
    '        myRemoveButton_click(sender, Nothing)
    '    End If
    'End Sub

    Private Sub Upload()
        Dim Chronlist As New ChronList
        Dim iDate As ListViewItem

        For Each iDate In myListView.Items
            Chronlist.Add(iDate.Text, iDate.SubItems(1).Text)
        Next
        LazyNode.ChronList = Chronlist
        RaiseEventDataChanged(Me, Chronlist)
    End Sub

End Class
