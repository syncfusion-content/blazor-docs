---
layout: post
title: Resolve the connection failure issue with Azure Blob Storage | Syncfusion
description: Learn all about resolving the connection failure issue with Azure Blob Storage and more.
platform: Blazor
control: File Manager
documentation: ug
---

# Resolve the connection failure issue with Azure Blob Storage 

To resolve connection failure issues with Azure Blob Storage in Syncfusion FileManager, you can follow these steps:

* Check whether you have enabled access permissions for the files in Azure blob storage.
* Check whether you have mapped the proper path details in Azure controller part. Also, need to specify the startPath and originalPath values as below.

```csharp
string startPath = "https://azure_service_account.blob.core.windows.net/files/";  
string originalPath = ("https://azure_service_account.blob.core.windows.net/files/Files").Replace(startPath, "");   
```

Inside that container, create a new folder, **Files** which includes all files and folders that need to be viewed in FileManager. Check out the below path for an example.

```csharp
string originalPath = ("https://azure_service_account.blob.core.windows.net/files/Files/").Replace(startPath, "");  
```