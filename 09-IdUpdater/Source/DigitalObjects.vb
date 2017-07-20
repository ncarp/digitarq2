Imports System.Data.SqlClient ' SQL Server Data Provider



Module DigitalObjects

    'Public Sub AssociateDigitalObject(ByVal ComponentID As Integer, ByVal Title As String, ByVal URL As String)
    '    Dim SQLConnection As SqlConnection = New SqlConnection
    '    SQLConnection.ConnectionString = _
    '        String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", _
    '        "server3", "digitarq", "digitarq", "qartigid")

    '    Dim SQLCommand As New SqlCommand

    '    SQLCommand.Connection = SQLConnection

    '    Dim NbrDigitalObjects As Integer
    '    Try
    '        SQLConnection.Open()
    '        SQLCommand.CommandText = String.Format("INSERT INTO DaoGrp (ComponentID, Title, Href) VALUES ({0}, '{1}', '{2}')", ComponentID, Title, URL)
    '        SQLCommand.ExecuteNonQuery()
    '    Catch ex As Exception
    '    Finally
    '        SQLConnection.Close()
    '    End Try
    'End Sub


    'Public Function HasDigitalObjects(ByVal ComponentID As Integer) As Boolean
    '    Dim SQLConnection As SqlConnection = New SqlConnection
    '    SQLConnection.ConnectionString = _
    '        String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", _
    '        "server3", "digitarq", "websearch", "websearch")

    '    Dim SQLCommand As New SqlCommand

    '    SQLCommand.Connection = SQLConnection

    '    Dim NbrDigitalObjects As Integer = 0
    '    Try
    '        SQLConnection.Open()
    '        SQLCommand.CommandText = String.Format("SELECT COUNT(id) FROM DaoGrp WHERE ComponentID = {0}", ComponentID)
    '        NbrDigitalObjects = CInt(SQLCommand.ExecuteScalar())
    '    Catch ex As Exception
    '    Finally
    '        SQLConnection.Close()
    '    End Try
    '    Return NbrDigitalObjects > 0
    'End Function

End Module
