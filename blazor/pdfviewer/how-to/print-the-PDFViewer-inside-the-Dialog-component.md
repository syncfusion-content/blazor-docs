---
layout: post
title: Print the PDFViewer inside the Dialog in Blazor | Syncfusion
description: Learn here all about how to print the PDFViewer inside the Dialog in Syncfusion Blazor PDF Viewer component and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Print the PDFViewer inside the Dialog in Blazor PDF Viewer Component

The PDF Viewer supports printing the loaded PDF file by default. Here, we perform print action once PDFViewer is loaded with document.

The following code illustrates how to perform print action once PDF Viewer is loaded.

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.PdfViewer
@using Syncfusion.Blazor.PdfViewerServer

<div id="target" style="width:800px;height:100%">
    <SfButton @onclick="OnClick">Open PDF Viewer</SfButton>
    <SfDialog @ref="@dialog" Target="#target" MinHeight="100%" Width="1060px" CloseOnEscape="true" AllowDragging="true" Visible="false"
              IsModal="true" Header="@Header" ShowCloseIcon="false">
        <SfButton @onclick="OnClickopen">Open PDF Document</SfButton>
        <SfPdfViewerServer @ref="viewer"
                           Height="800px">
            <PdfViewerEvents DocumentLoaded="@documentLoad"></PdfViewerEvents>
        </SfPdfViewerServer>
    </SfDialog>
</div>

@code{
    SfPdfViewerServer viewer;
    SfDialog dialog;

    public void OnClick(MouseEventArgs args)
    {
        //Method to show the dialog window.
        this.dialog.Show(true);
    }

    //Triggers when the dialog is opened.
    public void OnClickopen(MouseEventArgs args)
    {
        //Reads the contents of the file into a byte array, and then closes the file.
        byte[] byteArray = System.IO.File.ReadAllBytes("wwwroot/data/HTTP Succinctly.pdf");
        //Converts the byte array in to base64 string.
        string base64String = Convert.ToBase64String(byteArray);
        //PDF document will get loaded from the base64 string.
        viewer.Load("data:application/pdf;base64," + base64String, null);
    }

    private void documentLoad(LoadEventArgs args)
    {
        //Perform print action on the PDFViewer. 
        viewer.PrintAsync();
    }

    public string Header { get; set; } = "PDF Viewer";
}
```

N> [View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-classic-examples/tree/master/Print/PDF%20Viewer%20in%20a%20Dialog).
