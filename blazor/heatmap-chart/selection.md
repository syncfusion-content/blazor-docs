---
layout: post
title: Selection in Blazor HeatMap Chart Component | Syncfusion
description: Checkout and learn here all about Selection in Syncfusion Blazor HeatMap Chart component and much more.
platform: Blazor
control: HeatMap Chart
documentation: ug
---

# Selection in Blazor HeatMap Chart Component

In the [Blazor HeatMap Chart](https://www.syncfusion.com/blazor-components/blazor-heatmap-chart), the cell selection is used to select the single or multiple HeatMap cells at runtime and get the selected cell details using the `CellSelected`  event. You can enable this cell selection using the `AllowSelection` property.

To select multiple cells using different modes of interactions as shown in the below table.

|   Modes of Interactions |   Description                                                                                                      |
|------------------------ | -------------------------------------------------------------------------------------------------------------------|
|   Mouse                 |  To select multiple cells, click and drag the mouse across the specific cells.                                     |
|   Touch                 |  To select multiple cells, touch and drag the fingers across the specific cells.                                   |
|   Keyboard              |  To select multiple cells, holding the Ctrl (Control) key on your keyboard and click on any other specific cells.  |

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

The image below illustrates the process of selecting multiple cells in the HeatMap by clicking and dragging the mouse across the specific cells.

![Multiple Selection in Blazor HeatMap Chart](images/blazor-heatmap-chart-multiple-selection.gif)

## Enable single cell selection

In the HeatMap, the [EnableMultiSelect]() property is used to allow single cell selection. When you set the `EnableMultiSelect` property to **false**, only one cell is selected. By default, `EnableMultiSelect` property is set to **true**.

```cshtml

@using Syncfusion.Blazor.HeatMap

<SfHeatMap DataSource="@DataSource"AllowSelection="true" EnableMultiSelect="false">
    <HeatMapTitleSettings Text="Sales Revenue per Employee (in 1000 US$)"></HeatMapTitleSettings>
    <HeatMapXAxis Labels="@XLabels"></HeatMapXAxis>
    <HeatMapYAxis Labels="@YLabels"></HeatMapYAxis>
</SfHeatMap>

@code{
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

### ClearSelection Method

The `ClearSelection` method is used to clear the cell selection in the HeatMap.

```cshtml

@using Syncfusion.Blazor.HeatMap

<button @onclick="ClearSelection"> Clear Selection</button>


<SfHeatMap @ref="Heatmap" AllowSelection="true" DataSource="@dataSource">
    <HeatMapTitleSettings Text="Sales Revenue per Employee (in 1000 US$)">
    </HeatMapTitleSettings>
    <HeatMapXAxis Labels="@XAxisLabels"></HeatMapXAxis>
    <HeatMapYAxis Labels="@YAxisLabels"></HeatMapYAxis>
    <HeatMapCellSettings ShowLabel="true" TileType="CellType.Rect"></HeatMapCellSettings>
</SfHeatMap>

@code {
    SfHeatMap<int[,]> Heatmap;
   
    public int[,] dataSource = new int[,]
        {
            {73, 39, 26, 39, 94, 0},
            {93, 58, 53, 38, 26, 68},
            {99, 28, 22, 4, 66, 90},
            {14, 26, 97, 69, 69, 3},
            {7, 46, 47, 47, 88, 6},
            {41, 55, 73, 23, 3, 79}
        };
       
    string[] XAxisLabels = new string[] { "Nancy", "Andrew", "Janet", "Margaret", "Steven", "Michael" };
    string[] YAxisLabels = new string[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
    
    
    public void ClearSelection()
    {
        Heatmap.ClearSelection();
    }
}

```

![Clear cell selection method in Blazor HeatMap Chart](images/blazor-heatmap-chart-clear-selection-method.gif)