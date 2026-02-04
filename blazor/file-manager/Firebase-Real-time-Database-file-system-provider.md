---
layout: post
title: Firebase provider in Blazor File Manager Component | Syncfusion
description: Checkout and learn here all about Firebase file system provider in Syncfusion Blazor File Manager component and more.
platform: Blazor
control: File Manager
documentation: ug
---

# Firebase file system provider

To get started with the Firebase file system provider, ensure that you have a Firebase project, Firebase Realtime Database created, and a service account key (JSON) generated from the Firebase console.

The [Firebase Real time Database](https://firebase.google.com/) file system provider in **ASP.NET Core** provides an efficient way to store the File Manager file system in a cloud database as JSON representation.

### Generate a service account key

Follow these steps to generate and download the service account key:

* Visit the [Firebase Console](https://console.firebase.google.com/u/0/?pli=1) and open your project.

* Navigate to the **Project Settings > Service Accounts** tab.

* In the new dialog window, click the **All service accounts** option to navigate to the Google service accounts console to generate the secret key.

![Blazor File Manager displays File System Authentication](images/blazor-filemanager-file-system.png)

* Now, open the Firebase service project from the Google service accounts console and generate a key.

![Generating Key for Service Project in Blazor FileManager](images/blazor-filemanager-generate-key-image-1.png)

![Generating Key for Service Project in Blazor FileManager](images/blazor-filemanager-generate-key-image-2.png)

* After generating the key, replace the JSON content in the `access_key.json` file in the Firebase Realtime Database provider project to enable authentication for read and write operations.

To integrate with Firebase Realtime Database, create a database under **Firebase Realtime Database** and configure the **read** and **write** permissions by specifying the rules in the **Rules** tab as shown in the following example.

N> By default, rules of a Firebase project will be **false**. To read and write the data, configure the **Rules** as given in the following code snippet in the *Rules* tab in the Firebase Real time Database project.

```json
{
  /* Visit https://firebase.google.com/docs/database/security to learn more about security rules. */
  "rules": {
    ".read": "auth!=null",
    ".write": "auth!=null"
  }
}
```

Then, create a root node and add children to the root node. Refer to the following code snippet for the structure of JSON.

```json
{
  "Files": [
    {
      "_fm_selected": false,
      "caseSensitive": false,
      "dateCreated": "2026-01-01T09:15:32Z",
      "dateModified": "2026-01-15T14:48:10Z",
      "filterPath": "",
      "hasChild": true,
      "id": "0",
      "isFile": false,
      "isRoot": false,
      "name": "Files",
      "showHiddenItems": false,
      "size": 0,
      "type": ""
    },
    {
      "caseSensitive": false,
      "dateCreated": "2026-01-10T11:22:45Z",
      "dateModified": "2026-01-22T17:55:12Z",
      "filterId": "0/",
      "filterPath": "/",
      "hasChild": false,
      "id": "5",
      "isFile": false,
      "isRoot": true,
      "name": "Music",
      "parentId": "0",
      "selected": false,
      "showHiddenItems": false,
      "size": 0,
      "type": "folder"
    },
    {
      "caseSensitive": false,
      "dateCreated": "2026-01-05T13:04:27Z",
      "dateModified": "2026-01-13T12:52:44Z",
      "filterId": "0/",
      "filterPath": "/",
      "hasChild": false,
      "id": "6",
      "isFile": false,
      "isRoot": true,
      "name": "Videos",
      "parentId": "0",
      "selected": false,
      "showHiddenItems": false,
      "size": 0,
      "type": ""
    }
  ]
}
```

Here, `Files` denotes the `rootNode`, and the array items represent folders/files in the File Manager file system. The first object typically represents the root folder, and child items reference the root using `parentId`.

In the **Data** tab of your Firebase Realtime Database, locate the project's **API URL**. You can use this URL in your backend configuration code. To upload the file structure, create a **.json** file using the format shown above and import it using the **Import JSON** option.

![Firebase Database in Blazor FileManager](images/blazor-filemanager-database.png)

After that, clone the [EJ2.ASP.NET Core Firebase Realtime Database File Provider](https://github.com/SyncfusionExamples/ej2-firebase-realtime-database-aspcore-file-provider), open the project in Visual Studio, and restore the NuGet packages.

Register Firebase Realtime Database by assigning the **Firebase Realtime Database REST API URL**, **rootNode**, and **serviceAccountKeyPath** parameters in the `RegisterFirebaseRealtimeDB` method of the `FirebaseRealtimeDBFileProvider` class in the controller part of the ASP.NET Core application, in the `FirebaseProviderController.cs` file.

```csharp

this.operation.RegisterFirebaseRealtimeDB("<---API URL--->", "<---RootNode--->", Path.Combine(hostingEnvironment.ContentRootPath, "FirebaseRealtimeDBHelper", "access_key.json"));

```

**Example:**

```csharp

this.operation.RegisterFirebaseRealtimeDB("https://filemanager-c0f6d.firebaseio.com/", "Files", Path.Combine(hostingEnvironment.ContentRootPath, "FirebaseRealtimeDBHelper", "access_key.json"));

```

In the above code,

* `https://filemanager-c0f6d.firebaseio.com/` denotes Firebase Real time Database REST API link.

* `Files` denotes newly created root node in Firebase Real time Database.

* `{give the service account key path}` denotes service account key path which has authentication key for the Firebase Real time Database data.

After configuring the Firebase Real time Database service link, build and run the project. Now, the project will be hosted in `http://localhost:{port}` and just mapping the [FileManagerAjaxSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerAjaxSettings.html) property of the File Manager component to the appropriate controller methods allows you to manage the files in the Firebase Real time Database.

```cshtml

@*Initializing File Manager with Firebase Realtime Database service*@

@* Replace the hosted port number in the place of "{port}" *@

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="http://localhost:{port}/api/FirebaseProvider/FirebaseRealtimeFileOperations"
                             UploadUrl="http://localhost:{port}/api/FirebaseProvider/FirebaseRealtimeUpload"
                             DownloadUrl="http://localhost:{port}/api/FirebaseProvider/FirebaseRealtimeDownload"
                             GetImageUrl="http://localhost:{port}/api/FirebaseProvider/FirebaseRealtimeGetImage">
    </FileManagerAjaxSettings>
</SfFileManager>


```

To perform file operations (Read, Create, Rename, Delete, Get file details, Search, Copy, Move, Upload, Download, GetImage) in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor File Manager component using the Firebase file system provider, you need to initialize the Firebase file system provider in the controller.

To initialize a local service with the above-mentioned file operations, create a new folder named `Controllers` inside the server part of the project. Then, create a new file with the extension `.cs` inside the Controllers folder and add the necessary file operation code available in the `FirebaseProviderController.cs` found at this [link](https://github.com/SyncfusionExamples/firebase-realtime-database-aspcore-file-provider/blob/master/Controllers/FirebaseProviderController.cs). Additionally, you can check out all the required file operation method details for this provider in the same GitHub repository.

N> To learn more about file actions that you can perform with Firebase file system provider, refer to this [link](https://github.com/SyncfusionExamples/firebase-realtime-database-aspcore-file-provider#key-features)