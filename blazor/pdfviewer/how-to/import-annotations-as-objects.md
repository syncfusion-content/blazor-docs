---
layout: post
title: Import annotations as objects in Blazor PDF Viewer | Syncfusion
description: Learn here all about Import annotations as objects in Syncfusion Blazor PDF Viewer component and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Import annotations as objects in Blazor PDF Viewer Component

The Syncfusion's Blazor PDF Viewer component allows to import annotations from objects or streams instead of loading it as a file. To import such annotation objects, the PDF Viewer control must export the PDF annotations as objects using the [ExportAnnotationsAsObject()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PdfViewer.PdfViewerBase.html#Syncfusion_Blazor_PdfViewer_PdfViewerBase_ExportAnnotationsAsObject) method. Only the annotations objects that are exported from the PDF Viewer can be imported.

The following code example shows how to import annotations as objects, that are exported using the [ExportAnnotationsAsObject()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PdfViewer.PdfViewerBase.html#Syncfusion_Blazor_PdfViewer_PdfViewerBase_ExportAnnotationsAsObject) method.

```cshtml
@page "/"
@using Syncfusion.Blazor.PdfViewerServer
@using Syncfusion.Blazor.PdfViewer

<button @onclick="ExportAnnot">ExportAnnot</button>
<button @onclick="ImportAnnot">ImportAnnot</button>

<SfPdfViewerServer @ref="PdfViewer" DocumentPath="@DocumentPath" Height="500px" Width="1060px">
</SfPdfViewerServer>

@code {
    public SfPdfViewerServer PdfViewer { get; set; }
    private string DocumentPath { get; set; } = "PDF_Succinctly.pdf";
    public object annotation;

    //Export the annotations as an object
    public async void ExportAnnot()
    {
        await PdfViewer.ExportAnnotation();
        annotation = await PdfViewer.ExportAnnotationsAsObject();
    }

    //Import the annotations that are exported as objects
    public async void ImportAnnot()
    {
        await PdfViewer.ImportAnnotation(annotation);
    }
}
```

N> [View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-classic-examples/tree/master/Annotations/Import-Export/Annotations%20as%20JSON%20object).

N> You can refer to our [Blazor PDF Viewer](https://www.syncfusion.com/blazor-components/blazor-pdf-viewer) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor PDF Viewer example](https://blazor.syncfusion.com/demos/pdf-viewer/default-functionalities?theme=bootstrap4) to understand how to explains core features of PDF Viewer.