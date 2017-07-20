Imports System
Imports System.Collections


Public Class RecordsIDCollection
    Inherits CollectionBase

    Public Function Add(ByVal ID As Integer) As Integer
        Return List.Add(New RecordID(ID))
    End Function

    Public Function IndexOf(ByVal value As RecordID) As Integer
        Return List.IndexOf(value)
    End Function

    Public Sub Insert(ByVal index As Integer, ByVal value As RecordID)
        List.Insert(index, value)
    End Sub

    Public Sub Remove(ByVal value As RecordID)
        List.Remove(value)
    End Sub

    Public Function Contains(ByVal value As RecordID) As Boolean
        Return List.Contains(value)
    End Function

    Default Public Property Item(ByVal index As Integer) As RecordID
        Get
            Return CType(List(index), RecordID)
        End Get
        Set(ByVal Value As RecordID)
            List(index) = Value
        End Set
    End Property
End Class



Public Class RecordID

    Private myID As Integer

    Public Sub New(ByVal ID As Integer)
        myID = ID
    End Sub

    Property ID() As Integer
        Get
            Return myID
        End Get
        Set(ByVal Value As Integer)
            myID = Value
        End Set
    End Property

End Class
