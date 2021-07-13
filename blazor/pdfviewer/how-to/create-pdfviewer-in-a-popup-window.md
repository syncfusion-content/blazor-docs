---
layout: post
title: How to Create Pdfviewer In A Popup Window in Blazor PDF Viewer Component | Syncfusion
description: Checkout and learn about Create Pdfviewer In A Popup Window in Blazor PDF Viewer component of Syncfusion, and more details.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# How to display PDF file in a popup or dialog window

For quick view, you might need to display the PDF file in a dialog window. The following code snippet explains how to use the PDF Viewer component inside a dialog window. In this example, the Syncfusion’s dialog component is used for Blazor.

```csharp
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.PdfViewerServer

<div id="target" style="width:800px;height:500px">
    <SfButton @onclick="OnClick">Open PDF Viewer</SfButton>
    <SfDialog @ref="@dialog" Target="#target" Width="1060px" Visible="false"
        IsModal="true" Header= "@Header" ShowCloseIcon="true">
        <DialogEvents OnOpen="OnOpen"></DialogEvents>
        <SfPdfViewerServer @ref="@viewer"/>
    </SfDialog>
</div>
@code{
        SfPdfViewerServer viewer;
        SfDialog dialog;

        public void OnClick(MouseEventArgs args)
        {
            this.dialog.Show();
        }

        public void OnOpen(BeforeOpenEventArgs args)
        {
            viewer.Load(DocumentPath, null);
        }
        public string DocumentPath { get; set; } = "wwwroot/data/PDF_Succinctly.pdf";
        public string Header { get; set; } = "PDF Viewer";
}
```