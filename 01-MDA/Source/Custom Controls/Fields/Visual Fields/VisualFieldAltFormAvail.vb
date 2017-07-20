
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

Imports System.Configuration

Public Class VisualFieldAltFormAvail
    Inherits VisualField

    Private WithEvents myTextField As VisualTextField
    Private WithEvents myDOList As ListView

    Public Sub New(ByVal LazyNode As LazyNode, ByVal ButtonImages As ImageList)
        Me.LazyNode = LazyNode

        myTextField = New VisualTextField(VisualFieldLabel("AltFormAvail"), VisualTextField.TextBoxWidthExtraLarge - 15)
        myTextField.Value = LazyNode.AltFormAvail

        Dim chDigitalObject As New ColumnHeader
        chDigitalObject.Text = VisualFieldLabel("DigitalObjectHeader")
        chDigitalObject.Width = (VisualTextField.TextBoxWidthExtraLarge - 15) * 0.25

        Dim chArchiveID As New ColumnHeader
        chArchiveID.Text = VisualFieldLabel("ArchiveIDHeader")
        chArchiveID.Width = (VisualTextField.TextBoxWidthExtraLarge - 15) * 0.25

        Dim chTopographicalQuota As New ColumnHeader
        chTopographicalQuota.Text = VisualFieldLabel("TopographicalQuotaHeader")
        chTopographicalQuota.Width = (VisualTextField.TextBoxWidthExtraLarge - 15) * 0.3

        Dim chImageName As New ColumnHeader
        chImageName.Text = VisualFieldLabel("ImageNameHeader")
        chImageName.Width = (VisualTextField.TextBoxWidthExtraLarge - 15) * 0.2

        myDOList = New ListView
        With myDOList
            .Location = New Point(VisualTextField.DefaultLabelWidth + VisualTextField.DefaultLabelTextBoxGap, myTextField.Location.Y + myTextField.Height + 5)
            .Width = VisualTextField.TextBoxWidthExtraLarge - 15
            .Alignment = System.Windows.Forms.ListViewAlignment.Default
            .AllowColumnReorder = True
            .AutoArrange = False
            .BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            .Columns.AddRange(New System.Windows.Forms.ColumnHeader() {chDigitalObject, chArchiveID, chTopographicalQuota, chImageName})
            .FullRowSelect = True
            .HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
            .LabelWrap = False
            .MultiSelect = False
            .Sorting = System.Windows.Forms.SortOrder.Ascending
            .View = System.Windows.Forms.View.Details
            .Items.Clear()
        End With

        Me.Size = New Size(myTextField.Width, Me.myTextField.Height + 5 + Me.myDOList.Height)
        Me.Controls.Add(myTextField)
        Me.Controls.Add(myDOList)

        LoadAssociations()
    End Sub


    Private Sub Upload(ByVal EventCode As Integer, ByVal Value As Object) Handles myTextField.ValueChanged
        LazyNode.AltFormAvail = CStr(Value)
        RaiseEventDataChanged(Me, Value)
    End Sub

    Private Sub LoadAssociations()
        'Dim SQLServerSettings As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")
        Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")

        Dim myData As DataSet = SQLLazyNode.GetAssociations(SQLServerSettings.Item("ServerAddress"), _
                                                SQLServerSettings.Item("Database"), _
                                                SQLServerSettings.Item("Username"), _
                                                SQLServerSettings.Item("Password"), _
                                                LazyNode.ID)

        myDOList.Items.Clear()
        Dim myTable As DataTable = myData.Tables(0)
        For Each row As DataRow In myTable.Rows
            Dim lvi As ListViewItem = New ListViewItem(row.Item("DOName").ToString)
            lvi.SubItems.Add(row.Item("ArchiveID").ToString)
            lvi.SubItems.Add(row.Item("TopographicalQuota").ToString)
            lvi.SubItems.Add(row.Item("DOFileName").ToString)

            Me.myDOList.Items.Add(lvi)
        Next
    End Sub

End Class
