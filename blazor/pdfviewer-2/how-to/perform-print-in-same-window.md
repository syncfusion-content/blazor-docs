---
layout: post
title: Perform print in same window using SfPdfViewer | Syncfusion®
description: Learn here all about how to perform print in same window in Syncfusion® Blazor SfPdfViewer component and more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Perform print in same window in Blazor SfPdfViewer Component

The `PrintMode` enum of SfPdfViewer2 allows you to decide whether to print in the same window or in a new window. The available enum values are `PrintMode.Default` and `PrintMode.NewWindow`.

* **Default** - If you set `PrintMode.Default`, printing will occur in the same window.
* **NewWindow** - If you set `PrintMode.NewWindow`, printing will open in a new window.

```cshtml
@using Syncfusion.Blazor.SfPdfViewer

<SfPdfViewer2 PrintMode="PrintMode.Default"
              DocumentPath="@DocumentPath"
              Height="100%"
              Width="100%"></SfPdfViewer2>

@code {
    private string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
}
```
In the provided code, `PrintMode.Default` is used to specify printing in the same window.

## See also

* [Print in Blazor SfPdfViewer Component](../print)

* [How to print the SfPdfViewer inside the Dialog](./print-the-sfpdfiewer-inside-the-dialog-component)