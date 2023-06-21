---
layout: post
title: Magnification in Blazor SfPdfViewer Component | Syncfusion
description: Checkout and learn here all about magnification in Syncfusion Blazor SfPdfViewer component and much more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Magnification in Blazor SfPdfViewer Component

The built-in toolbar of SfPdfViewer contains the following zooming options:

* **Zoom** **In**: Increases the zoom value (document magnification) from the current value by preset levels.

* **Zoom** **Out**: Decreases the zoom value from the current value by preset levels.

* **Zoom** **To**: Magnifies the pages to the specified zoom value.

* **Fit** **Page**: Fits the page entirely in the available document view port size.

* **Fit** **Width**: Fits the page to the width of the view port size.

![Magnification in Blazor SfPdfViewer](../pdfviewer/images/blazor-pdfviewer-magnification.png)

You can enable or disable the magnification option in SfPdfViewer default toolbar by setting the `EnableMagnification` property.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer

<SfPdfViewer2 Height="100%" Width="100%" DocumentPath="@DocumentPath" EnableMagnification="false" />

@code{
    public string DocumentPath { get; set; } = "wwwroot/data/PDF_Succinctly.pdf";
}

```

Also, you can programmatically perform zooming operations as follows.

```cshtml

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.SfPdfViewer

<div style="display:inline-block">
    <SfButton OnClick="OnZoomInClick">Zoom In</SfButton>
</div>

<div style="display:inline-block">
    <SfButton OnClick="OnZoomOutClick">Zoom Out</SfButton>
</div>

<div style="display:inline-block">
    <SfTextBox @ref="@TextBox"></SfTextBox>
</div>

<div style="display:inline-block">
    <SfButton OnClick="OnZoomClick">Zoom</SfButton>
</div>

<div style="display:inline-block;">
    <SfButton OnClick="OnFitPageClick">Fit To Page</SfButton>
</div>

<div style="display:inline-block">
    <SfButton OnClick="OnFitWidthClick">Fit To Width</SfButton>
</div>

<SfPdfViewer2 Height="100%" Width="100%" DocumentPath="@DocumentPath" @ref="@Viewer" />

@code {
    SfPdfViewer2 Viewer;

    SfTextBox TextBox;

    public string DocumentPath { get; set; } = "wwwroot/data/PDF_Succinctly.pdf";

    public void OnZoomInClick(MouseEventArgs args)
    {
        Viewer.ZoomIn();
    }

    public void OnZoomOutClick(MouseEventArgs args)
    {
        Viewer.ZoomOut();
    }

    public void OnFitPageClick(MouseEventArgs args)
    {
        Viewer.FitToPage();
    }

    public void OnZoomClick(MouseEventArgs args)
    {
        int zoomValue = int.Parse(TextBox.Value.ToString());
        Viewer.ZoomTo(zoomValue);
    }

    public void OnFitWidthClick(MouseEventArgs args)
    {
        Viewer.FitToWidth();
    }
}

```

N> SfPdfViewer  can support zoom value ranges from 50% to 400%.