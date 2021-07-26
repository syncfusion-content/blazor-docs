---
layout: post
title: How to Load Pdf Document Dynamically in Blazor PDF Viewer Component | Syncfusion
description: Checkout and learn about Load Pdf Document Dynamically in Blazor PDF Viewer component of Syncfusion, and more details.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# How to load PDF documents dynamically in Blazor PDF Viewer

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

    public void clicked()
    {
        byte[] byteArray = System.IO.File.ReadAllBytes("wwwroot/Data/Python_Succinctly.pdf");
        string base64String = Convert.ToBase64String(byteArray);
        Viewer.Load("data:application/pdf;base64," + base64String, null);
    }
}
```

The following code example shows how to load the PDF dynamically by specifying file path.

```cshtml
@using Syncfusion.Blazor.PdfViewerServer
@using Syncfusion.Blazor.Buttons

<SfButton @onclick="clicked">Load Document</SfButton>
<SfPdfViewerServer DocumentPath="@DocumentPath" Height="500px" Width="1060px" @ref="Viewer"></SfPdfViewerServer>

@code{
    SfPdfViewerServer Viewer;
    private string DocumentPath { get; set; } = "wwwroot/data/PDF_Succinctly.pdf";

    public void clicked()
    {
        Viewer.Load("wwwroot/data/Python_Succinctly.pdf", null);
    }
}
```
