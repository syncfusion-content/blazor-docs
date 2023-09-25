---
layout: post
title: Events in Blazor HeatMap Component | Syncfusion
description: Checkout and learn here all about events in Syncfusion Blazor HeatMap component and much more details.
platform: Blazor
control: HeatMap Chart
documentation: ug
---

# Events in Blazor HeatMap chart Component
 
This section explains the list of events that will be triggered for appropriate actions in HeatMap. The events should be declared in the HeatMap component using the [HeatMapEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.HeatMap.HeatMapEvents.html).

## CellRendering

The [CellRendering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.HeatMap.HeatMapEvents.html#Syncfusion_Blazor_HeatMap_HeatMapEvents_CellRendering) event will be triggered before each HeatMap cell is rendered. To know more about arguments of this event, refer [here](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.HeatMap.HeatMapCellRenderEventArgs.html).

The following example demonstrates how to customize the data label, color and border color of the cells using the `CellRendering` event.

```cshtml
@using Syncfusion.Blazor.HeatMap

<SfHeatMap DataSource="@dataSource">
    <HeatMapEvents CellRendering="@CellRender"/>
    <HeatMapTitleSettings Text="GDP Growth Rate for Major Economies (in Percentage)"/>
    <HeatMapXAxis Labels="@xAxisLabels"/>
    <HeatMapYAxis Labels="@yAxisLabels"/>
</SfHeatMap>
@code{
    private void CellRender(HeatMapCellRenderEventArgs args)
    {
        if (args.CellValue == "2.2")
        {
            args.CellValue = "UPFRONT TEXT";
            args.CellColor = "#c7afcf";
            args.BorderColor = "Red";
        }
    }
    double[,] dataSource = new double[2, 2]
    {
            {9.5, 2.2 },
            {4.3, 8.9 }
    };
    string[] xAxisLabels = new string[] { "China", "India" };
    string[] yAxisLabels = new string[] { "2008", "2009" };
}
```
![CellRendering event in Blazor HeatMap chart](images/events/blazor-heatmap-chart-cell-rendering-event.png)