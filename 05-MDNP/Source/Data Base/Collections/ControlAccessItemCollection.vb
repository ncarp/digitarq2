'This class was from digitarq and is used were in the web form!
Imports System
Imports System.Collections


Public Class ControlAccessItem

    Private myID As Integer
    Private myTypeID As Integer
    Private myType As String
    Private myItem As String

    Public Sub New()
    End Sub

    Public Sub New(ByVal ID As Integer, ByVal TypeID As Integer, ByVal Type As String, ByVal Item As String)
        myID = ID
        myTypeID = TypeID
        myType = Type
        myItem = Item
    End Sub
    'I creat this new constructor for use in the Childpage to list the items related with the
    'the type chosed by the user
    Public Sub New(ByVal ID As Integer, ByVal TypeID As String, ByVal Item As String)
        myID = ID
        myTypeID = TypeID
        myItem = Item
    End Sub

    Property ID() As Integer
        Get
            Return myID
        End Get
        Set(ByVal Value As Integer)
            myID = Value
        End Set
    End Property

    Property TypeID() As Integer
        Get
            Return myTypeID
        End Get
        Set(ByVal Value As Integer)
            myTypeID = Value
        End Set
    End Property

    Property Item() As String
        Get
            Return myItem
        End Get
        Set(ByVal Value As String)
            myItem = Value
        End Set
    End Property

    Property Type() As String
        Get
            Return myType
        End Get
        Set(ByVal Value As String)
            myType = Value
        End Set
    End Property

    Public Overloads Overrides Function Equals(ByVal obj As Object) As Boolean
        If Not TypeOf obj Is ControlAccessType Then
            Return False
        Else
            Return ID.Equals(CType(obj, ControlAccessType).ID)
        End If
    End Function

    Public Function IsEmpty() As Boolean
        If myID = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

End Class


Public Class colCtlAccessItem
    Inherits CollectionBase

    Default Public Property Item(ByVal index As Integer) As ControlAccessItem
        Get
            Return CType(List(index), ControlAccessItem)
        End Get
        Set(ByVal Value As ControlAccessItem)
            List(index) = Value
        End Set
    End Property

    Public Function Add(ByVal ID As Integer, ByVal TypeID As Integer, ByVal Type As String, ByVal Item As String) As Integer
        Return List.Add(New ControlAccessItem(ID, TypeID, Type, Item))
    End Function 'Add

    Public Function Add(ByVal value As ControlAccessItem) As Integer
        Return List.Add(value)
    End Function 'Add

    Public Function IndexOf(ByVal value As ControlAccessItem) As Integer
        Return List.IndexOf(value)
    End Function 'IndexOf

    Public Sub Insert(ByVal index As Integer, ByVal value As ControlAccessItem)
        List.Insert(index, value)
    End Sub 'Insert

    Public Sub Remove(ByVal value As ControlAccessItem)
        List.Remove(value)
    End Sub 'Remove

    Public Function Contains(ByVal value As ControlAccessItem) As Boolean
        Return List.Contains(value)
    End Function 'Contains

End Class