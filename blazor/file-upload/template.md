---
layout: post
title: Template in Blazor File Upload Component | Syncfusion
description: Checkout and learn here about Template in Syncfusion Blazor File Upload component and much more details.
platform: Blazor
control: File Upload
documentation: ug
---

# Template in Blazor File Upload Component

The template in the code snippet allows for the customization of how file details are displayed in the uploader's UI. It provides flexibility to define the structure and styling of individual file elements, such as file name, size, and status. This allows to create a tailored and visually appealing file upload interface that aligns with their application's design and user experience requirements.

### With server-side API endpoint

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

When using the file upload template, the progress bar does not display in the UI. We can add the progress bar using template and then show the progress while reading and writing to the stream in the ValueChange event. The code snippet below demonstrates a Blazor file upload example with a progress bar using a custom template. The custom template includes elements to display the file name, size, progress bar, and file status.

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