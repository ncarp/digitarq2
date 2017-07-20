
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

Imports System.Text.RegularExpressions
Imports System.Threading

Public Class Iterator


#Region "Properties"

    Private myProgressDialog As ProgressDialog
    Private myRootLazyNode As LazyNode
    Private myResult As Object
    Private myArgument As Object

    Public Enum Action
        MakeVisible
        MakeInvisible
        MakeValid
        MakeInvalid
        MakeAvailable
        MakeUnavailable

        CollectFondsGuideData
        CollectInventoryData
        CollectUIInventoryData
        CollectCatalogData
        CollectSeriesListData
        CollectInstalationUnitsListData
        CollectInstalationUnitsBySeriesListData
        CollectClassificationPlanData
        CollectAuthorsListData

        UpdateCompleteUnitId
        CountNodesByOtherLevel

        SearchReplace
        Search
    End Enum


    Public ReadOnly Property Result()
        Get
            Return myResult
        End Get
    End Property

    Public WriteOnly Property Argument() As Object
        Set(ByVal Value As Object)
            myArgument = Value
        End Set
    End Property

#End Region


#Region "Contructors"


    Public Sub New(ByVal RootLazyNode As LazyNode)
        myRootLazyNode = RootLazyNode
    End Sub


#End Region




    Public Function Start(ByVal Action As Action) As Object
        Cursor.Current = Cursors.WaitCursor


        myProgressDialog = New ProgressDialog(True)

        myProgressDialog.MinimumValue = 0
        myProgressDialog.MaximumValue = 10
        myProgressDialog.TopMost = True
        myProgressDialog.Show()

        Dim thread As Thread
        Select Case Action
            Case Action.MakeInvalid : thread = New Thread(New ThreadStart(AddressOf MakeInvalid))
            Case Action.MakeValid : thread = New Thread(New ThreadStart(AddressOf MakeValid))
            Case Action.MakeVisible : thread = New Thread(New ThreadStart(AddressOf MakeVisible))
            Case Action.MakeInvisible : thread = New Thread(New ThreadStart(AddressOf MakeInvisible))
            Case Action.MakeAvailable : thread = New Thread(New ThreadStart(AddressOf MakeAvailable))
            Case Action.MakeUnavailable : thread = New Thread(New ThreadStart(AddressOf MakeUnavailable))
            Case Action.CollectFondsGuideData : thread = New Thread(New ThreadStart(AddressOf CollectFondsGuideData))
            Case Action.CollectInventoryData : thread = New Thread(New ThreadStart(AddressOf CollectInventoryData))
            Case Action.CollectUIInventoryData : thread = New Thread(New ThreadStart(AddressOf CollectUIInventoryData))
            Case Action.CollectCatalogData : thread = New Thread(New ThreadStart(AddressOf CollectCatalogData))
            Case Action.CollectSeriesListData : thread = New Thread(New ThreadStart(AddressOf CollectSeriesListData))
            Case Action.CollectInstalationUnitsListData : thread = New Thread(New ThreadStart(AddressOf CollectInstalationUnitsListData))
            Case Action.CollectInstalationUnitsBySeriesListData : thread = New Thread(New ThreadStart(AddressOf CollectInstalationUnitsBySeriesListData))
            Case Action.CollectClassificationPlanData : thread = New Thread(New ThreadStart(AddressOf CollectClassificationPlanData))
            Case Action.CollectAuthorsListData : thread = New Thread(New ThreadStart(AddressOf CollectAuthorsListData))
            Case Action.UpdateCompleteUnitId : thread = New Thread(New ThreadStart(AddressOf UpdateCompleteUnitId))
            Case Action.CountNodesByOtherLevel : thread = New Thread(New ThreadStart(AddressOf CountNodesByOtherLevel))
            Case Action.SearchReplace : thread = New Thread(New ThreadStart(AddressOf SearchReplace))
            Case Action.Search : thread = New Thread(New ThreadStart(AddressOf Search))
            Case Else : Exit Function
        End Select

        thread.Start()

        While thread.IsAlive
            System.Windows.Forms.Application.DoEvents()
        End While

        myProgressDialog.Hide()
        myProgressDialog.Close()
        myProgressDialog.Dispose()

        Cursor.Current = Cursors.Default
        Return Result
    End Function




#Region "Action code"
    Private Sub MakeVisible()
        myProgressDialog.Text = String.Format(InfoMessage("ChangeVisibility.Title"), myRootLazyNode.UnitTitle)
        Cursor.Current = Cursors.WaitCursor
        myRootLazyNode.StopableCatamorphism(New GeneChangeVisiblility(True, myProgressDialog))
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub MakeInvisible()
        myProgressDialog.Text = String.Format(InfoMessage("ChangeVisibility.Title"), myRootLazyNode.UnitTitle)
        Cursor.Current = Cursors.WaitCursor
        myRootLazyNode.StopableCatamorphism(New GeneChangeVisiblility(False, myProgressDialog))
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub MakeValid()
        Cursor.Current = Cursors.WaitCursor
        myProgressDialog.Text = String.Format(InfoMessage("ChangeValidation.Title"), myRootLazyNode.UnitTitle)
        myRootLazyNode.StopableCatamorphism(New GeneChangeValidation(True, myProgressDialog))
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub MakeInvalid()
        myProgressDialog.Text = String.Format(InfoMessage("ChangeValidation.Title"), myRootLazyNode.UnitTitle)
        Cursor.Current = Cursors.WaitCursor
        myRootLazyNode.StopableCatamorphism(New GeneChangeValidation(False, myProgressDialog))
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub MakeAvailable()
        Cursor.Current = Cursors.WaitCursor
        myProgressDialog.Text = String.Format(InfoMessage("ChangeAvailability.Title"), myRootLazyNode.UnitTitle)
        myRootLazyNode.StopableCatamorphism(New GeneChangeAvailability(True, myProgressDialog))
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub MakeUnavailable()
        myProgressDialog.Text = String.Format(InfoMessage("ChangeAvailability.Title"), myRootLazyNode.UnitTitle)
        Cursor.Current = Cursors.WaitCursor
        myRootLazyNode.StopableCatamorphism(New GeneChangeAvailability(False, myProgressDialog))
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub CollectFondsGuideData()
        myProgressDialog.Text = String.Format(InfoMessage("CollectingData.ProgressBar.Title"), myRootLazyNode.UnitTitle)
        Cursor.Current = Cursors.WaitCursor
        myResult = myRootLazyNode.StopableCatamorphism(New GeneFondsGuide(myProgressDialog))
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub CollectInventoryData()
        myProgressDialog.Text = String.Format(InfoMessage("CollectingData.ProgressBar.Title"), myRootLazyNode.UnitTitle)
        Cursor.Current = Cursors.WaitCursor
        myResult = myRootLazyNode.StopableCatamorphism(New GeneInventory(myProgressDialog))
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub CollectUIInventoryData()
        myProgressDialog.Text = String.Format(InfoMessage("CollectingData.ProgressBar.Title"), myRootLazyNode.UnitTitle)
        Cursor.Current = Cursors.WaitCursor
        myResult = myRootLazyNode.StopableCatamorphism(New GeneUIInventory(myProgressDialog))
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub CollectCatalogData()
        myProgressDialog.Text = String.Format(InfoMessage("CollectingData.ProgressBar.Title"), myRootLazyNode.UnitTitle)
        Cursor.Current = Cursors.WaitCursor
        myResult = myRootLazyNode.StopableCatamorphism(New GeneCatalog(myProgressDialog))
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub CollectSeriesListData()
        myProgressDialog.Text = String.Format(InfoMessage("CollectingData.ProgressBar.Title"), myRootLazyNode.UnitTitle)
        Cursor.Current = Cursors.WaitCursor
        myResult = myRootLazyNode.StopableCatamorphism(New GeneSeriesList(myProgressDialog))
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub CollectAuthorsListData()
        myProgressDialog.Text = String.Format(InfoMessage("CollectingData.ProgressBar.Title"), myRootLazyNode.UnitTitle)
        Cursor.Current = Cursors.WaitCursor
        myResult = myRootLazyNode.StopableCatamorphism(New GeneAuthorsList(myProgressDialog))
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub CollectInstalationUnitsListData()
        myProgressDialog.Text = String.Format(InfoMessage("CollectingData.ProgressBar.Title"), myRootLazyNode.UnitTitle)
        Cursor.Current = Cursors.WaitCursor
        myResult = myRootLazyNode.StopableCatamorphism(New GeneInstalationUnitsList(myProgressDialog))
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub CollectInstalationUnitsBySeriesListData()
        myProgressDialog.Text = String.Format(InfoMessage("CollectingData.ProgressBar.Title"), myRootLazyNode.UnitTitle)
        Cursor.Current = Cursors.WaitCursor
        myResult = myRootLazyNode.StopableCatamorphism(New GeneInstalationUnitsBySeriesList(myProgressDialog))
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub CollectClassificationPlanData()
        myProgressDialog.Text = String.Format(InfoMessage("CollectingData.ProgressBar.Title"), myRootLazyNode.UnitTitle)
        Cursor.Current = Cursors.WaitCursor
        myResult = myRootLazyNode.StopableCatamorphism(New GeneInventory(myProgressDialog))
        Cursor.Current = Cursors.Default
    End Sub



    Private Sub UpdateCompleteUnitId()
        myProgressDialog.Text = String.Format(InfoMessage("UpdateCompleteUnitId.Title"), myRootLazyNode.UnitTitle)
        Cursor.Current = Cursors.WaitCursor
        myResult = myRootLazyNode.StopableCatamorphism(New GeneUpdateCompleteUnitId(myProgressDialog))
        Cursor.Current = Cursors.Default
    End Sub


    Private Sub CountNodesByOtherLevel()
        myProgressDialog.Text = String.Format(InfoMessage("GeneNodeCounter.Title"), myRootLazyNode.UnitTitle)
        Cursor.Current = Cursors.WaitCursor
        myResult = myRootLazyNode.StopableCatamorphism(New GeneNodeCounterPro(myProgressDialog))
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub SearchReplace()
        myProgressDialog.Text = String.Format(InfoMessage("SearchReplace.Title"), myRootLazyNode.UnitTitle)
        Cursor.Current = Cursors.WaitCursor
        Dim Args As Hashtable = CType(myArgument, Hashtable)
        myResult = myRootLazyNode.StopableCatamorphism(New GeneSearchReplace(myProgressDialog, Args("FieldName"), Args("SearchString"), Args("ReplaceBy"), Args("CaseSensitive"), Args("RegExp"), Args("ProcessInfoName")))
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub Search()
        myProgressDialog.Text = String.Format(InfoMessage("Search.Title"), myRootLazyNode.UnitTitle)
        Cursor.Current = Cursors.WaitCursor
        Dim Args As Hashtable = CType(myArgument, Hashtable)
        myResult = myRootLazyNode.StopableCatamorphism(New GeneSearch(myProgressDialog, Args("FieldName"), Args("SearchString"), Args("CaseSensitive"), Args("RegExp")))
        Cursor.Current = Cursors.Default
    End Sub

#End Region





End Class
