---
layout: post
title: Toolbar in Blazor FileManager Component | Syncfusion
description: Checkout and learn here all about Toolbar in Syncfusion Blazor FileManager component and much more.
platform: Blazor
control: File Manager
documentation: ug
---

# Toolbar in Blazor FileManager Component

The Toolbar in the File Manager provides a user-friendly interface for performing various file operations. It contains pre-defined items that correspond to specific actions. Here are some key points about the toolbar.

## Built-in Toolbar items

By default, the File Manager includes several pre-defined toolbar items. These items are ready to use and come with associated actions. This collection can be modified by defining the required items in [FileManagerToolbarSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerToolbarSettings.html).

Some common built-in toolbar items include:

* `New Folder` - Creates a new folder in the current directory.
* `SortBy` - Allows users to sort files and folders based on different criteria (e.g., name, size, date modified).
* `Upload` - Enables users to upload files to the server.
* `Refresh` - Specifies the array of string that is used to configure file items.
* `View` - Specifies the array of string that is used to configure folder items.
* `Details` - Specifies the array of string that is used to configure layout items.

## Control Toolbar visibility

The Toolbar visibility can also be controlled by using the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerToolbarSettings.html#Syncfusion_Blazor_FileManager_FileManagerToolbarSettings_Visible) property. Set this property as false to hide the toolbar. You can also toggle this property dynamically based on your application logic.

## Events

The Blazor FileManager Toolbar component has a [ToolbarCreated](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_ToolbarCreated) and [ToolbarItemClicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_ToolbarItemClicked) events that can be triggered for certain actions. These events can be bound to the FileManager using the **FileManagerEvents**, which requires the **TValue** to be provided.

N> All the events should be provided in a single **FileManagerEvents** component.

### ToolbarCreated

The [ToolbarCreated](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_ToolbarCreated) event of the Blazor FileManager component is triggered before creating the toolbar items.

```cshtml

@using Syncfusion.Blazor.FileManager

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/FileOperations"
                             UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Upload"
                             DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Download"
                             GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerEvents TValue="FileManagerDirectoryContent" ToolbarCreated="ToolbarCreated"></FileManagerEvents>
</SfFileManager>

@code {
    public void ToolbarCreated(ToolbarCreateEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```

### ToolbarItemClicked

The [ToolbarItemClicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_ToolbarItemClicked) event of the Blazor FileManager component is triggered when the toolbar item is clicked.

```cshtml

@using Syncfusion.Blazor.FileManager

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/FileOperations"
                             UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Upload"
                             DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Download"
                             GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerEvents TValue="FileManagerDirectoryContent" ToolbarItemClicked="ToolbarItemClicked"></FileManagerEvents>
</SfFileManager>

@code {
    public void OnMenuClick(ToolbarClickEventArgs<FileManagerDirectoryContent> args)
    {
        // Here, you can customize your code.
    }
}

```

## See Also

[Adding Custom Item To Toolbar](https://blazor.syncfusion.com/documentation/file-manager/how-to/add-custom-tool-bar)