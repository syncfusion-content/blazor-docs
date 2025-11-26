---
layout: post
title: Asynchronous Upload in Blazor File Upload Component | Syncfusion
description: Checkout and learn here all about Asynchronous Upload in Syncfusion Blazor File Upload component and more.
platform: Blazor
control: File Upload
documentation: ug
---

# Asynchronous Upload in Blazor File Upload Component

The Uploader component allows you to upload files asynchronously. The upload process requires [`SaveUrl`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderAsyncSettings.html#Syncfusion_Blazor_Inputs_UploaderAsyncSettings_SaveUrl) and [`RemoveUrl`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderAsyncSettings.html#Syncfusion_Blazor_Inputs_UploaderAsyncSettings_RemoveUrl) to manage the upload process on the server.
*   The [`SaveUrl`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderAsyncSettings.html#Syncfusion_Blazor_Inputs_UploaderAsyncSettings_SaveUrl) is necessary to handle the upload operation.
*   The [`RemoveUrl`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderAsyncSettings.html#Syncfusion_Blazor_Inputs_UploaderAsyncSettings_RemoveUrl) is optional; it handles files removed from the server.

>The `name` attribute in the generated HTML input element for the Uploader must match the name of the parameter in the server-side POST method. For more information, refer [here](https://learn.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads?view=aspnetcore-8.0#match-name-attribute-value-to-parameter-name-of-post-method). The `name` attribute is automatically generated from the control’s `ID` property. If the desired `name` attribute differs from the `ID` property, you can use the `htmlAttributes` property to set the `name` attribute directly to the input element. For more information, refer [here](./how-to/html-attributes).

Files can be uploaded automatically or manually. For more information, you can refer to the [Auto Upload](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfUploader.html#Syncfusion_Blazor_Inputs_SfUploader_AutoUpload) section in the documentation.

## With server-side API endpoint

[`SaveUrl`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderAsyncSettings.html#Syncfusion_Blazor_Inputs_UploaderAsyncSettings_SaveUrl) and [`RemoveUrl`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderAsyncSettings.html#Syncfusion_Blazor_Inputs_UploaderAsyncSettings_RemoveUrl) actions are explained in this [link](./chunk-upload#save-and-remove-action-for-blazor-aspnet-core-hosted-application).

```cshtml
@using Syncfusion.Blazor.Inputs

<SfUploader ID="UploadFiles">
 <UploaderAsyncSettings SaveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Save" RemoveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Remove">
</UploaderAsyncSettings>
</SfUploader>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXBSWWBdJDLpZIrg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Without server-side API endpoint

```cshtml
@using Syncfusion.Blazor.Inputs
<SfUploader ID="UploadFiles">
      <UploaderEvents ValueChange="@OnChange" ></UploaderEvents>
</SfUploader>
@code {
    private async Task OnChange(UploadChangeEventArgs args)
    {
        try
        {
            foreach (var file in args.Files)
            {
                var path = @"" + file.FileInfo.Name;
                FileStream filestream = new FileStream(path, FileMode.Create, FileAccess.Write);
                await file.File.OpenReadStream(long.MaxValue).CopyToAsync(filestream);
                filestream.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
```

## Backend Configuration

### With server-side API endpoint

The upload process requires save and remove action URL to manage the upload process in the server.

N> * The save action is necessary to handle the upload operation.
<br/> * The remove action is optional, one can handle the removed files from server.

The save action handler upload the files that needs to be specified in the [SaveUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderAsyncSettings.html#Syncfusion_Blazor_Inputs_UploaderAsyncSettings_SaveUrl) property.

The save handler receives the submitted files and manages the save process in server. After uploading the files to server location, the color of the selected file name changes to green and the remove icon is changed as bin icon.

The remove action is optional. The remove action handler removes the files that needs to be specified in the [RemoveUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderAsyncSettings.html#Syncfusion_Blazor_Inputs_UploaderAsyncSettings_RemoveUrl) property.

{% tabs %}
{% highlight cshtml %}

[Route("api/[controller]")]

private IHostingEnvironment hostingEnv;

public SampleDataController(IHostingEnvironment env)
{
    this.hostingEnv = env;
}

[HttpPost("[action]")]
public void Save(IList<IFormFile> UploadFiles)
{
    long size = 0;
    try
    {
        foreach (var file in UploadFiles)
        {
            var filename = ContentDispositionHeaderValue
                    .Parse(file.ContentDisposition)
                    .FileName
                    .Trim('"');
                filename = hostingEnv.ContentRootPath + $@"\{filename}";
                size += (int)file.Length;
            if (!System.IO.File.Exists(filename))
            {
                using (FileStream fs = System.IO.File.Create(filename))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }
        }
    }
    catch (Exception e)
    {
        Response.Clear();
        Response.StatusCode = 204;
        Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "File failed to upload";
        Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = e.Message;
    }
}
[HttpPost("[action]")]
public void Remove(IList<IFormFile> UploadFiles)
{
    try
    {
        var filename = hostingEnv.ContentRootPath + $@"\{UploadFiles[0].FileName}";
        if (System.IO.File.Exists(filename))
        {
            System.IO.File.Delete(filename);
        }
    }
    catch (Exception e)
    {
        Response.Clear();
        Response.StatusCode = 200;
        Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "File removed successfully";
        Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = e.Message;
    }
}

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight razor %}

<SfUploader ID="UploadFiles">
    <UploaderAsyncSettings SaveUrl="api/SampleData/Save" RemoveUrl="api/SampleData/Remove"></UploaderAsyncSettings>
</SfUploader>

{% endhighlight %}
{% endtabs %}

> Replace api/SampleData/Save and api/SampleData/Remove with your backend routes. Incorrect SaveUrl/RemoveUrl will trigger Failure events.

## Events

The Syncfusion File Upload component provides several events to help you control and customize the upload process. Below is detailed documentation for each event including their usage scenarios and sample code.

### BeforeUpload

**Description:** Triggered before the upload process begins. This event is used to add additional parameters with upload requests or to cancel the upload process.

**Usage Scenarios:**

- Add headers or extra parameters to the upload request
- Validate files before upload
- Prevent specific files from being uploaded

```cshtml
<SfUploader @ref="uploader" ID="chunkFile">
    <UploaderEvents BeforeUpload="BeforeUploadHandler"></UploaderEvents>
     <UploaderAsyncSettings SaveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Save" RemoveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Remove"></UploaderAsyncSettings>
</SfUploader>

@code {
    private void BeforeUploadHandler(BeforeUploadEventArgs args)
    {
        // To prevent the default upload
        args.Cancel = true;
        
        // Or add custom data with the upload request
        args.CustomFormData = new List<object> { new { Name = "Syncfusion" } };
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDVeCiVoAGUKZnZb?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### OnUploadStart

**Description**: Triggers when the upload process starts. This event can be used to add additional parameters with upload requests or convert files to a specific format.

**Usage Scenarios:**

- Convert files to byte arrays before uploading to a database
- Add custom headers
- Track upload start time for analytics

```cshtml
<SfUploader ID="chunkFile">
    <UploaderEvents OnUploadStart="UploadStartHandler"></UploaderEvents>
     <UploaderAsyncSettings SaveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Save" RemoveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Remove"></UploaderAsyncSettings>
</SfUploader>
<strong>@statusMessage</strong>
@code {
    private string statusMessage = "Waiting for upload...";
    private void UploadStartHandler(UploadingEventArgs args)
    {
        statusMessage = $"Upload started for file: {args.FileData.Name}";
    }

}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXBeWMBIUlraMdku?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Progressing

**Description:** Triggers when uploading a file to the server using AJAX requests. Provides real-time progress information during file upload.

**Usage Scenarios:**

- Show custom progress UI
- Calculate upload speed
- Display remaining time estimation

```cshtml
<SfUploader @ref="uploader" AutoUpload="true" ShowProgressBar="false">
    <UploaderEvents Progressing="ProgressHandler" />
    <UploaderAsyncSettings SaveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Save"
                           RemoveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Remove" />
</SfUploader>

@if (!string.IsNullOrEmpty(progressText))
{
    <p>@progressText</p>
}

@code {
    private SfUploader? uploader;
    private string progressText = "";

    private void ProgressHandler(Syncfusion.Blazor.Inputs.ProgressEventArgs args)
    {
        if (args.LengthComputable && args.Total > 0)
        {
            var percent = (int)((args.Loaded / args.Total) * 100);
            progressText = $"Uploading {args.File?.Name}: {percent}% completed";
            StateHasChanged();
        }
        else
        {
            progressText = $"Uploading {args.File?.Name}: progress unknown";
        }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LZreCWBeTZzShNnS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### OnActionComplete

**Description**: Triggers after all selected files have been processed for upload, either successfully or failed to the server.

**Usage Scenarios:**

- Display upload summary
- Perform post-upload processing
- Navigate to another page after upload completes

```cshtml
@using Syncfusion.Blazor.Inputs

<h3>File Upload with ActionComplete Event</h3>

<SfUploader @ref="uploader" AutoUpload="true">
    <UploaderEvents OnActionComplete="ActionCompleteHandler" />
    <UploaderAsyncSettings SaveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Save" RemoveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Remove" />
</SfUploader>

@if (!string.IsNullOrEmpty(actionMessage))
{
    <p>@actionMessage</p>
}

@code {
    private SfUploader? uploader;
    private string actionMessage = "";
    private void ActionCompleteHandler(Syncfusion.Blazor.Inputs.ActionCompleteEventArgs args)
    {
        // "2" = success (string)
        bool allSuccess = args.FileData.All(file => file.StatusCode == "2");
        actionMessage = allSuccess
        ? "✅ All files uploaded successfully!"
        : $"❌ Failed files: {string.Join(", ", args.FileData.Where(f => f.StatusCode != "2").Select(f => f.Name))}";
        StateHasChanged();
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LXhyCirozVBSfKLa?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Success

**Description**: The Success event is triggered only after a file has been uploaded successfully.

**Usage Scenarios:**

- Display success messages
- Process server response
- Update UI with uploaded file information

```cshtml
<SfUploader>
    <UploaderEvents Success="SuccessHandler"></UploaderEvents>
     <UploaderAsyncSettings SaveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Save" RemoveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Remove" />
</SfUploader>

@if (!string.IsNullOrEmpty(successMessage))
{
    <p>@successMessage</p>
}

@code {
    private string successMessage = "";

    private void SuccessHandler(SuccessEventArgs args)
    {
        successMessage = $"✅ File '{args.File.Name}' uploaded successfully!";
        StateHasChanged();
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LtLoCCBSTgJSDCIc?appbar=true&editor=true&result=true&errorlist=true&theme=bootstrap5" %}

### OnFailure

- The OnFailure event is triggered only when a file upload fails (e.g., due to an incorrect SaveUrl).

**Usage Scenarios:**

- Display detailed error message
- Retry failed uploads
- Log failures

```cshtml

<SfUploader>
    <UploaderEvents OnFailure="@OnFailure"></UploaderEvents>
     <UploaderAsyncSettings SaveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Save" RemoveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Remove" />
</SfUploader>

@if (!string.IsNullOrEmpty(FailureMessage))
{
    <p>@FailureMessage</p>
}

@code {
    private string FailureMessage = "";
    private void OnFailure(Syncfusion.Blazor.Inputs.FailureEventArgs args)
    {
        // Show error message from args.Response
        FailureMessage = $"❌ File '{args.File.Name}' uploaded Failed!";
        StateHasChanged();
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hDrSiWrIJpNySjIM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### OnCancel

**Description**: Triggers when the user cancels an in-progress file upload.

**Usage Scenarios:**

- Update the UI to indicate that the upload was canceled
- Log cancellation for auditing or analytics
- Notify the user about the cancellation

```cshtml

<SfUploader>
    <UploaderEvents OnCancel="OnCancel"></UploaderEvents>
    <UploaderAsyncSettings SaveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Save" />
</SfUploader>

<div>
    <h4>Upload Status</h4>
    <ul>
        @foreach (var message in cancelMessages)
        {
            <li>@message</li>
        }
    </ul>
</div>

@code {
    private List<string> cancelMessages = new List<string>();

    private void OnCancel(CancelEventArgs args)
    {
        // Track cancellation and update UI
        var msg = $"Upload canceled for file {args.FileData.Name}";
        cancelMessages.Add(msg);

        // Optional: Log or clean up resources
        Console.WriteLine(msg);
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VtLSWsLngIuAERjF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### OnClear

**Description:**

The OnClear event is triggered when the file list in the uploader is cleared (either by the user or programmatically). This event can be used to reset UI state, release resources, or log the action.

**Usage Scenarios:**

- Reset UI elements to default state
- Clear any temporary data or cached files
- Log the clear action for auditing
- Notify the user that the file list has been cleared

```cshtml

<SfUploader AutoUpload="false">
    <UploaderEvents OnClear="@OnClearHandler"></UploaderEvents>
    <UploaderAsyncSettings SaveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Save" />
</SfUploader>

<div>
    <h4>Upload Status</h4>
    <p>@clearMessage</p>
</div>

@code {
    private string clearMessage = string.Empty;

    private void OnClearHandler(ClearingEventArgs args)
    {
        // Update UI when files are cleared
        clearMessage = "All files have been cleared from the uploader.";

        // Optional: Log or clean up resources
        Console.WriteLine("Uploader file list cleared.");
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VZhoCiVdgQLbOfil?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### BeforeRemove

**Description**: Triggers before sending a remove request. Allows cancellation.

**Usage Scenarios:**

- Confirm deletion
- Prevent removal of critical files

```cshtml
<SfUploader AutoUpload="false">
    <UploaderEvents BeforeRemove="@BeforeRemove"></UploaderEvents>
    <UploaderAsyncSettings SaveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Save" />
</SfUploader>


@code {
    private void BeforeRemove(BeforeRemoveEventArgs args)
    {
        // Example: Ask for confirmation before removing
        if (!ConfirmRemove(args.FilesData[0].Name))
        {
            args.Cancel = true; // Prevent removal
        }
    }

    private bool ConfirmRemove(string fileName)
    {
        // Custom logic: return false if user cancels
        return false; // For now, always allow
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VtVoWsVdqFwdMHay?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### OnRemove

**Description**: OnRemove triggers when the remove action is initiated—after confirmation and just before the remove request is sent to the server. It’s useful for tracking removal actions, updating UI states, or performing custom logic before the actual removal occurs.

**Usage Scenarios**

- Show which files are being removed in real-time.
- Track user behavior for file removal actions.

```cshtml
<SfUploader AutoUpload="false">
    <UploaderEvents OnRemove="OnRemove"></UploaderEvents>
    <UploaderAsyncSettings SaveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Save" />
</SfUploader>

<div class="log-panel">
    <h4>Removal Log:</h4>
    <ul>
        @foreach (var log in RemovalLogs)
        {
            <li>@log</li>
        }
    </ul>
</div>

@code {
    private List<string> RemovalLogs = new();

    private void OnRemove(RemovingEventArgs args)
    {
        var timestamp = DateTime.Now.ToString("HH:mm:ss");
        var fileNames = string.Join(", ", args.FilesData.Select(f => f.Name));
        RemovalLogs.Add($"[{timestamp}] Removing {args.FilesData.Count} file(s): {fileNames}");
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rthSWWLxgaAOmLBJ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## See Also

- Handling custom data with upload: https://support.syncfusion.com/kb/article/16000/handling-custom-data-with-file-upload-component-in-blazor
- Upload with user info in SfUploader: https://support.syncfusion.com/kb/article/15190/how-to-handle-blazor-file-upload-with-user-information-in-sfuploader
- Upload to Azure Blob Storage: https://www.syncfusion.com/blogs/post/simple-steps-to-upload-files-to-azure-blob-storage-in-b
- Upload files to Database in Blazor: (https://github.com/SyncfusionExamples/how-to-upload-files-to-database-in-blazor)
