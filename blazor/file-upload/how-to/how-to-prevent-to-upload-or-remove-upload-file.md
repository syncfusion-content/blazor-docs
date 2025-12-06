---
layout: post
title: How to prevent uploading or removing in Uploader | Syncfusion
description: Checkout and learn here how to Preventing File Upload or Removal in Uploader Component in Syncfusion Blazor File Upload component and more.
platform: Blazor
control: File Upload
documentation: ug
---

# How to prevent uploading or removing files in Uploader component

Prevent selected files from being uploaded and block removal when the remove button is clicked by handling Uploader events. The [BeforeUpload](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_BeforeUpload) event fires before the upload begins and can be used to cancel the operation or add custom parameters. The [BeforeRemove](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_BeforeRemove) event fires when a file is about to be removed and can be used to cancel removal (for example, after confirming with the user).

### With server-side API endpoint

```cshtml

@using Syncfusion.Blazor.Inputs
<SfUploader AutoUpload="false">
    <UploaderAsyncSettings SaveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Save"
                           RemoveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Remove"></UploaderAsyncSettings>
    <UploaderEvents BeforeUpload="@BeforeUploadHandler" BeforeRemove="@BeforeRemovehandler"></UploaderEvents>
</SfUploader>
@code {
    private void BeforeUploadHandler(BeforeUploadEventArgs args)
    {
        // You can prevent uploading by setting "Cancel" to true.
        args.Cancel =  true;
    }
    private void BeforeRemovehandler(BeforeRemoveEventArgs args)
    {
        // You can prevent removing by setting "Cancel" to true.
        args.Cancel =  true;
    }
}
```

### Without server-side API endpoint

```cshtml

@using Syncfusion.Blazor.Inputs
<SfUploader AutoUpload="false">
    <UploaderEvents BeforeUpload="@BeforeUploadHandler" BeforeRemove="@BeforeRemovehandler"></UploaderEvents>
</SfUploader>
@code {
    private void BeforeUploadHandler(BeforeUploadEventArgs args)
    {
        // You can prevent uploading by setting "Cancel" to true.
        args.Cancel =  true;
    }
    private void BeforeRemovehandler(BeforeRemoveEventArgs args)
    {
        // You can prevent removing by setting "Cancel" to true.
        args.Cancel =  true;
    }
}
```