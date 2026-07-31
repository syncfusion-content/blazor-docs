---
layout: post
title: Drag and Drop in Blazor File Manager Component | Syncfusion®
description: Checkout and learn here all about drag and drop in Blazor File Manager component and much more details.
platform: Blazor
control: File Manager
documentation: ug
---

# Drag and Drop in Blazor File Manager Component

The File Manager allows files and folders to be moved within the file system by drag and dropping them. This support can be enabled or disabled using the [AllowDragAndDrop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.SfFileManager-1.html#Syncfusion_Blazor_FileManager_SfFileManager_1_AllowDragAndDrop) property of the File Manager.

## Enabling Drag and Drop

Set the `AllowDragAndDrop` property to `true` to enable drag-and-drop functionality:

```cshtml
<SfFileManager AllowDragAndDrop="true" TValue="FileManagerDirectoryContent">
    ...
</SfFileManager>
```

## Drag and Drop Events

The following events trigger during drag and drop operations:

* [`OnFileDragStart`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_OnFileDragStart) - Triggers when file/folder dragging starts.
* [`OnFileDragStop`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_OnFileDragStop) - Triggers when file/folder is about to be dropped.
* [`FileDropped`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_FileDropped) - Triggers when file/folder is successfully dropped.

## Complete Example

```cshtml
@using Syncfusion.Blazor.FileManager

<SfFileManager @ref="FileManagerRef" AllowDragAndDrop="true" TValue="FileManagerDirectoryContent">
    <FileManagerEvents TValue="FileManagerDirectoryContent"
                       OnFileDragStart="@OnDragStart"
                       OnFileDragStop="@OnDragStop"
                       FileDropped="@OnDropped">
    </FileManagerEvents>
    <FileManagerAjaxSettings Url="/api/SampleData/FileOperations"
                             UploadUrl="/api/SampleData/Upload"
                             DownloadUrl="/api/SampleData/Download"
                             GetImageUrl="/api/SampleData/GetImage">
    </FileManagerAjaxSettings>
</SfFileManager>

@code {
    private SfFileManager<FileManagerDirectoryContent> FileManagerRef { get; set; }

    private void OnDragStart(FileManagerEventArgs args)
    {
        Console.WriteLine($"Dragging: {args.FileDetails[0].Name}");
    }

    private void OnDragStop(FileManagerEventArgs args)
    {
        Console.WriteLine($"Drop target: {args.DropPath}");
    }

    private void OnDropped(FileManagerEventArgs args)
    {
        Console.WriteLine($"Dropped successfully at: {args.DropPath}");
    }
}
```

## Prerequisites

- Syncfusion.Blazor.FileManager NuGet package
- Server-side API endpoints configured for file operations
- .NET 6.0 or later

## How It Works

When drag-and-drop is enabled:
1. User clicks and holds on a file/folder to begin dragging
2. The `OnFileDragStart` event fires
3. User moves cursor to target location and the `OnFileDragStop` event fires
4. Upon release, the `FileDropped` event fires and the file is moved to the target location

## Output

After compiling your application, run it with `F5`. You can then drag files and folders within the File Manager interface.

![Drag and Drop in Blazor FileManager](images/blazor-filemanager-drag-and-drop.webp)

## Video Reference

For a practical demonstration of drag-and-drop and multi-selection configuration, watch this video:

{% youtube
"youtube:https://www.youtube.com/watch?v=KU3RwdzDvJ0" %}
