---
layout: post
title: Grouping in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Grouping in Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Grouping in Blazor DataGrid Component

The grouping feature in the Syncfusion Blazor DataGrid allows you to organize data into a hierarchical structure, making it easier to expand and collapse records. You can group the columns by simply dragging and dropping the column header to the group drop area. To enable grouping in the grid, you need to set the [AllowGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowGrouping) property to **true**. Additionally, you can customize the grouping options using the [GridGroupSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GroupSettings) component.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowGrouping="true" Height="400">
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjLgDxhChQSxbQyx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * You can group and ungroup columns by using the **GroupColumn** and **UngroupColumn** methods.
> * To disable grouping for a particular column, set the [AllowGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowGrouping) to false in **GridColumn** component.

## Initial group

To enable initial grouping in the DataGrid, you can use the [GridGroupSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html) component and set the GridGroupSettings [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html#Syncfusion_Blazor_Grids_GridGroupSettings_Columns) property to a string array of column names(field of the column) that you want to group by. This feature is particularly useful when working with large datasets, as it allows you to quickly organize and analyze the data based on specific criteria.

The following example demonstrates how to set an initial grouping for the **CustomerID** and **ShipCountry** columns during the initial rendering grid, by using the `GridGroupSettings` component of the `Columns` property.

```cshtml
@using Syncfusion.Blazor.Grids

@{
    var Initial = (new string[] { "OrderID", "ShipCountry" });
}
<SfGrid DataSource="@Orders" AllowGrouping="true" Height="400">
    <GridGroupSettings Columns="@Initial"></GridGroupSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
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
                ShipCountry = (new string[] { "USA", "UK", "JAPAN" })[new Random().Next(3)],
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string? ShipCountry { get; set; }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZVgZmsvrThKRsiL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> You can group by multiple columns by specifying a string array of column names in the columns property of the `GridGroupSettings` component.

## Prevent grouping for particular column

The DataGrid component provides the ability to prevent grouping for a particular column. This can be useful when you have certain columns that you do not want to be included in the grouping process. It can be achieved by setting the [AllowGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowGrouping) property of the particular `Column` to **false**. The following example demonstrates, how to disable grouping for **CustomerID** column. 

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowGrouping="true" Height="400">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" AllowGrouping="false" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
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
                ShipCountry = (new string[] { "USA", "UK", "JAPAN" })[new Random().Next(3)],
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string? ShipCountry { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hjBgtQsFrIHAbUoy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


## Hide drop area

By default, the DataGrid provides a drop area for grouping columns. This drop area allows you to drag and drop columns to group and ungroup them. However, in some cases, you may want to prevent ungrouping or further grouping a column after initial grouping.

To hide the drop area in the Syncfusion Blazor Grid, you can set the `GridGroupSettings` component of the [ShowDropArea](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html#Syncfusion_Blazor_Grids_GridGroupSettings_ShowDropArea) property to **false**. 

The following example demonstrates how to set the `GridGroupSettings` component of the `ShowDropArea` property to **false** to hide the drop area.


```cshtml
@using Syncfusion.Blazor.Grids

@{
    var Hide = (new string[] {"Freight"});
}
<SfGrid DataSource="@Orders" AllowGrouping="true" Height="400">
    <GridGroupSettings ShowDropArea="false" Columns=@Hide></GridGroupSettings>
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZVgXdrMhFNlisyU?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> By default, the group drop area will be shown only if there is at least one column available to group.

## Show the grouped column

The Syncfusion Blazor DataGrid has a default behavior where the grouped column is hidden, to provide a cleaner and more focused view of your data. However, if you prefer to show the grouped column in the grid, you can achieve this by setting the `GridGroupSettings` component of the [ShowGroupedColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html#Syncfusion_Blazor_Grids_GridGroupSettings_ShowGroupedColumn) property to **true**.

In the following example, the [Blazor Toggle Switch Button](https://blazor.syncfusion.com/documentation/toggle-switch-button/getting-started) component is added to hide or show the grouped columns. When the switch is toggled, the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChangeEventArgs-1.html) event is triggered and the `GridGroupSettings` component of the showGroupedColumn property of the grid is updated accordingly. 

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div style="display:flex;gap: 5px;">
    <label> Hide or show grouped columns</label>
    <SfSwitch OffLabel="OFF" OnLabel="ON" ValueChange="Change" TChecked="bool?"></SfSwitch>
</div>
@{
    var columns = (new string[] { "OrderID", "ShipCountry" });
}
<SfGrid @ref="Grid" DataSource="@Orders" AllowGrouping="true" Height="400">
    <GridGroupSettings Columns="@columns" ShowGroupedColumn=@IsShow></GridGroupSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" AllowGrouping="false" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {

    public SfGrid<Order>? Grid { get; set; }
    public List<Order> Orders { get; set; }

    public bool IsShow { get; set; } = true;

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
                Freight = 2.1 * x,
                OrderDate = DateTime.Now.AddDays(-x),
                ShipCountry = (new string[] { "USA", "UK", "JAPAN" })[new Random().Next(3)],
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string? ShipCountry { get; set; }
    }

    private void Change(Syncfusion.Blazor.Buttons.ChangeEventArgs<bool?> args)
    {
        if (args.Checked == true)
        {
            IsShow = false;
            Grid.Refresh();
        }
        else
        {
            IsShow = true;
            Grid.Refresh();
        }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXBADGMbULplRnqO?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Sort grouped columns in descending order during initial grouping

By default, grouped columns are sorted in ascending order. However, you can sort them in descending order during initial grouping by setting the [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortColumn.html#Syncfusion_Blazor_Grids_GridSortColumn_Field) and [Direction](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortColumn.html#Syncfusion_Blazor_Grids_GridSortColumn_Direction) in the `GridSortSettings` component of the [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortSettings.html#Syncfusion_Blazor_Grids_GridSortSettings_Columns) property.

The following example demonstrates how to sort the **CustomerID** column by setting the `GridSortSettings` component of the `Columns` property to **Descending** during the initial grouping of the Datagrid.

```cshtml
@using Syncfusion.Blazor.Grids

@{
    var columns = (new string[] { "CustomerID" });
}
<SfGrid  DataSource="@Orders" AllowGrouping="true" AllowSorting="true" Height="400">
    <GridGroupSettings Columns="@columns"></GridGroupSettings>
    <GridSortSettings>
        <GridSortColumns>
            <GridSortColumn Field="CustomerID" Direction="SortDirection.Descending"></GridSortColumn>
        </GridSortColumns>
    </GridSortSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" AllowGrouping="false" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
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
                ShipCountry = (new string[] { "USA", "UK", "JAPAN" })[new Random().Next(3)],
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string? ShipCountry { get; set; }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXVUXGCFgfnvgMZk?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Group by format

By default, columns are grouped by the data or value present for the particular row. However, you can also group numeric or datetime columns based on the specified format. To enable this feature, you need to set the [EnableGroupByFormat](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_EnableGroupByFormat)
property of the corresponding grid column. This feature allows you to group numeric or datetime columns based on a specific format.

The following example demonstrates how to perform a group action using the `EnableGroupByFormat` property for the  **OrderDate** and **Freight** columns of the grid. 

```cshtml
@using Syncfusion.Blazor.Grids

@{
    var Format = (new string[] {"OrderDate", "Freight" });
}
<SfGrid DataSource="@Orders" AllowGrouping="true" Height="400">
    <GridGroupSettings ShowDropArea="false" Columns=@Format></GridGroupSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="yyyy/MMM" Type="ColumnType.Date" EnableGroupByFormat="true" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" EnableGroupByFormat="true" Width="120"></GridColumn>
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

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNBUXwsvUFqMNGGB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> Numeric columns can be grouped based on formats such as currency or percentage, while datetime columns can be grouped based on specific date or time formats.

## Group or Ungroup column externally

By default, the Syncfusion DataGrid supports interaction-oriented column grouping, where users manually group columns by dragging and dropping them into the grouping area of the grid. Grid provides an ability to group and ungroup a column using [GroupColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GroupColumnAsync_System_String_) and [UngroupColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_UngroupColumnAsync_System_String_) methods. These methods provide a programmatic approach to perform column grouping and ungrouping.

The following example demonstrates how to group and upgroup the columns in a grid. It utilizes the [DropDownList](https://blazor.syncfusion.com/documentation/dropdown-list/getting-started) component to select the column. When an external button is clicked, the `GroupColumnAsync` and `UngroupColumnAsync` methods are called to group or ungroup the selected column.

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.DropDowns

<div style="display:flex;gap: 5px;">
    <label> Column name :</label>
<SfDropDownList TValue="string" TItem="Columns" Width="300px" Placeholder="Select a Column" DataSource="@LocalData" @bind-Value="@DropDownValue">
    <DropDownListFieldSettings Value="ID" Text="Value"></DropDownListFieldSettings>
</SfDropDownList>

<SfButton OnClick="GroupColumn">Group column</SfButton>

<SfButton OnClick="UnGroupColumn">UnGroup column</SfButton>
</div>

<SfGrid @ref="Grid"  TValue="Order" DataSource="@Orders" AllowGrouping="true" Height="400">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date"  TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right"  Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<Order> Orders { get; set; }
    SfGrid<Order>? Grid { get; set; }
    public string DropDownValue { get; set; } = "OrderID";
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
    List<Columns> LocalData = new List<Columns>
    {
        new Columns() { ID= "OrderID", Value= "OrderID" },
        new Columns() { ID= "CustomerID", Value= "CustomerID" },
        new Columns() { ID= "Freight", Value= "Freight" },
        new Columns() { ID= "OrderDate", Value= "OrderDate" },
    };

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
    public class Columns
    {
        public string ID { get; set; }
        public string Value { get; set; }
    }

    public async Task GroupColumn()
    {
        await Grid.GroupColumnAsync(DropDownValue);
        
    }

    public async Task  UnGroupColumn()
    {
       await Grid.UngroupColumnAsync(DropDownValue);
    }

}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rNLKZcsFfhSXRSPK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Expand or collapse externally

The Syncfusion Blazor DataGrid offers a convenient feature to expand or collapse grouped rows, allowing you to control the visibility of grouped data. This section will provide guidance on enabling this functionality and integrating it into your application using the Grid properties and methods.

### Expand or collapse all grouped rows

DataGrid provides an ability to expand or collapse grouped rows using [ExpandAllGroupAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExpandAllGroupAsync) and [CollapseAllGroupAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_CollapseAllGroupAsync) methods respectively.

In the following example, the [Blazor Toggle Switch Button](https://blazor.syncfusion.com/documentation/toggle-switch-button/getting-started) component is added to expand or collapse grouped rows. When the switch is toggled, the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChangeEventArgs-1.html) event is triggered and the `ExpandAllGroupAsync` and `CollapseAllGroupAsync` methods are called to expand or collapse grouped rows. 

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div style="display:flex;gap:10px">
    <label>  Expand or collapse rows </label>
    <SfSwitch OffLabel="OFF" OnLabel="ON" ValueChange="Change" TChecked="bool?"></SfSwitch>
</div>

@{
    var columns = (new string[] { "OrderID", "ShipCountry" });
}
<SfGrid @ref="Grid" DataSource="@Orders" AllowGrouping="true" Height="400">
    <GridGroupSettings Columns="@columns"></GridGroupSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" AllowGrouping="false" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {

    public SfGrid<Order>? Grid { get; set; }
    public List<Order> Orders { get; set; }

    public bool IsShow { get; set; } = true;

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
                Freight = 2.1 * x,
                OrderDate = DateTime.Now.AddDays(-x),
                ShipCountry = (new string[] { "USA", "UK", "JAPAN" })[new Random().Next(3)],
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string? ShipCountry { get; set; }
    }

    private void Change(Syncfusion.Blazor.Buttons.ChangeEventArgs<bool?> args)
    {
        if (args.Checked == true)
        {
            Grid.CollapseAllGroupAsync();
        }
        else
        {
            Grid.ExpandAllGroupAsync();
        }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXhqZQMFpzMFbRMT?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Clear grouping 

The clear grouping feature in the Syncfusion Blazor DataGrid allows you to removing all the grouped columns from the grid. This feature provides a convenient way to clear the grouping of columns in your application.

To clear all the grouped columns in the Grid, you can utilize the [ClearGroupingAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ClearGroupingAsync) method of the grid.

The following example demonstrates how to clear the grouping using `ClearGroupingAsync` method in the external button click.

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="ClearGrouping"> Clear Grouping</SfButton>
@{
    var columns = (new string[] { "OrderID", "ShipCountry" });
}
<SfGrid @ref="Grid" DataSource="@Orders" AllowGrouping="true" Height="400">
    <GridGroupSettings Columns="@columns"></GridGroupSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" AllowGrouping="false" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {

    public SfGrid<Order>? Grid { get; set; }
    public List<Order> Orders { get; set; }

    public bool IsShow { get; set; } = true;

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
                Freight = 2.1 * x,
                OrderDate = DateTime.Now.AddDays(-x),
                ShipCountry = (new string[] { "USA", "UK", "JAPAN" })[new Random().Next(3)],
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string? ShipCountry { get; set; }
    }

    private async Task ClearGrouping()
    {
        await Grid.ClearGroupingAsync();
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXVUNmsbfRMgYjJH?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Grouping events

The DataGrid component provides two events that are triggered during the group action such as [OnActionBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html) and [OnActionComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html). The `OnActionBegin` event is triggered before the group action starts, and the `OnActionComplete` event is triggered after the group action is completed. You can use these events to perform any custom action based on the grouping.

1. **OnActionBegin Event**: `OnActionBegin` event is triggered before the group action begins. It provides a way to perform any necessary operations before the group action takes place. This event provides a parameter that contains the current grid state, including the current group field name, requestType information and etc.

2. **OnActionComplete Event**: `OnActionComplete` event is triggered after the group action is completed. It provides a way to perform any necessary operations after the group action has taken place. This event provides a parameter that contains the current grid state, including the grouped data and column information and etc.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowGrouping="true">
    <GridEvents OnActionComplete="GroupActionHandler" OnActionBegin="GroupActionHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
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
            ShipCountry = (new string[] { "USA", "UK", "JAPAN" })[new Random().Next(3)],
        }).ToList();
    }

    public class Order {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCountry { get; set; }
    }
    public void GroupActionHandler(ActionEventArgs<Order> args){
        // You can get args.RequestType and other details.
    }
}
```
> [args.RequestType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ActionEventArgs-1.html#Syncfusion_Blazor_Grids_ActionEventArgs_1_RequestType) property represents the name of the current action being performed. For instance, during grouping, the `args.RequestType` value will be **grouping**.

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNLgDnhiBuxVmGDp?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## See Also

* [Exporting grouped records](https://blazor.syncfusion.com/documentation/datagrid/excel-exporting#exporting-grouped-records)

> You can refer to our [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap4) to understand how to present and manipulate data.