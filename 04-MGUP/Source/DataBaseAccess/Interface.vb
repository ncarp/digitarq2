
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





