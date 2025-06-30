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

`Note:` File restrictions apply when uploading images to the Image Editor, whether through the open method or the built-in uploader. If uploadSettings is not defined in the sample, the Image Editor, by default, allows files with .jpg, .png, .svg, .webp and .bmp extensions, without any file size restrictions.

## Allowed image extensions

The Image Editor allows users to specify acceptable file extensions for uploaded images using the [`ImageEditorUploadSettings.AllowedExtensions`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorUploadSettings.html#Syncfusion_Blazor_ImageEditor_ImageEditorUploadSettings_AllowedExtensions) property, ensuring that only supported formats, such as `.jpg`, `.png`, `.svg`,  `.webp` and `.bmp` are allowed. This helps maintain compatibility and prevents errors caused by unsupported file types. By default, the Image Editor allows files with .jpg, .png, .svg, .webp, and .bmp  extensions.

`Note:` To specify allowed extensions in the upload settings, use the format '.png, .svg', listing the permitted file types as a comma-separated string.

Here is an example of configuring image restrictions using the `ImageEditorUploadSettings` property.

```cshtml
@using Syncfusion.Blazor.ImageEditor
@using Syncfusion.Blazor.Buttons

<div style="padding-bottom: 15px">
    <SfButton OnClick="LoadInvalidImage">Load Invalid Image</SfButton>
</div>

<SfImageEditor @ref="ImageEditor" Height="400">
    <ImageEditorUploadSettings AllowedExtensions="@AllowedExtensions"></ImageEditorUploadSettings>
</SfImageEditor>
@code {
    private SfImageEditor ImageEditor;
    string AllowedExtensions = ".jpg, .svg";
    private async void LoadInvalidImage()
    {
        await ImageEditor.OpenAsync("https://ej2.syncfusion.com/react/demos/src/image-editor/images/bridge.png");
    }
}
```

![Blazor Image Editor with Image file type restriction](./images/blazor-image-editor-file-type-restrict.jpg)

## Minimum and maximum image size

The Image Editor allows users to specify the minimum and maximum size limits for uploaded image files by using the [ImageEditorUploadSettings.MinFileSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorUploadSettings.html#Syncfusion_Blazor_ImageEditor_ImageEditorUploadSettings_MinFileSize) and [ImageEditorUploadSettings.MaxFileSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorUploadSettings.html#Syncfusion_Blazor_ImageEditor_ImageEditorUploadSettings_MaxFileSize) properties. This ensures that images meet specific requirements, maintaining consistency and preventing oversized or undersized files from being processed.

`Note:` Users can also upload images as base64 strings, in which case file extension validation is bypassed, but file size restrictions still apply.

Here is an example of configuring image restrictions using the `ImageEditorUploadSettings` property.

```cshtml
@using Syncfusion.Blazor.ImageEditor
@using Syncfusion.Blazor.Buttons

<div style="padding-bottom: 15px">
    <SfButton OnClick="LoadInvalidImage">Load Invalid Image</SfButton>
</div>

<SfImageEditor @ref="ImageEditor" Height="400">
    <ImageEditorUploadSettings MinFileSize="@MinFileSize" MaxFileSize="@MaxFileSize"></ImageEditorUploadSettings>
</SfImageEditor>
@code {
    private SfImageEditor ImageEditor;
    double MinFileSize = 1;
    double MaxFileSize = 100;
    private async void LoadInvalidImage()
    {
        await ImageEditor.OpenAsync("https://ej2.syncfusion.com/react/demos/src/image-editor/images/bridge.png");
    }
}
```

![Blazor Image Editor with Image file size restriction](./images/blazor-image-editor-file-size-restrict.jpg)