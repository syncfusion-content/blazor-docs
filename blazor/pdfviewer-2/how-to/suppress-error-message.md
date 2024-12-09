---
layout: post
title: Suppress the error dialog in the Blazor SfPdfViewer | Syncfusion
description: Learn here all about how to suppress the error dialog in Syncfusion Blazor SfPdfViewer component and more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Suppress the error dialog in Blazor SfPdfViewer Component

The Syncfusion's Blazor SfPdfViewer component allows you to suppress or disable the error dialog box displayed in the SfPdfViewer using the [**EnableErrorDialog**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_EnableErrorDialog) property. The default value of the property is `true`.

The following code example shows how to suppress the error dialog.

```cshtml
@using Syncfusion.Blazor.SfPdfViewer

<SfPdfViewer2 @ref="PdfViewer"
              DocumentPath="@DocumentPath"
              EnableErrorDialog="false"
              Height="100%"
              Width="100%">
</SfPdfViewer2>

@code{
    SfPdfViewer2 PdfViewer;
    private string DocumentPath { get; set; } = "PDF_Succinctly.pdf";
}
```
 
[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Common/Supress%20the%20Error%20Dialog)