---
layout: post
title: Toolbar in Blazor File Manager Component | Syncfusion
description: Checkout and learn here all about Toolbar module in Syncfusion Blazor File Manager component and much more.
platform: Blazor
control: File Manager
documentation: ug
---

# Toolbar in Blazor File Manager Component

The Toolbar in the File Manager provides a user-friendly interface for performing various file operations. It contains pre-defined items that correspond to specific actions. Here are some key points about the toolbar.

## Built-in Toolbar Items

By default, the File Manager includes several pre-defined toolbar items that are ready to use and come with associated actions. This collection can be modified by defining the required items in [FileManagerToolbarSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerToolbarSettings.html).

Some common built-in toolbar items include:

* `New Folder` - Creates a new folder in the current directory.
* `SortBy` - Allows users to sort files and folders based on different criteria (e.g., name, size, date modified).
* `Upload` - Enables users to upload files to the server.
* `Refresh` - Specifies the array of string that is used to configure file items.
* `View` - Specifies the array of string that is used to configure folder items.
* `Details` - Specifies the array of string that is used to configure layout items.

## Control Toolbar Visibility

The Toolbar visibility can be controlled using the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerToolbarSettings.html#Syncfusion_Blazor_FileManager_FileManagerToolbarSettings_Visible) property. Set this property to `false` to hide the toolbar. This property can also be toggled dynamically based on application logic.

```cshtml

@using Syncfusion.Blazor.FileManager

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/FileOperations"
                             UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Upload"
                             DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Download"
                             GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerToolbarSettings Visible=false></FileManagerToolbarSettings>
</SfFileManager>

```

## Events

The Blazor File Manager Toolbar component has a [ToolbarCreated](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_ToolbarCreated) and [ToolbarItemClicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_ToolbarItemClicked) events that can be triggered for certain actions. These events can be bound to the File Manager using the **FileManagerEvents**, which requires the **TValue** to be provided.

N> All events should be provided within a single **FileManagerEvents** component.

### ToolbarCreated

The [ToolbarCreated](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_ToolbarCreated) event of the Blazor File Manager component is triggered before the toolbar items are created.

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

The [ToolbarItemClicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_ToolbarItemClicked) event of the Blazor File Manager component is triggered when a toolbar item is clicked.

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