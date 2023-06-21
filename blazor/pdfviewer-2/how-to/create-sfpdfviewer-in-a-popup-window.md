---
layout: post
title: Create PDF Viewer in a popup window in Blazor SfPdfViewer | Syncfusion
description: Learn here all about Create PDF Viewer in a popup window in Syncfusion Blazor SfPdfViewer component and more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Create PDF Viewer in a popup window in Blazor PDF Viewer Component

For quick view, you might need to display the PDF file in a dialog window. The following code snippet explains how to use the SfPdfViewer component inside a dialog window. In this example, the Syncfusion’s dialog component is used for Blazor.

```csharp

@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.SfPdfViewer

<div id="target" style="width:800px;height:500px">
    <SfButton @onclick="OnClick">Open PDF Viewer</SfButton>
    <SfDialog @ref="@Dialog" Target="#target" Width="1060px" Visible="false" IsModal="true" Header= "@Header" ShowCloseIcon="true">
        <DialogEvents OnOpen="OnOpen"></DialogEvents>
        <SfPdfViewer2 @ref="Viewer" />
    </SfDialog>
</div>

@code {
    public SfPdfViewer2? Viewer { get; set; }
    SfDialog? Dialog;
    
    public void OnClick(MouseEventArgs args)
    {
        this.Dialog.Show();
    }

    public void OnOpen(BeforeOpenEventArgs args)
    {
        Viewer.LoadAsync(DocumentPath, null);
    }
    public string DocumentPath { get; set; } = "wwwroot/data/PDF_Succinctly.pdf";
    public string Header { get; set; } = "PDF Viewer";
}

```

[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Common/PdfViewer%20in%20Popup%20window%20-%20SfPdfViewer)