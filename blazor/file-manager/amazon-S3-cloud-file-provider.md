---
layout: post
title: Amazon S3 Cloud Provider in Blazor File Manager Component | Syncfusion
description: Checkout and learn here all about Amazon S3 cloud file provider in Syncfusion Blazor File Manager component and more.
platform: Blazor
control: File Manager
documentation: ug
---

# Amazon S3 Cloud File Provider

The Amazon ***S3*** (*Simple Storage Service*) cloud file provider enables users to access and manage a server-hosted file system as a collection of objects stored in an Amazon S3 bucket. To get started, clone the [Amazon S3 File Provider](https://github.com/SyncfusionExamples/ej2-amazon-s3-aspcore-file-provider) using the following command

```

git clone https://github.com/SyncfusionExamples/ej2-amazon-s3-aspcore-file-provider.git  ej2-amazon-s3-aspcore-file-provider.git

```

N> To learn more about creating and configuring an Amazon S3 bucket, refer to the [link](https://docs.aws.amazon.com/AmazonS3/latest/userguide/creating-buckets-s3.html).

After cloning, open the project in Visual Studio and restore the NuGet packages. Now, register Amazon S3 client account details, including *awsAccessKeyId*, *awsSecretKeyId* and *awsRegion* details in **RegisterAmazonS3** method within the File Manager controller to enable file operations.

```csharp

 void RegisterAmazonS3(string bucketName, string awsAccessKeyId, string awsSecretAccessKey, string bucketRegion)

```

Once the Amazon client account details are registered, build and run the project. The application will be hosted at `http://localhost:{port}`. Map the `ajaxSettings` property of the File Manager component to the appropriate controller methods to manage the Amazon S3 bucket's object storage.

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

To perform file operations such as read, create, rename, delete, get file details, search, copy, move, upload, download, and get image in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor File Manager component using the Amazon S3 cloud file provider, initialize the provider in the controller.

To set up a local service for these file operations, create a folder named `Controllers` in the server project. Add a new `.cs` file inside the `Controllers` folder and include the necessary file operations code from the `AmazonS3ProviderController.cs` available at this [GitHub link](https://github.com/SyncfusionExamples/amazon-s3-aspcore-file-provider/blob/master/Controllers/AmazonS3ProviderController.cs). Refer to the repository for details on all supported file operation methods.

N> For more information about the file actions available with the Amazon S3 Cloud File Provider, see the [feature list](https://github.com/SyncfusionExamples/ej2-amazon-s3-aspcore-file-provider.git#key-features).