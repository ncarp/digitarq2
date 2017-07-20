
#Region "License Agreement"

'* DigitArq
'* Copyright 2007-2015 
'* Arquivo Distrital do Porto
'* Todos os direitos reservados.
'*  
'* Este software foi desenvolvido pelo Arquivo
'* Distrital do Porto (http://www.adporto.pt)
'* em articula��o com a Direc��o-Geral de Arquivos
'* (http://www.dgarq.gov.pt) e com a coordena��o
'* inform�tica da Universidade do Minho
'* (http://www.uminho.pt).
'* O desenvolvimento deste produto foi parcialmente
'* financiado pelo Programa Operacional para a 
'* Cultura (POC) promovido pelo Governo Portugu�s.
'* ---------------------------------------------------
'*
'* A redistribui��o e utiliza��o deste produto sob a
'* forma de c�digo-fonte ou programa compilado, com ou
'* sem modifica��es, � permitida desde que o seguinte
'* conjunto de condi��es seja cumprido:
'* 
'*	* Todas as redistribui��es do c�digo-fonte 
'*	  deste produto dever�o ser acompanhadas do
'*	  texto que comp�e esta licen�a, incluindo o 
'*	  texto inicial de atribui��o de autoria,
'*	  esta lista de condi��es e do seguinte termo
'*	  de responsabilidade.
'*
'*	* Os nomes da Direc��o-Geral de Arquivos,
'*	  do Arquivo Distrital do Porto, da 
'*	  Universidade do Minho e das pessoas 
'*	  individuais que colaboraram no desenvolvimento 
'*	  deste produto n�o dever�o ser utilizados na 
'*	  promo��o de produtos derivados deste 
'*	  sem que seja obtido consentimento pr�vio, por
'*	  escrito, por parte dos visados.

'*	* A utiliza��o da designa��o DigitArq, seus 
'*	  log�tipos e nomes institucionais associados
'*	  � apenas permitida em distribui��es que sejam
'*	  c�pias exactas da vers�o oficial deste produto
'*	  aprovada e/ou distribu�da pela Direc��o-Geral 
'*	  de Arquivos.

'*	* O desenvolvimento de obras derivadas deste
'*	  produto � permitido desde que a designa��o 
'*	  DigitArq, seus logotipos e parceiros 
'*	  institucionais n�o sejam utilizados em todo e
'*	  qualquer tipo de distribui��o e/ou promo��o 
'*	  da obra derivada.
'* 
'* ESTE SOFTWARE � DISTRIBUIDO PELA DIREC��O-GERAL DE
'* ARQUIVOS "NO ESTADO EM QUE SE ENCONTRA" SEM QUALQUER
'* PRESUN��O DE QUALIDADE OU GARANTIA ASSOCIADAS, 
'* INCLUINDO, MAS N�O LIMITADO A, GARANTIAS ASSOCIADAS
'* A COM�RCIO DE PRODUTOS OU DECLARA��O DE ADEQUABILIDADE
'* A DETERMINADO FIM OU OBJECTIVO. 

'* EM NENHUMA CIRCUNST�NCIA PODER� A DIREC��O-GERAL DE 
'* ARQUIVOS SER CONSIDERADA RESPONS�VEL POR QUAISQUER 
'* DANOS QUE RESULTEM DA UTILIZA��O DIRECTA, INDIRECTA,
'* ACIDENTAL, ESPECIAL OU DEMONSTRATIVA DESTE PRODUTO 
'* (INCLUINDO, MAS N�O LIMITADO A, PERDAS DE DADOS, 
'* LUCROS, FAL�NCIA, INDEVIDA PRESTA��O DE SERVI�OS
'* OU NEGLIG�NCIA), AINDA QUE O LICENCIANTE TENHA SIDO 
'* AVISADO DA POSSIBILIDADE DA OCORR�NCIA DE TAIS DANOS.
'*
'* ---------------------------------------------------
'* Para mais informa��o sobre este produto ou a sua 
'* licen�a, � favor consultar o endere�o electr�nico
'* http://www.digitarq.pt

#End Region

Imports System.Data.SqlClient
Imports System.IO

Public Class ReportDataSetBuilder


    Public Function GenerateUIDigitalizationReportData(ByVal LVFondsCollection As ListView.SelectedListViewItemCollection) As UIDigitalizationData
        Dim myData As New UIDigitalizationData
        Dim myReader As SqlDataAdapter
        Dim myCommand As String
        Try
            Dim strListFonds As String = GetDigitalObjectIDList(LVFondsCollection)

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
                        "WHERE Otherlevel='F' " & _
                        "AND ID IN " & strListFonds

            myReader = New SqlDataAdapter(myCommand, Constants.DigitArqConnectionString)
            myReader.Fill(myData, "Components")

            myCommand = "SELECT ParentFondsID AS ID, 1 AS UINum, 1 UIPercent, COUNT(C.OtherLevel) AS UINumTotal " & _
                        "FROM Components C " & _
                        "WHERE C.OtherLevel='UI' AND ParentFondsID IN " & strListFonds & _
                        " GROUP BY ParentFondsID " & _
                        "UNION " & _
                        "SELECT ParentFondsID AS ID, 1 AS UINum, 1 UIPercent, 0 AS UINumTotal " & _
                        "FROM Components C " & _
                        "WHERE ParentFondsID IN " & strListFonds & _
                        " AND ParentFondsID NOT IN " & _
                        "(SELECT ParentFondsID " & _
                        "FROM Components C " & _
                        "WHERE C.OtherLevel='UI' AND ParentFondsID IN " & strListFonds & ")"


            myReader = New SqlDataAdapter(myCommand, Constants.DigitArqConnectionString)
            myReader.Fill(myData, "NumUI")

            For Each row As DataRow In myData.NumUI
                row.Item("UINum") = CalculateDigitalizatedUI(row.Item("ID"))
                If CInt(row.Item("UINumTotal")) <> 0 Then
                    row.Item("UIPercent") = row.Item("UINum") * 100.0 / row.Item("UINumTotal")
                Else
                    row.Item("UIPercent") = 0
                End If
            Next

        Catch e As Exception
            MsgBox(e.Message)
        End Try
        Return myData
    End Function


    Private Function CalculateDigitalizatedUI(ByVal ID As Int64) As Integer
        Dim myReader As SqlDataReader
        Dim myConnection As New SqlConnection(Constants.DigitArqConnectionString)
        Dim myCommand As New SqlCommand
        Try
            myConnection.Open()
            myCommand.Connection = myConnection
            myCommand.CommandText = "SELECT COUNT(DISTINCT ID) " & _
                                    "FROM DigitalObjects DO " & _
                                    "INNER JOIN DaoGrp DG ON DO.DigitalobjectID = DG.DigitalObjectID " & _
                                    "INNER JOIN Components C ON C.ID = DG.ComponentID " & _
                                    "WHERE C.OtherLevel='UI' AND ParentFondsID = " & ID

            Return DBToInt(myCommand.ExecuteScalar)

        Catch e As SqlException
            MsgBox(e.Message, MsgBoxStyle.Critical)
        Finally
            myConnection.Close()
        End Try
    End Function


    Public Function GenerateDigitarqDOReportData(ByVal FondID As Int64) As DigitarqODData
        Dim myData As New DigitarqODData
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

            myCommand = "SELECT DISTINCT ID, ParentID, ParentFondsID, HasChildren, Otherlevel, CompleteUnitID, CountryCode, RepositoryCode, UnitTitle " & _
                        "FROM Components " & _
                        "WHERE ParentFondsID=" & FondID

            myReader = New SqlDataAdapter(myCommand, Constants.DigitArqConnectionString)
            myReader.Fill(myData, "Components")

            myCommand = "SELECT DO.DigitalObjectID, ProjectID, Name, ArchiveID, QuantityOfTerminalObjects, TopographicalQuota " & _
                        "FROM DigitalObjects DO " & _
                        "INNER JOIN DaoGrp DG ON DO.DigitalObjectID=DG.DigitalObjectID " & _
                        "INNER JOIN Components C ON C.ID=DG.ComponentID " & _
                        "WHERE C.ParentFondsID=" & FondID & _
                        "UNION " & _
                        "SELECT -1, 0, '', '', 0, ''"

            myReader = New SqlDataAdapter(myCommand, Constants.DigitArqConnectionString)
            myReader.Fill(myData, "DigitalObjects")


            myCommand = "SELECT DISTINCT C.ID AS ComponentID, ISNULL(DG.DigitalObjectID, -1) AS DigitalObjectID " & _
                        "FROM DaoGrp DG " & _
                        "RIGHT JOIN Components C ON C.ID=DG.ComponentID " & _
                        "WHERE C.ParentFondsID=" & FondID

            myReader = New SqlDataAdapter(myCommand, Constants.DigitArqConnectionString)
            myReader.Fill(myData, "DaoGrp")

            For Each row As DataRow In myData.Components
                Dim ret(2) As Integer
                Dim value As Int64 = CType(row.Item("ID"), Int64)
                ret = CalculateParentAndChildrenDerivatives(value)
                row.Item("TotalImages") = ret(1)
                row.Item("TotalDerivatives") = ret(2)
            Next

        Catch e As Exception
            MsgBox(e.Message)
        End Try
        Return myData
    End Function


    Private Function CalculateParentAndChildrenDerivatives(ByVal ID As Integer) As Integer()
        Dim ret(2), ret1(2), ret2(2) As Integer
        Try
            ret1 = CalculateParentDerivativesNumber(ID)
            ret2 = CalculateChildrenDerivativesNumber(ID)

            ret(1) = ret1(1) + ret2(1)
            ret(2) = ret1(2) + ret2(2)
        Catch ex As Exception
            Dim erro As String = ex.ToString
            Dim erro1 As String = ex.ToString
        End Try

        Return ret
    End Function

    Private Function CalculateParentDerivativesNumber(ByVal ID As Integer) As Integer()
        Dim myReader As SqlDataReader
        Dim myConnection As New SqlConnection(Constants.DigitArqConnectionString)
        Dim myCommand As New SqlCommand
        Dim value As Integer
        Dim ret(2) As Integer
        Try
            myConnection.Open()
            myCommand.Connection = myConnection
            myCommand.CommandText = "SELECT SUM(QuantityOfTerminalObjects) " & _
                                    "FROM DigitalObjects DO " & _
                                    "INNER JOIN DaoGrp DG ON DO.DigitalObjectID=DG.DigitalObjectID " & _
                                    "WHERE DG.ComponentID=" & ID & " AND Type = 0"
            value = DBToInt(myCommand.ExecuteScalar)

            myCommand.CommandText = "SELECT Count(FileID) " & _
                                    "FROM DaoGrp " & _
                                    "WHERE ComponentID = " & ID & " AND Type = 1"
            ret(1) = value + DBToInt(myCommand.ExecuteScalar)

            myCommand.CommandText = "SELECT COUNT(DF.FileID) " & _
                                    "FROM DOFiles DF " & _
                                    "INNER JOIN DigitalObjects DO ON DF.DigitalObjectID=DO.DigitalObjectID " & _
                                    "INNER JOIN DaoGrp DG ON DO.DigitalObjectID=DG.DigitalObjectID " & _
                                    "WHERE Image IS NOT NULL AND DG.ComponentID =" & ID & " AND Type = 0 " & _
                                    "GROUP BY DO.DigitalObjectID"
            value = DBToInt(myCommand.ExecuteScalar)

            myCommand.CommandText = "SELECT COUNT(FileID) " & _
                                    "FROM DOFiles " & _
                                    "WHERE Image IS NOT NULL AND FileID IN (SELECT FileID FROM DaoGrp WHERE Type=1 AND ComponentID=" & ID & ")"
            ret(2) = value + DBToInt(myCommand.ExecuteScalar)

            Return ret
        Catch e As SqlException
            MsgBox(e.Message, MsgBoxStyle.Critical)
        Finally
            myConnection.Close()
        End Try
    End Function

    Private Function CalculateChildrenDerivativesNumber(ByVal ID As Integer, Optional ByVal images As Integer = 0, Optional ByVal derivatives As Integer = 0) As Integer()
        Dim myReader As SqlDataReader
        Dim myConnection As New SqlConnection(Constants.DigitArqConnectionString)
        Dim myCommand As New SqlCommand
        Dim value As Integer
        Dim ret(2) As Integer
        Try
            myConnection.Open()
            myCommand.Connection = myConnection
            myCommand.CommandText = "SELECT SUM(QuantityOfTerminalObjects) " & _
                                    "FROM DigitalObjects DO " & _
                                    "INNER JOIN DaoGrp DG ON DO.DigitalObjectID=DG.DigitalObjectID " & _
                                    "INNER JOIN Components C ON C.ID=DG.ComponentID " & _
                                    "WHERE C.ParentID=" & ID & " AND DG.Type = 0 " & _
                                    "GROUP BY C.ParentID"
            value = images + DBToInt(myCommand.ExecuteScalar())

            myCommand.CommandText = "SELECT Count(DG.FileID) " & _
                                    "FROM DaoGrp DG " & _
                                    "INNER JOIN Components C ON C.ID=DG.ComponentID " & _
                                    "WHERE C.ParentID=" & ID & " AND DG.Type = 1"
            ret(1) = value + DBToInt(myCommand.ExecuteScalar())

            myCommand.CommandText = "SELECT COUNT(DF.FileID) " & _
                                    "FROM DOFiles DF " & _
                                    "INNER JOIN DigitalObjects DO ON DF.DigitalObjectID=DO.DigitalObjectID " & _
                                    "INNER JOIN DaoGrp DG ON DO.DigitalObjectID=DG.DigitalObjectID " & _
                                    "INNER JOIN Components C ON C.ID=DG.ComponentID " & _
                                    "WHERE Image IS NOT NULL AND C.ParentID =" & ID & " AND DG.Type = 0"

            value = derivatives + DBToInt(myCommand.ExecuteScalar())

            myCommand.CommandText = "SELECT COUNT(DF.FileID) " & _
                                    "FROM DOFiles DF " & _
                                    "WHERE DF.Image IS NOT NULL " & _
                                    "AND DF.FileID IN " & _
                                    "(SELECT FileID FROM DaoGrp DG " & _
                                    "INNER JOIN Components C ON C.ID=DG.ComponentID " & _
                                    "AND C.ParentID =" & ID & " AND DG.Type = 1)"

            ret(2) = value + DBToInt(myCommand.ExecuteScalar)

            myCommand.CommandText = "SELECT ID, HasChildren " & _
                                    "FROM Components " & _
                                    "WHERE ParentID=" & ID
            myReader = myCommand.ExecuteReader
            While myReader.Read
                If DBToBool(myReader.Item("HasChildren")) Then
                    ret = CalculateChildrenDerivativesNumber(myReader.Item("ID"), ret(1), ret(2))
                End If
            End While
            Return ret
        Catch e As SqlException
            MsgBox(e.Message, MsgBoxStyle.Critical)
        Finally
            myConnection.Close()
        End Try
    End Function

    Private Function GetDigitalObjectIDList(ByVal LVDOCollection As ListView.SelectedListViewItemCollection) As String
        Dim strList As String = "("
        For i As Integer = 0 To LVDOCollection.Count - 1
            strList = strList + CStr(LVDOCollection.Item(i).Tag) + ","
        Next
        strList = strList.TrimEnd(",")
        strList = strList + ")"
        Return strList
    End Function


End Class
