---
layout: post
title: Import annotations as objects in Blazor SfPdfViewer Component | Syncfusion
description: Learn here all about Import annotations as objects in Syncfusion Blazor SfPdfViewer component and more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Import annotations as objects in Blazor SfPdfViewer Component

The Syncfusion's Blazor SfPdfViewer component allows to import annotations from objects or streams instead of loading it as a file. To import such annotation objects, the SfPdfViewer control must export the PDF annotations as objects using the [ExportAnnotationsAsObjectAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_ExportAnnotationsAsObjectAsync) method. Only the annotations objects that are exported from the SfPdfViewer can be imported.

The following code example shows how to import annotations as objects, that are exported using the [ExportAnnotationsAsObjectAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_ExportAnnotationsAsObjectAsync) method.

```cshtml
@page "/"
@using Syncfusion.Blazor.SfPdfViewer

<button @onclick="ExportAnnot">ExportAnnot</button>
<button @onclick="ImportAnnot">ImportAnnot</button>

<SfPdfViewer2 @ref="PdfViewer"
              DocumentPath="@DocumentPath"
              Height="100%"
              Width="100%">
</SfPdfViewer2>

@code {
    public SfPdfViewer2 PdfViewer { get; set; }
    private string DocumentPath { get; set; } = "PDF_Succinctly.pdf";
    public object annotation;

    //Export the annotations as an object
    public async void ExportAnnot()
    {
        await PdfViewer.ExportAnnotation();
        annotation = await PdfViewer.ExportAnnotationsAsObjectAsync();
    }

    //Import the annotations that are exported as objects
    public async void ImportAnnot()
    {
        await PdfViewer.ImportAnnotation(annotation);
    }
}
```

[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Annotations/Import-Export/Annotations%20as%20JSON%20object).

N> You can refer to our [Blazor SfPdfViewer](https://www.syncfusion.com/blazor-components/blazor-pdf-viewer) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor SfPdfViewer example](https://blazor.syncfusion.com/demos/pdf-viewer-2/default-functionalities?theme=bootstrap4) to understand how to explains core features of SfPdfViewer.

## See also

* [Import and Export annotations in Blazor SfPdfViewer Component](../annotation/import-export-annotation)