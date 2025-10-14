---
layout: post
title: Selection in Blazor HeatMap Chart Component | Syncfusion
description: Check out and learn how to use and customize cell selection in Syncfusion Blazor HeatMap Chart component.
platform: Blazor
control: HeatMap Chart
documentation: ug
---

# Selection in Blazor HeatMap Chart Component

In the [Blazor HeatMap Chart](https://www.syncfusion.com/blazor-components/blazor-heatmap-chart), cell selection allows users to select single or multiple cells at runtime and retrieve selected cell details using the [CellSelected](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.HeatMap.HeatMapEvents.html#Syncfusion_Blazor_HeatMap_HeatMapEvents_CellSelected) event. Enable cell selection with the [AllowSelection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.HeatMap.SfHeatMap-1.html#Syncfusion_Blazor_HeatMap_SfHeatMap_1_AllowSelection) property.

Cells can be selected using the following interactions:

| Modes of Interaction | Description |
|---------------------|-------------|
| Mouse | Select cells by clicking or dragging over them. |
| Touch | Select cells by tapping or dragging over them. |
| Keyboard | Use the **Ctrl** key to enable multiple cell selection with mouse or touch. The **Ctrl** key works only if `EnableMultiSelect` is set to **true**. |

```cshtml

@using Syncfusion.Blazor.HeatMap

<SfHeatMap AllowSelection="true" DataSource="@HeatMapData">
    <HeatMapTitleSettings Text="Sales Revenue per Employee (in 1000 US$)">
    </HeatMapTitleSettings>
    <HeatMapXAxis Labels="@XAxisLabels"></HeatMapXAxis>
    <HeatMapYAxis Labels="@YAxisLabels"></HeatMapYAxis>
    <HeatMapCellSettings ShowLabel="true" TileType="CellType.Rect"></HeatMapCellSettings>
</SfHeatMap>

@code {
    public object HeatMapData { get; set; }

    public string[] XAxisLabels = new string[] {"Nancy", "Andrew", "Janet", "Margaret", "Steven", "Michael" };
    public string[] YAxisLabels = new string[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

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

    protected override void OnInitialized()
    {
        HeatMapData = GetDefaultData();
    }
}

```

![Selection in Blazor HeatMap Chart](images/blazor-heatmap-chart-selection.png)

The following illustration shows how to select multiple cells by clicking and dragging the mouse across the cells.

![Multiple selection in Blazor HeatMap Chart](images/blazor-heatmap-chart-multiple-selection.gif)

## Enable single cell selection

Use the [EnableMultiSelect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.HeatMap.SfHeatMap-1.html#Syncfusion_Blazor_HeatMap_SfHeatMap_1_EnableMultiSelect) property to enable single cell selection. When set to **false**, only one cell can be selected at a time. By default, `EnableMultiSelect` is **true**.

```cshtml

@using Syncfusion.Blazor.HeatMap

<SfHeatMap DataSource="@DataSource"AllowSelection="true" EnableMultiSelect="false">
    <HeatMapTitleSettings Text="Sales Revenue per Employee (in 1000 US$)"></HeatMapTitleSettings>
    <HeatMapXAxis Labels="@XLabels"></HeatMapXAxis>
    <HeatMapYAxis Labels="@YLabels"></HeatMapYAxis>
</SfHeatMap>

@code {
    public int YIndex = 0;

    public string[] XLabels = new string[] { "Nancy", "Andrew", "Janet", "Margaret", "Steven", "Michael", "Robert", "Laura", "Anne", "Paul", "Karin", "Mario" };
    public string[] YLabels = new string[] { "Mon", "Tues", "Wed", "Thurs", "Fri", "Sat" };

    public double[,] DataSource = new double[,]
    {
        { 73, 39, 26, 39, 94, 0 },
        { 93, 58, 53, 38, 26, 68 },
        { 99, 28, 22, 4, 66, 90 },
        { 14, 26, 97, 69, 69, 3 },
        { 7, 46, 47, 47, 88, 6 },
        { 41, 55, 73, 23, 3, 79 },
        { 56, 69, 21, 86, 3, 33 },
        { 45, 7, 53, 81, 95, 79 },
        { 60, 77, 74, 68, 88, 51 },
        { 25, 25, 10, 12, 78, 14 },
        { 25, 56, 55, 58, 12, 82 },
        {74, 33, 88, 23, 86, 59 }
    };
}

```
![Single cell selection in Blazor HeatMap Chart](images/blazor-heatmap-chart-single-cell-selection.gif)

### Clearing cell selection

Use the [ClearSelectionAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.HeatMap.SfHeatMap-1.html#Syncfusion_Blazor_HeatMap_SfHeatMap_1_ClearSelectionAsync) method to clear all selected cells.

```cshtml

@using Syncfusion.Blazor.HeatMap

<SfHeatMap @ref="Heatmap" AllowSelection="true" DataSource="@dataSource">
    <HeatMapTitleSettings Text="Sales Revenue per Employee (in 1000 US$)">
    </HeatMapTitleSettings>
    <HeatMapXAxis Labels="@XAxisLabels"></HeatMapXAxis>
    <HeatMapYAxis Labels="@YAxisLabels"></HeatMapYAxis>
    <HeatMapCellSettings ShowLabel="true" TileType="CellType.Rect"></HeatMapCellSettings>
</SfHeatMap>

<button @onclick="ClearSelection">Clear Selection</button>

@code {
    public SfHeatMap<int[,]> Heatmap;
     
    public string[] XAxisLabels = new string[] { "Nancy", "Andrew", "Janet", "Margaret", "Steven", "Michael" };
    public string[] YAxisLabels = new string[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

    public int[,] dataSource = new int[,]
    {
        {73, 39, 26, 39, 94, 0},
        {93, 58, 53, 38, 26, 68},
        {99, 28, 22, 4, 66, 90},
        {14, 26, 97, 69, 69, 3},
        {7, 46, 47, 47, 88, 6},
        {41, 55, 73, 23, 3, 79}
    };

    public async Task ClearSelection()
    {
        Heatmap.ClearSelectionAsync();
    }
}

```

![Clearing cell selection in Blazor HeatMap Chart](images/blazor-heatmap-chart-clear-selection-method.gif)
