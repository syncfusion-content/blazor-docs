---
layout: post
title: Amazon S3 Cloud Provider in Blazor File Manager | Syncfusion®
description: Check out and learn about the Amazon S3 cloud file provider in the Blazor File Manager component and much more detail.
platform: Blazor
control: File Manager
documentation: ug
---

# Amazon S3 cloud file provider

## Introduction to Amazon S3

Amazon Simple Storage Service (Amazon S3) is AWS's object storage service for storing and retrieving any amount of data. In this guide, the [Blazor File Manager](https://www.syncfusion.com/blazor-components/blazor-file-manager) connects to S3 through an ASP.NET Core backend so you can securely browse and perform file operations in the File Manager component.

**Tested with:** .NET 6.0 and later, Syncfusion Blazor File Manager 20.x and later

## Prerequisites

Before you integrate Amazon S3 with the Blazor File Manager, ensure you have:
 - An AWS account
 - A configured S3 bucket
 - AWS credentials: `awsAccessKeyId`, `awsSecretAccessKey`, `awsRegion`

## Setting Up Amazon S3

 - Open the [AWS Management Console guide](https://docs.aws.amazon.com/awsconsolehelpdocs/) and sign in to the AWS Management Console, then navigate to S3.
 - Click `Create Bucket`. The Amazon S3 provider requires a top-level root folder in your bucket to place all required files and subfolders. See [creating-buckets-s3](https://docs.aws.amazon.com/AmazonS3/latest/userguide/creating-buckets-s3.html) for more details.
 - Provide a DNS-compliant bucket name. See [bucketnamingrules](https://docs.aws.amazon.com/AmazonS3/latest/userguide/bucketnamingrules.html) for naming requirements.
 - Choose the AWS region. See [AWS Regions](https://docs.aws.amazon.com/general/latest/gr/s3.html) for available options.
 - Create an IAM user with S3 permissions or use an existing IAM role. Ensure the user/role has `s3:GetObject`, `s3:PutObject`, `s3:DeleteObject`, and `s3:ListBucket` permissions on your bucket.
 - Store credentials securely using AWS Secrets Manager or environment variables, not in code.

## Backend Setup

Clone the [Amazon S3 File Provider](https://github.com/SyncfusionExamples/amazon-s3-aspcore-file-provider) using the following command:

```bash
git clone https://github.com/SyncfusionExamples/amazon-s3-aspcore-file-provider amazon-s3-aspcore-file-provider
```

N> This Amazon S3 provider for the Blazor File Manager is intended for demonstration and evaluation only. Before using it, consult your security team and complete a security review.

To initialize a local service with the mentioned file operations, create a folder named `Controllers` in the server project. Then, create a `.cs` file in the `Controllers` folder and add the required file operation code from [AmazonS3ProviderController.cs](https://github.com/SyncfusionExamples/amazon-s3-aspcore-file-provider/blob/master/Controllers/AmazonS3ProviderController.cs). You can also find the method-level details for this provider in the same repository.

## Registering S3 Credentials in the Provider

After cloning, open the project in Visual Studio and restore the NuGet packages. In the `AmazonS3ProviderController.cs` file, locate the `RegisterAmazonS3` method in the controller initialization and provide your AWS credentials:

```csharp
// Example in AmazonS3ProviderController.cs
public void ConfigureAmazonS3()
{
    var bucketName = "your-bucket-name";
    var awsAccessKeyId = "your-access-key";
    var awsSecretAccessKey = "your-secret-key";
    var awsRegion = "us-east-1";
    
    this.operation.RegisterAmazonS3(bucketName, awsAccessKeyId, awsSecretAccessKey, awsRegion);
}
```

**Security Note:** Store credentials in appsettings.json or AWS Secrets Manager, not hardcoded in source code.

## Configuring Blazor File Manager UI

### Install Required Packages

Open the NuGet Package Manager in Visual Studio (Tools → NuGet Package Manager → Manage NuGet Packages for Solution) and install:
- **Syncfusion.Blazor.FileManager**
- **Syncfusion.Blazor.Themes**

See [File Manager Getting Started](https://blazor.syncfusion.com/documentation/file-manager/getting-started-with-web-app) for detailed setup instructions.

### Register Syncfusion Services

In your Blazor application's `Program.cs`, register Syncfusion services:

```csharp
builder.Services.AddSyncfusionBlazor();
```

### Add the File Manager Component

In your .razor file, add the File Manager component configured with Amazon S3 endpoints. Build and run the Amazon S3 backend project first; it will be hosted at `http://localhost:{port}`. Replace `{port}` with the actual port number.

```cshtml
@page "/filemanager"
@using Syncfusion.Blazor.FileManager

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings 
        Url="http://localhost:5000/api/AmazonS3Provider/AmazonS3FileOperations"
        UploadUrl="http://localhost:5000/api/AmazonS3Provider/AmazonS3Upload"
        DownloadUrl="http://localhost:5000/api/AmazonS3Provider/AmazonS3Download"
        GetImageUrl="http://localhost:5000/api/AmazonS3Provider/AmazonS3GetImage">
    </FileManagerAjaxSettings>
</SfFileManager>
```

**Endpoint Descriptions:**
- **Url** - Handles file/folder read, rename, delete, and search operations
- **UploadUrl** - Handles file and folder upload operations
- **DownloadUrl** - Handles file download operations
- **GetImageUrl** - Handles image preview and thumbnail generation

## Supported File Operations

The following file operations are supported with the Amazon S3 cloud file provider:

| Operation | Details |
|---|---|
| Read | Browse folders and files in S3 bucket |
| Create | Create new folders in S3 bucket |
| Rename | Rename files and folders |
| Delete | Delete files and folders |
| Search | Search files by name across folders |
| Copy/Move | Copy or move files and folders between directories |
| Upload | [Directory upload](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerUploadSettings.html#Syncfusion_Blazor_FileManager_FileManagerUploadSettings_DirectoryUpload), [Sequential upload](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerUploadSettings.html#Syncfusion_Blazor_FileManager_FileManagerUploadSettings_SequentialUpload), [Chunk upload](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerUploadSettings.html#Syncfusion_Blazor_FileManager_FileManagerUploadSettings_ChunkSize), [Auto upload](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerUploadSettings.html#Syncfusion_Blazor_FileManager_FileManagerUploadSettings_AutoUpload), [Drag and drop upload](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerUploadSettings.html#Syncfusion_Blazor_FileManager_FileManagerUploadSettings_DropArea) |
| Download | Download files from S3 bucket |
| Get Image | Display image thumbnails and previews |
| Access Control | [Setting rules to files/folders](https://github.com/SyncfusionExamples/amazon-s3-aspcore-file-provider/blob/master/Models/AmazonS3FileProvider.cs#L62), [Supported rules](https://github.com/SyncfusionExamples/amazon-s3-aspcore-file-provider/blob/master/Models/Base/AccessDetails.cs#L65) |

For complete implementation details, see [Amazon S3 File Provider Repository](https://github.com/SyncfusionExamples/amazon-s3-aspcore-file-provider). To view a live demo, visit the [Amazon S3 File Provider Demo](https://blazor.syncfusion.com/demos/file-manager/amazon-s3-provider?theme=fluent2).

## Troubleshooting

**AWS Credential Errors:**
- Verify `awsAccessKeyId` and `awsSecretAccessKey` are correct
- Ensure IAM user has S3 permissions (see [Setting Up Amazon S3](#setting-up-amazon-s3))
- Check that the AWS region matches your bucket location

**Bucket Access Errors:**
- Confirm bucket name is correct and exists
- Verify bucket policy allows the IAM user/role access
- Ensure bucket region matches the `awsRegion` parameter

**Upload/Download Issues:**
- Check network connectivity to AWS
- Verify bucket has sufficient storage space for uploads
- Ensure file permissions allow read/write operations

**For Production Deployment:**
- Replace `localhost` URLs with your actual backend server URL
- Use HTTPS instead of HTTP
- Store AWS credentials in a secure configuration service, not in code
