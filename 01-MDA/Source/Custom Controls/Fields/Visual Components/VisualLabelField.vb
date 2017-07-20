
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

Public Class VisualLabelField
    Inherits Panel
    Implements VisualComponent


#Region "Properties and Events"

    Private myLabel As Label
    Private WithEvents myTextLabel As Label
    Private myMandatory As Boolean

    Private myToolTip As ToolTip
    Public Event ValueChanged(ByVal EventCode As Integer, ByVal Value As Object) Implements VisualComponent.ValueChanged

#End Region

#Region "Constants"
    Public Const DefaultTextBoxHeight As Integer = 15
    Public Const DefaultLabelWidth As Integer = 120
    Public Const DefaultLabelTextBoxGap As Integer = 5

    Public Const TextBoxWidthExtraSmall = 50
    Public Const TextBoxWidthSmall = 100
    Public Const TextBoxWidthMedium = 200
    Public Const TextBoxWidthLarge = 300
    Public Const TextBoxWidthExtraLarge = 360

    Public Const TextBoxHeightSmall = 1
    Public Const TextBoxHeightMedium = 5
    Public Const TextBoxHeightLarge = 20


#End Region


    Public Sub New(ByVal Label As String, ByVal Length As Integer, ByVal Lines As Integer)
        Me.New(Label, DefaultLabelWidth, Length, Lines, ValidTextBox.FieldTypes.DefaultField)
    End Sub

    Public Sub New(ByVal Label As String, ByVal Length As Integer, ByVal ValidationType As ValidTextBox.FieldTypes)
        Me.New(Label, DefaultLabelWidth, Length, 1, ValidationType)
    End Sub


    Public Sub New(ByVal Label As String, ByVal Length As Integer)
        Me.New(Label, DefaultLabelWidth, Length, 1, ValidTextBox.FieldTypes.DefaultField)
    End Sub



    Public Sub New(ByVal Label As String, ByVal LabelWidth As Integer, _
                   ByVal Length As Integer, _
                   ByVal ValidationType As ValidTextBox.FieldTypes)
        Me.New(Label, LabelWidth, Length, 1, ValidationType)
    End Sub





    Public Sub New(ByVal Label As String, ByVal LabelWidth As Integer, _
                   ByVal Length As Integer, ByVal Lines As Integer, _
                   ByVal ValidationType As ValidTextBox.FieldTypes)
        ' Visual Components
        myLabel = New Label
        myTextLabel = New Label

        myToolTip = New ToolTip

        With myLabel
            .Text = Label
            .Location = New Point(0, 0)
            .Size = New Size(LabelWidth, DefaultTextBoxHeight)
        End With


        With myTextLabel
            If myLabel.Width = 0 Then
                .Location = New Point(0, 0)
            Else
                .Location = New Point(myLabel.Width + DefaultLabelTextBoxGap, 0)
            End If

            .Size = New Size(Length, DefaultTextBoxHeight)

            If (ValidationType = ValidTextBox.FieldTypes.IntegerField Or ValidationType = ValidTextBox.FieldTypes.FloatField) Then
                .TextAlign = ContentAlignment.MiddleRight
            Else
                .TextAlign = ContentAlignment.MiddleLeft
            End If
            '.BorderStyle = BorderStyle.FixedSingle
        End With

        Me.Size = New Size(myTextLabel.Location.X + myTextLabel.Width, myTextLabel.Height)
        Me.Controls.Add(myLabel)
        Me.Controls.Add(myTextLabel)
    End Sub


    Public Property Tip() As String
        Get
            Return myToolTip.GetToolTip(myTextLabel)
        End Get
        Set(ByVal Value As String)
            myToolTip.SetToolTip(myTextLabel, Value)
            myToolTip.SetToolTip(myLabel, Value)
        End Set
    End Property




    Public Property Value() As Object Implements VisualComponent.Value
        Get
            Return myTextLabel.Text
        End Get
        Set(ByVal Value As Object)
            myTextLabel.Text = CStr(Value)
        End Set
    End Property



    Public Property Mandatory() As Boolean
        Get
            Return myMandatory
        End Get
        Set(ByVal Value As Boolean)
            myMandatory = Value

            If myMandatory Then
                myLabel.ForeColor = VisualField.MandatoryForeColor
                'myLabel.Font = New Font(myLabel.Font, FontStyle.Underline)
            Else
                myLabel.ForeColor = System.Drawing.Color.Black
                'myLabel.Font = New Font(myLabel.Font, FontStyle.Regular)
            End If

        End Set
    End Property





End Class
