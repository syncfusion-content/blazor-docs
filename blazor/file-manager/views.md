---
layout: post
title: Views in Blazor File Manager Component | Syncfusion
description: Checkout and learn here all about available Views module in Syncfusion Blazor File Manager component and much more.
platform: Blazor
control: File Manager
documentation: ug
---

# Views in Blazor File Manager component

The Blazor File Manager component provides both the `Large Icons View` for visual recognition and the `Details View` for organized information.

## Large Icons View

The `Large Icons View` is the default starting view in the FileManager. The view can be changed by using the [Toolbar](https://blazor.syncfusion.com/documentation/file-manager/file-operations#toolbar) view button or by using the view menu in [Context Menu](https://blazor.syncfusion.com/documentation/file-manager/context-menu). The [View](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.SfFileManager-1.html#Syncfusion_Blazor_FileManager_SfFileManager_1_View) API can also be used to change the initial view of the FileManager.

In the large icons view, the thumbnail icons will be shown in a larger size, which displays the data in a form that best suits their content. For image type files, a **preview** will be displayed. Extension thumbnails will be displayed for other type files.

### Customize existing Large Icons View

The large icons view layout can be customized using the `LargeIconsTemplate` property, which allows you to display file or folder information, apply custom formatting, and use conditional rendering based on item type. You can customize it further based on your application requirements.

```cshtml

@using Syncfusion.Blazor.FileManager;
<SfFileManager TValue="FileManagerDirectoryContent" CssClass="e-fm-template-sample">
    <ChildContent>
        <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/FileOperations"
                                 UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Upload"
                                 DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Download"
                                 GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/GetImage">
        </FileManagerAjaxSettings>
    </ChildContent>
    <LargeIconsTemplate Context="item">
        @if (item is not null)
        {
            <div class="custom-icon-card">
                <div class="file-header">
                    <div class="file-name" title="@item.Name">@item.Name</div>
                </div>
                <div class="@GetFileTypeCssClass(item)"></div>
                <div class="file-formattedDate">Created on @item.DateCreated.ToString("MMMM d, yyyy")</div>
            </div>
        }
    </LargeIconsTemplate>
</SfFileManager>

@code {
    private string GetFileTypeCssClass(FileManagerDirectoryContent item)
    {
        if (!item.IsFile)
        {
            return $"e-list-icon e-fe-folder";
        }
        var ext = System.IO.Path.GetExtension(item.Name)?.TrimStart('.') ?? string.Empty;
        var type = ExtensionIconClassMap.GetValueOrDefault(ext, "unknown");
        return $"e-list-icon e-fe-{type}";
    }
    private static readonly Dictionary<string, string> ExtensionIconClassMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        { "jpg", "image" }, { "jpeg", "image" }, { "png", "image" }, { "gif", "image" },
        { "mp3", "music" }, { "wav", "music" }, { "mp4", "video" }, { "avi", "video" },
        { "xlsx", "xlsx" }, { "xls", "xlsx" }, { "pptx", "pptx" }, { "ppt", "pptx" },
        { "rar", "rar" }, { "zip", "zip" }, { "txt", "txt" }, { "js", "js" },
        { "css", "css" }, { "html", "html" }, { "exe", "exe" }, { "msi", "msi" },
        { "php", "php" }, { "doc", "doc" }, { "docx", "docx" }, { "xml", "xml" },
        { "pdf", "pdf" }
    };
}
<style>
    .e-fm-template-sample .custom-icon-card {
        padding: 8px;
        border: 1px solid #ccc;
        border-radius: 10px;
        height: 100%;
        box-sizing: border-box;
        display: flex;
        flex-direction: column;
        justify-content: flex-start;
        align-items: center;
    }

    .e-fm-template-sample .file-header {
        display: contents;
        align-items: center;
        width: 100%;
        margin-bottom: 10px;
    }

    .e-fm-template-sample .file-name {
        font-size: 14px;
        font-weight: 600;
        white-space: nowrap;
        overflow: hidden;
        text-overflow: ellipsis;
        max-width: 110px;
    }

    .e-fm-template-sample .file-formattedDate {
        font-size: 12px;
        margin-top: 8px;
        text-align: center;
        font-weight: 600;
    }

    .e-filemanager.e-fm-template-sample .e-large-icons .e-list-item {
        height: 150px;
        width: 135px;
    }
</style>

```

## Details View

In the details view, the files are displayed in a sorted list order. This file list comprises of several columns of information about the files such as **Name**, **Date Modified**, **Type**, and **Size**. Each file has its own small icon representing the file type. Additional columns can be added using [DetailsViewSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerDetailsViewSettings.html) API. The details view allows you to perform sorting using column header.

### Define custom columns

To add a custom column to the details view, use the [FileManagerColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerColumn.html) from the `Syncfusion.Blazor.FileManager` namespace. Here's an example:

```cshtml

@using Syncfusion.Blazor.FileManager

<SfFileManager TValue="FileManagerDirectoryContent" View="ViewType.Details">
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

<SfFileManager TValue="FileManagerDirectoryContent" View="ViewType.Details">
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

