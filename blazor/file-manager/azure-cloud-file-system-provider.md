---
layout: post
title: Azure cloud provider in Blazor File Manager Component | Syncfusion
description: Checkout and learn here all about Azure cloud file system provider in Syncfusion Blazor File Manager component and more.
platform: Blazor
control: File Manager
documentation: ug
---

# Azure cloud file system provider

The Azure file system provider enables users to access and manage blobs in Azure Blob Storage. To get started, clone the [Azure File Provider](https://github.com/SyncfusionExamples/ej2-azure-aspcore-file-provider) repository using the following command.

```

git clone https://github.com/SyncfusionExamples/ej2-azure-aspcore-file-provider  ej2-azure-aspcore-file-provider

```

After cloning, open the project in Visual Studio and restore the NuGet packages. Register the Azure storage by passing the account name, account key, and blob name to the Register Azure method in the File Manager controller.

```csharp

this.operation.RegisterAzure("<--accountName-->", "<--accountKey-->", "<--blobName-->");

 ```

Set the blob container and root blob directory by passing the corresponding URLs as parameters in the setBlobContainer method as shown below.

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

N> Also, **blobPath** is the container path in Azure Blob Storage, and **filePath** is the file location path. For example, create a **files** container in the mentioned Azure blob storage. Inside that container, create a new folder, **Files** include all files and folders to be viewed in File Manager. Check out the below path for an example.

```csharp

public AzureProviderController(IHostingEnvironment hostingEnvironment)
    {
        this.operation = new AzureFileProvider();
        blobPath = "https://azure_service_account.blob.core.windows.net/files/";
        filePath = "https://azure_service_account.blob.core.windows.net/files/Files";

``` 

After setting the blob container references, build and run the project. The application will be hosted at `http://localhost:{port}`. Map the `ajaxSettings` property of the File Manager component to the appropriate controller methods to manage Azure Blob Storage.

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

N> **NuGet:** [NuGet](https://www.nuget.org/packages/Syncfusion.EJ2.FileManager.AzureFileProvider.AspNet.Core) package of **ASP.NET Core Azure file system provider** has been created.

Install the NuGet package using the following command:

```

 dotnet add package Syncfusion.EJ2.FileManager.AzureFileProvider.AspNet.Core

```

To perform file operations (Read, Create, Rename, Delete, Get file details, Search, Copy, Move, Upload, Download, GetImage) in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor File Manager component using the Azure cloud file system provider, initialize the provider in the controller.

To set up a local service with the above-mentioned file operations, create a new folder named `Controllers` in the server project. Then, create a new file with the extension `.cs` inside the Controllers folder and add the necessary file operations code available in the `AzureProviderController.cs` found at this [link](https://github.com/SyncfusionExamples/azure-aspcore-file-provider/blob/master/Controllers/AzureProviderController.cs). Refer to the repository for details on all supported file operation methods.

N> For more information about file actions available with the Azure cloud file system provider, refer to the [link](https://github.com/SyncfusionExamples/ej2-azure-aspcore-file-provider#key-features).