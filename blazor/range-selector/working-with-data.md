---
layout: post
title: Working with Data in Blazor Range Selector Component | Syncfusion
description: Checkout and learn here all about Working with Data in Syncfusion Blazor Range Selector Component and much more.
platform: Blazor
control: Chart
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# Working with Data in Blazor Range Selector Component

The Range Selector uses [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html), which supports both RESTful JSON data services binding and IEnumerable binding. The [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorSeries.html#Syncfusion_Blazor_Charts_RangeNavigatorSeries_DataSource) value can be set using either [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) property value or a list of business objects.

It supports the following data binding methods:
* List binding
* Remote data

## List binding

To do list binding to the Range Selector, you can assign a IEnumerable object to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorSeries.html#Syncfusion_Blazor_Charts_RangeNavigatorSeries_DataSource) property. The list data source can also be provided as an instance of the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) or by using [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component.

```cshtml

@using Syncfusion.Blazor.Charts

<SfRangeNavigator Value="@Value" ValueType="RangeValueType.DateTime" IntervalType="RangeIntervalType.Years">
    <RangeNavigatorSeriesCollection>
        <RangeNavigatorSeries DataSource="@StockInfo" XName="Date" Type="RangeNavigatorType.Line" YName="Close">
        </RangeNavigatorSeries>
    </RangeNavigatorSeriesCollection>
</SfRangeNavigator>

@code {

    public class StockDetails
    {
        public DateTime Date { get; set; }
        public double Close { get; set; }
    }

    public DateTime[] Value = new DateTime[] { new DateTime(2006, 01, 01), new DateTime(2008, 01, 01) };

    public List<StockDetails> StockInfo = new List<StockDetails>
    {
        new StockDetails { Date = new DateTime(2005, 01, 01), Close = 21 },
        new StockDetails { Date = new DateTime(2006, 01, 01), Close = 24 },
        new StockDetails { Date = new DateTime(2007, 01, 01), Close = 36 },
        new StockDetails { Date = new DateTime(2008, 01, 01), Close = 38 },
        new StockDetails { Date = new DateTime(2009, 01, 01), Close = 54 },
        new StockDetails { Date = new DateTime(2010, 01, 01), Close = 57 },
        new StockDetails { Date = new DateTime(2011, 01, 01), Close = 70 }
    };
}

```

![Blazor Range Navigator with List](images/working-data/blazor-range-list-binding.png)

N> By default, [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) uses **BlazorAdaptor** for list data-binding.

### ExpandoObject binding

Range Selector is a generic component which is strongly bound to a model type. There are cases when the model type is unknown during compile time. In such circumstances data can be bound to the Range Selector as a list of **ExpandoObject**. The **ExpandoObject** can be bound to Range Selector by assigning to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorSeries.html#Syncfusion_Blazor_Charts_RangeNavigatorSeries_DataSource) property.

```cshtml

@using Syncfusion.Blazor.Charts
@using System.Dynamic

<SfRangeNavigator Value="@Value" ValueType="RangeValueType.DateTime">
    <RangeNavigatorSeriesCollection>
        <RangeNavigatorSeries DataSource="@StockInfo" XName="X" Type="RangeNavigatorType.Area" YName="Y">
        </RangeNavigatorSeries>
    </RangeNavigatorSeriesCollection>
</SfRangeNavigator>

@code{
    private List<DateTime> Dates = new List<DateTime> { new DateTime(2005, 01, 01), new DateTime(2006, 01, 01), 
        new DateTime(2007, 01, 01), new DateTime(2008, 01, 01), new DateTime(2009, 01, 01), new DateTime(2010, 01, 01), new DateTime(2011, 01, 01) };
    public DateTime[] Value = new DateTime[] { new DateTime(2006, 01, 01), new DateTime(2008, 01, 01) };
    public List<ExpandoObject> StockInfo { get; set; } = new List<ExpandoObject>();
    private Random randomNum = new Random();
    protected override void OnInitialized()
    {
        StockInfo = Enumerable.Range(0, 6).Select((x) =>
        {
            dynamic d = new ExpandoObject();
            d.X = Dates[x];
            d.Y = randomNum.Next(20, 70);
            return d;
        }).Cast<ExpandoObject>().ToList<ExpandoObject>();
    }
        
}
```

![Blazor Range Navigator with ExpandoObject](images/working-data/blazor-range-expando-object.png)

### DynamicObject binding

Range Selector supports **DynamicObject** data source when the model type is unknown. The **DynamicObject** can be bound to Range Selector by assigning to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorSeries.html#Syncfusion_Blazor_Charts_RangeNavigatorSeries_DataSource) property.

```cshtml

@using Syncfusion.Blazor.Charts
@using System.Dynamic

<SfRangeNavigator ValueType="RangeValueType.DateTime" Width="450">
    <RangeNavigatorSeriesCollection>
        <RangeNavigatorSeries DataSource="@MedalDetails" XName="X" Type="RangeNavigatorType.Area" YName="Y">
        </RangeNavigatorSeries>
    </RangeNavigatorSeriesCollection>
</SfRangeNavigator>


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

![Blazor Range Navigator with DynamicObject](images/working-data/blazor-range-dynamic-object.png)

## Remote data

### Binding with OData services

[OData](https://www.odata.org/documentation/odata-version-3-0/) is a standardized protocol for creating and consuming data. You can retrieve data from OData service using the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html). Refer to the following code example for remote data binding using OData service.

```cshtml

@using Syncfusion.Blazor.Charts
@using Syncfusion.Blazor.Data

<SfRangeNavigator ValueType="RangeValueType.Double">    
    <RangeNavigatorSeriesCollection>
        <RangeNavigatorSeries XName="OrderID" Type="RangeNavigatorType.Line" YName="Freight">
            <SfDataManager Url="https://services.odata.org/V4/Northwind/Northwind.svc/Orders" Adaptor="Adaptors.ODataAdaptor"></SfDataManager>
        </RangeNavigatorSeries>
    </RangeNavigatorSeriesCollection>
</SfRangeNavigator>

```

![Blazor Range Navigator with OData Adaptor](images/working-data/blazor-range-remote-data.png)

### Binding with OData v4 services

The [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) can retrieve and consume OData v4 services, which is an upgraded version of OData protocols. Refer to the  [OData documentation](http://docs.oasis-open.org/odata/odata/v4.0/errata03/os/complete/part1-protocol/odata-v4.0-errata03-os-part1-protocol-complete.html#_Toc453752197) for additional information on OData v4 services. To bind an OData v4 service, use the **ODataV4Adaptor**.

```cshtml

@using Syncfusion.Blazor.Charts
@using Syncfusion.Blazor.Data

<SfRangeNavigator ValueType="RangeValueType.Double">    
    <RangeNavigatorSeriesCollection>
        <RangeNavigatorSeries XName="OrderID" Type="RangeNavigatorType.Line" YName="Freight">
            <SfDataManager Url="https://services.odata.org/V4/Northwind/Northwind.svc/Orders" Adaptor="Adaptors.ODataV4Adaptor"></SfDataManager>
        </RangeNavigatorSeries>
    </RangeNavigatorSeriesCollection>
</SfRangeNavigator>

```

![Blazor Range Navigator with OData v4 adaptor](images/working-data/blazor-range-remote-data.png)

### Web API

The [WebApiAdaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.WebApiAdaptor.html) can be used to bind a Range Selector to a Web API created using an [OData](https://www.odata.org/documentation/odata-version-3-0/) endpoint.

```cshtml
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Charts

<SfRangeNavigator ValueType="RangeValueType.Double">    
    <RangeNavigatorSeriesCollection>
        <RangeNavigatorSeries XName="OrderID" Type="RangeNavigatorType.Line" YName="Freight">
            <SfDataManager Url="https://services.odata.org/V4/Northwind/Northwind.svc/Orders" Adaptor="Adaptors.WebAPIAdaptor"></SfDataManager>
        </RangeNavigatorSeries>
    </RangeNavigatorSeriesCollection>
</SfRangeNavigator>

```

![Blazor Range Navigator with Web API](images/working-data/blazor-range-remote-data.png)

### Sending additional parameters to the server

To create a data request with a custom parameter, add additional parameters to the [Query](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorSeries.html#Syncfusion_Blazor_Charts_RangeNavigatorSeries_Query) object and assign it to the Range Selector's `Query` property.

The following sample code shows how to send parameters using the `Query` property in the series.

```cshtml
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Charts

<SfRangeNavigator ValueType="RangeValueType.Double">    
    <RangeNavigatorSeriesCollection>
        <RangeNavigatorSeries Query="@RNQuery" XName="OrderID" Type="RangeNavigatorType.Line" YName="Freight">
            <SfDataManager Url="https://services.odata.org/V4/Northwind/Northwind.svc/Orders" Adaptor="Adaptors.ODataV4Adaptor"></SfDataManager>
        </RangeNavigatorSeries>
    </RangeNavigatorSeriesCollection>
</SfRangeNavigator>

@code {
    public Query RNQuery { get; set; }

    protected override void OnInitialized()
    {
        RNQuery = new Query().Take(10).Where("Freight", "GreaterThan", 300, false);
    }

}
```
![Blazor Range Navigator with Query](images/working-data/blazor-range-remote-data.png)

## Observable collection

The [ObservableCollection](https://learn.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.observablecollection-1?view=net-6.0) (dynamic data collection) provides notifications when items are added, removed, and moved. The implemented [INotifyCollectionChanged](https://learn.microsoft.com/en-us/dotnet/api/system.collections.specialized.inotifycollectionchanged?view=net-6.0) provides notification when the dynamic changes of adding, removing, moving, and clearing the collection occur.

```cshtml

@using Syncfusion.Blazor.Charts
@using System.Collections.ObjectModel;

<SfRangeNavigator Value="@Value" ValueType="RangeValueType.DateTime" IntervalType="RangeIntervalType.Years">
    <RangeNavigatorSeriesCollection>
        <RangeNavigatorSeries DataSource="@ChartPoints" XName="Date" Type="RangeNavigatorType.Line" YName="Close">
        </RangeNavigatorSeries>
    </RangeNavigatorSeriesCollection>
</SfRangeNavigator>

@code {
    public ObservableCollection<RangeData> ChartPoints { get; set; }

    public DateTime[] Value = new DateTime[] { new DateTime(2006, 01, 01), new DateTime(2008, 01, 01) };

    public class RangeData
    {
        public DateTime Date { get; set; }
        public double Close { get; set; }
        public static ObservableCollection<RangeData> GetData()
        {
            ObservableCollection<RangeData> ChartPoints = new ObservableCollection<RangeData>()
            {
                new RangeData { Date = new DateTime(2005, 01, 01), Close = 21 },
                new RangeData { Date = new DateTime(2006, 01, 01), Close = 24 },
                new RangeData { Date = new DateTime(2007, 01, 01), Close = 36 },
                new RangeData { Date = new DateTime(2008, 01, 01), Close = 38 },
                new RangeData { Date = new DateTime(2009, 01, 01), Close = 54 },
                new RangeData { Date = new DateTime(2010, 01, 01), Close = 57 },
                new RangeData { Date = new DateTime(2011, 01, 01), Close = 70 }
            };
            return ChartPoints;
        }
    }

    protected override void OnInitialized()
    {
        this.ChartPoints = RangeData.GetData();
    }
}
```

![Blazor Chart with Web API Binding](images/working-data/blazor-range-observable-collection.png)

N> Refer to our [Blazor Range Selector](https://www.syncfusion.com/blazor-components/blazor-range-selector) feature tour page for its groundbreaking feature representations and also explore our [Blazor Range Selector Example](https://blazor.syncfusion.com/demos/range-selector/range-navigator?theme=fluent) to know various Range Selector types and how to represent time-dependent data, showing trends at equal intervals.