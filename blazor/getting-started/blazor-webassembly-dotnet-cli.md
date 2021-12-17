---
layout: post
title: Getting Started - Syncfusion Blazor WebAssembly App in .NET CLI
description: Checkout the documentation for getting started with Blazor WebAssembly App and Syncfusion Blazor Components in Visual Studio using .NET CLI and much more.
platform: Blazor
component: Common
documentation: ug
---

<!-- markdownlint-disable MD024 -->

# Blazor WebAssembly App using .NET CLI

This article provides a step-by-step instructions for building Blazor WebAssembly App with `Blazor Calendar` component using the [.NET CLI](https://dotnet.microsoft.com/download/dotnet/).

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a Blazor WebAssembly project using .NET CLI

Run the `dotnet new blazorwasm` command to create a new Blazor WebAssembly application in the command prompt (Windows) or terminal (Linux or macOS).

```
dotnet new blazorwasm -o BlazorApp
cd BlazorApp
```
This command creates new Blazor app project and places it in a new directory called BlazorApp inside your current location. See [Create Blazor app topic](https://dotnet.microsoft.com/en-us/learn/aspnet/blazor-tutorial/create) and [dotnet new CLI command](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new) topics for more details.

> If you have installed multiple SDK versions and need any specific framework version (net5.0/netcoreapp3.1) project, then add `-f` flag along with `dotnet new blazorwasm` comment. Refer [here](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new#blazorwasm) for the available options.

## Install Syncfusion Blazor packages in the App

Syncfusion Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). In order to use Syncfusion Blazor components in the application, add reference to the corresponding NuGet. Refer to [NuGet packages topic](https://blazor.syncfusion.com/documentation/nuget-packages) for available NuGet packages list with component details.

Add Syncfusion.Blazor.Calendars NuGet package to the application using the following command in the command prompt (Windows) or terminal (Linux and macOS) to install a NuGet package. See [Install and manage packages using the dotnet CLI](https://docs.microsoft.com/en-us/nuget/consume-packages/install-use-packages-dotnet-cli) topics for more details.

```
dotnet add package Syncfusion.Blazor.Calendars --version {{ site.releaseversion }}
```

## Add Style Sheet

Checkout the [Blazor Themes topic](https://blazor.syncfusion.com/documentation/appearance/themes) to learn different ways to refer themes in Blazor application, and to have the expected appearance for Syncfusion Blazor components. Here, the theme is referred using [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets).

To add theme to the app, Add `Syncfusion.Blazor.Themes` NuGet package to the application using the following command in the command prompt (Windows) or terminal (Linux and macOS) to install the NuGet package.

```
dotnet add package Syncfusion.Blazor.Themes --version {{ site.releaseversion }}
```

Add the Syncfusion bootstrap5 theme in the <head> element of the **wwwroot/index.html** file of client web app.

{% tabs %}
{% highlight html %}
<head>
    ...
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>
{% endhighlight %}
{% endtabs %}

## Add Script Reference

Checkout [Adding Script Reference topic](https://blazor.syncfusion.com/documentation/common/adding-script-references) to learn different ways to add script reference in Blazor Application. In this getting started walk-through, the required scripts are referenced automatically via javascript script isolation approach.

> Syncfusion recommends to reference scripts using [Static Web Assets](https://blazor.syncfusion.com/documentation/common/adding-script-references#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/common/adding-script-references#cdn-reference) and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator) by [disabling JavaScript isolation](https://blazor.syncfusion.com/documentation/common/adding-script-references#disable-javascript-isolation) for better loading performance of the Blazor application.

## Register Syncfusion Blazor Service

* Open **~/_Imports.razor** file and import the `Syncfusion.Blazor` namespace.

    {% tabs %}
    {% highlight razor %}

    @using Syncfusion.Blazor

    {% endhighlight %}
    {% endtabs %}

* Now, Open **~/Program.cs** file and register the Syncfusion Blazor Service in the client web app.

    * For .NET 6 app,
    {% tabs %}
    {% highlight c# tabtitle=NET6 %}
    using Microsoft.AspNetCore.Components.Web;
    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Syncfusion.Blazor;

    var builder = WebAssemblyHostBuilder.CreateDefault(args);
    builder.RootComponents.Add<App>("#app");
    builder.RootComponents.Add<HeadOutlet>("head::after");

    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

    builder.Services.AddSyncfusionBlazor();
    await builder.Build().RunAsync();
    ....
    {% endhighlight %}
    {% endtabs %}

    * For **.NET 5 and .NET 3.X** app
    {% tabs %}
    {% highlight c# tabtitle=NET3 and NET5 %}
    using Syncfusion.Blazor;

    namespace BlazorApp
    {
        public class Program
        {
            public static async Task Main(string[] args)
            {
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

* Open **~/_Imports.razor** file or any razor page under the `~/Pages` folder where the component is to be added and import the `Syncfusion.Blazor.Calendars` namespace.
    {% tabs %}
    {% highlight razor %}

    @using Syncfusion.Blazor
    @using Syncfusion.Blazor.Calendars
    
    {% endhighlight %}
    {% endtabs %}
    
* Now, add the Syncfusion Calendar component in .razor file. Here, the Calendar component is added in the `~/Pages/Index.razor` page under the `~/Pages` folder.

    {% tabs %}
    {% highlight razor %}

    <SfCalendar TValue="DateTime"></SfCalendar>

    {% endhighlight %}
    {% endtabs %}

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the app. Then, the Syncfusion Blazor Calendar component will be rendered in the default web browser.

* In the command prompt (Windows) or terminal (Linux and macOS) to run the following command to build and start the app. The app listening on `http://localhost:<port number>` and view it in the browser.

    ```
    dotnet run
    ```

    ![Blazor Calendar Component](images/browser-output.png)

> You need to include a valid license key (either paid or trial key) within your applications. Please refer to this [help topic](https://blazor.syncfusion.com/documentation/getting-started/license-key/overview) for more information.

## See Also

* [Getting Started with Blazor Server App using .NET CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-dotnet-cli)