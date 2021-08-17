---
layout: post
title: Text Search in Blazor PDF Viewer Component | Syncfusion
description: Checkout and learn here all about Text Search in Syncfusion Blazor PDF Viewer component and much more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Text Search in Blazor PDF Viewer Component

You can find the specified text content in the PDF document using the built-in options provided with the toolbar. On initiating the search operation, the control searches for the specified text and highlights all the occurrences in the pages.

![Text Search](../pdfviewer/images/text-search.png)

You can enable or disable the text search by setting the `EnableTextSearch` API.

```cshtml
@using Syncfusion.Blazor.PdfViewerServer

<SfPdfViewerServer Width="1060px" Height="500px" DocumentPath="@DocumentPath" EnableTextSearch="true"/>

@code{
    public string DocumentPath { get; set; } = "wwwroot/data/PDF_Succinctly.pdf";
}
```

Also, you can programmatically perform search operation as given in the following code example.

```cshtml
@using Syncfusion.Blazor.PdfViewerServer
@using Syncfusion.Blazor.Buttons

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

<SfPdfViewerServer Width="1060px" Height="500px" DocumentPath="@DocumentPath" @ref="@Viewer" />

@code{
    SfPdfViewerServer Viewer;
    public string DocumentPath { get; set; } = "wwwroot/data/PDF_Succinctly.pdf";

    public void OnSearchClick(MouseEventArgs args)
    {
        //Here PDF is to be serached from the loaded document
        Viewer.SearchText("pdf", false);
    }

    public void OnSearchNext(MouseEventArgs args)
    {
        Viewer.SearchNext();
    }

    public void OnSearchPrevious(MouseEventArgs args)
    {
        Viewer.SearchPrevious();
    }

    public void OnCancelSearch(MouseEventArgs args)
    {
        Viewer.CancelTextSearch();
    }
}
```

> You can refer to our [Blazor PDF Viewer](https://www.syncfusion.com/blazor-components/blazor-pdf-viewer) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor PDF Viewer example](https://blazor.syncfusion.com/demos/pdf-viewer/default-functionalities?theme=bootstrap4) to understand how to explains core features of PDF Viewer.