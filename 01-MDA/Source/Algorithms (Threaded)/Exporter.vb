
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

Imports System.Threading
Imports System.IO
Imports System.Data.SqlClient

Public Class Exporter

    Private myServerAddress As String
    Private myDatabase As String
    Private myUsername As String
    Private myPassword As String
    Private myFilename As String
    Private myProcessInfoName As String = "admin"
    Private myProgressDialog As ProgressDialog
    Private myFondsID As Integer
    Private myOperationCancelled As Boolean = False


    Public Sub New(ByVal ServerAddress As String, ByVal Database As String, _
                   ByVal Username As String, ByVal Password As String, _
                   ByVal Filename As String, ByVal FondsID As Integer)
        myServerAddress = ServerAddress
        myDatabase = Database
        myUsername = Username
        myPassword = Password
        myFilename = Filename
        myFondsID = FondsID
    End Sub

    Public Sub New(ByVal ServerAddress As String, ByVal Database As String, _
                      ByVal Username As String, ByVal Password As String, _
                      ByVal FondsID As Integer, ByVal processInfoName As String)
        myServerAddress = ServerAddress
        myDatabase = Database
        myUsername = Username
        myPassword = Password
        myFondsID = FondsID
        myProcessInfoName = processInfoName
    End Sub



    Public Sub Export()
        Cursor.Current = Cursors.WaitCursor
        Dim startTime As Date = Date.Now
        myProgressDialog = New ProgressDialog(True)
        myProgressDialog.MinimumValue = 0
        myProgressDialog.MaximumValue = 10
        myProgressDialog.Text = String.Format(InfoMessage("Exporter.Title"), Path.GetFileName(myFilename))
        myProgressDialog.Show()

        Dim t As Thread = New Thread(New ThreadStart(AddressOf ExportFonds))
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



    Private Sub ExportFonds()
        Dim EADNode As LazyNode
        Dim SQLNode As LazyNode
        Try
            myProgressDialog.Message = ErrorMessage("ExportEAD.OpeningFile") & " " & Path.GetFileName(myFilename) & "..."
            EADNode = New EADLazyNode
            SQLNode = New SQLLazyNode(myServerAddress, myDatabase, myUsername, myPassword, myFondsID)

            EADNode.ImportFields(SQLNode)
            EADNode.Upload()
            MergeTrees(EADNode, SQLNode)

            If Not myOperationCancelled Then CType(EADNode, EADLazyNode).SaveXML(myFilename)
        Catch ex As Exception
            MsgBoxException(ex)
            'MsgBox(String.Format(ErrorMessage("ExportEAD.Cancelation"), Path.GetFileName(myFilename)), MsgBoxStyle.Critical)
            'Debug.WriteLine(ex.Message & ControlChars.NewLine & ex.StackTrace)
        End Try

    End Sub


    Public Sub PromoteToFonds()
        Cursor.Current = Cursors.WaitCursor
        Dim startTime As Date = Date.Now
        myProgressDialog = New ProgressDialog(True)
        myProgressDialog.MinimumValue = 0
        myProgressDialog.MaximumValue = 10
        myProgressDialog.Text = String.Format(InfoMessage("Exporter.Title"), Path.GetFileName(myFilename))
        myProgressDialog.Show()

        Dim t As Thread = New Thread(New ThreadStart(AddressOf PromoteToFondsThreaded))
        t.Start()

        While t.IsAlive
            System.Windows.Forms.Application.DoEvents()
        End While

        myProgressDialog.Hide()
        myProgressDialog.Close()
        myProgressDialog.Dispose()

        Dim finishTime As Date = Date.Now
        Dim timeSpan As TimeSpan = finishTime.Subtract(startTime)
        Debug.WriteLine(Path.GetFileName(myFilename) & ": " & timeSpan.Minutes.ToString.PadLeft(2, "0") & ":" & timeSpan.Seconds.ToString.PadLeft(2, "0") & " minutos")

        Cursor.Current = Cursors.Default
    End Sub


    Private Sub PromoteToFondsThreaded()
        Try
            myProgressDialog.Message = "A criar fundo..."

            Dim OldSQLNode As New SQLLazyNode(myServerAddress, myDatabase, myUsername, myPassword, myFondsID)
            Dim NewSQLNode As LazyNode = SQLLazyNode.CreateNewFonds(myServerAddress, _
                                                         myDatabase, myUsername, myPassword, OldSQLNode.UnitId, _
                                                         OldSQLNode.UnitTitle, myProcessInfoName)

            NewSQLNode.ImportFields(OldSQLNode)
            NewSQLNode.OtherLevel = OTHERLEVEL_FONDS
            NewSQLNode.Upload()
            MergeTrees(NewSQLNode, OldSQLNode, False)
        Catch ex As Exception
            MsgBoxException(ex)
            'MsgBox(String.Format(ErrorMessage("ExportEAD.Cancelation"), Path.GetFileName(myFilename)), MsgBoxStyle.Critical)
            'Debug.WriteLine(ex.Message & ControlChars.NewLine & ex.StackTrace)
        End Try

    End Sub


    Private Sub MergeTrees(ByVal DstNode As LazyNode, ByVal SrcNode As LazyNode, Optional ByVal FilterByVisibility As Boolean = True)
        Dim Index As Integer
        Dim ChildSrcNode As LazyNode
        Dim Children As LazyNodeCollection

        For Each ChildSrcNode In SrcNode.Children
            myProgressDialog.Message = String.Format(InfoMessage("Importer.Progression"), ChildSrcNode.UnitId)
            myProgressDialog.Increment()
            If myProgressDialog.Cancel Then
                myOperationCancelled = True
                Exit Sub
            End If

            If Not FilterByVisibility Or ChildSrcNode.Visible Then
                Children = DstNode.Children
                Dim NewDstNode As LazyNode = DstNode.CreateNode()
                NewDstNode.ImportFields(ChildSrcNode) ' Copy all the stuff into the node
                NewDstNode.Upload()
                DstNode.AppendChild(NewDstNode)
                MergeTrees(NewDstNode, ChildSrcNode, FilterByVisibility)
            End If
        Next

    End Sub

    Public ReadOnly Property OperationCancelled() As Boolean
        Get
            Return myOperationCancelled
        End Get
    End Property


End Class

