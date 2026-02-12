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

1. [Introduction to Amazon S3](#intro-s3)
2. [Prerequisites](#prerequisites)
3. [Setting Up Amazon S3](#setup-s3)
4. [Backend Setup](#backend-setup)
5. [Registering S3 Credentials in the Provider](#register-credentials)
6. [Configuring Syncfusion File Manager UI](#configure-ui)
7. [Supported File Operations](#supported-ops)
8. [Security Recommendations](#security)
9. [Troubleshooting](#troubleshooting)

<a id="intro-s3"></a>
### 1. Introduction to amazon S3

Amazon Simple Storage Service (Amazon S3) is an object storage service. It provides features to optimize, organize, and configure access to your data to meet your specific business, organizational, and compliance requirements.

<a id="intro-s3"></a>
### 1. Introduction to Amazon S3

Amazon Simple Storage Service (Amazon S3) is AWS’s object storage service for storing and retrieving any amount of data. S3 is durable, scalable, and pay‑as‑you‑go. In this guide the Syncfusion Blazor File Manager connects to S3 through an ASP.NET Core backend so you can securely browse and perform file operations in the File Manager component.

<a id="prerequisites"></a>
### 2. Prerequisites

Before you integrate Amazon S3 with the Syncfusion Blazor File Manager, ensure you have:
 - An AWS Account
 - A configured S3 Bucket
 - AWS credentials: `awsAccessKeyId`, `awsSecretAccessKeyId`, `bucketRegion`, `awsRegion`.

### 3. Setting Up Amazon S3

<a id="setup-s3"></a>
#### Create an S3 Bucket

 - Log into [AWS Console](https://console.aws.amazon.com) -> Navigate to S3
 - Proceed by clicking `Create Bucket`. A bucket is a container for objects. An object is a file and any metadata that describes that file. The Amazon S3 provider requires a top-level root folder in your bucket to place all required files and subfolders inside this root. Click this [link](https://docs.aws.amazon.com/AmazonS3/latest/userguide/creating-buckets-s3.html) for more details.
 - Provide a DNS‑compliant bucket name. Click this [link](https://docs.aws.amazon.com/AmazonS3/latest/userguide/bucketnamingrules.html) for more details.
 - Choose the AWS region. Click this [link](https://docs.aws.amazon.com/general/latest/gr/s3.html) for more details.

<a id="backend-setup"></a>
### 4. Backend Setup

Clone the [Amazon S3 File Provider](https://github.com/SyncfusionExamples/ej2-amazon-s3-aspcore-file-provider) using the following command,

```bash

git clone https://github.com/SyncfusionExamples/ej2-amazon-s3-aspcore-file-provider.git  ej2-amazon-s3-aspcore-file-provider.git

```

<a id="register-credentials"></a>
### 5. Registering S3 Credentials in the Provider

After cloning, open the project in Visual Studio and restore the NuGet packages. Now, register Amazon S3 client account details like **bucketName**, **awsAccessKeyId**, **awsSecretAccessKeyId** and **awsRegion** details in **RegisterAmazonS3** method in the `AmazonS3ProviderController.cs` file to perform the file operations.

```csharp

this.operation.RegisterAmazonS3("<---bucketName--->", "<---awsAccessKeyId--->", "<---awsSecretAccessKey--->", "<---region--->");

```

<a id="configure-ui"></a>
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

<a id="supported-ops"></a>
### 7. Supported File Operations

To initialize a local service and to perform file operations, create a new folder named `Controllers` inside the server part of the project. Then, create a new file with the extension `.cs` inside the Controllers folder and add the necessary file operations code available in the `AmazonS3ProviderController.cs` found at this [link](https://github.com/SyncfusionExamples/amazon-s3-aspcore-file-provider/blob/master/Controllers/AmazonS3ProviderController.cs). 

We have enabled below list of features that can be performed using amazon provider,

|Operation | Function |
|---|---|
| Upload | <ul><li>[Directory upload](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerUploadSettings.html#Syncfusion_Blazor_FileManager_FileManagerUploadSettings_DirectoryUpload)</li><li>[Sequential upload](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerUploadSettings.html#Syncfusion_Blazor_FileManager_FileManagerUploadSettings_SequentialUpload)</li><li>[Chunk upload](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerUploadSettings.html#Syncfusion_Blazor_FileManager_FileManagerUploadSettings_ChunkSize)</li><li>[Auto upload](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerUploadSettings.html#Syncfusion_Blazor_FileManager_FileManagerUploadSettings_AutoUpload)</li><li>[Drag and drop upload](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerUploadSettings.html#Syncfusion_Blazor_FileManager_FileManagerUploadSettings_DropArea)</li></ul> |
| Access Control | <ul><li>[Setting rules to files/folders](https://github.com/SyncfusionExamples/amazon-s3-aspcore-file-provider/blob/master/Models/AmazonS3FileProvider.cs#L51)</li><li>[Supported rules](https://github.com/SyncfusionExamples/amazon-s3-aspcore-file-provider/blob/master/Models/Base/AccessDetails.cs#L13)</li></ul> |


Additionally, you can check out all the necessary file operation method details for this provider in the same GitHub repository.

N> To learn more about the file actions that can be performed with Amazon S3 Cloud File provider, refer to this [link](https://github.com/SyncfusionExamples/amazon-s3-aspcore-file-provider#key-features)

<a id="security"></a>
### 8. Security Recommendations

This Amazon S3 provider for the Syncfusion Blazor File Manager is intended for demonstration and evaluation only. Before using it consult your security team or advisor and complete a security review.