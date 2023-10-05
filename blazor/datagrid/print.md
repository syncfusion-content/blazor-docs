---
layout: post
title: Print in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Print in Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

<!-- markdownlint-disable MD033 -->

# Print in Blazor DataGrid Component

The printing feature in Syncfusion Grid allows you to easily generate and print a representation of the grid’s content for better offline accessibility and documentation. You can enable this feature using either the grid’s Toolbar or the programmatically available [PrintAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_PrintAsync) method.

To add the printing option to the grid’s Toolbar, simply include the [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Toolbar) property in your grid configuration and add the **Print** as Toolbar item. This will allow you to directly initiate the printing process while click on the Print item from the toolbar

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Toolbar="@(new List<object>() { "Print" })" AllowPaging="true">
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipName) HeaderText="Ship Name" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {

    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 10247 + x,
                CustomerID = (new string[] { "VINET", "TOMSP", "HANAR", "SUPRD", "CHOPS" })[new Random().Next(5)],
                ShipCity = (new string[] { "Reims", "Münster", "Rio de Janeiro", "Lyon", "Charleroi" })[new Random().Next(5)],
                ShipName = (new string[] { "Vins et alcools Chev", "Toms Spezialitäten", "Hanari Carnes", "Victuailles en stock", "Suprêmes délices" })[new Random().Next(5)],
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipName { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BDVACDDzLCOPwlKE?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Page setup

When printing a webpage, some print options, such as layout, paper size, and margin settings, cannot be configured through code. Instead, you need to customize these settings using the browser’s page setup dialog. Below are links to the page setup guides for popular web browsers:

* [Chrome](https://support.google.com/chrome/answer/1069693?hl=en&visit_id=1-636335333734668335-3165046395&rd=1)
* [Firefox](https://support.mozilla.org/en-US/kb/how-print-web-pages-firefox)
* [Safari](https://www.mintprintables.com/print-tips/adjust-margins-osx/)
* [IE](https://www.helpteaching.com/)

## Print by external button

You can print the grid’s content using an external button by utilizing the [PrintAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_PrintAsync) method. This method allows you to trigger the printing process programmatically.

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids

<SfButton Content="Print" OnClick="PrintContent"></SfButton>
<SfGrid @ref="DefaultGrid" DataSource="@Orders" AllowPaging="true">
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" TextAlign="TextAlign.Right" Width="130" ></GridColumn>
        <GridColumn Field=@nameof(Order.ShipName) HeaderText="Ship Name" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {

    public List<Order> Orders { get; set; }

    private SfGrid<Order> DefaultGrid;

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 10247 + x,
                CustomerID = (new string[] { "VINET", "TOMSP", "HANAR", "SUPRD", "WELLI" })[new Random().Next(5)],
                ShipCity = (new string[] { "Reims", "Münster", "Rio de Janeiro", "Lyon", "Charleroi" })[new Random().Next(5)],
                ShipName = (new string[] { "Vins et alcools Cheva", "Toms Spezialitäten", "	Hanari Carnes", "Suprêmes délices", "Ernst Handel" })[new Random().Next(5)],
             }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipName { get; set; }
    }
    public void PrintContent()
    {
        this.DefaultGrid.PrintAsync();
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rXrgWXZTryODdbNo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Print visible Page

By default, the Syncfusion Blazor Grid prints all the pages of the grid. The [PrintMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DashArray) property within the grid grants you control over the printing process. However, if you want to print only the current visible page, you can achieve this by setting the `PrintMode` property to **CurrentPage**.

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns

<label>Select Print Mode: </label>
<SfDropDownList TValue="PrintMode" TItem="ddlOrder" @bind-Value="@DropVal" DataSource="@LocalData" Width="130px">
    <DropDownListFieldSettings Text="Text" Value="Value"></DropDownListFieldSettings>
    <DropDownListEvents ValueChange="OnValueChange" TValue="PrintMode" TItem="ddlOrder"></DropDownListEvents>
</SfDropDownList>

<SfGrid @ref="Grid" DataSource="@Orders" Toolbar="@(new List<object>() { "Print" })" PrintMode="@DropVal" AllowPaging="true">
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<Order> Grid;
    public List<Order> Orders { get; set; }

    public PrintMode DropVal { get; set; } = PrintMode.AllPages;

    public class ddlOrder
    {
        public string Text { get; set; }
        public PrintMode Value { get; set; }
    }
    List<ddlOrder> LocalData = new List<ddlOrder>
    {
        new ddlOrder() { Text = "All Pages", Value = PrintMode.AllPages },
        new ddlOrder() { Text = "Current Page", Value = PrintMode.CurrentPage },
  
    };
    public void OnValueChange(ChangeEventArgs<PrintMode, ddlOrder> Args)
    {
        DropVal = Args.Value;
        Grid.Refresh();
    }

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/rjhAsZXfAWARnqzP?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

<!-- Print the hierarchy datagrid

By default, the datagrid will print the master and expanded child grids alone. You can change the print option by using the [`HierarchyPrintMode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Type) property of the Grid component. The available options are,

Mode |Behavior
-----|-----
Expanded |Prints the master datagrid with expanded child grids.
All |Prints the master datagrid with all the child grids.
None |Prints the master datagrid alone.

This is demonstrated in the below sample code,

```cshtml
@using Syncfusion.Blazor.Grids

@{
    GridModel<object> ChildGridData = new GridModel<object>()
    {
        DataSource = Orders,
        QueryString = "EmployeeID",
        Columns = new List<GridColumn> {
            new GridColumn() { Field="OrderID", HeaderText="OrderID", Width="110" },
            new GridColumn() { Field="CustomerName", HeaderText="CustomerName", Width="110"},
            new GridColumn() { Field="ShipCountry", HeaderText="ShipCountry", Width="110" }
        }
    };
}
<SfGrid DataSource="@Employees" Toolbar="@(new List<object>() { "Print" })" HierarchyPrintMode=HierarchyGridPrintMode.Expanded ChildGrid="ChildGridData" Height="315px">
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeData.EmployeeID) HeaderText="EmployeeID" Width="110"> </GridColumn>
        <GridColumn Field=@nameof(EmployeeData.FirstName) HeaderText="First Name" Width="110"> </GridColumn>
        <GridColumn Field=@nameof(EmployeeData.City) HeaderText="Last Name" Width="110"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Country) HeaderText="Country" Width="110"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<EmployeeData> Employees { get; set; }

    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Employees = Enumerable.Range(1, 9).Select(x => new EmployeeData()
        {
            EmployeeID = x,
            FirstName = (new string[] { "Nancy", "Andrew", "Janet", "Margaret", "Steven" })[new Random().Next(5)],
            City = (new string[] { "Seattle", "Tacoma", "Redmond", "Kirkland", "London" })[new Random().Next(5)],
            Country = (new string[] { "USA", "UK" })[new Random().Next(2)],
        }).ToList();

        Orders = Enumerable.Range(1, 9).Select(x => new Order()
        {
            EmployeeID = x,
            OrderID = 1000 + x,
            CustomerName = (new string[] { "Nancy", "Andrew" })[new Random().Next(2)],
            ShipCountry = (new string[] { "USA", "UK" })[new Random().Next(2)],
        }).ToList();
    }

    public class EmployeeData
    {
        public int? EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime? HireDate { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }

    public class Order
    {
        public int? EmployeeID { get; set; }
        public int? OrderID { get; set; }
        public string CustomerName { get; set; }
        public string ShipCountry { get; set; }
    }
}
```

The following image represents Hierarchial Grid with print toolbar item,
![Print Hierarchial Grid Content](./images/grid-hierarchial-print.png) -->

## Print large number of columns

When printing a grid with a large number of columns, the browser’s default page size (usually A4) might not be sufficient to display all the columns properly. As a result, the browser’s print preview may automatically hide the overflowed content, leading to a cut-off appearance.

To show a large number of columns when printing, you can adjust the scale option from the print option panel based on your content size. This will allow you to fit the entire grid content within the printable area.

![Printing Large Number of Columns in Blazor DataGrid](./images/blazor-datagrid-print-large-columns.png)

<!-- Show or hide columns while Printing

You can show a hidden column or hide a visible column while printing the datagrid using ToolbarClick and PrintComplete events.

In the ToolbarClick event, we can show or hide columns by modifying the Visible property value of the GridColumn component.

Then in the PrintComplete event, we can reverse the state back to the previous state.

In the below example, we have **CustomerID** as a hidden column in the datagrid. While printing, we have changed **CustomerID** to visible column and **Freight** as hidden column.

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations

<SfGrid DataSource="@Orders" Toolbar="@(new List<object>() { "Print" })" PrintMode=PrintMode.CurrentPage AllowPaging="true">
    <GridEvents PrintComplete="OnPrintComplete" OnToolbarClick="ToolbarClicked" TValue="Order"></GridEvents>
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Visible="@CustomerIDVisibility" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Visible="@FreightVisibility" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{

    public List<Order> Orders { get; set; }

    public bool CustomerIDVisibility = false;

    public bool FreightVisibility = true;

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

    public void ToolbarClicked(ClickEventArgs args)
    {
        this.CustomerIDVisibility = true;
        this.FreightVisibility = false;
    }

    public void OnPrintComplete(args)
    {
        this.CustomerIDVisibility = false;
        this.FreightVisibility = true;
    }
}
``` -->

## Limitations of printing large data

Printing a large volume of data all at once in the grid can have certain limitations due to potential browser performance issues. Rendering numerous DOM elements on a single page can lead to browser slowdowns or even hang the browser. The grid offers a solution to manage extensive datasets through virtualization. However, it’s important to note that virtualization for both rows and columns is not feasible during the printing process.

If printing all the data remains a requirement, an alternative approach is recommended. Exporting the grid data to formats like [Excel](https://blazor.syncfusion.com/documentation/datagrid/excel-exporting) or [CSV](https://blazor.syncfusion.com/documentation/datagrid/excel-exporting) or [Pdf](https://blazor.syncfusion.com/documentation/datagrid/pdf-export) is advised. This exported data can then be printed using non-web-based applications, mitigating the potential performance challenges associated with printing large datasets directly from the browser.

N> You can refer to our [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap4) to understand how to present and manipulate data.