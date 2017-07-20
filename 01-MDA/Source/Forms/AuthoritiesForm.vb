
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
Imports System.IO
Imports System.Xml.Xsl
Imports System.Xml
Imports System.Xml.XPath


Public Class AuthoritiesForm
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
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents FondsIcon As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents AddType As System.Windows.Forms.Button
    Friend WithEvents ControlAccessTypeHeader As System.Windows.Forms.ColumnHeader
    Friend WithEvents ControlAccessTypeIDHeader As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblReference As System.Windows.Forms.Label
    Friend WithEvents lblEacHeaderType As System.Windows.Forms.Label
    Friend WithEvents Type As System.Windows.Forms.TextBox
    Friend WithEvents TabControlAuthorities As System.Windows.Forms.TabControl
    Friend WithEvents tpMaintenanceHistory As System.Windows.Forms.TabPage
    Friend WithEvents lvMainHistory As System.Windows.Forms.ListView
    Friend WithEvents txtMainDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtMainDate As System.Windows.Forms.TextBox
    Friend WithEvents cbMainType As System.Windows.Forms.ComboBox
    Friend WithEvents txtMainName As System.Windows.Forms.TextBox
    Friend WithEvents btnExportEAC As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader28 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader29 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader30 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader31 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader32 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader33 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader34 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader35 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader36 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader37 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader49 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader50 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader51 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader52 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader53 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader54 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader55 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpMuseologicRelationships As System.Windows.Forms.TabPage
    Friend WithEvents cbResType As System.Windows.Forms.ComboBox
    Friend WithEvents txtResRelDate As System.Windows.Forms.TextBox
    Friend WithEvents cbResRelType As System.Windows.Forms.ComboBox
    Friend WithEvents lvResourceRelationships As System.Windows.Forms.ListView
    Friend WithEvents txtResUnit As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader21 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader22 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader23 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader24 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader25 As System.Windows.Forms.ColumnHeader
    Friend WithEvents tpFondsRelationships As System.Windows.Forms.TabPage
    Friend WithEvents txtFondsRelDescNote As System.Windows.Forms.TextBox
    Friend WithEvents btnListFonds As System.Windows.Forms.Button
    Friend WithEvents txtFondsRelUnitDateFinal As System.Windows.Forms.TextBox
    Friend WithEvents txtFondsRelUnitDateInitial As System.Windows.Forms.TextBox
    Friend WithEvents txtFondsRelUnitTitle As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtFondsRelRepository As System.Windows.Forms.TextBox
    Friend WithEvents txtFondsRelDate As System.Windows.Forms.TextBox
    Friend WithEvents cbFondsRelType As System.Windows.Forms.ComboBox
    Friend WithEvents txtFondSRelUnitId As System.Windows.Forms.TextBox
    Friend WithEvents btnAddFondsRel As System.Windows.Forms.Button
    Friend WithEvents btnRemoveFondsRel As System.Windows.Forms.Button
    Friend WithEvents lvFondsRelationships As System.Windows.Forms.ListView
    Friend WithEvents txtOwnerCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCountryCode As System.Windows.Forms.TextBox
    Friend WithEvents cbDetailLevel As System.Windows.Forms.ComboBox
    Friend WithEvents cbIdentityType As System.Windows.Forms.ComboBox
    Friend WithEvents lvIdentity As System.Windows.Forms.ListView
    Friend WithEvents txtPart As System.Windows.Forms.TextBox
    Friend WithEvents txtUseDate As System.Windows.Forms.TextBox
    Friend WithEvents tpEacRelationships As System.Windows.Forms.TabPage
    Friend WithEvents cbEacType As System.Windows.Forms.ComboBox
    Friend WithEvents txtEacRelPlace As System.Windows.Forms.TextBox
    Friend WithEvents txtEacRelDescNote As System.Windows.Forms.TextBox
    Friend WithEvents cbEacRelType As System.Windows.Forms.ComboBox
    Friend WithEvents txtEacRelName As System.Windows.Forms.TextBox
    Friend WithEvents lvEacRelationships As System.Windows.Forms.ListView
    Friend WithEvents txtActualPart As System.Windows.Forms.TextBox
    Friend WithEvents txtActualUseDate As System.Windows.Forms.TextBox
    Friend WithEvents cbType As System.Windows.Forms.ComboBox
    Friend WithEvents txtSysKey As System.Windows.Forms.TextBox
    Friend WithEvents tpAuthoritiesIdentity As System.Windows.Forms.TabPage
    Friend WithEvents tpAuthoritiesDescription As System.Windows.Forms.TabPage
    Friend WithEvents lvLanguangeDecl As System.Windows.Forms.ListView
    Friend WithEvents ColLangDeclID As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColLanguageDeclaration As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtLanguage As System.Windows.Forms.TextBox
    Friend WithEvents txtLegalId As System.Windows.Forms.TextBox
    Friend WithEvents txtPlace As System.Windows.Forms.TextBox
    Friend WithEvents txtRules As System.Windows.Forms.TextBox
    Friend WithEvents txtLegalStatus As System.Windows.Forms.TextBox
    Friend WithEvents cbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents txtBiogHist As System.Windows.Forms.TextBox
    Friend WithEvents txtEnv As System.Windows.Forms.TextBox
    Friend WithEvents txtAssetStruct As System.Windows.Forms.TextBox
    Friend WithEvents txtFunActDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtEacRelDate As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents AuthoritieslblLegalId As System.Windows.Forms.Label
    Friend WithEvents AuthoritieslblActualPart As System.Windows.Forms.Label
    Friend WithEvents AuthoritieslblActualUseDate As System.Windows.Forms.Label
    Friend WithEvents AuthoritieslblActualType As System.Windows.Forms.Label
    Friend WithEvents AuthoritieslblSysKey As System.Windows.Forms.Label
    Friend WithEvents AuthoritieslblType As System.Windows.Forms.Label
    Friend WithEvents AuthoritieslblPart As System.Windows.Forms.Label
    Friend WithEvents AuthoritieslblUseDate As System.Windows.Forms.Label
    Friend WithEvents AuthoritiescolID As System.Windows.Forms.ColumnHeader
    Friend WithEvents AuthoritiescolParallelName As System.Windows.Forms.ColumnHeader
    Friend WithEvents AuthoritiescolPart As System.Windows.Forms.ColumnHeader
    Friend WithEvents AuthoritiescolUseDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents AuthoritiesgbPrimaryName As System.Windows.Forms.GroupBox
    Friend WithEvents AuthoritiesgbParallelName As System.Windows.Forms.GroupBox
    Friend WithEvents AuthoritiesdbLanguageDecl As System.Windows.Forms.GroupBox
    Friend WithEvents AuthoritieslblLanguage As System.Windows.Forms.Label
    Friend WithEvents AuthoritiesgbControlInformation As System.Windows.Forms.GroupBox
    Friend WithEvents AuthoritieslblRules As System.Windows.Forms.Label
    Friend WithEvents AuthoritieslblStatus As System.Windows.Forms.Label
    Friend WithEvents AuthoritieslblCountryCode As System.Windows.Forms.Label
    Friend WithEvents AuthoritieslblOwnerCode As System.Windows.Forms.Label
    Friend WithEvents AuthoritieslblDetailLevel As System.Windows.Forms.Label
    Friend WithEvents AuthoritieslblEnv As System.Windows.Forms.Label
    Friend WithEvents AuthoritieslblAssetStruct As System.Windows.Forms.Label
    Friend WithEvents AuthoritieslblFunActDesc As System.Windows.Forms.Label
    Friend WithEvents AuthoritieslblLegalStatus As System.Windows.Forms.Label
    Friend WithEvents AuthoritieslblPlace As System.Windows.Forms.Label
    Friend WithEvents AuthoritieslblBiogHist As System.Windows.Forms.Label
    Friend WithEvents AuthoritiesgbEvent As System.Windows.Forms.GroupBox
    Friend WithEvents AuthoritieslblMainDate As System.Windows.Forms.Label
    Friend WithEvents AuthoritieslblMainType As System.Windows.Forms.Label
    Friend WithEvents AuthoritieslblMainName As System.Windows.Forms.Label
    Friend WithEvents AuthoritieslblMainDesc As System.Windows.Forms.Label
    Friend WithEvents AuthoritiescolMainID As System.Windows.Forms.ColumnHeader
    Friend WithEvents AuthoritiescolMainType As System.Windows.Forms.ColumnHeader
    Friend WithEvents AuthoritiescolMainName As System.Windows.Forms.ColumnHeader
    Friend WithEvents AuthoritiescolMainDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents AuthoritiescolMainDesc As System.Windows.Forms.ColumnHeader
    Friend WithEvents AuthoritiesgbLinking As System.Windows.Forms.GroupBox
    Friend WithEvents AuthoritiesTypeRel As System.Windows.Forms.Label
    Friend WithEvents AuthoritieslblDateRel As System.Windows.Forms.Label
    Friend WithEvents AuthoritieslblRelation As System.Windows.Forms.Label
    Friend WithEvents AuthoritieslblReference As System.Windows.Forms.Label
    Friend WithEvents AuthoritiescolResID As System.Windows.Forms.ColumnHeader
    Friend WithEvents AuthoritiescolResRelType As System.Windows.Forms.ColumnHeader
    Friend WithEvents AuthoritiescolResDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents AuthoritiescolResType As System.Windows.Forms.ColumnHeader
    Friend WithEvents AuthoritiescolResReference As System.Windows.Forms.ColumnHeader
    Friend WithEvents AuthoritiesgbLinkingArch As System.Windows.Forms.GroupBox
    Friend WithEvents AuthoritieslblRelNotesArch As System.Windows.Forms.Label
    Friend WithEvents AuthoritieslblRepository As System.Windows.Forms.Label
    Friend WithEvents AuthoritieslblDatesArch As System.Windows.Forms.Label
    Friend WithEvents AuthoritiesRelDateArch As System.Windows.Forms.Label
    Friend WithEvents AuthoritieslblRelArch As System.Windows.Forms.Label
    Friend WithEvents AuthoritieslblRefArch As System.Windows.Forms.Label
    Friend WithEvents AuthoritiesColLinkArchId As System.Windows.Forms.ColumnHeader
    Friend WithEvents AuthoritiesColLinkArchRelType As System.Windows.Forms.ColumnHeader
    Friend WithEvents AuthoritiesColLinkArchRelDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents AuthoritiesColLinkArchReference As System.Windows.Forms.ColumnHeader
    Friend WithEvents AuthoritiesColLinkArchUnitTitle As System.Windows.Forms.ColumnHeader
    Friend WithEvents AuthoritiesColLinkArchInitialDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents AuthoritiesColLinkArchFinalDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents AuthoritiesColLinkArchRepository As System.Windows.Forms.ColumnHeader
    Friend WithEvents AuthoritiesColLinkArchRelNote As System.Windows.Forms.ColumnHeader
    Friend WithEvents AuthoritiesgbRelationships As System.Windows.Forms.GroupBox
    Friend WithEvents AuthoritieslblRelPlace As System.Windows.Forms.Label
    Friend WithEvents AuthoritieslblRelNote As System.Windows.Forms.Label
    Friend WithEvents AuthoritieslblRelDate As System.Windows.Forms.Label
    Friend WithEvents AuthoritieslblRelType As System.Windows.Forms.Label
    Friend WithEvents AuthoritieslblRelEntType As System.Windows.Forms.Label
    Friend WithEvents AuthoritieslblRelEntTitle As System.Windows.Forms.Label
    Friend WithEvents AuthoritiesColRelId As System.Windows.Forms.ColumnHeader
    Friend WithEvents AuthoritiesColRelRelType As System.Windows.Forms.ColumnHeader
    Friend WithEvents AuthoritiesColRelDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents AuthoritiesColRelEntType As System.Windows.Forms.ColumnHeader
    Friend WithEvents AuthoritiesColRelEntTitle As System.Windows.Forms.ColumnHeader
    Friend WithEvents AuthoritiesColRelPlace As System.Windows.Forms.ColumnHeader
    Friend WithEvents AuthoritiesColRelNote As System.Windows.Forms.ColumnHeader
    Friend WithEvents tpAuthoritiesLinks As System.Windows.Forms.TabPage
    Friend WithEvents tpAuthoritiesControl As System.Windows.Forms.TabPage
    Friend WithEvents btnAddIdentity As mkccontrols.windows.forms.control.mkc_Button
    Friend WithEvents btnRemoveIdentity As mkccontrols.windows.forms.control.mkc_Button
    Friend WithEvents btnAddLanguage As mkccontrols.windows.forms.control.mkc_Button
    Friend WithEvents btnRemoveLanguage As mkccontrols.windows.forms.control.mkc_Button
    Friend WithEvents btnAddEacRel As mkccontrols.windows.forms.control.mkc_Button
    Friend WithEvents btnRemoveEacRel As mkccontrols.windows.forms.control.mkc_Button
    Friend WithEvents btnAddResRel As mkccontrols.windows.forms.control.mkc_Button
    Friend WithEvents btnRemoveResRel As mkccontrols.windows.forms.control.mkc_Button
    Friend WithEvents btnAddMainHistory As mkccontrols.windows.forms.control.mkc_Button
    Friend WithEvents btnRemoveMainHistory As mkccontrols.windows.forms.control.mkc_Button
    Friend WithEvents imglButtons As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AuthoritiesForm))
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnCancel = New System.Windows.Forms.Button
        Me.imglButtons = New System.Windows.Forms.ImageList(Me.components)
        Me.btnOk = New System.Windows.Forms.Button
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.btnExportEAC = New System.Windows.Forms.Button
        Me.FondsIcon = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TabControlAuthorities = New System.Windows.Forms.TabControl
        Me.tpAuthoritiesIdentity = New System.Windows.Forms.TabPage
        Me.AuthoritiesgbPrimaryName = New System.Windows.Forms.GroupBox
        Me.txtLegalId = New System.Windows.Forms.TextBox
        Me.AuthoritieslblLegalId = New System.Windows.Forms.Label
        Me.AuthoritieslblActualPart = New System.Windows.Forms.Label
        Me.txtActualPart = New System.Windows.Forms.TextBox
        Me.txtActualUseDate = New System.Windows.Forms.TextBox
        Me.AuthoritieslblActualUseDate = New System.Windows.Forms.Label
        Me.cbType = New System.Windows.Forms.ComboBox
        Me.AuthoritieslblActualType = New System.Windows.Forms.Label
        Me.txtSysKey = New System.Windows.Forms.TextBox
        Me.AuthoritieslblSysKey = New System.Windows.Forms.Label
        Me.AuthoritiesgbParallelName = New System.Windows.Forms.GroupBox
        Me.btnRemoveIdentity = New mkccontrols.windows.forms.control.mkc_Button
        Me.btnAddIdentity = New mkccontrols.windows.forms.control.mkc_Button
        Me.cbIdentityType = New System.Windows.Forms.ComboBox
        Me.AuthoritieslblType = New System.Windows.Forms.Label
        Me.lvIdentity = New System.Windows.Forms.ListView
        Me.AuthoritiescolID = New System.Windows.Forms.ColumnHeader
        Me.AuthoritiescolParallelName = New System.Windows.Forms.ColumnHeader
        Me.AuthoritiescolPart = New System.Windows.Forms.ColumnHeader
        Me.AuthoritiescolUseDate = New System.Windows.Forms.ColumnHeader
        Me.AuthoritieslblPart = New System.Windows.Forms.Label
        Me.txtPart = New System.Windows.Forms.TextBox
        Me.txtUseDate = New System.Windows.Forms.TextBox
        Me.AuthoritieslblUseDate = New System.Windows.Forms.Label
        Me.tpAuthoritiesLinks = New System.Windows.Forms.TabPage
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tpMuseologicRelationships = New System.Windows.Forms.TabPage
        Me.btnRemoveResRel = New mkccontrols.windows.forms.control.mkc_Button
        Me.AuthoritiesgbLinking = New System.Windows.Forms.GroupBox
        Me.btnAddResRel = New mkccontrols.windows.forms.control.mkc_Button
        Me.AuthoritiesTypeRel = New System.Windows.Forms.Label
        Me.cbResType = New System.Windows.Forms.ComboBox
        Me.AuthoritieslblDateRel = New System.Windows.Forms.Label
        Me.txtResRelDate = New System.Windows.Forms.TextBox
        Me.AuthoritieslblRelation = New System.Windows.Forms.Label
        Me.cbResRelType = New System.Windows.Forms.ComboBox
        Me.txtResUnit = New System.Windows.Forms.TextBox
        Me.AuthoritieslblReference = New System.Windows.Forms.Label
        Me.lvResourceRelationships = New System.Windows.Forms.ListView
        Me.AuthoritiescolResID = New System.Windows.Forms.ColumnHeader
        Me.AuthoritiescolResRelType = New System.Windows.Forms.ColumnHeader
        Me.AuthoritiescolResDate = New System.Windows.Forms.ColumnHeader
        Me.AuthoritiescolResType = New System.Windows.Forms.ColumnHeader
        Me.AuthoritiescolResReference = New System.Windows.Forms.ColumnHeader
        Me.tpFondsRelationships = New System.Windows.Forms.TabPage
        Me.AuthoritiesgbLinkingArch = New System.Windows.Forms.GroupBox
        Me.AuthoritieslblRelNotesArch = New System.Windows.Forms.Label
        Me.txtFondsRelDescNote = New System.Windows.Forms.TextBox
        Me.btnListFonds = New System.Windows.Forms.Button
        Me.AuthoritieslblRepository = New System.Windows.Forms.Label
        Me.txtFondsRelUnitDateFinal = New System.Windows.Forms.TextBox
        Me.txtFondsRelUnitDateInitial = New System.Windows.Forms.TextBox
        Me.AuthoritieslblDatesArch = New System.Windows.Forms.Label
        Me.txtFondsRelUnitTitle = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtFondsRelRepository = New System.Windows.Forms.TextBox
        Me.txtFondsRelDate = New System.Windows.Forms.TextBox
        Me.AuthoritiesRelDateArch = New System.Windows.Forms.Label
        Me.cbFondsRelType = New System.Windows.Forms.ComboBox
        Me.AuthoritieslblRelArch = New System.Windows.Forms.Label
        Me.txtFondSRelUnitId = New System.Windows.Forms.TextBox
        Me.AuthoritieslblRefArch = New System.Windows.Forms.Label
        Me.btnAddFondsRel = New System.Windows.Forms.Button
        Me.btnRemoveFondsRel = New System.Windows.Forms.Button
        Me.lvFondsRelationships = New System.Windows.Forms.ListView
        Me.AuthoritiesColLinkArchId = New System.Windows.Forms.ColumnHeader
        Me.AuthoritiesColLinkArchRelType = New System.Windows.Forms.ColumnHeader
        Me.AuthoritiesColLinkArchRelDate = New System.Windows.Forms.ColumnHeader
        Me.AuthoritiesColLinkArchReference = New System.Windows.Forms.ColumnHeader
        Me.AuthoritiesColLinkArchUnitTitle = New System.Windows.Forms.ColumnHeader
        Me.AuthoritiesColLinkArchInitialDate = New System.Windows.Forms.ColumnHeader
        Me.AuthoritiesColLinkArchFinalDate = New System.Windows.Forms.ColumnHeader
        Me.AuthoritiesColLinkArchRepository = New System.Windows.Forms.ColumnHeader
        Me.AuthoritiesColLinkArchRelNote = New System.Windows.Forms.ColumnHeader
        Me.tpAuthoritiesControl = New System.Windows.Forms.TabPage
        Me.AuthoritiesdbLanguageDecl = New System.Windows.Forms.GroupBox
        Me.btnRemoveLanguage = New mkccontrols.windows.forms.control.mkc_Button
        Me.btnAddLanguage = New mkccontrols.windows.forms.control.mkc_Button
        Me.lvLanguangeDecl = New System.Windows.Forms.ListView
        Me.ColLangDeclID = New System.Windows.Forms.ColumnHeader
        Me.ColLanguageDeclaration = New System.Windows.Forms.ColumnHeader
        Me.txtLanguage = New System.Windows.Forms.TextBox
        Me.AuthoritieslblLanguage = New System.Windows.Forms.Label
        Me.AuthoritiesgbControlInformation = New System.Windows.Forms.GroupBox
        Me.txtRules = New System.Windows.Forms.TextBox
        Me.AuthoritieslblRules = New System.Windows.Forms.Label
        Me.cbStatus = New System.Windows.Forms.ComboBox
        Me.AuthoritieslblStatus = New System.Windows.Forms.Label
        Me.txtOwnerCode = New System.Windows.Forms.TextBox
        Me.txtCountryCode = New System.Windows.Forms.TextBox
        Me.AuthoritieslblCountryCode = New System.Windows.Forms.Label
        Me.AuthoritieslblOwnerCode = New System.Windows.Forms.Label
        Me.cbDetailLevel = New System.Windows.Forms.ComboBox
        Me.AuthoritieslblDetailLevel = New System.Windows.Forms.Label
        Me.tpAuthoritiesDescription = New System.Windows.Forms.TabPage
        Me.AuthoritieslblEnv = New System.Windows.Forms.Label
        Me.txtEnv = New System.Windows.Forms.TextBox
        Me.AuthoritieslblAssetStruct = New System.Windows.Forms.Label
        Me.txtAssetStruct = New System.Windows.Forms.TextBox
        Me.AuthoritieslblFunActDesc = New System.Windows.Forms.Label
        Me.txtFunActDesc = New System.Windows.Forms.TextBox
        Me.txtLegalStatus = New System.Windows.Forms.TextBox
        Me.AuthoritieslblLegalStatus = New System.Windows.Forms.Label
        Me.txtPlace = New System.Windows.Forms.TextBox
        Me.AuthoritieslblPlace = New System.Windows.Forms.Label
        Me.AuthoritieslblBiogHist = New System.Windows.Forms.Label
        Me.txtBiogHist = New System.Windows.Forms.TextBox
        Me.tpEacRelationships = New System.Windows.Forms.TabPage
        Me.btnRemoveEacRel = New mkccontrols.windows.forms.control.mkc_Button
        Me.AuthoritiesgbRelationships = New System.Windows.Forms.GroupBox
        Me.btnAddEacRel = New mkccontrols.windows.forms.control.mkc_Button
        Me.AuthoritieslblRelPlace = New System.Windows.Forms.Label
        Me.txtEacRelPlace = New System.Windows.Forms.TextBox
        Me.AuthoritieslblRelNote = New System.Windows.Forms.Label
        Me.txtEacRelDescNote = New System.Windows.Forms.TextBox
        Me.txtEacRelDate = New System.Windows.Forms.TextBox
        Me.AuthoritieslblRelDate = New System.Windows.Forms.Label
        Me.cbEacRelType = New System.Windows.Forms.ComboBox
        Me.AuthoritieslblRelType = New System.Windows.Forms.Label
        Me.txtEacRelName = New System.Windows.Forms.TextBox
        Me.AuthoritieslblRelEntType = New System.Windows.Forms.Label
        Me.AuthoritieslblRelEntTitle = New System.Windows.Forms.Label
        Me.cbEacType = New System.Windows.Forms.ComboBox
        Me.lvEacRelationships = New System.Windows.Forms.ListView
        Me.AuthoritiesColRelId = New System.Windows.Forms.ColumnHeader
        Me.AuthoritiesColRelRelType = New System.Windows.Forms.ColumnHeader
        Me.AuthoritiesColRelDate = New System.Windows.Forms.ColumnHeader
        Me.AuthoritiesColRelEntType = New System.Windows.Forms.ColumnHeader
        Me.AuthoritiesColRelEntTitle = New System.Windows.Forms.ColumnHeader
        Me.AuthoritiesColRelPlace = New System.Windows.Forms.ColumnHeader
        Me.AuthoritiesColRelNote = New System.Windows.Forms.ColumnHeader
        Me.tpMaintenanceHistory = New System.Windows.Forms.TabPage
        Me.btnRemoveMainHistory = New mkccontrols.windows.forms.control.mkc_Button
        Me.AuthoritiesgbEvent = New System.Windows.Forms.GroupBox
        Me.btnAddMainHistory = New mkccontrols.windows.forms.control.mkc_Button
        Me.txtMainDate = New System.Windows.Forms.TextBox
        Me.AuthoritieslblMainDate = New System.Windows.Forms.Label
        Me.cbMainType = New System.Windows.Forms.ComboBox
        Me.AuthoritieslblMainType = New System.Windows.Forms.Label
        Me.txtMainName = New System.Windows.Forms.TextBox
        Me.AuthoritieslblMainName = New System.Windows.Forms.Label
        Me.AuthoritieslblMainDesc = New System.Windows.Forms.Label
        Me.txtMainDesc = New System.Windows.Forms.TextBox
        Me.lvMainHistory = New System.Windows.Forms.ListView
        Me.AuthoritiescolMainID = New System.Windows.Forms.ColumnHeader
        Me.AuthoritiescolMainType = New System.Windows.Forms.ColumnHeader
        Me.AuthoritiescolMainName = New System.Windows.Forms.ColumnHeader
        Me.AuthoritiescolMainDate = New System.Windows.Forms.ColumnHeader
        Me.AuthoritiescolMainDesc = New System.Windows.Forms.ColumnHeader
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.AddType = New System.Windows.Forms.Button
        Me.ControlAccessTypeHeader = New System.Windows.Forms.ColumnHeader
        Me.ControlAccessTypeIDHeader = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblReference = New System.Windows.Forms.Label
        Me.lblEacHeaderType = New System.Windows.Forms.Label
        Me.Type = New System.Windows.Forms.TextBox
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader28 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader29 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader30 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader31 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader32 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader33 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader34 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader35 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader36 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader37 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader49 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader50 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader51 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader52 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader53 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader54 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader55 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader15 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader16 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader17 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader18 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader19 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader21 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader22 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader20 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader23 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader24 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader25 = New System.Windows.Forms.ColumnHeader
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabControlAuthorities.SuspendLayout()
        Me.tpAuthoritiesIdentity.SuspendLayout()
        Me.AuthoritiesgbPrimaryName.SuspendLayout()
        Me.AuthoritiesgbParallelName.SuspendLayout()
        Me.tpAuthoritiesLinks.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tpMuseologicRelationships.SuspendLayout()
        Me.AuthoritiesgbLinking.SuspendLayout()
        Me.tpFondsRelationships.SuspendLayout()
        Me.AuthoritiesgbLinkingArch.SuspendLayout()
        Me.tpAuthoritiesControl.SuspendLayout()
        Me.AuthoritiesdbLanguageDecl.SuspendLayout()
        Me.AuthoritiesgbControlInformation.SuspendLayout()
        Me.tpAuthoritiesDescription.SuspendLayout()
        Me.tpEacRelationships.SuspendLayout()
        Me.AuthoritiesgbRelationships.SuspendLayout()
        Me.tpMaintenanceHistory.SuspendLayout()
        Me.AuthoritiesgbEvent.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Controls.Add(Me.btnOk)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 423)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(522, 40)
        Me.Panel2.TabIndex = 4
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.White
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.ImageIndex = 0
        Me.btnCancel.ImageList = Me.imglButtons
        Me.btnCancel.Location = New System.Drawing.Point(429, 8)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 25)
        Me.btnCancel.TabIndex = 202
        Me.btnCancel.Text = CType(configurationAppSettings.GetValue("AuthoritiesbtnCancel.Text", GetType(System.String)), String)
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'imglButtons
        '
        Me.imglButtons.ImageSize = New System.Drawing.Size(18, 18)
        Me.imglButtons.ImageStream = CType(resources.GetObject("imglButtons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglButtons.TransparentColor = System.Drawing.Color.Transparent
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.Color.White
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.ImageIndex = 1
        Me.btnOk.ImageList = Me.imglButtons
        Me.btnOk.Location = New System.Drawing.Point(347, 8)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 25)
        Me.btnOk.TabIndex = 201
        Me.btnOk.Text = CType(configurationAppSettings.GetValue("AuthoritiesbtnOk.Text", GetType(System.String)), String)
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnExportEAC)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(522, 40)
        Me.Panel3.TabIndex = 5
        '
        'btnExportEAC
        '
        Me.btnExportEAC.BackColor = System.Drawing.Color.White
        Me.btnExportEAC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportEAC.Location = New System.Drawing.Point(8, 8)
        Me.btnExportEAC.Name = "btnExportEAC"
        Me.btnExportEAC.Size = New System.Drawing.Size(96, 23)
        Me.btnExportEAC.TabIndex = 200
        Me.btnExportEAC.Text = CType(configurationAppSettings.GetValue("btnExportEAC.Text", GetType(System.String)), String)
        '
        'FondsIcon
        '
        Me.FondsIcon.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
        Me.FondsIcon.ImageSize = New System.Drawing.Size(16, 16)
        Me.FondsIcon.ImageStream = CType(resources.GetObject("FondsIcon.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.FondsIcon.TransparentColor = System.Drawing.Color.White
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TabControlAuthorities)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(522, 423)
        Me.Panel1.TabIndex = 5
        '
        'TabControlAuthorities
        '
        Me.TabControlAuthorities.Controls.Add(Me.tpAuthoritiesIdentity)
        Me.TabControlAuthorities.Controls.Add(Me.tpAuthoritiesLinks)
        Me.TabControlAuthorities.Controls.Add(Me.tpAuthoritiesControl)
        Me.TabControlAuthorities.Controls.Add(Me.tpAuthoritiesDescription)
        Me.TabControlAuthorities.Controls.Add(Me.tpEacRelationships)
        Me.TabControlAuthorities.Controls.Add(Me.tpMaintenanceHistory)
        Me.TabControlAuthorities.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlAuthorities.ItemSize = New System.Drawing.Size(87, 18)
        Me.TabControlAuthorities.Location = New System.Drawing.Point(0, 16)
        Me.TabControlAuthorities.Multiline = True
        Me.TabControlAuthorities.Name = "TabControlAuthorities"
        Me.TabControlAuthorities.SelectedIndex = 0
        Me.TabControlAuthorities.Size = New System.Drawing.Size(522, 407)
        Me.TabControlAuthorities.TabIndex = 16
        '
        'tpAuthoritiesIdentity
        '
        Me.tpAuthoritiesIdentity.Controls.Add(Me.AuthoritiesgbPrimaryName)
        Me.tpAuthoritiesIdentity.Controls.Add(Me.AuthoritiesgbParallelName)
        Me.tpAuthoritiesIdentity.Location = New System.Drawing.Point(4, 22)
        Me.tpAuthoritiesIdentity.Name = "tpAuthoritiesIdentity"
        Me.tpAuthoritiesIdentity.Size = New System.Drawing.Size(514, 381)
        Me.tpAuthoritiesIdentity.TabIndex = 0
        Me.tpAuthoritiesIdentity.Text = CType(configurationAppSettings.GetValue("tpAuthoritiesIdentity.Text", GetType(System.String)), String)
        '
        'AuthoritiesgbPrimaryName
        '
        Me.AuthoritiesgbPrimaryName.Controls.Add(Me.txtLegalId)
        Me.AuthoritiesgbPrimaryName.Controls.Add(Me.AuthoritieslblLegalId)
        Me.AuthoritiesgbPrimaryName.Controls.Add(Me.AuthoritieslblActualPart)
        Me.AuthoritiesgbPrimaryName.Controls.Add(Me.txtActualPart)
        Me.AuthoritiesgbPrimaryName.Controls.Add(Me.txtActualUseDate)
        Me.AuthoritiesgbPrimaryName.Controls.Add(Me.AuthoritieslblActualUseDate)
        Me.AuthoritiesgbPrimaryName.Controls.Add(Me.cbType)
        Me.AuthoritiesgbPrimaryName.Controls.Add(Me.AuthoritieslblActualType)
        Me.AuthoritiesgbPrimaryName.Controls.Add(Me.txtSysKey)
        Me.AuthoritiesgbPrimaryName.Controls.Add(Me.AuthoritieslblSysKey)
        Me.AuthoritiesgbPrimaryName.Location = New System.Drawing.Point(16, 8)
        Me.AuthoritiesgbPrimaryName.Name = "AuthoritiesgbPrimaryName"
        Me.AuthoritiesgbPrimaryName.Size = New System.Drawing.Size(488, 112)
        Me.AuthoritiesgbPrimaryName.TabIndex = 52
        Me.AuthoritiesgbPrimaryName.TabStop = False
        Me.AuthoritiesgbPrimaryName.Text = CType(configurationAppSettings.GetValue("AuthoritiesgbPrimaryName.Text", GetType(System.String)), String)
        '
        'txtLegalId
        '
        Me.txtLegalId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLegalId.Location = New System.Drawing.Point(344, 56)
        Me.txtLegalId.Name = "txtLegalId"
        Me.txtLegalId.Size = New System.Drawing.Size(120, 20)
        Me.txtLegalId.TabIndex = 4
        Me.txtLegalId.Text = ""
        '
        'AuthoritieslblLegalId
        '
        Me.AuthoritieslblLegalId.Location = New System.Drawing.Point(248, 58)
        Me.AuthoritieslblLegalId.Name = "AuthoritieslblLegalId"
        Me.AuthoritieslblLegalId.Size = New System.Drawing.Size(80, 16)
        Me.AuthoritieslblLegalId.TabIndex = 60
        Me.AuthoritieslblLegalId.Text = CType(configurationAppSettings.GetValue("AuthoritieslblLegalId.Text", GetType(System.String)), String)
        '
        'AuthoritieslblActualPart
        '
        Me.AuthoritieslblActualPart.Location = New System.Drawing.Point(16, 80)
        Me.AuthoritieslblActualPart.Name = "AuthoritieslblActualPart"
        Me.AuthoritieslblActualPart.Size = New System.Drawing.Size(100, 16)
        Me.AuthoritieslblActualPart.TabIndex = 56
        Me.AuthoritieslblActualPart.Text = CType(configurationAppSettings.GetValue("AuthoritieslblActualPart.Text", GetType(System.String)), String)
        '
        'txtActualPart
        '
        Me.txtActualPart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtActualPart.Location = New System.Drawing.Point(120, 80)
        Me.txtActualPart.Name = "txtActualPart"
        Me.txtActualPart.Size = New System.Drawing.Size(344, 20)
        Me.txtActualPart.TabIndex = 5
        Me.txtActualPart.Text = ""
        '
        'txtActualUseDate
        '
        Me.txtActualUseDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtActualUseDate.Location = New System.Drawing.Point(344, 24)
        Me.txtActualUseDate.Name = "txtActualUseDate"
        Me.txtActualUseDate.Size = New System.Drawing.Size(120, 20)
        Me.txtActualUseDate.TabIndex = 2
        Me.txtActualUseDate.Text = ""
        '
        'AuthoritieslblActualUseDate
        '
        Me.AuthoritieslblActualUseDate.Location = New System.Drawing.Point(248, 26)
        Me.AuthoritieslblActualUseDate.Name = "AuthoritieslblActualUseDate"
        Me.AuthoritieslblActualUseDate.Size = New System.Drawing.Size(96, 16)
        Me.AuthoritieslblActualUseDate.TabIndex = 57
        Me.AuthoritieslblActualUseDate.Text = CType(configurationAppSettings.GetValue("AuthoritieslblActualUseDate.Text", GetType(System.String)), String)
        '
        'cbType
        '
        Me.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbType.Items.AddRange(New Object() {"corporatebody", "family", "person"})
        Me.cbType.Location = New System.Drawing.Point(120, 24)
        Me.cbType.Name = "cbType"
        Me.cbType.Size = New System.Drawing.Size(120, 21)
        Me.cbType.TabIndex = 1
        '
        'AuthoritieslblActualType
        '
        Me.AuthoritieslblActualType.Location = New System.Drawing.Point(16, 24)
        Me.AuthoritieslblActualType.Name = "AuthoritieslblActualType"
        Me.AuthoritieslblActualType.Size = New System.Drawing.Size(100, 16)
        Me.AuthoritieslblActualType.TabIndex = 55
        Me.AuthoritieslblActualType.Text = CType(configurationAppSettings.GetValue("AuthoritieslblActualType.Text", GetType(System.String)), String)
        '
        'txtSysKey
        '
        Me.txtSysKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSysKey.Location = New System.Drawing.Point(120, 56)
        Me.txtSysKey.Name = "txtSysKey"
        Me.txtSysKey.Size = New System.Drawing.Size(120, 20)
        Me.txtSysKey.TabIndex = 3
        Me.txtSysKey.Text = ""
        '
        'AuthoritieslblSysKey
        '
        Me.AuthoritieslblSysKey.Location = New System.Drawing.Point(16, 56)
        Me.AuthoritieslblSysKey.Name = "AuthoritieslblSysKey"
        Me.AuthoritieslblSysKey.Size = New System.Drawing.Size(100, 16)
        Me.AuthoritieslblSysKey.TabIndex = 54
        Me.AuthoritieslblSysKey.Text = CType(configurationAppSettings.GetValue("AuthoritieslblSysKey.Text", GetType(System.String)), String)
        '
        'AuthoritiesgbParallelName
        '
        Me.AuthoritiesgbParallelName.Controls.Add(Me.btnRemoveIdentity)
        Me.AuthoritiesgbParallelName.Controls.Add(Me.btnAddIdentity)
        Me.AuthoritiesgbParallelName.Controls.Add(Me.cbIdentityType)
        Me.AuthoritiesgbParallelName.Controls.Add(Me.AuthoritieslblType)
        Me.AuthoritiesgbParallelName.Controls.Add(Me.lvIdentity)
        Me.AuthoritiesgbParallelName.Controls.Add(Me.AuthoritieslblPart)
        Me.AuthoritiesgbParallelName.Controls.Add(Me.txtPart)
        Me.AuthoritiesgbParallelName.Controls.Add(Me.txtUseDate)
        Me.AuthoritiesgbParallelName.Controls.Add(Me.AuthoritieslblUseDate)
        Me.AuthoritiesgbParallelName.Location = New System.Drawing.Point(16, 128)
        Me.AuthoritiesgbParallelName.Name = "AuthoritiesgbParallelName"
        Me.AuthoritiesgbParallelName.Size = New System.Drawing.Size(488, 224)
        Me.AuthoritiesgbParallelName.TabIndex = 62
        Me.AuthoritiesgbParallelName.TabStop = False
        Me.AuthoritiesgbParallelName.Text = CType(configurationAppSettings.GetValue("AuthoritiesgbParallelName.Text", GetType(System.String)), String)
        '
        'btnRemoveIdentity
        '
        Me.btnRemoveIdentity.BorderColor = System.Drawing.SystemColors.Control
        Me.btnRemoveIdentity.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveIdentity.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.btnRemoveIdentity.ButtonImage = CType(resources.GetObject("btnRemoveIdentity.ButtonImage"), System.Drawing.Image)
        Me.btnRemoveIdentity.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnRemoveIdentity.ButtonShowShadow = True
        Me.btnRemoveIdentity.ButtonText = ""
        Me.btnRemoveIdentity.ButtonTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnRemoveIdentity.ButtonTransparentColor = System.Drawing.Color.Empty
        Me.btnRemoveIdentity.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRemoveIdentity.HighlightBackgroundColor = System.Drawing.SystemColors.Control
        Me.btnRemoveIdentity.Location = New System.Drawing.Point(24, 112)
        Me.btnRemoveIdentity.Name = "btnRemoveIdentity"
        Me.btnRemoveIdentity.Size = New System.Drawing.Size(20, 20)
        Me.btnRemoveIdentity.TabIndex = 71
        '
        'btnAddIdentity
        '
        Me.btnAddIdentity.BorderColor = System.Drawing.SystemColors.Control
        Me.btnAddIdentity.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddIdentity.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAddIdentity.ButtonImage = CType(resources.GetObject("btnAddIdentity.ButtonImage"), System.Drawing.Image)
        Me.btnAddIdentity.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAddIdentity.ButtonShowShadow = True
        Me.btnAddIdentity.ButtonText = ""
        Me.btnAddIdentity.ButtonTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAddIdentity.ButtonTransparentColor = System.Drawing.Color.Empty
        Me.btnAddIdentity.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddIdentity.HighlightBackgroundColor = System.Drawing.SystemColors.Control
        Me.btnAddIdentity.Location = New System.Drawing.Point(452, 80)
        Me.btnAddIdentity.Name = "btnAddIdentity"
        Me.btnAddIdentity.Size = New System.Drawing.Size(20, 20)
        Me.btnAddIdentity.TabIndex = 70
        '
        'cbIdentityType
        '
        Me.cbIdentityType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbIdentityType.ItemHeight = 13
        Me.cbIdentityType.Location = New System.Drawing.Point(136, 24)
        Me.cbIdentityType.Name = "cbIdentityType"
        Me.cbIdentityType.Size = New System.Drawing.Size(152, 21)
        Me.cbIdentityType.TabIndex = 6
        '
        'AuthoritieslblType
        '
        Me.AuthoritieslblType.Location = New System.Drawing.Point(16, 24)
        Me.AuthoritieslblType.Name = "AuthoritieslblType"
        Me.AuthoritieslblType.Size = New System.Drawing.Size(100, 16)
        Me.AuthoritieslblType.TabIndex = 69
        Me.AuthoritieslblType.Text = CType(configurationAppSettings.GetValue("AuthoritieslblType.Text", GetType(System.String)), String)
        '
        'lvIdentity
        '
        Me.lvIdentity.Alignment = System.Windows.Forms.ListViewAlignment.Default
        Me.lvIdentity.AutoArrange = False
        Me.lvIdentity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvIdentity.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.AuthoritiescolID, Me.AuthoritiescolParallelName, Me.AuthoritiescolPart, Me.AuthoritiescolUseDate})
        Me.lvIdentity.FullRowSelect = True
        Me.lvIdentity.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvIdentity.HideSelection = False
        Me.lvIdentity.Location = New System.Drawing.Point(53, 112)
        Me.lvIdentity.MultiSelect = False
        Me.lvIdentity.Name = "lvIdentity"
        Me.lvIdentity.Size = New System.Drawing.Size(419, 96)
        Me.lvIdentity.TabIndex = 10
        Me.lvIdentity.View = System.Windows.Forms.View.Details
        '
        'AuthoritiescolID
        '
        Me.AuthoritiescolID.Text = CType(configurationAppSettings.GetValue("AuthoritiescolID.Text", GetType(System.String)), String)
        Me.AuthoritiescolID.Width = 0
        '
        'AuthoritiescolParallelName
        '
        Me.AuthoritiescolParallelName.Text = CType(configurationAppSettings.GetValue("AuthoritiescolParallelName.Text", GetType(System.String)), String)
        Me.AuthoritiescolParallelName.Width = 75
        '
        'AuthoritiescolPart
        '
        Me.AuthoritiescolPart.Text = CType(configurationAppSettings.GetValue("AuthoritiescolPart.Text", GetType(System.String)), String)
        Me.AuthoritiescolPart.Width = 174
        '
        'AuthoritiescolUseDate
        '
        Me.AuthoritiescolUseDate.Text = CType(configurationAppSettings.GetValue("AuthoritiescolUseDate.Text", GetType(System.String)), String)
        Me.AuthoritiescolUseDate.Width = 111
        '
        'AuthoritieslblPart
        '
        Me.AuthoritieslblPart.Location = New System.Drawing.Point(16, 48)
        Me.AuthoritieslblPart.Name = "AuthoritieslblPart"
        Me.AuthoritieslblPart.Size = New System.Drawing.Size(100, 16)
        Me.AuthoritieslblPart.TabIndex = 62
        Me.AuthoritieslblPart.Text = CType(configurationAppSettings.GetValue("AuthoritieslblPart.Text", GetType(System.String)), String)
        '
        'txtPart
        '
        Me.txtPart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPart.Location = New System.Drawing.Point(136, 48)
        Me.txtPart.Name = "txtPart"
        Me.txtPart.Size = New System.Drawing.Size(296, 20)
        Me.txtPart.TabIndex = 7
        Me.txtPart.Text = ""
        '
        'txtUseDate
        '
        Me.txtUseDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUseDate.Location = New System.Drawing.Point(136, 72)
        Me.txtUseDate.Name = "txtUseDate"
        Me.txtUseDate.Size = New System.Drawing.Size(176, 20)
        Me.txtUseDate.TabIndex = 8
        Me.txtUseDate.Text = ""
        '
        'AuthoritieslblUseDate
        '
        Me.AuthoritieslblUseDate.Location = New System.Drawing.Point(16, 72)
        Me.AuthoritieslblUseDate.Name = "AuthoritieslblUseDate"
        Me.AuthoritieslblUseDate.Size = New System.Drawing.Size(100, 16)
        Me.AuthoritieslblUseDate.TabIndex = 63
        Me.AuthoritieslblUseDate.Text = CType(configurationAppSettings.GetValue("AuthoritieslblUseDate.Text", GetType(System.String)), String)
        '
        'tpAuthoritiesLinks
        '
        Me.tpAuthoritiesLinks.Controls.Add(Me.TabControl1)
        Me.tpAuthoritiesLinks.Location = New System.Drawing.Point(4, 22)
        Me.tpAuthoritiesLinks.Name = "tpAuthoritiesLinks"
        Me.tpAuthoritiesLinks.Size = New System.Drawing.Size(514, 381)
        Me.tpAuthoritiesLinks.TabIndex = 8
        Me.tpAuthoritiesLinks.Text = CType(configurationAppSettings.GetValue("tpAuthoritiesLinks.Text", GetType(System.String)), String)
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpMuseologicRelationships)
        Me.TabControl1.Controls.Add(Me.tpFondsRelationships)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(514, 381)
        Me.TabControl1.TabIndex = 0
        '
        'tpMuseologicRelationships
        '
        Me.tpMuseologicRelationships.Controls.Add(Me.btnRemoveResRel)
        Me.tpMuseologicRelationships.Controls.Add(Me.AuthoritiesgbLinking)
        Me.tpMuseologicRelationships.Controls.Add(Me.lvResourceRelationships)
        Me.tpMuseologicRelationships.Location = New System.Drawing.Point(4, 22)
        Me.tpMuseologicRelationships.Name = "tpMuseologicRelationships"
        Me.tpMuseologicRelationships.Size = New System.Drawing.Size(506, 355)
        Me.tpMuseologicRelationships.TabIndex = 6
        Me.tpMuseologicRelationships.Text = CType(configurationAppSettings.GetValue("tpMuseologicRelationships.Text", GetType(System.String)), String)
        Me.tpMuseologicRelationships.Visible = False
        '
        'btnRemoveResRel
        '
        Me.btnRemoveResRel.BorderColor = System.Drawing.SystemColors.Control
        Me.btnRemoveResRel.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveResRel.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.btnRemoveResRel.ButtonImage = CType(resources.GetObject("btnRemoveResRel.ButtonImage"), System.Drawing.Image)
        Me.btnRemoveResRel.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnRemoveResRel.ButtonShowShadow = True
        Me.btnRemoveResRel.ButtonText = ""
        Me.btnRemoveResRel.ButtonTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnRemoveResRel.ButtonTransparentColor = System.Drawing.Color.Empty
        Me.btnRemoveResRel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRemoveResRel.HighlightBackgroundColor = System.Drawing.SystemColors.Control
        Me.btnRemoveResRel.Location = New System.Drawing.Point(21, 185)
        Me.btnRemoveResRel.Name = "btnRemoveResRel"
        Me.btnRemoveResRel.Size = New System.Drawing.Size(20, 20)
        Me.btnRemoveResRel.TabIndex = 76
        '
        'AuthoritiesgbLinking
        '
        Me.AuthoritiesgbLinking.Controls.Add(Me.btnAddResRel)
        Me.AuthoritiesgbLinking.Controls.Add(Me.AuthoritiesTypeRel)
        Me.AuthoritiesgbLinking.Controls.Add(Me.cbResType)
        Me.AuthoritiesgbLinking.Controls.Add(Me.AuthoritieslblDateRel)
        Me.AuthoritiesgbLinking.Controls.Add(Me.txtResRelDate)
        Me.AuthoritiesgbLinking.Controls.Add(Me.AuthoritieslblRelation)
        Me.AuthoritiesgbLinking.Controls.Add(Me.cbResRelType)
        Me.AuthoritiesgbLinking.Controls.Add(Me.txtResUnit)
        Me.AuthoritiesgbLinking.Controls.Add(Me.AuthoritieslblReference)
        Me.AuthoritiesgbLinking.Location = New System.Drawing.Point(16, 16)
        Me.AuthoritiesgbLinking.Name = "AuthoritiesgbLinking"
        Me.AuthoritiesgbLinking.Size = New System.Drawing.Size(480, 136)
        Me.AuthoritiesgbLinking.TabIndex = 67
        Me.AuthoritiesgbLinking.TabStop = False
        Me.AuthoritiesgbLinking.Text = CType(configurationAppSettings.GetValue("AuthoritiesgbLinking.Text", GetType(System.String)), String)
        '
        'btnAddResRel
        '
        Me.btnAddResRel.BorderColor = System.Drawing.SystemColors.Control
        Me.btnAddResRel.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddResRel.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAddResRel.ButtonImage = CType(resources.GetObject("btnAddResRel.ButtonImage"), System.Drawing.Image)
        Me.btnAddResRel.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAddResRel.ButtonShowShadow = True
        Me.btnAddResRel.ButtonText = ""
        Me.btnAddResRel.ButtonTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAddResRel.ButtonTransparentColor = System.Drawing.Color.Empty
        Me.btnAddResRel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddResRel.HighlightBackgroundColor = System.Drawing.SystemColors.Control
        Me.btnAddResRel.Location = New System.Drawing.Point(423, 96)
        Me.btnAddResRel.Name = "btnAddResRel"
        Me.btnAddResRel.Size = New System.Drawing.Size(20, 20)
        Me.btnAddResRel.TabIndex = 74
        '
        'AuthoritiesTypeRel
        '
        Me.AuthoritiesTypeRel.Location = New System.Drawing.Point(48, 80)
        Me.AuthoritiesTypeRel.Name = "AuthoritiesTypeRel"
        Me.AuthoritiesTypeRel.Size = New System.Drawing.Size(88, 16)
        Me.AuthoritiesTypeRel.TabIndex = 66
        Me.AuthoritiesTypeRel.Text = CType(configurationAppSettings.GetValue("AuthoritiesTypeRel.Text", GetType(System.String)), String)
        '
        'cbResType
        '
        Me.cbResType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbResType.Items.AddRange(New Object() {"museu", "biblioteca"})
        Me.cbResType.Location = New System.Drawing.Point(48, 96)
        Me.cbResType.Name = "cbResType"
        Me.cbResType.Size = New System.Drawing.Size(104, 21)
        Me.cbResType.TabIndex = 37
        '
        'AuthoritieslblDateRel
        '
        Me.AuthoritieslblDateRel.Location = New System.Drawing.Point(168, 32)
        Me.AuthoritieslblDateRel.Name = "AuthoritieslblDateRel"
        Me.AuthoritieslblDateRel.Size = New System.Drawing.Size(100, 16)
        Me.AuthoritieslblDateRel.TabIndex = 64
        Me.AuthoritieslblDateRel.Text = CType(configurationAppSettings.GetValue("AuthoritieslblDateRel.Text", GetType(System.String)), String)
        '
        'txtResRelDate
        '
        Me.txtResRelDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResRelDate.Location = New System.Drawing.Point(168, 48)
        Me.txtResRelDate.Name = "txtResRelDate"
        Me.txtResRelDate.Size = New System.Drawing.Size(248, 20)
        Me.txtResRelDate.TabIndex = 36
        Me.txtResRelDate.Text = ""
        '
        'AuthoritieslblRelation
        '
        Me.AuthoritieslblRelation.Location = New System.Drawing.Point(48, 32)
        Me.AuthoritieslblRelation.Name = "AuthoritieslblRelation"
        Me.AuthoritieslblRelation.Size = New System.Drawing.Size(88, 16)
        Me.AuthoritieslblRelation.TabIndex = 62
        Me.AuthoritieslblRelation.Text = CType(configurationAppSettings.GetValue("AuthoritieslblRelation.Text", GetType(System.String)), String)
        '
        'cbResRelType
        '
        Me.cbResRelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbResRelType.Items.AddRange(New Object() {"causa", "control", "destruction", "origination", "subject", "other"})
        Me.cbResRelType.Location = New System.Drawing.Point(48, 48)
        Me.cbResRelType.Name = "cbResRelType"
        Me.cbResRelType.Size = New System.Drawing.Size(104, 21)
        Me.cbResRelType.TabIndex = 35
        '
        'txtResUnit
        '
        Me.txtResUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtResUnit.Location = New System.Drawing.Point(168, 96)
        Me.txtResUnit.Name = "txtResUnit"
        Me.txtResUnit.Size = New System.Drawing.Size(248, 20)
        Me.txtResUnit.TabIndex = 38
        Me.txtResUnit.Text = ""
        '
        'AuthoritieslblReference
        '
        Me.AuthoritieslblReference.Location = New System.Drawing.Point(168, 80)
        Me.AuthoritieslblReference.Name = "AuthoritieslblReference"
        Me.AuthoritieslblReference.Size = New System.Drawing.Size(152, 16)
        Me.AuthoritieslblReference.TabIndex = 60
        Me.AuthoritieslblReference.Text = CType(configurationAppSettings.GetValue("AuthoritieslblReference.Text", GetType(System.String)), String)
        '
        'lvResourceRelationships
        '
        Me.lvResourceRelationships.Alignment = System.Windows.Forms.ListViewAlignment.Default
        Me.lvResourceRelationships.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvResourceRelationships.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.AuthoritiescolResID, Me.AuthoritiescolResRelType, Me.AuthoritiescolResDate, Me.AuthoritiescolResType, Me.AuthoritiescolResReference})
        Me.lvResourceRelationships.FullRowSelect = True
        Me.lvResourceRelationships.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvResourceRelationships.HideSelection = False
        Me.lvResourceRelationships.Location = New System.Drawing.Point(48, 168)
        Me.lvResourceRelationships.MultiSelect = False
        Me.lvResourceRelationships.Name = "lvResourceRelationships"
        Me.lvResourceRelationships.Size = New System.Drawing.Size(448, 176)
        Me.lvResourceRelationships.TabIndex = 57
        Me.lvResourceRelationships.View = System.Windows.Forms.View.Details
        '
        'AuthoritiescolResID
        '
        Me.AuthoritiescolResID.Text = CType(configurationAppSettings.GetValue("AuthoritiescolResID.Text", GetType(System.String)), String)
        Me.AuthoritiescolResID.Width = 0
        '
        'AuthoritiescolResRelType
        '
        Me.AuthoritiescolResRelType.Text = CType(configurationAppSettings.GetValue("AuthoritiescolResRelType.Text", GetType(System.String)), String)
        Me.AuthoritiescolResRelType.Width = 84
        '
        'AuthoritiescolResDate
        '
        Me.AuthoritiescolResDate.Text = CType(configurationAppSettings.GetValue("AuthoritiescolResDate.Text", GetType(System.String)), String)
        Me.AuthoritiescolResDate.Width = 72
        '
        'AuthoritiescolResType
        '
        Me.AuthoritiescolResType.Text = CType(configurationAppSettings.GetValue("AuthoritiescolResType.Text", GetType(System.String)), String)
        Me.AuthoritiescolResType.Width = 82
        '
        'AuthoritiescolResReference
        '
        Me.AuthoritiescolResReference.Text = CType(configurationAppSettings.GetValue("AuthoritiescolResReference.Text", GetType(System.String)), String)
        Me.AuthoritiescolResReference.Width = 273
        '
        'tpFondsRelationships
        '
        Me.tpFondsRelationships.Controls.Add(Me.AuthoritiesgbLinkingArch)
        Me.tpFondsRelationships.Controls.Add(Me.btnRemoveFondsRel)
        Me.tpFondsRelationships.Controls.Add(Me.lvFondsRelationships)
        Me.tpFondsRelationships.Location = New System.Drawing.Point(4, 22)
        Me.tpFondsRelationships.Name = "tpFondsRelationships"
        Me.tpFondsRelationships.Size = New System.Drawing.Size(506, 355)
        Me.tpFondsRelationships.TabIndex = 7
        Me.tpFondsRelationships.Text = CType(configurationAppSettings.GetValue("tpArchRelationships.Text", GetType(System.String)), String)
        Me.tpFondsRelationships.Visible = False
        '
        'AuthoritiesgbLinkingArch
        '
        Me.AuthoritiesgbLinkingArch.Controls.Add(Me.AuthoritieslblRelNotesArch)
        Me.AuthoritiesgbLinkingArch.Controls.Add(Me.txtFondsRelDescNote)
        Me.AuthoritiesgbLinkingArch.Controls.Add(Me.btnListFonds)
        Me.AuthoritiesgbLinkingArch.Controls.Add(Me.AuthoritieslblRepository)
        Me.AuthoritiesgbLinkingArch.Controls.Add(Me.txtFondsRelUnitDateFinal)
        Me.AuthoritiesgbLinkingArch.Controls.Add(Me.txtFondsRelUnitDateInitial)
        Me.AuthoritiesgbLinkingArch.Controls.Add(Me.AuthoritieslblDatesArch)
        Me.AuthoritiesgbLinkingArch.Controls.Add(Me.txtFondsRelUnitTitle)
        Me.AuthoritiesgbLinkingArch.Controls.Add(Me.Label18)
        Me.AuthoritiesgbLinkingArch.Controls.Add(Me.txtFondsRelRepository)
        Me.AuthoritiesgbLinkingArch.Controls.Add(Me.txtFondsRelDate)
        Me.AuthoritiesgbLinkingArch.Controls.Add(Me.AuthoritiesRelDateArch)
        Me.AuthoritiesgbLinkingArch.Controls.Add(Me.cbFondsRelType)
        Me.AuthoritiesgbLinkingArch.Controls.Add(Me.AuthoritieslblRelArch)
        Me.AuthoritiesgbLinkingArch.Controls.Add(Me.txtFondSRelUnitId)
        Me.AuthoritiesgbLinkingArch.Controls.Add(Me.AuthoritieslblRefArch)
        Me.AuthoritiesgbLinkingArch.Controls.Add(Me.btnAddFondsRel)
        Me.AuthoritiesgbLinkingArch.Location = New System.Drawing.Point(8, 8)
        Me.AuthoritiesgbLinkingArch.Name = "AuthoritiesgbLinkingArch"
        Me.AuthoritiesgbLinkingArch.Size = New System.Drawing.Size(488, 176)
        Me.AuthoritiesgbLinkingArch.TabIndex = 93
        Me.AuthoritiesgbLinkingArch.TabStop = False
        Me.AuthoritiesgbLinkingArch.Text = CType(configurationAppSettings.GetValue("AuthoritiesgbLinkingArch.Text", GetType(System.String)), String)
        '
        'AuthoritieslblRelNotesArch
        '
        Me.AuthoritieslblRelNotesArch.Location = New System.Drawing.Point(8, 48)
        Me.AuthoritieslblRelNotesArch.Name = "AuthoritieslblRelNotesArch"
        Me.AuthoritieslblRelNotesArch.Size = New System.Drawing.Size(88, 16)
        Me.AuthoritieslblRelNotesArch.TabIndex = 92
        Me.AuthoritieslblRelNotesArch.Text = CType(configurationAppSettings.GetValue("AuthoritieslblRelNotesArch.Text", GetType(System.String)), String)
        '
        'txtFondsRelDescNote
        '
        Me.txtFondsRelDescNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFondsRelDescNote.Location = New System.Drawing.Point(104, 48)
        Me.txtFondsRelDescNote.Multiline = True
        Me.txtFondsRelDescNote.Name = "txtFondsRelDescNote"
        Me.txtFondsRelDescNote.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtFondsRelDescNote.Size = New System.Drawing.Size(336, 40)
        Me.txtFondsRelDescNote.TabIndex = 42
        Me.txtFondsRelDescNote.Text = ""
        '
        'btnListFonds
        '
        Me.btnListFonds.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnListFonds.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnListFonds.Image = CType(resources.GetObject("btnListFonds.Image"), System.Drawing.Image)
        Me.btnListFonds.Location = New System.Drawing.Point(456, 64)
        Me.btnListFonds.Name = "btnListFonds"
        Me.btnListFonds.Size = New System.Drawing.Size(23, 23)
        Me.btnListFonds.TabIndex = 49
        '
        'AuthoritieslblRepository
        '
        Me.AuthoritieslblRepository.Location = New System.Drawing.Point(216, 96)
        Me.AuthoritieslblRepository.Name = "AuthoritieslblRepository"
        Me.AuthoritieslblRepository.Size = New System.Drawing.Size(104, 16)
        Me.AuthoritieslblRepository.TabIndex = 88
        Me.AuthoritieslblRepository.Text = CType(configurationAppSettings.GetValue("AuthoritieslblRepository.Text", GetType(System.String)), String)
        '
        'txtFondsRelUnitDateFinal
        '
        Me.txtFondsRelUnitDateFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFondsRelUnitDateFinal.Location = New System.Drawing.Point(176, 144)
        Me.txtFondsRelUnitDateFinal.Name = "txtFondsRelUnitDateFinal"
        Me.txtFondsRelUnitDateFinal.Size = New System.Drawing.Size(64, 20)
        Me.txtFondsRelUnitDateFinal.TabIndex = 47
        Me.txtFondsRelUnitDateFinal.Text = ""
        '
        'txtFondsRelUnitDateInitial
        '
        Me.txtFondsRelUnitDateInitial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFondsRelUnitDateInitial.Location = New System.Drawing.Point(104, 144)
        Me.txtFondsRelUnitDateInitial.Name = "txtFondsRelUnitDateInitial"
        Me.txtFondsRelUnitDateInitial.Size = New System.Drawing.Size(64, 20)
        Me.txtFondsRelUnitDateInitial.TabIndex = 46
        Me.txtFondsRelUnitDateInitial.Text = ""
        '
        'AuthoritieslblDatesArch
        '
        Me.AuthoritieslblDatesArch.Location = New System.Drawing.Point(8, 144)
        Me.AuthoritieslblDatesArch.Name = "AuthoritieslblDatesArch"
        Me.AuthoritieslblDatesArch.Size = New System.Drawing.Size(88, 16)
        Me.AuthoritieslblDatesArch.TabIndex = 85
        Me.AuthoritieslblDatesArch.Text = CType(configurationAppSettings.GetValue("AuthoritieslblDatesArch.Text", GetType(System.String)), String)
        '
        'txtFondsRelUnitTitle
        '
        Me.txtFondsRelUnitTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFondsRelUnitTitle.Location = New System.Drawing.Point(104, 120)
        Me.txtFondsRelUnitTitle.Name = "txtFondsRelUnitTitle"
        Me.txtFondsRelUnitTitle.Size = New System.Drawing.Size(336, 20)
        Me.txtFondsRelUnitTitle.TabIndex = 45
        Me.txtFondsRelUnitTitle.Text = ""
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(8, 120)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(72, 16)
        Me.Label18.TabIndex = 83
        Me.Label18.Text = CType(configurationAppSettings.GetValue("Label18.Text", GetType(System.String)), String)
        '
        'txtFondsRelRepository
        '
        Me.txtFondsRelRepository.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFondsRelRepository.Location = New System.Drawing.Point(320, 96)
        Me.txtFondsRelRepository.Name = "txtFondsRelRepository"
        Me.txtFondsRelRepository.Size = New System.Drawing.Size(120, 20)
        Me.txtFondsRelRepository.TabIndex = 44
        Me.txtFondsRelRepository.Text = ""
        '
        'txtFondsRelDate
        '
        Me.txtFondsRelDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFondsRelDate.Location = New System.Drawing.Point(320, 24)
        Me.txtFondsRelDate.Name = "txtFondsRelDate"
        Me.txtFondsRelDate.Size = New System.Drawing.Size(120, 20)
        Me.txtFondsRelDate.TabIndex = 41
        Me.txtFondsRelDate.Text = ""
        '
        'AuthoritiesRelDateArch
        '
        Me.AuthoritiesRelDateArch.Location = New System.Drawing.Point(216, 26)
        Me.AuthoritiesRelDateArch.Name = "AuthoritiesRelDateArch"
        Me.AuthoritiesRelDateArch.Size = New System.Drawing.Size(88, 16)
        Me.AuthoritiesRelDateArch.TabIndex = 79
        Me.AuthoritiesRelDateArch.Text = CType(configurationAppSettings.GetValue("AuthoritiesRelDateArch.Text", GetType(System.String)), String)
        '
        'cbFondsRelType
        '
        Me.cbFondsRelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFondsRelType.Items.AddRange(New Object() {"associative", "child", "earlier", "identity", "later", "parent", "subordinate", "superior"})
        Me.cbFondsRelType.Location = New System.Drawing.Point(104, 24)
        Me.cbFondsRelType.Name = "cbFondsRelType"
        Me.cbFondsRelType.Size = New System.Drawing.Size(104, 21)
        Me.cbFondsRelType.TabIndex = 40
        '
        'AuthoritieslblRelArch
        '
        Me.AuthoritieslblRelArch.Location = New System.Drawing.Point(8, 26)
        Me.AuthoritieslblRelArch.Name = "AuthoritieslblRelArch"
        Me.AuthoritieslblRelArch.Size = New System.Drawing.Size(96, 16)
        Me.AuthoritieslblRelArch.TabIndex = 78
        Me.AuthoritieslblRelArch.Text = CType(configurationAppSettings.GetValue("AuthoritieslblRelArch.Text", GetType(System.String)), String)
        '
        'txtFondSRelUnitId
        '
        Me.txtFondSRelUnitId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFondSRelUnitId.Location = New System.Drawing.Point(104, 96)
        Me.txtFondSRelUnitId.Name = "txtFondSRelUnitId"
        Me.txtFondSRelUnitId.Size = New System.Drawing.Size(96, 20)
        Me.txtFondSRelUnitId.TabIndex = 43
        Me.txtFondSRelUnitId.Text = ""
        '
        'AuthoritieslblRefArch
        '
        Me.AuthoritieslblRefArch.Location = New System.Drawing.Point(8, 96)
        Me.AuthoritieslblRefArch.Name = "AuthoritieslblRefArch"
        Me.AuthoritieslblRefArch.Size = New System.Drawing.Size(72, 16)
        Me.AuthoritieslblRefArch.TabIndex = 77
        Me.AuthoritieslblRefArch.Text = CType(configurationAppSettings.GetValue("AuthoritieslblRefArch.Text", GetType(System.String)), String)
        '
        'btnAddFondsRel
        '
        Me.btnAddFondsRel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddFondsRel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddFondsRel.Image = CType(resources.GetObject("btnAddFondsRel.Image"), System.Drawing.Image)
        Me.btnAddFondsRel.Location = New System.Drawing.Point(456, 120)
        Me.btnAddFondsRel.Name = "btnAddFondsRel"
        Me.btnAddFondsRel.Size = New System.Drawing.Size(22, 22)
        Me.btnAddFondsRel.TabIndex = 48
        '
        'btnRemoveFondsRel
        '
        Me.btnRemoveFondsRel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRemoveFondsRel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemoveFondsRel.Image = CType(resources.GetObject("btnRemoveFondsRel.Image"), System.Drawing.Image)
        Me.btnRemoveFondsRel.Location = New System.Drawing.Point(16, 208)
        Me.btnRemoveFondsRel.Name = "btnRemoveFondsRel"
        Me.btnRemoveFondsRel.Size = New System.Drawing.Size(22, 22)
        Me.btnRemoveFondsRel.TabIndex = 71
        Me.btnRemoveFondsRel.TabStop = False
        '
        'lvFondsRelationships
        '
        Me.lvFondsRelationships.Alignment = System.Windows.Forms.ListViewAlignment.Default
        Me.lvFondsRelationships.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvFondsRelationships.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.AuthoritiesColLinkArchId, Me.AuthoritiesColLinkArchRelType, Me.AuthoritiesColLinkArchRelDate, Me.AuthoritiesColLinkArchReference, Me.AuthoritiesColLinkArchUnitTitle, Me.AuthoritiesColLinkArchInitialDate, Me.AuthoritiesColLinkArchFinalDate, Me.AuthoritiesColLinkArchRepository, Me.AuthoritiesColLinkArchRelNote})
        Me.lvFondsRelationships.FullRowSelect = True
        Me.lvFondsRelationships.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvFondsRelationships.HideSelection = False
        Me.lvFondsRelationships.Location = New System.Drawing.Point(48, 200)
        Me.lvFondsRelationships.MultiSelect = False
        Me.lvFondsRelationships.Name = "lvFondsRelationships"
        Me.lvFondsRelationships.Size = New System.Drawing.Size(448, 144)
        Me.lvFondsRelationships.TabIndex = 70
        Me.lvFondsRelationships.View = System.Windows.Forms.View.Details
        '
        'AuthoritiesColLinkArchId
        '
        Me.AuthoritiesColLinkArchId.Text = CType(configurationAppSettings.GetValue("AuthoritiesColLinkArchId.Text", GetType(System.String)), String)
        Me.AuthoritiesColLinkArchId.Width = 0
        '
        'AuthoritiesColLinkArchRelType
        '
        Me.AuthoritiesColLinkArchRelType.Text = CType(configurationAppSettings.GetValue("AuthoritiesColLinkArchRelType.Text", GetType(System.String)), String)
        Me.AuthoritiesColLinkArchRelType.Width = 50
        '
        'AuthoritiesColLinkArchRelDate
        '
        Me.AuthoritiesColLinkArchRelDate.Text = CType(configurationAppSettings.GetValue("AuthoritiesColLinkArchRelDate.Text", GetType(System.String)), String)
        Me.AuthoritiesColLinkArchRelDate.Width = 56
        '
        'AuthoritiesColLinkArchReference
        '
        Me.AuthoritiesColLinkArchReference.Text = CType(configurationAppSettings.GetValue("AuthoritiesColLinkArchReference.Text", GetType(System.String)), String)
        Me.AuthoritiesColLinkArchReference.Width = 69
        '
        'AuthoritiesColLinkArchUnitTitle
        '
        Me.AuthoritiesColLinkArchUnitTitle.Text = CType(configurationAppSettings.GetValue("AuthoritiesColLinkArchUnitTitle.Text", GetType(System.String)), String)
        Me.AuthoritiesColLinkArchUnitTitle.Width = 105
        '
        'AuthoritiesColLinkArchInitialDate
        '
        Me.AuthoritiesColLinkArchInitialDate.Text = CType(configurationAppSettings.GetValue("AuthoritiesColLinkArchInitialDate.Text", GetType(System.String)), String)
        Me.AuthoritiesColLinkArchInitialDate.Width = 69
        '
        'AuthoritiesColLinkArchFinalDate
        '
        Me.AuthoritiesColLinkArchFinalDate.Text = CType(configurationAppSettings.GetValue("AuthoritiesColLinkArchFinalDate.Text", GetType(System.String)), String)
        '
        'AuthoritiesColLinkArchRepository
        '
        Me.AuthoritiesColLinkArchRepository.Text = CType(configurationAppSettings.GetValue("AuthoritiesColLinkArchRepository.Text", GetType(System.String)), String)
        Me.AuthoritiesColLinkArchRepository.Width = 200
        '
        'AuthoritiesColLinkArchRelNote
        '
        Me.AuthoritiesColLinkArchRelNote.Text = CType(configurationAppSettings.GetValue("AuthoritiesColLinkArchRelNote.Text", GetType(System.String)), String)
        '
        'tpAuthoritiesControl
        '
        Me.tpAuthoritiesControl.Controls.Add(Me.AuthoritiesdbLanguageDecl)
        Me.tpAuthoritiesControl.Controls.Add(Me.AuthoritiesgbControlInformation)
        Me.tpAuthoritiesControl.Location = New System.Drawing.Point(4, 22)
        Me.tpAuthoritiesControl.Name = "tpAuthoritiesControl"
        Me.tpAuthoritiesControl.Size = New System.Drawing.Size(514, 381)
        Me.tpAuthoritiesControl.TabIndex = 6
        Me.tpAuthoritiesControl.Text = CType(configurationAppSettings.GetValue("tpAuthoritiesControl.Text", GetType(System.String)), String)
        Me.tpAuthoritiesControl.Visible = False
        '
        'AuthoritiesdbLanguageDecl
        '
        Me.AuthoritiesdbLanguageDecl.Controls.Add(Me.btnRemoveLanguage)
        Me.AuthoritiesdbLanguageDecl.Controls.Add(Me.btnAddLanguage)
        Me.AuthoritiesdbLanguageDecl.Controls.Add(Me.lvLanguangeDecl)
        Me.AuthoritiesdbLanguageDecl.Controls.Add(Me.txtLanguage)
        Me.AuthoritiesdbLanguageDecl.Controls.Add(Me.AuthoritieslblLanguage)
        Me.AuthoritiesdbLanguageDecl.Location = New System.Drawing.Point(16, 192)
        Me.AuthoritiesdbLanguageDecl.Name = "AuthoritiesdbLanguageDecl"
        Me.AuthoritiesdbLanguageDecl.Size = New System.Drawing.Size(488, 160)
        Me.AuthoritiesdbLanguageDecl.TabIndex = 61
        Me.AuthoritiesdbLanguageDecl.TabStop = False
        Me.AuthoritiesdbLanguageDecl.Text = CType(configurationAppSettings.GetValue("AuthoritiesdbLanguageDecl.Text", GetType(System.String)), String)
        '
        'btnRemoveLanguage
        '
        Me.btnRemoveLanguage.BorderColor = System.Drawing.SystemColors.Control
        Me.btnRemoveLanguage.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveLanguage.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.btnRemoveLanguage.ButtonImage = CType(resources.GetObject("btnRemoveLanguage.ButtonImage"), System.Drawing.Image)
        Me.btnRemoveLanguage.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnRemoveLanguage.ButtonShowShadow = True
        Me.btnRemoveLanguage.ButtonText = ""
        Me.btnRemoveLanguage.ButtonTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnRemoveLanguage.ButtonTransparentColor = System.Drawing.Color.Empty
        Me.btnRemoveLanguage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRemoveLanguage.HighlightBackgroundColor = System.Drawing.SystemColors.Control
        Me.btnRemoveLanguage.Location = New System.Drawing.Point(37, 72)
        Me.btnRemoveLanguage.Name = "btnRemoveLanguage"
        Me.btnRemoveLanguage.Size = New System.Drawing.Size(20, 20)
        Me.btnRemoveLanguage.TabIndex = 72
        '
        'btnAddLanguage
        '
        Me.btnAddLanguage.BorderColor = System.Drawing.SystemColors.Control
        Me.btnAddLanguage.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddLanguage.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAddLanguage.ButtonImage = CType(resources.GetObject("btnAddLanguage.ButtonImage"), System.Drawing.Image)
        Me.btnAddLanguage.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAddLanguage.ButtonShowShadow = True
        Me.btnAddLanguage.ButtonText = ""
        Me.btnAddLanguage.ButtonTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAddLanguage.ButtonTransparentColor = System.Drawing.Color.Empty
        Me.btnAddLanguage.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddLanguage.HighlightBackgroundColor = System.Drawing.SystemColors.Control
        Me.btnAddLanguage.Location = New System.Drawing.Point(408, 48)
        Me.btnAddLanguage.Name = "btnAddLanguage"
        Me.btnAddLanguage.Size = New System.Drawing.Size(20, 20)
        Me.btnAddLanguage.TabIndex = 71
        '
        'lvLanguangeDecl
        '
        Me.lvLanguangeDecl.Alignment = System.Windows.Forms.ListViewAlignment.Default
        Me.lvLanguangeDecl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvLanguangeDecl.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColLangDeclID, Me.ColLanguageDeclaration})
        Me.lvLanguangeDecl.FullRowSelect = True
        Me.lvLanguangeDecl.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvLanguangeDecl.HideSelection = False
        Me.lvLanguangeDecl.Location = New System.Drawing.Point(64, 72)
        Me.lvLanguangeDecl.MultiSelect = False
        Me.lvLanguangeDecl.Name = "lvLanguangeDecl"
        Me.lvLanguangeDecl.Size = New System.Drawing.Size(368, 64)
        Me.lvLanguangeDecl.TabIndex = 43
        Me.lvLanguangeDecl.View = System.Windows.Forms.View.Details
        '
        'ColLangDeclID
        '
        Me.ColLangDeclID.Width = 0
        '
        'ColLanguageDeclaration
        '
        Me.ColLanguageDeclaration.Width = 200
        '
        'txtLanguage
        '
        Me.txtLanguage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLanguage.Location = New System.Drawing.Point(64, 48)
        Me.txtLanguage.Name = "txtLanguage"
        Me.txtLanguage.Size = New System.Drawing.Size(336, 20)
        Me.txtLanguage.TabIndex = 21
        Me.txtLanguage.Text = ""
        '
        'AuthoritieslblLanguage
        '
        Me.AuthoritieslblLanguage.Location = New System.Drawing.Point(64, 32)
        Me.AuthoritieslblLanguage.Name = "AuthoritieslblLanguage"
        Me.AuthoritieslblLanguage.Size = New System.Drawing.Size(56, 16)
        Me.AuthoritieslblLanguage.TabIndex = 46
        Me.AuthoritieslblLanguage.Text = CType(configurationAppSettings.GetValue("AuthoritieslblLanguage.Text", GetType(System.String)), String)
        '
        'AuthoritiesgbControlInformation
        '
        Me.AuthoritiesgbControlInformation.Controls.Add(Me.txtRules)
        Me.AuthoritiesgbControlInformation.Controls.Add(Me.AuthoritieslblRules)
        Me.AuthoritiesgbControlInformation.Controls.Add(Me.cbStatus)
        Me.AuthoritiesgbControlInformation.Controls.Add(Me.AuthoritieslblStatus)
        Me.AuthoritiesgbControlInformation.Controls.Add(Me.txtOwnerCode)
        Me.AuthoritiesgbControlInformation.Controls.Add(Me.txtCountryCode)
        Me.AuthoritiesgbControlInformation.Controls.Add(Me.AuthoritieslblCountryCode)
        Me.AuthoritiesgbControlInformation.Controls.Add(Me.AuthoritieslblOwnerCode)
        Me.AuthoritiesgbControlInformation.Controls.Add(Me.cbDetailLevel)
        Me.AuthoritiesgbControlInformation.Controls.Add(Me.AuthoritieslblDetailLevel)
        Me.AuthoritiesgbControlInformation.Location = New System.Drawing.Point(16, 16)
        Me.AuthoritiesgbControlInformation.Name = "AuthoritiesgbControlInformation"
        Me.AuthoritiesgbControlInformation.Size = New System.Drawing.Size(488, 160)
        Me.AuthoritiesgbControlInformation.TabIndex = 60
        Me.AuthoritiesgbControlInformation.TabStop = False
        Me.AuthoritiesgbControlInformation.Text = CType(configurationAppSettings.GetValue("AuthoritiesgbControlInformation.Text", GetType(System.String)), String)
        '
        'txtRules
        '
        Me.txtRules.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRules.Location = New System.Drawing.Point(24, 112)
        Me.txtRules.Multiline = True
        Me.txtRules.Name = "txtRules"
        Me.txtRules.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRules.Size = New System.Drawing.Size(432, 40)
        Me.txtRules.TabIndex = 20
        Me.txtRules.Text = ""
        '
        'AuthoritieslblRules
        '
        Me.AuthoritieslblRules.Location = New System.Drawing.Point(24, 96)
        Me.AuthoritieslblRules.Name = "AuthoritieslblRules"
        Me.AuthoritieslblRules.Size = New System.Drawing.Size(120, 16)
        Me.AuthoritieslblRules.TabIndex = 69
        Me.AuthoritieslblRules.Text = CType(configurationAppSettings.GetValue("AuthoritieslblRules.Text", GetType(System.String)), String)
        '
        'cbStatus
        '
        Me.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStatus.Items.AddRange(New Object() {"edited", "draft"})
        Me.cbStatus.Location = New System.Drawing.Point(360, 64)
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.Size = New System.Drawing.Size(96, 21)
        Me.cbStatus.TabIndex = 19
        '
        'AuthoritieslblStatus
        '
        Me.AuthoritieslblStatus.Location = New System.Drawing.Point(248, 66)
        Me.AuthoritieslblStatus.Name = "AuthoritieslblStatus"
        Me.AuthoritieslblStatus.Size = New System.Drawing.Size(96, 16)
        Me.AuthoritieslblStatus.TabIndex = 67
        Me.AuthoritieslblStatus.Text = CType(configurationAppSettings.GetValue("AuthoritieslblStatus.Text", GetType(System.String)), String)
        '
        'txtOwnerCode
        '
        Me.txtOwnerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOwnerCode.Location = New System.Drawing.Point(360, 32)
        Me.txtOwnerCode.Name = "txtOwnerCode"
        Me.txtOwnerCode.Size = New System.Drawing.Size(96, 20)
        Me.txtOwnerCode.TabIndex = 17
        Me.txtOwnerCode.Text = ""
        '
        'txtCountryCode
        '
        Me.txtCountryCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCountryCode.Location = New System.Drawing.Point(136, 32)
        Me.txtCountryCode.Name = "txtCountryCode"
        Me.txtCountryCode.Size = New System.Drawing.Size(88, 20)
        Me.txtCountryCode.TabIndex = 16
        Me.txtCountryCode.Text = ""
        '
        'AuthoritieslblCountryCode
        '
        Me.AuthoritieslblCountryCode.Location = New System.Drawing.Point(24, 32)
        Me.AuthoritieslblCountryCode.Name = "AuthoritieslblCountryCode"
        Me.AuthoritieslblCountryCode.Size = New System.Drawing.Size(96, 18)
        Me.AuthoritieslblCountryCode.TabIndex = 65
        Me.AuthoritieslblCountryCode.Text = CType(configurationAppSettings.GetValue("AuthoritieslblCountryCode.Text", GetType(System.String)), String)
        '
        'AuthoritieslblOwnerCode
        '
        Me.AuthoritieslblOwnerCode.Location = New System.Drawing.Point(248, 32)
        Me.AuthoritieslblOwnerCode.Name = "AuthoritieslblOwnerCode"
        Me.AuthoritieslblOwnerCode.Size = New System.Drawing.Size(104, 16)
        Me.AuthoritieslblOwnerCode.TabIndex = 64
        Me.AuthoritieslblOwnerCode.Text = CType(configurationAppSettings.GetValue("AuthoritieslblOwnerCode.Text", GetType(System.String)), String)
        '
        'cbDetailLevel
        '
        Me.cbDetailLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDetailLevel.Items.AddRange(New Object() {"full", "partial", "minimal"})
        Me.cbDetailLevel.Location = New System.Drawing.Point(136, 64)
        Me.cbDetailLevel.Name = "cbDetailLevel"
        Me.cbDetailLevel.Size = New System.Drawing.Size(88, 21)
        Me.cbDetailLevel.TabIndex = 18
        '
        'AuthoritieslblDetailLevel
        '
        Me.AuthoritieslblDetailLevel.Location = New System.Drawing.Point(24, 66)
        Me.AuthoritieslblDetailLevel.Name = "AuthoritieslblDetailLevel"
        Me.AuthoritieslblDetailLevel.Size = New System.Drawing.Size(100, 16)
        Me.AuthoritieslblDetailLevel.TabIndex = 61
        Me.AuthoritieslblDetailLevel.Text = CType(configurationAppSettings.GetValue("AuthoritieslblDetailLevel.Text", GetType(System.String)), String)
        '
        'tpAuthoritiesDescription
        '
        Me.tpAuthoritiesDescription.Controls.Add(Me.AuthoritieslblEnv)
        Me.tpAuthoritiesDescription.Controls.Add(Me.txtEnv)
        Me.tpAuthoritiesDescription.Controls.Add(Me.AuthoritieslblAssetStruct)
        Me.tpAuthoritiesDescription.Controls.Add(Me.txtAssetStruct)
        Me.tpAuthoritiesDescription.Controls.Add(Me.AuthoritieslblFunActDesc)
        Me.tpAuthoritiesDescription.Controls.Add(Me.txtFunActDesc)
        Me.tpAuthoritiesDescription.Controls.Add(Me.txtLegalStatus)
        Me.tpAuthoritiesDescription.Controls.Add(Me.AuthoritieslblLegalStatus)
        Me.tpAuthoritiesDescription.Controls.Add(Me.txtPlace)
        Me.tpAuthoritiesDescription.Controls.Add(Me.AuthoritieslblPlace)
        Me.tpAuthoritiesDescription.Controls.Add(Me.AuthoritieslblBiogHist)
        Me.tpAuthoritiesDescription.Controls.Add(Me.txtBiogHist)
        Me.tpAuthoritiesDescription.Location = New System.Drawing.Point(4, 22)
        Me.tpAuthoritiesDescription.Name = "tpAuthoritiesDescription"
        Me.tpAuthoritiesDescription.Size = New System.Drawing.Size(514, 381)
        Me.tpAuthoritiesDescription.TabIndex = 10
        Me.tpAuthoritiesDescription.Text = CType(configurationAppSettings.GetValue("tpAuthoritiesDescription.Text", GetType(System.String)), String)
        '
        'AuthoritieslblEnv
        '
        Me.AuthoritieslblEnv.Location = New System.Drawing.Point(24, 128)
        Me.AuthoritieslblEnv.Name = "AuthoritieslblEnv"
        Me.AuthoritieslblEnv.Size = New System.Drawing.Size(179, 16)
        Me.AuthoritieslblEnv.TabIndex = 68
        Me.AuthoritieslblEnv.Text = CType(configurationAppSettings.GetValue("AuthoritieslblEnv.Text", GetType(System.String)), String)
        '
        'txtEnv
        '
        Me.txtEnv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEnv.Location = New System.Drawing.Point(24, 144)
        Me.txtEnv.Multiline = True
        Me.txtEnv.Name = "txtEnv"
        Me.txtEnv.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtEnv.Size = New System.Drawing.Size(480, 88)
        Me.txtEnv.TabIndex = 11
        Me.txtEnv.Text = ""
        '
        'AuthoritieslblAssetStruct
        '
        Me.AuthoritieslblAssetStruct.Location = New System.Drawing.Point(272, 240)
        Me.AuthoritieslblAssetStruct.Name = "AuthoritieslblAssetStruct"
        Me.AuthoritieslblAssetStruct.Size = New System.Drawing.Size(179, 16)
        Me.AuthoritieslblAssetStruct.TabIndex = 66
        Me.AuthoritieslblAssetStruct.Text = CType(configurationAppSettings.GetValue("AuthoritieslblAssetStruct.Text", GetType(System.String)), String)
        '
        'txtAssetStruct
        '
        Me.txtAssetStruct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAssetStruct.Location = New System.Drawing.Point(272, 256)
        Me.txtAssetStruct.Multiline = True
        Me.txtAssetStruct.Name = "txtAssetStruct"
        Me.txtAssetStruct.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtAssetStruct.Size = New System.Drawing.Size(232, 56)
        Me.txtAssetStruct.TabIndex = 13
        Me.txtAssetStruct.Text = ""
        '
        'AuthoritieslblFunActDesc
        '
        Me.AuthoritieslblFunActDesc.Location = New System.Drawing.Point(24, 240)
        Me.AuthoritieslblFunActDesc.Name = "AuthoritieslblFunActDesc"
        Me.AuthoritieslblFunActDesc.Size = New System.Drawing.Size(179, 16)
        Me.AuthoritieslblFunActDesc.TabIndex = 64
        Me.AuthoritieslblFunActDesc.Text = CType(configurationAppSettings.GetValue("AuthoritieslblFunActDesc.Text", GetType(System.String)), String)
        '
        'txtFunActDesc
        '
        Me.txtFunActDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFunActDesc.Location = New System.Drawing.Point(24, 256)
        Me.txtFunActDesc.Multiline = True
        Me.txtFunActDesc.Name = "txtFunActDesc"
        Me.txtFunActDesc.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtFunActDesc.Size = New System.Drawing.Size(232, 56)
        Me.txtFunActDesc.TabIndex = 12
        Me.txtFunActDesc.Text = ""
        '
        'txtLegalStatus
        '
        Me.txtLegalStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLegalStatus.Location = New System.Drawing.Point(272, 344)
        Me.txtLegalStatus.Name = "txtLegalStatus"
        Me.txtLegalStatus.Size = New System.Drawing.Size(224, 20)
        Me.txtLegalStatus.TabIndex = 15
        Me.txtLegalStatus.Text = ""
        '
        'AuthoritieslblLegalStatus
        '
        Me.AuthoritieslblLegalStatus.Location = New System.Drawing.Point(272, 328)
        Me.AuthoritieslblLegalStatus.Name = "AuthoritieslblLegalStatus"
        Me.AuthoritieslblLegalStatus.Size = New System.Drawing.Size(80, 16)
        Me.AuthoritieslblLegalStatus.TabIndex = 62
        Me.AuthoritieslblLegalStatus.Text = CType(configurationAppSettings.GetValue("AuthoritieslblLegalStatus.Text", GetType(System.String)), String)
        '
        'txtPlace
        '
        Me.txtPlace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPlace.Location = New System.Drawing.Point(24, 344)
        Me.txtPlace.Name = "txtPlace"
        Me.txtPlace.Size = New System.Drawing.Size(232, 20)
        Me.txtPlace.TabIndex = 14
        Me.txtPlace.Text = ""
        '
        'AuthoritieslblPlace
        '
        Me.AuthoritieslblPlace.Location = New System.Drawing.Point(24, 328)
        Me.AuthoritieslblPlace.Name = "AuthoritieslblPlace"
        Me.AuthoritieslblPlace.Size = New System.Drawing.Size(88, 16)
        Me.AuthoritieslblPlace.TabIndex = 60
        Me.AuthoritieslblPlace.Text = CType(configurationAppSettings.GetValue("AuthoritieslblPlace.Text", GetType(System.String)), String)
        '
        'AuthoritieslblBiogHist
        '
        Me.AuthoritieslblBiogHist.Location = New System.Drawing.Point(24, 16)
        Me.AuthoritieslblBiogHist.Name = "AuthoritieslblBiogHist"
        Me.AuthoritieslblBiogHist.Size = New System.Drawing.Size(176, 16)
        Me.AuthoritieslblBiogHist.TabIndex = 58
        Me.AuthoritieslblBiogHist.Text = CType(configurationAppSettings.GetValue("AuthoritieslblBiogHist.Text", GetType(System.String)), String)
        '
        'txtBiogHist
        '
        Me.txtBiogHist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBiogHist.Location = New System.Drawing.Point(24, 32)
        Me.txtBiogHist.Multiline = True
        Me.txtBiogHist.Name = "txtBiogHist"
        Me.txtBiogHist.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtBiogHist.Size = New System.Drawing.Size(480, 88)
        Me.txtBiogHist.TabIndex = 10
        Me.txtBiogHist.Text = ""
        '
        'tpEacRelationships
        '
        Me.tpEacRelationships.Controls.Add(Me.btnRemoveEacRel)
        Me.tpEacRelationships.Controls.Add(Me.AuthoritiesgbRelationships)
        Me.tpEacRelationships.Controls.Add(Me.lvEacRelationships)
        Me.tpEacRelationships.Location = New System.Drawing.Point(4, 22)
        Me.tpEacRelationships.Name = "tpEacRelationships"
        Me.tpEacRelationships.Size = New System.Drawing.Size(514, 381)
        Me.tpEacRelationships.TabIndex = 9
        Me.tpEacRelationships.Text = CType(configurationAppSettings.GetValue("tpEacRelationships.Text", GetType(System.String)), String)
        Me.tpEacRelationships.Visible = False
        '
        'btnRemoveEacRel
        '
        Me.btnRemoveEacRel.BorderColor = System.Drawing.SystemColors.Control
        Me.btnRemoveEacRel.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveEacRel.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.btnRemoveEacRel.ButtonImage = CType(resources.GetObject("btnRemoveEacRel.ButtonImage"), System.Drawing.Image)
        Me.btnRemoveEacRel.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnRemoveEacRel.ButtonShowShadow = True
        Me.btnRemoveEacRel.ButtonText = ""
        Me.btnRemoveEacRel.ButtonTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnRemoveEacRel.ButtonTransparentColor = System.Drawing.Color.Empty
        Me.btnRemoveEacRel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRemoveEacRel.HighlightBackgroundColor = System.Drawing.SystemColors.Control
        Me.btnRemoveEacRel.Location = New System.Drawing.Point(13, 210)
        Me.btnRemoveEacRel.Name = "btnRemoveEacRel"
        Me.btnRemoveEacRel.Size = New System.Drawing.Size(20, 20)
        Me.btnRemoveEacRel.TabIndex = 73
        '
        'AuthoritiesgbRelationships
        '
        Me.AuthoritiesgbRelationships.Controls.Add(Me.btnAddEacRel)
        Me.AuthoritiesgbRelationships.Controls.Add(Me.AuthoritieslblRelPlace)
        Me.AuthoritiesgbRelationships.Controls.Add(Me.txtEacRelPlace)
        Me.AuthoritiesgbRelationships.Controls.Add(Me.AuthoritieslblRelNote)
        Me.AuthoritiesgbRelationships.Controls.Add(Me.txtEacRelDescNote)
        Me.AuthoritiesgbRelationships.Controls.Add(Me.txtEacRelDate)
        Me.AuthoritiesgbRelationships.Controls.Add(Me.AuthoritieslblRelDate)
        Me.AuthoritiesgbRelationships.Controls.Add(Me.cbEacRelType)
        Me.AuthoritiesgbRelationships.Controls.Add(Me.AuthoritieslblRelType)
        Me.AuthoritiesgbRelationships.Controls.Add(Me.txtEacRelName)
        Me.AuthoritiesgbRelationships.Controls.Add(Me.AuthoritieslblRelEntType)
        Me.AuthoritiesgbRelationships.Controls.Add(Me.AuthoritieslblRelEntTitle)
        Me.AuthoritiesgbRelationships.Controls.Add(Me.cbEacType)
        Me.AuthoritiesgbRelationships.Location = New System.Drawing.Point(8, 8)
        Me.AuthoritiesgbRelationships.Name = "AuthoritiesgbRelationships"
        Me.AuthoritiesgbRelationships.Size = New System.Drawing.Size(496, 168)
        Me.AuthoritiesgbRelationships.TabIndex = 72
        Me.AuthoritiesgbRelationships.TabStop = False
        Me.AuthoritiesgbRelationships.Text = "Relacionamento"
        '
        'btnAddEacRel
        '
        Me.btnAddEacRel.BorderColor = System.Drawing.SystemColors.Control
        Me.btnAddEacRel.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddEacRel.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAddEacRel.ButtonImage = CType(resources.GetObject("btnAddEacRel.ButtonImage"), System.Drawing.Image)
        Me.btnAddEacRel.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAddEacRel.ButtonShowShadow = True
        Me.btnAddEacRel.ButtonText = ""
        Me.btnAddEacRel.ButtonTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAddEacRel.ButtonTransparentColor = System.Drawing.Color.Empty
        Me.btnAddEacRel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddEacRel.HighlightBackgroundColor = System.Drawing.SystemColors.Control
        Me.btnAddEacRel.Location = New System.Drawing.Point(452, 136)
        Me.btnAddEacRel.Name = "btnAddEacRel"
        Me.btnAddEacRel.Size = New System.Drawing.Size(20, 20)
        Me.btnAddEacRel.TabIndex = 72
        '
        'AuthoritieslblRelPlace
        '
        Me.AuthoritieslblRelPlace.Location = New System.Drawing.Point(376, 24)
        Me.AuthoritieslblRelPlace.Name = "AuthoritieslblRelPlace"
        Me.AuthoritieslblRelPlace.Size = New System.Drawing.Size(40, 16)
        Me.AuthoritieslblRelPlace.TabIndex = 69
        Me.AuthoritieslblRelPlace.Text = CType(configurationAppSettings.GetValue("AuthoritieslblRelPlace.Text", GetType(System.String)), String)
        '
        'txtEacRelPlace
        '
        Me.txtEacRelPlace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEacRelPlace.Location = New System.Drawing.Point(376, 40)
        Me.txtEacRelPlace.Name = "txtEacRelPlace"
        Me.txtEacRelPlace.Size = New System.Drawing.Size(96, 20)
        Me.txtEacRelPlace.TabIndex = 30
        Me.txtEacRelPlace.Text = ""
        '
        'AuthoritieslblRelNote
        '
        Me.AuthoritieslblRelNote.Location = New System.Drawing.Point(24, 64)
        Me.AuthoritieslblRelNote.Name = "AuthoritieslblRelNote"
        Me.AuthoritieslblRelNote.Size = New System.Drawing.Size(40, 16)
        Me.AuthoritieslblRelNote.TabIndex = 67
        Me.AuthoritieslblRelNote.Text = CType(configurationAppSettings.GetValue("AuthoritieslblRelNote.Text", GetType(System.String)), String)
        '
        'txtEacRelDescNote
        '
        Me.txtEacRelDescNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEacRelDescNote.Location = New System.Drawing.Point(72, 64)
        Me.txtEacRelDescNote.Multiline = True
        Me.txtEacRelDescNote.Name = "txtEacRelDescNote"
        Me.txtEacRelDescNote.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtEacRelDescNote.Size = New System.Drawing.Size(400, 40)
        Me.txtEacRelDescNote.TabIndex = 31
        Me.txtEacRelDescNote.Text = ""
        '
        'txtEacRelDate
        '
        Me.txtEacRelDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEacRelDate.Location = New System.Drawing.Point(200, 40)
        Me.txtEacRelDate.Name = "txtEacRelDate"
        Me.txtEacRelDate.Size = New System.Drawing.Size(168, 20)
        Me.txtEacRelDate.TabIndex = 29
        Me.txtEacRelDate.Text = ""
        '
        'AuthoritieslblRelDate
        '
        Me.AuthoritieslblRelDate.Location = New System.Drawing.Point(200, 24)
        Me.AuthoritieslblRelDate.Name = "AuthoritieslblRelDate"
        Me.AuthoritieslblRelDate.Size = New System.Drawing.Size(40, 16)
        Me.AuthoritieslblRelDate.TabIndex = 66
        Me.AuthoritieslblRelDate.Text = CType(configurationAppSettings.GetValue("AuthoritieslblRelDate.Text", GetType(System.String)), String)
        '
        'cbEacRelType
        '
        Me.cbEacRelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEacRelType.Items.AddRange(New Object() {"associative", "child", "earlier", "identity", "later", "parent", "subordinate", "superior"})
        Me.cbEacRelType.Location = New System.Drawing.Point(72, 40)
        Me.cbEacRelType.Name = "cbEacRelType"
        Me.cbEacRelType.Size = New System.Drawing.Size(120, 21)
        Me.cbEacRelType.TabIndex = 28
        '
        'AuthoritieslblRelType
        '
        Me.AuthoritieslblRelType.Location = New System.Drawing.Point(72, 24)
        Me.AuthoritieslblRelType.Name = "AuthoritieslblRelType"
        Me.AuthoritieslblRelType.Size = New System.Drawing.Size(64, 16)
        Me.AuthoritieslblRelType.TabIndex = 65
        Me.AuthoritieslblRelType.Text = CType(configurationAppSettings.GetValue("AuthoritieslblRelType.Text", GetType(System.String)), String)
        '
        'txtEacRelName
        '
        Me.txtEacRelName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEacRelName.Location = New System.Drawing.Point(208, 112)
        Me.txtEacRelName.Name = "txtEacRelName"
        Me.txtEacRelName.Size = New System.Drawing.Size(264, 20)
        Me.txtEacRelName.TabIndex = 33
        Me.txtEacRelName.Text = ""
        '
        'AuthoritieslblRelEntType
        '
        Me.AuthoritieslblRelEntType.Location = New System.Drawing.Point(24, 112)
        Me.AuthoritieslblRelEntType.Name = "AuthoritieslblRelEntType"
        Me.AuthoritieslblRelEntType.Size = New System.Drawing.Size(32, 16)
        Me.AuthoritieslblRelEntType.TabIndex = 64
        Me.AuthoritieslblRelEntType.Text = CType(configurationAppSettings.GetValue("AuthoritieslblRelEntType.Text", GetType(System.String)), String)
        '
        'AuthoritieslblRelEntTitle
        '
        Me.AuthoritieslblRelEntTitle.Location = New System.Drawing.Point(168, 112)
        Me.AuthoritieslblRelEntTitle.Name = "AuthoritieslblRelEntTitle"
        Me.AuthoritieslblRelEntTitle.Size = New System.Drawing.Size(40, 16)
        Me.AuthoritieslblRelEntTitle.TabIndex = 71
        Me.AuthoritieslblRelEntTitle.Text = CType(configurationAppSettings.GetValue("AuthoritieslblRelEntTitle.Text", GetType(System.String)), String)
        '
        'cbEacType
        '
        Me.cbEacType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbEacType.Items.AddRange(New Object() {"corporatebody", "family", "person"})
        Me.cbEacType.Location = New System.Drawing.Point(72, 112)
        Me.cbEacType.Name = "cbEacType"
        Me.cbEacType.Size = New System.Drawing.Size(88, 21)
        Me.cbEacType.TabIndex = 32
        '
        'lvEacRelationships
        '
        Me.lvEacRelationships.Alignment = System.Windows.Forms.ListViewAlignment.Default
        Me.lvEacRelationships.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvEacRelationships.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.AuthoritiesColRelId, Me.AuthoritiesColRelRelType, Me.AuthoritiesColRelDate, Me.AuthoritiesColRelEntType, Me.AuthoritiesColRelEntTitle, Me.AuthoritiesColRelPlace, Me.AuthoritiesColRelNote})
        Me.lvEacRelationships.FullRowSelect = True
        Me.lvEacRelationships.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvEacRelationships.HideSelection = False
        Me.lvEacRelationships.Location = New System.Drawing.Point(40, 192)
        Me.lvEacRelationships.MultiSelect = False
        Me.lvEacRelationships.Name = "lvEacRelationships"
        Me.lvEacRelationships.Size = New System.Drawing.Size(464, 168)
        Me.lvEacRelationships.TabIndex = 57
        Me.lvEacRelationships.View = System.Windows.Forms.View.Details
        '
        'AuthoritiesColRelId
        '
        Me.AuthoritiesColRelId.Text = CType(configurationAppSettings.GetValue("AuthoritiesColRelId.Text", GetType(System.String)), String)
        Me.AuthoritiesColRelId.Width = 0
        '
        'AuthoritiesColRelRelType
        '
        Me.AuthoritiesColRelRelType.Text = CType(configurationAppSettings.GetValue("AuthoritiesColRelRelType.Text", GetType(System.String)), String)
        Me.AuthoritiesColRelRelType.Width = 58
        '
        'AuthoritiesColRelDate
        '
        Me.AuthoritiesColRelDate.Text = CType(configurationAppSettings.GetValue("AuthoritiesColRelDate.Text", GetType(System.String)), String)
        Me.AuthoritiesColRelDate.Width = 82
        '
        'AuthoritiesColRelEntType
        '
        Me.AuthoritiesColRelEntType.Text = CType(configurationAppSettings.GetValue("AuthoritiesColRelEntType.Text", GetType(System.String)), String)
        Me.AuthoritiesColRelEntType.Width = 74
        '
        'AuthoritiesColRelEntTitle
        '
        Me.AuthoritiesColRelEntTitle.Text = CType(configurationAppSettings.GetValue("AuthoritiesColRelEntTitle.Text", GetType(System.String)), String)
        Me.AuthoritiesColRelEntTitle.Width = 105
        '
        'AuthoritiesColRelPlace
        '
        Me.AuthoritiesColRelPlace.Text = CType(configurationAppSettings.GetValue("AuthoritiesColRelPlace.Text", GetType(System.String)), String)
        Me.AuthoritiesColRelPlace.Width = 114
        '
        'AuthoritiesColRelNote
        '
        Me.AuthoritiesColRelNote.Text = CType(configurationAppSettings.GetValue("AuthoritiesColRelNote.Text", GetType(System.String)), String)
        Me.AuthoritiesColRelNote.Width = 200
        '
        'tpMaintenanceHistory
        '
        Me.tpMaintenanceHistory.Controls.Add(Me.btnRemoveMainHistory)
        Me.tpMaintenanceHistory.Controls.Add(Me.AuthoritiesgbEvent)
        Me.tpMaintenanceHistory.Controls.Add(Me.lvMainHistory)
        Me.tpMaintenanceHistory.Location = New System.Drawing.Point(4, 22)
        Me.tpMaintenanceHistory.Name = "tpMaintenanceHistory"
        Me.tpMaintenanceHistory.Size = New System.Drawing.Size(514, 381)
        Me.tpMaintenanceHistory.TabIndex = 2
        Me.tpMaintenanceHistory.Text = CType(configurationAppSettings.GetValue("tpMaintenanceHistory.Text", GetType(System.String)), String)
        Me.tpMaintenanceHistory.Visible = False
        '
        'btnRemoveMainHistory
        '
        Me.btnRemoveMainHistory.BorderColor = System.Drawing.SystemColors.Control
        Me.btnRemoveMainHistory.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveMainHistory.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.btnRemoveMainHistory.ButtonImage = CType(resources.GetObject("btnRemoveMainHistory.ButtonImage"), System.Drawing.Image)
        Me.btnRemoveMainHistory.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnRemoveMainHistory.ButtonShowShadow = True
        Me.btnRemoveMainHistory.ButtonText = ""
        Me.btnRemoveMainHistory.ButtonTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnRemoveMainHistory.ButtonTransparentColor = System.Drawing.Color.Empty
        Me.btnRemoveMainHistory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRemoveMainHistory.HighlightBackgroundColor = System.Drawing.SystemColors.Control
        Me.btnRemoveMainHistory.Location = New System.Drawing.Point(21, 185)
        Me.btnRemoveMainHistory.Name = "btnRemoveMainHistory"
        Me.btnRemoveMainHistory.Size = New System.Drawing.Size(20, 20)
        Me.btnRemoveMainHistory.TabIndex = 77
        '
        'AuthoritiesgbEvent
        '
        Me.AuthoritiesgbEvent.Controls.Add(Me.btnAddMainHistory)
        Me.AuthoritiesgbEvent.Controls.Add(Me.txtMainDate)
        Me.AuthoritiesgbEvent.Controls.Add(Me.AuthoritieslblMainDate)
        Me.AuthoritiesgbEvent.Controls.Add(Me.cbMainType)
        Me.AuthoritiesgbEvent.Controls.Add(Me.AuthoritieslblMainType)
        Me.AuthoritiesgbEvent.Controls.Add(Me.txtMainName)
        Me.AuthoritiesgbEvent.Controls.Add(Me.AuthoritieslblMainName)
        Me.AuthoritiesgbEvent.Controls.Add(Me.AuthoritieslblMainDesc)
        Me.AuthoritiesgbEvent.Controls.Add(Me.txtMainDesc)
        Me.AuthoritiesgbEvent.Location = New System.Drawing.Point(16, 16)
        Me.AuthoritiesgbEvent.Name = "AuthoritiesgbEvent"
        Me.AuthoritiesgbEvent.Size = New System.Drawing.Size(488, 128)
        Me.AuthoritiesgbEvent.TabIndex = 57
        Me.AuthoritiesgbEvent.TabStop = False
        Me.AuthoritiesgbEvent.Text = CType(configurationAppSettings.GetValue("AuthoritiesgbEvent.Text", GetType(System.String)), String)
        '
        'btnAddMainHistory
        '
        Me.btnAddMainHistory.BorderColor = System.Drawing.SystemColors.Control
        Me.btnAddMainHistory.ButtonFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddMainHistory.ButtonForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAddMainHistory.ButtonImage = CType(resources.GetObject("btnAddMainHistory.ButtonImage"), System.Drawing.Image)
        Me.btnAddMainHistory.ButtonImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAddMainHistory.ButtonShowShadow = True
        Me.btnAddMainHistory.ButtonText = ""
        Me.btnAddMainHistory.ButtonTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnAddMainHistory.ButtonTransparentColor = System.Drawing.Color.Empty
        Me.btnAddMainHistory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddMainHistory.HighlightBackgroundColor = System.Drawing.SystemColors.Control
        Me.btnAddMainHistory.Location = New System.Drawing.Point(440, 92)
        Me.btnAddMainHistory.Name = "btnAddMainHistory"
        Me.btnAddMainHistory.Size = New System.Drawing.Size(20, 20)
        Me.btnAddMainHistory.TabIndex = 75
        '
        'txtMainDate
        '
        Me.txtMainDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMainDate.Location = New System.Drawing.Point(336, 40)
        Me.txtMainDate.Name = "txtMainDate"
        Me.txtMainDate.Size = New System.Drawing.Size(96, 20)
        Me.txtMainDate.TabIndex = 25
        Me.txtMainDate.Text = CType(configurationAppSettings.GetValue("txtMainDate.Text", GetType(System.String)), String)
        Me.ToolTip.SetToolTip(Me.txtMainDate, "e.g.  AAAA-MM-DD/AAAA-MM-DD ou AAAA/AAAA")
        '
        'AuthoritieslblMainDate
        '
        Me.AuthoritieslblMainDate.Location = New System.Drawing.Point(336, 24)
        Me.AuthoritieslblMainDate.Name = "AuthoritieslblMainDate"
        Me.AuthoritieslblMainDate.Size = New System.Drawing.Size(40, 16)
        Me.AuthoritieslblMainDate.TabIndex = 55
        Me.AuthoritieslblMainDate.Text = CType(configurationAppSettings.GetValue("AuthoritieslblMainDate.Text", GetType(System.String)), String)
        '
        'cbMainType
        '
        Me.cbMainType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMainType.Items.AddRange(New Object() {"create", "delete", "update", "import"})
        Me.cbMainType.Location = New System.Drawing.Point(64, 40)
        Me.cbMainType.Name = "cbMainType"
        Me.cbMainType.Size = New System.Drawing.Size(104, 21)
        Me.cbMainType.TabIndex = 23
        '
        'AuthoritieslblMainType
        '
        Me.AuthoritieslblMainType.Location = New System.Drawing.Point(64, 24)
        Me.AuthoritieslblMainType.Name = "AuthoritieslblMainType"
        Me.AuthoritieslblMainType.Size = New System.Drawing.Size(40, 16)
        Me.AuthoritieslblMainType.TabIndex = 54
        Me.AuthoritieslblMainType.Text = CType(configurationAppSettings.GetValue("AuthoritieslblMainType.Text", GetType(System.String)), String)
        '
        'txtMainName
        '
        Me.txtMainName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMainName.Location = New System.Drawing.Point(176, 40)
        Me.txtMainName.Name = "txtMainName"
        Me.txtMainName.Size = New System.Drawing.Size(152, 20)
        Me.txtMainName.TabIndex = 24
        Me.txtMainName.Text = ""
        '
        'AuthoritieslblMainName
        '
        Me.AuthoritieslblMainName.Location = New System.Drawing.Point(176, 24)
        Me.AuthoritieslblMainName.Name = "AuthoritieslblMainName"
        Me.AuthoritieslblMainName.Size = New System.Drawing.Size(100, 16)
        Me.AuthoritieslblMainName.TabIndex = 53
        Me.AuthoritieslblMainName.Text = CType(configurationAppSettings.GetValue("AuthoritieslblMainName.Text", GetType(System.String)), String)
        '
        'AuthoritieslblMainDesc
        '
        Me.AuthoritieslblMainDesc.Location = New System.Drawing.Point(24, 64)
        Me.AuthoritieslblMainDesc.Name = "AuthoritieslblMainDesc"
        Me.AuthoritieslblMainDesc.Size = New System.Drawing.Size(40, 16)
        Me.AuthoritieslblMainDesc.TabIndex = 56
        Me.AuthoritieslblMainDesc.Text = CType(configurationAppSettings.GetValue("AuthoritieslblMainDesc.Text", GetType(System.String)), String)
        '
        'txtMainDesc
        '
        Me.txtMainDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMainDesc.Location = New System.Drawing.Point(64, 64)
        Me.txtMainDesc.Multiline = True
        Me.txtMainDesc.Name = "txtMainDesc"
        Me.txtMainDesc.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtMainDesc.Size = New System.Drawing.Size(368, 48)
        Me.txtMainDesc.TabIndex = 26
        Me.txtMainDesc.Text = ""
        '
        'lvMainHistory
        '
        Me.lvMainHistory.Alignment = System.Windows.Forms.ListViewAlignment.Default
        Me.lvMainHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lvMainHistory.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.AuthoritiescolMainID, Me.AuthoritiescolMainType, Me.AuthoritiescolMainName, Me.AuthoritiescolMainDate, Me.AuthoritiescolMainDesc})
        Me.lvMainHistory.FullRowSelect = True
        Me.lvMainHistory.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvMainHistory.HideSelection = False
        Me.lvMainHistory.Location = New System.Drawing.Point(48, 168)
        Me.lvMainHistory.MultiSelect = False
        Me.lvMainHistory.Name = "lvMainHistory"
        Me.lvMainHistory.Size = New System.Drawing.Size(456, 192)
        Me.lvMainHistory.TabIndex = 4
        Me.lvMainHistory.View = System.Windows.Forms.View.Details
        '
        'AuthoritiescolMainID
        '
        Me.AuthoritiescolMainID.Text = CType(configurationAppSettings.GetValue("AuthoritiescolMainID.Text", GetType(System.String)), String)
        Me.AuthoritiescolMainID.Width = 0
        '
        'AuthoritiescolMainType
        '
        Me.AuthoritiescolMainType.Text = CType(configurationAppSettings.GetValue("AuthoritiescolMainType.Text", GetType(System.String)), String)
        Me.AuthoritiescolMainType.Width = 67
        '
        'AuthoritiescolMainName
        '
        Me.AuthoritiescolMainName.Text = CType(configurationAppSettings.GetValue("AuthoritiescolMainName.Text", GetType(System.String)), String)
        Me.AuthoritiescolMainName.Width = 137
        '
        'AuthoritiescolMainDate
        '
        Me.AuthoritiescolMainDate.Text = CType(configurationAppSettings.GetValue("AuthoritiescolMainDate.Text", GetType(System.String)), String)
        Me.AuthoritiescolMainDate.Width = 92
        '
        'AuthoritiescolMainDesc
        '
        Me.AuthoritiescolMainDesc.Text = CType(configurationAppSettings.GetValue("AuthoritiescolMainDesc.Text", GetType(System.String)), String)
        Me.AuthoritiescolMainDesc.Width = 151
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(522, 16)
        Me.Panel4.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(16, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 37
        '
        'TextBox6
        '
        Me.TextBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox6.Location = New System.Drawing.Point(16, 88)
        Me.TextBox6.Multiline = True
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(432, 64)
        Me.TextBox6.TabIndex = 36
        Me.TextBox6.Text = ""
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(360, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 16)
        Me.Label4.TabIndex = 35
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(120, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 34
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 33
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Items.AddRange(New Object() {"Creation", "Deletion"})
        Me.ComboBox1.Location = New System.Drawing.Point(16, 40)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(96, 21)
        Me.ComboBox1.TabIndex = 32
        '
        'TextBox5
        '
        Me.TextBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox5.Location = New System.Drawing.Point(360, 40)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(112, 20)
        Me.TextBox5.TabIndex = 31
        Me.TextBox5.Text = ""
        '
        'TextBox4
        '
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox4.Location = New System.Drawing.Point(120, 40)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(232, 20)
        Me.TextBox4.TabIndex = 30
        Me.TextBox4.Text = ""
        '
        'AddType
        '
        Me.AddType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.AddType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AddType.Image = CType(resources.GetObject("AddType.Image"), System.Drawing.Image)
        Me.AddType.Location = New System.Drawing.Point(456, 128)
        Me.AddType.Name = "AddType"
        Me.AddType.Size = New System.Drawing.Size(22, 22)
        Me.AddType.TabIndex = 24
        '
        'ControlAccessTypeHeader
        '
        Me.ControlAccessTypeHeader.Width = 350
        '
        'ControlAccessTypeIDHeader
        '
        Me.ControlAccessTypeIDHeader.Text = "ID"
        Me.ControlAccessTypeIDHeader.Width = 0
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Width = 350
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "ID"
        Me.ColumnHeader3.Width = 0
        '
        'TextBox2
        '
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Location = New System.Drawing.Point(160, 72)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(64, 20)
        Me.TextBox2.TabIndex = 33
        Me.TextBox2.Text = ""
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Location = New System.Drawing.Point(160, 48)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(64, 20)
        Me.TextBox1.TabIndex = 32
        Me.TextBox1.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 16)
        Me.Label2.TabIndex = 31
        '
        'lblReference
        '
        Me.lblReference.Location = New System.Drawing.Point(16, 48)
        Me.lblReference.Name = "lblReference"
        Me.lblReference.Size = New System.Drawing.Size(64, 16)
        Me.lblReference.TabIndex = 30
        '
        'lblEacHeaderType
        '
        Me.lblEacHeaderType.Location = New System.Drawing.Point(16, 24)
        Me.lblEacHeaderType.Name = "lblEacHeaderType"
        Me.lblEacHeaderType.Size = New System.Drawing.Size(96, 16)
        Me.lblEacHeaderType.TabIndex = 29
        '
        'Type
        '
        Me.Type.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Type.Location = New System.Drawing.Point(160, 24)
        Me.Type.Name = "Type"
        Me.Type.Size = New System.Drawing.Size(112, 20)
        Me.Type.TabIndex = 28
        Me.Type.Text = ""
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "ID"
        Me.ColumnHeader5.Width = 0
        '
        'ColumnHeader28
        '
        Me.ColumnHeader28.Text = "Tipo"
        Me.ColumnHeader28.Width = 50
        '
        'ColumnHeader29
        '
        Me.ColumnHeader29.Text = "Data"
        Me.ColumnHeader29.Width = 56
        '
        'ColumnHeader30
        '
        Me.ColumnHeader30.Text = "Referência"
        Me.ColumnHeader30.Width = 69
        '
        'ColumnHeader31
        '
        Me.ColumnHeader31.Text = "Título"
        Me.ColumnHeader31.Width = 105
        '
        'ColumnHeader32
        '
        Me.ColumnHeader32.Text = "Data inicial"
        Me.ColumnHeader32.Width = 69
        '
        'ColumnHeader33
        '
        Me.ColumnHeader33.Text = "Data final"
        '
        'ColumnHeader34
        '
        Me.ColumnHeader34.Text = "Entidade detentora"
        Me.ColumnHeader34.Width = 200
        '
        'ColumnHeader35
        '
        Me.ColumnHeader35.Text = "Estado físico"
        '
        'ColumnHeader36
        '
        Me.ColumnHeader36.Text = "Resumo"
        '
        'ColumnHeader37
        '
        Me.ColumnHeader37.Text = "Nota de relação"
        '
        'ColumnHeader49
        '
        Me.ColumnHeader49.Text = "ID"
        Me.ColumnHeader49.Width = 0
        '
        'ColumnHeader50
        '
        Me.ColumnHeader50.Text = "Tipo"
        Me.ColumnHeader50.Width = 58
        '
        'ColumnHeader51
        '
        Me.ColumnHeader51.Text = "Data"
        Me.ColumnHeader51.Width = 82
        '
        'ColumnHeader52
        '
        Me.ColumnHeader52.Text = "Tipo EAC"
        Me.ColumnHeader52.Width = 74
        '
        'ColumnHeader53
        '
        Me.ColumnHeader53.Text = "EAC"
        Me.ColumnHeader53.Width = 105
        '
        'ColumnHeader54
        '
        Me.ColumnHeader54.Text = "Local"
        Me.ColumnHeader54.Width = 114
        '
        'ColumnHeader55
        '
        Me.ColumnHeader55.Text = "Notas"
        Me.ColumnHeader55.Width = 200
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "ID"
        Me.ColumnHeader15.Width = 0
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "Tipo"
        Me.ColumnHeader16.Width = 50
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Data"
        Me.ColumnHeader17.Width = 56
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Referência"
        Me.ColumnHeader18.Width = 69
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "Título"
        Me.ColumnHeader19.Width = 105
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = "Data inicial"
        Me.ColumnHeader21.Width = 69
        '
        'ColumnHeader22
        '
        Me.ColumnHeader22.Text = "Data final"
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "Entidade detentora"
        Me.ColumnHeader20.Width = 200
        '
        'ColumnHeader23
        '
        Me.ColumnHeader23.Text = "Estado físico"
        '
        'ColumnHeader24
        '
        Me.ColumnHeader24.Text = "Resumo"
        '
        'ColumnHeader25
        '
        Me.ColumnHeader25.Text = "Nota de relação"
        '
        'AuthoritiesForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(522, 463)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1600, 1024)
        Me.MinimumSize = New System.Drawing.Size(300, 200)
        Me.Name = "AuthoritiesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registo de autoridade"
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TabControlAuthorities.ResumeLayout(False)
        Me.tpAuthoritiesIdentity.ResumeLayout(False)
        Me.AuthoritiesgbPrimaryName.ResumeLayout(False)
        Me.AuthoritiesgbParallelName.ResumeLayout(False)
        Me.tpAuthoritiesLinks.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tpMuseologicRelationships.ResumeLayout(False)
        Me.AuthoritiesgbLinking.ResumeLayout(False)
        Me.tpFondsRelationships.ResumeLayout(False)
        Me.AuthoritiesgbLinkingArch.ResumeLayout(False)
        Me.tpAuthoritiesControl.ResumeLayout(False)
        Me.AuthoritiesdbLanguageDecl.ResumeLayout(False)
        Me.AuthoritiesgbControlInformation.ResumeLayout(False)
        Me.tpAuthoritiesDescription.ResumeLayout(False)
        Me.tpEacRelationships.ResumeLayout(False)
        Me.AuthoritiesgbRelationships.ResumeLayout(False)
        Me.tpMaintenanceHistory.ResumeLayout(False)
        Me.AuthoritiesgbEvent.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region "Private Properties"

    Private myFondsID As Integer
    Private Eac As Eac

#End Region


#Region "Component Initialization"
    Public Sub New(ByVal FondsID As Integer)
        Me.New()
        myFondsID = FondsID

        Eac = New EAC(FondsID)

        LoadComboboxesItems()
        LoadEACInformation()
    End Sub

    Public Sub New(ByVal LazyNode As LazyNode)
        Me.New()
        myFondsID = LazyNode.ID

        Eac = New EAC(LazyNode)

        LoadComboboxesItems()
        LoadEACInformation()
    End Sub


#End Region


#Region "Load Info to Screen"

    Private Sub LoadComboboxesItems()
        With Me.cbEacRelType
            .Items.Clear()
            .Items.Add(VisualFieldLabel("Authorities.Associative"))
            .Items.Add(VisualFieldLabel("Authorities.Child"))
            .Items.Add(VisualFieldLabel("Authorities.Earlier"))
            .Items.Add(VisualFieldLabel("Authorities.Identity"))
            .Items.Add(VisualFieldLabel("Authorities.Later"))
            .Items.Add(VisualFieldLabel("Authorities.Parent"))
            .Items.Add(VisualFieldLabel("Authorities.Subordinate"))
            .Items.Add(VisualFieldLabel("Authorities.Superior"))
            .SelectedIndex = 0
        End With

        With Me.cbEacType
            .Items.Clear()
            .Items.Add(VisualFieldLabel("Authorities.CorporateBody"))
            .Items.Add(VisualFieldLabel("Authorities.Person"))
            .Items.Add(VisualFieldLabel("Authorities.Family"))
            .SelectedIndex = 0
        End With

        With Me.cbFondsRelType
            .Items.Clear()
            .Items.Add(VisualFieldLabel("Authorities.Other"))
            .SelectedIndex = 0
        End With

        With Me.cbIdentityType
            .Items.Clear()
            .Items.Add(VisualFieldLabel("Authorities.AlternativeName"))
            .Items.Add(VisualFieldLabel("Authorities.OtherFormName"))
            .SelectedIndex = 0
        End With

        With Me.cbMainType
            .Items.Clear()
            .Items.Add(VisualFieldLabel("Authorities.Create"))
            .Items.Add(VisualFieldLabel("Authorities.Delete"))
            .Items.Add(VisualFieldLabel("Authorities.Update"))
            .Items.Add(VisualFieldLabel("Authorities.Import"))
            .SelectedIndex = 0
        End With

        With Me.cbResRelType
            .Items.Clear()
            .Items.Add(VisualFieldLabel("Authorities.Other"))
            .SelectedIndex = 0
        End With

        With Me.cbResType
            .Items.Clear()
            .Items.Add(VisualFieldLabel("Authorities.Bibliographic"))
            .Items.Add(VisualFieldLabel("Authorities.Museologic"))
            .SelectedIndex = 0
        End With

        With Me.cbStatus
            .Items.Clear()
            .Items.Add(VisualFieldLabel("Authorities.StatusDraft"))
            .Items.Add(VisualFieldLabel("Authorities.StatusEdited"))
            .SelectedIndex = 0
        End With

        With Me.cbType
            .Items.Clear()
            .Items.Add(VisualFieldLabel("Authorities.CorporateBody"))
            .Items.Add(VisualFieldLabel("Authorities.Person"))
            .Items.Add(VisualFieldLabel("Authorities.Family"))
            .SelectedIndex = 0
        End With

        With Me.cbDetailLevel
            .Items.Clear()
            .Items.Add(VisualFieldLabel("Authorities.Minimal"))
            .Items.Add(VisualFieldLabel("Authorities.Partial"))
            .Items.Add(VisualFieldLabel("Authorities.Full"))
            .SelectedIndex = 0
        End With

    End Sub


    Private Sub LoadEACInformation()
        txtActualPart.Text = Eac.Part
        txtActualUseDate.Text = Eac.UseDate

        txtSysKey.Text = Eac.SysKey
        txtCountryCode.Text = Eac.CountryCode
        txtOwnerCode.Text = Eac.OwnerCode
        cbType.SelectedItem = Eac.Type
        cbDetailLevel.SelectedItem = Eac.DetailLevel
        txtBiogHist.Text = Eac.BiogHist
        txtPlace.Text = Eac.Place
        txtLegalStatus.Text = Eac.LegalStatus
        txtLegalId.Text = Eac.LegalId
        txtFunActDesc.Text = Eac.FunActDesc
        txtAssetStruct.Text = Eac.AssetStruct
        txtEnv.Text = Eac.Env
        txtRules.Text = Eac.FunActDesc
        txtAssetStruct.Text = Eac.AssetStruct
        txtEnv.Text = Eac.Env
        txtRules.Text = Eac.Rules
        cbStatus.SelectedItem = Eac.Status

        LoadIdentityList()
        LoadMaintenanceHistoryList()
        LoadLanguageDeclarationList()
        LoadResourceRelationshipsList()
        LoadEacRelationshipsList()
        LoadFondsRelationshipsList()
    End Sub




#End Region


#Region "Identity"

    Private Sub LoadIdentityList()
        Dim Item As EacIdentityItem
        lvIdentity.Items.Clear()
        For Each Item In Eac.Identity
            Dim iID As New ListViewItem(Item.ID)
            Dim iType As New ListViewItem.ListViewSubItem(iID, Item.Type)
            Dim iPart As New ListViewItem.ListViewSubItem(iID, Item.Part)
            Dim iUseDate As New ListViewItem.ListViewSubItem(iID, Item.UseDate)

            iID.SubItems.Add(iType)
            iID.SubItems.Add(iPart)
            iID.SubItems.Add(iUseDate)

            lvIdentity.Items.Add(iID)
        Next
    End Sub

    Private Sub btnAddIdentity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddIdentity.Click
        If txtPart.Text = "" Or cbIdentityType.SelectedItem Is Nothing Then Exit Sub

        Eac.Identity.Add(txtPart.Text, txtUseDate.Text, CStr(cbIdentityType.SelectedItem))
        txtPart.Text = ""
        txtUseDate.Text = ""

        LoadIdentityList()
        txtPart.Focus()

    End Sub

    Private Sub btnRemoveIdentity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveIdentity.Click
        If Me.lvIdentity.SelectedItems.Count <> 1 Then Exit Sub
        Dim SelectedItem As ListViewItem = lvIdentity.SelectedItems(0)

        Dim ID As Integer = StrToInt(SelectedItem.SubItems(0).Text)
        cbIdentityType.SelectedItem = SelectedItem.SubItems(1).Text
        txtPart.Text = SelectedItem.SubItems(2).Text
        txtUseDate.Text = SelectedItem.SubItems(3).Text
        Eac.Identity.Remove(New EacIdentityItem(ID))
        Me.LoadIdentityList()
    End Sub

#End Region


#Region "Maintenence History"

    Private Sub LoadMaintenanceHistoryList()
        Dim Item As EacMaintenanceHistoryItem
        Me.lvMainHistory.Items.Clear()
        For Each Item In Eac.MaintenanceHistory
            Dim iID As New ListViewItem(Item.ID)
            Dim iType As New ListViewItem.ListViewSubItem(iID, Item.Type)
            Dim iName As New ListViewItem.ListViewSubItem(iID, Item.Name)
            Dim iDate As New ListViewItem.ListViewSubItem(iID, Item.DateStr)
            Dim iDesc As New ListViewItem.ListViewSubItem(iID, Item.Description)
            iID.SubItems.Add(iType)
            iID.SubItems.Add(iName)
            iID.SubItems.Add(iDate)
            iID.SubItems.Add(iDesc)
            lvMainHistory.Items.Add(iID)
        Next
    End Sub

    Private Sub btnAddMainHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddMainHistory.Click
        If cbMainType.SelectedItem Is Nothing Or txtMainName.Text = "" Then Exit Sub
        Eac.MaintenanceHistory.Add(cbMainType.SelectedItem, txtMainName.Text, txtMainDate.Text, txtMainDesc.Text)

        txtMainName.Text = ""
        txtMainDate.Text = ""
        txtMainDesc.Text = ""
        LoadMaintenanceHistoryList()
        txtMainName.Focus()
    End Sub

    Private Sub btnRemoveMainHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveMainHistory.Click
        If Me.lvMainHistory.SelectedItems.Count <> 1 Then Exit Sub
        Dim SelectedItem As ListViewItem = lvMainHistory.SelectedItems(0)

        Dim ID As Integer = StrToInt(SelectedItem.SubItems(0).Text)
        cbMainType.SelectedItem = CStr(SelectedItem.SubItems(1).Text)
        txtMainName.Text = SelectedItem.SubItems(2).Text
        txtMainDate.Text = SelectedItem.SubItems(3).Text
        txtMainDesc.Text = SelectedItem.SubItems(4).Text
        Eac.MaintenanceHistory.Remove(New EacMaintenanceHistoryItem(ID))
        Me.LoadMaintenanceHistoryList()
    End Sub

#End Region


#Region "Laguange Declaration"

    Private Sub LoadLanguageDeclarationList()
        Dim Item As EacLanguageDeclarationItem
        Me.lvLanguangeDecl.Items.Clear()
        For Each Item In Eac.LanguageDeclaration
            Dim iID As New ListViewItem(Item.ID)
            Dim iLanguage As New ListViewItem.ListViewSubItem(iID, Item.Language)
            iID.SubItems.Add(iLanguage)
            lvLanguangeDecl.Items.Add(iID)
        Next
    End Sub

    Private Sub btnAddLanguage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddLanguage.Click
        If Me.txtLanguage.Text = "" Then Exit Sub

        Eac.LanguageDeclaration.Add(txtLanguage.Text)
        txtLanguage.Text = ""
        LoadLanguageDeclarationList()
        txtLanguage.Focus()
    End Sub

    Private Sub btnRemoveLanguage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveLanguage.Click
        If Me.lvLanguangeDecl.SelectedItems.Count <> 1 Then Exit Sub
        Dim SelectedItem As ListViewItem = lvLanguangeDecl.SelectedItems(0)

        Dim ID As Integer = StrToInt(SelectedItem.SubItems(0).Text)
        txtLanguage.Text = SelectedItem.SubItems(1).Text
        Eac.LanguageDeclaration.Remove(New EacLanguageDeclarationItem(ID))
        Me.LoadLanguageDeclarationList()
    End Sub

#End Region


#Region "Bibliographic Relationships"

    Private Sub LoadResourceRelationshipsList()
        Dim Item As EacResourceRelationshipsItem
        Me.lvResourceRelationships.Items.Clear()
        For Each Item In Eac.ResourceRelationships
            Dim iID As New ListViewItem(Item.ID)
            Dim iType As New ListViewItem.ListViewSubItem(iID, Item.Type)
            Dim iDate As New ListViewItem.ListViewSubItem(iID, Item.DateStr)
            Dim iResType As New ListViewItem.ListViewSubItem(iID, Item.ResourceType)
            Dim iUnit As New ListViewItem.ListViewSubItem(iID, Item.Unit)
            iID.SubItems.Add(iType)
            iID.SubItems.Add(iDate)
            iID.SubItems.Add(iResType)
            iID.SubItems.Add(iUnit)
            lvResourceRelationships.Items.Add(iID)
        Next
    End Sub




    Private Sub btnAddResRel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddResRel.Click
        If Me.txtResUnit.Text = "" Or Me.cbResRelType.SelectedItem Is Nothing Or Me.cbResType.SelectedItem Is Nothing Then Exit Sub

        Eac.ResourceRelationships.Add(CStr(cbResRelType.SelectedItem), txtResUnit.Text, txtResRelDate.Text, CStr(cbResType.SelectedItem))
        Me.txtResUnit.Text = ""
        txtResRelDate.Text = ""
        LoadResourceRelationshipsList()
        txtResUnit.Focus()
    End Sub

    Private Sub btnRemoveResRel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveResRel.Click
        If Me.lvResourceRelationships.SelectedItems.Count <> 1 Then Exit Sub
        Dim SelectedItem As ListViewItem = lvResourceRelationships.SelectedItems(0)

        Dim ID As Integer = StrToInt(SelectedItem.SubItems(0).Text)
        cbResRelType.SelectedItem = SelectedItem.SubItems(1).Text
        txtResRelDate.Text = SelectedItem.SubItems(2).Text
        cbResType.SelectedItem = SelectedItem.SubItems(3).Text
        txtResUnit.Text = SelectedItem.SubItems(4).Text

        Eac.ResourceRelationships.Remove(New EacResourceRelationshipsItem(ID))
        Me.LoadResourceRelationshipsList()
    End Sub
#End Region


#Region "Eac Relationships"


    Private Sub btnAddEacRel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddEacRel.Click
        If Me.cbEacType.SelectedItem Is Nothing Or Me.cbEacRelType.SelectedItem Is Nothing Or Me.txtEacRelName.Text = "" Then Exit Sub

        Eac.EacRelationships.Add(CStr(cbEacRelType.SelectedItem), txtEacRelName.Text, Me.txtEacRelPlace.Text, Me.txtEacRelDate.Text, Me.txtEacRelDescNote.Text, CStr(cbEacType.SelectedItem))
        txtEacRelName.Text = ""
        Me.txtEacRelPlace.Text = ""
        Me.txtEacRelDescNote.Text = ""
        Me.txtEacRelDate.Text = ""
        LoadEacRelationshipsList()
        txtEacRelName.Focus()
    End Sub

    Private Sub btnRemoveEacRel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveEacRel.Click
        If Me.lvEacRelationships.SelectedItems.Count <> 1 Then Exit Sub
        Dim SelectedItem As ListViewItem = lvEacRelationships.SelectedItems(0)

        Dim ID As Integer = StrToInt(SelectedItem.SubItems(0).Text)
        cbEacRelType.SelectedItem = SelectedItem.SubItems(1).Text
        txtEacRelDate.Text = SelectedItem.SubItems(2).Text
        cbEacType.SelectedItem = SelectedItem.SubItems(3).Text
        txtEacRelName.Text = SelectedItem.SubItems(4).Text
        txtEacRelPlace.Text = SelectedItem.SubItems(5).Text
        txtEacRelDescNote.Text = SelectedItem.SubItems(6).Text

        Eac.EacRelationships.Remove(New EacRelationshipsItem(ID))
        Me.LoadEacRelationshipsList()
    End Sub

    Private Sub LoadEacRelationshipsList()
        Dim Item As EacRelationshipsItem
        Me.lvEacRelationships.Items.Clear()
        For Each Item In Eac.EacRelationships
            Dim iID As New ListViewItem(Item.ID)
            Dim iType As New ListViewItem.ListViewSubItem(iID, Item.Type)
            Dim iEacType As New ListViewItem.ListViewSubItem(iID, Item.EacType)
            Dim iName As New ListViewItem.ListViewSubItem(iID, Item.Name)
            Dim iDate As New ListViewItem.ListViewSubItem(iID, Item.DateStr)
            Dim iPlace As New ListViewItem.ListViewSubItem(iID, Item.Place)
            Dim iNote As New ListViewItem.ListViewSubItem(iID, Item.Note)
            iID.SubItems.Add(iType)
            iID.SubItems.Add(iDate)
            iID.SubItems.Add(iEacType)
            iID.SubItems.Add(iName)
            iID.SubItems.Add(iPlace)
            iID.SubItems.Add(iNote)
            lvEacRelationships.Items.Add(iID)
        Next
    End Sub

#End Region


#Region "Fonds Relationships"

    Private Sub LoadFondsRelationshipsList()
        Dim Item As EacArchRelationshipsItem
        Me.lvFondsRelationships.Items.Clear()
        For Each Item In Eac.ArchRelationships
            Dim iID As New ListViewItem(Item.ID)
            Dim iType As New ListViewItem.ListViewSubItem(iID, Item.Type)
            Dim iDate As New ListViewItem.ListViewSubItem(iID, Item.DateStr)
            Dim iUnitId As New ListViewItem.ListViewSubItem(iID, Item.UnitId)
            Dim iUnitTitle As New ListViewItem.ListViewSubItem(iID, Item.UnitTitle)
            Dim iUnitDateInitial As New ListViewItem.ListViewSubItem(iID, Item.UnitDateInitial)
            Dim iUnitDateFinal As New ListViewItem.ListViewSubItem(iID, Item.UnitDateFinal)
            Dim iRepository As New ListViewItem.ListViewSubItem(iID, Item.Repository)
            Dim iDescNote As New ListViewItem.ListViewSubItem(iID, Item.Note)
            iID.SubItems.Add(iType)
            iID.SubItems.Add(iDate)
            iID.SubItems.Add(iUnitId)
            iID.SubItems.Add(iUnitTitle)
            iID.SubItems.Add(iUnitDateInitial)
            iID.SubItems.Add(iUnitDateFinal)
            iID.SubItems.Add(iRepository)
            iID.SubItems.Add(iDescNote)
            lvFondsRelationships.Items.Add(iID)
        Next
    End Sub

    Private Sub btnAddFondsRel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddFondsRel.Click
        If Me.cbFondsRelType.SelectedItem Is Nothing Or Me.txtFondSRelUnitId.Text = "" Then Exit Sub

        Eac.ArchRelationships.Add(CStr(cbFondsRelType.SelectedItem), _
            txtFondsRelDate.Text, txtFondSRelUnitId.Text, txtFondsRelUnitTitle.Text, _
            txtFondsRelUnitDateInitial.Text, txtFondsRelUnitDateFinal.Text, txtFondsRelRepository.Text, _
            txtFondsRelDescNote.Text)

        txtFondsRelDate.Text = ""
        txtFondSRelUnitId.Text = ""
        txtFondsRelUnitTitle.Text = ""
        txtFondsRelUnitDateInitial.Text = ""
        txtFondsRelUnitDateFinal.Text = ""
        txtFondsRelRepository.Text = ""
        txtFondsRelDescNote.Text = ""
        LoadFondsRelationshipsList()
        txtFondSRelUnitId.Focus()
    End Sub

    Private Sub btnRemoveFondsRel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveFondsRel.Click
        If Me.lvFondsRelationships.SelectedItems.Count <> 1 Then Exit Sub
        Dim SelectedItem As ListViewItem = lvFondsRelationships.SelectedItems(0)

        Dim ID As Integer = StrToInt(SelectedItem.SubItems(0).Text)
        cbFondsRelType.SelectedItem = SelectedItem.SubItems(1).Text
        txtFondsRelDate.Text = SelectedItem.SubItems(2).Text
        txtFondSRelUnitId.Text = SelectedItem.SubItems(3).Text
        txtFondsRelUnitTitle.Text = SelectedItem.SubItems(4).Text
        txtFondsRelUnitDateInitial.Text = SelectedItem.SubItems(5).Text
        txtFondsRelUnitDateFinal.Text = SelectedItem.SubItems(6).Text
        txtFondsRelRepository.Text = SelectedItem.SubItems(7).Text
        txtFondsRelDescNote.Text = SelectedItem.SubItems(8).Text

        Eac.ArchRelationships.Remove(New EacArchRelationshipsItem(ID))
        Me.LoadFondsRelationshipsList()
    End Sub

    Private Sub btnListFonds_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListFonds.Click
        Cursor.Current = Cursors.WaitCursor
        Dim frmFondsManager As New FondsManagerForm("admin", True, Nothing)
        If frmFondsManager.ShowDialog() = DialogResult.OK Then
            Dim Fonds As LazyNode = frmFondsManager.SelectedFonds()

            txtFondSRelUnitId.Text = Fonds.UnitId
            txtFondsRelUnitTitle.Text = Fonds.UnitTitle
            txtFondsRelUnitDateInitial.Text = Fonds.UnitDateInitial
            txtFondsRelUnitDateFinal.Text = Fonds.UnitDateFinal
            txtFondsRelRepository.Text = Fonds.Repository
        End If
        Cursor.Current = Cursors.Default
    End Sub

#End Region


#Region "Button Events"

    Private Sub btnExportEAC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportEAC.Click
        Dim SaveFileDialog As New SaveFileDialog
        'OpenFileDialog.Multiselect = True
        'OpenFileDialog.InitialDirectory() = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
        SaveFileDialog.Filter = "EAD files (*.eac)|*.eac"
        SaveFileDialog.Title = "Exportar EAC..."
        SaveFileDialog.FileName = Eac.SysKey.Replace("/", "-")

        Try
            If SaveFileDialog.ShowDialog() = DialogResult.OK Then
                Dim Filename As String = SaveFileDialog.FileName
                Dim XmlFile As New Xml.XmlDocument
                XmlFile.LoadXml(Eac.toXml)
                If File.Exists(EAC_XSLT_FILENAME) Then
                    Debug.WriteLine("Stylesheet found on " & EAC_XSLT_FILENAME)
                    XmlFile.Save(Filename & ".tmp")
                    Dim xslt As XslTransform = New XslTransform
                    xslt.Load(EAC_XSLT_FILENAME)

                    Dim resolver As XmlUrlResolver = New XmlUrlResolver
                    resolver.Credentials = System.Net.CredentialCache.DefaultCredentials
                    xslt.Transform(Filename & ".tmp", Filename, resolver)
                    xslt = Nothing
                    File.Delete(Filename & ".tmp")
                Else
                    Debug.WriteLine("Stylesheet NOT FOUND on " & EAC_XSLT_FILENAME)
                    XmlFile.Save(Filename)
                End If
            End If
        Catch ex As Exception
            MessageBoxes.MsgBoxException(ex)
        End Try

    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Eac.Part = txtActualPart.Text
        Eac.UseDate = txtActualUseDate.Text
        Eac.OwnerCode = txtOwnerCode.Text
        Eac.Type = CStr(cbType.SelectedItem)
        Eac.SysKey = txtSysKey.Text
        Eac.DetailLevel = CStr(cbDetailLevel.SelectedItem)
        Eac.CountryCode = txtCountryCode.Text
        Eac.BiogHist = txtBiogHist.Text
        Eac.Place = txtPlace.Text
        Eac.LegalStatus = txtLegalStatus.Text
        Eac.LegalId = txtLegalId.Text
        Eac.FunActDesc = txtFunActDesc.Text
        Eac.AssetStruct = txtAssetStruct.Text
        Eac.Env = txtEnv.Text
        Eac.Rules = txtRules.Text
        Eac.Status = CStr(cbStatus.SelectedItem)
        Eac.Upload()
        Close()
    End Sub



#End Region


    Private Sub Mkc_Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveEacRel.Click

    End Sub
End Class

