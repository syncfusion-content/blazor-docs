---
layout: post
title: Customize the default file upload message in the Blazor File Upload
description: Learn how to customize the default file upload message in the Syncfusion Blazor File Upload component.
platform: Blazor
control: File Upload
documentation: ug
---

# Customize the File Upload Components' default message

You can customize the File Upload Components' default message using the [Success](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.UploaderEvents.html#Syncfusion_Blazor_Inputs_UploaderEvents_Success) event.

The following example demonstrates how to customize the File Upload Components' default message.

```cshtml
@using Syncfusion.Blazor.Inputs
<SfUploader>
    <UploaderEvents Success="@OnSuccessHandler" ></UploaderEvents>
</SfUploader>
@code {
    private void OnSuccessHandler(SuccessEventArgs args)
    {
        var FileName = args.File.Name;    
        args.StatusText = FileName+" uploaded Successfully";
    }
}
```