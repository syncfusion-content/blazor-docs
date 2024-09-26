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

### Export image in PDF footer content

To insert an image in the footer of an exported PDF document using Grid, you can utilize the [Footer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html#Syncfusion_Blazor_Grids_PdfExportProperties_Footer) property of the [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) class. The Footer property allows you to specify the content to be displayed in the footer section of the PDF. 

The [Src](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfHeaderFooterContent.html#Syncfusion_Blazor_Grids_PdfHeaderFooterContent_Src) property of the [PdfHeaderFooterContent](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfHeaderFooterContent.html) class is used to specify the base64 string representing the image content for the header or footer.

The [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfHeaderFooterContent.html#Syncfusion_Blazor_Grids_PdfHeaderFooterContent_Type) property of the `PdfHeaderFooterContent` class is used to specify the content type of the image. It can be set to "Image" for image content.

The following sample code demonstrates adding image in the footer section of the exported document,

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
@code {
    private SfGrid<Order> DefaultGrid;
    public List<Order> Orders { get; set; }
    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_pdfexport")  //Id is combination of Grid's ID and itemname
        {
            PdfExportProperties ExportProperties = new PdfExportProperties();
            var base64Footer = " iVBORw0KGgoAAAANSUhEUgAAAfQAAAH0CAYAAADL1t+KAAAACXBIWXMAAA7EAAAOxAGVKw4bAAAgAElEQVR4nO3df7AlZ33n98/n1q3JZDQ1O1HkiaISY0XLqpQ5KkJUc4jiZVkXZr2AMTZe1vxabK+xLds4Q1iWsMwJUVHsHWJsDMgG1vwwlsGA7TVg4/JiVsEOZimKO0W0Ku4sUam0yqDIKkU1Nasabt2aunW++aN/n9O/zjn3zkit9wtGc+93ztP9dPfp/nY//fTTjggBAICnt7WrXQEAALA6EjoAAANAQgcAYABI6AAADAAJHQCAASChAwAwACR0AAAGgIQOAMAAkNABABgAEjoAAANAQgcAYABI6AAADAAJHQCAASChAwAwACR0AAAGgIQOAMAAkNABABgAEjoAAANAQgcAYABI6AAADAAJHQCAASChAwAwACR0AAAGgIQOAMAAkNABABgAEjoAAANAQgcAYABI6AAADAAJHQCAASChAwAwACR0AAAGgIQOAMAAkNABABgAEjoAAANAQgcAYABI6AAADAAJHQCAASChAwAwACR0AAAGgIQOAMAAkNABABgAEjoAAANAQgcAYABI6AAADAAJHQCAASChAwAwACR0AAAGgIQOAMAAkNABABgAEjoAAANAQgcAYABI6AAADAAJHQCAASChAwAwACR0AAAGgIQOAMAAkNABABgAEjoAAANAQgcAYABI6AAADAAJHQCAASChAwAwACR0AAAGgIQOAMAAkNABABgAEjoAAANAQgcAYABI6AAADAAJHQCAASChAwAwACR0AAAGgIQOAMAAkNABABgAEjoAAANAQgcAYABI6AAADAAJHQCAASChAwAwACR0AAAGgIQOAMAAkNABABgAEjoAAANAQgcAYABI6AAADAAJHQCAASChAwAwACR0AAAGgIQOAMAAkNABABgAEjoAAANAQgcAYABI6AAADAAJHQCAASChAwAwACR0AAAGgIQOAMAAkNABABgAEjoAAANAQgcAYABI6AAADAAJHQCAASChAwAwACR0AAAGgIQOAMAAkNABABgAEjoAAANAQgcAYABI6AAADAAJHQCAASChAwAwACR0AAAGgIQOAMAAkNABABgAEjoAAANAQgcAYABI6AAADAAJHQCAASChAwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA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AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACWs3338euvdh0A4Jlm7WpXAAAArI6Ejv2wc7UrAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA8IzliLjadQAAACtau9oVAAAAqyOhAwAwACR0AAAGgIQOAMAAkNABABgAEjoAAANAQgcAYABI6AAADAAJHQCAASChAwAwACR0AAAGgIQOAMAAkNABABgAEjoAAANAQgcAYABI6AAADAAJHQCAASChAwAwACR0AAAGgIQOAMAAkNABABgAEjoAAANAQgcAYABI6AAADAAJHQCAASChAwAwACR0AAAGgIQOAMAAkNABABgAEjoAAANAQgcAYABI6AAADAAJHQCAASChAwAwACR0AAAGgIQOAMAAkNABABgAEjoAAANAQgcAYABI6AAADAAJHQCAASChAwAwACR0AAAGgIQOAMAAkNABABgAEjoAAANAQgcAYABI6AAADAAJHQCAASChAwAwACR0AAAGgIQOAMAAkNABABgAEjoAAANAQgcAYABI6AAADAAJHQCAASChAwAwACR0AAAGgIQOAMAAkNABABgAEjoAAANAQgcAYABI6AAADAAJHQCAASChAwAwACR0AAAGgIQOAMAAkNABABgAEjoAAANAQgcAYABI6AAADAAJHQCAASChAwAwACR0AAAGgIQOAMAAkNABABgAEjoAAANAQgcAYABI6AAADAAJHQCAASChAwAwACR0AAAGgIQOAMAAkNABABgAEjoAAANAQgcAYABI6AAADAAJHQCAASChAwAwACR0AAAGgIQOAMAAkNABABgAEjoAAANAQgcAYABI6AAADAAJHQCAASChAwAwACR0AAAGgIQOAMAAkNABABgAEjoAAANAQgcAYABI6AAADAAJHQCAASChAwAwACR0AAAGgIQOAMAAkNABABgAEjoAAANAQgcAYABI6AAADAAJHQCAASChAwAwACR0AAAGgIQOAMAAkNABABgAEjoAAAPw/wNtHfsbsGBE6wAAAABJRU5ErkJggg== ";
           
            List<PdfHeaderFooterContent> FooterContent = new List<PdfHeaderFooterContent>
        {
            new PdfHeaderFooterContent() { Type = ContentType.Image, Src = base64Footer, Position = new PdfPosition() { X = 150, Y = 0 } },
        };
            PdfFooter Footer = new PdfFooter()
                {
                    FromBottom = 60,
                    Height = 350,
                    Contents = FooterContent
                };
          
            ExportProperties.Footer = Footer;
            await this.DefaultGrid.PdfExport(ExportProperties);
        }
    }
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 20).Select(x => new Order()
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/htVgZPXihivgIThB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

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

## See also

* [Export Blazor Datagrid with Barcode to PDF](https://www.syncfusion.com/forums/175315/export-datagrid-with-barcode)


N> You can refer to our [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap4) to understand how to present and manipulate data.
