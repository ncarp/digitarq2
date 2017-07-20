
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

Imports System
Imports System.Collections


Public Class TreeNodeInfo

    Private myID As Int64
    Private myParentID As Int64
    Private myOtherLevel As String
    Private myUnitID As String
    Private myUnitTitle As String
    Private myHasChildren As Boolean
    Private myAssociated As Boolean


#Region "Constructors"

    Public Sub New()
    End Sub

#End Region


#Region "Properties"

    Property ID() As Int64
        Get
            Return myID
        End Get
        Set(ByVal Value As Int64)
            myID = Value
        End Set
    End Property

    Property ParentID() As Int64
        Get
            Return myParentID
        End Get
        Set(ByVal Value As Int64)
            myParentID = Value
        End Set
    End Property

    Property OtherLevel() As String
        Get
            Return myOtherLevel
        End Get
        Set(ByVal Value As String)
            myOtherLevel = Value
        End Set
    End Property

    Property UnitID() As String
        Get
            Return myUnitID
        End Get
        Set(ByVal Value As String)
            myUnitID = Value
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

    Property HasChildren() As Boolean
        Get
            Return myHasChildren
        End Get
        Set(ByVal Value As Boolean)
            myHasChildren = Value
        End Set
    End Property

    Property Associated() As Boolean
        Get
            Return myAssociated
        End Get
        Set(ByVal Value As Boolean)
            myAssociated = Value
        End Set
    End Property

#End Region

End Class

Public Class TreeNodeInfoCollection
    Inherits CollectionBase

    Default Public Property Item(ByVal index As Integer) As TreeNodeInfo
        Get
            Return CType(List(index), TreeNodeInfo)
        End Get
        Set(ByVal Value As TreeNodeInfo)
            List(index) = Value
        End Set
    End Property

    Public Function Add(ByVal value As TreeNodeInfo) As Integer
        Return List.Add(value)
    End Function

    Public Function IndexOf(ByVal value As TreeNodeInfo) As Integer
        Return List.IndexOf(value)
    End Function

    Public Sub Insert(ByVal index As Integer, ByVal value As TreeNodeInfo)
        List.Insert(index, value)
    End Sub

    Public Sub Remove(ByVal value As TreeNodeInfo)
        List.Remove(value)
    End Sub

    Public Function Contains(ByVal value As TreeNodeInfo) As Boolean
        Return List.Contains(value)
    End Function

End Class