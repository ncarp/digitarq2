
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
