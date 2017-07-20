
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

Public Class EacArchRelationships
    Inherits CollectionBase


    Public Function Add(ByVal Type As String, ByVal DateStr As String, ByVal UnitId As String, ByVal UnitTitle As String, _
                        ByVal UnitDateInitial As String, ByVal UnitDateFinal As String, _
                         ByVal Repository As String, _
                        ByVal Note As String) As Integer
        Return List.Add(New EacArchRelationshipsItem(Type, DateStr, UnitId, UnitTitle, UnitDateInitial, UnitDateFinal, Repository, Note))
    End Function


    Public Function Add(ByVal ID As Integer, ByVal Type As String, ByVal DateStr As String, ByVal UnitId As String, ByVal UnitTitle As String, _
                        ByVal UnitDateInitial As String, ByVal UnitDateFinal As String, _
                        ByVal Repository As String, _
                        ByVal Note As String) As Integer
        Return List.Add(New EacArchRelationshipsItem(ID, Type, DateStr, UnitId, UnitTitle, UnitDateInitial, UnitDateFinal, Repository, Note))
    End Function


    Public Sub Remove(ByVal Item As EacArchRelationshipsItem)
        List.Remove(Item)
    End Sub

    Public Function Item(ByVal index As Integer) As EacArchRelationshipsItem
        Return List.Item(index)
    End Function

    Public Function toXml() As String
        If Count = 0 Then Return ""

        Dim xml As String = ""
        For i As Integer = 0 To Count - 1
            xml &= "" 'String.Format("<resourcerel reltype='{0}'><archunit><unitid>{1}</unitid> <unittitle>{2}</unittitle> <unitdate label='criacao_inicial'>{3}</unitdate> <unitdate label='criacao_final'>{4}</unitdate></archunit><repository>{5}</repository><physdesc>{6}</physdesc><abstract>{7}</abstract><descnote>{8}</descnote></archunit><date>{9}</date></resourcerel>", Item(i).Type, Item(i).UnitId, Item(i).UnitTitle, Item(i).UnitDateInitial, Item(i).UnitDateFinal, Item(i).Repository, Item(i).PhysDesc, Item(i).Abstract, Item(i).Note, Item(i).DateStr)
        Next
        Return xml
    End Function

End Class



Public Class EacArchRelationshipsItem
    Private myID As Integer
    Private myType As String
    Private myDate As String
    Private myUnitId As String
    Private myUnitDateInitial As String
    Private myUnitDateFinal As String
    Private myUnitTitle As String
    Private myRepository As String
    Private myNote As String



    Public Sub New(ByVal Type As String, ByVal DateStr As String, ByVal UnitId As String, ByVal UnitTitle As String, _
                   ByVal UnitDateInitial As String, ByVal UnitDateFinal As String, _
                    ByVal Repository As String, _
                    ByVal Note As String)
        myID = 0
        myDate = DateStr
        myType = Type
        myUnitId = UnitId
        myUnitTitle = UnitTitle
        myUnitDateInitial = UnitDateInitial
        myUnitDateFinal = UnitDateFinal
        myRepository = Repository
        myNote = Note
    End Sub


    Public Sub New(ByVal ID As Integer, ByVal Type As String, ByVal DateStr As String, ByVal UnitId As String, ByVal UnitTitle As String, _
                   ByVal UnitDateInitial As String, ByVal UnitDateFinal As String, _
                    ByVal Repository As String, _
                    ByVal Note As String)
        myID = ID
        myType = Type
        myDate = DateStr
        myUnitId = UnitId
        myUnitTitle = UnitTitle
        myUnitDateInitial = UnitDateInitial
        myUnitDateFinal = UnitDateFinal
        myRepository = Repository
        myNote = Note
    End Sub


    Public Sub New(ByVal ID As Integer)
        myID = ID
    End Sub


    Public Overloads Overrides Function Equals(ByVal obj As Object) As Boolean
        If Not TypeOf obj Is EacArchRelationshipsItem Then
            Return False
        Else
            Return ID = CType(obj, EacArchRelationshipsItem).ID
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

    Property DateStr() As String
        Get
            Return myDate
        End Get
        Set(ByVal Value As String)
            myDate = Value
        End Set
    End Property

    Property UnitId() As String
        Get
            Return myUnitId
        End Get
        Set(ByVal Value As String)
            myUnitId = Value
        End Set
    End Property


    Property Repository() As String
        Get
            Return myRepository
        End Get
        Set(ByVal Value As String)
            myRepository = Value
        End Set
    End Property

    Property UnitDateInitial() As String
        Get
            Return myUnitDateInitial
        End Get
        Set(ByVal Value As String)
            myUnitDateInitial = Value
        End Set
    End Property

    Property UnitDateFinal() As String
        Get
            Return myUnitDateFinal
        End Get
        Set(ByVal Value As String)
            myUnitDateFinal = Value
        End Set
    End Property

    Property UnitTitle() As String
        Get
            Return myUnitTitle
        End Get
        Set(ByVal Value As String)
            myUnitTitle = Value
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



    Property ID() As Integer
        Get
            Return myID
        End Get
        Set(ByVal Value As Integer)
            myID = Value
        End Set
    End Property


    Public Function Clone() As Object
        Return New EacArchRelationshipsItem(myID, myType, myUnitId, myUnitTitle, myUnitDateInitial, myUnitDateFinal, myRepository, myNote)
    End Function




End Class