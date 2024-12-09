---
layout: post
title: Include the Authorization token in Blazor PDF Viewer | Syncfusion
description: Learn here all about how to include the authorization token in Syncfusion Blazor PDF Viewer component and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Include the Authorization token in Blazor PDF Viewer Component

The Syncfusion's Blazor PDF Viewer component allows to include the authorization token in the PDF viewer AJAX request using the properties of the ajaxRequest header available in [`AjaxRequestSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PdfViewer.PdfViewerBase.html#Syncfusion_Blazor_PdfViewer_PdfViewerBase_AjaxRequestSettings), and it will be included in every AJAX request send from PDF Viewer.

The following code example shows how include the authorization token.

```cshtml
@using Syncfusion.Blazor.PdfViewer

<SfPdfViewer @ref="PdfViewer" ServiceUrl="https://ej2services.syncfusion.com/production/web-services/api/pdfviewer"  DocumentPath="@DocumentPath" AjaxRequestSettings="@AjaxRequestSettings" Height="500px" Width="1060px">
</SfPdfViewer>

@code{
SfPdfViewer PdfViewer;
private string DocumentPath { get; set; } = "PDF_Succinctly.pdf";

public PdfViewerAjaxRequestSettings AjaxRequestSettings = new PdfViewerAjaxRequestSettings{
    AjaxHeaders = new List<AjaxHeader>() {
        new AjaxHeader { 
            HeaderName = "Authorization", 
            HeaderValue = "Bearer 64565dfgfdsjweiuvbiuyhiueygf" 
        },

    }, 
    WithCredentials = false
};

}
```

N>`AjaxRequestSettings` is applicable for Web assembly blazor alone.

N> [View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-classic-examples/tree/master/Common/Ajax%20Authorization%20token).

Find the sample, [How to include the authorization token](https://www.syncfusion.com/downloads/support/directtrac/general/ze/BlazorWebAsssembly-493517519.zip)

N> You can refer to our [Blazor PDF Viewer](https://www.syncfusion.com/blazor-components/blazor-pdf-viewer) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor PDF Viewer example](https://blazor.syncfusion.com/demos/pdf-viewer/default-functionalities?theme=bootstrap4) to understand how to explains core features of PDF Viewer.