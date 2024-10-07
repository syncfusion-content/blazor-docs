---
layout: post
title: Interaction mode in Blazor PDF Viewer Component | Syncfusion
description: Checkout and learn here all about interaction mode in Syncfusion Blazor PDF Viewer component and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

N> Syncfusion recommends using [Blazor PDF Viewer (NextGen)](https://blazor.syncfusion.com/documentation/pdfviewer-2/getting-started/server-side-application) Component which provides fast rendering of pages and improved performance. Also, there is no need of external Web service for processing the files and ease out the deployment complexity. It can be used in Blazor Server, WASM and MAUI applications without any changes.

# Interaction mode in Blazor PDF Viewer Component

The built-in toolbar of PDF Viewer contains the following two interaction options:

* Selection mode
* Panning mode

## Selection mode

In this mode, the text selection can be performed in the PDF document loaded in the PDF Viewer. It allows users to select and copy text from the PDF files. This is helpful for copying and sharing text content.

N> The panning and scrolling of the pages by touch cannot be performed in this mode.

You can enable or disable text selection by setting the `EnableTextSelection` property.

```cshtml
@using Syncfusion.Blazor.PdfViewerServer

<SfPdfViewerServer Width="1060px" Height="500px" DocumentPath="@DocumentPath" EnableTextSelection="true"/>

@code{
    public string DocumentPath { get; set; } = "wwwroot/data/PDF_Succinctly.pdf";
}
```

## Panning mode

In this mode, the panning and scrolling of the pages can be performed in the PDF document loaded in the PDF Viewer, but the text selection cannot be performed.

You can change the interaction mode of PDF Viewer using the `InteractionMode` property.

```cshtml
@using Syncfusion.Blazor.PdfViewer
@using Syncfusion.Blazor.PdfViewerServer

<SfPdfViewerServer Width="1060px" Height="500px" DocumentPath="@DocumentPath" InteractionMode="InteractionMode.Pan"/>

@code{
    public string DocumentPath { get; set; } = "wwwroot/data/PDF_Succinctly.pdf";
}
```
## Disable interaction with Annotations

You can disable the annotation interactions such as dragging, resizing, deleting the annotations by using the `IsLock` property of `AnnotationSettings`.

The following code illustrates how to disable the annotation interaction.

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.PdfViewer

<SfButton OnClick="@OnClick">Lock Annotation</SfButton>
<SfPdfViewer @ref="PDFViewer" DocumentPath="@DocumentPath" ServiceUrl="https://ej2services.syncfusion.com/production/web-services/api/pdfviewer">
</SfPdfViewer>

@code{
    SfPdfViewer PDFViewer;

    private string DocumentPath { get; set; } = "PDF_Succinctly.pdf";

    public async void OnClick(MouseEventArgs args)
    {
        //Gets the annotation collection of the PDF Viewer.
        var allAnnots = await PDFViewer.GetAnnotationsAsync();

        foreach (var item in allAnnots)
        {
            //Disabling the interaction with annotation.
            item.AnnotationSettings.IsLock = true;
            await PDFViewer.EditAnnotationAsync(item);
        }
    }
}
```

N> [View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-classic-examples/tree/master/Annotations/FAQs/Lock%20annotations).

N> You can refer to the [Blazor PDF Viewer](https://www.syncfusion.com/blazor-components/blazor-pdf-viewer) feature tour page for its groundbreaking feature representations. You can also explore the [Blazor PDF Viewer example](https://blazor.syncfusion.com/demos/pdf-viewer/default-functionalities?theme=bootstrap5) to understand how to explain core features of PDF Viewer.