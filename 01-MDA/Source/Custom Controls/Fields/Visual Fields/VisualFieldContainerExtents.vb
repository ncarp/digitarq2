
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

Public Class VisualFieldContainerExtents
    Inherits VisualField


#Region "Private Properties"

    Private WithEvents myExtentBook As VisualTextField
    Private WithEvents myExtentBox As VisualTextField
    Private WithEvents myExtentMaco As VisualTextField

    Private WithEvents myExtentMacete As VisualTextField
    Private WithEvents myExtentFolder As VisualTextField
    Private WithEvents myExtentCover As VisualTextField

    Private WithEvents myExtentCapilha As VisualTextField
    Private WithEvents myExtentRoll As VisualTextField
    Private WithEvents myExtentAlbum As VisualTextField

    Private WithEvents myExtentEnvelope As VisualTextField
    Private WithEvents myExtentOther As VisualTextField

    Private myExtentBookLabel As VisualLabelField
    Private myExtentBoxLabel As VisualLabelField
    Private myExtentMacoLabel As VisualLabelField

    Private myExtentMaceteLabel As VisualLabelField
    Private myExtentFolderLabel As VisualLabelField
    Private myExtentCoverLabel As VisualLabelField

    Private myExtentCapilhaLabel As VisualLabelField
    Private myExtentRollLabel As VisualLabelField
    Private myExtentAlbumLabel As VisualLabelField

    Private myExtentEnvelopeLabel As VisualLabelField
    Private myExtentOtherLabel As VisualLabelField

#End Region


#Region "Constants"
    Private Const DefaultTextBoxHeight As Integer = 20
    Private Const DefaultLabelWidth As Integer = 100
    Private Const DefaultTextBoxGap As Integer = 25
#End Region

    Public Sub New(ByVal LazyNode As LazyNode)
        Me.LazyNode = LazyNode

        If LazyNode.AllowExtentsInference Then
            DrawDefaultReadOnly()
        Else
            DrawDefaultEditable()
        End If
    End Sub



    ' Draws all extent fields with labels (read only)
    Private Sub DrawDefaultReadOnly()
        myExtentBookLabel = New VisualLabelField(VisualFieldLabel("ExtentBook"), VisualTextField.DefaultLabelWidth - 30, 50, ValidTextBox.FieldTypes.IntegerField)
        myExtentBoxLabel = New VisualLabelField(VisualFieldLabel("ExtentBox"), VisualTextField.DefaultLabelWidth - 30, 50, ValidTextBox.FieldTypes.IntegerField)
        myExtentMacoLabel = New VisualLabelField(VisualFieldLabel("ExtentMaco"), VisualTextField.DefaultLabelWidth - 30, 50, ValidTextBox.FieldTypes.IntegerField)

        myExtentMaceteLabel = New VisualLabelField(VisualFieldLabel("ExtentMacete"), VisualLabelField.DefaultLabelWidth - 30, 50, ValidTextBox.FieldTypes.IntegerField)
        myExtentFolderLabel = New VisualLabelField(VisualFieldLabel("ExtentFolder"), VisualTextField.DefaultLabelWidth - 30, 50, ValidTextBox.FieldTypes.IntegerField)
        myExtentCoverLabel = New VisualLabelField(VisualFieldLabel("ExtentCover"), VisualTextField.DefaultLabelWidth - 30, 50, ValidTextBox.FieldTypes.IntegerField)

        myExtentCapilhaLabel = New VisualLabelField(VisualFieldLabel("ExtentCapilha"), VisualLabelField.DefaultLabelWidth - 30, 50, ValidTextBox.FieldTypes.IntegerField)
        myExtentRollLabel = New VisualLabelField(VisualFieldLabel("ExtentRoll"), VisualTextField.DefaultLabelWidth - 30, 50, ValidTextBox.FieldTypes.IntegerField)
        myExtentAlbumLabel = New VisualLabelField(VisualFieldLabel("ExtentAlbum"), VisualTextField.DefaultLabelWidth - 30, 50, ValidTextBox.FieldTypes.IntegerField)

        myExtentEnvelopeLabel = New VisualLabelField(VisualFieldLabel("ExtentEnvelope"), VisualTextField.DefaultLabelWidth - 30, 50, ValidTextBox.FieldTypes.IntegerField)
        myExtentOtherLabel = New VisualLabelField(VisualFieldLabel("ExtentOther"), VisualTextField.DefaultLabelWidth - 30, 50, ValidTextBox.FieldTypes.IntegerField)


        With myExtentBookLabel
            .Location = New Point(0, 0)
            .Value = IntToStr(LazyNode.ExtentBook)
        End With

        With myExtentBoxLabel
            .Location = New Point(myExtentBookLabel.Location.X + myExtentBookLabel.Width + DefaultTextBoxGap, 0)
            .Value = IntToStr(LazyNode.ExtentBox)
        End With

        With myExtentMacoLabel
            .Location = New Point(myExtentBoxLabel.Location.X + myExtentBoxLabel.Width + DefaultTextBoxGap, 0)
            .Value = IntToStr(LazyNode.ExtentMaco)
        End With


        With myExtentMaceteLabel
            .Location = New Point(0, 20)
            .Value = IntToStr(LazyNode.ExtentMacete)
        End With

        With myExtentFolderLabel
            .Location = New Point(myExtentMaceteLabel.Location.X + myExtentMaceteLabel.Width + DefaultTextBoxGap, 20)
            .Value = IntToStr(LazyNode.ExtentFolder)
        End With

        With myExtentCoverLabel
            .Location = New Point(myExtentFolderLabel.Location.X + myExtentFolderLabel.Width + DefaultTextBoxGap, 20)
            .Value = IntToStr(LazyNode.ExtentCover)
        End With


        With myExtentCapilhaLabel
            .Location = New Point(0, 40)
            .Value = IntToStr(LazyNode.ExtentCapilha)
        End With

        With myExtentRollLabel
            .Location = New Point(myExtentCapilhaLabel.Location.X + myExtentCapilhaLabel.Width + DefaultTextBoxGap, 40)
            .Value = IntToStr(LazyNode.ExtentRoll)
        End With

        With myExtentAlbumLabel
            .Location = New Point(myExtentRollLabel.Location.X + myExtentRollLabel.Width + DefaultTextBoxGap, 40)
            .Value = IntToStr(LazyNode.ExtentAlbum)
        End With


        With myExtentEnvelopeLabel
            .Location = New Point(0, 60)
            .Value = IntToStr(LazyNode.ExtentEnvelope)
        End With

        With myExtentOtherLabel
            .Location = New Point(myExtentEnvelopeLabel.Location.X + myExtentEnvelopeLabel.Width + DefaultTextBoxGap, 60)
            .Value = IntToStr(LazyNode.ExtentOther)
        End With


        Me.Size = New Size(myExtentAlbumLabel.Location.X + myExtentAlbumLabel.Width + 10, _
                           myExtentOtherLabel.Location.Y + myExtentOtherLabel.Height)

        Me.Controls.Add(myExtentBookLabel)
        Me.Controls.Add(myExtentBoxLabel)
        Me.Controls.Add(myExtentMacoLabel)

        Me.Controls.Add(myExtentMaceteLabel)
        Me.Controls.Add(myExtentFolderLabel)
        Me.Controls.Add(myExtentCoverLabel)

        Me.Controls.Add(myExtentCapilhaLabel)
        Me.Controls.Add(myExtentRollLabel)
        Me.Controls.Add(myExtentAlbumLabel)

        Me.Controls.Add(myExtentEnvelopeLabel)
        Me.Controls.Add(myExtentOtherLabel)

    End Sub


    ' Draws all extent fields with text boxes (editable)
    Private Sub DrawDefaultEditable()
        myExtentBook = New VisualTextField(VisualFieldLabel("ExtentBook"), _
                           VisualTextField.DefaultLabelWidth - 30, 50, _
                           ValidTextBox.FieldTypes.IntegerField)

        myExtentBox = New VisualTextField(VisualFieldLabel("ExtentBox"), _
                          VisualTextField.DefaultLabelWidth - 30, 50, _
                          ValidTextBox.FieldTypes.IntegerField)

        myExtentMaco = New VisualTextField(VisualFieldLabel("ExtentMaco"), _
                           VisualTextField.DefaultLabelWidth - 30, 50, _
                           ValidTextBox.FieldTypes.IntegerField)


        myExtentMacete = New VisualTextField(VisualFieldLabel("ExtentMacete"), _
                            VisualLabelField.DefaultLabelWidth - 30, 50, _
                            ValidTextBox.FieldTypes.IntegerField)

        myExtentFolder = New VisualTextField(VisualFieldLabel("ExtentFolder"), _
                             VisualTextField.DefaultLabelWidth - 30, 50, _
                             ValidTextBox.FieldTypes.IntegerField)

        myExtentCover = New VisualTextField(VisualFieldLabel("ExtentCover"), _
                            VisualTextField.DefaultLabelWidth - 30, 50, _
                            ValidTextBox.FieldTypes.IntegerField)


        myExtentCapilha = New VisualTextField(VisualFieldLabel("ExtentCapilha"), _
                             VisualLabelField.DefaultLabelWidth - 30, 50, _
                             ValidTextBox.FieldTypes.IntegerField)

        myExtentRoll = New VisualTextField(VisualFieldLabel("ExtentRoll"), _
                           VisualTextField.DefaultLabelWidth - 30, 50, _
                           ValidTextBox.FieldTypes.IntegerField)

        myExtentAlbum = New VisualTextField(VisualFieldLabel("ExtentAlbum"), _
                                   VisualTextField.DefaultLabelWidth - 30, 50, _
                                   ValidTextBox.FieldTypes.IntegerField)


        myExtentEnvelope = New VisualTextField(VisualFieldLabel("ExtentEnvelope"), _
                           VisualTextField.DefaultLabelWidth - 30, 50, _
                           ValidTextBox.FieldTypes.IntegerField)

        myExtentOther = New VisualTextField(VisualFieldLabel("ExtentOther"), _
                    VisualTextField.DefaultLabelWidth - 30, 50, _
                    ValidTextBox.FieldTypes.IntegerField)


        Dim LineLocationY As Integer = 0
        With myExtentBook
            .Location = New Point(0, LineLocationY)
            .Value = IntToStr(LazyNode.ExtentBook)
        End With

        With myExtentBox
            .Location = New Point(myExtentBook.Location.X + myExtentBook.Width + DefaultTextBoxGap, LineLocationY)
            .Value = IntToStr(LazyNode.ExtentBox)
        End With

        With myExtentMaco
            .Location = New Point(myExtentBox.Location.X + myExtentBox.Width + DefaultTextBoxGap, LineLocationY)
            .Value = IntToStr(LazyNode.ExtentMaco)
        End With

        LineLocationY += 25

        With myExtentMacete
            .Location = New Point(0, LineLocationY)
            .Value = IntToStr(LazyNode.ExtentMacete)
        End With

        With myExtentFolder
            .Location = New Point(myExtentMacete.Location.X + myExtentMacete.Width + DefaultTextBoxGap, LineLocationY)
            .Value = IntToStr(LazyNode.ExtentFolder)
        End With

        With myExtentCover
            .Location = New Point(myExtentFolder.Location.X + myExtentFolder.Width + DefaultTextBoxGap, LineLocationY)
            .Value = IntToStr(LazyNode.ExtentCover)
        End With

        LineLocationY += 25

        With myExtentCapilha
            .Location = New Point(0, LineLocationY)
            .Value = IntToStr(LazyNode.ExtentCapilha)
        End With

        With myExtentRoll
            .Location = New Point(myExtentCapilha.Location.X + myExtentCapilha.Width + DefaultTextBoxGap, LineLocationY)
            .Value = IntToStr(LazyNode.ExtentRoll)
        End With

        With myExtentAlbum
            .Location = New Point(myExtentRoll.Location.X + myExtentRoll.Width + DefaultTextBoxGap, LineLocationY)
            .Value = IntToStr(LazyNode.ExtentAlbum)
        End With

        LineLocationY += 25

        With myExtentEnvelope
            .Location = New Point(0, LineLocationY)
            .Value = IntToStr(LazyNode.ExtentEnvelope)
        End With

        With myExtentOther
            .Location = New Point(myExtentEnvelope.Location.X + myExtentEnvelope.Width + DefaultTextBoxGap, LineLocationY)
            .Value = IntToStr(LazyNode.ExtentOther)
        End With

        Me.Size = New Size(myExtentAlbum.Location.X + myExtentAlbum.Width + 10, myExtentOther.Location.Y + myExtentOther.Height)

        Me.Controls.Add(myExtentBook)
        Me.Controls.Add(myExtentBox)
        Me.Controls.Add(myExtentMaco)

        Me.Controls.Add(myExtentMacete)
        Me.Controls.Add(myExtentFolder)
        Me.Controls.Add(myExtentCover)

        Me.Controls.Add(myExtentCapilha)
        Me.Controls.Add(myExtentRoll)
        Me.Controls.Add(myExtentAlbum)

        Me.Controls.Add(myExtentEnvelope)
        Me.Controls.Add(myExtentOther)

    End Sub


    Protected Sub UploadExtentBook(ByVal EventCode As Integer, ByVal Value As Object) _
            Handles myExtentBook.ValueChanged
        LazyNode.ExtentBook = StrToInt(Value)
        RaiseEventDataChanged(Me, Value)
    End Sub

    Protected Sub UploadExtentBox(ByVal EventCode As Integer, ByVal Value As Object) _
            Handles myExtentBox.ValueChanged
        LazyNode.ExtentBox = StrToInt(Value)
        RaiseEventDataChanged(Me, Value)
    End Sub

    Protected Sub UploadExtentMaco(ByVal EventCode As Integer, ByVal Value As Object) _
            Handles myExtentMaco.ValueChanged
        LazyNode.ExtentMaco = StrToInt(Value)
        RaiseEventDataChanged(Me, Value)
    End Sub


    Protected Sub UploadExtentMacete(ByVal EventCode As Integer, ByVal Value As Object) _
            Handles myExtentMacete.ValueChanged
        LazyNode.ExtentMacete = StrToInt(Value)
        RaiseEventDataChanged(Me, Value)
    End Sub

    Protected Sub UploadExtentFolder(ByVal EventCode As Integer, ByVal Value As Object) _
            Handles myExtentFolder.ValueChanged
        LazyNode.ExtentFolder = StrToInt(Value)
        RaiseEventDataChanged(Me, Value)
    End Sub

    Protected Sub UploadExtentCover(ByVal EventCode As Integer, ByVal Value As Object) _
            Handles myExtentCover.ValueChanged
        LazyNode.ExtentCover = StrToInt(Value)
        RaiseEventDataChanged(Me, Value)
    End Sub


    Protected Sub UploadExtentCapilha(ByVal EventCode As Integer, ByVal Value As Object) _
            Handles myExtentCapilha.ValueChanged
        LazyNode.ExtentCapilha = StrToInt(Value)
        RaiseEventDataChanged(Me, Value)
    End Sub

    Protected Sub UploadExtentRoll(ByVal EventCode As Integer, ByVal Value As Object) _
        Handles myExtentRoll.ValueChanged
        LazyNode.ExtentRoll = StrToInt(Value)
        RaiseEventDataChanged(Me, Value)
    End Sub

    Protected Sub UploadExtentAlbum(ByVal EventCode As Integer, ByVal Value As Object) _
            Handles myExtentAlbum.ValueChanged
        LazyNode.ExtentAlbum = StrToInt(Value)
        RaiseEventDataChanged(Me, Value)
    End Sub


    Protected Sub UploadExtentEnvelope(ByVal EventCode As Integer, ByVal Value As Object) _
            Handles myExtentEnvelope.ValueChanged
        LazyNode.ExtentEnvelope = StrToInt(Value)
        RaiseEventDataChanged(Me, Value)
    End Sub

    Protected Sub UploadExtentOther(ByVal EventCode As Integer, ByVal Value As Object) _
            Handles myExtentOther.ValueChanged
        LazyNode.ExtentOther = StrToInt(Value)
        RaiseEventDataChanged(Me, Value)
    End Sub

End Class


