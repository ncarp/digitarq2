
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

Public Class ComboBoxImage
    Inherits ComboBox

    Private myImageList As ImageList


    Sub New()
        MyBase.new()
        DrawMode = DrawMode.OwnerDrawFixed
        DropDownStyle = ComboBoxStyle.DropDownList
        ImageList = Nothing
        MaxDropDownItems = 12
        Size = New Size(120, 20)
    End Sub


    Property ImageList() As ImageList
        Get
            Return myImageList
        End Get
        Set(ByVal Value As ImageList)
            myImageList = Value
        End Set
    End Property



    Protected Overrides Sub onDrawItem(ByVal ea As DrawItemEventArgs)
        ea.DrawBackground()
        ea.DrawFocusRectangle()
        Dim item As ComboBoxImageItem

        Dim imageSize As Size = New Size(0, 0)
        If Not ImageList Is Nothing Then
            imageSize = ImageList.ImageSize()
        End If


        Dim bounds As Rectangle = ea.Bounds
        Try
            item = CType(Items(ea.Index), ComboBoxImageItem)
            If (item.ImageIndex <> -1) Then
                ImageList.Draw(ea.Graphics, bounds.Left, bounds.Top, item.ImageIndex)
                ea.Graphics.DrawString(item.Label, ea.Font, New SolidBrush(ea.ForeColor), bounds.Left + imageSize.Width, bounds.Top)
            Else
                ea.Graphics.DrawString(item.Label, ea.Font, New SolidBrush(ea.ForeColor), bounds.Left, bounds.Top)
            End If
        Catch
            If (ea.Index <> -1) Then
                ea.Graphics.DrawString(Items(ea.Index).ToString(), ea.Font, New SolidBrush(ea.ForeColor), bounds.Left, bounds.Top)
            Else
                ea.Graphics.DrawString(Text, ea.Font, New SolidBrush(ea.ForeColor), bounds.Left, bounds.Top)
            End If
        End Try
        MyBase.OnDrawItem(ea)
    End Sub


    Public Function getValueIndex(ByVal value As String) As Integer
        Dim item As ComboBoxImageItem
        Dim index As Integer = 0
        Dim result As Integer = -1
        For Each item In Items
            If (item.Value() = value) Then
                result = index
                Exit For
            End If
            index += 1
        Next

        Return result
    End Function


    Public Function getLabelIndex(ByVal value As String) As Integer
        Dim item As ComboBoxImageItem
        Dim index As Integer = 0
        Dim result As Integer = -1
        For Each item In Items
            If (item.Label() = value) Then
                result = index
                Exit For
            End If
            index += 1
        Next

        Return result
    End Function



    Public Shadows Property SelectedValue() As String
        Get
            Return CType(SelectedItem, ComboBoxImageItem).Value
        End Get
        Set(ByVal Value As String)
            Me.SelectedIndex = getValueIndex(Value)
        End Set
    End Property


    Public Shadows Property SelectedText() As String
        Get
            Return CType(SelectedItem, ComboBoxImageItem).Label
        End Get
        Set(ByVal Value As String)
            Me.SelectedIndex = getLabelIndex(Value)
        End Set
    End Property


End Class


Public Class ComboBoxImageItem
    Private myLabel As String
    Private myValue As String
    Private myImageIndex As Integer



    Public Property Value() As String
        Get
            Return myValue
        End Get
        Set(ByVal Value As String)
            myValue = Value
        End Set
    End Property

    Public Property Label() As String
        Get
            Return myLabel
        End Get
        Set(ByVal Value As String)
            myLabel = Value
        End Set
    End Property



    Property ImageIndex() As Integer
        Get
            Return myImageIndex
        End Get
        Set(ByVal Value As Integer)
            myImageIndex = Value
        End Set
    End Property

    Public Sub New(ByVal text As String, Optional ByVal value As String = Nothing, Optional ByVal imageIndex As Integer = -1)
        myLabel = text
        myImageIndex = imageIndex
        myValue = value
    End Sub

    Public Overrides Function ToString() As String
        Return Label
    End Function
End Class
