---
layout: post
title: Unload the PDF document from Viewer in Blazor SfPdfViewer | Syncfusion
description: Learn here all about Unload the PDF document from Viewer in Syncfusion Blazor SfPdfViewer component and more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Unload the PDF document from Viewer in Blazor SfPdfViewer Component

The SfPdfViewer component will automatically unload and clear the resources occupied by the PDF document when the control is disposed. Also, when loading another PDF file, the resources occupied by previous loaded file in viewer will be automatically unloaded and cleared.

If you want to unload and clear the resources occupied by the PDF file programmatically, invoke the [Unload()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_UnloadAsync) method as shown below.

```cshtml

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.SfPdfViewer

<SfButton @onclick="OnClick">Unload Document</SfButton>

<SfPdfViewer2 @ref="@Viewer"
              Height="100%"
              Width="100%"
              DocumentPath="@DocumentPath" />

@code {
    SfPdfViewer2 Viewer;

    public async void OnClick(MouseEventArgs args)
    {
        await Viewer.UnloadAsync();
    }

    public string DocumentPath { get; set; } = "wwwroot/data/PDF_Succinctly.pdf";
}

```

[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Common/Unload%20Pdf%20document%20from%20Viewer)

## See also

* [How to show or hide the Component dynamically](../how-to/show-or-hide-sfpdfviewer-dynamically)

* [How to load PDF documents dynamically](../how-to/load-pdf-document-dynamically)