---
layout: post
title: Data Binding in Blazor ListView Component | Syncfusion
description: Checkout and learn here all about data binding in Syncfusion Blazor ListView component and much more.
platform: Blazor
control: Listview
documentation: ug
---

# Data Binding in Blazor ListView Component

ListView provides an option to load the data either from local dataSource or remote data services. This can be done through the [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Lists.SfListView-1.html#Syncfusion_Blazor_Lists_SfListView_1_DataSource) property that supports the data type of array or [`DataManager`](https://blazor.syncfusion.com/documentation/data/getting-started). ListView supports different kind of data services such as OData, OData V4, and Web API, and data formats like XML, JSON, and, JSONP with the help of DataManager Adaptors.

| Fields | Type | Description |
|------|------|-------------|
| Id | string | Specifies ID attribute of list item, mapped in dataSource. |
| Text | string | Specifies list item display text field. |
| IsChecked | string | Specifies checked status of list item. |
| Enabled | string | Specifies enabled state of list item. |
| IconCss | string | Specifies the icon class of each list item that will be added before to the list item text. |
| Child | string | Specifies child dataSource fields. |
| Tooltip | string | Specifies tooltip title text field. |
| GroupBy | string | Specifies category of each list item. |
| HtmlAttributes | string | Specifies list item html attributes field. |

N> When complex data bind to ListView, you should map the [`ListViewFieldSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Lists.ListViewFieldSettings-1.html) properly. Otherwise, the ListView properties remains as undefined or null.

## Bind to local data

Local data can be represented in Array of JSON data:

### Array of JSON data

ListView can generate its list items through an array of complex data. To get it work properly, you should map the appropriate columns to the [`ListViewFieldSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Lists.ListViewFieldSettings-1.html) property.

```cshtml
@using Syncfusion.Blazor.Lists
<SfListView DataSource="@Data">
    <ListViewFieldSettings TValue="DataModel" Id="Id" Text="Text"></ListViewFieldSettings>
</SfListView>

@code {
   public string HeaderTitle = "Listview";

    List<DataModel> Data = new List<DataModel>();

    protected override void OnInitialized()
    {
        base.OnInitialized();
        Data.Add(new DataModel { Text = "Hennessey Venom", Id = "list-01" });
        Data.Add(new DataModel { Text = "Bugatti Chiron", Id = "list-02" });
        Data.Add(new DataModel { Text = "Bugatti Veyron Super Sport", Id = "list-03" });
        Data.Add(new DataModel { Text = "SSC Ultimate Aero", Id = "list-04" });
        Data.Add(new DataModel { Text = "Koenigsegg CCR", Id = "list-05" });
        Data.Add(new DataModel { Text = "McLaren F1", Id = "list-06" });
        Data.Add(new DataModel { Text = "Aston Martin One- 77", Id = "list-07" });
        Data.Add(new DataModel { Text = "Jaguar XJ220", Id = "list-08" });
        Data.Add(new DataModel { Text = "McLaren P1", Id = "list-09" });
        Data.Add(new DataModel { Text = "Ferrari LaFerrari", Id = "list-10" });
    }

    public class DataModel
    {
        public string Id { get; set; }
        public string Text { get; set; }
    }

}
```

![Data Binding in Blazor ListView](./images/list/blazor-listview-data-binding.png)

## Bind to remote data

The ListView supports to retrieve the data from remote data services with the help of [`DataManager`](https://blazor.syncfusion.com/documentation/data/getting-started) control. The `Query` property allows to fetch data and return it to the ListView from the database.

In the following sample, first 6 products from the Product table of NorthWind data service are displayed.

```cshtml
@using Syncfusion.Blazor.Lists
@using Syncfusion.Blazor.Data

<SfListView  HeaderTitle="Products" ShowHeader="true" TValue="Data" Query="@query">
    <ListViewFieldSettings TValue="Data" Id="ProductID" Text="ProductName"></ListViewFieldSettings>
    <SfDataManager Url="https://services.odata.org/V4/Northwind/Northwind.svc/" Adaptor="Adaptors.ODataV4Adaptor"></SfDataManager>
</SfListView>

@code {

    public static List<string> column = new List<string>()
{
        "ProductID","ProductName"
    };
    Query query = new Query().From("Products").Select(column).Take(6);
    public class Data
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
    }
}
```

![Data Binding in Blazor ListView](./images/list/blazor-listview-binding-data.png)

