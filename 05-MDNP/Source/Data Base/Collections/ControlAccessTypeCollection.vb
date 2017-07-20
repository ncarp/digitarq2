Imports System
Imports System.Collections


Public Class ControlAccessType

    Private myID As Integer
    Private myType As String

    Public Sub New()
    End Sub

    Public Sub New(ByVal ID As Integer, ByVal Type As String)
        myID = ID
        myType = Type
    End Sub

    Property ID() As Integer
        Get
            Return myID
        End Get
        Set(ByVal Value As Integer)
            myID = Value
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

End Class


Public Class colCtlAccessType
    Inherits CollectionBase

    Default Public Property Item(ByVal index As Integer) As ControlAccessType
        Get
            Return CType(List(index), ControlAccessType)
        End Get
        Set(ByVal Value As ControlAccessType)
            List(index) = Value
        End Set
    End Property

    Public Function Add(ByVal value As ControlAccessType) As Integer
        Return List.Add(value)
    End Function

    Public Function IndexOf(ByVal value As ControlAccessType) As Integer
        Return List.IndexOf(value)
    End Function

    Public Sub Insert(ByVal index As Integer, ByVal value As ControlAccessType)
        List.Insert(index, value)
    End Sub

    Public Sub Remove(ByVal value As ControlAccessType)
        List.Remove(value)
    End Sub

    Public Function Contains(ByVal value As ControlAccessType) As Boolean
        Return List.Contains(value)
    End Function

End Class
