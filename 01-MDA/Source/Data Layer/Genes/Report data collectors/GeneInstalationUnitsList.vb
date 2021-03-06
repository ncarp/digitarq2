
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

Public Class GeneInstalationUnitsList
    Inherits StopableGene

    Private myProgressDialog As ProgressDialog

    Public Sub New(ByVal ProgressDialog As ProgressDialog)
        myProgressDialog = ProgressDialog
    End Sub



    Public Overrides Function Apply(ByVal obj As LazyNode, ByVal ChildrenResults As Microsoft.VisualBasic.Collection) As Object
        Dim Result As New Hashtable
        Dim ChildInstalationUnits As LazyNodeCollection
        Dim InstalationUnit As LazyNode

        ChildInstalationUnits = GetChildInstalationUnits(obj)

        For Each InstalationUnit In ChildInstalationUnits
            Result = AppendToHashtable(Result, InstalationUnit, obj)
        Next

        Dim ChildResult As Hashtable
        For Each ChildResult In ChildrenResults
            Dim Key As LazyNode
            For Each Key In ChildResult.Keys
                Result = AppendToHashtable(Result, Key, CType(ChildResult.Item(Key), LazyNodeCollection))
            Next
        Next

        If Not myProgressDialog Is Nothing Then
            myProgressDialog.Message = String.Format(InfoMessage("CollectingData.ProgressBar.Progression"), obj.UnitId)
            myProgressDialog.Increment()
            Me.StopCatamorfism = myProgressDialog.Cancel

        End If

        Return Result
    End Function



    Private Function AppendToHashtable(ByVal Hash As Hashtable, ByVal Key As LazyNode, ByVal Value As LazyNode) As Hashtable
        Dim KeyNode As LazyNode = GetKeyNode(Hash.Keys, Key)
        If Not KeyNode Is Nothing Then
            Dim ParentsList As LazyNodeCollection = Hash.Item(KeyNode)
            ParentsList.Add(Value)
            'Hash.Add(KeyNode, ParentsList) ' Esta linha poder� ser omitida?!!?!?
        Else
            Dim ParentsList As New LazyNodeCollection
            ParentsList.Add(Value)
            Hash.Add(Key, ParentsList)
        End If

        Debug.WriteLine("ADDED TO HASHTABLE " & Key.UnitId & " " & Value.UnitId)
        Return Hash
    End Function


    Private Function GetKeyNode(ByVal Nodes As ICollection, ByVal NodeToSearch As LazyNode) As LazyNode
        Dim Node As LazyNode
        For Each Node In Nodes
            If Node.OtherLevel.Equals(NodeToSearch.OtherLevel) AndAlso Node.UnitId.Equals(NodeToSearch.UnitId) Then Return Node
        Next
        Return Nothing
    End Function


    Private Function AppendToHashtable(ByVal Hash As Hashtable, ByVal Key As LazyNode, ByVal Values As LazyNodeCollection) As Hashtable
        Dim Node As LazyNode
        For Each Node In Values
            Hash = AppendToHashtable(Hash, Key, Node)
        Next
        Return Hash
    End Function



    Private Function GetChildInstalationUnits(ByVal Node As LazyNode) As LazyNodeCollection
        Dim ChildNode As LazyNode
        Dim Result As New LazyNodeCollection

        For Each ChildNode In Node.Children
            If ChildNode.OtherLevel = EADDefinitions.OTHERLEVEL_INSTALATIONUNIT Then
                Result.Add(ChildNode)
            End If
        Next
        Return Result
    End Function

End Class