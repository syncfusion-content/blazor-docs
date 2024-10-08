---
layout: post
title: Customize the arrow annotation heads in Blazor PDF Viewer | Syncfusion
description: Learn here all about how to increase the connection buffer size in Syncfusion Blazor PDF Viewer component and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Customize the arrow annotation heads in Blazor PDF Viewer Component

You can customize the arrow annotation using the ArrowSettings API.

The following code illustrates how to remove the starting arrow and end arrow from arrow annotation.

```cshtml
@using Syncfusion.Blazor.PdfViewer
@using Syncfusion.Blazor.PdfViewerServer

<SfPdfViewerServer @ref="Viewer" DocumentPath="@DocumentPath" ArrowSettings="@ArrowSettings" Height="640px" Width="100%">
 <PdfViewerEvents DocumentLoaded="DocumentLoad"></PdfViewerEvents>
</SfPdfViewerServer>

@code
{
    public SfPdfViewerServer Viewer { get; set; }

    private string DocumentPath { get; set; } = "wwwroot/data/PDF Succinctly.pdf";

    PdfViewerArrowSettings ArrowSettings = new PdfViewerArrowSettings 
    { 
        //To remove the starting arrow.
        LineHeadStartStyle=LineHeadStyle.None,
        //To remove the end arrow.
        LineHeadEndStyle=LineHeadStyle.None
    };

    //Invokes while loading document in the PDFViewer. 
    public void DocumentLoad(LoadEventArgs args)
    {
        //Shows the AnnotationToolbar on initial loading.
        Viewer.ShowAnnotationToolbar(true);        
    }
}
```

N> [View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-classic-examples/tree/master/Annotations/Shapes/Remove%20arrow%20annotation%20heads).
