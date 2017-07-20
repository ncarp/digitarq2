Public Class AdvancedSearch

    Private myOtherLevel As ArrayList
    Private mySearchImages As Boolean
    Private myCompleteUnitID As String
    Private myPartUnitID As String
    Private myUnitTitle As BlnSearchFields
    Private myAuthorDestination As BlnSearchFields
    Private myGeogLocal As BlnSearchFields
    Private myKeyWord As BlnSearchFields
    Private myIntervalDates As IntervalDates
    Private myControlAccessItem As ControlAccessItem
   
    Public Sub New()
    End Sub

    Property OtherLevel() As ArrayList
        Get
            Return myOtherLevel
        End Get
        Set(ByVal Value As ArrayList)
            myOtherLevel = Value
        End Set
    End Property

    Property SearchImages() As Boolean
        Get
            Return mySearchImages
        End Get
        Set(ByVal Value As Boolean)
            mySearchImages = Value
        End Set
    End Property

    Property CompleteUnitID() As String
        Get
            Return myCompleteUnitID
        End Get
        Set(ByVal Value As String)
            myCompleteUnitID = Value
        End Set
    End Property

    Property PartUnitID() As String
        Get
            Return myPartUnitID
        End Get
        Set(ByVal Value As String)
            myPartUnitID = Value
        End Set
    End Property

    Property UnitTitle() As BlnSearchFields
        Get
            Return myUnitTitle
        End Get
        Set(ByVal Value As BlnSearchFields)
            myUnitTitle = Value
        End Set
    End Property

    Property AuthorDestination() As BlnSearchFields
        Get
            Return myAuthorDestination
        End Get
        Set(ByVal Value As BlnSearchFields)
            myAuthorDestination = Value
        End Set
    End Property

    Property GeogLocal() As BlnSearchFields
        Get
            Return myGeogLocal
        End Get
        Set(ByVal Value As BlnSearchFields)
            myGeogLocal = Value
        End Set
    End Property

    Property KeyWord() As BlnSearchFields
        Get
            Return myKeyWord
        End Get
        Set(ByVal Value As BlnSearchFields)
            myKeyWord = Value
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

    Property ControlAccessItem() As ControlAccessItem
        Get
            Return myControlAccessItem
        End Get
        Set(ByVal Value As ControlAccessItem)
            myControlAccessItem = Value
        End Set
    End Property

End Class
