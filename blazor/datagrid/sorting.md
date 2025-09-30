---
layout: post
title: Sorting in Blazor DataGrid | Syncfusion
description: Explore sorting in Syncfusion Blazor DataGrid including single/multi-column sort, initial sort, custom icons, foreign key sorting, and sorting events.
platform: Blazor
control: DataGrid
documentation: ug
---

# Sorting in Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides built-in support for sorting data-bound columns in ascending or descending order. To enable sorting in the Grid, set the [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowSorting) property to `true`.

To learn about `sorting` in the Grid, watch this video:

{% youtube "youtube:https://www.youtube.com/watch?v=P3VO_vd0Ev0" %}

To sort a particular column in the Grid, click on its column header. Each click toggles the sort direction between `ascending` and `descending`.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" AllowSorting="true" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
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
        public OrderData(int? OrderID,string CustomerID,string ShipCity, string ShipName)
        {
           this.OrderID = OrderID;    
           this.CustomerID = CustomerID;
            this.ShipCity = ShipCity;
            this.ShipName = ShipName;            
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
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
                    code += 5;
                }
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZrKsMZhrntSJwyp?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * Columns are sorted in `ascending` order on first click. Clicking the same column toggles the sort direction.
> * Apply or clear sorting programmatically using [SortColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SortColumnAsync_System_String_Syncfusion_Blazor_Grids_SortDirection_System_Nullable_System_Boolean__) and [ClearSortingAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ClearSortingAsync).
> * To disable sorting for a particular column, set the [GridColumn.AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) property to `false`.

## Initial sorting

By default, the Grid does not apply any sorting during initial rendering. To apply initial sorting, set [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortColumn.html#Syncfusion_Blazor_Grids_GridSortColumn_Field) and [Direction](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortColumn.html#Syncfusion_Blazor_Grids_GridSortColumn_Direction) in the [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortSettings.html#Syncfusion_Blazor_Grids_GridSortSettings_Columns) collection of [GridSortSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortSettings.html). This is useful for presenting data in a defined order on first load; users can still change sorting afterward.

The following example demonstrates setting `GridSortSettings` Columns for the `OrderID` and `ShipCity` fields with specified directions.

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
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>


@code {
    public List<OrderData> GridData { get; set; }

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
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
        public OrderData(int? OrderID,string CustomerID,string ShipCity, string ShipName)
        {
           this.OrderID = OrderID;    
           this.CustomerID = CustomerID;
            this.ShipCity = ShipCity;
            this.ShipName = ShipName;            
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
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
                    code += 5;
                }
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

> The initial sorting defined in `GridSortSettings` is applied at first render; users can change or clear sorting through interactions or APIs.

## Multi-column sorting

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports sorting more than one column at a time. To enable multi-column sorting, set [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowSorting) to true and [AllowMultiSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowMultiSorting) to true. Then hold Ctrl and click additional column headers to add them to the sort.

To remove a single column from a multi-sort configuration, press Shift and left‑click the column header.

> * `AllowSorting` must be `true` to enable multi-column sorting.
> * Set `AllowMultiSorting` to `false` to restrict sorting to a single column.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" AllowSorting="true" AllowMultiSorting="true" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
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
        public OrderData(int? OrderID,string CustomerID,string ShipCity, string ShipName)
        {
           this.OrderID = OrderID;    
           this.CustomerID = CustomerID;
            this.ShipCity = ShipCity;
            this.ShipName = ShipName;            
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
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
                    code += 5;
                }
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

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows preventing sorting for a specific column. This is useful for fields that should remain unsortable.

Set the [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowSorting) property of the target [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) to `false`.

The following example disables sorting for the `CustomerID` column.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" AllowSorting="true"  Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" AllowSorting="false" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
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
        public OrderData(int? OrderID,string CustomerID,string ShipCity, string ShipName)
        {
           this.OrderID = OrderID;    
           this.CustomerID = CustomerID;
            this.ShipCity = ShipCity;
            this.ShipName = ShipName;            
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
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
                    code += 5;
                }
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

When the [AllowUnsort](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortSettings.html#Syncfusion_Blazor_Grids_GridSortSettings_AllowUnsort) property is set to false in [GridSortSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortSettings.html), clicking a sorted column header will not return the Grid to an unsorted state. This restricts users from clearing sorting via header clicks.

In the following example, the Grid is prevented from entering an unsorted state by setting `AllowUnsort` to false in `GridSortSettings`.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" AllowSorting="true" Height="267px">
    <GridSortSettings AllowUnsort="false"></GridSortSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
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
        public OrderData(int? OrderID, string CustomerID, string ShipCity, string ShipName)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.ShipCity = ShipCity;
            this.ShipName = ShipName;
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
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
                    code += 5;
                }
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

By default, the sort order cycles as **Ascending -> Descending -> None**. The first click on a column header applies ascending order, a second click applies descending order, and a third click clears sorting.

## Custom sorting 

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows customizing the default sort logic for a column by setting the [SortComparer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnModel.html#Syncfusion_Blazor_Grids_ColumnModel_SortComparer) property of a column. SortComparer accepts an IComparer<object> implementation, so create a comparer class that implements the .NET [IComparer<T>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1?view=net-7.0&viewFallbackFrom=net-5) interface.

The following example defines a custom sort comparer for the `CustomerID` column.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" AllowSorting="true" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" SortComparer="new CustomComparer()" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" Width="80"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    public class CustomComparer : IComparer<Object>
    {
        public int Compare(object XRowDataToCompare, object YRowDataToCompare)
        {
            OrderData XRowData = XRowDataToCompare as OrderData;
            OrderData YRowData = YRowDataToCompare as OrderData;
            int XRowDataOrderID = (int)XRowData.OrderID;
            int YRowDataOrderID = (int)YRowData.OrderID;
            if (XRowDataOrderID < YRowDataOrderID)
            {
                return -1;
            }
            else if (XRowDataOrderID > YRowDataOrderID)
            {
                return 1;
            }
            else
            {
                return 0;
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
        public OrderData(int? OrderID, string CustomerID, double? Freight, string ShipName)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.Freight = Freight;
            this.ShipName = ShipName;
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
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
                    code += 5;
                }
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


{% previewsample "https://blazorplayground.syncfusion.com/embed/hDrUWMtqggCjRVvh?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * The comparer Compare method receives two row objects and must return -1, 0, or 1 to indicate order.
> * SortComparer property is applicable only when using local data.
> * When using a column template, ensure the [GridColumn.Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Field) is set so SortComparer can access the underlying field.

## Touch interaction

On touch devices, tapping a column header sorts that column. A popup ![Sorting in Blazor DataGrid.](./images/blazor-datagrid-sorting.jpg) is displayed to enable multi-column sorting. To sort multiple columns, tap the popup![Multiple sorting in Blazor DataGrid.](./images/blazor-datagrid-multiple-sorting.jpg), and then tap the desired Grid headers.

> Both [AllowMultiSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowMultiSorting) and [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowSorting) must be true for the popup to appear.

The following screenshot represents touch sorting in a Grid.

![Sorting in Blazor DataGrid](./images/blazor-datagrid-touch-sorting.jpg)

## Sort foreign key column based on text

To sort a foreign key column, configure a [GridForeignColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridForeignColumn-1.html#Syncfusion_Blazor_Grids_GridForeignColumn_1_ForeignDataSource) with [ForeignDataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridForeignColumn-1.html#Syncfusion_Blazor_Grids_GridForeignColumn_1_ForeignDataSource), [ForeignKeyField](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ForeignKeyField), and [ForeignKeyValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ForeignKeyValue).

**Sort foreign key column based on text for local data**

For local data, sorting is performed based on the text of the column’s [ForeignKeyValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ForeignKeyValue). Define ForeignKeyValue in the column to point to the display text from the foreign data source. The Grid sorts by that text.

The following example enables a foreign key column where the `CustomerID` field displays the `ContactName` from the foreign data and sorting uses that display text.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" Height="315" AllowSorting="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="90"></GridColumn>
        <GridForeignColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" ForeignKeyValue="ContactName" ForeignKeyField="CustomerID" ForeignDataSource="@customerData" Width="100"></GridForeignColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }
    public List<EmployeeData> customerData { get; set; }
    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
        customerData = EmployeeData.GetAllRecords();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
public class EmployeeData
    {
        public static List<EmployeeData> customerData = new List<EmployeeData>();
        public EmployeeData()
        {

        }
        public EmployeeData(int? customerID, string contactName)
        {
            CustomerID = customerID;
            ContactName = contactName;
        }
        public static List<EmployeeData> GetAllRecords()
        {
            if (customerData.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    customerData.Add(new EmployeeData(1, "Paul Henriot"));
                    customerData.Add(new EmployeeData(2, "Karin Josephs"));
                    customerData.Add(new EmployeeData(3, "Mario Pontes"));
                    customerData.Add(new EmployeeData(4, "Mary Saveley"));
                    customerData.Add(new EmployeeData(5, "Pascale Cartrain"));
                    customerData.Add(new EmployeeData(6, "Mario Pontes"));
                    customerData.Add(new EmployeeData(7, "Yang Wang"));
                    customerData.Add(new EmployeeData(8, "Michael Holz"));
                    customerData.Add(new EmployeeData(9, "Paula Parente"));
                    code += 5;
                }
            }
            return customerData;
        }
        public int? CustomerID { get; set; }
        public string ContactName { get; set; }
    }
    public class OrderData
    {
        public static List<OrderData> Orders = new List<OrderData>();
        
        public OrderData()
        {

        }
        public OrderData(int? OrderID,int? CustomerID,string ShipCity, string ShipName)
        {
           this.OrderID = OrderID;    
           this.CustomerID = CustomerID;
            this.ShipCity = ShipCity;
            this.ShipName = ShipName;            
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
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
                    code += 5;
                }
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNrKiWtqgIEXHWyp?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## How to customize sort icon

To customize the sort icon in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid, override the default Grid classes .e-icon-ascending and .e-icon-descending using CSS and set custom content via the content property, as shown below:

```css
.e-grid .e-icon-ascending::before {
  content: '\e87a';
}

.e-grid .e-icon-descending::before {
  content: '\e70d';
}
```

In the following sample, the Grid is rendered with customized sort icons.

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
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
    .e-grid .e-icon-ascending::before {
        content: '\e87a'; /* Unicode character representing the ascending icon */
    }

    .e-grid .e-icon-descending::before {
        content: '\e70d '; /* Unicode character representing the descending icon */
    }
</style>

@code {
    public List<OrderData> GridData { get; set; }

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
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
        public OrderData(int? OrderID,string CustomerID,string ShipCity, string ShipName)
        {
           this.OrderID = OrderID;    
           this.CustomerID = CustomerID;
            this.ShipCity = ShipCity;
            this.ShipName = ShipName;           
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
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
                    code += 5;
                }
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


{% previewsample "https://blazorplayground.syncfusion.com/embed/BNhKCWZqBWwrwhml?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Sort columns externally

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports sorting based on external interactions, such as dropdown selection and button clicks. You can add or remove sort columns and clear sorting programmatically.

### Add sort columns

To sort a column externally, use [SortColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SortColumnAsync_System_String_Syncfusion_Blazor_Grids_SortDirection_System_Nullable_System_Boolean__) with parameters for column name, direction, and whether to perform multi-sort.

The following example uses a [DropDownList](https://blazor.syncfusion.com/documentation/dropdown-list/getting-started-with-web-app) to select the column and sort direction, and calls `SortColumnAsync` on a button click.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.DropDowns

<div style="display:flex;">
    <label style="padding: 10px 20px 0 0"> Column name :</label>
    <SfDropDownList TValue="string" TItem="Columns" Width="300px" Placeholder="Select a Column" DataSource="@LocalData" @bind-Value="@DropDownValue">
        <DropDownListFieldSettings Value="ID" Text="Value"></DropDownListFieldSettings>
    </SfDropDownList>
</div>
<br />

<div style="display:flex;">
    <label style="padding: 10px 17px 0 0"> Sorting direction :</label>
    <SfDropDownList TValue="Syncfusion.Blazor.Grids.SortDirection" TItem="string" DataSource="@EnumValues" @bind-Value="@DropDownDirection" Width="300px">
    </SfDropDownList>
</div>
<br />
<div style="display:flex;">
    <Syncfusion.Blazor.Buttons.SfButton OnClick="AddsortColumn">ADD SORT COLUMN</Syncfusion.Blazor.Buttons.SfButton>
</div>

<SfGrid DataSource="@GridData" @ref="Grid" AllowSorting="true" Height="315">
    <GridSortSettings>
        <GridSortColumns>
            <GridSortColumn Field="ShipName" Direction="SortDirection.Ascending"></GridSortColumn>
        </GridSortColumns>
    </GridSortSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="80"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }

    public SfGrid<OrderData>? Grid { get; set; }

    public string DropDownValue { get; set; } = "OrderID";

    public string[] EnumValues = Enum.GetNames(typeof(Syncfusion.Blazor.Grids.SortDirection));

    public Syncfusion.Blazor.Grids.SortDirection DropDownDirection { get; set; } = SortDirection.Ascending;

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    List<Columns> LocalData = new List<Columns>
    {
        new Columns() { ID= "OrderID", Value= "OrderID" },
        new Columns() { ID= "CustomerID", Value= "CustomerID" },
        new Columns() { ID= "Freight", Value= "Freight" },
    };

    List<Direction> LocalData1 = new List<Direction>
    {
        new Direction() { ID= "Ascending", Value= "Ascending" },
        new Direction() { ID= "Descending", Value= "Descending" },

    };

    public class Columns
    {
        public string ID { get; set; }
        public string Value { get; set; }
    }

    public class Direction
    {
        public string ID { get; set; }
        public string Value { get; set; }
    }

    public async Task AddsortColumn()
    {
       await Grid.SortColumnAsync(DropDownValue, DropDownDirection, true);
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
        public OrderData(int? OrderID,string CustomerID, double? Freight, string ShipName)
        {
           this.OrderID = OrderID;    
           this.CustomerID = CustomerID;
            this.Freight = Freight;
            this.ShipName = ShipName;             
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
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
                    code += 5;
                }
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtBgsWDKBXuYpcUi?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Remove sort columns

To remove a specific sorted column externally, use [ClearSortingAsync(List<string>)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ClearSortingAsync_System_Collections_Generic_List_System_String__). The method clears sorting for the provided column names.

The following example uses a [DropDownList](https://blazor.syncfusion.com/documentation/dropdown-list/getting-started-with-web-app) to select a column and clears sorting for that column on button click.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.DropDowns

<div style="display:flex;">
    <label style="padding: 10px 20px 0 0"> Column name :</label>
    <SfDropDownList TValue="string" TItem="Columns" Width="125px" Placeholder="Select a Column" DataSource="@LocalData" @bind-Value="@DropDownValue">
        <DropDownListFieldSettings Value="ID" Text="Value"></DropDownListFieldSettings>
    </SfDropDownList>
</div>
<br />

<div style="display:flex;">
    <Syncfusion.Blazor.Buttons.SfButton OnClick="RemoveSortColumn">REMOVE SORT COLUMN</Syncfusion.Blazor.Buttons.SfButton>
</div>

<SfGrid @ref="Grid" DataSource="@GridData" AllowSorting="true" Height="315">
    <GridSortSettings>
        <GridSortColumns>
            <GridSortColumn Field="CustomerID" Direction="SortDirection.Ascending"></GridSortColumn>
            <GridSortColumn Field="ShipName" Direction="SortDirection.Descending"></GridSortColumn>
        </GridSortColumns>
    </GridSortSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }

    public SfGrid<OrderData>? Grid { get; set; }

    public string DropDownValue { get; set; } = "OrderID";


    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    List<Columns> LocalData = new List<Columns>
    {
        new Columns() { ID= "OrderID", Value= "OrderID" },
        new Columns() { ID= "CustomerID", Value= "CustomerID" },
        new Columns() { ID= "ShipCity", Value= "ShipCity" },
        new Columns() { ID= "ShipName", Value= "ShipName" },
    };

    public class Columns
    {
        public string ID { get; set; }
        public string Value { get; set; }
    }

    public class Direction
    {
        public string ID { get; set; }
        public string Value { get; set; }
    }
    List<string> listItems = new List<string>();
    public async Task RemoveSortColumn()
    {
        listItems.Add(DropDownValue);
        await Grid.ClearSortingAsync(listItems);
         listItems.Clear();

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
        public OrderData(int? OrderID,string CustomerID,string ShipCity, string ShipName)
        {
           this.OrderID = OrderID;    
           this.CustomerID = CustomerID;
            this.ShipCity = ShipCity;
            this.ShipName = ShipName;            
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
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
                    code += 5;
                }
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjhJXWtlsYHkfUrY?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Clear sorting 

To clear all sorting from the Grid in one action, use the [ClearSortingAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ClearSortingAsync) method. This clears sorting on every column, regardless of the current sort state or the AllowUnsort setting. Calling ClearSortingAsync when no columns are sorted has no effect.

The following example demonstrates how to clear sorting using the `ClearSortingAsync` method on an external button click.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div>
    <SfButton OnClick="onExternalSort">Clear Sorting</SfButton>
</div>

<SfGrid DataSource="@GridData" @ref="Grid" AllowSorting="true"  Height="315">
    <GridSortSettings>
        <GridSortColumns>
            <GridSortColumn Field="CustomerID" Direction="SortDirection.Ascending"></GridSortColumn>
            <GridSortColumn Field="ShipName" Direction="SortDirection.Descending"></GridSortColumn>
        </GridSortColumns>
    </GridSortSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID"  Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }

    public SfGrid<OrderData>? Grid { get; set; }

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }  

    private async Task onExternalSort()
    {
        await Grid.ClearSortingAsync();
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
        public OrderData(int? OrderID,string CustomerID,string ShipCity, string ShipName)
        {
           this.OrderID = OrderID;    
           this.CustomerID = CustomerID;
            this.ShipCity = ShipCity;
            this.ShipName = ShipName;            
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
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
                    code += 5;
                }
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNBUWWjKiFKHdJVl?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Sorting events

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid exposes two events during sorting operations:

1. [Sorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_Sorting): Fires before the sort action begins. Set args.Cancel = true to prevent the operation for that action. Common fields include ColumnName and Direction.
2. [Sorted](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_Sorted): Fires after the sort action completes. Useful for post-action updates such as notifications. Common fields include ColumnName and Direction.

These events are raised for both user interactions and programmatic operations (for example, SortColumnAsync and ClearSortingAsync), enabling centralized logic.

The following example shows how `Sorting` and `Sorted` events work. The Sorting event cancels sorting for the `OrderID` column, and the Sorted event displays a message.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

@if (show == true)
{
    <div style="text-align : center; color: red">
        <span> Sort action completed for @columnName column</span>
    </div>
    <br />
}

<SfGrid DataSource="@GridData"  AllowSorting="true"  Height="315px">
    <GridEvents Sorting="SortingHandler" Sorted="SortedHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }

    public string columnName { get; set; }
    public bool show { get; set; } = false;

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }  

    public async Task SortingHandler(SortingEventArgs args)
    {
        if (args.ColumnName == "OrderID")
        {
            args.Cancel = true;
        }
    }

    public async Task SortedHandler(SortedEventArgs args)
    {
        columnName = args.ColumnName;
        show = true;
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
        public OrderData(int? OrderID,string CustomerID,string ShipCity, string ShipName)
        {
           this.OrderID = OrderID;    
           this.CustomerID = CustomerID;
            this.ShipCity = ShipCity;
            this.ShipName = ShipName;           
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
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
                    code += 5;
                }
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


{% previewsample "https://blazorplayground.syncfusion.com/embed/hDhzNWNzLolkmHqw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> Refer to the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour for a broad overview. Explore the [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap5) to understand data presentation and manipulation.