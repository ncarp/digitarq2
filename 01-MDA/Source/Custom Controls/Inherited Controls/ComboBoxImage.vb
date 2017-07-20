
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
