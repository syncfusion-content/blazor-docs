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

<SfButton Content="ExportBase64" OnClick="@ExportBase64Async" />
<SfButton Content="ExportPng" OnClick="@ExportPngAsync" />
<SfDiagramComponent Height="600px" @ref="@_diagram">
</SfDiagramComponent>

@code {
    SfDiagramComponent _diagram;

    //To export the diagram as base64 string.
    private async Task ExportBase64Async()
    {
        DiagramExportSettings _export = new DiagramExportSettings();
        string[] base64 = await _diagram.ExportAsync(DiagramExportFormat.PNG, _export);
    }

    //To export the diagram as png.
    private async Task ExportPngAsync()
    {
        DiagramExportSettings _export = new DiagramExportSettings();
        await _diagram.ExportAsync("diagram", DiagramExportFormat.PNG, _export);
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hNVSsXjPKcQBMSRD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Export/Export.razor)

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

<SfButton Content="Export" OnClick="@ExportAsync" />
<SfDiagramComponent Height="600px" @ref="@_diagram">
</SfDiagramComponent>

@code {
    //Reference the diagram
    SfDiagramComponent _diagram;

    private async Task ExportAsync()
    {
        DiagramExportSettings _export = new DiagramExportSettings();
        //To export the diagram
        await _diagram.ExportAsync("Diagram", DiagramExportFormat.SVG, _export);
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BtVICZDlgwcGbHBb?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Export/ExportOption.razor)

### How to Customize Page Size

Diagram provides support to change the page size. The page size can be adjusted by setting the [DiagramExportSettings.PageWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramExportSettings.html#Syncfusion_Blazor_Diagram_DiagramExportSettings_PageWidth) and [DiagramExportSettings.PageHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramExportSettings.html#Syncfusion_Blazor_Diagram_DiagramExportSettings_PageHeight) properties. The default value for width is 1123 pixels and the height is 794 pixels.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Buttons

<SfButton Content="Export" OnClick="@ExportAsync" />
<SfDiagramComponent Height="600px" @ref="@_diagram">
</SfDiagramComponent>

@code {
    //Reference the diagram
    SfDiagramComponent _diagram;

    private async Task ExportAsync()
    {
        DiagramExportSettings _export = new DiagramExportSettings();
        _export.PageWidth = 816;
        _export.PageHeight = 1054;
        //To export the diagram
        await _diagram.ExportAsync(DiagramExportFormat.SVG, _export);
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rtBesNNFgwFiDfWu?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Export/ExportWithPageSize.razor)

### How to Add Margin Around Exported Diagram Image

[Margin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramExportSettings.html#Syncfusion_Blazor_Diagram_DiagramExportSettings_Margin) specifies the space around the content to be printed/exported.The default value for margin is 25 for all sides.
<!-- markdownlint-disable MD033 -->

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Buttons

<SfButton Content="Export" OnClick="@ExportAsync" />
<SfDiagramComponent Height="600px" @ref="@_diagram">
    <PageSettings Height="1000" Width="800"></PageSettings>
</SfDiagramComponent>

@code {
    //Reference the diagram
    SfDiagramComponent _diagram;

    private async Task ExportAsync()
    {
        DiagramExportSettings _export = new DiagramExportSettings();
        _export.Region = DiagramPrintExportRegion.PageSettings;
        _export.PageWidth = 816;
        _export.PageHeight = 1054;
        _export.Margin = new DiagramThickness() { Left = 10, Top = 10, Right = 10, Bottom = 10 };
        //To export the diagram
        await _diagram.ExportAsync("diagram", DiagramExportFormat.PNG, _export);
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hNryCjZvAmvTSrzu?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Export/ExportMargin.razor)

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

<SfButton Content="Export" OnClick="@ExportAsync" />
<SfDiagramComponent Height="600px" @ref="@_diagram">
    <PageSettings Height="1000" Width="800"></PageSettings>
</SfDiagramComponent>

@code {
    //Reference the diagram
    SfDiagramComponent _diagram;

    private async Task ExportAsync()
    {
        DiagramExportSettings _export = new DiagramExportSettings();
        _export.Region = DiagramPrintExportRegion.PageSettings;
        _export.PageWidth = 816;
        _export.PageHeight = 1054;
        _export.Margin = new DiagramThickness() { Left = 10, Top = 10, Right = 10, Bottom = 10 };
        //To export the diagram
        await _diagram.ExportAsync("Diagram", DiagramExportFormat.PNG, _export);
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hZrSiXtvUwbliLpo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Export/ExportRegion.razor)

### How to Export Diagram with Custom Bounds

Diagram provides support to export any specific region of the diagram by using the [ClipBounds](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramExportSettings.html#Syncfusion_Blazor_Diagram_DiagramExportSettings_ClipBounds) property.

The following code example illustrates how to export the region specified in the bounds.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Buttons

<SfButton Content="Export" OnClick="@ExportAsync" />
<SfDiagramComponent Height="600px" @ref="@_diagram">
</SfDiagramComponent>

@code{
    SfDiagramComponent _diagram;

    private async Task ExportAsync()
    {
        DiagramExportSettings _export = new DiagramExportSettings();
        _export.Region = DiagramPrintExportRegion.PageSettings;
        _export.PageWidth = 816;
        _export.PageHeight = 1054;                  
        _export.Margin = new DiagramThickness() { Left = 10, Top = 10, Right = 10, Bottom = 10 };
        _export.ClipBounds = new DiagramRect() { X = 0, Y = 0, Width = 500, Height = 500 };
        //To export the diagram
        await _diagram.ExportAsync("diagram",DiagramExportFormat.PNG, _export);
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BZresXjFUwYAvcER?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Export/ExportClipBounds.razor)

### How to Export Diagram as Single or Multiple Pages

Diagram provides support to export the entire diagram to either a single page or multiple pages using the [FitToPage](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramExportSettings.html#Syncfusion_Blazor_Diagram_DiagramExportSettings_FitToPage) property. By default, this property is set to false.

* True: Exports the diagram in a single page.
* False: Exports the diagram into multiple pages.

The following code example illustrates how to export the diagram to a single page.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Buttons

<SfButton Content="Export" OnClick="@ExportAsync" />
<SfDiagramComponent Height="600px" @ref="@_diagram">
    <PageSettings Height="1000" Width="800"></PageSettings>
</SfDiagramComponent>

@code {
    //Reference the diagram.
    SfDiagramComponent _diagram;

    private async Task ExportAsync()
    {
        DiagramExportSettings _export = new DiagramExportSettings();
        _export.Region = DiagramPrintExportRegion.PageSettings;
        _export.PageWidth = 816;
        _export.PageHeight = 1054;
        //To export the diagram in single page.
        _export.FitToPage = true;
        _export.Margin = new DiagramThickness() { Left = 10, Top = 10, Right = 10, Bottom = 10 };
        _export.ClipBounds = new DiagramRect() { X = 0, Y = 0, Width = 500, Height = 500 };
        //To export the diagram
        await _diagram.ExportAsync("Diagram", DiagramExportFormat.PNG, _export);
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LXBoMtjbgwaFojuu?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Export/ExportWithPage.razor)

### How to Change Orientation at Runtime

The diagram component supports switching between [Portrait](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PageOrientation.html#Syncfusion_Blazor_Diagram_PageOrientation_Portrait) and [Landscape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.PageOrientation.html#Syncfusion_Blazor_Diagram_PageOrientation_Landscape) orientation while exporting. The orientation can be configured by setting the [DiagramExportSettings.Orientation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramExportSettings.html#Syncfusion_Blazor_Diagram_DiagramExportSettings_Orientation) Property. By default, the orientation is set to **Landscape**.

```cshtml
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Buttons

<SfButton Content="Export" OnClick="@ExportAsync" />
<SfDiagramComponent Height="600px" @ref="@_diagram">
</SfDiagramComponent>

@code{
    SfDiagramComponent _diagram;

    private async Task ExportAsync()
    {
        DiagramExportSettings _export = new DiagramExportSettings();
        _export.Region = DiagramPrintExportRegion.PageSettings;
        _export.PageWidth = 816;
        _export.PageHeight = 1054;
        //To export the diagram in single page.
        _export.FitToPage = true;
        _export.Orientation = PageOrientation.Landscape;         
        _export.Margin = new DiagramThickness() { Left = 10, Top = 10, Right = 10, Bottom = 10 };
        _export.ClipBounds = new DiagramRect() { X = 0, Y = 0, Width = 500, Height = 500 };
        //To export the diagram
        await _diagram.ExportAsync("diagram", DiagramExportFormat.PNG, _export);
    }
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Export/ExportOrientation.razor)

### How to Export the Diagram as PDF

Diagram does not have built-in support to convert the diagram to a PDF file. However, this can be achieved by exporting the diagram as a base64 and then converting the exported file to PDF using Syncfusion.PdfExport.PdfDocument. JavaScript functions `downloadPdf` and `triggerDownload` are invoked to automatically download the pdf file. 

The following code illustrates how to export the diagram as PDF file.

```cshtml
@using Syncfusion.PdfExport;

@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Buttons
@inject IJSRuntime JS;

<SfButton Content="ExportPDF" OnClick="@ExportPDFAsync" />
<SfDiagramComponent Height="600px" @ref="@_diagram">
</SfDiagramComponent>

@code{
    //Reference the diagram
    SfDiagramComponent _diagram;

    private async void ExportPDFAsync()
    {
        DiagramExportSettings _print = new DiagramExportSettings();
        _print.Region = DiagramPrintExportRegion.PageSettings;
        _print.PageWidth = 500;
        _print.PageHeight = 800;
        _print.Orientation = PageOrientation.Portrait;
        _print.FitToPage = true;
        _print.Margin = new DiagramThickness() { Left = 30, Top = 20, Right = 10, Bottom = 10 };
        _print.ClipBounds = new DiagramRect() { X = 200, Y = 200, Width = 200, Height = 200 };
        //To export the diagram into base64
        var _images = await _diagram.ExportAsync(DiagramExportFormat.PNG, _print);
        var _pdforientation = PageOrientation.Portrait == PageOrientation.Landscape ? PdfPageOrientation.Landscape : PdfPageOrientation.Portrait;
        await ExportToPdfAsync("diagram", _pdforientation, true, _images);        
    }
    //
    private async Task<string> ExportToPdfAsync(string fileName, PdfPageOrientation orientation, bool allowDownload, string[] images)
    {
        PdfDocument _document = new PdfDocument();
        _document.PageSettings.Orientation = orientation;
        _document.PageSettings.Margins = new PdfMargins() { Left = 0, Right = 0, Top = 0, Bottom = 0 };
        string _base64String;
        var _dict = images;
        for (int i = 0; i < _dict.Count(); i++)
        {
            _base64String = _dict[i];
            using (MemoryStream _initialStream = new MemoryStream(Convert.FromBase64String(_base64String.Split("base64,")[1])))
            {
                Stream _stream = _initialStream as Stream;
                PdfPage _page = _document.Pages.Add();
                PdfGraphics _graphics = _page.Graphics;
                #pragma warning disable CA2000
                PdfBitmap _image = new PdfBitmap(_stream);
                #pragma warning restore CA2000
                _graphics.DrawImage(_image, 0, 0);
            }
        }
        using (MemoryStream _memoryStream = new MemoryStream())
        {
            _document.Save(_memoryStream);
            _memoryStream.Position = 0;
            _base64String = Convert.ToBase64String(_memoryStream.ToArray());
            if (allowDownload)
            {
                await JSRuntimeExtensions.InvokeAsync<string>(JS, "downloadPdf", new object[] { _base64String, fileName });
                _base64String = string.Empty;
            }
            else
            {
                _base64String = "data:application/pdf;base64," + _base64String;
            }
            _document.Dispose();
        }
        return _base64String;
    }

}

// Javascript methods to download file
function downloadPdf(base64String, fileName) {
    var _sliceSize = 512;
    var _byteCharacters = atob(base64String);
    var _byteArrays = [];
    for (var offset = 0; offset < _byteCharacters.length; offset += _sliceSize)
    {
        var _slice = _byteCharacters.slice(offset, offset + _sliceSize);
        var _byteNumbers = new Array(slice.length);
        for (var i = 0; i < _slice.length; i++)
        {
            _byteNumbers[i] = _slice.charCodeAt(i);
        }
        var _byteArray = new Uint8Array(_byteNumbers);
        _byteArrays.push(_byteArray);
    }
    var _blob = new Blob(_byteArrays,
        {
            type: 'application/pdf'
        }
    );
    var _blobUrl = window.URL.createObjectURL(_blob);
    this.triggerDownload("PDF", fileName, _blobUrl);
}
triggerDownload: function triggerDownload(type, fileName, url)
{
    var _anchorElement = document.createElement('a');
    _anchorElement.download = fileName + '.' + type.toLocaleLowerCase();
    _anchorElement.href = url;
    _anchorElement.click();
}
```
A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-UG-Examples/blob/master/Diagram/Server/Pages/Export/ExportToPDF.razor)

## See Also

* [How to print or export the HTML and Native node into image format](https://support.syncfusion.com/kb/article/12332/how-to-print-or-export-the-html-and-native-node-into-image-format-in-blazor-diagarm)

* [How to Export the Blazor Diagram to PDF](https://support.syncfusion.com/kb/article/16302/how-to-export-the-blazor-diagram-to-pdf)

* [How to Export Node Details into Excel File in Blazor Diagram](https://support.syncfusion.com/kb/article/16319/how-to-export-node-details-into-excel-file-in-blazor-diagram)

* [How to Export HTML Shapes into Image and PDF Format in Blazor Diagram](https://support.syncfusion.com/kb/article/16039/how-to-export-html-shapes-into-image-and-pdf-format-in-blazor-diagram)

* [How to Export Blazor Diagram with Image Nodes to a PNG File](https://support.syncfusion.com/kb/article/18750/how-to-export-blazor-diagram-with-image-nodes-to-a-png-file)
