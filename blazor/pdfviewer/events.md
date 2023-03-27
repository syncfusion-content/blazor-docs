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
|ajaxRequestSuccess|Triggers on successful AJAX request.|
|ajaxRequestInitiate|Triggers before the data is sent to the server.|
|OnPageClick|Triggers when the click or tap is performed over the page of the PDF document.|
|PageChanged|Triggers when there is change in current page number.|
|OnHyperlinkClick|Triggers when the hyperlink (TOC entries and links) in the PDF Document is clicked.|
|OnHyperlinkMouseOver|Triggers when hyperlink in a PDF document is hovered.|
|ZoomChanged|Triggers when there is change in the magnification value.|
|AnnotationAdded|Triggers when an annotation is added over the page of the PDF document.|
|AnnotationRemoved|Triggers when an annotation is removed from the page of the PDF document.|
|AnnotationPropertiesChanged|Triggers when the property of the annotation is changed.|
|AnnotationResized|Triggers when an annotation is resized.|
|AnnotationSelected|Triggers when an annotation is selected.|
|AnnotationUnSelect|Triggers when an annotation is unselected over the page of the PDF document.|
|AnnotationMoved|Triggers when an annotation is moved over the page of the PDF document.|
|annotationMouseover|Triggers when the mouse is moved over the annotation object.|
|annotationMouseLeave|Triggers when the user mouse moves away from the annotation object.|
|Created|Triggers when the PDFViewer component is created.|
|validateFormFields|Triggers when validation is failed.|
|addSignature|Triggers when a signature is added to a page of a PDF document.|
|removeSignature|Triggers when the signature is removed from the page of a PDF document.|
|moveSignature|Triggers when a signature is moved across the page of a PDF documen.t|
|signaturePropertiesChange|Triggers when the property of the signature is changed in the page of the PDF document.|
|resizeSignature|Triggers when the signature is resized and placed on a page of a PDF document.|
|signatureSelect|Triggers when signature is selected over the page of the PDF document.|
|pageMouseover|Triggers when moving the mouse over the page.|
|ImportStarted|Triggers when an imported annotation started to appear in the PDF document.|
|ExportStarted|Triggers when an exported annotation started in the PDF Viewer.|
|ImportSucceed|Triggers when the annotations in a PDF document are successfully imported.|
|ImportFailed|Triggers when the annotations imports in a PDF document fails.|
|ExportFailed|Triggers when the annotations export in a PDF document fails.|
|ExtractTextCompleted|Triggers when an text extraction is completed in the PDF Viewer.|
|OnThumbnailClick|Triggers when the thumbnail in the PDF Viewer's thumbnail panel is clicked.|
|BookmarkClick|Triggers when the bookmark is clicked in the PDF Viewer's bookmark panel.|
|OnTextSelectionStart|Triggers when the text selection is initiated.|
|OnTextSelectionEnd|Triggers when the text selection is complete.|
|DownloadStart|Triggers when the download action is initiated.|
|ButtonFieldClick|Triggers when the button is clicked.|
|FormFieldClick|Triggers when the form field is selected.|
|DownloadEnd|Triggers when the download actions are completed.|
|PrintStart|Triggers when the print action is initiated.|
|PrintEnd|Triggers when the print actions are completed.|
|OnTextSearchStart|Triggers when the text search is initiated.|
|OnTextSearchComplete|Triggers when the text search is completed.|
|OnTextSearchHighlight|Triggers when the text search text is highlighted.|
|commentAdd|Triggers when a comment for the annotation is added to the comment panel.|
|commentEdit|Triggers when the comment for the annotation in the comment panel is edited.|
|commentDelete|Triggers when the comment for the annotation in the comment panel is deleted.|
|commentSelect|Triggers when the comment for the annotation in the comment panel is selected.|
|commentStatusChanged|Triggers when the annotation's comment for status is changed in the comment panel.|
|beforeAddFreeText|Triggers before adding a text in the freeText annotation.|
|formFieldFocusOut|Triggers when focus out from the form fields.|
|formFieldAdd|Triggers when a form field is added.|
|formFieldRemove|Triggers when a form field is removed.|
|formFieldPropertiesChange|Triggers when a property of form field is changed.|
|formFieldMouseLeave|Triggers when the mouse cursor leaves the form field.|
|formFieldMouseover|Triggers when the mouse cursor is over a form field.|
|formFieldMove|Triggers when a form field is moved.|
|formFieldResize|Triggers when a form field is resized.|
|formFieldSelect|Triggers when a form field is selected.|
|formFieldUnselect|Triggers when a form field is unselected.|
|formFieldDoubleClick|Triggers when the form field is double-clicked.|

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