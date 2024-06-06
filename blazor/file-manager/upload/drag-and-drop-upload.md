---
layout: post
title: External upload in Blazor FileManager Component | Syncfusion
description: Checkout and learn here all about external upload in Syncfusion Blazor FileManager component and much more.
platform: Blazor
control: File Manager
documentation: ug
---

# Drag and Drop upload

The Blazor FileManager component allows you to easily perform drag and drop file uploads. You can drag files from your local file system and drop them directly into the FileManager. Additionally, you have the ability to customize the drop area for file uploads using the [DropArea](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerUploadSettings.html#Syncfusion_Blazor_FileManager_FileManagerUploadSettings_DropArea) property in the `FileManagerUploadSettings` class.

```cshtml

@using Syncfusion.Blazor.FileManager

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/FileOperations"
                             UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Upload"
                             DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Download"
                             GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerUploadSettings DropArea=".e-layout-content"></FileManagerUploadSettings>
</SfFileManager>

```