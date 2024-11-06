---
layout: post
title: Render JS PDF Viewer inside Blazor SfPdfViewer Component | Syncfusion
description: Learn here all about how to render the JS SfPdfViewer in Syncfusion Blazor SfPdfViewer component and more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Render JS PDF Viewer inside Blazor SfPdfViewer Component

The Syncfusion's Blazor SfPdfViewer component allows you to render the JS PDF Viewer component inside the blazor component.

The following code example shows how to render the JS PDF Viewer component into the blazor component.

**Step 1:** Add a script file to your application and refer it to the head tag.

```cshtml

<head>
    <script src="sample.js" type="text/javascript"></script>
</head>

```

**Step 2:** Add the following code to render the JS component in the blazor to the newly added JS file.

```javascript

window.renderJsPdfViewer = (id) => {
    // Render the PDF viewer control
    var viewer = new ej.pdfviewer.PdfViewer({
        documentPath: "PDF_Succinctly.pdf",
        serviceUrl: 'https://ej2services.syncfusion.com/production/web-services/api/pdfviewer'
    });
    ej.pdfviewer.PdfViewer.Inject(
        ej.pdfviewer.Toolbar, 
        ej.pdfviewer.Magnification,
        ej.pdfviewer.BookmarkView, 
        ej.pdfviewer.ThumbnailView, 
        ej.pdfviewer.TextSelection,
        ej.pdfviewer.TextSearch, 
        ej.pdfviewer.Print, 
        ej.pdfviewer.Navigation,
        ej.pdfviewer.LinkAnnotation, 
        ej.pdfviewer.Annotation,
        ej.pdfviewer.FormFields, 
        ej.pdfviewer.FormDesigner);
    viewer.appendTo('#' + id);
};

```

**Step 3:** Add the following code to the blazor component.

```cshtml

@inject IJSRuntime JS

<div id="pdfViewer" style="height:640px; width:100%;"></div>

@code {
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JS.InvokeVoidAsync("renderJsPdfViewer", "pdfViewer");
        }
    }
}

```

>N : you can’t able to use the API calls from C# side. You have to use a JS code snippet to use the PDF Viewer component API since we have rendered the JS component.

[View Sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Common/Render%20JS%20PDF%20Viewer%20component%20in%20Blazor)