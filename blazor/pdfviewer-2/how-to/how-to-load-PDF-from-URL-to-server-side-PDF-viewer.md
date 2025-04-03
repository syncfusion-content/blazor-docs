---
layout: post
title: How to load PDF from URL to server-side PDF viewer | Syncfusion
description: Learn here all about how to load PDf from URL on the server-side and load into Syncfusion Blazor SfPdfViewer component and more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# How to load PDF from URL to server-side PDF viewer.

We already support loading PDF documents from [remote URLs](https://blazor.syncfusion.com/documentation/pdfviewer-2/opening-pdf-file). However, you can also load a document from a URL on the server side using the code provided below.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer

<SfPdfViewer2 DocumentPath="@DocumentPath"
              Height="100%"
              Width="100%">
</SfPdfViewer2>

@code {
    public string DocumentPath { get; set; }
    protected override void OnInitialized()
    {
        string Url = "https://s3.amazonaws.com/files2.syncfusion.com/dtsupport/directtrac/general/pd/HTTP_Succinctly-1719682472.pdf";
        System.Net.WebClient webClient = new System.Net.WebClient();
        byte[] byteArray = webClient.DownloadData(Url);
        DocumentPath = "data:application/pdf;base64," + Convert.ToBase64String(byteArray);
    }
}

```
[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Load%20and%20Save/Load%20PDF%20file%20from%20URL)