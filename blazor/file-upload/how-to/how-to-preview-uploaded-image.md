---
layout: post
title: How to preview the uploaded image | Syncfusion
description: Checkout and learn here how to preview the uploaded image in Syncfusion Blazor File Upload component and more.
platform: Blazor
control: File Upload
documentation: ug
---

# How to preview the uploaded image

The following example shows how to preview a selected image in the Syncfusion Uploader component by using a custom template to display the image, file name, and size. The ValueChange (OnChange handler) converts the selected image to a base64-encoded string and updates the preview. This approach works client-side and does not require a server endpoint for preview.

```cshtml
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons
@using System.IO

@inject NavigationManager NavigationManager
<PageTitle>Blazor File Upload Image Preview Example - Syncfusion Demos</PageTitle>

<div class="col-lg-12 control-section">
    <div class="control_wrapper">
        <div class="col-lg-6" id="dropArea">
            <SfUploader @ref="uploadObj" CssClass="@CssClass" AutoUpload="true" AllowedExtensions=".png, .jpg, .jpeg">
                <UploaderButtons Browse="Browse"></UploaderButtons>
                <UploaderTemplates>
                    <Template>
                        @if (!string.IsNullOrEmpty(base64))
                        {
                            <span class="wrapper">
                                <img class="upload-image" alt="Image" src="@base64">
                            </span>
                            <div class="name file-name" title="@context.Name">@context.Name</div>
                            <div class="file-size">@fileSize</div>
                            <span class="e-icons e-file-remove-btn" id="removeIcon" title="Remove" @onclick="@onFileRemove"></span>
                        }
                    </Template>
                </UploaderTemplates>
                <UploaderEvents ValueChange="OnChange"></UploaderEvents>
            </SfUploader>
        </div>
    </div>
</div>

@code {
    private SfUploader uploadObj { get; set; }
    public string CssClass = "custom-file";
    private string base64 { get; set; }
    private string fileSize { get; set; }
    //Hidden:Lines
    private string canonicalURL { get; set; }

    protected override void OnInitialized()
    {
        canonicalURL = NavigationManager.Uri.Split("?")[0];
    }
    //End:Hidden
    private async Task OnChange(UploadChangeEventArgs args)
    {
        base64 = string.Empty;
        foreach (var file in args.Files)
        {
            MemoryStream memoryStream = new MemoryStream();
            using var fileStream = file.File.OpenReadStream(long.MaxValue);
            await fileStream.CopyToAsync(memoryStream);
            byte[] bytes = memoryStream.ToArray();
            base64 = "data:image/png;base64," + Convert.ToBase64String(bytes);
            fileSize = await uploadObj.BytesToSizeAsync(file.FileInfo.Size);
        }
    }
    private async Task onFileRemove()
    {
        await uploadObj.RemoveAsync();
    }
}
<style>
    .control_wrapper {
        width: 1100px;
    }
    .custom-file.e-control-wrapper {
        margin: 5px 0 -8px 0;
    }
    .custom-file .e-file-select-wrap {
        padding: 0px;
        margin-left: -100px
    }
    .custom-file button.e-css.e-btn.e-upload-browse-btn {
        margin-left: 130px;
        background: none !important;
        border: none;
        padding: 0 !important;
        font-family: inherit;
        color: #ff4081;
        text-decoration: underline;
        cursor: pointer;
        box-shadow: none;
        text-transform: capitalize;
    }
    .custom-file button.e-css.e-btn.e-upload-browse-btn:hover {
        background: none !important;
        border: none;
        padding: 0 !important;
        font-family: inherit;
        color: #ff4081;
        text-decoration: underline;
        cursor: pointer;
        box-shadow: none;
        text-transform: capitalize;
    }
    #dropArea .e-upload-files .e-file-delete-btn.e-icons,
    #dropArea .e-upload-files .e-file-remove-btn.e-icons,
    #dropArea .e-upload-files .e-file-abort-btn {
        top: 120px;
        background-color: white;
        border-radius: 50%;
        font-size: 12px;
        left: 80px;
    }
    #dropArea .e-upload-files li .e-file-remove-btn.e-icons.e-upload-icon {
        font-size: 14px;
        left: 20px;
    }
    #dropArea .e-upload-files li:hover .e-icons {
        visibility: visible;
    }
    #dropArea .e-upload-files li .e-icons {
        visibility: hidden;
    }
    #dropArea .e-upload .e-upload-files .e-icons.e-upload-icon {
        font-family: 'Uploader_Icon';
        speak: none;
        font-size: 16px;
        left: 20px;
        font-style: normal;
        font-weight: normal;
        font-variant: normal;
        text-transform: none;
        line-height: 1;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
    }
    #dropArea .e-upload .e-upload-files .e-icons.e-upload-icon::before {
        content: '\e700';
    }
    #dropArea .e-upload .e-upload-files .e-icons:not(.e-uploaded):hover {
        background-color: #e6e6e6;
        border-color: #adadad;
        color: #333;
    }
    #dropArea .e-upload .e-upload-files .e-upload-file-list {
        border: 0;
        display: inline-block;
        width: 165px;
    }
    .upload-image {
        width: 150px;
        height: 150px;
        display: inline-flex;
        background-size: contain;
        margin: 7px;
        text-align: center;
        line-height: 10;
        border-radius: 5px;
    }
    .upload-image:after {
        content: "";
        position: absolute;
        top: 6px;
        left: 6px;
        width: inherit;
        height: inherit;
        background: lightgray url('http://via.placeholder.com/300?text=Loading...') no-repeat center;
        color: transparent;
        border-radius: 5px;
    }
    div.file-name {
        color: rgb(14 121 32);
        font-size: 14px;
        padding: 3px 10px;
        overflow: hidden;
        text-overflow: ellipsis;
        width: 90%;
        white-space: nowrap;
    }
    div.file-size {
        font-size: 13px;
        padding: 3px 10px;
        overflow: hidden;
    }
    .progressbar {
        background: #ff4081;
        border: none;
        border-radius: 10px;
        height: 4px;
        margin-left: 7px;
        width: 90%;
        top: -60px;
        position: relative;
    }
    #dropArea progress {
        border: none;
        background: #fff;
    }
    progress::-webkit-progress-bar {
        border: none;
        background-color: #ffffff;
    }
    .material progress::-moz-progress-bar {
        border-radius: 2px;
        background-color: #ff4081;
    }
    .material #dropArea span a {
        color: #ff4081;
    }
    @@media all and (-ms-high-contrast: none), (-ms-high-contrast: active) {
        #dropArea .e-upload .e-upload-files .e-file-remove-btn.e-icons, .e-bigger #dropArea .e-upload .e-upload-files .e-file-remove-btn.e-icons {
            padding: 18px 25px 18px 12px;
        }
    }
</style>
```