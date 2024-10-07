---
layout: post
title: Events in Blazor SfPdfViewer Component | Syncfusion
description: Checkout and learn here all about events in Syncfusion Blazor SfPdfViewer component and much more details.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Events in Blazor SfPdfViewer Component

The events provided in SfPdfViewer component are listed out as follows:

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
|DocumentEdited|Triggers when the PDF Document getting edited in SfPdfViewer.|
|DocumentLoaded|Triggers while loading document into PdfViewer.|
|DocumentLoadFailed|Triggers while loading document got failed in PdfViewer.|
|DcoumentUnloaded|Triggers while close the document|
|DownloadEnd|Triggers an event when the download actions is finished.|
|DownloadStart|Triggers an event when the download action is started.|
|ExportFailed|Triggers when an export annotations failed in the SfPdfViewer.|
|ExportStarted|Triggers when an exported annotations started in the SfPdfViewer.|
|ExportSucceed|Triggers when an export annotations succeed in the SfPdfViewer.|
|ExtractTextCompleted|Triggers when an text extraction is completed in the SfPdfViewer.|
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
|OnThumbnailClick|Triggers an event when the thumbnail is clicked in the thumbnail panel of SfPdfViewer.|
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

## Adding SfPdfViewer events to Blazor component

The Syncfusion SfPdfViewer events has to be wrapped inside the [PdfViewerEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerEvents.html) tag.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer

<SfPdfViewer2 DocumentPath="@DocumentPath" Height="100%" Width="100%">
    <PdfViewerEvents DocumentLoaded="DocumentLoaded"></PdfViewerEvents>
</SfPdfViewer2>

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

@using Syncfusion.Blazor.SfPdfViewer

<SfPdfViewer2  DocumentPath="@DocumentPath" Height="100%" Width="100%">
    <PdfViewerEvents Created="created"></PdfViewerEvents>
</SfPdfViewer2>

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

## DocumentEdited Event

The DocumentEdited Event is Triggered when the PDF document getting Edited. 

The following code illustrates how to trigger the DocumentEdited Event. In that code , [EditingAction](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.EditingAction.html) provides the information related to document edited. 

```cshtml

@using Syncfusion.Blazor.SfPdfViewer 

<SfPdfViewer2 DocumentPath="@DocumentPath" Height="100%" Width="100%"> 
    <PdfViewerEvents DocumentEdited="@DocumentEdited"></PdfViewerEvents>
</SfPdfViewer2>

@code{ 
    private string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succintly.pdf"; 
    public async Task DocumentEdited(DocumentEditedEventArgs args) 
    {
        Console.WriteLine(args.EditingAction);
    }	 
}

```

[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Load%20and%20Save/Load%20a%20PDF%20document%20using%20created%20event)