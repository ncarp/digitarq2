Public Class BasicSearch

    Private myName As String
    Private myLocal As String
    Private myOtherTerms As String
    Private myIntervalDates As IntervalDates

    Public Sub New()
    End Sub

    
    Property Name() As String
        Get
            Return myName
        End Get
        Set(ByVal Value As String)
            myName = Value
        End Set
    End Property

    Property Local() As String
        Get
            Return myLocal
        End Get
        Set(ByVal Value As String)
            myLocal = Value
        End Set
    End Property

    Property OtherTerms() As String
        Get
            Return myOtherTerms
        End Get
        Set(ByVal Value As String)
            myOtherTerms = Value
        End Set
    End Property

    Property IntervalDates() As IntervalDates
        Get
            Return myIntervalDates
        End Get
        Set(ByVal Value As IntervalDates)
            myIntervalDates = Value
        End Set
    End Property

End Class
