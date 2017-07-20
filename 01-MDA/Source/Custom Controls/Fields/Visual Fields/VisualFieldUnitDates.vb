
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

Public Class VisualFieldUnitDates
    Inherits VisualField


#Region "Private Properties"

    Private myLabel As Label
    Private WithEvents myUnitDateInitial As VisualDateField
    Private WithEvents myUnitDateInitialCertainty As VisualCheckField
    Private WithEvents myUnitDateFinal As VisualDateField
    Private WithEvents myUnitDateFinalCertainty As VisualCheckField
    Private WithEvents myUnitDateBulk As VisualTextField
    Private WithEvents myAllowUnitDatesInference As VisualCheckField

    Const CenterTop As Integer = 3

#End Region

#Region "Events"
    Public Event InferenceButtonClicked()
#End Region

    Public Sub New(ByVal LazyNode As LazyNode)
        Me.LazyNode = LazyNode

        myLabel = New Label
        myUnitDateBulk = New VisualTextField(VisualFieldLabel("UnitDateBulk"), VisualTextField.TextBoxWidthLarge)

        With myLabel
            .Width = VisualTextField.DefaultLabelWidth
            .Text = VisualFieldLabel("UnitDates")
            .Location = New Point(0, 0)
            .ForeColor = VisualField.MandatoryForeColor
        End With

        Me.Controls.Add(myLabel)

        ' add functionality here to support inference
        Dim EnableControls As Boolean = LazyNode.isLeaf Or Not LazyNode.AllowUnitDatesInference

        If EnableControls Then
            DrawTextFields()
        Else
            DrawDateLabel()
        End If

        With myUnitDateBulk
            .Location = New Point(0, 25)
            .Value = LazyNode.UnitDateBulk
        End With

        Me.Controls.Add(myUnitDateBulk)
        Me.Size = New Size(myUnitDateBulk.Width, myUnitDateBulk.Location.Y + myUnitDateBulk.Height)

    End Sub


    ' Draws dates in a disabled state
    Private Sub DrawDateLabel()
        Dim myDateLabel As Label = New Label
        myAllowUnitDatesInference = New VisualCheckField( _
                                        VisualFieldLabel("AllowUnitDatesInference"))

        With myDateLabel
            .Location = New Point(myLabel.Location.X + myLabel.Width + VisualTextField.DefaultLabelTextBoxGap, 0)
            .Text = FormatExtremeDates(LazyNode)
            .Width = .Text.Length * 6
        End With


        With myAllowUnitDatesInference
            '.Location = New Point(myDateLabel.Location.X + myDateLabel.Width + VisualTextField.DefaultLabelTextBoxGap, 0)
            .Location = New Point(324, 0)
            .Text = VisualFieldLabel("AllowUnitDatesInference")
            .Value = LazyNode.AllowUnitDatesInference
        End With


        Me.Controls.Add(myAllowUnitDatesInference)
        Me.Controls.Add(myDateLabel)
    End Sub



    ' Draws dates in a enabled state
    Private Sub DrawTextFields()
        myUnitDateInitial = New VisualDateField
        myUnitDateFinal = New VisualDateField
        myUnitDateInitialCertainty = New VisualCheckField(VisualFieldLabel("ca"))
        myUnitDateFinalCertainty = New VisualCheckField(VisualFieldLabel("ca"))

        myAllowUnitDatesInference = New VisualCheckField(VisualFieldLabel("AllowUnitDatesInference"))



        With myUnitDateInitialCertainty
            .Location = New Point(myLabel.Location.X + myLabel.Width + VisualTextField.DefaultLabelTextBoxGap, CenterTop)
            .Value = Not LazyNode.UnitDateInitialCertainty
            '.Enabled = EnableControls
        End With

        With myUnitDateInitial
            .Location = New Point(myUnitDateInitialCertainty.Location.X + myUnitDateInitialCertainty.Width + VisualTextField.DefaultLabelTextBoxGap, 0)
            .Value = LazyNode.UnitDateInitial
            '.AllowEdit = EnableControls
        End With

        Dim mySeparator As New Label

        With mySeparator
            .Text = VisualFieldLabel("to")
            .AutoSize = True
            .Location = New Point(myUnitDateInitial.Location.X + myUnitDateInitial.Width + VisualTextField.DefaultLabelTextBoxGap, CenterTop)
        End With


        With myUnitDateFinalCertainty
            .Text = VisualFieldLabel("ca")
            .Location = New Point(mySeparator.Location.X + mySeparator.Width + VisualTextField.DefaultLabelTextBoxGap, CenterTop)
            .Value = Not LazyNode.UnitDateFinalCertainty
            '.Enabled = EnableControls
        End With

        With myUnitDateFinal
            .Location = New Point(myUnitDateFinalCertainty.Location.X + myUnitDateFinalCertainty.Width + VisualTextField.DefaultLabelTextBoxGap, 0)
            .Value = LazyNode.UnitDateFinal
        End With

        With myAllowUnitDatesInference
            .Text = VisualFieldLabel("AllowUnitDatesInference")
            .Location = New Point(myUnitDateFinal.Location.X + myUnitDateFinal.Width + VisualTextField.DefaultLabelTextBoxGap, CenterTop)
            .Value = LazyNode.AllowUnitDatesInference
        End With

        Me.Controls.Add(myLabel)
        Me.Controls.Add(myUnitDateInitialCertainty)
        Me.Controls.Add(myUnitDateInitial)
        Me.Controls.Add(mySeparator)
        Me.Controls.Add(myUnitDateFinalCertainty)
        Me.Controls.Add(myUnitDateFinal)
        If (Not LazyNode.isLeaf) Then
            Me.Controls.Add(myAllowUnitDatesInference)
        End If

    End Sub

    Private Function FormatExtremeDates(ByVal LazyNode As LazyNode)
        Dim ret As String = ""
        Dim ValidInitialDate As Boolean = False
        Dim ValidFinalDate As Boolean = False

        If Validator.IsValidDate(LazyNode.UnitDateInitial) Then
            If Not LazyNode.UnitDateInitialCertainty Then ret &= VisualFieldLabel("ca")
            ret &= LazyNode.UnitDateInitial
            ValidInitialDate = True
        End If

        If Validator.IsValidDate(LazyNode.UnitDateFinal) Then
            If ValidInitialDate Then ret &= " " & VisualFieldLabel("to") & " "
            If Not LazyNode.UnitDateFinalCertainty Then ret &= VisualFieldLabel("ca")
            ret &= LazyNode.UnitDateFinal
            ValidFinalDate = True
        End If

        If (ValidFinalDate Or ValidInitialDate) Then
            Return ret
        Else
            Return VisualFieldLabel("UndefinedExtremeDates")
        End If
    End Function


    ' handle events
    Protected Sub UploadUnitDateInitial(ByVal EventCode As Integer, ByVal Value As Object) Handles myUnitDateInitial.ValueChanged
        LazyNode.UnitDateInitial = CStr(Value)
        RaiseEventDataChanged(Me, Value)
    End Sub

    Protected Sub UploadUnitDateFinal(ByVal EventCode As Integer, ByVal Value As Object) Handles myUnitDateFinal.ValueChanged
        LazyNode.UnitDateFinal = CStr(Value)
        RaiseEventDataChanged(Me, Value)
    End Sub


    Protected Sub UploadUnitDateInitialCertainty(ByVal EventCode As Integer, ByVal Value As Object) Handles myUnitDateInitialCertainty.ValueChanged
        LazyNode.UnitDateInitialCertainty = Not CBool(Value)
        RaiseEventDataChanged(Me, LazyNode.UnitDateInitialCertainty)
    End Sub

    Protected Sub UploadUnitDateFinalCertainty(ByVal EventCode As Integer, ByVal Value As Object) Handles myUnitDateFinalCertainty.ValueChanged
        LazyNode.UnitDateFinalCertainty = Not CBool(Value)
        RaiseEventDataChanged(Me, LazyNode.UnitDateFinalCertainty)
    End Sub

    Protected Sub UploadUnitDateBulk(ByVal EventCode As Integer, ByVal Value As Object) Handles myUnitDateBulk.ValueChanged
        LazyNode.UnitDateBulk = CStr(Value)
        RaiseEventDataChanged(Me, Value)
    End Sub


    Protected Sub UploadAllowUnitDatesInference(ByVal EventCode As Integer, ByVal Value As Object) Handles myAllowUnitDatesInference.ValueChanged
        LazyNode.AllowUnitDatesInference = CBool(Value)
        RaiseEvent InferenceButtonClicked()
        RaiseEventDataChanged(Me, LazyNode.AllowUnitDatesInference)
    End Sub

End Class

