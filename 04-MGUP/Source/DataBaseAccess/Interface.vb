
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

Imports System

Public MustInherit Class SQLInterface
    Inherits System.Web.UI.Page

    Private myReturn As eReturn

    Public Enum eReturn
        Sucess
        ErrorDB
        ErrorNotProfile
        ErrorUsernamePass
        ErrorRepeatUsername
        ErrorNotActive
        AplicationAccessDenied
    End Enum

    Property Return_() As eReturn
        Get
            Return myReturn
        End Get
        Set(ByVal Value As eReturn)
            myReturn = Value
        End Set
    End Property

#Region "Employee"

    Public MustOverride Function validateEmployee(ByVal strAplicationCode As String, ByVal strUserName As String, ByVal strPassword As String) As eReturn

    Public MustOverride Function storeEmployee(ByVal objEmployee As Employee)

    Public MustOverride Function validateStoreEmployee(ByVal strUserName As String) As Boolean

    Public MustOverride Function loadEmployee(ByVal strUserName As String) As Employee

    Public MustOverride Sub loadEmployees(ByVal ddl As DropDownList, ByVal listType As Int16)

    Public MustOverride Sub loadEmployees(ByVal dg As DataGrid, ByVal intListType As Integer, ByVal strAplicationCode As String)

    Public MustOverride Function loadEmployees(ByVal intProfile As Integer, ByVal strAplicationCode As String) As DataSet

    Public MustOverride Function loadEmployees(ByVal strAplicationCode As String) As DataSet

    Public MustOverride Function loadFullEmployees() As DataSet

    Public MustOverride Sub updateEmployee(ByVal strUserName As String, ByVal intProfileID As Integer, ByVal strAplicationCode As String, ByVal bolActive As Boolean)

    Public MustOverride Sub updateEmployee(ByVal objEmployee As Employee)

    Public MustOverride Function countEmployees() As Integer

#End Region

#Region "Profiles"

    Public MustOverride Sub storeProfile(ByVal strProfileName As String, ByVal strAplicationCode As String)

    Public MustOverride Function loadProfiles(ByVal rdbl As RadioButtonList, ByVal strAplicationCode As String)

    Public MustOverride Function loadProfiles(ByVal ddl As DropDownList, ByVal strAplicationCode As String)

    Public MustOverride Function loadProfiles(ByVal dg As DataGrid, ByVal strAplicationCode As String)

    Public MustOverride Function loadProfiles(ByVal strAplicationCode As String) As DataSet

    Public MustOverride Function getProfile(ByVal strUserName As String, ByVal strAplicationCode As String) As Profile

    Public MustOverride Sub deleteProfile(ByVal strProfileID As Integer)

    Public MustOverride Sub updateProfile(ByVal strProfileID As Integer, ByVal strProfileName As String)

#End Region

#Region "Profile functions"

    Public MustOverride Function getProfileFunctions(ByVal intProfile As Integer, ByVal intParentID As String) As FunctionCollection

    Public MustOverride Function getAllProfileFunctions(ByVal strAplicationCode As String, ByVal intProfile As Integer, ByVal intParentID As String) As FunctionCollection

    Public MustOverride Sub updateProfileFunctions(ByVal intPtofileID As Integer, ByVal alstFunctionsID As ArrayList)

#End Region

#Region "Functions"

    Public MustOverride Function getAplicationFunctions(ByVal strAplicationCode As String, ByVal strParentCode As String) As FunctionCollection

    Public MustOverride Function loadFunction(ByVal strFunctionCode As String) As _Function

    Public MustOverride Sub storeFunction(ByVal objFunction As _Function)

    Public MustOverride Sub updateFunction(ByVal objFunction As _Function)

    Public MustOverride Sub deleteFunction(ByVal strFunctionCode As String, ByVal strAplicationCode As String)

    Public MustOverride Function hasFunctionsChildren(ByVal strFunctionCode As String) As Boolean

    Public MustOverride Function accessFunction(ByVal strUserName As String, ByVal strFunctionCode As String) As Boolean

#End Region

#Region "Aplications"

    Public MustOverride Function loadAplications() As DataSet

    'Public MustOverride Function loadAplications(ByVal ddl As DropDownList)

    'Public MustOverride Function loadAplications(ByVal rbl As RadioButtonList)

    'Public MustOverride Function loadAplications(ByVal cbl As CheckBoxList)

    'Public MustOverride Function loadAplications(ByVal dg As DataGrid)

    Public MustOverride Function getAllAplications() As Hashtable

    Public MustOverride Function loadAplication(ByVal strAplicationCode As String) As Aplication

    Public MustOverride Sub storeAplication(ByVal objAplication As Aplication)

    Public MustOverride Sub updateAplication(ByVal objAplication As Aplication)

    Public MustOverride Sub deleteAplication(ByVal strAplicationCode As String)

    Public MustOverride Function accessAplication(ByVal strUsername As String, ByVal strAplicationCode As String) As Boolean

#End Region

#Region "AplicationEmployee"

    Public MustOverride Function loadAplicationsEmployee(ByVal strUserName As String) As ArrayList

    Public MustOverride Sub updateAplicationsEmployee(ByVal strUserName As String, ByVal hshAplicationsID As Hashtable)

#End Region

#Region "Utils"

    'MustOverride Sub loadDdl(ByVal ddl As DropDownList, ByVal strDataValueField As String, _
    'ByVal strDataTextField As String, ByVal strTable As String, Optional ByVal strStratItem As String = "Selecionar")

#End Region

End Class





