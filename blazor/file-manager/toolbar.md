---
layout: post
title: Toolbar in Blazor File Manager Component | Syncfusion®
description: Checkout and learn here all the details about Toolbar module in Blazor File Manager component and much more details.
platform: Blazor
control: File Manager
documentation: ug
---

# Toolbar in Blazor File Manager Component

The Toolbar in the File Manager provides a user-friendly interface for performing various file operations. It contains pre-defined items that correspond to specific actions. Here are some key points about the toolbar.

## Built-in Toolbar items

By default, the File Manager includes several pre-defined toolbar items. These items are ready to use and come with associated actions. This collection can be modified by defining the required items in [FileManagerToolbarSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerToolbarSettings.html).

Some common built-in toolbar items include:

* `NewFolder` — Creates a new folder in the current directory.
* `SortBy` — Allows users to sort files and folders by name, size, date modified, or custom criteria.
* `Upload` — Opens the file upload dialog to upload files to the server.
* `Refresh` — Reloads the file list from the server and refreshes the current directory view.
* `View` — Toggles between different view modes (e.g., details, icons, list view).
* `Details` — Switches to detailed list view showing file properties (size, date modified, etc.).
* `Download` — Downloads selected files to the local machine.
* `Delete` — Deletes selected files and folders.
* `Rename` — Enables renaming of selected files and folders.

## Customize Toolbar Items

You can customize which toolbar items appear by setting the [Items](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerToolbarSettings.html#Syncfusion_Blazor_FileManager_FileManagerToolbarSettings_Items) property in [FileManagerToolbarSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerToolbarSettings.html). Pass a comma-separated list of toolbar item names to display only those items. Refer to the built-in items list above for available item names.

```cshtml

@using Syncfusion.Blazor.FileManager

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="https://physical-service.syncfusion.com/api/FileManager/FileOperations"
                             UploadUrl="https://physical-service.syncfusion.com/api/FileManager/Upload"
                             DownloadUrl="https://physical-service.syncfusion.com/api/FileManager/Download"
                             GetImageUrl="https://physical-service.syncfusion.com/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerToolbarSettings Items="@ToolbarItems"></FileManagerToolbarSettings>
</SfFileManager>

@code {
    private string[] ToolbarItems = new string[] { "NewFolder", "Upload", "Download", "Delete", "Refresh", "SortBy", "View" };
}

```

## Control Toolbar Visibility

The toolbar visibility can be controlled using the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerToolbarSettings.html#Syncfusion_Blazor_FileManager_FileManagerToolbarSettings_Visible) property. Set this property to `false` to hide the toolbar, or toggle it dynamically based on your application logic.

```cshtml

@using Syncfusion.Blazor.FileManager

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="https://physical-service.syncfusion.com/api/FileManager/FileOperations"
                             UploadUrl="https://physical-service.syncfusion.com/api/FileManager/Upload"
                             DownloadUrl="https://physical-service.syncfusion.com/api/FileManager/Download"
                             GetImageUrl="https://physical-service.syncfusion.com/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerToolbarSettings Visible="false"></FileManagerToolbarSettings>
</SfFileManager>

```

## Events

The Blazor File Manager Toolbar component provides two primary events:
- [ToolbarCreated](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_ToolbarCreated) — Triggered before the toolbar is initialized.
- [ToolbarItemClicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_ToolbarItemClicked) — Triggered when a toolbar item is clicked.

These events are bound to the File Manager using the [FileManagerEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html) component, which requires the **TValue** generic parameter.

> **Important:** All events should be provided within a single **FileManagerEvents** component.

### ToolbarCreated

The [ToolbarCreated](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_ToolbarCreated) event of the Blazor File Manager component is triggered before creating the toolbar items.

```cshtml

@using Syncfusion.Blazor.FileManager

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="https://physical-service.syncfusion.com/api/FileManager/FileOperations"
                             UploadUrl="https://physical-service.syncfusion.com/api/FileManager/Upload"
                             DownloadUrl="https://physical-service.syncfusion.com/api/FileManager/Download"
                             GetImageUrl="https://physical-service.syncfusion.com/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerEvents TValue="FileManagerDirectoryContent" ToolbarCreated="OnToolbarCreated"></FileManagerEvents>
</SfFileManager>

@code {
    private void OnToolbarCreated(ToolbarCreateEventArgs args)
    {
        // Customize toolbar before it renders
        Console.WriteLine("Toolbar created");
    }
}

```

### ToolbarItemClicked

The [ToolbarItemClicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_ToolbarItemClicked) event is triggered when a toolbar item is clicked. Use this event to perform custom actions or prevent default behavior.

**Event Arguments ([ToolbarClickEventArgs<TValue>](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.ToolbarClickEventArgs-1.html)):**
- `Item` — The clicked toolbar item name (e.g., "Upload", "Download").
- `Cancel` — Set to `true` to prevent the default toolbar action.

```cshtml

@using Syncfusion.Blazor.FileManager

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="https://physical-service.syncfusion.com/api/FileManager/FileOperations"
                             UploadUrl="https://physical-service.syncfusion.com/api/FileManager/Upload"
                             DownloadUrl="https://physical-service.syncfusion.com/api/FileManager/Download"
                             GetImageUrl="https://physical-service.syncfusion.com/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerEvents TValue="FileManagerDirectoryContent" ToolbarItemClicked="OnToolbarItemClicked"></FileManagerEvents>
</SfFileManager>

@code {
    private void OnToolbarItemClicked(ToolbarClickEventArgs<FileManagerDirectoryContent> args)
    {
        // Handle toolbar item clicks
        Console.WriteLine($"Toolbar item clicked: {args.Item}");
        
        // Optionally prevent default action
        if (args.Item == "Delete")
        {
            // Custom delete logic
            args.Cancel = true;
        }
    }
}

```

## See Also

* [FileManagerToolbarSettings API Reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerToolbarSettings.html)

* [FileManagerEvents API Reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html)

* [Adding Custom Item To Toolbar](https://blazor.syncfusion.com/documentation/file-manager/how-to/add-custom-tool-bar)