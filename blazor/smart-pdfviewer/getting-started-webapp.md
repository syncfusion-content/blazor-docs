---
layout: post
title: Getting started with Syncfusion Smart PdfViewer in Blazor Web App
description: Checkout and learn here all about Getting started with Syncfusion Blazor Smart PdfViewer component in Blazor Webapp and more.
platform: Blazor
platform: Blazor
control: Smart PdfViewer
documentation: ug
---
# Getting Started with Smart PdfViewer

This section briefly explains about how to include **Blazor Smart PdfViewer** component in your Blazor Web App using [Visual Studio](https://visualstudio.microsoft.com/vs/) and Visual Studio code.

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documNow, register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service in the **~/Program.cs** file of your Blazor Web App.

entation/system-requirements)
* [Azure OpenAI Account](https://learn.microsoft.com/en-us/azure/ai-services/openai/how-to/create-resource)

## Create a new Blazor Web App in Visual Studio

You can create a **Blazor Web App** using Visual Studio 2022 via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor SfSmartPdfViewer NuGet in the App

To add **Blazor Smart PdfViewer** component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search and install [Syncfusion.Blazor.SfSmartPdfViewer](https://www.nuget.org/packages?q=Syncfusion.Blazor.SfSmartPdfViewer).

![Blazor SfSmartPdfViewer NuGet](Images/Blazor-web-App-visual-studio.png)

Now, register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service in the **~/Program.cs** file of your Blazor Web App.

{% tabs %}
{% highlight C# tabtitle="Blazor web App" hl_lines="1 9 12" %}
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
	
builder.Services.AddSignalR(o => { o.MaximumReceiveMessageSize = 102400000; });
builder.Services.AddMemoryCache();

builder.Services.AddSyncfusionBlazor();	

....

{% endhighlight %}
{% endtabs %}

## Configure AI Service

To configure the AI service, add the following settings to the **~/Program.cs** file in your Blazor Web app.

{% tabs %}
{% highlight C# tabtitle="Blazor Web App" hl_lines="11 12 13 16" %}

using Syncfusion.Blazor;
using Syncfusion.Blazor.AI;
var builder = WebApplication.CreateBuilder(args);

....

builder.Services.AddSyncfusionBlazor();

// For OpenAI configuration
builder.Services.AddSingleton(new AIServiceCredentials
{
    ApiKey = "api-key",
    DeploymentName = "deployment-name",
    Endpoint = "end point url"
});

builder.Services.AddSingleton<IChatInferenceService,SyncfusionAIService>();
var app = builder.Build();

...
{% endhighlight %}
{% endtabs %}

Here,

* **apiKey**: "Azure OpenAI API Key";
* **deploymentName**: "Azure OpenAI deployment name";
* **endpoint**: "Azure OpenAI deployment end point URL";

For **Azure OpenAI**, first [deploy an Azure OpenAI Service resource and model](https://learn.microsoft.com/en-us/azure/ai-services/openai/how-to/create-resource), then values for `apiKey`, `deploymentName` and `endpoint` will all be provided to you.

## Adding Blazor SfSmartPdfViewer component
Add the Syncfusion<sup style="font-size:70%">&reg;</sup> **Blazor Smart PdfViewer** component in the **~Pages/Home.razor** file.

{% tabs %}
{% highlight razor tabtitle="~/Home.razor" %}

<div>
    <Syncfusion.Blazor.SmartPdfViewer.SfSmartPdfViewer id="pdf-viewer" Height="100%" Width="100%" DocumentPath="wwwroot/Fsharp_Succinctly.pdf">

    </Syncfusion.Blazor.SmartPdfViewer.SfSmartPdfViewer>
</div>
<style>
    #pdf-viewer_SmartPdfViewer .e-pv-smart-assistanceview .ai-assist-banner {
        display: none;
    }
</style>

{% endhighlight %}
{% endtabs %}