Imports System.Data.SqlClient


Module MessageBoxes



    Public Sub MsgBoxNetworkError()
        MsgBox(ErrorMessage("DatabaseAccess.Error"), MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly)
    End Sub

    Public Sub MsgBoxCustomError(ByVal ErrorMessage As String)
        MsgBox(ErrorMessage, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly)
    End Sub


    Public Sub MsgBoxSqlException(ByVal ex As SqlException)
        If ex.Number = 511 Then ' record overflow error. Record size is limited to 8060 chars
            MsgBoxCustomError(ErrorMessage("MsgBoxCustomError.RecordOverflow"))
        Else ' Generic error message
            MsgBox(ErrorMessage("MsgBoxCustomError.SqlException") & ControlChars.NewLine & ControlChars.NewLine & _
                   ErrorMessage("MsgBoxCustomError.AdvancedErrorDescription") & ControlChars.NewLine & _
                   "Description: " & ex.Message & ControlChars.NewLine & _
                   "Error type: " & ex.Number & ControlChars.NewLine & _
                   "Server: " & ex.Server & ControlChars.NewLine & _
                   "Source: " & ex.Source & ControlChars.NewLine & _
                   "State: " & ex.State & ControlChars.NewLine & _
                   "Method: " & ex.TargetSite.Name & ControlChars.NewLine & _
                   "Stack trace: " & ex.StackTrace & ControlChars.NewLine, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly)
        End If
    End Sub


    Public Sub MsgBoxException(ByVal ex As Exception)
        If TypeOf ex Is SqlException Then
            MsgBoxSqlException(ex)
        Else
            MsgBox(ErrorMessage("MsgBoxCustomError.Exception") & ControlChars.NewLine & ControlChars.NewLine & _
                   ErrorMessage("MsgBoxCustomError.AdvancedErrorDescription") & ControlChars.NewLine & _
                   "Description: " & ex.Message & ControlChars.NewLine & _
                   "Source: " & ex.Source & ControlChars.NewLine & _
                   "Method: " & ex.TargetSite.Name & ControlChars.NewLine & _
                   "Stack trace: " & ex.StackTrace & ControlChars.NewLine, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly)
        End If
    End Sub


End Module
