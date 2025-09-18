---
layout: post
title: Local Data in Blazor DataGrid | Syncfusion
description: Explore how to bind and display local data in the Syncfusion Blazor DataGrid using various approaches and customization options.
platform: Blazor
control: DataGrid
documentation: ug
---

# Local data in Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid offers a straightforward way to bind local data, such as arrays or JSON objects, to the Grid. This feature allows you to display and manipulate data within the Grid without the need for external server calls, making it particularly useful for scenarios where you're working with static or locally stored data.

To achieve this, you can assign a JavaScript object array to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) property. Additionally, you have an option to provide the local data source using an instance of the **SfDataManager**.

The following example demonstrates how to utilize the local data binding feature in the Grid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData">
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>    
        <GridColumn Field=@nameof(OrderDetails.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>    
    </GridColumns>
</SfGrid>

@code {
    private List<OrderDetails> OrderData;
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
}

{% endhighlight %}

{% highlight cs tabtitle="OrderDetails.cs" %}

public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();

    public OrderDetails() { }

    public OrderDetails(int OrderID, string CustomerId, string ShipCity, string ShipName)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.ShipCity = ShipCity;
        this.ShipName = ShipName;
    }

    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", "Reims", "Vins et alcools Chevalier"));
            order.Add(new OrderDetails(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
            order.Add(new OrderDetails(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            order.Add(new OrderDetails(10251, "VICTE", "Lyon", "Victuailles en stock"));
            order.Add(new OrderDetails(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
            order.Add(new OrderDetails(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            order.Add(new OrderDetails(10254, "CHOPS", "Bern", "Chop-suey Chinese"));
            order.Add(new OrderDetails(10255, "RICSU", "Genève", "Richter Supermarkt"));
            order.Add(new OrderDetails(10256, "WELLI", "Resende", "Wellington Importadora"));
            order.Add(new OrderDetails(10257, "HILAA", "San Cristóbal", "HILARION-Abastos"));
            order.Add(new OrderDetails(10258, "ERNSH", "Graz", "Ernst Handel"));
            order.Add(new OrderDetails(10259, "CENTC", "México D.F.", "Centro comercial Moctezuma"));
            order.Add(new OrderDetails(10260, "OTTIK", "Köln", "Ottilies Käseladen"));
            order.Add(new OrderDetails(10261, "QUEDE", "Rio de Janeiro", "Que Delícia"));
            order.Add(new OrderDetails(10262, "RATTC", "Albuquerque", "Rattlesnake Canyon Grocery"));
        }
        return order;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BthSXpBAUaAyeguK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## List binding

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports binding data from a list of objects (e.g., a List&lt;T&gt; or IEnumerable&lt;T&gt; collection). This is the most common approach when working with in-memory data in Blazor applications.

List binding allows the Grid to render and manage a collection of data directly in memory without requiring a remote service or external data manager unless needed. This is ideal for local CRUD operations, small datasets, or preloaded data.

**List binding can be enabled in the following scenarios:**

You can bind a list of data to the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid using the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) property. The list can be:

* A basic in-memory IEnumerable&lt;T&gt; (e.g., List&lt;Order&gt;).

* Provided via an [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) for additional data operations or offline capabilities.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData" AllowPaging="true">
    <GridPageSettings PageSize="5" PageCount="3"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.DateOnly" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderTime) HeaderText="Order Time" Type="ColumnType.TimeOnly" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="100"></GridColumn>       
    </GridColumns>
</SfGrid>

@code {
    private List<OrderDetails> OrderData;
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
}

{% endhighlight %}

{% highlight cs tabtitle="OrderDetails.cs" %}

public class OrderDetails
{
    public static List<OrderDetails> orders = new List<OrderDetails>();
    public OrderDetails() { }
    public OrderDetails(int orderID, string customerID, DateTime orderDateTime, double freight)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.OrderDate = DateOnly.FromDateTime(orderDateTime);
        this.OrderTime = TimeOnly.FromDateTime(orderDateTime);
        this.Freight = freight;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (orders.Count == 0)
        {
            orders.Add(new OrderDetails(10248, "VINET", new DateTime(1996, 7, 4, 9, 30, 0), 32.38));
            orders.Add(new OrderDetails(10249, "TOMSP", new DateTime(1996, 7, 5, 11, 45, 0), 11.61));
            orders.Add(new OrderDetails(10250, "HANAR", new DateTime(1996, 7, 8, 14, 15, 0), 65.83));
            orders.Add(new OrderDetails(10251, "VICTE", new DateTime(1996, 7, 8, 16, 0, 0), 41.34));
            orders.Add(new OrderDetails(10252, "SUPRD", new DateTime(1996, 7, 9, 10, 20, 0), 51.3));
            orders.Add(new OrderDetails(10253, "HANAR", new DateTime(1996, 7, 10, 13, 5, 0), 58.17));
            orders.Add(new OrderDetails(10254, "CHOPS", new DateTime(1996, 7, 11, 17, 45, 0), 22.98));
            orders.Add(new OrderDetails(10255, "RICSU", new DateTime(1996, 7, 12, 8, 50, 0), 148.33));
            orders.Add(new OrderDetails(10256, "WELLI", new DateTime(1996, 7, 15, 12, 10, 0), 13.97));
            orders.Add(new OrderDetails(10257, "HILAA", new DateTime(1996, 7, 16, 15, 30, 0), 81.91));
            orders.Add(new OrderDetails(10258, "ERNSH", new DateTime(1996, 7, 17, 10, 45, 0), 140.51));
            orders.Add(new OrderDetails(10259, "CENTC", new DateTime(1996, 7, 18, 9, 0, 0), 3.25));
            orders.Add(new OrderDetails(10260, "OTTIK", new DateTime(1996, 7, 19, 16, 20, 0), 55.09));
            orders.Add(new OrderDetails(10261, "QUEDE", new DateTime(1996, 7, 19, 13, 25, 0), 3.05));
            orders.Add(new OrderDetails(10262, "RATTC", new DateTime(1996, 7, 22, 11, 40, 0), 48.29));
        }
        return orders;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public DateOnly OrderDate { get; set; }
    public TimeOnly OrderTime { get; set; }
    public double Freight { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BtreNzrLVoDAAALh?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> By default, the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) uses the **BlazorAdaptor** for list data binding.

### ExpandoObject binding

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid is a strongly-typed generic component typically bound to a specific model at compile time. However, there are scenarios, especially in dynamic or metadata-driven applications, where the structure of the data is not known until runtime. In such cases, you can bind the Grid to a collection of [ExpandoObject](https://learn.microsoft.com/en-us/dotnet/api/system.dynamic.expandoobject?view=net-9.0) instances for a fully dynamic Grid structure.

**ExpandoObject can be used in the following scenarios:**

* For dynamic or runtime-generated data models.

* For dynamically constructing Grid columns and data (e.g., based on user input or metadata).

* For integrating with systems where the data structure cannot be statically defined.

For a visual demonstration of how to bind **ExpandoObject** in the Grid, watch this video:

{% youtube
"youtube:https://www.youtube.com/watch?v=Xhaw3DdHmJk"%}

You can assign a list of **ExpandoObject** to the Grid’s [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) property. Grid features like **paging**, **sorting**, **filtering**, and even **editing** are supported when using **ExpandoObject**.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using System.Dynamic

<SfGrid DataSource="@Orders" AllowPaging="true" Toolbar="@ToolbarItems">
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field="CustomerID" HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field="Freight" HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field="OrderDate" HeaderText=" Order Date" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field="ShipCountry" HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
        <GridColumn Field="Verified" HeaderText="Active" DisplayAsCheckBox="true" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<ExpandoObject> Orders { get; set; } = new List<ExpandoObject>();
    private List<string> ToolbarItems = new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" };
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select((x) =>
        {
            dynamic Order = new ExpandoObject();
            Order.OrderID = 1000 + x;
            Order.CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)];
            Order.Freight = (new double[] { 2, 1, 4, 5, 3 })[new Random().Next(5)] * x;
            Order.OrderDate = (new DateTime[] { new DateTime(1996, 11, 5), new DateTime(1996, 10, 3), new DateTime(1996, 9, 9), new DateTime(1996, 8, 2), new DateTime(1996, 4, 11) })[new Random().Next(5)];
            Order.ShipCountry = (new string[] { "USA", "UK" })[new Random().Next(2)];
            Order.Verified = (new bool[] { true, false })[new Random().Next(2)];
            return Order;
        }).Cast<ExpandoObject>().ToList<ExpandoObject>();
    }
}

{% endhighlight %}
{% endtabs %}

Please find the sample in this [GitHub location](https://github.com/SyncfusionExamples/databinding-in-blazor-datagrid/blob/master/ListBinding/ListBinding/Components/Pages/ExpandoObjectBinding.razor).

### ExpandoObject complex data binding

When working with complex or nested data structures using [ExpandoObject](https://learn.microsoft.com/en-us/dotnet/api/system.dynamic.expandoobject?view=net-9.0), the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows you to bind these nested fields using dot (.) notation. This is especially helpful when your **ExpandoObject** contains sub-objects or hierarchical data, and you want to present specific properties of those nested objects in individual Grid columns.

The following example demonstrates how to bind complex properties within an **ExpandoObject** to the Grid. In this sample, **CustomerID.Name** and **ShipCountry.Country** represent nested fields from the underlying dynamic object, and they are individually bound to display in their respective columns:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using System.Dynamic

<SfGrid DataSource="@Orders" AllowPaging="true" AllowFiltering="true" AllowSorting="true" AllowGrouping="true" Toolbar="@ToolbarItems">
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field="CustomerID.Name" HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field="Freight" HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field="OrderDate" HeaderText=" Order Date" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field="ShipCountry.Country" HeaderText="Ship Country"  Width="150"></GridColumn>
        <GridColumn Field="Verified" HeaderText="Active" DisplayAsCheckBox="true" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<ExpandoObject> Orders { get; set; } = new List<ExpandoObject>();
    private List<string> ToolbarItems = new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" };
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select((x) =>
        {
            dynamic Order = new ExpandoObject();
            dynamic customerName = new ExpandoObject();
            dynamic countryName = new ExpandoObject();
            Order.OrderID = 1000 + x;
            customerName.Name = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)];
            Order.CustomerID = customerName;
            Order.Freight = (new double[] { 2, 1, 4, 5, 3 })[new Random().Next(5)] * x;
            Order.OrderDate = (new DateTime[] { new DateTime(1996, 11, 5), new DateTime(1996, 10, 3), new DateTime(1996, 9, 9), new DateTime(1996, 8, 2), new DateTime(1996, 4, 11) })[new Random().Next(5)];
            countryName.Country = (new string[] { "USA", "UK" })[new Random().Next(2)];
            Order.ShipCountry = countryName;
            Order.Verified = (new bool[] { true, false })[new Random().Next(2)];

            return Order;
        }).Cast<ExpandoObject>().ToList<ExpandoObject>();
    }
}

{% endhighlight %}
{% endtabs %}

> You can perform data operations and CRUD operations for complex ExpandoObject binding fields as well.

The following image represents ExpandoObject complex data binding,

![Binding ExpandObject with complex data in Blazor DataGrid](./images/blazor-datagrid-expand-complex-data.png)

Please find the sample in this [GitHub location](https://github.com/SyncfusionExamples/databinding-in-blazor-datagrid/blob/master/ListBinding/ListBinding/Components/Pages/ExpandoObjectComplexBinding.razor).

### DynamicObject binding

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid is designed to work with strongly-typed models. However, in scenarios where the model structure is not known at compile time, such as metadata-driven Grids or dynamic data sources, you can bind the Grid to a list of objects derived from [DynamicObject](https://learn.microsoft.com/en-us/dotnet/api/system.dynamic.dynamicobject).

**DynamicObject can be implemented in this below scenarios:**

* In cases where data models are unknown at compile time.

* For creating dynamic, metadata-driven Grid layouts.

* During integration with external or runtime-generated data sources with unpredictable structures.

For a visual demonstration of how to bind a **DynamicObject** in the Grid, watch this video:

{% youtube
"youtube:https://www.youtube.com/watch?v=Xhaw3DdHmJk"%}

To bind a **DynamicObject**, assign a list of dynamic instances to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) property.

> You must override the [GetDynamicMemberNames](https://learn.microsoft.com/en-us/dotnet/api/system.dynamic.dynamicobject.getdynamicmembernames?view=net-9.0) method in your **DynamicObject** implementation. This allows the Grid to detect the property names during rendering and perform **editing**, **sorting**, **filtering**, and **paging** operations.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using System.Dynamic

<SfGrid DataSource="@Orders" AllowPaging="true" Toolbar="@ToolbarItems">
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field="CustomerID" HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field="OrderDate" HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" EditType="EditType.DatePickerEdit" Width="130"></GridColumn>
        <GridColumn Field="Freight" HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private List<string> ToolbarItems = new List<string>(){ "Add", "Edit", "Delete", "Update", "Cancel"};
    public List<DynamicDictionary> Orders = new List<DynamicDictionary>() { };
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 15).Select((x) =>
        {
            dynamic Order = new DynamicDictionary();
            Order.OrderID = 1000 + x;
            Order.CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)];
            Order.Freight = (new double[] { 2, 1, 4, 5, 3 })[new Random().Next(5)] * x;
            Order.OrderDate = (new DateTime[] { new DateTime(1996, 11, 5), new DateTime(1996, 10, 3), new DateTime(1996, 9, 9), new DateTime(1996, 8, 2), new DateTime(1996, 4, 11) })[new Random().Next(5)];
            return Order;
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

{% endhighlight %}
{% endtabs %}

Please find the sample in this [GitHub location](https://github.com/SyncfusionExamples/databinding-in-blazor-datagrid/blob/master/ListBinding/ListBinding/Components/Pages/DynamicObjectBinding.razor).

### DynamicObject complex data binding

When working with complex or nested data structures using [DynamicObject](https://learn.microsoft.com/en-us/dotnet/api/system.dynamic.dynamicobject), the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows you to bind these nested fields using dot (.) notation. This is especially helpful when your **DynamicObject** contains sub-objects or hierarchical data, and you want to present specific properties of those nested objects in individual Grid columns.

The following example demonstrates how to bind complex properties within a **DynamicObject** to the Grid. In this sample, **CustomerID.Name** and **ShipCountry.Country** represent nested fields from the underlying dynamic object, and they are individually bound to display in their respective columns:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using System.Dynamic

<SfGrid DataSource="@Orders" AllowPaging="true" AllowFiltering="true" AllowSorting="true" AllowGrouping="true" Toolbar="@ToolbarItems">
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field="CustomerID.Name" HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field="OrderDate" HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" EditType="EditType.DatePickerEdit" Width="130"></GridColumn>
        <GridColumn Field="Freight" HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field="ShipCountry.Country" HeaderText="Ship Country" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private List<string> ToolbarItems = new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" };
    public List<DynamicDictionary> Orders = new List<DynamicDictionary>() { };
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 15).Select((x) =>
        {
            dynamic Order = new DynamicDictionary();
            dynamic customerName = new DynamicDictionary();
            dynamic countryName = new DynamicDictionary();
            Order.OrderID = 1000 + x;
            customerName.Name = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)];
            Order.CustomerID = customerName;
            Order.Freight = (new double[] { 2, 1, 4, 5, 3 })[new Random().Next(5)] * x;
            Order.OrderDate = (new DateTime[] { new DateTime(1996, 11, 5), new DateTime(1996, 10, 3), new DateTime(1996, 9, 9), new DateTime(1996, 8, 2), new DateTime(1996, 4, 11) })[new Random().Next(5)];
            countryName.Country = (new string[] { "USA", "UK" })[new Random().Next(2)];
            Order.ShipCountry = countryName;
            return Order;
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

{% endhighlight %}
{% endtabs %}

> You can perform data operations and CRUD operations for complex DynamicObject binding fields as well.

The following image represents DynamicObject complex data binding

![Binding DynamicObject with Complex Data in Blazor DataGrid](./images/blazor-datagrid-dynamic-complex-data.png)

Please find the sample in this [GitHub location](https://github.com/SyncfusionExamples/databinding-in-blazor-datagrid/blob/master/ListBinding/ListBinding/Components/Pages/DynamicObjectComplexBinding.razor).

> When binding the Grid DataSource dynamically as a list of IEnumerable collections, you need to call the [Refresh](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Refresh_System_Boolean_) method of the Grid to reflect the changes externally. This is because tracking changes made externally to IEnumerable items is avoided for performance considerations.

### DataTable binding

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports binding data from a `System.Data.DataTable` using a custom adaptor, enabling dynamic generation of rows and columns based on backend data. This approach is particularly useful for scenarios where data is retrieved or processed in a DataTable format, and it provides full support for built-in data operations like paging, filtering, sorting, and searching. 

To bind a `DataTable` to Grid, set `TValue` to **ExpandoObject**, convert it into an **IQueryable&lt;ExpandoObject&gt;** collection, and supply it through a custom adaptor that extends DataAdaptor.

**Steps to bind DataTable to Grid:**

* Create a `DataTable` and populate it with data.

* Convert it to a list of **ExpandoObject** using a helper method.

* Use a custom adaptor by extending the [DataAdaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html) class.

* Override the [Read](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_Read_Syncfusion_Blazor_DataManagerRequest_System_String_) method to handle data fetching and operations.

The following example demonstrates how to bind a `DataTable` with a **CustomAdaptor**. In the example below, the `DataTable` is passed to the `ToQueryableCollection` method, which converts the `DataTable` data source into an **IQueryable** collection data source.

You can perform data operations like **searching**, **sorting**, and **filtering** using the `PerformDataOperation` method. This method takes a `DataTable` and a [DataManagerRequest](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html) object as parameters, processes the data operations, and then returns an **IQueryable** data source.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor;
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids
@using System.Dynamic;
@using System.Data;

<SfGrid TValue="ExpandoObject" ID="Grid" AllowSorting="true" AllowPaging="true" AllowFiltering="true" Toolbar="@(new List<string>() { "Search" })">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true, Number=true})" Width="100"></GridColumn>
        <GridColumn Field="CustomerID" HeaderText="Customer Name" ValidationRules="@(new ValidationRules { Required=true})" Width="100"></GridColumn>
        <GridColumn Field="OrderDate" HeaderText="Order Date" Format="d" Type="ColumnType.Date" Width="110"></GridColumn>
        <GridColumn Field="EmployeeID" HeaderText="Employee ID" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public static DataTable dataTable { get; set; }
    public static IQueryable DataSource;

    protected override void OnInitialized()
    {
        dataTable = GetData();

        // Convert the DataTable to an IQueryable<ExpandoObject> collection.
        DataSource = ToQueryableCollection(dataTable);  
    }

    // Custom adaptor class to handle data operations by extending the DataAdaptor class.
    public class CustomAdaptor : DataAdaptor
    {
        // Perform the Read operation to fetch data from the source.
        public override object Read(DataManagerRequest DataManagerRequest, string key = null)
        {
            // Apply searching, sorting, and filtering.
            DataSource = PerformDataOperation(dataTable, DataManagerRequest);

            // Get the total record count.
            int count = DataSource.Cast<ExpandoObject>().Count();

            // Perform paging operation using skip and take.
            if (DataManagerRequest.Skip != 0)
            {
                DataSource = QueryableOperation.PerformSkip<object>((IQueryable<object>)DataSource, DataManagerRequest.Skip);
            }
            if (DataManagerRequest.Take != 0)
            {
                DataSource = QueryableOperation.PerformTake<object>((IQueryable<object>)DataSource, DataManagerRequest.Take);
            }

            // Return the result with count if required.
            return DataManagerRequest.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
        }
    }    

    // Performs data operations like searching, sorting, and filtering.
    public static IQueryable PerformDataOperation(DataTable DataTable, DataManagerRequest DataManagerRequest)
    {
        // Convert the DataTable to an IQueryable collection.
        DataSource = ToQueryableCollection(DataTable);

        if (DataManagerRequest.Search != null && DataManagerRequest.Search.Count > 0)
        {
            // Perform searching operation.
            DataSource = DynamicObjectOperation.PerformSearching(DataSource, DataManagerRequest.Search);
        }
        if (DataManagerRequest.Where != null && DataManagerRequest.Where.Count > 0)
        {
            // Perform filtering operation.
            DataSource = DynamicObjectOperation.PerformFiltering(DataSource, DataManagerRequest.Where, DataManagerRequest.Where[0].Operator);
        }
        if (DataManagerRequest.Sorted != null && DataManagerRequest.Sorted.Count > 0)
        {
            // Perform sorting operation.
            DataSource = DynamicObjectOperation.PerformSorting(DataSource, DataManagerRequest.Sorted);
        }
        return DataSource;
    }

    // Converts a DataTable to an IQueryable collection of ExpandoObjects.
    public static IQueryable ToQueryableCollection(DataTable DataTable)
    {
        List<ExpandoObject> expandoList = new List<ExpandoObject>();
        foreach (DataRow row in DataTable.Rows)
        {
            var expandoDict = new ExpandoObject() as IDictionary<String, Object>;
            foreach (DataColumn col in DataTable.Columns)
            {
                var colValue = row[col.ColumnName];
                colValue = (colValue == DBNull.Value) ? null : colValue;
                expandoDict.Add(col.ToString(), colValue);
            }
            expandoList.Add((ExpandoObject)expandoDict);
        }
        return expandoList.AsQueryable();
    }

    public DataTable GetData()
    {
        DataTable DataTable = new DataTable();
        DataTable.Columns.AddRange(new DataColumn[4] { 
            new DataColumn("OrderID", typeof(long)),
            new DataColumn("CustomerID", typeof(string)),
            new DataColumn("EmployeeID",typeof(int)),
            new DataColumn("OrderDate",typeof(DateTime))
        });
        int code = 1000;
        int id = 0;
        for (int i = 1; i <= 15; i++)
        {
            DataTable.Rows.Add(code + 1, "ALFKI", id + 1, new DateTime(1991, 05, 15));
            DataTable.Rows.Add(code + 2, "CHOPS", id + 2, new DateTime(1990, 04, 04));
            DataTable.Rows.Add(code + 3, "ANTON", id + 3, new DateTime(1957, 11, 30));
            DataTable.Rows.Add(code + 4, "DRACH", id + 4, new DateTime(1930, 10, 22));
            DataTable.Rows.Add(code + 5, "BOLID", id + 5, new DateTime(1953, 02, 18));
            code += 5;
            id += 5;
        }
        return DataTable;
    }
}

{% endhighlight %}
{% endtabs %}

**Grouping and Aggregates with DataTable:**

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports dynamic **grouping** and **aggregates** even when bound to a `DataTable` via a custom adaptor. This allows you to group rows by one or more columns and apply aggregate functions (such as **Sum**, **Average**, **Count**, etc.) on those groups or entire datasets.

Below is an example showing how to implement grouping and aggregates in a custom adaptor:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
@using System.Data
@using System.Dynamic
@using System.Collections

<SfGrid TValue="ExpandoObject" AllowPaging="true" AllowGrouping="true">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridGroupSettings ShowGroupedColumn="true"></GridGroupSettings>
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridAggregates>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=Freight Type="AggregateType.Sum" Format="C2">
                    <FooterTemplate>
                        @{
                            var aggregate = (context as AggregateTemplateContext);
                            <div>
                                <p>Sum: @aggregate.Sum</p>
                            </div>
                        }
                    </FooterTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
    </GridAggregates>
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" Width="100" TextAlign="TextAlign.Right" />
        <GridColumn Field="CustomerID" HeaderText="Customer Name" Width="100" />
        <GridColumn Field="EmployeeID" HeaderText="Employee ID" Width="100" />
        <GridColumn Field="OrderDate" HeaderText="Order Date" Width="110" Format="d" Type="ColumnType.Date" />
        <GridColumn Field="Freight" TextAlign="TextAlign.Right" AllowGrouping="false" Format="C2" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public static DataTable dataTable { get; set; }
    public static IQueryable DataSource;

    protected override void OnInitialized()
    {
        dataTable = GetData();

        // Convert the DataTable to an IQueryable<ExpandoObject> collection.
        DataSource = ToQueryableCollection(dataTable);  
    }

    // Custom adaptor class to handle data operations by extending the DataAdaptor class.
    public class CustomAdaptor : DataAdaptor
    {
        // Perform the Read operation to fetch data from the source.
        public override object Read(DataManagerRequest DataManagerRequest, string key = null)
        {
            // Convert DataTable to IQueryable ExpandoObject list
            DataSource = ToQueryableCollection(dataTable);

            // Get the total record count.
            int count = DataSource.Cast<ExpandoObject>().Count();

            // Perform paging operation using skip and take.
            if (DataManagerRequest.Skip != 0)
            {
                DataSource = QueryableOperation.PerformSkip<object>((IQueryable<object>)DataSource, DataManagerRequest.Skip);
            }
            if (DataManagerRequest.Take != 0)
            {
                DataSource = QueryableOperation.PerformTake<object>((IQueryable<object>)DataSource, DataManagerRequest.Take);
            }

            // Perform aggregation operation.
            IDictionary<string, object> aggregates = new Dictionary<string, object>();
            if (DataManagerRequest.Aggregates != null)
            {
                aggregates = DataUtil.PerformAggregation(DataSource, DataManagerRequest.Aggregates);
            }

            // Perform grouping operation.
            DataResult DataObject = new DataResult();
            if (DataManagerRequest.Group != null)
            {
                IEnumerable result = (IEnumerable)DataSource;
                foreach (var group in DataManagerRequest.Group)
                {
                    result = DataUtil.Group<ExpandoObject>(result, group, DataManagerRequest.Aggregates, 0, DataManagerRequest.GroupByFormatter);
                }

                // Return grouped data with count and aggregates if required.
                return DataManagerRequest.RequiresCounts ? new DataResult() { Result = result, Count = count, Aggregates = aggregates } : (object)DataSource;
            }
            
            // Return the final result with count and aggregates if required.
            return DataManagerRequest.RequiresCounts ? new DataResult() { Result = DataSource, Count = count, Aggregates = aggregates } : (object)DataSource;
        }
    }

    // Converts a DataTable to an IQueryable collection of ExpandoObjects.
    public static IQueryable ToQueryableCollection(DataTable DataTable)
    {
        List<ExpandoObject> expandoList = new List<ExpandoObject>();
        foreach (DataRow row in DataTable.Rows)
        {
            var expandoDict = new ExpandoObject() as IDictionary<String, Object>;
            foreach (DataColumn col in DataTable.Columns)
            {
                var colValue = row[col.ColumnName];
                colValue = (colValue == DBNull.Value) ? null : colValue;
                expandoDict.Add(col.ToString(), colValue);
            }
            expandoList.Add((ExpandoObject)expandoDict);
        }
        return expandoList.AsQueryable();
    }

    public DataTable GetData()
    {
        DataTable DataTable = new DataTable();
        DataTable.Columns.AddRange(new DataColumn[5] { 
            new DataColumn("OrderID", typeof(long)),
            new DataColumn("CustomerID", typeof(string)),
            new DataColumn("EmployeeID",typeof(int)),
            new DataColumn("OrderDate",typeof(DateTime)),
            new DataColumn("Freight", typeof(double))
        });
        int code = 1000;
        int id = 0;
        for (int i = 1; i <= 15; i++)
        {
            DataTable.Rows.Add(code + 1, "ALFKI", id + 1, new DateTime(1991, 05, 15), 2.32 * i);
            DataTable.Rows.Add(code + 2, "CHOPS", id + 2, new DateTime(1990, 04, 04), 1.28 * i);
            DataTable.Rows.Add(code + 3, "ANTON", id + 3, new DateTime(1957, 11, 30), 4.31 * i );
            DataTable.Rows.Add(code + 4, "DRACH", id + 4, new DateTime(1930, 10, 22), 2.56 * i);
            DataTable.Rows.Add(code + 5, "BOLID", id + 5, new DateTime(1953, 02, 18), 5.54 * i);
            code += 5;
            id += 5;
        }
        return DataTable;
    }
}

{% endhighlight %}
{% endtabs %}

**DataTable with CRUD operations**

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports CRUD (Create, Read, Update, and Delete) operations with a DataTable using a custom adaptor. You can enable editing in the Grid and override specific methods of the [DataAdaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html) base class to update your `DataTable` in memory.

**The supported methods are:**

* [Insert](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_Insert_Syncfusion_Blazor_DataManager_System_Object_System_String_) / [InsertAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_InsertAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_) – Adds a new record to the `DataTable`.

* [Update](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_Update_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) / [UpdateAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_UpdateAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) – Updates an existing record.

* [Remove](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_Remove_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) / [RemoveAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_RemoveAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) – Removes a record from the `DataTable`.

* [BatchUpdate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_BatchUpdate_Syncfusion_Blazor_DataManager_System_Object_System_Object_System_Object_System_String_System_String_System_Nullable_System_Int32__) / [BatchUpdateAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_BatchUpdateAsync_Syncfusion_Blazor_DataManager_System_Object_System_Object_System_Object_System_String_System_String_System_Nullable_System_Int32__) – Handles batch operations like add, update, and delete in a single transaction (used for Batch Editing).

When using batch editing in the Grid, use the `BatchUpdate`/`BatchUpdateAsync` method to handle the corresponding CRUD operations.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor;
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids
@using System.Dynamic;
@using System.Data;

<SfGrid TValue="ExpandoObject" ID="Grid" AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridEditSettings AllowEditing="true" AllowDeleting="true" AllowAdding="true" Mode="@EditMode.Normal"></GridEditSettings>
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" IsPrimaryKey="true" ValidationRules="@(new ValidationRules{ Required=true, Number=true})" Width="100"></GridColumn>
        <GridColumn Field="CustomerID" HeaderText="Customer Name" ValidationRules="@(new ValidationRules { Required=true})" Width="100"></GridColumn>
        <GridColumn Field="OrderDate" HeaderText="Order Date" Format="d" Type="ColumnType.Date" Width="110"></GridColumn>
        <GridColumn Field="EmployeeID" HeaderText="Employee ID" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public static DataTable dataTable { get; set; }
    public static IQueryable DataSource;
    protected override void OnInitialized()
    {
        dataTable = GetData();

        // Convert the DataTable to an IQueryable<ExpandoObject> collection.
        DataSource = ToQueryableCollection(dataTable);
    }

    // Custom adaptor class to handle data operations by extending the DataAdaptor class.
    public class CustomAdaptor : DataAdaptor
    {
        // Perform the Read operation to fetch data from the source.
        public override object Read(DataManagerRequest DataManagerRequest, string key = null)
        {
            // Convert DataTable to IQueryable ExpandoObject list
            DataSource = ToQueryableCollection(dataTable);

            // Get the total record count.
            int count = DataSource.Cast<ExpandoObject>().Count();

            // Perform paging operation using skip and take.
            if (DataManagerRequest.Skip != 0)
            {
                DataSource = QueryableOperation.PerformSkip<object>((IQueryable<object>)DataSource, DataManagerRequest.Skip);
            }
            if (DataManagerRequest.Take != 0)
            {
                DataSource = QueryableOperation.PerformTake<object>((IQueryable<object>)DataSource, DataManagerRequest.Take);
            }
            
            // Return the result with count if required.
            return DataManagerRequest.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
        }

        // Perform insert operation.
        public override object Insert(DataManager DataManagerRequest, object value, string key)
        {
            DataRow newRow = dataTable.NewRow();
            var data = (ExpandoObject)value;
            foreach (var item in data)
            {
                newRow[item.Key] = item.Value ?? DBNull.Value;
            }
            
            // Insert the new row at the top of the DataTable.
            dataTable.Rows.InsertAt(newRow, 0);

            return value;
        }

        // Perform remove operation.
        public override object Remove(DataManager DataManagerRequest, object value, string keyField, string key)
        {
            DataRow? rowToRemove = null;

            // Find the row to remove based on the key field value.
            foreach (DataRow row in dataTable.Rows)
            {
                if (row[keyField].Equals(value))
                {
                    rowToRemove = row;
                    break;
                }
            }

            // Remove the row from the DataTable if it exists.
            if (rowToRemove != null)
            {
                dataTable.Rows.Remove(rowToRemove);
            }
            return value;
        }

        // Perform update operation.
        public override object Update(DataManager DataManagerRequest, object value, string keyField, string key)
        {
            var data = (IDictionary<string, object>)value;

            // Find the row to update based on the key field value.
            var rowToUpdate = dataTable.Rows
            .Cast<DataRow>()
            .FirstOrDefault(row => row[keyField].Equals(data[keyField]));

            // Update the row with new values if found.
            if (rowToUpdate != null)
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    var columnName = column.ColumnName;
                    var newValue = data[column.ColumnName] ?? column.DefaultValue;
                    rowToUpdate[columnName] = newValue;
                }
            }
            return value;
        }

        // Perform batch update operation for changed, added, and deleted records.
        public override object BatchUpdate(DataManager DataManagerRequest, object Changed, object Added, object Deleted, string KeyField, string Key, int? dropIndex)
        {
            // Handle changed records.
            if (Changed != null)
            {
                var changedRecords = (IEnumerable<IDictionary<string, object>>)Changed;
                foreach (var record in changedRecords)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row[KeyField].Equals(record[KeyField]))
                        {
                            foreach (DataColumn column in dataTable.Columns)
                            {
                                row[column.ColumnName] = record[column.ColumnName] ?? column.DefaultValue;
                            }
                        }
                    }
                }
            }

            // Handle added records.
            if (Added != null)
            {
                var addedRecords = (IEnumerable<IDictionary<string, object>>)Added;

                foreach (var record in addedRecords)
                {
                    DataRow newRow = dataTable.NewRow();
                    foreach (var item in record)
                    {
                        newRow[item.Key] = item.Value ?? DBNull.Value;
                    }

                    // Add the new row to the DataTable.
                    dataTable.Rows.Add(newRow);
                }
            }

            // Handle deleted records.
            if (Deleted != null)
            {
                var deletedRecords = (IEnumerable<IDictionary<string, object>>)Deleted;
                List<DataRow> rowsToRemove = new List<DataRow>();
                foreach (var record in deletedRecords)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row[KeyField].Equals(record[KeyField]))
                        {
                            rowsToRemove.Add(row);
                        }
                    }
                }

                // Remove the rows from the DataTable.
                foreach (DataRow rowToRemove in rowsToRemove)
                {
                    dataTable.Rows.Remove(rowToRemove);
                }
            }
            return dataTable;
        }
    }

    // Converts a DataTable to an IQueryable collection of ExpandoObjects.
    public static IQueryable ToQueryableCollection(DataTable DataTable)
    {
        List<ExpandoObject> expandoList = new List<ExpandoObject>();
        foreach (DataRow row in DataTable.Rows)
        {
            var expandoDict = new ExpandoObject() as IDictionary<String, Object>;
            foreach (DataColumn col in DataTable.Columns)
            {
                var colValue = row[col.ColumnName];
                colValue = (colValue == DBNull.Value) ? null : colValue;
                expandoDict.Add(col.ToString(), colValue);
            }
            expandoList.Add((ExpandoObject)expandoDict);
        }
        return expandoList.AsQueryable();
    }

    public DataTable GetData()
    {
        DataTable DataTable = new DataTable();
        DataTable.Columns.AddRange(new DataColumn[4] { 
            new DataColumn("OrderID", typeof(long)),
            new DataColumn("CustomerID", typeof(string)),
            new DataColumn("EmployeeID",typeof(int)),
            new DataColumn("OrderDate",typeof(DateTime))
        });

        int code = 1000;
        int id = 0;
        for (int i = 1; i <= 15; i++)
        {
            DataTable.Rows.Add(code + 1, "ALFKI", id + 1, new DateTime(1991, 05, 15));
            DataTable.Rows.Add(code + 2, "ANATR", id + 2, new DateTime(1990, 04, 04));
            DataTable.Rows.Add(code + 3, "ANTON", id + 3, new DateTime(1957, 11, 30));
            DataTable.Rows.Add(code + 4, "BLONP", id + 4, new DateTime(1930, 10, 22));
            DataTable.Rows.Add(code + 5, "BOLID", id + 5, new DateTime(1953, 02, 18));
            code += 5;
            id += 5;
        }
        return DataTable;
    }
}

{% endhighlight %}
{% endtabs %}

Please find the sample in this [GitHub location](https://github.com/SyncfusionExamples/databinding-in-blazor-datagrid/tree/master/DataTable).

## Managing spinner visibility during data loading

Showing a spinner during data loading in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid enhances the experience by providing a visual indication of the loading progress. This feature helps to understand that data is being fetched or processed.

To show or hide a spinner during data loading in the Grid, you can utilize the [ShowSpinnerAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ShowSpinnerAsync) and [HideSpinnerAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_HideSpinnerAsync) methods provided by the Grid.

The following example demonstrates how to show and hide the spinner during data loading using external buttons in a Grid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div Style="margin-bottom:15px">
    <SfButton CssClass="e-outline" OnClick="@(() => OnLoadData())" Content="Load Data"></SfButton>
    <SfButton CssClass="e-outline" Style="margin-left:5px" OnClick="@(() => ShowHideSpinner("showButton"))" Content="Show Spinner"></SfButton>
    <SfButton CssClass="e-outline" Style="margin-left:5px" OnClick="@(() => ShowHideSpinner("hideButton"))" Content="Hide Spinner"></SfButton>
</div>
<SfGrid @ref="Grid" TValue="OrderData" AllowPaging="true">
    <GridColumns>
        <GridColumn Field="@nameof(OrderData.OrderID)" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field="@nameof(OrderData.CustomerID)" HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field="@nameof(OrderData.ProductName)" HeaderText="Product Name" Width="110"></GridColumn>
        <GridColumn Field="@nameof(OrderData.Quantity)" HeaderText="Quantity" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    private async Task OnLoadData()
    {
        await Grid.ShowSpinnerAsync();
        Grid.DataSource = Orders;
        await Grid.HideSpinnerAsync();
    }

    // Method to show/hide the spinner based on button click.
    private async Task ShowHideSpinner(string buttonId)
    {
        if (buttonId == "showButton")
        {
            await Grid.ShowSpinnerAsync();
        }
        else if (buttonId == "hideButton")
        {
            await Grid.HideSpinnerAsync();
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData(int orderID, string customerID, string productName, int quantity)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.ProductName = productName;
        this.Quantity = quantity;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Random random = new Random();
            var customerIDs = new[] { "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD", "CHOPS", "RICSU", "WELLI", "HILAA", "ERNSH", "CENTC", "OTTIK", "QUEDE", "RATTC" };
            var productNames = new[] { "Apple", "Orange", "Banana", "Grapes", "Pineapple", "Peach", "Mango", "Strawberry", "Blueberry", "Watermelon" };

            for (int i = 1; i <= 20000; i++)
            {
                var orderID = i;
                var customerID = customerIDs[random.Next(customerIDs.Length)];
                var productName = productNames[random.Next(productNames.Length)];
                var quantity = random.Next(1, 100); // Random quantity between 1 and 100

                Orders.Add(new OrderData(orderID, customerID, productName, quantity));
            }
        }

        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LZVSXfVYgqFBPutf?appbar=true&editor=true&result=true&errorlist=true&theme=bootstrap5" %}

## Change datasource dynamically

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows to change the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) of the Grid  dynamically through an external button. This feature is useful to display different sets of data based on specific actions.

To implement this:

* Bind the Grid's `DataSource` property to a public list (e.g., Orders).

* Create a method that replaces this list with a new set of data.

* Trigger this method through a button or any other user interaction.

* The Grid automatically detects the data change and re-renders with the new content.

The following example demonstrates how to change the `DataSource` of the Grid dynamically:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfButton OnClick="ChangeDataSource">Change Data Source</SfButton>

<SfGrid @ref="grid" DataSource="@Orders" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="Syncfusion.Blazor.Grids.ColumnType.Date" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
  </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> grid;
    public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    private void ChangeDataSource()
    {
        // Replace the DataSource with a new list of records.
        Orders = OrderData.GetNewRecords();
    }
}

{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData() { }

    public OrderData(int orderID, string customerID, double freight, DateTime? orderDate)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.Freight = freight;
        this.OrderDate = orderDate;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", 32.38, new DateTime(1996, 7, 4)));
            Orders.Add(new OrderData(10249, "TOMSP", 11.61, new DateTime(1996, 7, 5)));
            Orders.Add(new OrderData(10250, "HANAR", 65.83, new DateTime(1996, 7, 6)));
            Orders.Add(new OrderData(10251, "VINET", 41.34, new DateTime(1996, 7, 7)));
            Orders.Add(new OrderData(10252, "SUPRD", 151.30, new DateTime(1996, 7, 8)));
            Orders.Add(new OrderData(10253, "HANAR", 58.17, new DateTime(1996, 7, 9)));
            Orders.Add(new OrderData(10254, "CHOPS", 22.98, new DateTime(1996, 7, 10))); 
        }
        return Orders;
    }

    public static List<OrderData> GetNewRecords()
    {
        return new List<OrderData>
        {
            new OrderData(20001, "ALFKI", 21.50, DateTime.Now.AddDays(-1)),
            new OrderData(20002, "ANATR", 42.75, DateTime.Now.AddDays(-2)),
            new OrderData(20003, "ANTON", 17.00, DateTime.Now.AddDays(-3)),
            new OrderData(20004, "BERGS", 65.20, DateTime.Now.AddDays(-4))
        };
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public DateTime? OrderDate { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDhIXeCHJywphWgL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Changing Datasource Dynamically in Blazor DataGrid](../images/blazor-datagrid-dynamic-datasource.gif)

## Data binding with SignalR 

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides support for real-time data binding using SignalR, allowing you to update the Grid automatically as data changes on the server-side. This feature is particularly useful for applications requiring live updates and synchronization across multiple clients.

To achieve real-time data binding with SignalR in your Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid, follow the steps below:

**Step 1:** Install the SignalR server package:

To add the SignalR server package to the app, open the NuGet Package Manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search for, and install the [Microsoft.AspNetCore.SignalR.Client](https://www.nuget.org/packages/Microsoft.AspNetCore.SignalR.Client) package.

**Step 2:** Create a **Hubs** folder and add the following **ChatHub** class (**Hubs/ChatHub.cs**):

```cs

using Microsoft.AspNetCore.SignalR;

namespace SignalRDataGrid.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage()
    {
        await Clients.All.SendAsync("ReceiveMessage");
    }
}

```

**Step 3:** Configure the SignalR server to route requests to the SignalR hub. In the **Program.cs** file, include the following code:

```cs

using SignalRDataGrid.Hubs;

var app = builder.Build();

app.UseRouting();
app.UseAntiforgery();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ChatHub>("/chathub");
    endpoints.MapFallbackToFile("/_Host");
});
app.Run();

```

**Step 4:** Create a simple Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid by following the [Getting Started](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-web-app) documentation link.

**Step 5:** Create a **Data** folder and add Data Controller (**OrderDetails.cs**) in your project to handle CRUD operations for the Grid: 

{% tabs %}
{% highlight cs tabtitle="OrderDetails.cs" %}

namespace SignalRDataGrid.Data
{
    public class OrderDetails
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipName { get; set; }

        public static List<OrderDetails> OrderList = new List<OrderDetails>();

        private static readonly string[] CustomerIDs = new[]
        {
        "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD", "CHOPS", "RICSU", "WELLI", "HILAA", "ERNSH", "CENTC", "OTTIK", "QUEDE", "RATTC"
        };

        private static readonly string[] ShipNames = new[]
        {
        "Vins et alcools Chevalier", "Toms Spezialitäten", "Hanari Carnes", "Victuailles en stock", "Suprêmes délices",
        "Chop-suey Chinese", "Richter Supermarkt", "Wellington Importadora", "HILARION-Abastos", "Ernst Handel",
        "Centro comercial Moctezuma", "Ottilies Käseladen", "Que Delícia", "Rattlesnake Canyon Grocery"
        };

        public static Task<List<OrderDetails>> GetOrdersAsync()
        {
            var rng = new Random();
            if (OrderList.Count == 0)
            {
                OrderList = Enumerable.Range(10248, 75).Select(index => new OrderDetails
                {
                    OrderID = index,
                    CustomerID = CustomerIDs[rng.Next(CustomerIDs.Length)],
                    ShipName = ShipNames[rng.Next(ShipNames.Length)]
                }).ToList();
            }

            return Task.FromResult(OrderList);
        }        
        public Task<OrderDetails> UpdateAsync(OrderDetails model)
        {
            var ord = OrderList.Where(x => x.OrderID == model.OrderID).FirstOrDefault();
            ord.CustomerID = model.CustomerID;
            ord.ShipName = model.ShipName;
            return Task.FromResult(model);
        }
        public List<OrderDetails> DeleteAsync(OrderDetails model)
        {
            var ord = OrderList.Remove(model);

            return OrderList;
        }
    }
}

{% endhighlight %}
{% endtabs %}

**Step 5:** In your **Home.razor** file, establish a connection to the SignalR hub and configure the Grid data.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.Grids
@using Microsoft.AspNetCore.SignalR.Client
@inject NavigationManager NavigationManager
@using SignalRDataGrid.Data
@inject OrderDetails OrderService
@implements IAsyncDisposable

<SfGrid @ref="Grid" DataSource="@OrderData" AllowSorting="true" AllowFiltering="true" ID="GridDemo" AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel", "Search" })">
    <GridEvents OnActionComplete="ActionComplete" TValue="OrderDetails"></GridEvents>
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipName) HeaderText=" Ship Name" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    SfGrid<OrderDetails> Grid { get; set; }
    private HubConnection hubConnection;
    public List<OrderDetails> OrderData = new List<OrderDetails>();
    protected override async Task OnInitializedAsync()
    {
        // Initialize SignalR connection.
        hubConnection = new HubConnectionBuilder()
        .WithUrl(NavigationManager.ToAbsoluteUri("/chathub"))
        .Build();

        // Set up a handler for receiving messages from the hub.
        hubConnection.On("ReceiveMessage", () =>
        {
            // Refresh grid on receiving a message.
            CallLoadData();
        });

        // Start SignalR connection.
        await hubConnection.StartAsync();
        await LoadData();
    }

    // Handles CRUD (Create, Read, Update, and Delete) operations.
    public async Task ActionComplete(ActionEventArgs<OrderDetails> Args)
    {
        if (Args.RequestType == Syncfusion.Blazor.Grids.Action.Save)
        {
            await OrderService.UpdateAsync(Args.Data);
            if (IsConnected) await Send();
        }
        if (Args.RequestType == Syncfusion.Blazor.Grids.Action.Delete)
        {
            OrderData = OrderService.DeleteAsync(Args.Data);
            if (IsConnected) await Send();
        }
    }
    private void CallLoadData()
    {
        Grid.Refresh();
    }
    protected async Task LoadData()
    {
        OrderData = await OrderDetails.GetOrdersAsync();
    }

    // Send a message to SignalR hub to notify other clients.
    async Task Send() =>
        await hubConnection.SendAsync("SendMessage");

        // Property to check SignalR connection state.
        public bool IsConnected => hubConnection.State == HubConnectionState.Connected;

        // Dispose the SignalR connection properly when component is disposed.
        public async ValueTask DisposeAsync()
        {
            if (hubConnection is not null)
            {
                await hubConnection.DisposeAsync();
            }
        }
}

{% endhighlight %}
{% endtabs %}

The above code demonstrates how to connect to a SignalR hub and refresh the Grid data in real time when updates are received.

**Step 6:** Adding the `OrderService` reference:

To include the `OrderService` reference, update the following line in your `Program.cs` file:

```csharp
builder.Services.AddSingleton<OrderDetails>();
```

The following screenshot illustrates the addition, editing, and deletion operations performed, with changes reflected across all client sides.

![SignalR Data](../images/signalR.gif)

Please find the sample in this [GitHub location](https://github.com/SyncfusionExamples/databinding-in-blazor-datagrid/tree/master/SignalRDataGrid).

## Binding data from Excel document

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows you to import data from Excel documents into your web application for display and manipulation within the Grid. This feature streamlines the process of transferring Excel data to a web-based environment. You can achieve this by using the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_ValueChange) event of the `SfFileUploader`.

To import Excel data into Grid, you can follow these steps:

1. Use the [SfFileUploader](https://blazor.syncfusion.com/documentation/file-upload/getting-started-with-web-app) to upload the Excel document.

2. Parse the file using the [Syncfusion.XlsIO](https://www.nuget.org/packages/Syncfusion.XlsIO.Net.Core/) library.

3. Convert the parsed data into a list of `ExpandoObject`.

4. Bind the list to the Grid.

The following example demonstrates how an Excel document is uploaded, parsed, converted into a list of `ExpandoObject`, and then bound to the Grid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.XlsIO;
@using System.IO;
@using Syncfusion.Blazor.Grids;
@using Syncfusion.Blazor.Inputs;
@using System.Data;
@using System.Dynamic;
@using Microsoft.AspNetCore.Hosting;
@using Syncfusion.Blazor.Popups

<label style="padding:20px 0px 20px 0px;font-weight: bold">Browse excel file to load and return Grid</label>
<div id="target">
    <SfUploader>
        <UploaderEvents OnRemove="OnRemove" ValueChange="OnChange"></UploaderEvents>
    </SfUploader>
</div>
@if (CustomerList != null && CustomerList.Count > 0)
{
    <SfGrid @ref="Grid" DataSource="@CustomerList" AllowPaging="true" Height="340px">
    </SfGrid>
}
<SfDialog @ref="dialog" ID="dialog" Target="#target" Visible="false" ShowCloseIcon="true" Header="Alert">
</SfDialog>

<style>
    #target {
        position: relative;
    }
    .dialog {
        max-height: 107px;
    }
</style>

@code {
    SfGrid<ExpandoObject> Grid;
    SfDialog dialog;
    public DataTable table = new DataTable();
    [Inject] private IWebHostEnvironment HostEnvironment { get; set; }

    private async void OnChange(UploadChangeEventArgs args)
    {
        if (args.Files[0].FileInfo.Type == "xlsx")
        {
            foreach (var file in args.Files)
            {
                var path = GetPath(file.FileInfo.Name);
                ExcelEngine excelEngine = new ExcelEngine();
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2016;

                // Create new file stream at the generated path.
                FileStream openFileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                await file.File.OpenReadStream(long.MaxValue).CopyToAsync(openFileStream);
                openFileStream.Close();

                // Open file stream from saved path.
                FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                IWorkbook workbook = application.Workbooks.Open(fileStream);
                IWorksheet worksheet = workbook.Worksheets[0];
                table = worksheet.ExportDataTable(worksheet.UsedRange, ExcelExportDataTableOptions.ColumnNames);
                GenerateListFromTable(table);
            }

        }
        else
        {
            dialog.Content = "Please upload only .xlsx format";
            dialog.ShowAsync(true);
        }
    }

    private async Task OnRemove(RemovingEventArgs args)
    {
        CustomerList = new List<ExpandoObject>();  // Clear data.
        Columns = null;
    }

    private string GetPath(string filename)
    {
        return Path.Combine(HostEnvironment.WebRootPath, filename);
    }

    string[] Columns;
    public List<ExpandoObject> CustomerList = new List<ExpandoObject>();

    public void GenerateListFromTable(DataTable input)
    {
        // Check if at least one cell has meaningful data.
        bool hasData = input.Rows.Cast<DataRow>()
            .Any(row => row.ItemArray.Any(cell => cell != null && !string.IsNullOrWhiteSpace(cell.ToString())));

        if (!hasData)
        {
            dialog.Content = "The uploaded Excel file contains only blank rows or invalid data.";
            dialog.ShowAsync();
            return; // Exit if the data is invalid.
        }

        var list = new List<ExpandoObject>();
        Columns = input.Columns.Cast<DataColumn>()
                             .Select(x => x.ColumnName)
                             .ToArray();
        foreach (DataRow row in input.Rows)
        {
            System.Dynamic.ExpandoObject e = new System.Dynamic.ExpandoObject();
            foreach (DataColumn col in input.Columns)
                e.TryAdd(col.ColumnName, row.ItemArray[col.Ordinal]);
            list.Add(e);
        }
        CustomerList = list;
        StateHasChanged();
    }
}

{% endhighlight %}
{% endtabs %}

[!Binding data from Excel document](./images/excel-import-data.gif)

> You can find the complete sample on [GitHub](https://github.com/SyncfusionExamples/databinding-in-blazor-datagrid/tree/master/Binding_data_from_excel/Excel_Export).

## Observable collection

An Observable collection is a special type of collection in .NET that automatically notifies any subscribers (such as the UI or other components) when changes are made to the collection. This is particularly useful in data-binding scenarios, where you want the UI to reflect changes in the underlying data model without having to manually update the view.

To achieve this, you can use the [ObservableCollection](https://learn.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.observablecollection-1?view=netframework-4.8), a dynamic data collection that:

   * Provides notifications when items are added, removed, or moved.

   * Implements the [INotifyCollectionChanged](https://learn.microsoft.com/en-us/dotnet/api/system.collections.specialized.inotifycollectionchanged?view=netframework-4.8) interface to notify subscribers about changes such as adding, removing, moving, or clearing items in the collection.

   * Implements the [INotifyPropertyChanged](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=netframework-4.8) interface to notify when a property value changes on the client side.

The following sample demonstrates how the Order class implements the **INotifyPropertyChanged** interface and raises the event when the `CustomerID`property value is changed.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
@using System.Collections.ObjectModel
@using Observable_Collection.Components.Data;

<div Style="margin-bottom:15px">
    <SfButton CssClass="e-outline" OnClick="@(() => AddRecords())" Content="Add Data"></SfButton>
    <SfButton CssClass="e-outline" Style="margin-left:5px" OnClick="@(() => DelRecords())" Content="Delete Data"></SfButton>
    <SfButton CssClass="e-outline" Style="margin-left:5px" OnClick="@(() => UpdateRecords())" Content="Update Data"></SfButton>
</div>

<SfGrid DataSource="@GridData" AllowReordering="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrdersDetailsObserveData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="@TextAlign.Center" HeaderTextAlign="@TextAlign.Center" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetailsObserveData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetailsObserveData.Freight) HeaderText="Freight" EditType="EditType.NumericEdit" Format="C2" Width="140" TextAlign="@TextAlign.Right" HeaderTextAlign="@TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetailsObserveData.OrderDate) HeaderText="Order Date" EditType="EditType.DatePickerEdit" Format="d" Type="ColumnType.Date" Width="160"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetailsObserveData.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>


@code {

    public ObservableCollection<OrdersDetailsObserveData> GridData { get; set; }
    public int Count = 32341;

    protected override void OnInitialized()
    {
        GridData = OrdersDetailsObserveData.GetRecords();
    }

    public void AddRecords()
    {
        GridData.Add(new OrdersDetailsObserveData(Count++, "ALFKI", 4343, 2.3 * 43, false, new DateTime(1991, 05, 15), "Berlin", "Simons bistro", "Denmark", new DateTime(1996, 7, 16), "Kirchgasse 6"));
    }

    public void DelRecords()
    {
        GridData.Remove(GridData.First());
    }

    public void UpdateRecords()
    {
        var a = GridData.First();
        a.CustomerID = "Update";
    }
}

{% endhighlight %}

{% highlight cs tabtitle="OrdersDetailsObserveData.cs" %}

using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Observable_Collection.Components.Data
{
    public class OrdersDetailsObserveData : INotifyPropertyChanged
    {
        public OrdersDetailsObserveData()
        {
        }
        public OrdersDetailsObserveData(int OrderID, string CustomerId, int EmployeeId, double Freight, bool Verified, DateTime OrderDate, string ShipCity, string ShipName, string ShipCountry, DateTime ShippedDate, string ShipAddress)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerId;
            this.EmployeeID = EmployeeId;
            this.Freight = Freight;
            this.ShipCity = ShipCity;
            this.Verified = Verified;
            this.OrderDate = OrderDate;
            this.ShipName = ShipName;
            this.ShipCountry = ShipCountry;
            this.ShippedDate = ShippedDate;
            this.ShipAddress = ShipAddress;
        }
        public static ObservableCollection<OrdersDetailsObserveData> GetRecords()
        {
            ObservableCollection<OrdersDetailsObserveData> order = new ObservableCollection<OrdersDetailsObserveData>();
            int code = 10000;
            for (int i = 1; i < 2; i++)
            {
                order.Add(new OrdersDetailsObserveData(code + 1, "ALFKI", i + 0, 2.3 * i, false, new DateTime(1991, 05, 15), "Berlin", "Simons bistro", "Denmark", new DateTime(1996, 7, 16), "Kirchgasse 6"));
                order.Add(new OrdersDetailsObserveData(code + 2, "ANATR", i + 2, 3.3 * i, true, new DateTime(1990, 04, 04), "Madrid", "Queen Cozinha", "Brazil", new DateTime(1996, 9, 11), "Avda. Azteca 123"));
                order.Add(new OrdersDetailsObserveData(code + 3, "ANTON", i + 1, 4.3 * i, true, new DateTime(1957, 11, 30), "Cholchester", "Frankenversand", "Germany", new DateTime(1996, 10, 7), "Carrera 52 con Ave. Bol�var #65-98 Llano Largo"));
                order.Add(new OrdersDetailsObserveData(code + 4, "BLONP", i + 3, 5.3 * i, false, new DateTime(1930, 10, 22), "Marseille", "Ernst Handel", "Austria", new DateTime(1996, 12, 30), "Magazinweg 7"));
                order.Add(new OrdersDetailsObserveData(code + 5, "BOLID", i + 4, 6.3 * i, true, new DateTime(1953, 02, 18), "Tsawassen", "Hanari Carnes", "Switzerland", new DateTime(1997, 12, 3), "1029 - 12th Ave. S."));
                code += 5;
            }
            return order;
        }

        public int OrderID { get; set; }
        public string CustomerID
        {
            get { return customerID; }
            set
            {
                customerID = value;
                NotifyPropertyChanged("CustomerID");
            }
        }
        public string customerID { get; set; }
        public int? EmployeeID { get; set; }
        public double? Freight { get; set; }
        public string ShipCity { get; set; }
        public bool Verified { get; set; }
        public DateTime? OrderDate { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public string ShipName { get; set; }

        public string ShipCountry { get; set; }

        public DateTime ShippedDate { get; set; }
        public string ShipAddress { get; set; }

        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

{% endhighlight %}
{% endtabs %}

The following screenshot represents the Grid with **Observable Collection**.

![Blazor DataGrid with ObservableCollection](./images/blazor-datagrid-observable.gif)

> You can find the complete sample on [GitHub](https://github.com/SyncfusionExamples/databinding-in-blazor-datagrid/tree/master/observable_collection/Observable_Collection).

N> While using an Observable collection, the added, removed, and changed records are reflected in the UI. But while updating the Observable collection using external actions like timers, events, and other notifications, you need to call the StateHasChanged method to reflect the changes in the UI.

### Add a range of items into ObservableCollection in Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports binding to an ObservableCollection, which allows the Grid to automatically reflect changes made to the data source. This approach is particularly useful when you need to add a large batch of records to the Grid at once, such as:

  * Loading or importing a large dataset dynamically.

  * Appending multiple items retrieved from an API or database.

  * Performing bulk updates or data synchronization operations.

  * Avoiding UI lag and flickering caused by multiple individual item additions.

  * Ensuring smoother and more efficient data rendering in scenarios with high-frequency data changes.


By default, the `Add` method is used to insert a single item into the **ObservableCollection**. When multiple items are added one by one using a `foreach` loop, the Grid refreshes after each addition. This can lead to performance issues and UI flickering, especially when adding a large number of items.

To optimize performance when adding multiple items at once, you can extend the `ObservableCollection<T>` class by implementing an `AddRange` method. By using this method, you can add a range of items and ensure that the `OnCollectionChanged` event is triggered only once, updating the Grid a single time for the entire batch operation.

To implement this functionality, follow these steps:

1. **Create a Custom Collection Class**

    Define a new class **SmartObservableCollection<T>** that inherits from `ObservableCollection<T>`. This allows you to customize the behavior of the collection.

2. **Add a flag to control notifications**

    Introduce a private boolean **flag _preventNotification** to temporarily disable collection change notifications while adding multiple items.

3. **Override the OnCollectionChanged method**

    Override this method to check the **_preventNotification** flag. When the flag is set to **true**, skip raising the notification to avoid multiple UI refreshes.

4. **Implement the AddRange method**

    This method enables adding multiple items efficiently by:

      * Setting **_preventNotification** to **true** to suppress notifications.
      * Adding each item from the input list to the collection using the `Add` method within a `foreach` loop.
      * Resetting **_preventNotification** to **false**.
      * Raising a single **NotifyCollectionChangedAction.Reset** notification to inform the Grid that the entire collection has changed.

The following example demonstrates how to use this approach in a Grid:  

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
@using System.Collections.ObjectModel
@using System.Collections.Specialized
@using ObservableCollection.Components.Data;

<div style="padding-bottom:20px">
    <SfButton OnClick="AddRangeItems">Add Range of Items</SfButton>
</div>
<SfGrid @ref="Grid" DataSource="@GridData" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrdersDetailsObserveData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetailsObserveData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetailsObserveData.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetailsObserveData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    SfGrid<OrdersDetailsObserveData> Grid;
    public SmartObservableCollection<OrdersDetailsObserveData> GridData = new SmartObservableCollection<OrdersDetailsObserveData>();
    public void AddRangeItems()
    {
        GridData.AddRange(OrdersDetailsObserveData.GetAllRecords());
    }

    public class SmartObservableCollection<T> : ObservableCollection<T>
    {
        private bool _preventNotification = false;
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (!_preventNotification)
                base.OnCollectionChanged(e);
        }
        public void AddRange(IEnumerable<T> list)
        {
            _preventNotification = true;
            foreach (T item in list)
                Add(item);
            _preventNotification = false;
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}

{% endhighlight %}

{% highlight cs tabtitle="OrdersDetailsObserveData.cs" %}

namespace ObservableCollection.Components.Data
{
    public class OrdersDetailsObserveData
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }

        public static IEnumerable<OrdersDetailsObserveData> GetAllRecords()
        {
            return Enumerable.Range(1, 10).Select(x => new OrdersDetailsObserveData
            {
                OrderID = 1000 + x,
                CustomerID = (new[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
                Freight = Math.Round(2.1 * x, 2),
                OrderDate = DateTime.Now.AddDays(-x)
            }).ToList();
        }
    }
}

{% endhighlight %}
{% endtabs %}

The following screenshot represents the Grid with **Observable Collection**.

![Blazor DataGrid with ObservableCollection](./images/Observable-collection-range.gif)

> You can find the complete sample on [GitHub](https://github.com/SyncfusionExamples/databinding-in-blazor-datagrid/tree/master/add_range_items_observableCollection/ObservableCollection).

## See also

* [How to import data from Excel sheet and bind to Blazor Grid](https://support.syncfusion.com/kb/article/11560/how-to-import-data-from-excel-sheet-and-bind-to-blazor-grid)
* [How to clear all Data from Grid](https://www.syncfusion.com/forums/150965/how-to-clear-all-data-from-grid)
