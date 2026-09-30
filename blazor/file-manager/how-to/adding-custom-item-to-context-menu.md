---
layout: post
title: Adding Custom Item to Context Menu in File Manager | Syncfusion®
description: Learn here all about adding custom item to context menu in Blazor File Manager component and much more details.
platform: Blazor
control: File Manager
documentation: ug
---

# Adding Custom Item to Context Menu in Blazor File Manager Component

The context menu can be customized using the [`ContextMenuSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerContextMenuSettings.html), [`MenuOpened`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_MenuOpened), and [`OnMenuClick`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_OnMenuClick) events.

The following example adds a custom item to the file, folder, and layout context menus. The `FileManagerContextMenuSettings` component adds the item, the `MenuOpened` event adds its icon, and the `OnMenuClick` event handles its selection.

```cshtml

@using Syncfusion.Blazor.FileManager

    <SfFileManager TValue="FileManagerDirectoryContent">
        <FileManagerAjaxSettings Url="/api/SampleData/FileOperations"
                                 UploadUrl="/api/SampleData/Upload"
                                 DownloadUrl="/api/SampleData/Download"
                                 GetImageUrl="/api/SampleData/GetImage">
        </FileManagerAjaxSettings>
        <FileManagerContextMenuSettings File="@Items" Folder="@Items"></FileManagerContextMenuSettings>
    </SfFileManager>

@code {
    SfFileManager<FileManagerDirectoryContent>? FileManager;
    public string[] Items = new string[] { "Open", "|", "Delete", "Download", "Rename", "|", "Details", "Custom" };
}

```

## Run the application

After your application compiles successfully, press `F5` to run it.

![Blazor File Manager with Custom Context Menu](../images/blazor-filemanager-custom-context-menu.webp)