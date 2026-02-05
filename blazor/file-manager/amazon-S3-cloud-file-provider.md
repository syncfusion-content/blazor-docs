---
layout: post
title: Amazon S3 cloud Provider in Blazor File Manager Component | Syncfusion
description: Check out and learn about the Amazon S3 cloud file provider in the Syncfusion Blazor File Manager component.
platform: Blazor
control: File Manager
documentation: ug
---

# Amazon S3 cloud file provider

To get started with the Amazon S3 cloud file provider, ensure that you have an active Amazon Web Services (AWS) account and an S3 bucket created in the required AWS Region. You will also need the `AWS Access Key ID`, `Secret Access Key`, `bucket name`, and the `bucket region` to connect the File Manager to the S3 storage.

To learn more about creating and configuring an Amazon S3 bucket, refer to this [link](https://docs.aws.amazon.com/AmazonS3/latest/userguide/creating-buckets-s3.html).

The Amazon **S3** (Simple Storage Service) cloud file provider allows users to access and manage a server-hosted file system as a collection of objects stored in an Amazon S3 bucket. To get started, clone the [Amazon S3 File Provider](https://github.com/SyncfusionExamples/ej2-amazon-s3-aspcore-file-provider):

```bash
git clone https://github.com/SyncfusionExamples/ej2-amazon-s3-aspcore-file-provider ej2-amazon-s3-aspcore-file-provider
```

After cloning, open the project in Visual Studio and restore the NuGet packages. Then, register the Amazon S3 client details (for example, **bucketName**, **awsAccessKeyId**, **awsSecretAccessKeyId**, and **awsRegion**) in the `RegisterAmazonS3` method in the `AmazonS3ProviderController.cs` file.

```csharp
this.operation.RegisterAmazonS3("<---bucketName--->", "<---awsAccessKeyId--->", "<---awsSecretAccessKey--->", "<---region--->");
```

After registering the Amazon client account details, build and run the project. The project will be hosted at `http://localhost:{port}`. By mapping the [FileManagerAjaxSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerAjaxSettings.html) property of the File Manager component to the appropriate controller methods, you can manage the Amazon S3 bucket objects.

```razor
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

To perform file operations (Read, Create, Rename, Delete, Get file details, Search, Copy, Move, Upload, Download, GetImage) in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor File Manager component using the Amazon S3 cloud file provider, initialize the Amazon S3 cloud file provider in the controller.

To initialize a local service with the above-mentioned file operations, create a folder named `Controllers` in the server project. Then, create a `.cs` file in the `Controllers` folder and add the required file operation code from `AmazonS3ProviderController.cs` in this repository: https://github.com/SyncfusionExamples/ej2-amazon-s3-aspcore-file-provider. You can also find the method-level details for this provider in the same repository.

N> To learn more about the file actions supported by the Amazon S3 cloud file provider, refer to the [key features](https://github.com/SyncfusionExamples/ej2-amazon-s3-aspcore-file-provider#key-features).