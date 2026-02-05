---
layout: post
title: Azure cloud provider in Blazor File Manager Component | Syncfusion
description: Check out and learn about the Azure cloud file system provider in the Syncfusion Blazor File Manager component.
platform: Blazor
control: File Manager
documentation: ug
---

# Azure cloud file system provider

To get started with the Azure cloud file system provider, ensure you have an active Microsoft Azure account with a configured Blob Storage service. [Create a Blob Storage container](https://learn.microsoft.com/en-us/azure/storage/common/storage-account-create?tabs=azure-portal) and add a subfolder to manage files and directories through the File Manager.

The Azure file system provider allows users to access and manage blobs in Azure Blob Storage. To get started, clone the [Azure File Provider](https://github.com/SyncfusionExamples/azure-aspcore-file-provider):

```bash
git clone https://github.com/SyncfusionExamples/ej2-azure-aspcore-file-provider ej2-azure-aspcore-file-provider
```

After cloning, open the project in Visual Studio and restore the NuGet packages. Then, register Azure Storage by passing **accountName**, **accountKey**, and **blobName** to the `RegisterAzure` method in the `AzureProviderController.cs` file.

```csharp
this.operation.RegisterAzure("<--accountName-->", "<--accountKey-->", "<--blobName-->");
```

Then, set the blob container and the root blob directory by passing the corresponding URLs as parameters to the `SetBlobContainer` method, as shown below.

```csharp
public AzureProviderController(IHostingEnvironment hostingEnvironment)
{
    this.operation = new AzureFileProvider();
    blobPath = "<--blobPath-->";
    filePath = "<--filePath-->";
    ...
    this.operation.SetBlobContainer(blobPath, filePath);
}
```

N> The **blobPath** represents a container path in Azure Blob Storage, and **filePath** refers to the file location path. For example, create a container named **files** in the specified Azure Blob Storage account. Inside that container, create a folder named **Files** that contains all the files and folders to be displayed in the File Manager. Refer to the following paths as an example.

```csharp
public AzureProviderController(IHostingEnvironment hostingEnvironment)
{
    this.operation = new AzureFileProvider();
    blobPath = "https://azure_service_account.blob.core.windows.net/files/";
    filePath = "https://azure_service_account.blob.core.windows.net/files/Files";
    ...
}
``` 

After setting the blob container references, build and run the project. The project will be hosted at `http://localhost:{port}`. By mapping the [FileManagerAjaxSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerAjaxSettings.html) property of the File Manager component to the appropriate controller methods, you can manage the Azure Blob Storage content.

```razor
@*Initializing File Manager with Azure service.*@

@* Replace the hosted port number in the place of "{port}" *@

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="http://localhost:{port}/api/AzureProvider/AzureFileOperations"
                             UploadUrl="http://localhost:{port}/api/AzureProvider/AzureUpload"
                             DownloadUrl="http://localhost:{port}/api/AzureProvider/AzureDownload"
                             GetImageUrl="http://localhost:{port}/api/AzureProvider/AzureGetImage">
    </FileManagerAjaxSettings>
</SfFileManager>
```

N> **NuGet:** A NuGet package for the **ASP.NET Core Azure file system provider** is available: [Syncfusion.EJ2.FileManager.AzureFileProvider.AspNet.Core](https://www.nuget.org/packages/Syncfusion.EJ2.FileManager.AzureFileProvider.AspNet.Core).

Use the following command to install the NuGet package in an application.

```bash
dotnet add package Syncfusion.EJ2.FileManager.AzureFileProvider.AspNet.Core
```

To perform file operations (Read, Create, Rename, Delete, Get file details, Search, Copy, Move, Upload, Download, GetImage) in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor File Manager component using the Azure cloud file system provider, initialize the Azure cloud provider in the controller.

To initialize a local service with the above-mentioned file operations, create a folder named `Controllers` in the server project. Then, create a `.cs` file in the `Controllers` folder and add the required file operation code from [AzureProviderController.cs](https://github.com/SyncfusionExamples/azure-aspcore-file-provider/blob/master/Controllers/AzureProviderController.cs). You can also find the method-level details for this provider in the same repository.

N> To learn more about the file actions supported by the Azure cloud file system provider, refer to the [key features](https://github.com/SyncfusionExamples/azure-aspcore-file-provider#key-features).