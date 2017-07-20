'*************************************************************************************************
' class: EacMaintenanceHistory
' Purpose: It Collects all items from the EacMaintenanceHistory table (DigitArq database/ EAC Diagram)
'          This is related with, ISAAR(CPF), 5.4.7  Dates of creation and revision.
' The Notation isn't used here.
'***************************************************************************************************
Public Class EacMaintenanceHistory
    Inherits CollectionBase


    Public Function Add(ByVal Type As String, ByVal Name As String, ByVal DateStr As String, ByVal Description As String) As Integer
        Return List.Add(New EacMaintenanceHistoryItem(Type, Name, DateStr, Description))
    End Function


    Public Function Add(ByVal ID As Integer, ByVal Type As String, ByVal Name As String, ByVal DateStr As String, ByVal Description As String) As Integer
        Return List.Add(New EacMaintenanceHistoryItem(ID, Type, Name, DateStr, Description))
    End Function


    Public Sub Remove(ByVal Item As EacMaintenanceHistoryItem)
        List.Remove(Item)
    End Sub

    Public Function Item(ByVal index As Integer) As EacMaintenanceHistoryItem
        Return List.Item(index)
    End Function

    '*************************************************************************************************
    ' Function: toHtml
    ' Purpose: It shows all items from the EacMaintenance table (DigitArq database/ EAC Diagram) for an
    '           given authority record (entry in AEC table)
    '          This is related with, ISAAR(CPF), 5.4.7  Dates of creation and revision.
    ' The Notation isn't used here.
    '***************************************************************************************************

    Public Function toHtml() As String
        If Count = 0 Then Return ""

        Dim Html As String = ""
        For i As Integer = 0 To Count - 1
            Html &= CreateTag("Datas de criação e revisão: ", Item(i).DateStr) & CreateTag("Notas: ", Item(i).Description)
        Next

        Return Html
    End Function


    'Private Function TypeToEac(ByVal Type As String) As String
    '    Select Case Type
    '        Case (VisualFieldLabel("Authorities.Create")) : Return "create"
    '        Case (VisualFieldLabel("Authorities.Delete")) : Return "delete"
    '        Case (VisualFieldLabel("Authorities.Update")) : Return "update"
    '        Case (VisualFieldLabel("Authorities.Import")) : Return "import"
    '        Case Else : Return ""
    '    End Select
    'End Function


End Class



Public Class EacMaintenanceHistoryItem
    Private myID As Integer
    Private myType As String
    Private myName As String
    Private myDate As String
    Private myDescription As String


    Public Sub New(ByVal ID As Integer)
        myID = ID
    End Sub

    Public Sub New(ByVal Type As String, ByVal Name As String, ByVal DateStr As String, ByVal Description As String)
        myID = 0
        myType = Type
        myName = Name
        myDate = DateStr
        myDescription = Description
    End Sub


    Public Sub New(ByVal ID As Integer, ByVal Type As String, ByVal Name As String, ByVal DateStr As String, ByVal Description As String)
        myID = ID
        myType = Type
        myName = Name
        myDate = DateStr
        myDescription = Description
    End Sub

    Public Property ID() As Integer
        Get
            Return myID
        End Get
        Set(ByVal Value As Integer)
            myID = Value
        End Set
    End Property

    Public Property Type() As String
        Get
            Return myType
        End Get
        Set(ByVal Value As String)
            myType = Value
        End Set
    End Property


    Public Property Name() As String
        Get
            Return myName
        End Get
        Set(ByVal Value As String)
            myName = Value
        End Set
    End Property


    Public Property DateStr() As String
        Get
            Return myDate
        End Get
        Set(ByVal Value As String)
            myDate = Value
        End Set
    End Property


    Public Property Description() As String
        Get
            Return myDescription
        End Get
        Set(ByVal Value As String)
            myDescription = Value
        End Set
    End Property

    Public Function Clone() As Object
        Return New EacMaintenanceHistoryItem(myID, myType, myName, myDate, myDescription)
    End Function


    Public Overloads Overrides Function Equals(ByVal obj As Object) As Boolean
        If Not TypeOf obj Is EacMaintenanceHistoryItem Then
            Return False
        Else
            Return ID = CType(obj, EacMaintenanceHistoryItem).ID
        End If
    End Function


End Class