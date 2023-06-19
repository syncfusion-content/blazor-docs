---
layout: post
title: Show or hide the pdfviewer dynamically in Blazor | Syncfusion
description: Learn here all about how to show or hide the pdfviewer dynamically in Syncfusion Blazor SfPdfViewer component and more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Show or hide the SfPdfViewer dynamically in Blazor SfPdfViewer Component

In the below code, the SfPdfViewer is hidden at page load. Then, on clicking a button, the PDFViewer container will be loaded. When the user clicks on a PDF file (here it is demonstrated with buttons), the SfPdfViewer already present on the same page will be updated to show the selected document. 

```cshtml

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.SfPdfViewer;
@using System.Net;

<style>
    .e-spinner-pane {
        display: none !important;
    }
</style>

<!--Show or hide the visibility of the SfPdfViewer-->
<SfButton OnClick="ShowHidePdfViewer">@Label SfPdfViewer</SfButton>

@if (IsShowPDFViewer)
{
    <SfButton OnClick="LoadDocument1">Physical Path</SfButton>
    <SfButton OnClick="LoadDocument2">Remote Path</SfButton>

    <div class="mt-2">
        <SfPdfViewer2 DocumentPath="@Base64Content" Height="100%" Width="100%"></SfPdfViewer2>
    </div>
}

@code
{
    SfPdfViewer2 PdfViewerServerRef { get; set; }

    string Base64Content { get; set; }

    bool IsShowPDFViewer { get; set; }

    string Label => IsShowPDFViewer ? "Hide" : "Show";

    //This method handles the visibility of the PDFViewer.
    void ShowHidePdfViewer() => IsShowPDFViewer = !IsShowPDFViewer;

    public void LoadDocument1()
    {
        //Returns a byte array containing the contents of the file.
        byte[] byteArray = System.IO.File.ReadAllBytes("wwwroot/Data/PDF_Succinctly.pdf");
        //Sets the document path from base64 string.
        Base64Content = $"data:application/pdf;base64,{Convert.ToBase64String(byteArray)}";
    }

    public async Task LoadDocument2()
    {
        using (var webClient = new WebClient())
        {
            //Downloads the resource as a byte array from the url specified.
            var data = await webClient.DownloadDataTaskAsync("https://www.syncfusion.com/downloads/support/directtrac/general/pd/FSuccinctly-2023061093.pdf");
            //Sets the document path from base64 string.
            Base64Content = $"data:application/pdf;base64,{Convert.ToBase64String(data)}";
        }
    }
}
```

N> [View sample in GitHub]().
