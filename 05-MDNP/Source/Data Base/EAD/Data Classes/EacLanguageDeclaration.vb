
'*************************************************************************************************
' class: EacLanguageDeclaration
' Purpose: It Collects all items from the EacLanguageDeclaration table (DigitArq database/ EAC Diagram)
'          This is related with, ISAAR(CPF), 5.4.6  Language(s) and script(s) of record.
' The Notation isn't used here.
'***************************************************************************************************
Public Class EacLanguageDeclaration
    Inherits CollectionBase


    Public Function Add(ByVal Language As String) As Integer
        Return List.Add(New EacLanguageDeclarationItem(Language))
    End Function


    Public Function Add(ByVal ID As Integer, ByVal Language As String) As Integer
        Return List.Add(New EacLanguageDeclarationItem(ID, Language))
    End Function


    Public Sub Remove(ByVal Item As EacLanguageDeclarationItem)
        List.Remove(Item)
    End Sub

    Public Function Item(ByVal index As Integer) As EacLanguageDeclarationItem
        Return List.Item(index)
    End Function

    '*************************************************************************************************
    ' Function: toHtml
    ' Purpose: It shows in a html tag the EacLanguageDeclaration table (DigitArq database/ EAC Diagram)
    '          this is ISAAR(CPF)/ 5.4.6 - Language(s) and script(s) of record.
    ' The Notation isn't used here.
    '***************************************************************************************************

    Public Function toHtml() As String
        If Count = 0 Then Return ""

        Dim Html As String = ""
        For i As Integer = 0 To Count - 1
            Html &= CreateTag("Lingua(s) e escrita(s) do registo: ", Item(i).Language)
        Next

        Return Html
    End Function



End Class



Public Class EacLanguageDeclarationItem
    Private myID As Integer
    Private myLanguage As String


    Public Overloads Overrides Function Equals(ByVal obj As Object) As Boolean
        If Not TypeOf obj Is EacLanguageDeclarationItem Then
            Return False
        Else
            Return ID = CType(obj, EacLanguageDeclarationItem).ID
        End If
    End Function




    Public Sub New(ByVal Language As String)
        myID = 0
        myLanguage = Language
    End Sub

    Public Sub New(ByVal ID As Integer, ByVal Language As String)
        myID = ID
        myLanguage = Language
    End Sub

    Public Sub New(ByVal ID As Integer)
        myID = ID
    End Sub


    Property Language() As String
        Get
            Return myLanguage
        End Get
        Set(ByVal Value As String)
            myLanguage = Value
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
        Return New EacLanguageDeclarationItem(myID, myLanguage)
    End Function




End Class