Option Strict On
Option Explicit On 

Imports System.Drawing

Public Class CommonData

    Public imgWidth As Single
    Public imgHeight As Single
    Public legendWidth As Single
    Public valWidth As Single
    Public percentWidth As Single
    Public pieRect As Rectangle()
    Public pieWidth As Single
    'Arrays to hold pie data
    Public startAngle As Single()
    Public sweepAngle As Single()
    Public percentVal As Single()
    Public secColor As Color()

End Class