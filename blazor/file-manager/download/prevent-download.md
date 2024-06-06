---
layout: post
title: Prevnt Download in Blazor FileManager Component | Syncfusion
description: Checkout and learn here all about prevent download in Syncfusion Blazor FileManager component and much more.
platform: Blazor
control: File Manager
documentation: ug
---

# Prevent Downloading File

In the Blazor FileManager component, you are able to prevent the download action for any types of files or folders by setting the [Cancel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.BeforeDownloadEventArgs-1.html#Syncfusion_Blazor_FileManager_BeforeDownloadEventArgs_1_Cancel) argument to **true** of the [BeforeDownload](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_BeforeDownload) event. 

The following example demonstrates how to prevent the download actions for all types of files in the Blazor FileManager component.

```cshtml

@using Syncfusion.Blazor.FileManager

<SfFileManager @ref="FileManager" TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/FileOperations"
                                UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Upload"
                                DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Download"
                                GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerEvents TValue="FileManagerDirectoryContent" BeforeDownload="BeforeDownload">
    </FileManagerEvents>
</SfFileManager>

@code {
    public void BeforeDownload(BeforeDownloadEventArgs<FileManagerDirectoryContent>args)
    {
        for(int i=0; i < args.DownloadData.DownloadFileDetails.Count(); i++)
        {
            if (args.DownloadData.DownloadFileDetails[i].IsFile)
            {
                args.Cancel = true;
            }
        }
    }

}

```