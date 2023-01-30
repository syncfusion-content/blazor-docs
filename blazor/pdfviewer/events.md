---
layout: post
title: Events in Blazor PDF Viewer Component | Syncfusion
description: Checkout and learn here all about events in Syncfusion Blazor PDF Viewer component and much more details.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Events in Blazor PDF Viewer Component

The events provided in PDF Viewer component are listed out as follows:

|Name|Description|
|---|---|
|DocumentLoaded|Triggers when the document is opened or loaded into the PDF Viewer.|
|DcoumentUnloaded|Triggers when the document gets closed.|
|DocumentLoadFailed|Triggers when the document loading gets failed.|
|AjaxRequestFailed|Triggers when the request gets failed in case of server-side component. Triggers when the communication between service and viewer gets failed in case of client-side component.|
|OnPageClick|Triggers when the click or tap is performed over the page of the PDF document.|
|PageChanged|Triggers when there is change in current page number.|
|OnHyperlinkClick|Triggers when the hyperlink (TOC entries and links) in the PDF Document is clicked.|
|ZoomChanged|Triggers when there is change in the magnification value.|
|AnnotationAdded|Triggers when an annotation is added over the page of the PDF document.|
|AnnotationRemoved|Triggers when an annotation is removed from the page of the PDF document.|
|AnnotationPropertiesChanged|Triggers when the property of the annotation is changed.|
|AnnotationResized|Triggers when an annotation is resized.|
|AnnotationSelected|Triggers when an annotation is selected.|
|Created|Triggers when the PDFViewer component is created.|

## Adding PDF Viewer events to Blazor component

The Syncfusion PDF Viewer events has to be wrapped inside the `PdfViewerEvents` tag.

```cshtml
<SfPdfViewerServer DocumentPath="@DocumentPath" Height="500px" Width="1060px" >
    <PdfViewerEvents DocumentLoaded="@DocumentLoaded"></PdfViewerEvents>
</SfPdfViewerServer>

@code{
    private string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
    private void DocumentLoaded(LoadEventArgs args)
    {
        object PageData = args.PageData;
    }
}
```

## Created event

The Created event is triggered when the PDFViewer component is rendered.

The following code illustrates how to load PDF document on created event.

```cshtml
@using Syncfusion.Blazor.PdfViewerServer
@using Syncfusion.Blazor.PdfViewer

<SfPdfViewerServer DocumentPath="@DocumentPath" Width="560" Height="315">
    <PdfViewerEvents Created="created"></PdfViewerEvents>
</SfPdfViewerServer>

@code 
{
    public string DocumentPath { get; set; }

    //Triggers when the PDFViewer component is created.
    public void created()
    {
        string Link = "http://infolab.stanford.edu/pub/papers/google.pdf";
        System.Net.WebClient webClient = new System.Net.WebClient();
        //Returns the byte array containing the downloaded PDF file.
        byte[] byteArray = webClient.DownloadData(Link);
        //Converting the byte array to Base64 string and sets the document path.
        DocumentPath = "data:application/pdf;base64," + Convert.ToBase64String(byteArray);
    }  
}
```
N> [View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Load%20and%20Save/Load%20a%20PDF%20document%20using%20created%20event).

N> You can refer to the [Blazor PDF Viewer](https://www.syncfusion.com/blazor-components/blazor-pdf-viewer) feature tour page for its groundbreaking feature representations. You can also explore the [Blazor PDF Viewer example](https://blazor.syncfusion.com/demos/pdf-viewer/default-functionalities?theme=bootstrap4) to understand how to explain core features of PDF Viewer.