---
layout: post
title: Globalization and RTL in Blazor SfPdfViewer Component | Syncfusion
description: Checkout and learn here all about globalization and RTL in Syncfusion Blazor SfPdfViewer component and more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Globalization and RTL in Blazor SfPdfViewer Component

## Localization

[Blazor SfPdfViewer](https://www.syncfusion.com/blazor-components/blazor-pdf-viewer) component can be localized. Refer to [Blazor Localization](https://blazor.syncfusion.com/documentation/common/localization) topic to localize Syncfusion Blazor components.

## Right to Left

To enable right-to-left (RTL) rendering for the user interface, you can set the [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_EnableRtl) property of the desired control to `true`. This will ensure that the control is rendered appropriately for users who use RTL languages such as Arabic, Hebrew, Azerbaijani, Persian, and Urdu. The following code snippet demonstrates how to enable RTL rendering.

By setting EnableRtl to `true`, the control will adjust its layout and appearance to align text, icons, and other elements from right to left, providing an optimized user experience for RTL language users.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer

<SfPdfViewer2 Height="100%"
              Width="100%"
              DocumentPath="@DocumentPath"
              EnableRtl="true" />

@code {
    public string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";
}

```

## See also

* [Events in Blazor SfPdfViewer Component](./events)