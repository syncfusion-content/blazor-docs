---
layout: post
title: HTTP Client in Blazor File Upload Component | Syncfusion
description: Learn about using HTTP Client with the Syncfusion Blazor File Upload component for handling file uploads with customized requests.
platform: Blazor
control: File Upload
documentation: ug
---

# HTTP Client in Blazor File Upload Component

The File Upload component supports configuring a custom HTTP pipeline for its network requests via the  [HttpClientInstance](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfUploader.html#Syncfusion_Blazor_Inputs_SfUploader_HttpClientInstance) property to append the HttpClient instance to file upload requests, allowing for customized request headers and form data. This approach offers flexibility in managing authentication and custom request configurations.

The following example illustrates how to configure the File Upload component to use a specific HttpClient instance for SaveUrl and RemoveUrl requests in a Blazor application. This approach applies to Blazor Server and Blazor Web App (Server/Auto). In Blazor WebAssembly, an HttpClient is available by default; register headers either via DI (for a scoped client) or on a per-request basis.

N> - Ensure the API configured in SaveUrl/RemoveUrl permits cross-origin requests if it runs on a different domain (CORS).
- Prefer standard Authorization headers (for example, Bearer tokens) and avoid hardcoding secrets.
- Consider IHttpClientFactory or named clients for production scenarios to manage handlers, retries, and resilience.
- To append additional form data for each file (for example, metadata), use Uploader events such as Uploading/BeforeUpload; headers should be used for auth and routing concerns.
- Handle failures using Uploader events (for example, OnFailure/Success) to surface authorization or validation errors returned by the API.

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