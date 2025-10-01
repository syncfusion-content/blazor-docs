---
layout: post
title: Multiple File Selection in Blazor File Manager Component | Syncfusion
description: Checkout and learn here all about multiple file selection in Syncfusion Blazor File Manager component and more.
platform: Blazor
control: File Manager
documentation: ug
---

# Multiple File Selection in Blazor File Manager Component

The File Manager allows the selection of multiple files by enabling the [`AllowMultiSelection`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.SfFileManager-1.html#Syncfusion_Blazor_FileManager_SfFileManager_1_AllowMultiSelection) property (enabled by default). Multiple selection can be done by pressing the `Ctrl` or `Shift` key while selecting files. Checkboxes can also be used for multiple selection. `Ctrl + A` can be used to select all files in the current directory. The [`FileSelected`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_FileSelected) event is triggered when items in the File Manager control are selected or unselected.

```cshtml

@using Syncfusion.Blazor.FileManager

<SfFileManager AllowMultiSelection="true" TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/FileOperations"
                         UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Upload"
                         DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Download"
                         GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/GetImage">
</FileManagerAjaxSettings>
</SfFileManager>

```

## Output

After successful compilation, the application can be run by pressing `F5`.



![Blazor File Manager with Multiple Selection](images/blazor-filemanager-multi-selection.png)

## Getting Selected Files

In the Blazor File Manager component, the details of selected files or folders can be retrieved using the [GetSelectedFiles](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.SfFileManager-1.html#Syncfusion_Blazor_FileManager_SfFileManager_1_GetSelectedFiles) method.

Additionally, these details can be obtained through the [FileDetails](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileSelectionEventArgs-1.html#Syncfusion_Blazor_FileManager_FileSelectionEventArgs_1_FileDetails) argument of the [FileSelection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_FileSelection) event.

```cshtml

@using Syncfusion.Blazor.FileManager
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="GetSelectedFiles">ClickToGetSelectedFiles</SfButton>
<SfFileManager @ref="FileManager" AllowMultiSelection="false" TValue="FileManagerDirectoryContent">
        <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/FileOperations"
                                 UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Upload"
                                 DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Download"
                                 GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/GetImage">
        </FileManagerAjaxSettings>
        <FileManagerEvents TValue="FileManagerDirectoryContent" FileSelection="FileSelection"></FileManagerEvents>
</SfFileManager>

@code {
    SfFileManager<FileManagerDirectoryContent>? FileManager;
    public void FileSelection(FileSelectionEventArgs<FileManagerDirectoryContent> args)
    {
        var SelectedFiles = args.FileDetails;
    }
    List<FileManagerDirectoryContent> SelectedFiles = new List<FileManagerDirectoryContent>();
    public void GetSelectedFiles()
    {
        SelectedFiles = this.FileManager?.GetSelectedFiles();
    }
}

```

## Prevent Selection for Specific Files/Folders

In the Blazor File Manager component, selection of specific files or folders can be prevented by setting the [FileSelection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_FileSelection) event's [Cancel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileSelectionEventArgs-1.html#Syncfusion_Blazor_FileManager_FileSelectionEventArgs_1_Cancel) argument value to `true`.

For example, in the following example, selection is prevented for the **Music** folder.


```cshtml

@using Syncfusion.Blazor.FileManager

<SfFileManager TValue="FileManagerDirectoryContent">
        <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/FileOperations"
                                 UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Upload"
                                 DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Download"
                                 GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/GetImage">
        </FileManagerAjaxSettings>
        <FileManagerEvents TValue="FileManagerDirectoryContent" FileSelection="FileSelection"></FileManagerEvents>
</SfFileManager>

@code {
    public void FileSelection(FileSelectionEventArgs<FileManagerDirectoryContent> args)
    {
        if (args.FileDetails.Name=="Music")
        {
            args.Cancel = true;
        }
    }
}

```

## Range Selection

The File Manager supports selecting files and folders in specific ranges through mouse drag, similar to File Explorer. This is useful in scenarios where there is a need to select a large group of files quickly without manually clicking each one.

### Enabling Range Selection

To enable range selection, set the [EnableRangeSelection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.SfFileManager-1.html#Syncfusion_Blazor_FileManager_SfFileManager_1_EnableRangeSelection) property to `true` and ensure that multi-selection is allowed using the [AllowMultiSelection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.SfFileManager-1.html#Syncfusion_Blazor_FileManager_SfFileManager_1_AllowMultiSelection) property.

````cshtml
@using Syncfusion.Blazor.FileManager;
<div class="control-section">
    <div class="control_wrapper">
        <SfFileManager @ref="File" TValue="FileManagerDirectoryContent" AllowMultiSelection="true" EnableRangeSelection="true">
            <FileManagerAjaxSettings Url="https://amazons3.azurewebsites.net/api/AmazonS3Provider/AmazonS3Fileoperations"
                                     UploadUrl="https://amazons3.azurewebsites.net/api/AmazonS3Provider/AmazonS3Upload"
                                     DownloadUrl="https://amazons3.azurewebsites.net/api/AmazonS3Provider/AmazonS3Download"
                                     GetImageUrl="https://amazons3.azurewebsites.net/api/AmazonS3Provider/AmazonS3GetImage">
            </FileManagerAjaxSettings>
        </SfFileManager>
    </div>
</div>
````

## Events

The Blazor File Manager component includes `FileSelection` and `FileSelected` events which are triggered during file selection and after a file has been selected, respectively. These events can be bound to the File Manager using the **FileManagerEvents**, which requires the **TValue** to be provided.

N> All events should be provided in a single **FileManagerEvents** component.

### FileSelection

The [FileSelection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_FileSelection) event of the Blazor File Manager component is triggered before a file or folder is selected.

```cshtml

@using Syncfusion.Blazor.FileManager

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/FileOperations"
                             UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Upload"
                             DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Download"
                             GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerEvents TValue="FileManagerDirectoryContent" FileSelection="FileSelection">
    </FileManagerEvents>
</SfFileManager>

@code {
    public void FileSelection(FileSelectionEventArgs<FileManagerDirectoryContent> args)
    {
        // Here, you can customize your code.
    }
}

```

### FileSelected

The [FileSelected](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_FileSelected) event of the Blazor File Manager component is triggered when the file or folder is selected or unselected.

```cshtml

@using Syncfusion.Blazor.FileManager

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/FileOperations"
                             UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Upload"
                             DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Download"
                             GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerEvents TValue="FileManagerDirectoryContent" FileSelected="FileSelected"></FileManagerEvents>
</SfFileManager>

@code {
    public void FileSelected(FileSelectEventArgs<FileManagerDirectoryContent> args)
    {
        // Here, you can customize your code.
    }
}

```