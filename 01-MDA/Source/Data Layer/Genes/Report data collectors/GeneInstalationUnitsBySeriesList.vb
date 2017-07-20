
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

Public Class GeneInstalationUnitsBySeriesList
    Inherits StopableGene

    Private myProgressDialog As ProgressDialog

    Public Sub New(ByVal ProgressDialog As ProgressDialog)
        myProgressDialog = ProgressDialog
    End Sub



    Public Overrides Function Apply(ByVal obj As LazyNode, ByVal ChildrenResults As Microsoft.VisualBasic.Collection) As Object
        Dim Result As New Hashtable
        Dim ChildInstalationUnits As LazyNodeCollection

        'If obj.OtherLevel.Equals(EADDefinitions.OTHERLEVEL_SUBFONDS) Then
        '    Result.Add(obj, New LazyNodeCollection)
        '    Debug.WriteLine("added subfonds " & obj.UnitId)
        'End If


        If obj.OtherLevel = EADDefinitions.OTHERLEVEL_SERIES OrElse obj.OtherLevel = EADDefinitions.OTHERLEVEL_SUBSERIES Then
            ChildInstalationUnits = GetChildInstalationUnits(obj)

            For Each InstalationUnit As LazyNode In ChildInstalationUnits
                Result = AppendToHashtable(Result, obj, InstalationUnit)
            Next
        End If


        For Each ChildResult As Hashtable In ChildrenResults
            For Each Key As LazyNode In ChildResult.Keys
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
            'Hash.Add(KeyNode, ParentsList) ' Esta linha poderá ser omitida?!!?!?
        Else
            Dim ParentsList As New LazyNodeCollection
            ParentsList.Add(Value)
            Hash.Add(Key, ParentsList)
        End If

        'Debug.WriteLine("ADDED TO HASHTABLE " & Key.UnitId & " " & Value.UnitId)
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