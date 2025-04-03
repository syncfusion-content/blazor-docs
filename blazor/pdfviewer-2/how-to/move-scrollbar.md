---
layout: post
title: Move the scrollbar to the exact location of annotations | Syncfusion
description: Learn here all about move scrollbar to the exact location of annotations in Syncfusion Blazor SfPdfViewer component and more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Move the scrollbar to the exact location of annotations

The Syncfusion&reg; Blazor SfPdfViewer component allows you to move the scrollbar to the exact location of annotations present in a loaded PDF document using the [GoToBookmarkAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_GoToBookmarkAsync_System_Int32_System_Double_) method.

The following code example shows how to move the scrollbar to annotation location.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer

<button @onclick="navigate">Navigation</button>

<SfPdfViewer2 @ref="PdfViewer" DocumentPath="@DocumentPath">
    <PdfViewerEvents DocumentLoaded="DocumentLoad"></PdfViewerEvents>
</SfPdfViewer2>

@code {
    SfPdfViewer2 PdfViewer;
    public string DocumentPath { get; set; } = "wwwroot/data/PDF Succinctly.pdf";
    public Dictionary<int, System.Drawing.SizeF> pageSize { get; set; }

    private void DocumentLoad(LoadEventArgs args)
    {
        pageSize = args.PageData.PageSizes;
    }

    private async void navigate()
    {
        var annotationCollection = await PdfViewer.GetAnnotationsAsync();
        var pageNumber = (annotationCollection[0].PageNumber);
        var Y = annotationCollection[0].Bound.Top;
        await PdfViewer.GoToBookmarkAsync(pageNumber, (pageSize[pageNumber].Height - Y));
    }

}

```

[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Common/Move%20scrollbar%20programmatically).