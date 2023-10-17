---
layout: post
title: Searching in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Searching in Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Searching in Blazor DataGrid Component

You can search records in a DataGrid, by using the **Search** method with search key as a parameter. This also provides an option to integrate search text box in datagrid's toolbar by adding **Search** item to the [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Toolbar).

```cshtml
@using Syncfusion.Blazor.Grids

@{
    var Tool = (new List<string>() { "Search" });
}
<SfGrid DataSource="@Orders" Toolbar=@Tool>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
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

    public class Order {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

The following GIF image represents a DataGrid Searching.

![Searching in Blazor DataGrid](images/blazor-datagrid-searching.gif)

## Initial search

To apply search at initial rendering, set the **Fields**, **Operator**, **Key**, and **IgnoreCase** using [GridSearchSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSearchSettings.html) component.

```cshtml
@using Syncfusion.Blazor.Grids

@{
    var InitSearch = (new string[] { "CustomerID" });
    var Tool = (new List<string>() { "Search" });
}
<SfGrid DataSource="@Orders" Toolbar=@Tool>
    <GridSearchSettings Fields=@InitSearch Operator=Syncfusion.Blazor.Operator.Contains Key="anton" IgnoreCase="true"></GridSearchSettings>
            <GridColumns>
                <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
                <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
                <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
                <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
            </GridColumns>
</SfGrid>

@code{
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

    public class Order {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

The following screenshot represents a DataGrid with initial searching.

![Blazor DataGrid with Initial Search](./images/blazor-datagrid-initial-search.png)

N> By default, datagrid searches all the bound column values. To customize this behavior, define the [Fields](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSearchSettings.html#Syncfusion_Blazor_Grids_GridSearchSettings_Fields) property of **GridSearchSettings** component.

## Search operators

The search operator can be defined in the [Operator](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSearchSettings.html#Syncfusion_Blazor_Grids_GridSearchSettings_Operator) property of **GridSearchSettings** to configure specific searching.

The following operators are supported in searching:

Operator |Description
-----|-----
StartsWith |Checks whether a value begins with the specified value.
EndsWith |Checks whether a value ends with the specified value.
Contains |Checks whether a value contains the specified value.
Equal |Checks whether a value is equal to the specified value.
NotEqual |Checks for values not equal to the specified value.

N> By default, the [Operator](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSearchSettings.html#Syncfusion_Blazor_Grids_GridSearchSettings_Operator) value is **Contains**.

## Search by external button

To search datagrid records from an external button, invoke the **Search** method.

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids

@{
    var Tool = (new List<string>() { "Search" });
}
<SfButton Content="Search" OnClick="SearchBtnHandler"></SfButton>
<SfGrid @ref="DefaultGrid" DataSource="@Orders" AllowSorting="true" Toolbar=@Tool>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;

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

    public class Order {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }

    public void SearchBtnHandler()
    {
        this.DefaultGrid.Search("1001");
    }
}
```

## Search specific columns

By default, datagrid searches all visible columns. You can search specific columns by defining the specific column's field names in the [Fields](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSearchSettings.html#Syncfusion_Blazor_Grids_GridSearchSettings_Fields) property of **GridSearchSettings** component.

```cshtml
@using Syncfusion.Blazor.Grids

@{
    var Tool = (new List<string>() { "Search" });
    var SpecificCols = (new string[] { "CustomerID","ShipCountry"});
}
<SfGrid DataSource="@Orders" Toolbar=@Tool>
    <GridSearchSettings Fields=@SpecificCols></GridSearchSettings>
            <GridColumns>
                <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
                <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
                <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
                <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
                <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" Width="120"></GridColumn>
            </GridColumns>
</SfGrid>

@code{
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
            ShipCountry = (new string[] { "USA", "UK", "CHINA", "RUSSIA", "INDIA" })[new Random().Next(5)]
        }).ToList();
    }

    public class Order {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCountry { get; set; }
    }
}
```

## Disable search for particular column

By default, DataGrid searches all visible columns. You can disable searching for a particular column by setting the [AllowSearching](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowSearching) property of **GridColumn** as false.

In the below code example, the **Order ID** column search functionality is disabled.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Toolbar="@(new List<string>() { "Search" })">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" AllowSearching="false" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>

</SfGrid>

@code{
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

    public class Order {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

N> You can refer to our [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap5) to understand how to present and manipulate data.

## Immediate searching

By default, the datagrid will initiate searching operation after the Enter key is pressed. If you want to initiate the searching operation while typing the values in the search box, then you can invoke the Search method of the datagrid in the Input event of the SfTextBox.

```cshtml
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Navigations

<SfGrid @ref="DefaultGrid" DataSource="@Orders" AllowSorting="true" AllowFiltering="true" AllowPaging="true">
    <SfToolbar>
        <ToolbarItems>
            <ToolbarItem Type="ItemType.Input" Align="Syncfusion.Blazor.Navigations.ItemAlign.Right">
                <Template>
                    <SfTextBox Placeholder="Enter values to search" Input="OnInput"></SfTextBox>
                    <span class="e-search-icon e-icons"></span>
                </Template>
            </ToolbarItem>
        </ToolbarItems>
    </SfToolbar>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="@TextAlign.Center" Width="140"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Verified) HeaderText="Freight" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;

    public List<Order> Orders { get; set; }

    public void OnInput(InputEventArgs args)
    {
        this.DefaultGrid.Search(args.Value);
    }

    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public bool Verified { get; set; }
        public double? Freight { get; set; }
    }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Verified = (new bool[] { true, false })[new Random().Next(2)],
            Freight = 2.1 * x,
        }).ToList();
    }
}
```
