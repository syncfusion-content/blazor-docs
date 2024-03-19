---
layout: post
title: Pdf Export in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Pdf Export in Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

<!-- markdownlint-disable MD033 -->

# PDF Export in Blazor DataGrid Component

PDF export allows exporting DataGrid data to PDF document. You need to use the
 **PdfExport** method for exporting. To enable PDF export in the datagrid, set the [AllowPdfExport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowPdfExport) as true.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" Toolbar="@(new List<string>() { "PdfExport" })" AllowPdfExport="true" AllowPaging="true">
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
       if (args.Item.Id == "Grid_pdfexport")  //Id is combination of Grid's ID and itemname
        {
            await this.DefaultGrid.PdfExport();
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

<!-- Multiple exporting

PDF export provides an option for exporting multiple grids to same file. In this exported document, each datagrid will be exported to new page of document in same file.

This is demonstrated in the below sample code block,

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids

<SfButton OnClick="PdfExport" Content="Pdf Export"></SfButton>
<SfGrid @ref="FirstGrid" DataSource="@Orders1" AllowPdfExport="true" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
<br />
<br />
<SfGrid @ref="SecondGrid" DataSource="@Orders2" AllowPdfExport="true" AllowPaging="true">
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

    public void PdfExport()
    {
        var ExportData = this.FirstGrid.PdfExport(null, true);
        ExportData.ContinueWith((PdfData) => {
            this.SecondGrid.PdfExport(null, false, PdfData);
        });
    }
}
``` -->

## To customize PDF export

PDF export provides an option to customize mapping of datagrid to exported PDF document.

### File name for exported document

You can assign the file name for the exported document by defining **fileName** property in **PdfExportProperties**.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" Toolbar="@(new List<string>() { "PdfExport" })" AllowPdfExport="true" AllowPaging="true">
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
       if (args.Item.Id == "Grid_pdfexport")  //Id is combination of Grid's ID and itemname
        {
            PdfExportProperties ExportProperties = new PdfExportProperties();
            ExportProperties.FileName = "test.pdf";
            await this.DefaultGrid.PdfExport(ExportProperties);
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

<!-- Default fonts for pdf exporting

By default, datagrid uses **Helvetica** font in the exported document. You can change the default font by using [`Theme`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html#Syncfusion_Blazor_Grids_PdfExportProperties_Theme) property of [`PdfExportProperties`](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html).

The available fonts are,

* Helvetica
* TimesRoman
* Courier
* Symbol
* ZapfDingbats

The following sample code demonstrates changing the default font value on exported document,

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids

<SfButton OnClick="PdfExport" Content="Pdf Export"></SfButton>
<SfGrid @ref="DefaultGrid" DataSource="@Orders" AllowSorting="true" AllowPdfExport="true" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@functions{
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

    public void PdfExport()
    {
        PdfExportProperties ExportProperties = new PdfExportProperties();
        PdfTheme Theme = new PdfTheme();

        string[] HeaderFont = new string[] { "TimesRoman" };

        PdfThemeStyle HeaderThemeStyle = new PdfThemeStyle()
        {
            Font = HeaderFont,
        };
        Theme.Header = HeaderThemeStyle;

        PdfThemeStyle RecordThemeStyle = new PdfThemeStyle()
        {
            Font = HeaderFont

        };
        Theme.Record = RecordThemeStyle;

        PdfThemeStyle CaptionThemeStyle = new PdfThemeStyle()
        {
            Font = HeaderFont

        };
        Theme.Caption = CaptionThemeStyle;

        ExportProperties.Theme = Theme;
        this.DefaultGrid.PdfExport(ExportProperties);
    }
    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
``` -->

<!-- Add custom font for pdf exporting

You can change the default font of Grid header, content, and caption cells in the exported document by using the [Theme](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html#Syncfusion_Blazor_Grids_PdfExportProperties_Theme) property of [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html).

The following sample code demonstrates changing the default font value to custom font on exported document,

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids

<SfButton OnClick="PdfExport" Content="Pdf Export"></SfButton>
<SfGrid @ref="DefaultGrid" DataSource="@Orders" AllowSorting="true" AllowPdfExport="true" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@functions{
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

    public void PdfExport()
    {
        PdfExportProperties ExportProperties = new PdfExportProperties();
        PdfTheme Theme = new PdfTheme();

        string[] HeaderFont = new string[] { "TimesRoman" };

        PdfThemeStyle HeaderThemeStyle = new PdfThemeStyle()
        {
            Font = HeaderFont,
        };
        Theme.Header = HeaderThemeStyle;

        PdfThemeStyle RecordThemeStyle = new PdfThemeStyle()
        {
            Font = HeaderFont

        };
        Theme.Record = RecordThemeStyle;

        PdfThemeStyle CaptionThemeStyle = new PdfThemeStyle()
        {
            Font = HeaderFont

        };
        Theme.Caption = CaptionThemeStyle;

        ExportProperties.Theme = Theme;
        this.DefaultGrid.PdfExport(ExportProperties);
    }
    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
``` -->

### To add header and footer

You can customize text, page number, line, page size and changing orientation in header and footer of the exported document.

#### How to add a text in header/footer

You can add text and customize its styles either in Header or Footer of exported PDF document using [Header](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html#Syncfusion_Blazor_Grids_PdfExportProperties_Header) and [Footer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html#Syncfusion_Blazor_Grids_PdfExportProperties_Footer) properties of the [PdfExportProperties](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) class.

The following sample code demonstrates adding text and customizing its styles in the Header section of the exported document,

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" Toolbar="@(new List<string>() { "PdfExport" })" AllowPdfExport="true" AllowPaging="true">
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

    public List<PdfHeaderFooterContent> HeaderContent = new List<PdfHeaderFooterContent>
{
        new PdfHeaderFooterContent() { Type = ContentType.Text, Value = "Northwind Traders", Position = new PdfPosition() { X = 0, Y = 50 }, Style = new PdfContentStyle() { TextBrushColor = "#000000", FontSize = 13 } }
    };

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
       if (args.Item.Id == "Grid_pdfexport")  //Id is combination of Grid's ID and itemname
        {
            PdfExportProperties ExportProperties = new PdfExportProperties();
            PdfHeader Header = new PdfHeader()
            {
                FromTop = 0,
                Height = 130,
                Contents = HeaderContent
            };

            ExportProperties.Header = Header;
            await this.DefaultGrid.PdfExport(ExportProperties);
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

#### How to draw a line in header/footer

You can add line either in the Header or Footer area of the exported PDF document using [Header](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html#Syncfusion_Blazor_Grids_PdfExportProperties_Header) and [Footer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html#Syncfusion_Blazor_Grids_PdfExportProperties_Footer) properties of the [PdfExportProperties](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) class.

Supported line styles are,

* Dash
* Dot
* DashDot
* DashDotDot
* Solid

The following sample code demonstrates adding line in the Header section of the exported document,

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" Toolbar="@(new List<string>() { "PdfExport" })" AllowPdfExport="true" AllowPaging="true">
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

    public List<PdfHeaderFooterContent> HeaderContent = new List<PdfHeaderFooterContent>
    {
        new PdfHeaderFooterContent() { Type = ContentType.Line, Points = new PdfPoints() { X1 = 0, Y1 = 4, X2 = 685, Y2 = 4 }, Style = new PdfContentStyle() { PenColor = "#000080", DashStyle = PdfDashStyle.Solid } }
    };

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
       if (args.Item.Id == "Grid_pdfexport")  //Id is combination of Grid's ID and itemname
        {
            PdfExportProperties ExportProperties = new PdfExportProperties();
            PdfHeader Header = new PdfHeader()
            {
                FromTop = 0,
                Height = 130,
                Contents = HeaderContent
            };

            ExportProperties.Header = Header;
            await this.DefaultGrid.PdfExport(ExportProperties);
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

#### How to add repeat headers in PDF Export

You can add headers for every page of PDF exported document by enabling [IsRepeatHeader](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html#Syncfusion_Blazor_Grids_PdfExportProperties_IsRepeatHeader) property of the [PdfExportProperties](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) class.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" Toolbar="@(new List<string>() { "PdfExport" })" AllowPdfExport="true" AllowPaging="true">
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
       if (args.Item.Id == "Grid_pdfexport")  //Id is combination of Grid's ID and itemname
        {
            PdfExportProperties ExportProperties = new PdfExportProperties();
            ExportProperties.IsRepeatHeader = true;
            await this.DefaultGrid.PdfExport(ExportProperties);
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

#### How to export the Grid with specific columns

You can export the PDF grid with specific columns instead of all columns which are defined in the Grid definition. To achieve this scenario by using [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html#Syncfusion_Blazor_Grids_PdfExportProperties_Columns) property of the [PdfExportProperties](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) class.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" Toolbar="@(new List<string>() { "PdfExport" })" AllowPdfExport="true" AllowPaging="true">
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
       if (args.Item.Id == "Grid_pdfexport")  //Id is combination of Grid's ID and itemname
        {
            PdfExportProperties ExportProperties = new PdfExportProperties();
            List<GridColumn> ExportColumns = new List<GridColumn>();
#pragma warning disable BL0005
            ExportColumns.Add(new GridColumn() { Field = "CustomerID", HeaderText = "Customer Name", Width = "100" });
            ExportColumns.Add(new GridColumn() { Field = "OrderDate", HeaderText = "Date", Width = "120", Format = "d" });
            ExportColumns.Add(new GridColumn() { Field = "Freight", HeaderText = "Freight", Width = "120", Format = "C2", TextAlign = TextAlign.Right });
#pragma warning restore BL0005
            ExportProperties.Columns = ExportColumns;

            await this.DefaultGrid.PdfExport(ExportProperties);
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

#### Add page number in header/footer

You can add page number either in Header or Footer area of exported PDF document using [Header](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html#Syncfusion_Blazor_Grids_PdfExportProperties_Header) and [Footer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html#Syncfusion_Blazor_Grids_PdfExportProperties_Footer) properties of the [PdfExportProperties](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) class.

Supported page number types are,

* LowerLatin - a, b, c,
* UpperLatin - A, B, C,
* LowerRoman - i, ii, iii,
* UpperRoman - I, II, III,
* Number - 1,2,3.

The following sample code demonstrates adding page number in the Header section of the exported document,

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" Toolbar="@(new List<string>() { "PdfExport" })" AllowPdfExport="true" AllowPaging="true">
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

    public List<PdfHeaderFooterContent> HeaderContent = new List<PdfHeaderFooterContent>
{
        new PdfHeaderFooterContent() { Type = ContentType.PageNumber, PageNumberType = PdfPageNumberType.Arabic, Position = new PdfPosition() { X = 0, Y = 25 }, Style = new PdfContentStyle() { TextBrushColor = "#0000ff", FontSize = 12, HAlign = PdfHorizontalAlign.Center } }
    };

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
       if (args.Item.Id == "Grid_pdfexport")  //Id is combination of Grid's ID and itemname
        {
            PdfExportProperties ExportProperties = new PdfExportProperties();
            PdfHeader Header = new PdfHeader()
            {
                FromTop = 0,
                Height = 130,
                Contents = HeaderContent
            };

            ExportProperties.Header = Header;
            await this.DefaultGrid.PdfExport(ExportProperties);
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

#### Insert an image in header/footer

Image (Base64 string) can be added in header/footer area of the exported PDF document using [Header](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html#Syncfusion_Blazor_Grids_PdfExportProperties_Header) and [Footer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html#Syncfusion_Blazor_Grids_PdfExportProperties_Footer) properties of the [PdfExportProperties](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) class.

The following sample code demonstrates inserting image in the Header section of the exported document,

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" Toolbar="@(new List<string>() { "PdfExport" })" AllowPdfExport="true" AllowPaging="true">
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

    public List<PdfHeaderFooterContent> HeaderContent = new List<PdfHeaderFooterContent>
    {
        new PdfHeaderFooterContent() { Type = ContentType.Image, Src = "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", Position = new PdfPosition() { X = 40, Y = 10 }, Size = new PdfSize() { Height = 100, Width = 250 } }
    };

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
       if (args.Item.Id == "Grid_pdfexport")  //Id is combination of Grid's ID and itemname
        {
            PdfExportProperties ExportProperties = new PdfExportProperties();
            PdfHeader Header = new PdfHeader()
            {
                FromTop = 0,
                Height = 130,
                Contents = HeaderContent
            };

            ExportProperties.Header = Header;
            await this.DefaultGrid.PdfExport(ExportProperties);
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

### How to change page orientation

Page orientation can be changed Landscape(Default Portrait) for the exported document using the export properties.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" Toolbar="@(new List<string>() { "PdfExport" })" AllowPdfExport="true" AllowPaging="true">
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
       if (args.Item.Id == "Grid_pdfexport")  //Id is combination of Grid's ID and itemname
        {
            PdfExportProperties ExportProperties = new PdfExportProperties();
            ExportProperties.PageOrientation = Syncfusion.Blazor.Grids.PageOrientation.Landscape;
            await this.DefaultGrid.PdfExport(ExportProperties);
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

### How to change page size

Page size can be customized for the exported document using the export properties.

Supported page sizes are:

* Letter
* Note
* Legal
* A0
* A1
* A2
* A3
* A5
* A6
* A7
* A8
* A9
* B0
* B1
* B2
* B3
* B4
* B5
* Archa
* Archb
* Archc
* Archd
* Arche
* Flsa
* HalfLetter
* Letter11x17
* Ledger

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" Toolbar="@(new List<string>() { "PdfExport" })" AllowPdfExport="true" AllowPaging="true">
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
       if (args.Item.Id == "Grid_pdfexport")  //Id is combination of Grid's ID and itemname
        {
            PdfExportProperties ExportProperties = new PdfExportProperties();
            ExportProperties.PageSize = PdfPageSize.Letter;
            await this.DefaultGrid.PdfExport(ExportProperties);
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

### Export current page

PDF export provides an option to export the current page into PDF. To export current page, define the **exportType** to **CurrentPage**.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" Toolbar="@(new List<string>() { "PdfExport" })" AllowPdfExport="true" AllowPaging="true">
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
       if (args.Item.Id == "Grid_pdfexport")  //Id is combination of Grid's ID and itemname
        {
            PdfExportProperties ExportProperties = new PdfExportProperties();
            ExportProperties.ExportType = ExportType.CurrentPage;
            await this.DefaultGrid.PdfExport(ExportProperties);
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

PDF export provides an option to export hidden columns of DataGrid by defining the [IncludeHiddenColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html#Syncfusion_Blazor_Grids_PdfExportProperties_IncludeHiddenColumn) as **true**.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" Toolbar="@(new List<string>() { "PdfExport" })" AllowPdfExport="true" AllowPaging="true">
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
       if (args.Item.Id == "Grid_pdfexport")  //Id is combination of Grid's ID and itemname
        {
            PdfExportProperties ExportProperties = new PdfExportProperties();
            ExportProperties.IncludeHiddenColumn = true;
            await this.DefaultGrid.PdfExport(ExportProperties);
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

The Grid has an option to export the selected records in a pdf exported document. This can be achieved by using the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html#Syncfusion_Blazor_Grids_PdfExportProperties_DataSource) property of the [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) class and the [GetSelectedRecordsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetSelectedRecordsAsync) method of the Grid.

In the following sample, selected records will be gotten from the `GetSelectedRecordsAsync` method and provided to the` DataSource` property of `PdfExportProperties`. Then pass this PdfExportProperties class to the [ExportToPdfAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExportToPdfAsync_Syncfusion_Blazor_Grids_PdfExportProperties_System_Nullable_System_Boolean__System_Object_System_Nullable_System_Boolean__) method to get the selected records in the exported document.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" AllowPdfExport="true" AllowPaging="true"
        Toolbar="@(new List<string>() { "PdfExport" })" AllowSelection="true">
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
        if (args.Item.Id == "Grid_pdfexport") //Id is combination of Grid's ID and itemname
        {
            PdfExportProperties PdfProperties = new PdfExportProperties();
            var selectedRecord = await DefaultGrid.GetSelectedRecordsAsync();
            if(selectedRecord.Count() > 0)
            {
                PdfProperties.DataSource = selectedRecord;
            }
            else
            {
                PdfProperties.DataSource = Orders;
            }
            await this.DefaultGrid.ExportToPdfAsync(PdfProperties);
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

### Theme

PDF export provides an option to include theme for exported PDF document.

To apply theme in exported PDF, define the **theme** in export properties.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" Toolbar="@(new List<string>() { "PdfExport" })" AllowPdfExport="true" AllowPaging="true">
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
       if (args.Item.Id == "Grid_pdfexport")  //Id is combination of Grid's ID and itemname
        {
            PdfExportProperties ExportProperties = new PdfExportProperties();
            PdfTheme Theme = new PdfTheme();

            PdfBorder HeaderBorder = new PdfBorder();
            HeaderBorder.Color = "#64FA50";

            PdfThemeStyle HeaderThemeStyle = new PdfThemeStyle()
            {
                FontColor = "#64FA50",
                FontName = "Calibri",
                FontSize = 17,
                Bold = true,
                Border = HeaderBorder
            };
            Theme.Header = HeaderThemeStyle;

            PdfThemeStyle RecordThemeStyle = new PdfThemeStyle()
            {
                FontColor = "#64FA50",
                FontName = "Calibri",
                FontSize = 17

            };
            Theme.Record = RecordThemeStyle;

            PdfThemeStyle CaptionThemeStyle = new PdfThemeStyle()
            {
                FontColor = "#64FA50",
                FontName = "Calibri",
                FontSize = 17,
                Bold = true

            };
            Theme.Caption = CaptionThemeStyle;

            ExportProperties.Theme = Theme;
            await this.DefaultGrid.PdfExport(ExportProperties);
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

N> By default, material theme is applied to exported PDF document.

### Customize column width in exported PDF document

The PDF export provides an option to customize the column being exported to a PDF format using the [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html#Syncfusion_Blazor_Grids_PdfExportProperties_Columns) property of the [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) class. While defining the column, we can change its width as per the requirement.

In the following code sample, we have customized the column width for the PDF exported grid by enabling the [DisableAutoFitWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html#Syncfusion_Blazor_Grids_PdfExportProperties_DisableAutoFitWidth) property of the `PdfExportProperties` class.

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids

<SfButton OnClick="PdfExport" Content="Pdf Export"></SfButton>
<SfGrid @ref="DefaultGrid" DataSource="@Orders" AllowPdfExport="true" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
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
    public async Task PdfExport()
    {
        PdfExportProperties ExportProperties = new PdfExportProperties();
        ExportProperties.DisableAutoFitWidth = true;
        ExportProperties.Columns = new List<GridColumn>()
        {
                new GridColumn(){ Field="OrderID", HeaderText="Order ID", TextAlign=TextAlign.Left, Width="300"},
                new GridColumn(){ Field="CustomerID", HeaderText="Customer Name", TextAlign=TextAlign.Left, Width="100"},
                new GridColumn(){ Field="OrderDate", HeaderText=" Order Date", Type=ColumnType.Date, Format="d", TextAlign=TextAlign.Left, Width="80"}
        };
        await this.DefaultGrid.PdfExport(ExportProperties);
    }
}

```

N> You can find the fully working sample [here](https://github.com/SyncfusionExamples/blazor-datagrid-customize-column-in-pdf-exported-document).

### Grid cell customization in PDF export

DataGrid has support to customize the column header and content styles, such as changing text orientation, the font color, the width of the header and content text, and so on in the exported PDF file. To achieve this requirement, define the `BeginCellLayout` event of the [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) with an event handler to perform the required action.

The [PdfHeaderQueryCellInfoEvent](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_PdfHeaderQueryCellInfoEvent) will be triggered when creating a column header for the pdf document to be exported. Collect the column header details in this event and handle the custom in the `BeginCellLayout` event handler.

In the following demo, the [DrawString](https://help.syncfusion.com/cr/file-formats/Syncfusion.Pdf.Graphics.PdfGraphics.html#Syncfusion_Pdf_Graphics_PdfGraphics_DrawString_System_String_Syncfusion_Pdf_Graphics_PdfFont_Syncfusion_Pdf_Graphics_PdfBrush_System_Drawing_PointF_) method from the [Graphics](https://help.syncfusion.com/cr/file-formats/Syncfusion.Pdf.Graphics.PdfGraphics.html) is used to rotate the header text of the column header inside the `BeginCellLayout` event handler.

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Pdf.Graphics
@using Syncfusion.PdfExport
@using System.Drawing
@using Syncfusion.Pdf

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" GridLines="GridLine.Both" Toolbar="@(new List<string>() {"PdfExport" })" AllowPdfExport="true" AllowPaging="true">
    <GridEvents  OnToolbarClick="ToolbarClickHandler" PdfHeaderQueryCellInfoEvent="PdfHeaderQueryCellInfoHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Center" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Center" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Center" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>


@code{
    public SfGrid<Order> DefaultGrid;
    public List<Order> Orders { get; set; }
    List<string> headerValues = new List<string>();

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_pdfexport")  // Id is combination of Grid's ID and itemname.
        {
            PdfExportProperties ExportProperties = new PdfExportProperties();
            ExportProperties.BeginCellLayout = new PdfGridBeginCellLayoutEventHandler(BeginCellEvent);
            ExportProperties.FileName = "test.pdf";
            ExportProperties.IsRepeatHeader = true;
            await this.DefaultGrid.PdfExport(ExportProperties);
        }
    }

    public void BeginCellEvent(object sender, PdfGridBeginCellLayoutEventArgs args)
    {
        PdfGrid grid = (PdfGrid)sender;
        var brush = new Syncfusion.PdfExport.PdfSolidBrush(new Syncfusion.PdfExport.PdfColor(Color.DimGray));
        args.Graphics.Save();
        args.Graphics.TranslateTransform(args.Bounds.X + 50, args.Bounds.Height + 40);
        args.Graphics.RotateTransform(-60);
        // Draw the text at particular bounds.
        args.Graphics.DrawString(headerValues[args.CellIndex], new Syncfusion.PdfExport.PdfStandardFont(Syncfusion.PdfExport.PdfFontFamily.Helvetica, 10), brush, new PointF(0, 0));
        if (args.IsHeaderRow)
        {
            grid.Headers[0].Cells[args.CellIndex].Value = string.Empty;
        }
        args.Graphics.Restore();
    }

    public void PdfHeaderQueryCellInfoHandler(PdfHeaderQueryCellInfoEventArgs args)
    {
        headerValues.Add(args.Column.HeaderText);
        var longestString = headerValues.Where(s => s.Length == headerValues.Max(m => m.Length)).
                            First();
        Syncfusion.PdfExport.PdfFont font = new Syncfusion.PdfExport.PdfStandardFont(Syncfusion.PdfExport.PdfFontFamily.Helvetica, 6);
        SizeF size = font.MeasureString(longestString);
        args.PdfGridColumn.Grid.Headers[0].Height = size.Width * 2;
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

<style>
    .e-grid .e-header {
        font-weight: bold !important;
    }

    .e-grid .e-columnheader .e-headercell {
        height: 100px;
        transform: rotate(-60deg); // This is used to rotate the header text.
    }
</style> 
```

![PDF Exported Grid Cell Customization in Blazor DataGrid](./images/blazor-datagrid-pdf-exported-grid-cell-customization.png)

<!-- Show or hide columns on exported pdf

You can show a hidden column or hide a visible column while exporting the datagrid by customizing the visibility settings while exporting.

This is demonstrated in the below sample code where initially the **CustomerID** is hidden. While exporting, we have changed CustomerID to visible column and Freight as hidden column. Then in the `PdfExportComplete` event, we have reversed the column's visibility state back to the previous state.

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids

<SfButton OnClick="PdfExport" Content="Pdf Export"></SfButton>
<SfGrid @ref="DefaultGrid" DataSource="@Orders" AllowPdfExport="true" AllowPaging="true">
<GridEvents PdfExportComplete="OnPdfExport" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150" Visible=@CustomerIDVisibility></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Visible=@FreightVisibility Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@functions{
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
    public void PdfExport()
    {
        CustomerIDVisibility = true;
        FreightVisibility = false;
        this.DefaultGrid.PdfExport();
    }
    public void OnPdfExport()
    {
        CustomerIDVisibility = false;
        FreightVisibility = true;
    }
}
``` -->

## Custom data source

PDF export provides an option to define the datasource dynamically before exporting. To export data dynamically, define it in the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html#Syncfusion_Blazor_Grids_PdfExportProperties_DataSource) property of the [PdfExportProperties](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) class

The following sample code demonstrates dynamically modifying the data source before exporting it,

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" Toolbar="@(new List<string>() { "PdfExport" })" AllowPdfExport="true" AllowPaging="true">
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
        if (args.Item.Id == "Grid_pdfexport")  //Id is combination of Grid's ID and itemname
        {
            PdfExportProperties PdfProperties = new PdfExportProperties();
            PdfProperties.DataSource = Orders;
            await this.DefaultGrid.PdfExport(PdfProperties);
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

## PDF Exporting with Templates

### Export template columns

PDF export provides an option to export template columns of the DataGrid by defining the [IncludeTemplateColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html#Syncfusion_Blazor_Grids_PdfExportProperties_IncludeTemplateColumn) of [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) as true. In the following sample, the CustomerID column is a template column. The template values cannot be directly exported into the cells. To customize the values of template columns in the PDF document, you must use [PdfQueryCellInfoEvent](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_PdfQueryCellInfoEvent).

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" Toolbar="@(new List<string>() { "PdfExport" })" AllowPdfExport="true" AllowPaging="true">
    <GridEvents PdfQueryCellInfoEvent="PdfQueryCellInfoHandler" OnToolbarClick="ToolbarClickHandler" TValue="Order"></GridEvents>
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
        if (args.Item.Id == "Grid_pdfexport")  //Id is combination of Grid's ID and itemname
        {
            PdfExportProperties ExportProperties = new PdfExportProperties();
            ExportProperties.IncludeTemplateColumn = true;
            await this.DefaultGrid.ExportToPdfAsync(ExportProperties);
        }
    }
    public void PdfQueryCellInfoHandler(PdfQueryCellInfoEventArgs<Order> args)
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

The PDF export feature allows you export a Grid with a caption template to a PDF document. 

The example below demonstrates how to customize the caption text in the PDF using the [PdfGroupCaptionTemplateInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_PdfGroupCaptionTemplateInfo) event.

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations

<SfGrid ID="Grid" @ref="Grid" DataSource="@GridData" AllowGrouping="true" Height="315px" Toolbar="@(new List<string>() { "PdfExport" })" AllowPdfExport="true">
    <GridEvents OnToolbarClick="ToolbarClickHandler" PdfGroupCaptionTemplateInfo="PdfGroupCaptionInfoHandler" TValue="OrderData"></GridEvents>
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
        if (args.Item.Id == "Grid_pdfexport")
        {
            await Grid.ExportToPdfAsync();
        }
    }

    public void PdfGroupCaptionInfoHandler(PdfCaptionTemplateArgs args)
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

By default, the Grid exports the parent grid along with expanded detail rows only. To modify the exporting behavior, utilize the [PdfExportProperties.PdfDetailRowMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfDetailRowMode.html) property. The available options include:

| Mode | Behaviour |
|-------|----------|
| Expand | Exports the parent grid with expanded detail rows.
| None | Exports the parent grid alone.

Customization of detail rows in the exported PDF is achievable through the [PdfDetailTemplateExporting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_PdfDetailTemplateExporting) event. This event enables formatting the detail rows based on their parent row details within the PDF document.

In the provided example, detail row content is formatted by specifyin the [ColumnCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfDetailTemplateRowSettings.html#Syncfusion_Blazor_Grids_PdfDetailTemplateRowSettings_ColumnCount), [Headers](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfDetailTemplateRowSettings.html#Syncfusion_Blazor_Grids_PdfDetailTemplateRowSettings_Headers), [Rows](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfDetailTemplateRowSettings.html#Syncfusion_Blazor_Grids_PdfDetailTemplateRowSettings_Rows) using parentRow details, facilitating the creation of detail rows within the PDF. Additionally, custom styles can be applied to specific cells using the [Style](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfDetailTemplateCell.html#Syncfusion_Blazor_Grids_PdfDetailTemplateCell_Style) property.

>If [ColumnCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfDetailTemplateRowSettings.html#Syncfusion_Blazor_Grids_PdfDetailTemplateRowSettings_ColumnCount) is not provided or is less than the number of cells in the first row of Headers/Rows, the columns in the detail row of the PDF grid will be generated based on the count of cells in the first row of Headers/Rows.


```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor

<SfGrid @ref="DefaultGrid" ID="Grid" DataSource="@Employees" Toolbar="@(new List<string>() { "ExcelExport", "PdfExport" })" AllowPdfExport="true" AllowExcelExport="true" Height="450px">
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
    <GridEvents ExcelDetailTemplateExporting="ExcelDetailTemplateHandler" PdfDetailTemplateExporting="PdfDetailTemplateHandler" OnToolbarClick="ToolbarClickHandler" TValue="Product"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Product.Category) HeaderText="Category" Width="110"> </GridColumn>
        <GridColumn Field=@nameof(Product.ProductID) HeaderText="Product ID" Width="160"> </GridColumn>
        <GridColumn Field=@nameof(Product.Status) HeaderText="Status" Width="180"></GridColumn>
    </GridColumns>
</SfGrid>

<style type="text/css" class="cssStyles">
    #container {
        visibility: hidden;
    }

    #loader {
        color: #008cff;
        font-family: 'Helvetica Neue','calibiri';
        font-size: 14px;
        height: 40px;
        left: 45%;
        position: absolute;
        top: 45%;
        width: 30%;
    }

    .orientationcss .e-headercelldiv {
        transform: rotate(90deg);
    }

    .detailtable td {
        font-size: 13px;
        padding: 4px;
        max-width: 0;
        overflow: hidden;
        text-overflow: ellipsis;
        white-space: nowrap;
        font-weight: normal;
    }

    .photo {
        width: 100px;
        height: 100px;
        border-radius: 50px;
        box-shadow: inset 0 0 1px #e0e0e0, inset 0 0 14px rgba(0, 0, 0, 0.2);
    }

    .Unavailable {
        color: #FF0000;
    }

    .Available {
        color: #00FF00;
    }

</style>

@code {

    SfGrid<Product> DefaultGrid;
    public List<Product> Employees { get; set; }
    public async Task ToolbarClickHandler(ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_pdfexport")  // Id is the combination of Grid's ID and item name.
        {
            PdfExportProperties PdfExportProperties = new PdfExportProperties();
            PdfExportProperties.PdfDetailRowMode = PdfDetailRowMode.Expand;
            await this.DefaultGrid.ExportToPdfAsync(PdfExportProperties);
        }
    }

    public void PdfDetailTemplateHandler(PdfDetailTemplateEventArgs<Product> args)
    {
        var pdfRows = new List<PdfDetailTemplateRow>();
        var data = args.ParentRow.Data;
        args.RowInfo.ColumnCount = 2;
        args.RowInfo.Headers = new List<PdfDetailTemplateRow>() { new PdfDetailTemplateRow() { Cells = new List<PdfDetailTemplateCell>() { new PdfDetailTemplateCell() { Index = 0, CellValue = "Product Details", ColumnSpan = 2, Style = new PdfThemeStyle() { Bold = true } } } } };
        pdfRows.Add(new PdfDetailTemplateRow()
            {
                Cells = new List<PdfDetailTemplateCell>()
        {
            new PdfDetailTemplateCell()
            {
                CellValue = data.ProductDesc, Index = 0
            },
            new PdfDetailTemplateCell()
            {
                Index = 1, Hyperlink = new Hyperlink() { DisplayText = data.Contact, Target = data.Contact }
            }
        }
            });
        pdfRows.Add(
            new PdfDetailTemplateRow()
                {
                    Cells = new List<PdfDetailTemplateCell>()
                {
            new PdfDetailTemplateCell()
            {
                CellValue = data.Cost, Index = 0
            },
            new PdfDetailTemplateCell()
            {
                Index = 1, CellValue = "Available :" + data.Available }
                }
                });
        pdfRows.Add(new PdfDetailTemplateRow()
            {
                Cells = new List<PdfDetailTemplateCell>()
            {
            new PdfDetailTemplateCell()
            {
                CellValue = data.Status, Index = 0
            },
            new PdfDetailTemplateCell()
            {
                Index = 1, CellValue = data.ReturnPolicy }
            }
            });
        pdfRows.Add(new PdfDetailTemplateRow()
            {
                Cells = new List<PdfDetailTemplateCell>()
            {
            new PdfDetailTemplateCell()
            {
                CellValue = "Offers :" + data.Offers, Index = 0, Style = new PdfThemeStyle()
                {
                  FontColor = "#0A76FF", FontSize = 12
                }
            },
            new PdfDetailTemplateCell()
            {
                Index = 1, CellValue = data.Cancellation }
            }
            });
        pdfRows.Add(new PdfDetailTemplateRow()
            {
                Cells = new List<PdfDetailTemplateCell>()
            {
            new PdfDetailTemplateCell()
            {
                CellValue = "Ratings: " + data.Ratings, Index = 0, Style = new PdfThemeStyle()
                {
                  FontColor = "#0A76FF", FontSize = 12
                }
            },
            new PdfDetailTemplateCell()
            {
                Index = 1, CellValue = data.Delivery, Style = new PdfThemeStyle()
                {
                  FontColor = "#0A76FF", FontSize = 12
                }
            }
            }
            });
        args.RowInfo.Rows = pdfRows;
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

The Grid have an option to export the hierarchy grid to pdf document using detail template feature. Customization of detail rows in the exported PDF is achievable through the [PdfDetailTemplateExporting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_PdfDetailTemplateExporting) event.

In the provided example, detail row content is formatted by specifyin the [Headers](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfDetailTemplateRowSettings.html#Syncfusion_Blazor_Grids_PdfDetailTemplateRowSettings_Headers), [Rows](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfDetailTemplateRowSettings.html#Syncfusion_Blazor_Grids_PdfDetailTemplateRowSettings_Rows) using parentRow details. Additionaly, this achieves a nested level of children using the [ChildRowInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfDetailTemplateRow.html#Syncfusion_Blazor_Grids_PdfDetailTemplateRow_ChildRowInfo) property.


```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Data

<SfGrid @ref="DefaultGrid" ID="Grid" DataSource="@Employees" AllowPdfExport="true" Toolbar="@(new List<string>() { "PdfExport" })">
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
    <GridEvents PdfDetailTemplateExporting="PdfDetailTemplateHandler" OnToolbarClick="ToolbarClickHandler" TValue="EmployeeData"></GridEvents>
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
        if (args.Item.Id == "Grid_pdfexport")  // Id is the combination of Grid's ID and item name.
        {
            PdfExportProperties PdfExportProperties = new PdfExportProperties();
            PdfExportProperties.PdfDetailRowMode = PdfDetailRowMode.Expand;
            await this.DefaultGrid.ExportToPdfAsync(PdfExportProperties);
        }
    }

    public void PdfDetailTemplateHandler(PdfDetailTemplateEventArgs<EmployeeData> args)
    {
        var pdfRows = new List<PdfDetailTemplateRow>();
        var data = Orders.ToList().Where(_ => _.EmployeeID == args.ParentRow.Data.EmployeeID).ToList();
        for (var i = 0; i < data.Count(); i++)
        {
            var row = data[i];
            var childData = OrderInfo.ToList().Where(_ => _.OrderID == row.OrderID).ToList();
            var pdfchildRows = new List<PdfDetailTemplateRow>();
            var pdfRow = ProcessPdfRow(new List<string>() { row.OrderID.ToString(), row.CustomerID.ToString(), row.Freight.ToString(), row.ShipCity });
            for(var j = 0; j < childData.Count; j++)
            {
                var childRow = childData[j];
                pdfchildRows.Add(ProcessPdfRow(new List<string>() { childRow.CustomerID.ToString(), childRow.Title.ToString(), childRow.Address.ToString(), childRow.Country }));
            }
            pdfRow.ChildRowInfo = new PdfDetailTemplateRowSettings() { Headers = new List<PdfDetailTemplateRow>() { ProcessPdfRow(new List<string>() { "Customer Name", "Title", "Address", "Country" }) }, Rows = pdfchildRows };
            pdfRows.Add(pdfRow);
        }
        args.RowInfo.Headers = new List<PdfDetailTemplateRow>() { ProcessPdfRow(new List<string>() { "Order ID", "Customer ID", "Freight", "Ship City" }) };
        args.RowInfo.Rows = pdfRows;
    }

    PdfDetailTemplateRow ProcessPdfRow(List<string> value)
    {
        var cells = new List<PdfDetailTemplateCell>();
        for(var j = 0; j < value.Count(); j++)
        {
            cells.Add(new PdfDetailTemplateCell { CellValue = $"{value[j]}", Index = j });
        }
        return new PdfDetailTemplateRow { Cells = cells };
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

## Exporting Grid Data as Stream

### Exporting Grid Data as Memory Stream
This section shows how to invoke a [ExportToPdfAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExportToExcelAsync_System_Int32_System_Int32_System_Int32_) method to export a pdf document as a memory stream.

To obtain the export file as a memory stream, set the `asMemoryStream` parameter to true within the `ExportToPdfAsync` method.

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

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" Toolbar="@(new List<string>() { "PdfExport" })" AllowPdfExport="true" AllowPaging="true">
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
        if (args.Item.Id == "Grid_pdfexport") //Id is combination of Grid's ID and itemname
        {           
            MemoryStream streamDoc = await DefaultGrid.ExportToPdfAsync(asMemoryStream: true);
            await JSRuntime.InvokeVoidAsync("saveAsFile", new object[] {"PdfMemoryStream.pdf", Convert.ToBase64String(streamDoc.ToArray()), true });
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

### Converting Memory Stream to File Stream for Pdf Export

This section explains the process of converting a memory stream obtained from the `ExportToPdfAsync` method into a file stream to export pdf document.

The example provided demonstrates this process of exporting the pdf document from the file stream.

```cshtml
@using Syncfusion.Blazor.Grids
@using System.IO;
@using Syncfusion.Pdf
@using Syncfusion.XlsIO
@using Syncfusion.PdfExport;
@using Syncfusion.ExcelExport;
@inject IJSRuntime JSRuntime

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" Toolbar="@(new List<string>() { "PdfExport" })" AllowPdfExport="true" AllowPaging="true">
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
        if (args.Item.Id == "Grid_pdfexport") //Id is combination of Grid's ID and itemname
        {           
            //Memory stream to file stream exporting
            MemoryStream streamDoc1 = await DefaultGrid.ExportToPdfAsync(asMemoryStream: true);

            //Create a copy of streamDoc1
            MemoryStream copyOfStreamDoc1 = new MemoryStream(streamDoc1.ToArray());
           //For creating the exporting location with file name, for this need to specify the physical exact path of the file
            string filePaths = "C:Users/abc/Downloads/SampleTestPdf.pdf";

            // Create a FileStream to write the moryStream contents to a file
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

### Merging Two Pdf Memory Streams

This section explains the process of combining two memory stream files and exporting the resulting merged file as a PDF document. To accomplish this, you can use the PDF documents [Merge](https://help.syncfusion.com/cr/file-formats/Syncfusion.Pdf.PdfDocumentBase.html#Syncfusion_Pdf_PdfDocumentBase_Merge_Syncfusion_Pdf_PdfDocumentBase_Syncfusion_Pdf_Parsing_PdfLoadedDocument_) method available in the [PdfDocumentBase](https://help.syncfusion.com/cr/file-formats/Syncfusion.Pdf.PdfDocumentBase.html) class, class. To achieve this functionality, you can utilize the [Syncfusion.Blazor.Pdf](https://www.nuget.org/packages/Syncfusion.Pdf.Net.Core/) package.

The provided example demonstrates the merging of two memory streams and exporting the resulting merged memory stream for browser download.

In this example, there are two memory streams: *streamDoc1* and *streamDoc2*. streamDoc1 represents the normal grid memory stream, while streamDoc2 contains the memory stream of a customized grid using the [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) class. The merging process combines these streams into a new PDF document, converting it into a memory stream. This merged memory stream is then utilized to initiate the browser download.

 ```cshtml
@using Syncfusion.Blazor.Grids
@using System.IO;
@using Syncfusion.PdfExport;
@using Syncfusion.Pdf
@inject IJSRuntime JSRuntime

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" Toolbar="@(new List<string>() { "PdfExport" })" AllowPdfExport="true"  AllowPaging="true">
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
        if (args.Item.Id == "Grid_pdfexport") //Id is combination of Grid's ID and itemname
        {
            //Merging two memory stream
            MemoryStream mergedStream = new MemoryStream();

            //Creates a PDF document.
            Syncfusion.Pdf.PdfDocument finalDoc = new Syncfusion.Pdf.PdfDocument();
            MemoryStream streamDoc1 = await DefaultGrid.ExportToPdfAsync(asMemoryStream: true);
            //Create a copy of streamDoc1 to access the memory stream
            MemoryStream copyOfStreamDoc1 = new MemoryStream(streamDoc1.ToArray());
            
            //Customized grid for memory stream export
            PdfExportProperties ExportProperties = new PdfExportProperties();
            PdfTheme Theme = new PdfTheme();
            PdfBorder HeaderBorder = new PdfBorder();
            HeaderBorder.Color = "#000000";

            PdfThemeStyle HeaderThemeStyle = new PdfThemeStyle()
            {
                FontColor = "#6A5ACD",
                FontName = "Comic Sans MS",
                FontSize = 17,
                Bold = true,
                Border = HeaderBorder
            };
            Theme.Header = HeaderThemeStyle;

            PdfThemeStyle RecordThemeStyle = new PdfThemeStyle()
            {
                FontColor = "#800080",
                FontName = "Comic Sans MS",
                FontSize = 14,
                Border = HeaderBorder
            };
            Theme.Record = RecordThemeStyle;

            ExportProperties.Theme = Theme;
            MemoryStream streamDoc2 = await DefaultGrid.ExportToPdfAsync(asMemoryStream: true, ExportProperties);
            //Create a copy of streamDoc2 to access the memory stream
            MemoryStream copyOfStreamDoc2 = new MemoryStream(streamDoc2.ToArray());

            //Creates a PDF stream for merging.
            Stream[] streams = { copyOfStreamDoc1, copyOfStreamDoc2 };
            Syncfusion.Pdf.PdfDocument.Merge(finalDoc, streams);
            finalDoc.Save(mergedStream);
            await JSRuntime.InvokeVoidAsync("saveAsFile", new object[] { "MemoryStreamMerge.pdf", Convert.ToBase64String(mergedStream.ToArray()), true });
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

* [Export Blazor Datagrid with Barcode to PDF](https://www.syncfusion.com/forums/175315/export-datagrid-with-barcode)


N> You can refer to our [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap4) to understand how to present and manipulate data.
