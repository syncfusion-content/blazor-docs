---
layout: post
title: Move the scrollbar to the exact location of annotations | Syncfusion
description: Learn here all about move scrollbar to the exact location of annotations in Syncfusion Blazor PDF Viewer component and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Move the scrollbar to the exact location of annotations

The Syncfusion's Blazor PDF Viewer component allows you to move the scrollbar to the exact location of annotations present in a loaded PDF document using the **GoToBookmark** method.

The following code example shows how to move the scrollbar to annotation location.

```csharp

<button @onclick="navigate">Navigation</button>

<SfPdfViewerServer @ref="PdfViewer" DocumentPath="@DocumentPath">
    <PdfViewerEvents DocumentLoaded="DocumentLoad"></PdfViewerEvents>
</SfPdfViewerServer>

@code{
    SfPdfViewerServer PdfViewer;
    public string DocumentPath { get; set; } = "wwwroot/data/PDF Succinctly.pdf";
    public Dictionary<int, System.Drawing.SizeF> pageSize { get; set; }

    private void DocumentLoad(LoadEventArgs args)
    {
        pageSize = args.PageData.PageSizes;
    }

    private async void navigate()
    {
        var annotationCollection = await PdfViewer.GetAnnotations();
        var pageNumber = (annotationCollection[0].PageNumber);
        var Y = annotationCollection[0].Bound.Top;
        await PdfViewer.GoToBookmark(pageNumber, (pageSize[pageNumber].Height - Y));
    }

}

```

Find the sample [How to move the scrollbar to exact location of annotations](https://www.syncfusion.com/downloads/support/directtrac/general/ze/TestApp-1621872311)