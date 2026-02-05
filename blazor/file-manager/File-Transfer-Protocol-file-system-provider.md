---
layout: post
title: File Transfer Protocol in Blazor File Manager Component | Syncfusion
description: Check out and learn about the File Transfer Protocol (FTP) file system provider in the Syncfusion Blazor File Manager component.
platform: Blazor
control: File Manager
documentation: ug
---

# File Transfer Protocol file system provider

To get started with the File Transfer Protocol (FTP) file system provider, ensure you have access to a valid FTP server along with the **host name**, **username**, and **password** credentials.

In ASP.NET Core, the File Transfer Protocol (FTP) file system provider allows users to access a hosted file system as a collection of objects stored on an FTP server. To get started, clone the [EJ2.ASP.NET Core FTP File Provider](https://github.com/SyncfusionExamples/ej2-ftp-aspcore-file-provider) using the following command.

```bash
git clone https://github.com/SyncfusionExamples/ej2-ftp-aspcore-file-provider.git ej2-ftp-aspcore-file-provider
```

After cloning, open the project in Visual Studio and restore the NuGet packages. Then, register FTP connection details such as *hostName*, *userName*, and *password* in the **SetFTPConnection** method in the File Manager controller to perform file operations.

```csharp
this.operation.SetFTPConnection("ftp://<---hostName--->/", "<---userName--->", "<---password--->");
```

After registering the FTP details, build and run the project. The project will be hosted at `http://localhost:{port}`. Then, map the [FileManagerAjaxSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerAjaxSettings.html) property of the File Manager component to the appropriate controller methods to manage the FTP server's storage.

```razor
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

To perform file operations (Read, Create, Rename, Delete, Get file details, Search, Copy, Move, Upload, Download, GetImage) in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor File Manager component using the File Transfer Protocol file system provider, you need to initialize the File Transfer Protocol file system provider in the controller.

To initialize a local service with the above-mentioned file operations, create a folder named `Controllers` in the server project. Then, create a `.cs` file in the `Controllers` folder and add the required file operation code from [FTPProviderController.cs](https://github.com/SyncfusionExamples/ftp-aspcore-file-provider/blob/master/Controllers/FTPProviderController.cs).

N> To learn more about the file actions supported by the FTP file system provider, refer to the [key features](https://github.com/SyncfusionExamples/ftp-aspcore-file-provider#key-features).