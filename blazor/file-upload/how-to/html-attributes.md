---
layout: post
title: Adding html attributes in Blazor File Upload Component | Syncfusion
description: Learn here all about adding html attributes such as name, value etc. in Blazor File Upload Component and more details.
platform: Blazor
control: File Upload
documentation: ug
---

# Adding HTML attributes in Blazor File Upload component

Add additional HTML attributes (such as disabled, value, name, and more) to the uploader element by using the [HtmlAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfUploader.html#Syncfusion_Blazor_Inputs_SfUploader_HtmlAttributes) property. When both a component property and an equivalent HTML attribute are configured, the component property value takes precedence. Use this approach to set native input attributes or boolean flags (for example, “disabled”) directly on the underlying element.

The following example demonstrates how to set attributes through the HtmlAttributes property in the uploader.

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