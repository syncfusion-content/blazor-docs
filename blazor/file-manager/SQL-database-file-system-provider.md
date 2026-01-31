---
layout: post
title: SQL database provider in Blazor File Manager Component | Syncfusion
description: Checkout and learn here all about SQL database file system provider in Syncfusion Blazor File Manager component and more.
platform: Blazor
control: File Manager
documentation: ug
---

# SQL database file system provider

To get started with the SQL database file system provider, ensure that a SQL Server instance or LocalDB is available and properly configured. A database with the required schema to manage files and folders should be created, and a valid connection string must be defined in the application configuration to establish connectivity.

The SQL database file system provider allows the users to manage the file system being maintained in a SQL database table. Unlike the other file system providers, the SQL database file system provider works on ID basis. Here, each file and folder have a unique ID based on which all the file operations will be performed. To get started, clone the [EJ2.ASP.NET Core SQL Server Database File Provider](https://github.com/SyncfusionExamples/ej2-sql-server-database-aspcore-file-provider) using the following command.

```json

git clone https://github.com/SyncfusionExamples/sql-server-database-aspcore-file-provider  sql-server-database-aspcore-file-provider

```

After cloning, just open the project in Visual Studio and restore the NuGet packages. To establish the SQL server connection with the database file (for eg: `FileManager.mdf`), you need to specify the connection string in the `web.config` file as shown below.

```json

<add name="FileExplorerConnection" connectionString="Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\FileManager.mdf;Integrated Security=True;Trusted_Connection=true" />

```

Then, make an entry for the connection string in `appsettings.json` file as shown below.

```json

"ConnectionStrings": {
    "FileManagerConnection": "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\App_Data\\FileManager.mdf;Integrated Security=True;Connect Timeout=30"
  }

```

Now, to configure the database connection, you need to set the **connectionName**, **tableName**, **rootFolderID** value by passing these values to the `SetSQLConnection` method in the `SQLProviderController.cs` file.

```csharp

operation.SetSQLConnection(connectionName, tableName, rootFolderID);

```

N> Refer to this [FileManager.mdf](https://github.com/SyncfusionExamples/ej2-sql-server-database-aspcore-file-provider/blob/master/App_Data/FileManager.mdf) to learn about the pre-defined file system SQL database for the Blazor File Manager.

After configuring the connection, just build and run the project. Now, the project will be hosted in `http://localhost:{port}` and just mapping the **FileManagerAjaxSettings** property of the File Manager component to the appropriate controller methods allows to manage the files in the SQL database table.

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

To perform file operations (Read, Create, Rename, Delete, Get file details, Search, Copy, Move, Upload, Download, GetImage) in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor File Manager component using the SQL database file system provider, you need to initialize the SQL database file system provider in the controller.

To initialize a local service with the above-mentioned file operations, create a new folder named `Controllers` inside the server part of the project. Then, create a new file with the extension `.cs` inside the Controllers folder and add the necessary file operations code available in the `SQLProviderController.cs` found at this [link](https://github.com/SyncfusionExamples/sql-server-database-aspcore-file-provider/blob/master/Controllers/SQLProviderController.cs). Additionally, you can check out all the necessary file operation method details for this provider in the same GitHub repository.

N> To learn more about file actions that can be performed with SQL database file system provider, refer to this [link](https://github.com/SyncfusionExamples/ej2-sql-server-database-aspcore-file-provider#key-features)