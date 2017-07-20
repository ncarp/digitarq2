
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

Public Class VisualFieldOtherLevel
    Inherits VisualField


#Region "Private Properties"

    Private myLabel As Label
    Private WithEvents myOtherLevel As VisualComboBoxImageField

#End Region


    Public Sub New(ByVal LazyNode As LazyNode, ByVal OtherLevelIcons As ImageList, ByVal TopOtherLevelIndex As Integer, ByVal BottonOtherLevelIndex As Integer)
        Me.LazyNode = LazyNode

        myLabel = New Label
        With myLabel
            .Width = VisualTextField.DefaultLabelWidth
            .Text = VisualFieldLabel("OtherLevel")
            .Location = New Point(0, 0)
            .ForeColor = VisualField.MandatoryForeColor
        End With




        ' Create items to pass to the combo box
        Debug.WriteLine(BottonOtherLevelIndex & "-" & TopOtherLevelIndex)
        If (BottonOtherLevelIndex - TopOtherLevelIndex) < 0 Then Exit Sub

        Dim Items(BottonOtherLevelIndex - TopOtherLevelIndex) As ComboBoxImageItem
        Dim i As Integer
        Dim index As Integer = 0
        Dim SelectItem As ComboBoxImageItem
        For i = TopOtherLevelIndex To BottonOtherLevelIndex
            Dim OtherLevel = OtherLevelIndexToOtherLevel(i)
            Items(index) = New ComboBoxImageItem(VisualFieldLabel(OtherLevel), OtherLevel, i)
            If OtherLevel = LazyNode.OtherLevel Then SelectItem = Items(index)
            index += 1
        Next

        myOtherLevel = New VisualComboBoxImageField(OtherLevelIcons, Items)

        With myOtherLevel
            .Location = New Point(myLabel.Location.X + myLabel.Width + VisualTextField.DefaultLabelTextBoxGap, 0)
            .Value = SelectItem
        End With


        Me.Size = New Size(myOtherLevel.Location.X + myOtherLevel.Width, myOtherLevel.Height)
        Me.Controls.Add(myLabel)
        Me.Controls.Add(myOtherLevel)
    End Sub





    Public Sub Upload(ByVal EventCode As Integer, ByVal Value As Object) Handles myOtherLevel.ValueChanged
        LazyNode.OtherLevel = CType(Value, ComboBoxImageItem).Value
        RaiseEventDataChanged(Me, Value)
    End Sub



End Class


