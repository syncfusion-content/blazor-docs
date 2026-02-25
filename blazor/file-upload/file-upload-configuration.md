---
layout: post
title: File Upload Configuration in Blazor File Upload Component | Syncfusion
description: Checkout and learn here all about File Upload Configuration in Syncfusion Blazor File Upload component and much more.
platform: Blazor
control: File Upload
documentation: ug
---

# File Upload Configuration

The Syncfusion Blazor FileUpload component offers a wide range of properties to configure its behavior and appearance.

## ID

The [`ID`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfUploader.html#Syncfusion_Blazor_Inputs_SfUploader_ID) property is used to provide a unique identifier for the FileUpload component. This is useful for referencing the component in JavaScript or CSS, and for ensuring accessibility.

```cshtml
<SfUploader ID="myFileUploadComponent" name="UploadFiles" />
```

> Note: Ensure the `ID` is unique across your application. When using AsyncSettings, the `name` must match the controller's save method parameter name.

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjryjYhTgSOYvHEJ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

---

## AllowedExtensions

The [`AllowedExtensions`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfUploader.html#Syncfusion_Blazor_Inputs_SfUploader_AllowedExtensions)property specifies the file types that can be uploaded. This is crucial for validating user uploads and ensuring only acceptable file formats are accepted.

```cshtml
<SfUploader AllowedExtensions=".jpg,.jpeg,.png,.gif" />
```

>Note: Multiple extensions should be separated by commas.

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNryjOhzKHgiZDmV?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

---

## AllowMultiple

The [`AllowMultiple`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfUploader.html#Syncfusion_Blazor_Inputs_SfUploader_AllowMultiple) property determines whether the user can select multiple files for upload at once. Set to `true` for scenarios where multiple documents or images need to be uploaded simultaneously.

```cshtml
<SfUploader AllowMultiple="true" />
```

>Note: When `AllowMultiple` is `false`, only one file can be selected at a time.

{% previewsample "https://blazorplayground.syncfusion.com/embed/htVojOhTKxefALsN?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

---

## AutoUpload

The [`AutoUpload`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfUploader.html#Syncfusion_Blazor_Inputs_SfUploader_AutoUpload) property controls whether files are uploaded immediately after selection. Set to `true` for instant uploads, useful for quick submissions.

```cshtml
<SfUploader AutoUpload="true" />
```

If [`AutoUpload`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfUploader.html#Syncfusion_Blazor_Inputs_SfUploader_AutoUpload) is `false`, you'll typically need to upload a file manually on upload button click.

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNrStOhTKnuyPkKt?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

---

## SequentialUpload

The [`SequentialUpload`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfUploader.html#Syncfusion_Blazor_Inputs_SfUploader_SequentialUpload)property, when [`AllowMultiple`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfUploader.html#Syncfusion_Blazor_Inputs_SfUploader_AllowMultiple) is `true`, specifies whether selected files should be uploaded one after another or concurrently. Use `true` for sequential processing, which can be useful for server resource management.

```cshtml
<SfUploader AllowMultiple="true" SequentialUpload="true" />
```

>Note: This property is only effective when `AllowMultiple` is `true`.

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjhSjkLpqQTZKrlg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

---

## DirectoryUpload

The [`DirectoryUpload`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfUploader.html#Syncfusion_Blazor_Inputs_SfUploader_DirectoryUpload) property enables users to select and upload an entire directory instead of individual files. This is useful for uploading complex folder structures.

```cshtml
<SfUploader DirectoryUpload="true" />
```

>Note: Browser support for directory upload may vary.

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtLeDOBfgceWwSNY?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

---

## Enabled

The [`Enabled`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfUploader.html#Syncfusion_Blazor_Inputs_SfUploader_Enabled) property controls whether the FileUpload component is interactive or disabled. This is useful for temporarily preventing file uploads, for example, until certain form conditions are met.

```cshtml
<SfUploader Enabled="false" />
```

>Note: When disabled, users cannot interact with the upload area.

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjLeNkVfKcOhxybv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

---

## MaxFileSize

The [`MaxFileSize`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfUploader.html#Syncfusion_Blazor_Inputs_SfUploader_MaxFileSize) property sets the maximum allowable size for a single file upload in bytes. This helps prevent excessively large files from being uploaded, which can impact server performance or storage.

```cshtml
<SfUploader MaxFileSize="5242880" /> @* 5 MB *@
```

>Note: The value is in bytes. Make sure your server-side configuration also handles maximum file sizes appropriately.

{% previewsample "https://blazorplayground.syncfusion.com/embed/htVStkLpqlnsPFdX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


---

## MinFileSize

The [`MinFileSize`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfUploader.html#Syncfusion_Blazor_Inputs_SfUploader_MinFileSize) property sets the minimum allowable size for a single file upload in bytes. This can be used to prevent the upload of empty or insignificant files.

```cshtml
<SfUploader MinFileSize="1024" /> @* 1 KB *@
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXVotaVTUYsmdyXM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

---

## EnableHtmlSanitizer

The [`EnableHtmlSanitizer`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfUploader.html#Syncfusion_Blazor_Inputs_SfUploader_EnableHtmlSanitizer) property, when set to `true`, sanitizes the file names to remove potentially harmful HTML content. This is a security measure to prevent cross-site scripting (XSS) attacks through malicious file names.

```cshtml
<SfUploader EnableHtmlSanitizer="true" />
```

>Note: It's recommended to keep this property `true` for security reasons, especially in public-facing applications.

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtBeNYVfUOhomymd?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## EnablePersistence

The [`EnablePersistence`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfUploader.html#Syncfusion_Blazor_Inputs_SfUploader_EnablePersistence) property, when `true`, allows the component's state (e.g., uploaded files list) to be maintained even after a page reload. This improves user experience by preserving progress.

```cshtml
<SfUploader EnablePersistence="true" ID="UploadFiles" >
</SfUploader>
```

>Note: Requires unique `ID` for proper functionality.

---

## EnableRtl

The [`EnableRtl`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfUploader.html#Syncfusion_Blazor_Inputs_SfUploader_EnableRtl) property enables Right-to-Left (RTL) rendering for cultures that read from right to left. This is important for internationalization and accessibility.

```cshtml
<SfUploader EnableRtl="true" />
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZhINEhJpCTkMvdI?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

---

## HtmlAttributes

The [`HtmlAttributes`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfUploader.html#Syncfusion_Blazor_Inputs_SfUploader_HtmlAttributes) property allows you to add custom HTML attributes to the root element of the FileUpload component. This is useful for applying custom styling, data attributes, or other HTML properties not directly exposed as Blazor parameters.

```cshtml
<SfUploader HtmlAttributes="@(new Dictionary<string, object>() { { "data-custom-attribute", "fileupload-data" }, { "class", "my-custom-uploader" } })" />
```

>Note: This property accepts a `Dictionary<string, object>`.

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNLoDYrpTrbUcwZq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

---

## InputAttributes

The [`InputAttributes`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfUploader.html#Syncfusion_Blazor_Inputs_SfUploader_InputAttributes) property allows you to add custom HTML attributes specifically to the underlying `input type="file"` element within the FileUpload component. This is useful for applying browser-specific input attributes or custom event handlers.

```cshtml
<SfUploader InputAttributes="@(new Dictionary<string, object>() { { "accept", "image/*" } })" />
```

>Note: This property accepts a `Dictionary<string, object>`. Be cautious not to override essential attributes managed by the component.

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZBetuhfzUNEgeqP?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

---

## TabIndex

The [`TabIndex`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfUploader.html#Syncfusion_Blazor_Inputs_SfUploader_TabIndex) property specifies the tab order of the FileUpload component relative to other focusable elements on the page. This is important for keyboard navigation and accessibility.

```cshtml
<input type="text" TabIndex="1" /><br />
<SfUploader TabIndex="2" />
<input type="text" TabIndex="3" />
```

>Note: A value of 0 means the element will be focused in the default tab order. Negative values remove the element from the tab order.

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNhotYhzzqUHHLgt?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


## Preloaded files

The FileUpload component supports displaying a list of files that are already available on the server as ["UploaderUploadedFiles"](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderUploadedFiles.html#properties) files. This is useful for editing scenarios where users need to see and potentially remove existing files before uploading new ones.

```cshtml
 <SfUploader>
    <UploaderFiles>
        <UploaderUploadedFiles Name="Nature" Size=500000 Type=".png"></UploaderUploadedFiles>
        <UploaderUploadedFiles Name="TypeScript Succinctly" Size=12000 Type=".pdf"></UploaderUploadedFiles>
        <UploaderUploadedFiles Name="ASP.NET Webhooks" Size="500000" Type=".docx"></UploaderUploadedFiles>
    </UploaderFiles>
</SfUploader>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDBytuBzpzikFnSt?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

