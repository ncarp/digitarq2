Imports System.Web
Imports System.Web.SessionState


Public Class [Global]
    Inherits System.Web.HttpApplication

#Region " Component Designer Generated Code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

#End Region

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        'Dim filePath As String = Me.Server.MapPath("") + "\counter.txt" 'path da aplica��o + nome do fich
        'Dim file As Integer = FreeFile()
        'Dim file_contents As String

        'Me.Application.Lock()
        ''abrir, ler o valor e fechar o ficheiro
        'Try
        '    If System.IO.File.Exists(filePath) Then
        '        FileOpen(file, filePath, OpenMode.Input)
        '        If Not EOF(file) Then
        '            Input(file, file_contents)
        '        End If
        '        FileClose(file)
        '    End If
        'Catch ex As System.IO.IOException
        '    file_contents = 0
        'End Try
        ''copiar o valor para a variavel me.application("Counter")
        'Try
        '    Me.Application.Add("counter", file_contents)
        'Catch ex As System.InvalidCastException
        '    Me.Application.Add("counter", 0)
        'End Try
        'Me.Application.UnLock()
    End Sub


    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        'Dim filePath As String = Me.Server.MapPath("") + "\counter.txt"
        'Dim file As Integer = FreeFile()

        'Me.Application.Lock()
        ''incrementa o valor
        'Me.Application("counter") = CInt(Me.Application("counter")) + 1
        ''escrever novo valor no ficheiro
        'Try
        '    If System.IO.File.Exists(filePath) Then
        '        FileOpen(file, filePath, OpenMode.Output)
        '        Print(file, Me.Application("counter"))
        '        FileClose(file)
        '    End If
        'Catch ex As System.IO.IOException
        'End Try

        ''libertar a aplica��o
        'Me.Application.UnLock()
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
        Dim LastException As Exception = Server.GetLastError.GetBaseException

        Dim LastError As String = "<font color='red'><b>Error in: </b></font>" + Request.Url.ToString() & _
              "<br><font color='red'><b>Error Message: </b></font><br>" + LastException.Message.ToString() & _
              "<br><font color='red'><b>Stack Trace: </b></font><br>" & LastException.StackTrace.ToString()

        Context.ClearError()

        Session("Error") = LastError
        Response.Redirect("./defaultIn.aspx?page=gpu-0")
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

End Class
