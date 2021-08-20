---
layout: post
title: Suppress the error dialog in the Blazor PDF Viewer | Syncfusion
description: Learn here all about how to suppress the error dialog in Syncfusion Blazor PDF Viewer component and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Suppress the error dialog in Blazor PDF Viewer Component

The Syncfusion's Blazor PDF Viewer component allows to suppress or disable the error dialog box been displayed in the PDF Viewer using the [**EnableErrorDialog**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PdfViewer.PdfViewerBase.html#Syncfusion_Blazor_PdfViewer_PdfViewerBase_EnableErrorDialog) property. The default value of the property is `true`.

The following code example shows how to suppress the error dialog.

```cshtml
@using Syncfusion.Blazor.PdfViewer

<SfPdfViewer @ref="PdfViewer" ServiceUrl="https://localhost:44399/pdfviewer"  DocumentPath="@DocumentPath" EnableErrorDialog="false" Height="500px" Width="1060px">
</SfPdfViewer>

@code{
    SfPdfViewer PdfViewer;
    private string DocumentPath { get; set; } = "PDF_Succinctly.pdf";
}
```
 
Find the sample, [How to suppress the error dialog in the Blazor PDF Viewer](https://www.syncfusion.com/downloads/support/directtrac/general/ze/BlazorWebAsssembly1506143488)

> You can refer to our [Blazor PDF Viewer](https://www.syncfusion.com/blazor-components/blazor-pdf-viewer) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor PDF Viewer example](https://blazor.syncfusion.com/demos/pdf-viewer/default-functionalities?theme=bootstrap4) to understand how to explains core features of PDF Viewer.