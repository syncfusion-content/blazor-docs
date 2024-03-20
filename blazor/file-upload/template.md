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