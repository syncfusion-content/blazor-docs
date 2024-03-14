---
layout: post
title: Flat data rendering in Blazor FileManager component | Syncfusion
description: Checkout and learn here all about flat data rendering in Syncfusion Blazor FileManager component and more.
platform: Blazor
control: File Manager
documentation: ug
---

# Flat data rendering in Blazor FileManager component

This section briefly explains how to render the FileManager component using a flat data object. With the latest enhancement, the File Manager component now employs a flat data object for rendering, eliminating the need to define `FileManagerAjaxSettings`. Instead, in the documentation code, a physical service is injected for file actions, and the corresponding file action's response can be retrieved from the locally injected service with the help of new event support for actions performed with the FileManager component.

**Event information**

Event Name | Description
 ---  | ---
OnRead | Gets or sets an event callback that will be invoked when the initial data is set and when the sub folders data are read.
ItemsDeleting | Gets or sets an event callback that will be invoked before the delete operation takes place.
FolderCreating | Gets or sets an event callback that will be invoked before the folder is being created.
Searching | Gets or sets an event callback that will be invoked when the character is entered in input box for searching files or folders.
ItemRenaming | Gets or sets an event callback that will be invoked when the file or folder is being renamed.
ItemsMoving | Gets or sets an event callback that will be invoked when the file or folder is being cut or copied for the reason to be pasted in another path.
ItemsUploaded | Gets or sets an event callback that will be invoked when the file or folder is uploaded.
BeforeImageLoad | Gets or sets an event callback that will be invoked before sending the image request to the server.
BeforeDownload  | Gets or sets an event callback that will be invoked before sending the download request to the server.

## Add Blazor FileManager component

Add the Syncfusion Blazor FileManager component in the **~/Pages/Index.razor** file.

```cshtml

@using Syncfusion.Blazor.FileManager
@inject FileManagerService FileManagerService

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerEvents TValue="FileManagerDirectoryContent" OnRead="OnReadAsync" ItemsDeleting="ItemsDeletingAsync" FolderCreating="FolderCreatingAsync" Searching="SearchingAsync" ItemRenaming="ItemRenamingAsync" ItemsMoving="ItemsMovingAsync" ItemsUploaded="ItemsUploadedAsync" BeforeDownload="BeforeDownload" BeforeImageLoad="BeforeImageLoadAsync"></FileManagerEvents>
</SfFileManager>

```

## Initialize the flat data service

File operations such as read, delete, and folder creation are seamlessly executed in the injected service.

To set up a locally injected service, create a new file with the extension `.cs` within the project and include the following GitHub file code in that file.

N> [View FileManagerService.cs in GitHub ](https://github.com/SyncfusionExamples).

Inject the created service into the `program.cs` file.

```cshtml

using Flat_Data;
using Flat_Data.Data;
using Syncfusion.Blazor;

...
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddSingleton<FileManagerService>();

```

## File operations

To perform file operations such as reading, deleting, creating, renaming, searching, and moving, utilize the respective action events. These events enable you to access essential item details from the event argument. Subsequently, update the FileManager component's result data by incorporating the data returned from the injected service. Assign this returned data to the Response property of the corresponding event argument.

```cshtml

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

## Upload operation

To perform a upload operation in FileManager component with injected service, utilize the `ItemsUploaded` event. This event enables you to access details of the file selected in the browser, providing access to metadata such as the file name, size, and content type. To read the contents of the uploaded file, invoke the OpenReadStream() method of the IBrowserFile interface, which returns a stream for reading the file data.

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

## Download operation

To perform a download operation in FileManager component with injected service, utilize the <code>BeforeDownload</code> event. This will allow you to retrieve necessary Downloaded item details from the event argument. Updating the downloaded file's stream data and name to the event arguments <code>FileStream</code> and <code>DownloadFileName</code> respectively completes the download operation.

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

## Get image operation

To load image in FileManager component with injected service, utilize the <code>BeforeImageLoad</code> event. This will allow you to retrieve necessary Downloaded item details from the event argument. Updating the image file's stream data to the event argument <code>FileStream</code> completes the image retrieval operation.

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

N> [View Sample in GitHub](https://github.com/SyncfusionExamples).
