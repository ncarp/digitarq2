
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

Imports System.Data.SqlClient
Imports System.io

Public Class ReportDataSetBuilder

    'Generate digitalization profiles report data
    Public Function GenerateDPReportData() As DigitalizationProfilesData
        Dim myData As New DigitalizationProfilesData
        Dim myReader As SqlDataAdapter
        Dim myCommand As String
        Try
            If File.Exists(AppDomain.CurrentDomain.BaseDirectory & Constants.LogoPath) Then
                Dim fs As FileStream
                Dim br As BinaryReader
                fs = New FileStream(AppDomain.CurrentDomain.BaseDirectory & Constants.LogoPath, FileMode.Open, FileAccess.Read)
                br = New BinaryReader(fs)
                Dim imgbyte(fs.Length) As Byte
                imgbyte = br.ReadBytes(Convert.ToInt32(fs.Length))
                br.Close()
                fs.Close()
                Dim drow As DataRow
                drow = myData.Logo.NewRow
                drow(0) = imgbyte
                myData.Logo.Rows.Add(drow)
            End If

            myCommand = "SELECT * FROM DigitalizationProfiles ORDER BY ProfileName"

            myReader = New SqlDataAdapter(myCommand, Constants.DigitArqConnectionString)
            myReader.Fill(myData, "DigitalizationProfiles")

        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            myReader.Dispose()
        End Try
        Return myData
    End Function


    'Generate DO revision report data
    Public Function GenerateDORevisionReportData(ByVal LVDOCollection As ListView.ListViewItemCollection) As DORevisionData
        Dim myData As New DORevisionData
        Dim myReader As SqlDataAdapter
        Dim myCommand As String
        Dim strDigitalObjectIDList As String = GetDigitalObjectIDList(LVDOCollection)
        Try
            If File.Exists(AppDomain.CurrentDomain.BaseDirectory & Constants.LogoPath) Then
                Dim fs As FileStream
                Dim br As BinaryReader
                fs = New FileStream(AppDomain.CurrentDomain.BaseDirectory & Constants.LogoPath, FileMode.Open, FileAccess.Read)
                br = New BinaryReader(fs)
                Dim imgbyte(fs.Length) As Byte
                imgbyte = br.ReadBytes(Convert.ToInt32(fs.Length))
                br.Close()
                fs.Close()
                Dim drow As DataRow
                drow = myData.Logo.NewRow
                drow(0) = imgbyte
                myData.Logo.Rows.Add(drow)
            End If

            myCommand = "SELECT DigitalObjectID, ProjectID, Name, ArchiveID, RevisionDateTime, QuantityOfTerminalObjects, TopographicalQuota " & _
                        "FROM DigitalObjects " & _
                        "WHERE DigitalObjectID IN " & strDigitalObjectIDList

            myReader = New SqlDataAdapter(myCommand, Constants.DigitArqConnectionString)
            myReader.Fill(myData, "DigitalObjects")

        Catch e As Exception
            MsgBox(e.Message)
        Finally
            myReader.Dispose()
        End Try
        Return myData
    End Function


    'Generate metadata of digital objects report data
    Public Function GenerateMIDigitalObjectsReportData(ByVal LVDOCollection As ListView.ListViewItemCollection) As DigitalObjectsData
        Dim myData As New DigitalObjectsData
        Dim myReader As SqlDataAdapter
        Dim myCommand As String
        Try
            If File.Exists(AppDomain.CurrentDomain.BaseDirectory & Constants.LogoPath) Then
                Dim fs As FileStream
                Dim br As BinaryReader
                fs = New FileStream(AppDomain.CurrentDomain.BaseDirectory & Constants.LogoPath, FileMode.Open, FileAccess.Read)
                br = New BinaryReader(fs)
                Dim imgbyte(fs.Length) As Byte
                imgbyte = br.ReadBytes(Convert.ToInt32(fs.Length))
                Dim drow As DataRow
                drow = myData.Logo.NewRow
                drow(0) = imgbyte
                myData.Logo.Rows.Add(drow)
                br.Close()
                fs.Close()
            End If

            myCommand = "SELECT DigitalObjectID, Name, ArchiveID, CaptureEntityCorporate, " & _
                        "ArchiveDateTime, CreationDateTime, DepositDateTime,  " & _
                        "QuantityOfTerminalObjects, Username, TopographicalQuota " & _
                        "FROM DigitalObjects " & _
                        "WHERE DigitalObjectID IN " & GetDigitalObjectIDList(LVDOCollection)

            myReader = New SqlDataAdapter(myCommand, Constants.DigitArqConnectionString)
            myReader.Fill(myData, "DigitalObjects")

        Catch e As Exception
            MsgBox(e.Message)
        Finally
            myReader.Dispose()
        End Try
        Return myData
    End Function


    'Generate metadata of DO files report data
    Public Function GenerateMIImagesReportData(ByVal LVDOCollection As ListView.ListViewItemCollection) As DOImagesData
        Dim myData As New DOImagesData
        Dim myReader As SqlDataAdapter
        Dim myCommand As String

        Dim strDigitalObjectIDList As String = GetDigitalObjectIDList(LVDOCollection)
        Try
            If File.Exists(AppDomain.CurrentDomain.BaseDirectory & Constants.LogoPath) Then
                Dim fs As FileStream
                Dim br As BinaryReader
                fs = New FileStream(AppDomain.CurrentDomain.BaseDirectory & Constants.LogoPath, FileMode.Open, FileAccess.Read)
                br = New BinaryReader(fs)
                Dim imgbyte(fs.Length) As Byte
                imgbyte = br.ReadBytes(Convert.ToInt32(fs.Length))
                Dim drow As DataRow
                drow = myData.Logo.NewRow
                drow(0) = imgbyte
                myData.Logo.Rows.Add(drow)
                br.Close()
                fs.Close()
            End If

            myCommand = "SELECT DigitalObjectID, Name AS DOName, ArchiveID, ArchiveDateTime, QuantityOfTerminalObjects, TopographicalQuota, Username " & _
                        "FROM DigitalObjects " & _
                        "WHERE DigitalObjectID IN " & strDigitalObjectIDList

            myReader = New SqlDataAdapter(myCommand, Constants.DigitArqConnectionString)
            myReader.Fill(myData, "DigitalObjects")

            myCommand = "SELECT DOF.FileID, DOF.DigitalObjectID, DOF.Name, DOF.Compression, DOF.ColorSpace, DOF.LampTypeID, DOF.Resolution, DOF.ImageHeight, DOF.ImageWidth, DOF.BitDepth, DOF.MIMEType, DOF.ImageSize, TP.DeviceSource, TP.ScannerManufacturer, TP.ScannerModelName, TP.ScanningSoftware, TP.ScanningSoftwareVersionNo, TP.OperatingSystem, TP.OperatingSystem " & _
                        "FROM DOFiles DOF INNER JOIN DigitalObjects DO ON DOF.DigitalObjectID=DO.DigitalObjectID " & _
                        "INNER JOIN TechnologicalPlatform TP ON DOF.TplatformID=TP.TplatformID " & _
                        "WHERE DO.DigitalObjectID IN " & strDigitalObjectIDList

            myReader = New SqlDataAdapter(myCommand, Constants.DigitArqConnectionString)
            myReader.Fill(myData, "DOFiles")

            myCommand = "SELECT DISTINCT C.ID, C.Otherlevel, C.CompleteUnitID, C.UnitTitle " & _
                        "FROM Components C " & _
                        "INNER JOIN DaoGrp DG ON C.ID=DG.ComponentID " & _
                        "INNER JOIN DigitalObjects DO ON DG.DigitalObjectID=DO.DigitalObjectID " & _
                        "WHERE DO.DigitalObjectID IN " & strDigitalObjectIDList

            myReader = New SqlDataAdapter(myCommand, Constants.DigitArqConnectionString)
            myReader.Fill(myData, "Components")

            'myCommand = "SELECT * FROM DaoGrp " & _
            '            "WHERE DigitalObjectID IN " & strDigitalObjectIDList

            myCommand = "SELECT DISTINCT DG.DigitalObjectID, DG.ComponentID " & _
                        "FROM DigitalObjects DO " & _
                        "INNER JOIN DaoGrp DG ON DO.DigitalObjectID=DG.DigitalObjectID " & _
                        "WHERE DO.DigitalObjectID IN " & strDigitalObjectIDList

            myReader = New SqlDataAdapter(myCommand, Constants.DigitArqConnectionString)
            myReader.Fill(myData, "DaoGrp")

        Catch e As Exception
            MsgBox(e.Message)
        Finally
            myReader.Dispose()
        End Try
        Return myData
    End Function


    'Generate operators report data
    Public Function GenerateDOOperatorsReportData(ByVal LVDOCollection As ListView.ListViewItemCollection) As DOOperatorsData
        Dim myData As New DOOperatorsData
        Dim myReader As SqlDataAdapter
        Dim myCommand As String
        Dim strProjectIDList As String = GetDigitalObjectIDList(LVDOCollection)
        Try
            If File.Exists(AppDomain.CurrentDomain.BaseDirectory & Constants.LogoPath) Then
                Dim fs As FileStream
                Dim br As BinaryReader
                fs = New FileStream(AppDomain.CurrentDomain.BaseDirectory & Constants.LogoPath, FileMode.Open, FileAccess.Read)
                br = New BinaryReader(fs)
                Dim imgbyte(fs.Length) As Byte
                imgbyte = br.ReadBytes(Convert.ToInt32(fs.Length))
                Dim drow As DataRow
                drow = myData.Logo.NewRow
                drow(0) = imgbyte
                myData.Logo.Rows.Add(drow)
                br.Close()
                fs.Close()
            End If

            myCommand = "SELECT DigitalObjectID, ProjectID, Name, ArchiveDateTime, QuantityOfTerminalObjects, Username " & _
                        "FROM DigitalObjects " & _
                        "WHERE ProjectID IN " & strProjectIDList & _
                        " ORDER BY ArchiveDateTime ASC"

            myReader = New SqlDataAdapter(myCommand, Constants.DigitArqConnectionString)
            myReader.Fill(myData, "DigitalObjects")

            myCommand = "SELECT DISTINCT ID, CompleteUnitID " & _
                        "FROM Components C " & _
                        "INNER JOIN DaoGrp DG ON C.ID=DG.ComponentID " & _
                        "INNER JOIN DigitalObjects DO ON DG.DigitalObjectID=DO.DigitalObjectID " & _
                        "WHERE DO.ProjectID IN " & strProjectIDList

            myReader = New SqlDataAdapter(myCommand, Constants.DigitArqConnectionString)
            myReader.Fill(myData, "Components")

            myCommand = "SELECT DISTINCT DG.DigitalObjectID, DG.ComponentID " & _
                        "FROM DigitalObjects DO " & _
                        "INNER JOIN DaoGrp DG ON DO.DigitalObjectID=DG.DigitalObjectID " & _
                        "WHERE DO.ProjectID IN " & strProjectIDList

            myReader = New SqlDataAdapter(myCommand, Constants.DigitArqConnectionString)
            myReader.Fill(myData, "DaoGrp")

        Catch e As Exception
            MsgBox(e.Message)
        Finally
            myReader.Dispose()
        End Try
        Return myData
    End Function


    'Generate preservation information report data
    Public Function GeneratePreservationInfoReportData(ByVal LVDOCollection As ListView.ListViewItemCollection) As PreservationInfoData
        Dim myData As New PreservationInfoData
        Dim myReader As SqlDataAdapter
        Dim myCommand As String
        Dim strDigitalObjectIDList As String = GetDigitalObjectIDList(LVDOCollection)
        Try
            If File.Exists(AppDomain.CurrentDomain.BaseDirectory & Constants.LogoPath) Then
                Dim fs As FileStream
                Dim br As BinaryReader
                fs = New FileStream(AppDomain.CurrentDomain.BaseDirectory & Constants.LogoPath, FileMode.Open, FileAccess.Read)
                br = New BinaryReader(fs)
                Dim imgbyte(fs.Length) As Byte
                imgbyte = br.ReadBytes(Convert.ToInt32(fs.Length))
                Dim drow As DataRow
                drow = myData.Logo.NewRow
                drow(0) = imgbyte
                myData.Logo.Rows.Add(drow)
                br.Close()
                fs.Close()
            End If

            myCommand = "SELECT DigitalObjectID, Name, ArchiveDateTime, ArchiveID, Username, QuantityOfTerminalObjects " & _
                        "FROM DigitalObjects " & _
                        "WHERE DigitalObjectID IN " & strDigitalObjectIDList

            myReader = New SqlDataAdapter(myCommand, Constants.DigitArqConnectionString)
            myReader.Fill(myData, "DigitalObjects")

            myCommand = "SELECT PA.*, RM.ReformattingMethod " & _
                        "FROM PreservationAction PA " & _
                        "LEFT JOIN ReformattingMethods RM ON PA.ReformattingMethodID=RM.ReformattingMethodID " & _
                        "WHERE DigitalObjectID IN " & strDigitalObjectIDList

            myReader = New SqlDataAdapter(myCommand, Constants.DigitArqConnectionString)
            myReader.Fill(myData, "PreservationAction")

            myCommand = "SELECT * FROM ReformattingNorms"

            myReader = New SqlDataAdapter(myCommand, Constants.DigitArqConnectionString)
            myReader.Fill(myData, "ReformattingNorms")

            myCommand = "SELECT * FROM PreservationNorms PN " & _
                        "INNER JOIN PreservationAction PA ON PN.PreservationActionID=PA.PreservationActionID " & _
                        "WHERE PA.DigitalObjectID IN " & strDigitalObjectIDList

            myReader = New SqlDataAdapter(myCommand, Constants.DigitArqConnectionString)
            myReader.Fill(myData, "PreservationNorms")

        Catch e As Exception
            MsgBox(e.Message)
        Finally
            myReader.Dispose()
        End Try
        Return myData
    End Function


    'Generate digitalization projects report data
    Public Function GenerateDigitalizationProjectsReportData(ByVal LVDOCollection As ListView.ListViewItemCollection) As ProjectsData
        Dim myData As New ProjectsData
        Dim myReader As SqlDataAdapter
        Dim myCommand As String
        Dim strProjectsIDList As String = GetDigitalObjectIDList(LVDOCollection)
        Try
            If File.Exists(AppDomain.CurrentDomain.BaseDirectory & Constants.LogoPath) Then
                Dim fs As FileStream
                Dim br As BinaryReader
                fs = New FileStream(AppDomain.CurrentDomain.BaseDirectory & Constants.LogoPath, FileMode.Open, FileAccess.Read)
                br = New BinaryReader(fs)
                Dim imgbyte(fs.Length) As Byte
                imgbyte = br.ReadBytes(Convert.ToInt32(fs.Length))
                Dim drow As DataRow
                drow = myData.Logo.NewRow
                drow(0) = imgbyte
                myData.Logo.Rows.Add(drow)
                br.Close()
                fs.Close()
            End If

            myCommand = "SELECT ProjectID, Name, UserName, CreationDateTime " & _
                        "FROM Projects " & _
                        "WHERE ProjectID IN " & strProjectsIDList

            myReader = New SqlDataAdapter(myCommand, Constants.DigitArqConnectionString)
            myReader.Fill(myData, "Projects")

            myCommand = "SELECT DigitalObjectID, ProjectID, Name, ArchiveDateTime, QuantityOfTerminalObjects, Username " & _
                        "FROM DigitalObjects " & _
                        "WHERE ProjectID IN " & strProjectsIDList

            myReader = New SqlDataAdapter(myCommand, Constants.DigitArqConnectionString)
            myReader.Fill(myData, "DigitalObjects")

        Catch e As Exception
            MsgBox(e.Message)
        Finally
            myReader.Dispose()
        End Try
        Return myData
    End Function


    'Generate reformatting methods report data
    Public Function GenerateReformattingMethodsReportData() As ReformattingMethodsData
        Dim myData As New ReformattingMethodsData
        Dim myReader As SqlDataAdapter
        Dim myCommand As String
        Try
            If File.Exists(AppDomain.CurrentDomain.BaseDirectory & Constants.LogoPath) Then
                Dim fs As FileStream
                Dim br As BinaryReader
                fs = New FileStream(AppDomain.CurrentDomain.BaseDirectory & Constants.LogoPath, FileMode.Open, FileAccess.Read)
                br = New BinaryReader(fs)
                Dim imgbyte(fs.Length) As Byte
                imgbyte = br.ReadBytes(Convert.ToInt32(fs.Length))
                Dim drow As DataRow
                drow = myData.Logo.NewRow
                drow(0) = imgbyte
                myData.Logo.Rows.Add(drow)
                br.Close()
                fs.Close()
            End If

            myCommand = "SELECT * FROM ReformattingMethods ORDER BY ReformattingMethod"

            myReader = New SqlDataAdapter(myCommand, Constants.DigitArqConnectionString)
            myReader.Fill(myData, "ReformattingMethods")

        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            myReader.Dispose()
        End Try
        Return myData
    End Function


    'Generate reformatting norms report data
    Public Function GenerateReformattingNormsReportData() As ReformattingNormsData
        Dim myData As New ReformattingNormsData
        Dim myReader As SqlDataAdapter
        Dim myCommand As String
        Try
            If File.Exists(AppDomain.CurrentDomain.BaseDirectory & Constants.LogoPath) Then
                Dim fs As FileStream
                Dim br As BinaryReader
                fs = New FileStream(AppDomain.CurrentDomain.BaseDirectory & Constants.LogoPath, FileMode.Open, FileAccess.Read)
                br = New BinaryReader(fs)
                Dim imgbyte(fs.Length) As Byte
                imgbyte = br.ReadBytes(Convert.ToInt32(fs.Length))
                Dim drow As DataRow
                drow = myData.Logo.NewRow
                drow(0) = imgbyte
                myData.Logo.Rows.Add(drow)
                br.Close()
                fs.Close()
            End If

            myCommand = "SELECT * FROM ReformattingNorms ORDER BY ReformattingNorm"

            myReader = New SqlDataAdapter(myCommand, Constants.DigitArqConnectionString)
            myReader.Fill(myData, "ReformattingNorms")

        Catch e As SqlException
            MessageBoxes.MsgBoxSqlException(e)
        Finally
            myReader.Dispose()
        End Try
        Return myData
    End Function


    'Generate UI digitalizated report data
    Public Function GenerateUIDigitalizationReportData() As UIDigitalizationData
        Dim myData As New UIDigitalizationData
        Dim myReader As SqlDataAdapter
        Dim myCommand As String
        Try
            If File.Exists(AppDomain.CurrentDomain.BaseDirectory & Constants.LogoPath) Then
                Dim fs As FileStream
                Dim br As BinaryReader
                fs = New FileStream(AppDomain.CurrentDomain.BaseDirectory & Constants.LogoPath, FileMode.Open, FileAccess.Read)
                br = New BinaryReader(fs)
                Dim imgbyte(fs.Length) As Byte
                imgbyte = br.ReadBytes(Convert.ToInt32(fs.Length))
                Dim drow As DataRow
                drow = myData.Logo.NewRow
                drow(0) = imgbyte
                myData.Logo.Rows.Add(drow)
                br.Close()
                fs.Close()
            End If

            myCommand = "SELECT ID, CompleteUnitID, UnitTitle " & _
                        "FROM Components " & _
                        "WHERE Otherlevel='F'"

            myReader = New SqlDataAdapter(myCommand, Constants.DigitArqConnectionString)
            myReader.Fill(myData, "Components")

            myCommand = "SELECT ParentFondsID AS ID, Count(DO.DigitalObjectID) AS UINum, (Count(DO.DigitalObjectID)*100.0)/Count(C.ID) AS UIPercent, Count(C.ID) AS UINumTotal " & _
                        "FROM Components C " & _
                        "LEFT JOIN DaoGrp DG ON C.ID=DG.ComponentID " & _
                        "LEFT JOIN DigitalObjects DO ON DG.DigitalObjectID=DO.DigitalObjectID " & _
                        "WHERE C.OtherLevel='UI' " & _
                        "AND ParentFondsID IN (SELECT ID FROM Components C WHERE Otherlevel='F') " & _
                        "GROUP BY ParentFondsID "

            myReader = New SqlDataAdapter(myCommand, Constants.DigitArqConnectionString)
            myReader.Fill(myData, "NumUI")

        Catch e As Exception
            MsgBox(e.Message)
        End Try
        Return myData
    End Function


    Private Function GetDigitalObjectIDList(ByVal LVDOCollection As ListView.ListViewItemCollection) As String
        Dim strList As String = "("
        For i As Integer = 0 To LVDOCollection.Count - 1
            strList = strList + CStr(LVDOCollection.Item(i).Tag) + ","
        Next
        strList = strList.TrimEnd(",")
        strList = strList + ")"
        Return strList
    End Function

End Class
