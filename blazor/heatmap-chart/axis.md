---
layout: post
title: Axis in Blazor HeatMap Chart Component | Syncfusion
description: Checkout and learn here all about Axis in Syncfusion Blazor HeatMap Chart component and much more details.
platform: Blazor
control: HeatMap Chart
documentation: ug
---

# Axis in Blazor HeatMap Chart Component

Heatmap consists of two axes namely, `X-axis` and `Y-axis` that displays the row headers and column headers to plot the data points respectively. You can customize both the axes by specifying the properties like type, format, and other customising options in the axis of the heatmap.

## Axis types

There are three different axis types available in the heatmap, which defines the data type of the axis labels. You can define the axis type by using the [ValueType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.HeatMap.HeatMapCommonAxis.html#Syncfusion_Blazor_HeatMap_HeatMapCommonAxis_ValueType) property in the heatmap.

Three different types of axis in the heatmap as follows.

* Category axis
* Numeric axis
* Date Time axis

### Category axis

Category axis type is used to represent the string values in axis labels. You can specify the [ValueType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.HeatMap.HeatMapCommonAxis.html#Syncfusion_Blazor_HeatMap_HeatMapCommonAxis_ValueType) property for the axis is **Category**.

```cshtml

@using Syncfusion.Blazor.HeatMap

<SfHeatMap DataSource="@HeatMapData">
    <HeatMapTitleSettings Text="Sales Revenue per Employee (in 1000 US$)">
    </HeatMapTitleSettings>
    <HeatMapXAxis Labels="@XAxisLabels" ValueType="Syncfusion.Blazor.HeatMap.ValueType.Category"></HeatMapXAxis>
    <HeatMapYAxis Labels="@YAxisLabels" ValueType="Syncfusion.Blazor.HeatMap.ValueType.Category"></HeatMapYAxis>
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

![Blazor HeatMap Chart with Axis](images/axis/blazor-heatmap-chart-axis.png)

### Numeric axis

Numeric axis type is used to represent the numeric values in the axis labels. You can specify the [ValueType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.HeatMap.HeatMapCommonAxis.html#Syncfusion_Blazor_HeatMap_HeatMapCommonAxis_ValueType) property for the axis is **Numeric**.

```cshtml

@using Syncfusion.Blazor.HeatMap

<SfHeatMap DataSource="@HeatMapData">
    <HeatMapTitleSettings Text="Sales Revenue per Employee (in 1000 US$)"></HeatMapTitleSettings>
    <HeatMapXAxis Labels="@XAxisLabels" ValueType="Syncfusion.Blazor.HeatMap.ValueType.Numeric"></HeatMapXAxis>
    <HeatMapYAxis Labels="@YAxisLabels" ValueType="Syncfusion.Blazor.HeatMap.ValueType.Numeric"></HeatMapYAxis>
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

![Blazor HeatMap Chart with Numeric Axis](images/axis/blazor-heatmap-chart-numeric-axis.png)

### Date-time axis

Date-time axis type is used to represent the date-time values in the axis labels with a specific format. In date-time axis, you can define the start and end date/time using the [Minimum](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.HeatMap.HeatMapCommonAxis.html#Syncfusion_Blazor_HeatMap_HeatMapCommonAxis_Minimum) and [Maximum](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.HeatMap.HeatMapCommonAxis.html#Syncfusion_Blazor_HeatMap_HeatMapCommonAxis_Maximum) properties. You can specify the [ValueType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.HeatMap.HeatMapCommonAxis.html#Syncfusion_Blazor_HeatMap_HeatMapCommonAxis_ValueType) property for the axis is **DateTime**.

```cshtml

@using Syncfusion.Blazor.HeatMap

<SfHeatMap DataSource="@HeatMapData">
    <HeatMapTitleSettings Text="Sales Revenue per Employee (in 1000 US$)">
    </HeatMapTitleSettings>
    <HeatMapXAxis Labels="@XAxisLabels" ValueType="Syncfusion.Blazor.HeatMap.ValueType.Category"></HeatMapXAxis>
    <HeatMapYAxis Labels="@YAxisLabels" ValueType="Syncfusion.Blazor.HeatMap.ValueType.DateTime" Minimum="@Minimum" Maximum="@Maximum" IntervalType="IntervalType.Months"></HeatMapYAxis>
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
    public object Minimum = new DateTime(2007, 2, 1);
    public object Maximum = new DateTime(2007, 7, 1);
    string[] XAxisLabels = new string[] {"Nancy", "Andrew", "Janet", "Margaret", "Steven", "Michael" };
    string[] YAxisLabels = new string[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
    public object HeatMapData { get; set; }
    protected override void OnInitialized()
    {
        HeatMapData = GetDefaultData();
    }
}

```

![Blazor HeatMap Chart with DateTime Axis](images/axis/blazor-heatmap-chart-datetime-axis.png)

## Axis customization

### Inversed axis

Heatmap supports inversing the axis origin for both axes, where the axis labels are placed in an inversed manner. You can enable axis inversing by enabling the [IsInversed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.HeatMap.HeatMapCommonAxis.html#Syncfusion_Blazor_HeatMap_HeatMapCommonAxis_IsInversed) property.

```cshtml

@using Syncfusion.Blazor.HeatMap

<SfHeatMap DataSource="@HeatMapData">
    <HeatMapTitleSettings Text="Sales Revenue per Employee (in 1000 US$)">
    </HeatMapTitleSettings>
    <HeatMapXAxis Labels="@XAxisLabels" ValueType="Syncfusion.Blazor.HeatMap.ValueType.Category" IsInversed="true"></HeatMapXAxis>
    <HeatMapYAxis Labels="@YAxisLabels" ValueType="Syncfusion.Blazor.HeatMap.ValueType.DateTime" Minimum="@Minimum" Maximum="@Maximum" IntervalType="IntervalType.Months"></HeatMapYAxis>
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
    public object Minimum = new DateTime(2007, 2, 1);
    public object Maximum = new DateTime(2007, 7, 1);
    string[] XAxisLabels = new string[] {"Nancy", "Andrew", "Janet", "Margaret", "Steven", "Michael" };
    string[] YAxisLabels = new string[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
    public object HeatMapData { get; set; }
    protected override void OnInitialized()
    {
        HeatMapData = GetDefaultData();
    }
}

```

![Blazor HeatMap Chart with Inversed Axis](images/axis/blazor-heatmap-chart-inversed-axis.png)

### Opposed axis

In heatmap, you can place the axis label in an opposite position of its default axis label position by using the [OpposedPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.HeatMap.HeatMapCommonAxis.html#Syncfusion_Blazor_HeatMap_HeatMapCommonAxis_OpposedPosition) property.

```cshtml

@using Syncfusion.Blazor.HeatMap

<SfHeatMap DataSource="@HeatMapData">
    <HeatMapTitleSettings Text="Sales Revenue per Employee (in 1000 US$)">
    </HeatMapTitleSettings>
    <HeatMapXAxis Labels="@XAxisLabels" ValueType="Syncfusion.Blazor.HeatMap.ValueType.Category" OpposedPosition="true"></HeatMapXAxis>
    <HeatMapYAxis Labels="@YAxisLabels" ValueType="Syncfusion.Blazor.HeatMap.ValueType.DateTime" Minimum="@Minimum" Maximum="@Maximum" IntervalType="IntervalType.Months"></HeatMapYAxis>
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
    public object Minimum = new DateTime(2007, 2, 1);
    public object Maximum = new DateTime(2007, 7, 1);
    string[] XAxisLabels = new string[] {"Nancy", "Andrew", "Janet", "Margaret", "Steven", "Michael" };
    string[] YAxisLabels = new string[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
    public object HeatMapData { get; set; }
    protected override void OnInitialized()
    {
        HeatMapData = GetDefaultData();
    }
}

```

![Blazor HeatMap Chart with Opposed Axis](images/axis/blazor-heatmap-chart-opposed-axis.png)

## Axis label customization

### Label formatting

Heatmap supports formatting the axis labels by using the [LabelFormat](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.HeatMap.HeatMapCommonAxis.html#Syncfusion_Blazor_HeatMap_HeatMapCommonAxis_LabelFormat) property. Using this property, you can customize the axis label by global string format (‘P’, ‘C’, etc) or customized format like ‘{value}°C’.

```cshtml

@using Syncfusion.Blazor.HeatMap

<SfHeatMap DataSource="@HeatMapData">
    <HeatMapTitleSettings Text="Sales Revenue per Employee (in 1000 US$)">
    </HeatMapTitleSettings>
    <HeatMapXAxis Labels="@XAxisLabels" ValueType="Syncfusion.Blazor.HeatMap.ValueType.Category"></HeatMapXAxis>
    <HeatMapYAxis Labels="@YAxisLabels" ValueType="Syncfusion.Blazor.HeatMap.ValueType.Numeric"  LabelFormat="${value}"></HeatMapYAxis>
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
    public object Minimum = new DateTime(2007, 2, 1);
    public object Maximum = new DateTime(2007, 7, 1);
    string[] XAxisLabels = new string[] {"Nancy", "Andrew", "Janet", "Margaret", "Steven", "Michael" };
    string[] YAxisLabels = new string[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
    public object HeatMapData { get; set; }
    protected override void OnInitialized()
    {
        HeatMapData = GetDefaultData();
    }
}

```

![Formatting Axis Label in Blazor HeatMap Chart](images/axis/blazor-heatmap-chart-label-format.png)

## Axis intervals

In heatmap, you can define an interval between the axis labels using the [Interval](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.HeatMap.HeatMapCommonAxis.html#Syncfusion_Blazor_HeatMap_HeatMapCommonAxis_Interval) property. In date-time axis, you can change the interval mode by using the [IntervalType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.HeatMap.HeatMapCommonAxis.html#Syncfusion_Blazor_HeatMap_HeatMapCommonAxis_IntervalType) property. The date-time axis supports the following interval types.

* Years
* Months
* Days
* Hours
* Minutes

```cshtml

@using Syncfusion.Blazor.HeatMap

<SfHeatMap DataSource="@HeatMapData">
    <HeatMapTitleSettings Text="Sales Revenue per Employee (in 1000 US$)">
    </HeatMapTitleSettings>
    <HeatMapXAxis Labels="@XAxisLabels" ValueType="Syncfusion.Blazor.HeatMap.ValueType.Category"></HeatMapXAxis>
    <HeatMapYAxis Labels="@YAxisLabels" ValueType="Syncfusion.Blazor.HeatMap.ValueType.DateTime" Minimum="@Minimum" Interval=2 Maximum="@Maximum" IntervalType="IntervalType.Months"></HeatMapYAxis>
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
    public object Minimum = new DateTime(2007, 2, 1);
    public object Maximum = new DateTime(2007, 7, 1);
    string[] XAxisLabels = new string[] { "Nancy", "Andrew", "Janet", "Margaret", "Steven", "Michael" };
    string[] YAxisLabels = new string[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
    public object HeatMapData { get; set; }
    protected override void OnInitialized()
    {
        HeatMapData = GetDefaultData();
    }
}

```

![Blazor HeatMap Chart with Axis Intervals](images/axis/blazor-heatmap-chart-axis-interval.png)

## Axis label increment

Axis label increment in the heatmap is used to display the axis labels with regular interval values in numeric and date-time axes. The labels will be displayed with gaps on the axis, when you set the interval. However, you need to limit the gaps on the axis, use the `Increment` property. The [Increment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.HeatMap.HeatMapCommonAxis.html#Syncfusion_Blazor_HeatMap_HeatMapCommonAxis_Increment) property can be used to set the increment value for the axis in order to display the axis labels without gaps and the default value of this property is **1**.

```cshtml

@using Syncfusion.Blazor.HeatMap

<SfHeatMap DataSource="@HeatMapData">
    <HeatMapTitleSettings Text="Sales Revenue per Employee (in 1000 US$)">
    </HeatMapTitleSettings>
    <HeatMapXAxis Labels="@XAxisLabels" ValueType="Syncfusion.Blazor.HeatMap.ValueType.Numeric" Increment=2></HeatMapXAxis>
    <HeatMapYAxis Labels="@YAxisLabels" ValueType="Syncfusion.Blazor.HeatMap.ValueType.Numeric" Increment=3></HeatMapYAxis>
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
    string[] XAxisLabels = new string[] { "Nancy", "Andrew", "Janet", "Margaret", "Steven", "Michael" };
    string[] YAxisLabels = new string[] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
    public object HeatMapData { get; set; }
    protected override void OnInitialized()
    {
        HeatMapData = GetDefaultData();
    }
}

```

![Incrementing Axis Label in Blazor HeatMap Chart](images/axis/blazor-heatmap-chart-increment-axis-label.png)

### Limiting labels in date-time axis

You can display the axis labels at specific time intervals along with the date-time axis using the [ShowLabelOn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.HeatMap.HeatMapCommonAxis.html#Syncfusion_Blazor_HeatMap_HeatMapCommonAxis_ShowLabelOn) property. This property supports the following types:

* None: Displays the axis labels based on the [`IntervalType`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.HeatMap.HeatMapCommonAxis.html#Syncfusion_Blazor_HeatMap_HeatMapCommonAxis_IntervalType) and `Interval` property of the axis. This type is default value of the `ShowLabelOn` property.
* Years: Displays the axis labels on every year between given date-time range.
* Months: Displays the axis labels on every month between given date-time range.
* Days: Displays the axis labels on every day between given date-time range.
* Hours: Displays the axis labels on every hours between given date-time range.

```cshtml

@using Syncfusion.Blazor.HeatMap

<SfHeatMap DataSource="@HeatMapData" Height="280px">
    <HeatMapTitleSettings Text="Annual Summary of User Activities in GitLab">
        <HeatMapTitleTextStyle Size="15px" FontWeight="500" FontStyle="Normal" FontFamily="Segoe UI"></HeatMapTitleTextStyle>
    </HeatMapTitleSettings>
    <HeatMapXAxis ValueType="Syncfusion.Blazor.HeatMap.ValueType.DateTime" OpposedPosition="true" Minimum="@Minimum" Maximum="@Maximum" IntervalType="IntervalType.Days" LabelFormat="MMM" Increment="7" ShowLabelOn="LabelType.Months">
    </HeatMapXAxis>
    <HeatMapYAxis Labels="@YAxisLabels" IsInversed="true"></HeatMapYAxis>
    <HeatMapPaletteSettings Type="PaletteType.Gradient">
        <HeatMapPalettes>
            <HeatMapPalette Value="0" Color="rgb(238,238,238)" Label="no contributions"></HeatMapPalette>
            <HeatMapPalette Value="1" Color="rgb(172, 213, 242)" Label="1-15 contributions"></HeatMapPalette>
            <HeatMapPalette Value="16" Color="rgb(127, 168, 201)" Label="16-31 contributions"></HeatMapPalette>
            <HeatMapPalette Value="32" Color="rgb(82, 123, 160)" Label="31-49 contributions"></HeatMapPalette>
            <HeatMapPalette Value="50" Color="rgb(37, 78, 119)" Label="50+ contributions"></HeatMapPalette>
        </HeatMapPalettes>
    </HeatMapPaletteSettings>
    <HeatMapLegendSettings Position="LegendPosition.Bottom" Width="20%" Alignment="Alignment.Near" ShowLabel="true" LabelDisplayType="LabelDisplayType.None" EnableSmartLegend="true"></HeatMapLegendSettings>
</SfHeatMap>

@code{
    int?[,] GetDefaultData()
    {
        int?[,]dataSource = new int?[,]
        {

            {null, null, null, null, 16, 48, 0 },
            {0, 15, 0, 24, 0, 39, 0 },
            {0, 18, 37, 0, 0, 50, 0 },
            {0, 10, 0, 0, 44, 5, 0 },
            {0, 36, 0, 45, 20, 18, 0 },
            {0, 28, 1, 42, 0, 10, 0 },
            {0, 16, 32, 0, 1, 25, 0},
            {0, 31, 2, 9, 24, 0, 0 },
            {0, 8, 47, 0, 0, 35, 0 },
            {0, 31, 0, 0, 0, 40, 0},
            {0, 8, 0, 27, 0, 35, 0},
            {0, 12, 9, 45, 0, 8, 0},
            {0, 0, 13, 0, 22, 10, 0},
            {0, 16, 32, 0, 1, 25, 0},
            {0, 31, 2, 9, 24, 0, 0},
            {0, 8, 47, 27, 0, 35, 0},
            {0, 28, 14, 10, 0, 0, 0},
            {0, 36, 0, 45, 20, 18, 0},
            { 0, 28, 1, 42, 0, 10, 0},
            {0, 31, 0, 24, 0, 40, 0},
            { 0, 8, 47, 27, 0, 35, 0},
            { 0, 36, 0, 45, 20, 18, 0},
            {0, 28, 1, 42, 0, 10, 0},
            { 0, 31, 0, 24, 0, 40, 0},
            { 0, 16, 32, 0, 1, 25, 0},
            {0, 31, 2, 9, 24, 0, 0},
            { 0, 8, 47, 27, 0, 35, 0},
            {0, 10, 0, 36, 23, 19, 0},
            { 0, 18, 37, 23, 0, 50, 0},
            {0, 28, 14, 10, 0, 0, 0},
            { 0, 18, 37, 23, 0, 50, 0},
            {0, 18, 37, 23, 0, 50, 0},
            { 0, 28, 14, 10, 0, 0, 0},
            {0, 31, 2, 9, 24, 0, 0},
            { 0, 8, 47, 27, 0, 35, 0},
            {0, 10, 2, 0, 44, 5, 0},
            { 0, 36, 0, 45, 20, 18, 0},
            { 0, 28, 1, 42, 0, 10, 0},
            { 0, 31, 0, 24, 0, 40, 1},
            { 0, 16, 32, 0, 1, 25, 0},
            { 0, 31, 2, 9, 24, 0, 0},
            { 0, 8, 47, 27, 0, 35, 0},
            { 0, 10, 2, 0, 44, 5, 0},
            { 0, 12, 9, 45, 0, 8, 0},
            {0, 0, 13, 35, 22, 10, 0},
            { 0, 28, 14, 10, 0, 0, 0},
            {0, 36, 0, 45, 20, 18, 2},
            { 0, 28, 1, 42, 0, 10, 0},
            {0, 31, 0, 24, 0, 40, 1},
            { 0, 8, 47, 27, 0, 35, 0},
            { 0, 10, 2, 0, 44, 5, 0},
            { 0, 31, 2, 9, 24, 0, 1},
            { 0, 8, 47, 27, 0, 35, 40},
            {0, 10, 2, 0, 44, 5, null}
        };
        return dataSource;
    }
    string[] YAxisLabels = new string[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
    object Minimum = new DateTime(2017, 6, 23);
    object Maximum = new DateTime(2018, 6, 30);
    public object HeatMapData { get; set; }
    protected override void OnInitialized()
    {
        HeatMapData = GetDefaultData();
    }
}

```
