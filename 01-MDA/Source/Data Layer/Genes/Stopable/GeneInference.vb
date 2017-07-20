
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

Public Class GeneInference
    Inherits StopableGene

    Private myProgressDialog As ProgressDialog


    Public Sub New(ByVal ProgressDialog As ProgressDialog)
        myProgressDialog = ProgressDialog
    End Sub

    Private Enum ExtremeDateTypes
        Initial
        Final
    End Enum




    Public Overrides Function Apply(ByVal obj As LazyNode, ByVal ChildrenResults As Microsoft.VisualBasic.Collection) As Object
        Dim Result As New InferenceData

        If obj.isLeaf Then
            Result.UnitDateFinal = obj.UnitDateFinal
            Result.UnitDateFinalCertainty = obj.UnitDateFinalCertainty
            Result.UnitDateInitial = obj.UnitDateInitial
            Result.UnitDateInitialCertainty = obj.UnitDateInitialCertainty

            If obj.OtherLevel = OTHERLEVEL_INSTALATIONUNIT OrElse _
               obj.OtherLevel = OTHERLEVEL_COMPOSEDDOCUMENT OrElse _
               obj.OtherLevel = OTHERLEVEL_DOCUMENT Then
                Result.ExtentPage = obj.ExtentPage
                Result.ExtentLeaf = obj.ExtentLeaf
                Debug.WriteLine("PAGE/LEAF: " & obj.UnitId)
            End If
        End If


        If obj.OtherLevel = OTHERLEVEL_INSTALATIONUNIT Then
            Select Case obj.ContainerType
                Case VisualFieldLabel("ContainerType.Book") : Result.ExtentBook = 1
                Case VisualFieldLabel("ContainerType.Box") : Result.ExtentBox = 1
                Case VisualFieldLabel("ContainerType.Page") : Result.ExtentPage = 1
                Case VisualFieldLabel("ContainerType.Leaf") : Result.ExtentLeaf = 1
                Case VisualFieldLabel("ContainerType.Maco") : Result.ExtentMaco = 1
                Case VisualFieldLabel("ContainerType.Other") : Result.ExtentOther = 1
                Case VisualFieldLabel("ContainerType.Roll") : Result.ExtentRoll = 1
                Case VisualFieldLabel("ContainerType.Cover") : Result.ExtentCover = 1
                Case VisualFieldLabel("ContainerType.Capilha") : Result.ExtentCapilha = 1
                Case VisualFieldLabel("ContainerType.Folder") : Result.ExtentFolder = 1
                Case VisualFieldLabel("ContainerType.Macete") : Result.ExtentMacete = 1
                Case VisualFieldLabel("ContainerType.Album") : Result.ExtentAlbum = 1
                Case VisualFieldLabel("ContainerType.Envelope") : Result.ExtentEnvelope = 1
            End Select
        ElseIf obj.OtherLevel = OTHERLEVEL_SERIES Then
            Result.ExtentMl = obj.ExtentMl
        End If


        ' Handle non leaf nodes
        If Not obj.isLeaf Then ' node is not leaf
            ' Handling the possibility of disabling inference
            If (obj.AllowUnitDatesInference) Then
                Dim InferedDates As InferenceData = InferDates(ChildrenResults)
                ' update result object
                Result.UnitDateInitial = InferedDates.UnitDateInitial
                Result.UnitDateInitialCertainty = InferedDates.UnitDateInitialCertainty
                Result.UnitDateFinal = InferedDates.UnitDateFinal
                Result.UnitDateFinalCertainty = InferedDates.UnitDateFinalCertainty
            Else ' if inference is off, use the values from this node
                Result.UnitDateFinal = obj.UnitDateFinal
                Result.UnitDateFinalCertainty = obj.UnitDateFinalCertainty
                Result.UnitDateInitial = obj.UnitDateInitial
                Result.UnitDateInitialCertainty = obj.UnitDateInitialCertainty
            End If


            If (obj.AllowExtentsInference) Then
                Dim InferedExtents As InferenceData = InferExtents(ChildrenResults)
                Result.ExtentBook = InferedExtents.ExtentBook
                Result.ExtentBox = InferedExtents.ExtentBox
                Result.ExtentCapilha = InferedExtents.ExtentCapilha
                Result.ExtentCover = InferedExtents.ExtentCover
                Result.ExtentFolder = InferedExtents.ExtentFolder
                Result.ExtentLeaf = InferedExtents.ExtentLeaf
                Result.ExtentMacete = InferedExtents.ExtentMacete
                Result.ExtentMaco = InferedExtents.ExtentMaco
                Result.ExtentMl = InferedExtents.ExtentMl
                Result.ExtentOther = InferedExtents.ExtentOther
                Result.ExtentPage = InferedExtents.ExtentPage
                Result.ExtentRoll = InferedExtents.ExtentRoll
                Result.ExtentAlbum = InferedExtents.ExtentAlbum
                Result.ExtentEnvelope = InferedExtents.ExtentEnvelope
            Else ' inference is off. Use node's own values
                Result.ExtentBook = obj.ExtentBook
                Result.ExtentBox = obj.ExtentBox
                Result.ExtentCapilha = obj.ExtentCapilha
                Result.ExtentCover = obj.ExtentCover
                Result.ExtentFolder = obj.ExtentFolder
                Result.ExtentLeaf = obj.ExtentLeaf
                Result.ExtentMacete = obj.ExtentMacete
                Result.ExtentMaco = obj.ExtentMaco
                Result.ExtentMl = obj.ExtentMl
                Result.ExtentOther = obj.ExtentOther
                Result.ExtentPage = obj.ExtentPage
                Result.ExtentRoll = obj.ExtentRoll
                Result.ExtentAlbum = obj.ExtentAlbum
                Result.ExtentEnvelope = obj.ExtentEnvelope
            End If
        End If


        ' fix anomalies
        If Result.UnitDateFinal = "0001-01-01" Then
            obj.UnitDateFinal = "0000-00-00"
        Else
            obj.UnitDateFinal = Result.UnitDateFinal
        End If
        obj.UnitDateFinalCertainty = Result.UnitDateFinalCertainty


        If Result.UnitDateInitial = "9999-12-31" Then
            obj.UnitDateInitial = "0000-00-00"
        Else
            obj.UnitDateInitial = Result.UnitDateInitial
        End If
        obj.UnitDateInitialCertainty = Result.UnitDateInitialCertainty


        ' Assigned infered data to current node attributes
        obj.ExtentMl = Result.ExtentMl
        obj.ExtentPage = Result.ExtentPage
        obj.ExtentLeaf = Result.ExtentLeaf

        obj.ExtentBook = Result.ExtentBook
        obj.ExtentBox = Result.ExtentBox
        obj.ExtentMaco = Result.ExtentMaco

        obj.ExtentMacete = Result.ExtentMacete
        obj.ExtentFolder = Result.ExtentFolder
        obj.ExtentCover = Result.ExtentCover

        obj.ExtentCapilha = Result.ExtentCapilha
        obj.ExtentRoll = Result.ExtentRoll
        obj.ExtentAlbum = Result.ExtentAlbum

        obj.ExtentEnvelope = Result.ExtentEnvelope
        obj.ExtentOther = Result.ExtentOther

        obj.Upload() ' save node

        If Not myProgressDialog Is Nothing Then
            myProgressDialog.Message = String.Format(InfoMessage("Inference.Progression"), obj.UnitId)
            myProgressDialog.Increment()
            StopCatamorfism = myProgressDialog.Cancel
        End If


        Return Result
    End Function


    Private Function handleUnkownDates(ByVal d As String, ByVal DateType As ExtremeDateTypes)
        If d = "0000-00-00" Then
            If DateType = ExtremeDateTypes.Final Then
                Return "0001-01-01"
            Else
                Return "9999-12-31"
            End If
        Else
            Return d
        End If
    End Function




    Private Function InferDates(ByVal DataList As Collection) As InferenceData

        Dim Result As New InferenceData
        Dim UnitDateFinal As String
        Dim UnitDateInitial As String

        Dim Child As InferenceData
        For Each Child In DataList
            UnitDateFinal = handleUnkownDates(Child.UnitDateFinal, ExtremeDateTypes.Final)
            UnitDateInitial = handleUnkownDates(Child.UnitDateInitial, ExtremeDateTypes.Initial)


            If UnitDateFinal.CompareTo(Result.UnitDateFinal) > 0 Then ' get max UnitDateFinal
                Result.UnitDateFinal = UnitDateFinal
                Result.UnitDateFinalCertainty = Child.UnitDateFinalCertainty
            End If

            If UnitDateInitial.CompareTo(Result.UnitDateInitial) < 0 Then ' get min UnitDateInitial
                Result.UnitDateInitial = UnitDateInitial
                Result.UnitDateInitialCertainty = Child.UnitDateInitialCertainty
            End If
        Next
        Return Result
    End Function


    Private Function InferExtents(ByVal DataList As Collection) As InferenceData

        Dim Result As New InferenceData
        Dim UnitDateFinal As String
        Dim UnitDateInitial As String

        Dim Child As InferenceData
        For Each Child In DataList
            Result.ExtentMl += Child.ExtentMl
            Result.ExtentPage += Child.ExtentPage
            Result.ExtentLeaf += Child.ExtentLeaf

            Result.ExtentBook += Child.ExtentBook
            Result.ExtentBox += Child.ExtentBox
            Result.ExtentMaco += Child.ExtentMaco

            Result.ExtentMacete += Child.ExtentMacete
            Result.ExtentFolder += Child.ExtentFolder
            Result.ExtentCover += Child.ExtentCover

            Result.ExtentCapilha += Child.ExtentCapilha
            Result.ExtentRoll += Child.ExtentRoll
            Result.ExtentAlbum += Child.ExtentAlbum

            Result.ExtentEnvelope += Child.ExtentEnvelope
            Result.ExtentOther += Child.ExtentOther
        Next
        Return Result
    End Function

End Class



Public Class InferenceData
    Private myUnitDateInitial As String
    Private myUnitDateInitialCertainty As Boolean
    Private myUnitDateFinal As String
    Private myUnitDateFinalCertainty As Boolean

    Private myExtentBook As Integer
    Private myExtentMaco As Integer
    Private myExtentMacete As Integer
    Private myExtentFolder As Integer
    Private myExtentCover As Integer
    Private myExtentCapilha As Integer
    Private myExtentRoll As Integer
    Private myExtentBox As Integer
    Private myExtentAlbum As Integer
    Private myExtentEnvelope As Integer
    Private myExtentMl As Double
    Private myExtentLeaf As Integer
    Private myExtentPage As Integer
    Private myExtentOther As Integer


    Public Sub New()
        UnitDateInitial = "9999-12-31"
        UnitDateFinal = "0001-01-01"

        myExtentBook = 0
        myExtentMaco = 0
        myExtentMacete = 0
        myExtentFolder = 0
        myExtentCover = 0
        myExtentCapilha = 0
        myExtentRoll = 0
        myExtentBox = 0
        myExtentAlbum = 0
        myExtentEnvelope = 0
        myExtentMl = 0.0
        myExtentLeaf = 0
        myExtentPage = 0
        myExtentOther = 0
    End Sub


    Public Property ExtentOther() As Integer
        Get
            Return myExtentOther
        End Get
        Set(ByVal Value As Integer)
            myExtentOther = Value
        End Set
    End Property
    Public Property ExtentLeaf() As Integer
        Get
            Return myExtentLeaf
        End Get
        Set(ByVal Value As Integer)
            myExtentLeaf = Value
        End Set
    End Property
    Public Property ExtentPage() As Integer
        Get
            Return myExtentPage
        End Get
        Set(ByVal Value As Integer)
            myExtentPage = Value
        End Set
    End Property
    Public Property ExtentBook() As Integer
        Get
            Return myExtentBook
        End Get
        Set(ByVal Value As Integer)
            myExtentBook = Value
        End Set
    End Property
    Public Property ExtentBox() As Integer
        Get
            Return myExtentBox
        End Get
        Set(ByVal Value As Integer)
            myExtentBox = Value
        End Set
    End Property
    Public Property ExtentCover() As Integer
        Get
            Return myExtentCover
        End Get
        Set(ByVal Value As Integer)
            myExtentCover = Value
        End Set
    End Property
    Public Property ExtentCapilha() As Integer
        Get
            Return myExtentCapilha
        End Get
        Set(ByVal Value As Integer)
            myExtentCapilha = Value
        End Set
    End Property
    Public Property ExtentFolder() As Integer
        Get
            Return myExtentFolder
        End Get
        Set(ByVal Value As Integer)
            myExtentFolder = Value
        End Set
    End Property
    Public Property ExtentMacete() As Integer
        Get
            Return myExtentMacete
        End Get
        Set(ByVal Value As Integer)
            myExtentMacete = Value
        End Set
    End Property
    Public Property ExtentMaco() As Integer
        Get
            Return myExtentMaco
        End Get
        Set(ByVal Value As Integer)
            myExtentMaco = Value
        End Set
    End Property
    Public Property ExtentMl() As Double
        Get
            Return myExtentMl
        End Get
        Set(ByVal Value As Double)
            myExtentMl = Value
        End Set
    End Property
    Public Property ExtentRoll() As Integer
        Get
            Return myExtentRoll
        End Get
        Set(ByVal Value As Integer)
            myExtentRoll = Value
        End Set
    End Property
    Public Property ExtentAlbum() As Integer
        Get
            Return myExtentAlbum
        End Get
        Set(ByVal Value As Integer)
            myExtentAlbum = Value
        End Set
    End Property
    Public Property ExtentEnvelope() As Integer
        Get
            Return myExtentEnvelope
        End Get
        Set(ByVal Value As Integer)
            myExtentEnvelope = Value
        End Set
    End Property
    Public Property UnitDateInitial() As String
        Get
            Return myUnitDateInitial
        End Get
        Set(ByVal Value As String)
            myUnitDateInitial = Value
        End Set
    End Property
    Public Property UnitDateInitialCertainty() As Boolean
        Get
            Return myUnitDateInitialCertainty
        End Get
        Set(ByVal Value As Boolean)
            myUnitDateInitialCertainty = Value
        End Set
    End Property
    Public Property UnitDateFinal() As String
        Get
            Return myUnitDateFinal
        End Get
        Set(ByVal Value As String)
            myUnitDateFinal = Value
        End Set
    End Property
    Public Property UnitDateFinalCertainty() As Boolean
        Get
            Return myUnitDateFinalCertainty
        End Get
        Set(ByVal Value As Boolean)
            myUnitDateFinalCertainty = Value
        End Set
    End Property


End Class


