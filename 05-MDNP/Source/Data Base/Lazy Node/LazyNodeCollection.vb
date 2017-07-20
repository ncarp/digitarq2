Imports System
Imports System.Collections

    Public Class LazyNodeCollection
        Inherits CollectionBase

        Default Public Property Item(ByVal index As Integer) As LazyNode
            Get
                Return CType(List(index), LazyNode)
            End Get
            Set(ByVal Value As LazyNode)
                List(index) = Value
            End Set
        End Property

        Public Function Add(ByVal value As LazyNode) As Integer
            Return List.Add(value)
        End Function 'Add

        Public Function IndexOf(ByVal value As LazyNode) As Integer
            Return List.IndexOf(value)
        End Function 'IndexOf

    Public Function FetchLazyNodeByID(ByVal ID As Integer) As LazyNode
        Dim Node As LazyNode
        For Each Node In list
            If Node.ID = ID Then Return Node
        Next
        Return Nothing
    End Function

    Public Sub Insert(ByVal index As Integer, ByVal value As LazyNode)
        List.Insert(index, value)
    End Sub 'Insert

    Public Sub Remove(ByVal value As LazyNode)
        List.Remove(value)
    End Sub 'Remove

    Public Function Contains(ByVal value As LazyNode) As Boolean
        ' If value is not of type LazyNode, this will return false.
        Return List.Contains(value)
    End Function 'Contains

End Class '



