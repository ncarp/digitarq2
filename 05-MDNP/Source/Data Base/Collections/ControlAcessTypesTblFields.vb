Public Class CtlAcessTypesTblFields
    Private myID As Integer
    Private myType As String

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


End Class
