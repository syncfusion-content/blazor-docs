---
layout: post
title: Interaction mode in Blazor SfPdfViewer Component | Syncfusion
description: Checkout and learn here all about interaction mode in Syncfusion Blazor SfPdfViewer component and more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Interaction mode in Blazor SfPdfViewer Component

The built-in toolbar of SfPdfViewer contains the following two interaction options:

* Selection mode
* Panning mode

## Selection mode

In this mode, the text selection can be performed in the PDF document loaded in the SfPdfViewer. It allows users to select and copy text from the PDF files. This is helpful for copying and sharing text content.

N> The panning and scrolling of the pages by touch cannot be performed in this mode.

You can enable or disable text selection by setting the [EnableTextSelection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_EnableTextSelection) property.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer

<SfPdfViewer2 DocumentPath="@DocumentPath"
              Height="100%"
              Width="100%"
              EnableTextSelection="true">
</SfPdfViewer2>

@code{
    public string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
}
```

## Panning mode

In this mode, the panning and scrolling of the pages can be performed in the PDF document loaded in the SfPdfViewer, but the text selection cannot be performed.

You can change the interaction mode of SfPdfViewer using the [InteractionMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_InteractionMode) property.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer

<SfPdfViewer2 DocumentPath="@DocumentPath"
              Height="100%"
              Width="100%"
              InteractionMode="InteractionMode.Pan">
</SfPdfViewer2>
@code{
    public string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
}

```
## Disable interaction with Annotations

You can disable the annotation interactions such as dragging, resizing, deleting the annotations by using the `IsLock` property of [AnnotationSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_AnnotationSettings).

The following code illustrates how to disable the annotation interaction.

```cshtml

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.SfPdfViewer

<SfButton OnClick="@OnClick">Lock Annotation</SfButton>
<SfPdfViewer2 @ref="viewer"
              DocumentPath="@DocumentPath">
</SfPdfViewer2>

@code {
    SfPdfViewer2 viewer;
    private string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";

    public async void OnClick(MouseEventArgs args)
    {
        //Gets the annotation collection of the SfPdfViewer.
        var allAnnots = await viewer.GetAnnotationsAsync();

        foreach (var item in allAnnots)
        {
            //Disabling the interaction with annotation.
            item.AnnotationSettings.IsLock = true;
            await viewer.EditAnnotationAsync(item);
        }
    }
}

```

[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Annotations/FAQs/Lock_annotations)

## See also

* [Navigation in Blazor SfPdfViewer Component](./navigation)