'*************************************************************************************************
' class: EacResourceRelationships
' Purpose: It Collects all items from the EacArchRelationships table (DigitArq database/ EAC Diagram)
'          This is related with, ISAAR(CPF), 6 - Relating corporate bodies, persons and famalies to
'           to other resources.
' The Notation isn't used here.
'***************************************************************************************************

Public Class EacResourceRelationships
    Inherits CollectionBase


    Public Function Add(ByVal Type As String, ByVal Unit As String, ByVal DateStr As String, ByVal ResourceType As String) As Integer
        Return List.Add(New EacResourceRelationshipsItem(Type, Unit, DateStr, ResourceType))
    End Function


    Public Function Add(ByVal ID As Integer, ByVal Type As String, ByVal Unit As String, ByVal DateStr As String, ByVal ResourceType As String) As Integer
        Return List.Add(New EacResourceRelationshipsItem(ID, Type, Unit, DateStr, ResourceType))
    End Function


    Public Sub Remove(ByVal Item As EacResourceRelationshipsItem)
        List.Remove(Item)
    End Sub

    Public Function Item(ByVal index As Integer) As EacResourceRelationshipsItem
        Return List.Item(index)
    End Function

    'Private Function TypeToEac(ByVal Type As String) As String
    '    Select Case Type
    '        Case VisualFieldLabel("Authorities.Other") : Return "other"
    '        Case Else : Return ""
    '    End Select
    'End Function


    '*************************************************************************************************
    ' Function: toHtml
    ' Purpose: It shows all items from the EacResourceRelationships table (DigitArq database/ EAC Diagram)
    '          This is related with, ISAAR(CPF) a part of point 6.
    ' The Notation isn't used here.
    '***************************************************************************************************
    Public Function toHtml() As String
        If Count = 0 Then Return ""

        Dim Html As String = ""
        For i As Integer = 0 To Count - 1
            Html &= CreateTag("Identificador do recurso relacionado: ", Item(i).Unit) & _
              CreateTag(" Tipo de recurso relacionado: ", Item(i).ResourceType) & _
            CreateTag("Datas do recurso: ", Item(i).DateStr)

        Next
        Return Html
    End Function

    'Private Function UnitPrefix(ByVal ResourceType As String)
    '    Select Case ResourceType
    '        Case (VisualFieldLabel("Authorities.Bibliographic")) : Return "bib"
    '        Case (VisualFieldLabel("Authorities.Museologic")) : Return "mus"
    '        Case Else : Return ""
    '    End Select
    'End Function



End Class



Public Class EacResourceRelationshipsItem
    Private myID As Integer
    Private myType As String
    Private myUnit As String
    Private myDate As String
    Private myResourceType As String


    Public Sub New(ByVal Type As String, ByVal Unit As String, ByVal DateStr As String, ByVal ResourceType As String)
        myID = 0
        myType = Type
        myUnit = Unit
        myDate = DateStr
        myResourceType = ResourceType
    End Sub

    Public Sub New(ByVal ID As Integer, ByVal Type As String, ByVal Unit As String, ByVal DateStr As String, ByVal ResourceType As String)
        myID = ID
        myType = Type
        myUnit = Unit
        myDate = DateStr
        myResourceType = ResourceType
    End Sub


    Public Sub New(ByVal ID As Integer)
        myID = ID
    End Sub



    Public Overloads Overrides Function Equals(ByVal obj As Object) As Boolean
        If Not TypeOf obj Is EacResourceRelationshipsItem Then
            Return False
        Else
            Return ID = CType(obj, EacResourceRelationshipsItem).ID
        End If
    End Function

    Property ResourceType() As String
        Get
            Return myResourceType
        End Get
        Set(ByVal Value As String)
            myResourceType = Value
        End Set
    End Property


    Property Type() As String
        Get
            Return myType
        End Get
        Set(ByVal Value As String)
            myType = Value
        End Set
    End Property


    Property Unit() As String
        Get
            Return myUnit
        End Get
        Set(ByVal Value As String)
            myUnit = Value
        End Set
    End Property


    Property DateStr() As String
        Get
            Return myDate
        End Get
        Set(ByVal Value As String)
            myDate = Value
        End Set
    End Property


    Property ID() As Integer
        Get
            Return myID
        End Get
        Set(ByVal Value As Integer)
            myID = Value
        End Set
    End Property


    Public Function Clone() As Object
        Return New EacResourceRelationshipsItem(myID, myType, myUnit, myDate, myResourceType)
    End Function




End Class