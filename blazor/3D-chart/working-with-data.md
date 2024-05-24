---
layout: post
title: Working with Data in Blazor 3D Chart Component | Syncfusion
description: Checkout and learn here all about working with data in Syncfusion Blazor 3D Chart component, it's elements and more.
platform: Blazor
control: 3D Chart
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# Working with Data in Blazor 3D Chart Component

The 3D Chart uses [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html), which supports both RESTful JSON data services binding and IEnumerable binding. The [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) value can be set using either [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) property values or a list of business objects.

It supports the following data binding methods:
* List binding
* Remote data

## List binding

An IEnumerable object can be assigned to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) property. The list data source can alternatively be given as an instance of [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) or by using [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) or as a component of the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) or by using [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html). The data fields should now be mapped to the [XName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_XName) and [YName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_YName) properties.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D Title="Inflation - Consumer Price" Width="60%">
    <Chart3DPrimaryXAxis LabelFormat="yyyy" ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime">
    </Chart3DPrimaryXAxis>
	<Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@ConsumerReports" XName="XValue" YName="YValue" Type="Chart3DSeriesType.Column">
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

@code{
    public class Chart3DData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<Chart3DData> ConsumerReports = new List<Chart3DData>
    {
		new Chart3DData { XValue = new DateTime(2005, 01, 01), YValue = 21 },
		new Chart3DData { XValue = new DateTime(2006, 01, 01), YValue = 24 },
		new Chart3DData { XValue = new DateTime(2007, 01, 01), YValue = 36 },
		new Chart3DData { XValue = new DateTime(2008, 01, 01), YValue = 38 },
		new Chart3DData { XValue = new DateTime(2009, 01, 01), YValue = 54 },
		new Chart3DData { XValue = new DateTime(2010, 01, 01), YValue = 57 },
		new Chart3DData { XValue = new DateTime(2011, 01, 01), YValue = 70 },
	};
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BjBKCrrVgRsckQvf?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Colum 3D Chart with Data Binding](images/working-data/blazor-chart-data-binding.png)

N> By default, [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) uses **BlazorAdaptor** for list data-binding.

### ExpandoObject binding

Blazor 3D Chart is a generic component which is strongly bound to a model type. There are cases when the model type is unknown during compile time. In such circumstances data can be bound to the chart as a list of **ExpandoObjects**. The **ExpandoObject** can be bound to 3D Chart by assigning to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) property.

```cshtml
@using Syncfusion.Blazor.Chart3D
@using System.Dynamic

<SfChart3D>
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@MedalDetails" XName="X" YName="Y" Type="Chart3DSeriesType.Column">
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

@code{
    private List<string> countries = new List<string> { "South Korea", "India", "Germany", "Italy", "Russia" };
    private Random randomNum = new Random();
    public List<ExpandoObject> MedalDetails { get; set; } = new List<ExpandoObject>();
    protected override void OnInitialized()
    {
        MedalDetails = Enumerable.Range(0, 5).Select((x) =>
        {
            dynamic d = new ExpandoObject();
            d.X = countries[x];
            d.Y = randomNum.Next(20, 80);
            return d;
        }).Cast<ExpandoObject>().ToList<ExpandoObject>();
    }
}
```

![Blazor Chart with ExpandoObject Binding](images/working-data/blazor-chart-expando-object-binding.png)

### DynamicObject binding

Blazor 3D Chart supports **DynamicObject** data source when the model type is unknown. The **DynamicObject** can be bound to chart by assigning to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) property.

```cshtml
@using Syncfusion.Blazor.Chart3D
@using System.Dynamic

<SfChart3D>
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime"></Chart3DPrimaryXAxis>
    <Chart3DPrimaryYAxis></Chart3DPrimaryYAxis>
    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="MedalDetails" XName="X" YName="Y" Type="Chart3DSeriesType.Column"></Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

@code{
    private List<DateTime> Dates = new List<DateTime> { new DateTime(2005, 01, 01), new DateTime(2006, 01, 01), 
        new DateTime(2007, 01, 01), new DateTime(2008, 01, 01), new DateTime(2009, 01, 01), new DateTime(2010, 01, 01), new DateTime(2011, 01, 01) };
    public DateTime[] Value = new DateTime[] { new DateTime(2006, 01, 01), new DateTime(2008, 01, 01) };
    private Random randomNum = new Random();
    public List<DynamicDictionary> MedalDetails = new List<DynamicDictionary>() { };
    protected override void OnInitialized()
    {
        MedalDetails = Enumerable.Range(0, 5).Select((x) =>
        {
            dynamic d = new DynamicDictionary();
            d.X = Dates[x];
            d.Y = randomNum.Next(20, 80);
            return d;
        }).Cast<DynamicDictionary>().ToList<DynamicDictionary>();
    }
    public class DynamicDictionary : DynamicObject
    {
        Dictionary<string, object> dictionary = new Dictionary<string, object>();

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            string name = binder.Name;
            return dictionary.TryGetValue(name, out result);
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            dictionary[binder.Name] = value;
            return true;
        }

        public override System.Collections.Generic.IEnumerable<string> GetDynamicMemberNames()
        {
            return this.dictionary?.Keys;
        }
    }
}
```

![Blazor 3D Chart with DynamicObject Binding](images/working-data/blazor-chart-dynamic-object.png)

## Remote data

The remote data can be bound to the 3D chart using the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html). The `DataManager` requires minimal information like web service URL, adaptor and cross domain to interact with service endpoint properly. Assign the instance of the `DataManager` to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) property in series and map the fields of data to [XName]() and [YName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_YName) properties.

```cshtml

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Chart3D
@using System.Dynamic

<SfChart3D>
    <SfDataManager Url="https://blazor.syncfusion.com/services/development/api/chart" Adaptor="Adaptors.WebApiAdaptor"></SfDataManager>

    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></Chart3DPrimaryXAxis>

    <Chart3DSeriesCollection>
        <Chart3DSeries XName="FoodName" YName="Price" Type="Chart3DSeriesType.Column"></Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hXBAihBrgvFhnbIU?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Remote Data Binding in Blazor 3D Chart](images/working-data/blazor-chart-remote-data-binding.png)

### Binding with OData services

[OData](https://www.odata.org/documentation/odata-version-3-0/) is a standardized data creation and consumption protocol. The [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) can be used to retrieve data from an [OData](https://www.odata.org/documentation/odata-version-3-0/) service. For remote data binding using the [OData](https://www.odata.org/documentation/odata-version-3-0/) service, see the code below.

### Binding with OData v4 services

The [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) can retrieve and consume OData v4 services, which is an upgraded version of OData protocols. Refer to the [OData documentation](https://docs.oasis-open.org/odata/odata/v4.0/errata03/os/complete/part1-protocol/odata-v4.0-errata03-os-part1-protocol-complete.html#_Toc453752197) for additional information on OData v4 services. To bind an OData v4 service, use the **ODataV4Adaptor**.

```cshtml
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Charts

<SfChart>
    <SfDataManager Url="https://blazor.syncfusion.com/services/production/api/Orders" Adaptor="Adaptors.WebApiAdaptor"></SfDataManager>

    <ChartPrimaryXAxis Title="Orders" ValueType="Syncfusion.Blazor.Charts.ValueType.Category"
                       ></ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries XName="OrderID" YName="Freight" Type="ChartSeriesType.Column"></ChartSeries>
    </ChartSeriesCollection>
</SfChart>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LjVKsrVVKFPmAhzX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor 3D Chart with ODataV4Adaptor Binding](images/working-data/blazor-chart-odata-adaptor-binding.png)

## Empty points
The data points that uses the `null` or `undefined` as value are considered as empty points. The empty data points are ignored and is not plotted in the chart. When the data is provided by using the points property, by using [EmptyPointSettings]() property in series, the empty can be customized. The default [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Mode) of the empty point is **Gap**.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D>
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </Chart3DPrimaryXAxis>

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@SalesReports" XName="Month" YName="Sales" Type="Chart3DSeriesType.Column">
            <Chart3DEmptyPointSettings Fill="gray" Mode="EmptyPointMode.Average">
            </Chart3DEmptyPointSettings>
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

@code{
    public class Chart3DData
    {
        public string Month { get; set; }
        public Nullable<double> Sales { get; set; }
    }

    public List<Chart3DData> SalesReports = new List<Chart3DData>
    {
        new Chart3DData{ Month= "Jan", Sales= 35 },
        new Chart3DData{ Month= "Feb", Sales= 28 },
        new Chart3DData{ Month= "Mar", Sales= double.NaN },
        new Chart3DData{ Month= "Apr", Sales= 32 },
        new Chart3DData{ Month= "May", Sales= 40 },
        new Chart3DData{ Month= "Jun", Sales= 32 },
        new Chart3DData{ Month= "Jul", Sales= 35 },
        new Chart3DData{ Month= "Aug", Sales= double.NaN },
        new Chart3DData{ Month= "Sep", Sales= 38 },
        new Chart3DData{ Month= "Oct", Sales= 30 },
        new Chart3DData{ Month= "Nov", Sales= 25 },
        new Chart3DData{ Month= "Dec", Sales= 32 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VtLUWVrBKOfaDiKg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

[Blazor Column 3D Chart with Empty Points]

N> Refer to our [Blazor 3D Chart](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor 3D Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See also

* [Data label](./data-labels)
* [Tooltip](./tool-tip)
* [Marker](./data-markers)