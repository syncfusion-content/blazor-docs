---
layout: post
title: Events in Blazor PDF Viewer Component | Syncfusion
description: Checkout and learn here all about events in Syncfusion Blazor PDF Viewer component and much more details.
platform: Blazor
control: PDF Viewer
documentation: ug
---

N> Syncfusion recommends using [Blazor PDF Viewer (NextGen)](https://blazor.syncfusion.com/documentation/pdfviewer-2/getting-started/server-side-application) Component which provides fast rendering of pages and improved performance. Also, there is no need of external Web service for processing the files and ease out the deployment complexity. It can be used in Blazor Server, WASM and MAUI applications without any changes.

# Events in Blazor PDF Viewer Component

The events provided in PDF Viewer component are listed out as follows:

|Name|Description|
|---|---|
|AddSignature|Triggers when signature is added over the page of the PDF document.|
|AjaxRequestFailed|Triggers when the AJAX request is failed.|
|AnnotationAdded|Triggers when an annotation is added over the page of the PDF document.|
|AnnotationMouseover|Triggers when mouse over the annotation object.|
|AnnotationMoved|Triggers when an annotation is moved over the page of the PDF document.|
|AnnotationPropertiesChanged|Triggers when the property of the annotation is changed in the page of the PDF document.|
|AnnotationRemoved|Triggers when an annotation is removed from the page of the PDF document.|
|AnnotationResized|Triggers when an annotation is resized over the page of the PDF document.|
|AnnotationSelected|Triggers when an annotation is selected over the page of the PDF document.|
|AnnotationUnselected|Triggers when an annotation is unselected over the page of the PDF document.|
|Created|Triggers when the PDFViewer component is created.|
|DocumentLoaded|Triggers while loading document into PdfViewer.|
|DocumentLoadFailed|Triggers while loading document got failed in PdfViewer.|
|DcoumentUnloaded|Triggers while close the document|
|DownloadEnd|Triggers an event when the download actions is finished.|
|DownloadStart|Triggers an event when the download action is started.|
|ExportFailed|Triggers when an export annotations failed in the PDF Viewer.|
|ExportStarted|Triggers when an exported annotations started in the PDF Viewer.|
|ExportSucceed|Triggers when an export annotations succeed in the PDF Viewer.|
|ExtractTextCompleted|Triggers when an text extraction is completed in the PDF Viewer.|
|ImportFailed|Triggers when an imports annotations failed in the PDF document.
|ImportStarted|Triggers when an imported annotations started in the PDF document.|
|ImportSucceed|Triggers when an imports annotations succeed in the PDF document.|
|MoveSignature|Triggers when an signature is moved over the page of the PDF document.|
|OnAnnotationDoubleClick|Triggers an event when the annotation is double click.|
|OnHyperlinkClick|Triggers when hyperlink in the PDF Document is clicked|
|OnHyperlinkMouseOver|Triggers when hyperlink in the PDF Document is hovered|
|OnPageClick|Triggers when the mouse click is performed over the page of the PDF document.|
|OnTextSearchComplete|Triggers an event when the text search is completed.|
|OnTextSearchHighlight|Triggers an event when the text search text is highlighted.|
|OnTextSearchStart|Triggers an event when the text search is started.|
|OnTextSelectionEnd|Triggers an event when the text selection is finished.|
|OnTextSelectionStart|Triggers an event when the text selection is started.|
|OnThumbnailClick|Triggers an event when the thumbnail is clicked in the thumbnail panel of PDF Viewer.|
|PageChanged|Triggers when there is change in current page number.|
|PageMouseover|Triggers when mouse over the page.|
|PrintEnd|Triggers an event when the print actions is finished.|
|PrintStart|Triggers an event when the print action is started.|
|RemoveSignature|Triggers when signature is removed over the page of the PDF document.|
|ResizeSignature|Triggers when signature is resized over the page of the PDF document.|
|SignaturePropertiesChange|Triggers when the property of the signature is changed in the page of the PDF document.|
|SignatureSelected|Triggers when signature is selected over the page of the PDF document.|
|SignatureUnselected|Triggers when signature is unselected over the page of the PDF document.|
|ZoomChanged|Triggers when there is change in the magnification value.|

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

N> You can refer to the [Blazor PDF Viewer](https://www.syncfusion.com/blazor-components/blazor-pdf-viewer) feature tour page for its groundbreaking feature representations. You can also explore the [Blazor PDF Viewer example](https://blazor.syncfusion.com/demos/pdf-viewer/default-functionalities?theme=bootstrap5) to understand how to explain core features of PDF Viewer.