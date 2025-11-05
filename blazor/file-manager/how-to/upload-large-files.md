---
layout: post
title: Upload large file in Blazor File Manager Component | Syncfusion
description: Checkout and learn here all about uploading large files in Syncfusion Blazor File Manager component and much more.
platform: Blazor
control: File Manager
documentation: ug
---

# Upload large files in Blazor File Manager Component

To enable large file uploads in the Blazor File Manager component, you can set the [MaxFileSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerUploadSettings.html#Syncfusion_Blazor_FileManager_FileManagerUploadSettings_MaxFileSize) property in the [`FileManagerUploadSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerUploadSettings.html) class. This property allows you to specify the maximum file size that can be uploaded, in bytes.

Here's an example of how to set the `MaxFileSize` property to allow uploads of large files:

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

## Server configuration for large files upload

To handle large file uploads on the server side, you can also configure the file size in the server's `web.config` file. Here's an example of how to set the maximum file size in the `web.config` file:

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

N> The above-mentioned configuration is only applicable for running a separate service, as well as when your Blazor Sample with Service is the same application running on IIS Express.