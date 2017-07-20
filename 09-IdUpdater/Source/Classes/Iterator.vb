Imports System.Configuration
Imports System.Text.RegularExpressions
Imports System.Threading

Public Class Iterator


#Region "Properties"

    Private myProgressDialog As ProgressDialog
    'Private myRootLazyNode As LazyNode
    Private myResult As Object
    Private myArgument As Object
    Private myFondsList As FondsListCollection

    Public Enum Action
        UpdateCompleteUnitId
    End Enum


    Public ReadOnly Property Result()
        Get
            Return myResult
        End Get
    End Property

    Public WriteOnly Property Argument() As Object
        Set(ByVal Value As Object)
            myArgument = Value
        End Set
    End Property

#End Region



#Region "Contructors"


    Public Sub New(ByVal FondsList As FondsListCollection)
        myFondsList = FondsList
    End Sub


#End Region




    Public Function Start(ByVal Action As Action) As Object

        myProgressDialog = New ProgressDialog(True)

        myProgressDialog.MinimumValue = 0
        myProgressDialog.MaximumValue = myFondsList.Count
        myProgressDialog.TopMost = True
        myProgressDialog.Show()

        Dim thread As Thread
        Select Case Action
            Case Action.UpdateCompleteUnitId : thread = New Thread(New ThreadStart(AddressOf UpdateCompleteUnitId))
            Case Else : Exit Function
        End Select


        thread.Priority = GetThreadPriority()
        thread.Start()

        While thread.IsAlive
            System.Windows.Forms.Application.DoEvents()
        End While

        myProgressDialog.Hide()
        myProgressDialog.Close()
        myProgressDialog.Dispose()

        Return Result
    End Function


    Private Function GetThreadPriority() As ThreadPriority
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Dim PriorityLevel As String = CType(configurationAppSettings.GetValue("ThreadPriority", GetType(System.String)), String)
        Select Case PriorityLevel
            Case "1" : Return ThreadPriority.Lowest
            Case "2" : Return ThreadPriority.BelowNormal
            Case "3" : Return ThreadPriority.Normal
            Case "4" : Return ThreadPriority.AboveNormal
            Case "5" : Return ThreadPriority.Highest
            Case Else : Return ThreadPriority.Normal
        End Select

    End Function


#Region "Action code"


    Private Sub UpdateCompleteUnitId()

        Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")
        Dim ServerAddress As String = SQLServerSettings.Item("ServerAddress")
        Dim Username As String = SQLServerSettings.Item("Username")
        Dim Password As String = SQLServerSettings.Item("Password")
        Dim Database As String = SQLServerSettings.Item("Database")

        myResult = 0
        For Each Fonds As FondsListItem In myFondsList
            myProgressDialog.Text = String.Format("Calculating IDs on {0} ...", Fonds.UnitTitle)

            Try
                Dim RootLazyNode As LazyNode = New SQLLazyNode(ServerAddress, Database, Username, Password, Fonds.ID)
                myResult += RootLazyNode.StopableCatamorphism(New GeneUpdateCompleteUnitId(myProgressDialog))
            Catch ex As Exception
                ' do nothing, continue
            End Try
            If myProgressDialog.Cancel Then Exit For
            myProgressDialog.Increment()
        Next

    End Sub

#End Region





End Class
