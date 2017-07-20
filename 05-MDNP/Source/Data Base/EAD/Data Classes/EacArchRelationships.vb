'*************************************************************************************************
' class: EacArchRelationships
' Purpose: It Collects all items from the EacArchRelationships table (DigitArq database/ EAC Diagram)
'          This is related with, ISAAR(CPF), 6 - Relating corporate bodies, persons and famalies to archival 
'          materials 
' The Notation isn't used here.
'***************************************************************************************************
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

    Private Function DateToHtml(ByVal datein As String, ByVal datefin As String) As String

        datein = strGetDate(datein)
        datefin = strGetDate(datefin)
        If datein = "" And datefin = "" Then

            Return ""

        ElseIf datefin = "" Then

            Return " <font class='TextNavy'>Datas: </font> " & datein
        ElseIf datein = "" Then
            Return " <font class='TextNavy'>Datas: </font> " & datefin
        Else
            Return " <font class='TextNavy'>Datas: </font>" & datein & " a " & datefin

        End If
        Return ""
    End Function

    '*************************************************************************************************
    ' Function: toHtml
    ' Purpose: It show in HTML the relationships Area according with 
    '          disposed on point 6 from ISAAR(CPF) document.
    ' The Notation isn't used here.
    '***************************************************************************************************
    Public Function toHtml() As String
        If Count = 0 Then Return ""

        Dim Html As String = ""
        For i As Integer = 0 To Count - 1
            Html &= CreateTag(" Identificador do recurso relacionado: ", WriteIfNotEmpty("", Item(i).UnitTitle) & WriteIfNotEmpty("<font class='TextBlueBottom'> Código: </font> ", Item(i).UnitId) & DateToHtml(Item(i).UnitDateInitial, Item(i).UnitDateFinal)) & _
               CreateTag(" Tipo de recurso relacionado: ", WriteIfNotEmpty("Documento do arquivo ", Item(i).Repository)) & _
               CreateTag(" Natureza da relação: ", Item(i).Note) & CreateTag("Datas do recurso: ", Item(i).DateStr)
        Next
        Return Html
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