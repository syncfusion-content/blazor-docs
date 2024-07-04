---
layout: post
title: Load PDF for initial loading in Blazor SfPdfViewer | Syncfusion
description: Learn here all about how to load desired PDF for initial loading in Syncfusion Blazor SfPdfViewer component and more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Load desired PDF for initial loading in Blazor SfPdfViewer Component

You can load your own PDF document for initial loading as well as change the document at runtime in the Blazor SfPdfViewer component.To load your desired PDF document for initial display, you need to set the [DocumentPath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_DocumentPath) property of the SfPdfViewer component to the path of your PDF file. 

```cshtml

@inject HttpClient Http;
@using Syncfusion.Blazor.Buttons;
@using Syncfusion.Blazor.SfPdfViewer

<SfButton OnClick="LoadAnotherDocument">Load Another Document</SfButton>

<SfPdfViewer2 Height="100%"
              Width="100%"
              DocumentPath="@DocumentPath">
</SfPdfViewer2>


@code
{
    public String DocumentPath = "Data/PDF_Succinctly.pdf";

    private async Task LoadAnotherDocument()
    {
        //Sends a GET request to a specified Uri and return the response body as a byte array.
        byte[] byteArray = await Http.GetByteArrayAsync("Data/FormFillingDocument.pdf");
        //Converts the byte array into base64 string.
        string base64String = Convert.ToBase64String(byteArray);
        //Sets the base64 string as document path for the PDF Viewer.
        DocumentPath = "data:application/pdf;base64," + base64String;
    }
}

```

In the above code, When the `Load Another Document` button is clicked, the `LoadAnotherDocument` method is triggered. This method uses the HttpClient service to retrieve the desired PDF document as a `byte` array. The byte array is then converted to a `base64` string, and the [DocumentPath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_DocumentPath) property is updated with the new document path.

With this implementation, users can click the `Load Another Document` button to dynamically change the PDF document displayed in the Blazor SfPdfViewer component.

[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Common/Load%20Desire%20PDF%20in%20Blazor%20-%20SfPdfViewer).

## See also

* [How to load Microsoft Office files in Blazor SfPdfViewer Component](./load-office-files)

* [How to load PDF documents dynamically in Blazor SfPdfViewer Component](./load-pdf-document-dynamically)

* [How to unload the PDF document from Viewer](./unload-the-pdf-document-from-viewer)