
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
