
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

Imports System.Xml
Imports System.IO
Imports System.Configuration

Public Class EADLazyNode
    Inherits LazyNode


#Region "Internal Properties (private)"
    '*************************************************************************
    Private configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
    Private myXmlDocument As XmlDocument
    Private myXmlNode As XmlNode
    '*************************************************************************
#End Region


#Region "Initializations"
    Public Sub New(ByVal Filename As String)
        Try
            myXmlDocument = New XmlDocument
            myXmlDocument.Load(Filename)
            myXmlNode = myXmlDocument.SelectSingleNode("/ead/archdesc")
            Download()
        Catch ex As Exception
            'MessageBoxes.MsgBoxException(ex)
            Throw ex
        End Try
    End Sub


    Public Sub New(ByVal XmlDocument As XmlDocument, ByVal XmlNode As XmlNode)
        myXmlDocument = XmlDocument
        myXmlNode = XmlNode
        Download()
    End Sub


    Public Sub New()
        myXmlDocument = New XmlDocument
        myXmlDocument.LoadXml(Constant("EmptyEAD"))
        myXmlNode = myXmlDocument.SelectSingleNode("/ead/archdesc")
        Download()
    End Sub


#End Region


#Region "Lazy Node Mandatory Methods"
    '*************************************************************************

    ' IMCOMPLETE - Falta testar
    ' Falta limpar os registos que nao teem informacao
    Public Sub SaveXML(ByVal filename As String)
        myXmlDocument.Save(filename)
    End Sub



    ' COMPLETE - Falta testar
    Public Overrides Sub AppendChild(ByVal Child As LazyNode)
        If Not TypeOf Child Is EADLazyNode Then Exit Sub
        Dim dsc As XmlNode = myXmlNode.Item("dsc")
        Dim EADChildNode As EADLazyNode = CType(Child, EADLazyNode)
        If dsc Is Nothing Then myXmlNode.AppendChild(myXmlDocument.CreateElement("dsc"))
        myXmlNode.SelectSingleNode("dsc").AppendChild(EADChildNode.XmlNode)
    End Sub


    Public Overrides ReadOnly Property HasChildren() As Boolean
        Get
            Return Not myXmlNode.SelectSingleNode("dsc/c") Is Nothing
        End Get
    End Property


    ' Maybe I should be loading into a private collection
    Public Overrides Function Children() As LazyNodeCollection
        Dim Node As XmlNode
        Dim Nodes As XmlNodeList = myXmlNode.SelectNodes("dsc/c")
        Dim NodeCollection As New LazyNodeCollection
        For Each Node In Nodes
            NodeCollection.Add(New EADLazyNode(myXmlDocument, Node))
        Next
        Return NodeCollection
    End Function


    ' COMPLETE - Falta testar
    Public Overrides Function Clone() As LazyNode
        Return New EADLazyNode(myXmlDocument, myXmlNode.Clone())
    End Function


    ' COMPLETE - Falta testar
    Public Overrides Function CreateNode() As LazyNode
        Dim NewXmlNode As XmlNode = myXmlDocument.CreateElement("c")
        Dim levelAttr As XmlAttribute = myXmlDocument.CreateNode(XmlNodeType.Attribute, "level", "")
        Dim otherLevelAttr As XmlAttribute = myXmlDocument.CreateNode(XmlNodeType.Attribute, "otherlevel", "")
        ' default values
        levelAttr.InnerText = "otherlevel"
        otherLevelAttr.InnerText = EADDefinitions.OTHERLEVEL_DOCUMENT
        NewXmlNode.Attributes.Append(levelAttr)
        NewXmlNode.Attributes.Append(otherLevelAttr)
        NewXmlNode.InnerXml &= _
        "<did><unitid countrycode='" & VisualFieldLabel("CountryCode.DefaultValue") & "' repositorycode='" & VisualFieldLabel("RepositoryCode.DefaultValue") & "'>[novo]</unitid></did>"
        Dim NewLazyNode As New EADLazyNode(myXmlDocument, NewXmlNode)
        Return NewLazyNode
    End Function


    ' this function was not yet tested
    Public Overrides Function Parent() As LazyNode
        Dim Node As XmlNode = myXmlNode.SelectSingleNode("../..")
        Return New EADLazyNode(myXmlDocument, Node)
    End Function


    Public Overrides Sub Download()
        Abstract = GetFieldAsString(LazyNodeFields.Abstract)
        AccessRestrict = GetFieldAsString(LazyNodeFields.AccessRestrict)
        Accruals = GetFieldAsString(LazyNodeFields.Accruals)
        AcqInfo = GetFieldAsString(LazyNodeFields.AcqInfo)
        Appraisal = AltFormAvail = GetFieldAsString(LazyNodeFields.AltFormAvail)
        Appraisal = GetFieldAsString(LazyNodeFields.Appraisal)
        AltFormAvail = GetFieldAsString(LazyNodeFields.AltFormAvail)
        Arrangement = GetFieldAsString(LazyNodeFields.Arrangement)
        Bibliography = GetFieldAsBibliography(LazyNode.LazyNodeFields.Bibliography)
        BiogHist = GetFieldAsString(LazyNodeFields.BiogHist)
        ChronList = getFieldAsChronList(LazyNodeFields.ChronList)
        ControlAccess = GetFieldAsControlAccess(LazyNodeFields.ControlAccess)
        CountryCode = GetFieldAsString(LazyNodeFields.CountryCode)
        CustodHist = GetFieldAsString(LazyNodeFields.CustodHist)
        DaoGrp = GetFieldAsDaoGrp(LazyNode.LazyNodeFields.DaoGrp)
        Dimensions = GetFieldAsString(LazyNodeFields.Dimensions)
        ExtentBook = GetFieldAsInteger(LazyNodeFields.ExtentBook)
        ExtentBox = GetFieldAsInteger(LazyNodeFields.ExtentBox)
        ExtentCover = GetFieldAsInteger(LazyNodeFields.ExtentCover)
        ExtentCapilha = GetFieldAsInteger(LazyNodeFields.ExtentCapilha)
        ExtentFolder = GetFieldAsInteger(LazyNodeFields.ExtentFolder)
        ExtentMacete = GetFieldAsInteger(LazyNodeFields.ExtentMacete)
        ExtentMaco = GetFieldAsInteger(LazyNodeFields.ExtentMaco)
        ExtentMl = GetFieldAsDouble(LazyNodeFields.ExtentMl)
        ExtentRoll = GetFieldAsInteger(LazyNodeFields.ExtentRoll)
        ExtentEnvelope = GetFieldAsInteger(LazyNodeFields.ExtentEnvelope)
        ExtentAlbum = GetFieldAsInteger(LazyNodeFields.ExtentAlbum)
        FilePlan = GetFieldAsString(LazyNodeFields.FilePlan)
        GenreForm = GetFieldAsString(LazyNodeFields.GenreForm)
        GeogName = GetFieldAsString(LazyNodeFields.GeogName)
        LangMaterial = GetFieldAsString(LazyNodeFields.LangMaterial)
        LegalStatus = GetFieldAsString(LazyNodeFields.LegalStatus)
        MaterialSpec = GetFieldAsString(LazyNodeFields.MaterialSpec)
        Note = GetFieldAsString(LazyNodeFields.Note)
        OriginalNumbering = GetFieldAsString(LazyNodeFields.OriginalNumbering)
        OriginalsLoc = GetFieldAsString(LazyNodeFields.OriginalsLoc)
        OriginationAuthor = GetFieldAsString(LazyNodeFields.OriginationAuthor)
        OriginationAuthorAddress = GetFieldAsString(LazyNodeFields.OriginationAuthorAddress)
        OriginationDestination = GetFieldAsString(LazyNodeFields.OriginationDestination)
        OriginationDestinationAddress = GetFieldAsString(LazyNodeFields.OriginationDestinationAddress)
        OriginationNotary = GetFieldAsString(LazyNodeFields.OriginationNotary)
        OriginationScrivener = GetFieldAsString(LazyNodeFields.OriginationScrivener)
        OtherFindAid = GetFieldAsString(LazyNodeFields.OtherFindAid)
        OtherLevel = GetFieldAsString(LazyNodeFields.OtherLevel)
        PhysFacet = GetFieldAsString(LazyNodeFields.PhysFacet)
        PhysLoc = GetFieldAsString(LazyNodeFields.PhysLoc)
        PhysTech = GetFieldAsString(LazyNodeFields.PhysTech)
        PreferCite = GetFieldAsString(LazyNodeFields.PreferCite)
        ProcessInfoDate = GetFieldAsString(LazyNodeFields.ProcessInfoDate)
        ProcessInfoName = GetFieldAsString(LazyNodeFields.ProcessInfoName)
        RelatedMaterial = GetFieldAsString(LazyNodeFields.RelatedMaterial)
        Repository = GetFieldAsString(LazyNodeFields.Repository)
        RepositoryCode = GetFieldAsString(LazyNodeFields.RepositoryCode)
        ScopeContent = GetFieldAsString(LazyNodeFields.ScopeContent)
        SeparatedMaterial = GetFieldAsString(LazyNodeFields.SeparatedMaterial)
        UnitDateFinal = NormalizeDate(GetFieldAsString(LazyNodeFields.UnitDateFinal))
        UnitDateFinalCertainty = GetFieldAsBoolean(LazyNodeFields.UnitDateFinalCertainty)
        UnitDateInitial = NormalizeDate(GetFieldAsString(LazyNodeFields.UnitDateInitial))
        UnitDateInitialCertainty = GetFieldAsBoolean(LazyNodeFields.UnitDateInitialCertainty)
        UnitId = GetFieldAsString(LazyNodeFields.UnitId)
        UnitTitle = GetFieldAsString(LazyNodeFields.UnitTitle)
        UseRestrict = GetFieldAsString(LazyNodeFields.UseRestrict)
        UnitTitleType = GetFieldAsString(LazyNodeFields.UnitTitleType)
        ExtentPage = GetFieldAsInteger(LazyNodeFields.ExtentPage)
        ExtentOther = GetFieldAsInteger(LazyNodeFields.ExtentOther)
        ExtentLeaf = GetFieldAsInteger(LazyNodeFields.ExtentLeaf)
        UnitDateBulk = GetFieldAsString(LazyNodeFields.UnitDateBulk)
        ContainerType = GetFieldAsString(LazyNodeFields.ContainerType)
        ContainerCustomType = GetFieldAsString(LazyNodeFields.ContainerCustomType)
    End Sub



    ' COMPLETE - Falta testar
    Public Overrides Sub RemoveChild(ByVal Child As LazyNode)
        If Not TypeOf Child Is EADLazyNode Then Exit Sub

        Dim dsc As XmlNode = myXmlNode.Item("dsc")

        If Not dsc Is Nothing Then
            Dim EADChildNode As EADLazyNode = CType(Child, EADLazyNode)
            dsc.RemoveChild(EADChildNode.XmlNode)
            If dsc.ChildNodes.Count = 0 Then myXmlNode.RemoveChild(dsc) ' remove dsc if no children left
        End If
    End Sub



    ' IMCOMPLETE - Faltam os campos compostos
    Public Overrides Sub Upload()
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.Abstract, Abstract)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.AccessRestrict, AccessRestrict)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.Accruals, Accruals)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.AcqInfo, AcqInfo)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.AltFormAvail, AltFormAvail)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.Appraisal, Appraisal)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.Abstract, Abstract)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.Arrangement, Arrangement)
        SetBibliographyValue(Me.myXmlNode, LazyNode.LazyNodeFields.Bibliography, Bibliography)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.BiogHist, BiogHist)
        SetChronListValue(Me.myXmlNode, LazyNode.LazyNodeFields.ChronList, ChronList)
        SetControlAccessValue(Me.myXmlNode, LazyNode.LazyNodeFields.ControlAccess, ControlAccess)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.CountryCode, CountryCode)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.CustodHist, CustodHist)
        'SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.DaoGrp, DaoGrp)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.Dimensions, Dimensions)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.ExtentBook, ExtentBook)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.ExtentCapilha, ExtentCapilha)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.ExtentCover, ExtentCover)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.ExtentFolder, ExtentFolder)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.ExtentMacete, ExtentMacete)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.ExtentMaco, ExtentMaco)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.ExtentMl, ExtentMl)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.ExtentRoll, ExtentRoll)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.ExtentEnvelope, ExtentEnvelope)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.ExtentAlbum, ExtentAlbum)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.FilePlan, FilePlan)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.GenreForm, GenreForm)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.GeogName, GeogName)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.LangMaterial, LangMaterial)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.LegalStatus, LegalStatus)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.MaterialSpec, MaterialSpec)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.Note, Note)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.OriginalNumbering, OriginalNumbering)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.OriginalsLoc, OriginalsLoc)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.OriginationAuthor, OriginationAuthor)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.OriginationAuthorAddress, OriginationAuthorAddress)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.OriginationDestination, OriginationDestination)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.OriginationDestinationAddress, OriginationDestinationAddress)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.OriginationNotary, OriginationNotary)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.OriginationScrivener, OriginationScrivener)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.OtherFindAid, OtherFindAid)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.OtherLevel, OtherLevel)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.PhysFacet, PhysFacet)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.PhysLoc, PhysLoc)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.PhysTech, PhysTech)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.PreferCite, PreferCite)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.ProcessInfoDate, ProcessInfoDate)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.ProcessInfoName, ProcessInfoName)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.RelatedMaterial, RelatedMaterial)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.Repository, Repository)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.RepositoryCode, RepositoryCode)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.ScopeContent, ScopeContent)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.SeparatedMaterial, SeparatedMaterial)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.UnitDateFinal, UnitDateFinal)
        SetBooleanFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.UnitDateFinalCertainty, UnitDateFinalCertainty)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.UnitDateInitial, UnitDateInitial)
        SetBooleanFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.UnitDateInitialCertainty, UnitDateInitialCertainty)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.UnitId, UnitId)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.UnitTitle, UnitTitle)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.UseRestrict, UseRestrict)
        'SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.Valid, Valid)
        'SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.Visible, Visible)

        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.UnitTitleType, UnitTitleType)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.ExtentOther, ExtentOther)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.ExtentPage, ExtentPage)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.ExtentLeaf, ExtentLeaf)
        SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.UnitDateBulk, UnitDateBulk)

        If OtherLevel = EADDefinitions.OTHERLEVEL_INSTALATIONUNIT Then ' this only exists for UI
            If ContainerType = VisualFieldLabel("ContainerType.Other") Then
                SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.ContainerCustomType, ContainerCustomType)
            Else
                SetFieldValue(Me.myXmlNode, LazyNode.LazyNodeFields.ContainerType, ContainerType)
            End If
        End If

    End Sub

#End Region


#Region "EAD Node Specific methods (private)"

    Public Overrides ReadOnly Property ID() As Object
        Get
            Return XmlNode
        End Get
    End Property

    Public Overrides Property ParentId() As Object
        Get
            Return Parent.ID
        End Get
        Set(ByVal Value As Object)
        End Set
    End Property


    Private ReadOnly Property XmlNode() As XmlNode
        Get
            Return myXmlNode
        End Get
    End Property

#End Region


#Region "Get Fields from XML"

    Private Function GetFieldAsDate(ByVal Field As LazyNodeFields) As Date
        Dim node As XmlNode = myXmlNode.SelectSingleNode(FieldToXPath(Field))
        If Not node Is Nothing Then
            Try
                Dim d As Date = Date.Parse(node.InnerText)
                Return d
            Catch ex As Exception
            End Try
        End If
        Return Date.Parse("0000-00-00")
    End Function

    Private Function GetFieldAsBoolean(ByVal Field As LazyNodeFields) As Boolean
        Dim node As XmlNode = myXmlNode.SelectSingleNode(FieldToXPath(Field))

        If node Is Nothing Then
            Return False
        Else
            If node.InnerText.ToLower = "yes" OrElse node.InnerText.ToLower = "true" OrElse node.InnerText = "1" Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Private Function GetFieldAsInteger(ByVal Field As LazyNodeFields) As Integer
        Dim node As XmlNode = myXmlNode.SelectSingleNode(FieldToXPath(Field))
        If Not node Is Nothing Then
            Try
                Dim d As Integer = CInt(node.InnerText)
                Return d
            Catch ex As Exception
            End Try
        End If
        Return 0
    End Function

    Private Function GetFieldAsDouble(ByVal Field As LazyNodeFields) As Double
        Dim node As XmlNode = myXmlNode.SelectSingleNode(FieldToXPath(Field))
        If Not node Is Nothing Then
            Try
                Dim d As Double = CDbl(node.InnerText)
                Return d
            Catch ex As Exception
            End Try
        End If
        Return 0.0
    End Function

    Private Function GetFieldAsString(ByVal Field As LazyNodeFields) As String
        Dim node As XmlNode = myXmlNode.SelectSingleNode(FieldToXPath(Field))

        'dim cut here
        Dim str As String
        If node Is Nothing Then str = "" Else str = node.InnerText
        Debug.WriteLine("GetFieldAsString " & Field & " XPATH_" & FieldToXPath(Field) & " = " & str)
        ' cut here
        If node Is Nothing Then Return "" Else Return node.InnerText
    End Function

    Private Function getFieldAsChronList(ByVal Field As LazyNodeFields) As ChronList
        Dim ChronList As XmlNode = myXmlNode.SelectSingleNode(FieldToXPath(Field))
        If ChronList Is Nothing Then Return New ChronList
        Dim ChronItems As XmlNodeList = ChronList.SelectNodes("chronitem")
        Dim cList As New ChronList
        Dim node As XmlNode
        Dim dte As String
        Dim evnt As String
        Dim tmpNode As XmlNode

        For Each node In ChronItems
            If Not node Is Nothing Then
                tmpNode = node.SelectSingleNode("date")
                If Not tmpNode Is Nothing Then dte = tmpNode.InnerText Else dte = ""
                tmpNode = node.SelectSingleNode("event")
                If Not tmpNode Is Nothing Then evnt = tmpNode.InnerText Else evnt = ""
                cList.Add(dte, evnt)
            End If
        Next
        Return cList
    End Function

    Private Function GetFieldAsDaoGrp(ByVal Field As LazyNodeFields) As DaoGrp
        'Dim nodes As XmlNodeList = myXmlNode.SelectNodes(FieldToXPath(Field))
        'Dim node As XmlNode
        Dim dgList As New DaoGrp
        'Dim title As String
        'Dim href As String

        'For Each node In nodes
        '    If Not node Is Nothing Then
        '        Dim tmp As XmlNode
        '        title = ""
        '        href = ""
        '        tmp = node.SelectSingleNode("@title")
        '        If Not tmp Is Nothing Then title = tmp.InnerText
        '        tmp = node.SelectSingleNode("@href")
        '        If Not tmp Is Nothing Then href = tmp.InnerText
        '        dgList.Add(title, href)
        '    End If
        'Next
        Return dgList
    End Function

    Private Function GetFieldAsControlAccess(ByVal Field As LazyNode.LazyNodeFields) As ControlAccess
        Dim ListItem As XmlNode = myXmlNode.SelectSingleNode(FieldToXPath(Field))
        If ListItem Is Nothing Then Return New ControlAccess

        Dim DefItems As XmlNodeList = myXmlNode.SelectNodes("defitem")
        Dim caList As New ControlAccess
        Dim type As String
        Dim item As String
        Dim node As XmlNode
        Dim tmpNode As XmlNode

        For Each node In DefItems
            If Not node Is Nothing Then
                tmpNode = node.SelectSingleNode("label")
                If Not tmpNode Is Nothing Then type = tmpNode.InnerText Else type = ""
                tmpNode = node.SelectSingleNode("item")
                If Not tmpNode Is Nothing Then item = tmpNode.InnerText Else item = ""
                caList.Add(type, item)
            End If
        Next
        Return caList
    End Function

    Private Function GetFieldAsBibliography(ByVal Field As LazyNode.LazyNodeFields) As Bibliography
        Dim BibliographyNode As XmlNode = myXmlNode.SelectSingleNode(FieldToXPath(Field))
        If BibliographyNode Is Nothing Then Return New Bibliography
        Dim BibRefs As XmlNodeList = BibliographyNode.SelectNodes("bibref")
        Dim Node As XmlNode
        Dim bibList As New Bibliography

        For Each Node In BibRefs
            If Not Node Is Nothing Then
                bibList.Add(Node.InnerText)
            End If
        Next
        Return bibList
    End Function

#End Region


#Region "Set Fields into XML"

    Public Function SetControlAccessValue(ByVal XmlNode As XmlNode, ByVal Field As LazyNode.LazyNodeFields, ByVal Value As ControlAccess) As Collection
        Dim result As New Collection
        If Value.Count = 0 Then Return result

        Dim XPath As String = FieldToXPath(Field)

        Dim node As XmlNode = XmlNode.SelectSingleNode(XPath)
        If node Is Nothing Then node = CreateXPath(XmlNode, XPath)

        Dim Item As ControlAccessItem
        For Each Item In Value
            node.InnerXml &= String.Format("<defitem><label>{0}</label><item>{1}</item></defitem>", Item.Type, Item.Item)
            result.Add(node)
        Next

        Return result
    End Function

    Public Function SetBibliographyValue(ByVal XmlNode As XmlNode, ByVal Field As LazyNode.LazyNodeFields, ByVal Value As Bibliography) As Collection
        Dim result As New Collection
        If Value.Count = 0 Then Return result

        Dim XPath As String = FieldToXPath(Field)

        Dim node As XmlNode = XmlNode.SelectSingleNode(XPath)
        If node Is Nothing Then node = CreateXPath(XmlNode, XPath)

        For Each Item As BibRefItem In Value
            Dim BibRefNode As XmlNode = myXmlDocument.CreateElement("bibref")
            BibRefNode.InnerText = Item.BibRef
            node.AppendChild(BibRefNode)
            'node.InnerXml &= String.Format("<bibref>{0}</bibref>", Item.BibRef)
            result.Add(node)
        Next

        Return result
    End Function

    Public Function SetChronListValue(ByVal XmlNode As XmlNode, ByVal Field As LazyNode.LazyNodeFields, ByVal Value As ChronList) As Collection
        Dim result As New Collection
        If Value.Count = 0 Then Return result

        Dim XPath As String = FieldToXPath(Field)

        Dim node As XmlNode = XmlNode.SelectSingleNode(XPath)
        If node Is Nothing Then node = CreateXPath(XmlNode, XPath)

        Dim Item As ChronListItem
        For Each Item In Value
            node.InnerXml &= String.Format("<chronitem><date>{0}</date><event>{1}</event></chronitem>", Item.EventDate, Item.EventDescription)
            result.Add(node)
        Next

        Return result
    End Function



    Public Function SetUnitTitleTypeValue(ByVal XmlNode As XmlNode, ByVal Field As LazyNode.LazyNodeFields, ByVal Value As String) As XmlNode
        Dim XPath As String = FieldToXPath(Field)
        Dim node As XmlNode = XmlNode.SelectSingleNode(XPath)

        If node Is Nothing Then ' create the whole path
            node = CreateXPath(XmlNode, XPath)
        End If
        If Value = "" Then
            node.InnerText = VisualFieldLabel("UnitTitleType.Original")
        Else
            node.InnerText = Value
        End If
        Return node
    End Function ' Creating non existing XPath elements


    Public Function SetFieldValue(ByVal XmlNode As XmlNode, ByVal Field As LazyNode.LazyNodeFields, ByVal Value As String) As XmlNode
        If Value.Length = 0 Then Return Nothing
        Dim XPath As String = FieldToXPath(Field)
        Dim node As XmlNode = XmlNode.SelectSingleNode(XPath)

        If node Is Nothing Then ' create the whole path
            node = CreateXPath(XmlNode, XPath)
        End If
        node.InnerText = Value
        Return node
    End Function ' Creating non existing XPath elements

    Public Function SetBooleanFieldValue(ByVal XmlNode As XmlNode, ByVal Field As LazyNode.LazyNodeFields, ByVal Value As String) As XmlNode
        If Value.Length = 0 Then Return Nothing
        If Value.ToLower = "true" Then
            Value = "yes"
        Else
            Value = "no"
        End If
        Dim XPath As String = FieldToXPath(Field)
        Dim node As XmlNode = XmlNode.SelectSingleNode(XPath)

        If node Is Nothing Then ' create the whole path
            node = CreateXPath(XmlNode, XPath)
        End If
        node.InnerText = Value
        Return node
    End Function ' Creating non existing XPath elements


    Private Function CreateXPath(ByRef node As XmlNode, ByVal XPath As String) As XmlNode
        Dim elements() As String = XPath.Split("/")
        Dim element As String

        For Each element In elements
            If (node.SelectSingleNode(element) Is Nothing) Then
                'MsgBox(element & " not found")
                Dim newNode As XmlNode = CreateElement(element)
                If TypeOf newNode Is XmlAttribute Then
                    node.Attributes.Append(newNode)
                Else
                    node.AppendChild(newNode)
                End If

            End If
            node = node.SelectSingleNode(element)
        Next
        Return node
    End Function

    Private Function CreateElement(ByVal element As String) As XmlNode
        If element.IndexOf("[") >= 0 Then ' has attribute  elementName[@attr=value]
            Dim parts() As String = element.Split("[")
            Dim newNode As XmlNode = myXmlDocument.CreateElement(parts(0))
            newNode.Attributes.Append(CreateAttributeCondition(parts(1).Substring(1, parts(1).Length - 2))) ' removing @ and ]
            Return newNode
        ElseIf element.Chars(0) = "@" Then 'is attribute
            Return myXmlDocument.CreateAttribute(element.Substring(1))
        Else
            Return myXmlDocument.CreateElement(element)
        End If
    End Function

    Private Function CreateAttributeCondition(ByVal element As String) As XmlNode
        Dim keyValue() As String = element.Split("=")
        Dim attrNode As XmlAttribute = myXmlDocument.CreateAttribute(keyValue(0))
        attrNode.InnerText = keyValue(1).Substring(1, keyValue(1).Length - 2) ' removing start ' and end '
        Return attrNode
    End Function
#End Region


#Region "Some EAD/XML Definitions"
    Private Function FieldToXPath(ByVal FieldName As LazyNode.LazyNodeFields) As String
        Select Case FieldName
            Case LazyNode.LazyNodeFields.Abstract : Return "did/abstract"
            Case LazyNode.LazyNodeFields.AccessRestrict : Return "accessrestrict/p"
            Case LazyNode.LazyNodeFields.Accruals : Return "accruals/p"
            Case LazyNode.LazyNodeFields.AcqInfo : Return "acqinfo/p"
            Case LazyNode.LazyNodeFields.AltFormAvail : Return "altformavail/p"
            Case LazyNode.LazyNodeFields.Appraisal : Return "appraisal/p"
            Case LazyNode.LazyNodeFields.Arrangement : Return "arrangement/p"
            Case LazyNode.LazyNodeFields.Bibliography : Return "bibliography"
            Case LazyNode.LazyNodeFields.BiogHist : Return "bioghist/p"
            Case LazyNode.LazyNodeFields.ChronList : Return "bioghist/chronlist"
            Case LazyNode.LazyNodeFields.ControlAccess : Return "controlaccess/list"
            Case LazyNode.LazyNodeFields.CountryCode : Return "did/unitid/@countrycode"
            Case LazyNode.LazyNodeFields.CustodHist : Return "custodhist/p"
            Case LazyNode.LazyNodeFields.DaoGrp : Return "daogrp/daoloc"
            Case LazyNode.LazyNodeFields.Dimensions : Return "did/physdesc/dimensions"
            Case LazyNode.LazyNodeFields.ExtentBook : Return "did/physdesc/extent[@unit='livro']"
            Case LazyNode.LazyNodeFields.ExtentBox : Return "did/physdesc/extent[@unit='caixa']"
            Case LazyNode.LazyNodeFields.ExtentCapilha : Return "did/physdesc/extent[@unit='capilha']"
            Case LazyNode.LazyNodeFields.ExtentCover : Return "did/physdesc/extent[@unit='capa']"
            Case LazyNode.LazyNodeFields.ExtentFolder : Return "did/physdesc/extent[@unit='pasta']"
            Case LazyNode.LazyNodeFields.ExtentMacete : Return "did/physdesc/extent[@unit='macete']"
            Case LazyNode.LazyNodeFields.ExtentMaco : Return "did/physdesc/extent[@unit='maco']"
            Case LazyNode.LazyNodeFields.ExtentMl : Return "did/physdesc/extent[@unit='ml']"
            Case LazyNode.LazyNodeFields.ExtentRoll : Return "did/physdesc/extent[@unit='rolo']"
            Case LazyNode.LazyNodeFields.ExtentEnvelope : Return "did/physdesc/extent[@unit='envelope']"
            Case LazyNode.LazyNodeFields.ExtentAlbum : Return "did/physdesc/extent[@unit='album']"
            Case LazyNode.LazyNodeFields.GenreForm : Return "did/physdesc/genreform"
            Case LazyNode.LazyNodeFields.GeogName : Return "did/physdesc/geogname"
            Case LazyNode.LazyNodeFields.LangMaterial : Return "did/langmaterial"
            Case LazyNode.LazyNodeFields.LegalStatus : Return "accessrestrict/legalstatus"
            Case LazyNode.LazyNodeFields.MaterialSpec : Return "did/materialspec"
            Case LazyNode.LazyNodeFields.Note : Return "note[@label='observacoes']/p"
            Case LazyNode.LazyNodeFields.OriginalNumbering : Return "note[@label='numeracao_original']/p"
            Case LazyNode.LazyNodeFields.OriginalsLoc : Return "originalsloc/p"
            Case LazyNode.LazyNodeFields.OriginationAuthor : Return "did/origination[@label='autor']"
            Case LazyNode.LazyNodeFields.OriginationAuthorAddress : Return "did/origination[@label='morada_autor']"
            Case LazyNode.LazyNodeFields.OriginationDestination : Return "did/origination[@label='destinatario']"
            Case LazyNode.LazyNodeFields.OriginationDestinationAddress : Return "did/origination[@label='morada_destinatario']"
            Case LazyNode.LazyNodeFields.OriginationNotary : Return "did/origination[@label='notario']"
            Case LazyNode.LazyNodeFields.OriginationScrivener : Return "did/origination[@label='escrivao']"
            Case LazyNode.LazyNodeFields.OtherFindAid : Return "otherfindaid/p"
            Case LazyNode.LazyNodeFields.OtherLevel : Return "@otherlevel"
            Case LazyNode.LazyNodeFields.PhysFacet : Return "did/physdesc/physfacet"
            Case LazyNode.LazyNodeFields.PhysLoc : Return "did/physloc"
            Case LazyNode.LazyNodeFields.PhysTech : Return "phystech/p"
            Case LazyNode.LazyNodeFields.PreferCite : Return "prefercite/p"
            Case LazyNode.LazyNodeFields.ProcessInfoDate : Return "processinfo/p/date"
            Case LazyNode.LazyNodeFields.ProcessInfoName : Return "processinfo/p/name"
            Case LazyNode.LazyNodeFields.RelatedMaterial : Return "relatedmaterial/p"
            Case LazyNode.LazyNodeFields.Repository : Return "did/repository"
            Case LazyNode.LazyNodeFields.RepositoryCode : Return "did/unitid/@repositorycode"
            Case LazyNode.LazyNodeFields.ScopeContent : Return "scopecontent/p"
            Case LazyNode.LazyNodeFields.SeparatedMaterial : Return "separatedmaterial/p"
            Case LazyNode.LazyNodeFields.UnitDateFinal : Return "did/unitdate[@datechar='criacao_final']"
            Case LazyNode.LazyNodeFields.UnitDateFinalCertainty : Return "did/unitdate[@datechar='criacao_final']/@certainty"
            Case LazyNode.LazyNodeFields.UnitDateInitial : Return "did/unitdate[@datechar='criacao_inicial']"
            Case LazyNode.LazyNodeFields.UnitDateInitialCertainty : Return "did/unitdate[@datechar='criacao_inicial']/@certainty"
            Case LazyNode.LazyNodeFields.UnitId : Return "did/unitid"

            Case LazyNode.LazyNodeFields.UnitTitle : Return "did/unittitle"
            Case LazyNode.LazyNodeFields.UnitTitleType : Return "did/unittitle/@type"

            Case LazyNode.LazyNodeFields.UseRestrict : Return "userestrict/p"
            Case LazyNode.LazyNodeFields.FilePlan : Return "fileplan/p"

            Case LazyNode.LazyNodeFields.ExtentPage : Return "did/physdesc/extent[@unit='pagina']"
            Case LazyNode.LazyNodeFields.ExtentLeaf : Return "did/physdesc/extent[@unit='folha']"
            Case LazyNode.LazyNodeFields.ExtentOther : Return "did/physdesc/extent[@unit='outro']"
            Case LazyNode.LazyNodeFields.UnitDateBulk : Return "did/unitdate[@datechar='predominantes']"

            Case LazyNode.LazyNodeFields.ContainerType : Return "did/container/@type"
            Case LazyNode.LazyNodeFields.ContainerCustomType : Return String.Format("did/container[@type='{0}']", VisualFieldLabel("ContainerType.Other"))
        End Select
    End Function
#End Region


End Class






