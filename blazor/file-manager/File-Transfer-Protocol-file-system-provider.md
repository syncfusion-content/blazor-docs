---
layout: post
title: File Transfer Protocol in Blazor File Manager Component | Syncfusion
description: Checkout and learn here all about File Transfer Protocol file system provider in Syncfusion Blazor File Manager component and more.
platform: Blazor
control: File Manager
documentation: ug
---

# File Transfer Protocol (FTP) file system provider

In ASP.NET Core, the File Transfer Protocol (FTP) file system provider allows users to access a hosted file system as a collection of objects stored in the file storage using FTP. To get started, clone the [EJ2.ASP.NET Core FTP File Provider](https://github.com/SyncfusionExamples/ej2-ftp-aspcore-file-provider) repository using the following command:

```

git clone https://github.com/SyncfusionExamples/ej2-ftp-aspcore-file-provider.git  ej2-ftp-aspcore-file-provider.git

```

After cloning, open the project in Visual Studio and restore the NuGet packages. Register the FTP details, including *hostName*, *userName* and *password* in **SetFTPConnection** method in the File Manager controller to perform the file operations.

```csharp

 void SetFTPConnection(string hostName, string userName, string password)

```

After registering the File Transfer Protocol details, just build and run the project. Now, the project will be hosted in `http://localhost:{port}` and just mapping the **ajaxSettings** property of the File Manager component to the appropriate controller methods allows you to manage the FTP's objects storage.

```cshtml

@*Initializing File Manager with File Transfer Protocol service*@

@* Replace the hosted port number in the place of "{port}" *@

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="http://localhost:{port}/api/FTPProvider/FTPFileOperations"
                             UploadUrl="http://localhost:{port}/api/FTPProvider/FTPUpload"
                             DownloadUrl="http://localhost:{port}/api/FTPProvider/FTPDownload"
                             GetImageUrl="http://localhost:{port}/api/FTPProvider/FTPGetImage">
    </FileManagerAjaxSettings>
</SfFileManager>

```

To perform file operations (Read, Create, Rename, Delete, Get file details, Search, Copy, Move, Upload, Download, GetImage) in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor File Manager component using the FTP file system provider, initialize the FTP file system provider in the controller.

To initialize a local service with the above-mentioned file operations, create a new folder named `Controllers` inside the server part of the project. Then, create a new file with the extension `.cs` inside the Controllers folder and add the necessary file operations code available in the `FTPProviderController.cs` found at this [link](https://github.com/SyncfusionExamples/ftp-aspcore-file-provider/blob/master/Controllers/FTPProviderController.cs). Additionally, you can check out all the necessary file operation method details for this provider in the same GitHub repository.

N> To learn more about the file actions that can be performed with File Transfer Protocol file system provider, refer to this [link](https://github.com/SyncfusionExamples/ej2-ftp-aspcore-file-provider.git#key-features)