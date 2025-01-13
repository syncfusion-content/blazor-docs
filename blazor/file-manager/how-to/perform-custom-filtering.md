---
layout: post
title: Perform Custom Filtering in Blazor File Manager Component | Syncfusion
description: Checkout and learn here all about Custom Filtering in Syncfusion Blazor File Manager component and more.
platform: Blazor
control: File Manager
documentation: ug
---

# Perform Custom Filtering in Blazor File Manager component

In the Blazor File Manager component, filtering support is provided. When the [FilterFilesAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.SfFileManager-1.html#Syncfusion_Blazor_FileManager_SfFileManager_1_FilterFilesAsync_System_Collections_Generic_List__0__) method is called, it triggers a custom operation on the controller side. Using this method, you can perform search operations by passing the SearchString as a parameter. 

In the following example, the SearchStringvalue **Downloads** is passed, and based on that, a search operation is performed in the Blazor File Manager using a button click.

```cshtml

@using Syncfusion.Blazor.FileManager
@using Syncfusion.Blazor.Buttons

<SfButton @onclick="CustomClick">ClickToPerformCustomFilter</SfButton>
<SfFileManager @ref="FileManager" TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="/api/FilemanagerSyncfusion/FileOperations"
                            UploadUrl="/api/FilemanagerSyncfusion/Upload"
                            DownloadUrl="/api/FilemanagerSyncfusion/Download"
                            GetImageUrl="/api/FilemanagerSyncfusion/GetImage">
    </FileManagerAjaxSettings>
</SfFileManager>

@code {
    SfFileManager<FileManagerDirectoryContent>? FileManager;
    public async Task CustomClick()
    {
        List<FileManagerDirectoryContent> Files = new List<FileManagerDirectoryContent>() {
            new FileManagerDirectoryContent() { SearchString = "Downloads" }
        };
        await FileManager.FilterFilesAsync(Files);
    }
}

```

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Features;
using Syncfusion.EJ2.FileManager.PhysicalFileProvider;
using Syncfusion.EJ2.FileManager.Base;
using Newtonsoft.Json;

namespace BlazorFileManager.Controllers
{
    [Route("api/[controller]")]
    public class FilemanagerSyncfusionController : Controller
    {
        ...

        //[HttpPost]
        [Route("FileOperations")]
        public object FileOperations([FromBody] FileManagerDirectoryContent args)
        {
            if (args.Action == "delete" || args.Action == "rename")
            {
                if ((args.TargetPath == null) && (args.Path == ""))
                {
                    FileManagerResponse response = new FileManagerResponse();
                    response.Error = new ErrorDetails { Code = "401", Message = "Restricted to modify the root folder." };
                    return this.operation.ToCamelCase(response);
                }
            }
            switch (args.Action)
            {
                ...

                case "filter":
                    if (args.Data[0].SearchString == "")
                    {
                        // Perform read operation while search string is empty.
                        return this.operation.ToCamelCase(this.operation.GetFiles(args.Path, args.ShowHiddenItems));
                    }
                    else
                    {
                        // Perform Search operation while serach string has value.
                        args.SearchString = args.Data[0].SearchString + "*";
                        return this.operation.ToCamelCase(this.operation.Search(args.Path, args.SearchString, args.ShowHiddenItems, args.CaseSensitive));
                    }
            }
            return null;
        }
        
        ...
    }
}

```