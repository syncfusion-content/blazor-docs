---
layout: post
title: Get loaded PDF document's data from Blazor SfPdfViewer | Syncfusion
description: Learn here all about how to get loaded PDF document's data in Syncfusion Blazor SfPdfViewer component and more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Get PDF document's data from Blazor SfPdfViewer Component

You can get the loaded PDF document's data from the SfPdfViewer component using the [GetDocumentAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_GetDocumentAsync) method of SfPdfViewer. 

The following code example shows how to get the loaded/edited document data and re-load the document.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer
@using Syncfusion.Blazor.Buttons

<SfButton @onclick="retrieve">Retrieve Document</SfButton>

<SfButton @onclick="load">ReloadRetrievedDocument</SfButton>

<SfPdfViewer2 @ref="@viewer"
              DocumentPath="@DocumentPath"
              Height="100%"
              Width="100%">
</SfPdfViewer2>

@code
{
    SfPdfViewer2 viewer;
    private string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";

    byte[]? save;

    public async void retrieve()
    {
        //Gets the loaded PDF document
        save = await viewer.GetDocumentAsync();
    }

    public async void load()
    {
        //Converts the byte array into base64 string.
        string base64String = Convert.ToBase64String(save);
        //Loads the PDF document from the specified base64 string.
        await viewer.LoadAsync("data:application/pdf;base64," + base64String, null);
    }
}

```
[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Common/Get%20the%20PDF%20document%20as%20a%20byte%20array%20-%20SfPdfViewer).

## See also

* [How to create SfPdfViewer Component in a Splitter Component](./create-sfpdfviewer-in-a-splitter-component)

* [How to create a SfPdfViewer within a popup window in Blazor](./create-sfpdfviewer-in-a-popup-window)