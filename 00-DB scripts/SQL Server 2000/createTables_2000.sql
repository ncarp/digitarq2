SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[KindActionNot](
	[KindActionNotCode] [int] IDENTITY(1,1) NOT NULL,
	[KindActionNot] [nvarchar](50) NULL,
 CONSTRAINT [PK_KindActionNot] PRIMARY KEY CLUSTERED 
(
	[KindActionNotCode] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[MsgCategories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[Category] [nvarchar](100) NULL,
 CONSTRAINT [PK_MsgCategories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[RevisionInterval](
	[RevisionIntervalID] [int] IDENTITY(1,1) NOT NULL,
	[RevisionValue] [int] NULL,
 CONSTRAINT [PK_RevisionInterval] PRIMARY KEY CLUSTERED 
(
	[RevisionIntervalID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[Employees](
	[UserName] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Obs] [nvarchar](100) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[KindActionPrc](
	[KindActionPrcCode] [int] IDENTITY(1,1) NOT NULL,
	[KindActionPrc] [nvarchar](50) NULL,
 CONSTRAINT [PK_KindActionPrc] PRIMARY KEY CLUSTERED 
(
	[KindActionPrcCode] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[TypesEntryExit](
	[TypeEntryExitCode] [nvarchar](20) NOT NULL,
	[TypeEntryExit] [nvarchar](50) NULL,
 CONSTRAINT [PK_TypesEntryExit] PRIMARY KEY CLUSTERED 
(
	[TypeEntryExitCode] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[Components](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ParentID] [bigint] NULL,
	[ParentFondsID] [bigint] NULL,
	[Visible] [bit] NOT NULL,
	[Valid] [bit] NOT NULL,
	[Available] [bit] NULL,
	[HasChildren] [bit] NOT NULL,
	[TakenBy] [varchar](100) NULL,
	[OtherLevel] [varchar](10) NOT NULL,
	[UnitId] [varchar](100) NULL,
	[CompleteUnitId] [varchar](1000) NULL,
	[CountryCode] [varchar](3) NULL,
	[RepositoryCode] [varchar](10) NULL,
	[UnitTitle] [varchar](1000) NULL,
	[UnitTitleType] [varchar](100) NULL,
	[UnitDateInitial] [varchar](10) NULL,
	[UnitDateInitialCertainty] [bit] NULL,
	[UnitDateFinal] [varchar](10) NULL,
	[UnitDateFinalCertainty] [bit] NULL,
	[UnitDateBulk] [ntext] NULL,
	[ExtentBook] [int] NULL,
	[ExtentMaco] [int] NULL,
	[ExtentMacete] [int] NULL,
	[ExtentFolder] [int] NULL,
	[ExtentCover] [int] NULL,
	[ExtentCapilha] [int] NULL,
	[ExtentRoll] [int] NULL,
	[ExtentBox] [int] NULL,
	[ExtentAlbum] [int] NULL,
	[ExtentEnvelope] [int] NULL,
	[ExtentOther] [int] NULL,
	[ExtentPage] [int] NULL,
	[ExtentLeaf] [int] NULL,
	[ExtentMl] [float] NULL,
	[Dimensions] [ntext] NULL,
	[GenreForm] [ntext] NULL,
	[GeogName] [ntext] NULL,
	[PhysFacet] [ntext] NULL,
	[PhysLoc] [ntext] NULL,
	[MaterialSpec] [ntext] NULL,
	[LangMaterial] [ntext] NULL,
	[OriginationAuthor] [ntext] NULL,
	[OriginationDestination] [ntext] NULL,
	[OriginationAuthorAddress] [ntext] NULL,
	[OriginationDestinationAddress] [ntext] NULL,
	[OriginationScrivener] [ntext] NULL,
	[OriginationNotary] [ntext] NULL,
	[ScopeContent] [ntext] NULL,
	[BiogHist] [ntext] NULL,
	[OtherFindAid] [ntext] NULL,
	[OriginalNumbering] [ntext] NULL,
	[Note] [ntext] NULL,
	[RelatedMaterial] [ntext] NULL,
	[PhysTech] [ntext] NULL,
	[AcqInfo] [ntext] NULL,
	[Arrangement] [ntext] NULL,
	[CustodHist] [ntext] NULL,
	[AltFormAvail] [ntext] NULL,
	[Appraisal] [ntext] NULL,
	[AccessRestrict] [ntext] NULL,
	[LegalStatus] [ntext] NULL,
	[Accruals] [ntext] NULL,
	[UseRestrict] [ntext] NULL,
	[OriginalsLoc] [ntext] NULL,
	[ProcessInfoName] [ntext] NULL,
	[ProcessInfoDate] [varchar](10) NULL,
	[ProcessInfo] [nvarchar](3000) NULL,
	[DescRules] [nvarchar](3000) NULL,
	[PreferCite] [nvarchar](3000) NULL,
	[SeparatedMaterial] [ntext] NULL,
	[Abstract] [ntext] NULL,
	[Repository] [ntext] NULL,
	[FilePlan] [ntext] NULL,
	[ContainerType] [ntext] NULL,
	[ContainerCustomType] [ntext] NULL,
	[AllowUnitDatesInference] [bit] NULL,
	[AllowExtentsInference] [bit] NULL,
 CONSTRAINT [PK_Components] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[EmployeesGOD](
	[ID_Employee] [bigint] IDENTITY(1,1) NOT NULL,
	[CaptureEntityIndividual] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Functionary] PRIMARY KEY CLUSTERED 
(
	[ID_Employee] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[TechnologicalPlatform](
	[TPlatformID] [int] IDENTITY(1,1) NOT NULL,
	[ScannerModelName] [nvarchar](100) NULL,
	[DeviceSource] [nvarchar](100) NULL,
	[ScannerManufacturer] [nvarchar](100) NULL,
	[ScanningSoftware] [nvarchar](100) NULL,
	[ScanningSoftwareVersionNo] [nvarchar](50) NULL,
	[OperatingSystem] [nvarchar](100) NULL,
	[OperatingSystemVersion] [nvarchar](50) NULL,
 CONSTRAINT [PK_TechnologicalPlatform] PRIMARY KEY CLUSTERED 
(
	[TPlatformID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[ImageResolution](
	[idResolution] [int] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](200) NULL,
	[value] [int] NOT NULL,
 CONSTRAINT [PK_Resolution] PRIMARY KEY CLUSTERED 
(
	[idResolution] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[TypesCertificate](
	[TypeCertificateCode] [int] NOT NULL,
	[TypeCertificate] [nvarchar](100) NULL,
 CONSTRAINT [PK_CertificateType] PRIMARY KEY CLUSTERED 
(
	[TypeCertificateCode] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[TypesReproduction](
	[TypeReproductionCode] [int] NOT NULL,
	[TypeReproduction] [nvarchar](50) NULL,
 CONSTRAINT [PK_CopyType] PRIMARY KEY CLUSTERED 
(
	[TypeReproductionCode] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[ReformattingMethods](
	[ReformattingMethodID] [int] IDENTITY(1,1) NOT NULL,
	[ReformattingMethod] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](2000) NULL,
 CONSTRAINT [PK_ReformattingMethods] PRIMARY KEY CLUSTERED 
(
	[ReformattingMethodID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[ReformattingNorms](
	[ReformattingNormID] [int] IDENTITY(1,1) NOT NULL,
	[ReformattingNorm] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](2000) NULL,
 CONSTRAINT [PK_ReformattingNorms] PRIMARY KEY CLUSTERED 
(
	[ReformattingNormID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[ControlAccessTypes](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](8000) NOT NULL,
 CONSTRAINT [PK_ControlAccessTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[Categories](
	[CategoryID] [smallint] IDENTITY(1,1) NOT NULL,
	[Category] [nvarchar](50) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[Countries](
	[CountryCode] [int] NOT NULL,
	[Country] [nvarchar](100) NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryCode] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[Professions](
	[ProfessionID] [int] IDENTITY(1,1) NOT NULL,
	[Profession] [nvarchar](100) NULL,
 CONSTRAINT [PK_Profession] PRIMARY KEY CLUSTERED 
(
	[ProfessionID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[WorkAreas](
	[WorkAreaID] [int] IDENTITY(1,1) NOT NULL,
	[WorkArea] [nvarchar](100) NULL,
 CONSTRAINT [PK_AreaWork] PRIMARY KEY CLUSTERED 
(
	[WorkAreaID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[DigitalizationProfiles](
	[ProfileID] [int] IDENTITY(1,1) NOT NULL,
	[ProfileName] [varchar](50) NOT NULL,
	[Description] [nvarchar](300) NULL,
	[Resolution] [nvarchar](10) NULL,
	[BitDepth] [nvarchar](10) NULL,
	[Format] [nvarchar](100) NULL,
	[Compression] [nvarchar](20) NULL,
	[Rotation] [bit] NULL,
	[Brightness] [varchar](50) NULL,
	[Contrast] [varchar](50) NULL,
	[Sharpness] [varchar](50) NULL,
	[Blur] [varchar](50) NULL,
 CONSTRAINT [PK_DigitalizationProfile_IdProfile] PRIMARY KEY CLUSTERED 
(
	[ProfileID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[Aplications](
	[AplicationCode] [nvarchar](50) NOT NULL,
	[AplicationName] [nvarchar](50) NULL,
	[Version] [nvarchar](20) NULL,
 CONSTRAINT [PK_Aplicactions] PRIMARY KEY CLUSTERED 
(
	[AplicationCode] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[AcademicsHab](
	[AcademicsHabID] [int] IDENTITY(1,1) NOT NULL,
	[AcademicsHab] [nvarchar](100) NULL,
 CONSTRAINT [PK_AcademicalHab] PRIMARY KEY CLUSTERED 
(
	[AcademicsHabID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[ActivityAreas](
	[ActivityAreaID] [int] IDENTITY(1,1) NOT NULL,
	[ActivityArea] [nvarchar](100) NULL,
 CONSTRAINT [PK_ActivityAreas] PRIMARY KEY CLUSTERED 
(
	[ActivityAreaID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[AutoFocus](
	[AutoFocusID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_AutoFocus] PRIMARY KEY CLUSTERED 
(
	[AutoFocusID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[MeteringModes](
	[MeteringModeID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_MeteringModes] PRIMARY KEY CLUSTERED 
(
	[MeteringModeID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[LampType](
	[LampTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_LampType] PRIMARY KEY CLUSTERED 
(
	[LampTypeID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[EAC](
	[FondsID] [bigint] NOT NULL,
	[Type] [varchar](100) NULL,
	[SysKey] [varchar](100) NULL,
	[CountryCode] [varchar](100) NULL,
	[OwnerCode] [varchar](100) NULL,
	[Part] [varchar](8000) NULL,
	[UseDate] [varchar](100) NULL,
	[DetailLevel] [varchar](50) NULL,
	[BiogHist] [varchar](8000) NULL,
	[Place] [varchar](8000) NULL,
	[LegalStatus] [varchar](200) NULL,
	[LegalId] [varchar](200) NULL,
	[FunActDesc] [varchar](8000) NULL,
	[AssetStruct] [varchar](8000) NULL,
	[Env] [varchar](8000) NULL,
	[Rules] [varchar](8000) NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_EAC] PRIMARY KEY CLUSTERED 
(
	[FondsID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[ConsultationRequest](
	[ConsultationRequestID] [bigint] NOT NULL,
	[ReferenceDigitarq] [nvarchar](100) NULL,
 CONSTRAINT [PK_ConsultationRequest] PRIMARY KEY CLUSTERED 
(
	[ConsultationRequestID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[EventsProfiles](
	[EventID] [bigint] NOT NULL,
	[ProfileID] [smallint] NOT NULL,
 CONSTRAINT [PK_EventsProfiles] PRIMARY KEY CLUSTERED 
(
	[EventID] ASC,
	[ProfileID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[ReservationRequest](
	[ReservationRequestID] [bigint] NOT NULL,
	[ReferenceDigitarq] [nvarchar](100) NULL,
	[ReserveDate] [datetime] NULL,
	[PartDay] [char](1) NULL,
 CONSTRAINT [PK_ReserveRequest] PRIMARY KEY CLUSTERED 
(
	[ReservationRequestID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[Tasks](
	[TaskID] [bigint] NOT NULL,
	[Type] [int] NULL,
	[Note] [nvarchar](200) NULL,
 CONSTRAINT [PK_Budgets] PRIMARY KEY CLUSTERED 
(
	[TaskID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[Correspondence](
	[CorrespondenceID] [bigint] NOT NULL,
	[ManualEntryExitID] [bigint] IDENTITY(1,1) NOT NULL,
	[ParentID] [bigint] NULL,
	[TypeEntryExitCode] [nvarchar](20) NULL,
	[DocumentDate] [nvarchar](20) NULL,
	[ProvDest] [nvarchar](100) NULL,
	[Reference] [nvarchar](50) NULL,
	[Subject] [nvarchar](100) NULL,
	[Note] [nvarchar](200) NULL,
 CONSTRAINT [PK_Correspondence] PRIMARY KEY CLUSTERED 
(
	[CorrespondenceID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[ReproductionRequest](
	[ReproductionRequestID] [bigint] NOT NULL,
	[ReferenceDigitarq] [nvarchar](200) NULL,
	[Search] [bit] NULL,
	[Reproduction] [bit] NULL,
	[TypeReproductionCode] [int] NULL,
	[Certificate] [bit] NULL,
	[TypeCertificateCode] [int] NULL,
	[Destination] [nvarchar](100) NULL,
	[RedutionsCosts] [nvarchar](100) NULL,
	[NumberCopies] [int] NULL,
	[AdditionalInformation] [nvarchar](1000) NULL,
	[RequestSubTypeCode] [tinyint] NULL,
 CONSTRAINT [PK_ReproductionRequest] PRIMARY KEY CLUSTERED 
(
	[ReproductionRequestID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[TaskDetails](
	[TaskID] [bigint] NOT NULL,
	[ServiceID] [smallint] NOT NULL,
	[UnitPrice] [float] NULL,
	[Quantity] [smallint] NULL,
	[Discount] [real] NULL,
	[Attached] [image] NULL,
	[AttachedName] [nchar](300) NULL,
	[AttachedType] [nchar](200) NULL,
	[AttachedLength] [bigint] NULL,
 CONSTRAINT [PK_BudgetDetails] PRIMARY KEY CLUSTERED 
(
	[TaskID] ASC,
	[ServiceID] ASC
)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[OtherRequest](
	[OtherRequestID] [bigint] NOT NULL,
	[Fonds] [text] NULL,
	[Name] [nvarchar](100) NULL,
	[TermsWords] [nvarchar](100) NULL,
	[Document] [nvarchar](100) NULL,
	[Localities] [nvarchar](100) NULL,
	[InitialDate] [nvarchar](10) NULL,
	[FinalDate] [nvarchar](10) NULL,
 CONSTRAINT [PK_OtherRequest] PRIMARY KEY CLUSTERED 
(
	[OtherRequestID] ASC
)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[ParochialRequest](
	[ParochialRequestID] [bigint] NOT NULL,
	[KindActionPrcCode] [int] NULL,
	[Address] [nvarchar](100) NULL,
	[Region] [nvarchar](100) NULL,
	[Name] [nvarchar](100) NULL,
	[FiliationFather] [nvarchar](100) NULL,
	[FiliationMather] [nvarchar](100) NULL,
	[Spouse] [nvarchar](100) NULL,
	[SeatNumber] [nvarchar](50) NULL,
	[SeatYear] [int] NULL,
	[PageNumber] [nvarchar](50) NULL,
	[InitialDate] [nvarchar](10) NULL,
	[FinalDate] [nvarchar](10) NULL,
 CONSTRAINT [PK_ParochialRequest] PRIMARY KEY CLUSTERED 
(
	[ParochialRequestID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[NotaryRequest](
	[NotaryRequestID] [bigint] NOT NULL,
	[KindActionNotCode] [int] NULL,
	[Notary] [nvarchar](100) NULL,
	[CartoryNumber] [nvarchar](50) NULL,
	[Locality] [nvarchar](100) NULL,
	[ParticipantsAction] [nvarchar](500) NULL,
	[PageNumber] [nvarchar](50) NULL,
	[InitialDate] [nvarchar](10) NULL,
	[FinalDate] [nvarchar](10) NULL,
 CONSTRAINT [PK_NotaryRequest] PRIMARY KEY CLUSTERED 
(
	[NotaryRequestID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[ProfileFunction](
	[ProfileID] [smallint] NOT NULL,
	[FunctionCode] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ProfileFunction] PRIMARY KEY CLUSTERED 
(
	[ProfileID] ASC,
	[FunctionCode] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[Projects](
	[ProjectID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Location] [nvarchar](100) NULL,
	[Description] [nvarchar](2000) NULL,
	[CreationDateTime] [nvarchar](20) NOT NULL,
	[LastUpdateDateTime] [nvarchar](20) NOT NULL,
	[UserName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[ProjectID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[Events](
	[EventID] [bigint] IDENTITY(10000,1) NOT NULL,
	[EntryExitID] [bigint] NULL,
	[DerivedFrom] [bigint] NULL,
	[SourceEventID] [bigint] NULL,
	[EntryExit] [bit] NULL,
	[EventDate] [datetime] NOT NULL,
	[EventCode] [int] NULL,
	[SourceEventCode] [int] NULL,
	[Status] [int] NULL,
	[Classification] [nvarchar](50) NULL,
	[NoteToNext] [nvarchar](1500) NULL,
	[Notification] [nvarchar](1000) NULL,
	[UserID] [int] NULL,
	[EmployeeID] [nvarchar](50) NULL,
	[ProcessID] [bigint] NULL,
 CONSTRAINT [PK_RequestType] PRIMARY KEY CLUSTERED 
(
	[EventID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[Logs](
	[LogID] [bigint] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[Date] [datetime] NULL,
	[UserName] [nvarchar](50) NULL,
	[FunctionCode] [nvarchar](50) NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[DOFiles](
	[FileID] [bigint] IDENTITY(1,1) NOT NULL,
	[DigitalObjectID] [bigint] NOT NULL,
	[CreationDateTime] [nvarchar](20) NULL,
	[Name] [nvarchar](100) NOT NULL,
	[TPlatformID] [int] NULL,
	[ColorSpace] [nvarchar](100) NULL,
	[LampTypeID] [int] NULL,
	[ImageWidth] [nvarchar](10) NULL,
	[ImageHeight] [nvarchar](10) NULL,
	[Resolution] [nvarchar](10) NULL,
	[BitDepth] [int] NULL,
	[Compression] [nvarchar](50) NULL,
	[MIMEType] [nvarchar](100) NULL,
	[FNumber] [nvarchar](100) NULL,
	[ExposureTime] [nvarchar](100) NULL,
	[MeteringModeID] [int] NULL,
	[Focallength] [nvarchar](100) NULL,
	[AutoFocusID] [int] NULL,
	[CheckSumCreationDateTime] [nvarchar](20) NULL,
	[CheckSumValue] [nvarchar](256) NULL,
	[ImageSize] [bigint] NULL,
	[ProfileID] [int] NULL,
	[ProcessingDateTime] [nvarchar](20) NULL,
	[ProcessingActions] [nvarchar](1000) NULL,
	[ProcessingSoftwareName] [nvarchar](200) NULL,
	[ProcessingSoftwareVersion] [nvarchar](200) NULL,
	[ProcessingOSName] [nvarchar](200) NULL,
	[ProcessingOSVersion] [nvarchar](200) NULL,
	[ColorManager] [nvarchar](200) NULL,
	[Image] [image] NULL,
	[Thumb] [image] NULL,
	[UserName] [nvarchar](50) NULL,
 CONSTRAINT [PK_DOFiles] PRIMARY KEY CLUSTERED 
(
	[FileID] ASC
)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[Processes](
	[ProcessID] [bigint] IDENTITY(1,1) NOT NULL,
	[OtherProcessID] [int] NULL,
	[ProcessType] [tinyint] NULL,
	[Classification] [nvarchar](50) NULL,
	[Subject] [nvarchar](200) NULL,
	[FolderID] [nvarchar](100) NULL,
	[InitialDate] [nvarchar](50) NULL,
	[FinalDate] [nvarchar](50) NULL,
	[EmployeeID] [nvarchar](50) NULL,
	[UserID] [int] NULL,
 CONSTRAINT [PK_Processes] PRIMARY KEY CLUSTERED 
(
	[ProcessID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[BudgetEmployee](
	[BudgetID] [bigint] NOT NULL,
	[EmployeeID] [nvarchar](50) NOT NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_BudgetEmployee] PRIMARY KEY CLUSTERED 
(
	[BudgetID] ASC,
	[EmployeeID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[AplicationEmployee](
	[AplicationCode] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[ProfileID] [smallint] NULL,
 CONSTRAINT [PK_AplicationEmployee] PRIMARY KEY CLUSTERED 
(
	[AplicationCode] ASC,
	[UserName] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[DigitalObjects](
	[DigitalObjectID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProjectID] [bigint] NULL,
	[Name] [nvarchar](100) NOT NULL,
	[OriginalName] [nvarchar](200) NULL,
	[ArchiveID] [nvarchar](100) NULL,
	[ArchivingProfile] [nvarchar](1200) NULL,
	[CaptureEntityCorporate] [nvarchar](100) NULL,
	[ResponsabilityEntity] [nvarchar](100) NULL,
	[CreationDateTime] [nvarchar](20) NULL,
	[ArchiveDateTime] [nvarchar](20) NULL,
	[DepositDateTime] [nvarchar](20) NULL,
	[RevisionDateTime] [nvarchar](20) NULL,
	[ExternalDescriptiveInformation] [nvarchar](1100) NULL,
	[PreservationOriginalInformation] [nvarchar](1100) NULL,
	[QuantityOfTerminalObjects] [int] NULL,
	[TopographicalQuota] [nvarchar](100) NULL,
	[Structure] [ntext] NULL,
	[UserName] [nvarchar](50) NULL,
	[Active] [int] NULL,
 CONSTRAINT [PK_DigitalObjects_IdDigitalObject] PRIMARY KEY CLUSTERED 
(
	[DigitalObjectID] ASC
)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[Messages](
	[MessageID] [int] IDENTITY(1,1) NOT NULL,
	[MessageTitle] [nvarchar](50) NULL,
	[Message] [nvarchar](2000) NULL,
	[MsgCategoryID] [int] NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[DaoGrp](
	[ComponentID] [bigint] NOT NULL,
	[DigitalObjectID] [bigint] NOT NULL,
	[FileID] [bigint] NOT NULL,
	[Type] [char](10) NULL,
 CONSTRAINT [PK_DaoGrp] PRIMARY KEY CLUSTERED 
(
	[ComponentID] ASC,
	[DigitalObjectID] ASC,
	[FileID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[Notes](
	[NoteID] [int] IDENTITY(1,1) NOT NULL,
	[NoteTitle] [nvarchar](200) NULL,
	[NoteDate] [nvarchar](20) NULL,
	[Note] [nvarchar](2000) NULL,
	[UserID] [int] NULL,
 CONSTRAINT [PK_Notes] PRIMARY KEY CLUSTERED 
(
	[NoteID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[ArchivistNotes](
	[NoteID] [int] IDENTITY(1,1) NOT NULL,
	[NoteTitle] [nvarchar](200) NULL,
	[Note] [nvarchar](1000) NULL,
	[NoteDate] [nvarchar](10) NULL,
	[ComponentID] [bigint] NULL,
	[Username] [nvarchar](50) NULL,
 CONSTRAINT [PK_ArchivistNotes] PRIMARY KEY CLUSTERED 
(
	[NoteID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[Bibliography](
	[ComponentID] [bigint] NOT NULL,
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[BibRef] [varchar](8000) NOT NULL,
 CONSTRAINT [PK_Bibliography] PRIMARY KEY CLUSTERED 
(
	[ComponentID] ASC,
	[ID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[ControlAccessItemsFonds](
	[ComponentID] [bigint] NOT NULL,
	[ItemID] [bigint] NOT NULL,
 CONSTRAINT [PK_ControlAccessItemsFonds] PRIMARY KEY CLUSTERED 
(
	[ComponentID] ASC,
	[ItemID] ASC
)
) ON [PRIMARY]


;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[ControlAccess](
	[ComponentID] [bigint] NOT NULL,
	[ItemID] [bigint] NOT NULL,
 CONSTRAINT [PK_ControlAccess] PRIMARY KEY CLUSTERED 
(
	[ComponentID] ASC,
	[ItemID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[ChronList](
	[ComponentID] [bigint] NOT NULL,
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Date] [varchar](8000) NOT NULL,
	[Event] [varchar](8000) NOT NULL,
 CONSTRAINT [PK_ChronList] PRIMARY KEY CLUSTERED 
(
	[ComponentID] ASC,
	[ID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[Attacheds](
	[AttachedID] [int] IDENTITY(1,1) NOT NULL,
	[Attached] [image] NULL,
	[FileName] [nvarchar](300) NULL,
	[ContentType] [nvarchar](200) NULL,
	[ContentLength] [int] NULL,
	[CorrespondenceID] [bigint] NULL,
 CONSTRAINT [PK_Attacheds] PRIMARY KEY CLUSTERED 
(
	[AttachedID] ASC
)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[PreservationAction](
	[PreservationActionID] [int] IDENTITY(1,1) NOT NULL,
	[ArchiveNextDateTime] [nvarchar](20) NULL,
	[RevisionDateTime] [nvarchar](20) NULL,
	[Transformer] [nvarchar](100) NULL,
	[Platform] [nvarchar](100) NULL,
	[RenderEngine] [nvarchar](100) NULL,
	[InputFormat] [nvarchar](100) NULL,
	[Parameters] [nvarchar](2000) NULL,
	[ReformattingMethodID] [int] NULL,
	[DigitalObjectID] [bigint] NULL,
 CONSTRAINT [PK_PreservationInfo] PRIMARY KEY CLUSTERED 
(
	[PreservationActionID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[PreservationNorms](
	[PreservationActionID] [int] NOT NULL,
	[ReformattingNormID] [int] NOT NULL,
 CONSTRAINT [PK_MethodsNorms] PRIMARY KEY CLUSTERED 
(
	[PreservationActionID] ASC,
	[ReformattingNormID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[ControlAccessItems](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TypeID] [bigint] NOT NULL,
	[Item] [varchar](8000) NOT NULL,
 CONSTRAINT [PK_ControlAccessItems] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[Emoluments](
	[EmolumentID] [int] IDENTITY(1,1) NOT NULL,
	[EmolumentDate] [nvarchar](20) NULL,
	[ReceiptNumber] [bigint] NULL,
	[IVA] [smallint] NULL,
	[Cost] [float] NULL,
	[CertificateNumber] [bigint] NULL,
	[Exemption] [nvarchar](100) NULL,
	[Note] [nvarchar](100) NULL,
	[CategoryID] [smallint] NULL,
 CONSTRAINT [PK_Emoluments] PRIMARY KEY CLUSTERED 
(
	[EmolumentID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[Services](
	[ServiceID] [smallint] IDENTITY(1,1) NOT NULL,
	[Service] [nvarchar](50) NULL,
	[UnitPrice] [float] NULL,
	[CategoryID] [smallint] NULL,
 CONSTRAINT [PK_ReproductionTypes] PRIMARY KEY CLUSTERED 
(
	[ServiceID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1000,1) NOT NULL,
	[UserType] [tinyint] NULL,
	[FullName] [nvarchar](50) NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Sex] [char](1) NULL,
	[BirthDate] [nvarchar](20) NULL,
	[Institution] [nvarchar](100) NULL,
	[HomePhone] [nvarchar](20) NULL,
	[MobilePhone] [nvarchar](20) NULL,
	[Fax] [nvarchar](20) NULL,
	[Email] [nvarchar](100) NULL,
	[Address] [nvarchar](200) NULL,
	[Locality] [nvarchar](75) NULL,
	[PostalCode] [nvarchar](20) NULL,
	[CountryCode] [int] NULL,
	[Nationality] [nvarchar](75) NULL,
	[IdentityCard] [nvarchar](50) NULL,
	[ContributorNumber] [nvarchar](50) NULL,
	[ProfessionID] [int] NULL,
	[WorkAreaID] [int] NULL,
	[ActivityAreaID] [int] NULL,
	[AcademicsHabID] [int] NULL,
 CONSTRAINT [PK_UsersCRAV] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[Functions](
	[FunctionCode] [nvarchar](50) NOT NULL,
	[ParentCode] [nvarchar](50) NULL,
	[FunctionName] [nvarchar](50) NOT NULL,
	[AplicationCode] [nvarchar](50) NULL,
 CONSTRAINT [PK_Functions] PRIMARY KEY CLUSTERED 
(
	[FunctionCode] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[Profiles](
	[ProfileID] [smallint] IDENTITY(1,1) NOT NULL,
	[Profile] [nvarchar](50) NULL,
	[AplicationCode] [nvarchar](50) NULL,
 CONSTRAINT [PK_Profiles] PRIMARY KEY CLUSTERED 
(
	[ProfileID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[EacLanguageDecl](
	[EacID] [bigint] NOT NULL,
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Language] [varchar](100) NULL,
 CONSTRAINT [PK_EacLanguageDecl] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[EacID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[EacResourceRelationships](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[EacID] [bigint] NOT NULL,
	[Type] [varchar](50) NULL,
	[ResourceType] [varchar](50) NULL,
	[Unit] [varchar](8000) NULL,
	[Date] [varchar](50) NULL,
 CONSTRAINT [PK_EacBibliographicRelationships] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[EacID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[EacArchRelationships](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[EacID] [bigint] NOT NULL,
	[Type] [varchar](500) NULL,
	[Date] [varchar](50) NULL,
	[UnitId] [varchar](500) NULL,
	[UnitDateInitial] [varchar](10) NULL,
	[UnitDateFinal] [varchar](10) NULL,
	[UnitTitle] [varchar](800) NULL,
	[Repository] [varchar](800) NULL,
	[DescNote] [varchar](800) NULL,
 CONSTRAINT [PK_EacFondsRelationships] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[EacID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[EacIdentity](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[EacID] [bigint] NOT NULL,
	[Part] [varchar](8000) NULL,
	[UseDate] [varchar](50) NULL,
	[Type] [varchar](50) NULL,
 CONSTRAINT [PK_EacIdentity] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[EacID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[EacRelationships](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[EacID] [bigint] NOT NULL,
	[Type] [varchar](100) NULL,
	[Name] [varchar](500) NULL,
	[Date] [varchar](10) NULL,
	[Place] [varchar](500) NULL,
	[DescNote] [varchar](8000) NULL,
	[EacType] [varchar](50) NULL,
 CONSTRAINT [PK_EacRelationships] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[EacID] ASC
)
) ON [PRIMARY]

;
SET ANSI_NULLS ON
;
SET QUOTED_IDENTIFIER ON
;
CREATE TABLE [dbo].[EacMaintenanceHistory](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[EacID] [bigint] NOT NULL,
	[MainType] [varchar](50) NULL,
	[MainName] [varchar](500) NULL,
	[MainDate] [varchar](50) NULL,
	[MainDesc] [varchar](8000) NULL,
 CONSTRAINT [PK_EACMaintenanceHistory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC,
	[EacID] ASC
)
) ON [PRIMARY]

;
ALTER TABLE [dbo].[ConsultationRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_ConsultationRequest_Request] FOREIGN KEY([ConsultationRequestID])
REFERENCES [dbo].[Events] ([EventID])
ON DELETE CASCADE
;
ALTER TABLE [dbo].[ConsultationRequest] CHECK CONSTRAINT [FK_ConsultationRequest_Request]
;
ALTER TABLE [dbo].[EventsProfiles]  WITH NOCHECK ADD  CONSTRAINT [FK_EventsProfiles_Events] FOREIGN KEY([EventID])
REFERENCES [dbo].[Events] ([EventID])
ON DELETE CASCADE
;
ALTER TABLE [dbo].[EventsProfiles] CHECK CONSTRAINT [FK_EventsProfiles_Events]
;
ALTER TABLE [dbo].[EventsProfiles]  WITH CHECK ADD  CONSTRAINT [FK_EventsProfiles_Profiles] FOREIGN KEY([ProfileID])
REFERENCES [dbo].[Profiles] ([ProfileID])
;
ALTER TABLE [dbo].[ReservationRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_ReserveRequest_Request] FOREIGN KEY([ReservationRequestID])
REFERENCES [dbo].[Events] ([EventID])
ON DELETE CASCADE
;
ALTER TABLE [dbo].[ReservationRequest] CHECK CONSTRAINT [FK_ReserveRequest_Request]
;
ALTER TABLE [dbo].[Tasks]  WITH NOCHECK ADD  CONSTRAINT [FK_Budgets_Events] FOREIGN KEY([TaskID])
REFERENCES [dbo].[Events] ([EventID])
ON DELETE CASCADE
;
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Budgets_Events]
;
ALTER TABLE [dbo].[Correspondence]  WITH NOCHECK ADD  CONSTRAINT [FK_Correspondence_Correspondence] FOREIGN KEY([ParentID])
REFERENCES [dbo].[Correspondence] ([CorrespondenceID])
;
ALTER TABLE [dbo].[Correspondence] CHECK CONSTRAINT [FK_Correspondence_Correspondence]
;
ALTER TABLE [dbo].[Correspondence]  WITH NOCHECK ADD  CONSTRAINT [FK_Correspondence_Events] FOREIGN KEY([CorrespondenceID])
REFERENCES [dbo].[Events] ([EventID])
;
ALTER TABLE [dbo].[Correspondence] CHECK CONSTRAINT [FK_Correspondence_Events]
;
ALTER TABLE [dbo].[Correspondence]  WITH NOCHECK ADD  CONSTRAINT [FK_Correspondence_TypesEntryExit] FOREIGN KEY([TypeEntryExitCode])
REFERENCES [dbo].[TypesEntryExit] ([TypeEntryExitCode])
;
ALTER TABLE [dbo].[Correspondence] CHECK CONSTRAINT [FK_Correspondence_TypesEntryExit]
;
ALTER TABLE [dbo].[ReproductionRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_ReproductionRequest_CertificateType] FOREIGN KEY([TypeCertificateCode])
REFERENCES [dbo].[TypesCertificate] ([TypeCertificateCode])
ON UPDATE CASCADE
ON DELETE CASCADE
;
ALTER TABLE [dbo].[ReproductionRequest] CHECK CONSTRAINT [FK_ReproductionRequest_CertificateType]
;
ALTER TABLE [dbo].[ReproductionRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_ReproductionRequest_CopyType] FOREIGN KEY([TypeReproductionCode])
REFERENCES [dbo].[TypesReproduction] ([TypeReproductionCode])
;
ALTER TABLE [dbo].[ReproductionRequest] CHECK CONSTRAINT [FK_ReproductionRequest_CopyType]
;
ALTER TABLE [dbo].[ReproductionRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_ReproductionRequest_Request] FOREIGN KEY([ReproductionRequestID])
REFERENCES [dbo].[Events] ([EventID])
ON DELETE CASCADE
;
ALTER TABLE [dbo].[ReproductionRequest] CHECK CONSTRAINT [FK_ReproductionRequest_Request]
;
ALTER TABLE [dbo].[TaskDetails]  WITH NOCHECK ADD  CONSTRAINT [FK_BudgetDetails_Budgets] FOREIGN KEY([TaskID])
REFERENCES [dbo].[Tasks] ([TaskID])
ON DELETE CASCADE
;
ALTER TABLE [dbo].[TaskDetails] CHECK CONSTRAINT [FK_BudgetDetails_Budgets]
;
ALTER TABLE [dbo].[TaskDetails]  WITH NOCHECK ADD  CONSTRAINT [FK_BudgetDetails_ReproductionTypes] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Services] ([ServiceID])
;
ALTER TABLE [dbo].[TaskDetails] CHECK CONSTRAINT [FK_BudgetDetails_ReproductionTypes]
;
ALTER TABLE [dbo].[OtherRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_OtherRequest_ReproductionRequest] FOREIGN KEY([OtherRequestID])
REFERENCES [dbo].[ReproductionRequest] ([ReproductionRequestID])
ON DELETE CASCADE
;
ALTER TABLE [dbo].[OtherRequest] CHECK CONSTRAINT [FK_OtherRequest_ReproductionRequest]
;
ALTER TABLE [dbo].[ParochialRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_ParochialRequest_KindActionPrc] FOREIGN KEY([KindActionPrcCode])
REFERENCES [dbo].[KindActionPrc] ([KindActionPrcCode])
;
ALTER TABLE [dbo].[ParochialRequest] CHECK CONSTRAINT [FK_ParochialRequest_KindActionPrc]
;
ALTER TABLE [dbo].[ParochialRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_ParochialRequest_ReproductionRequest] FOREIGN KEY([ParochialRequestID])
REFERENCES [dbo].[ReproductionRequest] ([ReproductionRequestID])
ON DELETE CASCADE
;
ALTER TABLE [dbo].[ParochialRequest] CHECK CONSTRAINT [FK_ParochialRequest_ReproductionRequest]
;
ALTER TABLE [dbo].[NotaryRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_NotaryRequest_KindActionNot] FOREIGN KEY([KindActionNotCode])
REFERENCES [dbo].[KindActionNot] ([KindActionNotCode])
;
ALTER TABLE [dbo].[NotaryRequest] CHECK CONSTRAINT [FK_NotaryRequest_KindActionNot]
;
ALTER TABLE [dbo].[NotaryRequest]  WITH NOCHECK ADD  CONSTRAINT [FK_NotaryRequest_ReproductionRequest] FOREIGN KEY([NotaryRequestID])
REFERENCES [dbo].[ReproductionRequest] ([ReproductionRequestID])
ON DELETE CASCADE
;
ALTER TABLE [dbo].[NotaryRequest] CHECK CONSTRAINT [FK_NotaryRequest_ReproductionRequest]
;
ALTER TABLE [dbo].[ProfileFunction]  WITH NOCHECK ADD  CONSTRAINT [FK_ProfileFunction_Functions] FOREIGN KEY([FunctionCode])
REFERENCES [dbo].[Functions] ([FunctionCode])
ON UPDATE CASCADE
ON DELETE CASCADE
;
ALTER TABLE [dbo].[ProfileFunction] CHECK CONSTRAINT [FK_ProfileFunction_Functions]
;
ALTER TABLE [dbo].[ProfileFunction]  WITH NOCHECK ADD  CONSTRAINT [FK_ProfileFunction_Profiles] FOREIGN KEY([ProfileID])
REFERENCES [dbo].[Profiles] ([ProfileID])
;
ALTER TABLE [dbo].[ProfileFunction] CHECK CONSTRAINT [FK_ProfileFunction_Profiles]
;
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_UserName] FOREIGN KEY([UserName])
REFERENCES [dbo].[Employees] ([UserName])
ON UPDATE CASCADE
ON DELETE CASCADE
;
ALTER TABLE [dbo].[Events]  WITH NOCHECK ADD  CONSTRAINT [FK_Events_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([UserName])
;
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_Employees]
;
ALTER TABLE [dbo].[Events]  WITH NOCHECK ADD  CONSTRAINT [FK_Events_Processes] FOREIGN KEY([ProcessID])
REFERENCES [dbo].[Processes] ([ProcessID])
;
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_Processes]
;
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
;
ALTER TABLE [dbo].[Logs]  WITH NOCHECK ADD  CONSTRAINT [FK_Logs_Employees1] FOREIGN KEY([UserName])
REFERENCES [dbo].[Employees] ([UserName])
;
ALTER TABLE [dbo].[Logs] CHECK CONSTRAINT [FK_Logs_Employees1]
;
ALTER TABLE [dbo].[DOFiles]  WITH NOCHECK ADD  CONSTRAINT [FK_DOFiles_AutoFocus] FOREIGN KEY([AutoFocusID])
REFERENCES [dbo].[AutoFocus] ([AutoFocusID])
;
ALTER TABLE [dbo].[DOFiles] CHECK CONSTRAINT [FK_DOFiles_AutoFocus]
;
ALTER TABLE [dbo].[DOFiles]  WITH NOCHECK ADD  CONSTRAINT [FK_DOFiles_IdDigitalObject] FOREIGN KEY([DigitalObjectID])
REFERENCES [dbo].[DigitalObjects] ([DigitalObjectID])
ON UPDATE CASCADE
ON DELETE CASCADE
;
ALTER TABLE [dbo].[DOFiles] CHECK CONSTRAINT [FK_DOFiles_IdDigitalObject]
;
ALTER TABLE [dbo].[DOFiles]  WITH NOCHECK ADD  CONSTRAINT [FK_DOFiles_IdLampType] FOREIGN KEY([LampTypeID])
REFERENCES [dbo].[LampType] ([LampTypeID])
;
ALTER TABLE [dbo].[DOFiles] CHECK CONSTRAINT [FK_DOFiles_IdLampType]
;
ALTER TABLE [dbo].[DOFiles]  WITH NOCHECK ADD  CONSTRAINT [FK_DOFiles_IdProfile] FOREIGN KEY([ProfileID])
REFERENCES [dbo].[DigitalizationProfiles] ([ProfileID])
;
ALTER TABLE [dbo].[DOFiles] CHECK CONSTRAINT [FK_DOFiles_IdProfile]
;
ALTER TABLE [dbo].[DOFiles]  WITH NOCHECK ADD  CONSTRAINT [FK_DOFiles_IdScanner] FOREIGN KEY([TPlatformID])
REFERENCES [dbo].[TechnologicalPlatform] ([TPlatformID])
;
ALTER TABLE [dbo].[DOFiles] CHECK CONSTRAINT [FK_DOFiles_IdScanner]
;
ALTER TABLE [dbo].[DOFiles]  WITH NOCHECK ADD  CONSTRAINT [FK_DOFiles_MeteringModes] FOREIGN KEY([MeteringModeID])
REFERENCES [dbo].[MeteringModes] ([MeteringModeID])
;
ALTER TABLE [dbo].[DOFiles] CHECK CONSTRAINT [FK_DOFiles_MeteringModes]
;
ALTER TABLE [dbo].[DOFiles]  WITH NOCHECK ADD  CONSTRAINT [FK_DOFiles_UserName] FOREIGN KEY([UserName])
REFERENCES [dbo].[Employees] ([UserName])
;
ALTER TABLE [dbo].[DOFiles] CHECK CONSTRAINT [FK_DOFiles_UserName]
;
ALTER TABLE [dbo].[Processes]  WITH NOCHECK ADD  CONSTRAINT [FK_Processes_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([UserName])
;
ALTER TABLE [dbo].[Processes] CHECK CONSTRAINT [FK_Processes_Employees]
;
ALTER TABLE [dbo].[Processes]  WITH CHECK ADD  CONSTRAINT [FK_Processes_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
;
ALTER TABLE [dbo].[BudgetEmployee]  WITH NOCHECK ADD  CONSTRAINT [FK_BudgetEmployee_Budgets] FOREIGN KEY([BudgetID])
REFERENCES [dbo].[Tasks] ([TaskID])
;
ALTER TABLE [dbo].[BudgetEmployee] CHECK CONSTRAINT [FK_BudgetEmployee_Budgets]
;
ALTER TABLE [dbo].[BudgetEmployee]  WITH NOCHECK ADD  CONSTRAINT [FK_BudgetEmployee_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([UserName])
;
ALTER TABLE [dbo].[BudgetEmployee] CHECK CONSTRAINT [FK_BudgetEmployee_Employees]
;
ALTER TABLE [dbo].[AplicationEmployee]  WITH NOCHECK ADD  CONSTRAINT [FK_AplicationEmployee_Aplications] FOREIGN KEY([AplicationCode])
REFERENCES [dbo].[Aplications] ([AplicationCode])
ON UPDATE CASCADE
;
ALTER TABLE [dbo].[AplicationEmployee] CHECK CONSTRAINT [FK_AplicationEmployee_Aplications]
;
ALTER TABLE [dbo].[AplicationEmployee]  WITH NOCHECK ADD  CONSTRAINT [FK_AplicationEmployee_Employees] FOREIGN KEY([UserName])
REFERENCES [dbo].[Employees] ([UserName])
;
ALTER TABLE [dbo].[AplicationEmployee] CHECK CONSTRAINT [FK_AplicationEmployee_Employees]
;
ALTER TABLE [dbo].[AplicationEmployee]  WITH NOCHECK ADD  CONSTRAINT [FK_AplicationEmployee_Profiles] FOREIGN KEY([ProfileID])
REFERENCES [dbo].[Profiles] ([ProfileID])
;
ALTER TABLE [dbo].[AplicationEmployee] CHECK CONSTRAINT [FK_AplicationEmployee_Profiles]
;
ALTER TABLE [dbo].[DigitalObjects]  WITH NOCHECK ADD  CONSTRAINT [FK_DigitalObjects_IdProject] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Projects] ([ProjectID])
ON UPDATE CASCADE
ON DELETE CASCADE
;
ALTER TABLE [dbo].[DigitalObjects] CHECK CONSTRAINT [FK_DigitalObjects_IdProject]
;
ALTER TABLE [dbo].[DigitalObjects]  WITH NOCHECK ADD  CONSTRAINT [FK_DigitalObjects_UserName] FOREIGN KEY([UserName])
REFERENCES [dbo].[Employees] ([UserName])
;
ALTER TABLE [dbo].[DigitalObjects] CHECK CONSTRAINT [FK_DigitalObjects_UserName]
;
ALTER TABLE [dbo].[Messages]  WITH NOCHECK ADD  CONSTRAINT [FK_Messages_MsgCategories] FOREIGN KEY([MsgCategoryID])
REFERENCES [dbo].[MsgCategories] ([CategoryID])
;
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_MsgCategories]
;
ALTER TABLE [dbo].[DaoGrp]  WITH NOCHECK ADD  CONSTRAINT [FK_DaoGrp_Components] FOREIGN KEY([ComponentID])
REFERENCES [dbo].[Components] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
;
ALTER TABLE [dbo].[DaoGrp] CHECK CONSTRAINT [FK_DaoGrp_Components]
;
ALTER TABLE [dbo].[DaoGrp]  WITH CHECK ADD  CONSTRAINT [FK_DaoGrp_DigitalObjects] FOREIGN KEY([DigitalObjectID])
REFERENCES [dbo].[DigitalObjects] ([DigitalObjectID])
;
ALTER TABLE [dbo].[DaoGrp]  WITH CHECK ADD  CONSTRAINT [FK_DaoGrp_DOFiles] FOREIGN KEY([FileID])
REFERENCES [dbo].[DOFiles] ([FileID])
ON DELETE CASCADE
;
ALTER TABLE [dbo].[Notes]  WITH NOCHECK ADD  CONSTRAINT [FK_Notes_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
;
ALTER TABLE [dbo].[Notes] CHECK CONSTRAINT [FK_Notes_Users]
;
ALTER TABLE [dbo].[ArchivistNotes]  WITH NOCHECK ADD  CONSTRAINT [FK_ArchivistNotes_Components] FOREIGN KEY([ComponentID])
REFERENCES [dbo].[Components] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
;
ALTER TABLE [dbo].[ArchivistNotes] CHECK CONSTRAINT [FK_ArchivistNotes_Components]
;
ALTER TABLE [dbo].[Bibliography]  WITH NOCHECK ADD  CONSTRAINT [FK_Bibliography_Components] FOREIGN KEY([ComponentID])
REFERENCES [dbo].[Components] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
;
ALTER TABLE [dbo].[Bibliography] CHECK CONSTRAINT [FK_Bibliography_Components]
;
ALTER TABLE [dbo].[ControlAccessItemsFonds]  WITH NOCHECK ADD  CONSTRAINT [FK_ControlAccessItemsFonds_Components] FOREIGN KEY([ComponentID])
REFERENCES [dbo].[Components] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
;
ALTER TABLE [dbo].[ControlAccessItemsFonds] CHECK CONSTRAINT [FK_ControlAccessItemsFonds_Components]
;
ALTER TABLE [dbo].[ControlAccessItemsFonds]  WITH NOCHECK ADD  CONSTRAINT [FK_ControlAccessItemsFonds_ControlAccessItems] FOREIGN KEY([ItemID])
REFERENCES [dbo].[ControlAccessItems] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
;
ALTER TABLE [dbo].[ControlAccessItemsFonds] CHECK CONSTRAINT [FK_ControlAccessItemsFonds_ControlAccessItems]
;
ALTER TABLE [dbo].[ControlAccess]  WITH NOCHECK ADD  CONSTRAINT [FK_ControlAccess_Components1] FOREIGN KEY([ComponentID])
REFERENCES [dbo].[Components] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
;
ALTER TABLE [dbo].[ControlAccess] CHECK CONSTRAINT [FK_ControlAccess_Components1]
;
ALTER TABLE [dbo].[ControlAccess]  WITH NOCHECK ADD  CONSTRAINT [FK_ControlAccess_ControlAccessItems] FOREIGN KEY([ItemID])
REFERENCES [dbo].[ControlAccessItems] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
;
ALTER TABLE [dbo].[ControlAccess] CHECK CONSTRAINT [FK_ControlAccess_ControlAccessItems]
;
ALTER TABLE [dbo].[ChronList]  WITH NOCHECK ADD  CONSTRAINT [FK_ChronList_Components] FOREIGN KEY([ComponentID])
REFERENCES [dbo].[Components] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
;
ALTER TABLE [dbo].[ChronList] CHECK CONSTRAINT [FK_ChronList_Components]
;
ALTER TABLE [dbo].[Attacheds]  WITH NOCHECK ADD  CONSTRAINT [FK_Attacheds_Correspondence] FOREIGN KEY([CorrespondenceID])
REFERENCES [dbo].[Correspondence] ([CorrespondenceID])
;
ALTER TABLE [dbo].[Attacheds] CHECK CONSTRAINT [FK_Attacheds_Correspondence]
;
ALTER TABLE [dbo].[PreservationAction]  WITH NOCHECK ADD  CONSTRAINT [FK_PreservationInfo_DigitalObjects] FOREIGN KEY([DigitalObjectID])
REFERENCES [dbo].[DigitalObjects] ([DigitalObjectID])
;
ALTER TABLE [dbo].[PreservationAction] CHECK CONSTRAINT [FK_PreservationInfo_DigitalObjects]
;
ALTER TABLE [dbo].[PreservationAction]  WITH NOCHECK ADD  CONSTRAINT [FK_PreservationInfo_ReformattingMethods] FOREIGN KEY([ReformattingMethodID])
REFERENCES [dbo].[ReformattingMethods] ([ReformattingMethodID])
;
ALTER TABLE [dbo].[PreservationAction] CHECK CONSTRAINT [FK_PreservationInfo_ReformattingMethods]
;
ALTER TABLE [dbo].[PreservationNorms]  WITH CHECK ADD  CONSTRAINT [FK_MethodsNorms_ReformattingNorms] FOREIGN KEY([ReformattingNormID])
REFERENCES [dbo].[ReformattingNorms] ([ReformattingNormID])
;
ALTER TABLE [dbo].[PreservationNorms]  WITH NOCHECK ADD  CONSTRAINT [FK_PreservationNorms_PreservationAction] FOREIGN KEY([PreservationActionID])
REFERENCES [dbo].[PreservationAction] ([PreservationActionID])
;
ALTER TABLE [dbo].[PreservationNorms] CHECK CONSTRAINT [FK_PreservationNorms_PreservationAction]
;
ALTER TABLE [dbo].[ControlAccessItems]  WITH NOCHECK ADD  CONSTRAINT [FK_ControlAccessItems_ControlAccessTypes] FOREIGN KEY([TypeID])
REFERENCES [dbo].[ControlAccessTypes] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
;
ALTER TABLE [dbo].[ControlAccessItems] CHECK CONSTRAINT [FK_ControlAccessItems_ControlAccessTypes]
;
ALTER TABLE [dbo].[Emoluments]  WITH NOCHECK ADD  CONSTRAINT [FK_Emoluments_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
;
ALTER TABLE [dbo].[Emoluments] CHECK CONSTRAINT [FK_Emoluments_Categories]
;
ALTER TABLE [dbo].[Services]  WITH CHECK ADD  CONSTRAINT [FK_ReproductionTypes_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
ON UPDATE CASCADE
ON DELETE CASCADE
;
ALTER TABLE [dbo].[Users]  WITH NOCHECK ADD  CONSTRAINT [FK_Users_AcademicalHab] FOREIGN KEY([AcademicsHabID])
REFERENCES [dbo].[AcademicsHab] ([AcademicsHabID])
;
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_AcademicalHab]
;
ALTER TABLE [dbo].[Users]  WITH NOCHECK ADD  CONSTRAINT [FK_Users_ActivityAreas] FOREIGN KEY([ActivityAreaID])
REFERENCES [dbo].[ActivityAreas] ([ActivityAreaID])
;
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_ActivityAreas]
;
ALTER TABLE [dbo].[Users]  WITH NOCHECK ADD  CONSTRAINT [FK_Users_AreaWork] FOREIGN KEY([WorkAreaID])
REFERENCES [dbo].[WorkAreas] ([WorkAreaID])
;
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_AreaWork]
;
ALTER TABLE [dbo].[Users]  WITH NOCHECK ADD  CONSTRAINT [FK_Users_Countries] FOREIGN KEY([CountryCode])
REFERENCES [dbo].[Countries] ([CountryCode])
;
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Countries]
;
ALTER TABLE [dbo].[Users]  WITH NOCHECK ADD  CONSTRAINT [FK_Users_Profession] FOREIGN KEY([ProfessionID])
REFERENCES [dbo].[Professions] ([ProfessionID])
;
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Profession]
;
ALTER TABLE [dbo].[Functions]  WITH NOCHECK ADD  CONSTRAINT [FK_Functions_Aplications] FOREIGN KEY([AplicationCode])
REFERENCES [dbo].[Aplications] ([AplicationCode])
ON UPDATE CASCADE
;
ALTER TABLE [dbo].[Functions] CHECK CONSTRAINT [FK_Functions_Aplications]
;
ALTER TABLE [dbo].[Profiles]  WITH NOCHECK ADD  CONSTRAINT [FK_Profiles_Aplications] FOREIGN KEY([AplicationCode])
REFERENCES [dbo].[Aplications] ([AplicationCode])
ON UPDATE CASCADE
;
ALTER TABLE [dbo].[Profiles] CHECK CONSTRAINT [FK_Profiles_Aplications]
;
ALTER TABLE [dbo].[EacLanguageDecl]  WITH NOCHECK ADD  CONSTRAINT [FK_EacLanguageDecl_EAC] FOREIGN KEY([EacID])
REFERENCES [dbo].[EAC] ([FondsID])
ON UPDATE CASCADE
ON DELETE CASCADE
;
ALTER TABLE [dbo].[EacLanguageDecl] CHECK CONSTRAINT [FK_EacLanguageDecl_EAC]
;
ALTER TABLE [dbo].[EacResourceRelationships]  WITH NOCHECK ADD  CONSTRAINT [FK_EacBibliographicRelationships_EAC] FOREIGN KEY([EacID])
REFERENCES [dbo].[EAC] ([FondsID])
ON UPDATE CASCADE
ON DELETE CASCADE
;
ALTER TABLE [dbo].[EacResourceRelationships] CHECK CONSTRAINT [FK_EacBibliographicRelationships_EAC]
;
ALTER TABLE [dbo].[EacArchRelationships]  WITH NOCHECK ADD  CONSTRAINT [FK_EacFondsRelationships_EAC] FOREIGN KEY([EacID])
REFERENCES [dbo].[EAC] ([FondsID])
ON UPDATE CASCADE
ON DELETE CASCADE
;
ALTER TABLE [dbo].[EacArchRelationships] CHECK CONSTRAINT [FK_EacFondsRelationships_EAC]
;
ALTER TABLE [dbo].[EacIdentity]  WITH NOCHECK ADD  CONSTRAINT [FK_EacIdentity_EAC] FOREIGN KEY([EacID])
REFERENCES [dbo].[EAC] ([FondsID])
ON UPDATE CASCADE
ON DELETE CASCADE
;
ALTER TABLE [dbo].[EacIdentity] CHECK CONSTRAINT [FK_EacIdentity_EAC]
;
ALTER TABLE [dbo].[EacRelationships]  WITH NOCHECK ADD  CONSTRAINT [FK_EacRelationships_EAC] FOREIGN KEY([EacID])
REFERENCES [dbo].[EAC] ([FondsID])
ON UPDATE CASCADE
ON DELETE CASCADE
;
ALTER TABLE [dbo].[EacRelationships] CHECK CONSTRAINT [FK_EacRelationships_EAC]
;
ALTER TABLE [dbo].[EacMaintenanceHistory]  WITH NOCHECK ADD  CONSTRAINT [FK_EacMaintenanceHistory_EAC] FOREIGN KEY([EacID])
REFERENCES [dbo].[EAC] ([FondsID])
ON UPDATE CASCADE
ON DELETE CASCADE
;
ALTER TABLE [dbo].[EacMaintenanceHistory] CHECK CONSTRAINT [FK_EacMaintenanceHistory_EAC]
