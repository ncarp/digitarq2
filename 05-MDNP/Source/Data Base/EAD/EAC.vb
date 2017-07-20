Imports System.Data.SqlClient ' SQL Server Data Provider
Imports System.Configuration

'*************************************************************************************************
' class: EAC
' Purpose: This class downloads the content of EAC Diagrams tables that made the AR (Authorities Records).
' This AR can be showed with the help of XML, we had the DTD(EAD) but for construct the XML we need
' a function like toXml which we have to build and a XSL Stylesheet. But this solution introduces 
' much process time then I opted for only to read from the diagram AEC and construct the HTML/ OR ASPX page.
' The Notation isn't used here.
'***************************************************************************************************


Public Class EAC
    Inherits BaseClassP

#Region "Private variables"

    '*************************************************************************
    Private myServerAddress As String
    Private myDatabase As String
    Private myUsername As String
    Private myPassword As String
    Private myConnString As String

    Private myFondsID As Integer
    '*************************************************************************

    Private myType As String
    Private mySysKey As String
    Private myCountryCode As String
    Private myOwnerCode As String
    Private myPart As String
    Private myUseDate As String
    Private myEacIdentity As EacIdentity
    Private myDetailLevel As String
    Private myBiogHist As String
    Private myPlace As String
    Private myLegalStatus As String
    Private myLegalId As String
    Private myFunActDesc As String
    Private myAssetStruct As String
    Private myEnv As String
    Private myRules As String
    Private myStatus As String

    Private myMaintenanceHistory As EacMaintenanceHistory
    Private myLanguageDeclaration As EacLanguageDeclaration

    Private myEacRelationships As EacRelationships
    Private myResourceRelationships As EacResourceRelationships
    Private myArchRelationships As EacArchRelationships

#End Region

#Region "Public properties"

    Property Status() As String
        Get
            Return myStatus
        End Get
        Set(ByVal Value As String)
            myStatus = Value
        End Set
    End Property

    Property Rules() As String
        Get
            Return myRules
        End Get
        Set(ByVal Value As String)
            myRules = Value
        End Set
    End Property

    Property Env() As String
        Get
            Return myEnv
        End Get
        Set(ByVal Value As String)
            myEnv = Value
        End Set
    End Property

    Property AssetStruct() As String
        Get
            Return myAssetStruct
        End Get
        Set(ByVal Value As String)
            myAssetStruct = Value
        End Set
    End Property

    Property FunActDesc() As String
        Get
            Return myFunActDesc
        End Get
        Set(ByVal Value As String)
            myFunActDesc = Value
        End Set
    End Property

    Property LegalId() As String
        Get
            Return myLegalId
        End Get
        Set(ByVal Value As String)
            myLegalId = Value
        End Set
    End Property

    Property LegalStatus() As String
        Get
            Return myLegalStatus
        End Get
        Set(ByVal Value As String)
            myLegalStatus = Value
        End Set
    End Property

    Property Place() As String
        Get
            Return myPlace
        End Get
        Set(ByVal Value As String)
            myPlace = Value
        End Set
    End Property

    Property BiogHist() As String
        Get
            Return myBiogHist
        End Get
        Set(ByVal Value As String)
            myBiogHist = Value
        End Set
    End Property

    Property DetailLevel() As String
        Get
            Return myDetailLevel
        End Get
        Set(ByVal Value As String)
            myDetailLevel = Value
        End Set
    End Property

    Property Part() As String
        Get
            Return myPart
        End Get
        Set(ByVal Value As String)
            myPart = Value
        End Set
    End Property

    Property UseDate() As String
        Get
            Return myUseDate
        End Get
        Set(ByVal Value As String)
            myUseDate = Value
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

    Property SysKey() As String
        Get
            Return mySysKey
        End Get
        Set(ByVal Value As String)
            mySysKey = Value
        End Set
    End Property

    Property CountryCode() As String
        Get
            Return myCountryCode
        End Get
        Set(ByVal Value As String)
            myCountryCode = Value
        End Set
    End Property

    Property OwnerCode() As String
        Get
            Return myOwnerCode
        End Get
        Set(ByVal Value As String)
            myOwnerCode = Value
        End Set
    End Property

    Property Identity() As EacIdentity
        Get
            Return myEacIdentity
        End Get
        Set(ByVal Value As EacIdentity)
            myEacIdentity = Value
        End Set
    End Property

    Property MaintenanceHistory() As EacMaintenanceHistory
        Get
            Return myMaintenanceHistory
        End Get
        Set(ByVal Value As EacMaintenanceHistory)
            myMaintenanceHistory = Value
        End Set
    End Property

    Property LanguageDeclaration() As EacLanguageDeclaration
        Get
            Return myLanguageDeclaration
        End Get
        Set(ByVal Value As EacLanguageDeclaration)
            myLanguageDeclaration = Value
        End Set
    End Property

    Property EacRelationships() As EacRelationships
        Get
            Return myEacRelationships
        End Get
        Set(ByVal Value As EacRelationships)
            myEacRelationships = Value
        End Set
    End Property

    Property ResourceRelationships() As EacResourceRelationships
        Get
            Return myResourceRelationships
        End Get
        Set(ByVal Value As EacResourceRelationships)
            myResourceRelationships = Value
        End Set
    End Property

    Property ArchRelationships() As EacArchRelationships
        Get
            Return myArchRelationships
        End Get
        Set(ByVal Value As EacArchRelationships)
            myArchRelationships = Value
        End Set
    End Property

#End Region

#Region "Initialization"

    Public Sub New(ByVal ServerAddress As String, ByVal Database As String, ByVal Username As String, ByVal Password As String, ByVal FondsID As Integer)
        'Dim hshDatabase As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")

        'Dim ServerAddress As String = hshDatabase("ServerAddress")
        'Dim Database As String = hshDatabase("Database")
        'Dim SA_Username As String = hshDatabase("SA_Username")
        'Dim SA_Password As String = hshDatabase("SA_Password")
        'Dim Username As String = hshDatabase("Username")
        'Dim Password As String = hshDatabase("Password")

        myConnString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; password={3}", ServerAddress, Database, Username, Password)

        myFondsID = FondsID
        Download()
    End Sub

    Public Sub New(ByVal FondsID As Integer)
        Dim hshDatabase As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")

        Dim ServerAddress As String = hshDatabase("ServerAddress")
        Dim Database As String = hshDatabase("Database")
        Dim SA_Username As String = hshDatabase("SA_Username")
        Dim SA_Password As String = hshDatabase("SA_Password")
        Dim Username As String = hshDatabase("Username")
        Dim Password As String = hshDatabase("Password")

        myConnString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; password={3}", ServerAddress, Database, Username, Password)
        myFondsID = FondsID
        Download()
    End Sub




#End Region

#Region "Download"





    Private Function Exists(ByVal FondsID As Integer) As Boolean
        Dim EacDescriptionExists As Boolean
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = myConnString

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Try
            SQLConnection.Open()
            SQLCommand.CommandText = String.Format("SELECT count(FondsID) FROM EAC WHERE FondsID = '{0}'", myFondsID)
            EacDescriptionExists = CType(SQLCommand.ExecuteScalar, Integer) = 1

        Catch ex As SqlException
            'MsgBoxSqlException(ex)
        Catch ex As Exception
            'MsgBoxException(ex)
        Finally
            SQLConnection.Close()
        End Try
        Return EacDescriptionExists
    End Function



    Public Sub Download()
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = myConnString

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Dim Transaction As SqlTransaction
        Try
            SQLConnection.Open()
            Transaction = SQLConnection.BeginTransaction(IsolationLevel.ReadCommitted)
            SQLCommand.Transaction = Transaction
            SQLCommand.CommandText = String.Format("SELECT * FROM EAC WHERE FondsID = '{0}'", myFondsID)
            Dim DataReader As SqlDataReader

            DataReader = SQLCommand.ExecuteReader()
            While DataReader.Read()
                Type = DBToStr(DataReader.Item("Type"))
                SysKey = DBToStr(DataReader.Item("SysKey"))
                CountryCode = DBToStr(DataReader.Item("CountryCode"))
                OwnerCode = DBToStr(DataReader.Item("OwnerCode"))
                Part = DBToStr(DataReader.Item("Part"))
                UseDate = DBToStr(DataReader.Item("UseDate"))
                DetailLevel = DBToStr(DataReader.Item("DetailLevel"))

                BiogHist = DBToStr(DataReader.Item("BiogHist"))
                Place = DBToStr(DataReader.Item("Place"))
                LegalStatus = DBToStr(DataReader.Item("LegalStatus"))
                LegalId = DBToStr(DataReader.Item("LegalId"))
                FunActDesc = DBToStr(DataReader.Item("FunactDesc"))
                AssetStruct = DBToStr(DataReader.Item("AssetStruct"))
                Env = DBToStr(DataReader.Item("Env"))
                Rules = DBToStr(DataReader.Item("Rules"))
                Status = DBToStr(DataReader.Item("Status"))
            End While
            DataReader.Close()

            '**************************************************************************
            SQLCommand.CommandText = String.Format("SELECT ID, Part, UseDate, Type FROM EacIdentity WHERE EacID = '{0}'", myFondsID)
            Dim EacIdentityDataReader As SqlDataReader
            EacIdentityDataReader = SQLCommand.ExecuteReader()
            Dim clIdentity As New EacIdentity
            While EacIdentityDataReader.Read()
                clIdentity.Add(DBToInt(EacIdentityDataReader.Item("ID")), _
                DBToStr(EacIdentityDataReader.Item("Part")), _
                DBToStr(EacIdentityDataReader.Item("UseDate")), _
                DBToStr(EacIdentityDataReader.Item("Type")))

            End While
            Identity = clIdentity
            EacIdentityDataReader.Close()

            '**************************************************************************
            SQLCommand.CommandText = String.Format("SELECT ID,[Language] FROM EacLanguageDecl WHERE EacID = '{0}'", myFondsID)
            Dim EacLanguageDeclDataReader As SqlDataReader
            EacLanguageDeclDataReader = SQLCommand.ExecuteReader()
            Dim clLanguage As New EacLanguageDeclaration
            While EacLanguageDeclDataReader.Read()
                clLanguage.Add(DBToInt(EacLanguageDeclDataReader.Item("ID")), DBToStr(EacLanguageDeclDataReader.Item("Language")))
            End While
            LanguageDeclaration = clLanguage
            EacLanguageDeclDataReader.Close()

            '**************************************************************************
            SQLCommand.CommandText = String.Format("SELECT ID, MainType, MainName, MainDate, MainDesc FROM EacMaintenanceHistory WHERE EacID = '{0}'", myFondsID)
            Dim MaintenanceHistoryDataReader As SqlDataReader
            MaintenanceHistoryDataReader = SQLCommand.ExecuteReader()
            Dim clMainHistory As New EacMaintenanceHistory
            While MaintenanceHistoryDataReader.Read()
                clMainHistory.Add( _
                    DBToInt(MaintenanceHistoryDataReader.Item("ID")), _
                    DBToStr(MaintenanceHistoryDataReader.Item("MainType")), _
                    DBToStr(MaintenanceHistoryDataReader.Item("MainName")), _
                    DBToStr(MaintenanceHistoryDataReader.Item("MainDate")), _
                    DBToStr(MaintenanceHistoryDataReader.Item("MainDesc")))
            End While
            MaintenanceHistory = clMainHistory
            MaintenanceHistoryDataReader.Close()

            '**************************************************************************
            SQLCommand.CommandText = String.Format("SELECT ID, Type, Unit, Date, ResourceType FROM EacResourceRelationships WHERE EacID = '{0}'", myFondsID)
            Dim ResDataReader As SqlDataReader = SQLCommand.ExecuteReader()
            Dim clResRel As New EacResourceRelationships
            While ResDataReader.Read()
                clResRel.Add( _
                    DBToInt(ResDataReader.Item("ID")), _
                    DBToStr(ResDataReader.Item("Type")), _
                    DBToStr(ResDataReader.Item("Unit")), _
                    DBToStr(ResDataReader.Item("Date")), _
                    DBToStr(ResDataReader.Item("ResourceType")))
            End While
            Me.ResourceRelationships = clResRel
            ResDataReader.Close()

            '**************************************************************************
            SQLCommand.CommandText = String.Format("SELECT * FROM EacRelationships WHERE EacID = '{0}'", myFondsID)
            Dim EacRelDataReader As SqlDataReader = SQLCommand.ExecuteReader()
            Dim clEacRel As New EacRelationships
            While EacRelDataReader.Read()
                clEacRel.Add( _
                    DBToInt(EacRelDataReader.Item("ID")), _
                    DBToStr(EacRelDataReader.Item("Type")), _
                    DBToStr(EacRelDataReader.Item("Name")), _
                    DBToStr(EacRelDataReader.Item("Place")), _
                    DBToStr(EacRelDataReader.Item("Date")), _
                    DBToStr(EacRelDataReader.Item("DescNote")), _
                    DBToStr(EacRelDataReader.Item("EacType")))
            End While
            Me.EacRelationships = clEacRel
            EacRelDataReader.Close()

            '**************************************************************************
            SQLCommand.CommandText = String.Format("SELECT * FROM EacArchRelationships WHERE EacID = '{0}'", myFondsID)
            Dim EacFondsRelDataReader As SqlDataReader = SQLCommand.ExecuteReader()
            Dim clEacFondsRel As New EacArchRelationships
            While EacFondsRelDataReader.Read()
                clEacFondsRel.Add( _
                    DBToInt(EacFondsRelDataReader.Item("ID")), _
                    DBToStr(EacFondsRelDataReader.Item("Type")), _
                    DBToStr(EacFondsRelDataReader.Item("Date")), _
                    DBToStr(EacFondsRelDataReader.Item("UnitId")), _
                    DBToStr(EacFondsRelDataReader.Item("UnitTitle")), _
                    DBToStr(EacFondsRelDataReader.Item("UnitDateInitial")), _
                    DBToStr(EacFondsRelDataReader.Item("UnitDateFinal")), _
                    DBToStr(EacFondsRelDataReader.Item("Repository")), _
                    DBToStr(EacFondsRelDataReader.Item("DescNote")))
            End While
            Me.ArchRelationships = clEacFondsRel
            EacFondsRelDataReader.Close()
            '**************************************************************************

            Transaction.Commit()
            ''Debug.WriteLine("EAC " & myFondsID & " Downloaded from Database")

        Catch ex As SqlException
            Transaction.Rollback()
            'MsgBoxSqlException(ex)
        Catch ex As Exception
            'MsgBoxException(ex)
        Finally
            SQLConnection.Close()
        End Try
    End Sub

#End Region

#Region "HTML"
    '*********************************************************************************************
    '
    'Note: The following functions aren't used in this project belongs to the DigitArq application
    '
    '**********************************************************************************************
    'Public Shared Function StatusToEac(ByVal Status As String) As String
    '    Select Case Status
    '        Case (VisualFieldLabel("Authorities.StatusDraft")) : Return "draft"
    '        Case (VisualFieldLabel("Authorities.StatusEdited")) : Return "edited"
    '        Case Else : Return ""
    '    End Select
    'End Function

    'Public Shared Function EacPrefix(ByVal Type As String)
    '    Select Case Type
    '        Case VisualFieldLabel("Authorities.CorporateBody") : Return "corp"
    '        Case VisualFieldLabel("Authorities.Family") : Return "fam"
    '        Case VisualFieldLabel("Authorities.Person") : Return "pers"
    '        Case Else : Return ""
    '    End Select
    'End Function




    Public Function toHtml() As String
        Dim EacHtml As String
        Dim EacHeader As String
        Dim EacConDesc As String
        Dim EacMainHist As String
        Dim EacBiogHist As String
        Dim EacId As String
        Dim EacLanguageDecl As String
        Dim EacRuleDecl As String
        Dim EacIdentity As String
        Dim EacDesc As String
        Dim EacRels As String
        Dim EacLocation As String
        Dim EacLegalStatus As String
        Dim EacFunActDesc As String
        Dim EacAssetStruct As String
        Dim EacEnv As String
        Dim EacLegalId As String
        Dim EacParallelOrOtherFormsName As String
        Dim EacControl As String
        Dim EacType As String
        Dim EacOwnerCode As String
        Dim EacStatus As String
        Dim EacDetailLevel As String
        Dim EacArchRels As String

        Dim EacAuthorizedName As String

        '------------------------------ ZONA DE IDENTIFICA플O ------------------------------------------
        EacType = CreateTag(GetLabel("WS.authorityRecord.EacType"), Type)
        EacAuthorizedName = CreateTag(GetLabel("WS.authorityRecord.EacAuthorizedName"), Part & " " & UseDate)
        EacParallelOrOtherFormsName = Identity.toHtml

        EacIdentity = CreateTag("<p><font class='SubTitle07'>" & GetLabel("WS.authorityRecord.EacIdentity") & "</font></p>", EacType & EacAuthorizedName & EacParallelOrOtherFormsName)


        '------------------------------ ZONA DE DESCRI플O ----------------------------------------------
        EacBiogHist = CreateTag(GetLabel("WS.authorityRecord.EacBiogHist"), BiogHist)
        EacLocation = CreateTag(GetLabel("WS.authorityRecord.EacLocation"), Place)
        EacLegalStatus = CreateTag(GetLabel("WS.authorityRecord.EacLegalStatus"), LegalStatus)
        EacFunActDesc = CreateTag(GetLabel("WS.authorityRecord.EacFunActDesc"), FunActDesc)
        EacLegalId = CreateTag(GetLabel("WS.authorityRecord.EacLegalId"), LegalId)
        EacAssetStruct = CreateTag(GetLabel("WS.authorityRecord.EacAssetStruct"), AssetStruct)
        EacEnv = CreateTag(GetLabel("WS.authorityRecord.EacEnv"), Env)

        EacDesc = CreateTag("<p><font class='SubTitle07'>" & GetLabel("WS.authorityRecord.EacDesc") & "</font></p>", EacBiogHist & EacLocation & EacLegalStatus & EacFunActDesc & EacAssetStruct & EacEnv)


        '------------------------------ ZONA DAS RELA합ES ----------------------------------------------
        EacRels = CreateTag("<p><font class='SubTitle07'>" & GetLabel("WS.authorityRecord.EacRels") & "</font></p>", EacRelationships.toHtml)


        '------------------------------ ZONA DE CONTROLO ----------------------------------------------
        'ISAAR 5.4.1:
        EacId = CreateTag(GetLabel("WS.authorityRecord.EacId"), SysKey)
        ' ISAAR 5.4.2 :
        EacOwnerCode = CreateTag(GetLabel("WS.authorityRecord.EacOwnerCode"), OwnerCode)
        'ISAAR 5.4.3:
        EacRuleDecl = CreateTag(GetLabel("WS.authorityRecord.EacRuleDecl"), String.Join("</br>", Me.Rules.Split(";")))
        'ISAAR 5.4.4 -> status
        EacStatus = CreateTag(GetLabel("WS.authorityRecord.EacStatus"), Status)
        'ISAAR 5.4.5 -> DetailLevel
        EacDetailLevel = CreateTag(GetLabel("WS.authorityRecord.EacDetailLevel"), DetailLevel)
        'ISAAR 5.3.6 :
        EacLanguageDecl = LanguageDeclaration.toHtml
        'ISAAR 5.4.7, 5.4.8
        EacMainHist = Me.MaintenanceHistory.toHtml

        EacControl = CreateTag("<p><font class='SubTitle07'>" & GetLabel("WS.authorityRecord.EacControl") & "</font></p>", EacId & EacOwnerCode & EacRuleDecl & EacStatus & EacDetailLevel & EacLanguageDecl & EacMainHist)


        '------------------------------ LIGA합ES ------------------------------------------------------
        EacArchRels = CreateTag("<p><font class='SubTitle07'>" & GetLabel("WS.authorityRecord.EacArchRels") & "</font></p>", ArchRelationships.toHtml & ResourceRelationships.toHtml)


        '------------------------------ RETURN --------------------------------------------------------
        EacHtml = EacIdentity & EacDesc & EacRels & EacControl & EacArchRels

        Return EacHtml
    End Function
#End Region









End Class
