Public Class GeneUpdateCompleteUnitId
    Inherits StopableGene

    Private myProgressDialog As ProgressDialog



    Public Sub New(ByVal ProgressDialog As ProgressDialog)
        myProgressDialog = ProgressDialog
    End Sub

    Public Sub New()
        myProgressDialog = Nothing
    End Sub



    Public Overrides Function Apply(ByVal obj As LazyNode, ByVal ChildrenResults As Microsoft.VisualBasic.Collection) As Object


        obj.CompleteUnitId = obj.CalculateCompleteUnitId
        obj.Upload()

        If Not myProgressDialog Is Nothing Then
            myProgressDialog.Message = String.Format("Processing {0}...", obj.CompleteUnitId)
            'myProgressDialog.Increment()
            Me.StopCatamorfism = myProgressDialog.Cancel
        End If

        Dim result As Integer = 1
        For Each Child As Integer In ChildrenResults
            result += Child
        Next
        Return result
    End Function


End Class