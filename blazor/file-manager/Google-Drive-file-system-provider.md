---
layout: post
title: Google Drive provider in Blazor File Manager Component | Syncfusion
description: Checkout and learn here all about Google Drive file system provider in Syncfusion Blazor File Manager component and more.
platform: Blazor
control: File Manager
documentation: ug
---

# Google Drive file system provider

## Introduction

The Google Drive file system provider enables the Syncfusion Blazor File Manager to browse, manage, and manipulate files stored in a Google Drive account using an ASP.NET Core backend.
Each file and folder in Google Drive is identified by a unique file ID, and all operations—read, create, delete, copy, move, search, upload, download—are performed using these internal IDs.
This guide shows how to set up Google OAuth 2.0, configure the Syncfusion ASP.NET Core Google Drive provider, and integrate it with the Blazor File Manager.

## Prerequisites

Before integrating the Google Drive provider with the Syncfusion Blazor File Manager, ensure the following:
 - A Google Cloud Platform project
 - [Google Drive API](https://developers.google.com/drive/api/v3/reference/)
 - [OAuth 2.0](https://developers.google.com/identity/protocols/OAuth2) Client ID credentials
 - The generated `client_secret.json`.

## Setting Up Google OAuth 2.0 Credentials

1. Go to the [Google API Console](https://console.cloud.google.com/).
2. Create a new project or select an existing one.
3. Enable the Google Drive API.
4. Create OAuth 2.0 credentials (Desktop App or Web Application).
5. Download the generated `client_secret.json` file.

For detailed steps, refer to the [Google OAuth 2.0 JavaScript Implicit Flow documentation](https://developers.google.com/identity/protocols/oauth2/javascript-implicit-flow).

## Backend Setup

Clone the Syncfusion [Google Drive ASP.NET Core file provider](https://github.com/SyncfusionExamples/google-drive-aspcore-file-provider) using the following command,

```bash
git clone https://github.com/SyncfusionExamples/google-drive-aspcore-file-provider  google-drive-aspcore-file-provider
```

N> This Google Drive file provider for the Syncfusion Blazor File Manager is intended for demonstration and evaluation only. Before using it in production, consult your security team and complete a security review.

To initialize a local service with the above-mentioned file operations, create a folder named `Controllers` in the server project. Then, create a `.cs` file in the Controllers folder and add the required file operation code from [GoogleDriveProviderController.cs](https://github.com/SyncfusionExamples/google-drive-aspcore-file-provider/blob/master/EJ2GoogleDriveFileProvider/Controllers/GoogleDriveProviderController.cs). You can also find the method-level details for this provider in the same repository.

## Configuring OAuth Credentials

Copy the downloaded `client_secret.json` file to the following two folders inside the cloned project:
- [`EJ2GoogleDriveFileProvider/credentials/client_secret.json`](https://github.com/SyncfusionExamples/google-drive-aspcore-file-provider/tree/master/EJ2GoogleDriveFileProvider/credentials)
- [`GoogleOAuth2.0Base/credentials/client_secret.json`](https://github.com/SyncfusionExamples/google-drive-aspcore-file-provider/tree/master/GoogleOAuth2.0Base/credentials)

These credentials are required for authenticating Google Drive requests from your backend.

## Configuring Syncfusion File Manager UI

To configure File Manager component, open the NuGet package manager in Visual Studio (Tools → NuGet Package Manager → Manage NuGet Packages for Solution), then search and install **Syncfusion.Blazor.FileManager** and **Syncfusion.Blazor.Themes**. Integrate the FileManager component by pasting the below code in your .razor file of the Blazor application. Click this [link](https://blazor.syncfusion.com/documentation/file-manager/getting-started-with-web-app) for more details.

Now, build and run the Google Drive File Service provider project. It will be hosted in `http://localhost:{port}`. When accessed, it will prompt for Google account authentication and request permission to access Google Drive files. Grant the required permissions to proceed. Map the [FileManagerAjaxSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerAjaxSettings.html) of the File Manager component to the Google drive provider controller endpoints (Url, UploadUrl, DownloadUrl, GetImageUrl) to manage the files from the Google Drive.

```cshtml
@*Initializing File Manager with Google Drive file system service.*@

@* Replace the hosted port number in the place of "{port}" *@

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="http://localhost:{port}/api/GoogleDriveProvider/GoogleDriveFileOperations"
                             UploadUrl="http://localhost:{port}/api/GoogleDriveProvider/GoogleDriveUpload"
                             DownloadUrl="http://localhost:{port}/api/GoogleDriveProvider/GoogleDriveDownload"
                             GetImageUrl="http://localhost:{port}/api/GoogleDriveProvider/GoogleDriveGetImage">
    </FileManagerAjaxSettings>
</SfFileManager>
```

To perform file operations (Read, Create, Rename, Delete, Get file details, Search, Copy, Move, Upload, Download, GetImage) in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor File Manager component using the Google Drive file system provider, you need to initialize the Google Drive file system provider in the controller.

## Supported File Operations

We have enabled below list of features that can be performed using Google Drive file system provider,

|Operation | Function |
|---|---|
| Upload | <ul><li>[Directory upload](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerUploadSettings.html#Syncfusion_Blazor_FileManager_FileManagerUploadSettings_DirectoryUpload)</li><li>[Sequential upload](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerUploadSettings.html#Syncfusion_Blazor_FileManager_FileManagerUploadSettings_SequentialUpload)</li><li>[Chunk upload](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerUploadSettings.html#Syncfusion_Blazor_FileManager_FileManagerUploadSettings_ChunkSize)</li><li>[Auto upload](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerUploadSettings.html#Syncfusion_Blazor_FileManager_FileManagerUploadSettings_AutoUpload)</li><li>[Drag and drop upload](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerUploadSettings.html#Syncfusion_Blazor_FileManager_FileManagerUploadSettings_DropArea)</li></ul> |

Additionally, you can check out all the necessary file operation method details for this provider in the same GitHub repository.

N> To learn more about file actions that can be performed with Google drive file system provider, refer to this [link](https://github.com/SyncfusionExamples/ej2-google-drive-aspcore-file-provider#key-features)