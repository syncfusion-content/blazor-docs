---
layout: post
title: Dimensions in Blazor HeatMap Chart Component | Syncfusion
description: Checkout and learn here all about Dimensions in Syncfusion Blazor HeatMap Chart component and much more.
platform: Blazor
control: HeatMap Chart
documentation: ug
---

# Dimensions in Blazor HeatMap Chart Component

## Size for heatmap

You can set the size of heatmap directly by using the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.HeatMap.Size.html#Syncfusion_Blazor_HeatMap_Size_Width) and [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.HeatMap.Size.html#Syncfusion_Blazor_HeatMap_Size_Height) properties.

### In pixel

You can set the size for heatmap in a pixel.

```cshtml

@using Syncfusion.Blazor.HeatMap

<SfHeatMap DataSource="@HeatMapData" Width="750px" Height="350px">
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

![Changing Blazor Heatmap Chart Size in Pixel](images/dimension/blazor-heatmap-chart-size-in-pixel.png)

### In percentage

By setting the value in percentage, the heatmap gets its dimension with respect to its container. For example, when the height is ‘50%’, the heatmap is rendered to half of the container height.

```cshtml

@using Syncfusion.Blazor.HeatMap

<SfHeatMap DataSource="@HeatMapData" Width=75% Height=75%>
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

![Changing Blazor HeatMap Chart Size in Percentage](images/dimension/blazor-heatmap-chart-size-in-percentage.png)