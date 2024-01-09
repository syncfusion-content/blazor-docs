---
layout: post
title: Save PDF files to AWS S3 in Blazor PDF Viewer Component | Syncfusion
description: Learn here all about how to save PDF files to AWS S3 in Syncfusion Blazor PDF Viewer component and much more details.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Save PDF file to AWS S3

To save a PDF file to AWS S3, you can follow the steps below

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
@using Syncfusion.Blazor.Buttons
```

**Step 4:** Add the below code example to save pdf to aws s3 bucket.

```csharp
@page "/"

<SfButton @onclick="OnClick">Save file to AWS S3 bucket</SfButton>
<SfPdfViewerServer @ref="@viewer" DocumentPath="@DocumentPath" Height="500px" Width="1060px"></SfPdfViewerServer>

@code {
    private SfPdfViewerServer viewer;
    private string DocumentPath { get; set; }

    private readonly string accessKey = "Your Access Key from AWS S3";
    private readonly string secretKey = "Your Secret Key from AWS S3";
    private readonly string bucketName = "Your Bucket name from AWS S3";
    private readonly string fileName = "File Name to be loaded into Syncfusion PDF Viewer";

    public async void OnClick(MouseEventArgs args)
    {
        byte[] data = await viewer.GetDocument();
        string result = Path.GetFileNameWithoutExtension(fileName);
        string FileName = result + "_downloaded.pdf";
        RegionEndpoint bucketRegion = RegionEndpoint.USEast1;

        // Configure the AWS SDK with your access credentials and other settings
        var s3Client = new AmazonS3Client(accessKey, secretKey, bucketRegion);
        using (MemoryStream stream = new MemoryStream(data))
        {
            var request = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = result + "_downloaded.pdf",
                    InputStream = stream,
                };
            // Upload the PDF document to AWS S3
            var response = s3Client.PutObjectAsync(request).Result;
        }
    }
}
```

Replace the file name with the actual document name that you want to load from Box cloud file storage. Make sure to pass the document name from the box folder to the `documentPath` property of the PDF viewer component

N> Replace **Your Access Key from AWS S3**, **Your Secret Key from AWS S3**, and **Your Bucket name from AWS S3** with your actual AWS access key, secret key and bucket name

N> The **AWSSDK.S3** NuGet package must be installed in your application to use the previous code example.

[View sample in GitHub](https://github.com/SyncfusionExamples/open-save-pdf-documents-in-aws-s3)