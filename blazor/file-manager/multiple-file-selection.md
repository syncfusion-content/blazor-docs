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



![Blazor FileManager with Multiple Selection](images/blazor-filemanager-multi-selection.png)

## Getting Selected Files

In the Blazor FileManager component, you can retrieve the details of the selected files or folders using the [GetSelectedFiles](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.SfFileManager-1.html#Syncfusion_Blazor_FileManager_SfFileManager_1_GetSelectedFiles) method. 

Additionally, you can obtain these details through the [FileDetails](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileSelectionEventArgs-1.html#Syncfusion_Blazor_FileManager_FileSelectionEventArgs_1_FileDetails) argument of the [FileSelection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_FileSelection) event.

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

In the Blazor FileManager component, you are able to prevent selection of specific files or folders by setting the [FileSelection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_FileSelection) event's [Cancel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileSelectionEventArgs-1.html#Syncfusion_Blazor_FileManager_FileSelectionEventArgs_1_Cancel) argument value to **true**. 

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

## Events

The Blazor FileManager component includes FileSelection and FileSelected events which are triggered during file selection and after a file has been selected, respectively. These events can be bound to the FileManager using the **FileManagerEvents**, which requires the **TValue** to be provided.

N> All the events should be provided in a single **FileManagerEvents** component.

### FileSelection

The [FileSelection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_FileSelection) event of the Blazor FileManager component is triggered before a file or folder is selected.

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

The [FileSelected](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_FileSelected) event of the Blazor FileManager component is triggered when the file or folder is selected or unselected.

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