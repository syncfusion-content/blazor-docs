---
layout: post
title: Interaction mode in Blazor PDF Viewer Component | Syncfusion
description: Checkout and learn here all about Interaction mode in Syncfusion Blazor PDF Viewer component and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Interaction mode in Blazor PDF Viewer Component

The built-in toolbar of PDF Viewer contains the following two interaction options:

* Selection mode
* Panning mode

## Selection mode

In this mode, the text selection can be performed in the PDF document loaded in the PDF Viewer. It allows users to select and copy text from the PDF files. This is helpful for copying and sharing text content.

> The panning and scrolling of the pages by touch cannot be performed in this mode.

You can enable or disable text selection by setting the `EnableTextSelection` property.

```cshtml
@using Syncfusion.Blazor.PdfViewerServer

<SfPdfViewerServer Width="1060px" Height="500px" DocumentPath="@DocumentPath" EnableTextSelection="true"/>

@code{
    public string DocumentPath { get; set; } = "wwwroot/data/PDF_Succinctly.pdf";
}
```

## Panning mode

In this mode, the panning and scrolling of the pages can be performed in the PDF document loaded in the PDF Viewer, but the text selection cannot be performed.

You can change the interaction mode of PDF Viewer using the `InteractionMode` property.

```cshtml
@using Syncfusion.Blazor.PdfViewer
@using Syncfusion.Blazor.PdfViewerServer

<SfPdfViewerServer Width="1060px" Height="500px" DocumentPath="@DocumentPath" InteractionMode="InteractionMode.Pan"/>

@code{
    public string DocumentPath { get; set; } = "wwwroot/data/PDF_Succinctly.pdf";
}
```

> You can refer to our [Blazor PDF Viewer](https://www.syncfusion.com/blazor-components/blazor-pdf-viewer) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor PDF Viewer example](https://blazor.syncfusion.com/demos/pdf-viewer/default-functionalities?theme=bootstrap4) to understand how to explains core features of PDF Viewer.