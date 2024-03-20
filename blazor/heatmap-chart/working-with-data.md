---
layout: post
title: Working with data in Blazor HeatMap Chart Component | Syncfusion
description: Checkout and learn here all about Working with data in Syncfusion Blazor HeatMap Chart component and more.
platform: Blazor
control: HeatMap Chart
documentation: ug
---

# Working with data in Blazor HeatMap Chart Component

This section shows how to bind data to the HeatMap component using the video below.

{% youtube
"youtube:https://www.youtube.com/watch?v=u27NqwNs8sw&t=78s"%}

Heat map visualizes the JSON data and two-dimensional array data. Using the data adaptor support, data can be bound to the heat map.

## Data adaptor

Heat map supports the following types of data binding with the adaptor support.

* Array - Table Binding

### Array - Table binding

This data type is a collection of one dimensional array objects, at which each inner array contains data points for an X-axis data label. This is the default data binding type for heat map. You can also directly bind the array object to the `DataSource` property.

```cshtml

@using Syncfusion.Blazor.HeatMap

<SfHeatMap DataSource="@HeatMapData">
    <HeatMapTitleSettings Text="GDP Growth Rate for Major Economies (in Percentage)">
    </HeatMapTitleSettings>
    <HeatMapXAxis Labels="@XAxisLabels"></HeatMapXAxis>
    <HeatMapYAxis Labels="@YAxisLabels"></HeatMapYAxis>
    <HeatMapPaletteSettings Type="PaletteType.Gradient">
        <HeatMapPalettes>
            <HeatMapPalette Color="#F0D6AD" Value=-1></HeatMapPalette>
            <HeatMapPalette Color="#9da49a" Value=0></HeatMapPalette>
            <HeatMapPalette Color="#d7c7a7" Value=3.5></HeatMapPalette>
            <HeatMapPalette Color="#6e888f" Value=6.0></HeatMapPalette>
            <HeatMapPalette Color="#466f86" Value=7.5></HeatMapPalette>
            <HeatMapPalette Color="#19547B" Value=10></HeatMapPalette>
        </HeatMapPalettes>
    </HeatMapPaletteSettings>
</SfHeatMap>

@code{
    double[,] GetDefaultData()
    {
        double[,] dataSource = new double[6, 10]
            {
                {9.5, 2.2, 4.2, 8.2, -0.5, 3.2, 5.4, 7.4, 6.2, 1.4 },
                {4.3, 8.9, 10.8, 6.5, 5.1, 6.2, 7.6, 7.5, 6.1, 7.6},
                {3.9, 2.7, 2.5, 3.7, 2.6, 5.1, 5.8, 2.9, 4.5, 5.1},
                {2.4, -3.7, 4.1, 6.0, 5.0, 2.4, 3.3, 4.6, 4.3, 2.7},
                {2.0, 7.0, -4.1, 8.9, 2.7, 5.9, 5.6, 1.9, -1.7, 2.9},
                {5.4, 1.1, 6.9, 4.5, 2.9, 3.4, 1.5, -2.8, -4.6, 1.2}
            };
            return dataSource;
    }
    string[] XAxisLabels = new string[] { "China", "India", "Australia", "Mexico", "Canada", "Brazil" };
    string[] YAxisLabels = new string[] { "2008", "2009", "2010", "2011", "2012", "2013", "2014", "2015", "2016", "2017" };
    public object HeatMapData { get; set; }
    protected override void OnInitialized()
    {
        HeatMapData = GetDefaultData();
    }
}

```

![Data Binding in Blazor HeatMap Chart](images/data/blazor-heatmap-chart-data-binding.png)

## Empty points

The data points that use the `null` or `""` or `undefined` as value are considered as empty points. Empty data points are ignored and not displayed in the heat map, and these points are rendered with default palette. You can customize the empty data point color value using the `EmptyPointColor` property.

```cshtml

@using Syncfusion.Blazor.HeatMap

<SfHeatMap DataSource="@HeatMapData">
    <HeatMapTitleSettings Text="Sales Revenue per Employee (in 1000 US$)">
    </HeatMapTitleSettings>
    <HeatMapXAxis Labels="@XAxisLabels"></HeatMapXAxis>
    <HeatMapYAxis Labels="@YAxisLabels"></HeatMapYAxis>
</SfHeatMap>

@code{
        int?[,] GetDefaultData()
        {
            int?[,] dataSource = new int?[6, 12]
            {
                {8, 5, 2, 6, 8, 2, 9, 3, 7, 8, 7, 6},
                {5, null, 4, 9, 10, null, 11, 7, 3, 7, 8, null},
                {8, 7, 2, null, 5, 3, null, 2, 1, 8, null, 4},
                {10, 2, null, 4, 5, null, 1, 10, 5, 2, 1, null},
                {1, 2, 9, 4, null, 5, 1, null, 12, 1, null, 4},
                {4, null, 3, 5, 2, null, null, null, 5, null, 1, 3},
            };
            return dataSource;
        }
    string[] XAxisLabels = new string[] {"Nancy", "Andrew", "Janet", "Margaret", "Steven", "Michael", "Robert","Laura", "Anne", "Paul", "Karin", "Mario" };
    string[] YAxisLabels = new string[] { "2008", "2009", "2010", "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018", "2019" };
    public object HeatMapData { get; set; }
    protected override void OnInitialized()
    {
        HeatMapData = GetDefaultData();
    }
}


```

![Blazor HeatMap Chart with Empty Points](images/data/blazor-heatmap-chart-empty-points.png)