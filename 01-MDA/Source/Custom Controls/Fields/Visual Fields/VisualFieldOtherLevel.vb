
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


