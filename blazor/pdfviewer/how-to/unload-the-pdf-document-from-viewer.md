---
layout: post
title: How to Unload The Pdf Document From Viewer in Blazor PDF Viewer Component | Syncfusion
description: Checkout and learn about Unload The Pdf Document From Viewer in Blazor PDF Viewer component of Syncfusion, and more details.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# How to unload PDF document from Blazor PDF Viewer programmatically

The PDF Viewer component will automatically unload and clear the resources occupied by the PDF document when the control is disposed. Also, when loading another PDF file, the resources occupied by previous loaded file in viewer will be automatically unloaded and cleared.

If you want to unload and clear the resources occupied by the PDF file programmatically, invoke the Unload() method as shown below.

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.PdfViewerServer

<SfButton @onclick="OnClick">Unload Document</SfButton>
<SfPdfViewerServer @ref="@viewer" Height="500px" Width="1060px" DocumentPath="@DocumentPath" />

@code{
        SfPdfViewerServer viewer;
        public void OnClick(MouseEventArgs args)
        {
            viewer.Unload();
        }
    public string DocumentPath { get; set; } = "wwwroot/data/PDF_Succinctly.pdf";
}

```