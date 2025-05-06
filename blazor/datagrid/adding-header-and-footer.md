---
layout: post
title:  Adding header and footer in Blazor DataGrid | Syncfusion
description: Checkout and learn here all about Adding Header and Footer in PDF Export Syncfusion Blazor DataGrid and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Adding header and footer in Blazor DataGrid 

The Syncfusion Blazor DataGrid allows you to add customized header and footer sections in the exported PDF document. This feature enables you to include custom text, page numbers, lines, page size, and even change the orientation of the header and footer.

## Adding text in header and footer

The Syncfusion Blazor DataGrid allows you to add custom text in the header or footer section in the exported PDF document.  

The header section of a PDF document is typically located at the top of each page. It's a space where you can include additional information or branding elements. This is particularly useful for adding details like a company logo, a title for the document, a date, or any other information that you want to appear consistently on every page of the PDF document.

The footer section, on the other hand, is usually positioned at the bottom of each page in the PDF document. It's another area where you can insert custom text. Common content in the footer includes page numbers, copyright information, or disclaimers. Similar to the header, the footer content is repeated on every page.

To add text in the header or footer of the exported PDF document, follow these steps:

1. Access the [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) of the Grid.
2. Set the [Header](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_Header) or [Footer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_Footer) property to a string value representing the desired text.
3. Trigger the PDF export operation.

The following code example demonstrates how to add the header in the exported PDF document. 

```cshtml

PdfExportProperties ExportProperties = new PdfExportProperties();
var header = new PdfHeader
{
    FromTop = 0,
    Height = 130,
    Contents = new List<PdfHeaderFooterContent>
    {
        new PdfHeaderFooterContent
        {
            Type = ContentType.Text,
            Value = "Exported Document Of Customers",
            Position = new PdfPosition() { X = 200, Y = 50 },
            Style = new PdfContentStyle() { TextBrushColor = "#000000", FontSize = 20 }
    }
};
}
ExportProperties.Header = Header;
```

## Draw a line in header and footer

When exporting data from the Syncfusion Blazor DataGrid to a PDF document, you have an option to add a line in the header and footer section. This feature allows you to enhance the visual appearance of the exported PDF document and create a clear separation between the header and the content.

This can be achieved using the [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) property of the Grid. You can customize the line style using different supported line styles listed below:

* Dash
* Dot
* DashDot
* DashDotDot
* Solid

To add a line in the header or footer of the exported PDF document, you can access the `Header.Contents` or `Footer.Contents` property of the [Header](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_Header) or [Footer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_Footer) in the `PdfExportProperties` property of the Grid. 

The following code example demonstrates how to draw a line in the header of the exported PDF document. 

```cshtml

 var header = new PdfHeader
        {
            FromTop = 0,
            Height = 130,
            Contents = new List<PdfHeaderFooterContent>
            {
                new PdfHeaderFooterContent
                {
                    Type = ContentType.Line,
                    Style = new PdfContentStyle
                    {
                        PenColor = "#000080",
                        PenSize = 2,
                        DashStyle = PdfDashStyle.Solid
                    },
                    Points = new PdfPoints
                    {
                        X1 = 0,
                        Y1 = 4,
                        X2 = 685,
                        Y2 = 4
                    }
                }
            }
        };

        var footer = new PdfFooter
        {
            FromBottom = 10,
            Height = 60,
            Contents = new List<PdfHeaderFooterContent>
            {
                new PdfHeaderFooterContent
                {
                    Type = ContentType.Line,
                    Style = new PdfContentStyle
                    {
                        PenColor = "#000080",
                        PenSize = 2,
                        DashStyle = PdfDashStyle.Dot
                    },
                    Points = new PdfPoints
                    {
                        X1 = 0,
                        Y1 = 4,
                        X2 = 685,
                        Y2 = 4
                    }
                }
            }
        };

        var exportProperties = new PdfExportProperties
        {
            Header = header,
            Footer = footer
        };

```

## Add page number in header and footer

When exporting data from the Syncfusion Blazor DataGrid to a PDF document, you have an option to include page numbers in the header and footer section. This feature allows you to provide a reference to the page number for better document navigation.

This can be achieved using the [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) property of the Grid. You can choose from different types of supported page number listed below:

* LowerLatin - a, b, c,
* UpperLatin - A, B, C,
* LowerRoman - i, ii, iii,
* UpperRoman - I, II, III,
* Number - 1,2,3,
* Arabic - 1,2,3.

To add a page number in the header or footer of the exported PDF document, you can access the `Header.Contents` or `Footer.Contents` property of the [Header](https://ej2.syncfusion.com/angular/documentation/api/grid/pdfExportProperties/#header) or [Footer](https://ej2.syncfusion.com/angular/documentation/api/grid/pdfExportProperties/#footer) in the `PdfExportProperties` property of the Grid. 

The following code example demonstrates how to add a page number in the footer of the exported PDF document.

```cshtml

   var footer = new PdfFooter
        {
            FromBottom = 10,
            Height = 60,
            Contents = new List<PdfHeaderFooterContent>
            {
                new PdfHeaderFooterContent
                {
                    Type = ContentType.PageNumber,
                     PageNumberType = PdfPageNumberType.Arabic,
                    Value = "Page ${current} of ${total}",
                    Position = new PdfPosition { X = 0, Y = 25 },
                    Style = new PdfContentStyle
                    {
                        TextBrushColor = "#4169e1",
                        FontSize = 15,
                        HAlign = PdfHorizontalAlign.Center
                    }
                }
            }
        };


```

## Insert an image in header and footer

The Syncfusion Blazor DataGrid have an option to include an image in the header and footer section when exporting data from the Grid to PDF document. This feature allows you to add a custom logo, branding, or any other relevant image to the exported PDF document.

You can use a base64 string with the .jpeg format to represent the image. This can be achieved using the [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) property of the Grid.

To insert an image in the header or footer of the exported PDF document, follow these steps:

1. Convert your desired image to a base64 string in the .jpeg format.

2. Access the `PdfExportProperties` of the Grid.

3. Set the `Header.Contents.Src` property to the respective file of the image or the base64 string of the image.

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

    public List<PdfHeaderFooterContent> HeaderContent = new List<PdfHeaderFooterContent>
    {
        new PdfHeaderFooterContent() { Type = ContentType.Image, Src = "/9j/4AAQSkZJRgABAQAAAQABAAD...", Position = new PdfPosition() { X = 40, Y = 10 }, Size = new PdfSize() { Height = 100, Width = 250 } }
    };

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
       if (args.Item.Id == "Grid_pdfexport")  //Id is combination of Grid's ID and itemname.
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDhoDfWnryhHzyIz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Repeat column header on every page

When exporting data from the Syncfusion Blazor DataGrid to a PDF document, you have an option to repeat the column header on every page. This feature ensures that the column header remains visible and easily identifiable, even when the data spans multiple pages in the exported PDF document.

By default, the column header is occurs only on the first page of the PDF document. However, you can enable the `IsRepeatHeader` property of the **pdfGrid** object to **true** which display the column header on every page. This can be achieved using the [PdfHeaderQueryCellInfo](https://ej2.syncfusion.com/angular/documentation/api/grid/#pdfheaderquerycellinfo) event of the Grid.

The following example demonstrates how to repeat the column header on every page of the exported PDF document using the `PdfHeaderQueryCellInfo` event.

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
            ExportProperties.IsRepeatHeader = true;
            await this.DefaultGrid.PdfExport(ExportProperties);
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDLyXTCdVQgRVfzE?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}