---
layout: post
title: Blazor ASP.NET Core Hosted WebAssembly App in Visual Studio - Syncfusion Blazor
description: Check out the documentation for getting started with Blazor ASP.NET Core Hosted WebAssembly App and Syncfusion Blazor Components in Visual Studio.
platform: Blazor
component: Common
documentation: ug
---

<!-- markdownlint-disable MD024 -->

# Getting started with Blazor ASP.NET Core Hosted WebAssembly App in Visual Studio

This article provides a step-by-step instructions for building Blazor ASP.NET Core Hosted WebAssembly application with `Blazor Calendar` components using [Visual Studio](https://visualstudio.microsoft.com/vs/).

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a Blazor ASP.NET Core Hosted WebAssembly App in Visual Studio

You can create Blazor ASP.NET Core Hosted WebAssembly app using Visual Studio in one of the following ways,

* [Create a Project using Microsoft Templates](https://docs.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-5.0&pivots=windows)

* [Create a Project using Syncfusion Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/vs2019-extensions/create-project)

![Blazor Core Hosted Project Structure](images/core-hosted-structure-2022.png)

## Install Syncfusion Blazor Packages in the App

Syncfusion Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). In order to use Syncfusion Blazor components in the application, add reference to the corresponding NuGet. Refer to [NuGet packages topic](https://blazor.syncfusion.com/documentation/nuget-packages) for available NuGet packages list with component details.

To add Blazor Calendar component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search for [Syncfusion.Blazor.Calendars](https://www.nuget.org/packages/Syncfusion.Blazor.Calendars/) and then install it.

## Add Style Sheet

Checkout the [Blazor Themes topic](https://blazor.syncfusion.com/documentation/appearance/themes) to learn different ways to refer themes in Blazor application, and to have the expected appearance for Syncfusion Blazor components. Here, the theme is referred using [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets).

To add theme to the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search for [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) and then install it. Then, the theme style sheet from NuGet can be referred as follows,

* Add the Syncfusion bootstrap5 theme in the `<head>` of **~/wwwroot/index.html** file of client web app.

{% tabs %}
{% highlight cshtml tabtitle="wwwroot/index.html" %}

<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>

{% endhighlight %}
{% endtabs %}

## Add Script reference

Checkout [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different ways to add script reference in Blazor Application. In this getting started walk-through, the required scripts are referenced automatically via javascript script isolation approach.

> Syncfusion recommends to reference scripts using [Static Web Assets](https://blazor.syncfusion.com/documentation/common/adding-script-references#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/common/adding-script-references#cdn-reference) and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator) by [disabling JavaScript isolation](https://blazor.syncfusion.com/documentation/common/adding-script-references#disable-javascript-isolation) for better loading performance of the Blazor application.

## Register Syncfusion Blazor Service

* Open **~/_imports.razor** file and import the `Syncfusion.Blazor` namespace.

    {% tabs %}
    {% highlight razor tabtitle="~/_imports.razor" %}

    @using Syncfusion.Blazor

    {% endhighlight %}
    {% endtabs %}

* Now, Open the **~/Program.cs** file and register the Syncfusion Blazor Service in the client web app.

* For .NET 6 app,

{% tabs %}
{% highlight c# tabtitle="~/Program.cs" hl_lines="10" %}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
....

{% endhighlight %}
{% endtabs %}

* For .NET 5 and .NET 3.x app,

{% tabs %}
{% highlight c# tabtitle="~/Program.cs" hl_lines="11" %}

using Syncfusion.Blazor;

namespace BlazorApp.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            ....
            ....
            builder.Services.AddSyncfusionBlazor();
            await builder.Build().RunAsync();
        }
    }
}

{% endhighlight %}
{% endtabs %}

> You can disable the dynamic script loading and refer to the scripts from the application end by using the `IgnoreScriptIsolation` parameter in `AddSyncfusionBlazor()` at the `Program.cs`. For more details, please refer here for [how to refer custom/CDN resources](../common/custom-resource-generator/#how-to-use-custom-resources-in-the-blazor-application).

## Add Syncfusion Blazor component

* Open **~/_Imports.razor** file or any razor page under the `~/Pages` folder where the component to be added and import the `Syncfusion.Blazor.Calendars` namespace.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Calendars

{% endhighlight %}
{% endtabs %}

* Now, add the Syncfusion Calendar component in razor file. Here, the Calendar component is added in the **~/Pages/Index.razor** page under the `~Pages` folder of the client web app.

{% tabs %}
{% highlight razor %}

<SfCalendar TValue="DateTime"></SfCalendar>

{% endhighlight %}
{% endtabs %}

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the app. Then, the Syncfusion Blazor Calendar component will be rendered in the default web browser.

![Blazor Calendar Component](images/core-hosted/browser-output.png)

> For Blazor ASP.NET Core Hosted WebAssembly application, the **`Server`[BlazorApp.Server]** project should be the startup project.

> You need to include a valid license key (either paid or trial key) within your applications. Please refer to this [help topic](https://blazor.syncfusion.com/documentation/getting-started/license-key/overview) for more information.

## See Also

* [ASP.NET Core Blazor hosting models](https://docs.microsoft.com/en-us/aspnet/core/blazor/hosting-models?view=aspnetcore-5.0)
