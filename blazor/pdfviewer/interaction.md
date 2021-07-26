---
layout: post
title: Interaction in Blazor PDF Viewer Component | Syncfusion 
description: Learn about Interaction in Blazor PDF Viewer component of Syncfusion, and more details.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Interaction mode

The built-in toolbar of PDF Viewer contains the following two interaction options:

* Selection mode
* Panning mode

## Selection mode

In this mode, the text selection can be performed in the PDF document loaded in the PDF Viewer. It allows users to select and copy text from the PDF files. This is helpful for copying and sharing text content.

>Note: The panning and scrolling of the pages by touch cannot be performed in this mode.

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