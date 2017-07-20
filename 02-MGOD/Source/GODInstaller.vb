
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
