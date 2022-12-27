---
layout: post
title: Axis in Blazor HeatMap Chart Component | Syncfusion
description: Checkout and learn here all about Axis in Syncfusion Blazor HeatMap Chart component and much more details.
platform: Blazor
control: HeatMap Chart
documentation: ug
---

# Axis in Blazor HeatMap Chart Component

Heatmap consists of two axes namely, `X-axis` and `Y-axis` that displays the row headers and column headers to plot the data points respectively. You can define the type, format, and other customizing options for both axes in the heatmap.

## Types

There are three different axis types available in the heatmap, which defines the data type of the axis labels. You can define the axis type by using the [ValueType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.HeatMap.HeatMapCommonAxis.html#Syncfusion_Blazor_HeatMap_HeatMapCommonAxis_ValueType) property in the heatmap.

### Category axis

Category axis type is used to represent the string values in axis labels.

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

Numeric axis type is used to represent the numeric values in axis labels.

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

Date-time axis type is used to represent the date-time values in axis labels with a specific format. In date-time axis, you can define the start and end date/time using the [Minimum](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.HeatMap.HeatMapCommonAxis.html#Syncfusion_Blazor_HeatMap_HeatMapCommonAxis_Minimum) and [Maximum](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.HeatMap.HeatMapCommonAxis.html#Syncfusion_Blazor_HeatMap_HeatMapCommonAxis_Maximum) properties.

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

## Inversed axis

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

## Opposed axis

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

## Label formatting

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

Axis label increment in the heatmap is used to display the axis labels with regular interval values in numeric and date-time axes. The labels will be displayed with tick gaps when you set the label interval. But, to achieve the same behavior without tick gaps, use the label increment. You can set the axis label increment using the [Increment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.HeatMap.HeatMapCommonAxis.html#Syncfusion_Blazor_HeatMap_HeatMapCommonAxis_Increment) property and the default value of this property is **1**.

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