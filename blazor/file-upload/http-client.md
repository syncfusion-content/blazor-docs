---
layout: post
title: HTTP Client in Blazor File Upload Component | Syncfusion
description: Learn about using HTTP Client with the Syncfusion Blazor File Upload component for handling file uploads with customized requests.
platform: Blazor
control: File Upload
documentation: ug
---

# HTTP Client in Blazor File Upload Component

The File Upload component in Blazor allows you to use the HttpClient for file upload operations with customized request headers and form data. This approach provides flexibility in handling authentication, sequential uploads, and custom request configurations.

## Basic HTTP Client Setup

The following example demonstrates how to set up the File Upload component with HttpClient in a Blazor application. The sample includes configuration options for auto upload and sequential upload modes, along with custom headers for authentication.

```cshtml
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons
@inject HttpClient httpClient;

<div class="col-lg-12">
    <div class="col-lg-8 control-section sb-property-border">
        <div class="control-wrapper">
            <SfUploader @ref="UploadObj" 
                        AutoUpload="SetAutoUpload" 
                        SequentialUpload="SetSequentialUpload">
                <UploaderEvents BeforeUpload="@before" 
                               OnRemove="OnFileRemove"></UploaderEvents>
                <UploaderAsyncSettings SaveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Save" 
                                     RemoveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Remove"></UploaderAsyncSettings>
            </SfUploader>
        </div>
    </div>
    <div class="col-lg-4">
        <div class='property-panel-section'>
            <div class="property-panel-header">Properties</div>
            <div class="property-panel-content">
                <SfCheckBox Label="Auto upload" 
                           ValueChange="OnAutoChange" 
                           TChecked="bool"></SfCheckBox>
            </div>
            <div class="property-panel-content">
                <SfCheckBox Label="Sequential upload" 
                           ValueChange="OnSequentialChange" 
                           TChecked="bool"></SfCheckBox>
            </div>
        </div>
    </div>
</div>

<style>
    .control-section {
        min-height: 370px;
    }
    .control-wrapper {
        max-width: 350px;
        margin: 0 auto;
        padding: 50px 0px 0px;
    }
    .property-panel-content {
        padding: 0px 0px 20px 0px;
    }
    .property-panel-content:last-child {
        padding: 0px 0px 40px 0px;
    }
</style>

@code {
    SfUploader UploadObj;
    private bool SetAutoUpload { get; set; } = false;
    private bool SetSequentialUpload { get; set; } = false;

    protected override async Task OnInitializedAsync()
    {
        // Adding authorization header to HTTP client
        httpClient.DefaultRequestHeaders.Add("Authorization", "syncfusion _ 1");
        await base.OnInitializedAsync();
    }

    public void OnFileRemove(RemovingEventArgs args)
    {
        // Prevent posting raw file data on removal
        args.PostRawFile = false;
    }

    public void before(BeforeUploadEventArgs e)
    {
        // Add custom form data to the request
        e.CustomFormData = new List<object> { new { Name = "Syncfusion _3" } };
        
        // Set custom request information
        e.CurrentRequest = new List<object> { new { Name = "syncfusion 4" } };
    }

    public void OnAutoChange(Syncfusion.Blazor.Buttons.ChangeEventArgs<bool> args)
    {
        // Clear all files and update auto upload setting
        this.UploadObj.ClearAllAsync();
        this.SetAutoUpload = args.Checked;
    }

    public void OnSequentialChange(Syncfusion.Blazor.Buttons.ChangeEventArgs<bool> args)
    {
        // Clear all files and update sequential upload setting
        this.UploadObj.ClearAllAsync();
        this.SetSequentialUpload = args.Checked;
    }
}
```

![Blazor FileUpload with HTTP Client](./images/blazor-fileupload-drop-area-customization.png)