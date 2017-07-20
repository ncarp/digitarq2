Public Class URLS

    Private myText As String
    Private myUrl As String
    Private myClassName As String

    Public Sub New(ByVal Text As String, ByVal Url As String, ByVal className As String)
        myText = Text
        myUrl = Url
        myClassName = className
    End Sub

    Property Text() As String
        Get
            Return myText
        End Get
        Set(ByVal Value As String)
            myText = Value
        End Set
    End Property

    Property Url() As String
        Get
            Return myUrl
        End Get
        Set(ByVal Value As String)
            myUrl = Value
        End Set
    End Property

    Property className() As String
        Get
            Return myClassName
        End Get
        Set(ByVal Value As String)
            myClassName = Value
        End Set
    End Property

End Class
