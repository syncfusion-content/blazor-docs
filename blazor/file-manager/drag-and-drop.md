# Drag and Drop

The file manager allows files and folders to be moved within the file system by drag and dropping them. This support can be enabled or disabled using the [AllowDragAndDrop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.SfFileManager-1.html#Syncfusion_Blazor_FileManager_SfFileManager_1_AllowDragAndDrop) property of the file manager.

The events which trigger when using drag and drop functionality are listed below.

* `OnFileDragStart` - Triggers when the file/folder dragging is started.
* `OnFileDragStop` - Triggers when the file/folder is about to be dropped at the target.
* `FileDropped` - Triggers when the file/folder is dropped.

```csharp

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

Output be like the below.

![Drag and drop](images/drag-and-drop.gif)