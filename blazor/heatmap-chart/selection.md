---
layout: post
title: Selection in Blazor HeatMap Chart Component | Syncfusion
description: Checkout and learn here all about Selection in Syncfusion Blazor HeatMap Chart component and much more.
platform: Blazor
control: HeatMap Chart
documentation: ug
---

# Selection in Blazor HeatMap Chart Component

In the [Blazor HeatMap Chart](https://www.syncfusion.com/blazor-components/blazor-heatmap-chart), the cell selection is used to select the single or multiple heat map cells at runtime and get the selected cell details using the `CellSelected`  event. You can enable this cell selection using the `AllowSelection` property.

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
    int[,] GetDefaultData()
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
    string[] XAxisLabels = new string[] {"Nancy", "Andrew", "Janet", "Margaret", "Steven", "Michael" };
    string[] YAxisLabels = new string[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
    public object HeatMapData { get; set; }
    protected override void OnInitialized()
    {
        HeatMapData = GetDefaultData();
    }
}

```

![Selection in Blazor HeatMap Chart](images/blazor-heatmap-chart-selection.png)

## Enable single cell selection

In the HeatMap, the [EnableMultiSelect]() property is used to allow single cell selection. When you set the `EnableMultiSelect` property to **false**, only one cell is selected. By default, `EnableMultiSelect` property is set to **true**.

```cshtml

@using Syncfusion.Blazor.HeatMap

<SfHeatMap @ref="Heatmap" Height="300px" DataSource="@DataSource"AllowSelection=true>
   
    <HeatMapTitleSettings Text="Top export products 2014-2018, Value in USD million"></HeatMapTitleSettings>
    <HeatMapXAxis Labels="@XLabels"></HeatMapXAxis>
    <HeatMapYAxis Labels="@YLabels"></HeatMapYAxis>
    <HeatMapPaletteSettings>
        <HeatMapPalettes>
            <HeatMapPalette Color="#3C5E62"></HeatMapPalette>
            <HeatMapPalette Color="#86C843"></HeatMapPalette>
        </HeatMapPalettes>
    </HeatMapPaletteSettings>
    <HeatMapLegendSettings Visible=false></HeatMapLegendSettings>
</SfHeatMap>

@code{

    public SfHeatMap<double[,]> Heatmap;
    public int YIndex = 0;
    public string[] XLabels = new string[] { "Cereals", "Meat", "Spices", "Tea", "Edible Oil", "Dairy Products", "Wheat" };
    public string[] YLabels = new string[] { "2014", "2015", "2016", "2017", "2018" };
    public double[,] DataSource = new double[,]
           {
        {2.9, 5.2, 3.4, 5.6, 4.4},
        {6.6, 4.8, 8, 3.9, 6.5},
        {5.1, 4.6, 5.4, 3.9, 4.3},
        {5.2, 4.3, 3.9, 6.2, 6.4},
        {7, 3, 1.9, 5.9, 3.5},
        {7.8, 5.9, 3.9, 4.3, 4.3},
        {6.5, 4.3, 3.9, 5.2, 3.9}
    };
}

```

