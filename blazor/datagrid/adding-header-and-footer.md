---
layout: post
title:  Adding header and footer in Blazor DataGrid | Syncfusion
description: Checkout and learn here all about adding header and footer in PDF export using Syncfusion Blazor DataGrid and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Adding header and footer in Blazor DataGrid 

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows you to add customized header and footer sections in the exported PDF document. This feature enables you to include custom text, page numbers, lines, page size, and even change the orientation of the header and footer.

## Adding text in header and footer

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows you to add custom text in the header and footer section in the exported PDF document.  

The header section of a PDF document is typically located at the top of each page. It provides space for including additional information or branding elements, such as a company logo, document title, date, or any other content you want to display consistently on every page of the PDF document.

The footer section, on the other hand, appears at the bottom of each page. It's commonly used to include custom text such as page numbers, copyright information, or disclaimers. Like the header, the footer content is repeated on every page of the document.

To add text in the header and footer of the exported PDF document, follow these steps:

* Access the [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) of the Grid.
* Set the [Header](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_Header) and [Footer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_Footer) property to a string value representing the desired text.
* Using [ExportToPdfAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ExportToPdfAsync_Syncfusion_Blazor_Grids_PdfExportProperties_) method to trigger the PDF export operation.

The following example demonstrates how to add text in the header and footer of the exported PDF document:

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjhoMCCpJlwMDtUW?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Draw a line in header and footer

When exporting data from the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid to a PDF document, you have an option to draw lines in the header and footer sections. This feature allows you to enhance the visual appearance of the exported PDF document and create a clear separation between the header/footer and the content.

You can achieve this by using the [PdfDashStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfDashStyle.html) property, which defines the style of the line drawn. The supported [PdfDashStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfDashStyle.html#fields) include:

* Dash
* Dot
* DashDot
* DashDotDot
* Solid

To draw a line in the header and footer of the exported PDF document:

* Access the `Header.Contents` and `Footer.Contents` properties from the [Header] (https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_Header) and [Footer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_Footer) sections of the [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html).

* Customize these sections to include a line with the desired dash style using the `PdfDashStyle` options.

The following example demonstrates how to draw a line in the header and footer of the exported PDF document using a [DropDownList](https://blazor.syncfusion.com/documentation/dropdown-list/getting-started-with-web-app) to dynamically select a line style:

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjBSWMWfzvaADrfe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Add page number in header and footer

When exporting data from the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid to a PDF document, you have an option to include page numbers in the header and footer section. This feature helps improve document navigation by providing consistent page references.

This can be achieved using the [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) property, which allows customization of the header and footer content. Page numbers can be inserted using the [ContentType.PageNumber](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ContentType.html#Syncfusion_Blazor_Grids_ContentType_PageNumber) setting in the [PdfHeaderFooterContent](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfHeaderFooterContent.html).

You can choose from the following [PageNumberType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfPageNumberType.html#fields) formats:

* LowerLatin - a, b, c,
* UpperLatin - A, B, C,
* LowerRoman - i, ii, iii,
* UpperRoman - I, II, III,
* Number - 1,2,3,
* Arabic - 1,2,3.

To add page numbers to the header and footer of the exported PDF document:

* Access the `Header.Contents` and `Footer.Content`s properties of the [Header](https://ej2.syncfusion.com/angular/documentation/api/grid/pdfExportProperties/#header) and [Footer](https://ej2.syncfusion.com/angular/documentation/api/grid/pdfExportProperties/#footer) sections in the `PdfExportProperties`.

* Set the ContentType to `PageNumber` and define the desired page number format using `PageNumberType`.

The following example demonstrates how to add a page number in the header and footer of the exported PDF document using a [DropDownList](https://blazor.syncfusion.com/documentation/dropdown-list/getting-started-with-web-app) to dynamically select the page number format:

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjhSiCWzTEtZVJVn?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Insert an image in header and footer

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid have an option to include images in the header and footer section when exporting data from the Grid to PDF document. This feature allows you to add a custom logo, branding, or any relevant images to enhance the appearance of the exported PDF document.

Images can be inserted using a Base64-encoded string in the .jpeg format. This can be achieved using the [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) property of the Grid.

To insert an image in the header and footer of the exported PDF document, follow these steps:

* Convert your desired image to a Base64 string in the .jpeg format.

* Access the `PdfExportProperties` and assign the Base64 string or image file path to the `Src` property of the corresponding entry in the `Header.Contents` or `Footer.Contents` collection.

The following example demonstrates how to insert an image in header and footer of the exported PDF document:

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDheMMCpTuXlBLxH?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Repeat column header on every page

When exporting data from the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid to a PDF document, you have an option to repeat the column headers on every page. This feature ensures that the column headers remains visible and easily identifiable, even when the data spans multiple pages in the exported PDF document.

By default, the column headers is occurs only on the first page of the PDF document. However, you can enable the  [IsRepeatHeader](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html#Syncfusion_Blazor_Grids_PdfExportProperties_IsRepeatHeader) property of the [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) class to display the column headers on every page. This can be achieved using the [PdfHeaderQueryCellInfo](https://blazor.syncfusion.com/documentation/datagrid/events#pdfheaderquerycellinfoevent) event of the Grid.

The following example demonstrates how to repeat the column headers on every page of the exported PDF document using the `PdfHeaderQueryCellInfo` event:

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDheMMCpTuXlBLxH?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}