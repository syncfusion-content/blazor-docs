---
layout: post
title: Azure cloud provider in Blazor File Manager Component | Syncfusion
description: Checkout and learn here all about Azure cloud file system provider in Syncfusion Blazor File Manager component and more.
platform: Blazor
control: File Manager
documentation: ug
---

# Azure cloud file system provider

<a id="intro-azure"></a>
## Introduction to Azure Blob Storage

Azure Blob Storage is Microsoft Azure's object storage solution for the cloud, optimized for storing massive amounts of unstructured data. In this guide, the Syncfusion Blazor File Manager connects to Blob Storage through an ASP.NET Core backend so you can securely browse and perform file operations in the File Manager component.

<a id="prerequisites"></a>
## Prerequisites

Before you integrate Azure Blob Storage with the Syncfusion Blazor File Manager, ensure you have:
- An active Microsoft Azure subscription
- A Storage Account with Blob service enabled
- A Blob Container and an optional root folder inside that container
- Azure credentials: `accountName`, `accountKey`, and `blobName`

<a id="setup-azure"></a>
## Setting Up Azure Blob Storage

- Sign in to the [Azure Portal](https://portal.azure.com/) and [create a storage account](https://learn.microsoft.com/en-us/azure/storage/common/storage-account-create?tabs=azure-portal) with Blob service enabled.
- [Create a Blob Container](https://learn.microsoft.com/en-us/azure/storage/blobs/storage-quickstart-blobs-portal?tabs=azure-portal#create-a-container) (example: files). See Azure docs for [container naming rules](https://learn.microsoft.com/en-us/azure/storage/blobs/storage-blobs-introduction#naming-and-referencing-containers-blobs-and-metadata).

<a id="backend-setup"></a>
## Backend Setup

Clone the [Azure File Provider](https://github.com/SyncfusionExamples/ej2-azure-aspcore-file-provider) using the following command,

```bash

git clone https://github.com/SyncfusionExamples/ej2-azure-aspcore-file-provider  ej2-azure-aspcore-file-provider

```

N> This Azure Blob Storage provider for the Syncfusion Blazor File Manager is intended for demonstration and evaluation only. Before using it in production, consult your security team and complete a security review.

To initialize a local service with the above-mentioned file operations, create a new folder named `Controllers` inside the server part of the project. Then, create a new file with the extension `.cs` inside the Controllers folder and add the necessary file operations code available in the `AzureProviderController.cs` found at this [link](https://github.com/SyncfusionExamples/azure-aspcore-file-provider/blob/master/Controllers/AzureProviderController.cs). 

<a id="register-credentials"></a>
## Registering Azure Credentials in the Provider

After cloning, open the project in Visual Studio and restore the NuGet packages. Then, register the Azure storage by passing details like **accountName**, **accountKey**, and **blobName** to the `RegisterAzure` method in the `AzureProviderController.cs` file.

```csharp

this.operation.RegisterAzure("<--accountName-->", "<--accountKey-->", "<--blobName-->");

 ```

Set the blob container and the root blob directory by passing the corresponding URLs as parameters in the `SetBlobContainer` method as shown below.

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

N> The **blobPath** represents a container path in Azure Blob Storage, and **filePath** refers to the file location path. For example, create a container named **files** in the specified Azure Blob Storage account. Inside that container, create a new folder named **Files**, which contains all the files and folders that need to be displayed in the File Manager. Refer to the following path as an example.

```csharp

public AzureProviderController(IHostingEnvironment hostingEnvironment)
{
    this.operation = new AzureFileProvider();
    blobPath = "https://azure_service_account.blob.core.windows.net/files/";
    filePath = "https://azure_service_account.blob.core.windows.net/files/Files";
    ...
}

``` 

<a id="configure-ui"></a>
## Configuring Syncfusion File Manager UI

To configure File Manager component, open the NuGet package manager in Visual Studio (Tools → NuGet Package Manager → Manage NuGet Packages for Solution), then search and install **Syncfusion.Blazor.FileManager** and **Syncfusion.Blazor.Themes**. Integrate the FileManager component by pasting the below code in your .razor file of the Blazor application. Click this [link](https://blazor.syncfusion.com/documentation/file-manager/getting-started-with-web-app) for more details.

Now, build and run the Azure File Service provider project. It will be hosted in `http://localhost:{port}`. Map the [FileManagerAjaxSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerAjaxSettings.html) of the File Manager component to the AzureProvider controller endpoints (Url, UploadUrl, DownloadUrl, GetImageUrl) to manage blobs in your Azure Blob Storage container.

```cshtml

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

To perform file operations (Read, Create, Rename, Delete, Get file details, Search, Copy, Move, Upload, Download, GetImage) in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor File Manager component using the Azure cloud file system provider, you need to initialize the Azure cloud provider in the controller.

<a id="supported-ops"></a>
## Supported File Operations

We have enabled below list of features that can be performed using Azure File Service provider,

|Operation | Function |
|---|---|
| Upload | <ul><li>[Directory upload](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerUploadSettings.html#Syncfusion_Blazor_FileManager_FileManagerUploadSettings_DirectoryUpload)</li><li>[Sequential upload](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerUploadSettings.html#Syncfusion_Blazor_FileManager_FileManagerUploadSettings_SequentialUpload)</li><li>[Chunk upload](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerUploadSettings.html#Syncfusion_Blazor_FileManager_FileManagerUploadSettings_ChunkSize)</li><li>[Auto upload](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerUploadSettings.html#Syncfusion_Blazor_FileManager_FileManagerUploadSettings_AutoUpload)</li><li>[Drag and drop upload](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerUploadSettings.html#Syncfusion_Blazor_FileManager_FileManagerUploadSettings_DropArea)</li></ul> |
| Access Control | <ul><li>[Setting rules to files/folders](https://github.com/SyncfusionExamples/azure-aspcore-file-provider/blob/master/Models/AzureFileProvider.cs#L58)</li><li>[Supported rules](https://github.com/SyncfusionExamples/azure-aspcore-file-provider/blob/master/Models/Base/AccessDetails.cs#L65)</li></ul> |

Additionally, you can check out all the necessary file operation method details for this provider in the same GitHub repository.

N> To learn more about file actions that can be performed with Azure cloud file system provider, refer to this [link](https://github.com/SyncfusionExamples/ej2-azure-aspcore-file-provider#key-features)