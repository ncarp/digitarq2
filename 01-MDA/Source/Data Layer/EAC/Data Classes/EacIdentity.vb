
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

Public Class EacIdentity
    Inherits CollectionBase


    Public Function Add(ByVal Part As String, ByVal UseDate As String, ByVal Type As String) As Integer
        Return List.Add(New EacIdentityItem(Part, UseDate, Type))
    End Function


    Public Function Add(ByVal ID As Integer, ByVal Part As String, ByVal UseDate As String, ByVal Type As String) As Integer
        Return List.Add(New EacIdentityItem(ID, Part, UseDate, Type))
    End Function


    Public Sub Remove(ByVal Item As EacIdentityItem)
        List.Remove(Item)
    End Sub

    Public Function Item(ByVal index As Integer) As EacIdentityItem
        Return List.Item(index)
    End Function

    Private Function TypeToEac(ByVal Type As String) As String
        Select Case Type
            Case VisualFieldLabel("Authorities.AlternativeName") : Return "alternative"
            Case VisualFieldLabel("Authorities.OtherFormName") : Return "otherform"
            Case Else : Return ""
        End Select
    End Function



    Public Function toXml(ByVal TypePrefix As String) As String
        If Count = 0 Then Return ""

        Dim xml As String = ""
        For i As Integer = 0 To Count - 1
            xml &= String.Format("<{2}head><part type='{3}'>{0}</part><usedate>{1}</usedate></{2}head>", Item(i).Part, Item(i).UseDate, TypePrefix, TypeToEac(Item(i).Type))
        Next
        Return xml
    End Function

End Class



Public Class EacIdentityItem
    Private myID As Integer
    Private myUseDate As String
    Private myPart As String
    Private myType As String


    Public Sub New(ByVal Part As String, ByVal UseDate As String, ByVal Type As String)
        myUseDate = UseDate
        myPart = Part
        myType = Type
        myID = 0
    End Sub

    Public Sub New(ByVal ID As Integer, ByVal Part As String, ByVal UseDate As String, ByVal Type As String)
        myUseDate = UseDate
        myPart = Part
        myType = Type
        myID = ID
    End Sub


    Public Sub New(ByVal ID As Integer)
        myID = ID
    End Sub

    Property Type() As String
        Get
            Return myType
        End Get
        Set(ByVal Value As String)
            myType = Value
        End Set
    End Property


    Property UseDate() As String
        Get
            Return myUseDate
        End Get
        Set(ByVal Value As String)
            myUseDate = Value
        End Set
    End Property

    Property Part() As String
        Get
            Return myPart
        End Get
        Set(ByVal Value As String)
            myPart = Value
        End Set
    End Property

    Property ID() As Integer
        Get
            Return myID
        End Get
        Set(ByVal Value As Integer)
            myID = Value
        End Set
    End Property


    Public Function Clone() As Object
        Return New EacIdentityItem(myID, myPart, myUseDate, myType)
    End Function


    Public Overloads Overrides Function Equals(ByVal obj As Object) As Boolean
        If Not TypeOf obj Is EacIdentityItem Then
            Return False
        Else
            Return ID = CType(obj, EacIdentityItem).ID
        End If
    End Function

End Class