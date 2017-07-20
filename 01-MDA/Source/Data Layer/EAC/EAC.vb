
#Region "License Agreement"

'* DigitArq
'* Copyright 2007-2015 
'* Arquivo Distrital do Porto
'* Todos os direitos reservados.
'*  
'* Este software foi desenvolvido pelo Arquivo
'* Distrital do Porto (http://www.adporto.pt)
'* em articulação com a Direcção-Geral de Arquivos
'* (http://www.dgarq.gov.pt) e com a coordenação
'* informática da Universidade do Minho
'* (http://www.uminho.pt).
'* O desenvolvimento deste produto foi parcialmente
'* financiado pelo Programa Operacional para a 
'* Cultura (POC) promovido pelo Governo Português.
'* ---------------------------------------------------
'*
'* A redistribuição e utilização deste produto sob a
'* forma de código-fonte ou programa compilado, com ou
'* sem modificações, é permitida desde que o seguinte
'* conjunto de condições seja cumprido:
'* 
'*	* Todas as redistribuições do código-fonte 
'*	  deste produto deverão ser acompanhadas do
'*	  texto que compõe esta licença, incluindo o 
'*	  texto inicial de atribuição de autoria,
'*	  esta lista de condições e do seguinte termo
'*	  de responsabilidade.
'*
'*	* Os nomes da Direcção-Geral de Arquivos,
'*	  do Arquivo Distrital do Porto, da 
'*	  Universidade do Minho e das pessoas 
'*	  individuais que colaboraram no desenvolvimento 
'*	  deste produto não deverão ser utilizados na 
'*	  promoção de produtos derivados deste 
'*	  sem que seja obtido consentimento prévio, por
'*	  escrito, por parte dos visados.

'*	* A utilização da designação DigitArq, seus 
'*	  logótipos e nomes institucionais associados
'*	  é apenas permitida em distribuições que sejam
'*	  cópias exactas da versão oficial deste produto
'*	  aprovada e/ou distribuída pela Direcção-Geral 
'*	  de Arquivos.

'*	* O desenvolvimento de obras derivadas deste
'*	  produto é permitido desde que a designação 
'*	  DigitArq, seus logotipos e parceiros 
'*	  institucionais não sejam utilizados em todo e
'*	  qualquer tipo de distribuição e/ou promoção 
'*	  da obra derivada.
'* 
'* ESTE SOFTWARE É DISTRIBUIDO PELA DIRECÇÃO-GERAL DE
'* ARQUIVOS "NO ESTADO EM QUE SE ENCONTRA" SEM QUALQUER
'* PRESUNÇÃO DE QUALIDADE OU GARANTIA ASSOCIADAS, 
'* INCLUINDO, MAS NÃO LIMITADO A, GARANTIAS ASSOCIADAS
'* A COMÉRCIO DE PRODUTOS OU DECLARAÇÃO DE ADEQUABILIDADE
'* A DETERMINADO FIM OU OBJECTIVO. 

'* EM NENHUMA CIRCUNSTÂNCIA PODERÁ A DIRECÇÃO-GERAL DE 
'* ARQUIVOS SER CONSIDERADA RESPONSÁVEL POR QUAISQUER 
'* DANOS QUE RESULTEM DA UTILIZAÇÃO DIRECTA, INDIRECTA,
'* ACIDENTAL, ESPECIAL OU DEMONSTRATIVA DESTE PRODUTO 
'* (INCLUINDO, MAS NÃO LIMITADO A, PERDAS DE DADOS, 
'* LUCROS, FALÊNCIA, INDEVIDA PRESTAÇÃO DE SERVIÇOS
'* OU NEGLIGÊNCIA), AINDA QUE O LICENCIANTE TENHA SIDO 
'* AVISADO DA POSSIBILIDADE DA OCORRÊNCIA DE TAIS DANOS.
'*
'* ---------------------------------------------------
'* Para mais informação sobre este produto ou a sua 
'* licença, é favor consultar o endereço electrónico
'* http://www.digitarq.pt

#End Region

Imports System.Data.SqlClient ' SQL Server Data Provider
Imports System.Configuration


Public Class EAC

#Region "Private variables"

    '*************************************************************************
    Private myServerAddress As String
    Private myDatabase As String
    Private myUsername As String
    Private myPassword As String
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
        myServerAddress = ServerAddress
        myDatabase = Database
        myUsername = Username
        myPassword = Password
        myFondsID = FondsID
        If Not Exists(FondsID) Then CreateEacDescription(myFondsID)
        Download()
    End Sub

    Public Sub New(ByVal FondsID As Integer)
        Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")

        myServerAddress = SQLServerSettings.Item("ServerAddress")
        myDatabase = SQLServerSettings.Item("Database")
        myUsername = SQLServerSettings.Item("Username")
        myPassword = SQLServerSettings.Item("Password")
        myFondsID = FondsID
        If Not Exists(FondsID) Then CreateEacDescription(myFondsID)
        Download()
    End Sub

    Public Sub New(ByVal LazyNode As LazyNode)
        Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")

        myServerAddress = SQLServerSettings.Item("ServerAddress")
        myDatabase = SQLServerSettings.Item("Database")
        myUsername = SQLServerSettings.Item("Username")
        myPassword = SQLServerSettings.Item("Password")
        myFondsID = LazyNode.ID
        If Not Exists(myFondsID) Then
            CreateEacDescription(myFondsID)
            Download()
            SysKey = LazyNode.UnitId
            Part = LazyNode.UnitTitle
            UseDate = LazyNode.UnitDateInitial & "/" & LazyNode.UnitDateFinal
            BiogHist = LazyNode.BiogHist
            Env = LazyNode.ScopeContent
            AssetStruct = LazyNode.Arrangement
            Place = LazyNode.GeogName
            Type = "corporatebody"
            Upload()
        Else
            Download()
        End If
    End Sub

#End Region

#Region "Download and Upload"


    Private Sub CreateEacDescription(ByVal FondsID As Integer)
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", myServerAddress, myDatabase, myUsername, myPassword)

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Dim Transaction As SqlTransaction

        Try

            SQLConnection.Open()
            Transaction = SQLConnection.BeginTransaction(IsolationLevel.ReadCommitted)
            SQLCommand.Transaction = Transaction
            SQLCommand.CommandText = String.Format("INSERT INTO EAC (FondsID, OwnerCode, CountryCode, Status, Type) VALUES ({0}, '{1}', '{2}', '{3}', '{4}')", FondsID, VisualFieldLabel("RepositoryCode.DefaultValue"), VisualFieldLabel("CountryCode.DefaultValue"), VisualFieldLabel("Authorities.StatusDraft"), VisualFieldLabel("Authorities.CorporateBody"))
            SQLCommand.ExecuteNonQuery()
            Transaction.Commit()
        Catch ex As SqlException
            If Not ex.Number = 8152 Then
                Transaction.Rollback()
                MsgBoxSqlException(ex)
            End If
        Catch ex As Exception
            MsgBoxException(ex)
        Finally
            SQLConnection.Close()
        End Try


    End Sub


    Private Function Exists(ByVal FondsID As Integer) As Boolean
        Dim EacDescriptionExists As Boolean
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", myServerAddress, myDatabase, myUsername, myPassword)

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Try
            SQLConnection.Open()
            SQLCommand.CommandText = String.Format("SELECT count(FondsID) FROM EAC WHERE FondsID = '{0}'", myFondsID)
            EacDescriptionExists = CType(SQLCommand.ExecuteScalar, Integer) = 1

        Catch ex As SqlException
            MsgBoxSqlException(ex)
        Catch ex As Exception
            MsgBoxException(ex)
        Finally
            SQLConnection.Close()
        End Try
        Return EacDescriptionExists
    End Function



    Public Sub Download()
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", myServerAddress, myDatabase, myUsername, myPassword)

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
            Debug.WriteLine("EAC " & myFondsID & " Downloaded from Database")

        Catch ex As SqlException
            Transaction.Rollback()
            MsgBoxSqlException(ex)
        Catch ex As Exception
            MsgBoxException(ex)
        Finally
            SQLConnection.Close()
        End Try
    End Sub


    Public Sub Upload()
        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", myServerAddress, myDatabase, myUsername, myPassword)

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection

        Dim Transaction As SqlTransaction

        Try

            SQLConnection.Open()
            Transaction = SQLConnection.BeginTransaction(IsolationLevel.ReadCommitted)
            SQLCommand.Transaction = Transaction

            SQLCommand.CommandText = String.Format("UPDATE EAC SET " & _
                                        "Type = '{1}'," & _
                                        "SysKey  = '{2}'," & _
                                        "CountryCode  = '{3}', " & _
                                        "OwnerCode  = '{4}'," & _
                                        "Part  = '{5}', " & _
                                        "UseDate  = '{6}', " & _
                                        "DetailLevel  = '{7}', " & _
                                        "BiogHist  = '{8}', " & _
                                        "Place  = '{9}', " & _
                                        "LegalStatus = '{10}', " & _
                                        "LegalId  = '{11}', " & _
                                        "FunActDesc = '{12}', " & _
                                        "AssetStruct = '{13}', " & _
                                        "Env = '{14}', " & _
                                        "Rules = '{15}', " & _
                                        "Status = '{16}'" & _
                                        "WHERE FondsID={0}", myFondsID, _
                                            StrToDB(Type), _
                                            StrToDB(SysKey), _
                                            StrToDB(CountryCode), _
                                            StrToDB(OwnerCode), _
                                            StrToDB(Part), _
                                            StrToDB(UseDate), _
                                            StrToDB(DetailLevel), _
                                            StrToDB(BiogHist), _
                                            StrToDB(Place), _
                                            StrToDB(LegalStatus), _
                                            StrToDB(LegalId), _
                                            StrToDB(FunActDesc), _
                                            StrToDB(AssetStruct), _
                                            StrToDB(Env), _
                                            StrToDB(Rules), _
                                            StrToDB(Status) _
                                        )
            SQLCommand.ExecuteNonQuery()


            ' Identity
            SQLCommand.CommandText = String.Format("DELETE FROM EacIdentity WHERE EacID = '{0}'", myFondsID)
            SQLCommand.ExecuteNonQuery()
            Dim clItem As EacIdentityItem
            For Each clItem In Identity
                SQLCommand.CommandText = _
                    String.Format("INSERT INTO EacIdentity (EacID, Part, UseDate, Type) VALUES ({0}, '{1}', '{2}', '{3}')", _
                        myFondsID, StrToDB(clItem.Part), StrToDB(clItem.UseDate), StrToDB(clItem.Type))
                SQLCommand.ExecuteNonQuery()
            Next


            ' Language Declaration
            SQLCommand.CommandText = String.Format("DELETE FROM EacLanguageDecl WHERE EacID = '{0}'", myFondsID)
            SQLCommand.ExecuteNonQuery()
            Dim LangItem As EacLanguageDeclarationItem
            For Each LangItem In Me.LanguageDeclaration
                SQLCommand.CommandText = _
                    String.Format("INSERT INTO EacLanguageDecl (EacID, [Language]) VALUES ({0}, '{1}')", _
                        myFondsID, StrToDB(LangItem.Language))
                SQLCommand.ExecuteNonQuery()
            Next

            ' Maintenace History
            SQLCommand.CommandText = String.Format("DELETE FROM EacMaintenanceHistory WHERE EacID = '{0}'", myFondsID)
            SQLCommand.ExecuteNonQuery()
            Dim MainItem As EacMaintenanceHistoryItem
            For Each MainItem In Me.MaintenanceHistory
                SQLCommand.CommandText = _
                    String.Format("INSERT INTO EacMaintenanceHistory (EacID, MainType, MainName, MainDate, MainDesc) VALUES ({0}, '{1}', '{2}', '{3}', '{4}')", _
                        myFondsID, StrToDB(MainItem.Type), StrToDB(MainItem.Name), StrToDB(MainItem.DateStr), StrToDB(MainItem.Description))
                SQLCommand.ExecuteNonQuery()
            Next


            ' Bib Rel
            SQLCommand.CommandText = String.Format("DELETE FROM EacResourceRelationships WHERE EacID = '{0}'", myFondsID)
            SQLCommand.ExecuteNonQuery()
            Dim ResItem As EacResourceRelationshipsItem
            For Each ResItem In Me.ResourceRelationships
                SQLCommand.CommandText = _
                    String.Format("INSERT INTO EacResourceRelationships (EacID, Type, Unit, [Date], ResourceType) VALUES ({0}, '{1}', '{2}', '{3}', '{4}')", _
                        myFondsID, StrToDB(ResItem.Type), StrToDB(ResItem.Unit), StrToDB(ResItem.DateStr), StrToDB(ResItem.ResourceType))
                SQLCommand.ExecuteNonQuery()
            Next


            ' Eac Rel
            SQLCommand.CommandText = String.Format("DELETE FROM EacRelationships WHERE EacID = '{0}'", myFondsID)
            SQLCommand.ExecuteNonQuery()
            Dim EacRelItem As EacRelationshipsItem
            For Each EacRelItem In Me.EacRelationships
                SQLCommand.CommandText = _
                    String.Format("INSERT INTO EacRelationships (EacID, Type, Name, [Date], Place, DescNote, EacType) VALUES ({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", _
                        myFondsID, StrToDB(EacRelItem.Type), StrToDB(EacRelItem.Name), StrToDB(EacRelItem.DateStr), StrToDB(EacRelItem.Place), StrToDB(EacRelItem.Note), StrToDB(EacRelItem.EacType))
                SQLCommand.ExecuteNonQuery()
            Next

            ' Fonds Rel
            SQLCommand.CommandText = String.Format("DELETE FROM EacArchRelationships WHERE EacID = '{0}'", myFondsID)
            SQLCommand.ExecuteNonQuery()
            Dim FondsRelItem As EacArchRelationshipsItem
            For Each FondsRelItem In Me.ArchRelationships
                SQLCommand.CommandText = _
                    String.Format("INSERT INTO EacArchRelationships (EacID, Type, [Date], UnitId, UnitTitle, UnitDateInitial, UnitDateFinal,  Repository, DescNote) VALUES ({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')", _
                        myFondsID, StrToDB(FondsRelItem.Type), StrToDB(FondsRelItem.DateStr), StrToDB(FondsRelItem.UnitId), StrToDB(FondsRelItem.UnitTitle), StrToDB(FondsRelItem.UnitDateInitial), StrToDB(FondsRelItem.UnitDateFinal), _
                        StrToDB(FondsRelItem.Repository), StrToDB(FondsRelItem.Note))
                SQLCommand.ExecuteNonQuery()
            Next


            Transaction.Commit()
            Debug.WriteLine("SQLLazynode: Uploaded To Database")
        Catch ex As SqlException
            If Not ex.Number = 8152 Then
                Transaction.Rollback()
                MsgBoxSqlException(ex)
            End If
        Catch ex As Exception
            MsgBoxException(ex)

        Finally
            SQLConnection.Close()
        End Try

    End Sub


#End Region

#Region "XML"


    Public Shared Function StatusToEac(ByVal Status As String) As String
        Select Case Status
            Case (VisualFieldLabel("Authorities.StatusDraft")) : Return "draft"
            Case (VisualFieldLabel("Authorities.StatusEdited")) : Return "edited"
            Case Else : Return ""
        End Select
    End Function

    Public Shared Function EacPrefix(ByVal Type As String)
        Select Case Type
            Case VisualFieldLabel("Authorities.CorporateBody") : Return "corp"
            Case VisualFieldLabel("Authorities.Family") : Return "fam"
            Case VisualFieldLabel("Authorities.Person") : Return "pers"
            Case Else : Return ""
        End Select
    End Function


    Public Shared Function TypeToEac(ByVal Type As String) As String
        Select Case Type
            Case (VisualFieldLabel("Authorities.CorporateBody")) : Return "corporatebody"
            Case (VisualFieldLabel("Authorities.Family")) : Return "family"
            Case (VisualFieldLabel("Authorities.Person")) : Return "person"
            Case Else : Return ""
        End Select
    End Function

    Public Function toXml() As String
        Dim EacXml As String
        Dim EacHeader As String
        Dim EacConDesc As String
        Dim EacMainHist As String
        Dim EacId As String
        Dim EacLanguageDecl As String
        Dim EacRuleDecl As String
        Dim EacIdentity As String
        Dim EacDesc As String
        Dim EacRels As String
        Dim EacResourceRels As String
        Dim EacLocation As String
        Dim EacLegalStatus As String
        Dim EacFunActDesc As String
        Dim EacAssetStruct As String
        Dim EacEnv As String
        Dim EacBiogHist
        Dim EacAuthorizedName As String



        EacId = CreateTag("eacid", String.Format("{1}::{2}::{0}", SysKey, CountryCode, OwnerCode), String.Format("syskey='{0}' countrycode='{1}' ownercode='{2}'", SysKey, CountryCode, OwnerCode))
        EacLanguageDecl = LanguageDeclaration.toXml
        EacMainHist = Me.MaintenanceHistory.toXml
        EacRuleDecl = CreateTag("ruledecl", CreateTag("rule", String.Join("</rule><rule>", Me.Rules.Split(";"))))
        EacHeader = CreateTag("eacheader", EacId & EacMainHist & EacLanguageDecl & EacRuleDecl, String.Format("status='{0}'", StatusToEac(Status)))

        EacAuthorizedName = String.Format("<{2}head authorized='iantt'><part>{0}</part><usedate>{1}</usedate></{2}head>", Part, UseDate, EacPrefix(Type))

        EacIdentity = CreateTag("identity", CreateTag("legalid", LegalId) & EacAuthorizedName & Identity.toXml(EacPrefix(Type)))

        EacLocation = CreateTag("location", CreateTag("place", Place))
        EacLegalStatus = CreateTag("legalstatus", CreateTag("value", LegalStatus))
        EacFunActDesc = CreateTag("funactdesc", CreateTag("p", FunActDesc))
        EacAssetStruct = CreateTag("assetstruct", CreateTag("p", AssetStruct))
        EacEnv = CreateTag("env", CreateTag("p", Env))
        EacBiogHist = CreateTag("bioghist", CreateTag("p", BiogHist))
        EacDesc = CreateTag("desc", CreateTag(EacPrefix(Type) & "desc", EacLocation & EacLegalStatus & EacFunActDesc & EacAssetStruct & EacEnv) & EacBiogHist)

        EacRels = EacRelationships.toXml
        EacResourceRels = CreateTag("resourcerels", ResourceRelationships.toXml)
        EacConDesc = CreateTag("condesc", EacIdentity & EacDesc & EacRels & EacResourceRels)

        EacXml = CreateTag("eac", EacHeader & EacConDesc, String.Format("type='{0}'", TypeToEac(Type)))
        Return EacXml
    End Function
#End Region


End Class
