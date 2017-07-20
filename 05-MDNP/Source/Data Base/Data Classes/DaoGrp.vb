Public Class DaoGrp

    Private myComponentID As Int64
    Private myDigitalObjectID As Int64
    Private myDigitalObjectName As String
    Private myFileID As Int64
    Private myFileName As String
    Private myType As Int16
    Private myArchiveID As String
    Private myTopographicalQuota As String
    Private myNumImages As Integer


    Public Sub New()
    End Sub

    Public Sub New(ByVal ComponentID As Int64, ByVal DigitalObjectID As Int64, ByVal FileID As Int64, ByVal Type As Int16)
        myComponentID = ComponentID
        myDigitalObjectID = DigitalObjectID
        myFileID = FileID
        myType = Type
    End Sub

    Property ComponentID() As Int64
        Get
            Return myComponentID
        End Get
        Set(ByVal Value As Int64)
            myComponentID = Value
        End Set
    End Property

    Property DigitalObjectID() As Int64
        Get
            Return myDigitalObjectID
        End Get
        Set(ByVal Value As Int64)
            myDigitalObjectID = Value
        End Set
    End Property

    Property DigitalObjectName() As String
        Get
            Return myDigitalObjectName
        End Get
        Set(ByVal Value As String)
            myDigitalObjectName = Value
        End Set
    End Property

    Property FileID() As Int64
        Get
            Return myFileID
        End Get
        Set(ByVal Value As Int64)
            myFileID = Value
        End Set
    End Property

    Property FileName() As String
        Get
            Return myFileName
        End Get
        Set(ByVal Value As String)
            myFileName = Value
        End Set
    End Property

    Property Type() As Int16
        Get
            Return myType
        End Get
        Set(ByVal Value As Int16)
            myType = Value
        End Set
    End Property

    Property ArchiveID() As String
        Get
            Return myArchiveID
        End Get
        Set(ByVal Value As String)
            myArchiveID = Value
        End Set
    End Property

    Property TopographicalQuota() As String
        Get
            Return myTopographicalQuota
        End Get
        Set(ByVal Value As String)
            myTopographicalQuota = Value
        End Set
    End Property

    Property NumImages() As Integer
        Get
            Return myNumImages
        End Get
        Set(ByVal Value As Integer)
            myNumImages = Value
        End Set
    End Property

    Public Function Clone() As Object
        Return New DaoGrp(myComponentID, myDigitalObjectID, myFileID, myType)
    End Function
End Class


Public Class DaoGrpCollection
    Inherits CollectionBase

    Default Public Property Item(ByVal index As Integer) As DaoGrp
        Get
            Return CType(List(index), DaoGrp)
        End Get
        Set(ByVal Value As DaoGrp)
            List(index) = Value
        End Set
    End Property


    Public Function Add(ByVal value As DaoGrp) As Integer
        Return List.Add(value)
    End Function 'Add

    Public Function IndexOf(ByVal value As DaoGrp) As Integer
        Return List.IndexOf(value)
    End Function 'IndexOf

    Public Sub Insert(ByVal index As Integer, ByVal value As DaoGrp)
        List.Insert(index, value)
    End Sub 'Insert

    Public Sub Remove(ByVal value As BibRefItem)
        List.Remove(value)
    End Sub 'Remove

    Public Function Contains(ByVal value As DaoGrp) As Boolean
        Return List.Contains(value)
    End Function 'Contains

End Class





