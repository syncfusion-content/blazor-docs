---
layout: post
title: Chunk Upload in Blazor File Upload Component | Syncfusion
description: Checkout and learn here all about Chunk Upload in Syncfusion Blazor File Upload component and much more.
platform: Blazor
control: File Upload
documentation: ug
---

# Chunk Upload in Blazor File Upload Component

The Uploader sends the large file split into small chunks and transmits to the server using AJAX. You can also pause, resume, and retry the failed chunk file.

N> The chunk upload works in asynchronous upload only.

To enable the chunk upload, set the size to [ChunkSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfUploader.html#Syncfusion_Blazor_Inputs_SfUploader_AsyncSettings) option of the upload and it receives the value in `bytes`. The [OnChunkUploadStart](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_OnChunkUploadStart) event is triggered at the start of chunk upload process.

## Save and remove action for Blazor (ASP.NET Core hosted) application

The server-side implementation entirely depends on the application requirements and logic. The following code snippet provides the server-side logic to handle the chunk upload using the FileUpload components.

>The `chunk-index` and `total-chunk` values are accessible through the form data using `Request.Form`, which retrieves these details from the incoming request.
* `chunk-index` - Indicates the index of the current chunk being received.
* `total-chunk` - Represents the total number of chunks for the file being uploaded.

```csharp
public string uploads = Path.Combine(Directory.GetCurrentDirectory(), "Uploaded Files"); // Set your desired upload directory path

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

            if (UploadFiles.ContentType == "application/octet-stream") //Handle chunk upload
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
            else //Handle normal upload
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
public async Task<IActionResult> Remove(string UploadFiles)
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
```

```cshtml
@using Syncfusion.Blazor.Inputs

<SfUploader ID="UploadFiles">
    <UploaderAsyncSettings SaveUrl="api/SampleData/Save" RemoveUrl="api/SampleData/Remove" ChunkSize="500000"></UploaderAsyncSettings>
    <UploaderEvents OnChunkUploadStart="@OnChunkUploadStartHandler" OnChunkSuccess="@OnChunkSuccessHandler" Success="@SuccessHandler" OnChunkFailure="@OnChunkFailureHandler"></UploaderEvents>
</SfUploader>
@code {
    private void OnChunkUploadStartHandler(UploadingEventArgs args)
    {
        // Here, you can customize your code.
    }
    private void OnChunkSuccessHandler(SuccessEventArgs args)
    {
        // Here, you can customize your code.
    }
    private void SuccessHandler(SuccessEventArgs args)
    {
        // Here, you can customize your code.
    }
    private void OnChunkFailureHandler(FailureEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```


![Blazor FileUpload with Chunk Upload](./images/blazor-fileupload-with-chunk-upload.png)

The chunk upload functionality separates the selected files into blobs of the data or chunks. These chunks are transmitted to the server using an AJAX request. The chunks are sent in **sequential** order, and the next chunk can be sent to the server according to the success of the previous chunk. If any one of the chunks failed, then the remaining chunk cannot be sent to the server. The [ChunkSuccess](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderModel.html#Syncfusion_Blazor_Inputs_UploaderModel_ChunkSuccess) or [ChunkFailure](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderModel.html#Syncfusion_Blazor_Inputs_UploaderModel_ChunkFailure) event will be triggered when the chunk is sent to the server successfully or failed. If all the chunks are sent to the server successfully, the uploader [Success](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_Success) event is triggered.

N> Chunk upload will work when the selected file size is greater than the specified chunk size. otherwise, it upload the files normally.

## Save action configuration in server-side blazor

The uploader save action configuration in server-side blazor application, using MVC via `UseMvcWithDefaultRoute` in ASP.NET Core 3.0 and `services.AddMvc(option => option.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0)` on IServiceCollection requires an explicit opt-in inside **Startup.cs** page. This is required because MVC must know whether it can rely on the authorization and CORS Middle ware during initialization.

```csharp
using Microsoft.AspNetCore.Mvc;

public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc(option => option.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
    services.AddRazorPages();
    services.AddServerSideBlazor();
    services.AddSingleton<WeatherForecastService>();
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
    app.UseMvcWithDefaultRoute();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapBlazorHub<App>(selector: "app");
        endpoints.MapFallbackToPage("/_Host");
    });
}
```

## Additional configurations

To modify the chunk upload, the following options can be used.

* **RetryAfterDelay**: If error occurs while sending any chunk request from JavaScript, hold the operation for 500 milliseconds (by default), and retry the operation using chunk. This can be achieved by using the [AsyncSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfUploader.html#Syncfusion_Blazor_Inputs_SfUploader_AsyncSettings) property. You can modify the holding time interval in milliseconds.

* **RetryCount**: Specifies the number of retry actions performed when the file fails to upload. By default, retry action is performed 3 times. If the file fails to upload continuously, the request is
aborted and the uploader [Failure](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderModel.html#Syncfusion_Blazor_Inputs_UploaderModel_Failure) event will trigger.

The following sample specifies the chunk upload delay with 3000 milliseconds and the retry count is 5. The failure event is triggered as the wrong saveUrl is used.

`SaveUrl` and `RemoveUrl` actions are explained in this [link](./chunk-upload/#save-and-remove-action-for-blazor-aspnet-core-hosted-application).

```cshtml
@using Syncfusion.Blazor.Inputs

<SfUploader ID="UploadFiles">
    <UploaderAsyncSettings SaveUrl="api/SampleData/Save" RemoveUrl="api/SampleData/Remove" ChunkSize=500000 RetryCount=5 RetryAfterDelay =3000>
</UploaderAsyncSettings>
</SfUploader>
```

## Resumable upload

Allows you to resume an upload operation after a network failure or manually interrupts (pause) the upload. You can perform pause and resume upload actions using public methods (pause and resume) and UI interaction. The pause icon is enabled after the upload begins. The [Paused](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_Paused) event is triggered when we pause the uploading file, and the [OnResume](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_OnResume) event is triggered when we click the resume icon to upload the remaining file.

N> The pause and resume features are available only when the chunk upload is enabled.

`SaveUrl` and `RemoveUrl` actions are explained in this [link](./chunk-upload/#save-and-remove-action-for-blazor-aspnet-core-hosted-application).

```cshtml
@using Syncfusion.Blazor.Inputs

<SfUploader ID="UploadFiles">
    <UploaderAsyncSettings SaveUrl="api/SampleData/Save" RemoveUrl="api/SampleData/Remove"  ChunkSize=500000>
</UploaderAsyncSettings>
<UploaderEvents OnResume="@OnResumeHandler" Paused="@PausedHandler"></UploaderEvents>
</SfUploader>
@code {
    private void OnResumeHandler(PauseResumeEventArgs args)
    {
        // Here, you can customize your code.
    }
    private void PausedHandler(PauseResumeEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```


![Resuming File Uploads in Blazor FileUpload](./images/blazor-fileupload-resume-file-upload.png)

## Cancel upload

The uploader component allows you to cancel the uploading file. This can be achieved by clicking the cancel icon or using the `Cancel` method. The [Canceling](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderModel.html#Syncfusion_Blazor_Inputs_UploaderModel_Canceling) event will be fired whenever the file upload request is canceled. While canceling the upload request, the partially uploaded file is removed from the server.

When the request fails, the pause icon is changed to retry icon. By clicking the retry icon, sends the failed chunk request again to the server and upload started from where it is failed. You can retry the canceled upload request again using retry UI or `Retry` methods. But, if you retry this, the file upload action again starts from initial.

The following example explains about chunk upload with cancel support.

`SaveUrl` and `RemoveUrl` actions are explained in this [link](./chunk-upload#save-and-remove-action-for-blazor-aspnet-core-hosted-application).

```cshtml
@using Syncfusion.Blazor.Inputs

<SfUploader ID="UploadFiles">
<UploaderAsyncSettings SaveUrl="api/SampleData/Save" RemoveUrl="api/SampleData/Remove" ChunkSize=500000>
</UploaderAsyncSettings>
</SfUploader>
```


![Canceling File Uploads in Blazor FileUpload](./images/blazor-fileupload-cancel-file-upload.png)

N> The retry action has different working behavior for chunk upload and default upload.
<br/> * Chunk upload: Retries to upload the failed request where it is failed previously.
<br/> * Default upload: Retries to upload the failed file again from initial.