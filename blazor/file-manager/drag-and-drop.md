---
layout: post
title: Drag and Drop in Blazor FileManager Component | Syncfusion
description: Checkout and learn here all about drag and drop in Syncfusion Blazor FileManager component and more.
platform: Blazor
control: File Manager
documentation: ug
---

# Drag and Drop in Blazor FileManager Component

The file manager allows files and folders to be moved within the file system by drag and dropping them. This support can be enabled or disabled using the [AllowDragAndDrop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.SfFileManager-1.html#Syncfusion_Blazor_FileManager_SfFileManager_1_AllowDragAndDrop) property of the file manager.

The events which trigger when using drag and drop functionality are listed below.

* `OnFileDragStart` - Triggers when the file/folder dragging is started.
* `OnFileDragStop` - Triggers when the file/folder is about to be dropped at the target.
* `FileDropped` - Triggers when the file/folder is dropped.

```cshtml

@using Syncfusion.Blazor.FileManager

<SfFileManager AllowDragAndDrop="true" TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings  Url="/api/SampleData/FileOperations"
                                UploadUrl="/api/SampleData/Upload"
                                DownloadUrl="/api/SampleData/Download"
                                GetImageUrl="/api/SampleData/GetImage">
    </FileManagerAjaxSettings>
</SfFileManager>

```

## Output

After successful compilation of your application, simply press `F5` to run the application.



![Drag and Drop in Blazor FileManager](images/blazor-filemanager-drag-and-drop.gif)