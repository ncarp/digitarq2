
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

Public Class MaskedBox
    Inherits System.Windows.Forms.TextBox

    Private aMskMask() As Char
    Private aMask() As Char
    Private tmpMask As String
    Private a As Integer

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'MaskedBox
        '
        Me.Name = "MaskedBox"

    End Sub

#End Region

    Public Property Mask() As String

        Get
            Return tmpMask
        End Get

        Set(ByVal Value As String)
            tmpMask = Value
            SetMask()
        End Set

    End Property

    Private Sub SetMask()

        On Error Resume Next

        Me.Text = tmpMask
        Me.Text = Me.Text.Replace("#", "_")
        Me.Text = Me.Text.Replace("&", "_")

        ReDim aMask(Me.Text.Length - 1)
        ReDim aMskMask(Me.Text.Length - 1)

        For a = 0 To tmpMask.Length - 1
            If tmpMask.Substring(a, 1) = "#" Or tmpMask.Substring(a, 1) = "&" Then
                aMask.SetValue(CType("_", Char), a)
            Else
                aMask.SetValue(CType(tmpMask.Substring(a, 1), Char), a)
            End If
        Next

        For a = 0 To tmpMask.Length - 1
            aMskMask.SetValue(CType(tmpMask.Substring(a, 1), Char), a)
        Next

    End Sub

    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim tmpset = Me.SelectionStart

        On Error Resume Next

        Select Case e.KeyCode
            Case Keys.Delete
                Me.Text = ""
                For a = tmpset To aMask.Length - 1
                    Select Case aMskMask.GetValue(a + 1)
                        Case ".", "-", "\", "/", ","
                            aMask.SetValue(aMask.GetValue(a + 2), a)
                            a = a + 1
                        Case Else
                            aMask.SetValue(aMask.GetValue(a + 1), a)
                    End Select
                Next

                aMask.SetValue(CType("_", Char), aMask.Length - 1)

                e.Handled = True

                Me.Text = ""
                For a = 0 To aMask.Length - 1
                    Me.Text += aMask.GetValue(a)
                Next
                Me.SelectionStart = tmpset

        End Select

    End Sub

    Protected Overrides Sub OnKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)
        e.Handled = True
    End Sub

    Protected Overrides Sub OnKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim tmpset = Me.SelectionStart
        Dim tmpCH As Char

        On Error Resume Next

        If Asc(e.KeyChar) = 8 Then
            Select Case CType(aMskMask.GetValue(tmpset - 1), String)
                Case ".", "-", "\", "/", ","
                    tmpset = tmpset - 2
                    aMask.SetValue(CType("_", Char), tmpset)
                    tmpset = tmpset - 1
                Case Else
                    tmpset = tmpset - 1
                    aMask.SetValue(CType("_", Char), tmpset)
                    tmpset = tmpset - 1
            End Select

            e.Handled = True

            Me.Text = ""
            For a = 0 To aMask.Length - 1
                Me.Text += aMask.GetValue(a)
            Next
            Me.SelectionStart = tmpset + 1

        ElseIf Char.IsControl(e.KeyChar) Then

        Else
            Select Case aMskMask.GetValue(tmpset)
                Case ".", "-", "\", "/", ","
                    tmpset = tmpset + 1
                    If aMskMask.GetValue(tmpset) = "#" Then
                        If Char.IsDigit(e.KeyChar) Then
                            aMask.SetValue(e.KeyChar, tmpset)
                        Else
                            tmpset = tmpset - 1
                        End If
                    ElseIf aMskMask.GetValue(tmpset) = "&" Then
                        aMask.SetValue(e.KeyChar, tmpset)
                    End If

                Case Else
                    If aMskMask.GetValue(tmpset) = "#" Then
                        If Char.IsDigit(e.KeyChar) Then
                            aMask.SetValue(e.KeyChar, tmpset)
                        Else
                            tmpset = tmpset - 1
                        End If
                    ElseIf aMskMask.GetValue(tmpset) = "&" Then
                        aMask.SetValue(e.KeyChar, tmpset)
                    End If

            End Select

            e.Handled = True

            Me.Text = ""
            For a = 0 To aMask.Length - 1
                Me.Text += aMask.GetValue(a)
            Next
            Me.SelectionStart = tmpset + 1

        End If
    End Sub

    Public Sub SetText(ByVal txt As String)

        On Error Resume Next

        If txt = "" Then
            For a = 0 To tmpMask.Length - 1
                If tmpMask.Substring(a, 1) = "#" Or tmpMask.Substring(a, 1) = "&" Then
                    aMask.SetValue(CType("_", Char), a)
                Else
                    aMask.SetValue(CType(tmpMask.Substring(a, 1), Char), a)
                End If
            Next
        Else
            For a = 0 To txt.Length - 1
                If tmpMask.Substring(a, 1) = "#" Or tmpMask.Substring(a, 1) = "&" Then
                    aMask.SetValue(CType(txt.Substring(a, 1), Char), a)
                Else
                    aMask.SetValue(CType(tmpMask.Substring(a, 1), Char), a)
                End If
            Next

        End If

        Me.Text = ""
        For a = 0 To aMask.Length - 1
            Me.Text += aMask.GetValue(a)
        Next

    End Sub

End Class
