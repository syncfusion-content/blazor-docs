---
layout: post
title: Print the Pdf Viewer inside Dialog Component in Blazor | Synfusion
description: Learn here all about how to print the Pdf Viewer inside the Dialog in Syncfusion Blazor Pdf Viewer component, it's elements and more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Print the Pdf Viewer inside the Dialog Component in Blazor

The SfPdfViewer supports printing the loaded PDF file by default. Here, we perform print action once SfPdfViewer is loaded with document.

The following code illustrates how to perform print action once SfPdfViewer is loaded.

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.SfPdfViewer

<div id="target" style="width:800px;height:100%">
    <SfButton @onclick="OnClick">Open PDF Viewer</SfButton>
       <SfDialog @ref="@dialog" 
                 Target="#target" 
                 MinHeight="100%" 
                 Width="100%" 
                 CloseOnEscape="true" 
                 AllowDragging="true" 
                 Visible="false"
                 IsModal="true" 
                 Header="@Header" 
                 ShowCloseIcon="false">
    <SfButton @onclick="OnClickopen">Open PDF Document</SfButton>
        <SfPdfViewer2 @ref="viewer"
              Width="100%"
              Height="100%">
    <PdfViewerEvents DocumentLoaded="@documentLoad">
    </PdfViewerEvents>
</SfPdfViewer2>
    </SfDialog>
</div>

@code{
    SfPdfViewer2 viewer;
    SfDialog dialog;

    public void OnClick(MouseEventArgs args)
    {
        //Method to show the dialog window.
        this.dialog.Show(true);
    }

    //Triggers when the dialog is opened.
    public async void OnClickopen(MouseEventArgs args)
    {
        //Reads the contents of the file into a byte array, and then closes the file.
        byte[] byteArray = System.IO.File.ReadAllBytes("wwwroot/data/HTTP Succinctly.pdf");
        //Converts the byte array in to base64 string.
        string base64String = Convert.ToBase64String(byteArray);
        //PDF document will get loaded from the base64 string.
        await viewer.LoadAsync("data:application/pdf;base64," + base64String, null);
    }

    private async void documentLoad(LoadEventArgs args)
    {
        //Perform print action on the SfPdfViewer. 
        await viewer.PrintAsync();
    }

    public string Header { get; set; } = "SfPdfViewer";
}
```

[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Print/PDF%20Viewer%20in%20a%20Dialog-SfPdfViewer).

## See also

* [Print in Blazor SfPdfViewer Component](../print)

* [How to perform print in same window](./perform-print-in-same-window)