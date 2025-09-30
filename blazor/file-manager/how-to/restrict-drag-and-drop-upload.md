---
layout: post
title: Prevent upload in Blazor File Manager Component | Syncfusion
description: Checkout and learn here all about prevent external upload in Syncfusion Blazor File Manager component and much more.
platform: Blazor
control: File Manager
documentation: ug
---

# Restrict drag and drop upload

The Blazor File Manager component allows developers to restrict external drag-and-drop upload actions for files and folders. To disable this functionality, set the [DropArea](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerUploadSettings.html#Syncfusion_Blazor_FileManager_FileManagerUploadSettings_DropArea) property as `null` in the [`FileManagerUploadSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerUploadSettings.html) class. 

The following example demonstrates how to prevent external drag-and-drop upload actions for all file types in the Blazor File Manager component.

```cshtml

@using Syncfusion.Blazor.FileManager

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/FileOperations"
                                UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Upload"
                                DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Download"
                                GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerUploadSettings DropArea="null"></FileManagerUploadSettings>
</SfFileManager>

```