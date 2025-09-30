---
layout: post
title: Adding Custom Item to Context Menu in Blazor File Manager | Syncfusion
description: Learn here all about adding custom item to context menu in Syncfusion Blazor File Manager component and more.
platform: Blazor
control: File Manager
documentation: ug
---

# Adding Custom Item to Context Menu in Blazor File Manager Component

The context menu in the Blazor File Manager can be customized by configuring its [`ContextMenuSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerContextMenuSettings.html), [`MenuOpened`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_MenuOpened) and [`OnMenuClick`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_OnMenuClick) events.

The following example demonstrates how to add a custom item to the context menu. The `ContextMenuSettings` property is used to define the new menu item and its position. The `MenuOpened` event is then utilized to dynamically add an icon to the custom menu item before the menu is displayed. Finally, the `OnMenuClick` event is used to add an event handler to the new menu item.

```cshtml

@using Syncfusion.Blazor.FileManager

    <SfFileManager TValue="FileManagerDirectoryContent">
        <FileManagerAjaxSettings Url="/api/SampleData/FileOperations"
                                 UploadUrl="/api/SampleData/Upload"
                                 DownloadUrl="/api/SampleData/Download"
                                 GetImageUrl="/api/SampleData/GetImage">
        </FileManagerAjaxSettings>
        <FileManagerContextMenuSettings  File="@Items" Folder="@Items"></FileManagerContextMenuSettings>
    </SfFileManager>

@code {
    public string[] Items = new string[] { "Open", "|", "Delete", "Download", "Rename", "|", "Details", "Custom" };
}

```

## Run the application

After successful compilation of the application, simply press `F5` to run it.



![Blazor File Manager displays Custom Context Menu Item](../images/blazor-filemanager-custom-context-menu.png)