---
layout: post
title: Get loaded PDF document's data from Blazor PDF Viewer | Syncfusion
description: Learn here all about how to get loaded PDF document's data in Syncfusion Blazor PDF Viewer component and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Get PDF document's data from Blazor PDF Viewer Component

You can get the loaded PDF document's data from the PDF Viewer component using the GetDocumentAsync() method of PDF Viewer. 

The following code example shows how to get the loaded/edited document data and re-load the document.

```cshtml
@using Syncfusion.Blazor.PdfViewerServer
@using Syncfusion.Blazor.Buttons

<SfButton @onclick="retrieve">Retrieve Document</SfButton>
<SfButton @onclick="load">ReloadRetrievedDocument</SfButton>
<SfPdfViewerServer @ref="@PDFViewer" DocumentPath="@DocumentPath"> </SfPdfViewerServer>

@code
{
    public SfPdfViewerServer PDFViewer { get; set; }

    //Sets the PDF document path for initial loading.
    private string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";

    byte[] save;

    public async void retrieve()
    {
        //Gets the loaded PDF document
        save = await PDFViewer.GetDocumentAsync();
    }

    public void load()
    {
        //Converts the byte array into base64 string.
        string base64String = Convert.ToBase64String(save);
        //Loads the PDF document from the specified base64 string.
        PDFViewer.LoadAsync("data:application/pdf;base64," + base64String, null);
    }    
}
```
N> [View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-classic-examples/tree/master/Common/Get%20the%20PDF%20document%20as%20a%20byte%20array).