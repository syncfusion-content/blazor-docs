---
layout: post
title: Chunk Upload in Blazor File Upload Component | Syncfusion
description: Checkout and learn here all about Chunk Upload in Syncfusion Blazor File Upload component and much more.
platform: Blazor
control: File Upload
documentation: ug
---

# Chunk Upload in Blazor File Upload Component

### Description

Chunk Upload in the Syncfusion Blazor File Upload component allows you to upload large files by splitting them into smaller, manageable chunks. This process significantly improves reliability, especially over unreliable networks, by reducing the impact of network interruptions. If a part of the file fails to upload, only that specific chunk needs to be re-transmitted, rather than the entire file. This feature is particularly useful for handling large media files, database backups, or any other substantial data transfers where interruptions are a concern. The Uploader sends these chunks to the server using AJAX, enabling the ability to pause, resume, and retry failed chunk uploads.

**Use Case:** Imagine a user uploading a 2GB video file. Without chunking, a network hiccup or browser crash during the upload would require the user to restart the entire upload from the beginning. With chunk upload, the file is broken into smaller pieces (e.g., 10MB each). If the upload fails at the 500MB mark, only the 51st chunk (and subsequent chunks) needs to be re-uploaded, saving significant time and improving user experience.

**Note:**
* **The chunk upload works exclusively with asynchronous uploads.**
* **Chunk upload will only be activated when the selected file size is greater than the specified `ChunkSize`. Otherwise, files will be uploaded using the normal (non-chunked) upload mechanism.**

## Chunk Configuration

To enable chunk upload, you need to configure the `ChunkSize` property within the [`<UploaderAsyncSettings>`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderAsyncSettings.html) component. The `ChunkSize` property accepts a value in `bytes`.

The following properties allow for further control over the chunk upload process:

*   **[`ChunkSize`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderAsyncSettings.html#Syncfusion_Blazor_Inputs_UploaderAsyncSettings_ChunkSize)**: Sets the size of each chunk in bytes. Larger files will be divided based on this size.
*   **[`RetryAfterDelay`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderAsyncSettings.html#Syncfusion_Blazor_Inputs_UploaderAsyncSettings_RetryAfterDelay)**: Specifies the delay in milliseconds before attempting a retry after a chunk upload fails. The default is 500 milliseconds.
*   **[`RetryCount`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderAsyncSettings.html#Syncfusion_Blazor_Inputs_UploaderAsyncSettings_RetryCount)**: Defines the number of times the component will attempt to retry a failed chunk upload. By default, it retries 3 times. If all retries fail, the upload is aborted, and the `Failure` event is triggered.

### Code Example - Enabling Chunk Upload

```cshtml
@using Syncfusion.Blazor.Inputs

<SfUploader ID="UploadFiles">
    <UploaderAsyncSettings 
        SaveUrl="api/SampleData/Save" 
        RemoveUrl="api/SampleData/Remove" 
        ChunkSize="500000"  @* 500 KB chunk size *@
        RetryCount="5" 
        RetryAfterDelay="3000">
    </UploaderAsyncSettings>
</SfUploader>
```

### Preview

![Blazor FileUpload with Chunk Upload](./images/blazor-fileupload-with-chunk-upload.png)

### Resumable Upload

The File Upload component supports resumable uploads, allowing users to pause and resume large file transfers. This is invaluable when dealing with network interruptions or when a user needs to temporarily halt an upload. The pause icon becomes available once an upload begins.

>**The pause and resume features are only available when chunk upload is enabled.**

### Public Methods:

*   **`PauseAsync()`**: Manually pauses the ongoing file upload.
*   **`ResumeAsync()`**: Resumes a paused file upload.

### Code Example - Resumable Upload

```cshtml
@using Syncfusion.Blazor.Inputs

<SfUploader ID="UploadFiles" @ref="UploaderObj">
    <UploaderAsyncSettings SaveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Save" RemoveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Remove" ChunkSize="500000">
</UploaderAsyncSettings>
    <UploaderEvents OnResume="@OnResumeHandler" Paused="@PausedHandler"></UploaderEvents>
</SfUploader>

<button @onclick="PauseUpload">Pause Upload</button>
<button @onclick="ResumeUpload">Resume Upload</button>

@code {
    SfUploader UploaderObj;

    private void OnResumeHandler(PauseResumeEventArgs args)
    {
        // Custom logic to execute when an upload is resumed
    }

    private void PausedHandler(PauseResumeEventArgs args)
    {
        // Custom logic to execute when an upload is paused
    }

    private async Task PauseUpload()
    {
        await UploaderObj.PauseAsync();
    }

    private async Task ResumeUpload()
    {
        await UploaderObj.ResumeAsync();
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXBSCiBHpPMIERUe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Preview

![Resuming File Uploads in Blazor FileUpload](./images/blazor-fileupload-resume-file-upload.png)

### Cancel Upload

Users can cancel an ongoing file upload using the cancel icon in the UI or programmatically using the `CancelAsync()` method. When an upload is canceled, any partially uploaded file is removed from the server.

If an upload fails (e.g., due to server error), the pause icon transforms into a retry icon. Clicking this icon will retry the failed chunk request from where it left off. However, if you explicitly cancel an upload and then retry, the file upload action will restart from the beginning.

**Note:**
*   **Chunk upload retry:** Retries to upload the failed request from the point of failure.
*   **Default upload retry:** Retries to upload the entire failed file again from the beginning.

### Public Methods:

*   **`CancelAsync()`**: Cancels the current upload operation.
*   **`RetryAsync()`**: Retries the upload of a failed or canceled file.

### Code Example - Cancel Upload

```cshtml
@using Syncfusion.Blazor.Inputs

<SfUploader ID="UploadFiles" @ref="UploaderObj">
    <UploaderAsyncSettings SaveUrl="api/SampleData/Save" RemoveUrl="api/SampleData/Remove" ChunkSize="500000"></UploaderAsyncSettings>
</SfUploader>

<button @onclick="CancelFirstFile">Cancel First File</button>
<button @onclick="RetryFirstFile">Retry First File</button>

@code {
    SfUploader UploaderObj;

    private async Task CancelFirstFile()
    {
        await UploaderObj.CancelAsync();
    }

    private async Task RetryFirstFile()
    {
        await UploaderObj.RetryAsync();
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rjhSiiVdpPBHTykT?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Preview

![Canceling File Uploads in Blazor FileUpload](./images/blazor-fileupload-cancel-file-upload.png)

## Backend Configuration (ASP.NET Core Hosted Application)

The server-side implementation is crucial for handling the incoming file chunks. The following C# code snippet demonstrates how to handle chunk uploads in an ASP.NET Core backend.

> The `chunk-index` and `total-chunk` values are accessible through the form data using `Request.Form`, which retrieves these details from the incoming request.
> *   `chunk-index` - Indicates the index of the current chunk being received.
> *   `total-chunk` - Represents the total number of chunks for the file being uploaded.

```csharp
public class SampleDataController : Controller
{
    public string uploads = Path.Combine(Directory.GetCurrentDirectory(), "Uploaded Files"); // Set your desired upload directory path

    [HttpPost("api/SampleData/Save")]
    public async Task<IActionResult> Save(IFormFile UploadFiles)
    {
        try
        {
            if (UploadFiles.Length > 0)
            {
                var fileName = UploadFiles.FileName;

                // Create upload directory if it doesn't exist
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }

                // Check for chunk upload based on ContentType
                if (Request.Form.ContainsKey("chunk-index") && Request.Form.ContainsKey("total-chunk")) // Handle chunk upload
                {
                    // Fetch chunk-index and total-chunk from form data
                    var chunkIndex = Request.Form["chunk-index"];
                    var totalChunk = Request.Form["total-chunk"];

                    // Path to save the chunk files with .part extension
                    var tempFilePath = Path.Combine(uploads, fileName + ".part");

                    using (var fileStream = new FileStream(tempFilePath, chunkIndex == "0" ? FileMode.Create : FileMode.Append))
                    {
                        await UploadFiles.CopyToAsync(fileStream);
                    }

                    // If all chunks are uploaded, move the file to the final destination
                    if (Convert.ToInt32(chunkIndex) == Convert.ToInt32(totalChunk) - 1)
                    {
                        var finalFilePath = Path.Combine(uploads, fileName);

                        // Move the .part file to the final destination without the .part extension
                        System.IO.File.Move(tempFilePath, finalFilePath);

                        return Ok(new { status = "File uploaded successfully" });
                    }

                    return Ok(new { status = "Chunk uploaded successfully" });
                }
                else // Handle normal upload
                {
                    var filePath = Path.Combine(uploads, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await UploadFiles.CopyToAsync(fileStream);
                    }

                    return Ok(new { status = "File uploaded successfully" });
                }
            }

            return BadRequest(new { status = "No file to upload" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { status = "Error", message = ex.Message });
        }
    }

    // Method to handle file removal (optional if needed)
    [HttpPost("api/SampleData/Remove")]
    public IActionResult Remove(string UploadFiles)
    {
        try
        {
            var filePath = Path.Combine(uploads, UploadFiles);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
                return Ok(new { status = "File deleted successfully" });
            }
            else
            {
                return NotFound(new { status = "File not found" });
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { status = "Error", message = ex.Message });
        }
    }
}
```

### Save action configuration in server-side blazor

For server-side Blazor applications using ASP.NET Core 3.0 or later, configuring the uploader's `Save` action requires explicit opt-in for MVC routing within your `Startup.cs` file. This ensures that MVC can properly handle authorization and CORS middleware during initialization.

```csharp
using Microsoft.AspNetCore.Mvc;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc(option => option.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        services.AddRazorPages();
        services.AddServerSideBlazor();
        services.AddSingleton<WeatherForecastService>(); // Example service
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseMvcWithDefaultRoute(); // Crucial for MVC controller routing

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapBlazorHub<App>(selector: "app");
            endpoints.MapFallbackToPage("/_Host");
        });
    }
}
```

## Events

The Blazor Uploader component provides several events specific to chunk upload operations, allowing you to hook into different stages of the process and implement custom logic.

*   **[`OnChunkUploadStart`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_OnChunkUploadStart)**: Triggered at the beginning of each chunk's upload process. This event allows you to perform actions before a chunk is sent to the server.
*   **[`OnChunkSuccess`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_OnChunkSuccess)**: Occurs when a single chunk has been successfully uploaded to the server. This can be used for tracking progress per chunk.
*   **[`OnChunkFailure`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_OnChunkFailure)**: Fired when an individual chunk upload fails. This is useful for error handling and logging specific chunk failures.
*   **[`Paused`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_Paused)**: Triggered when a file transfer is paused by the user or programmatically.
*   **[`OnResume`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_OnResume)**: Occurs when a paused file transfer is resumed.
*   **[`Canceling`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_Canceling)**: Triggered when an upload request is about to be canceled.
*   **[`Success`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_Success)**: This event is triggered when all chunks of a file have been successfully uploaded, indicating the completion of the entire file transfer.
*   **[`Failure`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_Failure)**: Occurs when the overall file upload operation (after all retries) ultimately fails.

### Code Example - Handling Chunk Events

```cshtml
@using Syncfusion.Blazor.Inputs

@using Syncfusion.Blazor.Inputs
<SfUploader ID="UploadFiles">
    <UploaderAsyncSettings 
        SaveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Save" 
        RemoveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Remove" 
        ChunkSize="500000">
    </UploaderAsyncSettings>
    <UploaderEvents 
        OnChunkUploadStart="@OnChunkUploadStartHandler" 
        OnChunkSuccess="@OnChunkSuccessHandler" 
        OnChunkFailure="@OnChunkFailureHandler"
        Paused="@PausedHandler"
        OnResume="@OnResumeHandler"
        Success="@SuccessHandler"
        OnFailure="@FailureHandler">
    </UploaderEvents>
</SfUploader>

<div style="margin-top:20px;">
    <h4>Upload Status:</h4>
    <p><strong>Chunk Upload:</strong> @ChunkStatus</p>
    <p><strong>Pause/Resume:</strong> @PauseResumeStatus</p>
    <p><strong>Final Status:</strong> @FinalStatus</p>
</div>

@code {
    private string ChunkStatus = "Waiting...";
    private string PauseResumeStatus = "Waiting...";
    private string FinalStatus = "Waiting...";

    private void OnChunkUploadStartHandler(UploadingEventArgs args)
    {
        ChunkStatus = $"Started chunk upload for {args.FileData.Name}";
    }

    private void OnChunkSuccessHandler(SuccessEventArgs args)
    {
        ChunkStatus = $"Chunk upload successful for {args.File?.Name}, Response: {args.Response}";
    }

    private void OnChunkFailureHandler(Syncfusion.Blazor.Inputs.FailureEventArgs args)
    {
        ChunkStatus = $"Chunk upload failed for {args.File?.Name}, Error: {args.StatusText}";
    }

    private void PausedHandler(PauseResumeEventArgs args)
    {
        PauseResumeStatus = $"File {args.File?.Name} paused.";
    }

    private void OnResumeHandler(PauseResumeEventArgs args)
    {
        PauseResumeStatus = $"File {args.File?.Name} resumed.";
    }

    private void SuccessHandler(SuccessEventArgs args)
    {
        FinalStatus = $"File {args.File?.Name} uploaded successfully. Response: {args.Response}";
    }

    private void FailureHandler(Syncfusion.Blazor.Inputs.FailureEventArgs args)
    {
        FinalStatus = $"File upload failed for {args.File?.Name}. Error: {args.StatusText}";
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LDhoiCrRfOPSTmJm?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}