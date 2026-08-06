---
layout: post
title: Restrict drag and drop upload in Blazor File Manager | Syncfusion
description: Learn how to disable the external drag and drop upload action for any types of files or folders in the Blazor File Manager.
control: File Manager
platform: Blazor
documentation: ug
---

# How to Restrict Drag and Drop Upload in Blazor File Manager

In the [Blazor File Manager](https://www.syncfusion.com/blazor-components/blazor-file-manager) component, you are able to prevent the external drag and drop upload action for any types of files or folders by setting the [DropArea](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerUploadSettings.html#Syncfusion_Blazor_FileManager_FileManagerUploadSettings_DropArea) property as `@null` in the [`FileManagerUploadSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerUploadSettings.html) class. 

The following example demonstrates how to prevent the external drag and drop upload actions for all types of files in the Blazor File Manager component.

```cshtml

@using Syncfusion.Blazor.FileManager

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="https://physical-service.syncfusion.com/api/FileManager/FileOperations"
                                UploadUrl="https://physical-service.syncfusion.com/api/FileManager/Upload"
                                DownloadUrl="https://physical-service.syncfusion.com/api/FileManager/Download"
                                GetImageUrl="https://physical-service.syncfusion.com/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerUploadSettings DropArea="@null"></FileManagerUploadSettings>
</SfFileManager>

```
