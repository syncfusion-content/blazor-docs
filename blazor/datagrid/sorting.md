---
layout: post
title: Sorting in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Sorting in Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Sorting in Blazor DataGrid Component

The DataGrid component provides built-in support for sorting data-bound columns in ascending or descending order. To enable sorting in the Datagrid, set the [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowSorting) property to **true**.

To sort a particular column in the DataGrid, click on its column header. Each time you click the header, the order of the column will switch between **Ascending** and **Descending**.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid  DataSource="@Orders" AllowSorting="true" Height="270">
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjhAtnLrCcWEZBCb?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * DataGrid columns are sorted in the **Ascending** order. If you click the already sorted column, then toggles the sort direction..
> * You can apply and clear sorting by using the [SortColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SortColumnAsync_System_String_Syncfusion_Blazor_Grids_SortDirection_System_Nullable_System_Boolean__) and [ClearSortingAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ClearSortingAsync) methods.
> * To disable sorting for a particular column, set the [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowSorting) property of **GridColumn** to false.

## Initial sort

By default, the DataGrid component does not apply any sorting to its records at initial rendering. However, you can set the [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortColumn.html#Syncfusion_Blazor_Grids_GridSortColumn_Field) and [Direction](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortColumn.html#Syncfusion_Blazor_Grids_GridSortColumn_Direction) in [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortSettings.html#Syncfusion_Blazor_Grids_GridSortSettings_Columns) property of **GridSortSettings** component.. This feature is helpful when you want to display your data in a specific order when the grid is first loaded.

The following example demonstrates how to set the **GridSortSettings** component of the  [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortSettings.html#Syncfusion_Blazor_Grids_GridSortSettings_Columns) for **OrderDate** and **Freight** columns with a specified [Direction](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortColumn.html#Syncfusion_Blazor_Grids_GridSortColumn_Direction).


```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowSorting="true" Height="270">
     <GridSortSettings>
        <GridSortColumns>
            <GridSortColumn Field="OrderDate" Direction="SortDirection.Ascending"></GridSortColumn>
            <GridSortColumn Field="Freight" Direction="SortDirection.Descending"></GridSortColumn>
        </GridSortColumns>
    </GridSortSettings>
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjhUNnrhicoBFLef?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> The initial sorting defined in the `GridSortSettings` component of the  [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortSettings.html#Syncfusion_Blazor_Grids_GridSortSettings_Columns) will override any sorting applied through user interaction.

## Multi-column sorting

The Grid component allows to sort more than one column at a time using multi-column sorting. To enable multi-column sorting in the grid, set the [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowSorting) property to **true**, and set the [AllowMultiSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowMultiSorting) property to **true** which enable the user to sort multiple columns by hold the **CTRL** key and click on the column headers. This feature is useful when you want to sort your data based on multiple criteria to analyze it in various ways.

To clear multi-column sorting for a particular column, press the "Shift + mouse left click".

> The [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowSorting) must be **true** while enabling multi-column sort.
> Set [AllowMultiSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowMultiSorting) property as **false** to disable multi-column sorting.

```csharp

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowSorting="true" AllowMultiSorting="true" Height="270">
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXVqNRLVMlRgPzPB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Prevent sorting for particular column

The DataGrid component provides the ability to prevent sorting for a particular column. This can be useful when you have certain columns that you do not want to be included in the sorting process.

It can be achieved by setting the [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowSorting) property of the particular column to **false**.

The following example demonstrates, how to disable sorting for **CustomerID** column.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowSorting="true" Height="270">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" AllowSorting="false" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXVqjPjbqEvgyBSP?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Sort order

By default, the sorting order will be as **Ascending -> Descending -> None**.

When you click on a column header for the first time, it sorts the column in ascending order. Clicking the same column header again will sort the column in descending order. A repetitive third click on the same column header will clear the sorting.

## Custom sorting 

The DataGrid component provides a way to customize the default sort action for a column by defining the [SortComparer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnModel.html#Syncfusion_Blazor_Grids_ColumnModel_SortComparer) property of GridColumn Directive.The SortComparer data type was the IComparer interface, so the custom sort comparer class should be implemented in the interface [IComparer](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.icomparer-1?view=net-5).

The following example demonstrates how to define custom sort comparer function for the **CustomerID** column.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowSorting="true" Width="600" Height="270">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) Visible="false" HeaderText="Order ID" Width="80"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) SortComparer="new CustomComparer()" HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date"  Width="100"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2"  Width="80"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="ShipCountry" Format="C2"  Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 10).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
            ShipCountry = (new string[] {"USA","UK","INDIA","CHINA","ENGLAND"})[new Random().Next(5)],
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCountry { get; set; }
    }

    public class CustomComparer : IComparer<Object>
    {
        public int Compare(object XRowDataToCompare, object YRowDataToCompare)
        {
            Order XRowData = XRowDataToCompare as Order;
            Order YRowData = YRowDataToCompare as Order;
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
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LthKDxVriaVxqpEP?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * The CustomSortComparer function takes two parameters: a and b. The a and b parameters are the values to be compared. The function returns -1, 0, or 1, depending on the comparison result.
> * The SortComparer property will work only for local data.
<br/> When using the column template to display data in a column, you will need to use the [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Field) property of [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) to work with the [SortComparer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_SortComparer) property.

## Touch interaction

When you tap the datagrid header on touchscreen devices, the selected column header is sorted. A popup ![sorting](./images/sorting.jpg) is displayed for multi-column sorting. To sort multiple columns, tap the popup![msorting](./images/msorting.jpg), and then tap the desired datagrid headers.

> The [AllowMultiSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowMultiSorting) and [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowSorting) should be **true** then only the popup will be shown.

The following screenshot represents a grid touch sorting in the device.

![Sorting in Blazor DataGrid using Touch Interaction](./images/blazor-datagrid-touch-sorting.jpg)

## Sort foreign key column based on text

To perform sorting based on foreign key column, the `GridForeignColumn` column can be enabled by using [ForeignDataSource ](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridForeignColumn-1.html#Syncfusion_Blazor_Grids_GridForeignColumn_1_ForeignDataSource), [ForeignKeyField](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html?_gl=1*vgn3lm*_ga*MTcyMDA4OTE2OS4xNjg3OTQzMDQ5*_ga_WC4JKKPHH0*MTY4OTc2NTA2MS44NC4xLjE2ODk3NjUyNDAuNjAuMC4w&_ga=2.195629932.1791817302.1689564530-1720089169.1687943049#Syncfusion_Blazor_Grids_GridColumn_ForeignKeyField) and [ForeignKeyValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html?_gl=1*vgn3lm*_ga*MTcyMDA4OTE2OS4xNjg3OTQzMDQ5*_ga_WC4JKKPHH0*MTY4OTc2NTA2MS44NC4xLjE2ODk3NjUyNDAuNjAuMC4w&_ga=2.195629932.1791817302.1689564530-1720089169.1687943049#Syncfusion_Blazor_Grids_GridColumn_ForeignKeyValue) properties.

**Sort foreign key column based on text for local data**

In the case of local data in the grid, the sorting operation will be performed based on the [ForeignKeyValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html?_gl=1*vgn3lm*_ga*MTcyMDA4OTE2OS4xNjg3OTQzMDQ5*_ga_WC4JKKPHH0*MTY4OTc2NTA2MS44NC4xLjE2ODk3NjUyNDAuNjAuMC4w&_ga=2.195629932.1791817302.1689564530-1720089169.1687943049#Syncfusion_Blazor_Grids_GridColumn_ForeignKeyValue)  property of the column. The `ForeignKeyValue` property should be defined in the column definition with the corresponding foreign key value for each row. The grid will sort the foreign key column based on the text representation of the `ForeignKeyValue` property.

The following example demonstrates how to perform sorting by enabling a foreign key column, where the **EmployeeID** column acts as a foreign column displaying the **FirstName** column from foreign data.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="315" AllowSorting="true">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridForeignColumn Field=@nameof(Order.EmployeeID)  HeaderText="Employee Name" ForeignKeyValue="FirstName" ForeignDataSource="@Employees" Width="150"></GridForeignColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; }
    public List<EmployeeData> Employees { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                EmployeeID = x,
                Freight = 2.1 * x,
                OrderDate = DateTime.Now.AddDays(-x),
            }).ToList();

        Employees = Enumerable.Range(1, 75).Select(x => new EmployeeData()
            {
                EmployeeID = x,
                FirstName = (new string[] { "Nancy", "Andrew", "Janet", "Margaret", "Steven" })[new Random().Next(5)],
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public int? EmployeeID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }

    public class EmployeeData
    {
        public int? EmployeeID { get; set; }
        public string FirstName { get; set; }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZhKXQCaTsbNgtSD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## How to customize sort icon

To customize the sort icon in the DataGrid, you can override the default grid classes **.e-icon-ascending** and **.e-icon-descending** with custom content using CSS. Simply specify the desired icons or symbols using the **content** property as mentioned below

```css
.e-grid .e-icon-ascending::before {
  content: '\e87a';
}

.e-grid .e-icon-descending::before {
  content: '\e70d';
}
```

In the below sample, DataGrid is rendered with a customized sort icon.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowSorting="true" Height="270">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDBUDmikzfjVcSTE?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Sort columns externally

The DataGrid component in Syncfusion's Blazor suite allows you to customize the sorting of columns and provides flexibility in sorting based on external interactions. You can sort columns and clear sorting using an external button click.

### Add sort columns

To sort a column externally, you can utilize the [SortColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SortColumnAsync_System_String_Syncfusion_Blazor_Grids_SortDirection_System_Nullable_System_Boolean__) method with parameters **columnName**, **direction** and **isMultiSort** provided by the DataGrid component. This method allows you to programmatically sort a specific column based on your requirements.

The following example demonstrates how to add sort columns to a grid. It utilizes the **DropDownList** component to select the column and sort direction. When an external button is clicked, the [SortColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SortColumnAsync_System_String_Syncfusion_Blazor_Grids_SortDirection_System_Nullable_System_Boolean__) method is called with the specified **columnName**, **direction**, and **isMultiSort** parameters. 

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns

<div style="display:flex;">
    <SfDropDownList TValue="string" TItem="Columns" Width="300px" Placeholder="Select a Column" DataSource="@LocalData" @bind-Value="@DropDownValue">
        <DropDownListFieldSettings Value="ID" Text="Value"></DropDownListFieldSettings>
    </SfDropDownList>
</div>

<div style="display:flex;">
    <SfDropDownList TValue="Syncfusion.Blazor.Grids.SortDirection" TItem="string" DataSource="@EnumValues" @bind-Value="@DropDownDirection" Width="300px">
    </SfDropDownList>
</div>

<div style="display:flex;">
    <Syncfusion.Blazor.Buttons.SfButton OnClick="AddsortColumn">Add sort Column</Syncfusion.Blazor.Buttons.SfButton>
</div>

<SfGrid DataSource="@Orders" AllowMultiSorting="true" @ref="Grid" TValue="Order" AllowSorting="true" Height="270">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {

    SfGrid<Order>? Grid { get; set; }
    public List<Order> Orders { get; set; }
    public string DropDownValue { get; set; } = "OrderID";

    public string[] EnumValues = Enum.GetNames(typeof(Syncfusion.Blazor.Grids.SortDirection));

    public Syncfusion.Blazor.Grids.SortDirection DropDownDirection { get; set; } = SortDirection.Ascending;

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

    List<Columns> LocalData = new List<Columns>
    {
        new Columns() { ID= "OrderID", Value= "OrderID" },
        new Columns() { ID= "CustomerID", Value= "CustomerID" },
        new Columns() { ID= "Freight", Value= "Freight" },
        new Columns() { ID= "OrderDate", Value= "OrderDate" },
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

    public void AddsortColumn()
    {

        Grid.SortColumnAsync(DropDownValue, DropDownDirection, true);

    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXBKDGBIqkLSeSwE?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Clear sorting 

To clear the sorting on an external button click, you can use the [ClearSortingAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ClearSortingAsync) method provided by the DataGrid component. This method clears the sorting applied to all columns in the grid. 

The following example demonstrates how to clear the sorting using `ClearSortingAsync` method in the external button click.

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div>
    <SfButton OnClick="ClearSorting">Clear Sorting</SfButton>
</div>

<SfGrid @ref="Grid" TValue="Order" DataSource="@Orders" AllowSorting="true" Height="270">
    <GridSortSettings>
        <GridSortColumns>
            <GridSortColumn Field="OrderDate" Direction="SortDirection.Ascending"></GridSortColumn>
            <GridSortColumn Field="Freight" Direction="SortDirection.Descending"></GridSortColumn>
        </GridSortColumns>
    </GridSortSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; }
    public SfGrid<Order>? Grid { get; set; }
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

    private async Task ClearSorting()
    {
        await Grid.ClearSortingAsync();
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hjLqZQLygYvasMAs?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Sorting events

The DataGrid component provides two events that are triggered during the sorting action such as  [OnActionBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html) and [OnActionComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html). These events can be used to perform any custom actions before and after the sorting action is completed.

1. **OnActionBegin**:  [OnActionBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html) event is triggered before the sorting action begins. It provides a way to perform any necessary operations before the sorting action takes place. This event provides a parameter that contains the current grid state, including the current sorting column, direction, and data.

2. **OnActionComplete**: [OnActionComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html) event is triggered after the sorting action is completed. It provides a way to perform any necessary operations after the sorting action has taken place. This event provides a parameter that contains the current grid state, including the sorted data and column information.

```csharp

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowSorting="true">
    <GridEvents OnActionBegin="SortEvent"  OnActionComplete="SortEvent" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" MinWidth="10" Width="120" MaxWidth="200"></GridColumn>
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

    public void SortEvent(ActionEventArgs<Order> args) {
        if (args.RequestType.Equals(Syncfusion.Blazor.Grids.Action.Sorting)){
            // You can get action information from the argument.
        }    
    }
}
```
> [args.RequestType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ActionEventArgs-1.html#Syncfusion_Blazor_Grids_ActionEventArgs_1_RequestType) refers to the current action being performed. For example in sorting, the `args.RequestType` value is **Sorting**.


{% previewsample "https://blazorplayground.syncfusion.com/embed/rjLUZnrrCOiiKMSf?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


> You can refer to our [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap4) to understand how to present and manipulate data.