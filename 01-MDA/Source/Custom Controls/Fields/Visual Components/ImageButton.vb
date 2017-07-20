Imports System.Text.RegularExpressions
Imports System.ComponentModel

Public Class ColorButton
    Inherits Button

    Private WithEvents myColorButton As ColorButton
    'Public firstText, secondText As String
    'Public Shared configReader As System.Configuration.AppSettingsReader = _
    '        New System.Configuration.AppSettingsReader

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal Image As Image)
        myColorButton = New ColorButton
        Dim Item As ComboBoxImageItem

        With myColorButton
            .Size = New Size(20, 20)
            .FlatStyle = FlatStyle.Flat
            .Image = Image
        End With

        Me.Size = New Size(myColorButton.Width, myColorButton.Height)
        Me.Controls.Add(myColorButton)
    End Sub

    Private Sub ColorButton_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.TextChanged
        If Me.Text.Equals(configReader.GetValue("btnEdit.Text", GetType(System.String))) Then
            Me.BackColor = Color.White
            Me.ForeColor = Color.Black
        Else
            'Me.BackColor = Color.MistyRose
            'Me.ForeColor = Color.RosyBrown
            Me.BackColor = Color.FromArgb(255, 230, 255, 230)
            Me.ForeColor = Color.Black
        End If
    End Sub

    Public Sub setFirstText(ByVal firstText1 As String)
        Me.firstText = firstText1
        Me.Text = Me.firstText
    End Sub

    Public Sub setSecondText(ByVal secondText1 As String)
        Me.secondText = secondText1
    End Sub

End Class
