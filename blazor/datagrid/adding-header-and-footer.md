---
layout: post
title:  Adding header and footer in Blazor DataGrid | Syncfusion
description: Checkout and learn here all about Adding Header and Footer in Pdf Export Syncfusion Blazor DataGrid and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Adding header and footer in Blazor DataGrid 

The Syncfusion Blazor DataGrid allows you to add customized header and footer sections in the exported PDF document. This feature enables you to include custom text, page numbers, lines, page size, and even change the orientation of the header and footer.

## Adding text in header and footer

The Syncfusion Blazor DataGrid allows you to add custom text in the header or footer section in the exported PDF document.  

The header section of a PDF document is typically located at the top of each page. It's a space where you can include additional information or branding elements. This is particularly useful for adding details like a company logo, a title for the document, a date, or any other information that you want to appear consistently on every page of the PDF.

The footer section, on the other hand, is usually positioned at the bottom of each page in the PDF. It's another area where you can insert custom text. Common content in the footer includes page numbers, copyright information, or disclaimers. Similar to the header, the footer content is repeated on every page.

To add text in the header or footer of the exported PDF document, follow these steps:

1. Access the [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) of the Grid.
2. Set the [Header](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_Header) or [Footer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_Footer) property to a string value representing the desired text.
3. Trigger the PDF export operation.

The following code example demostrates how to add the header in the exported PDF document. 

```typescript

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

To add a line in the header or footer of the exported PDF document, you can access the `Header.Contents` or `Footer.Contents` property of the [Header](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_Header) or [Footer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_Footer) in the `PdfExportProperties` property of the grid. 

The following code example demostrates how to draw a line in the header of the exported PDF document. 

```typescript

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

To add a page number in the header or footer of the exported PDF document, you can access the `Header.Contents` or `Footer.Contents` property of the [Header](https://ej2.syncfusion.com/angular/documentation/api/grid/pdfExportProperties/#header) or [Footer](https://ej2.syncfusion.com/angular/documentation/api/grid/pdfExportProperties/#footer) in the `PdfExportProperties` property of the grid. 

The following code example demostrates how to add a page number in the footer of the exported PDF document.

```typescript

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

The Syncfusion Blazor DataGrid have an option to include an image in the header and footer section when exporting data from the Grid to PDF document. This feature allows you to add a custom logo, branding, or any other relevant image to the exported document.

You can use a base64 string with the .jpeg format to represent the image. This can be achieved using the [PdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportProperties.html) property of the Grid.

To insert an image in the header or footer of the exported PDF document, follow these steps:

1. Convert your desired image to a base64 string in the .jpeg format.

2. Access the `PdfExportProperties` of the Grid.

3. Set the `Header.Contents.Src` property to the respective file of the image or the base64 string of the image.

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/LDhoDfWnryhHzyIz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Repeat column header on every page

When exporting data from the Syncfusion Blazor DataGrid to a PDF document, you have an option to repeat the column header on every page. This feature ensures that the column header remains visible and easily identifiable, even when the data spans multiple pages in the exported PDF document.

By default, the column header is occurs only on the first page of the PDF document. However, you can enable the `IsRepeatHeader` property of the **pdfGrid** object to **true** which display the column header on every page. This can be achieved using the [PdfHeaderQueryCellInfo](https://ej2.syncfusion.com/angular/documentation/api/grid/#pdfheaderquerycellinfo) event of the Grid.

The following example demonstrates how to repeat the column header on every page of the exported PDF document using the `PdfHeaderQueryCellInfo` event.

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
       if (args.Item.Id == "Grid_pdfexport")  //Id is combination of Grid's ID and itemname.
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
{% previewsample "https://blazorplayground.syncfusion.com/embed/VDLyXTCdVQgRVfzE?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}