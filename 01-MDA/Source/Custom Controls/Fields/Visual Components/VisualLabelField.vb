
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
