---
title: "Opening PDF file"
component: "PDF Viewer"
description: "This page helps you to learn about how to load PDF files from various locations in Syncfusion's Blazor PDF Viewer."
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Open PDF files in PDF Viewer for Blazor from various storage location

You might need to open and view the PDF files from various location. In this section, you can find information about how to open PDF files from URL, Cloud, database, local file system, and as base64 string.

## Opening a PDF from URL

If you have your PDF files in the web, you can open it in the viewer using URL. The following code example explains how to open PDF file from URL.

```cshtml
@using Syncfusion.Blazor.PdfViewerServer

<SfPdfViewerServer DocumentPath="@DocumentPath" Width="1060px" Height="500px" />

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

## Opening a PDF from Cloud

You can open the PDF file from Cloud storage.

The following code example shows how to open and load the PDF file stored in Azure Blob Storage.

```cshtml
@using Azure.Storage.Blobs
@using Azure.Storage.Blobs.Specialized
@using System.IO;
@using Syncfusion.Blazor.PdfViewerServer

<SfPdfViewerServer DocumentPath="@DocumentPath" Width="1060px" Height="500px" />

@code {
    public string DocumentPath { get; set; }
    public void blobLoad(MouseEventArgs args)
    {
        //Connection String of Storage Account
        string connectionString = "Here Place Your Connection string";
        BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
        //Container Name
        string containerName = "pdf-file";
        //File Name to be loaded into Syncfusion PDF Viewer
        string fileName = "Python_Succinctly.pdf";
        BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
        BlockBlobClient blockBlobClient = blobContainerClient.GetBlockBlobClient(fileName);
        MemoryStream memoryStream = new MemoryStream();
        blockBlobClient.DownloadTo(memoryStream);
        DocumentPath = "data:application/pdf;base64," + Convert.ToBase64String(memoryStream.ToArray());
    }
}
```

>Note: The **Azure.Storage.Blobs** NuGet package must be installed in your application to use the previous code example.

You can open the PDF file from Azure File Storage using the following code example.

```cshtml
@using Azure.Storage.Files.Shares
@using System.IO;
@using Syncfusion.Blazor.PdfViewerServer

<SfPdfViewerServer DocumentPath="@DocumentPath" Width="1060px" Height="500px" />

@code {
    public string DocumentPath { get; set; } = "wwwroot/data/PDF_Succinctly.pdf";
    protected override void OnInitialized()
    {
        //Connection String of Storage Account
        string connectionString = "Here Place Your Connection string";
        string shareName = "pdfdocument";
        //File Name to be loaded into Syncfusion PDF Viewer
        string filePath = "Hive_Succinctly.pdf";
        ShareFileClient shareFileClient = new ShareFileClient(connectionString, shareName, filePath);
        Stream stream = shareFileClient.OpenRead();
        byte[] bytes;
        using (var memoryStream = new MemoryStream())
        {
            stream.CopyTo(memoryStream);
            bytes = memoryStream.ToArray();
        }
        DocumentPath = "data:application/pdf;base64," + Convert.ToBase64String(bytes);
    }
}
```

>Note: The **Azure.Storage.Files.Shares** NuGet package must be installed in your application to use the previous code example.

## Opening a PDF from database

The following code example shows how to open the PDF file in viewer from SQL Server database.

```cshtml
@using Syncfusion.Blazor.PdfViewerServer

<SfPdfViewerServer DocumentPath="@DocumentPath" Width="1060px" Height="500px" />

@code {
    public string DocumentPath { get; set; }
    protected override void OnInitialized()
    {
        string documentID = "PDF Succinctly";
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Database.mdf;";
        System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString);
        //Searches for the PDF document from the database
        string query = "select Data from Table where DocumentName = '" + documentID + "'";
        System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(query, connection);
        connection.Open();
        System.Data.SqlClient.SqlDataReader read = command.ExecuteReader();
        read.Read();
        //Reads the PDF document data as byte array from the database
        byte[] byteArray = (byte[])read["Data"];
        DocumentPath = "data:application/pdf;base64," + Convert.ToBase64String(byteArray);
    }
}
```

>Note: The **System.Data.SqlClient** package must be installed in your application to use the previous code example. You need to modify the connectionString variable in the previous code example as per the connection string of your database.

## Opening a PDF from file system

There is an UI option in built-in toolbar to open the PDF file from local file system. If you want to achieve the same functionality when design your own toolbar, you can use the following code example to load and open the PDF file. In this sample, the Syncfusion’s Uploader control is used for Blazor.

```cshtml
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.PdfViewerServer

<SfUploader ID="UploadFiles" AllowedExtensions=".pdf,.PDF">
    <UploaderEvents FileSelected="onsuccess"></UploaderEvents>
</SfUploader>
<SfPdfViewerServer @ref="@Viewer" Width="1060px" Height="500px" />

@code {
    SfPdfViewerServer Viewer;
    public void onsuccess(SelectedEventArgs action)
    {
        string filePath = action.FilesData[0].RawFile.ToString();
        Viewer.Load(filePath, null);
    }
}
```

## Opening a PDF from base64 data

The following code snippet explains how the PDF file can be loaded in PDF Viewer as base64 string.

```cshtml
@using Syncfusion.Blazor.PdfViewerServer

<SfPdfViewerServer ID="pdfviewer" DocumentPath="@DocumentPath" Width="1060px" Height="500px"/>

@code {
    static byte[] byteArray = System.IO.File.ReadAllBytes("wwwroot/data/PDF_Succinctly.pdf");
    static string base64String = Convert.ToBase64String(byteArray);
    public string DocumentPath { get; set; } = "data:application/pdf;base64," + base64String;
}
```

## Opening a PDF from stream

You can load a PDF file from stream in PDF Viewer by converting the stream into a base64 string. The following code sample explains how the PDF file can be loaded in PDF Viewer from stream.

```csharp
@using Syncfusion.Blazor.PdfViewerServer
@using System.IO;

<SfPdfViewerServer ID="pdfviewer" DocumentPath="@DocumentPath" Width="1060px" Height="500px"/>

@code{
    public string DocumentPath { get; set; }
    protected override void OnInitialized()
    {
        string filePath = "wwwroot/data/PDF_Succinctly.pdf";
        FileStream fileStream = new FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
        MemoryStream stream = new MemoryStream();
        fileStream.CopyTo(stream);
        byte[] byteArray = stream.ToArray();
        string base64String = Convert.ToBase64String(byteArray);
        DocumentPath = "data:application/pdf;base64," + base64String;
    }
}
```

>Note: You can refer to our [Blazor PDF Viewer](https://www.syncfusion.com/blazor-components/blazor-pdf-viewer) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor PDF Viewer example](https://blazor.syncfusion.com/demos/pdf-viewer/default-functionalities?theme=bootstrap4) to understand how to explains core features of PDF Viewer.