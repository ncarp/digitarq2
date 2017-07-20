
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

Imports System.Text.RegularExpressions
Imports System.ComponentModel


Public Class ValidTextBox
    Inherits TextBox

    Private myFieldType As FieldTypes
    Private myAllowErrorMessage As Boolean
    Private myErrorMessageArguments As Collection

    Public Enum FieldTypes As Integer
        DefaultField
        DateField
        FondsReferenceField
        ReferenceField
        NotEmptyField
        FloatField
        IntegerField
    End Enum


    Public Sub New()
        MyBase.New()
        myFieldType = FieldTypes.NotEmptyField
        myAllowErrorMessage = True
        myErrorMessageArguments = New Collection
    End Sub



    Public Property ErrorMessageArguments() As Collection
        Get
            Return myErrorMessageArguments
        End Get
        Set(ByVal Value As Collection)
            myErrorMessageArguments = Value
        End Set
    End Property



    Public Property AllowErrorMessage() As Boolean
        Get
            Return myAllowErrorMessage
        End Get
        Set(ByVal Value As Boolean)
            myAllowErrorMessage = Value
        End Set
    End Property



    Public Property FieldType() As FieldTypes
        Get
            Return myFieldType
        End Get
        Set(ByVal Value As FieldTypes)
            myFieldType = Value
            If (myFieldType = FieldTypes.IntegerField Or myFieldType = FieldTypes.FloatField) Then
                Me.RightToLeft = RightToLeft.Yes
            Else
                Me.RightToLeft = RightToLeft.No
            End If


        End Set
    End Property



    Protected Overrides Sub OnValidating(ByVal e As CancelEventArgs)
        If isValid() Then
            Me.ForeColor = Color.Black
            MyBase.OnValidating(e) ' move on 
        ElseIf ContinueAnyway() Then
            Me.ForeColor = Color.Red
            MyBase.OnValidating(e) ' move on 
        Else
            Me.ForeColor = Color.Red
            e.Cancel = True
        End If
    End Sub



    Public Function isValid() As Boolean
        Select Case FieldType
            Case FieldTypes.DefaultField : Return True
            Case FieldTypes.DateField : Return Validator.IsValidDate(Text)
            Case FieldTypes.FondsReferenceField : Return Validator.IsFondsReference(Text)
            Case FieldTypes.NotEmptyField : Return Validator.IsNotEmpty(Text)
            Case FieldTypes.IntegerField : Return Validator.IsInteger(Text)
            Case FieldTypes.FloatField : Return Validator.IsFloat(Text)
            Case FieldTypes.ReferenceField : Return Validator.IsNotEmpty(Text)
        End Select
    End Function


    Private Function ContinueAnyway()
        If Not myAllowErrorMessage Then Return True
        Select Case FieldType
            Case FieldTypes.DateField : Return ShowErrorMessage(ErrorMessage("NotValidDate"))
            Case FieldTypes.FondsReferenceField : Return ShowErrorMessage(ErrorMessage("NotFondsReference"))
            Case FieldTypes.NotEmptyField : Return ShowErrorMessage(ErrorMessage("EmptyField"))
            Case FieldTypes.IntegerField : Return ShowErrorMessage(ErrorMessage("NotInteger"))
            Case FieldTypes.FloatField : Return ShowErrorMessage(ErrorMessage("NotFloat"))
            Case FieldTypes.ReferenceField : Return ShowErrorMessage(ErrorMessage("EmptyField"))
        End Select
    End Function



    Public Function ShowErrorMessage(ByVal Message As String) As Boolean
        Return DialogResult.Yes = MessageBox.Show(Message, ErrorMessage("ShowErrorMessage.Title"), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
    End Function


    Private Sub ValidTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
        Me.BackColor = Color.FromArgb(255, 255, 210)
        Me.SelectAll()
    End Sub


    Private Sub ValidTextBox_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Leave
        BackColor = Color.White
    End Sub

End Class
