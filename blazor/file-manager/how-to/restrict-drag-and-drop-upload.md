---
layout: post
title: Prevent upload in Blazor FileManager Component | Syncfusion
description: Checkout and learn here all about prevent external upload in Syncfusion Blazor FileManager component and much more.
platform: Blazor
control: File Manager
documentation: ug
---

# Restrict drag and drop upload

In the Blazor FileManager component, you are able to prevent the external drag and drop upload action for any types of files or folders by setting the [DropArea](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerUploadSettings.html#Syncfusion_Blazor_FileManager_FileManagerUploadSettings_DropArea) property as `null` in the `FileManagerUploadSettings` class. 

The following example demonstrates how to prevent the external drag and drop upload actions for all types of files in the Blazor FileManager component.

```cshtml

@using Syncfusion.Blazor.FileManager

<SfFileManager @ref="FileManager" TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/FileOperations"
                                UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Upload"
                                DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Download"
                                GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerUploadSettings DropArea="null"></FileManagerUploadSettings>
    </FileManagerEvents>
</SfFileManager>

```