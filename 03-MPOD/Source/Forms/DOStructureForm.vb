
#Region "License Agreement"

'* DigitArq
'* Copyright 2007-2015 
'* Arquivo Distrital do Porto
'* Todos os direitos reservados.
'*  
'* Este software foi desenvolvido pelo Arquivo
'* Distrital do Porto (http://www.adporto.pt)
'* em articulação com a Direcção-Geral de Arquivos
'* (http://www.dgarq.gov.pt) e com a coordenação
'* informática da Universidade do Minho
'* (http://www.uminho.pt).
'* O desenvolvimento deste produto foi parcialmente
'* financiado pelo Programa Operacional para a 
'* Cultura (POC) promovido pelo Governo Português.
'* ---------------------------------------------------
'*
'* A redistribuição e utilização deste produto sob a
'* forma de código-fonte ou programa compilado, com ou
'* sem modificações, é permitida desde que o seguinte
'* conjunto de condições seja cumprido:
'* 
'*	* Todas as redistribuições do código-fonte 
'*	  deste produto deverão ser acompanhadas do
'*	  texto que compõe esta licença, incluindo o 
'*	  texto inicial de atribuição de autoria,
'*	  esta lista de condições e do seguinte termo
'*	  de responsabilidade.
'*
'*	* Os nomes da Direcção-Geral de Arquivos,
'*	  do Arquivo Distrital do Porto, da 
'*	  Universidade do Minho e das pessoas 
'*	  individuais que colaboraram no desenvolvimento 
'*	  deste produto não deverão ser utilizados na 
'*	  promoção de produtos derivados deste 
'*	  sem que seja obtido consentimento prévio, por
'*	  escrito, por parte dos visados.

'*	* A utilização da designação DigitArq, seus 
'*	  logótipos e nomes institucionais associados
'*	  é apenas permitida em distribuições que sejam
'*	  cópias exactas da versão oficial deste produto
'*	  aprovada e/ou distribuída pela Direcção-Geral 
'*	  de Arquivos.

'*	* O desenvolvimento de obras derivadas deste
'*	  produto é permitido desde que a designação 
'*	  DigitArq, seus logotipos e parceiros 
'*	  institucionais não sejam utilizados em todo e
'*	  qualquer tipo de distribuição e/ou promoção 
'*	  da obra derivada.
'* 
'* ESTE SOFTWARE É DISTRIBUIDO PELA DIRECÇÃO-GERAL DE
'* ARQUIVOS "NO ESTADO EM QUE SE ENCONTRA" SEM QUALQUER
'* PRESUNÇÃO DE QUALIDADE OU GARANTIA ASSOCIADAS, 
'* INCLUINDO, MAS NÃO LIMITADO A, GARANTIAS ASSOCIADAS
'* A COMÉRCIO DE PRODUTOS OU DECLARAÇÃO DE ADEQUABILIDADE
'* A DETERMINADO FIM OU OBJECTIVO. 

'* EM NENHUMA CIRCUNSTÂNCIA PODERÁ A DIRECÇÃO-GERAL DE 
'* ARQUIVOS SER CONSIDERADA RESPONSÁVEL POR QUAISQUER 
'* DANOS QUE RESULTEM DA UTILIZAÇÃO DIRECTA, INDIRECTA,
'* ACIDENTAL, ESPECIAL OU DEMONSTRATIVA DESTE PRODUTO 
'* (INCLUINDO, MAS NÃO LIMITADO A, PERDAS DE DADOS, 
'* LUCROS, FALÊNCIA, INDEVIDA PRESTAÇÃO DE SERVIÇOS
'* OU NEGLIGÊNCIA), AINDA QUE O LICENCIANTE TENHA SIDO 
'* AVISADO DA POSSIBILIDADE DA OCORRÊNCIA DE TAIS DANOS.
'*
'* ---------------------------------------------------
'* Para mais informação sobre este produto ou a sua 
'* licença, é favor consultar o endereço electrónico
'* http://www.digitarq.pt

#End Region

Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml

Public Class DOStructureForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal intDOID As Int64, ByVal strDOName As String, ByVal consult As Boolean)
        MyBase.New()
        Me.myDigitalObjectID = intDOID
        Me.myDigitalObjectName = strDOName
        Me.bHasDO = consult '//used for the consultations (true:consult structure, false:change structure)

        'This call is required by the Windows Form Designer.
        InitializeComponent()
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
    'Friend WithEvents oTv As System.Windows.Forms.TreeView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents tvwDO As System.Windows.Forms.TreeView
    Friend WithEvents ImageListTVImages As System.Windows.Forms.ImageList
    Friend WithEvents pbImage As PictureBoxCtrl.PictureBox
    Friend WithEvents btnAdjust As mkccontrols.windows.forms.control.mkc_Button
    Friend WithEvents btnZoomOut As mkccontrols.windows.forms.control.mkc_Button
    Friend WithEvents btnZoomInOut As mkccontrols.windows.forms.control.mkc_Button
    Friend WithEvents btnZoomIn As mkccontrols.windows.forms.control.mkc_Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(DOStructureForm))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnAdjust = New mkccontrols.windows.forms.control.mkc_Button
        Me.btnZoomOut = New mkccontrols.windows.forms.control.mkc_Button
        Me.btnZoomInOut = New mkccontrols.windows.forms.control.mkc_Button
        Me.btnZoomIn = New mkccontrols.windows.forms.control.mkc_Button
        Me.pbImage = New PictureBoxCtrl.PictureBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.tvwDO = New System.Windows.Forms.TreeView
        Me.ImageListTVImages = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox3.Controls.Add(Me.btnAdjust)
        Me.GroupBox3.Controls.Add(Me.btnZoomOut)
        Me.GroupBox3.Controls.Add(Me.btnZoomInOut)
        Me.GroupBox3.Controls.Add(Me.btnZoomIn)
        Me.GroupBox3.Controls.Add(Me.pbImage)
        Me.GroupBox3.Location = New System.Drawing.Point(208, 16)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(632, 544)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Imagem"
        '
        'btnAdjust
        '
        Me.btnAdjust.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.btnAdjust.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdjust.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAdjust.ButtonImage = CType(resources.GetObject("btnAdjust.ButtonImage"), System.Drawing.Image)
        Me.btnAdjust.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAdjust.ButtonShowShadow = True
        Me.btnAdjust.ButtonText = ""
        Me.btnAdjust.ButtonTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAdjust.ButtonTransparentColor = System.Drawing.Color.WhiteSmoke
        Me.btnAdjust.HighlightBackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.btnAdjust.Location = New System.Drawing.Point(8, 14)
        Me.btnAdjust.Name = "btnAdjust"
        Me.btnAdjust.Size = New System.Drawing.Size(25, 25)
        Me.btnAdjust.TabIndex = 113
        '
        'btnZoomOut
        '
        Me.btnZoomOut.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnZoomOut.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.btnZoomOut.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnZoomOut.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.btnZoomOut.ButtonImage = CType(resources.GetObject("btnZoomOut.ButtonImage"), System.Drawing.Image)
        Me.btnZoomOut.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnZoomOut.ButtonShowShadow = True
        Me.btnZoomOut.ButtonText = ""
        Me.btnZoomOut.ButtonTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnZoomOut.ButtonTransparentColor = System.Drawing.Color.WhiteSmoke
        Me.btnZoomOut.HighlightBackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.btnZoomOut.Location = New System.Drawing.Point(568, 14)
        Me.btnZoomOut.Name = "btnZoomOut"
        Me.btnZoomOut.Size = New System.Drawing.Size(25, 25)
        Me.btnZoomOut.TabIndex = 112
        '
        'btnZoomInOut
        '
        Me.btnZoomInOut.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.btnZoomInOut.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnZoomInOut.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.btnZoomInOut.ButtonImage = CType(resources.GetObject("btnZoomInOut.ButtonImage"), System.Drawing.Image)
        Me.btnZoomInOut.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnZoomInOut.ButtonShowShadow = True
        Me.btnZoomInOut.ButtonText = ""
        Me.btnZoomInOut.ButtonTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnZoomInOut.ButtonTransparentColor = System.Drawing.Color.WhiteSmoke
        Me.btnZoomInOut.HighlightBackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.btnZoomInOut.Location = New System.Drawing.Point(40, 14)
        Me.btnZoomInOut.Name = "btnZoomInOut"
        Me.btnZoomInOut.Size = New System.Drawing.Size(25, 25)
        Me.btnZoomInOut.TabIndex = 111
        '
        'btnZoomIn
        '
        Me.btnZoomIn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnZoomIn.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.btnZoomIn.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnZoomIn.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.btnZoomIn.ButtonImage = CType(resources.GetObject("btnZoomIn.ButtonImage"), System.Drawing.Image)
        Me.btnZoomIn.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnZoomIn.ButtonShowShadow = True
        Me.btnZoomIn.ButtonText = ""
        Me.btnZoomIn.ButtonTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnZoomIn.ButtonTransparentColor = System.Drawing.Color.WhiteSmoke
        Me.btnZoomIn.HighlightBackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.btnZoomIn.Location = New System.Drawing.Point(599, 14)
        Me.btnZoomIn.Name = "btnZoomIn"
        Me.btnZoomIn.Size = New System.Drawing.Size(25, 25)
        Me.btnZoomIn.TabIndex = 110
        '
        'pbImage
        '
        Me.pbImage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbImage.BackColor = System.Drawing.Color.White
        Me.pbImage.Border = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbImage.Image = Nothing
        Me.pbImage.Location = New System.Drawing.Point(8, 40)
        Me.pbImage.Name = "pbImage"
        Me.pbImage.Size = New System.Drawing.Size(616, 496)
        Me.pbImage.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox2.Controls.Add(Me.tvwDO)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(192, 544)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Estrutura do objecto digital"
        '
        'tvwDO
        '
        Me.tvwDO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tvwDO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tvwDO.ImageList = Me.ImageListTVImages
        Me.tvwDO.Location = New System.Drawing.Point(8, 40)
        Me.tvwDO.Name = "tvwDO"
        Me.tvwDO.Size = New System.Drawing.Size(173, 496)
        Me.tvwDO.TabIndex = 0
        '
        'ImageListTVImages
        '
        Me.ImageListTVImages.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageListTVImages.ImageStream = CType(resources.GetObject("ImageListTVImages.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListTVImages.TransparentColor = System.Drawing.Color.Transparent
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.GroupBox3)
        Me.Panel3.Controls.Add(Me.GroupBox2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(856, 574)
        Me.Panel3.TabIndex = 12
        '
        'DOStructureForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(856, 574)
        Me.Controls.Add(Me.Panel3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DOStructureForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Estruturar Objecto Digital"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region "Private properties"

    Private database As New database
    Private myDOStructure As String

    Dim myDigitalObjectID As Int64
    Dim myDigitalObjectName As String
    Dim bHasDO As Boolean

    Private myImage As System.Drawing.Image

#End Region

#Region "Load"

    Private Sub DOStructureForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = GetFormTitle("[" & myDigitalObjectName & "]")
        LoadTreeDO()
        EnableDisableZoom(False)
    End Sub

#End Region

#Region "Methods and functions"

    Private Sub LoadTreeDO()
        Dim DOTv As New DOTreeView(Me.tvwDO, myDigitalObjectID)
        DOTv.LoadTreeDO()
        Me.tvwDO.Nodes(0).EnsureVisible()
    End Sub

    Private Sub tvwDO_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvwDO.AfterSelect
        Try
            e.Node.SelectedImageIndex = e.Node.ImageIndex
            If Not (e.Node Is Nothing) Then
                If Not e.Node.Text.ToLower.EndsWith("pdf") Then
                    myImage = database.getImage(e.Node.Text, myDigitalObjectID)
                    If Not myImage Is Nothing Then
                        EnableDisableZoom(True)
                        pbImage.PicBox.Size = ResizeImage(myImage.Size)
                        pbImage.PicBox.Image = myImage
                    Else
                        EnableDisableZoom(False)
                    End If
                End If
            End If
        Catch ex As Exception
            'MessageBoxes.MsgBoxException(ex)
        End Try
    End Sub

    Private Sub tvwDO_AfterCollapse(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvwDO.AfterCollapse
        e.Node.ImageIndex = 3
        e.Node.SelectedImageIndex = 3
    End Sub

    Private Sub tvwDO_AfterExpand(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvwDO.AfterExpand
        e.Node.ImageIndex = 0
        e.Node.SelectedImageIndex = 0
    End Sub

    Private Sub DOstructure_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub btnZoomInOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomInOut.Click
        Me.pbImage.PicBox.Size = myImage.Size
    End Sub

    Private Sub btnZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomIn.Click
        Me.pbImage.PicBox.Size = New Size(Me.pbImage.PicBox.Width * 1.2, Me.pbImage.PicBox.Height * 1.2)
    End Sub

    Private Sub btnZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomOut.Click
        Me.pbImage.PicBox.Size = New Size(Me.pbImage.PicBox.Width * 0.8, Me.pbImage.PicBox.Height * 0.8)
    End Sub

    Private Sub btnAdjust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjust.Click
        Me.pbImage.PicBox.Size = ResizeImage(myImage.Size)
    End Sub

    Private Sub EnableDisableZoom(ByVal blnEnable As Boolean)
        Me.btnZoomIn.Enabled = blnEnable
        Me.btnZoomInOut.Enabled = blnEnable
        Me.btnZoomOut.Enabled = blnEnable
        Me.btnAdjust.Enabled = blnEnable
    End Sub

    Private Function ResizeImage(ByVal Size As Size) As Size
        Dim OriginalImageHeight As Integer = Size.Height
        Dim OriginalImageWidth As Integer = Size.Width
        Size = New Size(OriginalImageWidth, OriginalImageHeight)

        If OriginalImageWidth > Me.pbImage.Width Then
            Dim Width1 As Integer = Me.pbImage.Width - 5
            Dim Height1 As Integer = OriginalImageHeight * Width1 / OriginalImageWidth
            Size = New Size(Width1, Height1)

            If Height1 > Me.pbImage.Height Then
                Dim Height2 As Integer = Me.pbImage.Height - 5
                Dim Width2 As Integer = Width1 * Height2 / Height1
                Size = New Size(Width2, Height2)
            End If
        End If

        Return Size
    End Function

#End Region

End Class
