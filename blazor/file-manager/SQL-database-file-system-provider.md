---
layout: post
title: SQL Database Provider in Blazor File Manager Component | Syncfusion
description: Checkout and learn here all about SQL database file system provider in Syncfusion Blazor File Manager component and more.
platform: Blazor
control: File Manager
documentation: ug
---

# SQL database file system provider

The SQL database file system provider allows users to manage a file system maintained in a SQL database table. Unlike other file system providers, this provider operates on an ID basis, where each file and folder has a unique ID used for all file operations. To begin, clone the [EJ2.ASP.NET Core SQL Server Database File Provider](https://github.com/SyncfusionExamples/ej2-sql-server-database-aspcore-file-provider) using the following command:

```json

<add name="FileExplorerConnection" connectionString="Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\FileManager.mdf;Integrated Security=True;Trusted_Connection=true" />

```

After cloning, open the project in Visual Studio and restore the NuGet packages. To establish the SQL server connection with the database file (e.g., FileManager.mdf), specify the connection string in the `web.config` file as follows:

```json

<add name="FileExplorerConnection" connectionString="Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\FileManager.mdf;Integrated Security=True;Trusted_Connection=true" />

```

Then, add an entry for the connection string in `appsettings.json` file as shown below.

```json

"ConnectionStrings": {
    "FileManagerConnection": "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\App_Data\\FileManager.mdf;Integrated Security=True;Connect Timeout=30"
  }

```

To configure the database connection, set the connection name, table name, and root folder ID by passing these values to the `SetSQLConnection` method:

```csharp

void SetSQLConnection(string name, string tableName, string tableID)\

```

N> Refer to this [FileManager.mdf](https://github.com/SyncfusionExamples/ej2-sql-server-database-aspcore-file-provider/blob/master/App_Data/FileManager.mdf) to learn about the pre-defined file system SQL database for the Blazor File Manager.

After configuring the connection, just build and run the project. Now, the project will be hosted in `http://localhost:{port}` and just mapping the ajaxSettings property of the File Manager component to the appropriate controller methods allows to manage the files in the SQL database table.

```cshtml

@*Initializing File Manager with SQL database file system service*@

@* Replace the hosted port number in the place of "{port}" *@

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="http://localhost:{port}/api/SQLProvider/SQLFileOperations"
                             UploadUrl="http://localhost:{port}/api/SQLProvider/SQLUpload"
                             DownloadUrl="http://localhost:{port}/api/SQLProvider/SQLDownload"
                             GetImageUrl="http://localhost:{port}/api/SQLProvider/SQLGetImage">
    </FileManagerAjaxSettings>
</SfFileManager>

```

To perform file operations (Read, Create, Rename, Delete, Get file details, Search, Copy, Move, Upload, Download, GetImage) in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor File Manager component using the SQL database file system provider, initialize the SQL database file system provider in the controller.

To initialize a local service with the above-mentioned file operations, create a new folder named `Controllers` inside the server part of the project. Then, create a new file with the extension `.cs` inside the Controllers folder and add the necessary file operations code available in the `SQLProviderController.cs` found at this [link](https://github.com/SyncfusionExamples/sql-server-database-aspcore-file-provider/blob/master/Controllers/SQLProviderController.cs). Additionally, all necessary file operation method details for this provider can be found in the same GitHub repository.

N> To learn more about file actions that can be performed with SQL database file system provider, refer to this [link](https://github.com/SyncfusionExamples/ej2-sql-server-database-aspcore-file-provider#key-features)