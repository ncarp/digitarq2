Option Strict On
Option Explicit On 

Imports System

<Serializable()> _
Public Class WebChartItemCollection : Inherits System.Collections.CollectionBase

    Private mOwner As WebChart

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Owner As WebChart)
        MyBase.New()
        mOwner = Owner
    End Sub

    Private Property Owner() As WebChart
        Get
            Return CType(mOwner, WebChart)
        End Get
        Set(ByVal Value As WebChart)
            mOwner = Value
        End Set
    End Property

    Default Public ReadOnly Property Item(ByVal index As Int32) As WebChartItem
        Get
            Return CType(List.Item(index), WebChartItem)
        End Get
    End Property

    Public Function Add(ByVal Item As WebChartItem) As Integer
        Return List.Add(Item)
    End Function

End Class
