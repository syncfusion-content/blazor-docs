---
layout: post
title: Setting Authorization Header for GetImage Operations | Syncfusion
description: Checkout and learn here all about Setting Authorization Header for GetImage Operations in Syncfusion Blazor File Manager component and more.
platform: Blazor
control: File Manager
documentation: ug
---

# Setting Authorization Header for GetImage Operations in Blazor File Manager Component

In secured applications, retrieving images often requires authentication. The File Manager component now provides enhanced support for adding authorization headers to image requests through the [BeforeImageLoad](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_BeforeImageLoad) event.

## Understanding the Challenge

When working with secured APIs, image loading operations need proper authentication. Traditional image loading (using HTML `src` attributes) doesn't support custom headers, making it difficult to authenticate image requests properly.

## Solution: Using HTTP Client for Image Operations

The Blazor File Manager component offers a solution by supporting HTTP Client-based image operations instead of direct URL references. This approach enables you to:

* Add authorization headers to image requests
* Maintain security when retrieving images from protected endpoints
* Control how images are loaded and processed

## BeforeImageLoad Event: UseImageAsUrl Property

The [BeforeImageLoad](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_BeforeImageLoad) event provides the [UseImageAsUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.BeforeImageLoadEventArgs-1.html#Syncfusion_Blazor_FileManager_BeforeImageLoadEventArgs_1_UseImageAsUrl) property which determines how images are loaded:

* When `UseImageAsUrl` is `true` (default), images are loaded directly via URL in image tags, which doesn't allow for custom headers.
* When `UseImageAsUrl` is `false`, images are loaded using HTTP client requests, enabling the addition of custom headers like authorization tokens.

Setting `UseImageAsUrl` to `false` is essential for secure environments where image requests must include authentication.

## Implementation Steps

### 1. Configure the BeforeImageLoad Event Handler

```csharp
<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="https://your-api-endpoint/api/FileManager/FileOperations"
                            UploadUrl="https://your-api-endpoint/api/FileManager/Upload"
                            DownloadUrl="https://your-api-endpoint/api/FileManager/Download"
                            GetImageUrl="https://your-api-endpoint/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerEvents TValue="FileManagerDirectoryContent" 
                      BeforeImageLoad="HandleBeforeImageLoad">
    </FileManagerEvents>
</SfFileManager>
```

### 2. Implement the Event Handler Method

```csharp
@code {
    private void HandleBeforeImageLoad(BeforeImageLoadEventArgs<FileManagerDirectoryContent> args)
    {
        // Switch to HTTP Client-based approach instead of direct URL
        args.UseImageAsUrl = false;
        
        // Add your authorization header
        args.HttpClientInstance.DefaultRequestHeaders.Authorization = 
            new System.Net.Http.Headers.AuthenticationHeaderValue("scheme", "your-token-here");
    }
}
```

## Complete Example

Here's a complete example showing how to implement secure image operations:

```csharp
@using Syncfusion.Blazor.FileManager
@using System.Net.Http.Headers

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="https://your-api-endpoint/api/FileManager/FileOperations"
                           UploadUrl="https://your-api-endpoint/api/FileManager/Upload"
                           DownloadUrl="https://your-api-endpoint/api/FileManager/Download"
                           GetImageUrl="https://your-api-endpoint/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerEvents TValue="FileManagerDirectoryContent" 
                      BeforeImageLoad="SecureImageLoading">
    </FileManagerEvents>
</SfFileManager>

@code {
    private void SecureImageLoading(BeforeImageLoadEventArgs<FileManagerDirectoryContent> args)
    {
        // Switch to HTTP Client-based approach
        args.UseImageAsUrl = false;
        
        // Add authentication header
        args.HttpClientInstance.DefaultRequestHeaders.Authorization = 
            new System.Net.Http.Headers.AuthenticationHeaderValue("scheme", "your-token-here");
    }
}
```

> **Note:** 
> 
> When implementing HTTP Client-based image operations, you'll need to modify your server-side API endpoint to accept the parameters as a request body rather than query parameters. Here's how your controller methods should differ:
> 
> **For traditional URL-based image loading (UseImageAsUrl = true):**
> ```csharp
> public IActionResult GetImage(FileManagerDirectoryContent args)
> {
>     return this.operation.GetImage(args.Path, args.Id, false, null, null);
> }
> ```
> 
> **For HTTP Client-based image loading (UseImageAsUrl = false):**
> ```csharp
> public IActionResult GetImage([FromBody] FileManagerDirectoryContent args)
> {
>     return this.operation.GetImage(args.Path, args.Id, false, null, null);
> }
> ```
> 
> This change is necessary because HTTP Client-based requests send data in the request body, while URL-based requests use query parameters.