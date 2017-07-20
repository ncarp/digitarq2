
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

Imports System.Data.SqlClient ' SQL Server Data Provider
Imports System.Configuration
Imports System.Threading


Public Class DBCleaner
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ListView As System.Windows.Forms.ListView
    Friend WithEvents chOtherLevel As System.Windows.Forms.ColumnHeader
    Friend WithEvents chUnitId As System.Windows.Forms.ColumnHeader
    Friend WithEvents chUnitTitle As System.Windows.Forms.ColumnHeader
    Friend WithEvents chErrorDescription As System.Windows.Forms.ColumnHeader
    Friend WithEvents chID As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnProblemDetection As System.Windows.Forms.Button
    Friend WithEvents CompleteUnitID As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnAutoResolver As System.Windows.Forms.Button
    Friend WithEvents lblNbrProblems As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblNbrProblems = New System.Windows.Forms.Label
        Me.btnAutoResolver = New System.Windows.Forms.Button
        Me.btnProblemDetection = New System.Windows.Forms.Button
        Me.ListView = New System.Windows.Forms.ListView
        Me.chOtherLevel = New System.Windows.Forms.ColumnHeader
        Me.CompleteUnitID = New System.Windows.Forms.ColumnHeader
        Me.chUnitId = New System.Windows.Forms.ColumnHeader
        Me.chUnitTitle = New System.Windows.Forms.ColumnHeader
        Me.chErrorDescription = New System.Windows.Forms.ColumnHeader
        Me.chID = New System.Windows.Forms.ColumnHeader
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblNbrProblems)
        Me.Panel1.Controls.Add(Me.btnAutoResolver)
        Me.Panel1.Controls.Add(Me.btnProblemDetection)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(552, 104)
        Me.Panel1.TabIndex = 0
        '
        'lblNbrProblems
        '
        Me.lblNbrProblems.Location = New System.Drawing.Point(16, 80)
        Me.lblNbrProblems.Name = "lblNbrProblems"
        Me.lblNbrProblems.Size = New System.Drawing.Size(256, 16)
        Me.lblNbrProblems.TabIndex = 2
        '
        'btnAutoResolver
        '
        Me.btnAutoResolver.Enabled = False
        Me.btnAutoResolver.Location = New System.Drawing.Point(16, 48)
        Me.btnAutoResolver.Name = "btnAutoResolver"
        Me.btnAutoResolver.Size = New System.Drawing.Size(120, 23)
        Me.btnAutoResolver.TabIndex = 1
        Me.btnAutoResolver.Text = "2. Solve Problems"
        '
        'btnProblemDetection
        '
        Me.btnProblemDetection.Location = New System.Drawing.Point(16, 16)
        Me.btnProblemDetection.Name = "btnProblemDetection"
        Me.btnProblemDetection.Size = New System.Drawing.Size(120, 23)
        Me.btnProblemDetection.TabIndex = 0
        Me.btnProblemDetection.Text = "1. Detect Problems"
        '
        'ListView
        '
        Me.ListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chOtherLevel, Me.CompleteUnitID, Me.chUnitId, Me.chUnitTitle, Me.chErrorDescription, Me.chID})
        Me.ListView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListView.FullRowSelect = True
        Me.ListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView.Location = New System.Drawing.Point(0, 104)
        Me.ListView.MultiSelect = False
        Me.ListView.Name = "ListView"
        Me.ListView.Size = New System.Drawing.Size(552, 302)
        Me.ListView.TabIndex = 27
        Me.ListView.View = System.Windows.Forms.View.Details
        '
        'chOtherLevel
        '
        Me.chOtherLevel.Text = ""
        Me.chOtherLevel.Width = 20
        '
        'CompleteUnitID
        '
        Me.CompleteUnitID.Text = "Ref. Completa"
        Me.CompleteUnitID.Width = 85
        '
        'chUnitId
        '
        Me.chUnitId.Text = "Referência"
        Me.chUnitId.Width = 69
        '
        'chUnitTitle
        '
        Me.chUnitTitle.Text = "Título"
        Me.chUnitTitle.Width = 154
        '
        'chErrorDescription
        '
        Me.chErrorDescription.Text = CType(configurationAppSettings.GetValue("chErrorDescription.Text", GetType(System.String)), String)
        Me.chErrorDescription.Width = 278
        '
        'chID
        '
        Me.chID.Text = "ID"
        Me.chID.Width = 0
        '
        'DBCleaner
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(552, 406)
        Me.Controls.Add(Me.ListView)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "DBCleaner"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Digitarq DBCleaner"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Enum FieldName
        UnitDateInitial
        UnitDateFinal
        CountryCode
        RepositoryCode
    End Enum


    Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")
    Dim ServerAddress As String = SQLServerSettings.Item("ServerAddress")
    Dim Database As String = SQLServerSettings.Item("Database")
    Dim Username As String = SQLServerSettings.Item("Username")
    Dim Password As String = SQLServerSettings.Item("Password")

    Dim UnitDateInitialErrogenousRecords As Collection
    Dim UnitDateFinalErrogenousRecords As Collection
    Dim CountryCodeErrogenousRecords As Collection
    Dim RepositoryCodeErrogenousRecords As Collection
    Dim OrphanRecords As Collection

    Dim ErrorCounter As Integer

    Dim progress As ProgressDialog = New ProgressDialog(True)





    Private Sub btnProblemDetection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProblemDetection.Click

        progress = New ProgressDialog(True)
        progress.MaximumValue = 100
        progress.MinimumValue = 0
        progress.Text = "Detecting problems..."
        progress.Show()



        Dim t As New Thread(AddressOf ProblemDetection)
        t.Start()

    End Sub




    Sub ProblemDetection()
        Dim DataReader As SqlDataReader
        Dim SQLConnection As New SqlConnection
        Dim SQLCommand As New SqlCommand





        UnitDateInitialErrogenousRecords = New Collection
        UnitDateFinalErrogenousRecords = New Collection
        RepositoryCodeErrogenousRecords = New Collection
        CountryCodeErrogenousRecords = New Collection
        OrphanRecords = New Collection
        ErrorCounter = 0

        ListView.Items.Clear()
        btnProblemDetection.Enabled = False


        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", ServerAddress, Database, Username, Password)
        SQLCommand.Connection = SQLConnection

        Try
            SQLConnection.Open()
            SQLCommand.CommandText = "SELECT UnitDateInitial, UnitDateFinal, ID, UnitID, CompleteUnitID, UnitTitle, CountryCode, RepositoryCode, ParentID, OtherLevel, Valid FROM Components" ' WHERE  ((not (parentID is null)) or (parentID is null and otherlevel='F'))"
            DataReader = SQLCommand.ExecuteReader()
            Dim Cicles As Integer = 0

            While (DataReader.Read)

                'Dim ErrorDescription As String
                Dim UnitID As String = DBToStr(DataReader.Item("UnitID"))
                Dim CompleteUnitID As String = DBToStr(DataReader.Item("CompleteUnitID"))
                Dim UnitTitle As String = DBToStr(DataReader.Item("UnitTitle"))
                Dim ID As Integer = DBToInt(DataReader.Item("ID"))

                Dim UnitDateInitial As String = DBToStr(DataReader.Item("UnitDateInitial"))
                Dim UnitDateFinal As String = DBToStr(DataReader.Item("UnitDateFinal"))
                Dim CountryCode As String = DBToStr(DataReader.Item("CountryCode"))
                Dim RepositoryCode As String = DBToStr(DataReader.Item("RepositoryCode"))
                Dim ParentID As String = DBToStr(DataReader.Item("ParentID"))
                Dim OtherLevel As String = DBToStr(DataReader.Item("OtherLevel"))
                Dim Valid As Boolean = DBToBool(DataReader.Item("Valid"))

                Cicles += 1
                If (Cicles Mod 200) = 0 Then
                    progress.Value = (progress.Value + 1) Mod 100
                    progress.Message = "Processing " & CompleteUnitID & "..."
                End If

                If (progress.Cancel) Then Exit While


                If (Valid And Not Validator.IsValidDate(UnitDateInitial)) Then
                    UnitDateInitialErrogenousRecords.Add(ID)
                    AppendError(CompleteUnitID, UnitID, UnitTitle, ID, "Invalid initial date: " & UnitDateInitial)
                    ErrorCounter += 1
                    lblNbrProblems.Text = "Problems detected: " & ErrorCounter
                End If

                If (Valid And Not Validator.IsValidDate(UnitDateFinal)) Then
                    UnitDateFinalErrogenousRecords.Add(ID)
                    AppendError(CompleteUnitID, UnitID, UnitTitle, ID, "Invalid final date: " & UnitDateFinal)
                    ErrorCounter += 1
                    lblNbrProblems.Text = "Problems detected: " & ErrorCounter
                End If

                If (CountryCode <> "pt") Then
                    CountryCodeErrogenousRecords.Add(ID)
                    AppendError(CompleteUnitID, UnitID, UnitTitle, ID, "Wrong CountryCode: " & CountryCode)
                    ErrorCounter += 1
                    lblNbrProblems.Text = "Problems detected: " & ErrorCounter
                End If

                If (RepositoryCode <> "adprt") Then
                    RepositoryCodeErrogenousRecords.Add(ID)
                    AppendError(CompleteUnitID, UnitID, UnitTitle, ID, "Wrong RepositoryCode: " & RepositoryCode)
                    ErrorCounter += 1
                    lblNbrProblems.Text = "Problems detected: " & ErrorCounter
                End If


                If (ParentID = "" And OtherLevel <> "F") Then
                    OrphanRecords.Add(ID)
                    AppendError(CompleteUnitID, UnitID, UnitTitle, ID, "Orphan record")
                    ErrorCounter += 1
                    lblNbrProblems.Text = "Problems detected: " & ErrorCounter
                End If

            End While

        Catch ex As Exception
            MsgBoxException(ex)
        Finally
            SQLConnection.Close()
        End Try
        btnAutoResolver.Enabled = True
        btnProblemDetection.Enabled = True
        progress.Close()


        Dim msg As String = _
            "UnitDateInitial: " & Me.UnitDateInitialErrogenousRecords.Count & ControlChars.NewLine & _
            "UnitDateFinal: " & Me.UnitDateFinalErrogenousRecords.Count & ControlChars.NewLine & _
            "Orphans: " & Me.OrphanRecords.Count & ControlChars.NewLine & _
            "RepositoryCode: " & Me.RepositoryCodeErrogenousRecords.Count & ControlChars.NewLine & _
            "CountryCode: " & Me.CountryCodeErrogenousRecords.Count & ControlChars.NewLine

        MsgBox(msg)
    End Sub



    Private Sub btnAutoResolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutoResolver.Click
        progress = New ProgressDialog(True)
        progress.MaximumValue = 100
        progress.MinimumValue = 0
        progress.Text = "Solving problems..."
        progress.Show()


        Dim t As New Thread(AddressOf ProblemSolver)
        t.Start()

    End Sub



    Sub ProblemSolver()
        btnAutoResolver.Enabled = False
        btnProblemDetection.Enabled = False
        Dim Cicles As Integer = 0

        For Each ID As Integer In UnitDateInitialErrogenousRecords
            Dim FieldValue As String = GetField(ID, FieldName.UnitDateInitial)
            Dim NewFieldValue As String

            NewFieldValue = FixDateValue(FieldValue)
            UpdateField(ID, FieldName.UnitDateInitial, NewFieldValue)
            ErrorCounter -= 1
            lblNbrProblems.Text = "Problems detected: " & ErrorCounter



            Cicles += 1
            If (Cicles Mod 100) = 0 Then
                progress.Value = (progress.Value + 1) Mod 100
                progress.Message = "Processing " & ID & "..."
            End If

            If (progress.Cancel) Then Exit For

        Next

        For Each ID As Integer In UnitDateFinalErrogenousRecords
            Dim FieldValue As String = GetField(ID, FieldName.UnitDateFinal)
            Dim NewFieldValue As String

            NewFieldValue = FixDateValue(FieldValue)
            UpdateField(ID, FieldName.UnitDateFinal, NewFieldValue)

            ErrorCounter -= 1
            lblNbrProblems.Text = "Problems detected: " & ErrorCounter

            Cicles += 1
            If (Cicles Mod 100) = 0 Then
                progress.Value = (progress.Value + 1) Mod 100
                progress.Message = "Processing " & ID & "..."
            End If

            If (progress.Cancel) Then Exit For
        Next


        For Each ID As Integer In CountryCodeErrogenousRecords
            Dim FieldValue As String = GetField(ID, FieldName.CountryCode)
            Dim NewFieldValue As String = "pt"
            UpdateField(ID, FieldName.CountryCode, NewFieldValue)
            ErrorCounter -= 1
            lblNbrProblems.Text = "Problems detected: " & ErrorCounter

            Cicles += 1
            If (Cicles Mod 100) = 0 Then
                progress.Value = (progress.Value + 1) Mod 100
                progress.Message = "Processing " & ID & "..."
            End If

            If (progress.Cancel) Then Exit For
        Next

        For Each ID As Integer In RepositoryCodeErrogenousRecords
            Dim FieldValue As String = GetField(ID, FieldName.RepositoryCode)
            Dim NewFieldValue As String = "adprt"
            UpdateField(ID, FieldName.RepositoryCode, NewFieldValue)
            ErrorCounter -= 1
            lblNbrProblems.Text = "Problems detected: " & ErrorCounter

            Cicles += 1
            If (Cicles Mod 100) = 0 Then
                progress.Value = (progress.Value + 1) Mod 100
                progress.Message = "Processing " & ID & "..."
            End If

            If (progress.Cancel) Then Exit For
        Next

        For Each ID As Integer In OrphanRecords

            DeleteRecord(id)
            ErrorCounter -= 1
            lblNbrProblems.Text = "Problems detected: " & ErrorCounter

            Cicles += 1
            If (Cicles Mod 100) = 0 Then
                progress.Value = (progress.Value + 1) Mod 100
                progress.Message = "Processing " & ID & "..."
            End If

            If (progress.Cancel) Then Exit For
        Next

        progress.Close()
        MsgBox("Problem solving completed.")

        btnAutoResolver.Enabled = False
        btnProblemDetection.Enabled = True
    End Sub



    Function FixDateValue(ByVal FieldValue As String) As String
        Dim newFieldValue As String = ""
        If (Validator.Matches(FieldValue, "^\d\d\d\d$")) Then
            newFieldValue = FieldValue & "-00-00"
        ElseIf (Validator.Matches(FieldValue, "^\d\d\d\d-\d\d$")) Then
            newFieldValue = FieldValue & "-00"
        ElseIf (Validator.Matches(FieldValue, "^\d\d\d\d-\d\d-$")) Then
            newFieldValue = FieldValue & "00"
        ElseIf (Validator.Matches(FieldValue, "^\d\d\d\d-\d\d\.\d\d$")) Then
            newFieldValue = FieldValue.Replace(".", "-")
        ElseIf (Validator.Matches(FieldValue, "^\d\d\d\d\.\d\d-\d\d$")) Then
            newFieldValue = FieldValue.Replace(".", "-")
        ElseIf (Validator.Matches(FieldValue, "^\d\d\d\d-__-__$")) Then
            newFieldValue = FieldValue.Split("-")(0) & "-00-00"
        ElseIf (Validator.Matches(FieldValue, "^\[\d\d\d\d\]$")) Then
            newFieldValue = FieldValue.Replace("[", "").Replace("]", "") & "-00-00"
        ElseIf (Validator.Matches(FieldValue, "^c\. \d\d\d\d$")) Then
            newFieldValue = FieldValue.Replace("c", "").Replace(".", "").Replace(" ", "") & "-00-00"
        ElseIf (Validator.Matches(FieldValue, "^\d\d\d\d-\d\d-__$")) Then
            newFieldValue = FieldValue.Split("-")(0) & "-" & FieldValue.Split("-")(1) & "-00"
        ElseIf (Validator.Matches(FieldValue, "^---$")) Then
            newFieldValue = "0000-00-00"
        ElseIf FieldValue.Length = 0 Then
            newFieldValue = "0000-00-00"
        Else
            newFieldValue = FieldValue.Replace(" ", "")
        End If

        Return newFieldValue

    End Function

    Function GetField(ByVal ID As Integer, ByVal FieldName As FieldName) As String
        Dim DataReader As SqlDataReader
        Dim SQLConnection As New SqlConnection
        Dim SQLCommand As New SqlCommand
        Dim Field As String

        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", ServerAddress, Database, Username, Password)
        SQLCommand.Connection = SQLConnection

        Try
            SQLConnection.Open()
            SQLCommand.CommandText = String.Format("SELECT UnitDateInitial, UnitDateFinal FROM Components WHERE ID={0}", ID)
            DataReader = SQLCommand.ExecuteReader()
            While (DataReader.Read)
                Select Case FieldName
                    Case FieldName.UnitDateInitial
                        Field = DBToStr(DataReader.Item("UnitDateInitial"))
                    Case FieldName.UnitDateFinal
                        Field = DBToStr(DataReader.Item("UnitDateFinal"))
                End Select
            End While

        Catch ex As Exception
            MsgBoxException(ex)
        Finally
            SQLConnection.Close()
        End Try
        Return Field
    End Function

    Function UpdateField(ByVal ID As Integer, ByVal FieldName As FieldName, ByVal Value As String) As String
        'UPDATE COMPONENTS SET UnitDateInitial='1963-04-01' WHERE ID=409301;
        Dim DataReader As SqlDataReader
        Dim SQLConnection As New SqlConnection
        Dim SQLCommand As New SqlCommand
        Dim Field As String

        Select Case FieldName
            Case FieldName.UnitDateInitial
                Field = "UnitDateInitial"
            Case FieldName.UnitDateFinal
                Field = "UnitDateFinal"
            Case FieldName.CountryCode
                Field = "CountryCode"
            Case FieldName.RepositoryCode
                Field = "RepositoryCode"
        End Select

        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", ServerAddress, Database, Username, Password)
        SQLCommand.Connection = SQLConnection

        Try
            SQLConnection.Open()
            SQLCommand.CommandText = String.Format("UPDATE COMPONENTS SET {0}='{1}' WHERE ID={2}", Field, Value, ID)
            SQLCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBoxException(ex)
        Finally
            SQLConnection.Close()
        End Try
    End Function


    Sub DeleteRecord(ByVal ID As Integer)
        Dim DataReader As SqlDataReader
        Dim SQLConnection As New SqlConnection
        Dim SQLCommand As New SqlCommand

        SQLConnection.ConnectionString = String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", ServerAddress, Database, Username, Password)
        SQLCommand.Connection = SQLConnection

        Try
            SQLConnection.Open()
            SQLCommand.CommandText = String.Format("DELETE FROM COMPONENTS WHERE ID={0}", ID)
            SQLCommand.ExecuteNonQuery()
        Catch ex As Exception
            MsgBoxException(ex)
        Finally
            SQLConnection.Close()
        End Try
    End Sub



    Sub AppendError(ByVal CompleteUnitID As String, _
                    ByVal UnitID As String, _
                    ByVal UnitTitle As String, _
                    ByVal ID As Integer, _
                    ByVal ErrorDescription As String)

        Dim Row As New ListViewItem("")

        Dim lIcon As New ListViewItem.ListViewSubItem(Row, "")
        Dim lUnitId As New ListViewItem.ListViewSubItem(Row, UnitID)
        Dim lCompleteUnitId As New ListViewItem.ListViewSubItem(Row, CompleteUnitID)
        Dim lUnitTitle As New ListViewItem.ListViewSubItem(Row, UnitTitle)
        Dim lErrorDescription As New ListViewItem.ListViewSubItem(Row, ErrorDescription)
        Dim lID As New ListViewItem.ListViewSubItem(Row, ID)

        Row.SubItems.Add(lCompleteUnitId)
        Row.SubItems.Add(lUnitId)
        Row.SubItems.Add(lUnitTitle)
        Row.SubItems.Add(lErrorDescription)
        Row.SubItems.Add(lID)
        ListView.Items.Add(Row)
    End Sub




End Class
