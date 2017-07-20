
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
Imports System.Collections


Public Class Bibliography
    Inherits CollectionBase


    Default Public Property Item(ByVal index As Integer) As BibRefItem
        Get
            Return CType(List(index), BibRefItem)
        End Get
        Set(ByVal Value As BibRefItem)
            List(index) = Value
        End Set
    End Property


    Public Function Add(ByVal ID As Integer, ByVal BibRef As String) As Integer
        Return List.Add(New BibRefItem(ID, BibRef))
    End Function 'Add


    Public Function Add(ByVal BibRef As String) As Integer
        Return List.Add(New BibRefItem(BibRef))
    End Function 'Add

    Public Function IndexOf(ByVal value As BibRefItem) As Integer
        Return List.IndexOf(value)
    End Function 'IndexOf


    Public Sub Insert(ByVal index As Integer, ByVal value As BibRefItem)
        List.Insert(index, value)
    End Sub 'Insert


    Public Sub Remove(ByVal value As BibRefItem)
        List.Remove(value)
    End Sub 'Remove


    Public Function Contains(ByVal value As BibRefItem) As Boolean
        Return List.Contains(value)
    End Function 'Contains


    Public Overrides Function ToString() As String
        Dim BibRef As BibRefItem
        Dim Ret As String = ""
        For Each BibRef In MyBase.List
            Ret = BibRef.ToString & Chr(13)
        Next
        If Ret.Length > 2 Then Ret = Ret.Remove(Ret.Length - 2, 1)
        Return Ret
    End Function

End Class





Public Class BibRefItem
    Private myID As Integer
    Private myBibRef As String


    Public Sub New(ByVal BibRef As String)
        myBibRef = BibRef
        myID = 0
    End Sub

    Public Sub New(ByVal ID As Integer, ByVal BibRef As String)
        myBibRef = BibRef
        myID = ID
    End Sub

    Property BibRef() As String
        Get
            Return myBibRef
        End Get
        Set(ByVal Value As String)
            myBibRef = Value
        End Set
    End Property


    Property ID() As Integer
        Get
            Return myID
        End Get
        Set(ByVal Value As Integer)
            myID = Value
        End Set
    End Property

    Public Function Clone() As Object
        Return New BibRefItem(myID, myBibRef)
    End Function

    Public Overrides Function ToString() As String
        Return myBibRef
    End Function



End Class
