---
layout: post
title: Views in Blazor FileManager Component | Syncfusion
description: Checkout and learn here all about available Views module in Syncfusion Blazor FileManager component and much more.
platform: Blazor
control: File Manager
documentation: ug
---

# Views in Blazor FileManager component

The Blazor FileManager component provides both the `Large Icons View` for visual recognition and the `Details View` for organized information.

## Large Icons View

The `Large Icons View` is the default starting view in the FileManager. The view can be changed by using the [Toolbar](./end-user-capabilities.md/#toolbar) view button or by using the view menu in [Context Menu](./end-user-capabilities.md/#context-menu). The [View](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.SfFileManager-1.html#Syncfusion_Blazor_FileManager_SfFileManager_1_View) API can also be used to change the initial view of the FileManager.

In the large icons view, the thumbnail icons will be shown in a larger size, which displays the data in a form that best suits their content. For image type files, a **preview** will be displayed. Extension thumbnails will be displayed for other type files.

## Details View

In the details view, the files are displayed in a sorted list order. This file list comprises of several columns of information about the files such as **Name**, **Date Modified**, **Type**, and **Size**. Each file has its own small icon representing the file type. Additional columns can be added using [DetailsViewSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerDetailsViewSettings.html) API. The details view allows you to perform sorting using column header.

### Define custom columns

To add a custom column to the details view, use the [FileManagerColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerColumn.html) from the `Syncfusion.Blazor.FileManager` namespace. Here's an example:

```cshtml

@using Syncfusion.Blazor.FileManager

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/FileOperations"
                             UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Upload"
                             DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Download"
                             GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerDetailsViewSettings>
        <FileManagerColumns>
            <FileManagerColumn Field="Name" HeaderText="Name"></FileManagerColumn>
            <FileManagerColumn Field="Size" HeaderText="Size"></FileManagerColumn>
            <FileManagerColumn Field="DateModified" HeaderText="DateModified"></FileManagerColumn>
            <FileManagerColumn Field="Type">
                <HeaderTemplate>
                    <span>Category</span>
                </HeaderTemplate>
                <Template>
                    @{
                        var data = (context as FileManagerDirectoryContent);
                        <div>@data.Type</div>
                    }
                </Template>
            </FileManagerColumn>
        </FileManagerColumns>
    </FileManagerDetailsViewSettings>
</SfFileManager>

```

### Customize existing column format

The details view settings like, column [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerColumn.html#Syncfusion_Blazor_FileManager_FileManagerColumn_Width), [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerColumn.html#Syncfusion_Blazor_FileManager_FileManagerColumn_Format), [HeaderText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerColumn.html#Syncfusion_Blazor_FileManager_FileManagerColumn_HeaderText), [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerColumn.html#Syncfusion_Blazor_FileManager_FileManagerColumn_Template) for each field can be customized using [FileManagerColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerColumn.html) property.

```cshtml

@using Syncfusion.Blazor.FileManager

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/FileOperations"
                             UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Upload"
                             DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Download"
                             GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerDetailsViewSettings>
        <FileManagerColumns>
            <FileManagerColumn Field="Name">
                <HeaderTemplate><span class="e-headertext">Name</span></HeaderTemplate>
                <Template>
                    @{
                        var data = (context as FileManagerDirectoryContent);
                        <div><span class="e-fe-text">@data!.Name</span></div>
                    }
                </Template>
            </FileManagerColumn>
            <FileManagerColumn Field="Size" HeaderText="Size" MinWidth="50" Width="110"></FileManagerColumn>
            <FileManagerColumn Field="DateModified" HeaderText="DateModified" Format="MM/dd/yyyy h:mm tt"></FileManagerColumn>
        </FileManagerColumns>
    </FileManagerDetailsViewSettings>
</SfFileManager>

```

