---
layout: post
title: Check the document editing status in PDF Viewer | Syncfusion
description: Learn here all about how to check the editing status of the document in Syncfusion Blazor PDF Viewer component.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Check the document's editing status in Blazor PDF Viewer Component

You can check whether the loaded PDF document is edited or not by using the [IsDocumentEdited](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PdfViewer.PdfViewerBase.html#Syncfusion_Blazor_PdfViewer_PdfViewerBase_IsDocumentEdited) property of the PDFViewer.

The following code represents how to check the editing status of the document.

```cshtml
@using Syncfusion.Blazor.PdfViewer
@using Syncfusion.Blazor.Buttons

<SfButton @onclick="OnClick">Check</SfButton>
<SfPdfViewer @ref="Viewer" 
             DocumentPath="@DocumentPath" 
             Height="640px" 
             Width="100%" 
             ServiceUrl="https://ej2services.syncfusion.com/production/web-services/api/pdfviewer">
</SfPdfViewer>

@code{
    public SfPdfViewer Viewer { get; set; }

    private string DocumentPath { get; set; } = "PDF_Succinctly.pdf";

    //Prints the document's edited status in console window.
    public void OnClick(MouseEventArgs args)
    {
        Console.WriteLine(Viewer.IsDocumentEdited);
    }
}
```

N> [View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-classic-examples/tree/master/Common/Document%20editing%20status).