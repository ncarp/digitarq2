
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

