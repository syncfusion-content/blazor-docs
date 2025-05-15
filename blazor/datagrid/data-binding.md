---
layout: post
title: Data Binding in Blazor DataGrid | Syncfusion
description: Checkout and learn here all about Data Binding in Syncfusion Blazor DataGrid and much more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Data Binding in Blazor DataGrid

Data binding is a fundamental technique that empowers the Syncfusion Blazor DataGrid to integrate data into its interface, enabling the creation of dynamic and interactive Grid views. This feature is particularly valuable when working with large datasets or when data needs to be fetched remotely. 

The Syncfusion Blazor DataGrid utilizes the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html), which supports both RESTful JSON data service binding and IEnumerable binding. The key property, [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource), can be assigned to a `SfDataManager` instance or list of business objects.

It supports two kinds of data binding methods:

* Local data
* Remote data

> When using [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) as `IEnumerable<T>`, the component type (TValue) will be inferred from its value. When using [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) for data binding, the **TValue** must be provided explicitly in the Grid.

## List binding

The Syncfusion Blazor DataGrid supports binding data from a list of objects (e.g., a List&lt;T&gt; or IEnumerable&lt;T&gt; collection). This is the most common approach when working with in-memory data in Blazor applications.

List binding allows the Grid to render and manage a collection of data directly in memory without requiring a remote service or external data manager unless needed. This is ideal for local CRUD operations, small datasets, or preloaded data.

**List binding can be enabled in the following scenarios:**

You can bind a list of data to the Syncfusion Blazor DataGrid using the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) property. The list can be:

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

The Syncfusion Blazor DataGrid is a strongly-typed generic component typically bound to a specific model at compile time. However, there are scenarios, especially in dynamic or metadata-driven applications, where the structure of the data is not known until runtime. In such cases, you can bind the Grid to a collection of [ExpandoObject](https://learn.microsoft.com/en-us/dotnet/api/system.dynamic.expandoobject?view=net-9.0) instances for a fully dynamic Grid structure.

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

### ExpandoObject complex data binding

When working with complex or nested data structures using [ExpandoObject](https://learn.microsoft.com/en-us/dotnet/api/system.dynamic.expandoobject?view=net-9.0), the Syncfusion Blazor DataGrid allows you to bind these nested fields using dot (.) notation. This is especially helpful when your **ExpandoObject** contains sub-objects or hierarchical data, and you want to present specific properties of those nested objects in individual Grid columns.

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

### DynamicObject binding

The Syncfusion Blazor DataGrid is designed to work with strongly-typed models. However, in scenarios where the model structure is not known at compile time, such as metadata-driven Grids or dynamic data sources, you can bind the Grid to a list of objects derived from [DynamicObject](https://learn.microsoft.com/en-us/dotnet/api/system.dynamic.dynamicobject).

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

### DynamicObject complex data binding

When working with complex or nested data structures using [DynamicObject](https://learn.microsoft.com/en-us/dotnet/api/system.dynamic.dynamicobject), the Syncfusion Blazor DataGrid allows you to bind these nested fields using dot (.) notation. This is especially helpful when your **DynamicObject** contains sub-objects or hierarchical data, and you want to present specific properties of those nested objects in individual Grid columns.

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

> When binding the Grid DataSource dynamically as a list of IEnumerable collections, you need to call the [Refresh](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Refresh_System_Boolean_) method of the Grid to reflect the changes externally. This is because tracking changes made externally to IEnumerable items is avoided for performance considerations.

### DataTable binding

The Syncfusion Blazor DataGrid supports binding data from a `System.Data.DataTable` using a custom adaptor, enabling dynamic generation of rows and columns based on backend data. This approach is particularly useful for scenarios where data is retrieved or processed in a DataTable format, and it provides full support for built-in data operations like paging, filtering, sorting, and searching. 

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

The Syncfusion Blazor DataGrid supports dynamic **grouping** and **aggregates** even when bound to a `DataTable` via a custom adaptor. This allows you to group rows by one or more columns and apply aggregate functions (such as **Sum**, **Average**, **Count**, etc.) on those groups or entire datasets.

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

The Syncfusion Blazor DataGrid supports CRUD (Create, Read, Update, and Delete) operations with a DataTable using a custom adaptor. You can enable editing in the Grid and override specific methods of the [DataAdaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html) base class to update your `DataTable` in memory.

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

## Remote data

To bind remote data to datagrid component, assign service data as an instance of [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) property or by using [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component. To interact with remote data source, provide the endpoint **Url**.

N> When using [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) for data binding then the **TValue** must be provided explicitly in the datagrid component.
<br/> By default, [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) uses **ODataAdaptor** for remote data-binding.

### Binding with OData services

[OData](https://www.odata.org/documentation/odata-version-3-0/) is a standardized protocol for creating and consuming data. You can retrieve data from OData service using the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html). Refer to the following code example for remote Data binding using **OData** service.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfGrid TValue="Order" AllowPaging="true">
    <SfDataManager Url="https://services.odata.org/Northwind/Northwind.svc/Orders" Adaptor="Adaptors.ODataAdaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public class Order {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCountry { get; set; }
    }
}
```

### Binding with OData v4 services

The ODataV4 is an improved version of OData protocols, and the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) can also retrieve and consume OData v4 services. For more details on OData v4 services, refer to the [OData documentation](https://docs.oasis-open.org/odata/odata/v4.0/errata03/os/complete/part1-protocol/odata-v4.0-errata03-os-part1-protocol-complete.html#_Toc453752197). To bind OData v4 service, use the **ODataV4Adaptor**.

To know about how to bind ODatav4 services in Blazor DataGrid Component, you can check this video.

{% youtube "youtube:https://www.youtube.com/watch?v=MrpjneRHSeA"%}

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfGrid TValue="Order" AllowPaging="true">
    <SfDataManager Url="https://services.odata.org/V4/Northwind/Northwind.svc/Orders/" Adaptor="Adaptors.ODataV4Adaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public class Order {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}

```

### Web API

You can use **WebApiAdaptor** to bind datagrid with Web API created using **OData** endpoint.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfGrid TValue="Order" AllowPaging="true">
    <SfDataManager Url="https://blazor.syncfusion.com/services/production/api/Orders/" Adaptor="Adaptors.WebApiAdaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public class Order {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}

```

The response object from the Web API should contain properties, **Items** and **Count**, whose values are a collection of entities and total count of the entities, respectively.

The sample response object should look like this:

```javascript
{
    Items: [{..}, {..}, {..}, ...],
    Count: 830
}
```

N> The data source is returned in the form of items and count pairs while using the WebAPI Adaptor. But when the [Offline](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Offline) property of [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) is enabled, the entire data source is returned from the server as a collection of objects. So, the `$inlinecount` will not be present when the `Offline` property is enabled. Also, only one request will be made to fetch the entire details from the server and no further request will be sent to the server.

### Enable SfDataManager after initial rendering

It is possible to render the datasource in DataGrid after initial rendering. This can be achieved by conditionally enabling the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component after datagrid rendering.

The following sample code demonstrates enabling data manager condition in the DataGrid on button click,

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfButton OnClick="Enable" CssClass="e-primary" IsPrimary="true" Content="Enable data manager"></SfButton>
<SfGrid TValue="Order" AllowPaging="true">
    <GridPageSettings PageSize="10"></GridPageSettings>
    @if(IsInitialRender)
    {
        <SfDataManager Url="https://blazor.syncfusion.com/services/production/api/Orders/" Adaptor="Adaptors.WebApiAdaptor"></SfDataManager>
    }
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public bool IsInitialRender = false;

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }

    public void Enable()
    {
        // Enabling condition to render the data manager
        this.IsInitialRender = true;
    }
}
```

The following GIF represents dynamically rendering data manager in DataGrid,

![Dynamically Rendering Data Manager in Blazor DataGrid](./images/blazor-datagrid-dynamic-render-data-manager.gif)

### Sending additional parameters to the server

To add a custom parameter to the data request, use the addParams method of Query class. Assign the Query object with additional parameters to the datagrid's [Query](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.Query.html) property.

The following sample code demonstrates sending additional parameters using the Query property,

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfGrid TValue="Order" AllowPaging="true" Query=@GridQuery>
    <GridPageSettings PageSize="10"></GridPageSettings>
    <SfDataManager Url="https://blazor.syncfusion.com/services/production/api/Orders/" Adaptor="Adaptors.WebApiAdaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public string ParamValue = "true";
    public Query GridQuery { get; set; }

    protected override void OnInitialized() {
        GridQuery = new Query().AddParams("ej2grid", ParamValue);
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

### Configuring HttpClient

**SfDataManager** uses the **HttpClient** instance to make HTTP requests to data services. **SfDataManager** checks whether a **HttpClient** is already registered in the service container. If it's found, the SfDataManager will use HttpClient from the service container else it will create and add HttpClient to the service container and use that instance for making requests to the server.

When registering your HttpClient, the registration should be done before calling `AddSyncfusionBlazor()` method in **Program.cs**, so that **SfDataManager** will not create its own HttpClient and uses the pre-configured HttpClient. This helps SfDataManager to use HttpClient instance pre-configured with base address, authentication, default headers, etc.

You could also pass HttpClient to the SfDataManager component as a parameter using `HttpClientInstance` property. This will be useful when the application has more than one pre-configured HttpClients. You can use this approach to use the named HttpClient with SfDataManager.

To troubleshoot the requests and responses made using HttpClient, a custom HTTP message handler can be used. More information about registering the custom HTTP message handler can be found [here](https://learn.microsoft.com/en-us/aspnet/web-api/overview/advanced/httpclient-message-handlers).

N> Using Typed HttpClient with SfDataManager is not supported. The [custom binding](./custom-binding) feature has to be used to achieve this requirement.

### Handling HTTP error

During server interaction from the datagrid, sometimes server-side exceptions might occur. These error messages or exception details can be acquired in client-side using the [OnActionFailure](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnActionFailure) event.

The argument passed to the [OnActionFailure](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnActionFailure) event contains the error details returned from the server.

The following sample code demonstrates notifying user when server-side exception has occurred,

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<span class="error">@ErrorDetails</span>
<SfGrid TValue="Order" AllowPaging="true">
    <GridEvents TValue="Order" OnActionFailure="@ActionFailure"></GridEvents>
    <GridPageSettings PageSize="10"></GridPageSettings>
    <SfDataManager Url="https://some.com/invalidUrl" Adaptor="Adaptors.WebApiAdaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
    .error {
        color: red;
    }
</style>

@code{
    public string ErrorDetails = "";
    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }

    public void ActionFailure(FailureEventArgs args)
    {
        this.ErrorDetails = "Server exception: 404 Not found";
        StateHasChanged();
    }
}
```


### Authorization and Authentication

It is common to have authorization in the server of origin to prevent anonymous access to the data services. **SfDataManager** can consume data from such protected remote data services with the proper bearer token. The access token or bearer token can be used by **SfDataManager** in one of the following ways.

* By using the pre-configured HttpClient with the access token or authentication message handler, SfDataManager can access protected remote services. When registering your HttpClient, the registration should be done before calling `AddSyncfusionBlazor()` method in **Program.cs**, so that SfDataManager will not create its own HttpClient and uses the already configured HttpClient.
* Setting access token in the default header of the HttpClient by injecting it in the page. See here for adding default headers to HttpClient.

```csharp

@inject HttpClient _httpClient

. . . .

@code {

    . . .

    protected override async Task OnInitializedAsync()
    {
        . . . .
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {tokenValue}");

        await base.OnInitializedAsync();
    }
}
```

* Setting the access token in the **Headers** property of the **SfDataManager**. See [here](#setting-custom-headers) for adding headers.

Getting the bearer token may vary with access token providers. More information on configuring HttpClient with authentication can be found on the official page [here](https://learn.microsoft.com/en-us/aspnet/core/blazor/security/webassembly/additional-scenarios?view=aspnetcore-8.0).

### Setting custom headers

To add a custom headers to the data request, use the [Headers](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Headers) property of the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html).

The following sample code demonstrates adding custom headers to the `SfDataManager` request,

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfGrid TValue="Order" AllowPaging="true">
    <GridPageSettings PageSize="10"></GridPageSettings>
    <SfDataManager Headers=@HeaderData Url="https://blazor.syncfusion.com/services/production/api/Orders/" Adaptor="Adaptors.WebApiAdaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private IDictionary<string, string> HeaderData = new Dictionary<string, string>();

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

### Change Query parameter value dynamically

It is possible to dynamically modify datagrid's [Query](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.Query.html) property value.

The following sample code demonstrates achieving this,

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfButton Content="Modify query data" OnClick="BtnClick"></SfButton>
<SfGrid TValue="Order" @ref="GridObj" AllowPaging="true" Query="@QueryData">
    <GridPageSettings PageSize="10"></GridPageSettings>
    <SfDataManager Url="https://services.odata.org/V4/Northwind/Northwind.svc/Orders" Adaptor="Adaptors.ODataV4Adaptor">
    </SfDataManager>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public SfGrid<Order> GridObj;
    private Query QueryData = new Query().Where("CustomerID", "equal", "VINET");
    private Query UpdatedQueryData = new Query().Where("CustomerID", "equal", "HANAR");

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public double? Freight { get; set; }
    }
    public void BtnClick()
    {
        QueryData = UpdatedQueryData;
    }
}
```

The following GIF represents dynamically modifying the query property in DataGrid,

![Changing Query Dynamically in Blazor DataGrid](./images/blazor-datagrid-query-update.gif)

## GraphQL service binding

GraphQL is a query language for APIs with which you can get exactly what you need and nothing more. The GraphQLAdaptor provides an option to retrieve data from the GraphQL server. You can also perform CRUD and data operations like paging, sorting, filtering etc by sending the required arguments to the server.

### Fetching data from GraphQL service and binding to grid

To bind GraphQL service data to grid, you have to provide the GraphQL query string by using the [Query](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLAdaptorOptions.html#Syncfusion_Blazor_Data_GraphQLAdaptorOptions_Query) property of the [GraphQLAdaptorOptions](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLAdaptorOptions.html). Also you need to set the [ResolverName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLAdaptorOptions.html#Syncfusion_Blazor_Data_GraphQLAdaptorOptions_ResolverName) property of [GraphQLAdaptorOptions](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLAdaptorOptions.html) to map the response. The GraphQLAdaptor expects response as a JSON object with properties of Result, Count and Aggregates which contains the collection of entities, total number of records and value of aggregates respectively. The GraphQL response should be returned in JSON format like { “data”: { … }} with query name as field.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfGrid TValue="Order" AllowPaging=true AllowSorting=true AllowFiltering=true>
    <SfDataManager Url="https://xxxxxx" GraphQLAdaptorOptions=@adaptorOptions Adaptor="Adaptors.GraphQLAdaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey=true TextAlign="TextAlign.Right" Width="120"><GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" TextAlign="TextAlign.Right"
        Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private GraphQLAdaptorOptions adaptorOptions { get; set; } = new GraphQLAdaptorOptions
    {
        Query = @"
            query ordersData($dataManager: DataManagerRequestInput!){
                ordersData(dataManager: $dataManager) {
                    count, result { OrderID, CustomerID, OrderDate, Freight } , aggregates
                }
            }",
        ResolverName = "OrdersData"
    };

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

### Performing data operations

The following code demonstrates the resolver function used in the GraphQL server to bind data and to perform data operations like paging, sorting, filtering etc.

```cshtml
    public class GraphQLQuery
    {
        public ReturnType<Order> OrdersData(DataManagerRequest dataManager)
        {
            IEnumerable<Order> result = Orders;
            if (dataManager.Search != null)
            {
                result = DataOperations.PerformSearching(result, dataManager.Search);
            }
            if (dataManager.Sorted != null)
            {
                result = DataOperations.PerformSorting(result, dataManager.Sorted);
            }
            if (dataManager.Where != null)
            {
                result = DataOperations.PerformFiltering<Order>(result.AsQueryable(), dataManager.Where, dataManager.Where[0].Condition).ToList();
            }
            int count = result.Count();
            if (dataManager.Skip != 0)
            {
                result = DataOperations.PerformSkip(result, dataManager.Skip);
            }
            if (dataManager.Take != 0)
            {
                result = DataOperations.PerformTake(result, dataManager.Take);
            }
            if (dataManager.Aggregates != null)
            {
                IDictionary<string, object> aggregates = DataUtil.PerformAggregation(result, dataManager.Aggregates);
                return new ReturnType<Order>() { Count = count, Result = result, Aggregates = aggregates };
            }
            return dataManager.RequiresCounts ? new ReturnType<Order>() { Result = result, Count = count } : new ReturnType<Order>() { Result = result };
        }

        public static List<Order> Orders { get; set; } = GetOrdersList();

        private static List<Order> GetOrdersList()
        {
            var data = new List<Order>();
            int count = 1000;
            int employeeCount = 0;
            for (int i = 0; i < 10; i++)
            {
                data.Add(new Order() { OrderID = count + 1, EmployeeID = employeeCount + 1,  CustomerID = "ALFKI", OrderDate = new DateTime(2023, 08, 23), Freight = 5.7 * 2, Address = new CustomerAddress() { ShipCity = "Berlin", ShipCountry = "Denmark" }  });
                data.Add(new Order() { OrderID = count + 2, EmployeeID = employeeCount + 2, CustomerID = "ANANTR", OrderDate = new DateTime(1994, 08, 24), Freight = 6.7 * 2, Address = new CustomerAddress() { ShipCity = "Madrid", ShipCountry = "Brazil" } });
                data.Add(new Order() { OrderID = count + 3, EmployeeID = employeeCount + 3, CustomerID = "BLONP", OrderDate = new DateTime(1993, 08, 25), Freight = 7.7 * 2, Address = new CustomerAddress() { ShipCity = "Cholchester", ShipCountry = "Germany" } });
                data.Add(new Order() { OrderID = count + 4, EmployeeID = employeeCount + 4, CustomerID = "ANTON", OrderDate = new DateTime(1992, 08, 26), Freight = 8.7 * 2, Address = new CustomerAddress() { ShipCity = "Marseille", ShipCountry = "Austria" } });
                data.Add(new Order() { OrderID = count + 5, EmployeeID = employeeCount + 5, CustomerID = "BOLID", OrderDate = new DateTime(1991, 08, 27), Freight = 9.7 * 2, Address = new CustomerAddress() { ShipCity = "Tsawassen", ShipCountry = "Switzerland" } });
                count += 5;
                employeeCount += 5;
            }
            return data;
        }
    }

    public class ReturnType<T>
    {
        public int Count { get; set; }

        public IEnumerable<T> Result { get; set; }

        [GraphQLType(typeof(AnyType))]
        public IDictionary<string, object> Aggregates { get; set; }
    }

```

#### Note

The implementation for PerformSearching, PerformSorting, PerformFiltering, PerformSkip, PerformTake, PerformAggregation methods can be found in the [github sample](https://github.com/SyncfusionExamples/GraphQLAdaptor-Binding-Blazor-DataGrid).

### Performing CRUD operation using mutation

You can perform the CRUD operations by setting the mutation queries in the [Mutation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLAdaptorOptions.html#Syncfusion_Blazor_Data_GraphQLAdaptorOptions_Mutation) property of [GraphQLAdaptorOptions](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLAdaptorOptions.html).

#### Normal editing and Dialog editing

The following sample code demonstrates performing CRUD operation by using [Normal](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.EditMode.html#Syncfusion_Blazor_Grids_EditMode_Normal) editing in grid. You have to set the Insert mutation query in [Insert](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLMutation.html#Syncfusion_Blazor_Data_GraphQLMutation_Insert) property of Mutation in `GraphQLAdaptorOptions`. Similarly, you have to set the Update and Delete mutation queries in [Update](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLMutation.html#Syncfusion_Blazor_Data_GraphQLMutation_Update) and [Delete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLMutation.html#Syncfusion_Blazor_Data_GraphQLMutation_Delete) properties of Mutation in `GraphQLAdaptorOptions` respectively.

If you want to use Dialog editing, then you can set the [EditSettings.Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Mode) as **Dialog**.

The following variables are passed as a parameter to the mutation method written for **Insert** operation in server side.

| Properties | Description |
|--------|----------------|
| record | The new record which is need to be inserted. |
| index | Specifies the index at which the newly added record will be inserted.  |
| action | Indicates the type of operation being performed. When the same method is used for all CRUD actions, this argument serves to distinguish the action, such as **Add, Delete and Update**  |
| additionalParameters | An optional parameter that can be used to perform any operations.   |

The following variables are passed as a parameter to the mutation method written for **Update** operation in server side.

| Properties | Description |
|--------|----------------|
| record | The new record which is need to be updated. |
| action | Indicates the type of operation being performed. When the same method is used for all CRUD actions, this argument serves to distinguish the action, such as **Add, Delete and Update**  |
| primaryColumnName | Specifies the field name of the primary column. |
| primaryColumnValue | Specifies the primary column value which is needs to be updated in the collection.   |
| additionalParameters | An optional parameter that can be used to perform any operations.   |

The following variables are passed as a parameter to the mutation method written for **Delete** operation in server side.

| Properties | Description |
|--------|----------------|
| primaryColumnValue | Specifies the primary column value which is needs to be removed from the collection. |
| action | Indicates the type of operation being performed. When the same method is used for all CRUD actions, this argument serves to distinguish the action, such as **Add, Delete and Update**  |
| primaryColumnName | specifies the field name of the primary column.  |
| additionalParameters | An optional parameter that can be used to perform any operations.   |

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfGrid TValue="Order" AllowPaging=true AllowSorting=true AllowFiltering=true
    Toolbar="@(new List<string>() { "Search", "Add", "Edit", "Delete", "Cancel", "Update" })">
    <GridEditSettings AllowAdding=true AllowEditing=true AllowDeleting=true Mode="EditMode.Normal"></GridEditSettings>
    <SfDataManager Url="https://xxxxxx" GraphQLAdaptorOptions=@adaptorOptions Adaptor="Adaptors.GraphQLAdaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey=true TextAlign="TextAlign.Right" Width="120"><GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" TextAlign="TextAlign.Right"
        Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private GraphQLAdaptorOptions adaptorOptions { get; set; } = new GraphQLAdaptorOptions
    {
        Query = @"
            query ordersData($dataManager: DataManagerRequestInput!){
                ordersData(dataManager: $dataManager) {
                    count, result { OrderID, CustomerID, OrderDate, Freight } , aggregates
                }
            }",
        Mutation = new GraphQLMutation
        {
            Insert = @"
                mutation create($record: OrderInput!, $index: Int!, $action: String!, $additionalParameters: Any) {
                  createOrder(order: $record, index: $index, action: $action, additionalParameters: $additionalParameters) {
                    OrderID, CustomerID, OrderDate, Freight
                  }
                }",
            Update = @"
                mutation update($record: OrderInput!, $action: String!, $primaryColumnName: String! , $primaryColumnValue: Int!, $additionalParameters: Any) {
                  updateOrder(order: $record, action: $action, primaryColumnName: $primaryColumnName, primaryColumnValue: $primaryColumnValue, additionalParameters: $additionalParameters) {
                    OrderID, CustomerID, OrderDate, Freight
                  }
                }",
            Delete = @"
                mutation delete($primaryColumnValue: Int!, $action: String!, $primaryColumnName: String!, $additionalParameters: Any) {
                  deleteOrder(primaryColumnValue: $primaryColumnValue, action: $action, primaryColumnName: $primaryColumnName, additionalParameters: $additionalParameters) {
                    OrderID, CustomerID, OrderDate, Freight
                  }
                }"
        },
        ResolverName = "OrdersData"
    };

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

The following code demonstrates the mutation methods used in the GraphQL server for [Normal](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.EditMode.html#Syncfusion_Blazor_Grids_EditMode_Normal) editing.

```cshtml
    public class GraphQLMutation
    {
        public Order CreateOrder(Order order, int index, string action,
            [GraphQLType(typeof(AnyType))] IDictionary<string, object> additionalParameters)
        {
            GraphQLQuery.Orders.Insert(index, order);
            return order;
        }
        public Order UpdateOrder(Order order, string action, string primaryColumnName, int primaryColumnValue,
            [GraphQLType(typeof(AnyType))] IDictionary<string, object> additionalParameters)
        {
            Order updatedOrder = GraphQLQuery.Orders.Where(x => x.OrderID == primaryColumnValue).FirstOrDefault();
            updatedOrder.OrderID = order.OrderID;
            updatedOrder.CustomerID = order.CustomerID;
            updatedOrder.Freight = order.Freight;
            updatedOrder.OrderDate = order.OrderDate;
            return updatedOrder;
        }
        public Order DeleteOrder(int primaryColumnValue, string action, string primaryColumnName,
            [GraphQLType(typeof(AnyType))] IDictionary<string, object> additionalParameters)
        {
            Order deletedOrder = GraphQLQuery.Orders.Where(x => x.OrderID == primaryColumnValue).FirstOrDefault();
            GraphQLQuery.Orders.Remove(deletedOrder);
            return deletedOrder;
        }
    }
```

#### Batch editing

The following sample code demonstrates performing CRUD operation by using [Batch](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.EditMode.html#Syncfusion_Blazor_Grids_EditMode_Batch) editing in grid. You have to set the Batch mutation query in [Batch](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.GraphQLMutation.html#Syncfusion_Blazor_Data_GraphQLMutation_Batch) property of Mutation in `GraphQLAdaptorOptions`.

The following variables are passed as a parameter to the mutation method written for **Batch** operation in server side.

| Properties | Description |
|--------|----------------|
| changed | Specifies the collection of record to be updated. |
| added | Specifies the collection of record to be inserted.  |
| deleted | Specifies the collection of record to be removed.   |
| action | Indicates the type of operation being performed. |
| primaryColumnName | Specifies the field name of the primary column.  |
| additionalParameters | An optional parameter that can be used to perform any operations.   |
| dropIndex | Specifies the record position, from which new records will be added while performing drag and drop.   |

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfGrid TValue="Order" AllowPaging=true AllowSorting=true AllowFiltering=true
    Toolbar="@(new List<string>() { "Search", "Add", "Edit", "Delete", "Cancel", "Update" })">
    <GridEditSettings AllowAdding=true AllowEditing=true AllowDeleting=true Mode="EditMode.Batch"></GridEditSettings>
    <SfDataManager Url="https://xxxxxx" GraphQLAdaptorOptions=@adaptorOptions Adaptor="Adaptors.GraphQLAdaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey=true TextAlign="TextAlign.Right" Width="120"><GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" TextAlign="TextAlign.Right"
        Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private GraphQLAdaptorOptions adaptorOptions { get; set; } = new GraphQLAdaptorOptions
    {
        Query = @"
            query ordersData($dataManager: DataManagerRequestInput!){
                ordersData(dataManager: $dataManager) {
                    count, result { OrderID, CustomerID, OrderDate, Freight } , aggregates
                }
            }",
        Mutation = new GraphQLMutation
        {
            Batch = @"
                mutation batch($changed: [OrderInput!], $added: [OrderInput!], $deleted: [OrderInput!], $action: String!, $primaryColumnName: String!, $additionalParameters: Any, $dropIndex: Int) {
                  batchUpdate(changed: $changed, added: $added, deleted: $deleted, action: $action, primaryColumnName :$primaryColumnName, additionalParameters: $additionalParameters, dropIndex: $dropIndex) {
                    OrderID, CustomerID, OrderDate, Freight
                  }
                }"
        },
        ResolverName = "OrdersData"
    };

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

The following code demonstrates the mutation method used in the GraphQL server for [Batch](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.EditMode.html#Syncfusion_Blazor_Grids_EditMode_Batch) editing.

```cshtml
    public class GraphQLMutation
    {
        public List<Order> BatchUpdate(List<Order>? changed, List<Order>? added,
            List<Order>? deleted, string action, String primaryColumnName,
            [GraphQLType(typeof(AnyType))] IDictionary<string, object> additionalParameters, int? dropIndex)
        {
            if (changed != null && changed.Count > 0)
            {
                foreach (var changedOrder in (IEnumerable<Order>)changed)
                {
                    Order order = GraphQLQuery.Orders.Where(e => e.OrderID == changedOrder.OrderID).FirstOrDefault();
                    order.OrderID = changedOrder.OrderID;
                    order.CustomerID = changedOrder.CustomerID;
                    order.OrderDate = changedOrder.OrderDate;
                    order.Freight = changedOrder.Freight;
                }
            }
            if (added != null && added.Count > 0)
            {
                if (dropIndex != null)
                {
                    //for Drag and Drop feature in Grid
                    GraphQLQuery.Orders.InsertRange((int)dropIndex, added);
                }
                else {
                    foreach (var newOrder in (IEnumerable<Order>)added)
                    {
                        GraphQLQuery.Orders.Add(newOrder);
                    }
                }
            }
            if (deleted != null && deleted.Count > 0)
            {
                foreach (var deletedOrder in (IEnumerable<Order>)deleted)
                {
                    GraphQLQuery.Orders.Remove(GraphQLQuery.Orders.Where(e => e.OrderID == deletedOrder.OrderID).FirstOrDefault());
                }
            }
            return GraphQLQuery.Orders;
        }
    }
```

### Configuration in GraphQL server application

The following code is the configuration in GraphQL server application to set GraphQL query and mutation type and to enable CORS.

Program.cs

```cshtml

var builder = WebApplication.CreateBuilder(args);

//GraphQL resolver is defined in GraphQLQuery class and mutation methods are defined in GraphQLMutation class
builder.Services.AddGraphQLServer().AddQueryType<GraphQLQuery>().AddMutationType<GraphQLMutation>();

//CORS is enabled to access the GraphQL server from the client application
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("https://xxxxxx")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials().Build();
    });
});

```

The following code demonstrates the **DataManagerRequest** class which is passed as an argument to the resolver function.

```cshtml
    public class DataManagerRequest
    {
        [GraphQLName("Skip")]
        public int Skip { get; set; }

        [GraphQLName("Take")]
        public int Take { get; set; }

        [GraphQLName("RequiresCounts")]
        public bool RequiresCounts { get; set; } = false;

        [GraphQLName("Params")]
        [GraphQLType(typeof(AnyType))]
        public IDictionary<string, object> Params { get; set; }

        [GraphQLName("Aggregates")]
        [GraphQLType(typeof(AnyType))]
        public List<Aggregate>? Aggregates { get; set; }

        [GraphQLName("Search")]
        public List<SearchFilter>? Search { get; set; }

        [GraphQLName("Sorted")]
        public List<Sort>? Sorted { get; set; }

        [GraphQLName("Where")]
        [GraphQLType(typeof(AnyType))]
        public List<WhereFilter>? Where { get; set; }

        [GraphQLName("Group")]
        public List<string>? Group { get; set; }

        [GraphQLName("antiForgery")]
        public string? antiForgery { get; set; }

        [GraphQLName("Table")]
        public string? Table { get; set; }

        [GraphQLName("IdMapping")]
        public string? IdMapping { get; set; }

        [GraphQLName("Select")]
        public List<string>? Select { get; set; }

        [GraphQLName("Expand")]
        public List<string>? Expand { get; set; }

        [GraphQLName("Distinct")]
        public List<string>? Distinct { get; set; }

        [GraphQLName("ServerSideGroup")]
        public bool? ServerSideGroup { get; set; }

        [GraphQLName("LazyLoad")]
        public bool? LazyLoad { get; set; }

        [GraphQLName("LazyExpandAllGroup")]
        public bool? LazyExpandAllGroup { get; set; }
    }

    public class Aggregate
    {
        [GraphQLName("Field")]
        public string Field { get; set; }

        [GraphQLName("Type")]
        public string Type { get; set; }
    }

    public class SearchFilter
    {
        [GraphQLName("Fields")]
        public List<string> Fields { get; set; }

        [GraphQLName("Key")]
        public string Key { get; set; }

        [GraphQLName("Operator")]
        public string Operator { get; set; }

        [GraphQLName("IgnoreCase")]
        public bool IgnoreCase { get; set; }
    }

    public class Sort
    {
        [GraphQLName("Name")]
        public string Name { get; set; }

        [GraphQLName("Direction")]
        public string Direction { get; set; }

        [GraphQLName("Comparer")]
        [GraphQLType(typeof(AnyType))]
        public object Comparer { get; set; }
    }

    public class WhereFilter
    {
        [GraphQLName("Field")]
        public string? Field { get; set; }

        [GraphQLName("IgnoreCase")]
        public bool? IgnoreCase { get; set; }

        [GraphQLName("IgnoreAccent")]
        public bool? IgnoreAccent { get; set; }

        [GraphQLName("IsComplex")]
        public bool? IsComplex { get; set; }

        [GraphQLName("Operator")]
        public string? Operator { get; set; }

        [GraphQLName("Condition")]
        public string? Condition { get; set; }

        [GraphQLName("value")]
        [GraphQLType(typeof(AnyType))]
        public object? value { get; set; }

        [GraphQLName("predicates")]
        public List<WhereFilter>? predicates { get; set; }
    }

```

### Note

You can get the entire code in the [github](https://github.com/SyncfusionExamples/GraphQLAdaptor-Binding-Blazor-DataGrid) sample.

## SQL Server data binding(SQL Client)

The following examples demonstrate how to consume data from SQL Server using Microsoft SqlClient and bound it to Blazor DataGrid. You can achieve this requirement by using [Custom Adaptor](./custom-binding#custom-adaptor-as-component).

Before the implementation, add required NuGet like **Microsoft.Data.SqlClient** and **Syncfusion.Blazor** in your application. In the following sample, Custom Adaptor can be created as a Component. In custom adaptor **Read** method, you can get grid action details like paging, filtering, sorting information etc., using **DataManagerRequest**.

Based on the DataManagerRequest, you can form SQL query string (to perform paging) and execute the SQL query and retrieve the data from database using **SqlDataAdapter**. The Fill method of the **DataAdapter** is used to populate a **DataSet** with the results of the **SelectCommand** of the DataAdapter, then convert the DataSet into List and return **Result** and **Count** pair object in **Read** method to bind the data to Grid.

```cshtml
@using Syncfusion.Blazor.Grids;
@using Syncfusion.Blazor.Data;
@using Syncfusion.Blazor;

<SfGrid TValue="Order" AllowPaging="true">
    <SfDataManager Adaptor="Adaptors.CustomAdaptor">
        <CustomAdaptorComponent></CustomAdaptorComponent>
    </SfDataManager>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsIdentity="true" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120">
        </GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    SfGrid<Order> Grid { get; set; }
    public static List<Order> Orders { get; set; }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
    }
}
```

```cshtml
@using Syncfusion.Blazor;
@using Syncfusion.Blazor.Data;
@using Newtonsoft.Json
@using static EFGrid.Pages.Index;
@using Microsoft.Data.SqlClient;
@using System.Data;
@using System.IO;
@using Microsoft.AspNetCore.Hosting;

@inject IHostingEnvironment _env

@inherits DataAdaptor<Order>

<CascadingValue Value="@this">
    @ChildContent
</CascadingValue>

@code {
    [Parameter]
    [JsonIgnore]
    public RenderFragment ChildContent { get; set; }
    public static DataSet CreateCommand(string queryString, string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(
                   connectionString))
        {

            SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
            DataSet dt = new DataSet();
            try
            {
                connection.Open();
                adapter.Fill(dt);// using sqlDataAdapter we process the query string and fill the data into dataset
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.ToString());
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
    }
    // Performs data operation through Read method
    public override object Read(DataManagerRequest dm, string key = null)
    {
        string appdata = _env.ContentRootPath;
        string path = Path.Combine(appdata, "App_Data\\NORTHWND.MDF");
        string str = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='{path}';Integrated Security=True;Connect Timeout=30";
        // based on the skip and take count from DataManagerRequest here we formed SQL query string
        string qs = "SELECT OrderID, CustomerID FROM dbo.Orders ORDER BY OrderID OFFSET " + dm.Skip + " ROWS FETCH NEXT " + dm.Take + " ROWS ONLY;";
        DataSet data = CreateCommand(qs, str);
        Orders = data.Tables[0].AsEnumerable().Select(r => new Order
        {
            OrderID = r.Field<int>("OrderID"),
            CustomerID = r.Field<string>("CustomerID")
        }).ToList();  // here we convert dataset into list
        IEnumerable<Order> DataSource = Orders;
        SqlConnection conn = new SqlConnection(str);
        conn.Open();
        SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM dbo.Orders", conn);
        Int32 count = (Int32)comm.ExecuteScalar();
        return dm.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
    }
}
```

N> * In this [sample](https://github.com/SyncfusionExamples/blazor-grid-sqldatabinding), paging action is handled for Blazor grid. Based on your needs, you can extend the given logic for other operations.
<br/> * For performing data manipulation, you can override available methods such as **Insert**, **Update** and **Remove** of the Custom Adaptor.

## Entity Framework

You need to follow the below steps to consume data from the **Entity Framework** in the datagrid component.

To know about how to consume data from the Entity Framework and handle CRUD operations in Blazor DataGrid Component, you can check this video.

{% youtube "youtube:https://www.youtube.com/watch?v=MEdHxxqeY9A"%}

### Create DBContext class

The first step is to create a DBContext class called **OrderContext** to connect to a Microsoft SQL Server database.

```csharp
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFGrid.Shared.Models;

namespace EFGrid.Shared.DataAccess
{
    public class OrderContext : DbContext
    {
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='F:\blazor\EFGrid - CRUD - P6\EFGrid.Shared\App_Data\NORTHWND.MDF';Integrated Security=True;Connect Timeout=30");
            }
        }
    }
}
```

### Create data access layer to perform data operation

Now, you need to create a class named **OrderDataAccessLayer**, which act as data access layer for retrieving the records and also insert, update and delete the records from the database table.

```csharp
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFGrid.Shared.Models;

namespace EFGrid.Shared.DataAccess
{
    public class OrderDataAccessLayer
    {
        OrderContext db = new OrderContext();
        public DbSet<Order> GetAllOrders()
        {
            try
            {
                return db.Orders;
            }
            catch
            {
                throw;
            }
        }
    }
}
```

### Creating Web API Controller

 A Web API Controller has to be created which allows datagrid directly to consume data from the Entity Framework.

```csharp
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using EFGrid.Shared.DataAccess;
using EFGrid.Shared.Models;

namespace WebApplication1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        OrderDataAccessLayer db = new OrderDataAccessLayer();
        [HttpGet]
        public object Get()
        {
            IQueryable<Order> data = db.GetAllOrders().AsQueryable();
            var count = data.Count();
            var queryString = Request.Query;
            if (queryString.Keys.Contains("$inlinecount"))
            {
                StringValues Skip;
                StringValues Take;
                int skip = (queryString.TryGetValue("$skip", out Skip)) ? Convert.ToInt32(Skip[0]) : 0;
                int top = (queryString.TryGetValue("$top", out Take)) ? Convert.ToInt32(Take[0]) : data.Count();
                return new { Items = data.Skip(skip).Take(top), Count = count };
            }
            else
            {
                return data;
            }
        }
    }
}
```

### Configure datagrid component using Web API adaptor

Now, you can configure the datagrid using the **'SfDataManager'** to interact with the created Web API and consume the data appropriately. To interact with web api, you need to use WebApiAdaptor.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids

<SfGrid TValue="Order" AllowPaging="true" >
    <SfDataManager Url="api/Default" Adaptor="Adaptors.WebApiAdaptor"></SfDataManager>
        <GridColumns>
            <GridColumn Field="OrderID" HeaderText="Order ID" IsPrimaryKey="true" IsIdentity="true" TextAlign="@Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
            <GridColumn Field="CustomerID" HeaderText="Customer ID" Width="90"></GridColumn>
            <GridColumn Field="EmployeeID" HeaderText="Employee ID" Width="90"></GridColumn>
        </GridColumns>
</SfGrid>

@code{
    public class Order {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

To perform datagrid CRUD operation using Entity Framework. You can refer [here](./editing#entity-framework).
N>You can find the fully working sample [here](https://github.com/ej2gridsamples/Blazor/blob/master/EntityFramework.zip).

## HTTP client

It is possible to call web api from the Blazor WebAssembly(client-side) app. This can be used for sending HTTP requests to fetch data from web api and bind them in the DataGrid's data source. The requests are sent using [HttpClient](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-3.0) service.

This can be achieved by initially injecting the `HttpClient` instance in the app.

```cshtml
@using System.Net.Http
@inject HttpClient Http
```

After that the data to be fetched is defined in the api controller of the Blazor WebAssembly app.

```csharp
[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
    {
        List<Employee> employee = new List<Employee>();
        [HttpGet]
        public object Get()
        {
                employee.Add(new Employee { EmployeeID = 1, FirstName = "Andrew", LastName = "Fuller", Title = "Branch Manager" });
                employee.Add(new Employee { EmployeeID = 2, FirstName = "Nancy", LastName = "Leverling", Title = "Product Manager" });
                employee.Add(new Employee { EmployeeID = 3, FirstName = "Anne", LastName = "Dodsworth", Title = "Team Lead" });
                employee.Add(new Employee { EmployeeID = 4, FirstName = "Laura", LastName = "Callahan", Title = "Product Manager" });
                employee.Add(new Employee { EmployeeID = 5, FirstName = "Michael", LastName = "Suyama", Title = "Team Lead" });
                employee.Add(new Employee { EmployeeID = 6, FirstName = "Robert", LastName = "King", Title = "Developer" });
                employee.Add(new Employee { EmployeeID = 7, FirstName = "Janet", LastName = "Peacock", Title = "Developer" });
                employee.Add(new Employee { EmployeeID = 8, FirstName = "Steven", LastName = "Buchanan", Title = "Developer" });
                employee.Add(new Employee { EmployeeID = 9, FirstName = "Margaret", LastName = "Davolio", Title = "Developer" });
            return employee;
        }
    }

public class Employee
    {
        public int? EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
    }
```

Then using the `GetJsonAsync` method request is sent to the api controller for fetching data which is bounded to the DataGrid's data source

```cshtml
@using Syncfusion.Blazor.Grids

@inject HttpClient Http

<SfGrid DataSource="@Empdata" AllowPaging="true">
    <GridPageSettings PageSize="7"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Employee.EmployeeID) HeaderText="Employee ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Employee.FirstName) HeaderText="First Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Employee.LastName) HeaderText="Last Name" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Employee.Title) HeaderText="Title" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<Employee> Empdata { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Empdata = await Http.GetJsonAsync<List<Employee>>("api/Employee");
    }

    public class Employee
    {
        public int? EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
    }
}
```

N> The above steps are processed in the Blazor WebAssembly app which has the pre-configured `HttpClient` service. For Blazor server apps, web api calls are created using [IHttpClientFactory](https://learn.microsoft.com/en-gb/dotnet/api/system.net.http.ihttpclientfactory?view=dotnet-plat-ext-7.0). More information on making requests using `IHttpClientFactory` is available in this [link](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-3.0).

## Observable collection

This [ObservableCollection](https://learn.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.observablecollection-1?view=netframework-4.8)(dynamic data collection) provides notifications when items added, removed and moved. The implement [INotifyCollectionChanged](https://learn.microsoft.com/en-us/dotnet/api/system.collections.specialized.inotifycollectionchanged?view=netframework-4.8) notifies when dynamic changes of add,remove, move and clear the collection. The implement [INotifyPropertyChanged](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=netframework-4.8) notifies when property value has changed in client side.

Here, Order class implements the interface of **INotifyPropertyChanged** and it raises the event when CustomerID property value was changed.

```csharp

@using Syncfusion.Blazor.Grids
@using System.Collections.ObjectModel
@using System.ComponentModel

<button id="add" @onclick="AddRecords">Add Data</button>
<button id="del" @onclick="DelRecords">Delete Data</button>
<button id="update" @onclick="UpdateRecords">Update Data</button>
<SfGrid DataSource="@GridData" AllowReordering="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrdersDetailsObserveData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="@TextAlign.Center" HeaderTextAlign="@TextAlign.Center" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetailsObserveData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetailsObserveData.Freight) HeaderText="Freight" EditType="EditType.NumericEdit" Format="C2" Width="140" TextAlign="@TextAlign.Right" HeaderTextAlign="@TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetailsObserveData.OrderDate) HeaderText="Order Date" EditType="EditType.DatePickerEdit" Format="d" Type="ColumnType.Date" Width="160"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetailsObserveData.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>


@code{

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

 ```

The following screenshot represents the DataGrid with **Observable Collection**.

![Blazor DataGrid with ObservableCollection](./images/blazor-datagrid-observable-collection.PNG)

N> While using an Observable collection, the added, removed, and changed records are reflected in the UI. But while updating the Observable collection using external actions like timers, events, and other notifications, you need to call the StateHasChanged method to reflect the changes in the UI.

## Troubleshoot: DataGrid renders without data even though server returns with correct data

In ASP.NET Core, by default the JSON results are returned in **camelCase** format. So datagrid field names are also changed in **camelCase**.

To avoid this problem, you need to add [DefaultContractResolver](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.serialization.datacontractresolver?view=net-7.0) in **Startup.cs** file.

```csharp
public void ConfigureServices(IServiceCollection services)
{
  services.AddRazorPages();
  services.AddServerSideBlazor().AddCircuitOptions();
  services.AddSingleton<WeatherForecastService>();
  services.AddMvc().AddNewtonsoftJson(options =>
  {
    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
  });
}
```

## Handling exceptions

Exceptions occurred during grid actions can be handled without stopping application. These error messages or exception details can be acquired using the [OnActionFailure](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnActionFailure) event.

The argument passed to the [OnActionFailure](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnActionFailure) event contains the error details returned from the server.

N> We recommend you to bind **OnActionFailure** event during your application development phase, this helps you to find any exceptions. You can pass these exception details to our support team to get solution as early as possible.

The following sample code demonstrates notifying user when server-side exception has occurred during data operation,

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<span class="error">@ErrorDetails</span>
<SfGrid TValue="Order" AllowPaging="true">
    <GridEvents TValue="Order" OnActionFailure="@ActionFailure"></GridEvents>
    <GridPageSettings PageSize="10"></GridPageSettings>
    <SfDataManager Url="https://some.com/invalidUrl" Adaptor="Adaptors.WebApiAdaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
    .error {
        color: red;
    }
</style>

@code{
    public string ErrorDetails = "";
    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }

    public void ActionFailure(FailureEventArgs args)
    {
        this.ErrorDetails = "Server exception: 404 Not found";
        StateHasChanged();
    }
}
```

## Perform data operation in WebAPI service

While using the WebAPI adaptor type in the SfDataManager component, queries will be generated for data operations to be sent to the server side as QueryString, and based on these QueryString values, actions(filtering, sorting, paging, etc.) will be performed on the server side.

Requests sent to the server can be retrieved using "Request.Query", and these values can be differentiated as below.

|   Keys    |   Explanation                            |
|----------------------| -----------------------------------------|
|     $skip, $top      |   This contains query for performing paging operation in server side.|
|     $filter             |    This contains query for performing filtering operation in server side. |
|     $search           |   This contains query for performing searching operation in server side. |
|     $orderby           |    This contains query for performing sorting operation in server side. |

Using the above QueryString keys, you can get the corresponding values and perform the required actions. In the following sample, simple filtering, sorting, and paging operations are demonstrated.

```cshtml
@using Grid_WebAPI.Data
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfGrid TValue="Order" AllowFiltering="true" Toolbar="@(new List<string> {"Add","Edit","Delete","Update","Cancel","Search" })" AllowSorting="true" AllowPaging="true">
    <SfDataManager Url="api/Default" Adaptor="Adaptors.WebApiAdaptor"></SfDataManager>

    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field="EmployeeID" HeaderText="ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field="OrderID" HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field="CustomerID" HeaderText="Customer Name" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>
```

```csharp
public class DefaultController : ControllerBase
    {
    public OrderDataAccessLayer OrderService = new OrderDataAccessLayer();
    // GET: api/Default
    [HttpGet]
    public async Task<object> Get(int? code)
        {
            try
            {
                Microsoft.AspNetCore.Http.IQueryCollection queryString = Request.Query;
                if (queryString == null)
                return null;
                IQueryable<Order> dataSource = OrderService.GetAllOrders();
                int countAll = dataSource.Count();
                StringValues sSkip, sTake, sFilter, sSort;

                // Performing Filtering operation at server side.
                string filter = (queryString.TryGetValue("$filter", out sFilter)) ? sFilter[0] : null; //filter query
                List<DynamicLinqExpression.Filter> listFilter = ParsingFilterFormula.PrepareFilter(filter);
                if (listFilter.Count() > 0)
                {
                    Expression<Func<Order, bool>> deleg = DynamicLinqExpression.ExpressionBuilder.GetExpressionFilter<Order>(listFilter);
                    dataSource = dataSource.Where(deleg);
                }

               // Performing Sorting operation at server side.
               string sort = (queryString.TryGetValue("$orderby", out sSort)) ? sSort[0] : null;         //sort query
                if (sort != null)
                {
                    string s = DynamicLinqExpression.GetSortString(sort);
                    if (s == null)
                        return null;
                    else if (s.Length > 0)
                    {
                      dataSource = dataSource.OrderBy(s);
                    }
                }

                int countFiltered = dataSource.Count();

                // Performing Paging operation at server side.
                int skip = (queryString.TryGetValue("$skip", out sSkip)) ? Convert.ToInt32(sSkip[0]) : 0;
                int top = (queryString.TryGetValue("$top", out sTake)) ? Convert.ToInt32(sTake[0]) : countAll;
                dataSource = dataSource.Skip(skip).Take(top);

                if (queryString.Keys.Contains("$inlinecount"))
                    return new { Items = dataSource, Count = countFiltered };
                else
                    return dataSource;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
```
N> Similarly, we suggest you handle the same scenarios for complex queries.

N> [View Sample in GitHub.](https://github.com/SyncfusionExamples/blazor-datagrid-data-operations-in-wep-api-service)

N> ASP.NET Core (Blazor) Web API with batch handling is not yet supported by ASP.NET Core v3+. Hence, it is not feasible for us to support batch mode CRUD operations until ASP.NET Core provides the support for the batch handler. Refer [here](https://github.com/dotnet/aspnetcore/issues/14722) for more details.

## See also

* [How to import data from Excel sheet and bind to Blazor Grid](https://support.syncfusion.com/kb/article/11560/how-to-import-data-from-excel-sheet-and-bind-to-blazor-grid)
* [How to clear all Data from Grid](https://www.syncfusion.com/forums/150965/how-to-clear-all-data-from-grid)
* [Binding SQL data to the Blazor DataGrid Component](https://blazor.syncfusion.com/documentation/common/data-binding/sql-server-data-binding#binding-sql-data-to-the-blazor-datagrid-component)
* [Handling CRUD operations with our Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid component](https://blazor.syncfusion.com/documentation/common/data-binding/sql-server-data-binding#handling-crud-operations-with-our-syncfusion-blazor-datagrid-component)
