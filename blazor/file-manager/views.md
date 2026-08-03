---
layout: post
title: Views in Blazor File Manager Component | Syncfusion®
description: Checkout and learn here all about available Views module in Blazor File Manager component and much more details.
platform: Blazor
control: File Manager
documentation: ug
---

# Views in Blazor File Manager component

The [Blazor File Manager](https://www.syncfusion.com/blazor-components/blazor-file-manager) component provides two view modes: **Large Icons View** for visual file recognition and **Details View** for organized information.

## Prerequisites

- Syncfusion Blazor FileManager NuGet package installed
- `using Syncfusion.Blazor.FileManager` namespace imported
- Backend AJAX service configured (FileOperations, Upload, Download, GetImage endpoints)
- .NET 6.0 or later; Blazor WebAssembly or Server-side Blazor

## View Types Overview

| View Type | Default | Use Case | Display |
|-----------|---------|----------|---------|
| **Large Icons** | Yes | Visual browsing, image/media preview | Large thumbnails/icons |
| **Details** | — | Data-driven workflows, sorting/filtering | Tabular column-based list |

## Large Icons View

The `Large Icons View` is the default view in FileManager. Change views using:
- The toolbar view button  
- The context menu
- Programmatically via the [View](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.SfFileManager-1.html#Syncfusion_Blazor_FileManager_SfFileManager_1_View) property

In Large Icons View, files display with large thumbnails. Image files show preview thumbnails; other file types display extension-based icons. 

### Customize Large Icons View

The `LargeIconsTemplate` property customizes the display of each file/folder. This template accepts a `FileManagerDirectoryContent` context item and allows you to render custom HTML, apply CSS classes, and conditionally display information based on file type.

```cshtml

@using Syncfusion.Blazor.FileManager

<SfFileManager TValue="FileManagerDirectoryContent" View="ViewType.LargeIcons" CssClass="custom-fm-sample">
    <FileManagerAjaxSettings Url="https://physical-service.syncfusion.com/api/FileManager/FileOperations"
                             UploadUrl="https://physical-service.syncfusion.com/api/FileManager/Upload"
                             DownloadUrl="https://physical-service.syncfusion.com/api/FileManager/Download"
                             GetImageUrl="https://physical-service.syncfusion.com/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
    <LargeIconsTemplate Context="item">
        <div class="custom-icon-card">
            <div class="file-icon @GetFileTypeCssClass(item)"></div>
            <div class="file-name" title="@item.Name">@item.Name</div>
            <div class="file-date">@item.DateModified?.ToString("MMM d, yyyy")</div>
        </div>
    </LargeIconsTemplate>
</SfFileManager>

@code {
    private string GetFileTypeCssClass(FileManagerDirectoryContent item)
    {
        if (!item.IsFile)
            return "e-fe-folder";
        
        var ext = System.IO.Path.GetExtension(item.Name)?.TrimStart('.') ?? string.Empty;
        return ext switch
        {
            "jpg" or "jpeg" or "png" or "gif" => "e-fe-image",
            "mp3" or "wav" => "e-fe-music",
            "mp4" or "avi" => "e-fe-video",
            "pdf" => "e-fe-pdf",
            "zip" or "rar" => "e-fe-zip",
            "txt" => "e-fe-txt",
            "doc" or "docx" => "e-fe-docx",
            _ => "e-fe-unknown"
        };
    }
}

<style>
    .custom-fm-sample .custom-icon-card {
        padding: 8px;
        border: 1px solid #e0e0e0;
        border-radius: 8px;
        height: 140px;
        display: flex;
        flex-direction: column;
        justify-content: center;
        align-items: center;
        gap: 8px;
    }

    .custom-fm-sample .file-icon {
        font-size: 32px;
        height: 40px;
    }

    .custom-fm-sample .file-name {
        font-size: 13px;
        font-weight: 500;
        white-space: nowrap;
        overflow: hidden;
        text-overflow: ellipsis;
        max-width: 110px;
    }

    .custom-fm-sample .file-date {
        font-size: 11px;
        color: #666;
        text-align: center;
    }
</style>

```

## Details View

Details View displays files in a sortable table with columns for **Name**, **Date Modified**, **Type**, and **Size**. Each file shows a type-identifying icon. You can add custom columns, customize formatting, and perform sorting by clicking column headers. Use [FileManagerDetailsViewSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerDetailsViewSettings.html) to configure columns.

### Add Custom Columns

Add custom columns using the [FileManagerColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerColumn.html) component. Built-in fields include: `Name`, `DateModified`, `Type`, `Size`, `DateCreated`. You can also bind custom data properties returned from your AJAX backend.

```cshtml

@using Syncfusion.Blazor.FileManager

<SfFileManager TValue="FileManagerDirectoryContent" View="ViewType.Details">
    <FileManagerAjaxSettings Url="https://physical-service.syncfusion.com/api/FileManager/FileOperations"
                             UploadUrl="https://physical-service.syncfusion.com/api/FileManager/Upload"
                             DownloadUrl="https://physical-service.syncfusion.com/api/FileManager/Download"
                             GetImageUrl="https://physical-service.syncfusion.com/api/FileManager/GetImage">
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

### Customize Column Formatting and Display

Customize column appearance and behavior using [FileManagerColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerColumn.html) properties:
- **Width**: Set fixed or flexible column width
- **Format**: Apply date/number formatting (e.g., "MM/dd/yyyy h:mm tt")
- **HeaderText**: Custom column header label
- **Template**: Render custom HTML per cell

```cshtml

@using Syncfusion.Blazor.FileManager

<SfFileManager TValue="FileManagerDirectoryContent" View="ViewType.Details">
    <FileManagerAjaxSettings Url="https://physical-service.syncfusion.com/api/FileManager/FileOperations"
                             UploadUrl="https://physical-service.syncfusion.com/api/FileManager/Upload"
                             DownloadUrl="https://physical-service.syncfusion.com/api/FileManager/Download"
                             GetImageUrl="https://physical-service.syncfusion.com/api/FileManager/GetImage">
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



