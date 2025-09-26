---
layout: post
title: Customize PDF headers and footers in the Blazor DataGrid | Syncfusion
description: Learn how to add and customize headers and footers in PDF export using the Syncfusion Blazor DataGrid, including text, page numbers, images, lines, page size, and orientation.
platform: Blazor
control: DataGrid
documentation: ug
---

# Adding header and footer in Blazor DataGrid 

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports customized header and footer sections in exported PDF documents. Use these regions to add text, page numbers, lines, adjust page size, and change orientation.

## Adding text in header and footer

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid can add custom text to the header and footer of the exported PDF.

- The header appears at the top of each page and typically contains information such as a logo, document title, or date.
- The footer appears at the bottom of each page and commonly contains page numbers, copyright text, or disclaimers.

To add text in the header and footer of the exported PDF:

- Access `[PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html).
- Assign [Header](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_Header) and [Footer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_Footer) using `PdfHeader`/`PdfFooter`, and provide one or more `PdfHeaderFooterContent` entries in their `Contents` collections.
- Call [ExportToPdfAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExportToPdfAsync_Syncfusion_Blazor_Grids_PdfExportProperties_) to export with the configured header and footer.

The following example demonstrates adding text in the header and footer:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations

<SfGrid ID= "Grid" @ref="Grid" DataSource="@Orders" Toolbar="@(new List<string> { "PdfExport" })" AllowPdfExport="true" AllowPaging="true">
    <GridEvents TValue="OrderData" OnToolbarClick="ToolbarClickHandler" />
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" Width="90" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" />
        <GridColumn Field="CustomerID" HeaderText="Customer ID" Width="120" />
        <GridColumn Field="ShipCity" HeaderText="Ship City" Width="100" />
        <GridColumn Field="ShipName" HeaderText="Ship Name" Width="150" />
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_pdfexport")
        {
            var exportProps = new PdfExportProperties
            {
                Header = new PdfHeader
                {
                    FromTop = 0, 
                    Height = 60,
                    Contents = new List<PdfHeaderFooterContent>
                    {
                        new PdfHeaderFooterContent
                        {
                            Type = ContentType.Text, // Set content type as text.
                            Value = "This is the PDF Header Text", // // Set the text to display in PDF document header section.
                            Position = new PdfPosition { X = 200, Y = 30 }, // Set the position of header text.
                            Style = new PdfContentStyle
                            {
                                TextBrushColor = "#000000",
                                FontSize = 16
                            }
                        }
                    }
                },
                Footer = new PdfFooter
                {
                    FromBottom = 10,
                    Height = 50,
                    Contents = new List<PdfHeaderFooterContent>
                    {
                        new PdfHeaderFooterContent
                        {
                            Type = ContentType.Text, // Set content type as text.    
                            Value = "This is the PDF Footer Text", // Set the text to display in PDF document footer section.
                            Position = new PdfPosition { X = 200, Y = 20 }, //Set the position of footer text.
                            Style = new PdfContentStyle
                            {
                                TextBrushColor = "#000000",
                                FontSize = 14
                            }
                        }
                    }
                }
            };

            await Grid.ExportToPdfAsync(exportProps);
        }
    }

}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData() { }

    public OrderData(int OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry, int employeeID)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.ShipName = ShipName;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = ShippedDate;
        this.IsVerified = IsVerified;
        this.ShipCity = ShipCity;
        this.ShipCountry = ShipCountry;
        this.EmployeeID = employeeID;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France", 1));
            Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany", 2));
            Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "Brazil", 3));
            Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France", 1));
            Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium", 2));
            Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland", 3));
            Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland", 2));
            Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "Brazil", 1));
            Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France", 3));
        }
        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipName { get; set; }
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public bool? IsVerified { get; set; }
    public string ShipCity { get; set; }
    public string ShipCountry { get; set; }
    public int EmployeeID { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNBStoZvKaemjUsG?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Draw a line in header and footer

When exporting to PDF, lines can be drawn in the header and footer to visually separate those regions from the main content.

Use the [PdfDashStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfDashStyle.html) enumeration to control the line style. Supported styles include:

- Dash
- Dot
- DashDot
- DashDotDot
- Solid

To draw a line in the header and footer:

- Access `Header.Contents` and `Footer.Contents` in [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) and add content items with `Type = ContentType.Line`.
- Set the `Style` with `DashStyle`, `PenColor`, and `PenSize`, and define the line coordinates with `Points`.

The following example shows dynamically selecting a line style with a [DropDownList](https://blazor.syncfusion.com/documentation/dropdown-list/getting-started-with-web-app):

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor

<div style="display: flex; align-items: center; margin-bottom: 15px; gap: 30px;">
    <div>
        <label style="padding-right: 10px; font-weight: bold;">Select Line Style:</label>
        <SfDropDownList TValue="string" TItem="LineStyleOption" @bind-Value="SelectedLineStyle"
                        DataSource="@LineStyles" Width="180px">
            <DropDownListFieldSettings Text="Text" Value="Value" />
        </SfDropDownList>
    </div>
</div>

<SfGrid ID="Grid" @ref="Grid" DataSource="@Orders" AllowPaging="true" AllowPdfExport="true"
        Toolbar="@(new List<string>() { "PdfExport" })" Height="300">
    <GridEvents TValue="OrderData" OnToolbarClick="ToolbarClickHandler" />
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" Width="90" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" />
        <GridColumn Field="CustomerID" HeaderText="Customer ID" Width="100" />
        <GridColumn Field="ShipCity" HeaderText="Ship City" Width="100" />
        <GridColumn Field="ShipName" HeaderText="Ship Name" Width="120" />
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }

    // Dropdown selection for line style.
    private string SelectedLineStyle = "Solid";

    // Dropdown options for line styles.
    public List<LineStyleOption> LineStyles = new()
    {
        new LineStyleOption { Text = "Solid", Value = "Solid" },
        new LineStyleOption { Text = "Dash", Value = "Dash" },
        new LineStyleOption { Text = "Dot", Value = "Dot" },
        new LineStyleOption { Text = "DashDot", Value = "DashDot" },
        new LineStyleOption { Text = "DashDotDot", Value = "DashDotDot" }
    };

    public class LineStyleOption
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_pdfexport")
        {
            // Parse the selected dash style from string to PdfDashStyle.
            var parsedStyle = Enum.TryParse<PdfDashStyle>(SelectedLineStyle, out var dashStyle)
                ? dashStyle
                : PdfDashStyle.Solid;

            // Create a line for the PDF header.
            var headerLine = new PdfHeaderFooterContent
            {
                Type = ContentType.Line,
                Style = new PdfContentStyle
                {
                    PenColor = "#000080",
                    PenSize = 2,
                    DashStyle = parsedStyle
                },
                Points = new PdfPoints
                {
                    X1 = 0,
                    Y1 = 4,
                    X2 = 685,
                    Y2 = 4
                }
            };

            // Create a line for the PDF footer.
            var footerLine = new PdfHeaderFooterContent
            {
                Type = ContentType.Line,
                Style = new PdfContentStyle
                {
                    PenColor = "#000080",
                    PenSize = 2,
                    DashStyle = parsedStyle
                },
                Points = new PdfPoints
                {
                    X1 = 0,
                    Y1 = 4,
                    X2 = 685,
                    Y2 = 4
                }
            };

            // Set the header and footer content for the export.
            var exportProps = new PdfExportProperties
            {
                Header = new PdfHeader
                {
                    FromTop = 0,
                    Height = 50,
                    Contents = new List<PdfHeaderFooterContent> { headerLine }
                },
                Footer = new PdfFooter
                {
                    FromBottom = 10,
                    Height = 40,
                    Contents = new List<PdfHeaderFooterContent> { footerLine }
                }
            };
            await Grid.ExportToPdfAsync(exportProps);
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData() { }

    public OrderData(int OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry, int employeeID)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.ShipName = ShipName;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = ShippedDate;
        this.IsVerified = IsVerified;
        this.ShipCity = ShipCity;
        this.ShipCountry = ShipCountry;
        this.EmployeeID = employeeID;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France", 1));
            Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany", 2));
            Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "Brazil", 3));
            Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France", 1));
            Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium", 2));
            Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland", 3));
            Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland", 2));
            Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "Brazil", 1));
            Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France", 3));
        }
        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipName { get; set; }
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public bool? IsVerified { get; set; }
    public string ShipCity { get; set; }
    public string ShipCountry { get; set; }
    public int EmployeeID { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNLetytPqYKdmets?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Add page number in header and footer

When exporting to PDF, page numbers can be included in header and footer regions to enhance document navigation.

This is configured using [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) with [PdfHeaderFooterContent](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfHeaderFooterContent.html) items whose `Type` is [ContentType.PageNumber](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContentType.html#Syncfusion_Blazor_Grids_ContentType_PageNumber). The display format is controlled by [PageNumberType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfPageNumberType.html#fields):

- LowerLatin – a, b, c
- UpperLatin – A, B, C
- LowerRoman – i, ii, iii
- UpperRoman – I, II, III
- Number – 1, 2, 3
- Arabic – 1, 2, 3

To add page numbers:

- Add [PdfHeaderFooterContent](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfHeaderFooterContent.html) with `Type = ContentType.PageNumber` to `Header.Contents` and/or `Footer.Contents`.
- Set `PageNumberType`, `Position`, and `Style` as needed.

The following example demonstrates adding page numbers with a DropDownList to choose the format:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor

<div style="margin-bottom: 15px;">
    <label style="font-weight: bold; margin-right: 10px;">Select Page Number Format:</label>
    <SfDropDownList TValue="string" TItem="PageNumberOption" @bind-Value="SelectedPageNumberType"
                    DataSource="@PageNumberTypes" Width="200px">
        <DropDownListFieldSettings Text="Text" Value="Value" />
    </SfDropDownList>
</div>

<SfGrid ID="Grid" @ref="Grid" DataSource="@Orders" AllowPaging="true" AllowPdfExport="true"
        Toolbar="@(new List<string>() { "PdfExport" })" Height="300">
    <GridEvents TValue="OrderData" OnToolbarClick="ToolbarClickHandler" />
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" Width="90" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" />
        <GridColumn Field="CustomerID" HeaderText="Customer ID" Width="100" />
        <GridColumn Field="ShipCity" HeaderText="Ship City" Width="100" />
        <GridColumn Field="ShipName" HeaderText="Ship Name" Width="120" />
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }

    private string SelectedPageNumberType = "Arabic";

    // Dropdown options for page number.
    public List<PageNumberOption> PageNumberTypes = new()
    {
        new PageNumberOption { Text = "Arabic", Value = "Arabic" },
        new PageNumberOption { Text = "Number", Value = "Number" },
        new PageNumberOption { Text = "Lower Latin", Value = "LowerLatin" },
        new PageNumberOption { Text = "Upper Latin", Value = "UpperLatin" },
        new PageNumberOption { Text = "Lower Roman", Value = "LowerRoman" },
        new PageNumberOption { Text = "Upper Roman", Value = "UpperRoman" }
    };

    public class PageNumberOption
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "Grid_pdfexport")
        {
            // Try to parse the selected dropdown value to the PdfPageNumberType.
            var pageType = Enum.TryParse<PdfPageNumberType>(SelectedPageNumberType, out var result) ? result: PdfPageNumberType.Arabic;

            // Create a page number content element for the PDF header/footer.
            var pageNumber = new PdfHeaderFooterContent
            {
                Type = ContentType.PageNumber,
                PageNumberType = pageType, // Set the selected page number format.
                Position = new PdfPosition { X= 360, Y = 20 }, // set the position of the text in the header/footer.
                Style = new PdfContentStyle
                {
                    TextBrushColor = "#4169e1",
                    FontSize = 16,
                    HAlign = PdfHorizontalAlign.Center
                }
            };

            var exportProps = new PdfExportProperties
            {
                Header = new PdfHeader { Height = 60, Contents = new List<PdfHeaderFooterContent> { pageNumber } }, // Add page number to header.
                Footer = new PdfFooter { Height = 60, Contents = new List<PdfHeaderFooterContent> { pageNumber } } // Add page number to footer.
            };

            await Grid.ExportToPdfAsync(exportProps);
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData() { }

    public OrderData(int OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry, int employeeID)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.ShipName = ShipName;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = ShippedDate;
        this.IsVerified = IsVerified;
        this.ShipCity = ShipCity;
        this.ShipCountry = ShipCountry;
        this.EmployeeID = employeeID;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France", 1));
            Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany", 2));
            Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "Brazil", 3));
            Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France", 1));
            Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium", 2));
            Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland", 3));
            Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland", 2));
            Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "Brazil", 1));
            Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France", 3));
        }
        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipName { get; set; }
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public bool? IsVerified { get; set; }
    public string ShipCity { get; set; }
    public string ShipCountry { get; set; }
    public int EmployeeID { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZLojkCeTOdnSgCJ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Insert an image in header and footer

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows you to include images—such as logos—in the header and footer sections when exporting the grid to a PDF document.

Images can be added using a Base64-encoded string in .jpeg format. This is done through the [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) property of the Grid.

To insert an image in the header or footer of the exported PDF:

- Convert the desired image to a Base64 string in .jpeg format.
- Use the [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) and assign the Base64 string or image file path to the `Src` property within the `Header.Contents` or `Footer.Contents` collections.

The following example demonstrates inserting an image in the header and footer:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" Toolbar="@(new List<string>() { "PdfExport" })" AllowPdfExport="true" AllowPaging="true">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="OrderData"></GridEvents>
 <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" Width="90" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" />
        <GridColumn Field="CustomerID" HeaderText="Customer ID" Width="100" />
        <GridColumn Field="ShipCity" HeaderText="Ship City" Width="100" />
        <GridColumn Field="ShipName" HeaderText="Ship Name" Width="120" />
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<OrderData> DefaultGrid;
    public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }    

    public List<PdfHeaderFooterContent> HeaderContent = new List<PdfHeaderFooterContent>
    {
       new PdfHeaderFooterContent()
        {
            Type = ContentType.Image, // Set the content type to image.
            Src = "/9j/4AAQSkZJRgABAQAAAQABAAD....", // Place the Base64 encoded image string.
            Position = new PdfPosition() { X = 10, Y = 10 }, // Set the position of the image in the header/footer.
            Size = new PdfSize() { Height = 15, Width = 15 }  // Place the size of the image.
        }
    };

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
       if (args.Item.Id == "Grid_pdfexport")  //Id is combination of Grid's ID and itemname.
        {
            var exportProps = new PdfExportProperties
            {
                Header = new PdfHeader
                {
                    FromTop = 0,
                    Height = 30,
                    Contents = HeaderContent
                },
                Footer = new PdfFooter
                {
                    FromBottom = 0,
                    Height = 30,
                    Contents = HeaderContent
                }
            };
            await this.DefaultGrid.ExportToPdfAsync(exportProps);  
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData() { }

    public OrderData(int OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry, int employeeID)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.ShipName = ShipName;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = ShippedDate;
        this.IsVerified = IsVerified;
        this.ShipCity = ShipCity;
        this.ShipCountry = ShipCountry;
        this.EmployeeID = employeeID;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France", 1));
            Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany", 2));
            Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "Brazil", 3));
            Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France", 1));
            Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium", 2));
            Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland", 3));
            Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland", 2));
            Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "Brazil", 1));
            Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France", 3));
        }
        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipName { get; set; }
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public bool? IsVerified { get; set; }
    public string ShipCity { get; set; }
    public string ShipCountry { get; set; }
    public int EmployeeID { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDLeXINbTSiCxMZL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Repeat column header on every page

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports repeating column headers on every page of a PDF document during export, ensuring visibility when content spans multiple pages. By default, column headers appear only on the first page. To display them on every page, enable the [IsRepeatHeader](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html#Syncfusion_Blazor_Grids_PdfExportProperties_IsRepeatHeader) property of the PdfExportProperties class. Optionally, use the [PdfHeaderQueryCellInfo](https://ej2.syncfusion.com/angular/documentation/api/grid/#pdfheaderquerycellinfo) event to customize header appearance, such as styling or formatting.

The following example repeats the column headers on every page in the exported PDF:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" @ref="DefaultGrid" DataSource="@Orders" Toolbar="@(new List<string>() { "PdfExport" })" AllowPdfExport="true" AllowPaging="true">
    <GridEvents OnToolbarClick="ToolbarClickHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<OrderData> DefaultGrid;
    public List<OrderData> Orders { get; set; }

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
       if (args.Item.Id == "Grid_pdfexport")  //Id is combination of Grid's ID and itemname.
        {
            PdfExportProperties ExportProperties = new PdfExportProperties();
            ExportProperties.IsRepeatHeader = true; // Repeats the Grid's header on every page in the PDF document.
            await this.DefaultGrid.ExportToPdfAsync(ExportProperties);
        }
    }
    protected override void OnInitialized()
    {
       Orders = OrderData.GetAllRecords();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData() { }

    public OrderData(int OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry, int employeeID)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.ShipName = ShipName;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = ShippedDate;
        this.IsVerified = IsVerified;
        this.ShipCity = ShipCity;
        this.ShipCountry = ShipCountry;
        this.EmployeeID = employeeID;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France", 1));
            Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany", 2));
            Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "Brazil", 3));
            Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France", 1));
            Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium", 2));
            Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland", 3));
            Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland", 2));
            Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "Brazil", 1));
            Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France", 3));
        }
        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipName { get; set; }
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public bool? IsVerified { get; set; }
    public string ShipCity { get; set; }
    public string ShipCountry { get; set; }
    public int EmployeeID { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDVINuLIyMVDkBoc?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}