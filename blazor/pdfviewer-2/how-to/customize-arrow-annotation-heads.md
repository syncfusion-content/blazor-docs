---
layout: post
title: Customize the arrow annotation heads in SfPdfviewer | Syncfusion
description: Learn here all about how to increase the connection buffer size in Syncfusion Blazor SfPdfviewer component and more.
platform: Blazor
control: SfPdfviewer
documentation: ug
---

# Customize the arrow annotation heads in Blazor SfPdfViewer Component

You can customize the arrow annotation using the ArrowSettings API.

The following code illustrates how to remove the starting arrow and end arrow from arrow annotation.

```cshtml
@using Syncfusion.Blazor.SfPdfviewer

<SfPdfViewer2 @ref="Viewer"
              DocumentPath="@DocumentPath"
              ArrowSettings="@ArrowSettings"
              Height="100%"
              Width="100%">
    <PdfViewerEvents DocumentLoaded="DocumentLoad"></PdfViewerEvents>
</SfPdfViewer2>

@code
{
    public SfPdfViewer2 Viewer { get; set; }

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

[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Annotations/Shapes/Remove%20arrow%20annotation%20heads).

## See also

* [Shape annotations in Blazor SfPdfViewer Component](../annotation/shape-annotation)

* [Measurement annotations in Blazor SfPdfViewer Component](../annotation/measurement-annotation)