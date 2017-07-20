
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