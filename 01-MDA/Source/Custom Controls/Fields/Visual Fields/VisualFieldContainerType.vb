
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
