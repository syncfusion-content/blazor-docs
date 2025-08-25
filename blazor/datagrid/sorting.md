---
layout: post
title: Sorting in Blazor DataGrid | Syncfusion
description: Learn all about sorting data-bound columns, single and multiple, in Syncfusion® Blazor DataGrid component.
platform: Blazor
control: DataGrid
documentation: ug
---

# Sorting in Blazor DataGrid

The Syncfusion Blazor DataGrid provides built-in support for sorting data-bound columns in ascending or descending order. To enable sorting in the Grid, set the [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowSorting) property to **true**.

To know about how to **Sorting** in Grid, you can check this video.

{% youtube "youtube:https://www.youtube.com/watch?v=P3VO_vd0Ev0" %}

To sort a particular column in the Grid, click on its column header. Each time you click the header, the order of the column will switch between **Ascending** and **Descending**.

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

> * Grid columns are sorted in the **Ascending** order. If you click the already sorted column, then toggles the sort direction.
> * You can apply and clear sorting by using the [SortColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SortColumnAsync_System_String_Syncfusion_Blazor_Grids_SortDirection_System_Nullable_System_Boolean__) and [ClearSortingAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ClearSortingAsync) methods.
> * To disable sorting for a particular column, set the `AllowSorting` property of [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) to **false**.

## Initial sorting

By default, the Grid does not apply any sorting to its records at initial rendering. However, you can apply initial sorting by setting the [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortColumn.html#Syncfusion_Blazor_Grids_GridSortColumn_Field) and [Direction](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortColumn.html#Syncfusion_Blazor_Grids_GridSortColumn_Direction) in [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortSettings.html#Syncfusion_Blazor_Grids_GridSortSettings_Columns) property of the [GridSortSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortSettings.html). This feature is helpful when you want to display your data in a specific order when the Grid is first loaded.

The following example demonstrates how to set the **GridSortSettings** of the  `Columns` for **OrderID** and **ShipCity** columns with a specified `Direction`.

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

> The initial sorting defined in the `GridSortSettings` of the  `Columns` will override any sorting applied through user interaction.

## Multi-column sorting

The Syncfusion Blazor DataGrid allows to sort more than one column at a time using multi-column sorting. To enable multi-column sorting in the Grid, set the [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowSorting) property to **true**, and set the [AllowMultiSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowMultiSorting) property to **true** which enable the user to sort multiple columns by holding the **CTRL** key and click on the column headers. This feature is useful when you want to sort your data based on multiple criteria to analyze it in various ways.

To clear multi-column sorting for a particular column, press the "Shift + mouse left click".

> * The `AllowSorting` must be **true** while enabling multi-column sort.
> * Set `AllowMultiSorting` property as **false** to disable multi-column sorting.

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

The Syncfusion Blazor DataGrid provides the ability to prevent sorting for a particular column. This can be useful when you have certain columns that you do not want to be included in the sorting process.

It can be achieved by setting the [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowSorting) property of the particular column to **false**.

The following example demonstrates, how to disable sorting for **CustomerID** column.

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

When the [AllowUnsort](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortSettings.html#Syncfusion_Blazor_Grids_GridSortSettings_AllowUnsort) property is set to **false** in [GridSortSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortSettings.html), the Grid cannot be placed in an unsorted state by clicking on a sorted column header. This setting restricts the action of reverting the Grid to its original unsorted layout through column header clicks.

In the following example, this is demonstrated by preventing the Grid from entering an unsorted state by setting `AllowUnsort` to **false** in **GridSortSettings**.

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

By default, the sorting order will be as **Ascending -> Descending -> None**.

When you click on a column header for the first time, it sorts the column in ascending order. Clicking the same column header again will sort the column in descending order. A repetitive third click on the same column header will clear the sorting.

## Custom sorting 

The Syncfusion Blazor DataGrid provides a way to customize the default sort action for a column by defining the [SortComparer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnModel.html#Syncfusion_Blazor_Grids_ColumnModel_SortComparer) property of GridColumn. The SortComparer data type was the IComparer interface, so the custom sort comparer class should be implemented in the interface [IComparer](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1?view=net-7.0&viewFallbackFrom=net-5).


The following example demonstrates how to define custom sort comparer function for the **CustomerID** column.

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

> * The SortComparer function takes two parameters: a and b. The a and b parameters are the values to be compared. The function returns -1, 0, or 1, depending on the comparison result.
> * The SortComparer property will work only for local data.
> * When using the column template to display data in a column, you will need to use the [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Field) property of [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) to work with the [SortComparer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_SortComparer) property.

## Touch interaction

When you tap the Syncfusion Blazor DataGrid header on touchscreen devices, the selected column header is sorted. A popup ![Sorting in Blazor DataGrid.](./images/blazor-datagrid-sorting.jpg) is displayed for multi-column sorting. To sort multiple columns, tap the popup![Multiple sorting in Blazor DataGrid.](./images/blazor-datagrid-multiple-sorting.jpg), and then tap the desired Grid headers.

> The [AllowMultiSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowMultiSorting) and [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowSorting) should be **true** then only the popup will be shown.

The following screenshot represents a Grid touch sorting in the device.

![Sorting in Blazor DataGrid using touch interaction.](./images/blazor-datagrid-touch-sorting.jpg)

## Sort foreign key column based on text

To perform sorting based on foreign key column, the `GridForeignColumn` column can be enabled by using [ForeignDataSource ](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridForeignColumn-1.html#Syncfusion_Blazor_Grids_GridForeignColumn_1_ForeignDataSource), [ForeignKeyField](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html?_gl=1*vgn3lm*_ga*MTcyMDA4OTE2OS4xNjg3OTQzMDQ5*_ga_WC4JKKPHH0*MTY4OTc2NTA2MS44NC4xLjE2ODk3NjUyNDAuNjAuMC4w&_ga=2.195629932.1791817302.1689564530-1720089169.1687943049#Syncfusion_Blazor_Grids_GridColumn_ForeignKeyField) and [ForeignKeyValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html?_gl=1*vgn3lm*_ga*MTcyMDA4OTE2OS4xNjg3OTQzMDQ5*_ga_WC4JKKPHH0*MTY4OTc2NTA2MS44NC4xLjE2ODk3NjUyNDAuNjAuMC4w&_ga=2.195629932.1791817302.1689564530-1720089169.1687943049#Syncfusion_Blazor_Grids_GridColumn_ForeignKeyValue) properties.

**Sort foreign key column based on text for local data**

In the case of local data in the Grid, the sorting operation will be performed based on the [ForeignKeyValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html?_gl=1*vgn3lm*_ga*MTcyMDA4OTE2OS4xNjg3OTQzMDQ5*_ga_WC4JKKPHH0*MTY4OTc2NTA2MS44NC4xLjE2ODk3NjUyNDAuNjAuMC4w&_ga=2.195629932.1791817302.1689564530-1720089169.1687943049#Syncfusion_Blazor_Grids_GridColumn_ForeignKeyValue) property of the column. The `ForeignKeyValue` property should be defined in the column definition with the corresponding foreign key value for each row. The Grid will sort the foreign key column based on the text representation of the `ForeignKeyValue` property.

The following example demonstrates how to perform sorting by enabling a foreign key column, where the **CustomerID** column acts as a foreign column displaying the **ContactName** column from foreign data.

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

To customize the sort icon in the Syncfusion Blazor DataGrid, you can override the default Grid classes **.e-icon-ascending** and **.e-icon-descending** with custom content using CSS. Simply specify the desired icons or symbols using the **content** property as mentioned below

```css
.e-grid .e-icon-ascending::before {
  content: '\e87a';
}

.e-grid .e-icon-descending::before {
  content: '\e70d';
}
```

In the below sample, Grid is rendered with a customized sort icon.

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

The Syncfusion Blazor DataGrid allows you to customize the sorting of columns and provides flexibility in sorting based on external interactions. You can sort columns and clear sorting using an external button click.

### Add sort columns

To sort a column externally, you can utilize the [SortColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SortColumnAsync_System_String_Syncfusion_Blazor_Grids_SortDirection_System_Nullable_System_Boolean__) method with parameters **ColumnName**, **Direction** and **IsMultiSort** provided by the Grid. This method allows you to programmatically sort a specific column based on your requirements.

The following example demonstrates how to add sort columns to a Grid. It utilizes the [DropDownList](https://blazor.syncfusion.com/documentation/dropdown-list/getting-started-with-web-app) to select the column and sort direction. When an external button is clicked, the `SortColumnAsync` method is called with the specified **ColumnName**, **Direction**, and **IsMultiSort** parameters. 

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

To remove a sort column externally, you can use the [ClearSortingAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ClearSortingAsync_System_Collections_Generic_List_System_String__) method provided by the Grid. This method allows you to remove the sorting applied to a specific column.

The following example demonstrates how to remove sort columns. It utilizes the [DropDownList](https://blazor.syncfusion.com/documentation/dropdown-list/getting-started-with-web-app) to select the column. When an external button is clicked, the `ClearSortingAsync` method is called to remove the selected sort column.

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

To clear the sorting on an external button click, you can use the [ClearSortingAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ClearSortingAsync) method provided by the Grid. This method clears the sorting applied to all columns in the Grid. 

The following example demonstrates how to clear the sorting using `ClearSortingAsync` method in the external button click.

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

The Syncfusion Blazor DataGrid provides two events that are triggered during the sorting action such as  [Sorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_Sorting) and [Sorted](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_Sorted). These events can be used to perform any custom actions before and after the sorting action is completed.

1. **Sorting**: `Sorting` event is triggered before the sorting action begins. It provides a way to perform any necessary operations before the sorting action takes place. This event provides a parameter that contains the current sorting column name, direction, and action.

2. **Sorted**: `Sorted` event is triggered after the sorting action is completed. It provides a way to perform any necessary operations after the sorting action has taken place. This event provides a parameter that contains the current sorting column name, direction, and action.

The following example demonstrates how the `Sorting` and `Sorted` events work when Sorting is performed. The `Sorting` event event is used to cancel the sorting of the OrderID column. The `Sorted` event is used to display a message.

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


> You can refer to our [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap5) to understand how to present and manipulate data.