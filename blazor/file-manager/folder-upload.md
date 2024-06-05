---
layout: post
title: Folder upload in Blazor FileManager Component | Syncfusion
description: Checkout and learn here all about folder upload in Syncfusion Blazor FileManager component and much more.
platform: Blazor
control: File Manager
documentation: ug
---

# Folder Upload support

To perform the directory(folder) upload in File Manager, set [DirectoryUpload](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerUploadSettings.html#Syncfusion_Blazor_FileManager_FileManagerUploadSettings_DirectoryUpload) as true within the FileManagerUploadSettings. The directory upload feature is supported for the following file service providers:
* Physical file service provider.
* Azure file service provider.
* NodeJS file service provider.
* Amazon file service provider.

In this example, you can enable or disable the ability to upload directories by selecting an option from the DropDownButton. The DropDownButton is created using the Template feature in FileManagerCustomToolbarItems. 

{% tabs %}
{% highlight razor %}

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings  Url="/api/SampleData/FileOperations"
                                UploadUrl="/api/SampleData/Upload"
                                DownloadUrl="/api/SampleData/Download"
                                GetImageUrl="/api/SampleData/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerUploadSettings DirectoryUpload="@IsDirectoryUpload"></FileManagerUploadSettings>
    <FileManagerEvents TValue="FileManagerDirectoryContent" ToolbarItemClicked="ItemClicked"><FileManagerEvents>
    <FileManagerToolbarSettings ToolbarItems="@Items">
        <FileManagerCustomToolbarItems>
            <FileManagerCustomToolbarItem Name="Upload">
                <Template>
                    <SfDropDownButton IconCss="e-icons e-fe-upload" CssClass=" e-tbar-btn e-tbtn-txt  e-fe-popup" @attributes="@(new Dictionary<string, object> { {"tabindex", -1 } })">
                            <span class="e-tbar-btn-text e-tbar-ddb-text">Upload</span>
                            <DropDownButtonEvents ItemSelected="@ItemSelected"></DropDownButtonEvents>
                            <DropDownMenuItems>
                                <DropDownMenuItem Id="Folder" Text="Folder"></DropDownMenuItem>
                                <DropDownMenuItem Id="Files" Text="Files"></DropDownMenuItem>
                            </DropDownMenuItems>
                    </SfDropDownButton>
                </Template>
            </FileManagerCustomToolbarItem>
        </FileManagerCustomToolbarItems>
    </FileManagerToolbarSettings>
</SfFileManager>
@code{
    private List<ToolBarItemModel> Items = new List<ToolBarItemModel>()
    {
        new ToolBarItemModel() { Name="NewFolder" },
        new ToolBarItemModel() { Name = "Upload" },
        new ToolBarItemModel() { Name = "Cut" },
        new ToolBarItemModel() { Name = "Copy" },
        new ToolBarItemModel() { Name = "Paste" },
        new ToolBarItemModel() { Name = "Delete" },
        new ToolBarItemModel() { Name = "Download" },
        new ToolBarItemModel() { Name = "Rename" },
        new ToolBarItemModel() { Name = "SortBy" },
        new ToolBarItemModel() { Name = "Refresh",PrefixIcon="fa fa-refresh"},
        new ToolBarItemModel() { Name = "Selection" },
        new ToolBarItemModel() { Name = "View" ,Disabled=true },
        new ToolBarItemModel() { Name = "Details" },
    };
    public bool IsDirectoryUpload = true;
    public async void ItemSelected(MenuEventArgs args)
    {
        if (args.Item.Id == "Folder")
        {
            IsDirectoryUpload = true;
        }
        else
        {
            IsDirectoryUpload = false;
        }
        await Task.Delay(100);
        await JSRuntime.InvokeVoidAsync("uploadClick");
    }
    public void ItemClicked(ToolbarClickEventArgs<FileManagerDirectoryContent> args)
    {
        if (args.Item.Text == "Upload")
        {
            args.Cancel = true;
        }
    }
}
<style>
    .fluent  .directory-upload,
    .fluent-dark .directory-upload {
        padding-right: 5px;
    }
</style>

{% endhighlight %}
{% endtabs %}

![Folder Upload in Blazor FileManager](images/blazor-filemanager-folder-upload.gif)

## Physical file service provider

To achieve the directory upload in the physical file service provider, use the below code snippet in `IActionResult Upload` method in the `Controllers/FileManagerController.cs` file.

```typescript
[Route("Upload")]
        public IActionResult Upload(string path, IList<IFormFile> uploadFiles, string action)
        {
            FileManagerResponse uploadResponse;
            foreach (var file in uploadFiles)
            {
                var folders = (file.FileName).Split('/');
                // checking the folder upload
                if (folders.Length > 1)
                {
                    for (var i = 0; i < folders.Length - 1; i++)
                    {
                        string newDirectoryPath = Path.Combine(this.basePath + path, folders[i]);
                        if (!Directory.Exists(newDirectoryPath))
                        {
                            this.operation.ToCamelCase(this.operation.Create(path, folders[i]));
                        }
                        path += folders[i] + "/";
                    }
                }
            }
            uploadResponse = operation.Upload(path, uploadFiles, action, null);
            if (uploadResponse.Error != null)
            {
               Response.Clear();
               Response.ContentType = "application/json; charset=utf-8";
               Response.StatusCode = Convert.ToInt32(uploadResponse.Error.Code);
               Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = uploadResponse.Error.Message;
            }
            return Content("");
        }
```

Refer to the [GitHub](https://github.com/SyncfusionExamples/ej2-aspcore-file-provider/blob/master/Controllers/FileManagerController.cs#L76) for more details

And also add the below code snippet in `FileManagerResponse Upload` method in `Models/PhysicalFileProvider.cs` file.

```typescript
string[] folders = name.Split('/');
string fileName = folders[folders.Length - 1];
var fullName = Path.Combine((this.contentRootPath + path), fileName);
```

Refer to the [GitHub](https://github.com/SyncfusionExamples/ej2-aspcore-file-provider/blob/master/Models/PhysicalFileProvider.cs#L1185) for more details.

## Azure file service provider

For Azure file service provider, no customizations are needed for directory upload with server side and this will work with the below default upload method code.

Refer to the [GitHub](https://github.com/SyncfusionExamples/azure-aspcore-file-provider/blob/master/Controllers/AzureProviderController.cs#L94) for more details.

## NodeJS file service provider

To perform the directory upload in the NodeJS file service provider, use the below code snippet in `app.post` method in the `filesystem-server.js` file.

```typescript
var folders = (req.body.filename).split('/');
var filepath = req.body.path;
var uploadedFileName = folders[folders.length - 1];
// checking the folder upload
if (folders.length > 1)
   {
     for (var i = 0; i < folders.length - 1; i++)
       {
          var newDirectoryPath = path.join(contentRootPath + filepath, folders[i]);
          if (!fs.existsSync(newDirectoryPath)) {
                fs.mkdirSync(newDirectoryPath);
                (async () => {
                           await FileManagerDirectoryContent(req, res, newDirectoryPath).then(data => {
                                response = { files: data };
                                response = JSON.stringify(response);
                           });
                        })();
                    }
                    filepath += folders[i] + "/";
                }
                fs.rename('./' + uploadedFileName, path.join(contentRootPath, filepath + uploadedFileName), function (err) {
                    if (err) {
                        if (err.code != 'EBUSY') {
                            errorValue.message = err.message;
                            errorValue.code = err.code;
                        }
                    }
                });
            }
```

Refer to the [GitHub](https://github.com/SyncfusionExamples/ej2-filemanager-node-filesystem/blob/master/filesystem-server.js#L788) for more details.

## Amazon file service provider

To perform the directory upload in the Amazon file service provider, use the below code snippet in `IActionResult AmazonS3Upload` method in the `Controllers/AmazonS3ProviderController.cs` file.

```typescript
foreach (var file in uploadFiles)
            {
                var folders = (file.FileName).Split('/');
                // checking the folder upload
                if (folders.Length > 1)
                {
                    for (var i = 0; i < folders.Length - 1; i++)
                    {
                        if (!this.operation.checkFileExist(path, folders[i]))
                        {
                            this.operation.ToCamelCase(this.operation.Create(path, folders[i], dataObject));
                        }
                        path += folders[i] + "/";
                    }
                }
            }
```

Refer to the [GitHub](https://github.com/SyncfusionExamples/amazon-s3-aspcore-file-provider/blob/master/Controllers/AmazonS3ProviderController.cs#L83) for more details.

And also add the below code snippet in `AsyncUpload` method in `Models/AmazonS3FileProvider.cs` file.

```typescript
string[] folders = file.FileName.Split('/');
string name = folders[folders.Length - 1];
```

Refer to the [GitHub](https://github.com/SyncfusionExamples/amazon-s3-aspcore-file-provider/blob/master/Models/AmazonS3FileProvider.cs#L585) for more details.