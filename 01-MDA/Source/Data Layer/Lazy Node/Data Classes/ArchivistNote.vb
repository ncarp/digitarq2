
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


Public Class ArchivistNotes
    Inherits CollectionBase


    Default Public Property Item(ByVal index As Integer) As ArchivistNotesItem
        Get
            Return CType(List(index), ArchivistNotesItem)
        End Get
        Set(ByVal Value As ArchivistNotesItem)
            List(index) = Value
        End Set
    End Property


    Public Function Add(ByVal Value As ArchivistNotesItem) As Integer
        Return List.Add(Value)
    End Function 'Add


    Public Function IndexOf(ByVal value As ArchivistNotesItem) As Integer
        Return List.IndexOf(value)
    End Function 'IndexOf


    Public Sub Insert(ByVal index As Integer, ByVal value As ArchivistNotesItem)
        List.Insert(index, value)
    End Sub 'Insert


    Public Sub Remove(ByVal value As ArchivistNotesItem)
        List.Remove(value)
    End Sub 'Remove


    Public Function Contains(ByVal value As ArchivistNotesItem) As Boolean
        Return List.Contains(value)
    End Function 'Contains


End Class





Public Class ArchivistNotesItem
    Private myNoteID As Integer
    Private myNoteTitle As String
    Private myNote As String
    Private myNoteDate As String
    Private myComponentID As Int64
    Private myUsername As String


    Public Sub New()

    End Sub

    Public Sub New(ByVal NoteTitle As String, ByVal Note As String, ByVal NoteDate As String, ByVal ComponentID As Integer, ByVal Username As String)
        myNoteTitle = NoteTitle
        myNote = Note
        myNoteDate = NoteDate
        myComponentID = ComponentID
        myUsername = Username
    End Sub


    Property NoteID() As Integer
        Get
            Return myNoteID
        End Get
        Set(ByVal Value As Integer)
            myNoteID = Value
        End Set
    End Property

    Property NoteTitle() As String
        Get
            Return myNoteTitle
        End Get
        Set(ByVal Value As String)
            myNoteTitle = Value
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

    Property NoteDate() As String
        Get
            Return myNoteDate
        End Get
        Set(ByVal Value As String)
            myNoteDate = Value
        End Set
    End Property

    Property ComponentID() As Int64
        Get
            Return myComponentID
        End Get
        Set(ByVal Value As Int64)
            myComponentID = Value
        End Set
    End Property

    Property Username() As String
        Get
            Return myUsername
        End Get
        Set(ByVal Value As String)
            myUsername = Value
        End Set
    End Property


    Public Function Clone() As Object
        Return New ArchivistNotesItem(myNoteTitle, myNote, myNoteDate, myComponentID, myUsername)
    End Function

    Public Overloads Overrides Function Equals(ByVal obj As Object) As Boolean
        If Not TypeOf obj Is ArchivistNotesItem Then
            Return False
        Else
            Return NoteID = CType(obj, ArchivistNotesItem).NoteID
        End If
    End Function
End Class
