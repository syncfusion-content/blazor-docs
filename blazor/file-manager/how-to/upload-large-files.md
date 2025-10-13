---
layout: post
title: Upload large files in Blazor File Manager Component | Syncfusion
description: Checkout and learn here all about uploading large files in Syncfusion Blazor File Manager component and much more.
platform: Blazor
control: File Manager
documentation: ug
---

# Upload large files in Blazor File Manager Component

To enable large file uploads in the Blazor File Manager component, set the [MaxFileSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerUploadSettings.html#Syncfusion_Blazor_FileManager_FileManagerUploadSettings_MaxFileSize) property in the [`FileManagerUploadSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerUploadSettings.html) class. This property specifies the maximum file size allowed for upload, in bytes.

The following example demonstrates how to set the `MaxFileSize` property to allow uploads of large files:

```cshtml

<SfFileManager @ref="FileManager" TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/FileOperations"
                                UploadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Upload"
                                DownloadUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/Download"
                                GetImageUrl="https://ej2-aspcore-service.azurewebsites.net/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerUploadSettings MaxFileSize="30000000"></FileManagerUploadSettings>
    <FileManagerEvents></FileManagerEvents>
</SfFileManager>

```

## Server Configuration for Large File Uploads

To support large file uploads on the server, configure the maximum allowed content length in the server's `web.config` file. The following example sets the maximum file size:

```xml

<configuration>
  <system.webServer>
    <security> 
      <requestFiltering> 
        <requestLimits maxAllowedContentLength="1073741824" ></requestLimits> 
      </requestFiltering> 
    </security> 
  </system.webServer>
</configuration>

```

N> This configuration applies when running a separate service or when the Blazor sample and service are hosted together on IIS Express.