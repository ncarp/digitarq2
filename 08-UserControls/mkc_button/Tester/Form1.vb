Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
	Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
	Friend WithEvents Mkc_Button1 As mkccontrols.windows.forms.control.mkc_Button
	Friend WithEvents Mkc_Button2 As mkccontrols.windows.forms.control.mkc_Button
	Friend WithEvents Mkc_Button3 As mkccontrols.windows.forms.control.mkc_Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Mkc_Button1 = New mkccontrols.windows.forms.control.mkc_Button
        Me.Mkc_Button2 = New mkccontrols.windows.forms.control.mkc_Button
        Me.Mkc_Button3 = New mkccontrols.windows.forms.control.mkc_Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(8, 72)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(296, 20)
        Me.TextBox1.TabIndex = 7
        Me.TextBox1.Text = "TextBox1"
        '
        'Mkc_Button1
        '
        Me.Mkc_Button1.BorderColor = System.Drawing.SystemColors.Highlight
        Me.Mkc_Button1.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mkc_Button1.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.Mkc_Button1.ButtonImage = CType(resources.GetObject("Mkc_Button1.ButtonImage"), System.Drawing.Image)
        Me.Mkc_Button1.ButtonImageAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.Mkc_Button1.ButtonShowShadow = True
        Me.Mkc_Button1.ButtonText = "Click Me"
        Me.Mkc_Button1.ButtonTextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.Mkc_Button1.ButtonTransparentColor = System.Drawing.Color.Magenta
        Me.Mkc_Button1.Enabled = False
        Me.Mkc_Button1.HighlightBackgroundColor = System.Drawing.Color.FromArgb(CType(200, Byte), CType(203, Byte), CType(209, Byte))
        Me.Mkc_Button1.Location = New System.Drawing.Point(8, 8)
        Me.Mkc_Button1.Name = "Mkc_Button1"
        Me.Mkc_Button1.Size = New System.Drawing.Size(56, 56)
        Me.Mkc_Button1.TabIndex = 9
        '
        'Mkc_Button2
        '
        Me.Mkc_Button2.BorderColor = System.Drawing.SystemColors.Control
        Me.Mkc_Button2.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mkc_Button2.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.Mkc_Button2.ButtonImage = CType(resources.GetObject("Mkc_Button2.ButtonImage"), System.Drawing.Image)
        Me.Mkc_Button2.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.Mkc_Button2.ButtonShowShadow = False
        Me.Mkc_Button2.ButtonText = ""
        Me.Mkc_Button2.ButtonTextAlignment = System.Drawing.ContentAlignment.BottomCenter
        Me.Mkc_Button2.ButtonTransparentColor = System.Drawing.Color.IndianRed
        Me.Mkc_Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Mkc_Button2.HighlightBackgroundColor = System.Drawing.SystemColors.Control
        Me.Mkc_Button2.Location = New System.Drawing.Point(80, 8)
        Me.Mkc_Button2.Name = "Mkc_Button2"
        Me.Mkc_Button2.Size = New System.Drawing.Size(56, 56)
        Me.Mkc_Button2.TabIndex = 10
        '
        'Mkc_Button3
        '
        Me.Mkc_Button3.BorderColor = System.Drawing.Color.FromArgb(CType(113, Byte), CType(111, Byte), CType(114, Byte))
        Me.Mkc_Button3.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mkc_Button3.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.Mkc_Button3.ButtonImage = CType(resources.GetObject("Mkc_Button3.ButtonImage"), System.Drawing.Image)
        Me.Mkc_Button3.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.Mkc_Button3.ButtonShowShadow = True
        Me.Mkc_Button3.ButtonText = "Click Me"
        Me.Mkc_Button3.ButtonTextAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.Mkc_Button3.ButtonTransparentColor = System.Drawing.Color.Magenta
        Me.Mkc_Button3.HighlightBackgroundColor = System.Drawing.Color.Teal
        Me.Mkc_Button3.Location = New System.Drawing.Point(152, 8)
        Me.Mkc_Button3.Name = "Mkc_Button3"
        Me.Mkc_Button3.Size = New System.Drawing.Size(96, 56)
        Me.Mkc_Button3.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.Location = New System.Drawing.Point(280, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 56)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Label1"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(464, 107)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Mkc_Button3)
        Me.Controls.Add(Me.Mkc_Button2)
        Me.Controls.Add(Me.Mkc_Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "Form1"
        Me.Text = "Tester"
        Me.ResumeLayout(False)

    End Sub

#End Region

	Private Sub Mkc_Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mkc_Button1.Click
		TextBox1.Text = "Mkc_Button1 Clicked - " & Now
	End Sub

	Private Sub Mkc_Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mkc_Button2.Click
		TextBox1.Text = "Mkc_Button2 Clicked - " & Now
	End Sub

	Private Sub Mkc_Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Mkc_Button3.Click
		TextBox1.Text = "Mkc_Button3 Clicked - " & Now
	End Sub

End Class
