---
layout: post
title: Download in Blazor SfPdfViewer Component | Syncfusion
description: Checkout and learn here all about download in Syncfusion Blazor SfPdfViewer component and much more details.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Download in Blazor SfPdfViewer Component

The SfPdfViewer supports downloading the loaded PDF file from the toolbar by default. You can enable or disable the download option by setting the `EnableDownload` API.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer

<SfPdfViewer2 Width="100%" Height="100%" DocumentPath="@DocumentPath" EnableDownload="true" />

@code{

    public string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
}

```

![Blazor SfPdfViewer with Download Option](../pdfviewer/images/blazor-pdfviewer-download-option.png)


```cshtml

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.SfPdfViewer

<SfButton OnClick="OnClick">Download</SfButton>
<SfPdfViewer2 Width="100%" Height="100%" DocumentPath="@DocumentPath" @ref="@Viewer" />

@code {
    SfPdfViewer2 Viewer;
    public string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
    public void OnClick(MouseEventArgs args)
    {
        Viewer.Download();
    }
}

```

## Download Filename

The `DownloadFileName` property of the SfPdfViewer enables you to sets the name of the file to be downloaded.

The following code example shows how to set default filename to the downloaded file.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer

<SfPdfViewer2 DocumentPath="@documentPath" DownloadFileName="@downloadFileName" Height="100%" Width="100%"></SfPdfViewer2>

@code
{
    //Sets the PDF document path for initial loading.
    public string documentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";

    //Sets the name of the file to be downloaded.
    private string downloadFileName { get; set; } = "TOP-View_CutSheets.pdf";

}

```
[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Load%20and%20Save/Modify%20the%20file%20name-SfPdfViewer).

## See also

* [Print in Blazor SfPdfViewer Component](./print)