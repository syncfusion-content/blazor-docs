---
title: "Opening PDF file in Blazor SfPdfViewer Component | Syncfusion"
component: "SfPdfViewer"
description: "This page helps you to learn about how to load PDF files from various locations in Syncfusion's Blazor SfPdfViewer."
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Open PDF files in SfPdfViewer for Blazor from various storage location

You might need to open and view the PDF files from various location. In this section, you can find the information about how to open PDF files from URL, Cloud, database, local file system, and as base64 string.

## Opening a PDF from URL

If you have your PDF files in the web, you can open it in the viewer using URL.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer

<SfPdfViewer2 DocumentPath="@DocumentPath"  Height="100%" Width="100%">
</SfPdfViewer2>


@code {
    public string DocumentPath { get; set; }
    protected override void OnInitialized()
    {
        string Url = "https://s3.amazonaws.com/files2.syncfusion.com/dtsupport/directtrac/general/pd/HTTP_Succinctly-1719682472.pdf";
        System.Net.WebClient webClient = new System.Net.WebClient();
        byte[] byteArray = webClient.DownloadData(Url);
        DocumentPath = "data:application/pdf;base64," + Convert.ToBase64String(byteArray);
    }
}

```
N> [View sample in GitHub]()

## Opening a PDF from Cloud

You can open the PDF file from Cloud storage.

The following code example shows how to open and load the PDF file stored in Azure Blob Storage.

```cshtml

@using Azure.Storage.Blobs
@using Azure.Storage.Blobs.Specialized
@using System.IO;
@using Syncfusion.Blazor.SfPdfViewer

<SfPdfViewer2 DocumentPath="@DocumentPath" Height="100%" Width="100%"></SfPdfViewer2>

@code {

    public string DocumentPath { get; set; }

    protected override void OnInitialized()
    {
        //Connection String of Storage Account
        string connectionString = "Here Place Your Connection string";
        BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
        //Container Name
        string containerName = "pdf-file";
        //File Name to be loaded into Syncfusion SfPdfViewer
        string fileName = "PDF_Succinctly.pdf";
        BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
        BlockBlobClient blockBlobClient = blobContainerClient.GetBlockBlobClient(fileName);
        MemoryStream memoryStream = new MemoryStream();
        blockBlobClient.DownloadTo(memoryStream);
        DocumentPath = "data:application/pdf;base64," + Convert.ToBase64String(memoryStream.ToArray());
    }
}

```

N> The **Azure.Storage.Blobs** NuGet package must be installed in your application to use the previous code example.

## Opening a PDF from file system

There is an UI option in built-in toolbar to open the PDF file from local file system. If you want to achieve the same functionality while designing your own toolbar, you can use the following code example to load and open the PDF file. In this sample, the Syncfusion’s Uploader control is used for Blazor.

```cshtml

@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.SfPdfViewer

<SfUploader ID="UploadFiles" AllowedExtensions=".pdf,.PDF">

    <UploaderEvents OnUploadStart="onsuccess"></UploaderEvents>

    <UploaderAsyncSettings SaveUrl="https://aspnetmvc.syncfusion.com/services/api/uploadbox/Save" 
    RemoveUrl="https://aspnetmvc.syncfusion.com/services/api/uploadbox/Remove"></UploaderAsyncSettings>

</SfUploader>

<SfPdfViewer2 @ref="@Viewer" Height="100%" Width="100%">

</SfPdfViewer2>

@code {

    SfPdfViewer2 Viewer;

    public void onsuccess(UploadingEventArgs action)
    {
        string filePath = action.FileData.RawFile.ToString();
        Viewer.Load(filePath, null);
    }
}

```

## Opening a PDF from base64 data

The following code snippet explains how the PDF file can be loaded in SfPdfViewer as base64 string.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer

<SfPdfViewer2 ID="viewer" DocumentPath="@DocumentPath" Height="100%" Width="100%">
</SfPdfViewer2>

@code {

    static byte[] byteArray = System.IO.File.ReadAllBytes("wwwroot/Data/PDF_Succinctly.pdf");

    static string base64String = Convert.ToBase64String(byteArray);

    public string DocumentPath { get; set; } = "data:application/pdf;base64," + base64String;

}

```

N> [View sample in GitHub]()

## Opening a PDF from stream

You can load a PDF file from stream in SfPdfViewer by converting the stream into a base64 string. The following code sample explains how the PDF file can be loaded in SfPdfViewer from stream.

```csharp

@using Syncfusion.Blazor.SfPdfViewer
@using System.IO;

<SfPdfViewer2 ID="viewer" DocumentPath="@DocumentPath" Height="100%" Width="100%">
</SfPdfViewer2>

@code{

    public string DocumentPath { get; set; }

    protected override void OnInitialized()
    {
        string filePath = "wwwroot/Data/PDF_Succinctly.pdf";
        FileStream fileStream = new FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
        MemoryStream stream = new MemoryStream();
        fileStream.CopyTo(stream);
        byte[] byteArray = stream.ToArray();
        string base64String = Convert.ToBase64String(byteArray);
        DocumentPath = "data:application/pdf;base64," + base64String;
    }

}

```

N> [View sample in GitHub]()