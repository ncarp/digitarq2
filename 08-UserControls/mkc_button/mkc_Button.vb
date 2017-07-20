'=====================================================================================
'  mkc_Button
'  button control 
'=====================================================================================
'  Created By: Marc Cramer
'  Published Date: 3/9/2003
'  Legal Copyright: Marc Cramer © 3/9/2003
'=====================================================================================
'  Portions of code adapted from Flat Button Control as found on www.codeproject.com
'=====================================================================================
Imports System.ComponentModel

Namespace mkccontrols.windows.forms.control

	<System.ComponentModel.DefaultEvent("Click"), System.ComponentModel.DefaultProperty("ButtonText")> _
	Public Class mkc_Button
		Inherits System.Windows.Forms.UserControl

#Region " Variable Declaration "
		'=====================================================================================
		' VARIABLES
		'=====================================================================================
		Dim IDEBackgroundColor As System.Drawing.Color = CalculateIDEBackgroundColor()
		Dim FocusFlag As Boolean
		Dim NormalImage As System.Drawing.Image
		Dim RegularImage As System.Drawing.Image
        Dim FocusedImage As System.Drawing.Image
        Dim DisabledImage As System.Drawing.Image
		Dim BackgroundColorChangeFlag As Boolean = False
		Dim ButtonDownFlag As Boolean
		'=====================================================================================
		' PROPERT VARIABLES
		'=====================================================================================
		Dim m_TransparencyColor As System.Drawing.Color
		Dim m_ShowShadow As Boolean = True
		Dim m_BorderColor As Color = System.Drawing.Color.FromKnownColor(KnownColor.Highlight)
		Dim m_HighlightBackgroundColor As Color = IDEBackgroundColor
		'=====================================================================================

#End Region

#Region " Windows Form Designer generated code "
		'=====================================================================================
		' WINDOWS FORM DESIGNER GENERATED CODE
		'=====================================================================================
		Public Sub New()
			MyBase.New()

			'This call is required by the Windows Form Designer.
			InitializeComponent()

			'Add any initialization after the InitializeComponent() call
			NormalImage = lblButton.Image
			RegularImage = BuildRegularImage()
            FocusedImage = BuildFocusedImage()
            DisabledImage = BuildDisabledImage()
		End Sub		 'New()
		'=====================================================================================
		'UserControl1 overrides dispose to clean up the component list.
		Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If Not (components Is Nothing) Then
					components.Dispose()
				End If
				NormalImage.Dispose()
				RegularImage.Dispose()
				FocusedImage.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub		 'Dispose(ByVal disposing As Boolean)
		'=====================================================================================
		'Required by the Windows Form Designer
		Private components As System.ComponentModel.IContainer

		'NOTE: The following procedure is required by the Windows Form Designer
		'It can be modified using the Windows Form Designer.  
		'Do not modify it using the code editor.
		Friend WithEvents lblButton As System.Windows.Forms.Label
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(mkc_Button))
			Me.lblButton = New System.Windows.Forms.Label
			Me.SuspendLayout()
			'
			'lblButton
			'
			Me.lblButton.BackColor = System.Drawing.Color.Transparent
			Me.lblButton.Dock = System.Windows.Forms.DockStyle.Fill
			Me.lblButton.Image = CType(resources.GetObject("lblButton.Image"), System.Drawing.Bitmap)
			Me.lblButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter
			Me.lblButton.Name = "lblButton"
			Me.lblButton.Size = New System.Drawing.Size(56, 56)
			Me.lblButton.TabIndex = 0
			Me.lblButton.Text = "Click Me"
			Me.lblButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter
			'
			'mkc_Button
			'
			Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblButton})
			Me.Name = "mkc_Button"
			Me.Size = New System.Drawing.Size(56, 56)
			Me.ResumeLayout(False)

		End Sub		 'InitializeComponent()
		'=====================================================================================
#End Region

#Region " Events "
		'=====================================================================================
		' EVENTS
		'=====================================================================================
		Private Sub lblButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblButton.Click
			' handle the event and raise it up
			Me.OnClick(e)
		End Sub		 'lblButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblButton.Click
		'=====================================================================================
		Private Sub lblButton_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblButton.MouseEnter
			' handle the event and raise it up
			Me.OnMouseEnter(e)
			FocusFlag = True
			Me.Invalidate()
		End Sub		 'lblButton_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblButton.MouseEnter
		'=====================================================================================
		Private Sub lblButton_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblButton.MouseLeave
			' handle the event and raise it up
			Me.OnMouseLeave(e)
			FocusFlag = False
			Me.Invalidate()
		End Sub		 'lblButton_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblButton.MouseLeave
		'=====================================================================================
		Private Sub mkc_Button_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
			' handle the event 
            DrawHighlight(FocusFlag, e.Graphics, e.ClipRectangle())
			UpdateImage(FocusFlag)
		End Sub		 'mkc_Button_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
		'=====================================================================================
		Protected Overrides Function ProcessMnemonic(ByVal ChrCode As Char) As Boolean
			' process shortcut key
			Dim ChrPosition As Integer = lblButton.Text.IndexOf("&")
			Dim ChrToCheck As Char
			If ChrPosition > -1 And ChrPosition < lblButton.Text.Length Then
				ChrToCheck = lblButton.Text.Chars(ChrPosition + 1)
				If Char.ToLower(ChrToCheck) = Char.ToLower(ChrCode) Then
					lblButton_Click(Nothing, Nothing)
					Return True
				End If
			End If
			Return False
		End Function		 'ProcessMnemonic(ByVal ChrCode As Char) As Boolean
		'=====================================================================================
		Private Sub mkc_Button_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Enter
			' handle the event
			FocusFlag = True
			Me.Invalidate()
		End Sub		 'mkc_Button_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Enter
		'=====================================================================================
		Private Sub mkc_Button_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Leave
			' handle the event
			FocusFlag = False
			Me.Invalidate()
		End Sub		 'mkc_Button_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Leave
		'=====================================================================================
		Private Sub mkc_Button_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
			If e.KeyChar = Chr(13) Then lblButton_Click(Nothing, Nothing)
		End Sub		 'mkc_Button_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		'=====================================================================================
		Private Sub lblButton_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblButton.MouseDown
			Me.OnMouseDown(e)
			ButtonDownFlag = True
			Me.Invalidate()
		End Sub		 'lblButton_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblButton.MouseDown
		'=====================================================================================
		Private Sub lblButton_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblButton.MouseUp
			Me.OnMouseUp(e)
			ButtonDownFlag = False
			Me.Invalidate()
		End Sub		 'lblButton_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblButton.MouseUp
		'=====================================================================================
#End Region

#Region " Helper Routines "
		'=====================================================================================
		' HELPER ROUTINES
		'=====================================================================================
		Private Sub DrawHighlight(ByVal IsSelected As Boolean, ByVal ItemGraphics As Graphics, ByVal ItemRectangle As Rectangle)
			If IsSelected = False Then
				' draw with out the highlight rectangle
				Dim BackgroundBrush As New SolidBrush(Me.BackColor)
				ItemGraphics.FillRectangle(BackgroundBrush, ItemRectangle.Left, ItemRectangle.Top, ItemRectangle.Width, ItemRectangle.Height)
				backgroundbrush.Dispose()
			Else
				' draw with the highlight rectangle
				Dim BorderPen As New Pen(m_BorderColor)
				Dim BackgroundBrush As New SolidBrush(IDEBackgroundColor)
				If m_HighlightBackgroundColor.ToString <> IDEBackgroundColor.ToString Then BackgroundBrush.Color = m_HighlightBackgroundColor
				If ButtonDownFlag = True Then
					BackgroundBrush.Color = Me.BackColor
				End If
				ItemGraphics.FillRectangle(BackgroundBrush, ItemRectangle.Left, ItemRectangle.Top, ItemRectangle.Width, ItemRectangle.Height)
				ItemGraphics.DrawRectangle(BorderPen, ItemRectangle.Left, ItemRectangle.Top, ItemRectangle.Width - 1, ItemRectangle.Height - 1)
				BorderPen.Dispose()
				BackgroundBrush.Dispose()
			End If
		End Sub		 'DrawHighlight(ByVal IsSelected As Boolean, ByVal ItemGraphics As Graphics, ByVal ItemRectangle As Rectangle)
		'=====================================================================================
		Private Function CalculateIDEBackgroundColor() As System.Drawing.Color
			' create the background color
			Dim AlphaBlend As Integer = 70
			Dim BorderColor As System.Drawing.Color = System.Drawing.Color.FromArgb(255, m_BorderColor)
			Dim WindowColor As System.Drawing.Color			 '= System.Drawing.Color.FromArgb(255, Color.White)
			If BorderColor.ToArgb <> System.Drawing.Color.FromKnownColor(KnownColor.Highlight).ToArgb Then
				WindowColor = System.Drawing.Color.FromArgb(255, Color.White)
			Else
				WindowColor = System.Drawing.Color.FromArgb(255, System.Drawing.Color.FromKnownColor(KnownColor.Window))
			End If
			Dim RedValue As Byte = CByte(CSng(BorderColor.R * AlphaBlend / 255 + WindowColor.R * (CSng((255 - AlphaBlend) / 255))))
			Dim BlueValue As Byte = CByte(CSng(BorderColor.B * AlphaBlend / 255 + WindowColor.B * (CSng((255 - AlphaBlend) / 255))))
			Dim GreenValue As Byte = CByte(CSng(BorderColor.G * AlphaBlend / 255 + WindowColor.G * (CSng((255 - AlphaBlend) / 255))))

			CalculateIDEBackgroundColor = System.Drawing.Color.FromArgb(255, RedValue, GreenValue, BlueValue)
		End Function		 'CalculateIDEBackgroundColor() As System.Drawing.Color
		'=====================================================================================
        'Private Function BuildRegularImage() As System.Drawing.Image
        '	' creates a faded bright image 
        '	Dim X As Integer
        '	Dim Y As Integer
        '	Dim TempBitmap As New Bitmap(NormalImage)

        '	For X = 0 To TempBitmap.Width - 1
        '		For Y = 0 To TempBitmap.Height - 1
        '			Dim OldColor As Color = TempBitmap.GetPixel(X, Y)
        '			If Not OldColor.Equals(Color.FromArgb(0, 0, 0, 0)) Then
        '				Dim NewColor As Color = Color.FromArgb(76 - Int((OldColor.R + 32) / 64) * 19 + OldColor.R, 76 - Int((OldColor.G + 32) / 64) * 19 + OldColor.G, 76 - Int((OldColor.B + 32) / 64) * 19 + OldColor.B)
        '				TempBitmap.SetPixel(X, Y, NewColor)
        '				TempBitmap.MakeTransparent(m_TransparencyColor)
        '			End If
        '		Next
        '	Next


        '   Return TempBitmap
        'End Function		 'BuildRegularImage() As System.Drawing.Image

        Private Function BuildRegularImage() As System.Drawing.Image
            Return NormalImage
        End Function

        '=====================================================================================
        'Private Function BuildFocusedImage() As System.Drawing.Image
        '    ' creates a normal image with dropshadow
        '    Dim X As Integer
        '    Dim Y As Integer
        '    Dim TempBitmap As New Bitmap(NormalImage)
        '    Dim NewBitmap As New Bitmap(TempBitmap.Width + 2, TempBitmap.Height + 2)

        '    TempBitmap.MakeTransparent(m_TransparencyColor)
        '    For X = 0 To TempBitmap.Width - 1
        '        For Y = 0 To TempBitmap.Height - 1
        '            Dim OldColor As Color = TempBitmap.GetPixel(X, Y)
        '            If OldColor.Equals(Color.FromArgb(0, 0, 0, 0)) Then
        '                NewBitmap.SetPixel(X + 2, Y + 2, Color.Transparent)
        '            Else
        '                NewBitmap.SetPixel(X + 2, Y + 2, Color.Gray)
        '            End If
        '        Next
        '    Next

        '    Dim Graphics As Graphics = Graphics.FromImage(NewBitmap)
        '    Graphics.DrawImage(TempBitmap, 0, 0)

        '    Return NewBitmap
        'End Function   'BuildRegularImage() As System.Drawing.Image


        Private Function BuildFocusedImage() As System.Drawing.Image
            ' creates a normal image with dropshadow
            Dim X As Integer
            Dim Y As Integer
            Dim TempBitmap As New Bitmap(NormalImage)
            Dim NewBitmap As New Bitmap(TempBitmap.Width, TempBitmap.Height)
            Dim Bitmap As New Bitmap(TempBitmap.Width, TempBitmap.Height)

            For X = 0 To NewBitmap.Width - 1
                For Y = 0 To NewBitmap.Height - 1
                    Dim OldColor As Color = TempBitmap.GetPixel(X, Y)
                    Dim NewColor As Color = Color.FromArgb(Math.Max(0, OldColor.A * 0.6), OldColor.R, OldColor.G, OldColor.B)
                    NewBitmap.SetPixel(X, Y, NewColor)

                Next
            Next

            Dim Graphics As Graphics = Graphics.FromImage(TempBitmap)
            Graphics.DrawImage(NewBitmap, 0, 0)

            Return NewBitmap
        End Function   'BuildRegularImage() As System.Drawing.Image


        Private Function BuildDisabledImage() As System.Drawing.Image
            ' creates a normal image with dropshadow
            Dim X As Integer
            Dim Y As Integer
            Dim TempBitmap As New Bitmap(NormalImage)
            Dim NewBitmap As New Bitmap(TempBitmap.Width, TempBitmap.Height)
            Dim Bitmap As New Bitmap(TempBitmap.Width, TempBitmap.Height)

            For X = 0 To NewBitmap.Width - 1
                For Y = 0 To NewBitmap.Height - 1
                    Dim OldColor As Color = TempBitmap.GetPixel(X, Y)
                    Dim NewColor As Color = Color.FromArgb(Math.Max(0, OldColor.A * 0.3), OldColor.R, OldColor.G, OldColor.B)
                    NewBitmap.SetPixel(X, Y, NewColor)

                Next
            Next

            Dim Graphics As Graphics = Graphics.FromImage(TempBitmap)
            Graphics.DrawImage(NewBitmap, 0, 0)

            Return NewBitmap
        End Function   'BuildRegularImage() As System.Drawing.Image


        '=====================================================================================
        Private Function BuildTransparentImage() As System.Drawing.Image
            ' creates a transparent image
            Dim TempBitmap As New Bitmap(NormalImage)
            TempBitmap.MakeTransparent(m_TransparencyColor)
            Return TempBitmap
        End Function   'BuildTransparentImage() As System.Drawing.Image
        '=====================================================================================
        Private Sub UpdateImage(ByVal Focused As Boolean)
            ' update the image as needed
            If Me.Enabled Then
                If Focused = True Then
                    lblButton.Image = FocusedImage
                    'lblButton.Image = NormalImage
                Else
                    lblButton.Image = RegularImage
                    'lblButton.Image = NormalImage
                End If
            Else
                lblButton.Image = DisabledImage
            End If

        End Sub   'UpdateImage(ByVal Focused As Boolean)
        '=====================================================================================
        'Private Sub BuildImages()
        '     'build the images we need
        '    RegularImage = BuildRegularImage()
        '    If m_ShowShadow = True Then
        '        FocusedImage = BuildFocusedImage()
        '    Else
        '        FocusedImage = BuildTransparentImage()
        '    End If
        '    lblButton.Image = RegularImage
        'End Sub   'BuildImages()

        Private Sub BuildImages()
            'build the images we need
            RegularImage = BuildRegularImage()

            FocusedImage = BuildFocusedImage()

            DisabledImage = BuildDisabledImage()

            lblButton.Image = RegularImage
        End Sub   'BuildImages()


        '=====================================================================================
#End Region

#Region " Properties "
		'=====================================================================================
		' PROPERTIES
		'=====================================================================================
		<Description("Color of the button background displayed when mouse is over the button."), Category("Custom")> _
		Public Property HighlightBackgroundColor() As System.Drawing.Color
			Get
				Return m_HighlightBackgroundColor
			End Get
			Set(ByVal Value As System.Drawing.Color)
				m_HighlightBackgroundColor = Value
				BackgroundColorChangeFlag = True
			End Set
		End Property		 'HighlightBackgroundColor() As System.Drawing.Color
		'===========================================================================
		<Description("Color of the border displayed around control when mouse over it."), Category("Custom")> _
		  Public Property BorderColor() As System.Drawing.Color
			Get
				Return m_BorderColor
			End Get
			Set(ByVal Value As System.Drawing.Color)
				m_BorderColor = Value
				IDEBackgroundColor = CalculateIDEBackgroundColor()
				If BackgroundColorChangeFlag = False Then m_HighlightBackgroundColor = IDEBackgroundColor
			End Set
		End Property		 'BorderColor() As System.Drawing.Color
		'===========================================================================
		<Description("Gets and sets the button image."), Category("Custom")> _
		Public Property ButtonImage() As System.Drawing.Image
			Get
				Return NormalImage
			End Get
			Set(ByVal Value As System.Drawing.Image)
				NormalImage = Value
				BuildImages()
			End Set
		End Property		 'ButtonImage() As System.Drawing.Image
		'=====================================================================================
		<Description("Gets and sets the button text."), Category("Custom")> _
		Public Property ButtonText() As String
			Get
				Return lblButton.Text
			End Get
			Set(ByVal Value As String)
				lblButton.Text = Value
			End Set
		End Property		 'ButtonText() As String
		'=====================================================================================
		<Description("Gets and sets the button font."), Category("Custom")> _
		Public Property ButtonFont() As Font
			Get
				Return lblButton.Font
			End Get
			Set(ByVal Value As Font)
				lblButton.Font = Value
			End Set
		End Property		 'ButtonFont() As Font
		'=====================================================================================
		<Description("Gets and sets the button forecolor."), Category("Custom")> _
		Public Property ButtonForeColor() As Color
			Get
				Return lblButton.ForeColor
			End Get
			Set(ByVal Value As Color)
				lblButton.ForeColor = Value
			End Set
		End Property		 'ButtonForeColor() As Color
		'=====================================================================================
		<Description("Gets and sets the button image transparent color."), Category("Custom")> _
		Public Property ButtonTransparentColor() As Color
			Get
				Return m_TransparencyColor
			End Get
			Set(ByVal Value As Color)
				m_TransparencyColor = Value
				BuildImages()
			End Set
		End Property		 'ButtonTransparentColor() As Color
		'=====================================================================================
		<Description("Gets and sets if the focused button image should display a drop shadow."), Category("Custom")> _
		Public Property ButtonShowShadow() As Boolean
			Get
				Return m_ShowShadow
			End Get
			Set(ByVal Value As Boolean)
				m_ShowShadow = Value
				BuildImages()
			End Set
		End Property		 'ButtonShowShadow() As Boolean
		'=====================================================================================
		<Description("Gets and sets the text alignemnt for the button."), Category("Custom")> _
		Public Property ButtonTextAlignment() As System.Drawing.ContentAlignment
			Get
				Return lblButton.TextAlign
			End Get
			Set(ByVal Value As System.Drawing.ContentAlignment)
				lblButton.TextAlign = Value
			End Set
		End Property		 'ButtonTextAlignment() As System.Drawing.ContentAlignment
		'=====================================================================================
		<Description("Gets and sets the image alignemnt for the button."), Category("Custom")> _
		Public Property ButtonImageAlignment() As System.Drawing.ContentAlignment
			Get
				Return lblButton.ImageAlign
			End Get
			Set(ByVal Value As System.Drawing.ContentAlignment)
				lblButton.ImageAlign = Value
			End Set
		End Property		 'ButtonImageAlignment() As System.Drawing.ContentAlignment
		'=====================================================================================
#End Region

	End Class

End Namespace
