
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

Imports System.Configuration

Public Class VisualFieldArchivistNotes
    Inherits VisualField


#Region "Private Properties"

    Private WithEvents myNoteTitle As VisualTextField
    Private WithEvents myNote As VisualTextField
    Private myLabel As Label
    Private WithEvents myNoteList As ListView
    Private WithEvents myAddButton As mkccontrols.windows.forms.control.mkc_Button
    Private WithEvents myRemoveButton As mkccontrols.windows.forms.control.mkc_Button
    Private myProcessInfoName As String

#End Region


#Region "Constants"

    Private Const DefaultTextBoxHeight As Integer = 20
    Private Const DefaultLabelWidth As Integer = 100
    Private Const DefaultTextBoxGap As Integer = 25
    Private Const DefaultSeparatorHeight As Integer = 10

#End Region

    Public Sub New(ByVal LazyNode As LazyNode, ByVal ButtonImages As ImageList, ByVal ProcessInfoName As String)
        Me.LazyNode = LazyNode
        myProcessInfoName = ProcessInfoName

        myLabel = New Label
        With myLabel
            .Location = New Point(0, 0)
            .Text = VisualFieldLabel("ArchivistNoteTitle")
            .AutoSize = True
        End With

        myNoteTitle = New VisualTextField("", 0, VisualTextField.TextBoxWidthExtraLarge - 15, ValidTextBox.FieldTypes.DefaultField)
        With myNoteTitle
            .Location = New Point(VisualTextField.DefaultLabelWidth + VisualTextField.DefaultLabelTextBoxGap, 0)
            .Value = ""
            .MaxLength = 190
        End With

        myNote = New VisualTextField("", VisualTextField.TextBoxWidthExtraLarge - 15, VisualTextField.TextBoxHeightMedium)
        With myNote
            .Location = New Point(0, myNoteTitle.Location.Y + myNoteTitle.Height + 5)
            .Value = ""
            .AllowEdit = True
            .Mandatory = False
            .MaxLength = 490
        End With

        Dim chUsername As New ColumnHeader
        chUsername.Text = VisualFieldLabel("ArchivistNameHeader")
        chUsername.Width = VisualTextField.TextBoxWidthSmall

        Dim chDate As New ColumnHeader
        chDate.Text = VisualFieldLabel("DateHeader")
        chDate.Width = VisualTextField.TextBoxWidthSmall - 20

        Dim chNoteTitle As New ColumnHeader
        chNoteTitle.Text = VisualFieldLabel("NoteTitleHeader")
        chNoteTitle.Width = VisualTextField.TextBoxWidthExtraLarge - 15 - chDate.Width - chUsername.Width

        myNoteList = New ListView
        With myNoteList
            .Location = New Point(VisualTextField.DefaultLabelWidth + VisualTextField.DefaultLabelTextBoxGap, myNote.Location.Y + myNote.Height + 5)
            .Width = VisualTextField.TextBoxWidthExtraLarge - 15
            .Alignment = System.Windows.Forms.ListViewAlignment.Default
            .AllowColumnReorder = True
            .AutoArrange = False
            .BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            .Columns.AddRange(New System.Windows.Forms.ColumnHeader() {chNoteTitle, chUsername, chDate})
            .FullRowSelect = True
            .HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
            .LabelWrap = False
            .MultiSelect = False
            .Sorting = System.Windows.Forms.SortOrder.Ascending
            .View = System.Windows.Forms.View.Details
            .Items.Clear()
        End With

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
            .Location = New Point(myNoteList.Location.X + myNoteList.Width + 3, myNoteList.Location.Y)
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

        Me.Size = New Size(myAddButton.Location.X + myAddButton.Width, myNoteList.Location.Y + myNoteList.Height)

        Me.Controls.Add(myLabel)
        Me.Controls.Add(myNoteTitle)
        Me.Controls.Add(myNote)
        Me.Controls.Add(myAddButton)
        Me.Controls.Add(myRemoveButton)
        Me.Controls.Add(myNoteList)

        LoadArchivistNotes()
    End Sub


    Private Sub myAddButton_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myAddButton.Click
        If CStr(myNoteTitle.Value).Trim <> "" Then
            AddArchivistNote()
            myNoteTitle.Value = ""
            myNote.Value = ""
            myNoteTitle.Focus()
        End If
    End Sub


    Private Sub myRemoveButton_click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles myRemoveButton.Click
        If myNoteList.SelectedIndices.Count > 0 Then
            SelectAndFillNote()
            RemoveArchivistNote()
        End If
    End Sub

    Private Sub AddArchivistNote()
        'Dim SQLServerSettings As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")
        Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")

        Dim ArchivistNoteItem As New ArchivistNotesItem(Me.myNoteTitle.Value, Me.myNote.Value, DateToDB(Now), LazyNode.ID, myProcessInfoName)

        SQLLazyNode.AddArchivistNote(SQLServerSettings.Item("ServerAddress"), _
                                     SQLServerSettings.Item("Database"), _
                                     SQLServerSettings.Item("Username"), _
                                     SQLServerSettings.Item("Password"), _
                                     ArchivistNoteItem)
        LoadArchivistNotes()
    End Sub

    Private Sub RemoveArchivistNote()
        'Dim SQLServerSettings As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")
        Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")

        SQLLazyNode.RemoveArchivistNote(SQLServerSettings.Item("ServerAddress"), _
                                SQLServerSettings.Item("Database"), _
                                SQLServerSettings.Item("Username"), _
                                SQLServerSettings.Item("Password"), _
                                myNoteList.SelectedItems(0).Tag)

        LoadArchivistNotes()
    End Sub

    Private Sub LoadArchivistNotes()
        'Dim SQLServerSettings As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")
        Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")

        Dim ArchivistNotesList As ArchivistNotes = SQLLazyNode.GetArchivistNotesList(SQLServerSettings.Item("ServerAddress"), _
                                                SQLServerSettings.Item("Database"), _
                                                SQLServerSettings.Item("Username"), _
                                                SQLServerSettings.Item("Password"), _
                                                LazyNode.ID)

        myNoteList.Items.Clear()
        For Each item As ArchivistNotesItem In ArchivistNotesList
            Dim lvi As ListViewItem = New ListViewItem(item.NoteTitle)
            lvi.SubItems.Add(item.Username)
            lvi.SubItems.Add(item.NoteDate)
            lvi.Tag = item.NoteID
            Me.myNoteList.Items.Add(lvi)
        Next
    End Sub

    Private Sub myListBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles myNoteList.SelectedIndexChanged
        If myNoteList.SelectedIndices.Count > 0 Then
            SelectAndFillNote()
        End If
    End Sub

    Private Sub SelectAndFillNote()
        'Dim SQLServerSettings As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")
        Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")

        Dim ArchivistNote As ArchivistNotesItem = SQLLazyNode.GetArchivistNote(SQLServerSettings.Item("ServerAddress"), _
                                                SQLServerSettings.Item("Database"), _
                                                SQLServerSettings.Item("Username"), _
                                                SQLServerSettings.Item("Password"), _
                                                myNoteList.SelectedItems(0).Tag)

        Me.myNoteTitle.Value = ArchivistNote.NoteTitle
        Me.myNote.Value = ArchivistNote.Note
        If myProcessInfoName <> ArchivistNote.Username Then
            Me.myRemoveButton.Enabled = False
        Else
            Me.myRemoveButton.Enabled = True
        End If
        Me.myAddButton.Enabled = False
    End Sub

    Private Sub myNoteTitle_ValueChanged(ByVal EventCode As Integer, ByVal Value As Object) Handles myNoteTitle.ValueChanged
        Me.myAddButton.Enabled = True
    End Sub

    Private Sub myNote_ValueChanged(ByVal EventCode As Integer, ByVal Value As Object) Handles myNote.ValueChanged
        Me.myAddButton.Enabled = True
    End Sub
End Class

