---
layout: post
title: Create PDF Viewer in a popup window in Blazor PDF Viewer | Syncfusion
description: Learn here all about Create PDF Viewer in a popup window in Syncfusion Blazor PDF Viewer component and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Create PDF Viewer in a popup window in Blazor PDF Viewer Component

For quick view, you might need to display the PDF file in a dialog window. The following code snippet explains how to use the PDF Viewer component inside a dialog window. In this example, the Syncfusion’s dialog component is used for Blazor.

```cshtml
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

N> You can refer to our [Blazor PDF Viewer](https://www.syncfusion.com/blazor-components/blazor-pdf-viewer) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor PDF Viewer example](https://blazor.syncfusion.com/demos/pdf-viewer-2/default-functionalities?theme=bootstrap5) to understand how to explains core features of PDF Viewer.