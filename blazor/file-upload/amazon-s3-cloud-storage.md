---
layout: post
title: Amazon S3 Cloud Storage Integration in Blazor File Upload Component | Syncfusion
description: Learn how to integrate and upload files to Amazon S3 Cloud Storage using the Syncfusion Blazor File Upload component with complete AWS setup and configuration guidance.
platform: Blazor
control: File Upload
documentation: ug
---

# Amazon S3 Cloud Storage in Blazor File Upload Component

The Syncfusion Blazor File Upload component integrates with Amazon S3 Cloud Storage to enable direct file uploads to AWS buckets. This integration eliminates the need for local server storage and provides scalable, secure cloud-based file management through AWS infrastructure.

## Prerequisites

To integrate Amazon S3 Cloud Storage with the Syncfusion Blazor File Upload component, ensure you have:

* An active Amazon Web Services (AWS) account
* An S3 bucket created in your desired AWS Region
* AWS credentials including the Access Key ID and Secret Access Key from your IAM console
* The bucket name and AWS region where the bucket is located
* Basic familiarity with AWS Identity and Access Management (IAM) for credential management

For detailed instructions on creating and configuring an Amazon S3 bucket, refer to the [AWS S3 bucket creation guide](https://docs.aws.amazon.com/AmazonS3/latest/userguide/creating-buckets-s3.html).

## Getting Started with Amazon S3 Integration

The Amazon S3 file provider enables you to access and manage files stored in your S3 bucket as cloud-based objects. To implement this integration, clone the [Amazon S3 File Provider example](https://github.com/SyncfusionExamples/ej2-amazon-s3-aspcore-file-provider) repository using the following command

```bash
git clone https://github.com/SyncfusionExamples/ej2-amazon-s3-aspcore-file-provider.git ej2-amazon-s3-aspcore-file-provider
```

After cloning the repository, open the project in Visual Studio and restore all NuGet packages. Next, register your AWS account credentials in the `AmazonS3ProviderController.cs` file by calling the `RegisterAmazonS3` method with your AWS credentials. This method initializes the S3 file provider with your bucket configuration for subsequent file operations.

## Registering AWS Credentials

Configure your AWS credentials in the `AmazonS3ProviderController.cs` file by calling the `RegisterAmazonS3` method with the following parameters:

```csharp
this.operation.RegisterAmazonS3("your-bucket-name", "your-access-key-id", "your-secret-access-key", "us-east-1");
```

Replace the placeholder values with your actual AWS credentials:
* `your-bucket-name`: The name of your S3 bucket
* `your-access-key-id`: Your AWS Access Key ID from the IAM console
* `your-secret-access-key`: Your AWS Secret Access Key
* `us-east-1`: Your S3 bucket's AWS region (adjust as needed)

N> Store your AWS credentials securely using environment variables, AWS Secrets Manager, or configuration management tools. Never hardcode credentials directly in source code or commit them to version control.

## Configuring the File Upload Component

After registering your AWS credentials, build and run the project. Configure the Syncfusion Blazor File Upload component by mapping the [`SaveUrl`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderAsyncSettings.html#Syncfusion_Blazor_Inputs_UploaderAsyncSettings_SaveUrl) property to your controller's upload action endpoint. This configuration enables file uploads directly to your S3 bucket.

```razor
@* Initializing File Uploader with Amazon S3 service *@
@* Replace the hosted port number in the place of "{port}" *@

<SfUploader ID="UploadFiles">
    <UploaderAsyncSettings SaveUrl="http://localhost:{port}/api/AmazonS3Provider/AmazonS3Upload"></UploaderAsyncSettings>
</SfUploader>
```

## File Operations with Amazon S3

The Amazon S3 file provider supports multiple file operations including Read, Create, Rename, Delete, Get file details, Search, Copy, Move, Upload, Download, and GetImage. To enable these operations in the Syncfusion Blazor File Upload component, initialize the Amazon S3 file provider in your controller.

Create a new controller file named `AmazonS3ProviderController.cs` in the `Controllers` folder of your Server project. Reference the implementation details available in the [AmazonS3ProviderController.cs](https://github.com/SyncfusionExamples/amazon-s3-aspcore-file-provider/blob/master/Controllers/AmazonS3ProviderController.cs) file from the official GitHub repository. This controller handles the communication between the File Upload component and your S3 bucket.

For comprehensive information about available file operations and features supported by the Amazon S3 cloud file provider, refer to the [Amazon S3 File Provider key features documentation](https://github.com/SyncfusionExamples/amazon-s3-aspcore-file-provider#key-features) in the GitHub repository.
