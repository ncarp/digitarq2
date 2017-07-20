'*************************************************************************************************
' class: EacIdentity
' Purpose: It Collects all items from the EacIdentity table (DigitArq database/ EAC Diagram)
'          This is related with, ISAAR(CPF), 5.1 Identity Area
' The Notation isn't used here.
'***************************************************************************************************
Public Class EacIdentity
    Inherits CollectionBase


    Public Function Add(ByVal Part As String, ByVal UseDate As String, ByVal Type As String) As Integer
        Return List.Add(New EacIdentityItem(Part, UseDate, Type))
    End Function


    Public Function Add(ByVal ID As Integer, ByVal Part As String, ByVal UseDate As String, ByVal Type As String) As Integer
        Return List.Add(New EacIdentityItem(ID, Part, UseDate, Type))
    End Function


    Public Sub Remove(ByVal Item As EacIdentityItem)
        List.Remove(Item)
    End Sub

    Public Function Item(ByVal index As Integer) As EacIdentityItem
        Return List.Item(index)
    End Function

    'Private Function TypeToEac(ByVal Type As String) As String
    '    Select Case Type
    '        Case VisualFieldLabel("Authorities.AlternativeName") : Return "alternative"
    '        Case VisualFieldLabel("Authorities.OtherFormName") : Return "otherform"
    '        Case Else : Return ""
    '    End Select
    'End Function

    '*************************************************************************************************
    ' Function: toHtml
    ' Purpose: For each Identity item will be return the the 5.1.3 ISAAR (CPF) if Item.Type="Nome paralelo"  
    '          or the 5.1.4 ISAAR (CPF) if Item.Type=" Outra forma de nome"  
    ' The Notation isn't used here.
    '***************************************************************************************************
    Public Function toHtml() As String
        If Count = 0 Then Return ""

        Dim Html As String = ""
        For i As Integer = 0 To Count - 1
            Html &= CreateTag(Item(i).Type, Item(i).Part & " <b>" & Item(i).UseDate & "</b>")
        Next
        Return Html
    End Function

End Class



Public Class EacIdentityItem
    Private myID As Integer
    Private myUseDate As String
    Private myPart As String
    Private myType As String


    Public Sub New(ByVal Part As String, ByVal UseDate As String, ByVal Type As String)
        myUseDate = UseDate
        myPart = Part
        myType = Type
        myID = 0
    End Sub

    Public Sub New(ByVal ID As Integer, ByVal Part As String, ByVal UseDate As String, ByVal Type As String)
        myUseDate = UseDate
        myPart = Part
        myType = Type
        myID = ID
    End Sub


    Public Sub New(ByVal ID As Integer)
        myID = ID
    End Sub

    Property Type() As String
        Get
            Return myType
        End Get
        Set(ByVal Value As String)
            myType = Value
        End Set
    End Property


    Property UseDate() As String
        Get
            Return myUseDate
        End Get
        Set(ByVal Value As String)
            myUseDate = Value
        End Set
    End Property

    Property Part() As String
        Get
            Return myPart
        End Get
        Set(ByVal Value As String)
            myPart = Value
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
        Return New EacIdentityItem(myID, myPart, myUseDate, myType)
    End Function


    Public Overloads Overrides Function Equals(ByVal obj As Object) As Boolean
        If Not TypeOf obj Is EacIdentityItem Then
            Return False
        Else
            Return ID = CType(obj, EacIdentityItem).ID
        End If
    End Function

End Class