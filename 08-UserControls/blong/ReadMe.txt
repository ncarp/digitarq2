These files are the full source code for the WebChart control.

Control Usage:

In order to use this control you must first compile it to your
\bin directory and then make a reference to it in your web application. A command line compiler .bat file has been added to this zipped file (WebChartCompile.bat).

If you need assistance on how to install a project reference in VS.NET please consult the online VS.NET help documentation. 

---------------------------------------------------------------------------------------------------------------
WebChart History:

Version 1.0 - 10/24/2002
Initial Release

Version 1.1 - 1/1/2003
No longer rely on implicit type casting. Option Explicit/Strict enabled.
Removed unecessary code.
Added code to support image streaming, no longer writes images to disk.

---------------------------------------------------------------------------------------------------------------
Web.Config:

Please insert the following XML tags into your Web.config file directly underneath the opening <system.web> tag.  This tag allows ASP.NET to track WebChart images via Application Variable.  This tag is required for proper operation.

<httpModules>
    <add name="WebChartImageStream" type="blong.WebControls.WebChartImageStream, blong" />
</httpModules>

---------------------------------------------------------------------------------------------------------------
Code Example:

Imports System.Data.SqlClient
Imports blong.WebControls

Protected Sub MakeChart()

      ' Define Objects
        Dim Chart As WebChart
        Dim i As Int32
        Dim cn As New SqlConnection(Session.Item("strConn"))
        Dim cmd As New SqlCommand("WebHitsPerMonth", cn)
        Dim dReader As SqlDataReader

        cn.Open()
        cmd.CommandType = CommandType.StoredProcedure
        dReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        ' Override Default Constructor
        ' Copyright Symbol: Hold ALT + 0681
        Chart = New WebChart()

        With Chart
            .ID = "CodeChart"
            .Type = WebChart.ChartType.Pie

            ' Override WebChartItems for Pie Data
            Dim highVal As Single
            Dim ExplodeIndex As Int32

            While dReader.Read
                If Not IsDBNull(dReader("HitYear")) Then
                    .WebChartItems.Add(New WebChartItem(dReader("HitMonth") & " " & dReader("HitYear"), dReader("HitMonthCount"), False))
                    If dReader("HitMonthCount") > highVal Then
                        highVal = dReader("HitMonthCount")
                        ExplodeIndex = i - 1
                    End If
                End If
                i += 1
            End While

            'Explode High Value
            .WebChartItems(ExplodeIndex).Explode = True
            .ShowLegend = True
            .Diameter = WebChart.PieDiameter.Larger
            .ExplodeOffset = 25
            .Rotate = 70
            .Thickness = WebChart.PieThickness.Medium
            .Title = "My Run Time Chart"

            'Specify output format
            .Format = WebChart.ChartFormat.Png

        End With

        ' Add control to web form
        Me.Controls.Add(Chart)

    End Sub

---------------------------------------------------------------------------------------------------------------

Disclaimer:  This control has not been tested in a production 
environment.  The author of this control shall not be responsible for any losses incurred as the result of deploying this control on your website.  Use this control at your own risk!

---------------------------------------------------------------------------------------------------------------