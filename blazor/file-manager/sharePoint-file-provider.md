---
layout: post
title: SharePoint provider in Blazor File Manager Component | Syncfusion
description: Checkout and learn here all about SharePoint Provider in Syncfusion Blazor File Manager component and more.
platform: Blazor
control: File Manager
documentation: ug
---

# SharePoint file provider

To get started with the SharePoint file system provider, ensure you have access to a Microsoft 365 account with the necessary SharePoint permissions. You must register an application in Azure Active Directory to obtain the required credentials, including the `Tenant ID`, `Client ID`, and `Client Secret`. These credentials are required to authenticate and interact with the Microsoft Graph API for accessing the SharePoint document library.

The SharePoint file provider allows users to access and manage files within Microsoft SharePoint. To get started, clone the [SharePoint File Provider](https://github.com/SyncfusionExamples/sharepoint-aspcore-file-provider) using the following command.


```

git clone https://github.com/SyncfusionExamples/sharepoint-aspcore-file-provider  sharepoint-aspcore-file-provider

cd sharepoint-aspcore-file-provider

```

To set up the SharePoint service provider, follow these steps:

1. **Create an App Registration in Azure Active Directory (AAD):** 
   - Navigate to the Azure portal and create a new app registration under Azure Active Directory.
   - Note down the **Tenant ID**, **Client ID**, and **Client Secret** from the app registration.

2. **Use Microsoft Graph Instance:** 
   - With the obtained Tenant ID, Client ID, and Client Secret, you can create a Microsoft Graph instance.
   - This instance will be used to interact with the SharePoint document library.

3. **Use Details from `appsettings.json`:**
   - The `SharePointController` is already configured to use the credentials provided in the `appsettings.json` file.
   - You only need to provide your `Tenant ID`, `Client ID`, `Client Secret`, `User Site Name`, and `User Drive ID` in the `appsettings.json` file, and the application will automatically initialize the SharePoint service.

**Example `appsettings.json` Configuration**

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "SharePointSettings": {
    "TenantId": "<--Tenant Id-->",
    "ClientId": "<--Client Id-->",
    "ClientSecret": "<--Client Secret-->",
    "UserSiteName": "<--User Site Name-->",
    "UserDriveId": "<--User Drive ID-->"
  },
  "AllowedHosts": "*"
}
```

Replace `"<--User Site Name-->"`, `"<--User Drive ID-->"`, `"tenantId"`, `"clientId"`, and `"clientSecret"` with your actual values.

After configuring the SharePoint file provider, build and run the project. Now, the project will be hosted in `http://localhost:{port}` and just mapping the [FileManagerAjaxSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerAjaxSettings.html) property of the File Manager component to the appropriate controller methods allows to manage the files in the Microsoft SharePoint.

```cshtml

@* Initializing File Manager with SharePoint file provider *@

@* Replace the hosted port number in the place of "{port}" *@

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="http://localhost:{port}/api/SharePoint/SharePointFileOperations"
                             UploadUrl="http://localhost:{port}/api/SharePoint/SharePointUpload"
                             DownloadUrl="http://localhost:{port}/api/SharePoint/SharePointDownload"
                             GetImageUrl="http://localhost:{port}/api/SharePoint/SharePointGetImage">
    </FileManagerAjaxSettings>
</SfFileManager>

```

To perform file operations (Read, Create, Rename, Delete, Get file details, Search, Copy, Move, Upload, Download, GetImage) in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor File Manager component using the SharePoint file provider, you need to initialize the SharePoint service in the controller.

To initialize a local service with the above-mentioned file operations, create a new folder named `Controllers` inside the server part of the project. Then, create a new file with the extension `.cs` inside the Controllers folder and add the necessary file operations code available in the `SharePointController.cs` found at this [link](https://github.com/SyncfusionExamples/sharepoint-aspcore-file-provider/blob/master/Controllers/SharePointController.cs). Additionally, you can check out all the necessary file operation method details for this provider in the same GitHub repository.

N> To learn more about file actions that can be performed with SharePoint file provider, refer to this [link](https://github.com/SyncfusionExamples/sharepoint-aspcore-file-provider#key-features)