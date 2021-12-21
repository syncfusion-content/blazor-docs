---
layout: post
title: Blazor ASP.NET Core Hosted App in .NET Core CLI - Syncfusion Blazor
description: Check out the documentation for Getting started with Syncfusion Blazor - Blazor ASP.NET Core Hosted App in .NET Core CLI.
platform: Blazor
component: Common
documentation: ug
---
<!-- markdownlint-disable MD024 -->

# Getting started with Blazor ASP.NET Core Hosted App in .NET Core CLI

This articles provides a step-by-step instructions for building Blazor ASP.NET Core Hosted application with `Blazor Calendar` components using [.NET Core CLI](https://dotnet.microsoft.com/download/dotnet/).

## Prerequisites

* [System requirements for Blazor Application](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a Blazor ASP.NET Core Hosted project using .NET Core CLI

Run the `dotnet new blazorwasm` command to create a new Blazor WebAssembly application in the command prompt (Windows) or terminal (Linux or macOS).

```
dotnet new blazorwasm -o BlazorWasmHosted --hosted
cd BlazorWasmHosted
```

This command creates new Blazor App project and places it in a new directory called BlazorApp inside your current location. See [Create Blazor App topic](https://dotnet.microsoft.com/en-us/learn/aspnet/blazor-tutorial/create) and [dotnet new CLI command](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new) topics for more details.

> If you have installed multiple SDK versions and need any specific framework version (net5.0/netcoreapp3.1) project, then add `-f` flag along with `dotnet new blazorwasm` comment. Refer [here](https://docs.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-5.0&pivots=windows) for the available options.

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

Add the Syncfusion bootstarp5 theme in the `<head>` element of the **~/wwwroot/index.html** page in **`Client`[BlazorWasmHosted.Client]** project.

{% tabs %}
{% highlight html %}
<head>
    ...
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>
{% endhighlight %}
{% endtabs %}

## Add Script Reference

Checkout [Adding Script Reference topic](https://blazor.syncfusion.com/documentation/common/adding-script-references) to learn different ways to add script reference in Blazor Application. In this getting started walk-through, the required scripts are referenced automatically via javascript isolation approach.

> Syncfusion recommends to reference scripts using [Static Web Assets](https://blazor.syncfusion.com/documentation/common/adding-script-references#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/common/adding-script-references#cdn-reference) and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator) by [disabling JavaScript isolation](https://blazor.syncfusion.com/documentation/common/adding-script-references#disable-javascript-isolation) for better loading performance of the Blazor application.

## Register Syncfusion Blazor Service

* Open **~/_Imports.razor** file in **`Client`[BlazorWasmHosted.Client]** project and import the `Syncfusion.Blazor` namespace.

    {% tabs %}
    {% highlight razor %}

    @using Syncfusion.Blazor

    {% endhighlight %}
    {% endtabs %}

* Now, Open the **~/Program.cs** file in the **`Client`[BlazorWasmHosted.Client]** project and register the Syncfusion Blazor Service.

* For .NET 6 app,

  {% tabs %}
  {% highlight c# %}

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
    {% highlight c# %}

    using Syncfusion.Blazor;

    namespace BlazorWasmHosted.Client
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

## Adding Syncfusion Blazor component and running the application

* Open **~/_Imports.razor** file in **`Client`[BlazorWasmHosted.Client]** project and import the `Syncfusion.Blazor.Calendars` namespace.

    {% tabs %}
    {% highlight razor %}

    @using Syncfusion.Blazor
    @using Syncfusion.Blazor.Calendars
    
    {% endhighlight %}
    {% endtabs %}

* Now, add the Syncfusion Calendar component in razor file. Here, the Calendar component is added in the **~/Pages/Index.razor** page under the `~Pages` folder of **`Client`[BlazorWasmHosted.Client]** project.

    {% tabs %}
    {% highlight razor %}
    
    <SfCalendar TValue="DateTime"></SfCalendar>
    
    {% endhighlight %}
    {% endtabs %}

* Navigate to the **`Server`[BlazorWasmHosted.Server]** project and run the following command to run the application in the command prompt (Windows) or terminal (Linux or macOS).

    ```
    dotnet run
    ```

    ![Blazor Calendar Component](images/core-hosted/browser-output.png)

    > For ASP.NET Core Hosted Blazor application, the **`Server`[BlazorWasmHosted.Server]** project should be the startup project.

    > You need to include a valid license key (either paid or trial key) within your applications. Please refer to this [help topic](https://blazor.syncfusion.com/documentation/getting-started/license-key/overview) for more information.


## See Also

* [ASP.NET Core Blazor hosting models](https://docs.microsoft.com/en-us/aspnet/core/blazor/hosting-models?view=aspnetcore-5.0)
