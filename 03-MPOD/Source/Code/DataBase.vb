
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
Imports System.Configuration
Imports System.String
Imports System.Text
Imports System.IO

Public Class DataBase


#Region "InsertDaoGrp"

    Public Function InsertDaoGrp(ByVal ComponentID As Int64, ByVal DigitalObjectID As Int64, ByVal FileID As Int64, ByVal Type As Integer) As Boolean
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection

        Try
            myConnection.ConnectionString = Constants.DigitArqConnectionString
            myCommand.Connection = myConnection
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("INSERT INTO DaoGrp(ComponentID, DigitalObjectID, FileID, Type) " & _
                                        "VALUES ({0},{1},{2},{3})", ComponentID, DigitalObjectID, FileID, Type)
            myCommand.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("Associação já existente", MsgBoxStyle.Critical, "Associação ao DigitArq")
            Return False
        Finally
            myCommand.Dispose()
            myConnection.Close()
            myConnection.Dispose()
        End Try
    End Function

#End Region

#Region "InsertAltFormAvail"

    Public Function InsertAltFormAvail(ByVal ComponentID As Int64, ByVal DOName As String, _
        ByVal ArchiveID As String, ByVal TopographicalQuota As String) As Boolean
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection

        Try
            myConnection.ConnectionString = Constants.DigitArqConnectionString
            myCommand.Connection = myConnection
            myCommand.Connection.Open()
            myCommand.CommandText = String.Format("SELECT AltFormAvail FROM Components " & _
                                                  "WHERE ID={0}", ComponentID)
            Dim strAltFormAvail As String = myCommand.ExecuteScalar()
            Dim strNewAltFormavail As String = " - Digitalizado: " & DOName & " @ " & ArchiveID & " @ " & TopographicalQuota

            myCommand.CommandText = String.Format("UPDATE Components " & _
                                    "SET AltFormAvail='" & strAltFormAvail & " {0}' " & _
                                    "WHERE ID={1}", strNewAltFormavail, ComponentID)
            myCommand.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("Associação já existente", MsgBoxStyle.Critical, "Associação ao DigitArq")
            Return False
        Finally
            myCommand.Dispose()
            myConnection.Close()
            myConnection.Dispose()
        End Try
    End Function

#End Region

#Region "Select InfoAssocionations"

    Public Function SelectInfoAssociations(ByVal intDigitalObjectID As Int64, ByVal intDOFileID As Int64) As DataSet
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim command As String
        Try
            command = "SELECT C.ID, C.CompleteUnitID, C.OtherLevel, C.UnitTitle " & _
                      "FROM DaoGrp DG " & _
                      "INNER JOIN Components C ON DG.ComponentID=C.ID " & _
                      "WHERE DG.DigitalObjectID = " & intDigitalObjectID & " AND FileID = " & intDOFileID

            myReader = New SqlDataAdapter(command, Constants.DigitArqConnectionString)
            myReader.Fill(myData)
        Catch e As SqlException
            MsgBox(e.Message, MsgBoxStyle.Critical)
        Finally
            myReader.Dispose()
        End Try
        Return myData
    End Function

    Public Function SelectInfoAssociationsF(ByVal intComponentID As Int64) As DataSet
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim command As String
        Try
            command = "SELECT DG.ComponentID, DG.DigitalObjectID, DG.FileID, DG.Type, P.Name AS ProjectName, DO.Name AS DOName, DOF.Name AS DOFileName " & _
                      "FROM DaoGrp DG " & _
                      "INNER JOIN DigitalObjects DO ON DG.DigitalObjectID=DO.DigitalObjectID " & _
                      "INNER JOIN Projects P ON DO.ProjectID=P.ProjectID " & _
                      "INNER JOIN DOFiles DOF ON DG.FileID=DOF.FileID " & _
                      "WHERE ComponentID =" & intComponentID & _
                      " ORDER BY DG.Type, DG.DigitalObjectID"

            myReader = New SqlDataAdapter(command, Constants.DigitArqConnectionString)
            myReader.Fill(myData)
        Catch e As SqlException
            MsgBox(e.Message, MsgBoxStyle.Critical)
        Finally
            myReader.Dispose()
        End Try
        Return myData
    End Function

    Public Function DeleteAssociation(ByVal ComponentID As Int64, ByVal DigitalObjectID As Int64, ByVal FileID As Int64) As DataSet
        Dim myData As New DataSet
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection(Constants.DigitArqConnectionString)
        Dim command As String
        Try
            myCommand.Connection = myConnection
            myConnection.Open()
            myCommand.CommandText = "DELETE FROM DaoGrp" & _
                                    " WHERE ComponentID=" & ComponentID & _
                                    " AND DigitalObjectID = " & DigitalObjectID & _
                                    " AND FileID = " & FileID

            myCommand.ExecuteNonQuery()
        Catch e As SqlException
            MsgBox(e.Message, MsgBoxStyle.Critical)
        Finally
            myCommand.Dispose()
            myConnection.Close()
            myConnection.Dispose()
        End Try
        Return myData
    End Function

#End Region

#Region "Select all projects"

    Public Function SelectAllProjects() As DataSet
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim command As String
        Try
            command = "SELECT P.Name, P.Location, P.ProjectID, P.Description, P.CreationDateTime, " & _
                      "P.LastUpdateDateTime, P.Username, Count(DO.DigitalObjectID) AS DOCount FROM Projects P " & _
                      "LEFT JOIN DigitalObjects DO ON DO.ProjectID=P.ProjectID " & _
                      "GROUP BY P.Name, P.Location, P.ProjectID, P.Description, P.CreationDateTime, P.LastUpdateDateTime, P.Username " & _
                      "ORDER BY P.ProjectID DESC"

            myReader = New SqlDataAdapter(command, Constants.DigitArqConnectionString)
            myReader.Fill(myData)
        Catch e As SqlException
            MsgBox(e.Message, MsgBoxStyle.Critical)
        Finally
            myReader.Dispose()
        End Try
        Return myData
    End Function

#End Region

#Region "Select Digital objects by ProjectID"

    Public Function SelectDigitalObjectsById(ByVal intProjectID As Int64) As DataSet
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim command As String
        Try
            command = "SELECT DigitalObjectID, ProjectID, Name, OriginalName, ArchiveId, ArchivingProfile, " & _
                "CaptureEntityCorporate, ResponsabilityEntity, " & _
                "CreationDateTime, ArchiveDateTime, DepositDateTime, RevisionDateTime, " & _
                "ExternalDescriptiveInformation, PreservationOriginalInformation, " & _
                "QuantityOfTerminalObjects, TopographicalQuota, Structure, Username, DigitalObjects.Active " & _
                "FROM DigitalObjects WHERE ProjectID = " & intProjectID

            myReader = New SqlDataAdapter(command, Constants.DigitArqConnectionString)
            myReader.Fill(myData)
        Catch e As SqlException
            MsgBox(e.Message, MsgBoxStyle.Critical)
        Finally
            myReader.Dispose()
        End Try
        Return myData
    End Function

    Public Function SelectDigitalObjects(ByVal intProjectID As Int64) As DataSet
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim myCommand As String
        Try
            myCommand = "SELECT DISTINCT DO.DigitalObjectID, DO.Name, DO.OriginalName, DG.DigitalObjectID as DaoGrpDOID " & _
                        "FROM DigitalObjects DO " & _
                        "LEFT JOIN DaoGrp DG ON DO.DigitalObjectID = DG.DigitalObjectID " & _
                        "WHERE ProjectID = " & intProjectID

            myReader = New SqlDataAdapter(myCommand, Constants.DigitArqConnectionString)
            myReader.Fill(myData)
        Catch e As SqlException
            MsgBox(e.Message, MsgBoxStyle.Critical)
        Finally
            myReader.Dispose()
        End Try
        Return myData
    End Function

#End Region

#Region "Select Digital object info (Name, ArchiveID, TopographicalQuota )"

    Public Function SelectDigitalObject(ByVal intDigitalObjectID As Int64) As DataSet
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim command As String
        Try
            command = "SELECT Name, ArchiveID, TopographicalQuota " & _
                      "FROM DigitalObjects " & _
                      "WHERE DigitalObjectID=" & intDigitalObjectID

            myReader = New SqlDataAdapter(command, Constants.DigitArqConnectionString)
            myReader.Fill(myData)
        Catch e As SqlException
            MsgBox(e.Message, MsgBoxStyle.Critical)
        Finally
            myReader.Dispose()
        End Try
        Return myData
    End Function

#End Region

#Region "Select all fonds"

    Public Function SelectAllFonds() As DataSet
        Dim myData As New DataSet
        Dim myReader As SqlDataAdapter
        Dim myCommand As String
        Try
            myCommand = "SELECT ID, UnitID FROM Components " & _
                        "WHERE OtherLevel='F' AND LEN(UnitID)>0 " & _
                        "ORDER BY UnitID"

            myReader = New SqlDataAdapter(myCommand, Constants.DigitArqConnectionString)
            myReader.Fill(myData)

        Catch e As SqlException
            MsgBox(e.Message, MsgBoxStyle.Critical)
        Finally
            myReader.Dispose()
        End Try
        Return myData
    End Function

#End Region

#Region "Select First File ID"

    Public Function SelectFirstFileName(ByVal DigitalObjectID As Int64) As String
        Dim myReader As SqlDataReader
        Dim myConnection As New SqlConnection(Constants.DigitArqConnectionString)
        Dim myCommand As New SqlCommand
        Try
            myConnection.Open()
            myCommand.Connection = myConnection
            myCommand.CommandText = "SELECT TOP 1 Name FROM DOFiles " & _
                                    "WHERE DigitalObjectID = " & DigitalObjectID & " " & _
                                    "ORDER BY FileID ASC"

            Return myCommand.ExecuteScalar

        Catch e As SqlException
            MsgBox(e.Message, MsgBoxStyle.Critical)
        Finally
            myCommand.Dispose()
            myConnection.Close()
            myConnection.Dispose()
        End Try
    End Function

#End Region

#Region "Count fond elements"

    Public Function CountFondElements(ByVal FondID As Int64) As Integer
        Dim myReader As SqlDataReader
        Dim myConnection As New SqlConnection(Constants.DigitArqConnectionString)
        Dim myCommand As New SqlCommand
        Try
            myConnection.Open()
            myCommand.Connection = myConnection
            myCommand.CommandText = "SELECT Count(ID) FROM Components " & _
                                    "WHERE ParentFondsID = " & FondID

            Return myCommand.ExecuteScalar

        Catch e As SqlException
            MsgBox(e.Message, MsgBoxStyle.Critical)
        Finally
            myReader.Close()
            myConnection.Close()
            myConnection.Dispose()
        End Try
    End Function

#End Region


#Region "Get image"

    Function getImage(ByVal ImageName As String, ByVal intDOID As Int64) As System.Drawing.Image
        Dim image As System.Drawing.Image
        'Dim res As Object
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
                End If
            End If
        Catch e As Exception
            MsgBox(e.Message)
        Finally
            cmd.Dispose()
            dr.Close()
            cn.Close()
            cn.Dispose()
        End Try
        Return image
    End Function

#End Region

#Region "Select DigitArq To Tree"

    Public Function SqlCommandSelectDigitArqToTree(ByVal FondName As String) As ArrayList
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim myReader As SqlDataReader
        Dim res As New ArrayList
        Try
            myConnection.ConnectionString = Constants.DigitArqConnectionString
            myCommand.Connection = myConnection
            myConnection.Open()
            myCommand.CommandText = "SELECT DISTINCT ID, ParentID, UnitID, OtherLevel, UnitTitle, DG.ComponentID " & _
                                    "FROM Components C " & _
                                    "LEFT JOIN DaoGrp DG ON C.ID = DG.ComponentID " & _
                                    "WHERE UnitID = " & "'" & FondName & "' AND OtherLevel = 'F' " & _
                                    "ORDER BY UnitID"

            myReader = myCommand.ExecuteReader

            Dim strFields() As String = {"ID", "ParentID", "UnitID", "OtherLevel", "UnitTitle", "ComponentID"}

            res = DataReaderToArrayList(myReader, strFields)

        Catch e As Exception
            MsgBox(e.Message)
        Finally
            myReader.Close()
            myConnection.Close()
            myConnection.Dispose()
        End Try
        Return res
    End Function

    Public Function SqlCommandSelectDigitArqToTree(ByVal FondID As Int64) As TreeNodeInfo
        Dim myCommand As New SqlCommand
        Dim myConnection As New SqlConnection
        Dim myReader As SqlDataReader
        Dim TreeNodeInfo As New TreeNodeInfo
        Try
            myConnection.ConnectionString = Constants.DigitArqConnectionString
            myCommand.Connection = myConnection
            myConnection.Open()
            myCommand.CommandText = "SELECT DISTINCT ID, ParentID, HasChildren, UnitID, OtherLevel, UnitTitle, DG.ComponentID " & _
                                    "FROM Components C " & _
                                    "LEFT JOIN DaoGrp DG ON C.ID = DG.ComponentID " & _
                                    "WHERE ID = " & "'" & FondID & "' AND OtherLevel = 'F' " & _
                                    "ORDER BY UnitID"
            myReader = myCommand.ExecuteReader

            myReader.Read()
            TreeNodeInfo.ID = myReader.Item("ID")
            TreeNodeInfo.ParentID = DBToInt(myReader.Item("ParentID"))
            TreeNodeInfo.OtherLevel = DBToStr(myReader.Item("OtherLevel"))
            TreeNodeInfo.UnitID = DBToStr(myReader.Item("UnitID"))
            TreeNodeInfo.UnitTitle = DBToStr(myReader.Item("UnitTitle"))
            TreeNodeInfo.HasChildren = DBToBool(myReader.Item("HasChildren"))
            If DBToStr(myReader.Item("ComponentID")).Equals("") Then
                TreeNodeInfo.Associated = False
            Else
                TreeNodeInfo.Associated = True
            End If

        Catch e As Exception
            MsgBox(e.Message)
        Finally
            myReader.Close()
            myReader = Nothing
            myConnection.Close()
            myConnection.Dispose()
        End Try
        Return TreeNodeInfo
    End Function

    Public Function Children(ByVal myID As Integer) As TreeNodeInfoCollection
        Dim myConnection As New SqlConnection
        Dim myCommand As New SqlCommand
        Dim myReader As SqlDataReader
        Dim TreeNodeInfoCollection As New TreeNodeInfoCollection

        Try
            myConnection.ConnectionString = Constants.DigitArqConnectionString
            myCommand.Connection = myConnection
            myConnection.Open()
            myCommand.CommandText = String.Format("SELECT DISTINCT ID, ParentID, HasChildren, UnitID, OtherLevel, UnitTitle, DG.ComponentID " & _
                                                  "FROM Components C " & _
                                                  "LEFT JOIN DaoGrp DG ON C.ID=DG.ComponentID " & _
                                                  "WHERE ParentID = '{0}' ORDER BY UnitID", myID)
            myReader = myCommand.ExecuteReader()

            While myReader.Read
                Dim TreeNodeInfo As New TreeNodeInfo

                TreeNodeInfo.ID = myReader.Item("ID")
                TreeNodeInfo.ParentID = DBToInt(myReader.Item("ParentID"))
                TreeNodeInfo.OtherLevel = DBToStr(myReader.Item("OtherLevel"))
                TreeNodeInfo.UnitID = DBToStr(myReader.Item("UnitID"))
                TreeNodeInfo.UnitTitle = DBToStr(myReader.Item("UnitTitle"))
                TreeNodeInfo.HasChildren = DBToBool(myReader.Item("HasChildren"))
                If DBToStr(myReader.Item("ComponentID")).Equals("") Then
                    TreeNodeInfo.Associated = False
                Else
                    TreeNodeInfo.Associated = True
                End If
                TreeNodeInfoCollection.Add(TreeNodeInfo)
            End While

        Catch ex As Exception
            MsgBox(ex)
        Finally
            myReader.Close()
            myCommand.Dispose()
            myConnection.Close()
            myConnection.Dispose()
        End Try
        Return TreeNodeInfoCollection
    End Function


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
                    arg = ""
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

End Class
