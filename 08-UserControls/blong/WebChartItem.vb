Option Strict On
Option Explicit On 

Imports System
Imports System.Data
Imports System.Web.UI
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.ComponentModel.Design.Serialization
Imports System.Globalization
Imports Microsoft.VisualBasic

<Serializable(), TypeConverter(GetType(WebChartItem.WebChartConverter)), PersistenceMode(PersistenceMode.InnerDefaultProperty)> _
    Public Class WebChartItem

    ' Default Values
    Private Const dPrimaryValue As Single = 0.0
    Private Const dAltValue As Single = 0.0
    Private Const dChartExplode As Boolean = False
    Private Const dPieLabel As String = "Label"

    ' Chart data fields - All Charts
    Private mPrimaryValue As Single = dPrimaryValue
    Private mAltValue As Single = dAltValue
    Private mChartExplode As Boolean = dChartExplode
    Private mPieLabel As String = dPieLabel

    Sub New()
        MyBase.New()
    End Sub

    'Bar Chart Constructor
    Sub New(ByVal BarValueA As Single, ByVal BarValueB As Single)
        MyBase.New()
        mPrimaryValue = BarValueA
        mAltValue = BarValueB
    End Sub

    'Pie Chart Constructor
    Sub New(ByVal PieLabel As String, ByVal PieValue As Single, ByVal Explode As Boolean)
        MyBase.New()
        mPieLabel = PieLabel
        mPrimaryValue = PieValue
        mChartExplode = Explode
    End Sub

    Public Overloads Overrides Function toString() As String
        Return CType("Chart Item", String)
    End Function

    <DefaultValue(dPrimaryValue), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Public Property PrimaryValue() As Single
        Get
            Return mPrimaryValue
        End Get
        Set(ByVal Value As Single)
            mPrimaryValue = Value
        End Set
    End Property

    <DefaultValue(dAltValue), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
Public Property AlternateValue() As Single
        Get
            Return mAltValue
        End Get
        Set(ByVal Value As Single)
            mAltValue = Value
        End Set
    End Property

    <DefaultValue(dPieLabel), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Public Property PieLabel() As String
        Get
            Return mPieLabel
        End Get
        Set(ByVal Value As String)
            mPieLabel = Value
        End Set
    End Property

    <DefaultValue(dChartExplode), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Public Property Explode() As Boolean
        Get
            Return mChartExplode
        End Get
        Set(ByVal Value As Boolean)
            mChartExplode = Value
        End Set
    End Property

#Region " TypeConverter "

    Friend Class WebChartConverter : Inherits TypeConverter

        ' Method used to define if object can be converted 
        ' to specific type
        Public Overloads Overrides Function CanConvertTo( _
                ByVal context As ITypeDescriptorContext, _
                ByVal destType As Type) As Boolean
            If destType Is GetType(InstanceDescriptor) Then
                Return True
            End If
            Return MyBase.CanConvertTo(context, destType)
        End Function

        ' Method used to do the conversion
        Public Overloads Overrides Function ConvertTo( _
                ByVal context As ITypeDescriptorContext, _
                ByVal culture As CultureInfo, _
                ByVal value As Object, ByVal destType As Type) As Object
            ' We want to create an InstanceDescriptor
            If destType Is GetType(InstanceDescriptor) Then
                Dim mChart As WebChartItem = CType(value, WebChartItem)
                ' If we have defined different value to our
                ' instance that the default values then use 
                ' overloaded constructor
                If mChart.mPrimaryValue.CompareTo(mChart.dPrimaryValue) <> 0.0 Or _
                mChart.mAltValue.CompareTo(mChart.dAltValue) <> 0.0 Then
                    Return New InstanceDescriptor( _
                        GetType(WebChartItem).GetConstructor( _
                            New Type() {GetType(Single), GetType(Single)}), _
                            New Object() { _
                                          mChart.mPrimaryValue, _
                                          mChart.mAltValue _
                                          })
                Else
                    If mChart.mPieLabel <> mChart.dPieLabel Or _
                    mChart.mChartExplode <> mChart.dChartExplode Then
                        Return New InstanceDescriptor( _
                            GetType(WebChartItem).GetConstructor( _
                                New Type() {GetType(String), GetType(Single), GetType(Boolean)}), _
                                New Object() { _
                                              mChart.mPieLabel, _
                                              mChart.mPrimaryValue, _
                                              mChart.mChartExplode _
                                              })
                    Else
                        'default constructor with the default values
                        Return New InstanceDescriptor( _
                        GetType(WebChartItem).GetConstructor( _
                        New Type() {}), Nothing)
                    End If
                End If
            End If

            ' For all other conversions we will use 
            ' the base ConvertTo method.
            Return MyBase.ConvertTo(context, culture, _
                value, destType)
        End Function

    End Class

#End Region

End Class