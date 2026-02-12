---
layout: post
title: Amazon S3 cloud Provider in Blazor File Manager Component | Syncfusion
description: Checkout and learn here all about Amazon S3 cloud file provider in Syncfusion Blazor File Manager component and more.
platform: Blazor
control: File Manager
documentation: ug
---

# Amazon S3 cloud file provider

### OverView

The Amazon S3 (Simple Storage Service) cloud file provider enables the Syncfusion Blazor File Manager to access and manage files stored in an Amazon S3 bucket. With this provider, users can perform essential operations such as reading, uploading, renaming, downloading, deleting, and searching directly in S3. It seamlessly with the Syncfusion File Manager UI, giving users a familiar, explorer‑style experience while leveraging Amazon S3’s scalable and highly available object storage.

### Table of Contents

1. Introduction to Amazon S3
2. Prerequisites
3. Setting Up Amazon S3
4. Backend Setup
5. Registering S3 Credentials in the Provider
6. Configuring Syncfusion File Manager UI
7. Supported File Operations
8. Security Recommendations
9. Troubleshooting

### 1. Introduction to amazon S3

Amazon Simple Storage Service (Amazon S3) is an object storage service. It provides features to optimize, organize, and configure access to your data to meet your specific business, organizational, and compliance requirements.

### 2. Prerequisites

Before integrating Amazon S3 with Syncfusion:
 - An AWS Account
 - A configured S3 Bucket
 - AWS credentials: `awsAccessKeyId`, `awsSecretAccessKeyId`, `bucketRegion`, `awsRegion`.

### 3. Setting Up Amazon S3

#### Create an S3 Bucket

 - Log into [AWS Console](https://console.aws.amazon.com) → Navigate to S3
 - Click Create Bucket. Click this [link](https://docs.aws.amazon.com/AmazonS3/latest/userguide/creating-buckets-s3.html) for more details.
 - Provide a DNS‑compliant bucket name. Click this [link](https://docs.aws.amazon.com/AmazonS3/latest/userguide/bucketnamingrules.html) for more details.
 - Choose the AWS region. Click this [link](https://docs.aws.amazon.com/general/latest/gr/s3.html) for more details.

### 4. Backend Setup

Clone the [Amazon S3 File Provider](https://github.com/SyncfusionExamples/ej2-amazon-s3-aspcore-file-provider) using the following command,

```bash

git clone https://github.com/SyncfusionExamples/ej2-amazon-s3-aspcore-file-provider.git  ej2-amazon-s3-aspcore-file-provider.git

```

### 5. Registering S3 Credentials in the Provider

After cloning, open the project in Visual Studio and restore the NuGet packages. Now, register Amazon S3 client account details like **bucketName**, **awsAccessKeyId**, **awsSecretAccessKeyId** and **awsRegion** details in **RegisterAmazonS3** method in the `AmazonS3ProviderController.cs` file to perform the file operations.

```csharp

this.operation.RegisterAmazonS3("<---bucketName--->", "<---awsAccessKeyId--->", "<---awsSecretAccessKey--->", "<---region--->");

```

### 6. Configuring Syncfusion File Manager UI

Now, build and run the project. It will be hosted in `http://localhost:{port}`. Map the [FileManagerAjaxSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerAjaxSettings.html) property of the File Manager component to the appropriate controller methods allows to manage the Amazon ***S3*** (*Simple Storage Service*) bucket's objects storage.

```cshtml

@*Initializing File Manager with Amazon service*@

@* Replace the hosted port number in the place of "{port}" *@

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="http://localhost:{port}/api/AmazonS3Provider/AmazonS3FileOperations"
                             UploadUrl="http://localhost:{port}/api/AmazonS3Provider/AmazonS3Upload"
                             DownloadUrl="http://localhost:{port}/api/AmazonS3Provider/AmazonS3Download"
                             GetImageUrl="http://localhost:{port}/api/AmazonS3Provider/AmazonS3GetImage">
    </FileManagerAjaxSettings>
</SfFileManager>

```

To perform file operations (Read, Create, Rename, Delete, Get file details, Search, Copy, Move, Upload, Download, GetImage) in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor File Manager component using the Amazon S3 cloud file provider, you need to initialize the Amazon S3 cloud file provider in the controller.

### 7. Supported File Operations

To initialize a local service and to perform file operations, create a new folder named `Controllers` inside the server part of the project. Then, create a new file with the extension `.cs` inside the Controllers folder and add the necessary file operations code available in the `AmazonS3ProviderController.cs` found at this [link](https://github.com/SyncfusionExamples/amazon-s3-aspcore-file-provider/blob/master/Controllers/AmazonS3ProviderController.cs). Additionally, you can check out all the necessary file operation method details for this provider in the same GitHub repository.

N> To learn more about the file actions that can be performed with Amazon S3 Cloud File provider, refer to this [link](https://github.com/SyncfusionExamples/amazon-s3-aspcore-file-provider#key-features)

### 8. Security Recommendations

This Amazon S3 provider for the Syncfusion Blazor File Manager is intended for demonstration and evaluation only. Before using it consult your security team or advisor and complete a security review.