---
layout: post
title: Flat data rendering in Blazor FileManager component | Syncfusion
description: Checkout and learn here all about flat data rendering in Syncfusion Blazor FileManager component and more.
platform: Blazor
control: File Manager
documentation: ug
---

# Flat data rendering in Blazor FileManager component

The Blazor FileManager component provides the option to load a list of objects. This can be achieved by providing the response within the corresponding events.

**Event information**

Event Name | Description
 ---  | ---
[OnRead](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_OnRead) | An event callback that will be invoked when the initial data is set and when the sub folders data are read.
[ItemsDeleting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_ItemsDeleting) | An event callback that will be invoked before the delete operation takes place.
[ItemsDeleted](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_ItemsDeleted) | An event callback that will be invoked when the file or folder is deleted successfully.
[FolderCreating](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_FolderCreating) | An event callback that will be invoked before the folder is being created.
[FolderCreated](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_FolderCreated) | An event callback that will be invoked when the new folder is created successfully. 
[Searching](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_Searching) | An event callback that will be invoked when the character is entered in input box for searching files or folders.
[Searched](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_Searched) | An event callback that will be invoked when the search action is completed.
[ItemRenaming](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_ItemRenaming) | An event callback that will be invoked when the file or folder is being renamed.
[ItemRenamed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_ItemRenamed) | An event callback that will be invoked when the file or folder is renamed successfully.
[ItemsMoving](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_ItemsMoving) | An event callback that will be invoked when the file or folder is being cut or copied for the reason to be pasted in another path.
[ItemsMoved](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_ItemsMoved) | An event callback that will be invoked when the file or folder is being pasted to the destination path.
[ItemsUploading](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_ItemsUploading) | An event callback that will be invoked when the file or folder upload begins.
[ItemsUploaded](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_ItemsUploaded) | An event callback that will be invoked when the file or folder is uploaded.
[BeforeImageLoad](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_BeforeImageLoad) | An event callback that will be invoked before sending the image request to the server.
[BeforeDownload](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_BeforeDownload)  | An event callback that will be invoked before sending the download request to the server.

## List object

Blazor FileManager can be populated with local data that contains the list of objects with [ParentId](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerDirectoryContent.html#Syncfusion_Blazor_FileManager_FileManagerDirectoryContent_ParentId) mapping.

To render the root-level folder, specify the ParentID as null, or there is no need to specify the ParentID in the local list object.

```cshtml

@using Syncfusion.Blazor.FileManager

 <SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerEvents TValue="FileManagerDirectoryContent" OnRead="OnReadAsync"></FileManagerEvents>
 </SfFileManager>

@code
{
    List<FileManagerDirectoryContent> Data { get; set; }

    protected override void OnInitialized()
    {
        Data = GetData();
    }

    private async Task OnReadAsync(ReadEventArgs<FileManagerDirectoryContent> args)
    {
        string path = args.Path;
        List<FileManagerDirectoryContent> fileDetails = args.Folder;
        FileManagerResponse<FileManagerDirectoryContent> response = new FileManagerResponse<FileManagerDirectoryContent>();
        if (path == "/")
        {
            string ParentId = Data
                .Where(x => string.IsNullOrEmpty(x.ParentId))
                .Select(x => x.Id).First();
            response.CWD = Data
                .Where(x => string.IsNullOrEmpty(x.ParentId)).First();
            response.Files = Data
                .Where(x => x.ParentId == ParentId).ToList();
        }
        else
        {
            var childItem = fileDetails.Count > 0 && fileDetails[0] != null ? fileDetails[0] : Data
                .Where(x => x.FilterPath == path).First();
            response.CWD = childItem;
            response.Files = Data
                .Where(x => x.ParentId == childItem.Id).ToList();
        }
        await Task.Yield();
        args.Response = response;
    }

    private List<FileManagerDirectoryContent> GetData()
    {
        List<FileManagerDirectoryContent> data = new List<FileManagerDirectoryContent>();
        data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterPath = "",
            FilterId = "",
            HasChild = true,
            Id = "0",
            IsFile = false,
            Name = "Files",
            ParentId = null,
            ShowHiddenItems = false,
            Size = 1779448,
            Type = "folder"
        });
        data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/",
            FilterPath = "/",
            HasChild = false,
            Id = "1",
            IsFile = false,
            Name = "Documents",
            ParentId = "0",
            ShowHiddenItems = false,
            Size = 680786,
            Type = "folder"
        });
        data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/",
            FilterPath = "/",
            HasChild = false,
            Id = "2",
            IsFile = false,
            Name = "Downloads",
            ParentId = "0",
            ShowHiddenItems = false,
            Size = 6172,
            Type = "folder"
        });
        data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/1/",
            FilterPath = "/Documents/",
            HasChild = false,
            Id = "5",
            IsFile = true,
            Name = "EJ2 File Manager.docx",
            ParentId = "1",
            ShowHiddenItems = false,
            Size = 12403,
            Type = ".docx"
        });
        data.Add(new FileManagerDirectoryContent()
        {
            CaseSensitive = false,
            DateCreated = new DateTime(2022, 1, 2),
            DateModified = new DateTime(2022, 2, 3),
            FilterId = "0/1/",
            FilterPath = "/Documents/",
            HasChild = false,
            Id = "6",
            IsFile = true,
            Name = "EJ2 File Manager.pdf",
            ParentId = "1",
            ShowHiddenItems = false,
            Size = 90099,
            Type = ".pdf"
        });
    }
}

```

N> [Also see the demo here](https://blazor.syncfusion.com/demos/file-manager/flat-data?theme=fluent).

## Injected service

Blazor FileManager can also be populated from an injected service, eliminating the need for HTTP client requests and backend URL configuration. This allows you to utilize your required service, such as physical, Amazon, Azure, etc., through the FileManager's action events.

These events enable you to access essential item details from the event argument. Subsequently, update the FileManager component's result data by incorporating the data returned from the injected service. Assign this returned data to the [Response](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.ReadEventArgs-1.html#Syncfusion_Blazor_FileManager_ReadEventArgs_1_Response) property of the corresponding event argument.

To set up a locally injected physical service, create a new file with the extension `.cs` within the project, include the following GitHub file code in this file, and then proceed to inject the created service into the `program.cs` file.

This will fetch the details of the static folder from the `wwwroot` directory. Likewise, you can inject your own service.

N> [View FileManagerService.cs in GitHub ](https://github.com/SyncfusionExamples/blazor-filemanager-with-flat-data/blob/master/FileManagerService.cs).

```cshtml

using Flat_Data;
using Flat_Data.Data;
using Syncfusion.Blazor;

...
builder.Services.AddSyncfusionBlazor();
builder.Services.AddSingleton<FileManagerService>();

```

```cshtml

@using Syncfusion.Blazor.FileManager
@inject FileManagerService FileManagerService

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerEvents TValue="FileManagerDirectoryContent" OnRead="OnReadAsync" ItemsDeleting="ItemsDeletingAsync" FolderCreating="FolderCreatingAsync" Searching="SearchingAsync" ItemRenaming="ItemRenamingAsync" ItemsMoving="ItemsMovingAsync" ItemsUploaded="ItemsUploadedAsync" BeforeDownload="BeforeDownload" BeforeImageLoad="BeforeImageLoadAsync"></FileManagerEvents>
</SfFileManager>

@code{

    public async Task OnReadAsync(ReadEventArgs<FileManagerDirectoryContent> args)
    {
        args.Response = await FileManagerService.GetFiles(args.Path, false, args.Folder.ToArray());
    }

    public async Task ItemsDeletingAsync(ItemsDeleteEventArgs<FileManagerDirectoryContent> args)
    {
        string[] names = args.Files.Select(x => x.Name).ToArray();
        args.Response = await FileManagerService.Delete(args.Path, names, args.Files.ToArray());
    }

    public async Task FolderCreatingAsync(FolderCreateEventArgs<FileManagerDirectoryContent> args)
    {
        args.Response = await FileManagerService.Create(args.Path, args.FolderName, args.ParentFolder);
    }

    public async Task SearchingAsync(SearchEventArgs<FileManagerDirectoryContent> args)
    {
        args.Response = await FileManagerService.Search(args.Path, args.SearchText, false, false);
    }

    public async Task ItemRenamingAsync(ItemRenameEventArgs<FileManagerDirectoryContent> args)
    {
        args.Response = await FileManagerService.Rename(args.Path, args.File.Name, args.NewName, false, args.ShowFileExtension, args.File);
    }

    public async Task ItemsMovingAsync(ItemsMoveEventArgs<FileManagerDirectoryContent> args)
    {
        string[] names = args.Files.Select(x => x.Name).ToArray();
        if (args.IsCopy)
        {
            args.Response = await FileManagerService.Copy(args.Path, args.TargetPath, names, args.TargetData, args.Files.ToArray());
        }
        else
        {
            args.Response = await FileManagerService.Move(args.Path, args.TargetPath, names, args.TargetData, args.Files.ToArray());
        }
    }
}

```

## Upload action

To perform a upload action in FileManager component with injected service, utilize the [ItemsUploaded](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_ItemsUploaded) event. This event enables you to access details of the file selected in the browser, providing access to metadata such as the file name, size, and content type. To read the contents of the uploaded file, invoke the [OpenReadStream()](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.forms.ibrowserfile.openreadstream?view=aspnetcore-8.0) method of the [IBrowserFile](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.forms.ibrowserfile?view=aspnetcore-8.0) interface, which returns a stream for reading the file data.

```cshtml

@code{

    public async Task ItemsUploadedAsync(ItemsUploadedEventArgs<FileManagerDirectoryContent> args)
    {
        string currentPath = args.Path;
        try
        {
            foreach (var file in args.Files)
            {
                var folders = (file.FileInfo.Name).Split('/');
                if (folders.Length > 1)
                {
                    for (var i = 0; i < folders.Length - 1; i++)
                    {
                        string newDirectoryPath = Path.Combine(FileManagerService.basePath + currentPath, folders[i]);
                        if (Path.GetFullPath(newDirectoryPath) != (Path.GetDirectoryName(newDirectoryPath) + Path.DirectorySeparatorChar + folders[i]))
                        {
                            throw new UnauthorizedAccessException("Access denied for Directory-traversal");
                        }
                        if (!Directory.Exists(newDirectoryPath))
                        {
                            await FileManagerService.Create(currentPath, folders[i]);
                        }
                        currentPath += folders[i] + "/";
                    }
                }
                var fullName = Path.Combine((FileManagerService.contentRootPath + currentPath), file.File.Name);
                using (var filestream = new FileStream(fullName, FileMode.Create, FileAccess.Write))
                {
                    await file.File.OpenReadStream(long.MaxValue).CopyToAsync(filestream);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

```

## Download action

To perform a download action in FileManager component with injected service, utilize the [BeforeDownload](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_BeforeDownload) event. This will allow you to retrieve necessary Downloaded item details from the event argument. Updating the downloaded file's stream data and name to the event arguments [FileStream](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.BeforeDownloadEventArgs-1.html#Syncfusion_Blazor_FileManager_BeforeDownloadEventArgs_1_FileStream) and [DownloadFileName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.BeforeDownloadEventArgs-1.html#Syncfusion_Blazor_FileManager_BeforeDownloadEventArgs_1_DownloadFileName) respectively completes the download action.

```cshtml

@code{

    public void BeforeDownload(BeforeDownloadEventArgs<FileManagerDirectoryContent> args)
    {
        var downloadData = FileManagerService.Download(args.DownloadData.Path, args.DownloadData.Names, args.DownloadData.DownloadFileDetails.ToArray());
        args.FileStream = downloadData.FileStream;
        args.DownloadFileName = downloadData.FileDownloadName;
    }
}

```

## Get image action

To load image in FileManager component with injected service, utilize the [BeforeImageLoad](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_BeforeImageLoad) event. This will allow you to retrieve necessary Downloaded item details from the event argument. Updating the image file's stream data to the event argument [FileStream](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.BeforeImageLoadEventArgs-1.html#Syncfusion_Blazor_FileManager_BeforeImageLoadEventArgs_1_FileStream) completes the image retrieval operation.

```cshtml

@code{

    public async Task BeforeImageLoadAsync(BeforeImageLoadEventArgs<FileManagerDirectoryContent> args)
    {
        var result = await FileManagerService.GetImage(args.ImageUrl, false, args.FileDetails);
        result.FileStream.Position = 0;
        args.FileStream = result.FileStream;
    }
}

```

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/blazor-filemanager-with-flat-data).
