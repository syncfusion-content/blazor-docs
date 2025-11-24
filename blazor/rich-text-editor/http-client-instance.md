---
layout: post
title: HttpClientInstance in Blazor RichTextEditor Component | Syncfusion
description: Checkout and learn here all about HttpClientInstance in Syncfusion Blazor RichTextEditor component and much more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# HttpClientInstance in Blazor RichTextEditor Component

The Rich Text Editor component in Blazor enables you to utilize the `HttpClientInstance` property to append the custom HttpClient instance to all file upload and download requests. This approach offers flexibility in managing authentication and custom request configurations for Word Import, Word and PDF Export and image/audio/video insertions.

The following example illustrates how to configure the Rich Text Editor component with HttpClient in a Blazor application.

```razor
@using Syncfusion.Blazor.RichTextEditor
@inject HttpClient httpClient

<SfRichTextEditor HttpClientInstance="@httpClient">
    <RichTextEditorImageSettings SaveUrl="https://your_api.com/upload/image">
    </RichTextEditorImageSettings>
    <RichTextEditorAudioSettings SaveUrl="https://your_api.com/upload/audio">
    </RichTextEditorAudioSettings>
    <RichTextEditorVideoSettings SaveUrl="https://your_api.com/upload/video">
    </RichTextEditorVideoSettings>
</SfRichTextEditor>

@code {
    protected override async Task OnInitializedAsync()
    {
        // Adding authorization header to HTTP client
        httpClient.DefaultRequestHeaders.Add("Authorization_1", "syncfusion");
        await base.OnInitializedAsync();
    }
}
```

## Program.cs

```csharp
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

```
