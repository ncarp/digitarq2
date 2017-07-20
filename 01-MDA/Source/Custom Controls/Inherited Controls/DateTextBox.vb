
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

Public Class DateTextBox
    Inherits MaskedBox.MaskedBox


    Sub New()
        MyBase.New()
        Me.Width = 60
        Me.Height = 20
        Me.MaxLength = 10
        Me.Mask = "####-##-##"
        Me.BorderStyle = BorderStyle.FixedSingle
        Me.Text = ""
    End Sub

    Private Sub DateTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
        Me.BackColor = Color.FromArgb(255, 255, 210)
        'Me.SelectAll()
    End Sub

    Private Sub DateTextBox_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Leave
        BackColor = Color.White
    End Sub


    Public Shadows Property Text() As String
        Get
            If MyBase.Text.Replace("_", "") = "--" Then
                Return ""
            Else
                Return MyBase.Text
            End If
        End Get
        Set(ByVal Value As String)
            SetText(Value)
        End Set
    End Property


End Class


'Public Class DateTextBox
'    Inherits ValidTextBox

'    Private Format As String


'    Sub New()
'        MyBase.New()
'        MyBase.FieldType = ValidTextBox.FieldTypes.DefaultField
'        Me.ContextMenu = New ContextMenu
'        Format = "dddd-dd-dd"
'        Me.Width = 60
'        Me.Height = 20
'        Me.MaxLength = Format.Length
'        InitializeText()
'    End Sub




'    Public Overrides Property Text() As String
'        Get
'            Dim str As String = MyBase.Text.Replace("_", "")
'            If str = "--" Then
'                Return ""
'            Else
'                Return MyBase.Text.Replace("_", "0")
'            End If
'        End Get
'        Set(ByVal Value As String)
'            If Validator.IsValidDate(Value) Then
'                Try
'                    Dim ParsedDate As String() = Value.Split("-")
'                    MyBase.Text = ParsedDate(0).PadLeft(4, "_") & "-" & ParsedDate(1).PadLeft(2, "_") & "-" & ParsedDate(2).PadLeft(2, "_")
'                Catch ex As Exception
'                    InitializeText()
'                End Try
'            Else
'                InitializeText()
'            End If
'        End Set
'    End Property


'    Private Sub InitializeText()
'        Dim i As Integer
'        Dim tmpText As String = ""

'        For i = 0 To Format.Length - 1
'            If Format.Chars(i) Like "d" Then
'                tmpText &= "_"
'            Else
'                tmpText &= Format.Chars(i)
'            End If
'        Next
'        MyBase.Text = tmpText
'    End Sub






'    Private Sub DateTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress

'        If Me.ReadOnly Then Exit Sub

'        Dim Position As Integer = SelectionStart
'        Dim PreviousText As String
'        Dim NextText As String

'        Debug.WriteLine(e.KeyChar & " on position " & Position)
'        Try
'            Select Case e.KeyChar
'                Case "0" To "9"
'                    If Position >= Format.Length Then
'                        Debug.WriteLine("Reached the end")
'                        Exit Sub
'                    ElseIf Format.Chars(Position) <> "d" Then
'                        If Position + 1 < Format.Length Then
'                            SelectionStart += 1
'                            DateTextBox_KeyPress(Me, e)
'                        Else
'                            Exit Sub
'                        End If
'                    Else
'                        PreviousText = MyBase.Text.Substring(0, Position)
'                        NextText = MyBase.Text.Substring(Position + 1, MyBase.Text.Length - Position - 1)
'                        MyBase.Text = PreviousText & e.KeyChar & NextText

'                        If Position + 1 < Format.Length AndAlso Format.Chars(Position + 1) = "d" Then
'                            SelectionStart = Position + 1
'                        ElseIf Position + 2 < Format.Length AndAlso Format.Chars(Position + 2) = "d" Then
'                            SelectionStart = Position + 2
'                        Else
'                            Exit Sub
'                        End If
'                    End If
'                    If MyBase.Text.Length <> Format.Length Then InitializeText()
'                Case ControlChars.Back
'                        If Position > 0 Then
'                            Position -= 1
'                            If Format.Chars(Position) = "d" Then
'                                PreviousText = MyBase.Text.Substring(0, Position)
'                                NextText = MyBase.Text.Substring(Position + 1, MyBase.Text.Length - Position - 1)
'                                MyBase.Text = PreviousText & "_" & NextText
'                            End If
'                            SelectionStart = Position
'                        End If
'            End Select
'        Catch ex As Exception
'            MsgBox(ex.Message & Chr(13) & ex.StackTrace)

'        End Try

'        e.Handled = True
'    End Sub



'    'Private Sub DateTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
'    '    If Me.ReadOnly Then Exit Sub

'    '    If e.KeyCode = Keys.Delete Then
'    '        If SelectionStart >= 0 AndAlso SelectionStart < Format.Length Then
'    '            SelectionStart += 1
'    '            DateTextBox_KeyPress(Me, New KeyPressEventArgs(ControlChars.Back))
'    '        End If
'    '        e.Handled = True
'    '    ElseIf e.KeyCode = Keys.ControlKey + Keys.V Then
'    '        e.Handled = True
'    '    End If
'    'End Sub



'    Private Sub DateTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
'        If Me.ReadOnly Then Exit Sub
'        Me.SelectionStart = 0
'        Me.SelectionLength = 0
'    End Sub



'    Private Sub DateTextBox_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
'        If Me.ReadOnly Then Exit Sub

'        If e.Button = MouseButtons.Left Then
'            Me.SelectionStart = 0
'            Me.SelectionLength = 0
'        End If
'    End Sub
'End Class

