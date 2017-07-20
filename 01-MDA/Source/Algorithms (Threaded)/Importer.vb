
#Region "License Agreement"

'* DigitArq
'* Copyright 2007-2015 
'* Arquivo Distrital do Porto
'* Todos os direitos reservados.
'*  
'* Este software foi desenvolvido pelo Arquivo
'* Distrital do Porto (http://www.adporto.pt)
'* em articula��o com a Direc��o-Geral de Arquivos
'* (http://www.dgarq.gov.pt) e com a coordena��o
'* inform�tica da Universidade do Minho
'* (http://www.uminho.pt).
'* O desenvolvimento deste produto foi parcialmente
'* financiado pelo Programa Operacional para a 
'* Cultura (POC) promovido pelo Governo Portugu�s.
'* ---------------------------------------------------
'*
'* A redistribui��o e utiliza��o deste produto sob a
'* forma de c�digo-fonte ou programa compilado, com ou
'* sem modifica��es, � permitida desde que o seguinte
'* conjunto de condi��es seja cumprido:
'* 
'*	* Todas as redistribui��es do c�digo-fonte 
'*	  deste produto dever�o ser acompanhadas do
'*	  texto que comp�e esta licen�a, incluindo o 
'*	  texto inicial de atribui��o de autoria,
'*	  esta lista de condi��es e do seguinte termo
'*	  de responsabilidade.
'*
'*	* Os nomes da Direc��o-Geral de Arquivos,
'*	  do Arquivo Distrital do Porto, da 
'*	  Universidade do Minho e das pessoas 
'*	  individuais que colaboraram no desenvolvimento 
'*	  deste produto n�o dever�o ser utilizados na 
'*	  promo��o de produtos derivados deste 
'*	  sem que seja obtido consentimento pr�vio, por
'*	  escrito, por parte dos visados.

'*	* A utiliza��o da designa��o DigitArq, seus 
'*	  log�tipos e nomes institucionais associados
'*	  � apenas permitida em distribui��es que sejam
'*	  c�pias exactas da vers�o oficial deste produto
'*	  aprovada e/ou distribu�da pela Direc��o-Geral 
'*	  de Arquivos.

'*	* O desenvolvimento de obras derivadas deste
'*	  produto � permitido desde que a designa��o 
'*	  DigitArq, seus logotipos e parceiros 
'*	  institucionais n�o sejam utilizados em todo e
'*	  qualquer tipo de distribui��o e/ou promo��o 
'*	  da obra derivada.
'* 
'* ESTE SOFTWARE � DISTRIBUIDO PELA DIREC��O-GERAL DE
'* ARQUIVOS "NO ESTADO EM QUE SE ENCONTRA" SEM QUALQUER
'* PRESUN��O DE QUALIDADE OU GARANTIA ASSOCIADAS, 
'* INCLUINDO, MAS N�O LIMITADO A, GARANTIAS ASSOCIADAS
'* A COM�RCIO DE PRODUTOS OU DECLARA��O DE ADEQUABILIDADE
'* A DETERMINADO FIM OU OBJECTIVO. 

'* EM NENHUMA CIRCUNST�NCIA PODER� A DIREC��O-GERAL DE 
'* ARQUIVOS SER CONSIDERADA RESPONS�VEL POR QUAISQUER 
'* DANOS QUE RESULTEM DA UTILIZA��O DIRECTA, INDIRECTA,
'* ACIDENTAL, ESPECIAL OU DEMONSTRATIVA DESTE PRODUTO 
'* (INCLUINDO, MAS N�O LIMITADO A, PERDAS DE DADOS, 
'* LUCROS, FAL�NCIA, INDEVIDA PRESTA��O DE SERVI�OS
'* OU NEGLIG�NCIA), AINDA QUE O LICENCIANTE TENHA SIDO 
'* AVISADO DA POSSIBILIDADE DA OCORR�NCIA DE TAIS DANOS.
'*
'* ---------------------------------------------------
'* Para mais informa��o sobre este produto ou a sua 
'* licen�a, � favor consultar o endere�o electr�nico
'* http://www.digitarq.pt

#End Region

Imports System.Threading
Imports System.IO
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text.RegularExpressions

Public Class Importer

    Private myServerAddress As String
    Private myDatabase As String
    Private myUsername As String
    Private myPassword As String
    Private myFilename As String
    Private myProgressDialog As ProgressDialog
    Private myProcessInfoName As String = "admin"
    Private mySourceFonds As LazyNode
    Private myDestinationFonds As LazyNode
    Private myImportType As ImportType
    Private myErrorCount As Integer

    Private Enum ImportType
        ExternalEAD
        TabSeparatedFile
        ExistingFonds
    End Enum


    Public ReadOnly Property ErrorCount()
        Get
            Return myErrorCount
        End Get
    End Property




    Public Sub New(ByVal ServerAddress As String, ByVal Database As String, _
                   ByVal Username As String, ByVal Password As String, _
                   ByVal Filename As String, ByVal ProcessInfoName As String)
        myServerAddress = ServerAddress
        myDatabase = Database
        myUsername = Username
        myPassword = Password
        myFilename = Filename
        myProcessInfoName = ProcessInfoName
        myImportType = ImportType.ExternalEAD
    End Sub



    Public Sub New(ByVal DestinationFonds As LazyNode, ByVal SourceFonds As LazyNode)
        myDestinationFonds = DestinationFonds
        mySourceFonds = SourceFonds
        myImportType = ImportType.ExistingFonds

    End Sub


    Public Sub New(ByVal DestinationFonds As LazyNode, ByVal Filename As String, ByVal ProcessInfoName As String)
        myDestinationFonds = DestinationFonds
        myFilename = Filename
        myProcessInfoName = ProcessInfoName
        myImportType = ImportType.TabSeparatedFile
    End Sub


    Public Sub Import()
        Select Case myImportType
            Case ImportType.ExistingFonds : ImportExistingFonds()
            Case ImportType.ExternalEAD : ImportExternalEAD()
            Case ImportType.TabSeparatedFile : ImportTabSeparatedFile()
        End Select
    End Sub


#Region "Import External EAD"

    Private Sub ImportExternalEAD()
        Cursor.Current = Cursors.WaitCursor
        Dim startTime As Date = Date.Now
        myProgressDialog = New ProgressDialog(True)
        myProgressDialog.MinimumValue = 0
        myProgressDialog.MaximumValue = 10
        myProgressDialog.Text = String.Format(InfoMessage("Importer.Title"), Path.GetFileName(myFilename))
        '"A importar " & Path.GetFileName(myFilename) & "..."
        myProgressDialog.Show()

        Dim t As Thread = New Thread(New ThreadStart(AddressOf ImportFonds))
        't.IsBackground = True
        t.Start()

        While t.IsAlive
            System.Windows.Forms.Application.DoEvents()
        End While

        'ImportFonds()

        myProgressDialog.Hide()
        myProgressDialog.Close()
        myProgressDialog.Dispose()

        Dim finishTime As Date = Date.Now
        Dim timeSpan As TimeSpan = finishTime.Subtract(startTime)
        Debug.WriteLine(Path.GetFileName(myFilename) & ": " & timeSpan.Minutes.ToString.PadLeft(2, "0") & ":" & timeSpan.Seconds.ToString.PadLeft(2, "0") & " minutos")

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub MergeTrees(ByVal DstNode As LazyNode, ByVal SrcNode As LazyNode)
        Dim Index As Integer
        Dim ChildSrcNode As LazyNode
        Dim Children As LazyNodeCollection

        Children = DstNode.Children
        For Each ChildSrcNode In SrcNode.Children
            Index = Children.IndexOf(ChildSrcNode)

            myProgressDialog.Message = String.Format(InfoMessage("Importer.Progression"), ChildSrcNode.UnitId)
            myProgressDialog.Increment()
            If myProgressDialog.Cancel Then Exit Sub

            If Index < 0 OrElse ChildSrcNode.isLeaf Then ' node doesn't existe. Create new one
                Dim NewDstNode As LazyNode = DstNode.CreateNode()
                ' Copy all the stuff into the node
                NewDstNode.ImportFields(ChildSrcNode)
                NewDstNode.ProcessInfoDate = DateToStr(Date.Now)
                NewDstNode.ProcessInfoName = myProcessInfoName
                If ChildSrcNode.OtherLevel = EADDefinitions.OTHERLEVEL_INSTALATIONUNIT _
                    AndAlso ChildSrcNode.ContainerType = "" Then
                    NewDstNode.ContainerType = VisualFieldLabel("ContainerType.Other")
                End If
                NewDstNode.Upload()
                DstNode.AppendChild(NewDstNode)
                MergeTrees(NewDstNode, ChildSrcNode)
            Else ' Node exists... use that one
                Dim NewDstNode As LazyNode = Children.Item(Index)
                MergeTrees(NewDstNode, ChildSrcNode)
            End If
        Next

    End Sub

    Private Sub ImportFonds()
        Dim EADNode As LazyNode
        Try
            myProgressDialog.Message = ErrorMessage("ImportEAD.OpeningFile") & " " & Path.GetFileName(myFilename) & "..."
            EADNode = New EADLazyNode(myFilename)

            Dim FondsList As FondsListCollection = SQLLazyNode.GetFondsList( _
                                                        myServerAddress, _
                                                        myDatabase, _
                                                        myUsername, _
                                                        myPassword _
                                                    )

            Dim ExistingFondsItem As FondsListItem
            Dim DummySearchItem As New FondsListItem(0, EADNode.UnitId, "", Nothing, Nothing, False)
            Dim Index As Integer = FondsList.IndexOf(DummySearchItem)

            If Index < 0 Then 'Fonds does not exists. Must create new fonds
                Dim SQLNode As SQLLazyNode = SQLLazyNode.CreateNewFonds( _
                                                            myServerAddress, _
                                                            myDatabase, _
                                                            myUsername, _
                                                            myPassword, _
                                                            EADNode.UnitId(), _
                                                            EADNode.UnitTitle(), _
                                                            myProcessInfoName _
                                                        )
                SQLNode.ImportFields(EADNode)
                SQLNode.ProcessInfoDate = DateToDB(Date.Now)
                SQLNode.ProcessInfoName = myProcessInfoName
                SQLNode.Upload()
                MergeTrees(SQLNode, EADNode)
                Log.Append(myProcessInfoName, Log.LogActions.ImportFonds, String.Format(LogMessage("Log.ImportedFonds"), EADNode.UnitId))
            Else
                ' The fonds already exists, get SQLNode and Merge
                ExistingFondsItem = FondsList.Item(Index)
                Dim SQLNode As SQLLazyNode = New SQLLazyNode( _
                                                        myServerAddress, _
                                                        myDatabase, _
                                                        myUsername, _
                                                        myPassword, _
                                                        ExistingFondsItem.ID _
                                                    )

                If MsgBox(String.Format(InfoMessage("ImportFonds.QuestionMergeFonds"), SQLNode.unitid), MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
                    MergeTrees(SQLNode, EADNode)
                    Log.Append(myProcessInfoName, Log.LogActions.ImportFonds, String.Format(LogMessage("Log.ImportedFonds"), EADNode.UnitId))
                End If
            End If
        Catch ex As SqlException
            Debug.WriteLine(ex.Message & ControlChars.NewLine & ex.StackTrace)
        Catch ex As Exception
            MsgBox(String.Format(ErrorMessage("ImportEAD.Cancelation"), Path.GetFileName(myFilename)), MsgBoxStyle.Critical)
            MsgBoxException(ex)
            'MsgBoxException(ex)
            'Debug.WriteLine(ex.Message & ControlChars.NewLine & ex.StackTrace)
        End Try

    End Sub

#End Region


#Region "Import Existing Fonds"

    Private Sub ImportExistingFonds()
        Cursor.Current = Cursors.WaitCursor
        Dim startTime As Date = Date.Now
        myProgressDialog = New ProgressDialog(True)
        myProgressDialog.MinimumValue = 0
        myProgressDialog.MaximumValue = 10
        myProgressDialog.Text = String.Format(InfoMessage("Importer.Title"), Path.GetFileName(myFilename))
        '"A importar " & Path.GetFileName(myFilename) & "..."
        myProgressDialog.Show()

        Dim t As Thread = New Thread(New ThreadStart(AddressOf MergeFonds))
        't.IsBackground = True
        t.Start()

        While t.IsAlive
            System.Windows.Forms.Application.DoEvents()
        End While

        'ImportFonds()

        myProgressDialog.Hide()
        myProgressDialog.Close()
        myProgressDialog.Dispose()

        Dim finishTime As Date = Date.Now
        Dim timeSpan As TimeSpan = finishTime.Subtract(startTime)

        Cursor.Current = Cursors.Default
    End Sub



    Private Sub MergeFonds()
        Try
            If myDestinationFonds Is Nothing OrElse mySourceFonds Is Nothing Then Exit Sub
            MergeTrees(myDestinationFonds, mySourceFonds)
        Catch ex As SqlException
            Debug.WriteLine(ex.Message & ControlChars.NewLine & ex.StackTrace)
        Catch ex As Exception
            MsgBox(String.Format(ErrorMessage("ImportEAD.Cancelation"), Path.GetFileName(myFilename)), MsgBoxStyle.Critical)
        End Try

    End Sub



#End Region


#Region "Import Tab Separated File"

    Private Sub ImportTabSeparatedFile()
        Cursor.Current = Cursors.WaitCursor

        myProgressDialog = New ProgressDialog(True)
        myProgressDialog.MinimumValue = 0
        myProgressDialog.MaximumValue = 10
        myProgressDialog.Text = String.Format(InfoMessage("Importer.Title"), Path.GetFileName(myFilename))
        myProgressDialog.Show()

        Dim t As Thread = New Thread(New ThreadStart(AddressOf ImportTabSeparatedFileIntoFonds))
        't.IsBackground = True
        t.Start()

        While t.IsAlive
            System.Windows.Forms.Application.DoEvents()
        End While

        'ImportFonds()

        myProgressDialog.Hide()
        myProgressDialog.Close()
        myProgressDialog.Dispose()


        Cursor.Current = Cursors.Default

    End Sub



    Private Sub ImportTabSeparatedFileIntoFonds()
        Dim TextFile As String = ReadTextFile(myFilename)
        Dim Lines As String() = TextFile.Split(ControlChars.NewLine)
        Dim HeaderFound As Boolean = False
        Dim Header As String()
        Dim Fields As String()
        myErrorCount = 0

        For Each Line As String In Lines
            If Not Regex.IsMatch(Line, "^\n?$") Then ' ignore empty lines
                Debug.WriteLine("Reading " & Line)
                If Not HeaderFound Then ' read header
                    Header = Line.Split(ControlChars.Tab)
                    HeaderFound = True
                Else ' read rest of file
                    myProgressDialog.Message = Line.Replace(ControlChars.Tab, " ")
                    myProgressDialog.Increment()
                    Try
                        Fields = Line.Split(ControlChars.Tab)
                        Dim NewSQLNode As LazyNode = myDestinationFonds.CreateNode()

                        For i As Integer = 0 To Fields.Length - 1
                            CallByName(NewSQLNode, Header(i).Trim, CallType.Set, Fields(i).Trim)
                            NewSQLNode.UpdateProcessInfo(myProcessInfoName)
                            NewSQLNode.Upload()
                        Next
                        myDestinationFonds.AppendChild(NewSQLNode)
                    Catch ex As Exception
                        myErrorCount += 1
                        'MsgBoxException(ex)
                    End Try
                End If
            Else
                Debug.WriteLine("[Empty Line]")
            End If
        Next
    End Sub

#End Region

End Class

