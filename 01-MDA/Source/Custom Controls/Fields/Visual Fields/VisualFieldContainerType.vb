
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

Public Class VisualFieldContainerType
    Inherits VisualField


    Private myLabel As Label
    Private WithEvents myContainerType As VisualComboBoxImageField
    Private WithEvents myContainerCustomType As VisualTextField



    Public Sub New(ByVal LazyNode As LazyNode, ByVal Icons As ImageList)
        Me.LazyNode = LazyNode

        myLabel = New Label
        With myLabel
            .Width = VisualTextField.DefaultLabelWidth
            .Text = VisualFieldLabel("ContainerType")
            .Location = New Point(0, 0)
            .ForeColor = VisualField.MandatoryForeColor
        End With



        Dim Items(10) As ComboBoxImageItem
        Items(0) = New ComboBoxImageItem(VisualFieldLabel("ContainerType.Book"), VisualFieldLabel("ContainerType.Book"), 0)
        Items(1) = New ComboBoxImageItem(VisualFieldLabel("ContainerType.Box"), VisualFieldLabel("ContainerType.Box"), 1)
        Items(2) = New ComboBoxImageItem(VisualFieldLabel("ContainerType.Maco"), VisualFieldLabel("ContainerType.Maco"), 2)
        Items(3) = New ComboBoxImageItem(VisualFieldLabel("ContainerType.Macete"), VisualFieldLabel("ContainerType.Macete"), 3)
        Items(4) = New ComboBoxImageItem(VisualFieldLabel("ContainerType.Folder"), VisualFieldLabel("ContainerType.Folder"), 4)
        Items(5) = New ComboBoxImageItem(VisualFieldLabel("ContainerType.Cover"), VisualFieldLabel("ContainerType.Cover"), 5)
        Items(6) = New ComboBoxImageItem(VisualFieldLabel("ContainerType.Capilha"), VisualFieldLabel("ContainerType.Capilha"), 6)
        Items(7) = New ComboBoxImageItem(VisualFieldLabel("ContainerType.Roll"), VisualFieldLabel("ContainerType.Roll"), 7)
        Items(8) = New ComboBoxImageItem(VisualFieldLabel("ContainerType.Album"), VisualFieldLabel("ContainerType.Album"), 0)
        Items(9) = New ComboBoxImageItem(VisualFieldLabel("ContainerType.Envelope"), VisualFieldLabel("ContainerType.Envelope"), 1)
        Items(10) = New ComboBoxImageItem(VisualFieldLabel("ContainerType.Other"), VisualFieldLabel("ContainerType.Other"), 8)


        myContainerType = New VisualComboBoxImageField(Icons, Items)
        With myContainerType
            .Location = New Point(myLabel.Location.X + myLabel.Width + VisualTextField.DefaultLabelTextBoxGap, 0)
        End With

        myContainerCustomType = New VisualTextField("", VisualTextField.TextBoxWidthSmall, 1)
        With myContainerCustomType
            .Location = New Point(myContainerType.Location.X + 30, myContainerType.Location.Y)
            .Value = LazyNode.ContainerCustomType
        End With


        Dim SelectedItem As ComboBoxImageItem
        For Each SelectedItem In Items
            If SelectedItem.Value = LazyNode.ContainerType Then Exit For
        Next
        myContainerType.Value = SelectedItem


        Me.Size = New Size(myContainerCustomType.Location.X + myContainerCustomType.Width, myContainerCustomType.Height)
        Me.Controls.Add(myLabel)
        Me.Controls.Add(myContainerType)
        Me.Controls.Add(myContainerCustomType)
    End Sub




    Private Sub SelectedItemChanged(ByVal EventCode As Integer, ByVal Value As Object) Handles myContainerType.ValueChanged
        Dim SelectedItem As ComboBoxImageItem = Value
        If Not SelectedItem Is Nothing Then
            myContainerCustomType.Visible = SelectedItem.Value = VisualFieldLabel("ContainerType.Other")
        Else
            myContainerCustomType.Visible = False
        End If
    End Sub



    Private Sub UploadContainerType(ByVal EventCode As Integer, ByVal Value As Object) Handles myContainerType.ValueChanged
        LazyNode.ContainerType = CType(Value, ComboBoxImageItem).Value
        RaiseEventDataChanged(Me, Value)
    End Sub

    Private Sub UploadContainerCustomType(ByVal EventCode As Integer, ByVal Value As Object) Handles myContainerCustomType.ValueChanged
        LazyNode.ContainerCustomType = CStr(Value)
        RaiseEventDataChanged(Me, Value)
    End Sub


End Class
