
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

Imports System.ComponentModel
Imports System.Configuration.Install
Imports System.IO
Imports System.Reflection
Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports System.Xml
Imports System.Reflection.Assembly
Imports System.Configuration.ConfigurationSettings
Imports System.DirectoryServices

<RunInstaller(True)> Public Class DigitarqInstaller
    Inherits System.Configuration.Install.Installer

#Region " Component Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Installer overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

#End Region

    Public Overrides Sub Install(ByVal stateSaver As System.Collections.IDictionary)

        MyBase.Install(stateSaver)

        Dim FoundItServerAddress As Boolean = False
        Dim FoundItDatabase As Boolean = False
        Dim FoundItUsername As Boolean = False
        Dim FoundItPassword As Boolean = False

        Dim ConfigFullName As String

        Try
            Dim AplicationName As String
            Dim ServerAddress As String = Me.Context.Parameters.Item("ServerAddress")
            Dim Database As String = Me.Context.Parameters.Item("Database")
            Dim AssemblyPath As String = Me.Context.Parameters("assemblypath")
            Dim MainDirectory As String = AssemblyPath.Substring(0, AssemblyPath.LastIndexOf("\bin"))
            ConfigFullName = MainDirectory + "\Web.config"
            Dim XmlDocument As New System.Xml.XmlDocument
            XmlDocument.Load(ConfigFullName)

            ' Throw New InstallException(XmlDocument.OuterXml)
            ' Finds the right node and change it to the new value.
            Dim Node As System.Xml.XmlNode

            For Each Node In XmlDocument.Item("configuration").Item("sqlServerSettings")
                If Node.Name = "add" Then ' skip any comments
                    Select Case Node.Attributes.GetNamedItem("key").Value
                        Case "ServerAddress"
                            Node.Attributes.GetNamedItem("value").Value = ServerAddress
                            FoundItServerAddress = True
                        Case "Database"
                            Node.Attributes.GetNamedItem("value").Value = Database
                            FoundItDatabase = True
                    End Select
                End If
            Next Node

            For Each Node In XmlDocument.Item("configuration").Item("appSettings")
                If Node.Name = "add" Then ' skip any comments
                    Select Case Node.Attributes.GetNamedItem("key").Value
                        Case "Aplication.Name"
                            AplicationName = Node.Attributes.GetNamedItem("value").Value
                    End Select
                End If
            Next

            If Not FoundItServerAddress Then
                Throw New InstallException("Config file did not contain a ServerName section.")
            End If

            If Not FoundItDatabase Then
                Throw New InstallException("Config file did not contain a DatabaseName section.")
            End If


            XmlDocument.Save(ConfigFullName)

            CreateVirtualDirectory("localhost", AplicationName, MainDirectory)

        Catch ex As Exception
            Throw New InstallException(ConfigFullName)
        End Try
    End Sub


    Private Sub CreateVirtualDirectory(ByVal WebSite As String, ByVal AppName As String, ByVal Path As String)

        Dim IISSchema As New System.DirectoryServices.DirectoryEntry("IIS://" & WebSite & "/Schema/AppIsolated")
        Dim CanCreate As Boolean = Not IISSchema.Properties("Syntax").Value.ToString.ToUpper() = "BOOLEAN"
        IISSchema.Dispose()
        If CanCreate Then
            Dim PathCreated As Boolean

            Try
                Dim IISAdmin As New System.DirectoryServices.DirectoryEntry("IIS://" & WebSite & "/W3SVC/1/Root")
                If Not System.IO.Directory.Exists(Path) Then
                    System.IO.Directory.CreateDirectory(Path)
                    PathCreated = True
                End If

                For Each VD As System.DirectoryServices.DirectoryEntry In IISAdmin.Children
                    If VD.Name = AppName Then
                        IISAdmin.Invoke("Delete", New String() {VD.SchemaClassName, AppName})
                        IISAdmin.CommitChanges()
                        Exit For
                    End If
                Next VD

                'Create and setup new virtual directory
                Dim VDir As System.DirectoryServices.DirectoryEntry = IISAdmin.Children.Add(AppName, "IIsWebVirtualDir")
                VDir.Properties("Path").Item(0) = Path
                VDir.Properties("AppFriendlyName").Item(0) = AppName
                VDir.Properties("EnableDirBrowsing").Item(0) = False
                VDir.Properties("AccessRead").Item(0) = True
                VDir.Properties("AccessExecute").Item(0) = True
                VDir.Properties("AccessWrite").Item(0) = False
                VDir.Properties("AccessScript").Item(0) = True
                VDir.Properties("AuthNTLM").Item(0) = True
                VDir.Properties("EnableDefaultDoc").Item(0) = True
                VDir.Properties("DefaultDoc").Item(0) = "default.htm,default.aspx,default.asp"
                VDir.Properties("AspEnableParentPaths").Item(0) = True
                VDir.CommitChanges()

                'the following are acceptable params
                'INPROC = 0
                'OUTPROC = 1
                'POOLED = 2
                VDir.Invoke("AppCreate", 1)

            Catch Ex As Exception
                If PathCreated Then
                    System.IO.Directory.Delete(Path)
                End If
                'Throw New InstallException(WebSite + "#" + AppName + "#" + Path)
            End Try
        End If
    End Sub

End Class
