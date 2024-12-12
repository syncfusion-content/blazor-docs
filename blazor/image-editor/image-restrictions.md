---
layout: post
title: Image Restrictions with Blazor Image Editor Component | Syncfusion
description: Checkout the Image Restrictions available in Blazor Image Editor component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Image Editor
documentation: ug
---

# Image Restrictions in the Blazor Image Editor component

The Image Editor allows users to specify image extensions, as well as the minimum and maximum image sizes for uploaded or loaded images using the [`ImageEditorUploadSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorUploadSettings.html) property. End users will receive a clear alert message if an uploaded image does not meet the defined criteria, ensuring a seamless and user-friendly upload experience.

`Note:` File restrictions apply when uploading images to the Image Editor, whether through the open method or the built-in uploader.

## Allowed Image Extensions

The Image Editor allows users to specify acceptable file extensions for uploaded images using the [`ImageEditorUploadSettings.AllowedExtensions`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorZoomSettings.html#Syncfusion_Blazor_ImageEditor_ImageEditorZoomSettings_AllowedExtensions) property, ensuring that only supported formats, such as `.jpg`, `.png`, and `.webp` and `.svg` are allowed. This helps maintain compatibility and prevents errors caused by unsupported file types. By default, the Image Editor allows files with .jpg, .png, .webp, and .svg extensions.

`Note:` To specify allowed extensions in upload settings, use the format: .png, .svg to denote the permitted file types.

Here is an example of configuring image restrictions using the [`uploadSettings`] property.

```cshtml
@using Syncfusion.Blazor.ImageEditor
@using Syncfusion.Blazor.Buttons

<div style="padding-bottom: 15px">
    <SfButton OnClick="LoadInvalidImage">Load Invalid Image</SfButton>
</div>

<SfImageEditor @ref="ImageEditor" Height="400">
<ImageEditorUploadSettings @ref="UploadSettings" AllowedExtensions="@AllowedExtensions"></ImageEditorUploadSettings>
</SfImageEditor>
@code {
    private SfImageEditor ImageEditor;
    string AllowedExtensions = ".jpeg, .jpg";
    private async void LoadInvalidImage()
    {
        await ImageEditor.OpenAsync("nature.png");
    }
}
```

![Blazor Image Editor with Image Restriction](./images/blazor-image-editor-redact.png)

## Minimum and Maximum Image Size

The Image Editor allows users to specify the minimum and maximum size limits for uploaded image files by using the [ImageEditorUploadSettings.MinFileSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorZoomSettings.html#Syncfusion_Blazor_ImageEditor_ImageEditorZoomSettings_MinFileSize) and [ImageEditorUploadSettings.MaxFileSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorZoomSettings.html#Syncfusion_Blazor_ImageEditor_ImageEditorZoomSettings_MaxFileSize) properties. This ensures that images meet specific requirements, maintaining consistency and preventing oversized or undersized files from being processed.

`Note:` Users can also upload images as base64 strings, in which case file extension validation is bypassed, but file size restrictions still apply.

Here is an example of configuring image restrictions using the [`ImageEditorUploadSettings`] property.

```cshtml
@using Syncfusion.Blazor.ImageEditor
@using Syncfusion.Blazor.Buttons

<div style="padding-bottom: 15px">
    <SfButton OnClick="LoadInvalidImage">Load Invalid Image</SfButton>
</div>

<SfImageEditor @ref="ImageEditor" Height="400">
<ImageEditorUploadSettings @ref="UploadSettings" MinFileSize="@MinFileSize" MaxFileSize="@MaxFileSize" ></ImageEditorUploadSettings>
</SfImageEditor>
@code {
    private SfImageEditor ImageEditor;
    double MinFileSize = 1;
    double MaxFileSize = 100;
    private async void LoadInvalidImage()
    {
        await ImageEditor.OpenAsync("nature.png");
    }
}
```

![Blazor Image Editor with Image Restriction](./images/blazor-image-editor-redact.png)