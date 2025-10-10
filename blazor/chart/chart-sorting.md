---
layout: post
title: Sorting in Blazor Charts Component | Syncfusion
description: Check out and learn how to configure and utilize sorting functionality in Syncfusion Blazor Charts component.
platform: Blazor
control: Chart
documentation: ug
---

# Sorting in Blazor Chart Component

Sorting in Blazor Charts allows data to be displayed in ascending or descending order for clearer analysis and comparison.

To sort chart data by y-axis value, set **Y** to the [PropertyName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSorting.html#Syncfusion_Blazor_Charts_ChartSorting_PropertyName) property.

```cshtml

@using Syncfusion.Blazor.Charts
@using Syncfusion.Blazor.Data

<SfChart Title="Sales History of Product X">
    <ChartSorting PropertyName="Y" Direction="ListSortDirection.Ascending"></ChartSorting>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="YValue" Type="ChartSeriesType.Column"></ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double YValue { get; set; }
        public double Profit { get; set; }
    }

    public List<ChartData> SalesReports = new List<ChartData>
    {
        new ChartData { X = "USA", YValue = 46, Profit = 25},
        new ChartData { X = "GBR", YValue = 30, Profit = 30},
        new ChartData { X = "CHN", YValue = 25, Profit = 20},
        new ChartData { X = "UK", YValue = 40, Profit = 15},
        new ChartData { X = "AUS", YValue = 28, Profit = 10},
        new ChartData { X = "IND", YValue = 35, Profit = 20},
        new ChartData { X = "DEN", YValue = 30, Profit = 10},
        new ChartData { X = "MEX", YValue = 20, Profit = 5}
    };
}

```

![Blazor Chart - Sorting by y-axis](images/sorting/sorting-yaxis-ascending.png)

## Sorting order

The default sorting order is **Ascending**. Change the order to descending by setting the [Direction](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSorting.html#Syncfusion_Blazor_Charts_ChartSorting_Direction) property to **Descending** in [ChartSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSorting.html).

```cshtml

@using Syncfusion.Blazor.Charts
@using Syncfusion.Blazor.Data

<SfChart Title="Sales History of Product X">
    <ChartSorting PropertyName="X" Direction="ListSortDirection.Descending"></ChartSorting>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="YValue" Type="ChartSeriesType.Column"></ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double YValue { get; set; }
        public double Profit { get; set; }
    }

    public List<ChartData> SalesReports = new List<ChartData>
    {
        new ChartData { X = "USA", YValue = 46, Profit = 25},
        new ChartData { X = "GBR", YValue = 30, Profit = 30},
        new ChartData { X = "CHN", YValue = 25, Profit = 20},
        new ChartData { X = "UK", YValue = 40, Profit = 15},
        new ChartData { X = "AUS", YValue = 28, Profit = 10},
        new ChartData { X = "IND", YValue = 35, Profit = 20},
        new ChartData { X = "DEN", YValue = 30, Profit = 10},
        new ChartData { X = "MEX", YValue = 20, Profit = 5}
    };
}

```

![Blazor Chart - Sort descending by y-axis](images/sorting/sorting-yaxis-descending.png)

## Sorting by custom value

Sort data by any field in the data source by specifying the field name in the [PropertyName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSorting.html#Syncfusion_Blazor_Charts_ChartSorting_PropertyName) property of [ChartSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSorting.html).

```cshtml

@using Syncfusion.Blazor.Charts
@using Syncfusion.Blazor.Data

<SfChart Title="Sales History of Product X">
    <ChartSorting PropertyName="Profit" Direction="ListSortDirection.Ascending"></ChartSorting>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="YValue" Type="ChartSeriesType.Column"></ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double YValue { get; set; }
        public double Profit { get; set; }
    }

    public List<ChartData> SalesReports = new List<ChartData>
    {
        new ChartData { X= "USA", YValue= 46, Profit = 25},
        new ChartData { X= "GBR", YValue= 30, Profit = 30},
        new ChartData { X= "CHN", YValue= 25, Profit = 20},
        new ChartData { X= "UK", YValue= 40, Profit = 15},
        new ChartData { X= "AUS", YValue= 28, Profit = 10},
        new ChartData { X= "IND", YValue= 35, Profit = 20},
        new ChartData { X= "DEN", YValue= 30, Profit = 10},
        new ChartData { X= "MEX", YValue= 20, Profit = 5},
    };
}

```

![Blazor Chart - Sorting by custom value](images/sorting/custom-sorting.png)

## See also

* [Data label](./data-labels)
* [Legend](./legend)
* [Marker](./data-markers)
