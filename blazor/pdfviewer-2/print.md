---
layout: post
title: Print in Blazor SfPdfViewer Component | Syncfusion
description: Checkout and learn here all about print in Syncfusion Blazor SfPdfViewer component and much more details.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Print in Blazor SfPdfViewer Component

The SfPdfViewer supports printing the loaded PDF file by default. You can enable or disable printing by setting the `EnablePrint` property.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer

<SfPdfViewer2 Height="100%"
              Width="100%"
              DocumentPath="@DocumentPath"
              EnablePrint="true" />

@code{
    public string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
}

```

![Printing in Blazor SfPdfViewer](../pdfviewer/images/blazor-pdfviewer-print.png)


```cshtml

@using Syncfusion.Blazor.SfPdfViewer
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="OnClick">Print</SfButton>
<SfPdfViewer2 Width="100%"
              Height="100%"
              DocumentPath="@DocumentPath"
              @ref="@Viewer" />

@code{
    SfPdfViewer2 Viewer;
    public string DocumentPath { get; set; } = "wwwroot/data/PDF_Succinctly.pdf";

    public async void OnClick(MouseEventArgs args)
    {
        await Viewer.PrintAsync();
    }
}

```