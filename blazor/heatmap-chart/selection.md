---
layout: post
title: Selection in Blazor HeatMap Chart Component | Syncfusion
description: Checkout and learn here all about Selection in Syncfusion Blazor HeatMap Chart component and much more.
platform: Blazor
control: HeatMap Chart
documentation: ug
---

# Selection in Blazor HeatMap Chart Component

In the [Blazor HeatMap Chart](https://www.syncfusion.com/blazor-components/blazor-heatmap-chart), the cell selection is used to select the single or multiple heatmap cells at runtime and get the selected cell details using the [CellSelected](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.HeatMap.HeatMapEvents.html#Syncfusion_Blazor_HeatMap_HeatMapEvents_CellSelected) event. You can enable the cell selection using the [AllowSelection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.HeatMap.SfHeatMap-1.html#Syncfusion_Blazor_HeatMap_SfHeatMap_1_AllowSelection) property.

```cshtml

@using Syncfusion.Blazor.HeatMap

<SfHeatMap AllowSelection="true" DataSource="@HeatMapData">
    <HeatMapTitleSettings Text="Sales Revenue per Employee (in 1000 US$)">
    </HeatMapTitleSettings>
    <HeatMapXAxis Labels="@XAxisLabels"></HeatMapXAxis>
    <HeatMapYAxis Labels="@YAxisLabels"></HeatMapYAxis>
    <HeatMapCellSettings ShowLabel="true" TileType="CellType.Rect"></HeatMapCellSettings>
</SfHeatMap>

@code{
    public int[,] GetDefaultData()
    {
        int[,] dataSource = new int[,]
        {
            {73, 39, 26, 39, 94, 0},
            {93, 58, 53, 38, 26, 68},
            {99, 28, 22, 4, 66, 90},
            {14, 26, 97, 69, 69, 3},
            {7, 46, 47, 47, 88, 6},
            {41, 55, 73, 23, 3, 79}
        };
        return dataSource;
    }
    public string[] XAxisLabels = new string[] {"Nancy", "Andrew", "Janet", "Margaret", "Steven", "Michael" };
    public string[] YAxisLabels = new string[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
    public object HeatMapData { get; set; }
    protected override void OnInitialized()
    {
        HeatMapData = GetDefaultData();
    }
}

```

![Selection in Blazor HeatMap Chart](images/blazor-heatmap-chart-selection.png)