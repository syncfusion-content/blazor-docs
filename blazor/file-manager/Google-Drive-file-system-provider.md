---
layout: post
title: Google Drive Provider in Blazor File Manager Component | Syncfusion
description: Checkout and learn here all about Google Drive file system provider in Syncfusion Blazor File Manager component and more.
platform: Blazor
control: File Manager
documentation: ug
---

# Google Drive file system provider

The Google Drive file system provider allows users to manage files and folders in a Google Drive account. This provider operates on an ID basis, where each file and folder has a unique ID. To begin, clone the [EJ2.ASP.NET Core Google Drive File Provider](https://github.com/SyncfusionExamples/ej2-google-drive-aspcore-file-provider) using the following command:

```

git clone https://github.com/SyncfusionExamples/ej2-google-drive-aspcore-file-provider  ej2-google-drive-aspcore-file-provider

cd ej2-google-drive-aspcore-file-provider

```

The Google Drive file system provider utilizes the [Google Drive APIs](https://developers.google.com/drive/api/v3/reference/) to read files and folders and employs the [OAuth 2.0](https://developers.google.com/identity/protocols/OAuth2) protocol for authentication and authorization. To authenticate from the client end, OAuth 2.0 client credentials must be obtained from the `Google API Console`. Refer to this [link](https://developers.google.com/identity/protocols/OAuth2UserAgent) for more information on generating client credentials from the Google API Console.

After generating the client secret data, copy the JSON data to the following specified JSON files in the cloned location.

* EJ2FileManagerService > credentials > client_secret.json
* GoogleOAuth2.0Base > credentials > client_secret.json

After updating the credentials, build and run the project. The project will be hosted at `http://localhost:{port}` and will prompt a login to the Gmail account for which the client secret credentials were created. Grant permission to access the Google Drive files by clicking the allow access button on the page. Map the `ajaxSettings` property of the File Manager component to the appropriate controller methods to manage the files from Google Drive.

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

To perform file operations (Read, Create, Rename, Delete, Get file details, Search, Copy, Move, Upload, Download, GetImage) in the Syncfusion Blazor File Manager component using the Google Drive file system provider, initialize the Google Drive file system provider in the controller.

To initialize a local service with the above-mentioned file operations, create a new folder named `Controllers` inside the server part of the project. Then, create a new file with the extension `.cs` inside the Controllers folder and add the necessary file operations code available in the `GoogleDriveProviderController.cs` found at this [link](https://github.com/SyncfusionExamples/google-drive-aspcore-file-provider/blob/master/EJ2GoogleDriveFileProvider/Controllers/GoogleDriveProviderController.cs). Additionally, all necessary file operation method details for this provider can be found in the same GitHub repository.

N> To learn more about file actions that can be performed with Google drive file system provider, refer to this [link](https://github.com/SyncfusionExamples/ej2-google-drive-aspcore-file-provider#key-features)