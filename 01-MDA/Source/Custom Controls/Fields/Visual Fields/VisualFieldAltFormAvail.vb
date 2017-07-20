
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
