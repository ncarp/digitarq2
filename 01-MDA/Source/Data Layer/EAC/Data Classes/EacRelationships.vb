
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

Public Class EacRelationships
    Inherits CollectionBase


    Public Function Add(ByVal Type As String, ByVal Name As String, ByVal Place As String, ByVal DateStr As String, ByVal Note As String, ByVal EacType As String) As Integer
        Return List.Add(New EacRelationshipsItem(Type, Name, Place, DateStr, Note, EacType))
    End Function


    Public Function Add(ByVal ID As Integer, ByVal Type As String, ByVal Name As String, ByVal Place As String, ByVal DateStr As String, ByVal Note As String, ByVal EacType As String) As Integer
        Return List.Add(New EacRelationshipsItem(ID, Type, Name, Place, DateStr, Note, EacType))
    End Function


    Public Sub Remove(ByVal Item As EacRelationshipsItem)
        List.Remove(Item)
    End Sub

    Public Function Item(ByVal index As Integer) As EacRelationshipsItem
        Return List.Item(index)
    End Function




    Public Function toXml() As String
        If Count = 0 Then Return ""
        Dim PrefixName As String

        Dim xml As String = "<eacrels>"
        For i As Integer = 0 To Count - 1
            xml &= String.Format("<eacrel reltype='{0}'><{5}name>{1}</{5}name><date>{3}</date><place>{2}</place><descnote>{4}</descnote></eacrel>", RelTypeToEac(Item(i).Type), Item(i).Name, Item(i).Place, Item(i).DateStr, Item(i).Note, EAC.EacPrefix(Item(i).EacType))
        Next
        xml &= "</eacrels>"
        Return xml
    End Function

    Private Function RelTypeToEac(ByVal RelType As String)
        Select Case RelType
            Case (VisualFieldLabel("Authorities.Associative")) : Return "associative"
            Case (VisualFieldLabel("Authorities.Child")) : Return "child"
            Case (VisualFieldLabel("Authorities.Earlier")) : Return "earlier"
            Case (VisualFieldLabel("Authorities.Identity")) : Return "identity"
            Case (VisualFieldLabel("Authorities.Later")) : Return "later"
            Case (VisualFieldLabel("Authorities.Parent")) : Return "parent"
            Case (VisualFieldLabel("Authorities.Subordinate")) : Return "subordinate"
            Case (VisualFieldLabel("Authorities.Superior")) : Return "superior"
            Case Else : Return ""
        End Select
    End Function

End Class



Public Class EacRelationshipsItem
    Private myID As Integer
    Private myType As String
    Private myName As String
    Private myPlace As String
    Private myDate As String
    Private myNote As String
    Private myEacType As String



    Public Sub New(ByVal Type As String, ByVal Name As String, ByVal Place As String, ByVal DateStr As String, ByVal Note As String, ByVal EacType As String)
        myID = 0
        myType = Type
        myName = Name
        myPlace = Place
        myDate = DateStr
        myNote = Note
        myEacType = EacType
    End Sub

    Public Sub New(ByVal ID As Integer, ByVal Type As String, ByVal Name As String, ByVal Place As String, ByVal DateStr As String, ByVal Note As String, ByVal EacType As String)
        myID = ID
        myType = Type
        myName = Name
        myPlace = Place
        myDate = DateStr
        myNote = Note
        myEacType = EacType
    End Sub



    Public Sub New(ByVal ID As Integer)
        myID = ID
    End Sub


    Public Overloads Overrides Function Equals(ByVal obj As Object) As Boolean
        If Not TypeOf obj Is EacRelationshipsItem Then
            Return False
        Else
            Return ID = CType(obj, EacRelationshipsItem).ID
        End If
    End Function


    Property Type() As String
        Get
            Return myType
        End Get
        Set(ByVal Value As String)
            myType = Value
        End Set
    End Property


    Property EacType() As String
        Get
            Return myEacType
        End Get
        Set(ByVal Value As String)
            myEacType = Value
        End Set
    End Property



    Property Place() As String
        Get
            Return myPlace
        End Get
        Set(ByVal Value As String)
            myPlace = Value
        End Set
    End Property

    Property DateStr() As String
        Get
            Return myDate
        End Get
        Set(ByVal Value As String)
            myDate = Value
        End Set
    End Property


    Property Note() As String
        Get
            Return myNote
        End Get
        Set(ByVal Value As String)
            myNote = Value
        End Set
    End Property


    Property Name() As String
        Get
            Return myName
        End Get
        Set(ByVal Value As String)
            myName = Value
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
        Return New EacRelationshipsItem(myID, myType, myName, myPlace, myDate, myNote)
    End Function




End Class