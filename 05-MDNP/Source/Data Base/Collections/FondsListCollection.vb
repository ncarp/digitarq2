Imports System
Imports System.Collections

Public Class FondsListCollection
    Inherits CollectionBase


    Default Public Property Item(ByVal index As Integer) As FondsListItem
        Get
            Return CType(List(index), FondsListItem)
        End Get
        Set(ByVal Value As FondsListItem)
            List(index) = Value
        End Set
    End Property


    Public Function Add(ByVal value As FondsListItem) As Integer
        Return List.Add(value)
    End Function 'Add

    Public Function IndexOf(ByVal value As FondsListItem) As Integer
        Return List.IndexOf(value)
    End Function 'IndexOf


    Public Sub Insert(ByVal index As Integer, ByVal value As FondsListItem)
        List.Insert(index, value)
    End Sub 'Insert


    Public Sub Remove(ByVal value As FondsListItem)
        List.Remove(value)
    End Sub 'Remove


    Public Function Contains(ByVal value As FondsListItem) As Boolean
        Return List.Contains(value)
    End Function 'Contains




End Class



Public Class FondsListItem

    Private myID As Integer
    Private myUnitId As String
    Private myUnitTitle As String
    Private myUnitDateInitial As Date
    Private myUnitDateFinal As Date
    Private myVisible As Boolean


    Public Sub New(ByVal ID As Integer, ByVal UnitId As String, ByVal UnitTitle As String, ByVal UnitDateInitial As Date, ByVal UnitDateFinal As Date, ByVal Visible As Boolean)
        myID = ID
        myUnitId = UnitId
        myUnitTitle = UnitTitle
        myUnitDateInitial = UnitDateInitial
        myUnitDateFinal = UnitDateFinal
        myVisible = Visible
    End Sub


    Property Visible() As Boolean
        Get
            Return myVisible
        End Get
        Set(ByVal Value As Boolean)
            myVisible = Value
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


    Property UnitTitle() As String
        Get
            Return myUnitTitle
        End Get
        Set(ByVal Value As String)
            myUnitTitle = Value
        End Set
    End Property


    Property UnitDateInitial() As Date
        Get
            Return myUnitDateInitial
        End Get
        Set(ByVal Value As Date)
            myUnitDateInitial = Value
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


    Property UnitDateFinal() As Date
        Get
            Return myUnitDateFinal
        End Get
        Set(ByVal Value As Date)
            myUnitDateFinal = Value
        End Set
    End Property

    Public Overloads Overrides Function Equals(ByVal obj As Object) As Boolean
        If Not TypeOf obj Is FondsListItem Then
            Return False
        Else
            Return UnitId.Equals(CType(obj, FondsListItem).UnitId)
        End If
    End Function


End Class
