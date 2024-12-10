---
layout: post
title: Load PDF documents dynamically in Blazor PDF Viewer | Syncfusion
description: Learn here all about how to load PDF documents dynamically in Syncfusion Blazor PDF Viewer component and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Load PDF documents dynamically in Blazor PDF Viewer Component

At times, you might need to switch or load the PDF documents dynamically after the initial load operation. To achieve this, load the PDF document as a base64 string or file path in PDF Viewer control using the `Load()` method dynamically.

The following code example shows how to load a bas64 string dynamically.

```cshtml
@using Syncfusion.Blazor.PdfViewerServer
@using Syncfusion.Blazor.Buttons

<SfButton @onclick="clicked">Load Document</SfButton>
<SfPdfViewerServer DocumentPath="@DocumentPath" Height="500px" Width="1060px" @ref="Viewer"></SfPdfViewerServer>

@code{
    SfPdfViewerServer Viewer;
    private string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";

    public async void clicked()
    {
        byte[] byteArray = System.IO.File.ReadAllBytes("wwwroot/Data/Python_Succinctly.pdf");
        string base64String = Convert.ToBase64String(byteArray);
        Viewer.LoadAsync("data:application/pdf;base64," + base64String, null);
    }
}
```
N> [View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-classic-examples/tree/master/Load%20and%20Save/LoadAsync).

The following code example shows how to load the PDF dynamically by specifying file path.

```cshtml
@using Syncfusion.Blazor.PdfViewerServer
@using Syncfusion.Blazor.Buttons

<SfButton @onclick="clicked">Load Document</SfButton>
<SfPdfViewerServer DocumentPath="@DocumentPath" Height="500px" Width="1060px" @ref="Viewer"></SfPdfViewerServer>

@code{
    SfPdfViewerServer Viewer;
    private string DocumentPath { get; set; } = "wwwroot/data/PDF_Succinctly.pdf";

    public async void clicked()
    {
        Viewer.LoadAsync("wwwroot/data/Python_Succinctly.pdf", null);
    }
}
```

N> You can refer to our [Blazor PDF Viewer](https://www.syncfusion.com/blazor-components/blazor-pdf-viewer) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor PDF Viewer example](https://blazor.syncfusion.com/demos/pdf-viewer/default-functionalities?theme=bootstrap5) to understand how to explains core features of PDF Viewer.