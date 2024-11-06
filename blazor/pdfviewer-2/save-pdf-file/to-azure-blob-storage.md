---
layout: post
title: Save PDF files to Azure Storage in SfPdfViewer Component | Syncfusion
description: Learn here all about how to save PDF files to Azure Blob Storage in Syncfusion Blazor SfPdfViewer component and much more details.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Save PDF file to Azure Blob Storage 

To save a PDF file to Azure Blob Storage , you can follow the steps below

**Step 1:** Create the Azure Blob Storage account

Log in to the Azure Portal. Create a new Storage Account with preferred settings. Note access keys during the setup. Within the Storage Account, create a Blob Container following the steps in this [link](https://learn.microsoft.com/en-us/azure/storage/common/storage-account-create?toc=%2Fazure%2Fstorage%2Fblobs%2Ftoc.json&tabs=azure-portal).

**Step 2:** Create a Simple SfPdfViewer Sample in blazor

Start by following the steps provided in this [link](https://blazor.syncfusion.com/documentation/pdfviewer-2/getting-started/server-side-application) to create a simple SfPdfViewer sample in blazor. This will give you a basic setup of the SfPdfViewer component.

**Step 3:** Include the following namespaces in the **Index.razor** file.

1. Import the required namespaces at the top of the file:

```csharp
@using System.IO;
@using Azure.Storage.Blobs;
@using Azure.Storage.Blobs.Specialized;
@using Syncfusion.Blazor.Buttons;
@using Syncfusion.Blazor.SfPdfViewer;
```

**Step 4:** Add the below code example to save the downloaded PDF files to Azure Blob Storage container

```csharp

@page "/"
<SfButton @onclick="OnClick">Save file to Azure Blob Storage</SfButton>
<SfPdfViewer2 DocumentPath="@DocumentPath"
              @ref="viewer"
              Height="100%"
              Width="100%">
</SfPdfViewer2>

@code {
    private string DocumentPath { get; set; }
    private SfPdfViewer2 viewer;
    private readonly string connectionString = "Your Connection string from Azure";
    private readonly string containerName = "Your container name in Azure";
    private readonly string fileName = "File Name to be loaded into Syncfusion SfPdfViewer";

    public async void OnClick(MouseEventArgs args)
    {
        byte[] data = await viewer.GetDocumentAsync();

        BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

        BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

        string result = Path.GetFileNameWithoutExtension(fileName);

        // Get a reference to the blob
        BlobClient blobClient = containerClient.GetBlobClient(result + "_downloaded.pdf");

        using (MemoryStream stream = new MemoryStream(data))
        {
            blobClient.Upload(stream, true);
        }
    }
}

```

N> Replace **Your Connection string from Azure** with the actual connection string for your Azure Blob Storage account, **File Name to be Loaded into Syncfusion SfPdfViewer** with the file name to load from the Azure container to the SfPdfViewer, and **Your container name in Azure** with the actual container name.

N> The **Azure.Storage.Blobs** NuGet package must be installed in your application to use the previous code example.

[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Load%20and%20Save/Open%20and%20Save%20from%20Azure%20blob%20storage).

## See also

* [Processing Large Files Without Increasing Maximum Message Size in SfPdfViewer Component](../how-to/processing-large-files-without-increasing-maximum-message-size)