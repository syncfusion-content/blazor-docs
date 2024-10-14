---
layout: post
title: Globalization and RTL in Blazor PDF Viewer Component | Syncfusion
description: Checkout and learn here all about globalization and RTL in Syncfusion Blazor PDF Viewer component and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

N> Syncfusion recommends using [Blazor PDF Viewer (NextGen)](https://blazor.syncfusion.com/documentation/pdfviewer-2/getting-started/server-side-application) Component which provides fast rendering of pages and improved performance. Also, there is no need of external Web service for processing the files and ease out the deployment complexity. It can be used in Blazor Server, WASM and MAUI applications without any changes.

# Globalization and RTL in Blazor PDF Viewer Component

## Localization

[Blazor PDFViewer](https://www.syncfusion.com/blazor-components/blazor-pdf-viewer) component can be localized. Refer to [Blazor Localization](https://blazor.syncfusion.com/documentation/common/localization) topic to localize Syncfusion Blazor components.

## Right to Left

Also, this component provides support to render the user interface suitable for users who use **right-to-left (RTL)** languages (Arabic, Hebrew, Azerbaijani, Persian, Urdu). You can specify the control to render in RTL by setting the `EnableRtl` property to true.

The following code snippet shows how to localize the component for Arabic language by setting the Locale and EnableRtl properties and providing the localized text.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.PdfViewerServer


<SfPdfViewerServer Width="1060px" Height="500px" DocumentPath="@DocumentPath" EnableRtl="true" Locale="ar-AE" />

@code{
    public string DocumentPath { get; set; } = "wwwroot/data/PDF_Succinctly.pdf";
    [Inject]
    protected IJSRuntime JsRuntime { get; set; }
    protected override void OnAfterRender(bool firstRender)
    {
        this.JsRuntime.Sf().LoadLocaleData("wwwroot/locale.json");
    }
}
```

N> You can refer to the [Blazor PDF Viewer](https://www.syncfusion.com/blazor-components/blazor-pdf-viewer) feature tour page for its groundbreaking feature representations. You can also explore the [Blazor PDF Viewer example](https://blazor.syncfusion.com/demos/pdf-viewer/default-functionalities?theme=bootstrap5) to understand how to explain core features of PDF Viewer.