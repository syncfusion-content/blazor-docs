---
layout: post
title: Physical Provider in Blazor File Manager Component | Syncfusion
description: Checkout and learn here all about Physical file system provider in Syncfusion Blazor File Manager component and more.
platform: Blazor
control: File Manager
documentation: ug
---

# Physical file system provider

The Physical file system provider allows users to access and manage the physical file system. To begin, clone the [Physical file system provider](https://github.com/SyncfusionExamples/ej2-aspcore-file-provider) using the following command.

```

git clone https://github.com/SyncfusionExamples/ej2-aspcore-file-provider  ej2-aspcore-file-provider

cd ej2-aspcore-file-provider

```

After cloning, open the project in Visual Studio and restore the NuGet packages. Set the root directory of the physical file system in the File Manager controller.

After setting the root directory, build and run the project. The project will be hosted at `http://localhost:{port}`. Mapping the `ajaxSettings` property of the File Manager component to the appropriate controller methods allows managing the files in the physical file system.

```cshtml

@* Initializing File Manager with Physical file system provider *@

@* Replace the hosted port number in the place of "{port}" *@

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="http://localhost:{port}/api/FileManager/FileOperations"
                             UploadUrl="http://localhost:{port}/api/FileManager/Upload"
                             DownloadUrl="http://localhost:{port}/api/FileManager/Download"
                             GetImageUrl="http://localhost:{port}/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
</SfFileManager>

```

To perform file operations (Read, Create, Rename, Delete, Get file details, Search, Copy, Move, Upload, Download, GetImage) in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor File Manager component using the Physical file system provider, initialize the physical service in the controller.

To initialize a local service with the above-mentioned file operations, create a new folder named `Controllers` inside the server part of the project. Then, create a new file with the extension `.cs` inside the Controllers folder and add the necessary file operations code available in the `FileManagerController.cs` found at this [link](https://github.com/SyncfusionExamples/ej2-aspcore-file-provider/blob/master/Controllers/FileManagerController.cs). Additionally, all necessary file operation method details for this provider can be found in the same GitHub repository.

N> To learn more about file actions that can be performed with Physical file system provider, refer to this [link](https://github.com/SyncfusionExamples/ej2-aspcore-file-provider#key-features). When using a custom physical file provider in Syncfusion File Manager, installing a [PhysicalFileProvider](https://www.nuget.org/packages/Syncfusion.Blazor.FileManager.PhysicalFileProvider) NuGet package is not required. The custom provider manages file operations independently, eliminating the need for additional dependencies.
