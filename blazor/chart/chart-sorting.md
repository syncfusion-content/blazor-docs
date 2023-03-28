---
layout: post
title: Sorting in Blazor Chart Component | Syncfusion
description: Checkout and learn here all about Sorting functionality in Syncfusion Blazor Charts component and more.
platform: Blazor
control: Chart
documentation: ug
---

# Sorting in Blazor Chart Component

Sorting enables you to sort data in the **Ascending** or **Descending** order. To sort the chart based on the Y-axis value, set 'Y' to the [PropertyName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSorting.html#Syncfusion_Blazor_Charts_ChartSorting_PropertyName) property.

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

@code{
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

![Sorting by Y axis](images/sorting/sorting-yaxis-ascending.png)

## Sort Order

By default, the sorting order will be Ascending -> Descending. The sort direction can be changed from Descending to Ascending by setting the [Direction](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSorting.html#Syncfusion_Blazor_Charts_ChartSorting_Direction) property as ‘Descending’ in the [ChartSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSorting.html).

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

@code{
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

![Sort by Descending order based on Y axis](images/sorting/sorting-yaxis-descending.png)


## Sorting By Custom Value

Data can also be sorted based on any field in the data source by passing the field name to the [PropertyName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSorting.html#Syncfusion_Blazor_Charts_ChartSorting_PropertyName) property in the [ChartSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSorting.html).

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

@code{
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

![Sorting by Custom Value](images/sorting/custom-sorting-categoryAxis.png)

## See Also

* [Data label](./data-labels)
* [Legend](./legend)
* [Marker](./data-markers)
