---
layout: post
title: Multiple File Selection in Blazor FileManager Component | Syncfusion
description: Checkout and learn here all about multiple file selection in Syncfusion Blazor FileManager component and more.
platform: Blazor
control: File Manager
documentation: ug
---

# Multiple File Selection in Blazor FileManager Component

The file manager allows you to select multiple files by enabling the `AllowMultiSelection` property (enabled by default). The multiple selection can be done by pressing the `Ctrl` key or `Shift` key and selecting the files. The check box can also be used to do multiple selection. `Ctrl + A` can be used to select all files in the current directory. The `FileSelected` event will be triggered when the items of file manager control is selected or unselected.

```cshtml

@using Syncfusion.Blazor.FileManager

<SfFileManager AllowMultiSelection="true" TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings  Url="/api/SampleData/FileOperations"
                                UploadUrl="/api/SampleData/Upload"
                                DownloadUrl="/api/SampleData/Download"
                                GetImageUrl="/api/SampleData/GetImage">
    </FileManagerAjaxSettings>
</SfFileManager>

```

## Output

After successful compilation of your application, simply press `F5` to run the application.

Output will be like the below.

![Blazor FileManager with Multiple Selection](images/blazor-filemanager-multi-selection.png)