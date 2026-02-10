---
layout: post
title: Amazon S3 Cloud Storage in Blazor File Upload Component | Syncfusion
description: Checkout and learn here all about uploading files to Amazon S3 Cloud Storage using Syncfusion Blazor File Upload component and more.
platform: Blazor
control: File Upload
documentation: ug
---

# Amazon S3 Cloud Storage in Blazor File Upload Component

To get started with uploading files to Amazon S3 Cloud Storage, ensure that you have an active Amazon Web Services (AWS) account and an S3 bucket created in the required AWS Region. You will also need the `AWS Access Key ID`, `Secret Access Key`, `bucket name`, and the `bucket region` to connect the File Upload component to the S3 storage.

To learn more about creating and configuring an Amazon S3 bucket, refer to this [link](https://docs.aws.amazon.com/AmazonS3/latest/userguide/creating-buckets-s3.html).

The Amazon ***S3*** (*Simple Storage Service*) cloud file provider allows the users to access and manage a server hosted file system as collection of objects stored in the Amazon S3 Bucket. To get started, clone the [Amazon S3 File Provider](https://github.com/SyncfusionExamples/ej2-amazon-s3-aspcore-file-provider) using the following command

```

git clone https://github.com/SyncfusionExamples/ej2-amazon-s3-aspcore-file-provider.git  ej2-amazon-s3-aspcore-file-provider.git

```

After cloning, open the project in Visual Studio and restore the NuGet packages. Now, register Amazon S3 client account details like **bucketName**, **awsAccessKeyId**, **awsSecretAccessKeyId** and **awsRegion** details in **RegisterAmazonS3** method in the `AmazonS3ProviderController.cs` file to perform the file operations.

```csharp

this.operation.RegisterAmazonS3("<---bucketName--->", "<---awsAccessKeyId--->", "<---awsSecretAccessKey--->", "<---region--->");

```

After registering the Amazon client account details, just build and run the project. Now, the project will be hosted in `http://localhost:{port}` and just mapping the [`SaveUrl`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderAsyncSettings.html#Syncfusion_Blazor_Inputs_UploaderAsyncSettings_SaveUrl) property of the File Upload component to the appropriate controller method allows you to manage file uploads to the Amazon ***S3*** (*Simple Storage Service*) bucket.

```cshtml

@*Initializing File Uploader with Amazon service*@

@* Replace the hosted port number in the place of "{port}" *@

<SfUploader ID="UploadFiles">
    <UploaderAsyncSettings SaveUrl="http://localhost:{port}/api/AmazonS3Provider/AmazonS3Upload"></UploaderAsyncSettings>
</SfUploader>

```

To perform file operations (Read, Create, Rename, Delete, Get file details, Search, Copy, Move, Upload, Download, GetImage) in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor File Uploader component using the Amazon S3 cloud file provider, you need to initialize the Amazon S3 cloud file provider in the controller.

To initialize a local service with the above-mentioned file operations, create a new folder named `Controllers` inside the server part of the project. Then, create a new file with the extension `.cs` inside the Controllers folder and add the necessary file operations code available in the `AmazonS3ProviderController.cs` found at this [link](https://github.com/SyncfusionExamples/amazon-s3-aspcore-file-provider/blob/master/Controllers/AmazonS3ProviderController.cs). Additionally, you can check out all the necessary file operation method details for this provider in the same GitHub repository.

N> To learn more about the file actions that can be performed with Amazon S3 Cloud File provider, refer to this [link](https://github.com/SyncfusionExamples/amazon-s3-aspcore-file-provider#key-features)
