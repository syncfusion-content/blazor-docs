---
layout: post
title: Getting started with Syncfusion Blazor - Blazor ASP.NET Core Hosted App in .NET Core CLI
description: Check out the documentation for Getting started with Syncfusion Blazor
platform: Blazor
component: Common
documentation: ug
---
<!-- markdownlint-disable MD024 -->

# Getting started with Syncfusion Blazor components in Blazor ASP.NET Core Hosted App using .NET Core CLI

This article provides step-by-step instructions about how to create Blazor ASP.NET Core Hosted application using [.NET Core CLI](https://dotnet.microsoft.com/download/dotnet/) with Syncfusion Blazor components setup pre-configured in it.

> **Note:** Starting with version 17.4.0.39 (2019 Volume 4), you need to include a valid license key (either paid or trial key) within your applications. Please refer to this [help topic](https://help.syncfusion.com/common/essential-studio/licensing/license-key#blazor) for more information.

## Prerequisites

* [.NET Core SDK 3.1.8](https://dotnet.microsoft.com/download/dotnet/3.1) / [.NET 5.0 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)

## Create a Blazor ASP.NET Core Hosted project using .NET Core CLI

1. Run the following command line to create a new Blazor WebAssembly application.

    ```bash
        dotnet new blazorwasm -o BlazorWasmHosted --hosted
        cd BlazorWasmHosted
    ```
    > If you have installed multiple SDK versions and need any specific framework version (net5.0/netcoreapp3.1) project, then add `-f` flag along with `dotnet new blazorwasm` comment. Refer [here](https://docs.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-5.0&pivots=windows) for the available options.

## Installing Syncfusion Blazor packages in the application

You can use any one of the following standards to install the Syncfusion Blazor library in your application.

### Using Syncfusion Blazor individual NuGet Packages [New standard]

> Starting with Volume 4, 2020 (v18.4.0.30) release, Syncfusion provides [individual NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages/) for our Syncfusion Blazor components. We highly recommend this new standard for your Blazor production applications. Refer to [this section](https://blazor.syncfusion.com/documentation/nuget-packages/#benefits-of-using-individual-nuget-packages) to know the benefits of the individual NuGet packages.

1. Now, install the **Syncfusion.Blazor.Calendars** NuGet package to the new application using the `NuGet Package Manager`. For more details about available NuGet packages, refer to the [Individual NuGet Packages](https://blazor.syncfusion.com/documentation/nuget-packages/) documentation.

2. Navigate to created **`Client`[BlazorWasmHosted.Client]** project to configure the Syncfusion Blazor Library.

    ```bash
        cd Client
        dotnet add package Syncfusion.Blazor.Calendars -v '{:nuget-version:}'
        dotnet restore
    ```

2. The Syncfusion Blazor Calendars package will be included in the newly created project once the installation process is completed.

3. Add the Syncfusion bootstrap4 theme in the `<head>` element of the **~/wwwroot/index.html** page in **`Client`[BlazorWasmHosted.Client]** project.

    ```html
    <head>
        ....
        ....
        <link href="_content/Syncfusion.Blazor.Themes/bootstrap4.css" rel="stylesheet" />
    </head>
    ```

    > Warning: `Syncfusion.Blazor` package should not be installed along with [individual NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages/). Hence, you have to add the above `Syncfusion.Blazor.Themes` static web assets (styles) in the application.

### Using Syncfusion.Blazor NuGet Package [Old standard]

> Warning: If you prefer the above new standard (individual NuGet packages), then skip this section. Using both old and new standards in the same application will throw ambiguous compilation errors.

1. Now, install the **Syncfusion.Blazor** NuGet package to the newly created application by using the `NuGet Package Manager`. Right-click on the **`Client`[BlazorWasmHosted.Client]** project and then select Manage NuGet Packages.

    ![nuget explorer](images/core-hosted/nuget-explorer.png)

2. Navigate to created **`Client`[BlazorWasmHosted.Client]** project to configure the Syncfusion Blazor Library.

    ```bash
        cd Client
        dotnet add package Syncfusion.Blazor -v '{:nuget-version:}'
        dotnet restore
    ```

2. The Syncfusion Blazor Calendars package will be included in the newly created project once the installation process is completed.

3. Add the Syncfusion bootstrap4 theme in the `<head>` element of the **~/wwwroot/index.html** page in **`Client`[BlazorWasmHosted.Client]** project.

    ```html
    <head>
        ....
        ....
        <link href="_content/Syncfusion.Blazor/styles/bootstrap4.css" rel="stylesheet" />
    </head>
    ```
    > **Note:** The same theme file can be referred through the CDN version by using [https://cdn.syncfusion.com/blazor/{:version:}/styles/bootstrap4.css](https://cdn.syncfusion.com/blazor/18.4.30/styles/bootstrap4.css).

## Adding Syncfusion Blazor component and running the application

1. Open **~/_Imports.razor** file in **`Client`[BlazorWasmHosted.Client]** project and import the `Syncfusion.Blazor` namespace.

    ```csharp
    @using Syncfusion.Blazor
    @using Syncfusion.Blazor.Calendars
    ```

2. Open the **~/Program.cs** file in the **`Client`[BlazorWasmHosted.Client]** project and register the Syncfusion Blazor Service.

    ```csharp
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
    ```

    > **Note:** We can disable the dynamic script loading and refer to the scripts from the application end by using the `IgnoreScriptIsolation` parameter in `AddSyncfusionBlazor()` at the `program.cs`. For more details, please refer here for [how to refer custom/CDN resources](../common/custom-resource-generator/#how-to-use-custom-resources-in-the-blazor-application).

3. Now, add the Syncfusion Blazor component in any web page (razor) in the `Pages` folder of **`Client`[BlazorWasmHosted.Client]** project. For example, the calendar component is added to the **~/Pages/Index.razor** page.

    ```csharp
    <SfCalendar TValue="DateTime"></SfCalendar>
    ```

4. Then Navigate to the **`Server`[BlazorWasmHosted.Server]** project and Run the **`dotnet run`** command to run the application. The Syncfusion Blazor Calendar component will be rendered in the web browser.

    ![output](images/core-hosted/browser-output.png)

    > **Note:** For ASP.NET Core Hosted Blazor application, the **`Server`[BlazorWasmHosted.Server]** project should be the startup project.

## See Also

* [ASP.NET Core Blazor hosting models](https://docs.microsoft.com/en-us/aspnet/core/blazor/hosting-models?view=aspnetcore-5.0)