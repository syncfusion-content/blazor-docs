---
layout: post
title: Load desired PDF for initial loading in Blazor PDF Viewer | Syncfusion
description: Learn here all about how to load desired PDF for initial loading in Syncfusion Blazor PDF Viewer component and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Load desired PDF for initial loading in Blazor PDF Viewer Component

You can load your own PDF document for initial loading as well as change document at run-time in PDF Viewer hosted sample. To achieve that, you need to add your document in the server project and refer api/values as ServiceUrl in client project.

```cshtml
@inject HttpClient Http;
@using Syncfusion.Blazor.Buttons;

<SfButton OnClick="LoadAnotherDocument">Load Another Document</SfButton>
<SfPdfViewer ServiceUrl="/api/Values" DocumentPath="@DocumentPath" Height="900px"></SfPdfViewer>

@code
{
    //Sets the PDF document path for initial loading.
    public string DocumentPath { get; set; } = "PDF_Succinctly1.pdf";

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

> [View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Hosted%20Samples/Load%20desired%20PDF%20for%20Wasm%20in%20hosted%20sample).
