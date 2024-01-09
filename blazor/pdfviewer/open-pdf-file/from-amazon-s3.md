---
layout: post
title:  Open PDF files from AWS S3 in PDF Viewer Component | Syncfusion
description: Learn here all about how to Open PDF files from AWS S3 in Syncfusion Blazor PDF Viewer component and much more details.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Open PDF file from AWS S3

To load a PDF file from AWS S3 in a PDF Viewer, you can follow the steps below

**Step 1:** Create AWS S3 account 

 Set up an AWS S3 account by following the instructions on the official AWS site: [AWS Management Console](https://docs.aws.amazon.com/AmazonS3/latest/userguide/Welcome.html). Create an S3 bucket and generate access keys while ensuring secure storage of 

**Step 2:** Create a Simple PDF Viewer Sample in blazor

Start by following the steps provided in this [link](https://blazor.syncfusion.com/documentation/pdfviewer/getting-started/server-side-application) to create a simple PDF viewer sample in blazor. This will give you a basic setup of the PDF viewer component.

**Step 3:** Include the following namespaces in the **Index.razor** file.

1. Import the required namespaces at the top of the file:

```csharp
@using Amazon;
@using Amazon.S3;
@using Amazon.S3.Model;
@using Syncfusion.Blazor.PdfViewerServer;
```

**Step 4:** Add the below code example to load the PDF files from AWS S3 bucket.

```csharp

@page "/"

<SfPdfViewerServer @ref="@viewer" DocumentPath="@DocumentPath" Height="500px" Width="1060px"></SfPdfViewerServer>

@code {
    private SfPdfViewerServer viewer;
    private string DocumentPath { get; set; }

    private readonly string accessKey = "Your Access Key from AWS S3";
    private readonly string secretKey = "Your Secret Key from AWS S3";
    private readonly string bucketName = "Your Bucket name from AWS S3";
    private readonly string fileName = "File Name to be loaded into Syncfusion PDF Viewer";

    protected override async Task OnInitializedAsync()
    {
        MemoryStream stream = new MemoryStream();
        RegionEndpoint bucketRegion = RegionEndpoint.USEast1;

        // Configure the AWS SDK with your access credentials and other settings
        var s3Client = new AmazonS3Client(accessKey, secretKey, bucketRegion);

        // Specify the document name or retrieve it from a different source
        var response = await s3Client.GetObjectAsync(bucketName, fileName);

        Stream responseStream = response.ResponseStream;
        responseStream.CopyTo(stream);
        stream.Seek(0, SeekOrigin.Begin);
        DocumentPath = "data:application/pdf;base64," + Convert.ToBase64String(stream.ToArray());
    }
}
```

Replace the file name with the actual document name that you want to load from Box cloud file storage. Make sure to pass the document name from the box folder to the `documentPath` property of the PDF viewer component

N> Replace **Your Access Key from AWS S3**, **Your Secret Key from AWS S3**, **File Name to be Loaded into Syncfusion PDF Viewer** with the file name to load from the aws s3 bucket to the PDF Viewer and **Your Bucket name from AWS S3** with your actual AWS access key, secret key and bucket name

N> The **AWSSDK.S3** NuGet package must be installed in your application to use the previous code example.

[View sample in GitHub](https://github.com/SyncfusionExamples/open-save-pdf-documents-in-aws-s3)