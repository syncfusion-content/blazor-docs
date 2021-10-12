---
layout: post
title: Getting started - Syncfusion Blazor Server Side App in .NET Core CLI
description: Check out the documentation for Getting started with Syncfusion Blazor, its elements, features, and more.
platform: Blazor
component: Common
documentation: ug
---

<!-- markdownlint-disable MD024 -->

# Getting started with Blazor Server Side App in .NET Core CLI

This article provides a step-by-step introduction to configure Syncfusion Blazor setup, and also to build and run a simple Blazor Server Side application using the [.NET Core CLI](https://dotnet.microsoft.com/download/dotnet/).

> Starting with version 17.4.0.39 (2019 Volume 4), you need to include a valid license key (either paid or trial key) within your applications. Please refer to this [help topic](https://help.syncfusion.com/common/essential-studio/licensing/license-key#blazor) for more information.

## Prerequisites

* [.NET Core SDK 3.1.8](https://dotnet.microsoft.com/download/dotnet/3.1) / [.NET 5.0 SDK](https://dotnet.microsoft.com/download/dotnet/5.0) / [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)

## Create a Blazor Server side project using .NET Core CLI

Run the following command line to create a new Blazor Server application.

```
dotnet new blazorserver -o WebApplication1
cd WebApplication1
```

## Installing Syncfusion Blazor packages in the application

You can use any one of the below standards to install the Syncfusion Blazor library in your application.

### Using Syncfusion Blazor individual NuGet Packages [New standard]

> Starting with Volume 4, 2020 (v18.4.0.30) release, Syncfusion provides [individual NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages/) for our Syncfusion Blazor components. We highly recommend this new standard for your Blazor production applications. Refer to [this section](https://blazor.syncfusion.com/documentation/nuget-packages/#benefits-of-using-individual-nuget-packages) to know the benefits of the individual NuGet packages.

1. Now, add **Syncfusion.Blazor.Calendars** NuGet package to the new application using the following command line. Refer to the [Individual NuGet Packages](https://blazor.syncfusion.com/documentation/nuget-packages/) section for the available NuGet packages.

    ```
    dotnet add package Syncfusion.Blazor.Calendars -v '{:nuget-version:}'
    dotnet restore
    ```

2. The Syncfusion Blazor Calendars package will be included in the newly created project once the installation process is completed.

3. Now, add the Syncfusion Blazor theme to the Blazor Server App.

    a) For **.NET 6.0** project, add the Syncfusion bootstrap4 theme in the `<head>` element of the **~/Pages/_Layout.cshtml** page.

    ```html
    <head>
        ....
        ....
        <link href="_content/Syncfusion.Blazor.Themes/bootstrap4.css" rel="stylesheet" />
    </head>
    ```

    b) For **.NET 5.0** or **.NET Core SDK 3.1** project, add the Syncfusion bootstrap4 theme in the `<head>` element of the **~/Pages/_Host.cshtml** page.

    ```html
    <head>
        ....
        ....
        <link href="_content/Syncfusion.Blazor.Themes/bootstrap4.css" rel="stylesheet" />
    </head>
    ```

    W> `Syncfusion.Blazor` package should not be installed along with [individual NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages/). Hence, you have to add the above `Syncfusion.Blazor.Themes` static web assets (styles) in the application.

### Using Syncfusion.Blazor NuGet Package [Old standard]

W> If you prefer the above new standard (individual NuGet packages), then skip this section. Using both old and new standards in the same application will throw ambiguous compilation errors.

1. Now, add **Syncfusion.Blazor** NuGet package to the new application using the following command line.

    ```bash
    dotnet add package Syncfusion.Blazor -v '{:nuget-version:}'
    dotnet restore
    ```

2. The Syncfusion Blazor package will be included in the newly created project once the installation process is completed.

3. Now, add the Syncfusion Blazor theme to the Blazor Server App.

    a) For **.NET 6.0** project, add the Syncfusion bootstrap4 theme in the `<head>` element of the **~/Pages/_Layout.cshtml** page.

    ```html
    <head>
        ....
        ....
        <link href="_content/Syncfusion.Blazor.Themes/bootstrap4.css" rel="stylesheet" />
    </head>
    ```

    b) For **.NET 5.0** or **.NET Core SDK 3.1** project, add the Syncfusion bootstrap4 theme in the `<head>` element of the **~/Pages/_Host.cshtml** page.

    ```html
    <head>
        ....
        ....
        <link href="_content/Syncfusion.Blazor.Themes/bootstrap4.css" rel="stylesheet" />
    </head>
    ```

    > The same theme file can be referred through the CDN version by using [https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/styles/bootstrap4.css](https://cdn.syncfusion.com/blazor/19.2.46/styles/bootstrap4.css).

## Adding Syncfusion Blazor component and running the application

1. Open **~/_Imports.razor** file and import the `Syncfusion.Blazor` namespace.

    ```cshtml
    @using Syncfusion.Blazor
    @using Syncfusion.Blazor.Calendars
    ```

2. Now, register the Syncfusion Blazor Service to the Blazor Server App.

    a) For **.NET 6.0** project, open the **~/Program.cs** file and register the Syncfusion Blazor Service.

    ```c#
    // For .NET 6.0 project, add the Syncfusion Blazor Service in Program.cs file.
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Web;
    using Syncfusion.Blazor;

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();
    ....
    builder.Services.AddSyncfusionBlazor();
    var app = builder.Build();
    ....
    ....
    ```

    b) For **.NET 5.0** or **.NET Core SDK 3.1** project, open the **~/Startup.cs** file and register the Syncfusion Blazor Service.

    ```c#
    // For .NET 5.0 or .NET Core SDK 3.1 project, add the Syncfusion Blazor Service in Startup.cs file.
    using Syncfusion.Blazor;

    namespace WebApplication1
    {
        public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
            {
                ....
                ....
                services.AddSyncfusionBlazor();
            }
        }
    }
    ```

    > We can disable the dynamic script rendering and refer the scripts from application end by using `IgnoreScriptIsolation` parameter in `AddSyncfusionBlazor()` at the `Program.cs` for `.NET 6.0` project and the `Startup.cs` for `.NET5.0` or `.NET Core SDK 3.1` project. For more details, please refer here for [how to refer custom/CDN resources](../common/custom-resource-generator/#how-to-use-custom-resources-in-the-blazor-application).

3. Now, add the Syncfusion Blazor components in any .razor file in the `~/Pages` folder. For example, the calendar component is added in the **~/Pages/Index.razor** page.

    ```cshtml
    <SfCalendar TValue="DateTime"></SfCalendar>
    ```

4. Run `dotnet run` command to run the application. the Syncfusion Blazor Calendar component will be rendered in the default web browser.

    ![output](images/browser-output.png)
