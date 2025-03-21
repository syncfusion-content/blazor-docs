---
layout: post
title: HTTP Client in Blazor File Upload Component | Syncfusion
description: Learn about using HTTP Client with the Syncfusion Blazor File Upload component for handling file uploads with customized requests.
platform: Blazor
control: File Upload
documentation: ug
---

# HTTP Client in Blazor File Upload Component

The File Upload component in Blazor allows you to append the HttpClient instance to file upload requests with customized request headers and form data. This approach provides flexibility in handling authentication, sequential uploads, and custom request configurations.

The following example demonstrates how to set up the File Upload component with HttpClient in a Blazor application. The sample includes configuration options for auto upload and sequential upload modes, along with custom headers for authentication.

```cshtml
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons
@inject HttpClient httpClient;

<div class="col-lg-12">
    <div class="col-lg-8 control-section sb-property-border">
        <div class="control-wrapper">
            <SfUploader HttpClientInstance="@httpClient">
                <UploaderAsyncSettings SaveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Save"
                                       RemoveUrl="https://blazor.syncfusion.com/services/production/api/FileUploader/Remove"></UploaderAsyncSettings>
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
        BaseAddress = new Uri("https://yourapi.com/")
    };

    // Add custom header
     httpClient.DefaultRequestHeaders.Add("Custom-Header", "YourCustomValue");
    return httpClient;
});
var app = builder.Build();
....

{% endhighlight %}
{% endtabs %}