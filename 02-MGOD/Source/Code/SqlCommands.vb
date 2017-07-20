Imports System.Threading
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.String
Imports System.Text
Imports System.IO

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

Public Class SqlCommands


    Public DATABASE_SQL_FILENAME As String = Application.StartupPath & "\" & "database.sql"


#Region "Functions/Procedures to SELECT information from tables"

#Region "SELECT Projects"

    Public Function SelectAllProjects() As DataSet
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim myCommand As String
        Try

            myCommand = "SELECT P.Name, P.Location, P.ProjectID, P.Description, P.CreationDateTime, " & _
                        "P.LastUpdateDateTime, P.Username, Count(DO.DigitalObjectID) AS DOCount FROM Projects P " & _
                        "LEFT JOIN DigitalObjects DO ON DO.ProjectID=P.ProjectID " & _
                        "GROUP BY P.Name, P.Location, P.ProjectID, P.Description, P.CreationDateTime, P.LastUpdateDateTime, P.Username " & _
                        "ORDER BY P.ProjectID DESC"


            myReader = New SqlDataAdapter(myCommand, Constants.DigitArqConnectionString)
            myReader.Fill(myData)
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            myReader.Dispose()
        End Try
        Return myData
    End Function


    Public Function SelectProjectById(ByVal intProjectID As Integer) As DataSet
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim command As String
        Try
            command = "SET DATEFORMAT ymd SELECT Name, Location, " & _
                  "Description, CreationDateTime, LastUpdateDateTime, " & _
                  "Username from PROJECTS WHERE ProjectID = " & intProjectID
            myReader = New SqlDataAdapter(command, Constants.DigitArqConnectionString)
            myReader.Fill(myData)
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            myReader.Dispose()
        End Try
        Return myData
    End Function

#End Region

#Region "SELECT DigitalObjects"

    Public Function SelectAllDigitalObjects()
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim command As String
        Try
            command = "SELECT DO.DigitalObjectD, DO.ProjectID, " & _
                      "Name, ArchiveId, ArchivingProfile, " & _
                      "DO.CaptureEntityCorporate, DO.ResponsabilityEntity, " & _
                      "CreationDateTime, ArchiveDateTime, DepositDateTime, RevisionDateTime" & _
                      "ExternalDescriptiveInformation, PreservationOriginalInformation, " & _
                      "QuantityOfTerminalObjects, TopographicalQuota, Structure," & _
                      "P.Name AS ProjectName " & _
                      "FROM DigitalObjects DO INNER JOIN " & _
                      "Projects P ON DO.ProjectID = P.ProjectID"

            myReader = New SqlDataAdapter(command, Constants.DigitArqConnectionString)
            myReader.Fill(myData)
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            myReader.Dispose()
        End Try
        Return myData
    End Function

    Public Function SelectDigitalObjectsByID(ByVal intProjectID As Integer)
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim myCommand As String
        Try
            myCommand = "SELECT * FROM DigitalObjects WHERE ProjectID = " & intProjectID & _
                        " ORDER BY DigitalObjectID DESC"

            myReader = New SqlDataAdapter(myCommand, Constants.DigitArqConnectionString)
            myReader.Fill(myData)
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            myReader.Dispose()
        End Try
        Return myData
    End Function

    Public Function SelectDOToCheck() As ArrayList
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim command As String
        Dim array As New ArrayList
        Dim i, count As Integer

        Try
            command = "SELECT DigitalObjectID " & _
            "FROM DigitalObjects WHERE RevisionDateTime < CONVERT(NVARCHAR(11), GETDATE(), 126)"
            myReader = New SqlDataAdapter(command, Constants.DigitArqConnectionString)
            myReader.Fill(myData)

            count = myData.Tables(0).Rows.Count - 1
            For i = 0 To count
                array.Add(myData.Tables(0).Rows(i).Item(0))
            Next i
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        End Try
        Return array
    End Function

    Public Function SelectProjectsToCheck() As ArrayList
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim command As String
        Dim i, count As Integer
        Dim array As New ArrayList

        Try
            command = "SELECT DISTINCT ProjectID " & _
                "FROM DigitalObjects WHERE RevisionDateTime < CONVERT(NVARCHAR(11), GETDATE(), 126)"

            myReader = New SqlDataAdapter(command, Constants.DigitArqConnectionString)
            myReader.Fill(myData)

            count = myData.Tables(0).Rows.Count - 1
            For i = 0 To count
                array.Add(myData.Tables(0).Rows(i).Item(0))
            Next i
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        End Try
        Return array
    End Function
#End Region

#Region "SELECT LampType"

    Public Function SelectAllLampTypes() As LampTypeCollection
        Dim myData As New LampTypeCollection
        Dim cn As New SqlConnection
        cn.ConnectionString = Constants.DigitArqConnectionString
        Dim myReader As SqlDataReader
        Dim myCommand As New SqlCommand
        Try
            cn.Open()
            myCommand.Connection = cn
            myCommand.CommandText = "SELECT * FROM LampType ORDER BY Description"
            myReader = myCommand.ExecuteReader
            While myReader.Read
                myData.Add(myReader.Item("Description"), myReader.Item("LampTypeID"))
            End While
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            cn.Close()
            cn.Dispose()
            myCommand.Dispose()
            myReader.Close()
        End Try
        Return myData
    End Function

    Public Function SelectLampTypeById(ByVal intLampTypeID As Integer) As DataSet
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim command As String
        Try
            command = "SELECT * FROM LamptType WHERE LampTypeID = " & intLampTypeID
            myReader = New SqlDataAdapter(command, Constants.DigitArqConnectionString)
            myReader.Fill(myData)
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        End Try
        Return myData
    End Function

#End Region

#Region "SELECT MeteringModes"

    Public Function SelectAllMeteringModes() As MeteringModeCollection
        Dim myData As New MeteringModeCollection
        Dim cn As New SqlConnection
        cn.ConnectionString = Constants.DigitArqConnectionString
        Dim myReader As SqlDataReader
        Dim myCommand As New SqlCommand
        Try
            cn.Open()
            myCommand.Connection = cn
            myCommand.CommandText = "SELECT * FROM MeteringModes ORDER BY Description"
            myReader = myCommand.ExecuteReader
            While myReader.Read
                myData.Add(myReader.Item("Description"), myReader.Item("MeteringModeID"))
            End While
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            cn.Close()
            cn.Dispose()
            myCommand.Dispose()
            myReader.Close()
        End Try
        Return myData
    End Function

#End Region

#Region "SELECT AutoFocus"

    Public Function SelectAllAutoFocus() As AutoFocusCollection
        Dim myData As New AutoFocusCollection
        Dim cn As New SqlConnection
        cn.ConnectionString = Constants.DigitArqConnectionString
        Dim myReader As SqlDataReader
        Dim myCommand As New SqlCommand
        Try
            cn.Open()
            myCommand.Connection = cn
            myCommand.CommandText = "SELECT * FROM AutoFocus ORDER BY Description"
            myReader = myCommand.ExecuteReader
            While myReader.Read
                myData.Add(myReader.Item("Description"), myReader.Item("AutoFocusID"))
            End While
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            cn.Close()
            cn.Dispose()
            myCommand.Dispose()
            myReader.Close()
        End Try
        Return myData
    End Function

#End Region

#Region "SELECT RevisionInterval"

    Public Function SelectAllRevisionInterval() As DataSet
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim command As String
        Try
            command = "SELECT * FROM RevisionInterval ORDER BY RevisionValue"

            myReader = New SqlDataAdapter(command, Constants.DigitArqConnectionString)
            myReader.Fill(myData)
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        End Try
        Return myData
    End Function

    Public Function SelectRevisionIntervalById(ByVal intRevisionIntervalID As Integer) As DataSet
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim command As String
        Try
            command = "SELECT * FROM RevisionInterval WHERE RevisionIntervalID = " & intRevisionIntervalID
            myReader = New SqlDataAdapter(command, Constants.DigitArqConnectionString)
            myReader.Fill(myData)
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        End Try
        Return myData
    End Function

#End Region

#Region "SELECT DigitalizationProfiles"

    Public Function SelectAllDigitalizationProfiles() As DataSet
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim command As String
        Try
            command = "SELECT * FROM DigitalizationProfiles WHERE LEN(ProfileName)>0 ORDER BY ProfileName"

            myReader = New SqlDataAdapter(command, Constants.DigitArqConnectionString)
            myReader.Fill(myData)
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        End Try
        Return myData
    End Function

    Public Function SelectDigitalizationProfiles() As DigitalizationProfileCollection
        Dim myData As New DigitalizationProfileCollection
        Dim cn As New SqlConnection
        cn.ConnectionString = Constants.DigitArqConnectionString
        Dim myReader As SqlDataReader
        Dim myCommand As New SqlCommand
        Try
            cn.Open()
            myCommand.Connection = cn
            myCommand.CommandText = "SELECT ProfileID, ProfileName FROM DigitalizationProfiles ORDER BY ProfileName"
            myReader = myCommand.ExecuteReader
            While myReader.Read
                myData.Add(myReader.Item("ProfileName"), myReader.Item("ProfileID"))
            End While
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            cn.Close()
            cn.Dispose()
            myCommand.Dispose()
            myReader.Close()
        End Try
        Return myData
    End Function

    Public Function SelectDigitalizationProfilesById(ByVal intProfileID As Integer) As DataSet
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim command As String
        Try
            command = "SELECT * FROM DigitalizationProfiles WHERE ProfileID = " & intProfileID
            myReader = New SqlDataAdapter(command, Constants.DigitArqConnectionString)
            myReader.Fill(myData)
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        End Try
        Return myData
    End Function

#End Region

#Region "SELECT TechnologicalPlatform"

    Public Function SelectAllTechnologicalPlatform() As DataSet
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim command As String
        Try
            command = "SELECT * FROM TechnologicalPlatform ORDER BY ScannerModelName"
            myReader = New SqlDataAdapter(command, Constants.DigitArqConnectionString)
            myReader.Fill(myData)
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        End Try
        Return myData
    End Function

    'Public Function SelectAllTechnologicalPlatform() As TechnologicalPlatformCollection
    '    Dim myData As New TechnologicalPlatformCollection
    '    Dim cn As New SqlConnection
    '    cn.ConnectionString = Constants.DigitArqConnectionString
    '    Dim myReader As SqlDataReader
    '    Dim myCommand As New SqlCommand
    '    Try
    '        cn.Open()
    '        myCommand.Connection = cn
    '        myCommand.CommandText = "SELECT * FROM TechnologicalPlatform ORDER BY ScannerModelName"
    '        myReader = myCommand.ExecuteReader
    '        While myReader.Read
    '            myData.Add(myReader.Item("TPlatformID"), myReader.Item("ScannerModelName"), _
    '                myReader.Item("DeviceSource"), myReader.Item("ScannerManufacturer"), _
    '                myReader.Item("ScanningSoftware"), myReader.Item("ScanningSoftwareVersionNo"), _
    '                myReader.Item("OperatingSystem"), myReader.Item("OperatingSystemVersion"))
    '        End While
    '    Catch e As SqlException
    '        MessageBoxes.MsgBoxSqlException(e)
    '    Finally
    '        cn.Close()
    '        cn.Dispose()
    '        myCommand.Dispose()
    '        myReader.Close()
    '    End Try
    '    Return myData
    'End Function

    Public Function SelectTechnologicalPlatform(ByVal intTPlatformID As Integer) As DataSet
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim command As String
        Try
            command = "SELECT * FROM TechnologicalPlatform WHERE TPlatformID = " & intTPlatformID
            myReader = New SqlDataAdapter(command, Constants.DigitArqConnectionString)
            myReader.Fill(myData)
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        End Try
        Return myData
    End Function

#End Region

#Region "SELECT DOImages"

    Public Function SelectAllDOImages() As DataSet
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim command As String
        Try
            command = "SELECT DOF.*, IBD.Description AS BDDescpription, " & _
                "LT.Description AS LTDescription, IF.Description AS IFDescription, " & _
                "RI.RevisionValue AS RevisionValue, IC.Description AS ICDescription, " & _
                "TP.ScannerModelName AS ScannerMN, TP.DeviceSource AS DSource, " & _
                "TP.ScannerManufacturer AS ScannerM, " & _
                "TP.ScanningSoftware AS ScanningSoft, " & _
                "TP.ScanningSoftwareVersionNo AS ScanningSoftVN, " & _
                "TP.OperatingSystem AS OS, TP.OperatingSystemVersion AS OSVersion " & _
                "FROM DOFiles AS DOF INNER JOIN ImageBitDepth AS IBD ON DOF.BitDepthID = IBD.BitDepthID " & _
                "INNER JOIN ImageCompression AS IC ON DOF.CompressionID = IC.CompressionID " & _
                "INNER JOIN ImageFormat AS IF ON DOF.FormatID = ImageFormat.FormatID " & _
                "INNER JOIN LampType AS LT ON DOF.LampTypeID = LampType.LampTypeID " & _
                "INNER JOIN RevisionInterval AS RI ON DOF.RevisionIntervalID = RevisionInterval.RevisionIntervalID " & _
                "INNER JOIN TechnologicalPlatform as TP ON DOF.ScannerID = TP.ScannerID"

            myReader = New SqlDataAdapter(command, Constants.DigitArqConnectionString)
            myReader.Fill(myData)
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        End Try
        Return myData
    End Function

    Public Function SelectAllDOImagesByDigitalObjectID(ByVal intDigitalObjectID As Integer) As DataSet
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim command As String
        Try
            command = "SELECT FileID, Name FROM DOFiles WHERE DigitalObjectID = " & intDigitalObjectID & " ORDER BY Name"

            myReader = New SqlDataAdapter(command, Constants.DigitArqConnectionString)
            myReader.Fill(myData)
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        End Try
        Return myData
    End Function

    Public Function SelectMetadataImageByName(ByVal intDigitalObjectID As Integer, ByVal strDOFileName As String) As DataSet
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim command As String
        Try
            command = "SELECT DOF.*, LT.Description AS LTDescription, " & _
                "TP.ScannerModelName AS ScannerMN, DP.ProfileName AS ProfileName, " & _
                "MM.Description AS MeteringMode, AF.Description AS AutoFocus " & _
                "FROM DOFiles AS DOF " & _
                "LEFT JOIN LampType AS LT ON DOF.LampTypeID = LT.LampTypeID " & _
                "LEFT JOIN TechnologicalPlatform AS TP ON DOF.TPlatformID = TP.TPlatformID " & _
                "LEFT JOIN DigitalizationProfiles AS DP ON DOF.ProfileID = DP.ProfileID " & _
                "LEFT JOIN MeteringModes AS MM ON DOF.MeteringModeID = MM.MeteringModeID " & _
                "LEFT JOIN AutoFocus AS AF ON DOF.AutoFocusID = AF.AutoFocusID " & _
                "WHERE DOF.DigitalObjectID = " & intDigitalObjectID & " AND DOF.Name='" & strDOFileName & "'"

            myReader = New SqlDataAdapter(command, Constants.DigitArqConnectionString)
            myReader.Fill(myData)
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        End Try
        Return myData
    End Function

    Public Function SelectMetadataImageByID(ByVal intDigitalObjectID As Integer, ByVal intDOFileID As Int64) As DataSet
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim command As String
        Try
            command = "SELECT DOF.*, LT.Description AS LampType, " & _
                "TP.ScannerModelName AS ScannerMN, DP.ProfileName AS ProfileName, " & _
                "MM.Description AS MeteringMode, AF.Description AS AutoFocus " & _
                "FROM DOFiles AS DOF " & _
                "LEFT JOIN LampType AS LT ON DOF.LampTypeID = LT.LampTypeID " & _
                "LEFT JOIN TechnologicalPlatform AS TP ON DOF.TPlatformID = TP.TPlatformID " & _
                "LEFT JOIN DigitalizationProfiles AS DP ON DOF.ProfileID = DP.ProfileID " & _
                "LEFT JOIN MeteringModes AS MM ON DOF.MeteringModeID = MM.MeteringModeID " & _
                "LEFT JOIN AutoFocus AS AF ON DOF.AutoFocusID = AF.AutoFocusID " & _
                "WHERE DOF.DigitalObjectID = " & intDigitalObjectID & " AND DOF.FileID='" & intDOFileID & "'"

            myReader = New SqlDataAdapter(command, Constants.DigitArqConnectionString)
            myReader.Fill(myData)
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        End Try
        Return myData
    End Function

#End Region

#Region "SELECT ImageByIdDO"

    Public Function haveDerivative(ByVal intFileID As Int64) As Integer
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim command As String
        Try
            command = "SELECT COUNT(FileID) AS C FROM DOFiles WHERE FileID = " & intFileID & " AND Image IS NOT NULL"
            myReader = New SqlDataAdapter(command, Constants.DigitArqConnectionString)
            myReader.Fill(myData)
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        End Try

        Return myData.Tables(0).Rows(0).Item(0)
    End Function

#End Region

#Region "SELECT ReformattingNorms"

    Public Function SelectAllReformattingNorms() As DataSet
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim command As String
        Try
            command = "SELECT * FROM ReformattingNorms ORDER BY ReformattingNorm"
            myReader = New SqlDataAdapter(command, Constants.DigitArqConnectionString)
            myReader.Fill(myData)
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        End Try
        Return myData
    End Function

    Public Function SelectReformattingNorms(ByVal intPreservationActionID As Integer) As DataSet
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim command As String
        Try
            command = "SELECT RN.ReformattingNormID, RN.ReformattingNorm, Description FROM ReformattingNorms RN " & _
                      "INNER JOIN PreservationNorms PN ON RN.ReformattingNormID=PN.ReformattingNormID " & _
                      "WHERE PreservationActionID = " & intPreservationActionID
            myReader = New SqlDataAdapter(command, Constants.DigitArqConnectionString)
            myReader.Fill(myData)
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        End Try
        Return myData
    End Function

#End Region

#Region "SELECT ReformattingMethods"

    Public Function SelectAllReformattingMethods() As DataSet
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim command As String
        Try
            command = "SELECT * FROM ReformattingMethods ORDER BY ReformattingMethod"
            myReader = New SqlDataAdapter(command, Constants.DigitArqConnectionString)
            myReader.Fill(myData)
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        End Try
        Return myData
    End Function

#End Region

#Region "SELECT ReformattingMethods"

    Public Function SelectHistoricalPresevation(ByVal intDigitalObjectID As Integer) As DataSet
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim command As String
        Try
            command = "SELECT * FROM PreservationAction PA " & _
                      "LEFT JOIN ReformattingMethods RM ON PA.ReformattingMethodID=RM.ReformattingMethodID " & _
                      "WHERE DigitalObjectID = " & intDigitalObjectID
            myReader = New SqlDataAdapter(command, Constants.DigitArqConnectionString)
            myReader.Fill(myData)
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        End Try
        Return myData
    End Function

#End Region

#Region "Select InfoAssocionations"

    Public Function SelectInfoAssociations(ByVal intDigitalObjectID As Int64) As DataSet
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim command As String
        Try
            command = "select DaoGrp.ComponentID, Components.CompleteUnitID, Components.OtherLevel, " & _
                "Components.UnitTitle FROM DaoGrp, Components " & _
                "WHERE DaoGrp.ComponentId = Components.ID AND DigitalObjectID = " & intDigitalObjectID

            myReader = New SqlDataAdapter(command, Constants.DigitArqConnectionString)
            myReader.Fill(myData)
        Catch e As SqlException
            MsgBox(e.Message, MsgBoxStyle.Critical)
        End Try
        Return myData
    End Function

    Public Function SelectInfoAssociationsF(ByVal intComponentID As Int64) As DataSet
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim command As String
        Try
            command = "SELECT DG.ComponentID, DG.DigitalObjectID, DO.Name " & _
                      "FROM DaoGrp DG INNER JOIN DigitalObjects DO ON DG.DigitalObjectID=DO.DigitalObjectID " & _
                      "WHERE ComponentID = " & intComponentID

            myReader = New SqlDataAdapter(command, Constants.DigitArqConnectionString)
            myReader.Fill(myData)
        Catch e As SqlException
            MsgBox(e.Message, MsgBoxStyle.Critical)
        End Try
        Return myData
    End Function

    Public Function DeleteAssociation(ByVal ComponentID As Integer, ByVal DigitalObjectID As Integer) As DataSet
        Dim myData As New DataSet
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection(Constants.DigitArqConnectionString)
        Dim command As String
        Try
            myCommand.Connection = myConnection
            myConnection.Open()
            myCommand.CommandText = "DELETE FROM DaoGrp" & _
                                    " WHERE ComponentID=" & ComponentID & _
                                    " AND ID_DigitalObject = " & DigitalObjectID

            myCommand.ExecuteNonQuery()
        Catch e As SqlException
            MsgBox(e.Message, MsgBoxStyle.Critical)
        Finally
            myCommand = Nothing
            myConnection.Close()
        End Try
        Return myData
    End Function

#End Region

#End Region


#Region "Functions/Procedures to INSERT information into tables"

#Region "INSERT Project"

    Public Function InsertProject(ByVal strProjectName As String, ByVal strLocation As String, _
        ByVal strDescription As String, ByVal strCreationDateTime As String, _
        ByVal LastUpdateDateTime As String, ByVal Username As String)

        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection

        myConnection.ConnectionString = Constants.DigitArqConnectionString
        myCommand.Connection = myConnection
        Try
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("INSERT INTO Projects(Name, Location, " & _
                                    "Description, CreationDateTime, LastUpdateDateTime, " & _
                                    "Username) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')", _
                                    strProjectName, strLocation, strDescription, strCreationDateTime, _
                                    LastUpdateDateTime, Username)
            myCommand.ExecuteNonQuery()
            myConnection.Close()
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            myConnection.Close()
            myConnection.Dispose()
        End Try
    End Function

#End Region

#Region "INSERT DigitalObject"

    Public Function InsertDigitalObject(ByVal intProjectID As Integer, ByVal strName As String, _
        ByVal strOriginalName As String, ByVal strArchiveId As String, ByVal strArchivingProfile As String, _
        ByVal strCaptureEntityCorporate As String, ByVal strResponsabilityEntity As String, _
        ByVal strCreationDateTime As String, ByVal strArchiveDateTime As String, ByVal strDepositDateTime As String, _
        ByVal strRevisionDateTime As String, ByVal strExternalDescriptiveInfo As String, _
        ByVal strPreservationOriginalInfo As String, ByVal intQtDO As Integer, _
        ByVal strTopographicalQuota As String, ByVal strXML As String, ByVal strUsername As String, ByVal intActive As Integer)

        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection

        myConnection.ConnectionString = Constants.DigitArqConnectionString
        myCommand.Connection = myConnection
        Try
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("INSERT INTO DigitalObjects(ProjectID, Name, OriginalName, " & _
                    "ArchiveId, ArchivingProfile, CaptureEntityCorporate, " & _
                    "ResponsabilityEntity, CreationDateTime, ArchiveDateTime, DepositDateTime, " & _
                    "RevisionDateTime, ExternalDescriptiveInformation, PreservationOriginalInformation, " & _
                    "QuantityOfTerminalObjects, TopographicalQuota, Structure, Username, Active) " & _
                    "VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}'," & _
                    "'{10}','{11}','{12}','{13}','{14}','{15}','{16}', '{17}')", intProjectID, strName, strOriginalName, _
                    strArchiveId, strArchivingProfile, strCaptureEntityCorporate, strResponsabilityEntity, strCreationDateTime, _
                    strArchiveDateTime, strDepositDateTime, strRevisionDateTime, strExternalDescriptiveInfo, _
                    strPreservationOriginalInfo, intQtDO, strTopographicalQuota, strXML, strUsername, intActive)

            myCommand.ExecuteNonQuery()
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            myCommand.Dispose()
            myConnection.Close()
            myConnection.Dispose()
        End Try
    End Function

#End Region

#Region "INSERT LampType"

    Public Function InsertLampType(ByVal Description As String) As Boolean
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim res As Boolean

        myConnection.ConnectionString = Constants.DigitArqConnectionString
        myCommand.Connection = myConnection
        Try
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("INSERT INTO LampType VALUES ('{0}')", Description)
            myCommand.ExecuteNonQuery()
        Catch e As SqlException
            res = False
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            res = True
            myConnection.Close()
        End Try
        Return res
    End Function

#End Region

#Region "INSERT MeteringMode"

    Public Function InsertMeteringMode(ByVal Description As String) As Boolean
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim res As Boolean

        myConnection.ConnectionString = Constants.DigitArqConnectionString
        myCommand.Connection = myConnection
        Try
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("INSERT INTO MeteringModes VALUES ('{0}')", Description)
            myCommand.ExecuteNonQuery()
        Catch e As SqlException
            res = False
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            res = True
            myConnection.Close()
            myConnection.Dispose()
        End Try
        Return res
    End Function

#End Region

#Region "INSERT AutoFocus"

    Public Function InsertAutoFocus(ByVal Description As String) As Boolean
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim res As Boolean

        myConnection.ConnectionString = Constants.DigitArqConnectionString
        myCommand.Connection = myConnection
        Try
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("INSERT INTO AutoFocus VALUES ('{0}')", Description)
            myCommand.ExecuteNonQuery()
        Catch e As SqlException
            res = False
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            res = True
            myConnection.Close()
            myConnection.Dispose()
        End Try
        Return res
    End Function

#End Region

#Region "INSERT RevisionInterval"

    Public Function InsertRevisionInterval(ByVal strValue As String)
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection

        myConnection.ConnectionString = Constants.DigitArqConnectionString
        myCommand.Connection = myConnection
        Try
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("INSERT INTO RevisionInterval(RevisionValue VALUES ('{0}')", strValue)
            myCommand.ExecuteNonQuery()
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            myConnection.Close()
            myConnection.Dispose()
        End Try
    End Function

#End Region

#Region "INSERT DigitalizationProfiles"

    Public Function InsertDigitalizationProfile(ByVal Profile As DigitalizationProfile) As Boolean

        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim res As Boolean

        myConnection.ConnectionString = Constants.DigitArqConnectionString
        myCommand.Connection = myConnection
        Try
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("INSERT INTO DigitalizationProfiles(ProfileName, Description, " & _
                                    "Resolution, BitDepth, Format, Compression, Rotation, Brightness, Contrast, Sharpness, Blur) " & _
                                    "VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", _
                                    Profile.ProfileName, Profile.Description, Profile.Resolution, _
                                    Profile.BitDepth, Profile.Format, Profile.Compression, _
                                    BoolToDB(Profile.Rotation), Profile.Brightness, Profile.Contrast, _
                                    Profile.Sharpness, Profile.Blur)
            myCommand.ExecuteNonQuery()
            res = True
        Catch e As SqlException
            res = False
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            myCommand.Dispose()
            myConnection.Close()
            myConnection.Dispose()
        End Try
        Return res
    End Function

#End Region

#Region "INSERT TechnologicalPlatform"

    Public Function InsertTechnologicalPlatform(ByVal ScannerModelName As String, ByVal DeviceSource As String, _
        ByVal ScannerManufacturer As String, ByVal ScanningSoftware As String, ByVal ScanningSoftwareVersion As String, _
        ByVal OperationgSystem As String, ByVal OperatingSystemVersion As String) As Integer

        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim res As Integer = 0

        myConnection.ConnectionString = Constants.DigitArqConnectionString
        myCommand.Connection = myConnection
        Try
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("INSERT INTO TechnologicalPlatform(ScannerModelName, DeviceSource, " & _
                                    "ScannerManufacturer, ScanningSoftware, ScanningSoftwareVersionNo, OperatingSystem, OperatingSystemVersion) " & _
                                    "VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", ScannerModelName, DeviceSource, _
                                    ScannerManufacturer, ScanningSoftware, ScanningSoftwareVersion, OperationgSystem, OperatingSystemVersion)
            myCommand.ExecuteNonQuery()
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            myCommand.Dispose()
            myConnection.Close()
            myConnection.Dispose()
        End Try
        Return 1
    End Function

#End Region

#Region "INSERT DOFiles"

    Public Function InsertDOFile(ByVal objImage As DOFile)

        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection

        myConnection.ConnectionString = Constants.DigitArqConnectionString
        myCommand.Connection = myConnection

        Try
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("INSERT INTO DOFiles(DigitalObjectID, CreationDateTime, " & _
                "Name, TPlatformID, ColorSpace, LampTypeID, ImageWidth, ImageHeight, Resolution, " & _
                "BitDepth, Compression, MimeType, FNumber, ExposureTime, MeteringModeID, FocalLength, AutoFocusID, " & _
                "CheckSumCreationDateTime, CheckSumValue, ImageSize, ProfileID, " & _
                "ProcessingDateTime, ProcessingActions, ProcessingSoftwareName, ProcessingSoftwareVersion, " & _
                "ProcessingOSName, ProcessingOSVersion, ColorManager, Username) " & _
                "VALUES ({0},'{1}','{2}',{3},'{4}',{5},'{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}', " & _
                "{14},'{15}',{16},'{17}','{18}','{19}',{20},'{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}')", _
                objImage.DigitalObjectID, objImage.CreationDateTime, objImage.Name, objImage.TPlatformID, _
                objImage.ColorSpace, objImage.LampTypeID, objImage.ImageWidth, objImage.ImageHeight, _
                objImage.Resolution, objImage.BitsPerPixel, objImage.Compression, objImage.MIMEType, _
                objImage.FNumber, objImage.ExposureTime, objImage.MeteringModeID, objImage.FocalLength, _
                objImage.AutoFocusID, objImage.CheckSumCreationDateTime, objImage.CheckSumValue, objImage.ImageSize, _
                objImage.ProfileID, objImage.ProcessingDateTime, objImage.ProcessingActions, objImage.ProcessingSoftwareName, _
                objImage.ProcessingSoftwareVersion, objImage.ProcessingOSName, objImage.ProcessingOSVersion, _
                objImage.ColorManager, objImage.UserName)
            myCommand.ExecuteNonQuery()
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            myCommand.Dispose()
            myConnection.Close()
            myConnection.Dispose()
        End Try
    End Function

#End Region

#Region "INSERT ReformattingNorm"

    Public Function InsertReformattingNorm(ByVal strReformattingNorm As String, ByVal strDescription As String)
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection

        myConnection.ConnectionString = Constants.DigitArqConnectionString
        myCommand.Connection = myConnection
        Try
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("INSERT INTO ReformattingNorms(ReformattingNorm, Description) " & _
                                        "VALUES (" & "'{0}','{1}')", strReformattingNorm, strDescription)
            myCommand.ExecuteNonQuery()
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            myCommand.Dispose()
            myConnection.Close()
            myConnection.Dispose()
        End Try
    End Function

#End Region

#Region "INSERT ReformattingMethod"

    Public Function InsertReformattingMethod(ByVal strReformattingMethod As String, ByVal strDescription As String)
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection

        myConnection.ConnectionString = Constants.DigitArqConnectionString
        myCommand.Connection = myConnection
        Try
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("INSERT INTO ReformattingMethods(ReformattingMethod, Description)" & _
                                        " VALUES (" & "'{0}','{1}')", strReformattingMethod, strDescription)

            myCommand.ExecuteNonQuery()
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            myCommand.Dispose()
            myConnection.Close()
            myConnection.Dispose()
        End Try
    End Function

#End Region

#Region "INSERT PreservationAction"

    Public Function InsertPrervationAction(ByVal strArchiveNextDateTime As String, ByVal strRevisionDateTime As String, _
        ByVal strTransformer As String, ByVal strPlatform As String, ByVal strRenderEngine As String, _
        ByVal strInputFormat As String, ByVal strParameters As String, ByVal intReformattingMethodID As Integer, _
        ByVal intDigitalObjectID As Integer, ByVal altNorms As ArrayList) As Boolean

        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection

        myConnection.ConnectionString = Constants.DigitArqConnectionString
        myCommand.Connection = myConnection
        Try
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("INSERT INTO PreservationAction" & _
                " VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7},{8})", _
                StrToDB(strArchiveNextDateTime), StrToDB(strRevisionDateTime), StrToDB(strTransformer), _
                StrToDB(strPlatform), StrToDB(strRenderEngine), StrToDB(strInputFormat), StrToDB(strParameters), _
                IntToDB(intReformattingMethodID), Int64ToDB(intDigitalObjectID))
            myCommand.ExecuteNonQuery()

            myCommand.CommandText = "SELECT @@IDENTITY"
            Dim intPreservationActionID As Integer = myCommand.ExecuteScalar

            For i As Integer = 0 To altNorms.Count - 1
                myCommand.CommandText = String.Format("INSERT INTO PreservationNorms" & _
                                       " VALUES ('{0}','{1}')", _
                                       intPreservationActionID, altNorms(i))
                myCommand.ExecuteNonQuery()
            Next
            Return True
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
            Return False
        Finally
            myCommand.Dispose()
            myConnection.Close()
            myConnection.Dispose()
        End Try
    End Function

#End Region

#End Region


#Region "Functions/Procedures to UPDATE information into tables"

#Region "UPDATE Project"

    Public Function UpdateProject(ByVal intProjectID As Int64, ByVal strProjectName As String, _
        ByVal strLocation As String, ByVal strDescription As String, ByVal strLastUpdateDateTime As String)

        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection

        myConnection.ConnectionString = Constants.DigitArqConnectionString
        myCommand.Connection = myConnection
        Try
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("UPDATE Projects SET Name='{0}', Location='{1}'," & _
                "Description='{2}', LastUpdateDateTime='{3}' WHERE ProjectID = '{4}'", _
                strProjectName, strLocation, strDescription, strLastUpdateDateTime, intProjectID)

            myCommand.ExecuteNonQuery()
            myConnection.Close()
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            myCommand.Dispose()
            myConnection.Close()
            myConnection.Dispose()
        End Try
    End Function

#End Region

#Region "UPDATE DigitalObject"

    Public Function UpdateDigitalObject(ByVal intDigitalObjectID As Integer, ByVal strOriginalName As String, _
        ByVal strArchiveId As String, ByVal strArchivingProfile As String, ByVal strCaptureEntityCorporate As String, _
        ByVal strResponsabilityEntity As String, ByVal strArchiveDateTime As String, _
        ByVal strDepositDateTime As String, ByVal strExternalDescriptiveInfo As String, _
        ByVal strPreservationOriginalInfo As String, ByVal strTopographicalQuota As String, ByVal intActive As Integer)

        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection

        myConnection.ConnectionString = Constants.DigitArqConnectionString
        myCommand.Connection = myConnection
        Try
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("UPDATE DigitalObjects SET " & _
                "OriginalName='{0}', ArchiveId='{1}', ArchivingProfile='{2}', CaptureEntityCorporate='{3}', " & _
                "ResponsabilityEntity='{4}', ArchiveDateTime='{5}', DepositDateTime='{6}', " & _
                "ExternalDescriptiveInformation='{7}', PreservationOriginalInformation='{8}', " & _
                "TopographicalQuota='{9}', Active='{10}' " & _
                "WHERE DigitalObjectID = '{11}'", strOriginalName, strArchiveId, strArchivingProfile, _
                strCaptureEntityCorporate, strResponsabilityEntity, _
                strArchiveDateTime, strDepositDateTime, strExternalDescriptiveInfo, _
                strPreservationOriginalInfo, strTopographicalQuota, intActive, intDigitalObjectID)

            myCommand.ExecuteNonQuery()
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            myCommand.Dispose()
            myConnection.Close()
            myConnection.Dispose()
        End Try
    End Function

#End Region

#Region "UPDATE LampType"

    Public Function UpdateLampType(ByVal intLampTypeID As Integer, ByVal strDescription As String) As Boolean
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim res As Boolean

        myConnection.ConnectionString = Constants.DigitArqConnectionString
        myCommand.Connection = myConnection
        Try
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("UPDATE LampType SET Description='{0}' " & _
                                    "WHERE LampTypeID = '{1}'", strDescription, intLampTypeID)
            myCommand.ExecuteNonQuery()
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
            res = False
        Finally
            res = True
            myCommand.Dispose()
            myConnection.Close()
            myConnection.Dispose()
        End Try
        Return res
    End Function

#End Region

#Region "UPDATE MeteringMode"

    Public Function UpdateMeteringMode(ByVal intMeteringModeID As Integer, ByVal strDescription As String) As Boolean
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim res As Boolean

        myConnection.ConnectionString = Constants.DigitArqConnectionString
        myCommand.Connection = myConnection
        Try
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("UPDATE MeteringModes SET Description='{0}' " & _
                                    "WHERE MeteringModeID = '{1}'", strDescription, intMeteringModeID)
            myCommand.ExecuteNonQuery()
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
            res = False
        Finally
            res = True
            myCommand.Dispose()
            myConnection.Close()
            myConnection.Dispose()
        End Try
        Return res
    End Function

#End Region

#Region "UPDATE AutoFocus"

    Public Function UpdateAutoFocus(ByVal intAutoFocusID As Integer, ByVal strDescription As String) As Boolean
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim res As Boolean

        myConnection.ConnectionString = Constants.DigitArqConnectionString
        myCommand.Connection = myConnection
        Try
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("UPDATE AutoFocus SET Description='{0}' " & _
                                    "WHERE AutoFocusID = '{1}'", strDescription, intAutoFocusID)
            myCommand.ExecuteNonQuery()
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
            res = False
        Finally
            res = True
            myCommand.Dispose()
            myConnection.Close()
            myConnection.Dispose()
        End Try
        Return res
    End Function

#End Region

#Region "UPDATE RevisionInterval"

    Public Function UpdateRevisionInterval(ByVal intRevisionIntervalID As Integer, ByVal strValue As String) As Boolean
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim res As Boolean

        myConnection.ConnectionString = Constants.DigitArqConnectionString
        myCommand.Connection = myConnection
        Try
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("UPDATE RevisionInterval SET RevisionValue='{0}' " & _
                                    "WHERE RevisionIntervalID = '{1}'", strValue, intRevisionIntervalID)
            myCommand.ExecuteNonQuery()
        Catch e As SqlException
            res = False
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            res = True
            myCommand.Dispose()
            myConnection.Close()
            myConnection.Dispose()
        End Try
        Return res
    End Function

#End Region

#Region "UPDATE DigitalizationProfiles"

    Public Function UpdateDigitalizationProfile(ByVal Profile As DigitalizationProfile) As Boolean

        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim res As Boolean

        myConnection.ConnectionString = Constants.DigitArqConnectionString
        myCommand.Connection = myConnection
        Try
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("UPDATE DigitalizationProfiles SET ProfileName='{0}', " & _
                "Description='{1}', Rotation='{2}', Resolution='{3}', BitDepth='{4}', Format='{5}', " & _
                "Compression='{6}', Brightness='{7}', Contrast='{8}', Sharpness='{9}', Blur='{10}' " & _
                "WHERE ProfileID = '{11}'", Profile.ProfileName, Profile.Description, BoolToDB(Profile.Rotation), _
                Profile.Resolution, Profile.BitDepth, Profile.Format, Profile.Compression, Profile.Brightness, _
                Profile.Contrast, Profile.Sharpness, Profile.Blur, Profile.ProfileID)

            myCommand.ExecuteNonQuery()
            res = True
        Catch e As SqlException
            res = False
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            myCommand.Dispose()
            myConnection.Close()
            myConnection.Dispose()
        End Try
        Return res
    End Function

#End Region

#Region "UPDATE TechnologicalPlatform"

    Public Function UpdateTechnologicalPlatform(ByVal TPlatformID As Integer, ByVal ScannerModelName As String, _
        ByVal DeviceSource As String, ByVal ScannerManufacturer As String, ByVal ScanningSoftware As String, _
        ByVal ScanningSoftwareVersion As String, ByVal OperationgSystem As String, ByVal OperatingSystemVersion As String)

        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection

        myConnection.ConnectionString = Constants.DigitArqConnectionString
        myCommand.Connection = myConnection
        Try
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("UPDATE TechnologicalPlatform SET ScannerModelName = '{0}', " & _
                "DeviceSource = '{1}', ScannerManufacturer = '{2}', ScanningSoftware = '{3}', " & _
                "ScanningSoftwareVersionNo = '{4}', OperatingSystem = '{5}', OperatingSystemVersion = '{6}' " & _
                "WHERE TPlatformID = '{7}'", ScannerModelName, DeviceSource, ScannerManufacturer, _
                ScanningSoftware, ScanningSoftwareVersion, OperationgSystem, OperatingSystemVersion, TPlatformID)

            myCommand.ExecuteNonQuery()
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            myCommand.Dispose()
            myConnection.Close()
            myConnection.Dispose()
        End Try
        Return 1
    End Function

#End Region

#Region "UPDATE image associated with a information already present in Database"

    '//insert digital image in database. Is a derivative of matrix image
    Public Sub setDerivative(ByVal pathNameImageJPEG As String, ByVal intDOID As Int64, ByVal intImgID As Int64)
        If pathNameImageJPEG = "" Then
            Exit Sub
        Else
            Dim strCn As String = Constants.DigitArqConnectionString
            Dim cn As New SqlConnection(strCn)
            Try
                Dim fsBLOBFileJPEG As New FileStream(pathNameImageJPEG, FileMode.Open, FileAccess.Read)
                Dim bytBLOBDataJPEG(fsBLOBFileJPEG.Length() - 1) As Byte

                fsBLOBFileJPEG.Read(bytBLOBDataJPEG, 0, bytBLOBDataJPEG.Length)

                Dim data As String = Date.Today.Year & "-" & Date.Today.Month & "-" & Date.Today.Day

                Dim cmd As New SqlCommand("UPDATE DOFiles SET Image = @BLOBData" & _
                                          " WHERE DigitalObjectID = " & intDOID & " And FileID = " & intImgID, cn)

                fsBLOBFileJPEG.Close()
                Dim prm As New SqlParameter("@BLOBData", SqlDbType.VarBinary, _
                    bytBLOBDataJPEG.Length, ParameterDirection.Input, False, _
                    0, 0, "Image", DataRowVersion.Current, bytBLOBDataJPEG)

                cmd.Parameters.Add(prm)
                cn.Open()
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MessageBoxes.MsgBoxException(ex)
            Finally
                cn.Close()
                cn.Dispose()
                'garbage collection cleans all variables
                GC.Collect()
            End Try
        End If
    End Sub

    Public Sub setThumb(ByVal pathNameImageJPEG As String, ByVal intDOID As Int64, ByVal intImgID As Int64)
        If pathNameImageJPEG = "" Then
            Exit Sub
        Else
            Dim strCn As String = Constants.DigitArqConnectionString
            Dim cn As New SqlConnection(strCn)
            Try
                Dim fsBLOBFileJPEG As New FileStream(pathNameImageJPEG, FileMode.Open, FileAccess.Read)
                Dim bytBLOBDataJPEG(fsBLOBFileJPEG.Length() - 1) As Byte

                fsBLOBFileJPEG.Read(bytBLOBDataJPEG, 0, bytBLOBDataJPEG.Length)

                Dim data As String = Date.Today.Year & "-" & Date.Today.Month & "-" & Date.Today.Day

                Dim cmd As New SqlCommand("UPDATE DOFiles SET Thumb = @BLOBData" & _
                                          " WHERE DigitalObjectID = " & intDOID & " And FileID = " & intImgID, cn)

                fsBLOBFileJPEG.Close()
                Dim prm As New SqlParameter("@BLOBData", SqlDbType.VarBinary, _
                    bytBLOBDataJPEG.Length, ParameterDirection.Input, False, _
                    0, 0, "Image", DataRowVersion.Current, bytBLOBDataJPEG)

                cmd.Parameters.Add(prm)
                cn.Open()
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MessageBoxes.MsgBoxException(ex)
            Finally
                cn.Close()
                cn.Dispose()
                'garbage collection cleans all variables
                GC.Collect()
            End Try
        End If
    End Sub

#End Region

#Region "UPDATE file associated with a information already present in Database"

    '//insert digital image in database. Is a derivative of matrix image
    Sub setFile(ByVal pathName As String, ByVal intDOID As Integer, ByVal intImgID As Integer)
        If pathName = "" Then
            Exit Sub
        Else
            Dim strCn As String = Constants.DigitArqConnectionString
            Dim cn As New SqlConnection(strCn)
            Try

                Dim fsBLOBFile As New FileStream(pathName, FileMode.Open, FileAccess.Read)
                Dim bytBLOBData(fsBLOBFile.Length() - 1) As Byte

                fsBLOBFile.Read(bytBLOBData, 0, bytBLOBData.Length)

                Dim data As String = Date.Today.Year & "-" & Date.Today.Month & "-" & Date.Today.Day

                Dim cmd As New SqlCommand("UPDATE DOFiles SET Image = @BLOBData" & _
                                          " WHERE DigitalObjectID = " & intDOID & " And FileID = " & intImgID, cn)

                fsBLOBFile.Close()
                Dim prm As New SqlParameter("@BLOBData", SqlDbType.VarBinary, _
                    bytBLOBData.Length, ParameterDirection.Input, False, _
                    0, 0, "Image", DataRowVersion.Current, bytBLOBData)

                cmd.Parameters.Add(prm)
                cn.Open()
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MessageBoxes.MsgBoxException(ex)
            Finally
                cn.Close()
                cn.Dispose()
                'garbage collection cleans all variables
                GC.Collect()
            End Try
        End If
    End Sub

#End Region

#Region "UPDATE meta-information of file in database"

    Sub updateDOFile(ByVal objDOFile As DOFile)

        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim ConnectionString As String = Constants.DigitArqConnectionString
        Dim cn As New SqlConnection(ConnectionString)

        Dim strCmd As String = String.Format("UPDATE DOFiles SET CreationDateTime='{0}', " & _
            "TPlatformID ={1}, ColorSpace='{2}', LampTypeID={3}, ImageWidth='{4}', " & _
            "ImageHeight='{5}', Resolution='{6}', BitDepth='{7}', Compression='{8}', MimeType='{9}', " & _
            "FNumber='{10}', ExposureTime='{11}', MeteringModeID={12}, FocalLength='{13}', AutoFocusID={14}, " & _
            "CheckSumCreationDateTime='{15}', CheckSumValue='{16}', ImageSize='{17}', ProfileID='{18}', " & _
            "ProcessingDateTime='{19}', ProcessingActions='{20}', ProcessingSoftwareName='{21}', ProcessingSoftwareVersion='{22}', " & _
            "ProcessingOSName='{23}', ProcessingOSVersion='{24}', ColorManager='{25}', Username='{26}' " & _
            "WHERE DigitalObjectID = '{27}' and FileID = '{28}'", _
            objDOFile.CreationDateTime, objDOFile.TPlatformID, objDOFile.ColorSpace, objDOFile.LampTypeID, _
            objDOFile.ImageWidth, objDOFile.ImageHeight, objDOFile.Resolution, objDOFile.BitsPerPixel, _
            objDOFile.Compression, objDOFile.MIMEType, objDOFile.FNumber, objDOFile.ExposureTime, objDOFile.MeteringModeID, _
            objDOFile.FocalLength, objDOFile.AutoFocusID, objDOFile.CheckSumCreationDateTime, objDOFile.CheckSumValue, _
            objDOFile.ImageSize, objDOFile.ProfileID, objDOFile.ProcessingDateTime, objDOFile.ProcessingActions, _
            objDOFile.ProcessingSoftwareName, objDOFile.ProcessingSoftwareVersion, objDOFile.ProcessingOSName, _
            objDOFile.ProcessingOSVersion, objDOFile.ColorManager, objDOFile.UserName, objDOFile.DigitalObjectID, objDOFile.FileID)
        Try
            Dim cmd As New SqlCommand(strCmd, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        Finally
            myCommand.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Sub

#End Region

#Region "UPDATE Technological Platform associated with a DOFile"

    '//insert digital image in database. Is a derivative of matrix image
    Public Function UpdateTPDOFile(ByVal DigitalObjectID As Int64, ByVal NameFile As String, _
        ByVal TechnologicalPlatformID As Integer) As Boolean

        Dim res As Boolean = False
        Dim strCn As String = Constants.DigitArqConnectionString
        Dim cn As New SqlConnection(strCn)

        Try
            Dim cmd As New SqlCommand("UPDATE DOFiles SET ScannerID = " & TechnologicalPlatformID & _
                                      " WHERE DigitalObjectID = " & DigitalObjectID & _
                                      " AND Name='" & NameFile & "'", cn)
            cn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        Finally
            cn.Close()
            GC.Collect()
            res = True
        End Try
        Return res
    End Function

#End Region

#Region "UPDATE Digitalization Profile associated with a DOFile"

    Public Function UpdateDPDOFile(ByVal DigitalObjectID As Int64, ByVal NameFile As String, _
        ByVal ProfileID As Integer) As Boolean

        Dim res As Boolean = False
        Dim strCn As String = Constants.DigitArqConnectionString
        Dim cn As New SqlConnection(strCn)

        Try
            Dim cmd As New SqlCommand("UPDATE DOFiles SET ProfileID = " & ProfileID & _
                                      " WHERE DigitalObjectID = " & DigitalObjectID & _
                                      " AND Name='" & NameFile & "'", cn)
            cn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        Finally
            cn.Close()
            GC.Collect()
            res = True
        End Try
        Return res
    End Function

#End Region

#Region "UPDATE Name of a file"

    Public Function UpdateNameDOFile(ByVal DigitalObjectID As Int64, ByVal OldNameFile As String, _
        ByVal NewNameFile As String) As Boolean

        Dim res As Boolean = False
        Dim strCn As String = Constants.DigitArqConnectionString
        Dim cn As New SqlConnection(strCn)
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim command As String
        Dim count As Integer

        Try
            '// already exists a file with the intended new name?
            command = "SELECT COUNT(FileID) AS C FROM DOFiles WHERE DigitalObjectID = " & DigitalObjectID & _
                " AND Name='" & NewNameFile & "'"

            myReader = New SqlDataAdapter(command, Constants.DigitArqConnectionString)
            myReader.Fill(myData)
            count = myData.Tables(0).Rows(0).Item(0)

            If count = 0 Then

                Dim cmd As New SqlCommand("UPDATE DOFiles SET Name = '" & NewNameFile & _
                                          "' WHERE DigitalObjectID = " & DigitalObjectID & _
                                          " AND Name='" & OldNameFile & "'", cn)
                cn.Open()
                cmd.ExecuteNonQuery()
                res = True
            Else
                res = False
            End If

        Catch ex As Exception
            res = False
            MessageBoxes.MsgBoxException(ex)
        Finally
            cn.Close()
            GC.Collect()
        End Try
        Return res
    End Function

#End Region

#Region "UPDATE CheckSum of a file"

    Public Function UpdateCheckSumDOFile(ByVal FileID As Int64, ByVal CheckSum As String) As Boolean
        Dim res As Boolean = False
        Dim strCn As String = Constants.DigitArqConnectionString
        Dim cn As New SqlConnection(strCn)
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim command As String
        Dim count As Integer

        Try
            '// already exists a file with the intended new name?
            command = String.Format("UPDATE DOFiles SET CheckSumValue = '{0}' WHERE FileID = {1}", CheckSum, FileID)
            Dim cmd As New SqlCommand(command, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            res = True

        Catch ex As Exception
            res = False
            MessageBoxes.MsgBoxException(ex)
        Finally
            cn.Close()
            GC.Collect()
        End Try
        Return res
    End Function

#End Region

#Region "UPDATE RevisionDateTime of a DigitalObject"

    Public Function UpdateRevisionDateTimeDO(ByVal DigitalObjectID As Integer, ByVal RevisionDateTime As String) As Boolean
        Dim res As Boolean = False
        Dim strCn As String = Constants.DigitArqConnectionString
        Dim cn As New SqlConnection(strCn)
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim command As String
        Dim count As Integer

        Try
            command = String.Format("UPDATE DigitalObjects SET RevisionDateTime = '{0}' " & _
                "WHERE DigitalObjectID = {1}", RevisionDateTime, DigitalObjectID)

            Dim cmd As New SqlCommand(command, cn)
            cn.Open()
            cmd.ExecuteNonQuery()
            res = True

        Catch ex As Exception
            res = False
            MessageBoxes.MsgBoxException(ex)
        Finally
            cn.Close()
            GC.Collect()
        End Try
        Return res
    End Function

#End Region

#Region "UPDATE Lamp Type associated with a DOFile"

    Public Function UpdateLTDOFile(ByVal DigitalObjectID As Integer, _
        ByVal NameFile As String, ByVal LampTypeID As Integer) As Boolean

        Dim res As Boolean = False
        Dim strCn As String = Constants.DigitArqConnectionString
        Dim cn As New SqlConnection(strCn)

        Try
            Dim cmd As New SqlCommand("UPDATE DOFiles SET LampTypeID = " & LampTypeID & _
                                      " WHERE DigitalObjectID = " & DigitalObjectID & _
                                      " AND Name='" & NameFile & "'", cn)
            cn.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        Finally
            cn.Close()
            GC.Collect()
            res = True
        End Try
        Return res
    End Function

#End Region

#Region "UPDATE ReformattingNorm"

    Public Function UpdateReformattingNorm(ByVal intReformattingNormID As Integer, ByVal strReformattingNorm As String, ByVal strDescription As String)
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection

        myConnection.ConnectionString = Constants.DigitArqConnectionString
        myCommand.Connection = myConnection
        Try
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("UPDATE ReformattingNorms SET ReformattingNorm='{0}', Description='{1}' " & _
                                    "WHERE ReformattingNormID='{2}'", strReformattingNorm, strDescription, intReformattingNormID)
            myCommand.ExecuteNonQuery()
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            myConnection.Close()
        End Try
    End Function

#End Region

#Region "UPDATE ReformattingNorm"

    Public Function UpdateReformattingMethod(ByVal intReformattingMethodID As Integer, ByVal strReformattingMethod As String, ByVal strDescription As String)
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection

        myConnection.ConnectionString = Constants.DigitArqConnectionString
        myCommand.Connection = myConnection
        Try
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("UPDATE ReformattingMethods SET ReformattingMethod='{0}', Description='{1}' " & _
                                    "WHERE ReformattingMethodID='{2}'", strReformattingMethod, strDescription, intReformattingMethodID)
            myCommand.ExecuteNonQuery()
            'MsgBox("Tipo de formato de imagem alterada com êxito!", MsgBoxStyle.Information)
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            myConnection.Close()
        End Try
    End Function

#End Region

#End Region


#Region "Functions/Procedures to DELETE information from tables"

#Region "DELETE DigitalizationProfiles"

    Public Function DeleteProject(ByVal ProjectID As Int64) As Boolean
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim res As Boolean = False

        myConnection.ConnectionString = Constants.DigitArqConnectionString
        myCommand.Connection = myConnection
        Try
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("DELETE FROM DaoGrp WHERE DigitalObjectID IN (SELECT DigitalObjectID FROM DigitalObjects WHERE ProjectID='{0}')", ProjectID)
            myCommand.ExecuteNonQuery()
            myCommand.CommandText = String.Format("DELETE FROM Projects WHERE ProjectID='{0}'", ProjectID)
            myCommand.ExecuteNonQuery()
            res = True
        Catch e As SqlException
            res = False
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            res = True
            myConnection.Close()
        End Try
        Return res
    End Function

#End Region

#Region "DELETE DigitalObjects"

    Public Function DeleteDigitalObjects(ByVal DigitalObjectID As Int64) As Boolean
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim res As Boolean = False

        myConnection.ConnectionString = Constants.DigitArqConnectionString
        myCommand.Connection = myConnection
        Try
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("DELETE FROM DigitalObjects WHERE DigitalObjectID='{0}'", DigitalObjectID)
            myCommand.ExecuteNonQuery()
            res = True
        Catch e As SqlException
            res = False
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            res = True
            myConnection.Close()
        End Try
        Return res
    End Function

#End Region

#Region "DELETE Derivatives"

    Public Function DeleteDerivatives(ByVal DigitalObjectID As Int64) As Boolean
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim res As Boolean = False

        myConnection.ConnectionString = Constants.DigitArqConnectionString
        myCommand.Connection = myConnection
        Try
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("UPDATE DOFiles SET Image=NULL WHERE DigitalObjectID='{0}'", DigitalObjectID)
            myCommand.ExecuteNonQuery()
            res = True
        Catch e As SqlException
            res = False
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            res = True
            myConnection.Close()
        End Try
        Return res
    End Function

#End Region

#Region "DELETE DigitalizationProfiles"

    Public Function DeleteDigitalizationProfiles(ByVal ProfileID As Integer)
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection

        myConnection.ConnectionString = Constants.DigitArqConnectionString
        myCommand.Connection = myConnection
        Try
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("DELETE FROM DigitalizationProfiles WHERE ProfileID='{0}'", ProfileID)
            myCommand.ExecuteNonQuery()
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            myConnection.Close()
        End Try
    End Function

#End Region

#Region "DELETE TecnhologicalPlatform"

    Public Function DeleteTecnhologicalPlatform(ByVal TPlatformID As Integer)
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection

        myConnection.ConnectionString = Constants.DigitArqConnectionString
        myCommand.Connection = myConnection
        Try
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("DELETE FROM TechnologicalPlatform WHERE TPlatformID='{0}'", TPlatformID)
            myCommand.ExecuteNonQuery()
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            myCommand = Nothing
            myConnection.Close()
        End Try
    End Function

#End Region

#Region "DELETE LampType"

    Public Function DeleteLampType(ByVal LampTypeID As Integer) As Boolean
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim res As Boolean

        myConnection.ConnectionString = Constants.DigitArqConnectionString
        myCommand.Connection = myConnection
        Try
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("DELETE FROM LampType WHERE LampTypeID='{0}'", LampTypeID)
            myCommand.ExecuteNonQuery()
        Catch e As SqlException
            res = False
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            myConnection.Close()
            res = True
        End Try
        Return res
    End Function

#End Region

#Region "DELETE MeteringMode"

    Public Function DeleteMeteringMode(ByVal MeteringModeID As Integer) As Boolean
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim res As Boolean

        myConnection.ConnectionString = Constants.DigitArqConnectionString
        myCommand.Connection = myConnection
        Try
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("DELETE FROM MeteringModes WHERE MeteringModeID='{0}'", MeteringModeID)
            myCommand.ExecuteNonQuery()
        Catch e As SqlException
            res = False
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            myConnection.Close()
            res = True
        End Try
        Return res
    End Function

#End Region

#Region "DELETE AutoFocus"

    Public Function DeleteAutoFocus(ByVal AutoFocusID As Integer) As Boolean
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim res As Boolean

        myConnection.ConnectionString = Constants.DigitArqConnectionString
        myCommand.Connection = myConnection
        Try
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("DELETE FROM AutoFocus WHERE AutoFocusID='{0}'", AutoFocusID)
            myCommand.ExecuteNonQuery()
        Catch e As SqlException
            res = False
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            myConnection.Close()
            res = True
        End Try
        Return res
    End Function

#End Region

#Region "DELETE File"

    Public Function DeleteFile(ByVal FileID As Int64) As Boolean
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim res As Boolean

        myConnection.ConnectionString = Constants.DigitArqConnectionString
        myCommand.Connection = myConnection
        Try
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("DELETE FROM DOFiles WHERE FileID='{0}'", FileID)
            myCommand.ExecuteNonQuery()
        Catch e As SqlException
            res = False
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            myConnection.Close()
            res = True
        End Try
        Return res
    End Function

#End Region

#Region "DELETE DigitalObject"

    Public Function DeleteDigitalObject(ByVal DigitalObjectID As Int64) As Boolean
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim res As Boolean

        myConnection.ConnectionString = Constants.DigitArqConnectionString
        myCommand.Connection = myConnection
        Try
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("DELETE FROM DigitalObjects WHERE DigitalObjectID={0}", DigitalObjectID)
            myCommand.ExecuteNonQuery()
        Catch e As SqlException
            res = False
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            myConnection.Close()
            res = True
        End Try
        Return res
    End Function

#End Region

#Region "DELETE ReformattingNorm"

    Public Function DeleteReformattingNorm(ByVal intReformattingNormID As Integer)
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection

        myConnection.ConnectionString = Constants.DigitArqConnectionString
        myCommand.Connection = myConnection
        Try
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("DELETE FROM ReformattingNorms WHERE ReformattingNormID = '{0}'", intReformattingNormID)
            myCommand.ExecuteNonQuery()
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            myConnection.Close()
        End Try
    End Function

#End Region

#Region "DELETE ReformattingMethod"

    Public Function DeleteReformattingMethod(ByVal intReformattingMethodID As Integer)
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection

        myConnection.ConnectionString = Constants.DigitArqConnectionString
        myCommand.Connection = myConnection
        Try
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("DELETE FROM ReformattingMethods WHERE ReformattingMethodID = '{0}'", intReformattingMethodID)
            myCommand.ExecuteNonQuery()
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            myConnection.Close()
        End Try
    End Function

#End Region

#End Region


#Region "getFile(nomeImg, DigitalObjectID)"

    Function getFile(ByVal ImageName As String, ByVal intDOID As Int64)
        Dim fs As FileStream = New FileStream(Application.StartupPath & "\view1.pdf", FileMode.Create, System.IO.FileAccess.Write)
        Dim res As Object
        Dim strCn As String = Constants.DigitArqConnectionString

        Dim cn As New SqlConnection(strCn)
        Dim cmd As New SqlCommand("SELECT FileID, Image FROM DOFiles " & _
                                  "WHERE Name = '" & ImageName & "' and DigitalObjectID = " & intDOID & " AND Image IS NOT NULL", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            dr = cmd.ExecuteReader
            If dr.Read Then
                Dim bytBLOBData(dr.GetBytes(1, 0, Nothing, 0, Integer.MaxValue) - 1) As Byte
                dr.GetBytes(1, 0, bytBLOBData, 0, bytBLOBData.Length)
                Dim stmBLOBData As New MemoryStream(bytBLOBData)
                If bytBLOBData.GetValue(0) = 0 Then
                    Directory.Delete(Application.StartupPath & "\view1.pdf")
                    Exit Function
                Else
                    fs.Write(bytBLOBData, 0, bytBLOBData.Length)
                    fs.Close()
                End If
            Else
                If Directory.Exists(Application.StartupPath & "\view1.pdf") Then
                    Directory.Delete(Application.StartupPath & "\view1.pdf")
                End If
            End If
        Catch e As Exception
            MsgBox("Error: " & e.Message, MsgBoxStyle.Critical)
        Finally
            dr.Close()
        End Try
    End Function

#End Region


#Region "getImage(nomeImg, DigitalObjectID)"

    Function getImage(ByVal ImageName As String, ByVal intDOID As Int64) As System.Drawing.Image
        Dim image As System.Drawing.Image
        Dim res As Object
        Dim strCn As String = Constants.DigitArqConnectionString

        Dim cn As New SqlConnection(strCn)
        Dim cmd As New SqlCommand("SELECT FileID, Image FROM DOFiles " & _
                                  "WHERE Name = '" & ImageName & "' AND DigitalObjectID = " & intDOID & " AND Image IS NOT NULL", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            dr = cmd.ExecuteReader
            If dr.Read Then
                Dim bytBLOBData(dr.GetBytes(1, 0, Nothing, 0, Integer.MaxValue) - 1) As Byte
                dr.GetBytes(1, 0, bytBLOBData, 0, bytBLOBData.Length)
                Dim stmBLOBData As New MemoryStream(bytBLOBData)
                If bytBLOBData.GetValue(0) = 0 Then
                    Exit Function
                Else
                    image = image.FromStream(stmBLOBData)
                    res = image
                End If
            End If
        Catch e As Exception
            MsgBox("Error: " & e.Message, MsgBoxStyle.Critical)
        Finally
            dr.Close()
        End Try
        Return res
    End Function

#End Region


#Region "gets name of last digital object of a given project"

    Function LastDO(ByVal handle As String) As String
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim myReader As SqlDataReader
        Dim res As String
        Try
            myConnection.ConnectionString = Constants.DigitArqConnectionString
            myCommand.Connection = myConnection
            myConnection.Open()
            myCommand.CommandText = "SELECT TOP 1 Name " & _
                                    "FROM DigitalObjects " & _
                                    "WHERE Name like '" & handle & "%' " & _
                                    "ORDER BY DigitalObjectID DESC"
            myReader = myCommand.ExecuteReader
            While myReader.Read
                res = myReader.GetValue(0)
            End While
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        Finally
            myReader.Close()
            myConnection.Close()
        End Try
        Return res
    End Function

#End Region


#Region "gets id of last digital object added at database"

    Function LastDO() As Integer
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim res As Integer
        Try
            myConnection.ConnectionString = Constants.DigitArqConnectionString
            myCommand.Connection = myConnection
            myConnection.Open()
            myCommand.CommandText = "SELECT MAX(DigitalObjectID) FROM DigitalObjects"
            res = CInt(myCommand.ExecuteScalar)
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        Finally
            myConnection.Close()
        End Try
        Return res
    End Function

#End Region


#Region "gets id of last image added at database"

    Public Function LastImage() As Integer
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim res As Integer
        Try
            myConnection.ConnectionString = Constants.DigitArqConnectionString
            myCommand.Connection = myConnection
            myConnection.Open()
            myCommand.CommandText = "SELECT MAX(FileID) From DOFiles"
            res = CInt(myCommand.ExecuteScalar)
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        Finally
            myConnection.Close()
        End Try
        Return res
    End Function

#End Region


#Region "gets location of a project"

    Public Function getLocationProject(ByVal ProjectID As Int64) As String
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim res As String
        Try
            myConnection.ConnectionString = Constants.DigitArqConnectionString
            myCommand.Connection = myConnection
            myConnection.Open()
            myCommand.CommandText = "SELECT Location FROM Projects WHERE ProjectID=" & ProjectID
            res = CStr(myCommand.ExecuteScalar)
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        Finally
            myConnection.Close()
        End Try
        Return res
    End Function

#End Region


#Region "gets id of digitalization profile"

    Public Function getProfileID(ByVal FileID As Integer) As Integer
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim res As Integer
        Try
            myConnection.ConnectionString = Constants.DigitArqConnectionString
            myCommand.Connection = myConnection
            myConnection.Open()
            myCommand.CommandText = "SELECT ProfileID FROM DOFiles WHERE FileID=" & FileID
            res = CInt(myCommand.ExecuteScalar)
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        Finally
            myConnection.Close()
        End Try
        Return res
    End Function

#End Region


#Region "getRevisionInterval"

    Public Function getRevisionInterval() As Integer
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim res As Integer
        Try
            myConnection.ConnectionString = Constants.DigitArqConnectionString
            myCommand.Connection = myConnection
            myConnection.Open()
            myCommand.CommandText = "SELECT top 1 RevisionValue From RevisionInterval"
            res = CInt(myCommand.ExecuteScalar)
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        Finally
            myConnection.Close()
        End Try
        Return res
    End Function

#End Region


#Region "getUserID"

    Public Shared Function getUserID(ByVal CheckUsername As String, _
                                    ByVal CheckPassword As String) As Integer

        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = Constants.DigitArqConnectionString

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection
        Dim Result As Integer

        Try
            SQLConnection.Open()
            SQLCommand.CommandText = String.Format( _
            "SELECT EmployeeID From Employees WHERE Username = '{0}' and Password = '{1}'", _
            CheckUsername, Cryptography.EncryptString(CheckPassword))
            Result = CInt(SQLCommand.ExecuteScalar())
        Catch ex As Exception
            MsgBoxException(ex)
        Finally
            SQLConnection.Close()
        End Try

        Return Result
    End Function

#End Region


#Region "getUsername"

    Public Shared Function getUsername(ByVal UserID As Integer) As String

        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = Constants.DigitArqConnectionString

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection
        Dim Result As String

        Try
            SQLConnection.Open()
            SQLCommand.CommandText = String.Format( _
            "SELECT Username From Employees WHERE EmployeeId = {0}", UserID)
            Result = CStr(SQLCommand.ExecuteScalar())
        Catch ex As Exception
            MsgBoxException(ex)
        Finally
            SQLConnection.Close()
        End Try

        Return Result
    End Function

#End Region


#Region "getRevisionDateTimeDO"

    Public Shared Function getRevisionDateTimeDO(ByVal DigitalObjectID As Int64) As String

        Dim SQLConnection As SqlConnection = New SqlConnection
        SQLConnection.ConnectionString = Constants.DigitArqConnectionString

        Dim SQLCommand As New SqlCommand
        SQLCommand.Connection = SQLConnection
        Dim Result As String

        Try
            SQLConnection.Open()
            SQLCommand.CommandText = String.Format("SELECT RevisionDateTime FROM DigitalObjects " & _
                "WHERE DigitalObjectID = '{0}'", DigitalObjectID)

            Result = CStr(SQLCommand.ExecuteScalar())
        Catch ex As Exception
            MsgBoxException(ex)
        Finally
            SQLConnection.Close()
        End Try

        Return Result
    End Function

#End Region


#Region "getFileID(ByVal DigitalObjectID As Integer, ByVal fileName As String)"

    Public Function getFileID(ByVal DigitalObjectID As Int64, ByVal fileName As String) As Object
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim res As Object
        Try
            myConnection.ConnectionString = Constants.DigitArqConnectionString
            myCommand.Connection = myConnection
            myConnection.Open()
            myCommand.CommandText = "SELECT FileID FROM DOFiles " & _
                                    " WHERE DigitalObjectID =" & DigitalObjectID & _
                                    " AND Name='" & fileName & "'"
            res = CInt(myCommand.ExecuteScalar)

        Catch e As Exception
            MessageBoxes.MsgBoxException(e)
        Finally
            myConnection.Close()
        End Try
        Return res
    End Function

#End Region


#Region "getProfileID(ByVal DigitalObjectID As Integer, ByVal fileName As String)"

    Public Function getProfileID(ByVal DigitalObjectID As Integer, ByVal FileName As String) As Object
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim res As Object
        Try
            myConnection.ConnectionString = Constants.DigitArqConnectionString
            myCommand.Connection = myConnection
            myConnection.Open()
            myCommand.CommandText = "SELECT ProfileID FROM DOFiles " & _
                                    " WHERE DigitalObjectID =" & DigitalObjectID & _
                                    " AND Name='" & FileName & "'"

            res = CInt(myCommand.ExecuteScalar)

        Catch e As Exception
            MessageBoxes.MsgBoxException(e)
        Finally
            myConnection.Close()
        End Try
        Return res
    End Function

#End Region


#Region "getCheckSumValue(ByVal DigitalObjectID As Integer, ByVal fileName As String)"

    Public Function getCheckSumValue(ByVal DigitalObjectID As Int64, ByVal fileName As String) As Object
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim res As Object
        Try
            myConnection.ConnectionString = Constants.DigitArqConnectionString
            myCommand.Connection = myConnection
            myConnection.Open()
            myCommand.CommandText = "SELECT CheckSumValue FROM DOFiles " & _
                                    " WHERE DigitalObjectID =" & DigitalObjectID & _
                                    " AND Name='" & fileName & "'"
            res = CStr(myCommand.ExecuteScalar)

        Catch e As Exception
            MessageBoxes.MsgBoxException(e)
        Finally
            myConnection.Close()
        End Try
        Return res
    End Function


#End Region


#Region "getProjectID(ByVal DigitalObjectID As Integer)"

    Public Function getProjectID(ByVal DigitalObjectID As Int64) As Object
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim res As Object
        Try
            myConnection.ConnectionString = Constants.DigitArqConnectionString
            myCommand.Connection = myConnection
            myConnection.Open()
            myCommand.CommandText = "SELECT ProjectID FROM DigitalObjects " & _
                                    " WHERE DigitalObjectID=" & DigitalObjectID
            res = CInt(myCommand.ExecuteScalar)

        Catch e As Exception
            MessageBoxes.MsgBoxException(e)
        Finally
            myConnection.Close()
        End Try
        Return res
    End Function



#End Region


#Region "getIdFormatJPEG()"

    Function getIdFormatJPEG() As Integer
        Dim strCn As String = Constants.DigitArqConnectionString
        Dim cn As New SqlConnection(strCn)
        Dim res As Integer
        Dim cmd As New SqlCommand("SELECT FormatID FROM ImageFormat " & _
                                  "WHERE Value LIKE 'jpeg'", cn)
        Try
            cn.Open()
            res = cmd.ExecuteScalar

        Catch e As Exception
            MessageBoxes.MsgBoxException(e)
        End Try
        Return res
    End Function

#End Region


#Region "getDOSize(DigitalObjectID)"

    '// we want count size just of JPEG images (the derivativas have been 
    '// generated on this format) 
    Function getDOSize(ByVal DigitalObjectID As Int64) As Integer
        Dim strCn As String = Constants.DigitArqConnectionString
        Dim cn As New SqlConnection(strCn)
        Dim res As Integer
        Dim FormatID As Integer = getIdFormatJPEG()
        Dim cmd As New SqlCommand("SELECT SUM(ImageSize) as SizeDO FROM DOFiles " & _
                                  "WHERE DigitalObjectID = " & DigitalObjectID & " AND FormatID =" & FormatID, cn)
        Try
            cn.Open()
            res = cmd.ExecuteScalar
        Catch e As Exception
            MessageBoxes.MsgBoxException(e)
        End Try
        Return res
    End Function

#End Region


#Region "count number of files that are associated at a digital object"

    Function CountFiles(ByVal DigitalObjectID As Int64) As Integer
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim res As Integer
        Try
            myConnection.ConnectionString = Constants.DigitArqConnectionString
            myCommand.Connection = myConnection
            myConnection.Open()
            myCommand.CommandText = "SELECT Count(FileID) FROM DOFiles WHERE DigitalObjectID = " & DigitalObjectID
            res = CInt(myCommand.ExecuteScalar)
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        Finally
            myConnection.Close()
        End Try
        Return res
    End Function

#End Region


#Region "set number of files that are associated at a digital object"

    Function setRevisionDateTime(ByVal intDigitalObjectID As Int64, ByVal strRevisionDateTime As String) As Boolean
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim res As Integer
        Try
            myConnection.ConnectionString = Constants.DigitArqConnectionString
            myCommand.Connection = myConnection
            myConnection.Open()
            myCommand.CommandText = String.Format("UPDATE DigitalObjects SET RevisionDateTime='{0}' " & _
                "WHERE DigitalObjectID = {1}", strRevisionDateTime, intDigitalObjectID)

            myCommand.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
            Return False
        Finally
            myConnection.Close()
        End Try
        Return res
    End Function

#End Region


#Region "set number of files that are associated at a digital object"

    Function setQuantityOfTerminalObjects(ByVal DigitalObjectID As Int64) As Integer
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim res As Integer
        Try
            myConnection.ConnectionString = Constants.DigitArqConnectionString
            myCommand.Connection = myConnection
            myConnection.Open()
            myCommand.CommandText = String.Format("UPDATE DigitalObjects SET QuantityOfTerminalObjects={0} " & _
                "WHERE DigitalObjectID = {1}", CountFiles(DigitalObjectID), DigitalObjectID)

            res = myCommand.ExecuteScalar
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        Finally
            myConnection.Close()
        End Try
        Return res
    End Function

    'Function setQuantityOfTerminalObjectsDec(ByVal DigitalObjectID As Int64) As Integer
    '    Dim myCommand As New SqlCommand
    '    Dim myConnection As New SqlConnection
    '    Dim res As Integer
    '    Try
    '        myConnection.ConnectionString = Constants.DigitArqConnectionString
    '        myCommand.Connection = myConnection
    '        myConnection.Open()
    '        myCommand.CommandText = String.Format("UPDATE DigitalObjects SET QuantityOfTerminalObjects={0} " & _
    '            "WHERE DigitalObjectID = {1}", CountFiles(DigitalObjectID), DigitalObjectID)

    '        myCommand.ExecuteNonQuery()
    '    Catch ex As Exception
    '        MessageBoxes.MsgBoxException(ex)
    '    Finally
    '        myConnection.Close()
    '    End Try
    '    Return res
    'End Function

#End Region


#Region "count number of images that have same name associated at a digital object"

    Function CountImages(ByVal DigitalObjectID As Int64, ByVal NameImage As String) As Integer
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim res As Integer
        Try
            myConnection.ConnectionString = Constants.DigitArqConnectionString
            myCommand.Connection = myConnection
            myConnection.Open()
            myCommand.CommandText = "SELECT Count(FileID) From DOFiles WHERE DigitalObjectID = " & _
                DigitalObjectID & " AND Name='" & NameImage & "'"

            res = CInt(myCommand.ExecuteScalar)
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        Finally
            myConnection.Close()
        End Try
        Return res
    End Function

#End Region


#Region "setActive"

    Function setActive(ByVal intDigitalObjectID As Integer, ByVal intActive As Integer) As Boolean
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim res As Boolean
        Try
            myConnection.ConnectionString = Constants.DigitArqConnectionString
            myCommand.Connection = myConnection
            myConnection.Open()
            myCommand.CommandText = "UPDATE DigitalObjects SET Active =" & intActive & " WHERE DigitalObjectID = " & intDigitalObjectID
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            res = False
            MessageBoxes.MsgBoxException(ex)
        Finally
            res = True
            myConnection.Close()
        End Try
        Return res
    End Function

#End Region


#Region "getIdBitDepth - giving a value tests if exists already in BD - if not insert and return its id"

    'Public Function getIdBitDepth(ByVal strValue As String) As Integer
    '    Dim myCommand As New SqlCommand
    '    Dim myConnection As New SqlConnection
    '    Dim res As Integer
    '    Try
    '        myConnection.ConnectionString = Constants.DigitArqConnectionString
    '        myCommand.Connection = myConnection
    '        myConnection.Open()
    '        myCommand.CommandText = "SELECT BitDepthID FROM ImageBitDepth WHERE Value = '" & strValue & "'"
    '        res = CInt(myCommand.ExecuteScalar)

    '        If res = 0 Then
    '            Me.InsertImageBitDepth("", strValue)
    '            res = Me.getIdBitDepth(strValue)
    '        End If
    '    Catch ex As Exception
    '        MessageBoxes.MsgBoxException(ex)
    '    Finally
    '        myConnection.Close()
    '    End Try
    '    Return res
    'End Function

#End Region


#Region "getIdFormat - giving a value tests if exists already in BD - if not insert and return its id"

    'Public Function getIdFormat(ByVal strValue As String) As Integer
    '    Dim myCommand As New SqlCommand
    '    Dim myConnection As New SqlConnection
    '    Dim res As Integer
    '    Try
    '        myConnection.ConnectionString = Constants.DigitArqConnectionString
    '        myCommand.Connection = myConnection
    '        myConnection.Open()
    '        myCommand.CommandText = "SELECT FormatID FROM ImageFormat WHERE Value = '" & strValue & "'"
    '        res = CInt(myCommand.ExecuteScalar)

    '        If res = 0 Then
    '            Me.InsertImageFormat("", strValue)
    '            res = Me.getIdFormat(strValue)
    '        End If
    '    Catch ex As Exception
    '        MessageBoxes.MsgBoxException(ex)
    '    Finally
    '        myConnection.Close()
    '    End Try
    '    Return res
    'End Function

#End Region


#Region "getIdCompression - giving a value tests if exists already in BD - if not insert and return its id"

    'Public Function getIdCompression(ByVal strValue As String) As Integer
    '    Dim myCommand As New SqlCommand
    '    Dim myConnection As New SqlConnection
    '    Dim res As Integer
    '    Try
    '        myConnection.ConnectionString = Constants.DigitArqConnectionString
    '        myCommand.Connection = myConnection
    '        myConnection.Open()
    '        myCommand.CommandText = "SELECT CompressionID FROM ImageCompression WHERE Value = '" & strValue & "'"
    '        res = CInt(myCommand.ExecuteScalar)

    '        If res = 0 Then
    '            Me.InsertImageFormat("", strValue)
    '            res = Me.getIdFormat(strValue)
    '        End If
    '    Catch ex As Exception
    '        MessageBoxes.MsgBoxException(ex)
    '    Finally
    '        myConnection.Close()
    '    End Try
    '    Return res
    'End Function

#End Region


#Region "getIdRevisionInterval"

    Public Function getIdRevisionInterval() As Integer
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim res As Integer
        Try
            myConnection.ConnectionString = Constants.DigitArqConnectionString
            myCommand.Connection = myConnection
            myConnection.Open()
            myCommand.CommandText = "SELECT TOP 1 RevisionValue FROM RevisionInterval ORDER BY RevisionIntervalID DESC"
            res = CInt(myCommand.ExecuteScalar)
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        Finally
            myConnection.Close()
        End Try
        Return res
    End Function

#End Region


#Region "getDOStructure -- gets the xml structure of DigitalObject"

    Public Function getDOStructure(ByVal intDigitalObjectID As Int64) As String
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim xml As String
        Try
            myConnection.ConnectionString = Constants.DigitArqConnectionString
            myCommand.Connection = myConnection
            myConnection.Open()
            myCommand.CommandText = "SELECT Structure FROM DigitalObjects WHERE DigitalObjectID=" & intDigitalObjectID
            xml = CStr(myCommand.ExecuteScalar)
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        Finally
            myConnection.Close()
        End Try
        Return xml
    End Function

#End Region


#Region "getDOName -- gets the xml structure of DigitalObject"

    Public Function getDOName(ByVal intDigitalObjectID As Int64) As String
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim xml As String
        Try
            myConnection.ConnectionString = Constants.DigitArqConnectionString
            myCommand.Connection = myConnection
            myConnection.Open()
            myCommand.CommandText = "SELECT Name FROM DigitalObjects WHERE DigitalObjectID=" & intDigitalObjectID
            xml = CStr(myCommand.ExecuteScalar)
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        Finally
            myConnection.Close()
        End Try
        Return xml
    End Function

#End Region


#Region "getProjectName -- gets the xml structure of DigitalObject"

    Public Function getProjectName(ByVal intProjectID As Int64) As String
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim xml As String
        Try
            myConnection.ConnectionString = Constants.DigitArqConnectionString
            myCommand.Connection = myConnection
            myConnection.Open()
            myCommand.CommandText = "SELECT Name FROM Projects WHERE ProjectID=" & intProjectID
            xml = CStr(myCommand.ExecuteScalar)
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        Finally
            myConnection.Close()
        End Try
        Return xml
    End Function

#End Region


#Region "setDOStructure -- sets the xml structure of DigitalObject"

    Public Function setDOStructure(ByVal intDigitalObjectID As Int64, ByVal strXML As String)
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Try
            myConnection.ConnectionString = Constants.DigitArqConnectionString
            myCommand.Connection = myConnection
            myConnection.Open()
            myCommand.CommandText = "UPDATE DigitalObjects SET Structure = '" & strXML & _
                "' WHERE DigitalObjectID = " & intDigitalObjectID
            myCommand.ExecuteNonQuery()
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        Finally
            myConnection.Close()
        End Try
    End Function

#End Region

#Region "SqlCommandSelectDoToTree"

    'Public Function SqlCommandSelectDoToTree(ByVal value As Object, ByVal fieldIn As String) As ArrayList
    '    Dim myCommand As New SqlCommand
    '    Dim myConnection As New SqlConnection
    '    Dim myReader As SqlDataReader
    '    Dim res As New ArrayList
    '    Try
    '        myConnection.ConnectionString = Constants.GODConnectionString
    '        myCommand.Connection = myConnection
    '        myConnection.Open()
    '        myCommand.CommandText = "SELECT * FROM DOImages WHERE " & fieldIn & " = " & "'" & value & "' ORDER BY SORT"
    '        myReader = myCommand.ExecuteReader

    '        Dim strFields() As String = {"ID", "ID_DigitalObject", "ID_Image", "dateCreated", "Moveable", "Root", _
    '                                     "ImageIndex", "ParentID", "ImageLevel", "Sort", "Name", "FullName"}

    '        res = DataReaderToArrayList(myReader, strFields)

    '    Catch e As Exception
    '        MsgBox(e.Message)
    '    Finally
    '        myReader.Close()
    '        myConnection.Close()
    '    End Try
    '    Return res
    'End Function

    Private Function DataReaderToArrayList(ByVal dReader As SqlDataReader, ByVal strField() As String) As ArrayList
        Dim i As Integer
        Dim str As String
        Dim res As New ArrayList
        Dim arg As New Object

        While (dReader.Read)
            Dim col As New Collection
            Dim j As Integer = 1
            For i = 0 To strField.Length - 1
                If dReader.Item(strField(i)).GetType.ToString = "System.DBNull" Then
                    arg = " "
                    col.Add(arg, j)
                Else
                    arg = dReader.Item(strField(i))
                    col.Add(arg, j)
                End If
                j += 1
            Next
            res.Add(col)
        End While
        Return res
    End Function

#End Region

    Function generateHash(ByVal pathNameImageTIFF As String) As String
        Dim fsBLOBFileTIFF As New FileStream(pathNameImageTIFF, FileMode.Open, FileAccess.Read)
        Dim bytBLOBDataTIFF(fsBLOBFileTIFF.Length() - 1) As Byte
        fsBLOBFileTIFF.Read(bytBLOBDataTIFF, 0, bytBLOBDataTIFF.Length)
        Dim strRet As String = Encrypt.GenerateHash(bytBLOBDataTIFF)
        Return strRet
    End Function

    '//select the field "field" from table "table" 
    Public Function SqlCommandSelect(ByVal field As String, ByVal table As String) As ArrayList 'Visto
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim myReader As SqlDataReader
        Dim res As New ArrayList
        Try
            myConnection.ConnectionString = Constants.DigitArqConnectionString
            myCommand.Connection = myConnection
            myConnection.Open()
            myCommand.CommandText = "SELECT " & field & " FROM " & table
            myReader = myCommand.ExecuteReader
            While (myReader.Read)
                Dim Name As String = myReader.Item(field)
                res.Add(Name)
            End While
        Catch e As Exception
            MsgBox(e.Message)
        Finally
            myReader.Close()
            myConnection.Close()
            myConnection.Dispose()
        End Try
        Return res
    End Function

    Public Function SelectByCommand(ByVal strCommand As String) As DataSet
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim myCommand As String
        Try
            myCommand = strCommand
            myReader = New SqlDataAdapter(myCommand, Constants.DigitArqConnectionString)
            myReader.Fill(myData)
        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            myReader.Dispose()
        End Try
        Return myData
    End Function

End Class
