---
layout: post
title: Column Rendering in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about column rendering in the Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Column Rendering

## Define columns manually 

To define columns manually in DataGrid, you can use the `GridColumn` component to define the columns and represent each column with its respective properties such as [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Field), [HeaderText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_HeaderText), [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Type), and [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Width) set accordingly. This allows you to customize the column's behavior and appearance based on the requirements.

> 1. If the column [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Field) is not specified in the dataSource, the column values will be empty.
> 2. If the [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Field) name contains “dot” operator, it is considered as complex binding.
> 3. It is must to define the [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Field) property for a [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template) column, to perform CRUD or Data Operations such as filtering, searching etc.

Here's an example code snippet that demonstrates how to define columns manually in the Syncfusion Blazor DataGrid:

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" >
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
                Freight = 2.1 * x,
                OrderDate = DateTime.Now.AddDays(-x),
            }).ToList();
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZhgDbDUUJBoTxjd?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Auto generated columns

The DataGrid automatically generates columns when the  [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnModel.html#Syncfusion_Blazor_Grids_ColumnModel_Columns) declaration is empty or undefined while initializing the datagrid. All the columns in the **DataSource** are bound as datagrid columns.

You can use the following code snippet to enable auto-generated columns in the Syncfusion DataGrid:

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders"></SfGrid>

@code {
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
                Freight = 2.1 * x,
                OrderDate = DateTime.Now.AddDays(-x),
            }).ToList();
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
{% previewsample "https://blazorplayground.syncfusion.com/embed/rXBgNdLXVHcZpVKb?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


>* When the columns are auto-generated, the column [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Type) is determined from the first record of the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource).
>* If you have a large dataset, auto-generating columns can result in performance issues. In this case, it is recommended to specify the columns manually in the columns property during initialization or else use column virtualization feature by setting [EnableColumnVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableColumnVirtualization) property value as **true**.

### Set IsPrimaryKey for auto generated columns when editing is enabled

When editing is enabled in the grid, you may need to set a primary key for auto-generated columns to uniquely identify each row for operations such as updating or deleting data. This can be achieved using the [IsPrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsPrimaryKey) property of the column object by using the [OnDataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnDataBound) event.

By setting `IsPrimaryKey` to **true** for an auto-generated column in the Syncfusion DataGrid, you can specify it as the primary key column, which uniquely identifies each row when editing is enabled.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" TValue="Order" DataSource="@Orders">
    <GridEvents OnDataBound="DataBoundHandler" TValue="Order"></GridEvents>
    <GridEditSettings AllowEditing="true" AllowAdding="true" AllowDeleting="true"></GridEditSettings>
</SfGrid>

@code {
    public List<Order> Orders { get; set; }
    SfGrid<Order>? Grid { get; set; }
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
                Freight = 2.1 * x,
                OrderDate = DateTime.Now.AddDays(-x),
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }

    public void DataBoundHandler(BeforeDataBoundArgs<Order> args)
    {
        Grid.Columns[0].IsPrimaryKey = true;
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNVUjvDAJWVCTydX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Set column options to auto generated columns

To configure column options such as [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Type), [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Format) and [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Width) for auto-generated columns in Syncfusion Grid, you can use the [OnDataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnDataBound) event of the Grid component. This event is triggered after the data has been bound to the Grid. By handling this event, you can specify the desired column options for the auto-generated columns.

Here's an example of how you can set column options for auto-generated columns using the `OnDataBound` event:

In the below example, `Width` is set for **OrderID** column, **date** `Type` is set for **OrderDate** column and `Format` is set for **Freight** and **OrderDate** column.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" TValue="Order" DataSource="@Orders">
    <GridEvents OnDataBound="DataBoundHandler" TValue="Order"></GridEvents>
</SfGrid>

@code {
    public List<Order> Orders { get; set; }
    SfGrid<Order>? Grid { get; set; }
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
                Freight = 2.1 * x,
                OrderDate = DateTime.Now.AddDays(-x),
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }

    public void DataBoundHandler(BeforeDataBoundArgs<Order> args)
    {
        var GridColumns = Grid.Columns;

        foreach (var column in GridColumns)
        {
            if (column.Field == "OrderID")
            {
                column.Width = "200";
            }
            else if (column.Field == "OrderDate")
            {
                column.Type = ColumnType.Date;
                column.Format = "d";
            }
            else if (column.Field == "Freight")
            {
                column.Format= "C2";
            }
        }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rZrUNvDKzLJQHWGD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Dynamic column building

It is possible to dynamically build and customize each of the DataGrid column using the type of the model.

You can refer the following code example to achieve this.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData">
    <GridEditSettings AllowEditing="true" AllowAdding="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        @foreach (var prop in typeof(Order).GetProperties())
        {
            <GridColumn Field="@prop.Name" IsPrimaryKey="@(prop.Name == "OrderID")" AllowEditing="@prop.CanWrite"></GridColumn>
        }
    </GridColumns>
</SfGrid>

@code{
    public List<Order> OrderData = new List<Order>
    {
        new Order() { OrderID = 10248, CustomerID = "VINET", EmployeeID = 4 },
        new Order() { OrderID = 10249, CustomerID = "TOMSP", EmployeeID = 5 },
        new Order() { OrderID = 10250, CustomerID = "HANAR", EmployeeID = 6 }
    };

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public int? EmployeeID { get; set; }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXLqZdLZLwieoVBr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Dynamic column binding using ExpandoObject

It is possible to build a column dynamically without knowing the model type during compile time. This can be achieved by binding data to the grid as a list of `ExpandoObject`.

In the following sample, columns are built dynamically using the `ExpandoObject`.

```cshtml
@using System.Dynamic
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfGrid TValue="ExpandoObject" DataSource=@GridData>
    <GridColumns>
        @if (GridData != null && GridData.Any())
        {
            foreach (var item in (IDictionary<string, object>)GridData.First())
            {
                <GridColumn Field="@item.Key"></GridColumn>
            }
        }
    </GridColumns>
</SfGrid>

@code {
    private List<ExpandoObject> GridData = GenerateNewData();

    private static List<ExpandoObject> GenerateNewData()
    {
        var data = new List<ExpandoObject>();
        var random = new Random();
        var ColCount = random.Next(2, 6);
        var ColNames = new string[ColCount];

        // Generate random number of columns.
        for (var col = 0; col < ColCount; col++)
        {
            ColNames[col] = "Col" + random.Next(0, 5000);
        }
        
        // Generate 25 rows based on the generated columns name.
        for (var row = 0; row < 25; row++)
        {
            dynamic item = new ExpandoObject();
            var dict = (IDictionary<string, object>)item;
            for (var col = 0; col < ColCount; col++)
            {
                dict[ColNames[col]] = random.Next(0, 10000);
            }
            data.Add(item);
        }
        return data;
    }
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDhqXHrjBldvsODR?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Complex data binding

The Syncfusion DataGrid component allows you to achieve complex data binding by using the dot (.) operator in the  column.field. This feature is particularly useful when dealing with nested or complex data structures.

### Using local data

To enable complex data binding in the DataGrid component using local data, use the dot (.) operator in the `Field` property of the column. Here is an example of how to achieve complex data binding using local data:

In the following examples, **Name.FirstName** and **Name.LastName** are complex data.

> You can also use the **nameof** for complex columns instead of assigning static text for the `Field` property.
> ```cshtml
> <GridColumn Field="@(nameof(EmployeeData.EmployeeName) + "." + nameof(EmployeeName.FirstName))" HeaderText="First Name" Width="150"></GridColumn>
> ```

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Employees" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeData.EmployeeID) HeaderText="EmployeeID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field="Name.FirstName" HeaderText="First Name" Width="150"></GridColumn>
        <GridColumn Field="Name.LastName" HeaderText="Last Name"Width="130"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Title) HeaderText="Title" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<EmployeeData> Employees { get; set; }

    protected override void OnInitialized()
    {
    Employees = Enumerable.Range(1, 9).Select(x => new EmployeeData()
    {
        EmployeeID = x,
        Name = new EmployeeName() {
            FirstName = (new string[] { "Nancy", "Andrew", "Janet", "Margaret", "Steven" })[new Random().Next(5)],
            LastName =(new string[] { "Davolio", "Fuller", "Leverling", "Peacock", "Buchanan" })[new Random().Next(5)]
        },
        Title = (new string[] { "Sales Representative", "Vice President, Sales", "Sales Manager",
                                              "Inside Sales Coordinator" })[new Random().Next(4)],
    }).ToList();
    }

    public class EmployeeData
    {
        public int? EmployeeID { get; set; }
        public EmployeeName Name { get; set; }
        public string Title { get; set; }
    }

    public class EmployeeName
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNhKjRLjhvQYGrBK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

###  Using remote data

To enable complex data binding in the DataGrid component using remote data, add the [Expand](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.Query.html#Syncfusion_Blazor_Data_Query_Expand_System_Collections_Generic_List_System_String__) query to the [Query](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Query) property of the DataGrid, to eager load the complex data. Here is an example of how to achieve complex data binding using remote data:

In the below example, we have used the `Expand` query to load the nested Employee object's **City** property using the dot (.) operator.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfGrid TValue="EmployeeData" ID="Grid" Query="@GridQuery" AllowPaging="true">
    <SfDataManager Url="https://services.odata.org/V4/Northwind/Northwind.svc/Orders/" Adaptor="Adaptors.ODataV4Adaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeData.OrderID) TextAlign="TextAlign.Center" HeaderText="Order ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.CustomerID) TextAlign="TextAlign.Center" HeaderText="Customer Name" Width="130"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.ShipCity) TextAlign="TextAlign.Center" HeaderText="ShipCity" Width="120"></GridColumn>
        <GridColumn Field="Employee.City" TextAlign="TextAlign.Center" HeaderText="City" Width="120"></GridColumn>

    </GridColumns>
</SfGrid>

@code {


    private Query GridQuery= new Query().Expand(new List<string> { "Employee" });
    public class EmployeeData
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public Employee Employee { get; set; }
    }

    public class Employee
    {
        public string City { get; set; }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtLgNFNfqhJiGCNS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### ExpandoObject Complex data binding

Before proceeding this, learn about [ExpandoObject Binding](https://blazor.syncfusion.com/documentation/datagrid/data-binding#expandoobject-binding). You can achieve ExpandoObject complex data binding in the DataGrid by using the dot(.) operator in the column.field. In the following examples, `CustomerID.Name` and `ShipCountry.Country` are complex data.

```cshtml
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
            dynamic d = new ExpandoObject();
            dynamic customerName = new ExpandoObject();
            dynamic countryName = new ExpandoObject();
            d.OrderID = 1000 + x;
            customerName.Name = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)];
            d.CustomerID = customerName;
            d.Freight = (new double[] { 2, 1, 4, 5, 3 })[new Random().Next(5)] * x;
            d.OrderDate = (new DateTime[] { new DateTime(2010, 11, 5), new DateTime(2018, 10, 3), new DateTime(1995, 9, 9), new DateTime(2012, 8, 2), new DateTime(2015, 4, 11) })[new Random().Next(5)];
            countryName.Country = (new string[] { "USA", "UK" })[new Random().Next(2)];
            d.ShipCountry = countryName;
            d.Verified = (new bool[] { true, false })[new Random().Next(2)];

            return d;
        }).Cast<ExpandoObject>().ToList<ExpandoObject>();

    }
}
```

> * you can perform the Data operations and CRUD operations for Complex ExpandoObject binding fields too.

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXrgXRVXLFuZSlab?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### DynamicObject Complex data binding

Before proceeding this, learn about [DynamicObject Binding](https://blazor.syncfusion.com/documentation/datagrid/data-binding#dynamicobject-binding). You can achieve DynamicObject complex data binding in the datagrid by using the dot(.) operator in the column.field. In the following examples, `CustomerID.Name` and `ShipCountry.Country` are complex data.

```cshtml
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
        Orders = Enumerable.Range(1, 1075).Select((x) =>
        {
            dynamic d = new DynamicDictionary();
            dynamic combo = new DynamicDictionary();
            dynamic countryName = new DynamicDictionary();
            d.OrderID = 1000 + x;
            combo.Name = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)];
            d.CustomerID = combo;
            d.Freight = (new double[] { 2, 1, 4, 5, 3 })[new Random().Next(5)] * x;
            d.OrderDate = DateTime.Now.AddDays(-x);
            countryName.Country = (new string[] { "USA", "UK" })[new Random().Next(2)];
            d.ShipCountry = countryName;
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

> * you can perform the Data operations and CRUD operations for Complex DynamicObject binding fields too.

{% previewsample "https://blazorplayground.syncfusion.com/embed/BtBgNdrjLuIpsnpS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


