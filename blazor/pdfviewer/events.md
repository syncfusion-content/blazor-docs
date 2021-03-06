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

> You can refer to the [Blazor PDF Viewer](https://www.syncfusion.com/blazor-components/blazor-pdf-viewer) feature tour page for its groundbreaking feature representations. You can also explore the [Blazor PDF Viewer example](https://blazor.syncfusion.com/demos/pdf-viewer/default-functionalities?theme=bootstrap4) to understand how to explain core features of PDF Viewer.