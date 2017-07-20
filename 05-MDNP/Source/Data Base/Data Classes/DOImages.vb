

'****************************************************************
'* DOImages Node Abstract Class
'****************************************************************


Public Class DOImages
    Inherits CollectionBase

    Public Function Add(ByVal id As Int64, ByVal DigitalObjectID As Int64, _
                        ByVal Name As String) As Integer
        Return List.Add(New DOImagesItem(id, DigitalObjectID, Name))
    End Function

    Public Sub Remove(ByVal Item As DOImagesItem)
        List.Remove(Item)
    End Sub

    Public Function Item(ByVal index As Integer) As DOImagesItem
        Return List.Item(index)
    End Function

End Class



Public Class DOImagesItem

#Region "Properties"

    Private myFileID As Int64
    Private myDigitalObjectID As Int64
    Private myCreationDateTime As String
    Private myName As String
    Private myTPlatformID As Integer
    Private myTPlatform As String
    Private myColorSpace As String
    Private myLampTypeID As Integer
    Private myLampType As String
    Private myImageWidth As String
    Private myImageHeight As String
    Private myResolution As String
    Private myBitDepth As Integer
    Private myCompression As String
    Private myMIMEType As String
    Private myFNumber As String
    Private myExposureTime As String
    Private myMeteringModeID As Integer
    Private myMeteringMode As String
    Private myFocalLength As String
    Private myAutoFocusID As Integer
    Private myAutoFocus As String
    Private myCheckSumCreationDateTime As String
    Private myCheckSumValue As String
    Private myImageSize As Integer
    Private myProfileID As Integer
    Private myProfileName As String
    Private myProcessingDateTime As String
    Private myProcessingActions As String
    Private myProcessingSoftwareName As String
    Private myProcessingSoftwareVersion As String
    Private myProcessingOSName As String
    Private myProcessingOSVersion As String
    Private myColorManager As String
    Private myImage As Byte()
    Private myUserName As String

#End Region


#Region "Inicializations"

    'All the elements needed for the treeview construction
    Public Sub New(ByVal id As Int64, ByVal DigitalObjectID As Int64, _
                   ByVal Name As String)
        myFileID = id
        myDigitalObjectID = DigitalObjectID
        myName = Name
    End Sub

    Public Sub New()
    End Sub

    Public Sub New(ByVal DigitalObjectID As Integer)
        myDigitalObjectID = DigitalObjectID
    End Sub

    Public Overloads Overrides Function Equals(ByVal obj As Object) As Boolean
        If Not TypeOf obj Is DOImagesItem Then
            Return False
        Else
            Return FileID = CType(obj, DOImagesItem).FileID
        End If
    End Function

#End Region


#Region "Gets and Sets of Public Properties"

    Public Property FileID() As Int64
        Get
            Return myFileID
        End Get
        Set(ByVal Value As Int64)
            myFileID = Value
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

    Public Property CreationDateTime() As String
        Get
            Return myCreationDateTime
        End Get
        Set(ByVal Value As String)
            myCreationDateTime = Value
        End Set
    End Property

    Public Property FileName() As String
        Get
            Return myName
        End Get
        Set(ByVal Value As String)
            myName = Value
        End Set
    End Property

    Public Property TPlatformID() As Integer
        Get
            Return myTPlatformID
        End Get
        Set(ByVal Value As Integer)
            myTPlatformID = Value
        End Set
    End Property

    Public Property TPlatform() As String
        Get
            Return myTPlatform
        End Get
        Set(ByVal Value As String)
            myTPlatform = Value
        End Set
    End Property

    Public Property ColorSpace() As String
        Get
            Return myColorSpace
        End Get
        Set(ByVal Value As String)
            myColorSpace = Value
        End Set
    End Property

    Public Property LampTypeID() As Integer
        Get
            Return myLampTypeID
        End Get
        Set(ByVal Value As Integer)
            myLampTypeID = Value
        End Set
    End Property

    Public Property LampType() As String
        Get
            Return myLampType
        End Get
        Set(ByVal Value As String)
            myLampType = Value
        End Set
    End Property

    Public Property ImageWidth() As String
        Get
            Return myImageWidth
        End Get
        Set(ByVal Value As String)
            myImageWidth = Value
        End Set
    End Property

    Public Property ImageHeight() As String
        Get
            Return myImageHeight
        End Get
        Set(ByVal Value As String)
            myImageHeight = Value
        End Set
    End Property

    Public Property Resolution() As String
        Get
            Return myResolution
        End Get
        Set(ByVal Value As String)
            myResolution = Value
        End Set
    End Property

    Public Property BitDepth() As Integer
        Get
            Return myBitDepth
        End Get
        Set(ByVal Value As Integer)
            myBitDepth = Value
        End Set
    End Property

    Public Property Compression() As String
        Get
            Return myCompression
        End Get
        Set(ByVal Value As String)
            myCompression = Value
        End Set
    End Property

    Public Property MIMEType() As String
        Get
            Return myMIMEType
        End Get
        Set(ByVal Value As String)
            myMIMEType = Value
        End Set
    End Property

    Public Property FNumber() As String
        Get
            Return myFNumber
        End Get
        Set(ByVal Value As String)
            myFNumber = Value
        End Set
    End Property

    Public Property ExposureTime() As String
        Get
            Return myExposureTime
        End Get
        Set(ByVal Value As String)
            myExposureTime = Value
        End Set
    End Property

    Public Property MeteringModeID() As Integer
        Get
            Return myMeteringModeID
        End Get
        Set(ByVal Value As Integer)
            myMeteringModeID = Value
        End Set
    End Property

    Public Property MeteringMode() As String
        Get
            Return myMeteringMode
        End Get
        Set(ByVal Value As String)
            myMeteringMode = Value
        End Set
    End Property

    Public Property FocalLength() As String
        Get
            Return myFocalLength
        End Get
        Set(ByVal Value As String)
            myFocalLength = Value
        End Set
    End Property

    Public Property AutoFocusID() As Integer
        Get
            Return myAutoFocusID
        End Get
        Set(ByVal Value As Integer)
            myAutoFocusID = Value
        End Set
    End Property

    Public Property CheckSumCreationDateTime() As String
        Get
            Return myCheckSumCreationDateTime
        End Get
        Set(ByVal Value As String)
            myCheckSumCreationDateTime = Value
        End Set
    End Property

    Public Property CheckSumValue() As String
        Get
            Return myCheckSumValue
        End Get
        Set(ByVal Value As String)
            myCheckSumValue = Value
        End Set
    End Property

    Public Property ImageSize() As String
        Get
            Return myImageSize
        End Get
        Set(ByVal Value As String)
            myImageSize = Value
        End Set
    End Property

    Public Property ProfileID() As Integer
        Get
            Return myProfileID
        End Get
        Set(ByVal Value As Integer)
            myProfileID = Value
        End Set
    End Property

    Public Property ProfileName() As String
        Get
            Return myProfileName
        End Get
        Set(ByVal Value As String)
            myProfileName = Value
        End Set
    End Property

    Public Property ProcessingDateTime() As String
        Get
            Return myProcessingDateTime
        End Get
        Set(ByVal Value As String)
            myProcessingDateTime = Value
        End Set
    End Property

    Public Property ProcessingActions() As String
        Get
            Return myProcessingActions
        End Get
        Set(ByVal Value As String)
            myProcessingActions = Value
        End Set
    End Property

    Public Property ProcessingSoftwareName() As String
        Get
            Return myProcessingSoftwareName
        End Get
        Set(ByVal Value As String)
            myProcessingSoftwareName = Value
        End Set
    End Property

    Public Property ProcessingSoftwareVersion() As String
        Get
            Return myProcessingSoftwareVersion
        End Get
        Set(ByVal Value As String)
            myProcessingSoftwareVersion = Value
        End Set
    End Property

    Public Property ProcessingOSName() As String
        Get
            Return myProcessingOSName
        End Get
        Set(ByVal Value As String)
            myProcessingOSName = Value
        End Set
    End Property

    Public Property ProcessingOSVersion() As String
        Get
            Return myProcessingOSVersion
        End Get
        Set(ByVal Value As String)
            myProcessingOSVersion = Value
        End Set
    End Property

    Public Property ColorManager() As String
        Get
            Return myColorManager
        End Get
        Set(ByVal Value As String)
            myColorManager = Value
        End Set
    End Property

    Public Property Image() As Byte()
        Get
            Return myImage
        End Get
        Set(ByVal Value As Byte())
            myImage = Value
        End Set
    End Property

    Public Property UserName() As String
        Get
            Return myUserName
        End Get
        Set(ByVal Value As String)
            myUserName = Value
        End Set
    End Property

#End Region

End Class
