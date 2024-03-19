---
layout: post
title: Excel Export in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Excel Export in Syncfusion Blazor DataGrid component and much more.
platform: Blazor
control: DataGrid
documentation: ug
---

<!-- markdownlint-disable MD033 -->

# Excel Export in Blazor DataGrid Component

The excel export allows exporting DataGrid data to Excel document. You need to use the
 **ExcelExport** method for exporting. To enable Excel export in the datagrid, set the [AllowExcelExport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowExcelExport) property as true.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" AllowSorting="true" Toolbar="@(new List<string>() { "ExcelExport" })" AllowExcelExport="true" AllowPaging="true">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;

    public List<Order> Orders { get; set; }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
       if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname
        {
            await this.DefaultGrid.ExcelExport();
        }
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

## To customize excel export

The excel export provides an option to customize mapping of the datagrid to excel document.

### Export current page

The excel export provides an option to export the current page into excel. To export current page, define **exportType** to **CurrentPage**.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" AllowSorting="true" Toolbar="@(new List<string>() { "ExcelExport" })" AllowExcelExport="true" AllowPaging="true">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;

    public List<Order> Orders { get; set; }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
       if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname
        {
            ExcelExportProperties ExportProperties = new ExcelExportProperties();
            ExportProperties.ExportType = ExportType.CurrentPage;
            await this.DefaultGrid.ExcelExport(ExportProperties);
        }
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

### Export hidden columns

The excel export provides an option to export hidden columns of DataGrid by defining [IncludeHiddenColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html#Syncfusion_Blazor_Grids_ExcelExportProperties_IncludeHiddenColumn) as **true**.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" AllowSorting="true" Toolbar="@(new List<string>() { "ExcelExport" })" AllowExcelExport="true" AllowPaging="true">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Visible="false" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;

    public List<Order> Orders { get; set; }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
       if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname
        {
            ExcelExportProperties ExportProperties = new ExcelExportProperties();
            ExportProperties.IncludeHiddenColumn = true;
            await this.DefaultGrid.ExcelExport(ExportProperties);
        }
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

### Export the selected records only

The Grid has an option to export the selected records in an excel exported document. This can be achieved by using the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html#Syncfusion_Blazor_Grids_ExcelExportProperties_DataSource) property of the [ExcelExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html) class and the [GetSelectedRecordsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetSelectedRecordsAsync) method of the Grid.

In the following sample, selected records will be gotten from the `GetSelectedRecordsAsync` method and provided to the `DataSource` property of `ExcelExportProperties`. Then pass this ExcelExportProperties class to the [ExportToExcelAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExportToExcelAsync_Syncfusion_Blazor_Grids_ExcelExportProperties_System_Nullable_System_Boolean__System_Object_System_Nullable_System_Boolean__) method to get the selected records in the exported document.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" AllowExcelExport="true" AllowPaging="true"
        Toolbar="@(new List<string>() { "ExcelExport" })" AllowSelection="true">
    <GridEvents OnToolbarClick="OnToolbarClick" TValue="Order"></GridEvents>
    <GridSelectionSettings Type="SelectionType.Multiple"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;
    public List<Order> Orders { get; set; }
    public async Task OnToolbarClick(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_excelexport") // Id is combination of Grid's ID and itemname.
        {
            ExcelExportProperties ExcelProperties = new ExcelExportProperties();
            var selectedRecord = await DefaultGrid.GetSelectedRecordsAsync();
            if(selectedRecord.Count() > 0)
            {
                ExcelProperties.DataSource = selectedRecord;
            }
            else
            {
                ExcelProperties.DataSource = Orders;
            }
            await this.DefaultGrid.ExportToExcelAsync(ExcelProperties);
        }
    }
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 15).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            ShipCountry = (new string[] { "Germany", "UK", "USA", "Italy", "France" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }
    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCountry { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

### Add custom text in header/footer

You can add text and customize its styles either in the header or footer of an exported excel document by using the [Header](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html#Syncfusion_Blazor_Grids_ExcelExportProperties_Header) and [Footer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html#Syncfusion_Blazor_Grids_ExcelExportProperties_Footer) properties of the [ExcelExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html) class.

The following sample code demonstrates adding custom text and customizing its styles in the header section of the exported document,

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker @ref="DateRange" TValue="DateTime?" StartDate="@StartValue" EndDate="@EndValue"></SfDateRangePicker>

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" Toolbar="@(new List<string>() { "ExcelExport" })" AllowExcelExport="true" AllowPaging="true">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfDateRangePicker<DateTime?> DateRange;
    private SfGrid<Order> DefaultGrid;
    public List<Order> Orders { get; set; }
    public DateTime? StartValue { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 28);
    public DateTime? EndValue { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 29);

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_excelexport")  //Id is combination of Grid's ID and itemname      
        {
            ExcelExportProperties  ExportProperties = new ExcelExportProperties ();
            ExcelHeader header = new ExcelHeader();
            header.HeaderRows = 2;
            List<ExcelCell> cell = new List<ExcelCell>
            {
                new ExcelCell() { RowSpan= 2,ColSpan=5 , Value= "PO Report from " + DateRange.StartDate.ToString() + " to " + DateRange.EndDate.ToString() + " Vendor All", Style = new ExcelStyle() { Bold = true, FontSize = 13, Italic= true }  }
            };

            List<ExcelRow> HeaderContent = new List<ExcelRow>
            {
                new ExcelRow() {  Cells = cell, Index = 1 }
            };
            header.Rows = HeaderContent;
            ExportProperties.Header = header;
            await this.DefaultGrid.ExcelExport(ExportProperties);
        }
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

![Adding custom text in header/footer in Blazor DataGrid](./images/blazor-datagrid-custom-text-in-header.png)

<!-- Show or hide columns on exported excel

You can show a hidden column or hide a visible column while exporting the DataGrid by customizing the visibility settings.

This is demonstrated in the below sample code where initially the **CustomerID** is hidden. While exporting, we have changed CustomerID to visible column and Freight as hidden column. Then in the `ExcelExportComplete` event, we have reversed the column's visibility state back to the previous state.

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids

<SfButton OnClick="ExcelExport" Content="Excel Export"></SfButton>
<SfGrid @ref="DefaultGrid" DataSource="@Orders" AllowSorting="true" AllowExcelExport="true" AllowPaging="true">
    <GridEvents ExcelExportComplete="OnExcelExport" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Visible=@CustomerIDVisibility Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Visible=@FreightVisibility Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;

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

    public void ExcelExport()
    {
        CustomerIDVisibility = true;
        FreightVisibility = false;
        this.DefaultGrid.ExcelExport();
    }
    public void OnExcelExport()
    {
        CustomerIDVisibility = false;
        FreightVisibility = true;
    }
}
``` -->

### Theme

The excel export provides an option to include theme for exported excel document.

To apply theme in exported Excel, define the **theme** in export properties.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" AllowSorting="true" Toolbar="@(new List<string>() { "ExcelExport" })" AllowExcelExport="true" AllowPaging="true">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;

    public List<Order> Orders { get; set; }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
       if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname
        {
            ExcelExportProperties ExcelProperties = new ExcelExportProperties();
            ExcelTheme Theme = new ExcelTheme();
            ExcelStyle ThemeStyle = new ExcelStyle()
            {
                FontName = "Segoe UI",
                FontColor = "#666666",
                FontSize = 20
            };
            Theme.Header = ThemeStyle;
            Theme.Record = ThemeStyle;
            Theme.Caption = ThemeStyle;
            ExcelProperties.Theme = Theme;
            await this.DefaultGrid.ExcelExport(ExcelProperties);
        }
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

N> By default, material theme is applied to exported excel document.

### Customizing the background color for a Grid in an exported Excel document

You can set the background color for a Grid in the exported document using the [Theme](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html#Syncfusion_Blazor_Grids_ExcelExportProperties_Theme) property of [ExcelExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html) class.

This can be demonstrated using the following sample:

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" AllowSorting="true" Toolbar="@(new List<string>() { "ExcelExport" })" AllowExcelExport="true" AllowPaging="true">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;
    public List<Order> Orders { get; set; }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname
        {
            ExcelExportProperties ExcelProperties = new ExcelExportProperties();
            ExcelTheme Theme = new ExcelTheme();
            ExcelStyle ThemeStyle = new ExcelStyle()
            {
                BackColor = "#C67878"
            };
            Theme.Header = ThemeStyle;
            Theme.Record = ThemeStyle;
            Theme.Caption = ThemeStyle;
            ExcelProperties.Theme = Theme;
            await this.DefaultGrid.ExcelExport(ExcelProperties);
        }
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

![Customizing the background color for a Blazor DataGrid in an exported Excel document](./images/blazor-datagrid-customize-background-color.png)

N> [View Sample in GitHub.](https://github.com/SyncfusionExamples/blazor-datagrid-customize-background-color-for-grid-exported-excel-file)

### Customizing the background color for a particular column in an exported Excel document

You can set the background color for a particular column in the exported document. This can be achieved by the [ExcelQueryCellInfoEvent](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_ExcelQueryCellInfoEvent) of the Grid.

This can be demonstrated using the following sample:

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" AllowSorting="true" Toolbar="@(new List<string>() { "ExcelExport" })" AllowExcelExport="true" AllowPaging="true">
    <GridEvents ExcelQueryCellInfoEvent="ExcelQueryCellInfoHandler" OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;
    public List<Order> Orders { get; set; }

    public void ExcelQueryCellInfoHandler(ExcelQueryCellInfoEventArgs<Order> args)
    {
        // Here you can customize your code
        if (args.Column.Field == "CustomerID") {
            if (args.Data.CustomerID == "ALFKI") 
            {
                args.Cell.CellStyle.BackColor = "#DC143C";
            }
            else if (args.Data.CustomerID == "ANANTR") 
            {
                args.Cell.CellStyle.BackColor = "#FF0000";
            }
            else if (args.Data.CustomerID == "ANTON")
            {
                args.Cell.CellStyle.BackColor = "#FFD700";
            }
            else if (args.Data.CustomerID == "BLONP")
            {
                args.Cell.CellStyle.BackColor = "#FFFF00";
            }
            else if (args.Data.CustomerID == "BOLID")
            {
                args.Cell.CellStyle.BackColor = "#7CFC00";
            }
        }
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname
        {
            await this.DefaultGrid.ExcelExport();
        }
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

![Customizing the background color for a particular column in an exported Excel document](./images/blazor-datagrid-customize-background-color-for-particular-column.png)

N> [View Sample in GitHub.](https://github.com/SyncfusionExamples/blazor-datagrid-customize-background-color-for-particular-column)

<!-- To add header and footer

The excel export provides an option to include header and footer content for exported excel document using the [`ExcelExportProperties`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html) class.

This is demonstrated in the below sample code,

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids

<SfButton OnClick="ExcelExport" Content="Excel Export"></SfButton>
<SfGrid @ref="DefaultGrid" DataSource="@Orders" AllowSorting="true" AllowExcelExport="true" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
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

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }

    public void ExcelExport()
    {
        ExcelExportProperties ExportProperties = new ExcelExportProperties();

        ExcelHeader Header = new ExcelHeader();

        ExcelFooter Footer = new ExcelFooter();

        List<ExcelRow> HeaderRows = new List<ExcelRow>()
        {
            new ExcelRow() {
                Cells = new List<ExcelCell>() {
                    new ExcelCell() { ColSpan = 4, Value = "Northwind Traders", Style = new ExcelStyle() {
                        FontColor = "#C67878",
                        FontSize = 20,
                        HAlign = ExcelHAlign.Center,
                        Bold = true
                    }
                    }
                }
            },
            new ExcelRow() {
                Cells = new List<ExcelCell>() {
                    new ExcelCell() { ColSpan = 4, Value = "2501 Aerial Center Parkway", Style = new ExcelStyle() {
                        FontColor = "#C67878",
                        FontSize = 15,
                        HAlign = ExcelHAlign.Center,
                        Bold = true
                    }
                    }
                }
            },
            new ExcelRow() {
                Cells = new List<ExcelCell>() {
                    new ExcelCell() { ColSpan = 4, Value = "Suite 200 Morrisville, NC 27560 USA", Style = new ExcelStyle() {
                        FontColor = "#C67878",
                        FontSize = 15,
                        HAlign = ExcelHAlign.Center,
                        Bold = true
                    }
                    }
                }
            },
            new ExcelRow() {
                Cells = new List<ExcelCell>() {
                    new ExcelCell() { ColSpan = 4, Value = "Tel +1 888.936.8638 Fax +1 919.573.0306", Style = new ExcelStyle() {
                        FontColor = "#C67878",
                        FontSize = 15,
                        HAlign = ExcelHAlign.Center,
                        Bold = true
                    }
                    }
                }
            },
            new ExcelRow() {
                Cells = new List<ExcelCell>() {
                    new ExcelCell() { ColSpan = 4, Hyperlink = new Hyperlink() { 
                        Target = "https://www.northwind.com/",
                        DisplayText = "www.northwind.com"
                    },
                        Style = new ExcelStyle() {
                        HAlign = ExcelHAlign.Center,
                    }
                    }
                }
            },
            new ExcelRow() {
                Cells = new List<ExcelCell>() {
                    new ExcelCell() { ColSpan = 4, Hyperlink = new Hyperlink() { 
                        Target = "mailto:support@northwind.com",
                        DisplayText = "Support"
                    },
                        Style = new ExcelStyle() {
                        HAlign = ExcelHAlign.Center,
                    }
                    }
                }
            }
        };
        Header.HeaderRows = 6;
        Header.Rows = HeaderRows;

        List<ExcelRow> FooterRows = new List<ExcelRow>()
        {
            new ExcelRow() {
                Cells = new List<ExcelCell>() {
                    new ExcelCell() { ColSpan = 4, Value = "Thank you for your business!", Style = new ExcelStyle() {
                        HAlign = ExcelHAlign.Center,
                        Bold = true
                    }
                    }
                }
            },
            new ExcelRow() {
                Cells = new List<ExcelCell>() {
                    new ExcelCell() { ColSpan = 4, Value = "!Visit Again!", Style = new ExcelStyle() {
                        HAlign = ExcelHAlign.Center,
                        Bold = true
                    }
                    }
                }
            }
        };
        Footer.FooterRows = 2;
        Footer.Rows = FooterRows;

        ExportProperties.Header = Header;
        ExportProperties.Footer = Footer;

        this.DefaultGrid.ExcelExport(ExportProperties);
    }
}
``` -->

### File name for exported document

You can assign the file name for the exported document by defining **fileName** property in excel export properties.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" AllowSorting="true" Toolbar="@(new List<string>() { "ExcelExport" })" AllowExcelExport="true" AllowPaging="true">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;

    public List<Order> Orders { get; set; }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
       if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname
        {
            ExcelExportProperties ExcelProperties = new ExcelExportProperties();
            ExcelProperties.FileName = "new.xlsx";
            await this.DefaultGrid.ExcelExport(ExcelProperties);
        }
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

### Add additional worksheets to excel file while exporting

Additional worksheets can be added to the excel file while exporting using the [ExcelExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html).

In the following sample, you can add the additional worksheets to excel file by creating a workbook using `ExcelExportProperties`. Additional sheets will be added along with the Grid data.

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.ExcelExport

@{
    var Tool = (new List<string>() { "ExcelExport"});
}

<SfGrid @ref="DefaultGrid" DataSource="@Orders" Toolbar=@Tool AllowExcelExport="true">
   <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
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
    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
    public async Task ToolbarClickHandler()
    {
        ExcelExportProperties ExportProperties = new ExcelExportProperties();
        // Add a new workbook to the excel file that contains only 1 worksheet.
        ExportProperties.Workbook = new Workbook();
        // Add additional worksheets.
        ExportProperties.Workbook.Worksheets.Add();
        ExportProperties.Workbook.Worksheets.Add();
        // Define the Gridsheet index where Grid data must be exported.
        ExportProperties.GridSheetIndex = 0;
        // Export the document. 
        await this.DefaultGrid.ExcelExport(ExportProperties);
    }
}

```

## Excel Exporting with Templates

### Exporting with template columns

The excel export provides an option to export template columns of the DataGrid by defining the [IncludeTemplateColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html#Syncfusion_Blazor_Grids_ExcelExportProperties_IncludeTemplateColumn) of [ExcelExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html) as true. In the following sample, the CustomerID column is a template column. The template values cannot be directly exported into the cells. To customize the values of the template columns in Excel file, you must use [ExcelQueryCellInfoEvent](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_ExcelQueryCellInfoEvent).

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" Toolbar="@(new List<string>() { "ExcelExport" })" AllowExcelExport="true" AllowPaging="true">
    <GridEvents ExcelQueryCellInfoEvent="ExcelQueryCellInfoHandler" OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150">
            <Template>
                @{
                    var con = (context as Order);
                }
                <span>Mr.@con.CustomerID</span>
            </Template>
        </GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;
    public List<Order> Orders { get; set; }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_excelexport")  // Id is the combination of Grid's ID and item name.
        {
            ExcelExportProperties ExportProperties = new ExcelExportProperties();
            ExportProperties.IncludeTemplateColumn = true;
            await this.DefaultGrid.ExportToExcelAsync(ExportProperties);
        }
    }
    public void ExcelQueryCellInfoHandler(ExcelQueryCellInfoEventArgs<Order> args)
    {
        if (args.Column.Field == "CustomerID")
        {
            args.Cell.Value = "Mr." + args.Data.CustomerID;
        }
    }
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "Alfki", "Anantr", "Anton", "Blonp", "Bolid" })[new Random().Next(5)],
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

### Exporting with Group caption template

The Excel export feature allows you export a Grid with a caption template to a Excel document. 

The example below demonstrates how to customize the caption text in the Excel using the [ExcelGroupCaptionTemplateInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_ExcelGroupCaptionTemplateInfo) event.

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations

<SfGrid ID="Grid" @ref="Grid" DataSource="@GridData" AllowGrouping="true" Height="315px" Toolbar="@(new List<string>() { "ExcelExport" })" AllowExcelExport="true">
    <GridEvents OnToolbarClick="ToolbarClickHandler" ExcelGroupCaptionTemplateInfo="ExcelGroupCaptionInfoHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Name" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="value" Width="80"></GridColumn>
    </GridColumns>
    <GridGroupSettings Columns=@(new string[] { "CustomerID" })>
        <CaptionTemplate>
            @{
                var order = (context as CaptionTemplateContext);
                <span>@order.Key - @order.Count Records : @order.HeaderText</span>
            }
        </CaptionTemplate>
    </GridGroupSettings>
</SfGrid>

@code {
    public List<OrderData> GridData { get; set; }

    public SfGrid<OrderData> Grid { get; set; }

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    public async Task ToolbarClickHandler(ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_excelexport")
        {
            await Grid.ExportToExcelAsync();
        }
    }

    public void ExcelGroupCaptionInfoHandler(ExcelCaptionTemplateArgs args)
    {
        args.Cell.Value = args.Key + "-" + args.Count + " Records: " + args.HeaderText;       //customize the caption cell value here
    }

    public class OrderData
    {
        public static List<OrderData> Orders = new List<OrderData>();

        public OrderData()
        {

        }
        public OrderData(int? OrderID, string CustomerID, string ShipCity, double? Freight)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.ShipCity = ShipCity;
            this.Freight = Freight;
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET", "Reims", 3.25));
                    Orders.Add(new OrderData(10249, "TOMSP", "Münster", 22.98));
                    Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", 140.51));
                    Orders.Add(new OrderData(10251, "VICTE", "Lyon", 65.83));
                    Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", 58.17));
                    Orders.Add(new OrderData(10253, "HANAR", "Lyon", 81.91));
                    Orders.Add(new OrderData(10254, "CHOPS", "Rio de Janeiro", 3.05));
                    Orders.Add(new OrderData(10255, "RICSU", "Münster", 55.09));
                    Orders.Add(new OrderData(10256, "WELLI", "Reims", 48.29));
                    code += 5;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public double? Freight { get; set; }
    }
}
```

### Exporting with Detail template

By default, the Grid exports the parent grid along with expanded detail rows only. To modify the exporting behavior, utilize the [ExcelExportProperties.ExcelDetailRowMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelDetailRowMode.html) property. The available options include:

| Mode | Behaviour |
|-------|----------|
| Expand | Exports the parent grid with expanded detail rows.
| Collapse | Exports the parent grid with collapsed detail rows.
| None | Exports the parent grid alone.

Customization of detail rows in the exported Excel is achievable through the [ExcelDetailTemplateExporting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_ExcelDetailTemplateExporting) event. This event enables formatting the detail rows based on their parent row details within the Excel document.

In the provided example, detail row content is formatted by specifying the [Headers](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelDetailTemplateRowSettings.html#Syncfusion_Blazor_Grids_ExcelDetailTemplateRowSettings_Headers), [Rows](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelDetailTemplateRowSettings.html#Syncfusion_Blazor_Grids_ExcelDetailTemplateRowSettings_Rows) using parent row details, facilitating the creation of detail rows within the Excel. Additionally, custom styles can be applied to specific cells using the [Style](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelDetailTemplateCell.html#Syncfusion_Blazor_Grids_ExcelDetailTemplateCell_Style) property.

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor

<SfGrid @ref="DefaultGrid" ID="Grid" DataSource="@Employees" Toolbar="@(new List<string>() { "ExcelExport" })" AllowExcelExport="true" Height="450px">
    <GridTemplates>
        <DetailTemplate>
            @{
                var employee = (context as Product);
                <table class="detailtable" width="100%">
                    <colgroup>
                        <col width="40%" />
                        <col width="60%" />
                    </colgroup>
                    <thead>
                        <tr>
                            <th colspan="2" style="font-weight: 500;text-align: center;background-color: #ADD8E6;">
                                Product Details
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td style="text-align: center;">
                                <span>@employee.ProductDesc</span>
                            </td>
                            <td>
                                <span class="link">
                                    Contact: <a href="mailto:${@employee.Contact}">@employee.Contact</a>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center;">
                                <span style="font-weight: 500;"> @employee.Cost</span>
                            </td>
                            <td>
                                <span>Available: @employee.Available </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center;">
                                <span class="${Status}" style="font-weight: 500;"> @employee.Status</span>
                            </td>
                            <td>
                                <span>@employee.ReturnPolicy</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center;">
                                <span style="font-weight: 500;color: #0a76ff;">Offers: @employee.Offers </span>
                            </td>

                            <td>
                                <span>@employee.Cancellation</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center;">
                                <span style="font-weight: 500;color: #0a76ff;"> Ratings: @employee.Ratings</span>
                            </td>
                            <td>
                                <span style="font-weight: 500;color: #0a76ff;">@employee.Delivery</span>
                            </td>
                        </tr>
                    </tbody>
                </table>

            }
        </DetailTemplate>
    </GridTemplates>
    <GridEvents ExcelDetailTemplateExporting="ExcelDetailTemplateHandler" OnToolbarClick="ToolbarClickHandler" TValue="Product"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Product.Category) HeaderText="Category" Width="110"> </GridColumn>
        <GridColumn Field=@nameof(Product.ProductID) HeaderText="Product ID" Width="160"> </GridColumn>
        <GridColumn Field=@nameof(Product.Status) HeaderText="Status" Width="180"></GridColumn>
    </GridColumns>
</SfGrid>

<style type="text/css" class="cssStyles">
    .detailtable td {
        font-size: 13px;
        padding: 4px;
        max-width: 0;
        overflow: hidden;
        text-overflow: ellipsis;
        white-space: nowrap;
        font-weight: normal;
    }
</style>

@code {

    SfGrid<Product> DefaultGrid;
    public List<Product> Employees { get; set; }
    public async Task ToolbarClickHandler(ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_excelexport")  // Id is the combination of Grid's ID and item name.
        {
            ExcelExportProperties ExportProperties = new ExcelExportProperties();
            ExportProperties.ExcelDetailRowMode = ExcelDetailRowMode.Expand;
            await this.DefaultGrid.ExportToExcelAsync(ExportProperties);
        }
    }

    public void ExcelDetailTemplateHandler(ExcelDetailTemplateEventArgs<Product> args)
    {
        var excelRows = new List<ExcelDetailTemplateRow>();
        var data = args.ParentRow.Data;
        args.RowInfo.Headers = new List<ExcelDetailTemplateRow>() { new ExcelDetailTemplateRow() { Cells = new List<ExcelDetailTemplateCell>() { new ExcelDetailTemplateCell() { Index = 0, CellValue = "Product Details", ColumnSpan = 2, Style = new ExcelStyle() { Bold = true, BackColor = "#ADD8E6" } } } } };
        excelRows.Add(new ExcelDetailTemplateRow()
            {
                Cells = new List<ExcelDetailTemplateCell>()
        {
            new ExcelDetailTemplateCell()
            {
                CellValue = data.ProductDesc, Index = 0
            },
            new ExcelDetailTemplateCell()
            {
                Index = 1, Hyperlink = new Hyperlink() { DisplayText = data.Contact, Target = data.Contact }
            }
        }
            });
        excelRows.Add(
            new ExcelDetailTemplateRow()
                {
                    Cells = new List<ExcelDetailTemplateCell>()
                            {
            new ExcelDetailTemplateCell()
            {
                CellValue = data.Cost, Index = 0
            },
            new ExcelDetailTemplateCell()
            {
                Index = 1, CellValue = "Available :" + data.Available }
                            }
                });
        excelRows.Add(new ExcelDetailTemplateRow()
            {
                Cells = new List<ExcelDetailTemplateCell>()
            {
            new ExcelDetailTemplateCell()
            {
                CellValue = data.Status, Index = 0
            },
            new ExcelDetailTemplateCell()
            {
                Index = 1, CellValue = data.ReturnPolicy }
            }
            });
        excelRows.Add(new ExcelDetailTemplateRow()
            {
                Cells = new List<ExcelDetailTemplateCell>()
            {
            new ExcelDetailTemplateCell()
            {
                CellValue = "Offers :" + data.Offers, Index = 0, Style = new ExcelStyle()
                {
                  FontColor = "#0A76FF", FontSize = 12
                }
            },
            new ExcelDetailTemplateCell()
            {
                Index = 1, CellValue = data.Cancellation }
            }
            });
        excelRows.Add(new ExcelDetailTemplateRow()
            {
                Cells = new List<ExcelDetailTemplateCell>()
            {
            new ExcelDetailTemplateCell()
            {
                CellValue = "Ratings: " + data.Ratings, Index = 0, Style = new ExcelStyle()
                {
                  FontColor = "#0A76FF", FontSize = 12
                }
            },
            new ExcelDetailTemplateCell()
            {
                Index = 1, CellValue = data.Delivery, Style = new ExcelStyle()
                {
                  FontColor = "#0A76FF", FontSize = 12
                }
            }
            }
            });
        args.RowInfo.Rows = excelRows;
    }

    protected override void OnInitialized()
    {
        Employees = new List<Product>
        {
            new Product() {Category = "Suits/Slim", Offers="5%", Cost ="199.99$", Available = "10", ItemID="Suit-001",ProductID="EJ-SU-01", Contact="nancy@domain.com", Status = "Available", ProductDesc = "Slim Fit Suit", ReturnPolicy = "No Returns Applicable", Delivery = "** FREE Delivery **", Cancellation = "Cancellation upto 12 hrs", Ratings ="4.5" },
            new Product() {Category = "Suits/Classic", Offers="12%", Cost ="249.99$", Available = "8", ItemID="Suit-002",ProductID="EJ-SU-02", Contact="nancy@domain.com", Status = "Available", ProductDesc = "Classic Fit Suit", ReturnPolicy = "No Returns Applicable", Delivery = "** FREE Delivery **", Cancellation = "Cancellation upto 24 hrs", Ratings ="4.8" },
            new Product() {Category = "Suits/Formal", Offers="5%", Cost ="149.99$", Available = "15", ItemID="Suit-003",ProductID="EJ-SU-03", Contact="nancy@domain.com", Status = "Available", ProductDesc = "Formal Fit Suit", ReturnPolicy = "No Returns Applicable", Delivery = "** FREE Delivery **", Cancellation = "Cancellation upto 12 hrs", Ratings ="4.7" },
            new Product() {Category = "Phants/Slim", Offers="10%", Cost ="19.99$", Available = "50", ItemID="Phant-001",ProductID="EJ-PH-01", Contact="nancy@domain.com", Status = "Available", ProductDesc = "Slim Fit Phant", ReturnPolicy = "Returns Applicable upto 2 days", Delivery = "** FREE Delivery **", Cancellation = "No Cancellation", Ratings ="4.5" },
            new Product() {Category = "Phants/Classic", Offers="10%", Cost ="24.99$", Available = "45", ItemID="Phant-002",ProductID="EJ-PH-02", Contact="nancy@domain.com", Status = "Available", ProductDesc = "Classic Fit Phant", ReturnPolicy = "No Returns Applicable", Delivery = "** FREE Delivery **", Cancellation = "No Cancellation", Ratings ="4.6" },
            new Product() {Category = "Shirts/Slim", Offers="8%", Cost ="19.99$", Available = "30", ItemID="Shirt-001",ProductID="EJ-SH-01", Contact="nancy@domain.com", Status = "Available", ProductDesc = "Slim Fit Shirt", ReturnPolicy = "No Returns Applicable", Delivery = "** FREE Delivery **", Cancellation = "No Cancellation", Ratings ="4.5" },
            new Product() {Category = "Shirts/Formal", Offers="10%", Cost ="14.99$", Available = "30", ItemID="Shirt-002",ProductID="EJ-SH-02", Contact="nancy@domain.com", Status = "Available", ProductDesc = "Formal Shirt", ReturnPolicy = "No Returns Applicable", Delivery = "** FREE Delivery **", Cancellation = "No Cancellation", Ratings ="4.0" },
            new Product() {Category = "Shirts/Classic", Offers="5%", Cost ="249.99$", Available = "25", ItemID="Shirt-003",ProductID="EJ-SH-03", Contact="nancy@domain.com", Status = "Available", ProductDesc = "Slim Fit Classic", ReturnPolicy = "No Returns Applicable", Delivery = "** FREE Delivery **", Cancellation = "Cancellation upto 12 hrs", Ratings ="4.8" },
            new Product() {Category = "Shirts/Slim", Offers="10%", Cost ="14.99$", Available = "30", ItemID="Shirt-001",ProductID="EJ-SH-01", Contact="nancy@domain.com", Status = "Available", ProductDesc = "Slim Fit Shirt", ReturnPolicy = "No Returns Applicable", Delivery = "** FREE Delivery **", Cancellation = "No Cancellation", Ratings ="4.5" },
        };
    }

    public class Product
    {
        public string Category { get; set; }
        public string Offers { get; set; }
        public string Cost { get; set; }
        public string Available { get; set; }
        public string ItemID { get; set; }
        public string ProductID { get; set; }
        public string Contact { get; set; }
        public string Status { get; set; }
        public string ProductImg { get; set; }
        public string ProductDesc { get; set; }
        public string ReturnPolicy { get; set; }
        public string Delivery { get; set; }
        public string Cancellation { get; set; }
        public string Ratings { get; set; }
    }
}
```

### Hierarchy Grid Exporting with Detail template

The DataGrid offers an option to export the hierarchical Grid to Excel using the detail template exporting feature. Customization of detail rows in the exported Excel is achievable through the [ExcelDetailTemplateExporting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_ExcelDetailTemplateExporting) event.

In the provided example, detail row content is formatted by specifyin the [Headers](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelDetailTemplateRowSettings.html#Syncfusion_Blazor_Grids_ExcelDetailTemplateRowSettings_Headers), [Rows](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelDetailTemplateRowSettings.html#Syncfusion_Blazor_Grids_ExcelDetailTemplateRowSettings_Rows) using parentRow details. Additionaly, this achieves a nested level of children using the [ChildRowInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelDetailTemplateRow.html#Syncfusion_Blazor_Grids_ExcelDetailTemplateRow_ChildRowInfo) property.


```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Data

<SfGrid @ref="DefaultGrid" ID="Grid" DataSource="@Employees" AllowExcelExport="true" Toolbar="@(new List<string>() { "ExcelExport"})">
    <GridTemplates>
        <DetailTemplate>
            @{
                var employee = (context as EmployeeData);
            }
            <SfGrid DataSource="@Orders" Query="@(new Query().Where("EmployeeID", "equal", employee.EmployeeID))">
                <GridTemplates>
                    <DetailTemplate Context="CustomerContext">
                        @{
                            var customer = (CustomerContext as Order);
                        }
                        <SfGrid DataSource="@OrderInfo" TValue="OrderDetails" Query="@(new Query().Where("OrderID", "equal", customer.OrderID))">
                            <GridColumns>
                                <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" TextAlign="TextAlign.Right" Width="110"> </GridColumn>
                                <GridColumn Field=@nameof(OrderDetails.Title) HeaderText="Title" Width="110"></GridColumn>
                                <GridColumn Field=@nameof(OrderDetails.Address) HeaderText="Address" TextAlign="TextAlign.Right" Width="90" Format="C2"></GridColumn>
                                <GridColumn Field=@nameof(OrderDetails.Country) HeaderText="Country" Width="110"></GridColumn>
                            </GridColumns>
                        </SfGrid>
                    </DetailTemplate>
                </GridTemplates>
                <GridColumns>
                    <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="110"> </GridColumn>
                    <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="110"></GridColumn>
                    <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" TextAlign="TextAlign.Right" Width="90" Format="C2"></GridColumn>
                    <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="110"></GridColumn>
                </GridColumns>
            </SfGrid>
        </DetailTemplate>
    </GridTemplates>
    <GridEvents ExcelDetailTemplateExporting="ExcelDetailTemplateHandler" OnToolbarClick="ToolbarClickHandler" TValue="EmployeeData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeData.EmployeeID) HeaderText="EmployeeID" Width="110"> </GridColumn>
        <GridColumn Field=@nameof(EmployeeData.FirstName) HeaderText="First Name" Width="110"> </GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Title) HeaderText="Title" Width="110"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Country) HeaderText="Country" Width="110"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    SfGrid<EmployeeData> DefaultGrid;
    public List<EmployeeData> Employees { get; set; }
    public List<OrderDetails> OrderInfo { get; set; }
    public static List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Employees = new List<EmployeeData>
        {
            new EmployeeData() {EmployeeID = 1, FirstName="Nancy",  Title="Sales Representative",City="Texas", Country="USA"},
            new EmployeeData() {EmployeeID = 2, FirstName="Andrew",  Title="Vice President",City="London", Country="UK"},
            new EmployeeData() {EmployeeID = 3, FirstName="Janet",  Title="Sales",City="London", Country="UK"},
            new EmployeeData() {EmployeeID = 4, FirstName="Margaret",  Title="Sales Manager",City="London", Country="UK"},
            new EmployeeData() {EmployeeID = 5, FirstName="Steven",  Title="Inside Sales Coordinator",City="Vegas", Country="USA"},
            new EmployeeData() {EmployeeID = 6, FirstName="Smith",  Title="HR Manager",City="Dubai", Country="UAE"},
            new EmployeeData() {EmployeeID = 7, FirstName="Steven",  Title="Inside Sales Coordinator",City="Paris", Country="France"},
            new EmployeeData() {EmployeeID = 8, FirstName="Smith",  Title="HR Manager",City="Mumbai", Country="India"},
            new EmployeeData() {EmployeeID = 9, FirstName="Smith",  Title="HR Manager",City="Chennai", Country="India"},
        };
        Orders = new List<Order>
        {
            new Order() {EmployeeID = 1, OrderID=1001, CustomerID="Nancy", ShipCity="Texas", Freight=2.1*1 },
            new Order() {EmployeeID = 2, OrderID=1002, CustomerID="Andrew", ShipCity="London", Freight=2.1*2},
            new Order() {EmployeeID = 3, OrderID=1003, CustomerID="Janet", ShipCity="London", Freight=2.1*3},
            new Order() {EmployeeID = 4, OrderID=1004, CustomerID="Margaret", ShipCity="London", Freight= 2.1*4},
            new Order() {EmployeeID = 5, OrderID=1005, CustomerID="Steven", ShipCity="Vegas", Freight=2.1*5},
            new Order() {EmployeeID = 6, OrderID=1006, CustomerID="Smith", ShipCity="Dubai", Freight=2.1*6},
            new Order() {EmployeeID = 7, OrderID=1007, CustomerID="Steven", ShipCity="Paris", Freight=2.1*7},
            new Order() {EmployeeID = 8, OrderID=1008, CustomerID="Smith", ShipCity="Mumbai", Freight=2.1*8},
            new Order() {EmployeeID = 9, OrderID=1009, CustomerID="Smith", ShipCity="Chennai", Freight=2.1*9},
            new Order() {EmployeeID = 2, OrderID=1010, CustomerID="Smith", ShipCity="Chennai", Freight=2.1*9},
            new Order() {EmployeeID = 3, OrderID=1011, CustomerID="Smith", ShipCity="Chennai", Freight=2.1*9},
            new Order() {EmployeeID = 3, OrderID=1012, CustomerID="Smith", ShipCity="Chennai", Freight=2.1*9},
        };

        OrderInfo = new List<OrderDetails>
        {
            new OrderDetails() { OrderID=1001, Title="Sales Representative", CustomerID="Nancy", Country="Germany", Address="Obere Str. 57" },
            new OrderDetails() { OrderID=1002, Title="HR Manager", CustomerID="Andrew", Country="Mexico", Address="Avda. de la Constitución 2222"},
            new OrderDetails() { OrderID=1003, Title="Vice President", CustomerID="Janet", Country="Mexico", Address="Mataderos 2312"},
            new OrderDetails() { OrderID=1004, Title="Inside Sales Coordinator", CustomerID="Margaret", Country="Mexico", Address="Mataderos 2312"},
            new OrderDetails() { OrderID=1005, Title="HR Manager", CustomerID="Steven", Country="Spain", Address="C/ Araquil, 67"},
            new OrderDetails() { OrderID=1006, Title="Vice President", CustomerID="Smith", Country="Mexico", Address="Avda. de la Constitución 2222"},
            new OrderDetails() { OrderID=1007, Title="Sales", CustomerID="Steven", Country="France", Address="24, place Kléber"},
            new OrderDetails() { OrderID=1008, Title="HR Manager", CustomerID="Smith", Country="Spain", Address="C/ Araquil, 67"},
            new OrderDetails() { OrderID=1009, Title="Sales", CustomerID="Smith", Country="Mexico", Address="Mataderos 2312"},
            new OrderDetails() { OrderID=1010, Title="Vice President", CustomerID="Smith", Country="Spain", Address="C/ Araquil, 67"},
            new OrderDetails() { OrderID=1011, Title="Inside Sales Coordinator", CustomerID="Smith", Country="Mexico", Address="Mataderos 2312"},
            new OrderDetails() { OrderID=1012, Title="HR Manager", CustomerID="Smith", Country="India", Address="45A "},
        };
    }

    public async Task ToolbarClickHandler(ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_excelexport")  // Id is the combination of Grid's ID and item name.
        {
            ExcelExportProperties ExportProperties = new ExcelExportProperties();
            ExportProperties.ExcelDetailRowMode = ExcelDetailRowMode.Expand;
            await this.DefaultGrid.ExportToExcelAsync(ExportProperties);
        }
    }

    public void ExcelDetailTemplateHandler(ExcelDetailTemplateEventArgs<EmployeeData> args)
    {
        var excelRows = new List<ExcelDetailTemplateRow>();
        var data = Orders.ToList().Where(_ => _.EmployeeID == args.ParentRow.Data.EmployeeID).ToList();
        for (var i = 0; i < data.Count(); i++)
        {
            var row = data[i];
            var childData = OrderInfo.ToList().Where(_ => _.OrderID == row.OrderID).ToList();
            var excelchildRows = new List<ExcelDetailTemplateRow>();
            var excelRow = ProcessExcelRow(new List<string>() { row.OrderID.ToString(), row.CustomerID.ToString(), row.Freight.ToString(), row.ShipCity });
            for (var j = 0; j < childData.Count; j++)
            {
                var childRow = childData[j];
                excelchildRows.Add(ProcessExcelRow(new List<string>() { childRow.CustomerID.ToString(), childRow.Title.ToString(), childRow.Address.ToString(), childRow.Country }));
            }
            excelRow.ChildRowInfo = new ExcelDetailTemplateRowSettings() { Headers = new List<ExcelDetailTemplateRow>() { ProcessExcelRow(new List<string>() { "Customer Name", "Title", "Address", "Country" }) }, Rows = excelchildRows };
            excelRows.Add(excelRow);
        }
        args.RowInfo.Headers = new List<ExcelDetailTemplateRow>() { ProcessExcelRow(new List<string>() { "Order ID", "Customer ID", "Freight", "Ship City" }) };
        args.RowInfo.Rows = excelRows;
    }

    ExcelDetailTemplateRow ProcessExcelRow(List<string> value)
    {
        var cells = new List<ExcelDetailTemplateCell>();
        for (var j = 0; j < value.Count(); j++)
        {
            cells.Add(new ExcelDetailTemplateCell { CellValue = $"{value[j]}", Index = j });
        }
        return new ExcelDetailTemplateRow { Cells = cells };
    }

    public class EmployeeData
    {
        public int? EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
    public class Order
    {
        public int OrderID { get; set; }
        public int? EmployeeID { get; set; }
        public string CustomerID { get; set; }
        public double Freight { get; set; }
        public string ShipCity { get; set; }
    }

    public class OrderDetails
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
    }
}
```

## Exporting grouped records

The excel export provides outline option for grouped records which hides the detailed data for better viewing.
In datagrid, we have provided the outline option for the exported document when the data's are grouped.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" AllowGrouping="true" Toolbar="@(new List<string>() { "ExcelExport" })" AllowExcelExport="true" AllowPaging="true">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridGroupSettings Columns="@(new string[] {"OrderDate"})"></GridGroupSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Visible="false" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;

    public List<Order> Orders { get; set; }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
       if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname
        {
            await this.DefaultGrid.ExcelExport();
        }
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

### Limitations

Microsoft Excel permits up to seven nested levels in outlines. So that in the datagrid we can able to provide only up to seven nested levels and if it exceeds more than seven levels then the document will be exported without outline option. Refer the [Microsoft Limitation](https://learn.microsoft.com/en-us/sql/reporting-services/report-builder/exporting-to-microsoft-excel-report-builder-and-ssrs?view=sql-server-2017#ExcelLimitations)

## How to export the Grid with specific columns

You can export the Excel grid with specific columns instead of all columns which are defined in the Grid definition. To achieve this scenario by using [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html#Syncfusion_Blazor_Grids_ExcelExportProperties_Columns) property of the [ExcelExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html) class.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" AllowExcelExport="true" AllowPaging="true" Toolbar="@(new List<string>() { "ExcelExport" })">
    <GridEvents OnToolbarClick="OnToolbarClick" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;

    public List<Order> Orders { get; set; }

    public async Task OnToolbarClick(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
       if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname
        {
            ExcelExportProperties ExportProperties = new ExcelExportProperties();
            List<GridColumn> ExportColumns = new List<GridColumn>();
#pragma warning disable BL0005
            ExportColumns.Add(new GridColumn() { Field = "CustomerID", HeaderText = "Customer Name", Width = "100" });
            ExportColumns.Add(new GridColumn() { Field = "OrderDate", HeaderText = "Date", Width = "120", Format = "d" });
            ExportColumns.Add(new GridColumn() { Field = "Freight", HeaderText = "Freight", Width = "120", Format = "C2", TextAlign = TextAlign.Right });
#pragma warning restore BL0005
            ExportProperties.Columns = ExportColumns;
            await this.DefaultGrid.ExcelExport(ExportProperties);
        }
    }
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 15).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            ShipCountry = (new string[] { "Germany", "UK", "USA", "Italy", "France" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCountry { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

<!-- Multiple datagrid exporting

The excel export provides option to export multiple datagrid data in the same excel file.

Same sheet

The excel export provides support to export multiple grids in the same sheet. To export in same sheet, set the [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.MultipleExport.html#Syncfusion_Blazor_Grids_MultipleExport_Type) value of [`MultipleExport`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html#Syncfusion_Blazor_Grids_ExcelExportProperties_MultipleExport) property as **AppendToSheet** in the [`ExcelExportProperties`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html) class. It is possible to provide blank rows between the grids. The blank rows count can be set by defining the value in [`BlankRows`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.MultipleExport.html#Syncfusion_Blazor_Grids_MultipleExport_BlankRows) of [`MultipleExport`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html#Syncfusion_Blazor_Grids_ExcelExportProperties_MultipleExport) property. 

This is demonstrated in the below sample code block,

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids

<SfButton OnClick="ExcelExport" Content="Excel Export"></SfButton>
<SfGrid @ref="FirstGrid" DataSource="@Orders1" AllowExcelExport="true" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
<SfGrid @ref="SecondGrid" DataSource="@Orders2" AllowExcelExport="true" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> FirstGrid;
    private SfGrid<Order> SecondGrid;

    public List<Order> Orders1 { get; set; }
    public List<Order> Orders2 { get; set; }

    protected override void OnInitialized()
    {
        Orders1 = Enumerable.Range(1, 15).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
        Orders2 = Enumerable.Range(1, 15).Select(x => new Order()
        {
            OrderID = 2000 + x,
            CustomerID = (new string[] { "JANET", "MARGARET", "NANCY", "STEVEN", "VINET" })[new Random().Next(5)],
            Freight = 3.1 * x,
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

    public void ExcelExport()
    {
        ExcelExportProperties ExcelProperties = new ExcelExportProperties();
        
        MultipleExport MultipleExportProperties = new MultipleExport()
        {
            Type = MultipleExportType.AppendToSheet,
            BlankRows = 2
        };

        ExcelProperties.MultipleExport = MultipleExportProperties;

        var ExportData = this.FirstGrid.ExcelExport(ExcelProperties, true);
        ExportData.ContinueWith((ExcelData) =>
        {
            this.SecondGrid.ExcelExport(ExcelProperties, false, ExcelData);
        });
    }
}
```

> By default, [`BlankRows`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.MultipleExport.html#Syncfusion_Blazor_Grids_MultipleExport_BlankRows) value is 5. -->

<!-- New sheet

The excel export provides support to export multiple grids in new sheet. To export in new sheet, set the [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.MultipleExport.html#Syncfusion_Blazor_Grids_MultipleExport_Type) value of [`MultipleExport`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html#Syncfusion_Blazor_Grids_ExcelExportProperties_MultipleExport) property as **NewSheet** in the [`ExcelExportProperties`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html) class.

This is demonstrated in the below sample code block,

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids

<SfButton OnClick="ExcelExport" Content="Excel Export"></SfButton>
<SfGrid @ref="FirstGrid" DataSource="@Orders1" AllowExcelExport="true" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
<SfGrid @ref="SecondGrid" DataSource="@Orders2" AllowExcelExport="true" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> FirstGrid;
    private SfGrid<Order> SecondGrid;

    public List<Order> Orders1 { get; set; }
    public List<Order> Orders2 { get; set; }

    protected override void OnInitialized()
    {
        Orders1 = Enumerable.Range(1, 15).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
        Orders2 = Enumerable.Range(1, 15).Select(x => new Order()
        {
            OrderID = 2000 + x,
            CustomerID = (new string[] { "JANET", "MARGARET", "NANCY", "STEVEN", "VINET" })[new Random().Next(5)],
            Freight = 3.1 * x,
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

    public void ExcelExport()
    {
        ExcelExportProperties ExcelProperties = new ExcelExportProperties();
        
        MultipleExport MultipleExportProperties = new MultipleExport()
        {
            Type = MultipleExportType.NewSheet
        };

        ExcelProperties.MultipleExport = MultipleExportProperties;

        var ExportData = this.FirstGrid.ExcelExport(ExcelProperties, true);
        ExportData.ContinueWith((ExcelData) =>
        {
            this.SecondGrid.ExcelExport(ExcelProperties, false, ExcelData);
        });
    }
}
``` -->

## Custom data source

Excel export provides an option to define the datasource dynamically before exporting. To export data dynamically, define it in the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html#Syncfusion_Blazor_Grids_ExcelExportProperties_DataSource) property of the [ExcelExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html) class.

The following sample code demonstrates dynamically modifying the data source before exporting it,

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" AllowExcelExport="true" AllowPaging="true" Toolbar="@(new List<string>() { "ExcelExport" })">
    <GridEvents OnToolbarClick="OnToolbarClick" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;

    public List<Order> Orders { get; set; }

    public async Task OnToolbarClick(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
       if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname
        {
            ExcelExportProperties ExcelProperties = new ExcelExportProperties();
            ExcelProperties.DataSource = Orders;
            await this.DefaultGrid.ExcelExport(ExcelProperties);
        }
    }
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 15).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            ShipCountry = (new string[] { "Germany", "UK", "USA", "Italy", "France" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCountry { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

## Customizing columns

Excel export provides an option to define the columns dynamically before exporting. You can define the dynamic columns using [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html#Syncfusion_Blazor_Grids_ExcelExportProperties_Columns) property of the [ExcelExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html) class.

The following sample code demonstrates dynamically adding `ShipCountry` column in the exported excel file,

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" AllowExcelExport="true" AllowPaging="true" Toolbar="@(new List<string>() { "ExcelExport" })">
    <GridEvents OnToolbarClick="OnToolbarClick" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;

    public List<Order> Orders { get; set; }

    public async Task OnToolbarClick(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
       if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname
        {
            ExcelExportProperties ExportProperties = new ExcelExportProperties();
            var columns = await DefaultGrid.GetColumns();     //get the columns available in Grid
            columns.Add(new GridColumn() { Field = "ShipCountry" });      //adding additional column
            ExportProperties.Columns = columns;
            await DefaultGrid.ExcelExport(ExportProperties);
        }
    }
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 15).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            ShipCountry = (new string[] { "Germany", "UK", "USA", "Italy", "France" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCountry { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

N> You can refer to our [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap4) to understand how to present and manipulate data.

<!-- Export the hierarchy datagrid

The datagrid has option to export hierarchy datagrid to the excel document. By default, datagrid exports the master datagrid with expanded child grids alone. The exporting option can be modified by using the [`HierarchyExportMode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html#Syncfusion_Blazor_Grids_ExcelExportProperties_HierarchyExportMode) property of the [`ExcelExportProperties`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html) class.

The available options are,

| Mode | Behavior |
|-------|---------|
| Expanded | Exports the master datagrid with expanded child grids.|
| All | Exports the master datagrid with all the child grids.|
| None | Exports the master datagrid alone. |

The following sample code demonstrates modifying the export options for hierarchy datagrid,

```cshtml
@using Syncfusion.Blazor.Buttons
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

<SfButton OnClick="ExcelExport" Content="Excel Export"></SfButton>
<SfGrid @ref="DefaultGrid" DataSource="@Employees" ChildGrid="ChildGridData" Height="315px" AllowExcelExport="true" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeData.EmployeeID) HeaderText="EmployeeID" Width="110"> </GridColumn>
        <GridColumn Field=@nameof(EmployeeData.FirstName) HeaderText="First Name" Width="110"> </GridColumn>
        <GridColumn Field=@nameof(EmployeeData.City) HeaderText="Last Name" Width="110"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Country) HeaderText="Country" Width="110"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<EmployeeData> DefaultGrid;

    public List<EmployeeData> Employees { get; set; }

    public List<Order> Orders { get; set; }

    public string[] ExportMode = new string[] { "Expanded" };

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

    public void ExcelExport()
    {
        ExcelExportProperties ExcelProperties = new ExcelExportProperties();
        ExcelProperties.HierarchyExportMode = ExportMode;
        this.DefaultGrid.ExcelExport(ExcelProperties);
    }
}
``` -->

## Exporting Grid Data as Stream

### Exporting Grid Data as Memory Stream
This section shows how to invoke a [ExportToExcelAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExportToExcelAsync_System_Int32_System_Int32_System_Int32_) method to export an excel workbook as a memory stream.

To obtain the export file as a memory stream, set the `asMemoryStream` parameter to true within the `ExportToExcelAsync` method.

The provided example showcases the process of exporting the file as a memory stream and sending the byte to initiate a browser download.

**Step 1**: **Create a JavaScript file to execute browser downloads and copy the code below**

```cshtml
function saveAsFile(filename, bytesBase64) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/octet-stream;base64," + bytesBase64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}
```
**Step 2**: **Invoke the JavaScript file to carry out browser downloads using the memory stream**

```cshtml
@using Syncfusion.Blazor.Grids
@using System.IO;
@using Syncfusion.Pdf
@using Syncfusion.XlsIO
@using Syncfusion.PdfExport;
@using Syncfusion.ExcelExport;
@inject IJSRuntime JSRuntime

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" Toolbar="@(new List<string>() { "ExcelExport"})" AllowExcelExport="true" AllowPaging="true">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;
    public List<Order> Orders { get; set; }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {       
        if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname
        {           
           MemoryStream streamDoc =  await DefaultGrid.ExportToExcelAsync(asMemoryStream: true);
           await JSRuntime.InvokeVoidAsync("saveAsFile", new object[] { "ExcelStream.xlsx", Convert.ToBase64String(streamDoc.ToArray()), true });
        }
    }
    public List<Order> GetAllRecords()
    {
        List<Order> data = new List<Order>();
        int count = 1000;
        for (int i = 0; i < 15; i++)
        {
            data.Add(new Order() { OrderID = count + 1, CustomerID = "ALFKI", OrderDate = new DateTime(1995, 05, 15), Freight = 25.7 * 2 });
            data.Add(new Order() { OrderID = count + 2, CustomerID = "ANANTR", OrderDate = new DateTime(1994, 04, 04), Freight = 26.7 * 2 });
            data.Add(new Order() { OrderID = count + 3, CustomerID = "BLONP", OrderDate = new DateTime(1993, 03, 10), Freight = 27.7 * 2 });
            data.Add(new Order() { OrderID = count + 4, CustomerID = "ANTON", OrderDate = new DateTime(1992, 02, 14), Freight = 28.7 * 2 });
            data.Add(new Order() { OrderID = count + 5, CustomerID = "BOLID", OrderDate = new DateTime(1991, 01, 18), Freight = 29.7 * 2 });
            count += 5;
        }
        return data;
    }
    protected override void OnInitialized()
    {
        Orders = GetAllRecords();
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

### Converting Memory Stream to File Stream for Excel Export

This section explains the process of converting a memory stream obtained from the `ExportToExcelAsync` method into a file stream to export excel workbook.

The example provided demonstrates this process of exporting the excel workboox from the file stream.

 ```cshtml
@using Syncfusion.Blazor.Grids
@using System.IO;
@using Syncfusion.Pdf
@using Syncfusion.XlsIO
@using Syncfusion.PdfExport;
@using Syncfusion.ExcelExport;
@inject IJSRuntime JSRuntime

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" Toolbar="@(new List<string>() { "ExcelExport"})" AllowExcelExport="true" AllowPaging="true">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;
    public List<Order> Orders { get; set; }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {       
        if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname
        {
            MemoryStream streamDoc =  await DefaultGrid.ExportToExcelAsync(asMemoryStream: true);
            
            //Create a copy of streamDoc1 to read the memory stream
            MemoryStream copyOfStreamDoc1 = new MemoryStream(streamDoc.ToArray());

            //For creating the exporting location with file name, for this need to specify the physical exact path of the file
            string filePaths = "C:Users/abc/Downloads/SampleTestExcel.xlsx";

            // Create a FileStream to write the memoryStream contents to a file
            using (FileStream fileStream = File.Create(filePaths))
            {
                // Copy the MemoryStream data to the FileStream
                copyOfStreamDoc1.CopyTo(fileStream);
            }
        }
    }
    public List<Order> GetAllRecords()
    {
        List<Order> data = new List<Order>();
        int count = 1000;
        for (int i = 0; i < 15; i++)
        {
            data.Add(new Order() { OrderID = count + 1, CustomerID = "ALFKI", OrderDate = new DateTime(1995, 05, 15), Freight = 25.7 * 2 });
            data.Add(new Order() { OrderID = count + 2, CustomerID = "ANANTR", OrderDate = new DateTime(1994, 04, 04), Freight = 26.7 * 2 });
            data.Add(new Order() { OrderID = count + 3, CustomerID = "BLONP", OrderDate = new DateTime(1993, 03, 10), Freight = 27.7 * 2 });
            data.Add(new Order() { OrderID = count + 4, CustomerID = "ANTON", OrderDate = new DateTime(1992, 02, 14), Freight = 28.7 * 2 });
            data.Add(new Order() { OrderID = count + 5, CustomerID = "BOLID", OrderDate = new DateTime(1991, 01, 18), Freight = 29.7 * 2 });
            count += 5;
        }
        return data;
    }
    protected override void OnInitialized()
    {
        Orders = GetAllRecords();
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

### Merging Two Excel Memory Streams

This section explains the process of combining two memory stream files and exporting the resulting merged file as a excel workbook, To copy a worksheet between workbooks or within the same workbook, utilize the capabilities of the package  [Syncfusion.Blazor.XlslO](https://www.nuget.org/packages/Syncfusion.XlsIO.Net.Core/).

The example below demonstrates how to merge two memory streams and export that merged memory stream for browser download.

In this example, there are two memory streams: *streamDoc1* and *streamDoc2*. streamDoc1 represents the normal grid memory stream, while streamDoc2 contains the memory stream of a customized grid using the [ExcelExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html) class. The merging process combines the contents of streamDoc1 with streamDoc2, resulting in a combined workbook saved as a memory stream. This merged memory stream is then utilized to initiate the browser download.

 ```cshtml
@using Syncfusion.Blazor.Grids
@using System.IO;
@using Syncfusion.Pdf
@using Syncfusion.XlsIO
@using Syncfusion.PdfExport;
@using Syncfusion.ExcelExport;
@inject IJSRuntime JSRuntime

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" Toolbar="@(new List<string>() { "ExcelExport"})" AllowExcelExport="true" AllowPaging="true">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;
    public List<Order> Orders { get; set; }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {       
        if (args.Item.Id == "Grid_excelexport") //Id is combination of Grid's ID and itemname
        {
            //Merging two memory stream for excel export
            MemoryStream mergedStream = new MemoryStream();

            MemoryStream streamDoc1 = await DefaultGrid.ExportToExcelAsync(asMemoryStream: true);
            //Create a copy of streamDoc1 to access the memory stream
            MemoryStream copyOfStreamDoc1 = new MemoryStream(streamDoc1.ToArray());
            
            //Cusotmized grid memory stream
            ExcelExportProperties ExcelProperties = new ExcelExportProperties();
            ExcelTheme Theme = new ExcelTheme();
            ExcelStyle ThemeStyle = new ExcelStyle()
            {
                BackColor = "#C67878"
            };
            Theme.Header = ThemeStyle;
            Theme.Record = ThemeStyle;
            ExcelProperties.Theme = Theme;
            MemoryStream streamDoc2 = await DefaultGrid.ExportToExcelAsync(asMemoryStream: true, ExcelProperties);
            //Create a copy of streamDoc2 to access the memory stream
            MemoryStream copyOfStreamDoc2 = new MemoryStream(streamDoc2.ToArray());

            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Xlsx;
                IWorkbook workbook1 = application.Workbooks.Open(copyOfStreamDoc1);
                IWorkbook workbook2 = application.Workbooks.Open(copyOfStreamDoc2);

                //Copy first worksheet from the workbook1 workbook to the workbook2 workbook
                workbook2.Worksheets.AddCopy(workbook1.Worksheets[0]);
                workbook2.ActiveSheetIndex = 1;

                //Saving merged workbook as memorystream
                workbook2.SaveAs(mergedStream);
            }

            await JSRuntime.InvokeVoidAsync("saveAsFile", new object[] { "MemoryStreamMerge.xlsx", Convert.ToBase64String(mergedStream.ToArray()), true });
        }
    }
    public List<Order> GetAllRecords()
    {
        List<Order> data = new List<Order>();
        int count = 1000;
        for (int i = 0; i < 15; i++)
        {
            data.Add(new Order() { OrderID = count + 1, CustomerID = "ALFKI", OrderDate = new DateTime(1995, 05, 15), Freight = 25.7 * 2 });
            data.Add(new Order() { OrderID = count + 2, CustomerID = "ANANTR", OrderDate = new DateTime(1994, 04, 04), Freight = 26.7 * 2 });
            data.Add(new Order() { OrderID = count + 3, CustomerID = "BLONP", OrderDate = new DateTime(1993, 03, 10), Freight = 27.7 * 2 });
            data.Add(new Order() { OrderID = count + 4, CustomerID = "ANTON", OrderDate = new DateTime(1992, 02, 14), Freight = 28.7 * 2 });
            data.Add(new Order() { OrderID = count + 5, CustomerID = "BOLID", OrderDate = new DateTime(1991, 01, 18), Freight = 29.7 * 2 });
            count += 5;
        }
        return data;
    }
    protected override void OnInitialized()
    {
        Orders = GetAllRecords();
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


## See also
* [How to import data from Excel sheet and bind to Blazor Grid?](https://www.syncfusion.com/kb/13131/how-to-import-data-from-excel-sheet-and-bind-to-blazor-grid)
* [Export data from Grid to Excel in different worksheets in Blazor](https://www.syncfusion.com/forums/175479/export-data-to-excel-in-different-worksheets)

