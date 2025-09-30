---
layout: post
title: Exporting in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about the Exporting feature in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Exporting in Blazor Diagram Component
To save and export a Blazor Diagram, watch the following video tutorial for a quick walkthrough of key options and workflows.

{% youtube "youtube:https://www.youtube.com/watch?v=2hhl00gMObc" %}

Diagram provides support to export the diagram as image or SVG files. The following methods help to export the diagram in the desired formats.

* `ExportAsync(DiagramExportFormat, DiagramExportSettings)`: Returns the exported diagram as a base64 string in the specified file format. For detailed information on the parameters, refer to [ExportAsync(DiagramExportFormat, DiagramExportSettings)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_ExportAsync_Syncfusion_Blazor_Diagram_DiagramExportFormat_Syncfusion_Blazor_Diagram_DiagramExportSettings_).

* `ExportAsync(String, DiagramExportFormat, DiagramExportSettings)` : Exports the rendered diagram to various file types. It supports jpeg, png, svg and pdf file types. Exported file will be downloaded at the client machine. To explore the parameters, refer to [ExportAsync(String, DiagramExportFormat, DiagramExportSettings)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_ExportAsync_System_String_Syncfusion_Blazor_Diagram_DiagramExportFormat_Syncfusion_Blazor_Diagram_DiagramExportSettings_).  

<!-- markdownlint-disable MD033 -->

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Buttons

<SfButton Content="ExportBase64" OnClick="@ExportBase64" />
<SfButton Content="ExportPng" OnClick="@ExportPng" />
<SfDiagramComponent Height="600px" @ref="@diagram">
</SfDiagramComponent>

@code {
    SfDiagramComponent diagram;

    //To export the diagram as base64 string.
    private async Task ExportBase64()
    {
        DiagramExportSettings export = new DiagramExportSettings();
        string[] base64 = await diagram.ExportAsync(DiagramExportFormat.PNG, export);
    }

    //To export the diagram as png.
    private async Task ExportPng()
    {
        DiagramExportSettings export = new DiagramExportSettings();
        await diagram.ExportAsync("diagram", DiagramExportFormat.PNG, export);
    }
}
```
You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Export/Export)

## Exporting Options

Diagram provides support to export the desired region of the diagram to the desired formats.

### How to Export Diagram to Different File Formats

[DiagramExportFormat](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramExportFormat.html) specifies the type/format of the exported file. By default, the diagram is exported in .jpeg format. Export the diagram to the following formats:

* JPEG
* PNG
* SVG

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Buttons

<SfButton Content="Export" OnClick="@Export" />
<SfDiagramComponent Height="600px" @ref="@diagram">
</SfDiagramComponent>

@code {
    //Reference the diagram
    SfDiagramComponent diagram;

    private async Task Export()
    {
        DiagramExportSettings export = new DiagramExportSettings();
        //To export the diagram
        await diagram.ExportAsync("Diagram", DiagramExportFormat.SVG, export);
    }
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Export/ExportOption)

### How to Customize Page Size

Diagram provides support to change the page size. The page size can be adjusted by setting the [DiagramExportSettings.PageWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramExportSettings.html#Syncfusion_Blazor_Diagram_DiagramExportSettings_PageWidth) and [DiagramExportSettings.PageHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramExportSettings.html#Syncfusion_Blazor_Diagram_DiagramExportSettings_PageHeight) properties. The default value for width is 1123 pixels and the height is 794 pixels.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Buttons

<SfButton Content="Export" OnClick="@Export" />
<SfDiagramComponent Height="600px" @ref="@diagram">
</SfDiagramComponent>

@code {
    //Reference the diagram
    SfDiagramComponent diagram;

    private async Task Export()
    {
        DiagramExportSettings export = new DiagramExportSettings();
        export.PageWidth = 816;
        export.PageHeight = 1054;
        //To export the diagram
        await diagram.ExportAsync(DiagramExportFormat.SVG, export);
    }
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Export/ExportWithPageSize)

### How to Add Margin Around Exported Diagram Image

[Margin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramExportSettings.html#Syncfusion_Blazor_Diagram_DiagramExportSettings_Margin) specifies the space around the content to be printed/exported.The default value for margin is 25 for all sides.
<!-- markdownlint-disable MD033 -->

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Buttons

<SfButton Content="Export" OnClick="@Export" />
<SfDiagramComponent Height="600px" @ref="@diagram">
    <PageSettings Height="1000" Width="800"></PageSettings>
</SfDiagramComponent>

@code {
    //Reference the diagram
    SfDiagramComponent diagram;

    private async Task Export()
    {
        DiagramExportSettings export = new DiagramExportSettings();
        export.Region = DiagramPrintExportRegion.PageSettings;
        export.PageWidth = 816;
        export.PageHeight = 1054;
        export.Margin = new DiagramThickness() { Left = 10, Top = 10, Right = 10, Bottom = 10 };
        //To export the diagram
        await diagram.ExportAsync("diagram", DiagramExportFormat.PNG, export);
    }
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Export/ExportMargin)

### How to Export Diagrams by Region

[Region](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramExportSettings.html#Syncfusion_Blazor_Diagram_DiagramExportSettings_Region) specifies whether the diagram is to be exported based on page settings, content, or clip bounds. The exporting options are as follows:

* [PageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramPrintExportRegion.html#Syncfusion_Blazor_Diagram_DiagramPrintExportRegion_PageSettings): Specifies the region within the x, y, width, and height values of page settings that is printed or exported.
* [Content](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramPrintExportRegion.html#Syncfusion_Blazor_Diagram_DiagramPrintExportRegion_Content): Specifies the content of the diagram without empty space around the content that is printed or exported.
* [ClipBounds](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramPrintExportRegion.html#Syncfusion_Blazor_Diagram_DiagramPrintExportRegion_ClipBounds): Exports the region specified using the [ClipBounds](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.IDiagramPrintExportSettings.html#Syncfusion_Blazor_Diagram_IDiagramPrintExportSettings_ClipBounds) property of `DiagramExportSettings`. This is applicable for export only.

For more information, refer to [DiagramPrintExportRegion](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramPrintExportRegion.html).

The following code example illustrates how to export the diagram based on page settings.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Buttons

<SfButton Content="Export" OnClick="@Export" />
<SfDiagramComponent Height="600px" @ref="@diagram">
    <PageSettings Height="1000" Width="800"></PageSettings>
</SfDiagramComponent>

@code {
    //Reference the diagram
    SfDiagramComponent diagram;

    private async Task Export()
    {
        DiagramExportSettings export = new DiagramExportSettings();
        export.Region = DiagramPrintExportRegion.PageSettings;
        export.PageWidth = 816;
        export.PageHeight = 1054;
        export.Margin = new DiagramThickness() { Left = 10, Top = 10, Right = 10, Bottom = 10 };
        //To export the diagram
        await diagram.ExportAsync("Diagram", DiagramExportFormat.PNG, export);
    }
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Export/ExportRegion)

### How to Export Diagram with Custom Bounds

Diagram provides support to export any specific region of the diagram by using the [ClipBounds](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramExportSettings.html#Syncfusion_Blazor_Diagram_DiagramExportSettings_ClipBounds) property.

The following code example illustrates how to export the region specified in the bounds.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Buttons

<SfButton Content="Export" OnClick="@Export" />
<SfDiagramComponent Height="600px" @ref="@diagram">
</SfDiagramComponent>

@code{
     SfDiagramComponent diagram;

     private async Task Export()
     {
          DiagramExportSettings export = new DiagramExportSettings();
          export.Region = DiagramPrintExportRegion.PageSettings;
          export.PageWidth = 816;
          export.PageHeight = 1054;                  
          export.Margin = new DiagramThickness() { Left = 10, Top = 10, Right = 10, Bottom = 10 };
          export.ClipBounds = new DiagramRect() { X = 0, Y = 0, Width = 500, Height = 500 };
          //To export the diagram
          await diagram.ExportAsync("diagram",DiagramExportFormat.PNG, export);
     }
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Export/ExportClipBounds)

### How to Export Diagram as Single or Multiple Pages

Diagram provides support to export the entire diagram to either a single page or multiple pages using the [FitToPage](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramExportSettings.html#Syncfusion_Blazor_Diagram_DiagramExportSettings_FitToPage) property. By default, this property is set to false.

* True: Exports the diagram in a single page.
* False: Exports the diagram into multiple pages.

The following code example illustrates how to export the diagram to a single page.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Buttons

<SfButton Content="Export" OnClick="@Export" />
<SfDiagramComponent Height="600px" @ref="@diagram">
    <PageSettings Height="1000" Width="800"></PageSettings>
</SfDiagramComponent>

@code {
    //Reference the diagram.
    SfDiagramComponent diagram;

    private async Task Export()
    {
        DiagramExportSettings export = new DiagramExportSettings();
        export.Region = DiagramPrintExportRegion.PageSettings;
        export.PageWidth = 816;
        export.PageHeight = 1054;
        //To export the diagram in single page.
        export.FitToPage = true;
        export.Margin = new DiagramThickness() { Left = 10, Top = 10, Right = 10, Bottom = 10 };
        export.ClipBounds = new DiagramRect() { X = 0, Y = 0, Width = 500, Height = 500 };
        //To export the diagram
        await diagram.ExportAsync("Diagram", DiagramExportFormat.PNG, export);
    }
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Export/ExportWithPage)

### How to Change Orientation at Runtime

The diagram component supports switching between [Portrait](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PageOrientation.html#Syncfusion_Blazor_Diagram_PageOrientation_Portrait) and [Landscape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PageOrientation.html#Syncfusion_Blazor_Diagram_PageOrientation_Landscape) orientation while exporting. The orientation can be configured by setting the [DiagramExportSettings.Orientation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramExportSettings.html#Syncfusion_Blazor_Diagram_DiagramExportSettings_Orientation) Property. By default, the orientation is set to Landscape.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Buttons

<SfButton Content="Export" OnClick="@Export" />
<SfDiagramComponent Height="600px" @ref="@diagram">
</SfDiagramComponent>

@code{
     SfDiagramComponent diagram;

     private async Task Export()
     {
          DiagramExportSettings export = new DiagramExportSettings();
          export.Region = DiagramPrintExportRegion.PageSettings;
          export.PageWidth = 816;
          export.PageHeight = 1054;
          //To export the diagram in single page.
          export.FitToPage = true;
          export.Orientation = PageOrientation.Landscape;         
          export.Margin = new DiagramThickness() { Left = 10, Top = 10, Right = 10, Bottom = 10 };
          export.ClipBounds = new DiagramRect() { X = 0, Y = 0, Width = 500, Height = 500 };
          //To export the diagram
          await diagram.ExportAsync("diagram", DiagramExportFormat.PNG, export);
     }
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Export/ExportOrientation)

### How to Export the Diagram as PDF

Diagram does not have built-in support to convert the diagram to a PDF file. However, this can be achieved by exporting the diagram as a base64 and then converting the exported file to PDF using Syncfusion.PdfExport.PdfDocument. JavaScript functions `downloadPdf` and `triggerDownload` are invoked to automatically download the pdf file. 

The following code illustrates how to export the diagram as PDF file.

```cshtml
@using Syncfusion.PdfExport;

@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Buttons
@inject IJSRuntime JS;

<SfButton Content="ExportPDF" OnClick="@ExportPDF" />
<SfDiagramComponent Height="600px" @ref="@diagram">
</SfDiagramComponent>

@code{
    //Reference the diagram
    SfDiagramComponent diagram;

    private async void ExportPDF()
    {
        DiagramExportSettings print = new DiagramExportSettings();
        print.Region = DiagramPrintExportRegion.PageSettings;
        print.PageWidth = 500;
        print.PageHeight = 800;
        print.Orientation = PageOrientation.Portrait;
        print.FitToPage = true;
        print.Margin = new DiagramThickness() { Left = 30, Top = 20, Right = 10, Bottom = 10 };
        print.ClipBounds = new DiagramRect() { X = 200, Y = 200, Width = 200, Height = 200 };
        //To export the diagram into base64
        var images = await diagram.ExportAsync(DiagramExportFormat.PNG, print);
        var pdforientation = PageOrientation.Portrait == PageOrientation.Landscape ? PdfPageOrientation.Landscape : PdfPageOrientation.Portrait;
        await ExportToPdf("diagram", pdforientation, true, images);        
    }
    //
    private async Task<string> ExportToPdf(string fileName, PdfPageOrientation orientation, bool allowDownload, string[] images)
    {
        PdfDocument document = new PdfDocument();
        document.PageSettings.Orientation = orientation;
        document.PageSettings.Margins = new PdfMargins() { Left = 0, Right = 0, Top = 0, Bottom = 0 };
        string base64String;
        var dict = images;
        for (int i = 0; i < dict.Count(); i++)
        {
            base64String = dict[i];
            using (MemoryStream initialStream = new MemoryStream(Convert.FromBase64String(base64String.Split("base64,")[1])))
            {
                Stream stream = initialStream as Stream;
                PdfPage page = document.Pages.Add();
                PdfGraphics graphics = page.Graphics;
                #pragma warning disable CA2000
                PdfBitmap image = new PdfBitmap(stream);
                #pragma warning restore CA2000
                graphics.DrawImage(image, 0, 0);
            }
        }
        using (MemoryStream memoryStream = new MemoryStream())
        {
            document.Save(memoryStream);
            memoryStream.Position = 0;
            base64String = Convert.ToBase64String(memoryStream.ToArray());
            if (allowDownload)
            {
                await JSRuntimeExtensions.InvokeAsync<string>(JS, "downloadPdf", new object[] { base64String, fileName });
                base64String = string.Empty;
            }
            else
            {
                base64String = "data:application/pdf;base64," + base64String;
            }
            document.Dispose();
        }
        return base64String;
    }

  }

    // Javascript methods to download file
    function downloadPdf(base64String, fileName) {
    var sliceSize = 512;
    var byteCharacters = atob(base64String);
    var byteArrays = [];
    for (var offset = 0; offset < byteCharacters.length; offset += sliceSize)
    {
        var slice = byteCharacters.slice(offset, offset + sliceSize);
        var byteNumbers = new Array(slice.length);
        for (var i = 0; i < slice.length; i++)
        {
            byteNumbers[i] = slice.charCodeAt(i);
        }
        var byteArray = new Uint8Array(byteNumbers);
        byteArrays.push(byteArray);
    }
    var blob = new Blob(byteArrays,
        {
          type: 'application/pdf'
        }
    );
    var blobUrl = window.URL.createObjectURL(blob);
    this.triggerDownload("PDF", fileName, blobUrl);
}
triggerDownload: function triggerDownload(type, fileName, url)
{
    var anchorElement = document.createElement('a');
    anchorElement.download = fileName + '.' + type.toLocaleLowerCase();
    anchorElement.href = url;
    anchorElement.click();
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/Export/ExportToPDF)

## See Also

* [How to print or export the HTML and Native node into image format](https://support.syncfusion.com/kb/article/12332/how-to-print-or-export-the-html-and-native-node-into-image-format-in-blazor-diagarm)

* [How to Export the Blazor Diagram to PDF](https://support.syncfusion.com/kb/article/16302/how-to-export-the-blazor-diagram-to-pdf)

* [How to Export Node Details into Excel File in Blazor Diagram](https://support.syncfusion.com/kb/article/16319/how-to-export-node-details-into-excel-file-in-blazor-diagram)

* [How to Export HTML Shapes into Image and PDF Format in Blazor Diagram](https://support.syncfusion.com/kb/article/16039/how-to-export-html-shapes-into-image-and-pdf-format-in-blazor-diagram)

* [How to Export Blazor Diagram with Image Nodes to a PNG File](https://support.syncfusion.com/kb/article/18750/how-to-export-blazor-diagram-with-image-nodes-to-a-png-file)
