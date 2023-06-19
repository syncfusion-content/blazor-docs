---
layout: post
title: Perform print in same window using SfPdfViewer | Syncfusion
description: Learn here all about how to perform print in same window in Syncfusion Blazor SfPdfViewer component and more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Perform print in same window in Blazor SfPdfViewer Component

`PrintMode` enum of SfPdfViewer2 allows you to decide whether perform print in same window or in a new window. 

* **Default** - Represents the print action in same window.
* **NewWindow** - Represents the print action in new window.

Refer the following code to perform print in same window.

```cshtml
@using Syncfusion.Blazor.SfPdfViewer

<SfPdfViewer2 PrintMode="PrintMode.Default"
              DocumentPath="@DocumentPath"
              Height="500px"
              Width="1060px"></SfPdfViewer2>

@code {
    private string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
}
```