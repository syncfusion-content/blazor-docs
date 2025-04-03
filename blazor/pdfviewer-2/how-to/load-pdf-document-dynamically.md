---
layout: post
title: Load PDF File dynamically in Blazor SfPdfViewer component| Syncfusion
description: Learn here all about how to load PDF documents dynamically in Syncfusion Blazor SfPdfViewer component and more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Load PDF documents dynamically in Blazor SfPdfViewer Component

At times, you might need to switch or load the PDF documents dynamically after the initial load operation. To achieve this, load the PDF document as a base64 string or file path in SfPdfViewer control using the [LoadAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_LoadAsync_System_Byte___System_String_) method dynamically.

The following code example shows how to load a bas64 string dynamically.

```cshtml
@using Syncfusion.Blazor.SfPdfViewer
@using Syncfusion.Blazor.Buttons

<SfButton @onclick="clicked">Load Document</SfButton>
<SfPdfViewer2 DocumentPath="@DocumentPath"
              Height="100%"
              Width="100%"
              @ref="Viewer">
</SfPdfViewer2>

@code{
    SfPdfViewer2 Viewer;
    private string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";

    public async void clicked()
    {
        byte[] byteArray = System.IO.File.ReadAllBytes("wwwroot/Data/Python_Succinctly.pdf");
        string base64String = Convert.ToBase64String(byteArray);
        await Viewer.LoadAsync("data:application/pdf;base64," + base64String, null);
    }
}
```
[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Load%20and%20Save/LoadAsync).

The following code example shows how to load the PDF dynamically by specifying file path.

```cshtml
@using Syncfusion.Blazor.SfPdfViewer
@using Syncfusion.Blazor.Buttons

<SfButton @onclick="clicked">Load Document</SfButton>
<SfPdfViewer2 DocumentPath="@DocumentPath"
              Height="100%"
              Width="100%"
              @ref="Viewer">
</SfPdfViewer2>

@code{
    SfPdfViewer2 Viewer;
    private string DocumentPath { get; set; } = "wwwroot/data/PDF_Succinctly.pdf";

    public async void clicked()
    {
        await Viewer.LoadAsync("wwwroot/data/Python_Succinctly.pdf", null);
    }
}
```

N> You can refer to our [Blazor SfPdfViewer](https://www.syncfusion.com/blazor-components/blazor-pdf-viewer) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor SfPdfViewer example](https://blazor.syncfusion.com/demos/pdf-viewer-2/default-functionalities?theme=bootstrap4) to understand how to explains core features of SfPdfViewer.

## See also

* [How to load Microsoft Office files in Blazor SfPdfViewer Component](./load-office-files)

* [How to unload the PDF document from Viewer](./unload-the-pdf-document-from-viewer)

* [How to show or hide the Component dynamically](../how-to/show-or-hide-sfpdfviewer-dynamically)