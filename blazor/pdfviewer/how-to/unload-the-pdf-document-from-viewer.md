---
layout: post
title: Unload the PDF document from Viewer in Blazor PDF Viewer | Syncfusion
description: Learn here all about Unload the PDF document from Viewer in Syncfusion Blazor PDF Viewer component and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Unload the PDF document from Viewer in Blazor PDF Viewer Component

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

N> You can refer to our [Blazor PDF Viewer](https://www.syncfusion.com/blazor-components/blazor-pdf-viewer) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor PDF Viewer example](https://blazor.syncfusion.com/demos/pdf-viewer-2/default-functionalities?theme=bootstrap5) to understand how to explains core features of PDF Viewer.