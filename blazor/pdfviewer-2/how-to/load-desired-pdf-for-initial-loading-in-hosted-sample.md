---
layout: post
title: Load desired PDF for initial loading in Blazor SfPdfViewer | Syncfusion
description: Learn here all about how to load desired PDF for initial loading in Syncfusion Blazor SfPdfViewer component and more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Load desired PDF for initial loading in Blazor SfPdfViewer Component

You can load your own PDF document for initial loading as well as change document at run-time in SfPdfViewer hosted sample. To achieve that, you need to add your document in the server project and refer api/values in client project.

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

[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Common/Load%20Desire%20PDF%20in%20Blazor%20-%20SfPdfViewer).
