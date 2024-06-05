---
layout: post
title: Loading Large Files Without Increasing Maximum Message Size|Syncfusion
description: Learn here all about how to Processing Large Files Without Increasing Maximum Message Size in SfPdfViewer Component.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Processing Large Files Without Increasing Maximum Message Size

The SfPdfViewer component now supports a new feature that allows for the processing of large files without the need to increase the maximum message size of a single incoming hub message (MaximumReceiveMessageSize 32KB). This is achieved through the use of chunk messaging.

To enable chunk messaging, set the [EnableChunkMessages](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_EnableChunkMessages) parameter to true. By default, this parameter is set to false.

Here is an example of how to use this feature:

```cshtml
@using Syncfusion.Blazor.SfPdfViewer

<SfPdfViewer2 @ref=" PdfViewer" EnableChunkMessages="true" DocumentPath="@DocumentPath" Height="100%" Width="100%">
</SfPdfViewer2>

@code {
    SfPdfViewer2 PdfViewer;
    public string DocumentPath { get; set; } = "wwwroot/data/PDF Succinctly.pdf";
}
```
With [EnableChunkMessages](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_EnableChunkMessages) set to true, the SfPdfViewer component will break down large files into smaller chunks and process them individually. This can be particularly useful when dealing with large PDF files, as it allows for more efficient data processing and reduces the likelihood of encountering issues related to message size limits.