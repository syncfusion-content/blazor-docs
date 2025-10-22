---
layout: post
title: Sorting in Blazor DataGrid | Syncfusion
description: Explore sorting in Syncfusion Blazor DataGrid including single/multi-column sort, initial sort, custom icons, foreign key sorting, and sorting events.
platform: Blazor
control: DataGrid
documentation: ug
---

# Sorting in Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid includes built-in support for sorting data-bound columns in **ascending** or **descending** order. Enable sorting by setting the [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowSorting) property to `true`.

An overview of **sorting** functionality is available in this video:

{% youtube "youtube:https://www.youtube.com/watch?v=P3VO_vd0Ev0" %}

Clicking a column header toggles the sort direction between `ascending` and `descending`.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" AllowSorting="true" Height="315">
    <GridColumns>
        <GridColumn Field="@nameof(OrderData.OrderID)" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field="@nameof(OrderData.CustomerID)" HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field="@nameof(OrderData.ShipCity)" HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field="@nameof(OrderData.ShipName)" HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; } = new List<OrderData>();

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }
}

{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    private static readonly List<OrderData> Orders = new List<OrderData>();

    public OrderData(int? orderId, string customerId, string shipCity, string shipName)
    {
        OrderID = orderId;
        CustomerID = customerId;
        ShipCity = shipCity;
        ShipName = shipName;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevali"));
            Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
            Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
            Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
            Orders.Add(new OrderData(10253, "HANAR", "Lyon", "Hanari Carnes"));
            Orders.Add(new OrderData(10254, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
            Orders.Add(new OrderData(10255, "RICSU", "Münster", "Richter Supermarkt"));
            Orders.Add(new OrderData(10256, "WELLI", "Reims", "Wellington Import"));
        }

        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDhoMjBsUXCtbeqV?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * Columns are sorted in **ascending** order by default.
> * Use [SortColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SortColumnAsync_System_String_Syncfusion_Blazor_Grids_SortDirection_System_Nullable_System_Boolean__) to sort programmatically.
> * Use [ClearSortingAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ClearSortingAsync) to remove sorting.
> * To disable sorting for a specific column, set the [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) property of GridColumn to `false`.

## Initial sorting

By default, the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid does not apply sorting during initial rendering. To display records in a predefined order when the Grid loads, configure initial sorting by setting the [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortColumn.html#Syncfusion_Blazor_Grids_GridSortColumn_Field) and [Direction](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortColumn.html#Syncfusion_Blazor_Grids_GridSortColumn_Direction) properties in the [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortSettings.html#Syncfusion_Blazor_Grids_GridSortSettings_Columns) collection of [GridSortSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortSettings.html).

In this configuration, initial sorting is applied to the **OrderID** and **ShipCity** columns using the [GridSortSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortSettings.html).

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" AllowSorting="true" Height="315">
    <GridSortSettings>
        <GridSortColumns>
            <GridSortColumn Field="OrderID" Direction="SortDirection.Ascending"></GridSortColumn>
            <GridSortColumn Field="ShipCity" Direction="SortDirection.Descending"></GridSortColumn>
        </GridSortColumns>
    </GridSortSettings>
    <GridColumns>
        <GridColumn Field="@nameof(OrderData.OrderID)" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field="@nameof(OrderData.CustomerID)" HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field="@nameof(OrderData.ShipCity)" HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field="@nameof(OrderData.ShipName)" HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; } = new List<OrderData>();

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }
}

{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    private static readonly List<OrderData> Orders = new List<OrderData>();

    public OrderData(int? orderId, string customerId, string shipCity, string shipName)
    {
        OrderID = orderId;
        CustomerID = customerId;
        ShipCity = shipCity;
        ShipName = shipName;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevali"));
            Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
            Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
            Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
            Orders.Add(new OrderData(10253, "HANAR", "Lyon", "Hanari Carnes"));
            Orders.Add(new OrderData(10254, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
            Orders.Add(new OrderData(10255, "RICSU", "Münster", "Richter Supermarkt"));
            Orders.Add(new OrderData(10256, "WELLI", "Reims", "Wellington Import"));
        }

        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZrAiCDLKrKWrRVA?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> Initial sorting defined in the `GridSortSettings` of the Columns is applied on first render and overrides any sorting applied through interaction.

## Multi-column sorting

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports sorting multiple columns simultaneously. Enable this feature by setting both [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowSorting) and [AllowMultiSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowMultiSorting) to `true`.
When multi-column sorting is active:

- Hold <kbd>Ctrl</kbd> (or <kbd>Command</kbd> on macOS) and click additional column headers to add them to the sort configuration.
- Press <kbd>Shift</kbd> and click a column header to remove it from the multi-sort configuration.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" AllowSorting="true" AllowMultiSorting="true" Height="315">
    <GridColumns>
        <GridColumn Field="@nameof(OrderData.OrderID)" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field="@nameof(OrderData.CustomerID)" HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field="@nameof(OrderData.ShipCity)" HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field="@nameof(OrderData.ShipName)" HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; } = new List<OrderData>();

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }
}

{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
public class OrderData
{
    private static readonly List<OrderData> Orders = new List<OrderData>();

    public OrderData(int? orderId, string customerId, string shipCity, string shipName)
    {
        OrderID = orderId;
        CustomerID = customerId;
        ShipCity = shipCity;
        ShipName = shipName;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevali"));
            Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
            Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
            Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
            Orders.Add(new OrderData(10253, "HANAR", "Lyon", "Hanari Carnes"));
            Orders.Add(new OrderData(10254, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
            Orders.Add(new OrderData(10255, "RICSU", "Münster", "Richter Supermarkt"));
            Orders.Add(new OrderData(10256, "WELLI", "Reims", "Wellington Import"));
        }
        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXhAWCDhqqMpzrfL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Prevent sorting for particular column

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows disabling sorting for specific columns. This is useful for fields that should not be sorted.

To disable sorting, set the [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowSorting) property of the target [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) to `false`.

In this configuration, sorting is disabled for the **CustomerID** column.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" AllowSorting="true" Height="315">
    <GridColumns>
        <GridColumn Field="@nameof(OrderData.OrderID)" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field="@nameof(OrderData.CustomerID)" HeaderText="Customer ID" AllowSorting="false" Width="100"></GridColumn>
        <GridColumn Field="@nameof(OrderData.ShipCity)" HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field="@nameof(OrderData.ShipName)" HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; } = new List<OrderData>();

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    private static readonly List<OrderData> Orders = new List<OrderData>();

    public OrderData(int? orderId, string customerId, string shipCity, string shipName)
    {
        OrderID = orderId;
        CustomerID = customerId;
        ShipCity = shipCity;
        ShipName = shipName;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevali"));
            Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
            Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
            Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
            Orders.Add(new OrderData(10253, "HANAR", "Lyon", "Hanari Carnes"));
            Orders.Add(new OrderData(10254, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
            Orders.Add(new OrderData(10255, "RICSU", "Münster", "Richter Supermarkt"));
            Orders.Add(new OrderData(10256, "WELLI", "Reims", "Wellington Import"));
        }

        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtVgWMDhqzLxBsoB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customizing sorting functionality with the AllowUnsort property

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows controlling whether a column can return to an unsorted state after sorting. This behavior is managed using the [AllowUnsort](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortSettings.html#Syncfusion_Blazor_Grids_GridSortSettings_AllowUnsort) property in [GridSortSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortSettings.html).
When [AllowUnsort](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortSettings.html#Syncfusion_Blazor_Grids_GridSortSettings_AllowUnsort) is set to `false`, clicking a sorted column header does not revert the Grid to its original unsorted layout. This configuration ensures that columns remain sorted unless explicitly changed through another sort action.

In this configuration, the Grid is prevented from entering an unsorted state by setting [AllowUnsort](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortSettings.html#Syncfusion_Blazor_Grids_GridSortSettings_AllowUnsort) to false.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" AllowSorting="true" Height="267px">
    <GridSortSettings AllowUnsort="false"></GridSortSettings>
    <GridColumns>
        <GridColumn Field="@nameof(OrderData.OrderID)" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field="@nameof(OrderData.CustomerID)" HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field="@nameof(OrderData.ShipCity)" HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field="@nameof(OrderData.ShipName)" HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; } = new List<OrderData>();

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
public class OrderData
{
    private static readonly List<OrderData> Orders = new List<OrderData>();

    public OrderData(int? orderId, string customerId, string shipCity, string shipName)
    {
        OrderID = orderId;
        CustomerID = customerId;
        ShipCity = shipCity;
        ShipName = shipName;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevali"));
            Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
            Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
            Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
            Orders.Add(new OrderData(10253, "HANAR", "Lyon", "Hanari Carnes"));
            Orders.Add(new OrderData(10254, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
            Orders.Add(new OrderData(10255, "RICSU", "Münster", "Richter Supermarkt"));
            Orders.Add(new OrderData(10256, "WELLI", "Reims", "Wellington Import"));
        }

        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjVUMsiJfaBVSChx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Sort order

By default, the sorting sequence in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid follows this pattern: **Ascending** → **Descending** → **None**.

- First click on a column header applies `ascending` sorting.
- Second click switches to `descending` sorting.
- Third click `clears` the sorting and restores the unsorted state.

## Custom sorting 

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows customizing the default sort logic for a column by setting the [SortComparer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnModel.html#Syncfusion_Blazor_Grids_ColumnModel_SortComparer) property of a column. This property accepts an IComparer<object> implementation, which can be created by defining a comparer class that implements the .NET [IComparer<T>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1?view=net-8.0) interface.

In this configuration, a custom comparer is assigned to the **CustomerID** column:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" AllowSorting="true" Height="315">
    <GridColumns>
        <GridColumn Field="@nameof(OrderData.OrderID)" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field="@nameof(OrderData.CustomerID)" HeaderText="Customer ID" SortComparer="new CustomComparer()" Width="100"></GridColumn>
        <GridColumn Field="@nameof(OrderData.Freight)" HeaderText="Freight" Format="C2" Width="80"></GridColumn>
        <GridColumn Field="@nameof(OrderData.ShipName)" HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; } = new List<OrderData>();

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    public class CustomComparer : IComparer<object>
    {
        public int Compare(object? XRowDataToCompare, object? YRowDataToCompare)
        {
            if (XRowDataToCompare is not OrderData XOrder || YRowDataToCompare is not OrderData YOrder)
            {
                return 0;
            }

            return Nullable.Compare(XOrder.OrderID, YOrder.OrderID);
        }
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
public class OrderData
{
    private static readonly List<OrderData> Orders = new List<OrderData>();

    public OrderData(int? orderId, string customerId, double? freight, string shipName)
    {
        OrderID = orderId;
        CustomerID = customerId;
        Freight = freight;
        ShipName = shipName;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", 3.25, "Vins et alcools Chevali"));
            Orders.Add(new OrderData(10249, "TOMSP", 22.98, "Toms Spezialitäten"));
            Orders.Add(new OrderData(10250, "HANAR", 140.51, "Hanari Carnes"));
            Orders.Add(new OrderData(10251, "VICTE", 65.83, "Victuailles en stock"));
            Orders.Add(new OrderData(10252, "SUPRD", 58.17, "Suprêmes délices"));
            Orders.Add(new OrderData(10253, "HANAR", 81.91, "Hanari Carnes"));
            Orders.Add(new OrderData(10254, "CHOPS", 3.05, "Chop-suey Chinese"));
            Orders.Add(new OrderData(10255, "RICSU", 55.09, "Richter Supermarkt"));
            Orders.Add(new OrderData(10256, "WELLI", 48.29, "Wellington Import"));
        }

        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipName { get; set; }
    public double? Freight { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNhIWXBiJFYfNCrP?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * The **SortComparer** function receives two parameters: `a` and `b`, which represent the values to be compared. The function must return:
    - **-1** if `a` should appear before `b`
    - **0** if `a` and `b` are equal
    - **1** if `a` should appear after `b`
> * The **SortComparer** property is supported only when using `local data`.
> * When using a `column template`, ensure the [GridColumn.Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Field) property is defined so that SortComparer can access the corresponding field value.

## Touch interaction

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports sorting through touch gestures. On touch-enabled devices, tapping a column header sorts that column. A popup icon
![Sorting in Blazor DataGrid.](./images/blazor-datagrid-sorting.jpg) appears to enable multi-column sorting.
To sort multiple columns, tap the popup
![Multiple sorting in Blazor DataGrid.](./images/blazor-datagrid-multiple-sorting.jpg), and then tap the desired column headers.

> Both [AllowMultiSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowMultiSorting) and [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowSorting) must be true for the popup to appear.

This screenshot illustrates touch-based sorting in the Grid:

![Sorting in Blazor DataGrid](./images/blazor-datagrid-touch-sorting.jpg)

## Sort foreign key column based on text

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports sorting foreign key columns based on display text. To enable this, configure a [GridForeignColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridForeignColumn-1.html#Syncfusion_Blazor_Grids_GridForeignColumn_1_ForeignDataSource) with the following properties:

- [ForeignDataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridForeignColumn-1.html#Syncfusion_Blazor_Grids_GridForeignColumn_1_ForeignDataSource)
- [ForeignKeyField](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ForeignKeyField)
- [ForeignKeyValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ForeignKeyValue)

**Sort foreign key column based on text for local data**

For local data, sorting is performed based on the value of the [ForeignKeyValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ForeignKeyValue) property. Assign this property to the display text field from the foreign data source to sort the column by that text.
In this configuration, the **ContactName** field is used as the display text for the **CustomerID** foreign key column:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" Height="315" AllowSorting="true">
    <GridColumns>
        <GridColumn Field="@nameof(OrderData.OrderID)" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="90"></GridColumn>
        <GridForeignColumn Field="@nameof(OrderData.CustomerID)" HeaderText="Customer ID" ForeignKeyValue="ContactName" ForeignKeyField="CustomerID" ForeignDataSource="@CustomerData" Width="100"></GridForeignColumn>
        <GridColumn Field="@nameof(OrderData.ShipCity)" HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field="@nameof(OrderData.ShipName)" HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; } = new List<OrderData>();
    public List<EmployeeData> CustomerData { get; set; } = new List<EmployeeData>();

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
        CustomerData = EmployeeData.GetAllRecords();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
public class EmployeeData
{
    private static readonly List<EmployeeData> EmployeeRecords = new List<EmployeeData>();

    public EmployeeData(int? customerId, string contactName)
    {
        CustomerID = customerId;
        ContactName = contactName;
    }

    public static List<EmployeeData> GetAllRecords()
    {
        if (EmployeeRecords.Count == 0)
        {
            EmployeeRecords.Add(new EmployeeData(1, "Paul Henriot"));
            EmployeeRecords.Add(new EmployeeData(2, "Karin Josephs"));
            EmployeeRecords.Add(new EmployeeData(3, "Mario Pontes"));
            EmployeeRecords.Add(new EmployeeData(4, "Mary Saveley"));
            EmployeeRecords.Add(new EmployeeData(5, "Pascale Cartrain"));
            EmployeeRecords.Add(new EmployeeData(6, "Mario Pontes"));
            EmployeeRecords.Add(new EmployeeData(7, "Yang Wang"));
            EmployeeRecords.Add(new EmployeeData(8, "Michael Holz"));
            EmployeeRecords.Add(new EmployeeData(9, "Paula Parente"));
        }

        return EmployeeRecords;
    }

    public int? CustomerID { get; set; }
    public string ContactName { get; set; }
}

public class OrderData
{
    private static readonly List<OrderData> Orders = new List<OrderData>();

    public OrderData(int? orderId, int? customerId, string shipCity, string shipName)
    {
        OrderID = orderId;
        CustomerID = customerId;
        ShipCity = shipCity;
        ShipName = shipName;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, 1, "Reims", "Vins et alcools Chevali"));
            Orders.Add(new OrderData(10249, 2, "Münster", "Toms Spezialitäten"));
            Orders.Add(new OrderData(10250, 3, "Rio de Janeiro", "Hanari Carnes"));
            Orders.Add(new OrderData(10251, 4, "Lyon", "Victuailles en stock"));
            Orders.Add(new OrderData(10252, 5, "Charleroi", "Suprêmes délices"));
            Orders.Add(new OrderData(10253, 6, "Lyon", "Hanari Carnes"));
            Orders.Add(new OrderData(10254, 7, "Rio de Janeiro", "Chop-suey Chinese"));
            Orders.Add(new OrderData(10255, 8, "Münster", "Richter Supermarkt"));
            Orders.Add(new OrderData(10256, 9, "Reims", "Wellington Import"));
        }

        return Orders;
    }

    public int? OrderID { get; set; }
    public int? CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjrosDBrMaWuSWBG?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## How to customize sort icon

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows customizing the default sort icons by overriding the **.e-icon-ascending** and **.e-icon-descending** CSS classes. Use the `content` property to define custom icons:

```css
.e-grid .e-icon-ascending::before {
  content: '\e87a';
}

.e-grid .e-icon-descending::before {
  content: '\e70d';
}
```

This configuration renders the Grid with customized sort icons.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" AllowSorting="true" Height="315">
    <GridSortSettings>
        <GridSortColumns>
            <GridSortColumn Field="ShipCity" Direction="SortDirection.Ascending"></GridSortColumn>
            <GridSortColumn Field="CustomerID" Direction="SortDirection.Descending"></GridSortColumn>
        </GridSortColumns>
    </GridSortSettings>
    <GridColumns>
        <GridColumn Field="@nameof(OrderData.OrderID)" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field="@nameof(OrderData.CustomerID)" HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field="@nameof(OrderData.ShipCity)" HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field="@nameof(OrderData.ShipName)" HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
    .e-grid .e-icon-ascending::before {
        content: '\e87a';
    }

    .e-grid .e-icon-descending::before {
        content: '\e70d';
    }
</style>

@code {
    public List<OrderData> GridData { get; set; } = new List<OrderData>();

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
public class OrderData
{
    private static readonly List<OrderData> Orders = new List<OrderData>();

    public OrderData(int? orderId, string customerId, string shipCity, string shipName)
    {
        OrderID = orderId;
        CustomerID = customerId;
        ShipCity = shipCity;
        ShipName = shipName;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevali"));
            Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
            Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
            Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
            Orders.Add(new OrderData(10253, "HANAR", "Lyon", "Hanari Carnes"));
            Orders.Add(new OrderData(10254, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
            Orders.Add(new OrderData(10255, "RICSU", "Münster", "Richter Supermarkt"));
            Orders.Add(new OrderData(10256, "WELLI", "Reims", "Wellington Import"));
        }

        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXryiZBieWXbgwvN?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Sort columns externally

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports sorting based on external interactions, such as dropdown selection and button clicks. You can add or remove sort columns and clear sorting programmatically.

### Add sort columns

To sort a column externally, use [SortColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SortColumnAsync_System_String_Syncfusion_Blazor_Grids_SortDirection_System_Nullable_System_Boolean__) with parameters for column name, direction, and whether to perform multi-sort.

This sample uses a [DropDownList](https://blazor.syncfusion.com/documentation/dropdown-list/getting-started-with-web-app) to select the column and sort direction, and calls `SortColumnAsync` on a button click.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.DropDowns

<div style="display:flex;">
    <label style="padding: 10px 20px 0 0"> Column name :</label>
    <SfDropDownList TValue="string" TItem="ColumnMetadata" Width="300px" Placeholder="Select a Column" DataSource="@Columns" @bind-Value="@DropDownValue">
        <DropDownListFieldSettings Value="Id" Text="Value"></DropDownListFieldSettings>
    </SfDropDownList>
</div>
<br />

<div style="display:flex;">
    <label style="padding: 10px 17px 0 0"> Sorting direction :</label>
    <SfDropDownList TValue="SortDirection" TItem="string" DataSource="@EnumValues" @bind-Value="@DropDownDirection" Width="300px">
    </SfDropDownList>
</div>
<br />
<div style="display:flex;">
    <SfButton OnClick="AddSortColumn">Add sort column</SfButton>
</div>

<SfGrid DataSource="@GridData" @ref="Grid" AllowSorting="true" Height="315">
    <GridSortSettings>
        <GridSortColumns>
            <GridSortColumn Field="ShipName" Direction="SortDirection.Ascending"></GridSortColumn>
        </GridSortColumns>
    </GridSortSettings>
    <GridColumns>
        <GridColumn Field="@nameof(OrderData.OrderID)" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field="@nameof(OrderData.CustomerID)" HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field="@nameof(OrderData.ShipName)" HeaderText="Ship Name" Width="120"></GridColumn>
        <GridColumn Field="@nameof(OrderData.Freight)" HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="80"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; } = new List<OrderData>();
    public SfGrid<OrderData>? Grid { get; set; }
    public string DropDownValue { get; set; } = "OrderID";
    public string[] EnumValues { get; set; } = Enum.GetNames(typeof(SortDirection));
    public SortDirection DropDownDirection { get; set; } = SortDirection.Ascending;
    public List<ColumnMetadata> Columns { get; set; } = new List<ColumnMetadata>
    {
        new ColumnMetadata { Id = "OrderID", Value = "Order ID" },
        new ColumnMetadata { Id = "CustomerID", Value = "Customer ID" },
        new ColumnMetadata { Id = "Freight", Value = "Freight" },
    };

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    public async Task AddSortColumn()
    {
        if (Grid != null)
        {
            await Grid.SortColumnAsync(DropDownValue, DropDownDirection, true);
        }
    }

    public class ColumnMetadata
    {
        public string Id { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
public class OrderData
{
    private static readonly List<OrderData> Orders = new List<OrderData>();

    public OrderData(int? orderId, string customerId, double? freight, string shipName)
    {
        OrderID = orderId;
        CustomerID = customerId;
        Freight = freight;
        ShipName = shipName;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", 3.25, "Vins et alcools Chevali"));
            Orders.Add(new OrderData(10249, "TOMSP", 22.98, "Toms Spezialitäten"));
            Orders.Add(new OrderData(10250, "HANAR", 140.51, "Hanari Carnes"));
            Orders.Add(new OrderData(10251, "VICTE", 65.83, "Victuailles en stock"));
            Orders.Add(new OrderData(10252, "SUPRD", 58.17, "Suprêmes délices"));
            Orders.Add(new OrderData(10253, "HANAR", 81.91, "Hanari Carnes"));
            Orders.Add(new OrderData(10254, "CHOPS", 3.05, "Chop-suey Chinese"));
            Orders.Add(new OrderData(10255, "RICSU", 55.09, "Richter Supermarkt"));
            Orders.Add(new OrderData(10256, "WELLI", 48.29, "Wellington Import"));
        }

        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipName { get; set; }
    public double? Freight { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZhIijrBrMZftWiI?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Remove sort columns

To remove a specific sorted column externally, use [ClearSortingAsync(List<string>)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ClearSortingAsync_System_Collections_Generic_List_System_String__). The method clears sorting for the provided column names.

This sample uses a [DropDownList](https://blazor.syncfusion.com/documentation/dropdown-list/getting-started-with-web-app) to select a column and clears sorting for that column on button click.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.DropDowns

<div style="display:flex;">
    <label style="padding: 10px 20px 0 0"> Column name :</label>
    <SfDropDownList TValue="string" TItem="ColumnMetadata" Width="125px" Placeholder="Select a Column" DataSource="@Columns" @bind-Value="@DropDownValue">
        <DropDownListFieldSettings Value="Id" Text="Value"></DropDownListFieldSettings>
    </SfDropDownList>
</div>
<br />

<div style="display:flex;">
    <SfButton OnClick="RemoveSortColumn">Remove sort column</SfButton>
</div>

<SfGrid @ref="Grid" DataSource="@GridData" AllowSorting="true" Height="315">
    <GridSortSettings>
        <GridSortColumns>
            <GridSortColumn Field="CustomerID" Direction="SortDirection.Ascending"></GridSortColumn>
            <GridSortColumn Field="ShipName" Direction="SortDirection.Descending"></GridSortColumn>
        </GridSortColumns>
    </GridSortSettings>
    <GridColumns>
        <GridColumn Field="@nameof(OrderData.OrderID)" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field="@nameof(OrderData.CustomerID)" HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field="@nameof(OrderData.ShipCity)" HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field="@nameof(OrderData.ShipName)" HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; } = new List<OrderData>();
    public SfGrid<OrderData>? Grid { get; set; }
    public string DropDownValue { get; set; } = "OrderID";
    public List<ColumnMetadata> Columns { get; set; } = new List<ColumnMetadata>
    {
        new ColumnMetadata { Id = "OrderID", Value = "Order ID" },
        new ColumnMetadata { Id = "CustomerID", Value = "Customer ID" },
        new ColumnMetadata { Id = "ShipCity", Value = "Ship City" },
        new ColumnMetadata { Id = "ShipName", Value = "Ship Name" },
    };

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    public async Task RemoveSortColumn()
    {
        if (Grid != null)
        {
            var columnNames = new List<string> { DropDownValue };
            await Grid.ClearSortingAsync(columnNames);
        }
    }

    public class ColumnMetadata
    {
        public string Id { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
public class OrderData
{
    private static readonly List<OrderData> Orders = new List<OrderData>();

    public OrderData(int? orderId, string customerId, string shipCity, string shipName)
    {
        OrderID = orderId;
        CustomerID = customerId;
        ShipCity = shipCity;
        ShipName = shipName;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevali"));
            Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
            Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
            Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
            Orders.Add(new OrderData(10253, "HANAR", "Lyon", "Hanari Carnes"));
            Orders.Add(new OrderData(10254, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
            Orders.Add(new OrderData(10255, "RICSU", "Münster", "Richter Supermarkt"));
            Orders.Add(new OrderData(10256, "WELLI", "Reims", "Wellington Import"));
        }

        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtVeiZVVriBiZzgv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Clear sorting 

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides the [ClearSortingAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ClearSortingAsync) method to remove sorting from all columns. 

In this configuration, sorting is cleared when the external button triggers the [ClearSortingAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ClearSortingAsync) method.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div>
    <SfButton OnClick="OnExternalSort">Clear sorting</SfButton>
</div>

<SfGrid DataSource="@GridData" @ref="Grid" AllowSorting="true" Height="315">
    <GridSortSettings>
        <GridSortColumns>
            <GridSortColumn Field="CustomerID" Direction="SortDirection.Ascending"></GridSortColumn>
            <GridSortColumn Field="ShipName" Direction="SortDirection.Descending"></GridSortColumn>
        </GridSortColumns>
    </GridSortSettings>
    <GridColumns>
        <GridColumn Field="@nameof(OrderData.OrderID)" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field="@nameof(OrderData.CustomerID)" HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field="@nameof(OrderData.ShipCity)" HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field="@nameof(OrderData.ShipName)" HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; } = new List<OrderData>();
    public SfGrid<OrderData>? Grid { get; set; }

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }  

    private async Task OnExternalSort()
    {
        if (Grid != null)
        {
            await Grid.ClearSortingAsync();
        }
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
public class OrderData
{
    private static readonly List<OrderData> Orders = new List<OrderData>();

    public OrderData(int? orderId, string customerId, string shipCity, string shipName)
    {
        OrderID = orderId;
        CustomerID = customerId;
        ShipCity = shipCity;
        ShipName = shipName;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevali"));
            Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
            Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
            Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
            Orders.Add(new OrderData(10253, "HANAR", "Lyon", "Hanari Carnes"));
            Orders.Add(new OrderData(10254, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
            Orders.Add(new OrderData(10255, "RICSU", "Münster", "Richter Supermarkt"));
            Orders.Add(new OrderData(10256, "WELLI", "Reims", "Wellington Import"));
        }

        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZVeCjrLrslsrRMx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Sorting events

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides events to handle sorting operations:

1. [Sorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_Sorting): Triggered before sorting begins. Set **args.Cancel = true** to `cancel` the operation. Key fields include `ColumnName` and `Direction`.
2. [Sorted](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_Sorted): Triggered after sorting completes. Useful for post-action logic such as displaying notifications. Key fields include `ColumnName` and `Direction`.

These events are triggered for both user interactions and programmatic operations, such as [SortColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SortColumnAsync_System_String_Syncfusion_Blazor_Grids_SortDirection_System_Nullable_System_Boolean__) and [ClearSortingAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ClearSortingAsync), allowing centralized handling of sorting logic.

In this configuration, sorting is canceled for the **OrderID** column using the [Sorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_Sorting) event, and a notification is displayed using the [Sorted](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_Sorted) event.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

@if (ShowNotification)
{
    <div style="text-align: center; color: red">
        <span>Sort action completed for @LastSortedColumn column</span>
    </div>
    <br />
}

<SfGrid DataSource="@GridData" AllowSorting="true" Height="315">
    <GridEvents Sorting="SortingHandler" Sorted="SortedHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field="@nameof(OrderData.OrderID)" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field="@nameof(OrderData.CustomerID)" HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field="@nameof(OrderData.ShipCity)" HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field="@nameof(OrderData.ShipName)" HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; } = new List<OrderData>();
    public string LastSortedColumn { get; set; } = string.Empty;
    public bool ShowNotification { get; set; }

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }  

    public Task SortingHandler(SortingEventArgs args)
    {
        if (args.ColumnName == "OrderID")
        {
            args.Cancel = true;
        }

        return Task.CompletedTask;
    }

    public Task SortedHandler(SortedEventArgs args)
    {
        LastSortedColumn = args.ColumnName;
        ShowNotification = true;
        return Task.CompletedTask;
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    private static readonly List<OrderData> Orders = new List<OrderData>();

    public OrderData(int? orderId, string customerId, string shipCity, string shipName)
    {
        OrderID = orderId;
        CustomerID = customerId;
        ShipCity = shipCity;
        ShipName = shipName;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevali"));
            Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
            Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
            Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
            Orders.Add(new OrderData(10253, "HANAR", "Lyon", "Hanari Carnes"));
            Orders.Add(new OrderData(10254, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
            Orders.Add(new OrderData(10255, "RICSU", "Münster", "Richter Supermarkt"));
            Orders.Add(new OrderData(10256, "WELLI", "Reims", "Wellington Import"));
        }

        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXrSCXrBrBVsLJxL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> Refer to the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour for a broad overview. Explore the [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap5) to understand data presentation and manipulation.