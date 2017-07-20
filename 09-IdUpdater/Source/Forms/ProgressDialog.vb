Public Class ProgressDialog
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Private Sub New()
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
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ProgressDialog))
        Me.ProgressBar = New System.Windows.Forms.ProgressBar
        Me.lblMessage = New System.Windows.Forms.Label
        Me.btnCancel = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(8, 48)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(296, 23)
        Me.ProgressBar.TabIndex = 0
        '
        'lblMessage
        '
        Me.lblMessage.Location = New System.Drawing.Point(8, 8)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(296, 32)
        Me.lblMessage.TabIndex = 2
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(120, 80)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        '
        'ProgressDialog
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(312, 111)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.ProgressBar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ProgressDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Progress"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private myWasCancelled As Boolean

    Public Sub New(ByVal AllowCancel As Boolean)
        Me.New()
        myWasCancelled = False
        MinimumValue = 0
        MaximumValue = 10
        TopMost = True
        If Not AllowCancel Then
            btnCancel.Visible = False
            Me.Height = 120
        End If

    End Sub

    Public Property Value() As Integer
        Get
            Return ProgressBar.Value
        End Get
        Set(ByVal Value As Integer)
            ProgressBar.Value = Value
            ProgressBar.Refresh()
        End Set
    End Property

    Public Property Message() As String
        Get
            Return lblMessage.Text
        End Get
        Set(ByVal Value As String)
            lblMessage.Text = Value
            lblMessage.Refresh()
        End Set
    End Property

    Public Property MinimumValue() As Integer
        Get
            Return ProgressBar.Minimum
        End Get
        Set(ByVal Value As Integer)
            ProgressBar.Minimum = Value
        End Set
    End Property


    Public Property MaximumValue() As Integer
        Get
            Return ProgressBar.Maximum
        End Get
        Set(ByVal Value As Integer)
            ProgressBar.Maximum = Value
        End Set
    End Property


    Public Sub Increment()
        If Value < MaximumValue Then
            Value += 1
        Else
            Value = 0
        End If
    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        myWasCancelled = True
    End Sub

    Public ReadOnly Property Cancel() As Boolean
        Get
            Return myWasCancelled
        End Get
    End Property



End Class
