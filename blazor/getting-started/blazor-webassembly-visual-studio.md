---
layout: post
title: Getting started with Syncfusion Blazor WASM App in Visual Studio
description: Check out the documentation for Getting started with Syncfusion Blazor, its elements, features, and more.
platform: Blazor
component: Common
documentation: ug
---

<!-- markdownlint-disable MD024 -->

# Getting started with Blazor WebAssembly App in Visual Studio

This article provides a step-by-step instructions about how to create Blazor WebAssembly application using [Visual Studio](https://visualstudio.microsoft.com/vs/) with Syncfusion Blazor components setup pre-configured in it.

> Starting with version 17.4.0.39 (2019 Volume 4), you need to include a valid license key (either paid or trial key) within your applications. Please refer to this [help topic](https://help.syncfusion.com/common/essential-studio/licensing/license-key#blazor) for more information.

## Prerequisites

* [Visual Studio 2019](https://visualstudio.microsoft.com/vs/) / [Visual Studio 2022 Preview](https://visualstudio.microsoft.com/vs/preview)
* [.NET Core SDK 3.1.8](https://dotnet.microsoft.com/download/dotnet/3.1) / [.NET 5.0 SDK](https://dotnet.microsoft.com/download/dotnet/5.0) / [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)

> **.NET Core SDK 3.1.8** requires Visual Studio 2019 16.7 or later. <br /> **.NET 5** requires Visual Studio 2019 16.8 or later. <br /> **.NET 6** requires Visual Studio 2022 Preview 4.1 or later.

## Create a Blazor WebAssembly project in Visual Studio

Refer to the [Blazor Tooling documentation](https://docs.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-5.0&pivots=windows) to create a new Blazor Server-Side Application using Visual Studio.

## Installing Syncfusion Blazor packages in the application

You can use any one of the below standard to install the Syncfusion Blazor library in your application.

### Using Syncfusion Blazor individual NuGet Packages [New standard]

> Starting with Volume 4, 2020 (v18.4.0.30) release, Syncfusion provides [individual NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages/) for our Syncfusion Blazor components. We highly recommend this new standard for your Blazor production applications. Refer to [this section](https://blazor.syncfusion.com/documentation/nuget-packages/#benefits-of-using-individual-nuget-packages) to know the benefits of the individual NuGet packages.

1. Now, install **Syncfusion.Blazor.Calendars** NuGet package to the new application using the `NuGet Package Manager`. For more details about available NuGet packages, refer to the [Individual NuGet Packages](https://blazor.syncfusion.com/documentation/nuget-packages/) documentation.

2. Right-click the project,and then select Manage NuGet Packages.

    ![nuget explorer](images/nuget-explorer.png)

3. Search **Syncfusion.Blazor.Calendars** keyword in the Browse tab and install **Syncfusion.Blazor.Calendars** NuGet package in the application.

    ![select nuget](images/individual-nuget.png)

4. The Syncfusion Blazor Calendars package will be included in the newly created project once the installation process is completed.

5. Add the Syncfusion bootstrap4 theme in the `<head>` element of the **~/wwwroot/index.html** page.

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

1. Now, install **Syncfusion.Blazor** NuGet package to the newly created application by using the `NuGet Package Manager`. Right-click the project and then select Manage NuGet Packages.

    ![nuget explorer](images/nuget-explorer.png)

2. Search **Syncfusion.Blazor** keyword in the Browse tab and install **Syncfusion.Blazor** NuGet package in the application.

    ![select nuget](images/select-nuget.png)

3. The Syncfusion Blazor package will be installed in the project once the installation process is completed.

4. Add the Syncfusion bootstrap4 theme in the `<head>` element of the **~/wwwroot/index.html** page.

    ```html
    <head>
        ....
        ....
         <link href="_content/Syncfusion.Blazor/styles/bootstrap4.css" rel="stylesheet" />
    </head>
    ```

    > The same theme file can be referred through the CDN version by using [https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/styles/bootstrap4.css](https://cdn.syncfusion.com/blazor/19.2.46/styles/bootstrap4.css).

## Adding Syncfusion Blazor component and running the application

1. Open **~/_Imports.razor** file and import the `Syncfusion.Blazor` namespace.

    ```cshtml
    @using Syncfusion.Blazor
    @using Syncfusion.Blazor.Calendars
    ```

2. Open the **~/Program.cs** file and register the Syncfusion Blazor Service.

    ```c#
    // For .NET 6 project.
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

    ```c#
    // For .NET 5 or .NET Core SDK 3.1 project.
    using Syncfusion.Blazor;

    namespace WebApplication1
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
    ```

    > You can disable the dynamic script loading and refer to the scripts from the application end by using the `IgnoreScriptIsolation` parameter in `AddSyncfusionBlazor()` at the `Program.cs`. For more details, please refer here for [how to refer custom/CDN resources](../common/custom-resource-generator/#how-to-use-custom-resources-in-the-blazor-application).

3. Now, add the Syncfusion Blazor component in any web page (razor) in the `Pages` folder. For example, the calendar component is added in the **~/Pages/Index.razor** page.

    ```cshtml
    <SfCalendar TValue="DateTime"></SfCalendar>
    ```

4. Run the application. Then, the Syncfusion Blazor Calendar component will be rendered in the default web browser.

    ![output](images/browser-output.png)
