---
layout: post
title: Navigation in Blazor SfPdfViewer Component | Syncfusion
description: Checkout and learn here all about navigation in Syncfusion Blazor SfPdfViewer component and much more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Navigation in Blazor SfPdfViewer Component

You can navigate between pages in Syncfusion SfPdfViewer in the following ways:

* Scroll through the pages.
* Click Go to pages in the built-in toolbar.
* Click the desired bookmark in bookmark pane.
* Click the desired page in thumbnail pane.
* Click hyperlink and table of contents.

## Page navigation

The built-in toolbar of SfPdfViewer contains the following page navigation tools:

* **First** **Page**: Navigates you to the first page in the document.
* **Last** **Page**: Navigates you to the last page in the document.
* **Next** **Page**: Scrolls forwards through pages, one page at a time.
* **Go** **To**: Allows you to quickly jump to the desired page number.
* **Previous** **Page**: Scrolls backwards through pages, one page at a time.

![Blazor SfPdfViewer with Page Navigation](../pdfviewer/images/blazor-pdfviewer-page-navigation.png)

You can enable or disable the page navigation option in SfPdfViewer default toolbar by setting the [EnableNavigation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_EnableNavigation) property.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer

<SfPdfViewer2 Width="100%"
              Height="100%"
              DocumentPath="@DocumentPath"
              EnableNavigation="false" />

@code{
    public string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
}

```

Also, you can programmatically perform page navigation as follows.

```cshtml

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.SfPdfViewer

<div style="display:inline-block">
    <SfButton OnClick="OnFirstPageClick">Go To First Page</SfButton>
</div>

<div style="display:inline-block">
    <SfButton OnClick="OnLastPageClick">Go To Last Page</SfButton>
</div>

<div style="display:inline-block">
    <SfButton OnClick="OnNextPageClick">Go To Next Page</SfButton>
</div>

<div style="display:inline-block">
    <SfTextBox @ref="@TextBox"></SfTextBox>
</div>

<div style="display:inline-block;">
    <SfButton OnClick="OnPageClick">Go To Page</SfButton>
</div>

<div style="display:inline-block">
    <SfButton OnClick="OnPreviousPageClick">Go To Previous Page</SfButton>
</div>

<SfPdfViewer2 Width="100%" Height="100%" DocumentPath="@DocumentPath" @ref="@Viewer" />

@code{
    SfPdfViewer2 Viewer;
    SfTextBox TextBox;
    public string DocumentPath { get; set; } = "wwwroot/data/PDF_Succinctly.pdf";

    public async void OnFirstPageClick(MouseEventArgs args)
    {
        await Viewer.GoToFirstPageAsync();
    }

    public async void OnLastPageClick(MouseEventArgs args)
    {
        await Viewer.GoToLastPageAsync();
    }

    public async void OnNextPageClick(MouseEventArgs args)
    {
        await Viewer.GoToNextPageAsync();
    }

    public async void OnPageClick(MouseEventArgs args)
    {
        int pageIndex =  int.Parse(TextBox.Value.ToString());
        await Viewer.GoToPageAsync(pageIndex);
    }

    public async void OnPreviousPageClick(MouseEventArgs args)
    {
        await Viewer.GoToPreviousPageAsync();
    }
}

```

## Bookmark navigation

The bookmarks saved in PDF files are loaded and listed in the bookmark pane (in the left navigation pane). The users can jump to areas of interest by clicking the desired bookmark easily.

![Blazor SfPdfViewer with Bookmark Navigation](../pdfviewer/images/blazor-pdfviewer-bookmark-navigation.png)

You can enable or disable the bookmark navigation pane by setting the [EnableBookmark](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_EnableBookmarkPanel) property.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer

<SfPdfViewer2 Height="100%" Width="100%" DocumentPath="@DocumentPath" EnableBookmarkPanel="true" />

@code{
    public string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
}

```

## Page thumbnail navigation

Page thumbnails is the miniature representation of actual pages in the PDF files. This feature displays thumbnails of the pages and represents a link to the respective pages. Clicking a page thumbnail will display the respective page in the document view.

![Blazor SfPdfViewer with Page Thumbnail Navigation](../pdfviewer/images/blazor-pdfviewer-page-thumbnail-navigation.png)

You can enable or disable the thumbnail navigation pane by setting the [EnableThumbnail](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_EnableThumbnailPanel) property.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer

<SfPdfViewer2 Height="100%" Width="100%" DocumentPath="@DocumentPath" EnableThumbnailPanel="true"/>

@code{
    public string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
}

```

### Open thumbnail panel programmatically

You can view the thumbnail navigation initially while loading the PDF document in the PDFViewer using the [IsThumbnailPanelOpen](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_IsThumbnailPanelOpen) property.

The following code illustrates how to open thumbnail panel programmatically.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer

<!--IsThumbnailPanelOpen property will enable the thumbnail panel on initial rendering itself-->
<SfPdfViewer2 @ref="@SfPdfViewer"
              DocumentPath="@DocumentPath"
              IsThumbnailPanelOpen="true"
              Height="100%"
              Width="100%">
</SfPdfViewer2>

@code {

    public SfPdfViewer2 SfPdfViewer { get; set; }
    //Sets the PDF document path for initial loading.
    private string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
}

```

[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Thumbnail/Show%20thumbnail%20panel%20-%20SfPdfViewer).

## Hyperlink navigation

Hyperlink navigation features enables navigation to the URLs (website links) in a PDF file.

![Blazor SfPdfViewer Hyperlink Navigation](../pdfviewer/images/blazor-pdfviewer-hyperlink-navigation.png)

## Table of content navigation

Table of contents navigation allows users to navigate to different parts of a PDF file that are listed in the table of contents section.

![Table of Content in Blazor SfPdfViewer](../pdfviewer/images/blazor-pdfviewer-title-of-content.png)

You can enable or disable both hyperlink and table of content navigation by setting the `EnableHyperlink` property.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer

<SfPdfViewer2 Height="100%" Width="100%" DocumentPath="@DocumentPath" EnableHyperlink="true" />

@code{
    public string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
}

```

You can set the target attribute for a hyperlink in SfPdfViewer using the [HyperlinkOpenState](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_HyperlinkOpenState) property.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer

<SfPdfViewer2 Height="100%"
              Width="100%" DocumentPath="@DocumentPath"
              EnableHyperlink="true"
              HyperlinkOpenState="LinkTarget.NewTab" />

@code{
    public string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
}
```

## See also

* [Magnification in Blazor SfPdfViewer Component](./magnification)