
'*************************************************************************************************
' class: ChronList
' Purpose:  It Collects all items from the ChronList table (DigitArq database)
' The Notation isn't used here.
'***************************************************************************************************

Public Class ChronList
    Inherits CollectionBase


    Public Function Add(ByVal EventDate As String, ByVal EventDescription As String) As Integer
        Return List.Add(New ChronListItem(EventDate, EventDescription))
    End Function


    Public Function Add(ByVal ID As Integer, ByVal EventDate As String, ByVal EventDescription As String) As Integer
        Return List.Add(New ChronListItem(ID, EventDate, EventDescription))
    End Function


    Public Sub Remove(ByVal Item As ChronListItem)
        List.Remove(Item)
    End Sub

    Public Function Item(ByVal index As Integer) As ChronListItem
        Return List.Item(index)
    End Function

End Class



Public Class ChronListItem
    Private myEventDate As String
    Private myEventDescription As String
    Private myID As Integer


    Public Sub New(ByVal EventDate As String, ByVal EventDescription As String)
        myEventDate = EventDate
        myEventDescription = EventDescription
        myID = 0
    End Sub

    Public Sub New(ByVal ID As Integer, ByVal EventDate As String, ByVal EventDescription As String)
        myEventDate = EventDate
        myEventDescription = EventDescription
        myID = ID
    End Sub


    Property EventDate() As String
        Get
            Return myEventDate
        End Get
        Set(ByVal Value As String)
            EventDate = Value
        End Set
    End Property

    Property EventDescription() As String
        Get
            Return myEventDescription
        End Get
        Set(ByVal Value As String)
            myEventDescription = Value
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
        Return New ChronListItem(myID, myEventDate, myEventDescription)
    End Function




End Class