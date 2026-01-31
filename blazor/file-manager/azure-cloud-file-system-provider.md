---
layout: post
title: Azure cloud provider in Blazor File Manager Component | Syncfusion
description: Checkout and learn here all about Azure cloud file system provider in Syncfusion Blazor File Manager component and more.
platform: Blazor
control: File Manager
documentation: ug
---

# Azure cloud file system provider

To get started with the Azure cloud file system provider, ensure you have an active Microsoft Azure account with a configured Blob Storage service. Create a Blob Storage container and add a subfolder to manage files and directories through the File Manager.

The Azure file system provider allows the users to access and manage the blobs in the Azure blob storage. To get started, clone the [Azure File Provider](https://github.com/SyncfusionExamples/ej2-azure-aspcore-file-provider) using the following command.

```

git clone https://github.com/SyncfusionExamples/ej2-azure-aspcore-file-provider  ej2-azure-aspcore-file-provider

```

After cloning, just open the project in Visual Studio and restore the NuGet packages. Now, you need to register the Azure storage by passing details like **accountName**, **accountKey**, and **blobName** to the `RegisterAzure` method in the `AzureProviderController.cs` file.

```csharp

this.operation.RegisterAzure("<--accountName-->", "<--accountKey-->", "<--blobName-->");

 ```

Then, set the blob container and the root blob directory by passing the corresponding URLs as parameters in the `SetBlobContainer` method as shown below.

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

After setting the blob container references, just build and run the project. Now, the project will be hosted in `http://localhost:{port}` and just mapping the **FileManagerAjaxSettings** property of the File Manager component to the appropriate controller methods allows to manage the Azure blob storage.

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

N> **NuGet:** Additionally, a [NuGet](https://www.nuget.org/packages/Syncfusion.EJ2.FileManager.AzureFileProvider.AspNet.Core) package of **ASP.NET Core Azure file system provider** has been created.

Use the following command to install the NuGet package in an application.

```

 dotnet add package Syncfusion.EJ2.FileManager.AzureFileProvider.AspNet.Core

```

To perform file operations (Read, Create, Rename, Delete, Get file details, Search, Copy, Move, Upload, Download, GetImage) in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor File Manager component using the Azure cloud file system provider, you need to initialize the Azure cloud provider in the controller.

To initialize a local service with the above-mentioned file operations, create a new folder named `Controllers` inside the server part of the project. Then, create a new file with the extension `.cs` inside the Controllers folder and add the necessary file operations code available in the `AzureProviderController.cs` found at this [link](https://github.com/SyncfusionExamples/azure-aspcore-file-provider/blob/master/Controllers/AzureProviderController.cs). Additionally, you can check out all the necessary file operation method details for this provider in the same GitHub repository.

N> To learn more about file actions that can be performed with Azure cloud file system provider, refer to this [link](https://github.com/SyncfusionExamples/ej2-azure-aspcore-file-provider#key-features)