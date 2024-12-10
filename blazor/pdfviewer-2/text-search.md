---
layout: post
title: Text Search in Blazor SfPdfViewer Component | Syncfusion
description: Checkout and learn here all about text search in Syncfusion Blazor SfPdfViewer component and much more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Text Search in Blazor SfPdfViewer Component

You can find the specified text content in the PDF document using the built-in options provided with the toolbar. On initiating the search operation, the control searches for the specified text and highlights all the occurrences in the pages.

![Text Search in Blazor SfPdfViewer](../pdfviewer/images/blazor-pdfviewer-text-search.png)

You can enable or disable the text search by setting the [EnableTextSearch](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_EnableTextSearch) API.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer

<SfPdfViewer2 Height="100%" Width="100%" DocumentPath="@DocumentPath" EnableTextSearch="true" />

@code{
    public string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
}

```

Also, you can programmatically perform search operation as given in the following code example.

```cshtml

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.SfPdfViewer

<div style="display:inline-block">
    <SfButton OnClick="OnSearchClick">Search Text</SfButton>
</div>

<div style="display:inline-block">
    <SfButton OnClick="OnSearchNext">Search Next</SfButton>
</div>

<div style="display:inline-block">
    <SfButton OnClick="OnSearchPrevious">Search Previous</SfButton>
</div>

<div style="display:inline-block">
    <SfButton OnClick="OnCancelSearch">Cancel Search</SfButton>
</div>

<SfPdfViewer2 Height="100%" Width="100%" DocumentPath="@DocumentPath" @ref="@Viewer" />

@code {
    SfPdfViewer2 Viewer;
    public string DocumentPath { get; set; } = "wwwroot/data/PDF_Succinctly.pdf";

    public async void OnSearchClick(MouseEventArgs args)
    {
        //Here PDF is to be serached from the loaded document
        await Viewer.SearchTextAsync("pdf", false);
    }

    public async void OnSearchNext(MouseEventArgs args)
    {
        await Viewer.SearchNextAsync();
    }

    public async void OnSearchPrevious(MouseEventArgs args)
    {
        await Viewer.SearchPreviousAsync();
    }

    public async void OnCancelSearch(MouseEventArgs args)
    {
        await Viewer.CancelTextSearchAsync();
    }

}

```