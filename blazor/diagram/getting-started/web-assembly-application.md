---
layout: post
title: Getting Started with Diagram Component in Blazor WASM App | Syncfusion
description: Checkout and learn about the documentation for getting started with Blazor Diagram Component in Blazor WASM App.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Getting started with Diagram Component in the Blazor WASM app

In this section, we'll guide you through the process of adding the Blazor Diagram component component to your Blazor WebAssembly (WASM) app. We'll break it down into simple steps to make it easy to follow. Additionally, you can find a fully functional example project on our [GitHub repository](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/DiagramComponent/BlazorWASMApp/DiagramSample).

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)


## Create a new Blazor App in Visual Studio    

You can create a **Blazor WebAssembly App**  using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-7.0) or the [Syncfusion Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

## Install Syncfusion Blazor Diagram and Themes NuGet in the blazor webAssembly App

To add **Blazor Diagram**  component in the app, open the NuGet package manager in Visual Studio (Tools → NuGet Package Manager → Manage NuGet Packages for Solution), search and install [Syncfusion.Blazor.Diagram](https://www.nuget.org/packages/Syncfusion.Blazor.Diagram) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/). Alternatively, you can utilize the following package manager command to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Diagram -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

## Register Syncfusion Blazor Service

* In the **~/_Imports.razor** file, add the following namespaces:

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor;
@using Syncfusion.Blazor.Diagram;

{% endhighlight %}
{% endtabs %}

* Register the Syncfusion Blazor Service in the program.cs file.

{% tabs %}
{% highlight C# tabtitle=".NET 6 & .NET 7 (~/Program.cs)" hl_lines="3 9 13" %}

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSyncfusionBlazor();
await builder.Build().RunAsync();

{% endhighlight %}
{% endtabs %}

## Adding stylesheet and script

Add the following stylesheet and script to the head section of the **wwwroot/index.html** file.

If you are using Syncfusion.Blazor && Syncfusion.Blazor.Themes NuGet package in your application, refer to the following script.
```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="_content/Syncfusion.Blazor/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>
```
If you are using Syncfusion.Blazor.Diagram && Syncfusion.Blazor.Themes NuGet package in your application, refer to the following script.
```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>
```

N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods: ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) referencing themes in your Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references)  topic to learn different approaches for adding script references in your Blazor application.