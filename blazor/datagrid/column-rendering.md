---
layout: post
title: Column Rendering in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about column rendering in the Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Column Rendering in Blazor DataGrid

In Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid, column rendering provides you with the ability to finely control how data is presented. This allows you to manually define columns, automatically generate them, and dynamically customize data presentation. With column rendering, you can ensure that your data is displayed exactly as needed, offering a wide range of possibilities for organizing and showcasing information within the Grid.

The column definitions are used as the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) schema in the Grid. The Grid operations such as sorting, filtering and grouping etc. are performed based on column definitions. The [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Field) property of Grid column is necessary to map the `DataSource` values in the Grid columns.

> If the column `Field` is not specified in the `DataSource`, the column values will be empty.
> If the `Field` name contains **dot** operator, it is considered as complex binding.
> It is must to define the `Field` property for a Template column, to perform CRUD or data Operations such as filtering, searching etc.

## Define columns manually 

To define columns manually in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid, you can use the `GridColumn` to define the columns and represent each column with its respective properties such as [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Field), [HeaderText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_HeaderText), [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Type), and [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Width) set accordingly. This allows you to customize the column's behavior and appearance based on the requirements.

> 1. If the column [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Field) is not specified in the dataSource, the column values will be empty.
> 2. If the [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Field) name contains “dot” operator, it is considered as complex binding.
> 3. It is must to define the [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Field) property for a [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template) column, to perform CRUD or Data Operations such as filtering, searching etc.

Here's an example code snippet that demonstrates how to define columns manually in the Grid:

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

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid automatically generates columns when the  [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnModel.html#Syncfusion_Blazor_Grids_ColumnModel_Columns) declaration is empty or undefined while initializing the Grid. All the columns in the **DataSource** are bound as Grid columns.

You can use the following code snippet to enable auto-generated columns in the Grid:

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

>* When the columns are auto-generated, the column [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Type) is determined from the first record of the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource).
>* If you have a large dataset, auto-generating columns can result in performance issues. In this case, it is recommended to specify the columns manually in the columns property during initialization or else use column virtualization feature by setting [EnableColumnVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableColumnVirtualization) property value as **true**.

To know about how to **Customize Auto generated columns using Data Annotation** in Grid, you can check this video.

{% youtube "youtube:https://www.youtube.com/watch?v=f7OIzUM0e7Y"%}

### Set IsPrimaryKey for auto generated columns when editing is enabled

When editing is enabled in the Grid, you may need to set a primary key for auto-generated columns to uniquely identify each row for operations such as updating or deleting data. This can be achieved using the [IsPrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsPrimaryKey) property of the column object by using the [OnDataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnDataBound) event.

By setting `IsPrimaryKey` to **true** for an auto-generated column in the Grid, you can specify it as the primary key column, which uniquely identifies each row when editing is enabled.

Here is an example code snippet that shows how to set a primary key for an auto-generated column when editing is enabled:

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

### Set column options to auto generated columns

To configure column options such as [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Type), [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Format) and [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Width) for auto-generated columns in Syncfusion<sup style="font-size:70%">&reg;</sup> Grid, you can use the [OnDataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnDataBound) event of the Grid. This event is triggered after the data has been bound to the Grid. By handling this event, you can specify the desired column options for the auto-generated columns.

Here's an example of how you can set column options for auto-generated columns using the `OnDataBound` event:

In the below example, `Width` is set for **OrderID** column, **date** `Type` is set for **OrderDate** column and `Format` is set for **Freight** and **OrderDate** column.

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

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows you to dynamically generate columns at runtime, based on the data provided. This feature is useful when you need to display data with varying columns based on user requirements or dynamic data sources.

You can refer the following code example to achieve this:

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

It is possible to build a column dynamically without knowing the model type during compile time. This can be achieved by binding data to the Grid as a list of `ExpandoObject`.

In the following sample, columns are built dynamically using the `ExpandoObject`:

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

## Complex data generation

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows you to achieve complex data binding by using the dot (.) operator in the  column.field. This feature is particularly useful when dealing with nested or complex data structures.

### Using local data

To enable complex data binding in the Grid using local data, use the dot (.) operator in the `Field` property of the column. Here is an example of how to achieve complex data binding using local data:

In the below example, we have bound the nested **Employee** object’s **FirstName** and **LastName** properties using the dot (.) operator.

> You can also use the **nameof** for complex columns instead of assigning static text for the `Field` property.
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

To enable complex data binding in the Grid using remote data, add the [Expand](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.Query.html#Syncfusion_Blazor_Data_Query_Expand_System_Collections_Generic_List_System_String__) query to the [Query](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Query) property of the Grid, to eager load the complex data. Here is an example of how to achieve complex data binding using remote data:

In the below example, we have used the `Expand` query to load the nested Employee object's **City** property using the dot (.) operator:

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

Before proceeding this, learn about [ExpandoObject Binding](https://blazor.syncfusion.com/documentation/datagrid/data-binding#expandoobject-binding). You can achieve ExpandoObject complex data binding in the Grid by using the dot(.) operator in the column.field. In the following examples, `CustomerID.Name` and `ShipCountry.Country` are complex data.

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

> * you can perform the Data operations and CRUD operations for Complex ExpandoObject binding fields too.

### Complex data generation using DynamicObject

Before proceeding this, learn about [DynamicObject Binding](https://blazor.syncfusion.com/documentation/datagrid/data-binding#dynamicobject-binding). You can achieve DynamicObject complex data binding in the Grid by using the dot(.) operator in the column.field. In the following examples, `CustomerID.Name` and `ShipCountry.Country` are complex data.

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

### How to set complex column as foreign key column

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides the ability to use complex columns as foreign key columns. This allows related data from a foreign data source to be displayed based on the value of a complex column.

The following example demonstrates how to set the **Employee.EmployeeID** column as a foreign key column, and display the **FirstName** column from the foreign data source:

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
