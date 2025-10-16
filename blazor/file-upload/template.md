---
layout: post
title: Template in Blazor File Upload Component | Syncfusion
description: Checkout and learn here about Template in Syncfusion Blazor File Upload component and much more details.
platform: Blazor
control: File Upload
documentation: ug
---

# Template in Blazor File Upload Component

The template feature customizes how each file item is rendered in the uploader UI. It enables full control over layout and styling for file details such as name, size, and status, so the interface can match application design requirements and provide a tailored user experience.

### With server-side API endpoint

Use a template with server endpoints when uploads are processed by a backend. The template controls only the display of file items; the upload flow still uses SaveUrl and RemoveUrl.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfUploader ID="Files" AutoUpload="false">
    <UploaderAsyncSettings SaveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Save"
                           RemoveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Remove"></UploaderAsyncSettings>
    <UploaderTemplates>
        <Template>
            <div class="name file-name" title="@(context.Name)">File Name : @(context.Name)</div>
            <div class="file-size">File Size : @(context.Size)</div>
            <div class="e-file-status">File Status : @(context.Status)</div>
        </Template>
    </UploaderTemplates>
</SfUploader>
```
### Without server-side API endpoint

Use a template without server endpoints when handling files locally (for example, demos or trusted environments). The template syntax and available context properties are the same as the server-backed example.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfUploader ID="Files" AutoUpload="false">
    <UploaderTemplates>
        <Template>
            <div class="name file-name" title="@(context.Name)">File Name : @(context.Name)</div>
            <div class="file-size">File Size : @(context.Size)</div>
            <div class="e-file-status">File Status : @(context.Status)</div>
        </Template>
    </UploaderTemplates>
</SfUploader>
```

### Adding progressbar using template

When using a custom file template, the built-in progress bar is not shown. The following example disables the default progress indicator (ShowProgressBar=false), renders a custom progress element in the template, and updates it during stream read/write in the ValueChange event. The template displays file name, size, progress, and status, and toggles remove/delete icons based on item state. In browser-only environments (such as WebAssembly), write streams to appropriate storage or a server API; writing directly to the local file system is supported in server/desktop contexts.

```cshtml
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.ProgressBar
<SfUploader @ref="@uploderObj" ID="UploadFiles" MaxFileSize="100000000000" ShowProgressBar = "false">
    <UploaderEvents BeforeUpload="onBeforeUpload" Success="onSuccess" ValueChange="onChange"></UploaderEvents>
    <UploaderTemplates>
        <Template>
            <span class="e-file-container">
                <span class="e-file-name" title="@(context.Name)">@this.GetFileName(context.Name)</span>
                <span class="e-file-type">@("." + context.Type)</span>
                @if (context.Size > 0)
                {
                    fileSize = CalculateFileSize(context.Size);
                }
                <div class="e-file-size">@fileSize</div>
                @if (CurrentFile != null && (CurrentFile.Name == context.Name && CurrentFile.Size == context.Size && CurrentFile.Status == "Uploading" && context.Status == "File uploaded successfully"))
                {
                    <span class="e-upload-progress-wrap">
                        <span class="e-progress-inner-wrap">
                            <progressbar class="@("e-upload-progress-bar" + " " + "e-upload-progress")" value="0" max="100" style="width: @(ProgressValue.ToString() + "%")"></progressbar>
                        </span>
                        <span class="e-progress-bar-text">@(ProgressValue.ToString() + "%")</span>
                    </span>
                }
                @if (fileStates.ContainsKey(context.Name) && fileStates[context.Name] && context.Status == "File uploaded successfully")
                {
                    <span class="file-status" style="color: green">@context.Status</span>
                }
                else if (context.Status != "File uploaded successfully" && context.Status != "Ready to upload")
                {
                    <span class="file-status" style="color: red">@context.Status</span>
                }
                else if (context.Status == "Ready to upload" || ((fileStates.ContainsKey(context.Name) && !fileStates[context.Name] && CurrentFile != null && CurrentFile.Size != context.Size)))
                {
                    <span class="file-status">Ready to upload</span>
                }
                @if (fileStates.ContainsKey(context.Name) && fileStates[context.Name] && context.Status == "File uploaded successfully")
                {
                    <span class="e-icons e-file-delete-btn @this.RemoveIconDisable" id="deleteIcon" title="Delete" @onclick="(args) => ClickHandler(context)"></span>
                }
                else
                {
                    <span class="e-icons e-file-remove-btn @this.RemoveIconDisable" id="removeIcon" title="Remove" @onclick="(args) => ClickHandler(context)"></span>
                }
            </span>
            
        </Template>
    </UploaderTemplates>
</SfUploader>
@code {
    private SfUploader uploderObj;
    public bool isVisible { get; set; } = false;
    private FileInfo CurrentFile {get; set;}
    public string fileSize { get; set; } = "0";
    public string RemoveIconDisable = string.Empty;
#pragma warning disable CA2213 // Disposable fields should be disposed
    private readonly SemaphoreSlim FileSemaphore = new SemaphoreSlim(1);
#pragma warning restore CA2213 // Disposable fields should be disposed
    private decimal ProgressValue { get; set; } = 0;
    private Dictionary<string, bool> fileStates = new Dictionary<string, bool>();
    public string CalculateFileSize(double size)
    {
        string fileSizeStr = "";
        if (size >= 1024 * 1024)
        {
            return fileSizeStr = $"{size / (1024f * 1024f):0.00} MB";
        }
        else if (size >= 1024)
        {
            return fileSizeStr = $"{size / 1024f:0.00} KB";
        }
        else
        {
            return fileSizeStr = $"{size} bytes";
        }
    }
    private string GetFileName(string fileName)
    {
        string type = GetFileType(fileName);
        string[] names = fileName.Split(new string[] { "." + type }, StringSplitOptions.None);
        return names[0];
    }
    private string GetFileType(string name)
#pragma warning restore CA1822 // Mark members as static
    {
        string extension = string.Empty;
        int index = name.LastIndexOf('.');
        if (index > 0)
        {
            extension = name.Substring(index + 1);
        }

        return (!string.IsNullOrEmpty(extension)) ? extension : string.Empty;
    }
    private async Task onFileRemove()
    {
        await uploderObj.RemoveAsync();
    }
    public async Task ClickHandler(FileInfo context)
    {
        await uploderObj.RemoveAsync(new FileInfo[] { context });
    }
    public void onBeforeUpload(BeforeUploadEventArgs args)
    {
        foreach (var file in args.FilesData)
        {
            fileStates[file.Name] = false;
        }
    }
    public void onSuccess(SuccessEventArgs args)
    {
        //fileStates[args.File.Name] = false;
        isVisible = false;
        this.ProgressValue = 0;
    }
   
    public async Task onChange(UploadChangeEventArgs args)
    {
        await FileSemaphore.WaitAsync();
        try
        {
            foreach (var file in args.Files)
            {
                var path = @"" + file.FileInfo.Name;
                CurrentFile = file.FileInfo;
                CurrentFile.Status = "Uploading";
                await using FileStream writeStream = new(path, FileMode.Create);
                using var readStream = file.File.OpenReadStream(file.File.Size);
                var bytesRead = 0;
                var totalRead = 0;
                var buffer = new byte[1024 * 10];

                while ((bytesRead = await readStream.ReadAsync(buffer)) != 0)
                {
                    RemoveIconDisable = "e-disabled";
                    totalRead += bytesRead;
                    await writeStream.WriteAsync(buffer, 0, bytesRead);
                    ProgressValue = (long)((decimal)readStream.Position * 100) / readStream.Length;
                    StateHasChanged();
                }
                CurrentFile.Status = "File uploaded successfully";
                RemoveIconDisable = string.Empty;
                fileStates[file.FileInfo.Name] = true;

            }
        }
        catch (Exception ex)
        {
            RemoveIconDisable = string.Empty;
            Console.WriteLine(ex.Message);
        }
        finally
        {
            FileSemaphore.Release();
        }
    }
}
```

![Blazor FileUpload with Chunk Upload](./images/blazor-template-progressbar.gif)