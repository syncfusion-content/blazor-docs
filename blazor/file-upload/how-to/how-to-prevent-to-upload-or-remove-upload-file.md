---
layout: post
title: How to Preventing File Upload or Removal in Uploader Component | Syncfusion
description: Checkout and learn here how to Preventing File Upload or Removal in Uploader Component in Syncfusion Blazor File Upload component and more.
platform: Blazor
control: File Upload
documentation: ug
---

# How to Preventing File Upload and Removal in Uploader Component

We can prevent the selected file from being uploaded and also prevent the removal of the file when the remove button is clicked on the Uploader component. The [BeforeUpload](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_BeforeUpload) event is triggered before the upload process begins, allowing us to add additional parameters to the upload request. Similarly, the [BeforeRemove](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_BeforeRemove) event is triggered when a file is being removed. This event can be used to obtain confirmation before deleting the file from the server.

### With server-side API endpoint

```cshtml

@using Syncfusion.Blazor.Inputs
<SfUploader AutoUpload="false">
    <UploaderAsyncSettings SaveUrl="https://aspnetmvc.syncfusion.com/services/api/uploadbox/Save"
                           RemoveUrl="https://aspnetmvc.syncfusion.com/services/api/uploadbox/Remove"></UploaderAsyncSettings>
    <UploaderEvents BeforeUpload="@BeforeUploadHandler" BeforeRemove="@BeforeRemovehandler"></UploaderEvents>
</SfUploader>
@code {
    private void BeforeUploadHandler(BeforeUploadEventArgs args)
    {
        // Here, you can customize your code.
    }
    private void BeforeRemovehandler(BeforeRemoveEventArgs args)
    {
        // Here, you can customize your code.
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
        // Here, you can customize your code.
    }
    private void BeforeRemovehandler(BeforeRemoveEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```