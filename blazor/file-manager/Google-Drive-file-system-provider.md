---
layout: post
title: Google Drive provider in Blazor File Manager Component | Syncfusion
description: Checkout and learn here all about Google Drive file system provider in Syncfusion Blazor File Manager component and more.
platform: Blazor
control: File Manager
documentation: ug
---

# Google Drive file system provider

To get started with the Google Drive file system provider, ensure that you have a Google account, a project created in the Google API Console with the Google Drive API enabled, and OAuth 2.0 client credentials (**client ID** and **client secret**) downloaded as a `client_secret.json` file.

The Google Drive file system provider allows users to manage files and folders in their Google Drive account. It operates on an ID-based system where each file and folder has a unique ID. To begin, clone the [EJ2.ASP.NET Core Google Drive File Provider](https://github.com/SyncfusionExamples/ej2-google-drive-aspcore-file-provider) using the following command.

```

git clone https://github.com/SyncfusionExamples/ej2-google-drive-aspcore-file-provider  ej2-google-drive-aspcore-file-provider

cd ej2-google-drive-aspcore-file-provider

```
The Google Drive file system provider uses the [Google Drive APIs](https://developers.google.com/drive/api/v3/reference/) for file access, and [OAuth 2.0](https://developers.google.com/identity/protocols/OAuth2) for authentication and authorization.

To authenticate from the client end, you need to obtain OAuth 2.0 client credentials from the `Google API Console`. To learn more about generating the client credentials from the from Google API Console, refer to this [link](https://developers.google.com/identity/protocols/OAuth2UserAgent).

**Steps to Generate OAuth 2.0 Credentials:**

* Go to the [Google API Console](https://console.developers.google.com).
* Create a new project or select an existing project.
* Enable the **Google Drive API** for your project by selecting **API Library**.
* Configure the project by selecting the **OAuth consent screen** option. Complete the steps under **App Information, Audience, Contact Information, and Finish** by clicking **Get Started** in the displayed window.
* After completing the above details, click the **Create OAuth client** button. Choose either **Desktop app** or **Web application** as appropriate.
* Once the OAuth client is created, a confirmation popup will appear. Download the generated **client_secret.json** file.
* Finally, add test users by selecting the **Audience** option under the **OAuth consent screen** section.

After downloading the `client_secret.json`, copy it into the following paths of the cloned project:

* EJ2FileManagerService > credentials > client_secret.json
* GoogleOAuth2.0Base > credentials > client_secret.json

After updating the credentials, just build and run the project. Now, the project will be hosted in `http://localhost:{port}`, and it will ask to log on to the Gmail account for which created the client secret credentials. Then, provide permission to access the Google Drive files by clicking the allow access button in the page. Now, just mapping the ajaxSettings property of the File Manager component to the appropriate controller methods will allow to manage the files from the Google Drive.

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

To initialize a local service with the above-mentioned file operations, create a new folder named `Controllers` inside the server part of the project. Then, create a new file with the extension `.cs` inside the Controllers folder and add the necessary file operations code available in the `GoogleDriveProviderController.cs` found at this [link](https://github.com/SyncfusionExamples/google-drive-aspcore-file-provider/blob/master/EJ2GoogleDriveFileProvider/Controllers/GoogleDriveProviderController.cs). Additionally, you can check out all the necessary file operation method details for this provider in the same GitHub repository.

N> To learn more about file actions that can be performed with Google drive file system provider, refer to this [link](https://github.com/SyncfusionExamples/ej2-google-drive-aspcore-file-provider#key-features)