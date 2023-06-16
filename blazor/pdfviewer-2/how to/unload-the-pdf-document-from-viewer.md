---
layout: post
title: Unload the PDF document from Viewer in Blazor SfPdfViewer | Syncfusion
description: Learn here all about Unload the PDF document from Viewer in Syncfusion Blazor SfPdfViewer component and more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Unload the PDF document from Viewer in Blazor PDF Viewer Component

The SfPdfViewer component will automatically unload and clear the resources occupied by the PDF document when the control is disposed. Also, when loading another PDF file, the resources occupied by previous loaded file in viewer will be automatically unloaded and cleared.

If you want to unload and clear the resources occupied by the PDF file programmatically, invoke the Unload() method as shown below.

```csharp

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.SfPdfViewer

<SfButton @onclick="OnClick">Unload Document</SfButton>
<SfPdfViewer2 @ref="@Viewer" Height="500px" Width="1060px" DocumentPath="@DocumentPath" />

@code {
    SfPdfViewer2 Viewer;
    public void OnClick(MouseEventArgs args)
    {
        Viewer.UnloadAsync();
    }
    public string DocumentPath { get; set; } = "wwwroot/data/PDF_Succinctly.pdf";
}

```

[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Common/Unload%20Pdf%20document%20from%20Viewer%20-%20SfPdfViewer)