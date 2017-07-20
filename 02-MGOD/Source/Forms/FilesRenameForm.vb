
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

Imports System.IO

Public Class FilesRenameForm
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
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents bttnSeleccionar As System.Windows.Forms.Button
    Friend WithEvents bttnRemoverLstBx1 As System.Windows.Forms.Button
    Friend WithEvents bttnInserir As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents bttnCopiar As System.Windows.Forms.Button
    Friend WithEvents bttnRemoverLstBx2 As System.Windows.Forms.Button
    Friend WithEvents bttnRenomear As System.Windows.Forms.Button
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents pb As System.Windows.Forms.ProgressBar
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents bttnReplace As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FilesRenameForm))
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.pb = New System.Windows.Forms.ProgressBar
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.bttnReplace = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.bttnCopiar = New System.Windows.Forms.Button
        Me.bttnRemoverLstBx2 = New System.Windows.Forms.Button
        Me.bttnRenomear = New System.Windows.Forms.Button
        Me.ListBox2 = New System.Windows.Forms.ListBox
        Me.bttnSeleccionar = New System.Windows.Forms.Button
        Me.bttnRemoverLstBx1 = New System.Windows.Forms.Button
        Me.bttnInserir = New System.Windows.Forms.Button
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.ButtonCancel = New System.Windows.Forms.Button
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox2.Controls.Add(Me.pb)
        Me.GroupBox2.Controls.Add(Me.TextBox2)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.bttnReplace)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.bttnCopiar)
        Me.GroupBox2.Controls.Add(Me.bttnRemoverLstBx2)
        Me.GroupBox2.Controls.Add(Me.bttnRenomear)
        Me.GroupBox2.Controls.Add(Me.ListBox2)
        Me.GroupBox2.Controls.Add(Me.bttnSeleccionar)
        Me.GroupBox2.Controls.Add(Me.bttnRemoverLstBx1)
        Me.GroupBox2.Controls.Add(Me.bttnInserir)
        Me.GroupBox2.Controls.Add(Me.ListBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 21)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(780, 520)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        '
        'pb
        '
        Me.pb.Location = New System.Drawing.Point(286, 340)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(208, 22)
        Me.pb.TabIndex = 20
        '
        'TextBox2
        '
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Location = New System.Drawing.Point(286, 263)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(208, 20)
        Me.TextBox2.TabIndex = 6
        Me.TextBox2.Text = ""
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(339, 236)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 15)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "por"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'bttnReplace
        '
        Me.bttnReplace.BackColor = System.Drawing.Color.White
        Me.bttnReplace.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttnReplace.Location = New System.Drawing.Point(352, 298)
        Me.bttnReplace.Name = "bttnReplace"
        Me.bttnReplace.Size = New System.Drawing.Size(80, 23)
        Me.bttnReplace.TabIndex = 7
        Me.bttnReplace.Text = ">>"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(339, 187)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 17)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Substituir"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Location = New System.Drawing.Point(286, 215)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(208, 20)
        Me.TextBox1.TabIndex = 5
        Me.TextBox1.Text = ""
        '
        'bttnCopiar
        '
        Me.bttnCopiar.BackColor = System.Drawing.Color.White
        Me.bttnCopiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttnCopiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnCopiar.Location = New System.Drawing.Point(680, 21)
        Me.bttnCopiar.Name = "bttnCopiar"
        Me.bttnCopiar.Size = New System.Drawing.Size(90, 23)
        Me.bttnCopiar.TabIndex = 10
        Me.bttnCopiar.Text = "Copiar para..."
        '
        'bttnRemoverLstBx2
        '
        Me.bttnRemoverLstBx2.AccessibleDescription = ""
        Me.bttnRemoverLstBx2.BackColor = System.Drawing.Color.White
        Me.bttnRemoverLstBx2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttnRemoverLstBx2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnRemoverLstBx2.Location = New System.Drawing.Point(500, 21)
        Me.bttnRemoverLstBx2.Name = "bttnRemoverLstBx2"
        Me.bttnRemoverLstBx2.Size = New System.Drawing.Size(90, 23)
        Me.bttnRemoverLstBx2.TabIndex = 8
        Me.bttnRemoverLstBx2.Text = "Remover tudo"
        '
        'bttnRenomear
        '
        Me.bttnRenomear.BackColor = System.Drawing.Color.White
        Me.bttnRenomear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttnRenomear.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnRenomear.Location = New System.Drawing.Point(590, 21)
        Me.bttnRenomear.Name = "bttnRenomear"
        Me.bttnRenomear.Size = New System.Drawing.Size(90, 23)
        Me.bttnRenomear.TabIndex = 9
        Me.bttnRenomear.Text = "Renomear"
        '
        'ListBox2
        '
        Me.ListBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox2.Location = New System.Drawing.Point(500, 49)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(271, 444)
        Me.ListBox2.TabIndex = 11
        '
        'bttnSeleccionar
        '
        Me.bttnSeleccionar.BackColor = System.Drawing.Color.White
        Me.bttnSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttnSeleccionar.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnSeleccionar.Location = New System.Drawing.Point(187, 21)
        Me.bttnSeleccionar.Name = "bttnSeleccionar"
        Me.bttnSeleccionar.Size = New System.Drawing.Size(90, 23)
        Me.bttnSeleccionar.TabIndex = 3
        Me.bttnSeleccionar.Text = "Seleccionar tudo"
        '
        'bttnRemoverLstBx1
        '
        Me.bttnRemoverLstBx1.BackColor = System.Drawing.Color.White
        Me.bttnRemoverLstBx1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttnRemoverLstBx1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnRemoverLstBx1.Location = New System.Drawing.Point(97, 21)
        Me.bttnRemoverLstBx1.Name = "bttnRemoverLstBx1"
        Me.bttnRemoverLstBx1.Size = New System.Drawing.Size(90, 23)
        Me.bttnRemoverLstBx1.TabIndex = 2
        Me.bttnRemoverLstBx1.Text = "Remover tudo"
        '
        'bttnInserir
        '
        Me.bttnInserir.BackColor = System.Drawing.Color.White
        Me.bttnInserir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttnInserir.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnInserir.Location = New System.Drawing.Point(7, 21)
        Me.bttnInserir.Name = "bttnInserir"
        Me.bttnInserir.Size = New System.Drawing.Size(90, 23)
        Me.bttnInserir.TabIndex = 1
        Me.bttnInserir.Text = "Inserir..."
        '
        'ListBox1
        '
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox1.Location = New System.Drawing.Point(7, 49)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.ListBox1.Size = New System.Drawing.Size(270, 444)
        Me.ListBox1.Sorted = True
        Me.ListBox1.TabIndex = 4
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox3.Controls.Add(Me.ButtonCancel)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 541)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(780, 41)
        Me.GroupBox3.TabIndex = 17
        Me.GroupBox3.TabStop = False
        '
        'ButtonCancel
        '
        Me.ButtonCancel.BackColor = System.Drawing.Color.White
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCancel.Location = New System.Drawing.Point(701, 11)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(70, 20)
        Me.ButtonCancel.TabIndex = 12
        Me.ButtonCancel.Text = "Sair"
        '
        'FilesRenameForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(793, 596)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FilesRenameForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Renomeação de ficheiros"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Dim filenames As String()
    Dim hash As New Hashtable
    Dim directoryName As String
    Dim file As file

    Private Sub bttnInserir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnInserir.Click
        Dim i As Integer
        Dim directory As Directory

        Dim openFileDialog As New OpenFileDialog
        openFileDialog.Multiselect = True
        openFileDialog.Title = "Abrir..."
        openFileDialog.InitialDirectory = "C:\"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            filenames = openFileDialog.FileNames

            directoryName = Path.GetDirectoryName(filenames(0))
            For i = 0 To filenames.Length - 1
                Dim FileName As String = Path.GetFileName(filenames(i))
                Me.ListBox1.Items.Add(FileName)
            Next
            Me.TextBox1.Text = Path.GetFileNameWithoutExtension(filenames(filenames.Length - 1))
            hash.Clear()
        End If
    End Sub

    Private Sub bttnRemoverLstBx1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnRemoverLstBx1.Click
        Me.ListBox1.Items.Clear()
    End Sub

    Private Sub bttnReplace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnReplace.Click
        Dim filenames As System.Windows.Forms.ListBox.SelectedObjectCollection
        filenames = Me.ListBox1.SelectedItems

        Dim i As Integer = 0
        'hash.Clear()
        Dim num As Integer = hash.Count
        If filenames.Count = 0 Then
            MsgBox("Não está nenhum Item seleccionado.", MsgBoxStyle.Exclamation, "Renomeação de ficheiros")
            Return
        End If
        If Me.TextBox1.Text = "" Then
            MsgBox("Campo ""Substituir"" vazio.", MsgBoxStyle.Exclamation, "Renomeação de ficheiros")
            Return
        End If
        Dim numFiles As Integer = filenames.Count
        Try
            For i = 0 To numFiles - 1
                Dim oldFileName As String = filenames(i)
                Dim newFileName As String = oldFileName.Replace(Me.TextBox1.Text, Me.TextBox2.Text)
                Me.ListBox2.Items.Add(newFileName)
                Me.hash.Add(newFileName, oldFileName)
            Next
            For i = numFiles - 1 To i = 0 Step -1
                Me.ListBox1.Items.Remove(filenames(i))
            Next
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Renomeação de ficheiros")
            Me.TextBox1.Clear()
            Me.TextBox2.Clear()
            Me.ListBox2.Items.Clear()
        End Try
    End Sub

    Private Sub bttnRemoverLstBx2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnRemoverLstBx2.Click
        Me.ListBox2.Items.Clear()
    End Sub

    Private Sub bttnRenomear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnRenomear.Click
        Dim filenames As System.Windows.Forms.ListBox.ObjectCollection
        filenames = Me.ListBox2.Items
        Dim i As Integer = 0
        Dim numFiles As Integer = filenames.Count
        pb.Value = 0
        pb.Minimum = 0
        pb.Maximum = numFiles

        For i = 0 To numFiles - 1
            Dim strFileName As String = filenames(i)
            Dim oldFileName As String = Me.hash(strFileName)
            pb.Increment(1)

            file.Move(directoryName + "\" + oldFileName, directoryName + "\" + strFileName)
        Next
        MsgBox("Renomeação bem sucedida.", MsgBoxStyle.Information)
        Me.ListBox1.Items.Clear()
        Me.ListBox2.Items.Clear()
        Me.TextBox1.Clear()
        Me.TextBox2.Clear()
        Me.pb.Value = 0
    End Sub

    Private Sub bttnSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnSeleccionar.Click
        Dim i As Integer
        For i = 0 To Me.ListBox1.Items.Count - 1
            Me.ListBox1.SetSelected(i, True)
        Next
    End Sub

    Private Sub bttnCopiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnCopiar.Click
        Me.FolderBrowserDialog1.ShowDialog()
        pb.Value = 0

        Dim filenames As System.Windows.Forms.ListBox.ObjectCollection
        filenames = Me.ListBox2.Items
        Dim newDirectory As String = Me.FolderBrowserDialog1.SelectedPath.ToString
        Dim i As Integer = 0
        Dim numFiles As Integer = filenames.Count
        pb.Minimum = 0
        pb.Maximum = numFiles

        For i = 0 To numFiles - 1
            pb.Increment(1)
            Dim strFileName As String = filenames(i)
            Dim oldFileName As String = Me.hash(strFileName)
            file.Copy(directoryName + "\" + oldFileName, newDirectory + "\" + strFileName, True)
        Next
        MsgBox("Cópia e renomeação bem sucedida.", MsgBoxStyle.Information, "Renomeação de ficheiros")
        Me.ListBox1.Items.Clear()
        Me.ListBox2.Items.Clear()
        Me.TextBox1.Clear()
        Me.TextBox2.Clear()
        Me.pb.Value = 0
    End Sub

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        Close()
    End Sub

End Class
