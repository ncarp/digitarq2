
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
Imports System.Threading
Imports System.Data.SqlClient
Imports System.Configuration

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

        Dim ServerAddress As String = Me.Context.Parameters.Item("ServerAddress")
        Dim Database As String = Me.Context.Parameters.Item("Database")
        Dim InstitutionName As String = Me.Context.Parameters.Item("InstitutionName")
        Dim InstitutionCode As String = Me.Context.Parameters.Item("InstitutionCode")
        Dim EmailFrom As String = Me.Context.Parameters.Item("EmailFrom")
        Dim SMTPEmail As String = Me.Context.Parameters.Item("SMTPEmail")

        Dim AssemblyPath As String = Me.Context.Parameters("assemblypath")
        Dim MainDirectory As String = AssemblyPath.Substring(0, AssemblyPath.LastIndexOf("\"))
        Dim ConfigFullName As String = MainDirectory + "\MGOD.exe.config"

        Try
            ' Loads the config file into the XML DOM.
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
                        Case "Database"
                            Node.Attributes.GetNamedItem("value").Value = Database
                    End Select
                End If
            Next Node

            For Each Node In XmlDocument.Item("configuration").Item("InstitutionSettings")
                If Node.Name = "add" Then ' skip any comments
                    Select Case Node.Attributes.GetNamedItem("key").Value
                        Case "Institution.Code"
                            Node.Attributes.GetNamedItem("value").Value = InstitutionCode
                        Case "Institution.Name"
                            Node.Attributes.GetNamedItem("value").Value = InstitutionName
                    End Select
                End If
            Next Node

            For Each Node In XmlDocument.Item("configuration").Item("EmailSettings")
                If Node.Name = "add" Then ' skip any comments
                    Select Case Node.Attributes.GetNamedItem("key").Value
                        Case "Email.From"
                            Node.Attributes.GetNamedItem("value").Value = EmailFrom
                        Case "SmtpMail.SmtpServer"
                            Node.Attributes.GetNamedItem("value").Value = SMTPEmail
                    End Select
                End If
            Next Node

            XmlDocument.Save(ConfigFullName)

        Catch ex As Exception
            Throw New InstallException(ConfigFullName)
        End Try
    End Sub

End Class
