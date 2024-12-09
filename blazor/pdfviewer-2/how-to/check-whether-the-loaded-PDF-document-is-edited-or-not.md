---
layout: post
title: Check the document's editing status in Blazor SfPdfViewer | Syncfusion
description: Learn here all about how to check the editing status of the document in Syncfusion Blazor SfPdfViewer component.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Check the document's editing status in Blazor SfPdfViewer Component

You can check whether the loaded PDF document is edited or not by using the [IsDocumentEdited](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_IsDocumentEdited) property of the SfPdfViewer.

The following code represents how to check the editing status of the document.

```cshtml
@using Syncfusion.Blazor.SfPdfViewer
@using Syncfusion.Blazor.Buttons

<SfButton @onclick="OnClick">Check</SfButton>
<SfPdfViewer2 @ref="Viewer"
              DocumentPath="@DocumentPath"
              Height="100%"
              Width="100%">
</SfPdfViewer2>

@code{
    public SfPdfViewer Viewer { get; set; }
    private string DocumentPath { get; set; } = "Data/PDF_Succinctly.pdf";

    //Prints the document's edited status in console window.
    public void OnClick(MouseEventArgs args)
    {
        Console.WriteLine(Viewer.IsDocumentEdited);
    }
}
```

[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Common/Document%20editing%20status).