---
layout: post
title: Customize PDF headers and footers in the Blazor DataGrid | Syncfusion
description: Learn how to customize headers and footers in PDF export using Syncfusion Blazor DataGrid, including text, images, and page settings.
platform: Blazor
control: DataGrid
documentation: ug
---

# Adding header and footer in Blazor DataGrid 

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports customizing header and footer sections in PDF exports. These regions can include:

* **Text** – Titles, dates, or disclaimers.
* **Page Numbers** – For easy navigation.
* **Lines** – To visually separate sections.
* **Images** – Such as logos or branding elements.
* **Layout Adjustments** – Page size and orientation.

## Adding text in header and footer

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports adding custom text to header and footer regions in PDF exports.

* The **header** appears at the top of each page and can include elements such as a document title, company logo, or date and metadata. This section is typically used for branding and document identification.

* The **footer** appears at the bottom of each page and commonly contains page numbers, copyright text, or disclaimers. This section is useful for navigation and compliance information.

To add text in the header and footer of the exported PDF:

1. Access `[PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html).
2. Assign [Header](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_Header) and [Footer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_Footer) using [PdfHeader](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfHeader.html) and [PdfFooter](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfFooter.html) objects.
3. Add one or more [PdfHeaderFooterContent](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfHeaderFooterContent.html) items to the `Contents` collection for each region.
4. Call [ExportToPdfAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExportToPdfAsync_Syncfusion_Blazor_Grids_PdfExportProperties_) to export with the configured header and footer.

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

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports drawing lines in header and footer regions when exporting to PDF. **Lines** are commonly used to visually separate these regions from the main content.

**Supported Line Styles**

The line style is controlled using the [PdfDashStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfDashStyle.html) enumeration. Available styles include:

- Dash
- Dot
- DashDot
- DashDotDot
- Solid

To draw a line in the header and footer:

1. Access Header.Contents and Footer.Contents in [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html).
2. Add [PdfHeaderFooterContent](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfHeaderFooterContent.html) items and set the [ContentType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContentType.html#Syncfusion_Blazor_Grids_ContentType) to [Line](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContentType.html#Syncfusion_Blazor_Grids_ContentType_Line).
3. Configure Style properties such as `DashStyle`, `PenColor`, and `PenSize`.
4. Define line coordinates using `Points`.

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

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports adding page numbers to header and footer regions when exporting to PDF. This feature improves document navigation and readability.

Page numbers are configured using [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html). Set the [ContentType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContentType.html#Syncfusion_Blazor_Grids_ContentType) to [PageNumber](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContentType.html#Syncfusion_Blazor_Grids_ContentType_PageNumber) when adding page numbers to the header or footer.

The display format is controlled by [PageNumberType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfPageNumberType.html#fields), which supports:

* Arabic – 1, 2, 3
* Number – 1, 2, 3
* LowerLatin – a, b, c
* UpperLatin – A, B, C
* LowerRoman – i, ii, iii
* UpperRoman – I, II, III

To add page numbers:

1. Add content items to the header and/or footer and set the content type to `PageNumber`.
2. Specify the page number format using `PageNumberType`.
3. Define position and style properties as needed.
4. Call [ExportToPdfAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExportToPdfAsync_Syncfusion_Blazor_Grids_PdfExportProperties_) to generate the PDF with page numbers.

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

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports adding images, such as company logos, to header and footer regions when exporting to PDF. This feature is useful for branding and document personalization.

To insert an image:

1. Convert the image to a **Base64 string** in **JPEG** format.
2. Access [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) and add content items to the [header](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_Header) and/or [footer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_Footer).
3. Set the [ContentType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContentType.html#Syncfusion_Blazor_Grids_ContentType) to [Image](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContentType.html#Syncfusion_Blazor_Grids_ContentType_Image) and assign the **Base64 string** to the `Src` property.
4. Define the image position and size using `Position` and `Size` properties.
5. Call [ExportToPdfAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExportToPdfAsync_Syncfusion_Blazor_Grids_PdfExportProperties_) to generate the PDF with the configured image.

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

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports repeating column headers on every page of a PDF export. This ensures headers remain visible when the content spans multiple pages. By default, headers appear only on the first page.

To enable this feature:

1. Set the [IsRepeatHeader](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html#Syncfusion_Blazor_Grids_PdfExportProperties_IsRepeatHeader) property in [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) to **true**.
2. Optionally, customize header appearance using the [PdfHeaderQueryCellInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_PdfHeaderQueryCellInfoEvent) event.

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