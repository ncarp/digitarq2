Imports System.Web.UI.WebControls
Imports System.Resources
Imports System.Globalization
Imports System.Threading

Public Module utils

    Public Function strConvDate(ByVal strYear As String, ByVal strMonth As String, ByVal strDay As String) As String
        Dim str As String = strYear.Trim & strMonth.Trim & strDay.Trim
        If strYear.Trim & strMonth.Trim & strDay.Trim = "" Then
            Return ""
        Else
            strYear = strYear.PadLeft(4, "0")

            strMonth = strMonth.PadLeft(2, "0")

            strDay = strDay.PadLeft(2, "0")

            Return strYear & "-" & strMonth & "-" & strDay
            'Try
            '    Dim strDate As Date = strYear & "-" & strMonth & "-" & strDay
            '    Return strDate.ToString
            'Catch ex As Exception
            '    Return "Error"
            'End Try

        End If
    End Function

    Public Function ConvertToDate(ByVal strYear As String, ByVal strMonth As String, ByVal strDay As String) As String
        Dim str As String = strYear.Trim & strMonth.Trim & strDay.Trim
        If strYear.Trim & strMonth.Trim & strDay.Trim = "" Then
            Return ""
        Else
            strYear = strYear.PadLeft(4, "0")

            strMonth = strMonth.PadLeft(2, "0")

            strDay = strDay.PadLeft(2, "0")

            Try
                Dim strDate As Date = strYear & "-" & strMonth & "-" & strDay
                Return strDate.ToString
            Catch ex As Exception
                Return "Error"
            End Try

        End If
    End Function


    Public Sub loadDdlMonth(ByVal ddl As DropDownList)
        Dim firstLI As New ListItem
        firstLI.Value = ""
        firstLI.Text = ""
        ddl.Items.Add(firstLI)
        For i As Integer = 1 To 12
            Dim li As New ListItem
            li.Value = i.ToString.PadLeft(2, "0")
            li.Text = MonthName(i)
            ddl.Items.Add(li)
        Next
    End Sub


    Public Sub loadDdlDay(ByVal ddl As DropDownList)
        ddl.Items.Add("")
        For i As Integer = 1 To 31
            ddl.Items.Add(i.ToString.PadLeft(2, "0"))
        Next
    End Sub


    Public Sub Clean(ByVal controlP As Control)
        Dim ctl As Control
        For Each ctl In controlP.Controls
            If TypeOf ctl Is TextBox Then
                DirectCast(ctl, TextBox).Text = String.Empty
            ElseIf ctl.Controls.Count > 0 Then
                Clean(ctl)
            End If
        Next
    End Sub

End Module
