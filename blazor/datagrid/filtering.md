---
layout: post
title: Filtering in Blazor DataGrid | Syncfusion
description: Check out this page to learn all about how to configure initial filtering and filter operators in the Syncfusion Blazor DataGrid component.
platform: Blazor
control: DataGrid
documentation: ug
---

# Filtering in Blazor DataGrid

Filtering is a powerful feature in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid that enables you to selectively view data based on specific criteria. It allows you to narrow down large datasets and focus on the information you need, thereby enhancing data analysis and decision-making.

To enable filtering in the Grid, you need to set the [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowFiltering) property of the Grid to true. Once filtering is enabled, you can configure various filtering options through the [GridFilterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_FilterSettings). This property allows you to define the behavior and appearance of the filter.

Here is an example that demonstrates the default filtering feature of the Grid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@GridData" AllowFiltering="true" AllowSorting="true" AllowPaging="true">
    <GridPageSettings PageSize="6"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText=" Order Date" Format="d"  TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }
    SfGrid<OrderData>? Grid { get; set; }

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
    public OrderData(){}
    public OrderData(int? OrderID,string CustomerID, DateTime? OrderDate, double? Freight)
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
            int OrderID = 10248;
            for (int i = 1; i < 3; i++)
            {
                Orders.Add(new OrderData(OrderID+1, "VINET", new DateTime(1996, 07, 06), 32.38));
                Orders.Add(new OrderData(OrderID+2, "TOMSP", new DateTime(1996, 07, 06), 11.61));
                Orders.Add(new OrderData(OrderID+3, "HANAR", new DateTime(1996, 07, 06), 65.83));
                Orders.Add(new OrderData(OrderID+4, "VICTE", new DateTime(1996, 07, 06), 45.78));
                Orders.Add(new OrderData(OrderID+5, "SUPRD", new DateTime(1996, 07, 06), 98.6));
                Orders.Add(new OrderData(OrderID+6, "HANAR", new DateTime(1996, 07, 06), 103.45));
                Orders.Add(new OrderData(OrderID+7, "CHOPS", new DateTime(1996, 07, 06), 103.45));
                Orders.Add(new OrderData(OrderID+8, "RICSU", new DateTime(1996, 07, 06), 112.48));
                Orders.Add(new OrderData(OrderID+9, "WELLI", new DateTime(1996, 07, 06), 33.45));
                OrderID += 9;
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNrfZCsImdiJgcDd?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * You can apply and clear filtering by using **FilterByColumnAsync** and **ClearFilteringAsync** methods.
> * To disable filtering for a particular column, set [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowFiltering) property of **GridColumn** as **false**.

## Initial filter

To apply an initial filter, you need to specify the filter criteria using the [Predicate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridFilterColumn.html#Syncfusion_Blazor_Grids_GridFilterColumn_Predicate) object in [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridFilterSettings.html#Syncfusion_Blazor_Grids_GridFilterSettings_Columns) property of [GridFilterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_FilterSettings). The `Predicate` object represents the filtering condition and contains properties such as field, operator, and value.

Here is an example of how to configure the initial filter using the `Predicate` object:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" AllowFiltering="true" Height="273px">
    <GridFilterSettings>
        <GridFilterColumns>
            <GridFilterColumn Field="ShipCity" MatchCase=false Operator="Syncfusion.Blazor.Operator.StartsWith" Predicate="and" Value="@ShipCityValue"></GridFilterColumn>
           <GridFilterColumn Field="ShipName" MatchCase=false Operator="Syncfusion.Blazor.Operator.StartsWith" Predicate="and" Value="@ShipNameValue"></GridFilterColumn>
        </GridFilterColumns>
    </GridFilterSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

@code {

    public List<OrderData> GridData { get; set; }

    public string ShipCityValue = "reims";
    public string ShipNameValue = "Vins et alcools Chevalier";

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
    public OrderData(){}

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
            int OrderID = 10248;
            for (int i = 1; i < 3; i++)
            {
                Orders.Add(new OrderData(OrderID + 1, "VINET", "Reims", "Vins et alcools Chevalier"));
                Orders.Add(new OrderData(OrderID+2, "TOMSP", "Münster", "Toms Spezialitäten"));
                Orders.Add(new OrderData(OrderID+3, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                Orders.Add(new OrderData(OrderID+4, "VICTE", "Lyon", "Victuailles en stock"));
                Orders.Add(new OrderData(OrderID+5, "SUPRD", "Charleroi", "Suprêmes délices"));
                Orders.Add(new OrderData(OrderID+6, "HANAR", "Lyon", "Hanari Carnes"));
                Orders.Add(new OrderData(OrderID+7, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
                Orders.Add(new OrderData(OrderID+8, "RICSU", "Münster", "Richter Supermarkt"));
                Orders.Add(new OrderData(OrderID+9, "WELLI", "Reims", "Wellington Import")); 
                OrderID += 9;
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDVTZCCymbPjhVWg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Initial filter with multiple values for same column

In the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid, you can establish an initial filter containing multiple values for a particular column, which helps you to preset filter conditions for a specific column using multiple values. This functionality allows you to display a filtered records in the Grid right after the Grid is initially loaded.

To apply the filter with multiple values for same column at initial rendering, set the filter [Predicate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridFilterColumn.html#Syncfusion_Blazor_Grids_GridFilterColumn_Predicate) object in [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridFilterSettings.html#Syncfusion_Blazor_Grids_GridFilterSettings_Columns) property of [GridFilterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_FilterSettings).

The following example demonstrates, how to perform an initial filter with multiple values for same **CustomerID** column using `Columns` property of `GridFilterSettings` and `Predicate`.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data;
 
<SfGrid DataSource="@GridData" @ref="Grid" AllowFiltering="true" Height="325px">
<GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Excel"></GridFilterSettings>
<GridEvents DataBound="DataBoundHandler" TValue="OrderData"></GridEvents>
<GridColumns>
<GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="100"></GridColumn>
<GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
<GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
<GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="100"></GridColumn>
</GridColumns>
</SfGrid>
 
@code {
 
    public List<OrderData> GridData { get; set; }
    SfGrid<OrderData> Grid;
 
    public int value{ get; set; }
 
    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    public bool Initialrender = true;

    public async Task DataBoundHandler()
    {
        var columns = await Grid.GetColumns();

        if (columns != null && Initialrender == true)
        {
            Initialrender = false;
            if (Grid.FilterSettings.Columns == null)
            {
                Grid.FilterSettings.Columns = new List<GridFilterColumn>();
            }
            string CustomerfUid = columns[1].Uid;
           
            Grid.FilterSettings.Columns.Add(new GridFilterColumn
                {
                    Field = "CustomerID",
                    Operator = Syncfusion.Blazor.Operator.StartsWith,
                    Predicate = "or",
                    Value = "VINET",
                    Uid = CustomerfUid
                });

            Grid.FilterSettings.Columns.Add(new GridFilterColumn
                {
                    Field = "CustomerID",
                    Operator = Syncfusion.Blazor.Operator.StartsWith,
                    Predicate = "or",
                    Value = "HANAR",
                    Uid = CustomerfUid
                });

           await Grid.Refresh();
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

 public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();
    public OrderData(){}

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
            int OrderID = 10248;
            for (int i = 1; i < 3; i++)
            {
                Orders.Add(new OrderData(OrderID+1, "VINET", "Reims", "Vins et alcools Chevali"));
                Orders.Add(new OrderData(OrderID+2, "TOMSP", "Münster", "Toms Spezialitäten"));
                Orders.Add(new OrderData(OrderID+3, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                Orders.Add(new OrderData(OrderID+4, "VICTE", "Lyon", "Victuailles en stock"));
                Orders.Add(new OrderData(OrderID+5, "SUPRD", "Charleroi", "Suprêmes délices"));
                Orders.Add(new OrderData(OrderID+6, "HANAR", "Lyon", "Hanari Carnes"));
                Orders.Add(new OrderData(OrderID+7, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
                Orders.Add(new OrderData(OrderID+8, "RICSU", "Münster", "Richter Supermarkt"));
                Orders.Add(new OrderData(OrderID+9, "WELLI", "Reims", "Wellington Import"));
                OrderID += 9;
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDVzXLjnKdMxxvHP?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Initial filter with multiple values for different columns

In the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid, you can establish an initial filter containing multiple values for a different column, which helps you to preset filter conditions for a different column using multiple values. This functionality allows you to display a filtered records in the Grid right after the Grid is initially loaded.

To apply the filter with multiple values for different column at initial rendering, set the filter [Predicate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridFilterColumn.html#Syncfusion_Blazor_Grids_GridFilterColumn_Predicate) object in [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridFilterSettings.html#Syncfusion_Blazor_Grids_GridFilterSettings_Columns) property of [GridFilterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_FilterSettings).

The following example demonstrates how to perform an initial filter with multiple values for different **Order ID** and **Customer ID** columns using `Columns` property of `GridFilterSettings` and `Predicate`:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data;

<SfGrid DataSource="@GridData" @ref="Grid"  AllowFiltering="true" Height="273px">
    <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Excel"></GridFilterSettings>
    <GridEvents DataBound="DataBoundHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

@code {

    public List<OrderData> GridData { get; set; }
    SfGrid<OrderData> Grid;

    public int value { get; set; }

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    public bool Initialrender = true;

    public async Task DataBoundHandler()
    {
        var columns = await Grid.GetColumns();

        if (columns != null && Initialrender == true)
        {
            Initialrender = false;
            if (Grid.FilterSettings.Columns == null)
            {
                Grid.FilterSettings.Columns = new List<GridFilterColumn>();
            }
            string CustomerfUid = columns[1].Uid;
            string OrderfUid = columns[0].Uid;

            Grid.FilterSettings.Columns.Add(new GridFilterColumn
                {
                    Field = "CustomerID",
                    Operator = Syncfusion.Blazor.Operator.StartsWith,
                    Predicate = "or",
                    Value = "VINET",
                    Uid = CustomerfUid
                });

            Grid.FilterSettings.Columns.Add(new GridFilterColumn
                {
                    Field = "CustomerID",
                    Operator = Syncfusion.Blazor.Operator.StartsWith,
                    Predicate = "or",
                    Value = "HANAR",
                    Uid = CustomerfUid
                });

            Grid.FilterSettings.Columns.Add(new GridFilterColumn
                {
                    Field = "OrderID",
                    Operator = Syncfusion.Blazor.Operator.LessThan,
                    Predicate = "and",
                    Value = 10250,
                    Uid = OrderfUid
                });

            Grid.FilterSettings.Columns.Add(new GridFilterColumn
                {
                    Field = "OrderID",
                    Operator = Syncfusion.Blazor.Operator.NotEqual,
                    Predicate = "and",
                    Value = 10262,
                    Uid = OrderfUid
                });

            Grid.Refresh();
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

 public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();
    public OrderData(){}
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
            int OrderID = 10247;
            for (int i = 1; i < 3; i++)
            {
                Orders.Add(new OrderData(OrderID + 1, "VINET", "Reims", "Vins et alcools Chevali"));
                Orders.Add(new OrderData(OrderID + 2, "HANAR", "Münster", "Toms Spezialitäten"));
                Orders.Add(new OrderData(OrderID + 3, "TOMSP", "Rio de Janeiro", "Hanari Carnes"));
                Orders.Add(new OrderData(OrderID + 4, "VICTE", "Lyon", "Victuailles en stock"));
                Orders.Add(new OrderData(OrderID + 5, "SUPRD", "Charleroi", "Suprêmes délices"));
                Orders.Add(new OrderData(OrderID + 6, "HANAR", "Lyon", "Hanari Carnes"));
                Orders.Add(new OrderData(OrderID + 7, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
                Orders.Add(new OrderData(OrderID + 8, "RICSU", "Münster", "Richter Supermarkt"));
                Orders.Add(new OrderData(OrderID + 9, "WELLI", "Reims", "Wellington Import"));
                OrderID += 9;
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXrzNLDngxUMWDzM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Filter operators

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides various filter operators that can be used to define filter conditions for columns. The filter operator for a column can be defined using the [Operator](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridFilterColumn.html#Syncfusion_Blazor_Grids_GridFilterColumn_Operator) in [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridFilterSettings.html#Syncfusion_Blazor_Grids_GridFilterSettings_Columns) property of `GridFilterSettings`.

The available operators and its supported data types are,

Operator |Description |Supported Types
-----|-----|-----
StartsWith |Checks whether the value begins with the specified value. |String
DoesNotStartWith |Checks whether the value does not begin with the specified value. |String
EndsWith |Checks whether the value ends with the specified value. |String
DoesNotEndWith |Checks whether the value does not end with the specified value. |String
Contains |Checks whether the value contains the specified value. |String
DoesNotContain |Checks whether the value does not contain the specified value. |String
Equal |Checks whether the value is equal to the specified value. |String &#124; Number &#124; Boolean &#124; Date
NotEqual |Checks for values not equal to the specified value. |String &#124; Number &#124; Boolean &#124; Date
GreaterThan |Checks whether the value is greater than the specified value. |Number &#124; Date
GreaterThanOrEqual |Checks whether a value is greater than or equal to the specified value. |Number &#124; Date
LessThan |Checks whether the value is less than the specified value. |Number &#124; Date
LessThanOrEqual |Checks whether the value is less than or equal to the specified value. |Number &#124; Date
IsNull |Returns the values that are null. |String &#124; Number &#124; Date
IsNotNull |Returns the values that are not null. |String &#124; Number &#124; Date
IsEmpty |Returns the values that are empty. |String
IsNotEmpty |Returns the values that are not empty. |String
Between |Filter the values based on the range between the start and end specified values. |Number &#124; Date

> By default, the **Operator** value is **Equal** in [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridFilterSettings.html#Syncfusion_Blazor_Grids_GridFilterSettings_Columns) property of `GridFilterSettings`.

## WildCard and Like operator filter

**WildCard** and **Like** filter operators filter value based on the given string pattern, and they apply to string-type columns. But it will work slightly differently.

### WildCard filtering

The **WildCard** filter can process one or more search patterns using the “*” symbol, retrieving values matching the specified patterns.

* The **WildCard** filter option is supported for the Grid that has all search options.

Operator |Description
-----|-----
a*b | Everything that starts with “a” and ends with “b”.
a* | Everything that starts with “a”.
*b | Everything that ends with “b”.
a | Everything that has an “a” in it.
ab* | Everything that has an “a” in it, followed by anything, followed by a “b”, followed by anything.

The following GIF represent a WildCard operator filtering.

![Blazor DataGrid with WildCard operator filtering.](./images/blazor-datagrid-wildcard-operator-filtering.gif)

### Like filtering

The Like filter can process single search patterns using the “%” symbol, retrieving values matching the specified patterns. The following Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid features support Like filtering on string-type columns:

* Filter Menu
* Filter Bar using the [Operator](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.FilterSettings.html#Syncfusion_Blazor_Grids_FilterSettings_Operator) property within the [GridFilterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_FilterSettings) configuration.
* Custom Filter of Excel filter type.

**For example**
Operator |Description
-----|-----|
%ab% | Returns all the value that are contains “ab” character.
ab% | Returns all the value that are ends with “ab” character.
%ab | Returns all the value that are starts with “ab” character.

The following GIF represent a Like operator filtering.

![Blazor DataGrid with like operator filtering.](./images/blazor-datagrid-like-operator-filtering.gif)

## Filtering with case sensitivity

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides the flexibility to enable or disable case sensitivity during filtering. This feature is useful when you want to control whether filtering operations should consider the case of characters. It can be achieved by using the [EnableCaseSensitivity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridFilterSettings.html#Syncfusion_Blazor_Grids_GridFilterSettings_EnableCaseSensitivity) property of [GridFilterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_FilterSettings).

Below is an example code demonstrating how to enable or disable case sensitivity while filtering:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<label> Enable Case Sensitivity</label>
<SfSwitch @bind-Checked="isChecked" OffLabel="OFF" OnLabel="ON" ValueChange="onToggleCaseSensitive" TChecked="bool?"></SfSwitch>

<SfGrid DataSource="@GridData" AllowFiltering="true" Height="273px">
    <GridFilterSettings EnableCaseSensitivity="@isCaseSensitive">
    </GridFilterSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipRegion) HeaderText="Ship Region" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {

    public List<OrderData> GridData { get; set; }

    private bool? isChecked = null;
    private bool isCaseSensitive = false;

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }
 
    private async Task onToggleCaseSensitive(Syncfusion.Blazor.Buttons.ChangeEventArgs<bool?> args)
    {
        if (args.Checked == true)
        {
            isCaseSensitive = true;
        }
        else
        {
            isCaseSensitive = false;
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();
    public OrderData(){}
    public OrderData(int? OrderID, string CustomerID, string ShipCity, string ShipCountry, string ShipRegion)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.ShipCity = ShipCity;
        this.ShipCountry = ShipCountry;
        this.ShipRegion = ShipRegion;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
            int OrderID = 10247;
            for (int i = 1; i < 2; i++)
            {
                Orders.Add(new OrderData(OrderID + 1, "VINET", "Reims", "France", "CJ"));
                Orders.Add(new OrderData(OrderID + 2, "TOMSP", "Münster", "Germany", "CJ"));
                Orders.Add(new OrderData(OrderID + 3, "HANAR", "Rio de Janeiro", "Brazil", "RJ"));
                Orders.Add(new OrderData(OrderID + 4, "VICTE", "Lyon", "Belgium", "RJ"));
                Orders.Add(new OrderData(OrderID + 5, "SUPRD", "Charleroi", "Switzerland", "SP"));
                Orders.Add(new OrderData(OrderID + 6, "HANAR", "Lyon", "Venezuela", "NM"));
                Orders.Add(new OrderData(OrderID + 7, "CHOPS", "Rio de Janeiro", "Austria", "CJ"));
                Orders.Add(new OrderData(OrderID + 8, "RICSU", "Münster", "Mexico", "RJ"));
                Orders.Add(new OrderData(OrderID + 9, "WELLI", "Reims", "USA", "SP"));
                OrderID += 9;
            }
        }
        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCountry { get; set; }
    public string ShipCity { get; set; }
    public string ShipRegion { get; set; }
}
    
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/htLpjMAsrilvEiin?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Enable different filter for a column

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid offers the flexibility to customize filtering behavior for different columns by enabling various types of filters such as **Menu**, **Excel**, **Checkbox**. This feature allows you to tailor the filtering experience to suit the specific needs of each column in your Grid. For example, you might prefer a menu-based filter for a category column, an Excel-like filter for a date column, and a checkbox filter for a status column.

It can be achieved by adjusting the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.FilterSettings.html#Syncfusion_Blazor_Grids_FilterSettings_Type) property within the [GridFilterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_FilterSettings) configuration based on your requirements.

Here’s an example where the menu filter is enabled by default for all columns, but you can dynamically modify the filter types through a `DropDownList`:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.DropDowns

<label>Select Column</label>
<SfDropDownList TValue="string" TItem="string" Width="130px" Placeholder="Eg: OrderID" DataSource="@ColumnData">
    <DropDownListEvents TValue="string" TItem="string" ValueChange="onFieldChange"></DropDownListEvents>
 </SfDropDownList>

<label>Select Filter Type</label>
<SfDropDownList TValue="string" TItem="string" Width="130px" Placeholder="Eg: Excel" Enabled="@flag" DataSource="@LocalData">
    <DropDownListEvents TValue="string" TItem="string" ValueChange="onTypeChange"></DropDownListEvents>
</SfDropDownList>

<SfGrid DataSource="@GridData" @ref="Grid" AllowFiltering="true" AllowPaging="true" Height="273px">
    <GridFilterSettings Type=" Syncfusion.Blazor.Grids.FilterType.Menu"></GridFilterSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" FilterSettings="OrderIDFilterSettings" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" FilterSettings="customerIDFilterSettings" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight"  FilterSettings="FreightFilterSettings" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText=" Order Date" Format="d" FilterSettings="OrderDateFilterSettings" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Verified) HeaderText="Verified" FilterSettings="VerifiedFilterSettings" Width="130" DisplayAsCheckBox="true" Type="Syncfusion.Blazor.Grids.ColumnType.Boolean"></GridColumn>
    </GridColumns>

</SfGrid>

@code {

    public List<OrderData> GridData { get; set; }

    SfGrid<OrderData> Grid;

    public bool flag = false;

    FilterSettings OrderIDFilterSettings = new FilterSettings { Type = Syncfusion.Blazor.Grids.FilterType.Menu};
    FilterSettings customerIDFilterSettings = new FilterSettings { Type = Syncfusion.Blazor.Grids.FilterType.Menu };
    FilterSettings FreightFilterSettings = new FilterSettings { Type = Syncfusion.Blazor.Grids.FilterType.Menu };
    FilterSettings OrderDateFilterSettings = new FilterSettings { Type = Syncfusion.Blazor.Grids.FilterType.Menu };
    FilterSettings VerifiedFilterSettings = new FilterSettings { Type = Syncfusion.Blazor.Grids.FilterType.Menu };

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    List<string> LocalData = new List<string>() { "Menu", "CheckBox ", "Excel" };

    List<string> ColumnData = new List<string>() { "OrderID", "CustomerID", "Freight", "OrderDate", "Verified" };

    public string SelectedColumn { get; set; } 
    public string SelectedOperator { get; set; }

    public async Task onFieldChange(ChangeEventArgs<string, string> args)
    {
        SelectedColumn = args.Value;
        flag = true;

    }
    public async Task onTypeChange(ChangeEventArgs<string, string> args)
    {
        SelectedOperator = args.Value;
        onSingleValueFilter();
    }
    public async Task onSingleValueFilter()
    {
       
        Syncfusion.Blazor.Grids.FilterType filterType;
        Enum.TryParse(SelectedOperator, out filterType);

        switch (SelectedColumn)
        {
            case "OrderID":
                OrderIDFilterSettings = new FilterSettings { Type = filterType };
                break;
            case "CustomerID":
                customerIDFilterSettings = new FilterSettings { Type = filterType };
                break;
                
            case "Freight":
                FreightFilterSettings = new FilterSettings { Type = filterType };
                break;

            case "OrderDate":
                OrderDateFilterSettings = new FilterSettings { Type = filterType };
                break;
            case "Verified":
                VerifiedFilterSettings = new FilterSettings { Type = filterType };
                break;
            default:
                
                break;
        }
        await Grid.Refresh();
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();
    public OrderData(){}

    public OrderData(int? OrderID, string CustomerID, DateTime? OrderDate, double? Freight, bool Verified)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.OrderDate = OrderDate;
        this.Freight = Freight;
        this.Verified = Verified;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
            int OrderID = 10247;
            for (int i = 1; i < 3; i++)
            {
                Orders.Add(new OrderData(OrderID + 1, "VINET", new DateTime(1996, 07, 06), 32.38, true));
                Orders.Add(new OrderData(OrderID + 2, "TOMSP", new DateTime(1996, 07, 06), 11.61, false));
                Orders.Add(new OrderData(OrderID + 3, "HANAR", new DateTime(1996, 07, 06), 65.83, false));
                Orders.Add(new OrderData(OrderID + 4, "VICTE", new DateTime(1996, 07, 06), 45.78, true));
                Orders.Add(new OrderData(OrderID + 5, "SUPRD", new DateTime(1996, 07, 06), 98.6, true));
                Orders.Add(new OrderData(OrderID + 6, "HANAR", new DateTime(1996, 07, 06), 103.45, false));
                Orders.Add(new OrderData(OrderID + 7, "CHOPS", new DateTime(1996, 07, 06), 103.45, true));
                Orders.Add(new OrderData(OrderID + 8, "RICSU", new DateTime(1996, 07, 06), 112.48, true));
                Orders.Add(new OrderData(OrderID + 9, "WELLI", new DateTime(1996, 07, 06), 33.45, false));
                OrderID += 9;
            }
        }
        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public DateTime? OrderDate { get; set; }
    public double? Freight { get; set; }
    public bool Verified { get; set; }
}
    
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BtrpjMMlByBHiEUG?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Change default filter operator for particular column

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides the flexibility to change the default filter operator for a particular column. By default, the filter operator for string-type columns is **StartsWith**, for numerical-type columns is **Equal**, and for boolean-type columns is also **Equal**. However, you may need to customize the filter operator to better match the nature of the data in a specific column. This can be achieved using the [Operator](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.FilterSettings.html#Syncfusion_Blazor_Grids_FilterSettings_Operator) property within the [GridFilterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_FilterSettings) configuration.

Here’s an example that demonstrates how to change the default filter operator column:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns

<label>Select Column</label>
<SfDropDownList TValue="string" TItem="string" Width="130px" Placeholder="Eg: OrderID" DataSource="@ColumnData">
    <DropDownListEvents TValue="string" TItem="string" ValueChange="onFieldChange"></DropDownListEvents>
</SfDropDownList>

<label>Select Operator</label>
<SfDropDownList TValue="string" TItem="string" Width="130px" Placeholder="Eg: Equal" Enabled="@flag" DataSource="@LocalData">
    <DropDownListEvents TValue="string" TItem="string" ValueChange="onOperatorChange"></DropDownListEvents>
</SfDropDownList>

<SfGrid DataSource="@GridData" @ref="Grid" AllowFiltering="true" Height="273px">
   
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" FilterSettings="OrderIDFilterSettings" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" FilterSettings="customerIDFilterSettings" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight"  FilterSettings="FreightFilterSettings" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" FilterSettings="ShipCityFilterSettings" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" FilterSettings="ShipCountryFilterSettings" Width="120"></GridColumn>
    </GridColumns>

</SfGrid>

@code {

    public List<OrderData> GridData { get; set; }

    SfGrid<OrderData> Grid;

    public bool flag = false;

    FilterSettings OrderIDFilterSettings = new FilterSettings { Operator = Syncfusion.Blazor.Operator.Equal};
    FilterSettings customerIDFilterSettings = new FilterSettings { Operator = Syncfusion.Blazor.Operator.StartsWith};
    FilterSettings FreightFilterSettings = new FilterSettings { Operator = Syncfusion.Blazor.Operator.Equal };
    FilterSettings ShipCityFilterSettings = new FilterSettings { Operator = Syncfusion.Blazor.Operator.StartsWith };
    FilterSettings ShipCountryFilterSettings = new FilterSettings { Operator = Syncfusion.Blazor.Operator.StartsWith };

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    List<string> LocalData = new List<string>();

    List<string> ColumnData = new List<string>() { "OrderID", "CustomerID", "Freight", "ShipCity", "ShipCountry" };

    public string SelectedColumn { get; set; } 
    public string SelectedOperator { get; set; }

    public async Task onFieldChange(ChangeEventArgs<string, string> args)
    {
        SelectedColumn = args.Value;
        if (args.Value == "OrderID" || args.Value == "Freight")
        {
            LocalData = new List<string>() { "Equal ", "NotEqual ", "GreaterThan ", "GreaterThanOrEqual", "LessThan ", " LessThanOrEqual" };
        }
        else
        {
            LocalData = new List<string>() { "StartsWith ", "EndsWith ", "Contains ", "Equal ", "NotEqual" };
        }

        flag = true;
    }
    public async Task onOperatorChange(ChangeEventArgs<string, string> args)
    {
        SelectedOperator = args.Value;
        onSingleValueFilter();
    }
    public async Task onSingleValueFilter()
    {
        Syncfusion.Blazor.Operator filterOperator;
        Enum.TryParse(SelectedOperator, out filterOperator);

        switch (SelectedColumn)
        {
            case "OrderID":
                OrderIDFilterSettings = new FilterSettings { Operator = filterOperator };
                break;
            case "CustomerID":
                customerIDFilterSettings = new FilterSettings { Operator = filterOperator };
                break;
                
            case "Freight":
                FreightFilterSettings = new FilterSettings { Operator = filterOperator };
                break;

            case "ShipCity":
                ShipCityFilterSettings = new FilterSettings { Operator = filterOperator };
                break;
            case "ShipCountry":
                ShipCountryFilterSettings = new FilterSettings { Operator = filterOperator };
                break;
            default:
                
                break;
        }

        await Grid.Refresh();
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();
    public OrderData(){}
    public OrderData(int? OrderID, string CustomerID, double? Freight, string ShipCity, string ShipCountry)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.Freight = Freight;
        this.ShipCity = ShipCity;
        this.ShipCountry = ShipCountry;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
            int OrderID = 10247;
            for (int i = 1; i < 3; i++)
            {
                Orders.Add(new OrderData(OrderID + 1, "VINET", 32.38, "Reims", "France"));
                Orders.Add(new OrderData(OrderID + 2, "TOMSP", 11.61, "Münster", "Germany"));
                Orders.Add(new OrderData(OrderID + 3, "HANAR", 65.83, "Rio de Janeiro", "Brazil"));
                Orders.Add(new OrderData(OrderID + 4, "VICTE", 45.78, "Lyon", "Belgium"));
                Orders.Add(new OrderData(OrderID + 5, "SUPRD", 98.6, "Charleroi", "Switzerland"));
                Orders.Add(new OrderData(OrderID + 6, "HANAR", 103.45, "Lyon", "Venezuela"));
                Orders.Add(new OrderData(OrderID + 7, "CHOPS", 103.45, "Rio de Janeiro", "Austria"));
                Orders.Add(new OrderData(OrderID + 8, "RICSU", 112.48, "Münster", "Mexico"));
                Orders.Add(new OrderData(OrderID + 9, "WELLI", 33.45, "Reims", "USA"));
                OrderID += 9;
            }
        }
        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public double? Freight { get; set; }
    public string ShipCountry { get; set; }
    public string ShipCity { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtLTXCAsUitWDKfU?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Filter Blazor DataGrid programmatically with single and multiple values using method

Programmatic filtering in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid with single and multiple values allows you to apply filters to specific columns in the Grid without relying on interactions through the interface.

This can be achieved by utilizing the [FilterByColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_FilterByColumnAsync_System_String_System_String_System_Object_System_String_System_Nullable_System_Boolean__System_Nullable_System_Boolean__System_Object_System_Object_) method of the Grid.

The following example demostrates, how to programmatically filter the Grid using single and multiple values for the **OrderID** and **CustomerID** columns. This is accomplished by calling the `FilterByColumnAsync` method within an external button click function:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="onSingleValueFilter">Filter with single value</SfButton>
<SfButton style="margin-left:5px" OnClick="onMultipleValueFilter"> Filter with multiple values</SfButton>

<SfGrid DataSource="@GridData" @ref="Grid" AllowFiltering="true" Height="273px">
    <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Excel"></GridFilterSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

@code {

    public List<OrderData> GridData { get; set; }

    SfGrid<OrderData> Grid;

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    public async Task onSingleValueFilter()
    {
        await Grid.ClearFilteringAsync();
        await Grid.FilterByColumnAsync("OrderID", "equal", 10248);
    }
    public async Task onMultipleValueFilter()
    {
        await Grid.ClearFilteringAsync();
        await Grid.FilterByColumnAsync("CustomerID", "equal", new List<string> { "VINET", "TOMSP", "ERNSH" });
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();
    public OrderData(){}

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
            int OrderID = 10247;
            for (int i = 1; i < 2; i++)
            {
                Orders.Add(new OrderData(OrderID+1, "VINET", "Reims", "Vins et alcools Chevali"));
                Orders.Add(new OrderData(OrderID+2, "TOMSP", "Münster", "Toms Spezialitäten"));
                Orders.Add(new OrderData(OrderID+3, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                Orders.Add(new OrderData(OrderID+4, "VICTE", "Lyon", "Victuailles en stock"));
                Orders.Add(new OrderData(OrderID+5, "SUPRD", "Charleroi", "Suprêmes délices"));
                Orders.Add(new OrderData(OrderID+6, "HANAR", "Lyon", "Hanari Carnes"));
                Orders.Add(new OrderData(OrderID+7, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
                Orders.Add(new OrderData(OrderID + 8, "ERNSH", "Münster", "Richter Supermarkt"));
                Orders.Add(new OrderData(OrderID+9, "WELLI", "Reims", "Wellington Import"));
                OrderID += 9;
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZVptiACLTgtLlbq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## How to get filtered records

Retrieving filtered records in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid is essential when you want to work with data that matches the currently applied filters. You can achieve this using available methods and properties in the Grid.

**1.Using the GetFilteredRecordsAsync() method**

The [GetFilteredRecordsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetFilteredRecordsAsync) method is used to obtain an array of records that match the currently applied filters on the Grid.

This method retrieves an array of records that match the currently applied filters on the Grid.

Here’s an example of how to get the filtering data in a Grid using the `GetFilteredRecordsAsync` method:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div style="text-align : center; color: red">
    <span>@message</span>
</div>
<br />

<SfButton CssClass="e-success" OnClick="click">Get Filtered Data</SfButton>
<SfButton CssClass="e-danger" OnClick="clear">Clear</SfButton>

<SfGrid DataSource="@GridData" @ref="Grid" AllowFiltering="true" AllowPaging="true" Height="280px">
    <GridPageSettings PageSize="10" PageCount="5" ></GridPageSettings>
    <GridEvents Filtering="FilteringHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID"  Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City"  Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@if (showRecords == true)
{
    <h3> Filtered Records</h3>

    <SfGrid DataSource="@FilterData" AllowFiltering="true" AllowPaging="true" Height="280px">
        <GridPageSettings PageSize="10" PageCount="5"></GridPageSettings>
        <GridColumns>
            <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
            <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
            <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" Width="90"></GridColumn>
            <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="120"></GridColumn>
        </GridColumns>

    </SfGrid>
}

@code {

    public List<OrderData> GridData { get; set; }

    public List<OrderData> FilterData { get; set; }

    SfGrid<OrderData> Grid;

    public bool flag = false;
    public bool showRecords = false;

    public string message;

    public async Task click()
    {
        if (flag == true)
        {

            var filteredRecords = Grid.GetFilteredRecordsAsync();
            FilterData = (List<OrderData>)filteredRecords.Result;
            showRecords = true;
            message = "";
        }

        else
        {
            showRecords = false;
            message = "No Records is filtered ";
        }

    }

    public async Task clear()
    {
        await Grid.ClearFilteringAsync();
        showRecords = false;
    }

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    public async Task FilteringHandler(FilteringEventArgs args)

    {
        if (args.FilterPredicates != null)
        {
            flag = true;
        }
        else
        {
            flag = false;
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();
    public OrderData(){}

    public OrderData(int? OrderID, string CustomerID, double? Freight, string ShipCity, string ShipCountry)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.Freight = Freight;
        this.ShipCity = ShipCity;
        this.ShipCountry = ShipCountry;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
            int OrderID = 10247;
            for (int i = 1; i < 7; i++)
            {
                Orders.Add(new OrderData(OrderID + 1, "VINET", 32.38, "Reims", "France"));
                Orders.Add(new OrderData(OrderID + 2, "TOMSP", 11.61, "Münster", "Germany"));
                Orders.Add(new OrderData(OrderID + 3, "HANAR", 65.83, "Rio de Janeiro", "Brazil"));
                Orders.Add(new OrderData(OrderID + 4, "VICTE", 45.78, "Lyon", "Belgium"));
                Orders.Add(new OrderData(OrderID + 5, "SUPRD", 98.6, "Charleroi", "Switzerland"));
                Orders.Add(new OrderData(OrderID + 6, "HANAR", 103.45, "Lyon", "Venezuela"));
                Orders.Add(new OrderData(OrderID + 7, "CHOPS", 103.45, "Rio de Janeiro", "Austria"));
                Orders.Add(new OrderData(OrderID + 8, "RICSU", 112.48, "Münster", "Mexico"));
                Orders.Add(new OrderData(OrderID + 9, "WELLI", 33.45, "Reims", "USA"));
                OrderID += 9;
            }
        }
        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public double? Freight { get; set; }
    public string ShipCountry { get; set; }
    public string ShipCity { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjhpZCiFKFFRoZzt?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**2.Using the GetFilteredRecordsAsync() method for remote data**

Use the [GetFilteredRecordsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetFilteredRecordsAsync) method to retrieve the details of the filtered records from the Grid. The `GetFilteredRecordsAsync` method returns the filtered records in the form of objects when using a remote data source. So, you need to deserialize the object to retrieve the filtered records.

```cshtml
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Buttons
@using Newtonsoft.Json

<div style="text-align : center; color: red">
    <span>@message</span>
</div>
<br />

<SfButton CssClass="e-success" OnClick="click">Get Filtered Data</SfButton>
<SfButton CssClass="e-danger" OnClick="clear">Clear</SfButton>

<SfGrid @ref="Grid" TValue="EmployeeData" ID="Grid" AllowFiltering="true" AllowPaging="true">
    <GridPageSettings PageSize="10" PageCount="5"></GridPageSettings>
    <GridEvents Filtering="FilteringHandler" TValue="EmployeeData"></GridEvents>
    <SfDataManager Url="https://services.odata.org/V4/Northwind/Northwind.svc/Orders/" Adaptor="Adaptors.ODataV4Adaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeData.OrderID) TextAlign="Syncfusion.Blazor.Grids.TextAlign.Center" HeaderText="Order ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.CustomerID) TextAlign="Syncfusion.Blazor.Grids.TextAlign.Center" HeaderText="Customer Name" Width="130"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.ShipCity) TextAlign="Syncfusion.Blazor.Grids.TextAlign.Center" HeaderText="ShipCity" Width="120"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.ShipName) HeaderText="Ship Name" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

@if (showRecords == true)
{
    <h3> Filtered Records</h3>

    <SfGrid DataSource="@FilterData" AllowFiltering="true" AllowPaging="true" Height="280px">
        <GridPageSettings PageSize="10" PageCount="5"></GridPageSettings>
        <GridColumns>
            <GridColumn Field=@nameof(EmployeeData.OrderID) TextAlign="Syncfusion.Blazor.Grids.TextAlign.Center" HeaderText="Order ID" Width="120"></GridColumn>
            <GridColumn Field=@nameof(EmployeeData.CustomerID) TextAlign="Syncfusion.Blazor.Grids.TextAlign.Center" HeaderText="Customer Name" Width="130"></GridColumn>
            <GridColumn Field=@nameof(EmployeeData.ShipCity) TextAlign="Syncfusion.Blazor.Grids.TextAlign.Center" HeaderText="ShipCity" Width="120"></GridColumn>
            <GridColumn Field=@nameof(EmployeeData.ShipName) HeaderText="Ship Name" Width="100"></GridColumn>
        </GridColumns>

    </SfGrid>
}

@code {
    SfGrid<EmployeeData> Grid;

    public List<EmployeeData> FilterData { get; set; }

    public bool flag = false;
    public bool showRecords = false;

    public string message;

    public async Task click()
    {
        if (flag == true)
        {
            var filteredData = await Grid.GetFilteredRecordsAsync();
            List<EmployeeData> filteredList = JsonConvert.DeserializeObject<List<EmployeeData>>(JsonConvert.SerializeObject(filteredData));
            FilterData = filteredList;
            showRecords = true;
            message = "";
        }

        else
        {
            showRecords = false;
            message = "No Records is filtered ";
        }

    }
    public async Task clear()
    {
        await Grid.ClearFilteringAsync();
        showRecords = false;
    }

    public async Task FilteringHandler(FilteringEventArgs args)

    {
        if (args.FilterPredicates != null)
        {
            flag = true;
        }
        else
        {
            flag = false;
        }
    }
   
    public class EmployeeData
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipName { get; set; }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXLTXiUChxbmPDxX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}.

**3.Using the properties in the  FilteredEventArgs object**

Alternatively, you can use the properties available in the  FilteredEventArgs object to obtain the filter record details.

* [ColumnName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.FilteredEventArgs.html#Syncfusion_Blazor_Grids_FilteredEventArgs_ColumnName): This property returns the column name that is currently filtered.

* [FilterPredicates](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.FilteredEventArgs.html#Syncfusion_Blazor_Grids_FilteredEventArgs_FilterPredicates): This property returns the object containing filter predicate model details that is currently filtered.

To access these properties, you can use the [Filtered](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_Filtered) event handler as shown below:

```cshtml
  public async Task FilteredHandler(FilteredEventArgs args)
    {
        var columnname = args.ColumnName;
        var FilterPredicates = args.FilterPredicates;
    }
```

## Clear filtering using methods

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides a method called [ClearFilteringAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ClearFilteringAsync) to clear the filtering applied to the Grid. This method is used to remove the filter conditions and reset the Grid to its original state.

Here’s an example of how to clear the filtering in a Grid using the `ClearFilteringAsync` method:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="onClick"> Clear Filter</SfButton>

<SfGrid @ref="Grid" DataSource="@GridData" AllowSorting="true"  AllowFiltering="true" AllowPaging="true">
   <GridPageSettings PageSize="6"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }
    SfGrid<OrderData>? Grid { get; set; }

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    private async Task onClick()
    {
        await Grid.ClearFilteringAsync();
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();
    public OrderData(){}

    public OrderData(int? OrderID, string CustomerID, double? Freight, string ShipCountry)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.Freight = Freight;
        this.ShipCountry = ShipCountry;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
            int OrderID = 10248;
            for (int i = 1; i < 3; i++)
            {
                Orders.Add(new OrderData(OrderID + 1, "VINET", 32.38, "France"));
                Orders.Add(new OrderData(OrderID + 2, "TOMSP", 11.61, "Germany"));
                Orders.Add(new OrderData(OrderID + 3, "HANAR", 65.83, "Brazil"));
                Orders.Add(new OrderData(OrderID + 4, "VICTE", 45.78, "Belgium"));
                Orders.Add(new OrderData(OrderID + 5, "SUPRD", 98.6, "Switzerland"));
                Orders.Add(new OrderData(OrderID + 6, "HANAR", 103.45, "Venezuela"));
                Orders.Add(new OrderData(OrderID + 7, "CHOPS", 103.45, "Austria"));
                Orders.Add(new OrderData(OrderID + 8, "RICSU", 112.48, "Mexico"));
                Orders.Add(new OrderData(OrderID + 9, "WELLI", 33.45, "USA"));
                OrderID += 9;
            }
        }
        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCountry { get; set; }
    public double? Freight { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZVptMsmVVFUgOdG?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Filtering events

Filtering events allow you to customize the behavior of the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid when filtering is applied. You can prevent filtering for specific columns, show messages to users, or perform other actions to suit your application’s needs.

To implement filtering events in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid, you can utilize the available events such as [Filtering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_Filtering) and [Filtered](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_Filtered). These events allow you to intervene in the filtering process and customize it as needed.

In the given example, the filtering is prevented for ShipCity column during `Filtering` event:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<div style="text-align : center; color: red">
    <span>@message</span>
  
</div>
<br />

<SfGrid DataSource="@GridData" @ref="Grid" AllowFiltering="true" Height="273px">
    <GridEvents Filtering="FilteringHandler" Filtered="FilteredHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

@code {

    public List<OrderData> GridData { get; set; }

    SfGrid<OrderData> Grid;

    public string message;

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    public async Task FilteringHandler(FilteringEventArgs args)

    {
        if (args.ColumnName == "ShipCity")
        {
            args.Cancel = true;
            message = "The Filtering event has been triggered and the filtering action is cancelled for " +args.ColumnName;
        }
    }

    public async Task FilteredHandler(FilteredEventArgs args)
    {
        if(args.FilterPredicates != null)
        {
            message = "The actionComplete event has been triggered and the filtering action for the" + args.ColumnName + "column has been successfully executed";
        }
        else
        {
            message = " ";
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}
 
public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();
    public OrderData(){}

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
            int OrderID = 10248;
            for (int i = 1; i < 2; i++)
            {
                Orders.Add(new OrderData(OrderID+1, "VINET", "Reims", "Vins et alcools Chevali"));
                Orders.Add(new OrderData(OrderID+2, "TOMSP", "Münster", "Toms Spezialitäten"));
                Orders.Add(new OrderData(OrderID+3, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                Orders.Add(new OrderData(OrderID+4, "VICTE", "Lyon", "Victuailles en stock"));
                Orders.Add(new OrderData(OrderID+5, "SUPRD", "Charleroi", "Suprêmes délices"));
                Orders.Add(new OrderData(OrderID+6, "HANAR", "Lyon", "Hanari Carnes"));
                Orders.Add(new OrderData(OrderID+7, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
                Orders.Add(new OrderData(OrderID+8, "RICSU", "Münster", "Richter Supermarkt"));
                Orders.Add(new OrderData(OrderID+9, "WELLI", "Reims", "Wellington Import"));
                OrderID += 9;
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjVJDMMmLnklDAQG?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Filter enum column

Filter the enum type data in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid column using the Filter Template feature of the Grid.

In the following sample, the `SfDropDownList` is rendered in the [FilterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_FilterTemplate) for the Type column. The enumerated list data can be bound to the Type column. In the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_ValueChange) event of the `SfDropDownList`, dynamically filter the Type column using the [FilterByColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_FilterByColumnAsync_System_String_System_String_System_Object_System_String_System_Nullable_System_Boolean__System_Nullable_System_Boolean__System_Object_System_Object_) method of the Grid.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns

<SfGrid DataSource="@GridData" @ref="Grid" AllowFiltering="true" Height="273px">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Type) HeaderText="Type" Type="Syncfusion.Blazor.Grids.ColumnType.String" Width="130">
            <FilterTemplate>
                <SfDropDownList Placeholder="Type" ID="Type" Value="@((string)(context as PredicateModel).Value)" DataSource="@FilterDropData" TValue="string" TItem="Data">
                    <DropDownListEvents TItem="Data" ValueChange="Change" TValue="string"></DropDownListEvents>
                    <DropDownListFieldSettings Value="Type" Text="Type"></DropDownListFieldSettings>
                </SfDropDownList>
            </FilterTemplate>
        </GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public SfGrid<OrderData> Grid;
    public List<OrderData> GridData { get; set; }
    List<Data> FilterDropData = new List<Data>
    {
        new Data() { Type= "All" },
        new Data() { Type= "Base" },
        new Data() { Type= "Replace" },
        new Data() { Type= "Delta" }
    };

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    public async Task Change(ChangeEventArgs<string, Data> args)
    {
        if (args.Value == "All")
        {
            await this.Grid.ClearFilteringAsync();
        }
        else
        {
            await this.Grid.FilterByColumnAsync("Type", "contains", args.Value);
        }
    }

    public class Data
    {
        public string Type { get; set; }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();
    public OrderData(){}

    public OrderData(int? OrderID, string CustomerID, string ShipCity, string ShipName, FileType type)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.ShipCity = ShipCity;
        this.ShipName = ShipName;
        this.Type = type;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
            int OrderID = 10248;
            for (int i = 1; i < 3; i++)
            {
                Orders.Add(new OrderData(OrderID + 1, "VINET", "Reims", "Vins et alcools Chevalier", FileType.Base));
                Orders.Add(new OrderData(OrderID + 2, "TOMSP", "Münster", "Toms Spezialitäten", FileType.Replace));
                Orders.Add(new OrderData(OrderID + 3, "HANAR", "Rio de Janeiro", "Hanari Carnes", FileType.Delta));
                Orders.Add(new OrderData(OrderID + 4, "VICTE", "Lyon", "Victuailles en stock", FileType.Base));
                Orders.Add(new OrderData(OrderID + 5, "SUPRD", "Charleroi", "Suprêmes délices", FileType.Replace));
                Orders.Add(new OrderData(OrderID + 6, "HANAR", "Lyon", "Hanari Carnes", FileType.Delta));
                Orders.Add(new OrderData(OrderID + 7, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese", FileType.Base));
                Orders.Add(new OrderData(OrderID + 8, "RICSU", "Münster", "Richter Supermarkt", FileType.Replace));
                Orders.Add(new OrderData(OrderID + 9, "WELLI", "Reims", "Wellington Import", FileType.Delta));

                OrderID += 9;
            }
        }
        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
    public FileType Type { get; set; }
}

public enum FileType : short
{
    Base = 1,
    Replace = 2,
    Delta = 3
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNhTDiriFpkNhDml?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}.

## See also

* [How to Perform Multiple Value Filtering for Same Column in Grid](https://support.syncfusion.com/kb/article/10996/how-to-perform-multiple-value-filtering-for-same-column-in-grid?isInternalRefresh=False)
