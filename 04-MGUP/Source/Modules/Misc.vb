
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

Imports System.IO
Imports blong.WebControls

Public Class Misc
    Inherits BaseClassUC

    Public formatString As String = "{0:#,###0.00;(#,###0.00);0.00}"
    Public formatStringPerc As String = "{0:#,###0.00%;(#,###0.00);0.00%}"

    Public Sub New()
    End Sub

    Public Sub MakeChart(ByVal table As Table, ByVal Chart As WebChart, ByVal title As String, ByVal header As Boolean, ByVal ind As Int16)
        With Chart
            .ID = Chart.ID
            .Type = WebChart.ChartType.Pie
            ' Override WebChartItems for Pie Data
            Dim highVal As Int32 = 0
            Dim ExplodeIndex As Int16 = 0
            Dim i As Int16 = 0
            Dim siz As Int16 = table.Rows.Count
            For Each r As TableRow In table.Rows
                If header = True Or i = siz - 1 Then
                    header = False
                Else
                    'Dim c As TableCell = r.Cells.Item(1)
                    .WebChartItems.Add(New WebChartItem(r.Cells.Item(0).Text, Convert.ToInt32(r.Cells.Item(ind).Text), False))
                    If Convert.ToInt32(r.Cells.Item(ind).Text) > highVal Then
                        highVal = Convert.ToInt32(r.Cells.Item(ind).Text)
                        'ExplodeIndex = i - 1
                    End If
                End If
                i += 1
            Next
            'Explode High Value
            '.WebChartItems(ExplodeIndex).Explode = True
            .ShowLegend = True
            .Diameter = 180
            '.ExplodeOffset = 20
            .Rotate = 70
            .Thickness = WebChart.PieThickness.Thin
            .Title = title
            'Specify output format
            .Format = WebChart.ChartFormat.Png
        End With
    End Sub


    Public Sub MakeChart(ByVal ds As DataSet, ByVal Chart As WebChart, ByVal title As String, ByVal ShowTitle As Boolean, ByVal indText As Int16, ByVal indValue As Int16)
        With Chart
            .ID = Chart.ID
            .Type = WebChart.ChartType.Pie
            Dim siz As Int16 = ds.Tables(0).Rows.Count
            For Each r As DataRow In ds.Tables(0).Rows
                .WebChartItems.Add(New WebChartItem(r.Item(indText), Convert.ToInt32(r.Item(indValue)), False))
            Next
            .ShowLegend = True
            .Diameter = 180
            .Rotate = 70
            .Thickness = WebChart.PieThickness.Thin
            .Title = title
            .ShowTitle = ShowTitle
            .Format = WebChart.ChartFormat.Png
        End With
    End Sub

    Public Sub MakeChart(ByVal dt As DataTable, ByVal Chart As WebChart, ByVal title As String, ByVal ShowTitle As Boolean, ByVal indText As Int16, ByVal indValue As Int16)
        With Chart
            .ID = Chart.ID
            .Type = WebChart.ChartType.Pie
            Dim siz As Int16 = dt.Rows.Count
            For Each r As DataRow In dt.Rows
                .WebChartItems.Add(New WebChartItem(r.Item(indText), Convert.ToInt64(r.Item(indValue)), False))
            Next
            .ShowLegend = True
            .Diameter = 180
            .Rotate = 70
            .Thickness = WebChart.PieThickness.Thin
            .Title = title
            .ShowTitle = ShowTitle
            .Format = WebChart.ChartFormat.Png
        End With
    End Sub

    Public Sub MakeChartMonths(ByVal ds As DataSet, ByVal Chart As WebChart, ByVal title As String, ByVal ShowTitle As Boolean, ByVal indText As Int16, ByVal indValue As Int16)
        With Chart
            .ID = Chart.ID
            .Type = WebChart.ChartType.Pie
            Dim siz As Int16 = ds.Tables(0).Rows.Count
            For Each r As DataRow In ds.Tables(0).Rows
                .WebChartItems.Add(New WebChartItem(GetMonthName(r.Item(indText)), Convert.ToInt32(r.Item(indValue)), False))
            Next
            .ShowLegend = True
            .Diameter = 200
            .Rotate = 70
            .Thickness = WebChart.PieThickness.Thin
            .Title = title
            .ShowTitle = ShowTitle
            .Format = WebChart.ChartFormat.Png
        End With
    End Sub

    Public Sub MakeChartNT(ByVal table As Table, ByVal Chart As WebChart, ByVal title As String, ByVal ind As Int16)
        With Chart
            .ID = Chart.ID
            .Type = WebChart.ChartType.Pie
            ' Override WebChartItems for Pie Data
            Dim highVal As Int32 = 0
            Dim ExplodeIndex As Int16 = 0
            Dim header As Boolean = True
            For Each r As TableRow In table.Rows
                If header = True Then
                    header = False
                Else
                    'Dim c As TableCell = r.Cells.Item(1)
                    .WebChartItems.Add(New WebChartItem(r.Cells.Item(0).Text, Convert.ToInt32(r.Cells.Item(ind).Text), False))
                    If Convert.ToInt32(r.Cells.Item(ind).Text) > highVal Then
                        highVal = Convert.ToInt32(r.Cells.Item(ind).Text)
                        'ExplodeIndex = i - 1
                    End If
                End If
            Next
            'Explode High Value
            '.WebChartItems(ExplodeIndex).Explode = True
            .ShowLegend = True
            .Diameter = 180
            '.ExplodeOffset = 20
            .Rotate = 70
            .Thickness = WebChart.PieThickness.Thin
            .Title = title
            'Specify output format
            .Format = WebChart.ChartFormat.Png
        End With
    End Sub

    Public Function exportDG(ByVal dt As DataTable) As StringWriter
        Dim sw As New StringWriter
        sw.WriteLine()
        sw.WriteLine(GetLabel("statsIBDGerRel.lblCode") & ";" & GetLabel("statsIBDGerRel.lblDesignation"))
        For Each dr As DataRow In dt.Rows
            sw.Write(dr(0).ToString())
            sw.Write(";")
            sw.Write(dr(1).ToString())
            sw.WriteLine()
        Next
        Return sw
    End Function

    Public Function exportCSV5(ByVal table As Table) As StringWriter
        Dim output As StringWriter = New StringWriter
        For Each r As TableRow In table.Rows
            output.WriteLine(r.Cells.Item(0).Text & ";" & r.Cells.Item(1).Text & ";" & r.Cells.Item(2).Text & ";" & r.Cells.Item(3).Text & ";" & r.Cells.Item(4).Text)
        Next
        Return output
    End Function

    Public Function exportCSV4(ByVal table As Table) As StringWriter
        Dim output As StringWriter = New StringWriter
        For Each r As TableRow In table.Rows
            output.WriteLine(r.Cells.Item(0).Text & ";" & r.Cells.Item(1).Text & ";" & r.Cells.Item(2).Text & ";" & r.Cells.Item(3).Text)
        Next
        Return output
    End Function

    Public Function exportCSV3(ByVal table As Table) As StringWriter
        Dim output As StringWriter = New StringWriter
        For Each r As TableRow In table.Rows
            output.WriteLine(r.Cells.Item(0).Text & ";" & r.Cells.Item(1).Text & ";" & r.Cells.Item(2).Text)
        Next
        Return output
    End Function

    Public Function exportCSV2(ByVal table As Table) As StringWriter
        Dim output As StringWriter = New StringWriter
        For Each r As TableRow In table.Rows
            output.WriteLine(r.Cells.Item(0).Text & ";" & r.Cells.Item(1).Text)
        Next
        Return output
    End Function

    Public Sub loadDays(ByVal ddlYear As DropDownList, ByVal ddlMonth As DropDownList, ByVal ddlDay As DropDownList)
        'Dias
        Dim alDay As ArrayList = New ArrayList
        Dim lastDay As Int16 = 31
        If ddlMonth.SelectedValue = GetLabel("statsPGFunc.ddlApr") Or ddlMonth.SelectedValue = GetLabel("statsPGFunc.ddlJun") Or ddlMonth.SelectedValue = GetLabel("statsPGFunc.ddlSep") Or ddlMonth.SelectedValue = GetLabel("statsPGFunc.ddlNov") Then
            lastDay = 30
        ElseIf ddlMonth.SelectedValue = GetLabel("statsPGFunc.ddlFev") Then
            If (Double.Parse(ddlYear.SelectedValue) Mod 4) = 0 Then
                lastDay = 29
            Else : lastDay = 28
            End If
        End If
        Dim i As Int16
        For i = 1 To lastDay Step 1
            alDay.Add(i)
        Next
        ddlDay.DataSource() = alDay
        ddlDay.DataBind()
    End Sub

    Public Sub setHeaderCell(ByVal c As TableCell)
        c.HorizontalAlign = HorizontalAlign.Center
        c.ForeColor = System.Drawing.Color.White
        c.BackColor = System.Drawing.Color.Gainsboro
        c.Font.Size = FontUnit.Point(9)
        c.Font.Bold = True
        c.Height = Unit.Pixel(22)
    End Sub

    Public Function loadHTMonth() As Hashtable
        Dim htMonth As New Hashtable
        'Apoio para mapear datas para as queries sql
        htMonth.Add(GetLabel("statsPGFunc.ddlJan"), "1")
        htMonth.Add(GetLabel("statsPGFunc.ddlFev"), "2")
        htMonth.Add(GetLabel("statsPGFunc.ddlMar"), "3")
        htMonth.Add(GetLabel("statsPGFunc.ddlApr"), "4")
        htMonth.Add(GetLabel("statsPGFunc.ddlMay"), "5")
        htMonth.Add(GetLabel("statsPGFunc.ddlJun"), "6")
        htMonth.Add(GetLabel("statsPGFunc.ddlJul"), "7")
        htMonth.Add(GetLabel("statsPGFunc.ddlAug"), "8")
        htMonth.Add(GetLabel("statsPGFunc.ddlSep"), "9")
        htMonth.Add(GetLabel("statsPGFunc.ddlOct"), "10")
        htMonth.Add(GetLabel("statsPGFunc.ddlNov"), "11")
        htMonth.Add(GetLabel("statsPGFunc.ddlDec"), "12")
        Return htMonth
    End Function

    Public Function loadHTMonth2() As Hashtable
        Dim htMonth As New Hashtable
        'Apoio para mapear datas para as queries sql
        htMonth.Add(1, GetLabel("statsPGFunc.ddlJan"))
        htMonth.Add(2, GetLabel("statsPGFunc.ddlFev"))
        htMonth.Add(3, GetLabel("statsPGFunc.ddlMar"))
        htMonth.Add(4, GetLabel("statsPGFunc.ddlApr"))
        htMonth.Add(5, GetLabel("statsPGFunc.ddlMay"))
        htMonth.Add(6, GetLabel("statsPGFunc.ddlJun"))
        htMonth.Add(7, GetLabel("statsPGFunc.ddlJul"))
        htMonth.Add(8, GetLabel("statsPGFunc.ddlAug"))
        htMonth.Add(9, GetLabel("statsPGFunc.ddlSep"))
        htMonth.Add(10, GetLabel("statsPGFunc.ddlOct"))
        htMonth.Add(11, GetLabel("statsPGFunc.ddlNov"))
        htMonth.Add(12, GetLabel("statsPGFunc.ddlDec"))
        Return htMonth
    End Function

    Public Function loadMonthNames() As ArrayList
        Dim alMonth As ArrayList = New ArrayList
        alMonth.Add(GetLabel("statsPGFunc.ddlJan"))
        alMonth.Add(GetLabel("statsPGFunc.ddlFev"))
        alMonth.Add(GetLabel("statsPGFunc.ddlMar"))
        alMonth.Add(GetLabel("statsPGFunc.ddlApr"))
        alMonth.Add(GetLabel("statsPGFunc.ddlMay"))
        alMonth.Add(GetLabel("statsPGFunc.ddlJun"))
        alMonth.Add(GetLabel("statsPGFunc.ddlJul"))
        alMonth.Add(GetLabel("statsPGFunc.ddlAug"))
        alMonth.Add(GetLabel("statsPGFunc.ddlSep"))
        alMonth.Add(GetLabel("statsPGFunc.ddlOct"))
        alMonth.Add(GetLabel("statsPGFunc.ddlNov"))
        alMonth.Add(GetLabel("statsPGFunc.ddlDec"))
        Return alMonth
    End Function

    Public Function loadNivDescr() As ArrayList
        Dim alNiv As ArrayList = New ArrayList
        alNiv.Add("F")
        alNiv.Add("SF")
        alNiv.Add("SC")
        alNiv.Add("SSC")
        alNiv.Add("SSSC")
        alNiv.Add("SR")
        alNiv.Add("SSR")
        alNiv.Add("UI")
        alNiv.Add("D")
        alNiv.Add("DC")
        Return alNiv
    End Function

    Public Function loadDescr() As Hashtable
        Dim ardesc As Hashtable = New Hashtable
        ardesc.Add("F", "Node F%")
        ardesc.Add("SF", "Node SF%")
        ardesc.Add("SC", "Node SC%")
        ardesc.Add("SSC", "Node SSC%")
        ardesc.Add("SSSC", "Node SSSC%")
        ardesc.Add("SR", "Node SR%")
        ardesc.Add("SSR", "Node SSR%")
        ardesc.Add("UI", "Node UI%")
        ardesc.Add("D", "Node D %")
        ardesc.Add("DC", "Node DC%")
        Return ardesc
    End Function

    Function SortedListFromHashtables(ByVal ht1 As Hashtable, ByVal ht2 As Hashtable) As SortedList
        ' Create a case-insensitive sorted list 
        Dim list As SortedList = Specialized.CollectionsUtil.CreateCaseInsensitiveSortedList()
        ' initialize the list with all keys in first hashtable
        For Each key As Object In ht1.Keys
            list.Add(key, key)
        Next
        ' add keys from second hashtable
        For Each key As Object In ht2.Keys
            If Not ht1.Contains(key) Then
                list.Add(key, key)
            End If
        Next
        Return list

    End Function
End Class
