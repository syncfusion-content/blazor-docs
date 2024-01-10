---
layout: post
title:  Open PDF files from AWS S3 in SfPdfViewer Component | Syncfusion
description: Learn here all about how to Open PDF files from AWS S3 in Syncfusion Blazor SfPdfViewer component and much more details.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Open PDF file from AWS S3

To load a PDF file from AWS S3 in a SfPdfViewer, you can follow the steps below

**Step 1:** Create AWS S3 account 

 Set up an AWS S3 account by following the instructions on the official AWS site: [AWS Management Console](https://docs.aws.amazon.com/AmazonS3/latest/userguide/Welcome.html). Create an S3 bucket and generate access keys while ensuring secure storage of 

**Step 2:** Create a Simple SfPdfViewer Sample in blazor

Start by following the steps provided in this [link](https://blazor.syncfusion.com/documentation/pdfviewer-2/getting-started/server-side-application) to create a simple SfPdfViewer sample in blazor. This will give you a basic setup of the SfPdfViewer component.

**Step 3:** Include the following namespaces in the **Index.razor** file.

1. Import the required namespaces at the top of the file:

```csharp
@using Amazon;
@using Amazon.S3;
@using Amazon.S3.Model;
@using Syncfusion.Blazor.SfPdfViewer;
```

**Step 4:** Add the below code example to 

```csharp

@page "/"

<SfPdfViewer2 DocumentPath="@DocumentPath"
              @ref="viewer"
              Height="100%"
              Width="100%">
</SfPdfViewer2>

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

Replace the file name with the actual document name that you want to load from Box cloud file storage. Make sure to pass the document name from the box folder to the `documentPath` property of the SfPdfViewer component

N> Replace **Your Access Key from AWS S3**, **Your Secret Key from AWS S3**, and **Your Bucket name from AWS S3** with your actual AWS access key, secret key and bucket name

N> The **AWSSDK.S3** NuGet package must be installed in your application to use the previous code example.

[View sample in GitHub](https://github.com/SyncfusionExamples/open-save-pdf-documents-in-aws-s3)