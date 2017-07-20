'*************************************************************************************************
' class: EacRelationships
' Purpose: It Collects all items from the EacArchRelationships table (DigitArq database/ EAC Diagram)
'          This is related with, ISAAR(CPF), 5.3 Reletionships Area.
' The Notation isn't used here.
'***************************************************************************************************

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

    '*************************************************************************************************
    ' Function: toHtml
    ' Purpose: It shows all items from the EacRelationships table (DigitArq database/ EAC Diagram)
    '          This is related with, ISAAR(CPF), 5.3 Reletionships Area.
    ' The Notation isn't used here.
    '***************************************************************************************************


    Public Function toHtml() As String
        If Count = 0 Then Return ""
        Dim PrefixName As String
        Dim html As String

        For i As Integer = 0 To Count - 1
            html &= CreateTag("Nome/identificador da entidade relacionada:", Item(i).Name & "<font class='TextBlueBottom'> Tipo de entidade: </font> " & Item(i).EacType) & CreateTag("Tipo de relação:", Item(i).Type) & _
            CreateTag("Descrição da relação:", Item(i).Note) & CreateTag("Datas da relação:", Item(i).DateStr) & CreateTag("Localidade(s):", Item(i).Place)
        Next

        Return html
    End Function

    'Private Function RelTypeToEac(ByVal RelType As String)
    '    Select Case RelType
    '        Case (VisualFieldLabel("Authorities.Associative")) : Return "associative"
    '        Case (VisualFieldLabel("Authorities.Child")) : Return "child"
    '        Case (VisualFieldLabel("Authorities.Earlier")) : Return "earlier"
    '        Case (VisualFieldLabel("Authorities.Identity")) : Return "identity"
    '        Case (VisualFieldLabel("Authorities.Later")) : Return "later"
    '        Case (VisualFieldLabel("Authorities.Parent")) : Return "parent"
    '        Case (VisualFieldLabel("Authorities.Subordinate")) : Return "subordinate"
    '        Case (VisualFieldLabel("Authorities.Superior")) : Return "superior"
    '        Case Else : Return ""
    '    End Select
    'End Function

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