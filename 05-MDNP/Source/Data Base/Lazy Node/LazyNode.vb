

'****************************************************************
'* Lazy Node Abstract Class
'****************************************************************
Public MustInherit Class LazyNode

    Enum LazyNodeFields
        ID
        HasChildren
        Visible
        Valid

        OtherLevel
        OtherLevelIndex
        UnitId
        ParentID

        CountryCode
        RepositoryCode

        UnitTitle
        UnitTitleType

        UnitDateInitial
        UnitDateFinal
        UnitDateInitialCertainty
        UnitDateFinalCertainty
        UnitDateBulk

        ExtentBook
        ExtentMaco
        ExtentMacete
        ExtentFolder
        ExtentCover
        ExtentCapilha
        ExtentRoll
        ExtentBox
        ExtentEnvelope
        ExtentAlbum
        ExtentMl
        ExtentLeaf
        ExtentPage
        ExtentOther


        Dimensions

        GenreForm
        GeogName
        PhysFacet
        PhysLoc

        MaterialSpec
        LangMaterial

        OriginationScrivener
        OriginationAuthor
        OriginationDestination
        OriginationAuthorAddress
        OriginationDestinationAddress
        OriginationNotary

        ScopeContent
        BiogHist
        OtherFindAid
        OriginalNumbering

        Note

        RelatedMaterial
        PhysTech
        AcqInfo
        Arrangement
        CustodHist
        AltFormAvail
        Appraisal
        AccessRestrict
        LegalStatus
        Accruals
        UseRestrict
        OriginalsLoc

        ProcessInfoName
        ProcessInfoDate

        PreferCite
        SeparatedMaterial
        Abstract
        Repository

        DigitalObjectID
        DigitalObjectExists
        DOImageGOD

        Bibliography
        ControlAccess
        ChronList
        FilePlan

        ContainerType


    End Enum


    Public Enum SortingStyles
        ByUnitDateInitial
        ByUnitID
        ByOtherLevel
        None
    End Enum


#Region "Properties"


    Private mySortBy As SortingStyles = SortingStyles.None

    Private myVisible As Boolean
    Private myValid As Boolean


    Private myOtherLevel As String
    Private myUnitId As String
    Private myCompleteUnitId As String

    Private myCountryCode As String
    Private myRepositoryCode As String

    Private myUnitTitle As String
    Private myUnitTitleType As String


    Private myUnitDateInitial As String
    Private myUnitDateFinal As String
    Private myUnitDateInitialCertainty As Boolean
    Private myUnitDateFinalCertainty As Boolean
    Private myUnitDateBulk As String

    Private myExtentBook As Integer
    Private myExtentMaco As Integer
    Private myExtentMacete As Integer
    Private myExtentFolder As Integer
    Private myExtentCover As Integer
    Private myExtentCapilha As Integer
    Private myExtentRoll As Integer
    Private myExtentBox As Integer
    Private myExtentEnvelope As Integer
    Private myExtentAlbum As Integer
    Private myExtentMl As Double
    Private myExtentLeaf As Integer
    Private myExtentPage As Integer
    Private myExtentOther As Integer

    Private myDimensions As String

    Private myGenreForm As String
    Private myGeogName As String
    Private myPhysFacet As String
    Private myPhysLoc As String

    Private myMaterialSpec As String
    Private myLangMaterial As String

    Private myOriginationScrivener As String
    Private myOriginationAuthor As String
    Private myOriginationDestination As String
    Private myOriginationAuthorAddress As String
    Private myOriginationDestinationAddress As String
    Private myOriginationNotary As String

    Private myScopeContent As String
    Private myBiogHist As String
    Private myOtherFindAid As String
    Private myOriginalNumbering As String

    Private myNote As String

    Private myRelatedMaterial As String
    Private myPhysTech As String
    Private myAcqInfo As String
    Private myArrangement As String
    Private myCustodHist As String
    Private myAltFormAvail As String
    Private myAppraisal As String
    Private myAccessRestrict As String
    Private myLegalStatus As String
    Private myAccruals As String
    Private myUseRestrict As String
    Private myOriginalsLoc As String

    Private myProcessInfoName As String
    Private myProcessInfoDate As String

    Private myPreferCite As String
    Private mySeparatedMaterial As String
    Private myAbstract As String
    Private myRepository As String

    Private myDigitalObjectID As Int64
    Private myFileID As Int64
    Private myType As Int16

    Private myDaoGrp As New DaoGrpCollection

    Private myEac As Boolean
    Private myDigitalObjectExists As Boolean
    Private myIsDSDCUI As Boolean
    Private myDOImageGOD As Boolean
    Private myNumberImages As String

    Private myBibliography As Bibliography
    Private myControlAccess As ControlAccessItem
    Private myChronList As ChronList
    Private myFilePlan As String

    Private myContainerType As String
    Private myParentID As Integer

#End Region


#Region "Gets and Sets of Public Properties"

    Public MustOverride ReadOnly Property ID() As Object

    Public Property SortBy() As SortingStyles
        Get
            Return mySortBy
        End Get
        Set(ByVal Value As SortingStyles)
            mySortBy = Value
        End Set
    End Property

    Public Property ContainerType() As String
        Get
            Return myContainerType
        End Get
        Set(ByVal Value As String)
            myContainerType = Value
        End Set
    End Property

    Public Property OriginalNumbering() As String
        Get
            Return myOriginalNumbering
        End Get
        Set(ByVal Value As String)
            myOriginalNumbering = Value
        End Set
    End Property

    Public Property Abstract() As String
        Get
            Return myAbstract
        End Get
        Set(ByVal Value As String)
            myAbstract = Value
        End Set
    End Property

    Public Property AccessRestrict() As String
        Get
            Return myAccessRestrict
        End Get
        Set(ByVal Value As String)
            myAccessRestrict = Value
        End Set
    End Property

    Public Property Accruals() As String
        Get
            Return myAccruals
        End Get
        Set(ByVal Value As String)
            myAccruals = Value
        End Set
    End Property

    Public Property AcqInfo() As String
        Get
            Return myAcqInfo
        End Get
        Set(ByVal Value As String)
            myAcqInfo = Value
        End Set
    End Property

    Public Property AltFormAvail() As String
        Get
            Return myAltFormAvail
        End Get
        Set(ByVal Value As String)
            myAltFormAvail = Value
        End Set
    End Property

    Public Property UnitDateBulk() As String
        Get
            Return myUnitDateBulk
        End Get
        Set(ByVal Value As String)
            myUnitDateBulk = Value
        End Set
    End Property

    Public Property Appraisal() As String
        Get
            Return myAppraisal
        End Get
        Set(ByVal Value As String)
            myAppraisal = Value
        End Set
    End Property

    Public Property Arrangement() As String
        Get
            Return myArrangement
        End Get
        Set(ByVal Value As String)
            myArrangement = Value
        End Set
    End Property

    Public Property Bibliography() As Bibliography
        Get
            Return myBibliography
        End Get
        Set(ByVal Value As Bibliography)
            myBibliography = Value
        End Set
    End Property

    Public Property BiogHist() As String
        Get
            Return myBiogHist
        End Get
        Set(ByVal Value As String)
            myBiogHist = Value
        End Set
    End Property

    Public Property ChronList() As ChronList
        Get
            Return myChronList
        End Get
        Set(ByVal Value As ChronList)
            myChronList = Value
        End Set
    End Property

    Public Property ControlAccess() As ControlAccessItem
        Get
            Return myControlAccess
        End Get
        Set(ByVal Value As ControlAccessItem)
            myControlAccess = Value
        End Set
    End Property

    Public Property CountryCode() As String
        Get
            Return myCountryCode
        End Get
        Set(ByVal Value As String)
            myCountryCode = Value
        End Set
    End Property

    Public Property CustodHist() As String
        Get
            Return myCustodHist
        End Get
        Set(ByVal Value As String)
            myCustodHist = Value
        End Set
    End Property

    Public Property DigitalObjectID() As Int64
        Get
            Return myDigitalObjectID
        End Get
        Set(ByVal Value As Int64)
            myDigitalObjectID = Value
        End Set
    End Property

    Public Property FileID() As Int64
        Get
            Return myFileID
        End Get
        Set(ByVal Value As Int64)
            myFileID = Value
        End Set
    End Property

    Public Property Type() As Int16
        Get
            Return myType
        End Get
        Set(ByVal Value As Int16)
            myType = Value
        End Set
    End Property

    Public Property DaoGrp() As DaoGrpCollection
        Get
            Return myDaoGrp
        End Get
        Set(ByVal Value As DaoGrpCollection)
            myDaoGrp = Value
        End Set
    End Property

    Public Property Eac() As Boolean
        Get
            Return myEac
        End Get
        Set(ByVal Value As Boolean)
            myEac = Value
        End Set
    End Property

    Public Property DigitalObjectExists() As Boolean
        Get
            Return myDigitalObjectExists
        End Get
        Set(ByVal Value As Boolean)
            myDigitalObjectExists = Value
        End Set
    End Property

    Public Property IsDSDCUI() As Boolean
        Get
            Return myIsDSDCUI
        End Get
        Set(ByVal Value As Boolean)
            myIsDSDCUI = Value
        End Set
    End Property

    Public Property DOImageGOD() As Boolean
        Get
            Return myDOImageGOD
        End Get
        Set(ByVal Value As Boolean)
            myDOImageGOD = Value
        End Set
    End Property

    Public Property NumberImages() As String
        Get
            Return myNumberImages
        End Get
        Set(ByVal Value As String)
            myNumberImages = Value
        End Set
    End Property

    Public Property Dimensions() As String
        Get
            Return myDimensions
        End Get
        Set(ByVal Value As String)
            myDimensions = Value
        End Set
    End Property

    Public Property ExtentOther() As Integer
        Get
            Return myExtentOther
        End Get
        Set(ByVal Value As Integer)
            myExtentOther = Value
        End Set
    End Property

    Public Property ExtentLeaf() As Integer
        Get
            Return myExtentLeaf
        End Get
        Set(ByVal Value As Integer)
            myExtentLeaf = Value
        End Set
    End Property

    Public Property ExtentPage() As Integer
        Get
            Return myExtentPage
        End Get
        Set(ByVal Value As Integer)
            myExtentPage = Value
        End Set
    End Property

    Public Property ExtentBook() As Integer
        Get
            Return myExtentBook
        End Get
        Set(ByVal Value As Integer)
            myExtentBook = Value
        End Set
    End Property

    Public Property ExtentBox() As Integer
        Get
            Return myExtentBox
        End Get
        Set(ByVal Value As Integer)
            myExtentBox = Value
        End Set
    End Property

    Public Property ExtentCover() As Integer
        Get
            Return myExtentCover
        End Get
        Set(ByVal Value As Integer)
            myExtentCover = Value
        End Set
    End Property

    Public Property ExtentCapilha() As Integer
        Get
            Return myExtentCapilha
        End Get
        Set(ByVal Value As Integer)
            myExtentCapilha = Value
        End Set
    End Property

    Public Property ExtentFolder() As Integer
        Get
            Return myExtentFolder
        End Get
        Set(ByVal Value As Integer)
            myExtentFolder = Value
        End Set
    End Property

    Public Property ExtentMacete() As Integer
        Get
            Return myExtentMacete
        End Get
        Set(ByVal Value As Integer)
            myExtentMacete = Value
        End Set
    End Property

    Public Property ExtentMaco() As Integer
        Get
            Return myExtentMaco
        End Get
        Set(ByVal Value As Integer)
            myExtentMaco = Value
        End Set
    End Property

    Public Property ExtentMl() As Double
        Get
            Return myExtentMl
        End Get
        Set(ByVal Value As Double)
            myExtentMl = Value
        End Set
    End Property

    Public Property ExtentRoll() As Integer
        Get
            Return myExtentRoll
        End Get
        Set(ByVal Value As Integer)
            myExtentRoll = Value
        End Set
    End Property

    Public Property ExtentEnvelope() As Integer
        Get
            Return myExtentEnvelope
        End Get
        Set(ByVal Value As Integer)
            myExtentEnvelope = Value
        End Set
    End Property

    Public Property ExtentAlbum() As Integer
        Get
            Return myExtentAlbum
        End Get
        Set(ByVal Value As Integer)
            myExtentAlbum = Value
        End Set
    End Property

    Public Property GenreForm() As String
        Get
            Return myGenreForm
        End Get
        Set(ByVal Value As String)
            myGenreForm = Value
        End Set
    End Property

    Public Property GeogName() As String
        Get
            Return myGeogName
        End Get
        Set(ByVal Value As String)
            myGeogName = Value
        End Set
    End Property

    Public Property LangMaterial() As String
        Get
            Return myLangMaterial
        End Get
        Set(ByVal Value As String)
            myLangMaterial = Value
        End Set
    End Property

    Public Property LegalStatus() As String
        Get
            Return myLegalStatus
        End Get
        Set(ByVal Value As String)
            myLegalStatus = Value
        End Set
    End Property

    Public Property MaterialSpec() As String
        Get
            Return myMaterialSpec
        End Get
        Set(ByVal Value As String)
            myMaterialSpec = Value
        End Set
    End Property

    Public Property Note() As String
        Get
            Return myNote
        End Get
        Set(ByVal Value As String)
            myNote = Value
        End Set
    End Property

    Public Property OriginalsLoc() As String
        Get
            Return myOriginalsLoc
        End Get
        Set(ByVal Value As String)
            myOriginalsLoc = Value
        End Set
    End Property

    Public Property OriginationAuthor() As String
        Get
            Return myOriginationAuthor
        End Get
        Set(ByVal Value As String)
            myOriginationAuthor = Value
        End Set
    End Property

    Public Property OriginationAuthorAddress() As String
        Get
            Return myOriginationAuthorAddress
        End Get
        Set(ByVal Value As String)
            myOriginationAuthorAddress = Value
        End Set
    End Property

    Public Property OriginationDestination() As String
        Get
            Return myOriginationDestination
        End Get
        Set(ByVal Value As String)
            myOriginationDestination = Value
        End Set
    End Property

    Public Property OriginationDestinationAddress() As String
        Get
            Return myOriginationDestinationAddress
        End Get
        Set(ByVal Value As String)
            myOriginationDestinationAddress = Value
        End Set
    End Property

    Public Property OriginationNotary() As String
        Get
            Return myOriginationNotary
        End Get
        Set(ByVal Value As String)
            myOriginationNotary = Value
        End Set
    End Property

    Public Property OriginationScrivener() As String
        Get
            Return myOriginationScrivener
        End Get
        Set(ByVal Value As String)
            myOriginationScrivener = Value
        End Set
    End Property

    Public Property OtherFindAid() As String
        Get
            Return myOtherFindAid
        End Get
        Set(ByVal Value As String)
            myOtherFindAid = Value
        End Set
    End Property

    Public Property OtherLevel() As String
        Get
            Return myOtherLevel
        End Get
        Set(ByVal Value As String)
            myOtherLevel = Value
        End Set
    End Property

    Public ReadOnly Property OtherLevelIndex() As Integer
        Get
            'Return GetOtherLevelIndex(OtherLevel)
            Return -1

        End Get
    End Property
    Public Property PhysFacet() As String
        Get
            Return myPhysFacet
        End Get
        Set(ByVal Value As String)
            myPhysFacet = Value
        End Set
    End Property

    Public Property PhysLoc() As String
        Get
            Return myPhysLoc
        End Get
        Set(ByVal Value As String)
            myPhysLoc = Value
        End Set
    End Property

    Public Property PhysTech() As String
        Get
            Return myPhysTech
        End Get
        Set(ByVal Value As String)
            myPhysTech = Value
        End Set
    End Property

    Public Property PreferCite() As String
        Get
            Return myPreferCite
        End Get
        Set(ByVal Value As String)
            myPreferCite = Value
        End Set
    End Property

    Public Property ProcessInfoDate() As String
        Get
            Return myProcessInfoDate
        End Get
        Set(ByVal Value As String)
            myProcessInfoDate = Value
        End Set
    End Property

    Public Property ProcessInfoName() As String
        Get
            Return myProcessInfoName
        End Get
        Set(ByVal Value As String)
            myProcessInfoName = Value
        End Set
    End Property

    Public Property RelatedMaterial() As String
        Get
            Return myRelatedMaterial
        End Get
        Set(ByVal Value As String)
            myRelatedMaterial = Value
        End Set
    End Property

    Public Property Repository() As String
        Get
            Return myRepository
        End Get
        Set(ByVal Value As String)
            myRepository = Value
        End Set
    End Property

    Public Property RepositoryCode() As String
        Get
            Return myRepositoryCode
        End Get
        Set(ByVal Value As String)
            myRepositoryCode = Value
        End Set
    End Property

    Public Property ScopeContent() As String
        Get
            Return myScopeContent
        End Get
        Set(ByVal Value As String)
            myScopeContent = Value
        End Set
    End Property

    Public Property SeparatedMaterial() As String
        Get
            Return mySeparatedMaterial
        End Get
        Set(ByVal Value As String)
            mySeparatedMaterial = Value
        End Set
    End Property

    Public Property UnitDateFinal() As String
        Get
            Return myUnitDateFinal
        End Get
        Set(ByVal Value As String)
            myUnitDateFinal = Value
        End Set
    End Property

    Public Property UnitDateFinalCertainty() As Boolean
        Get
            Return myUnitDateFinalCertainty
        End Get
        Set(ByVal Value As Boolean)
            myUnitDateFinalCertainty = Value
        End Set
    End Property

    Public Property UnitDateInitial() As String
        Get
            Return myUnitDateInitial
        End Get
        Set(ByVal Value As String)
            myUnitDateInitial = Value
        End Set
    End Property

    Public Property UnitDateInitialCertainty() As Boolean
        Get
            Return myUnitDateInitialCertainty
        End Get
        Set(ByVal Value As Boolean)
            myUnitDateInitialCertainty = Value
        End Set
    End Property

    Public Property UnitId() As String
        Get
            Return myUnitId
        End Get
        Set(ByVal Value As String)
            myUnitId = Value
        End Set
    End Property

    Public Property CompleteUnitId() As String
        Get
            Return myCompleteUnitId
        End Get
        Set(ByVal Value As String)
            myCompleteUnitId = Value
        End Set
    End Property

    Public Property UnitTitle() As String
        Get
            Return myUnitTitle
        End Get
        Set(ByVal Value As String)
            myUnitTitle = Value
        End Set
    End Property

    Public Property UnitTitleType() As String
        Get
            Return myUnitTitleType
        End Get
        Set(ByVal Value As String)
            myUnitTitleType = Value
        End Set
    End Property

    Public Property UseRestrict() As String
        Get
            Return myUseRestrict
        End Get
        Set(ByVal Value As String)
            myUseRestrict = Value
        End Set
    End Property

    Public Property FilePlan() As String
        Get
            Return myFilePlan
        End Get
        Set(ByVal Value As String)
            myFilePlan = Value
        End Set
    End Property

    Public Property Valid() As Boolean
        Get
            Return myValid
        End Get
        Set(ByVal Value As Boolean)
            myValid = Value
        End Set
    End Property

    Public Property Visible() As Boolean
        Get
            Return myVisible
        End Get
        Set(ByVal Value As Boolean)
            myVisible = Value
        End Set
    End Property

    Public Property ParentID() As Integer
        Get
            Return myParentID
        End Get
        Set(ByVal Value As Integer)
            myParentID = Value
        End Set
    End Property

#End Region


#Region "LazyNode MustOverridable Methods"

    ' Propagates changes TO the Data layer

    Public MustOverride Sub Download()                                  ' Propagates changes FROM the Data Layer to the cache

    Public MustOverride Function Children() As LazyNodeCollection       ' Gets a collection of its children

    Public MustOverride Function colParentsToNItself() As LazyNodeCollection

    Public MustOverride Function strFullPath() As String

    Public MustOverride Function strFullPath(ByVal colParentsToNItself As LazyNodeCollection) As String

    Public MustOverride ReadOnly Property HasChildren() As Boolean

    ' Creates a copy of the current node

#End Region


#Region "Implemented Methods "


    Public Sub ImportFields(ByVal Node As LazyNode)
        Abstract = Node.Abstract
        AccessRestrict = Node.AccessRestrict
        Accruals = Node.Accruals
        AcqInfo = Node.AcqInfo
        AltFormAvail = Node.AltFormAvail
        Appraisal = Node.Appraisal
        Arrangement = Node.Arrangement
        Bibliography = Node.Bibliography
        BiogHist = Node.BiogHist
        ChronList = Node.ChronList
        ControlAccess = Node.ControlAccess
        CountryCode = Node.CountryCode
        CustodHist = Node.CustodHist
        'DaoGrp = Node.DaoGrp
        Dimensions = Node.Dimensions
        ExtentBook = Node.ExtentBook
        ExtentCover = Node.ExtentCover
        ExtentBox = Node.ExtentBox
        ExtentCapilha = Node.ExtentCapilha
        ExtentFolder = Node.ExtentFolder
        ExtentMacete = Node.ExtentMacete
        ExtentMaco = Node.ExtentMaco
        ExtentMl = Node.ExtentMl
        ExtentRoll = Node.ExtentRoll
        GenreForm = Node.GenreForm
        GeogName = Node.GeogName
        LangMaterial = Node.LangMaterial
        LegalStatus = Node.LegalStatus
        MaterialSpec = Node.MaterialSpec
        Note = Node.Note
        OriginalNumbering = Node.OriginalNumbering
        OriginalsLoc = Node.OriginalsLoc
        OriginationAuthor = Node.OriginationAuthor
        OriginationAuthorAddress = Node.OriginationAuthorAddress
        OriginationDestination = Node.OriginationDestination
        OriginationDestinationAddress = Node.OriginationDestinationAddress
        OriginationNotary = Node.OriginationNotary
        OriginationScrivener = Node.OriginationScrivener
        OtherFindAid = Node.OtherFindAid
        OtherLevel = Node.OtherLevel
        PhysFacet = Node.PhysFacet
        PhysLoc = Node.PhysLoc
        PhysTech = Node.PhysTech
        PreferCite = Node.PreferCite
        ProcessInfoDate = Node.ProcessInfoDate
        ProcessInfoName = Node.ProcessInfoName
        RelatedMaterial = Node.RelatedMaterial
        Repository = Node.Repository
        RepositoryCode = Node.RepositoryCode
        ScopeContent = Node.ScopeContent
        SeparatedMaterial = Node.SeparatedMaterial
        UnitDateFinal = Node.UnitDateFinal
        UnitDateFinalCertainty = Node.UnitDateFinalCertainty
        UnitDateInitial = Node.UnitDateInitial
        UnitDateInitialCertainty = Node.UnitDateInitialCertainty
        UnitId = Node.UnitId
        UnitTitle = Node.UnitTitle
        UseRestrict = Node.UseRestrict
        Valid = Node.Valid
        Visible = Node.Visible
        FilePlan = Node.FilePlan
        UnitTitleType = Node.UnitTitleType
        ExtentLeaf = Node.ExtentLeaf
        ExtentPage = Node.ExtentPage
        ExtentOther = Node.ExtentOther
        UnitDateBulk = Node.UnitDateBulk
        ContainerType = Node.ContainerType
        ParentID = Node.ParentID

    End Sub


    Public Overloads Overrides Function Equals(ByVal obj As Object) As Boolean
        If Not TypeOf obj Is LazyNode Then
            Return False
        Else
            Return UnitId.Equals(CType(obj, LazyNode).UnitId)
        End If
    End Function


    ' A wrapper element for all the handled EAD Properties
    Public Property Field(ByVal FieldName As LazyNode.LazyNodeFields) As Object
        Get
            Select Case FieldName
                Case LazyNode.LazyNodeFields.Abstract : Return Abstract
                Case LazyNode.LazyNodeFields.AccessRestrict : Return AccessRestrict
                Case LazyNode.LazyNodeFields.Accruals : Return Accruals
                Case LazyNode.LazyNodeFields.AcqInfo : Return AcqInfo
                Case LazyNode.LazyNodeFields.AltFormAvail : Return AltFormAvail
                Case LazyNode.LazyNodeFields.Appraisal : Return Appraisal
                Case LazyNode.LazyNodeFields.Arrangement : Return Arrangement
                Case LazyNode.LazyNodeFields.Bibliography : Return Bibliography
                Case LazyNode.LazyNodeFields.BiogHist : Return BiogHist
                Case LazyNode.LazyNodeFields.ChronList : Return ChronList
                Case LazyNode.LazyNodeFields.ControlAccess : Return ControlAccess
                Case LazyNode.LazyNodeFields.CountryCode : Return CountryCode
                Case LazyNode.LazyNodeFields.CustodHist : Return CustodHist
                Case LazyNode.LazyNodeFields.DigitalObjectExists : Return DigitalObjectExists
                Case LazyNode.LazyNodeFields.DigitalObjectID : Return DigitalObjectID
                Case LazyNode.LazyNodeFields.Dimensions : Return Dimensions
                Case LazyNode.LazyNodeFields.ExtentBook : Return ExtentBook
                Case LazyNode.LazyNodeFields.ExtentCover : Return ExtentBox
                Case LazyNode.LazyNodeFields.ExtentBox : Return ExtentBox
                Case LazyNode.LazyNodeFields.ExtentCapilha : Return ExtentCapilha
                Case LazyNode.LazyNodeFields.ExtentFolder : Return ExtentFolder
                Case LazyNode.LazyNodeFields.ExtentMacete : Return ExtentMacete
                Case LazyNode.LazyNodeFields.ExtentMaco : Return ExtentMaco
                Case LazyNode.LazyNodeFields.ExtentMl : Return ExtentMl
                Case LazyNode.LazyNodeFields.ExtentRoll : Return ExtentRoll
                Case LazyNode.LazyNodeFields.GenreForm : Return GenreForm
                Case LazyNode.LazyNodeFields.GeogName : Return GeogName
                Case LazyNode.LazyNodeFields.LangMaterial : Return LangMaterial
                Case LazyNode.LazyNodeFields.LegalStatus : Return LegalStatus
                Case LazyNode.LazyNodeFields.MaterialSpec : Return MaterialSpec
                Case LazyNode.LazyNodeFields.Note : Return Note
                Case LazyNode.LazyNodeFields.OriginalNumbering : Return OriginalNumbering
                Case LazyNode.LazyNodeFields.OriginalsLoc : Return OriginalsLoc
                Case LazyNode.LazyNodeFields.OriginationAuthor : Return OriginationAuthor
                Case LazyNode.LazyNodeFields.OriginationAuthorAddress : Return OriginationAuthorAddress
                Case LazyNode.LazyNodeFields.OriginationDestination : Return OriginationDestination
                Case LazyNode.LazyNodeFields.OriginationDestinationAddress : Return OriginationDestinationAddress
                Case LazyNode.LazyNodeFields.OriginationNotary : Return OriginationNotary
                Case LazyNode.LazyNodeFields.OriginationScrivener : Return OriginationScrivener
                Case LazyNode.LazyNodeFields.OtherFindAid : Return OtherFindAid
                Case LazyNode.LazyNodeFields.OtherLevel : Return OtherLevel
                Case LazyNode.LazyNodeFields.OtherLevelIndex : Return OtherLevelIndex
                Case LazyNode.LazyNodeFields.PhysFacet : Return PhysFacet
                Case LazyNode.LazyNodeFields.PhysLoc : Return PhysLoc
                Case LazyNode.LazyNodeFields.PhysTech : Return PhysTech
                Case LazyNode.LazyNodeFields.PreferCite : Return PreferCite
                Case LazyNode.LazyNodeFields.ProcessInfoDate : Return ProcessInfoDate
                Case LazyNode.LazyNodeFields.ProcessInfoName : Return ProcessInfoName
                Case LazyNode.LazyNodeFields.RelatedMaterial : Return RelatedMaterial
                Case LazyNode.LazyNodeFields.Repository : Return Repository
                Case LazyNode.LazyNodeFields.RepositoryCode : Return RepositoryCode
                Case LazyNode.LazyNodeFields.ScopeContent : Return ScopeContent
                Case LazyNode.LazyNodeFields.SeparatedMaterial : Return SeparatedMaterial
                Case LazyNode.LazyNodeFields.UnitDateFinal : Return UnitDateFinal
                Case LazyNode.LazyNodeFields.UnitDateFinalCertainty : Return UnitDateFinalCertainty
                Case LazyNode.LazyNodeFields.UnitDateInitial : Return UnitDateInitial
                Case LazyNode.LazyNodeFields.UnitDateInitialCertainty : Return UnitDateInitialCertainty
                Case LazyNode.LazyNodeFields.UnitId : Return UnitId
                Case LazyNode.LazyNodeFields.UnitTitle : Return UnitTitle
                Case LazyNode.LazyNodeFields.UseRestrict : Return UseRestrict
                Case LazyNode.LazyNodeFields.Valid : Return Valid
                Case LazyNode.LazyNodeFields.Visible : Return Visible
                Case LazyNode.LazyNodeFields.FilePlan : Return FilePlan
                Case LazyNode.LazyNodeFields.UnitTitleType : Return UnitTitleType
                Case LazyNode.LazyNodeFields.ExtentPage : Return ExtentPage
                Case LazyNode.LazyNodeFields.ExtentOther : Return ExtentOther
                Case LazyNode.LazyNodeFields.ExtentLeaf : Return ExtentLeaf
                Case LazyNode.LazyNodeFields.UnitDateBulk : Return UnitDateBulk
                Case LazyNode.LazyNodeFields.ContainerType : Return ContainerType
                Case LazyNode.LazyNodeFields.ParentID : Return ParentID
            End Select
        End Get
        Set(ByVal Value As Object)
            Select Case FieldName
                Case LazyNode.LazyNodeFields.Abstract : Abstract = Value
                Case LazyNode.LazyNodeFields.AccessRestrict : AccessRestrict = Value
                Case LazyNode.LazyNodeFields.Accruals : Accruals = Value
                Case LazyNode.LazyNodeFields.AcqInfo : AcqInfo = Value
                Case LazyNode.LazyNodeFields.AltFormAvail : AltFormAvail = Value
                Case LazyNode.LazyNodeFields.Appraisal : Appraisal = Value
                Case LazyNode.LazyNodeFields.Arrangement : Arrangement = Value
                Case LazyNode.LazyNodeFields.Bibliography : Bibliography = Value
                Case LazyNode.LazyNodeFields.BiogHist : BiogHist = Value
                Case LazyNode.LazyNodeFields.ChronList : ChronList = Value
                Case LazyNode.LazyNodeFields.ControlAccess : ControlAccess = Value
                Case LazyNode.LazyNodeFields.CountryCode : CountryCode = Value
                Case LazyNode.LazyNodeFields.CustodHist : CustodHist = Value

                Case LazyNode.LazyNodeFields.Dimensions : Dimensions = Value
                Case LazyNode.LazyNodeFields.ExtentBook : If TypeOf Value Is Integer Then ExtentBook = Value Else ExtentBook = StrToInt(Value)
                Case LazyNode.LazyNodeFields.ExtentBox : If TypeOf Value Is Integer Then ExtentBox = Value Else ExtentBox = StrToInt(Value)
                Case LazyNode.LazyNodeFields.ExtentCover : If TypeOf Value Is Integer Then ExtentCover = Value Else ExtentCover = StrToInt(Value)
                Case LazyNode.LazyNodeFields.ExtentCapilha : If TypeOf Value Is Integer Then ExtentCapilha = Value Else ExtentCapilha = StrToInt(Value)
                Case LazyNode.LazyNodeFields.ExtentFolder : If TypeOf Value Is Integer Then ExtentFolder = Value Else ExtentFolder = StrToInt(Value)
                Case LazyNode.LazyNodeFields.ExtentMacete : If TypeOf Value Is Integer Then ExtentMacete = Value Else ExtentMacete = StrToInt(Value)
                Case LazyNode.LazyNodeFields.ExtentMaco : If TypeOf Value Is Integer Then ExtentMaco = Value Else ExtentMaco = StrToInt(Value)
                Case LazyNode.LazyNodeFields.ExtentMl : If TypeOf Value Is Integer Then ExtentMl = Value Else ExtentMl = StrToDbl(Value)
                Case LazyNode.LazyNodeFields.ExtentRoll : If TypeOf Value Is Integer Then ExtentRoll = Value Else ExtentRoll = StrToInt(Value)
                Case LazyNode.LazyNodeFields.GenreForm : GenreForm = Value
                Case LazyNode.LazyNodeFields.GeogName : GeogName = Value
                Case LazyNode.LazyNodeFields.LangMaterial : LangMaterial = Value
                Case LazyNode.LazyNodeFields.LegalStatus : LegalStatus = Value
                Case LazyNode.LazyNodeFields.MaterialSpec : MaterialSpec = Value
                Case LazyNode.LazyNodeFields.Note : Note = Value
                Case LazyNode.LazyNodeFields.OriginalNumbering : OriginalNumbering = Value
                Case LazyNode.LazyNodeFields.OriginalsLoc : OriginalsLoc = Value
                Case LazyNode.LazyNodeFields.OriginationAuthor : OriginationAuthor = Value
                Case LazyNode.LazyNodeFields.OriginationAuthorAddress : OriginationAuthorAddress = Value
                Case LazyNode.LazyNodeFields.OriginationDestination : OriginationDestination = Value
                Case LazyNode.LazyNodeFields.OriginationDestinationAddress : OriginationDestinationAddress = Value
                Case LazyNode.LazyNodeFields.OriginationNotary : OriginationNotary = Value
                Case LazyNode.LazyNodeFields.OriginationScrivener : OriginationScrivener = Value
                Case LazyNode.LazyNodeFields.OtherFindAid : OtherFindAid = Value
                Case LazyNode.LazyNodeFields.OtherLevel : OtherLevel = Value
                Case LazyNode.LazyNodeFields.PhysFacet : PhysFacet = Value
                Case LazyNode.LazyNodeFields.PhysLoc : PhysLoc = Value
                Case LazyNode.LazyNodeFields.PhysTech : PhysTech = Value
                Case LazyNode.LazyNodeFields.PreferCite : PreferCite = Value
                Case LazyNode.LazyNodeFields.ProcessInfoDate : ProcessInfoDate = Value
                Case LazyNode.LazyNodeFields.ProcessInfoName : ProcessInfoName = Value
                Case LazyNode.LazyNodeFields.RelatedMaterial : RelatedMaterial = Value
                Case LazyNode.LazyNodeFields.Repository : Repository = Value
                Case LazyNode.LazyNodeFields.RepositoryCode : RepositoryCode = Value
                Case LazyNode.LazyNodeFields.ScopeContent : ScopeContent = Value
                Case LazyNode.LazyNodeFields.SeparatedMaterial : SeparatedMaterial = Value
                Case LazyNode.LazyNodeFields.UnitDateFinal : UnitDateFinal = Value
                Case LazyNode.LazyNodeFields.UnitDateFinalCertainty : UnitDateFinalCertainty = Value
                Case LazyNode.LazyNodeFields.UnitDateInitial : UnitDateInitial = Value
                Case LazyNode.LazyNodeFields.UnitDateInitialCertainty : UnitDateInitialCertainty = Value
                Case LazyNode.LazyNodeFields.UnitId : UnitId = Value
                Case LazyNode.LazyNodeFields.UnitTitle : UnitTitle = Value
                Case LazyNode.LazyNodeFields.UseRestrict : UseRestrict = Value
                Case LazyNode.LazyNodeFields.Valid : Valid = Value
                Case LazyNode.LazyNodeFields.Visible : Visible = Value
                Case LazyNode.LazyNodeFields.FilePlan : FilePlan = Value
                Case LazyNode.LazyNodeFields.UnitTitleType : UnitTitleType = Value
                Case LazyNode.LazyNodeFields.ParentID : ParentID = Value
                Case LazyNode.LazyNodeFields.ExtentPage : ExtentPage = Value
                Case LazyNode.LazyNodeFields.ExtentLeaf : ExtentLeaf = Value
                Case LazyNode.LazyNodeFields.ExtentOther : ExtentOther = Value
                Case LazyNode.LazyNodeFields.UnitDateBulk : UnitDateBulk = Value
                Case LazyNode.LazyNodeFields.ContainerType : ContainerType = Value
            End Select
        End Set
    End Property


    Public Function Catamorphism(ByVal Gene As Gene) As Object           ' Used for traversals
        Dim Child As LazyNode
        Dim ChildrenResults As New Collection

        For Each Child In Children()
            ChildrenResults.Add(Child.Catamorphism(Gene))
        Next
        Return Gene.Apply(Me, ChildrenResults)
    End Function


    Public Function StopableCatamorphism(ByVal Gene As StopableGene) As Object           ' Used for traversals
        Dim Child As LazyNode
        Dim ChildrenResults As New Collection

        For Each Child In Children()
            If Not Gene.StopCatamorfism Then
                ChildrenResults.Add(Child.StopableCatamorphism(Gene))
            End If
        Next
        Return Gene.Apply(Me, ChildrenResults)
    End Function


    Public Function isLeaf() As Boolean
        Return Not HasChildren
    End Function
    
#End Region


End Class


'****************************************************************
'* Gene inteface used for catamorphisms
'****************************************************************
Public Interface Gene
    Function Apply(ByVal obj As LazyNode, ByVal ChildrenResults As Collection) As Object
End Interface


Public MustInherit Class StopableGene
    Private myStopCatamorfism As Boolean = False

    Public Property StopCatamorfism() As Boolean
        Get
            Return myStopCatamorfism
        End Get
        Set(ByVal Value As Boolean)
            myStopCatamorfism = Value
        End Set
    End Property

    Public MustOverride Function Apply(ByVal obj As LazyNode, ByVal ChildrenResults As Collection) As Object


End Class







