---
layout: post
title: File System Provider for ASP.NET Core in Blazor FileManager Component | Syncfusion
description: Checkout and learn here all about ASP.NET Core File System Provider in Syncfusion Blazor FileManager component and more.
platform: Blazor
control: File Manager
documentation: ug
---

## ASP.NET Core file system provider

The ASP.NET Core file system provider allows the users to access and manage the physical file system. To get started, clone the [EJ2.ASP.NET Core File Provider](https://github.com/SyncfusionExamples/ej2-aspcore-file-provider) using the following command.

```

git clone https://github.com/SyncfusionExamples/ej2-aspcore-file-provider  ej2-aspcore-file-provider

cd ej2-aspcore-file-provider

```

After cloning, just open the project in Visual Studio and restore the NuGet packages. Now, you need to set the root directory of the physical file system in the FileManager controller.

After setting the root directory of the file system, just build and run the project. Now, the project will be hosted in `http://localhost:{port}` and just mapping the ajaxSettings property of the FileManager component to the appropriate controller methods allows to manage the files in the physical file system.

```cshtml

@* Initializing File Manager with ASP.NET Core service *@

@* Replace the hosted port number in the place of "{port}" *@

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="http://localhost:{port}/api/FileManager/FileOperations"
                             UploadUrl="http://localhost:{port}/api/FileManager/Upload"
                             DownloadUrl="http://localhost:{port}/api/FileManager/Download"
                             GetImageUrl="http://localhost:{port}/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
</SfFileManager>

```

N> To learn more about file actions that can be performed with ASP.NET Core file system provider, refer to this [link](https://github.com/SyncfusionExamples/ej2-aspcore-file-provider#key-features)