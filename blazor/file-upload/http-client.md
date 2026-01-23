---
layout: post
title: HTTP Client in Blazor File Upload Component | Syncfusion
description: Learn about using HTTP Client with the Syncfusion Blazor File Upload component for handling file uploads with customized requests.
platform: Blazor
control: File Upload
documentation: ug
---

# HTTP Client in Blazor File Upload Component

The File Upload component in Blazor enables you to utilize the [`HttpClientInstance`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfUploader.html#Syncfusion_Blazor_Inputs_SfUploader_HttpClientInstance) property of the `Uploader` component. This property allows you to append a pre-configured `HttpClient` instance to all file upload (SaveUrl) and remove (RemoveUrl) requests. This is particularly useful for centralized management of authentication tokens, custom headers, or other request configurations that need to be consistently applied across multiple HttpClient requests within your application.

The following example illustrates how to configure an `HttpClient` instance and use it with the File Upload component in a Blazor application to include custom headers.

```cshtml
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons
@inject HttpClient httpClient;

<div class="col-lg-12">
    <div class="col-lg-8 control-section sb-property-border">
        <div class="control-wrapper">
            <SfUploader HttpClientInstance="@httpClient">
                <UploaderAsyncSettings SaveUrl="https://your_api.com/Save"
                                       RemoveUrl="https://your_api.com/Remove"></UploaderAsyncSettings>
            </SfUploader>
        </div>
    </div>
</div>

@code {

    protected override async Task OnInitializedAsync()
    {
        // Adding authorization header to HTTP client
        httpClient.DefaultRequestHeaders.Add("Authorization_1", "syncfusion");
        await base.OnInitializedAsync();
    }
}
```

{% tabs %}
{% highlight c# tabtitle="~/_Program.cs" hl_lines="2 9" %}

...
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddScoped(sp =>
{
    var httpClient = new HttpClient
    {
        BaseAddress = new Uri("https://your_api.com/")
    };

    // Add custom header
     httpClient.DefaultRequestHeaders.Add("Custom-Header", "YourCustomValue");
    return httpClient;
});
var app = builder.Build();
....

{% endhighlight %}
{% endtabs %}