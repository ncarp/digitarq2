
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

Imports System.Configuration
Imports System.io

Public Class ReportDataSetBuilder

    Public Shared Function GenerateFondsGuideReportData(ByVal LazyNodes As LazyNodeCollection)
        Dim FondsGuideDataSet As New FondsGuideDataSet
        Dim FondsLazyNode As LazyNode
        Dim FondsSubFondsItem As LazyNode
        Dim FondsSubFonds As LazyNodeCollection
        FondsGuideDataSet.Clear()
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Dim logoPath As String = CType(configurationAppSettings.GetValue("LogoPath", GetType(System.String)), String)
        Dim smallLogoPath As String = CType(configurationAppSettings.GetValue("SmallLogoPath", GetType(System.String)), String)

        If File.Exists(AppDomain.CurrentDomain.BaseDirectory & logoPath) Then
            Dim fs1, fs2 As FileStream
            Dim br1, br2 As BinaryReader
            Dim drow As DataRow
            fs1 = New FileStream(AppDomain.CurrentDomain.BaseDirectory & logoPath, FileMode.Open, FileAccess.Read)
            br1 = New BinaryReader(fs1)
            Dim imgbyte1(fs1.Length) As Byte
            imgbyte1 = br1.ReadBytes(Convert.ToInt32(fs1.Length))
            drow = FondsGuideDataSet.Logo.NewRow
            drow(0) = imgbyte1
            If File.Exists(AppDomain.CurrentDomain.BaseDirectory & smallLogoPath) Then
                fs2 = New FileStream(AppDomain.CurrentDomain.BaseDirectory & smallLogoPath, FileMode.Open, FileAccess.Read)
                br2 = New BinaryReader(fs2)
                Dim imgbyte2(fs2.Length) As Byte
                imgbyte2 = br2.ReadBytes(Convert.ToInt32(fs2.Length))
                drow(1) = imgbyte2
            End If
            FondsGuideDataSet.Logo.Rows.Add(drow)
            br1.Close()
            fs1.Close()
            br2.Close()
            fs2.Close()
        End If

        For Each FondsLazyNode In LazyNodes
            Dim iterator As New Iterator(FondsLazyNode)
            iterator.Start(iterator.Action.CollectFondsGuideData)
            FondsSubFonds = CType(iterator.Result, LazyNodeCollection)
            For Each FondsSubFondsItem In FondsSubFonds
                FondsGuideDataSet.Components.AddComponentsRow( _
                FondsSubFondsItem.UnitId, _
                FondsSubFondsItem.UnitTitle, _
                JustYearDate(FondsSubFondsItem.UnitDateInitial), _
                JustYearDate(FondsSubFondsItem.UnitDateFinal), _
                FondsSubFondsItem.OtherLevel, _
                FondsSubFondsItem.Dimensions.Trim, _
                FondsSubFondsItem.ExtentMl, _
                FondsSubFondsItem.BiogHist.Trim, _
                FondsSubFondsItem.AcqInfo.Trim, _
                FondsSubFondsItem.ScopeContent.Trim, _
                FondsSubFondsItem.AccessRestrict.Trim, _
                FondsSubFondsItem.PhysTech.Trim, _
                FondsSubFondsItem.RelatedMaterial.Trim, _
                FondsSubFondsItem.Bibliography.ToString().Trim, _
                FondsSubFondsItem.OtherFindAid.Trim, _
                VisualFieldLabel(FondsSubFondsItem.OtherLevel))
            Next
        Next
        Return FondsGuideDataSet
    End Function

    Public Shared Function GenerateInventoryReportData(ByVal LazyNodes As LazyNodeCollection)
        Dim DataSet As New InventoryDataSet
        Dim FondsLazyNode As LazyNode
        Dim FondsItems As LazyNodeCollection
        Dim Item As LazyNode

        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Dim logoPath As String = CType(configurationAppSettings.GetValue("LogoPath", GetType(System.String)), String)
        Dim smallLogoPath As String = CType(configurationAppSettings.GetValue("SmallLogoPath", GetType(System.String)), String)

        DataSet.Clear()

        If File.Exists(AppDomain.CurrentDomain.BaseDirectory & logoPath) Then
            Dim fs1, fs2 As FileStream
            Dim br1, br2 As BinaryReader
            Dim drow As DataRow
            fs1 = New FileStream(AppDomain.CurrentDomain.BaseDirectory & logoPath, FileMode.Open, FileAccess.Read)
            br1 = New BinaryReader(fs1)
            Dim imgbyte1(fs1.Length) As Byte
            imgbyte1 = br1.ReadBytes(Convert.ToInt32(fs1.Length))
            drow = DataSet.Logo.NewRow
            drow(0) = imgbyte1
            If File.Exists(AppDomain.CurrentDomain.BaseDirectory & smallLogoPath) Then
                fs2 = New FileStream(AppDomain.CurrentDomain.BaseDirectory & smallLogoPath, FileMode.Open, FileAccess.Read)
                br2 = New BinaryReader(fs2)
                Dim imgbyte2(fs2.Length) As Byte
                imgbyte2 = br2.ReadBytes(Convert.ToInt32(fs2.Length))
                drow(1) = imgbyte2
            End If
            DataSet.Logo.Rows.Add(drow)
            br1.Close()
            fs1.Close()
            br2.Close()
            fs2.Close()
        End If

        For Each FondsLazyNode In LazyNodes
            'FondsLazyNode.SortBy = LazyNode.SortingStyles.ByUnitID
            Dim iterator As New Iterator(FondsLazyNode)
            iterator.Start(iterator.Action.CollectInventoryData)
            FondsItems = CType(iterator.Result, LazyNodeCollection)
            For Each Item In FondsItems
                DataSet.Components.AddComponentsRow( _
                Item.UnitId, _
                Item.OtherLevel, _
                Item.UnitTitle, _
                JustYearDate(Item.UnitDateInitial), _
                JustYearDate(Item.UnitDateFinal), _
                Item.Dimensions, _
                Item.ExtentMl, _
                Item.BiogHist, _
                Item.ScopeContent, _
                Item.AccessRestrict, _
                Item.PhysTech, _
                Item.RelatedMaterial, _
                Item.Bibliography.ToString(), _
                VisualFieldLabel(Item.OtherLevel))
            Next
        Next
        Return DataSet
    End Function


    Public Shared Function GenerateIUInventoryReportData(ByVal LazyNodes As LazyNodeCollection)
        Dim DataSet As New CatalogDataSet
        Dim FondsLazyNode As LazyNode
        Dim FondsItems As LazyNodeCollection
        Dim Item As LazyNode

        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Dim logoPath As String = CType(configurationAppSettings.GetValue("LogoPath", GetType(System.String)), String)
        Dim smallLogoPath As String = CType(configurationAppSettings.GetValue("SmallLogoPath", GetType(System.String)), String)

        DataSet.Clear()

        If File.Exists(AppDomain.CurrentDomain.BaseDirectory & logoPath) Then
            Dim fs1, fs2 As FileStream
            Dim br1, br2 As BinaryReader
            Dim drow As DataRow
            fs1 = New FileStream(AppDomain.CurrentDomain.BaseDirectory & logoPath, FileMode.Open, FileAccess.Read)
            br1 = New BinaryReader(fs1)
            Dim imgbyte1(fs1.Length) As Byte
            imgbyte1 = br1.ReadBytes(Convert.ToInt32(fs1.Length))
            drow = DataSet.Logo.NewRow
            drow(0) = imgbyte1
            If File.Exists(AppDomain.CurrentDomain.BaseDirectory & smallLogoPath) Then
                fs2 = New FileStream(AppDomain.CurrentDomain.BaseDirectory & smallLogoPath, FileMode.Open, FileAccess.Read)
                br2 = New BinaryReader(fs2)
                Dim imgbyte2(fs2.Length) As Byte
                imgbyte2 = br2.ReadBytes(Convert.ToInt32(fs2.Length))
                drow(1) = imgbyte2
            End If
            DataSet.Logo.Rows.Add(drow)
            br1.Close()
            fs1.Close()
            br2.Close()
            fs2.Close()
        End If

        For Each FondsLazyNode In LazyNodes
            ' FondsLazyNode.SortBy = LazyNode.SortingStyles.ByUnitID
            Dim iterator As New Iterator(FondsLazyNode)
            iterator.Start(iterator.Action.CollectUIInventoryData)
            FondsItems = CType(iterator.Result, LazyNodeCollection)
            For Each Item In FondsItems
                DataSet.Components.AddComponentsRow( _
                Item.UnitId, _
                Item.OtherLevel, _
                Item.UnitTitle, _
                JustYearDate(Item.UnitDateInitial), _
                JustYearDate(Item.UnitDateFinal), _
                Item.Dimensions, _
                Nothing, _
                Nothing, _
                Item.ScopeContent, _
                Item.AccessRestrict, _
                Item.PhysTech, _
                Item.RelatedMaterial, _
                Item.Bibliography.ToString(), _
                VisualFieldLabel(Item.OtherLevel), _
                Item.OriginationAuthor.Replace(";", Chr(13)), _
                Item.OriginationAuthorAddress, _
                Item.UseRestrict, _
                Nothing, _
                Nothing, _
                Item.PhysLoc, _
                Nothing, _
                Item.OriginationNotary, _
                Item.OriginationScrivener, _
                Item.OriginationDestination, _
                Item.OriginationDestinationAddress)
            Next
        Next
        Return DataSet
    End Function


    Public Shared Function GenerateCatalogReportData(ByVal LazyNodes As LazyNodeCollection) As CatalogDataSet
        Dim DataSet As New CatalogDataSet
        Dim FondsLazyNode As LazyNode
        Dim FondsItems As LazyNodeCollection
        Dim Item As LazyNode
        Dim UnitDateInitial As String
        Dim UnitDateFinal As String

        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Dim logoPath As String = CType(configurationAppSettings.GetValue("LogoPath", GetType(System.String)), String)
        Dim smallLogoPath As String = CType(configurationAppSettings.GetValue("SmallLogoPath", GetType(System.String)), String)

        DataSet.Clear()

        If File.Exists(AppDomain.CurrentDomain.BaseDirectory & logoPath) Then
            Dim fs1, fs2 As FileStream
            Dim br1, br2 As BinaryReader
            Dim drow As DataRow
            fs1 = New FileStream(AppDomain.CurrentDomain.BaseDirectory & logoPath, FileMode.Open, FileAccess.Read)
            br1 = New BinaryReader(fs1)
            Dim imgbyte1(fs1.Length) As Byte
            imgbyte1 = br1.ReadBytes(Convert.ToInt32(fs1.Length))
            drow = DataSet.Logo.NewRow
            drow(0) = imgbyte1
            If File.Exists(AppDomain.CurrentDomain.BaseDirectory & smallLogoPath) Then
                fs2 = New FileStream(AppDomain.CurrentDomain.BaseDirectory & smallLogoPath, FileMode.Open, FileAccess.Read)
                br2 = New BinaryReader(fs2)
                Dim imgbyte2(fs2.Length) As Byte
                imgbyte2 = br2.ReadBytes(Convert.ToInt32(fs2.Length))
                drow(1) = imgbyte2
            End If
            DataSet.Logo.Rows.Add(drow)
            br1.Close()
            fs1.Close()
            br2.Close()
            fs2.Close()
        End If

        For Each FondsLazyNode In LazyNodes
            'FondsLazyNode.SortBy = LazyNode.SortingStyles.ByUnitID
            Dim iterator As New Iterator(FondsLazyNode)
            iterator.Start(iterator.Action.CollectCatalogData)
            FondsItems = CType(iterator.Result, LazyNodeCollection)
            For Each Item In FondsItems
                If Item.OtherLevel = EADDefinitions.OTHERLEVEL_DOCUMENT OrElse _
                   Item.OtherLevel = EADDefinitions.OTHERLEVEL_COMPOSEDDOCUMENT Then
                    ' put complete date in Docs
                    UnitDateInitial = Item.UnitDateInitial
                    UnitDateFinal = Item.UnitDateFinal
                Else
                    UnitDateInitial = JustYearDate(Item.UnitDateInitial)
                    UnitDateFinal = JustYearDate(Item.UnitDateFinal)
                End If
                If Item.OriginationDestination <> "" Then
                    Dim aa As String = "aa"
                End If
                DataSet.Components.AddComponentsRow( _
                   Item.UnitId, _
                   Item.OtherLevel, _
                   Item.UnitTitle, _
                   UnitDateInitial, _
                   UnitDateFinal, _
                   Item.Dimensions, _
                   Item.ExtentMl, _
                   Item.BiogHist, _
                   Item.ScopeContent, _
                   Item.AccessRestrict, _
                   Item.PhysTech, _
                   Item.RelatedMaterial, _
                   Item.Bibliography.ToString(), _
                   VisualFieldLabel(Item.OtherLevel), _
                   Item.OriginationAuthor.Replace(";", Chr(13)), _
                   Item.OriginationAuthorAddress, _
                   Item.UseRestrict, _
                   Item.LangMaterial, _
                   Item.PhysFacet, _
                   Item.PhysLoc, _
                   Item.AltFormAvail, _
                   Item.OriginationNotary.ToString, _
                   Item.OriginationScrivener.ToString, _
                   Item.OriginationDestination.ToString, _
                   Item.OriginationDestinationAddress.ToString)
            Next
        Next
        Return DataSet
    End Function



    Public Shared Function GenerateSeriesListData(ByVal LazyNodes As LazyNodeCollection)
        Dim DataSet As New ListDataSet
        Dim FondsLazyNode As LazyNode
        Dim Data As Hashtable
        Dim Item As LazyNode

        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Dim logoPath As String = CType(configurationAppSettings.GetValue("LogoPath", GetType(System.String)), String)
        Dim smallLogoPath As String = CType(configurationAppSettings.GetValue("SmallLogoPath", GetType(System.String)), String)

        DataSet.Clear()

        If File.Exists(AppDomain.CurrentDomain.BaseDirectory & logoPath) Then
            Dim fs1, fs2 As FileStream
            Dim br1, br2 As BinaryReader
            Dim drow As DataRow
            fs1 = New FileStream(AppDomain.CurrentDomain.BaseDirectory & logoPath, FileMode.Open, FileAccess.Read)
            br1 = New BinaryReader(fs1)
            Dim imgbyte1(fs1.Length) As Byte
            imgbyte1 = br1.ReadBytes(Convert.ToInt32(fs1.Length))
            drow = DataSet.Logo.NewRow
            drow(0) = imgbyte1
            If File.Exists(AppDomain.CurrentDomain.BaseDirectory & smallLogoPath) Then
                fs2 = New FileStream(AppDomain.CurrentDomain.BaseDirectory & smallLogoPath, FileMode.Open, FileAccess.Read)
                br2 = New BinaryReader(fs2)
                Dim imgbyte2(fs2.Length) As Byte
                imgbyte2 = br2.ReadBytes(Convert.ToInt32(fs2.Length))
                drow(1) = imgbyte2
            End If
            DataSet.Logo.Rows.Add(drow)
            br1.Close()
            fs1.Close()
            br2.Close()
            fs2.Close()
        End If

        For Each FondsLazyNode In LazyNodes
            'FondsLazyNode.SortBy = LazyNode.SortingStyles.ByUnitID
            Dim iterator As New Iterator(FondsLazyNode)
            iterator.Start(iterator.Action.CollectSeriesListData)
            Data = CType(iterator.Result, Hashtable)

            ' Include Fonds Node to show in report
            DataSet.Components.AddComponentsRow( _
            FondsLazyNode.UnitId, _
            FondsLazyNode.OtherLevel, _
            FondsLazyNode.UnitTitle, _
            JustYearDate(FondsLazyNode.UnitDateInitial), _
            JustYearDate(FondsLazyNode.UnitDateFinal), _
            Nothing, Nothing, Nothing, _
            VisualFieldLabel(FondsLazyNode.OtherLevel), _
            Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

            For Each Item In SortICollection(Data.Keys, "UnitId")
                DataSet.Components.AddComponentsRow( _
                Item.UnitId, _
                Item.OtherLevel, _
                Item.UnitTitle, _
                JustYearDate(FondsLazyNode.UnitDateInitial), _
                JustYearDate(FondsLazyNode.UnitDateFinal), _
                Nothing, _
                Item.ScopeContent, _
                Nothing, _
                VisualFieldLabel(Item.OtherLevel), _
                Nothing, _
                Nothing, _
                Nothing, _
                Nothing, _
                Nothing, _
                Nothing, _
                Nothing, _
                BuildParentsInformation(Data(Item)))
            Next
        Next
        Return DataSet
    End Function

    Public Shared Function GenerateInstalationUnitsListData(ByVal LazyNodes As LazyNodeCollection)
        Dim DataSet As New ListDataSet
        Dim FondsLazyNode As LazyNode
        Dim Data As Hashtable
        Dim Item As LazyNode

        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Dim logoPath As String = CType(configurationAppSettings.GetValue("LogoPath", GetType(System.String)), String)
        Dim smallLogoPath As String = CType(configurationAppSettings.GetValue("SmallLogoPath", GetType(System.String)), String)

        DataSet.Clear()

        If File.Exists(AppDomain.CurrentDomain.BaseDirectory & logoPath) Then
            Dim fs1, fs2 As FileStream
            Dim br1, br2 As BinaryReader
            Dim drow As DataRow
            fs1 = New FileStream(AppDomain.CurrentDomain.BaseDirectory & logoPath, FileMode.Open, FileAccess.Read)
            br1 = New BinaryReader(fs1)
            Dim imgbyte1(fs1.Length) As Byte
            imgbyte1 = br1.ReadBytes(Convert.ToInt32(fs1.Length))
            drow = DataSet.Logo.NewRow
            drow(0) = imgbyte1
            If File.Exists(AppDomain.CurrentDomain.BaseDirectory & smallLogoPath) Then
                fs2 = New FileStream(AppDomain.CurrentDomain.BaseDirectory & smallLogoPath, FileMode.Open, FileAccess.Read)
                br2 = New BinaryReader(fs2)
                Dim imgbyte2(fs2.Length) As Byte
                imgbyte2 = br2.ReadBytes(Convert.ToInt32(fs2.Length))
                drow(1) = imgbyte2
            End If
            DataSet.Logo.Rows.Add(drow)
            br1.Close()
            fs1.Close()
            br2.Close()
            fs2.Close()
        End If

        For Each FondsLazyNode In LazyNodes
            'FondsLazyNode.SortBy = LazyNode.SortingStyles.ByUnitID
            Dim iterator As New Iterator(FondsLazyNode)
            iterator.Start(iterator.Action.CollectInstalationUnitsListData)
            Data = CType(iterator.Result, Hashtable)

            ' Include Fonds Node to show in report
            DataSet.Components.AddComponentsRow( _
            FondsLazyNode.UnitId, _
            FondsLazyNode.OtherLevel, _
            FondsLazyNode.UnitTitle, _
            JustYearDate(FondsLazyNode.UnitDateInitial), _
            JustYearDate(FondsLazyNode.UnitDateFinal), _
            Nothing, Nothing, Nothing, _
            VisualFieldLabel(FondsLazyNode.OtherLevel), _
            Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)


            For Each Item In SortICollection(Data.Keys, "UnitId")
                DataSet.Components.AddComponentsRow( _
                Item.UnitId, _
                Item.OtherLevel, _
                Item.UnitTitle, _
                JustYearDate(Item.UnitDateInitial), _
                JustYearDate(Item.UnitDateFinal), _
                Nothing, _
                Item.ScopeContent, _
                Nothing, _
                VisualFieldLabel(Item.OtherLevel), _
                Nothing, _
                Item.PhysLoc, _
                Item.AltFormAvail, _
                Nothing, _
                Nothing, _
                Nothing, _
                Nothing, _
                BuildParentsInformation(Data(Item)))
                Debug.Write(Item.PhysLoc)
            Next
        Next
        Return DataSet
    End Function


    Public Shared Function GenerateInstalationUnitsBySeriesListData(ByVal LazyNodes As LazyNodeCollection)
        Dim DataSet As New ListDataSet
        Dim Data As Hashtable

        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Dim logoPath As String = CType(configurationAppSettings.GetValue("LogoPath", GetType(System.String)), String)
        Dim smallLogoPath As String = CType(configurationAppSettings.GetValue("SmallLogoPath", GetType(System.String)), String)

        DataSet.Clear()

        If File.Exists(AppDomain.CurrentDomain.BaseDirectory & logoPath) Then
            Dim fs1, fs2 As FileStream
            Dim br1, br2 As BinaryReader
            Dim drow As DataRow
            fs1 = New FileStream(AppDomain.CurrentDomain.BaseDirectory & logoPath, FileMode.Open, FileAccess.Read)
            br1 = New BinaryReader(fs1)
            Dim imgbyte1(fs1.Length) As Byte
            imgbyte1 = br1.ReadBytes(Convert.ToInt32(fs1.Length))
            drow = DataSet.Logo.NewRow
            drow(0) = imgbyte1
            If File.Exists(AppDomain.CurrentDomain.BaseDirectory & smallLogoPath) Then
                fs2 = New FileStream(AppDomain.CurrentDomain.BaseDirectory & smallLogoPath, FileMode.Open, FileAccess.Read)
                br2 = New BinaryReader(fs2)
                Dim imgbyte2(fs2.Length) As Byte
                imgbyte2 = br2.ReadBytes(Convert.ToInt32(fs2.Length))
                drow(1) = imgbyte2
            End If
            DataSet.Logo.Rows.Add(drow)
            br1.Close()
            fs1.Close()
            br2.Close()
            fs2.Close()
        End If

        For Each FondsLazyNode As LazyNode In LazyNodes
            'FondsLazyNode.SortBy = LazyNode.SortingStyles.ByUnitID
            Dim iterator As New Iterator(FondsLazyNode)
            iterator.Start(iterator.Action.CollectInstalationUnitsBySeriesListData)
            Data = CType(iterator.Result, Hashtable)

            ' Include Fonds Node to show in report
            DataSet.Components.AddComponentsRow( _
            FondsLazyNode.UnitId, _
            FondsLazyNode.OtherLevel, _
            FondsLazyNode.UnitTitle, _
            JustYearDate(FondsLazyNode.UnitDateInitial), _
            JustYearDate(FondsLazyNode.UnitDateFinal), _
            Nothing, Nothing, Nothing, _
            VisualFieldLabel(FondsLazyNode.OtherLevel), _
            Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

            For Each Item As LazyNode In SortICollection(Data.Keys, "UnitTitle")
                DataSet.Components.AddComponentsRow( _
                Item.UnitId, _
                Item.OtherLevel, _
                Item.UnitTitle, _
                JustYearDate(Item.UnitDateInitial), _
                JustYearDate(Item.UnitDateFinal), _
                Nothing, _
                Nothing, _
                Nothing, _
                VisualFieldLabel(Item.OtherLevel), _
                Nothing, _
                Nothing, _
                Nothing, _
                Nothing, _
                Nothing, _
                Nothing, _
                Nothing, _
                Nothing)

                For Each IUItem As LazyNode In SortICollection(CType(Data(Item), LazyNodeCollection), "UnitId")
                    DataSet.Components.AddComponentsRow( _
                    IUItem.UnitId, _
                    IUItem.OtherLevel, _
                    IUItem.UnitTitle, _
                    JustYearDate(IUItem.UnitDateInitial), _
                    JustYearDate(IUItem.UnitDateFinal), _
                    Nothing, _
                    Nothing, _
                    Nothing, _
                    Nothing, _
                    Nothing, _
                    IUItem.PhysLoc, _
                    Nothing, _
                    Nothing, _
                    Nothing, _
                    Nothing, _
                    Nothing, _
                    Nothing)
                Next
            Next
        Next
        Return DataSet
    End Function



    Public Shared Function GenerateClassificationPlanData(ByVal LazyNodes As LazyNodeCollection)
        Dim DataSet As New InventoryDataSet
        Dim FondsLazyNode As LazyNode
        Dim FondsItems As LazyNodeCollection
        Dim Item As LazyNode

        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Dim logoPath As String = CType(configurationAppSettings.GetValue("LogoPath", GetType(System.String)), String)
        Dim smallLogoPath As String = CType(configurationAppSettings.GetValue("SmallLogoPath", GetType(System.String)), String)

        DataSet.Clear()

        If File.Exists(AppDomain.CurrentDomain.BaseDirectory & logoPath) Then
            Dim fs1, fs2 As FileStream
            Dim br1, br2 As BinaryReader
            Dim drow As DataRow
            fs1 = New FileStream(AppDomain.CurrentDomain.BaseDirectory & logoPath, FileMode.Open, FileAccess.Read)
            br1 = New BinaryReader(fs1)
            Dim imgbyte1(fs1.Length) As Byte
            imgbyte1 = br1.ReadBytes(Convert.ToInt32(fs1.Length))
            drow = DataSet.Logo.NewRow
            drow(0) = imgbyte1
            If File.Exists(AppDomain.CurrentDomain.BaseDirectory & smallLogoPath) Then
                fs2 = New FileStream(AppDomain.CurrentDomain.BaseDirectory & smallLogoPath, FileMode.Open, FileAccess.Read)
                br2 = New BinaryReader(fs2)
                Dim imgbyte2(fs2.Length) As Byte
                imgbyte2 = br2.ReadBytes(Convert.ToInt32(fs2.Length))
                drow(1) = imgbyte2
            End If
            DataSet.Logo.Rows.Add(drow)
            br1.Close()
            fs1.Close()
            br2.Close()
            fs2.Close()
        End If

        For Each FondsLazyNode In LazyNodes
            'FondsLazyNode.SortBy = LazyNode.SortingStyles.ByUnitID

            Dim iterator As New Iterator(FondsLazyNode)
            iterator.Start(iterator.Action.CollectClassificationPlanData)
            FondsItems = CType(iterator.Result, LazyNodeCollection)
            For Each Item In FondsItems
                DataSet.Components.AddComponentsRow( _
                Item.UnitId, _
                Item.OtherLevel, _
                Item.UnitTitle, _
                JustYearDate(Item.UnitDateInitial), _
                JustYearDate(Item.UnitDateFinal), _
                Nothing, _
                Nothing, Nothing, Nothing, Nothing, _
                Nothing, Nothing, Nothing, VisualFieldLabel(Item.OtherLevel))
            Next
        Next
        Return DataSet
    End Function


    Public Shared Function GeneratePhysLocData(ByVal LazyNodes As LazyNodeCollection)
        Dim DataSet As New PhysLocDataSet
        Dim FondsLazyNode As LazyNode
        Dim FondsItems As LazyNodeCollection
        Dim Item As LazyNode

        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Dim logoPath As String = CType(configurationAppSettings.GetValue("LogoPath", GetType(System.String)), String)
        Dim smallLogoPath As String = CType(configurationAppSettings.GetValue("SmallLogoPath", GetType(System.String)), String)

        DataSet.Clear()

        If File.Exists(AppDomain.CurrentDomain.BaseDirectory & logoPath) Then
            Dim fs1, fs2 As FileStream
            Dim br1, br2 As BinaryReader
            Dim drow As DataRow
            fs1 = New FileStream(AppDomain.CurrentDomain.BaseDirectory & logoPath, FileMode.Open, FileAccess.Read)
            br1 = New BinaryReader(fs1)
            Dim imgbyte1(fs1.Length) As Byte
            imgbyte1 = br1.ReadBytes(Convert.ToInt32(fs1.Length))
            drow = DataSet.Logo.NewRow
            drow(0) = imgbyte1
            If File.Exists(AppDomain.CurrentDomain.BaseDirectory & smallLogoPath) Then
                fs2 = New FileStream(AppDomain.CurrentDomain.BaseDirectory & smallLogoPath, FileMode.Open, FileAccess.Read)
                br2 = New BinaryReader(fs2)
                Dim imgbyte2(fs2.Length) As Byte
                imgbyte2 = br2.ReadBytes(Convert.ToInt32(fs2.Length))
                drow(1) = imgbyte2
            End If
            DataSet.Logo.Rows.Add(drow)
            br1.Close()
            fs1.Close()
            br2.Close()
            fs2.Close()
        End If

        For Each Item In LazyNodes
            DataSet.Components.AddComponentsRow( _
                  Item.UnitId, _
                  Item.OtherLevel, _
                  Item.UnitTitle, _
                  VisualFieldLabel(Item.OtherLevel), _
                  CheckForContents(Item.PhysLoc))
        Next

        Return DataSet
    End Function


    Public Shared Function GenerateAllControlAccessData()
        Dim DataSet As New ControlAccessDataSet
        Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")
        Dim Types As ControlAccessTypeCollection
        Dim ControlAccessItems As ControlAccessItemCollection

        Dim TypeItem As ControlAccessTypeItem
        Dim ControlAccessItem As ControlAccessItemItem

        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Dim logoPath As String = CType(configurationAppSettings.GetValue("LogoPath", GetType(System.String)), String)
        Dim smallLogoPath As String = CType(configurationAppSettings.GetValue("SmallLogoPath", GetType(System.String)), String)

        Types = SQLLazyNode.GetControlAccessTypeList(SQLServerSettings.Item("ServerAddress"), _
                                                     SQLServerSettings.Item("Database"), _
                                                     SQLServerSettings.Item("Username"), _
                                                     SQLServerSettings.Item("Password"))

        DataSet.Clear()

        If File.Exists(AppDomain.CurrentDomain.BaseDirectory & logoPath) Then
            Dim fs1, fs2 As FileStream
            Dim br1, br2 As BinaryReader
            Dim drow As DataRow
            fs1 = New FileStream(AppDomain.CurrentDomain.BaseDirectory & logoPath, FileMode.Open, FileAccess.Read)
            br1 = New BinaryReader(fs1)
            Dim imgbyte1(fs1.Length) As Byte
            imgbyte1 = br1.ReadBytes(Convert.ToInt32(fs1.Length))
            drow = DataSet.Logo.NewRow
            drow(0) = imgbyte1
            If File.Exists(AppDomain.CurrentDomain.BaseDirectory & smallLogoPath) Then
                fs2 = New FileStream(AppDomain.CurrentDomain.BaseDirectory & smallLogoPath, FileMode.Open, FileAccess.Read)
                br2 = New BinaryReader(fs2)
                Dim imgbyte2(fs2.Length) As Byte
                imgbyte2 = br2.ReadBytes(Convert.ToInt32(fs2.Length))
                drow(1) = imgbyte2
            End If
            DataSet.Logo.Rows.Add(drow)
            br1.Close()
            fs1.Close()
            br2.Close()
            fs2.Close()
        End If

        For Each TypeItem In Types
            DataSet.ControlAccessItem.AddControlAccessItemRow(TypeItem.Type, "", Nothing)

            ControlAccessItems = SQLLazyNode.GetControlAccessItemList(SQLServerSettings.Item("ServerAddress"), _
                                                                 SQLServerSettings.Item("Database"), _
                                                                 SQLServerSettings.Item("Username"), _
                                                                 SQLServerSettings.Item("Password"), _
                                                                 TypeItem.ID)
            For Each ControlAccessItem In ControlAccessItems
                DataSet.ControlAccessItem.AddControlAccessItemRow("", ControlAccessItem.Item, Nothing)
            Next
        Next
        Return DataSet
    End Function


    Public Shared Function GenerateControlAccessData(ByVal LazyNodes As LazyNodeCollection)
        Dim DataSet As New ControlAccessDataSet
        Dim SQLServerSettings As Hashtable = ConfigurationManager.GetSection("sqlServerSettings")
        Dim Types As ControlAccessTypeCollection
        Dim ControlAccessItems As ControlAccessItemCollection

        Dim TypeItem As ControlAccessTypeItem
        Dim ControlAccessItem As ControlAccessItemItem
        Dim FondsLazyNode As LazyNode

        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Dim logoPath As String = CType(configurationAppSettings.GetValue("LogoPath", GetType(System.String)), String)
        Dim smallLogoPath As String = CType(configurationAppSettings.GetValue("SmallLogoPath", GetType(System.String)), String)

        Types = SQLLazyNode.GetControlAccessTypeList(SQLServerSettings.Item("ServerAddress"), _
                                                     SQLServerSettings.Item("Database"), _
                                                     SQLServerSettings.Item("Username"), _
                                                     SQLServerSettings.Item("Password"))

        DataSet.Clear()

        If File.Exists(AppDomain.CurrentDomain.BaseDirectory & logoPath) Then
            Dim fs1, fs2 As FileStream
            Dim br1, br2 As BinaryReader
            Dim drow As DataRow
            fs1 = New FileStream(AppDomain.CurrentDomain.BaseDirectory & logoPath, FileMode.Open, FileAccess.Read)
            br1 = New BinaryReader(fs1)
            Dim imgbyte1(fs1.Length) As Byte
            imgbyte1 = br1.ReadBytes(Convert.ToInt32(fs1.Length))
            drow = DataSet.Logo.NewRow
            drow(0) = imgbyte1
            If File.Exists(AppDomain.CurrentDomain.BaseDirectory & smallLogoPath) Then
                fs2 = New FileStream(AppDomain.CurrentDomain.BaseDirectory & smallLogoPath, FileMode.Open, FileAccess.Read)
                br2 = New BinaryReader(fs2)
                Dim imgbyte2(fs2.Length) As Byte
                imgbyte2 = br2.ReadBytes(Convert.ToInt32(fs2.Length))
                drow(1) = imgbyte2
            End If
            DataSet.Logo.Rows.Add(drow)
            br1.Close()
            fs1.Close()
            br2.Close()
            fs2.Close()
        End If

        For Each FondsLazyNode In LazyNodes
            DataSet.ControlAccessItem.AddControlAccessItemRow(Nothing, Nothing, FondsLazyNode.UnitId & " " & FondsLazyNode.UnitTitle)
            ControlAccessItems = SQLLazyNode.GetControlAccessItemListInFonds(SQLServerSettings.Item("ServerAddress"), _
                                                                 SQLServerSettings.Item("Database"), _
                                                                 SQLServerSettings.Item("Username"), _
                                                                 SQLServerSettings.Item("Password"), _
                                                                 FondsLazyNode.ID)
            For Each ControlAccessItem In ControlAccessItems
                DataSet.ControlAccessItem.AddControlAccessItemRow(ControlAccessItem.Type, ControlAccessItem.Item, Nothing)
            Next
        Next

        Return DataSet
    End Function



    Public Shared Function GenerateAuthorsListData(ByVal LazyNodes As LazyNodeCollection)
        Dim DataSet As New ListDataSet
        Dim FondsLazyNode As LazyNode
        Dim Data As Collection

        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Dim logoPath As String = CType(configurationAppSettings.GetValue("LogoPath", GetType(System.String)), String)
        Dim smallLogoPath As String = CType(configurationAppSettings.GetValue("SmallLogoPath", GetType(System.String)), String)

        DataSet.Clear()

        If File.Exists(AppDomain.CurrentDomain.BaseDirectory & logoPath) Then
            Dim fs1, fs2 As FileStream
            Dim br1, br2 As BinaryReader
            Dim drow As DataRow
            fs1 = New FileStream(AppDomain.CurrentDomain.BaseDirectory & logoPath, FileMode.Open, FileAccess.Read)
            br1 = New BinaryReader(fs1)
            Dim imgbyte1(fs1.Length) As Byte
            imgbyte1 = br1.ReadBytes(Convert.ToInt32(fs1.Length))
            drow = DataSet.Logo.NewRow
            drow(0) = imgbyte1
            If File.Exists(AppDomain.CurrentDomain.BaseDirectory & smallLogoPath) Then
                fs2 = New FileStream(AppDomain.CurrentDomain.BaseDirectory & smallLogoPath, FileMode.Open, FileAccess.Read)
                br2 = New BinaryReader(fs2)
                Dim imgbyte2(fs2.Length) As Byte
                imgbyte2 = br2.ReadBytes(Convert.ToInt32(fs2.Length))
                drow(1) = imgbyte2
            End If
            DataSet.Logo.Rows.Add(drow)
            br1.Close()
            fs1.Close()
            br2.Close()
            fs2.Close()
        End If

        For Each FondsLazyNode In LazyNodes
            ' FondsLazyNode.SortBy = LazyNode.SortingStyles.ByUnitID
            Dim iterator As New Iterator(FondsLazyNode)
            iterator.Start(iterator.Action.CollectAuthorsListData)
            Data = CType(iterator.Result, Collection)

            ' Include Fonds Node to show in report
            DataSet.Components.AddComponentsRow( _
            FondsLazyNode.UnitId, _
            FondsLazyNode.OtherLevel, _
            FondsLazyNode.UnitTitle, _
            JustYearDate(FondsLazyNode.UnitDateInitial), _
            JustYearDate(FondsLazyNode.UnitDateFinal), _
            Nothing, Nothing, Nothing, _
            VisualFieldLabel(FondsLazyNode.OtherLevel), _
            Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

            Dim Reference As String
            Dim Authors As String()
            For Each Author As AuthorItem In SortICollection(Data, "OriginationAuthor")
                'Authors = Item.OriginationAuthor.Split(";")

                'For Each Author As String In Authors
                DataSet.Components.AddComponentsRow( _
                Author.CompleteUnitId, _
                "###", _
                Nothing, _
                JustYearDate(Author.UnitDateInitial), _
                JustYearDate(Author.UnitDateFinal), _
                Nothing, _
                Nothing, _
                Nothing, _
                Nothing, _
                Nothing, _
                Author.PhysLoc, _
                Nothing, _
                Nothing, _
                Nothing, _
                Author.OriginationAuthor, _
                Nothing, _
                Nothing)

                'Next
            Next
        Next
        Return DataSet
    End Function


    ' added by lmferros
    Public Shared Function GenerateCountElementsData(ByVal LazyNodes As LazyNodeCollection) As CountElements
        Dim DataSet As New CountElements
        Dim FondsLazyNode As LazyNode
        Dim FondsItems As LazyNodeCollection
        Dim Item As LazyNode

        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Dim logoPath As String = CType(configurationAppSettings.GetValue("LogoPath", GetType(System.String)), String)
        Dim smallLogoPath As String = CType(configurationAppSettings.GetValue("SmallLogoPath", GetType(System.String)), String)

        DataSet.Clear()

        If File.Exists(AppDomain.CurrentDomain.BaseDirectory & logoPath) Then
            Dim fs1, fs2 As FileStream
            Dim br1, br2 As BinaryReader
            Dim drow As DataRow
            fs1 = New FileStream(AppDomain.CurrentDomain.BaseDirectory & logoPath, FileMode.Open, FileAccess.Read)
            br1 = New BinaryReader(fs1)
            Dim imgbyte1(fs1.Length) As Byte
            imgbyte1 = br1.ReadBytes(Convert.ToInt32(fs1.Length))
            drow = DataSet.Logo.NewRow
            drow(0) = imgbyte1
            If File.Exists(AppDomain.CurrentDomain.BaseDirectory & smallLogoPath) Then
                fs2 = New FileStream(AppDomain.CurrentDomain.BaseDirectory & smallLogoPath, FileMode.Open, FileAccess.Read)
                br2 = New BinaryReader(fs2)
                Dim imgbyte2(fs2.Length) As Byte
                imgbyte2 = br2.ReadBytes(Convert.ToInt32(fs2.Length))
                drow(1) = imgbyte2
            End If
            DataSet.Logo.Rows.Add(drow)
            br1.Close()
            fs1.Close()
            br2.Close()
            fs2.Close()
        End If

        For Each FondsLazyNode In LazyNodes

            Dim iterator As New Iterator(FondsLazyNode)
            Dim res = iterator.Start(iterator.Action.CountNodesByOtherLevel)
            Dim result As New Hashtable
            result = GeneNodeCounterPro.AddResults(result, res)

            Dim total As Integer = 0
            Dim keys() As String = {"F", "SF", "SC", "SSC", "SSSC", "SR", "SSR", "UI", "DC", "D"}
            For i As Integer = 0 To keys.Length - 1
                If result.ContainsKey(keys(i)) Then
                    total += result(keys(i))
                Else
                    result.Add(keys(i), Nothing)
                End If
            Next

            DataSet.CountElements.AddCountElementsRow( _
                result.Item("F"), _
                result.Item("SF"), _
                result.Item("SC"), _
                result.Item("SSC"), _
                result.Item("SSSC"), _
                result.Item("SR"), _
                result.Item("SSR"), _
                result.Item("UI"), _
                result.Item("DC"), _
                result.Item("D"), _
                total, _
                FondsLazyNode.CompleteUnitId, _
                FondsLazyNode.UnitTitle)
        Next
        Return DataSet
    End Function


#Region "Auxiliary Functions "

    Private Shared Function BuildParentsInformation(ByVal Parents As LazyNodeCollection) As String
        Dim Parent As LazyNode
        Dim Result As String = ""
        For i As Integer = 0 To Parents.Count - 1
            Parent = Parents(i)
            Dim Reference As String
            If Parent.CompleteUnitId.Length = 0 Then
                Reference = Parent.CalculateCompleteUnitId
            Else
                Reference = Parent.CompleteUnitId
            End If
            Result &= String.Format("{0} {1}" & ControlChars.NewLine, VisualFieldLabel(Parent.OtherLevel), Reference)
            'If i < Parents.Count - 1 Then Result &= ", "
        Next
        Return Result
    End Function


    Public Shared Function CheckForContents(ByVal str As String) As String
        str = str.Trim
        If str.Length = 0 Then
            'Return VisualFieldLabel("Report.InfoNotAvailable")
            Return "-"
        Else
            Return str
        End If
    End Function


    Private Shared Function JustYearDate(ByVal DateStr As String) As String
        If DateStr = "0000-00-00" Then Return ""
        Dim SplitDate As String() = DateStr.Split("-")
        If SplitDate.Length >= 1 Then Return SplitDate.GetValue(0) Else Return ""
    End Function

    Private Shared Function JustValidDate(ByVal DateStr As String) As String
        If DateStr = "0000-00-00" Then Return "" Else Return DateStr
    End Function

#End Region



End Class
