
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

Public Class VisualFieldProcessInfo
    Inherits VisualField


#Region "Private Properties"
    Private WithEvents myName As VisualTextField
    Private WithEvents myDate As VisualDateField
    Private WithEvents myProcessInfo As VisualTextField
    Private WithEvents myDescRules As VisualTextField

#End Region


#Region "Constants"
    Private Const DefaultTextBoxHeight As Integer = 20
    Private Const DefaultLabelWidth As Integer = 100
    Private Const DefaultTextBoxGap As Integer = 25
    Private Const DefaultSeparatorHeight As Integer = 10
#End Region


    Public Sub New(ByVal LazyNode As LazyNode)
        Me.LazyNode = LazyNode

        myName = New VisualTextField(VisualFieldLabel("ProcessInfoName"), VisualTextField.DefaultLabelWidth, VisualTextField.TextBoxWidthMedium, ValidTextBox.FieldTypes.DefaultField)
        myDate = New VisualDateField
        myProcessInfo = New VisualTextField(VisualFieldLabel("ProcessInfo"), VisualTextField.TextBoxWidthExtraLarge, VisualTextField.TextBoxHeightMedium)
        myDescRules = New VisualTextField(VisualFieldLabel("DescRules"), VisualTextField.TextBoxWidthExtraLarge, VisualTextField.TextBoxHeightMedium)


        With myName
            .Location = New Point(0, 0)
            .Value = CStr(LazyNode.ProcessInfoName)
            .AllowEdit = False
            .Mandatory = True
        End With

        With myDate
            .Location = New Point(myName.Location.X + myName.Width + DefaultTextBoxGap, 0)
            .Value = CStr(LazyNode.ProcessInfoDate)
            .AllowEdit = False
        End With

        With myProcessInfo
            .Location = New Point(myName.Location.X, myName.Location.Y + myName.Height + DefaultSeparatorHeight)
            .Value = CStr(LazyNode.ProcessInfo)
            .AllowEdit = True
            .Mandatory = False
        End With

        With myDescRules
            .Location = New Point(myName.Location.X, myProcessInfo.Location.Y + myProcessInfo.Height + DefaultSeparatorHeight)
            .Value = CStr(LazyNode.DescRules)
            .AllowEdit = True
            .Mandatory = False
        End With

        Me.Size = New Size(myProcessInfo.Width, myName.Height + myProcessInfo.Height + myDescRules.Height + 2 * DefaultSeparatorHeight)

        Me.Controls.Add(myName)
        Me.Controls.Add(myDate)
        Me.Controls.Add(myProcessInfo)
        Me.Controls.Add(myDescRules)
    End Sub


    Protected Sub UploadName(ByVal EventCode As Integer, ByVal Value As Object) Handles myName.ValueChanged
        LazyNode.ProcessInfoName = CStr(Value)
        RaiseEventDataChanged(Me, Value)
    End Sub

    Protected Sub UploadDate(ByVal EventCode As Integer, ByVal Value As Object) Handles myDate.ValueChanged
        LazyNode.ProcessInfoDate = CStr(Value)
        RaiseEventDataChanged(Me, Value)
    End Sub

    Protected Sub UploadProcessInfo(ByVal EventCode As Integer, ByVal Value As Object) Handles myProcessInfo.ValueChanged
        LazyNode.ProcessInfo = CStr(Value)
        RaiseEventDataChanged(Me, Value)
    End Sub

    Protected Sub UploadDescRules(ByVal EventCode As Integer, ByVal Value As Object) Handles myDescRules.ValueChanged
        LazyNode.DescRules = CStr(Value)
        RaiseEventDataChanged(Me, Value)
    End Sub


End Class

