---
layout: post
title: Exporting in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about the Exporting feature in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Exporting in Blazor Diagram Component

Diagram provides support to export the diagram as image/svg files. The following methods helps to export the diagram in desired formats.

* `ExportAsync(DiagramExportFormat, DiagramExportSettings)` : Returns the exported diagram as base64 string of the specified file type.To explore the parameters, refer [ExportAsync(DiagramExportFormat, DiagramExportSettings)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_ExportAsync_Syncfusion_Blazor_Diagram_DiagramExportFormat_Syncfusion_Blazor_Diagram_DiagramExportSettings_).

* `ExportAsync(String, DiagramExportFormat, DiagramExportSettings)` : Exports the rendered diagram to various file types. It supports jpeg, png, svg ,bmp and pdf file types. Exported file will get download at client machine. To explore the parameters, refer [ExportAsync(String, DiagramExportFormat, DiagramExportSettings)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_ExportAsync_System_String_Syncfusion_Blazor_Diagram_DiagramExportFormat_Syncfusion_Blazor_Diagram_DiagramExportSettings_).  

<!-- markdownlint-disable MD033 -->

```cshtml
@using Syncfusion.Blazor.Diagram

<input type="button" value="Export" @onclick="@OnExport" />
<input type="button" value="Export" @onclick="@OnExportEntry" />
<SfDiagramComponent Height="600px" @ref="@diagram">
</SfDiagramComponent>

@code{
     SfDiagramComponent diagram;

     //To export the diagram as base64 string.
     private void OnExport()
     {
          DiagramExportSettings export = new DiagramExportSettings();         
          string[] base64 = await diagram.ExportAsync(DiagramExportFormat.PNG, export);          
     }

     //To export the diagram as png.
     private void OnExportEntry()
     {
          DiagramExportSettings export = new DiagramExportSettings();                   
          await diagram.ExportAsync("diagram",DiagramExportFormat.PNG, export);
     }
}
```

## Exporting options

Diagram provides support to export the desired region of the diagram to desired formats.

### File Formats

[DiagramExportFormat](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramExportFormat.html) is to specify the type/format of the exported file. By default, the diagram is exported as .jpeg format. You can export diagram to the following formats:

* JPEG
* PNG
* SVG

```cshtml
@using Syncfusion.Blazor.Diagram

<input type="button" value="Export" @onclick="@OnExport" />
<SfDiagramComponent Height="600px" @ref="@diagram">
</SfDiagramComponent>

@code{
     SfDiagramComponent diagram;

     private void OnExport()
     {
          DiagramExportSettings export = new DiagramExportSettings();                  
          //To export the diagram
          await diagram.ExportAsync(DiagramExportFormat.SVG, export);
     }
}
```

### Page Size

Diagram provides support to change the page size. Page size can be changed by setting the [DiagramExportSettings.PageWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramExportSettings.html#Syncfusion_Blazor_Diagram_DiagramExportSettings_PageWidth) and [DiagramExportSettings.PageHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramExportSettings.html#Syncfusion_Blazor_Diagram_DiagramExportSettings_PageHeight) properties. The default value of width is 1123 pixel and height is 794 pixel.

```cshtml
@using Syncfusion.Blazor.Diagram

<input type="button" value="Export" @onclick="@OnExport" />
<SfDiagramComponent Height="600px" @ref="@diagram">
</SfDiagramComponent>

@code{
     SfDiagramComponent diagram;

     private void OnExport()
     {
          DiagramExportSettings export = new DiagramExportSettings();          
          export.PageWidth = 816;
          export.PageHeight = 1054;         
          //To export the diagram
          await diagram.ExportAsync(DiagramExportFormat.SVG, export);
     }
}
```

### Add margin around exported image

[Margin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramExportSettings.html#Syncfusion_Blazor_Diagram_DiagramExportSettings_Margin) specifies the amount of space that has to be left around the diagram.

<!-- markdownlint-disable MD033 -->

```cshtml
@using Syncfusion.Blazor.Diagram

<input type="button" value="Export" @onclick="@OnExport" />
<SfDiagramComponent Height="600px" @ref="@diagram">
</SfDiagramComponent>

@code{
     SfDiagramComponent diagram;

     private void OnExport()
     {
          DiagramExportSettings export = new DiagramExportSettings();
          export.Region = DiagramPrintExportRegion.PageSettings;
          export.Margin = new Margin() { Left = 10, Top = 10, Right = 10, Bottom = 10 };
          //To export the diagram
          await diagram.ExportAsync(DiagramExportFormat.PNG, export);
     }
}
```

### Export diagram based on region

[Region](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramExportSettings.html#Syncfusion_Blazor_Diagram_DiagramExportSettings_Region) specifies whether the diagram is to be exported based on page settings, content or clip bounds. The exporting options are as follows:

* PageSettings: Specifies the region within the x,y, width and height values of page settings is printed or exported.
* Content: Specifies the content of the diagram without empty space around the content is printed or exported.
* ClipBounds: Exports the region specified using ClipBounds property. This is applicable for exporting only.

For more information, refer to [DiagramPrintExportRegion](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramPrintExportRegion.html).

The following code example illustrates how to export the diagram based on page settings.

```cshtml
@using Syncfusion.Blazor.Diagram

<input type="button" value="Export" @onclick="@OnExport" />
<SfDiagramComponent Height="600px" @ref="@diagram">
</SfDiagramComponent>

@code{
     SfDiagramComponent diagram;

     private void OnExport()
     {
          DiagramExportSettings export = new DiagramExportSettings();
          export.Region = DiagramPrintExportRegion.PageSettings;
          export.PageWidth = 816;
          export.PageHeight = 1054;                
          export.Margin = new Margin() { Left = 10, Top = 10, Right = 10, Bottom = 10 };          
          //To export the diagram
          await diagram.ExportAsync(DiagramExportFormat.PNG, export);
     }
}
```

### Custom bounds

Diagram provides support to export any specific region of the diagram by using [ClipBounds](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramExportSettings.html#Syncfusion_Blazor_Diagram_DiagramExportSettings_ClipBounds).

The following code example illustrates how to export the region specified in the bounds.

```cshtml
@using Syncfusion.Blazor.Diagram

<input type="button" value="Export" @onclick="@OnExport" />
<SfDiagramComponent Height="600px" @ref="@diagram">
</SfDiagramComponent>

@code{
     SfDiagramComponent diagram;

     private void OnExport()
     {
          DiagramExportSettings export = new DiagramExportSettings();
          export.Region = DiagramPrintExportRegion.PageSettings;
          export.PageWidth = 816;
          export.PageHeight = 1054;                  
          export.Margin = new Margin() { Left = 10, Top = 10, Right = 10, Bottom = 10 };
          export.ClipBounds = new DiagramRect() { X = 0, Y = 0, Width = 500, Height = 500 };
          //To export the diagram
          await diagram.ExportAsync(DiagramExportFormat.PNG, export);
     }
}
```

### Export diagram as single or multiple page

Diagram provides support to export the entire diagram to single page or multiple pages using [FitToPage](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramExportSettings.html#Syncfusion_Blazor_Diagram_DiagramExportSettings_FitToPage) property. The default value is false.

* True: Exports the diagram in single page.
* False: Exports the diagram into multiple pages.

The following code example illustrates how to export the diagram to single page.

```cshtml
@using Syncfusion.Blazor.Diagram

<input type="button" value="Export" @onclick="@OnExport" />
<SfDiagramComponent Height="600px" @ref="@diagram">
</SfDiagramComponent>

@code{
     SfDiagramComponent diagram;

     private void OnExport()
     {
          DiagramExportSettings export = new DiagramExportSettings();
          export.Region = DiagramPrintExportRegion.PageSettings;
          export.PageWidth = 816;
          export.PageHeight = 1054;
          //To export the diagram in single page.
          print.FitToPage = true;         
          export.Margin = new Margin() { Left = 10, Top = 10, Right = 10, Bottom = 10 };
          export.ClipBounds = new DiagramRect() { X = 0, Y = 0, Width = 500, Height = 500 };
          //To export the diagram
          await diagram.ExportAsync(DiagramExportFormat.PNG, export);
     }
}
```

### Change Orientation at runtime

Diagram provides support to switch between Portrait and Landscape orientation while exporting. Orientation can be changed by setting the DiagramExportSettings.Orientation Property. The default value is Landscape.

```cshtml
@using Syncfusion.Blazor.Diagram

<input type="button" value="Export" @onclick="@OnExport" />
<SfDiagramComponent Height="600px" @ref="@diagram">
</SfDiagramComponent>

@code{
     SfDiagramComponent diagram;

     private void OnExport()
     {
          DiagramExportSettings export = new DiagramExportSettings();
          export.Region = DiagramPrintExportRegion.PageSettings;
          export.PageWidth = 816;
          export.PageHeight = 1054;
          //To export the diagram in single page.
          print.FitToPage = true;
          export.Orientation = PageOrientation.Landscape;         
          export.Margin = new Margin() { Left = 10, Top = 10, Right = 10, Bottom = 10 };
          export.ClipBounds = new DiagramRect() { X = 0, Y = 0, Width = 500, Height = 500 };
          //To export the diagram
          await diagram.ExportAsync(DiagramExportFormat.PNG, export);
     }
}
```

### Export to PDF

SfDiagramComponent does not have the built-in support to convert the diagram to PDF file, but you can achieve this by exporting the diagram as base-64 and then convert the exported file to PDF using Syncfusion.PdfExport.PdfDocument.

The following code illustrates how to export the diagram as PDF file.

```cshtml
@using Syncfusion.Blazor.Diagram

<input type="button" value="Export" @onclick="@OnExportEntry" />
<SfDiagramComponent Height="600px" @ref="@diagram">
</SfDiagramComponent>

@code{
    SfDiagramComponent diagram;

    private async void OnExportEntry()
    {
        DiagramExportSettings print = new DiagramExportSettings();
        print.Region = region;
        print.PageWidth = pageWidth;
        print.PageHeight = pageHeight;
        print.Orientation = orientation;
        print.FitToPage = multiplePage;
        print.Margin = new Margin() { Left = left, Top = top, Right = right, Bottom = bottom };
        print.ClipBounds = new DiagramRect() { X = double.Parse(x), Y = double.Parse(y), Width = double.Parse(cwidth), Height = double.Parse(cheight) };
        //To export the diagram into base64
        var images = await diagram.ExportAsync(format, print);
        var pdforientation = orientation == PageOrientation.Landscape ? PdfPageOrientation.Landscape : PdfPageOrientation.Portrait;
        await ExportToPdf("diagram", pdforientation, true, images);        
    }

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
```