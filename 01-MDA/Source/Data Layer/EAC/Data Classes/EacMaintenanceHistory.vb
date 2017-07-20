
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

Public Class EacMaintenanceHistory
    Inherits CollectionBase


    Public Function Add(ByVal Type As String, ByVal Name As String, ByVal DateStr As String, ByVal Description As String) As Integer
        Return List.Add(New EacMaintenanceHistoryItem(Type, Name, DateStr, Description))
    End Function


    Public Function Add(ByVal ID As Integer, ByVal Type As String, ByVal Name As String, ByVal DateStr As String, ByVal Description As String) As Integer
        Return List.Add(New EacMaintenanceHistoryItem(ID, Type, Name, DateStr, Description))
    End Function


    Public Sub Remove(ByVal Item As EacMaintenanceHistoryItem)
        List.Remove(Item)
    End Sub

    Public Function Item(ByVal index As Integer) As EacMaintenanceHistoryItem
        Return List.Item(index)
    End Function



    Public Function toXml() As String
        If Count = 0 Then Return ""

        Dim xml As String = "<mainhist>"
        For i As Integer = 0 To Count - 1
            xml &= String.Format("<mainevent maintype='{0}'><name>{1}</name><maindate>{2}</maindate><maindesc>{3}</maindesc></mainevent>", TypeToEac(Item(i).Type), Item(i).Name, Item(i).DateStr, Item(i).Description)
        Next
        xml &= "</mainhist>"
        Return xml
    End Function


    Private Function TypeToEac(ByVal Type As String) As String
        Select Case Type
            Case (VisualFieldLabel("Authorities.Create")) : Return "create"
            Case (VisualFieldLabel("Authorities.Delete")) : Return "delete"
            Case (VisualFieldLabel("Authorities.Update")) : Return "update"
            Case (VisualFieldLabel("Authorities.Import")) : Return "import"
            Case Else : Return ""
        End Select
    End Function


End Class



Public Class EacMaintenanceHistoryItem
    Private myID As Integer
    Private myType As String
    Private myName As String
    Private myDate As String
    Private myDescription As String


    Public Sub New(ByVal ID As Integer)
        myID = ID
    End Sub

    Public Sub New(ByVal Type As String, ByVal Name As String, ByVal DateStr As String, ByVal Description As String)
        myID = 0
        myType = Type
        myName = Name
        myDate = DateStr
        myDescription = Description
    End Sub


    Public Sub New(ByVal ID As Integer, ByVal Type As String, ByVal Name As String, ByVal DateStr As String, ByVal Description As String)
        myID = ID
        myType = Type
        myName = Name
        myDate = DateStr
        myDescription = Description
    End Sub

    Public Property ID() As Integer
        Get
            Return myID
        End Get
        Set(ByVal Value As Integer)
            myID = Value
        End Set
    End Property

    Public Property Type() As String
        Get
            Return myType
        End Get
        Set(ByVal Value As String)
            myType = Value
        End Set
    End Property


    Public Property Name() As String
        Get
            Return myName
        End Get
        Set(ByVal Value As String)
            myName = Value
        End Set
    End Property


    Public Property DateStr() As String
        Get
            Return myDate
        End Get
        Set(ByVal Value As String)
            myDate = Value
        End Set
    End Property


    Public Property Description() As String
        Get
            Return myDescription
        End Get
        Set(ByVal Value As String)
            myDescription = Value
        End Set
    End Property

    Public Function Clone() As Object
        Return New EacMaintenanceHistoryItem(myID, myType, myName, myDate, myDescription)
    End Function


    Public Overloads Overrides Function Equals(ByVal obj As Object) As Boolean
        If Not TypeOf obj Is EacMaintenanceHistoryItem Then
            Return False
        Else
            Return ID = CType(obj, EacMaintenanceHistoryItem).ID
        End If
    End Function


End Class