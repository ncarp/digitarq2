'***************************************************************************
' Class: objBlnSearch 
' Purpose: Object that gives all fields for Boolean search. Each field 
'           corresponds to the content of one textbox
'***************************************************************************

Public Class BlnSearchFields

    Private strAndField As String '** local variable that stores the text (words) from the and textbox field
    Private strExactPhraseField As String '** local variable that stores the phrase (expression) from the ExactPhrase textbox field
    Private strOrField As String '** local variable that stores the text (words) from the or textbox field
    Private strNotField As String '** local variable that stores the text (words) from the Not textbox field

    Public Sub New()
        strAndField = "" 'Group id 
        strExactPhraseField = ""
        strOrField = ""
        strNotField = ""
    End Sub

    Public Sub New(ByVal AndField As String, ByVal ExactPhraseField As String, ByVal OrField As String, ByVal NotField As String)
        strAndField = AndField 'Group id 
        strExactPhraseField = ExactPhraseField
        strOrField = OrField
        strNotField = NotField
    End Sub

    '***************************************************************************
    ' Function: blnIsEmpty
    ' Purpose: Purpose: This function returns a Boolean: true if is empty if not 
    '          false.
    '***************************************************************************
    Public Function IsEmpty() As Boolean
        If strAndField = "" And strExactPhraseField = "" And strOrField = "" And strNotField = "" Then
            Return True
        Else
            Return False
        End If
    End Function

    Property AndField() As String  'Property procedure
        Get
            Return strAndField
        End Get
        Set(ByVal Value As String)
            strAndField = Value
        End Set
    End Property

    Property ExactPhraseField() As String
        Get
            Return strExactPhraseField
        End Get
        Set(ByVal Value As String)
            strExactPhraseField = Value
        End Set
    End Property

    Property OrField() As String
        Get
            Return strOrField
        End Get
        Set(ByVal Value As String)
            strOrField = Value
        End Set
    End Property

    Property NotField() As String
        Get
            Return strNotField
        End Get
        Set(ByVal Value As String)
            strNotField = Value
        End Set
    End Property

End Class
