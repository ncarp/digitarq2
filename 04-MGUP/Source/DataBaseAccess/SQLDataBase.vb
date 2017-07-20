
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
Imports System.Threading
Imports System.Text
Imports System.Configuration
Imports System.String
Imports System.IO


Public Class SQLDataBase
    Inherits SQLInterface


#Region "Properties connection"
    Private myReturn As eReturn
    'Private hshDatabase As Hashtable = ConfigurationSettings.GetConfig("sqlServerSettings")
    Private hshDatabase As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")

    Private ServerAddress As String = hshDatabase("ServerAddress")
    Private GPUDatabase As String = hshDatabase("Database")
    Private Username As String = hshDatabase("Username")
    Private Password As String = hshDatabase("Password")
    Private ConnectTimeout As String = hshDatabase("ConnectTimeout")

    Private myConnStringGPU As String = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; password={3}; Connect Timeout={4};", ServerAddress, GPUDatabase, Username, Password, ConnectTimeout)

#End Region


#Region "Employees"

    Public Overrides Function validateStoreEmployee(ByVal strUserName As String) As Boolean
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_validateStoreEmployee", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("@UserName", strUserName)
            dr = cm.ExecuteReader
            If Not dr.HasRows Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw (ex)
        Finally
            cm.Dispose()
            dr.Close()
            cn.Close()
            cn.Dispose()
        End Try
    End Function

    Public Overrides Function storeEmployee(ByVal objEmployee As Employee)
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_storeEmployee", cn)

        Try
            If Not validateStoreEmployee(objEmployee.UserName) Then
                myReturn = eReturn.ErrorRepeatUsername
                Return 0
            End If
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("@UserName", objEmployee.UserName)
            cm.Parameters.AddWithValue("@FirstName", objEmployee.FirstName)
            cm.Parameters.AddWithValue("@LastName", objEmployee.LastName)
            cm.Parameters.AddWithValue("@Password", objEmployee.Password)
            cm.Parameters.AddWithValue("@Obs", objEmployee.Obs)

            cm.ExecuteNonQuery()
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cm.Dispose()
            cn.Close()
            cn.Dispose()
        End Try

    End Function

    Public Overrides Function validateEmployee(ByVal strAplicationCode As String, ByVal strUserName As String, ByVal strPassword As String) As eReturn
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_validateEmployee", cn)
        Dim dr As SqlDataReader

        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("@UserName", strUserName)
            cm.Parameters.AddWithValue("@Password", Encrypt.GenerateHash(strPassword))
            dr = cm.ExecuteReader
            If Not dr.HasRows Then
                Return eReturn.ErrorUsernamePass
            ElseIf dr.HasRows Then
                While dr.Read
                    If Not Me.accessAplication(strUserName, strAplicationCode) Then
                        Return eReturn.AplicationAccessDenied
                    ElseIf Not Me.getProfile(strUserName, strAplicationCode).ProfileExists Then
                        Return eReturn.ErrorNotProfile
                    ElseIf IsDBNull(dr.Item("Active")) Or dr.Item("Active") = 0 Then
                        Return eReturn.ErrorNotActive
                    Else
                        Return eReturn.Sucess
                    End If
                End While
            End If
        Catch ex As Exception
            Throw (ex)
        Finally
            cm.Dispose()
            dr.Close()
            cn.Close()
            cn.Dispose()
        End Try
    End Function

    Public Overloads Overrides Function loadEmployee(ByVal strUserName As String) As Employee
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_loadEmployeeByUN", cn)
        Dim dr As SqlDataReader
        Dim objEmployee As New Employee
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("@UserName", strUserName)

            dr = cm.ExecuteReader
            If Not dr.HasRows Then
                objEmployee.EmployeeExists = False
                Return objEmployee
            Else
                objEmployee.EmployeeExists = True
            End If
            While dr.Read
                objEmployee.UserName = dr.Item("UserName")
                objEmployee.FirstName = DBToStr(dr.Item("FirstName"))
                objEmployee.LastName = DBToStr(dr.Item("LastName"))
                objEmployee.Obs = DBToStr(dr.Item("Obs"))
            End While
            dr.Close()
            myReturn = eReturn.Sucess
            Return objEmployee
        Catch ex As Exception
            Throw (ex)
        Finally
            cm.Dispose()
            dr.Close()
            cn.Close()
            cn.Dispose()
        End Try
    End Function

    Public Overloads Overrides Sub loadEmployees(ByVal ddl As DropDownList, ByVal listType As Int16)
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_loadEmployees", cn)

        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("@ListType", listType)
            cm.Parameters.AddWithValue("@AplicationCode", "DIGITARQ")
            ddl.DataValueField = "UserName"
            ddl.DataTextField = "FullName"
            ddl.DataSource = cm.ExecuteReader(CommandBehavior.CloseConnection)
            ddl.DataBind()
        Catch ex As Exception
            Throw (ex)
        Finally
            cm.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Sub

    Public Overloads Overrides Function loadEmployees(ByVal strAplicationCode As String) As DataSet
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU

        Dim objDataAdapter As SqlDataAdapter
        Dim objDataSet As DataSet

        Try
            cn.Open()
            objDataAdapter = New SqlDataAdapter("sp_loadEmployees", cn)
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@ListType", "0")
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@AplicationCode", strAplicationCode)
            objDataSet = New DataSet
            objDataAdapter.Fill(objDataSet)

            Return objDataSet
        Catch ex As Exception
            Dim erro As String = ex.ToString
            Dim erro1 As String = ex.ToString
        Finally
            cn.Close()
            objDataAdapter = Nothing
            cn = Nothing
        End Try
    End Function


    Public Overloads Overrides Sub loadEmployees(ByVal dg As DataGrid, ByVal intListType As Integer, ByVal strAplicationCode As String)
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU

        Dim objDataAdapter As SqlDataAdapter
        Dim objDataSet As DataSet

        Try
            cn.Open()
            objDataAdapter = New SqlDataAdapter("sp_loadEmployees", cn)
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@ListType", intListType)
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@AplicationCode", strAplicationCode)
            objDataSet = New DataSet
            objDataAdapter.Fill(objDataSet)

            dg.DataSource = objDataSet
            dg.DataBind()
        Catch ex As Exception
            Throw (ex)
        Finally
            objDataAdapter.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Sub

    Public Overloads Overrides Function loadEmployees(ByVal intProfileID As Integer, ByVal strAplicationCode As String) As DataSet
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU

        Dim objDataAdapter As SqlDataAdapter
        Dim objDataSet As DataSet

        Try
            cn.Open()
            objDataAdapter = New SqlDataAdapter("sp_loadEmployeesByProfile", cn)
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@ProfileID", intProfileID)
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@AplicationCode", strAplicationCode)
            objDataSet = New DataSet
            objDataAdapter.Fill(objDataSet)

            Return objDataSet
        Catch ex As Exception
            Throw (ex)
        Finally
            objDataAdapter.Dispose()
            cn.Close()
            cn.Dispose()
        End Try

    End Function

    Public Overrides Function loadFullEmployees() As DataSet
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU

        Dim objDataAdapter As SqlDataAdapter
        Dim objDataSet As DataSet
        Try
            cn.Open()
            objDataAdapter = New SqlDataAdapter("sp_loadFullEmployees", cn)
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            objDataSet = New DataSet
            objDataAdapter.Fill(objDataSet)

            myReturn = eReturn.Sucess
            Return objDataSet
        Catch ex As Exception
            Throw (ex)
        Finally
            objDataAdapter.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Function


    Public Overloads Overrides Sub updateEmployee(ByVal strUserName As String, ByVal intProfileID As Integer, ByVal strAplicationCode As String, ByVal bolActive As Boolean)
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand
        Try
            cn.Open()
            cm.Connection = cn
            cm.CommandText = "sp_updateEmployee"
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("@UserName", strUserName)
            cm.Parameters.AddWithValue("@ProfileID", intProfileID)
            cm.Parameters.AddWithValue("@AplicationCode", strAplicationCode)
            cm.Parameters.AddWithValue("@Active", bolActive)
            cm.ExecuteNonQuery()

            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cm.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Sub

    Public Overloads Overrides Sub updateEmployee(ByVal objEmployee As Employee)
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_updatePDEmployee", cn)

        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            cm.Parameters.AddWithValue("@UserName", objEmployee.UserName)
            cm.Parameters.AddWithValue("@FirstName", objEmployee.FirstName)
            cm.Parameters.AddWithValue("@LastName", objEmployee.LastName)
            cm.Parameters.AddWithValue("@Obs", objEmployee.Obs)
            cm.Parameters.AddWithValue("@Password", objEmployee.Password)

            cm.ExecuteNonQuery()
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cm.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Sub

    Public Overrides Function countEmployees() As Integer
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_countEmployees", cn)

        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.Add("@Count", SqlDbType.Int)
            cm.Parameters("@Count").Direction = ParameterDirection.Output
            cm.ExecuteNonQuery()
            Return cm.Parameters("@Count").Value
        Catch ex As Exception
            Return 0
        Finally
            cm.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Function

#End Region

#Region "Profiles"

    Public Overrides Sub storeProfile(ByVal strProfileName As String, ByVal strAplicationCode As String)
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_storeProfile", cn)
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("@ProfileName", strProfileName)
            cm.Parameters.AddWithValue("@AplicationCode", strAplicationCode)
            cm.ExecuteNonQuery()

            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cm.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Sub

    Public Overloads Overrides Function loadProfiles(ByVal rdbl As RadioButtonList, ByVal strAplicationCode As String)
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_loadProfiles", cn)
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("@AplicationCode", strAplicationCode)
            rdbl.DataValueField = "ProfileID"
            rdbl.DataTextField = "Profile"
            rdbl.DataSource = cm.ExecuteReader(CommandBehavior.CloseConnection)
            rdbl.DataBind()
            rdbl.SelectedValue = rdbl.Items(0).Value
        Catch ex As Exception
            Throw (ex)
        Finally
            cm.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Function

    Public Overloads Overrides Function loadProfiles(ByVal ddl As DropDownList, ByVal strAplicationCode As String)
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_loadProfiles", cn)

        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("@AplicationCode", strAplicationCode)
            ddl.DataValueField = "ProfileID"
            ddl.DataTextField = "Profile"
            ddl.DataSource = cm.ExecuteReader(CommandBehavior.CloseConnection)
            ddl.DataBind()

        Catch ex As Exception
            Throw (ex)
        Finally
            cm.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Function

    Public Overloads Overrides Function loadProfiles(ByVal dg As DataGrid, ByVal strAplicationCode As String)
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter("sp_loadProfiles", cn)
        Try
            cn.Open()
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@AplicationCode", strAplicationCode)

            da.Fill(ds)

            dg.DataSource = ds
            dg.DataBind()
        Catch ex As Exception
            Throw (ex)
        Finally
            da.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Function

    Public Overloads Overrides Function loadProfiles(ByVal strAplicationCode As String) As DataSet
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter("sp_loadProfiles", cn)
        Try
            cn.Open()
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.SelectCommand.Parameters.AddWithValue("@AplicationCode", strAplicationCode)
            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Throw (ex)
        Finally
            da.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Function

    Public Overloads Overrides Function getProfile(ByVal strUserName As String, ByVal strAplicationCode As String) As Profile
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_getProfile", cn)
        Dim dr As SqlDataReader
        Dim objProfile As New Profile
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            cm.Parameters.AddWithValue("@UserName", strUserName)
            cm.Parameters.AddWithValue("@AplicationCode", strAplicationCode)

            dr = cm.ExecuteReader
            If Not dr.HasRows Then
                objProfile.ProfileExists = False
                Return objProfile
            Else
                objProfile.ProfileExists = True
            End If
            While dr.Read
                objProfile.ProfileID = dr.Item("ProfileID")
                objProfile.Profile = dr.Item("Profile")
            End While
            dr.Close()
            myReturn = eReturn.Sucess
            Return objProfile
        Catch ex As Exception
            Throw (ex)
        Finally
            cm.Dispose()
            dr.Close()
            cn.Close()
            cn.Dispose()
        End Try
    End Function

    Public Overrides Sub deleteProfile(ByVal intProfileID As Integer)
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_deleteProfile", cn)

        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("@ProfileID", intProfileID)
            cm.ExecuteNonQuery()
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cm.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Sub

    Public Overrides Sub updateProfile(ByVal intProfileID As Integer, ByVal strProfileName As String)
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_updateProfile", cn)

        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("@ProfileID", intProfileID)
            cm.Parameters.AddWithValue("@ProfileName", strProfileName)
            cm.ExecuteNonQuery()
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cm.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Sub

#End Region

#Region "Profile Functions"

    Public Overrides Function getProfileFunctions(ByVal intProfile As Integer, ByVal intParentID As String) As FunctionCollection
        Dim FunctionCollection As New FunctionCollection
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_getProfileFunctions", cn)
        Dim dr As SqlDataReader

        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("@ProfileID", intProfile)
            cm.Parameters.AddWithValue("@ParentCode", intParentID)
            dr = cm.ExecuteReader()
            While dr.Read
                Dim objFunction As New _Function
                objFunction.FunctionCode = DBToStr(dr.Item("FunctionCode"))
                objFunction.FunctionName = DBToStr(dr.Item("FunctionName"))

                FunctionCollection.Add(objFunction)
            End While
            Return FunctionCollection

            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cm.Dispose()
            dr.Close()
            cn.Close()
            cn.Dispose()
        End Try
    End Function


    Public Overrides Function getAllProfileFunctions(ByVal strAplicationCode As String, ByVal intProfile As Integer, ByVal strParentID As String) As FunctionCollection
        Dim FunctionCollection As New FunctionCollection
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_getAllProfileFunctions", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("@AplicationCode", strAplicationCode)
            cm.Parameters.AddWithValue("@ProfileID", intProfile)
            cm.Parameters.AddWithValue("@ParentCode", strParentID)

            dr = cm.ExecuteReader()
            While dr.Read
                Dim objFunction As New _Function
                objFunction.FunctionCode = dr.Item("FunctionCode")
                objFunction.FunctionName = dr.Item("FunctionName")
                objFunction.IsInProfile = dr.Item("Exist")
                FunctionCollection.Add(objFunction)
            End While
            Return FunctionCollection

            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cm.Dispose()
            dr.Close()
            cn.Close()
            cn.Dispose()
        End Try
    End Function

    Public Overrides Sub updateProfileFunctions(ByVal intProfileID As Integer, ByVal alstFunctionsID As ArrayList)
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_deleteProfileFunctions", cn)
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("@ProfileID", intProfileID)
            cm.ExecuteNonQuery()
            cm.Parameters.Clear()

            cm.CommandText = "sp_insertProfileFunction"
            For i As Integer = 0 To alstFunctionsID.Count - 1
                cm.Parameters.AddWithValue("@ProfileID", intProfileID)
                cm.Parameters.AddWithValue("@FunctionCode", alstFunctionsID.Item(i))
                cm.ExecuteNonQuery()
                cm.Parameters.Clear()
            Next
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cm.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Sub

#End Region

#Region "Functions"

    Public Overrides Function getAplicationFunctions(ByVal strAplicationCode As String, ByVal strParentCode As String) As FunctionCollection
        Dim FunctionCollection As New FunctionCollection
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_getAplicationFunctions", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("@AplicationCode", strAplicationCode)
            cm.Parameters.AddWithValue("@ParentCode", strParentCode)

            dr = cm.ExecuteReader()
            While dr.Read
                Dim objFunction As New _Function
                objFunction.FunctionCode = DBToStr(dr.Item("FunctionCode"))
                objFunction.ParentCode = DBToStr(dr.Item("ParentCode"))
                objFunction.FunctionName = DBToStr(dr.Item("FunctionName"))
                FunctionCollection.Add(objFunction)
            End While
            Return FunctionCollection

            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            dr.Close()
            cm.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Function

    Public Overrides Function loadFunction(ByVal strFunctionCode As String) As _Function
        Dim objFunction As New _Function
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_getFunction", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("@FunctionCode", strFunctionCode)

            dr = cm.ExecuteReader()
            While dr.Read
                objFunction.FunctionCode = DBToStr(dr.Item("FunctionCode"))
                objFunction.ParentCode = DBToStr(dr.Item("ParentCode"))
                objFunction.FunctionName = DBToStr(dr.Item("FunctionName"))
            End While
            Return objFunction

            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cm.Dispose()
            dr.Close()
            cn.Close()
            cn.Dispose()
        End Try
    End Function

    Public Overrides Sub storeFunction(ByVal objFunction As _Function)
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_storeFunction", cn)
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("@FunctionCode", objFunction.FunctionCode)
            cm.Parameters.AddWithValue("@ParentCode", objFunction.ParentCode)
            cm.Parameters.AddWithValue("@FunctionName", objFunction.FunctionName)
            cm.Parameters.AddWithValue("@AplicationCode", objFunction.AplicationCode)

            cm.ExecuteNonQuery()

            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cm.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Sub

    Public Overrides Sub updateFunction(ByVal objFunction As _Function)
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_updateFunction", cn)
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("@FunctionCode", objFunction.FunctionCode)
            cm.Parameters.AddWithValue("@ParentCode", objFunction.ParentCode)
            cm.Parameters.AddWithValue("@FunctionName", objFunction.FunctionName)

            cm.ExecuteNonQuery()

            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cm.Dispose()
            cn.Close()
            cn.Dispose()
        End Try

    End Sub

    Public Overrides Sub deleteFunction(ByVal strFunctionCode As String, ByVal strAplicationCode As String)
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_deleteFunction", cn)
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("@FunctionCode", strFunctionCode)
            cm.Parameters.AddWithValue("@AplicationCode", strAplicationCode)

            cm.ExecuteNonQuery()

            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cm.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Sub

    Public Overrides Function hasFunctionsChildren(ByVal strFunctionCode As String) As Boolean
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_functionsChildren", cn)
        Dim dr As SqlDataReader

        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("@FunctionCode", strFunctionCode)
            dr = cm.ExecuteReader
            If Not dr.HasRows Then
                Return False
            Else
                Return True
            End If
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            dr.Close()
            cm.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Function

    Public Overrides Function accessFunction(ByVal strUserName As String, ByVal strFunctionCode As String) As Boolean
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_accessFunction", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("@UserName", strUserName)
            cm.Parameters.AddWithValue("@FunctionCode", strFunctionCode)
            dr = cm.ExecuteReader
            If dr.HasRows Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw (ex)
        Finally
            dr.Close()
            cm.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Function

#End Region

#Region "Aplications"

    Public Overloads Overrides Function loadAplications() As DataSet
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim ds As New DataSet
        Dim da As New SqlDataAdapter("sp_loadAplications", cn)
        Try
            cn.Open()
            da.SelectCommand.CommandType = CommandType.StoredProcedure
            da.Fill(ds)

            Return ds
        Catch ex As Exception
            Throw (ex)
        Finally
            da.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Function

    'Public Overloads Overrides Function loadAplications(ByVal ddl As DropDownList)
    '    Dim cn As New SqlConnection
    '    cn.ConnectionString = myConnStringGPU
    '    Dim cm As New SqlCommand("sp_loadAplications", cn)

    '    Try
    '        cn.Open()
    '        cm.CommandType = CommandType.StoredProcedure
    '        ddl.DataValueField = "AplicationCode"
    '        ddl.DataTextField = "AplicationName"
    '        ddl.DataSource = cm.ExecuteReader(CommandBehavior.CloseConnection)
    '        ddl.DataBind()

    '    Catch ex As Exception
    '        Dim erro As String = ex.ToString
    '        Dim a As String = "a"
    '    Finally
    '        cn.Close()
    '    End Try

    'End Function

    'Public Overloads Overrides Function loadAplications(ByVal rbl As RadioButtonList)
    '    Dim cn As New SqlConnection
    '    cn.ConnectionString = myConnStringGPU
    '    Dim cm As New SqlCommand("sp_loadAplications", cn)
    '    'Dim dr As SqlDataReader
    '    'Dim colProfiles As New Collection
    '    Try
    '        cn.Open()
    '        cm.CommandType = CommandType.StoredProcedure
    '        rbl.DataValueField = "AplicationCode"
    '        rbl.DataTextField = "AplicationName"
    '        rbl.DataSource = cm.ExecuteReader(CommandBehavior.CloseConnection)
    '        rbl.DataBind()
    '        rbl.SelectedValue = rbl.Items(0).Value

    '    Catch ex As Exception

    '    Finally
    '        cn.Close()
    '    End Try

    'End Function


    'Public Overloads Overrides Function loadAplications(ByVal cbl As CheckBoxList)
    '    Dim cn As New SqlConnection
    '    cn.ConnectionString = myConnStringGPU
    '    Dim cm As New SqlCommand("sp_loadAplications", cn)
    '    'Dim dr As SqlDataReader
    '    'Dim colProfiles As New Collection
    '    Try
    '        cn.Open()
    '        cm.CommandType = CommandType.StoredProcedure
    '        cbl.DataValueField = "AplicationCode"
    '        cbl.DataTextField = "AplicationName"
    '        cbl.DataSource = cm.ExecuteReader(CommandBehavior.CloseConnection)
    '        cbl.DataBind()

    '    Catch ex As Exception

    '    Finally
    '        cn.Close()
    '    End Try

    'End Function


    'Public Overloads Overrides Function loadAplications(ByVal dg As DataGrid)
    '    Dim cn As New SqlConnection
    '    cn.ConnectionString = myConnStringGPU
    '    Dim ds As New DataSet
    '    Dim da As New SqlDataAdapter("sp_loadAplications", cn)
    '    Try
    '        cn.Open()
    '        da.SelectCommand.CommandType = CommandType.StoredProcedure

    '        da.Fill(ds)

    '        dg.DataSource = ds
    '        dg.DataBind()
    '    Catch ex As Exception
    '        Dim erro As String = ex.ToString
    '        Dim a As String = "a"
    '    Finally
    '        cn.Close()
    '        da = Nothing
    '        cn = Nothing
    '    End Try

    'End Function

    Public Overrides Sub storeAplication(ByVal objAplication As Aplication)
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_storeAplication", cn)
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("@AplicationCode", objAplication.AplicationCode)
            cm.Parameters.AddWithValue("@AplicationName", objAplication.AplicationName)
            cm.Parameters.AddWithValue("@Version", objAplication.Version)

            cm.ExecuteNonQuery()

            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cm.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Sub


    Public Overrides Sub updateAplication(ByVal objAplication As Aplication)
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_updateAplication", cn)
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("@AplicationCode", objAplication.AplicationCode)
            cm.Parameters.AddWithValue("@AplicationName", objAplication.AplicationName)
            cm.Parameters.AddWithValue("@Version", objAplication.Version)

            cm.ExecuteNonQuery()

            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cm.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Sub

    Public Overrides Sub deleteAplication(ByVal strAplicationCode As String)
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_deleteAplication", cn)
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("@AplicationCode", strAplicationCode)

            cm.ExecuteNonQuery()

            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cm.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Sub

    Public Overrides Function getAllAplications() As Hashtable
        Dim hash As New Hashtable
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_loadAplications", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            dr = cm.ExecuteReader()
            While dr.Read
                hash.Add(dr.Item("AplicationID"), dr.Item("AplicationName"))
            End While
            Return hash

            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cm.Dispose()
            dr.Close()
            cn.Close()
            cn.Dispose()
        End Try
    End Function

    Public Overrides Function loadAplication(ByVal strAplicationCode As String) As Aplication
        Dim objAplication As New Aplication(strAplicationCode)
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_loadAplication", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("@AplicationCode", strAplicationCode)

            dr = cm.ExecuteReader()
            While dr.Read
                objAplication.AplicationName = DBToStr(dr.Item("AplicationName"))
                objAplication.Version = DBToStr(dr.Item("Version"))
            End While
            Return objAplication

            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cm.Dispose()
            dr.Close()
            cn.Close()
            cn.Dispose()
        End Try
    End Function

    Public Overrides Function accessAplication(ByVal strUserName As String, ByVal strAplicationCode As String) As Boolean
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_accessAplication", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("@UserName", strUserName)
            cm.Parameters.AddWithValue("@AplicationCode", strAplicationCode)
            dr = cm.ExecuteReader
            If dr.HasRows Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw (ex)
        Finally
            dr.Close()
            cm.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Function

#End Region

#Region "AplicationEmployee"

    Public Overrides Sub updateAplicationsEmployee(ByVal strUserName As String, ByVal hshAplicationsID As Hashtable)
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_insertAplicationEmployee", cn)
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            For Each key As String In hshAplicationsID.Keys
                cm.Parameters.AddWithValue("@UserName", strUserName)
                cm.Parameters.AddWithValue("@AplicationCode", key)
                cm.Parameters.AddWithValue("@Checked", hshAplicationsID(key))
                Dim vkey As Integer = hshAplicationsID(key)
                cm.ExecuteNonQuery()
                cm.Parameters.Clear()
            Next
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cm.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Sub

    Public Overrides Function loadAplicationsEmployee(ByVal strUserName As String) As ArrayList
        Dim alst As New ArrayList
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_loadAplicationsEmployee", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("@UserName", strUserName)

            dr = cm.ExecuteReader()
            While dr.Read
                alst.Add(CStr(dr.Item("AplicationCode")))
            End While
            Return alst

            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            dr.Close()
            cm.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Function

#End Region

#Region "Statistics DigitArq"

    Public Function stLoadEmployeesNames() As Hashtable
        Dim hsh As New Hashtable
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_loadEmployees", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("@ListType", 2)
            cm.Parameters.AddWithValue("@AplicationCode", "DIGITARQ")

            dr = cm.ExecuteReader()
            While dr.Read
                hsh.Add(DBToStr(dr.Item("UserName")), DBToStr(dr.Item("FullName")))
            End While
            Return hsh

            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

    Public Function stGetYears() As ArrayList
        Dim alst As New ArrayList
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_getYears", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            dr = cm.ExecuteReader()
            While dr.Read
                alst.Add(CStr(dr.Item("y")))
            End While
            alst.Sort()
            Return alst

            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

    Public Function stCalcTotDay(ByVal UserName As String, ByVal descr As String, ByVal FunctionCode As Int16, ByVal d As String, ByVal m As String, ByVal y As String) As Int32
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_calcTotDay", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            cm.Parameters.AddWithValue("@UserName", UserName)
            cm.Parameters.AddWithValue("@descr", descr)
            cm.Parameters.AddWithValue("@FunctionCode", FunctionCode)
            cm.Parameters.AddWithValue("@d", Convert.ToInt16(d))
            cm.Parameters.AddWithValue("@m", Convert.ToInt16(m))
            cm.Parameters.AddWithValue("@y", Convert.ToInt16(y))

            dr = cm.ExecuteReader
            dr.Read()
            Return Convert.ToInt32(dr.Item("Num"))
            dr.Close()
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

    Public Function stCalcTotDayAl(ByVal UserName As String, ByVal descr As String, ByVal d As String, ByVal m As String, ByVal y As String) As ArrayList
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_calcTotDayAl", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            cm.Parameters.AddWithValue("@UserName", UserName)
            cm.Parameters.AddWithValue("@descr", descr)
            cm.Parameters.AddWithValue("@d", Convert.ToInt16(d))
            cm.Parameters.AddWithValue("@m", Convert.ToInt16(m))
            cm.Parameters.AddWithValue("@y", Convert.ToInt16(y))

            dr = cm.ExecuteReader
            Dim temp As New ArrayList
            Dim less As Int32 = 0
            Dim more As Int32 = 0
            Dim hash As New Hashtable
            Dim at() As String
            Dim node As String
            Dim num As Int32 = 0
            While dr.Read
                at = dr.Item("Description").Split(" ")
                node = at(0) & " " & at(1) & " " & at(2)
                If hash.ContainsKey(node) Then
                    num = hash(node) + dr.Item("Num")
                    hash.Remove(node)
                Else
                    num = dr.Item("Num")
                End If
                hash.Add(node, num)
            End While

            Dim i As Int32
            For Each i In hash.Values
                If (i > 2) Then
                    more += 1
                Else : less += 1
                End If
            Next
            temp.Add(less)
            temp.Add(more)
            Return temp
            dr.Close()
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

    Public Function stCalcTotMon(ByVal UserName As String, ByVal descr As String, ByVal FunctionCode As Int16, ByVal m As String, ByVal y As String) As Int32
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_calcTotMon", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            cm.Parameters.AddWithValue("@UserName", UserName)
            cm.Parameters.AddWithValue("@descr", descr)
            cm.Parameters.AddWithValue("@FunctionCode", FunctionCode)
            cm.Parameters.AddWithValue("@m", m)
            cm.Parameters.AddWithValue("@y", y)

            dr = cm.ExecuteReader
            dr.Read()
            Return Convert.ToInt32(dr.Item("Num"))
            dr.Close()
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

    Public Function stCalcTotMon(ByVal UserName As String, ByVal FunctionCode As Int16, ByVal m As String, ByVal y As String) As Int32
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_calcTotMon2", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            cm.Parameters.AddWithValue("@UserName", UserName)
            cm.Parameters.AddWithValue("@FunctionCode", FunctionCode)
            cm.Parameters.AddWithValue("@m", m)
            cm.Parameters.AddWithValue("@y", y)

            dr = cm.ExecuteReader
            dr.Read()
            Return Convert.ToInt32(dr.Item("Num"))
            dr.Close()
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

    Public Function stCalcTotMonAl(ByVal UserName As String, ByVal descr As String, ByVal m As String, ByVal y As String) As ArrayList
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_calcTotMonAl", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            cm.Parameters.AddWithValue("@UserName", UserName)
            cm.Parameters.AddWithValue("@descr", descr)
            cm.Parameters.AddWithValue("@m", m)
            cm.Parameters.AddWithValue("@y", y)

            dr = cm.ExecuteReader
            Dim temp As New ArrayList
            Dim less As Int32 = 0
            Dim more As Int32 = 0
            Dim hash As New Hashtable
            Dim at() As String
            Dim node As String
            Dim num As Int32 = 0
            While dr.Read
                at = dr.Item("Description").Split(" ")
                node = at(0) & " " & at(1) & " " & at(2)
                If hash.ContainsKey(node) Then
                    num = hash(node) + dr.Item("Num")
                    hash.Remove(node)
                Else
                    num = dr.Item("Num")
                End If
                hash.Add(node, num)
            End While

            Dim i As Int32
            For Each i In hash.Values
                If (i > 2) Then
                    more += 1
                Else : less += 1
                End If
            Next
            temp.Add(less)
            temp.Add(more)
            Return temp
            dr.Close()
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

    Public Function stCalcTotMonAl(ByVal UserName As String, ByVal m As String, ByVal y As String) As ArrayList
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_calcTotMon2Al", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            cm.Parameters.AddWithValue("@UserName", UserName)
            cm.Parameters.AddWithValue("@m", m)
            cm.Parameters.AddWithValue("@y", y)

            dr = cm.ExecuteReader
            Dim temp As New ArrayList
            Dim less As Int32 = 0
            Dim more As Int32 = 0
            Dim hash As New Hashtable
            Dim at() As String
            Dim node As String
            Dim num As Int32 = 0
            While dr.Read
                at = dr.Item("Description").Split(" ")
                node = at(0) & " " & at(1) & " " & at(2)
                If hash.ContainsKey(node) Then
                    num = hash(node) + dr.Item("Num")
                    hash.Remove(node)
                Else
                    num = dr.Item("Num")
                End If
                hash.Add(node, num)
            End While

            Dim i As Int32
            For Each i In hash.Values
                If (i > 2) Then
                    more += 1
                Else : less += 1
                End If
            Next
            temp.Add(less)
            temp.Add(more)
            Return temp
            dr.Close()
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

    Public Function stCalcTotMonAll(ByVal descr As String, ByVal FunctionCode As Int16, ByVal m As String, ByVal y As String) As Int32
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_calcTotMonAll", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            cm.Parameters.AddWithValue("@descr", descr)
            cm.Parameters.AddWithValue("@FunctionCode", FunctionCode)
            cm.Parameters.AddWithValue("@m", Convert.ToInt16(m))
            cm.Parameters.AddWithValue("@y", Convert.ToInt16(y))

            dr = cm.ExecuteReader
            dr.Read()
            Return Convert.ToInt32(dr.Item("Num"))
            dr.Close()
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

    Public Function stCalcTotMonAll(ByVal FunctionCode As Int16, ByVal m As String, ByVal y As String) As Int32
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_calcTotMonAll2", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            cm.Parameters.AddWithValue("@FunctionCode", FunctionCode)
            cm.Parameters.AddWithValue("@m", Convert.ToInt16(m))
            cm.Parameters.AddWithValue("@y", Convert.ToInt16(y))

            dr = cm.ExecuteReader
            dr.Read()
            Return Convert.ToInt32(dr.Item("Num"))
            dr.Close()
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

    Public Function stCalcTotMonAllAl(ByVal m As String, ByVal y As String) As ArrayList
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_calcTotMonAll2Al", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            cm.Parameters.AddWithValue("@m", Convert.ToInt16(m))
            cm.Parameters.AddWithValue("@y", Convert.ToInt16(y))

            dr = cm.ExecuteReader
            Dim temp As New ArrayList
            Dim less As Int32 = 0
            Dim more As Int32 = 0
            Dim hash As New Hashtable
            Dim at() As String
            Dim node As String
            Dim num As Int32 = 0
            While dr.Read
                at = dr.Item("Description").Split(" ")
                node = at(0) & " " & at(1) & " " & at(2)
                If hash.ContainsKey(node) Then
                    num = hash(node) + dr.Item("Num")
                    hash.Remove(node)
                Else
                    num = dr.Item("Num")
                End If
                hash.Add(node, num)
            End While

            Dim i As Int32
            For Each i In hash.Values
                If (i > 2) Then
                    more += 1
                Else : less += 1
                End If
            Next
            temp.Add(less)
            temp.Add(more)
            Return temp
            dr.Close()
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

    Public Function stCalcTotMonAllAl(ByVal descr As String, ByVal m As String, ByVal y As String) As ArrayList
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_calcTotMonAllAl", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            cm.Parameters.AddWithValue("@descr", descr)
            cm.Parameters.AddWithValue("@m", Convert.ToInt16(m))
            cm.Parameters.AddWithValue("@y", Convert.ToInt16(y))

            dr = cm.ExecuteReader
            Dim temp As New ArrayList
            Dim less As Int32 = 0
            Dim more As Int32 = 0
            Dim hash As New Hashtable
            Dim at() As String
            Dim node As String
            Dim num As Int32 = 0
            While dr.Read
                at = dr.Item("Description").Split(" ")
                node = at(0) & " " & at(1) & " " & at(2)
                If hash.ContainsKey(node) Then
                    num = hash(node) + dr.Item("Num")
                    hash.Remove(node)
                Else
                    num = dr.Item("Num")
                End If
                hash.Add(node, num)
            End While

            Dim i As Int32
            For Each i In hash.Values
                If (i > 2) Then
                    more += 1
                Else : less += 1
                End If
            Next
            temp.Add(less)
            temp.Add(more)
            Return temp
            dr.Close()
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

    Public Function stCalcTotYear(ByVal UserName As String, ByVal descr As String, ByVal FunctionCode As Int16, ByVal y As String) As Int32
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_calcTotYear", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            cm.Parameters.AddWithValue("@UserName", UserName)
            cm.Parameters.AddWithValue("@descr", descr)
            cm.Parameters.AddWithValue("@FunctionCode", FunctionCode)
            cm.Parameters.AddWithValue("@y", Convert.ToInt16(y))

            dr = cm.ExecuteReader
            dr.Read()
            Return Convert.ToInt32(dr.Item("Num"))
            dr.Close()
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

    Public Function stCalcTotYearAl(ByVal UserName As String, ByVal descr As String, ByVal y As String) As ArrayList
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_calcTotYearAl", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            cm.Parameters.AddWithValue("@UserName", UserName)
            cm.Parameters.AddWithValue("@descr", descr)
            cm.Parameters.AddWithValue("@y", Convert.ToInt16(y))

            dr = cm.ExecuteReader
            Dim temp As New ArrayList
            Dim less As Int32 = 0
            Dim more As Int32 = 0
            Dim hash As New Hashtable
            Dim at() As String
            Dim node As String
            Dim num As Int32 = 0
            While dr.Read
                at = dr.Item("Description").Split(" ")
                node = at(0) & " " & at(1) & " " & at(2)
                If hash.ContainsKey(node) Then
                    num = hash(node) + dr.Item("Num")
                    hash.Remove(node)
                Else
                    num = dr.Item("Num")
                End If
                hash.Add(node, num)
            End While

            Dim i As Int32
            For Each i In hash.Values
                If (i > 2) Then
                    more += 1
                Else : less += 1
                End If
            Next
            temp.Add(less)
            temp.Add(more)
            Return temp
            dr.Close()
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

    Public Function stCalcTotYearAll(ByVal descr As String, ByVal FunctionCode As Int16, ByVal y As String) As Int32
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_calcTotYearAll", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            cm.Parameters.AddWithValue("@descr", descr)
            cm.Parameters.AddWithValue("@FunctionCode", FunctionCode)
            cm.Parameters.AddWithValue("@y", Convert.ToInt16(y))

            dr = cm.ExecuteReader
            dr.Read()
            Return Convert.ToInt32(dr.Item("Num"))
            dr.Close()
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

    Public Function stCalcTotYearAllAl(ByVal descr As String, ByVal y As String) As ArrayList
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_calcTotYearAllAl", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            cm.Parameters.AddWithValue("@descr", descr)
            cm.Parameters.AddWithValue("@y", Convert.ToInt16(y))

            dr = cm.ExecuteReader
            Dim temp As New ArrayList
            Dim less As Int32 = 0
            Dim more As Int32 = 0
            Dim hash As New Hashtable
            Dim at() As String
            Dim node As String
            Dim num As Int32 = 0
            While dr.Read
                at = dr.Item("Description").Split(" ")
                node = at(0) & " " & at(1) & " " & at(2)
                If hash.ContainsKey(node) Then
                    num = hash(node) + dr.Item("Num")
                    hash.Remove(node)
                Else
                    num = dr.Item("Num")
                End If
                hash.Add(node, num)
            End While

            Dim i As Int32
            For Each i In hash.Values
                If (i > 2) Then
                    more += 1
                Else : less += 1
                End If
            Next
            temp.Add(less)
            temp.Add(more)
            Return temp
            dr.Close()
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

    Public Function stGetOpsPerUser(ByVal y As String, ByVal op As Int16) As Hashtable
        Dim hash As New Hashtable
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_calcNumOpsPerUser", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("@y", Convert.ToInt16(y))
            cm.Parameters.AddWithValue("@op", op)

            dr = cm.ExecuteReader()
            While dr.Read
                hash.Add(dr.Item("UserName"), dr.Item("Num"))
            End While
            Return hash
            dr.Close()

            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try

    End Function

    Public Function stCalcNumOps(ByVal y As String, ByVal op As Int16) As Int32
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_calcTotLog", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("@y", y)
            cm.Parameters.AddWithValue("@op", op)

            dr = cm.ExecuteReader
            dr.Read()
            Return Convert.ToInt32(dr.Item("Num"))
            dr.Close()
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

    Public Function stLoadCUIDF() As Hashtable
        Dim hash As New Hashtable
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_loadCUIDF", cn)
        Dim dr As SqlDataReader
        Dim temp As String = ""
        Dim tmp As ArquiveGroup
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            dr = cm.ExecuteReader()

            While dr.Read
                If Not IsDBNull(dr.Item("CompleteUnitID")) Then
                    temp = dr.Item("CompleteUnitID").Split("/").GetValue(0)
                    If (hash.Contains(temp)) Then
                        tmp = hash(temp)
                        hash.Remove(temp)
                        tmp.addExtentMl(dr.Item("ExtentMl"))
                        hash.Add(temp, tmp)
                    Else : hash.Add(temp, New ArquiveGroup(temp, dr.Item("ExtentMl")))
                    End If
                End If
            End While
            Return hash
            dr.Close()

            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

    Public Function stLoadIDFunds() As ArrayList
        Dim alst As New ArrayList
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_loadIDFunds", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            dr = cm.ExecuteReader()
            While dr.Read
                alst.Add(CStr(dr.Item("ID")))
            End While

            Return alst
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

    Public Function stCalcNumFundRev() As Int32
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_calcNumFundRev", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            dr = cm.ExecuteReader
            dr.Read()
            Return Convert.ToInt32(dr.Item("Num"))
            dr.Close()
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

    Public Function stCalcNumFundVis() As Int32
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_calcNumFundVis", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            dr = cm.ExecuteReader
            dr.Read()
            Return Convert.ToInt32(dr.Item("Num"))
            dr.Close()
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

    Public Function stCalcWarn() As Int32
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_calcWarn", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            dr = cm.ExecuteReader
            dr.Read()
            Return Convert.ToInt32(dr.Item("Num"))
            dr.Close()
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

    Public Function stCalcTotReg() As Int32
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_calcTotReg", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            dr = cm.ExecuteReader
            dr.Read()
            Return Convert.ToInt32(dr.Item("Num"))
            dr.Close()
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

    Public Function stCalcTotRegRev() As Int32
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_calcTotRegRev", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            dr = cm.ExecuteReader
            dr.Read()
            Return Convert.ToInt32(dr.Item("Num"))
            dr.Close()
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

    Public Function stCalcTotRegVis() As Int32
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_calcTotRegVis", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            dr = cm.ExecuteReader
            dr.Read()
            Return Convert.ToInt32(dr.Item("Num"))
            dr.Close()
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

    Public Function stLoadIDUID() As Hashtable
        Dim hash As New Hashtable
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_loadIDUID", cn)
        Dim dr As SqlDataReader
        Dim temp As String = ""
        Dim tmp As Integer = 0
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            dr = cm.ExecuteReader()

            While dr.Read
                If Not IsDBNull(dr.Item("UnitID")) Then
                    hash.Add(dr.Item("ID"), dr.Item("UnitID"))
                End If
            End While
            Return hash
            dr.Close()

            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

    Public Function stChkRegC() As Int32
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_loadUIDandCUID", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            dr = cm.ExecuteReader
            Dim count As Int32 = 0
            While dr.Read
                If Not IsDBNull(dr.Item("UnitID")) And Not IsDBNull(dr.Item("CompleteUnitID")) Then
                    Dim str As String = dr.Item("CompleteUnitID")
                    If str.EndsWith(dr.Item("UnitID")) Then
                        count += 1
                    End If
                End If
            End While
            Return count
            dr.Close()
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

    Public Function stLoadUIDandUIT(ByVal id As String) As ArrayList
        Dim arLst As New ArrayList
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_loadUIDandUITbyID", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("@id", id)

            dr = cm.ExecuteReader()

            While dr.Read
                If Not IsDBNull(dr.Item("UnitID")) And Not IsDBNull(dr.Item("UnitTitle")) Then
                    arLst.Add(DBToStr(dr.Item("UnitID")))
                    arLst.Add(DBToStr(dr.Item("UnitTitle")))
                End If
            End While
            Return arLst
            dr.Close()

            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

    Public Function stGetDescr(ByVal op As String) As DataSet
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim objDataAdapter As SqlDataAdapter
        Dim objDataSet As DataSet

        Try
            cn.Open()
            If op = "F" Then
                objDataAdapter = New SqlDataAdapter("sp_getDescrF", cn)
            ElseIf op = "SC" Then
                objDataAdapter = New SqlDataAdapter("sp_getDescrSC", cn)
            ElseIf op = "SR" Then
                objDataAdapter = New SqlDataAdapter("sp_getDescrSR", cn)
            ElseIf op = "UI" Then
                objDataAdapter = New SqlDataAdapter("sp_getDescrUI", cn)
            ElseIf op = "D" Then
                objDataAdapter = New SqlDataAdapter("sp_getDescrD", cn)
            End If

            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            objDataSet = New DataSet
            objDataAdapter.Fill(objDataSet)

            Return objDataSet
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

    Public Function stGetNDescr(ByVal op As String) As Int32
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As SqlCommand
        If op = "F" Then
            cm = New SqlCommand("sp_getNdescrF", cn)
        ElseIf op = "SC" Then
            cm = New SqlCommand("sp_getNdescrSC", cn)
        ElseIf op = "SR" Then
            cm = New SqlCommand("sp_getNdescrSR", cn)
        ElseIf op = "UI" Then
            cm = New SqlCommand("sp_getNdescrUI", cn)
        ElseIf op = "D" Then
            cm = New SqlCommand("sp_getNdescrD", cn)
        End If

        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            dr = cm.ExecuteReader
            dr.Read()
            Return Convert.ToInt32(dr.Item("Num"))
            dr.Close()
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

    Public Function stCalcTotFunds() As Int32
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_calcTotFunds", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            dr = cm.ExecuteReader
            dr.Read()
            Return Convert.ToInt32(dr.Item("Num"))
            dr.Close()
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

    Public Function stCalcTotPeriodAll(ByVal descr As String, ByVal FunctionCode As Int16, ByVal from As String, ByVal t As String) As Int32
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_calcTotPeriodAll", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            cm.Parameters.AddWithValue("@descr", descr)
            cm.Parameters.AddWithValue("@FunctionCode", FunctionCode)
            cm.Parameters.AddWithValue("@from", from)
            cm.Parameters.AddWithValue("@to", t)

            dr = cm.ExecuteReader
            dr.Read()
            Return Convert.ToInt32(dr.Item("Num"))
            dr.Close()
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

    Public Function stCalcTotPeriodAllAl(ByVal descr As String, ByVal from As String, ByVal t As String) As ArrayList
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_calcTotPeriodAllAl", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            cm.Parameters.AddWithValue("@descr", descr)
            cm.Parameters.AddWithValue("@from", from)
            cm.Parameters.AddWithValue("@to", t)

            dr = cm.ExecuteReader
            Dim temp As New ArrayList
            Dim less As Int32 = 0
            Dim more As Int32 = 0
            Dim hash As New Hashtable
            Dim at() As String
            Dim node As String
            Dim num As Int32 = 0
            While dr.Read
                at = dr.Item("Description").Split(" ")
                node = at(0) & " " & at(1) & " " & at(2)
                If hash.ContainsKey(node) Then
                    num = hash(node) + dr.Item("Num")
                    hash.Remove(node)
                Else
                    num = dr.Item("Num")
                End If
                hash.Add(node, num)
            End While

            Dim i As Int32
            For Each i In hash.Values
                If (i > 2) Then
                    more += 1
                Else : less += 1
                End If
            Next
            temp.Add(less)
            temp.Add(more)
            Return temp
            dr.Close()
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

    Public Function stCalcTotPeriod(ByVal UserName As String, ByVal descr As String, ByVal FunctionCode As Int16, ByVal from As String, ByVal t As String) As Int32
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_calcTotPeriod", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            cm.Parameters.AddWithValue("@UserName", UserName)
            cm.Parameters.AddWithValue("@descr", descr)
            cm.Parameters.AddWithValue("@FunctionCode", FunctionCode)
            cm.Parameters.AddWithValue("@from", from)
            cm.Parameters.AddWithValue("@to", t)

            dr = cm.ExecuteReader
            dr.Read()
            Return Convert.ToInt32(dr.Item("Num"))
            dr.Close()
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

    Public Function stCalcTotPeriodAl(ByVal UserName As String, ByVal descr As String, ByVal from As String, ByVal t As String) As ArrayList
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_calcTotPeriodAl", cn)
        Dim dr As SqlDataReader
        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            cm.Parameters.AddWithValue("@UserName", UserName)
            cm.Parameters.AddWithValue("@descr", descr)
            cm.Parameters.AddWithValue("@from", from)
            cm.Parameters.AddWithValue("@to", t)

            dr = cm.ExecuteReader
            Dim temp As New ArrayList
            Dim less As Int32 = 0
            Dim more As Int32 = 0
            Dim hash As New Hashtable
            Dim at() As String
            Dim node As String
            Dim num As Int32 = 0
            While dr.Read
                at = dr.Item("Description").Split(" ")
                node = at(0) & " " & at(1) & " " & at(2)
                If hash.ContainsKey(node) Then
                    num = hash(node) + dr.Item("Num")
                    hash.Remove(node)
                Else
                    num = dr.Item("Num")
                End If
                hash.Add(node, num)
            End While

            Dim i As Int32
            For Each i In hash.Values
                If (i > 2) Then
                    more += 1
                Else : less += 1
                End If
            Next
            temp.Add(less)
            temp.Add(more)
            Return temp

            dr.Close()
            myReturn = eReturn.Sucess
        Catch ex As Exception
            Throw (ex)
        Finally
            cn.Close()
        End Try
    End Function

#End Region

#Region "System resources"

    Public Function countLogsByYear() As DataSet
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU

        Dim objDataAdapter As SqlDataAdapter
        Dim objDataSet As DataSet

        Try
            cn.Open()
            objDataAdapter = New SqlDataAdapter("sp_countLogsByYear", cn)
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            objDataSet = New DataSet
            objDataAdapter.Fill(objDataSet)

            Return objDataSet
        Catch ex As Exception
            Throw (ex)
        Finally
            objDataAdapter.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Function

    Public Function countLogsByUsername() As DataSet
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU

        Dim objDataAdapter As SqlDataAdapter
        Dim objDataSet As DataSet

        Try
            cn.Open()
            objDataAdapter = New SqlDataAdapter("sp_countLogsByUsername", cn)
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure

            objDataSet = New DataSet
            objDataAdapter.Fill(objDataSet)

            Return objDataSet
        Catch ex As Exception
            Throw (ex)
        Finally
            objDataAdapter.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Function

    Public Function getDBLocation() As String
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_getDBLocation", cn)

        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.AddWithValue("@DBLocation", SqlDbType.NVarChar)
            cm.Parameters("@DBLocation").Direction = ParameterDirection.Output
            cm.ExecuteNonQuery()
            Return cm.Parameters("@DBLocation").Value
        Catch ex As Exception
            Throw (ex)
        Finally
            cm.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Function

    Public Function getDBFilesLocation() As String()
        Dim ret(2) As String
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_getDBFilesLocation", cn)

        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.Parameters.Add("@DBDataLocation", SqlDbType.NVarChar, 2000)
            cm.Parameters("@DBDataLocation").Direction = ParameterDirection.Output
            cm.Parameters.Add("@DBLogLocation", SqlDbType.NVarChar, 2000)
            cm.Parameters("@DBLogLocation").Direction = ParameterDirection.Output
            cm.ExecuteNonQuery()
            ret(0) = DBToStr(cm.Parameters("@DBDataLocation").Value)
            ret(1) = DBToStr(cm.Parameters("@DBLogLocation").Value)
            Return ret
        Catch ex As Exception
            Throw (ex)
        Finally
            cm.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Function

#End Region

#Region "Statistics GOD"

    Public Function loadTotalImagesByOtherLevel() As DataSet
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU

        Dim objDataAdapter As SqlDataAdapter
        Dim objDataSet As DataSet

        Try
            cn.Open()
            objDataAdapter = New SqlDataAdapter("sp_loadTotalImagesByOtherLevel", cn)
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            objDataAdapter.SelectCommand.CommandTimeout = hshDatabase("ConnectTimeout")

            objDataSet = New DataSet
            objDataAdapter.Fill(objDataSet)

            Return objDataSet
        Catch ex As Exception
            Throw (ex)
        Finally
            objDataAdapter.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Function

    Public Function countProjects() As Integer
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_countProjects", cn)

        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.CommandTimeout = hshDatabase("ConnectTimeout")
            cm.Parameters.AddWithValue("@Count", SqlDbType.Int)
            cm.Parameters("@Count").Direction = ParameterDirection.Output
            cm.ExecuteNonQuery()
            Return cm.Parameters("@Count").Value
        Catch ex As Exception
            Throw (ex)
        Finally
            cm.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Function

    Public Function countDigitalObjects() As Integer
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_countDigitalObjects", cn)

        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.CommandTimeout = hshDatabase("ConnectTimeout")
            cm.Parameters.Add("@Count", SqlDbType.Int)
            cm.Parameters("@Count").Direction = ParameterDirection.Output
            cm.ExecuteNonQuery()
            Return cm.Parameters("@Count").Value
        Catch ex As Exception
            Throw (ex)
        Finally
            cm.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Function

    Public Function countImages() As Integer
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_countImages", cn)

        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.CommandTimeout = hshDatabase("ConnectTimeout")
            cm.Parameters.Add("@Count", SqlDbType.Int)
            cm.Parameters("@Count").Direction = ParameterDirection.Output
            cm.ExecuteNonQuery()
            Return cm.Parameters("@Count").Value
        Catch ex As Exception
            Throw (ex)
        Finally
            cm.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Function

    Public Function countDerivatives() As Integer
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim cm As New SqlCommand("sp_countDerivatives", cn)

        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure
            cm.CommandTimeout = hshDatabase("ConnectTimeout")
            cm.Parameters.Add("@Count", SqlDbType.Int)
            cm.Parameters("@Count").Direction = ParameterDirection.Output
            cm.ExecuteNonQuery()
            Return cm.Parameters("@Count").Value
        Catch ex As Exception
            Throw (ex)
        Finally
            cm.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Function

    Public Function getDOFilesYears() As ArrayList
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU
        Dim dr As SqlDataReader
        Dim cm As New SqlCommand("sp_getDOFilesYears", cn)
        Dim myData As New ArrayList

        Try
            cn.Open()
            cm.CommandType = CommandType.StoredProcedure

            dr = cm.ExecuteReader
            While dr.Read
                myData.Add(dr.Item(0))
            End While

            Return myData
        Catch ex As Exception
            Throw (ex)
        Finally
            cm.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Function

    Public Function loadArchiveProduction(ByVal strYear As String) As DataSet
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU

        Dim objDataAdapter As SqlDataAdapter
        Dim objDataSet As DataSet
        Dim myCommand As String

        Try
            cn.Open()

            objDataAdapter = New SqlDataAdapter("sp_loadArchiveProduction", cn)
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Year", strYear)

            objDataSet = New DataSet
            objDataAdapter.Fill(objDataSet)

            Return objDataSet
        Catch ex As Exception
            Throw (ex)
        Finally
            objDataAdapter.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Function

    Public Function loadEmployeesProduction(ByVal strYear As String) As DataSet
        Dim cn As New SqlConnection
        cn.ConnectionString = myConnStringGPU

        Dim objDataAdapter As SqlDataAdapter
        Dim objDataSet As DataSet

        Try
            cn.Open()
            objDataAdapter = New SqlDataAdapter("sp_loadEmployeesProduction", cn)
            objDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            objDataAdapter.SelectCommand.Parameters.AddWithValue("@Year", strYear)

            objDataSet = New DataSet
            objDataAdapter.Fill(objDataSet)

            Return objDataSet
        Catch ex As Exception
            Throw (ex)
        Finally
            objDataAdapter.Dispose()
            cn.Close()
            cn.Dispose()
        End Try
    End Function

#End Region

#Region "Files Access"

    Private Function acessFile(ByVal fileName As String) As String
        Dim filePath As String = Me.Server.MapPath("") + "\Files" + fileName 'path da aplicação + nome do fich
        Dim file As Integer = FreeFile()
        Dim file_contents As String

        Me.Application.Lock()
        'abrir, ler o valor e fechar o ficheiro
        Try
            If System.IO.File.Exists(filePath) Then
                FileOpen(file, filePath, OpenMode.Input)
                If Not EOF(file) Then
                    Input(file, file_contents)
                End If
                FileClose(file)
            End If
        Catch ex As System.IO.IOException
            file_contents = 0
        End Try

        Return file_contents

        Me.Application.UnLock()
    End Function

#End Region



End Class
