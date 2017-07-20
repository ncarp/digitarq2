
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

Public Class VisualFieldExtents
    Inherits VisualField


#Region "Private Properties"
    Private WithEvents myExtentMl As VisualTextField
    Private WithEvents myExtentPage As VisualTextField
    Private WithEvents myExtentLeaf As VisualTextField
    Private WithEvents myAllowExtentsInference As VisualCheckField

#End Region

#Region "Events"
    Public Event InferenceButtonClicked()

#End Region

#Region "Constants"
    Private Const DefaultTextBoxHeight As Integer = 20
    Private Const DefaultLabelWidth As Integer = 100
    Private Const DefaultTextBoxGap As Integer = 25
#End Region


    Private Sub DrawSeries()
        myExtentMl = New VisualTextField(VisualFieldLabel("ExtentMl"), VisualTextField.DefaultLabelWidth, 50, ValidTextBox.FieldTypes.FloatField)
        Dim myExtentPageLabel = New VisualLabelField(VisualFieldLabel("ExtentPage"), 50, 50, ValidTextBox.FieldTypes.IntegerField)
        Dim myExtentLeafLabel = New VisualLabelField(VisualFieldLabel("ExtentLeaf"), 50, 50, ValidTextBox.FieldTypes.IntegerField)

        With myExtentMl
            .Location = New Point(0, 0)
            .Value = DblToStr(LazyNode.ExtentMl)
        End With
        Me.Controls.Add(myExtentMl)

        With myExtentPageLabel
            .Location = New Point(VisualTextField.DefaultLabelWidth + 50 + DefaultTextBoxGap, 0)
            .Value = IntToStr(LazyNode.ExtentPage)
        End With

        With myExtentLeafLabel
            .Location = New Point(myExtentPageLabel.Location.X + myExtentPageLabel.Width + DefaultTextBoxGap, 0)
            .Value = IntToStr(LazyNode.ExtentLeaf)
        End With


        Me.Size = New Size(myExtentLeafLabel.Location.X + myExtentLeafLabel.Width + 10, myExtentMl.Location.Y + myExtentMl.Height)

        Me.Controls.Add(myExtentPageLabel)
        Me.Controls.Add(myExtentLeafLabel)
    End Sub







    Private Sub DrawBellowSeries()
        If LazyNode.isLeaf() Then
            myExtentPage = New VisualTextField(VisualFieldLabel("ExtentPage"), VisualTextField.DefaultLabelWidth, 50, ValidTextBox.FieldTypes.IntegerField)
            myExtentLeaf = New VisualTextField(VisualFieldLabel("ExtentLeaf"), 50, 50, ValidTextBox.FieldTypes.IntegerField)

            With myExtentPage
                .Location = New Point(0, 0)
                .Value = IntToStr(LazyNode.ExtentPage)
            End With

            With myExtentLeaf
                .Location = New Point(myExtentPage.Location.X + myExtentPage.Width + DefaultTextBoxGap, 0)
                .Value = IntToStr(LazyNode.ExtentLeaf)
            End With

            Me.Size = New Size(myExtentLeaf.Location.X + myExtentLeaf.Width + 10, myExtentLeaf.Location.Y + myExtentLeaf.Height)


            Me.Controls.Add(myExtentPage)
            Me.Controls.Add(myExtentLeaf)
        Else


            myAllowExtentsInference = New VisualCheckField( _
                                    VisualFieldLabel("AllowExtentsInference"))

            Dim LineLocationY As Integer = 0
            'With myAllowExtentsInference
            '    '.Location = New Point(Me.Width, LineLocationY)
            '    .Text = VisualFieldLabel("AllowExtentsInference")
            '    .Value = LazyNode.AllowExtentsInference
            'End With

            'LineLocationY += myAllowExtentsInference.Height + 10


            Dim myExtentPageLabel = New VisualLabelField(VisualFieldLabel("ExtentPage"), VisualTextField.DefaultLabelWidth, 50, ValidTextBox.FieldTypes.IntegerField)
            Dim myExtentLeafLabel = New VisualLabelField(VisualFieldLabel("ExtentLeaf"), 50, 50, ValidTextBox.FieldTypes.IntegerField)

            With myExtentPageLabel
                .Location = New Point(0, LineLocationY)
                .Value = IntToStr(LazyNode.ExtentPage)
            End With

            With myExtentLeafLabel
                .Location = New Point(myExtentPageLabel.Location.X + myExtentPageLabel.Width + _
                                      DefaultTextBoxGap, LineLocationY)
                .Value = IntToStr(LazyNode.ExtentLeaf)
            End With

            With myAllowExtentsInference
                .Location = New Point(myExtentLeafLabel.Location.X + myExtentLeafLabel.Width + DefaultTextBoxGap, LineLocationY)
                .Text = VisualFieldLabel("AllowExtentsInference")
                .Value = LazyNode.AllowExtentsInference
            End With

            Me.Size = New Size(myAllowExtentsInference.Location.X + myAllowExtentsInference.Width + 10, myExtentLeafLabel.Location.Y + myExtentLeafLabel.Height)

            'Me.Size = New Size(myExtentLeafLabel.Location.X + myExtentLeafLabel.Width + 10, myExtentLeafLabel.Location.Y + myExtentLeafLabel.Height)

            'Me.myAllowExtentsInference.Location = New Point(Me.Width - Me.myAllowExtentsInference.Width - 10, 0)

            Me.Controls.Add(myExtentPageLabel)
            Me.Controls.Add(myExtentLeafLabel)
            Me.Controls.Add(myAllowExtentsInference)
        End If

    End Sub





    Sub DrawBellowSeriesEditable()
        myAllowExtentsInference = New VisualCheckField( _
                                          VisualFieldLabel("AllowExtentsInference"))



        myExtentPage = New VisualTextField(VisualFieldLabel("ExtentPage"), _
                           VisualTextField.DefaultLabelWidth, 50, _
                           ValidTextBox.FieldTypes.IntegerField)

        myExtentLeaf = New VisualTextField(VisualFieldLabel("ExtentLeaf"), _
                           VisualTextField.DefaultLabelWidth - 50, 50, _
                           ValidTextBox.FieldTypes.IntegerField)

        Dim LineLocationY As Integer = 0


        With myExtentPage
            .Location = New Point(0, LineLocationY)
            .Value = IntToStr(LazyNode.ExtentPage)
        End With

        With myExtentLeaf
            .Location = New Point(myExtentPage.Location.X + myExtentPage.Width + DefaultTextBoxGap, LineLocationY)
            .Value = IntToStr(LazyNode.ExtentLeaf)
        End With

        With myAllowExtentsInference
            .Location = New Point(myExtentLeaf.Location.X + myExtentLeaf.Width + DefaultTextBoxGap, LineLocationY)
            .Text = VisualFieldLabel("AllowExtentsInference")
            .Value = LazyNode.AllowExtentsInference
        End With

        Me.Size = New Size(myAllowExtentsInference.Location.X + myAllowExtentsInference.Width + 10, myExtentLeaf.Location.Y + myExtentLeaf.Height)

        Me.Controls.Add(myExtentPage)
        Me.Controls.Add(myExtentLeaf)
        Me.Controls.Add(myAllowExtentsInference)
    End Sub





    Private Sub DrawDefaultReadOnly()
        myAllowExtentsInference = New VisualCheckField( _
                                      VisualFieldLabel("AllowExtentsInference"))

        Dim myExtentMlLabel = New VisualLabelField(VisualFieldLabel("ExtentMl"), _
                                  VisualTextField.DefaultLabelWidth - 30, 50, _
                                  ValidTextBox.FieldTypes.FloatField)

        Dim myExtentPageLabel = New VisualLabelField(VisualFieldLabel("ExtentPage"), _
                                    VisualTextField.DefaultLabelWidth - 30, 50, _
                                    ValidTextBox.FieldTypes.IntegerField)
        Dim myExtentLeafLabel = New VisualLabelField(VisualFieldLabel("ExtentLeaf"), _
                                    VisualTextField.DefaultLabelWidth - 30, 50, _
                                    ValidTextBox.FieldTypes.IntegerField)


        Dim LineLocationY As Integer = 0
        With myAllowExtentsInference
            '.Location = New Point(Me.Width, 0)
            .Text = VisualFieldLabel("AllowExtentsInference")
            .Value = LazyNode.AllowExtentsInference
        End With

        LineLocationY += myAllowExtentsInference.Height + 10

        With myExtentMlLabel
            .Location = New Point(0, LineLocationY)
            .Value = DblToStr(LazyNode.ExtentMl)
        End With

        With myExtentPageLabel
            .Location = New Point(myExtentMlLabel.Location.X + myExtentMlLabel.width + DefaultTextBoxGap, LineLocationY)
            .Value = IntToStr(LazyNode.ExtentPage)
        End With

        With myExtentLeafLabel
            .Location = New Point(myExtentPageLabel.Location.X + myExtentPageLabel.Width + DefaultTextBoxGap, LineLocationY)
            .Value = IntToStr(LazyNode.ExtentLeaf)
        End With

        Me.Size = New Size(myExtentLeafLabel.Location.X + myExtentLeafLabel.Width + 10, myExtentLeafLabel.Location.Y + myExtentLeafLabel.Height)

        Me.myAllowExtentsInference.Location = New Point(Me.Width - Me.myAllowExtentsInference.Width - 10, 0)

        Me.Controls.Add(myExtentMlLabel)
        Me.Controls.Add(myExtentPageLabel)
        Me.Controls.Add(myExtentLeafLabel)
        Me.Controls.Add(myAllowExtentsInference)
    End Sub



    Private Sub DrawDefaultEditable()
        myAllowExtentsInference = New VisualCheckField( _
                                        VisualFieldLabel("AllowExtentsInference"))

        myExtentMl = New VisualTextField(VisualFieldLabel("ExtentMl"), _
                         VisualTextField.DefaultLabelWidth - 30, 50, _
                         ValidTextBox.FieldTypes.FloatField)

        myExtentPage = New VisualTextField(VisualFieldLabel("ExtentPage"), _
                           VisualTextField.DefaultLabelWidth - 30, 50, _
                           ValidTextBox.FieldTypes.IntegerField)

        myExtentLeaf = New VisualTextField(VisualFieldLabel("ExtentLeaf"), _
                           VisualTextField.DefaultLabelWidth - 30, 50, _
                           ValidTextBox.FieldTypes.IntegerField)

        Dim LineLocationY As Integer = 0
        With myAllowExtentsInference
            '.Location = New Point(Me.Width, LineLocationY)
            .Text = VisualFieldLabel("AllowExtentsInference")
            .Value = LazyNode.AllowExtentsInference
        End With

        LineLocationY += myAllowExtentsInference.Height + 10

        With myExtentMl
            .Location = New Point(0, LineLocationY)
            .Value = DblToStr(LazyNode.ExtentMl)

        End With

        With myExtentPage
            .Location = New Point(myExtentMl.Location.X + myExtentMl.Width + DefaultTextBoxGap, LineLocationY)
            .Value = IntToStr(LazyNode.ExtentPage)
        End With

        With myExtentLeaf
            .Location = New Point(myExtentPage.Location.X + myExtentPage.Width + DefaultTextBoxGap, LineLocationY)
            .Value = IntToStr(LazyNode.ExtentLeaf)
        End With

        Me.Size = New Size(myExtentLeaf.Location.X + myExtentLeaf.Width + 10, myExtentLeaf.Location.Y + myExtentLeaf.Height)

        Me.myAllowExtentsInference.Location = New Point(Me.Width - Me.myAllowExtentsInference.Width - 10, 0)

        Me.Controls.Add(myExtentMl)
        Me.Controls.Add(myExtentPage)
        Me.Controls.Add(myExtentLeaf)
        Me.Controls.Add(myAllowExtentsInference)
    End Sub






    Protected Sub UploadExtentMl(ByVal EventCode As Integer, ByVal Value As Object) Handles myExtentMl.ValueChanged
        LazyNode.ExtentMl = StrToDbl(Value)
        RaiseEventDataChanged(Me, Value)
    End Sub

    Protected Sub UploadExtentPage(ByVal EventCode As Integer, ByVal Value As Object) Handles myExtentPage.ValueChanged
        LazyNode.ExtentPage = StrToInt(Value)
        RaiseEventDataChanged(Me, Value)
    End Sub

    Protected Sub UploadExtentLeaf(ByVal EventCode As Integer, ByVal Value As Object) Handles myExtentLeaf.ValueChanged
        LazyNode.ExtentLeaf = StrToInt(Value)
        RaiseEventDataChanged(Me, Value)
    End Sub


    Protected Sub UploadAllowExtentsInference(ByVal EventCode As Integer, ByVal Value As Object) Handles myAllowExtentsInference.ValueChanged
        LazyNode.AllowExtentsInference = CBool(Value)
        RaiseEventDataChanged(Me, LazyNode.AllowExtentsInference)
        RaiseEvent InferenceButtonClicked()
    End Sub





    Public Sub New(ByVal LazyNode As LazyNode)
        Me.LazyNode = LazyNode


        If LazyNode.OtherLevel = OTHERLEVEL_SERIES Then
            DrawSeries()
        ElseIf ((LazyNode.OtherLevel = OTHERLEVEL_INSTALATIONUNIT OrElse _
                LazyNode.OtherLevel = OTHERLEVEL_COMPOSEDDOCUMENT OrElse _
                LazyNode.OtherLevel = OTHERLEVEL_DOCUMENT)) And LazyNode.AllowExtentsInference Then
            DrawBellowSeries()
        ElseIf ((LazyNode.OtherLevel = OTHERLEVEL_INSTALATIONUNIT OrElse _
            LazyNode.OtherLevel = OTHERLEVEL_COMPOSEDDOCUMENT OrElse _
            LazyNode.OtherLevel = OTHERLEVEL_DOCUMENT)) And Not LazyNode.AllowExtentsInference Then
            DrawBellowSeriesEditable()
        Else
            If Not LazyNode.AllowExtentsInference And LazyNode.OtherLevel = OTHERLEVEL_FONDS Then
                DrawDefaultEditable()
            Else
                DrawDefaultReadOnly()
            End If
        End If


    End Sub


End Class

