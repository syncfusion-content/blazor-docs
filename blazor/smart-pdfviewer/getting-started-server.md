---
layout: post
title: Getting started with SfSmartPdfViewer in Blazor Server App
description: Checkout and learn here all about Getting started with SfSmartPdfViewer component in Blazor Server and more.
platform: Blazor
platform: Blazor
control: SfSmartPdfViewer
documentation: ug
---
# Getting Started with Smart PdfViewer

This section briefly explains about how to include **Blazor Smart PdfViewer** component in your Blazor Server App using [Visual Studio](https://visualstudio.microsoft.com/vs/) and Visual Studio code.

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documNow, register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service in the **~/Program.cs** file of your Blazor Web App.

entation/system-requirements)
* [Azure OpenAI Account](https://learn.microsoft.com/en-us/azure/ai-services/openai/how-to/create-resource)

## Create a new Blazor Server App in Visual Studio

You can create a **Blazor Server App** using Visual Studio 2022 via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor SfSmartPdfViewer NuGet in the App

To add **Blazor Smart PdfViewer** component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search and install [Syncfusion.Blazor.SfSmartPdfViewer](https://www.nuget.org/packages?q=Syncfusion.Blazor.SfSmartPdfViewer).

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

* In the **~/_Imports.razor** file, add the following namespaces:

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor;
@using Syncfusion.Blazor.SfPdfViewer;

{% endhighlight %}
{% endtabs %}

* Register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service in the **~/Program.cs** file.

{% tabs %}
{% highlight c# tabtitle="~/Program.cs" hl_lines="3 11 14" %}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddSignalR(o => { o.MaximumReceiveMessageSize = 102400000; });

// Add Syncfusion Blazor service to the container.
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();

{% endhighlight %}
{% endtabs %}

## Configure AI Service

To configure the AI service, add the following settings to the **~/Program.cs** file in your Blazor Server app.

{% tabs %}
{% highlight C# tabtitle="Blazor Server App" hl_lines="11 12 13 16" %}

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

## Adding stylesheet and script

Add the following stylesheet and script to the head section. The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Reference the stylesheet and script in the `<head>` of the main page as follows:

* For **.NET 6** Blazor Server app, include it in **~/Pages/_Layout.cshtml** file.

* For **.NET 7** Blazor Server app, include it in the **~/Pages/_Host.cshtml** file.

{% tabs %}
{% highlight cshtml %}

<head>
    <!-- Syncfusion Blazor PDF Viewer control's theme style sheet -->
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <!-- Syncfusion Blazor PDF Viewer control's scripts -->
    <script src="_content/Syncfusion.Blazor.SfPdfViewer/scripts/syncfusion-blazor-sfpdfviewer.min.js" type="text/javascript"></script>
</head>

{% endhighlight %}
{% endtabs %}


## Adding Blazor SfSmartPdfViewer component
Add the Syncfusion<sup style="font-size:70%">&reg;</sup> **Blazor Smart PdfViewer** component in the **~Pages/Index.razor** file.

{% tabs %}
{% highlight razor tabtitle="~/Index.razor" %}

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

N> If you don't provide the [DocumentPath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_DocumentPath) property value, the PDF Viewer component will be rendered without loading the PDF document. Users can then use the **open** option from the toolbar to browse and open the PDF as required.