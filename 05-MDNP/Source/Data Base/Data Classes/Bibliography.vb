


Imports System
Imports System.Collections

'*************************************************************************************************
' class: Bibliography
' Purpose:  It Collects all items form the Bibilography table (DigitArq database)
' The Notation isn't used here.
'***************************************************************************************************

Public Class Bibliography
    Inherits CollectionBase


    Default Public Property Item(ByVal index As Integer) As BibRefItem
        Get
            Return CType(List(index), BibRefItem)
        End Get
        Set(ByVal Value As BibRefItem)
            List(index) = Value
        End Set
    End Property


    Public Function Add(ByVal ID As Integer, ByVal BibRef As String) As Integer
        Return List.Add(New BibRefItem(ID, BibRef))
    End Function 'Add


    Public Function Add(ByVal BibRef As String) As Integer
        Return List.Add(New BibRefItem(BibRef))
    End Function 'Add

    Public Function IndexOf(ByVal value As BibRefItem) As Integer
        Return List.IndexOf(value)
    End Function 'IndexOf


    Public Sub Insert(ByVal index As Integer, ByVal value As BibRefItem)
        List.Insert(index, value)
    End Sub 'Insert


    Public Sub Remove(ByVal value As BibRefItem)
        List.Remove(value)
    End Sub 'Remove


    Public Function Contains(ByVal value As BibRefItem) As Boolean
        Return List.Contains(value)
    End Function 'Contains


End Class





Public Class BibRefItem
    Private myID As Integer
    Private myBibRef As String


    Public Sub New(ByVal BibRef As String)
        myBibRef = BibRef
        myID = 0
    End Sub

    Public Sub New(ByVal ID As Integer, ByVal BibRef As String)
        myBibRef = BibRef
        myID = ID
    End Sub

    Property BibRef() As String
        Get
            Return myBibRef
        End Get
        Set(ByVal Value As String)
            myBibRef = Value
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
        Return New BibRefItem(myID, myBibRef)
    End Function


End Class
