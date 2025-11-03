---
layout: post
title: Adding html attributes in Blazor File Upload Component | Syncfusion
description: Learn here all about adding html attributes such as name, value etc. in Blazor File Upload Component and more details.
platform: Blazor
control: File Upload
documentation: ug
---

# Adding HTML Attributes in Blazor File Upload Component

You can add the additional HTML attributes such as disabled, value, name, and more to the element using the [HtmlAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfUploader.html#Syncfusion_Blazor_Inputs_SfUploader_HtmlAttributes) property. If you configure both the property and equivalent HTML attribute, then the component will consider the property value.

The following example demonstrates how to set attributes in the HtmlAttributes property in the Uploader.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfUploader  HtmlAttributes="@htmlattribute">
    <UploaderAsyncSettings SaveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Save" RemoveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Remove"></UploaderAsyncSettings>
</SfUploader>

@code{

    Dictionary<string, object> htmlattribute = new Dictionary<string, object>()
        {
           { "name", "file-uploader" },
           {"disabled","true" }
        };
}

```
