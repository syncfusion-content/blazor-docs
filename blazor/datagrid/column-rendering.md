---
layout: post
title: Column Rendering in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about column rendering in the Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Column Rendering in Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides flexible options to control how columns are rendered. Columns can be manually defined, automatically generated, or customized dynamically to ensure data is displayed as required.

Column definitions act as the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) schema for the Grid. Operations such as sorting, filtering, and grouping are performed based on these definitions. The [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Field) property is essential for mapping `DataSource` values to Grid columns.

**Ways to render columns in Blazor DataGrid**

* **Manually defined columns:** Columns are explicitly declared using [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) for complete control over properties such as [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Field), [HeaderText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_HeaderText), [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Type), and [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Width).

* **Auto-generated columns:** When no column definitions are provided or AutoGenerateColumns is enabled, the Grid automatically creates columns based on the properties of the bound data model.

* **Dynamic columns:** Columns can be generated or modified at **runtime** based on requirements or dynamic data sources. This includes scenarios where columns are created using reflection or dynamic objects such as **ExpandoObject** for flexible data structures.

* **Complex data binding:** Dot notation in the `Field` property allows binding to nested object values for hierarchical or complex data structures.

* **Foreign key columns:** Related data from a [ForeignDataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridForeignColumn-1.html#Syncfusion_Blazor_Grids_GridForeignColumn_1_ForeignDataSource) can be displayed based on the value of a complex column using [GridForeignColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridForeignColumn-1.html) configuration.

> * If the column `Field` is not present in the `DataSource`, the column will display **empty** values.
> * If the `Field` name contains a **dot** operator, it is treated as complex binding.
> * The `Field` property must be defined for a [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template) column to enable CRUD and data operations such as filtering and searching.

## Define columns manually 

To define columns manually in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid, use [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) to specify each column and configure properties such as [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Field), [HeaderText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_HeaderText), [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Type), and [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Width). This approach provides full control over column behavior and appearance.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
   private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
       
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }       
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
    public class OrderData
    {
        public static List<OrderData> Orders = new List<OrderData>();
        public OrderData()
        {

        }
        public OrderData( int? OrderID, string CustomerID, DateTime? OrderDate, double? Freight)
        {
           this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.OrderDate = OrderDate;
            this.Freight = Freight;
        }
        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET",new DateTime(1996,07,07), 32.38));
                    Orders.Add(new OrderData(10249, "TOMSP", new DateTime(1996, 07, 07), 92.38));
                    Orders.Add(new OrderData(10250, "HANAR", new DateTime(1996, 07, 07), 62.77));
                    Orders.Add(new OrderData(10251, "VICTE", new DateTime(1996, 07, 07), 12.38));
                    Orders.Add(new OrderData(10252, "SUPRD", new DateTime(1996, 07, 07), 82.38));
                    Orders.Add(new OrderData(10253, "CHOPS", new DateTime(1996, 07, 07), 31.31));
                    Orders.Add(new OrderData(10254, "RICSU", new DateTime(1996, 07, 07), 22.37));
                    Orders.Add(new OrderData(10255, "WELLI", new DateTime(1996, 07, 07), 44.34));
                    Orders.Add(new OrderData(10256, "RICSU", new DateTime(1996, 07, 07), 31.33));                                                                                    
                    code += 5;
                }
            }
            return Orders;
        }
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    } 
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDBqWMZdAcXwOxFl?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Auto generated columns

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid automatically generates columns when the `Columns` collection is not defined during Grid initialization. All properties in the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) are rendered as Grid columns.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders"></SfGrid>

@code {
    public List<OrderData> Orders { get; set; }
       
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }   
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
    public class OrderData
    {
        public static List<OrderData> Orders = new List<OrderData>();
        public OrderData()
        {

        }
        public OrderData( int? OrderID, string CustomerID, DateTime? OrderDate, double? Freight)
        {
           this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.OrderDate = OrderDate;
            this.Freight = Freight;
        }
        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET",new DateTime(1996,07,07), 32.38));
                    Orders.Add(new OrderData(10249, "TOMSP", new DateTime(1996, 07, 07), 92.38));
                    Orders.Add(new OrderData(10250, "HANAR", new DateTime(1996, 07, 07), 62.77));
                    Orders.Add(new OrderData(10251, "VICTE", new DateTime(1996, 07, 07), 12.38));
                    Orders.Add(new OrderData(10252, "SUPRD", new DateTime(1996, 07, 07), 82.38));
                    Orders.Add(new OrderData(10253, "CHOPS", new DateTime(1996, 07, 07), 31.31));
                    Orders.Add(new OrderData(10254, "RICSU", new DateTime(1996, 07, 07), 22.37));
                    Orders.Add(new OrderData(10255, "WELLI", new DateTime(1996, 07, 07), 44.34));
                    Orders.Add(new OrderData(10256, "RICSU", new DateTime(1996, 07, 07), 31.33));                                                                                code += 5;
                }
            }
            return Orders;
        }
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    } 
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjBKWiXngmWUgDyz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * When columns are auto-generated, the column [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Type) is determined from the first record of the `DataSource`.
> * For large datasets, auto-generating columns can impact performance. In such cases, it is recommended to define columns manually or enable column virtualization by setting [EnableColumnVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableColumnVirtualization) to **true**.

{% youtube "youtube:https://www.youtube.com/watch?v=f7OIzUM0e7Y"%}

### Configure primary key for auto-generated columns

When editing is enabled in the Grid, a primary key must be set for auto-generated columns to uniquely identify each row for operations such as updating or deleting data. This can be achieved by using the [IsPrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsPrimaryKey) property of the [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) object in the [OnDataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnDataBound)  event.

Setting `IsPrimaryKey` to **true** for an auto-generated column ensures that the Grid can identify rows uniquely when editing is enabled.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" TValue="OrderData" DataSource="@Orders">
    <GridEvents OnDataBound="DataBoundHandler" TValue="OrderData"></GridEvents>
    <GridEditSettings AllowEditing="true" AllowAdding="true" AllowDeleting="true"></GridEditSettings>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
       
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }   
    public void DataBoundHandler(BeforeDataBoundArgs<OrderData> args)
    {
        Grid.Columns[0].IsPrimaryKey = true;
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
    public class OrderData
    {
        public static List<OrderData> Orders = new List<OrderData>();
        public OrderData()
        {

        }
        public OrderData( int? OrderID, string CustomerID, DateTime? OrderDate, double? Freight)
        {
           this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.OrderDate = OrderDate;
            this.Freight = Freight;
        }
        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                     Orders.Add(new OrderData(10248, "VINET",new DateTime(1996,07,07), 32.38));
                    Orders.Add(new OrderData(10249, "TOMSP", new DateTime(1996, 07, 07), 92.38));
                    Orders.Add(new OrderData(10250, "HANAR", new DateTime(1996, 07, 07), 62.77));
                    Orders.Add(new OrderData(10251, "VICTE", new DateTime(1996, 07, 07), 12.38));
                    Orders.Add(new OrderData(10252, "SUPRD", new DateTime(1996, 07, 07), 82.38));
                    Orders.Add(new OrderData(10253, "CHOPS", new DateTime(1996, 07, 07), 31.31));
                    Orders.Add(new OrderData(10254, "RICSU", new DateTime(1996, 07, 07), 22.37));
                    Orders.Add(new OrderData(10255, "WELLI", new DateTime(1996, 07, 07), 44.34));
                    Orders.Add(new OrderData(10256, "RICSU", new DateTime(1996, 07, 07), 31.33));                                                                   
                    code += 5;
                }
            }
            return Orders;
        }
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BtLgsstnKwBBNbFo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Configure column options for auto-generated columns

Column options such as [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Type), [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Format) and [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Width) can be applied to auto-generated columns using the [OnDataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnDataBound) event. This event is triggered after data binding, allowing customization of column properties dynamically.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" TValue="OrderData" DataSource="@Orders">
    <GridEvents OnDataBound="DataBoundHandler" TValue="OrderData"></GridEvents>
    <GridEditSettings AllowEditing="true" AllowAdding="true" AllowDeleting="true"></GridEditSettings>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
       
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }   
    public void DataBoundHandler(BeforeDataBoundArgs<OrderData> args)
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
                column.Format = "C2";
            }
        }
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
    public class OrderData
    {
        public static List<OrderData> Orders = new List<OrderData>();
        public OrderData()
        {

        }
        public OrderData( int? OrderID, string CustomerID, DateTime? OrderDate, double? Freight)
        {
           this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.OrderDate = OrderDate;
            this.Freight = Freight;
        }
        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET",new DateTime(1996,07,07), 32.38));
                    Orders.Add(new OrderData(10249, "TOMSP", new DateTime(1996, 07, 07), 92.38));
                    Orders.Add(new OrderData(10250, "HANAR", new DateTime(1996, 07, 07), 62.77));
                    Orders.Add(new OrderData(10251, "VICTE", new DateTime(1996, 07, 07), 12.38));
                    Orders.Add(new OrderData(10252, "SUPRD", new DateTime(1996, 07, 07), 82.38));
                    Orders.Add(new OrderData(10253, "CHOPS", new DateTime(1996, 07, 07), 31.31));
                    Orders.Add(new OrderData(10254, "RICSU", new DateTime(1996, 07, 07), 22.37));
                    Orders.Add(new OrderData(10255, "WELLI", new DateTime(1996, 07, 07), 44.34));
                    Orders.Add(new OrderData(10256, "RICSU", new DateTime(1996, 07, 07), 31.33));                                                                   
                    code += 5;
                }
            }
            return Orders;
        }
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXBgMiDRgQqNWGJe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Dynamic column generation

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports generating columns dynamically at runtime based on the data structure. This approach is useful when the column set changes depending on the data source or when working with flexible models. Columns can be created using reflection or dynamic objects in scenarios where the schema is not fixed.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders">
    <GridEditSettings AllowEditing="true" AllowAdding="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        @foreach (var prop in typeof(OrderData).GetProperties())
        {
            <GridColumn Field="@prop.Name" IsPrimaryKey="@(prop.Name == "OrderID")" AllowEditing="@prop.CanWrite"></GridColumn>
        }
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> Orders { get; set; }
       
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }   
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
    public class OrderData
    {
        public static List<OrderData> Orders = new List<OrderData>();
        public OrderData()
        {

        }
        public OrderData( int? OrderID, string CustomerID, DateTime? OrderDate, double? Freight)
        {
           this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.OrderDate = OrderDate;
            this.Freight = Freight;
        }
        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET",new DateTime(1996,07,07), 32.38));
                    Orders.Add(new OrderData(10249, "TOMSP", new DateTime(1996, 07, 07), 92.38));
                    Orders.Add(new OrderData(10250, "HANAR", new DateTime(1996, 07, 07), 62.77));
                    Orders.Add(new OrderData(10251, "VICTE", new DateTime(1996, 07, 07), 12.38));
                    Orders.Add(new OrderData(10252, "SUPRD", new DateTime(1996, 07, 07), 82.38));
                    Orders.Add(new OrderData(10253, "CHOPS", new DateTime(1996, 07, 07), 31.31));
                    Orders.Add(new OrderData(10254, "RICSU", new DateTime(1996, 07, 07), 22.37));
                    Orders.Add(new OrderData(10255, "WELLI", new DateTime(1996, 07, 07), 44.34));
                    Orders.Add(new OrderData(10256, "RICSU", new DateTime(1996, 07, 07), 31.33));                                                                   
                    code += 5;
                }
            }
            return Orders;
        }
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjBUCCNHAcKJQkfY?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Dynamic column binding using ExpandoObject

Columns can be generated dynamically at runtime by binding data as a list of [ExpandoObject](https://blazor.syncfusion.com/documentation/datagrid/data-binding/local-data#expandoobject-binding). This approach is useful when working with completely dynamic data structures where column names and values are determined during execution.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
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
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDhqXHrjBldvsODR?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Complex data generation

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports complex data binding using the dot (.) operator in the [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Field) property. This feature is useful for displaying nested or hierarchical data structures.

### Using local data

To bind local data to the Grid using the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) property, use the dot (.) operator in the [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Field) property of the [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html).

This approach is helpful for binding nested properties like **Employee.FirstName** and **Employee.LastName** from a nested **Employee** object.

> The **nameof** operator can also be used for complex columns instead of assigning static text for the `Field` property:

> ```cshtml
> <GridColumn Field="@(nameof(EmployeeData.EmployeeName) + "." + nameof(EmployeeName.FirstName))" HeaderText="First Name" Width="150"></GridColumn>
> ```

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Employees" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeData.EmployeeID) HeaderText="EmployeeID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field="Name.FirstName" HeaderText="First Name" Width="150"></GridColumn>
        <GridColumn Field="Name.LastName" HeaderText="Last Name"Width="130"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Title) HeaderText="Title" TextAlign="TextAlign.Right" Width="120"></GridColumn>
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
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNhKjRLjhvQYGrBK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

###  Using remote data

When using remote data, configure data operations through [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html), which handles data retrieval, paging, sorting, and other operations from the remote service.

Complex data binding can be enabled by adding the [Expand](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.Query.html#Syncfusion_Blazor_Data_Query_Expand_System_Collections_Generic_List_System_String__) query to the [Query](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Query) property of the Grid to eager load nested data.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
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
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtLgNFNfqhJiGCNS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Complex data generation using ExpandoObject 

[ExpandoObject](https://blazor.syncfusion.com/documentation/datagrid/data-binding/data-binding#expandoobject-binding) is used when properties need to be added dynamically at runtime. This is suitable for scenarios where the data structure is not fixed.

Complex data binding can be achieved by using the dot (.) operator in the [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Field) property when working with ExpandoObject.

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
{% endhighlight %}
{% endtabs %}

> * Data operations and CRUD operations are supported for complex DynamicObject binding fields.

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXrgXRVXLFuZSlab?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Complex data generation using DynamicObject

[DynamicObject](https://blazor.syncfusion.com/documentation/datagrid/data-binding#dynamicobject-binding) is used when custom logic for property access or dynamic behavior is required.

Complex data binding can be achieved by using the dot (.) operator in the [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Field)  property when working with DynamicObject.

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
{% endhighlight %}
{% endtabs %}

> * you can perform the Data operations and CRUD operations for Complex DynamicObject binding fields too.

{% previewsample "https://blazorplayground.syncfusion.com/embed/BtBgNdrjLuIpsnpS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### How to set complex column as foreign key column

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports using complex columns as foreign key columns. This enables related data from a [ForeignDataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridForeignColumn-1.html#Syncfusion_Blazor_Grids_GridForeignColumn_1_ForeignDataSource) to be displayed based on the value of a complex column.

In this configuration, the **Employee.EmployeeID** column is set as a foreign key column, and the **FirstName** field from the foreign data source is displayed.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using System.Dynamic

<p>Complex data binding with foreign data source</p>

<SfGrid DataSource="@Orders" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" Width="120"></GridColumn>
        <GridForeignColumn Field=Employee.EmployeeID HeaderText="Employee Name" ForeignKeyValue="FirstName" ForeignKeyField="EmployeeID" ForeignDataSource="@Employees1" Width="150"></GridForeignColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; }
    public List<EmployeeData> Employees1 { get; set; }
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                Employee = new EmployeeData()
                {
                    EmployeeID = x,
                },
                Freight = 2.1 * x,
                OrderDate = DateTime.Now.AddDays(-x),
            }).ToList();
        Employees1 = Enumerable.Range(1, 75).Select(x => new EmployeeData()
            {
                EmployeeID = x,
                FirstName = (new string[] { "Nancy", "Andrew", "Janet", "Margaret", "Steven" })[new Random().Next(5)],
            }).ToList();
    }
    public class Order
    {
        public int? OrderID { get; set; }
        public EmployeeData Employee { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
    public class EmployeeData
    {
        public int? EmployeeID { get; set; }
        public string FirstName { get; set; }
    }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtBoXTisskOldOAN?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
