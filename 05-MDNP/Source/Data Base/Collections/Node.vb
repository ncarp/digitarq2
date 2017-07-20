Public Class Node
    Private myID As Integer
    Private myTypeID As Integer
    Private myItem As String
    Public Sub New(ByVal ID As Integer, ByVal TypeId As String, ByVal Item As String)
        myID = ID
        myTypeID = TypeId
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

    Property TypeId() As Integer

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


End Class

