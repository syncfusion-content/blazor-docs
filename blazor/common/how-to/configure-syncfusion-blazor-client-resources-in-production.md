---
layout: post
title: Configure Syncfusion Blazor Client Resources in Production Environment in Blazor - Syncfusion
description: Check out the documentation for Configure Syncfusion Blazor Client Resources in Production Environment in Blazor
platform: Blazor
component: Common
documentation: ug
---

# How to Configure Syncfusion Blazor Client Resources in Production Environment

* Syncfusion Blazor suit maintains the built-in script resources (interop scripts) by default. So, there is no need to include script reference in the application end. Also, from v19.2.0.44, Syncfusion provides an option to load the scripts and styles by manually at application end.

## Adding Syncfusion Blazor init interop script in the production application

* By using [Blazor Custom Resource Generator](https://blazor.syncfusion.com/crg) (CRG) web tool, generate the required components scripts and styles. Refer [here for how to generate the component wise scripts manually](../custom-resource-generator/).

* Set `IgnoreScriptIsolation` as true in `AddSyncfusionBlazor` service in `~/Startup.cs` file for Blazor Server app or `~/Program.cs` file for Blazor WebAssembly app.

    **Blazor Server App (~/Startup.cs)**
    ```csharp
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();
        services.AddServerSideBlazor();

        // Set IgnoreScriptIsolation as true to load custom  scripts
        services.AddSyncfusionBlazor(options => {
            options.IgnoreScriptIsolation = true;
            });

        services.AddSingleton<WeatherForecastService>();
    }
    ```

    **Blazor WebAssembly App (~/Program.cs)**
    ```csharp
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args)    ;
        ....
        ....

        // Set IgnoreScriptIsolation as true to load custom  scripts
        builder.Services.AddSyncfusionBlazor(options => {
            options.IgnoreScriptIsolation = true;
            });

        await builder.Build().RunAsync();
    }
    ```

* Add Syncfusion Blazor resources manually in the `~/Pages/_Host.cshtml` file for Blazor server app or `~/wwwroot/index.html` file for Blazor WebAssembly app.

    ```html
    <head>
        ....
        ....
        <link href="material.css" rel="stylesheet" />
        <script src="syncfusion-blazor.min.js" type="text/javascript"></script>
    </head>
    ```
***How to use CDN resources in the Blazor application***

    * The same theme and script files can be referred through the CDN version by set `IgnoreScriptIsolation`
    as true in `AddSyncfusionBlazor` service in `~/Startup.cs` file for Blazor Server app or `~/Program.cs` file for Blazor WebAssembly app.

    * After that add the CDN interop script and styles in the `~/Pages/_Host.cshtml` for Blazor Server app or `~/wwwroot/index.html` for Blazor WebAssembly app.

    ```html
    <head>
        ....
        ....
        <link href="https://cdn.syncfusion.com/blazor/{:version:}/styles/bootstrap4.css" rel="stylesheet" />
        <script src="https://cdn.syncfusion.com/blazor/{:version:}/syncfusion-blazor.min.js" type="text/javascript"></script>
    </head>
    ```

* Now, publish the application with the production environment in the server.

## Creating custom themes for Syncfusion Blazor UI Components

[ThemeStudio](http://ej2.syncfusion.com/themestudio/) is an online web application where you can customize the Syncfusion built-in themes and generate custom theme files for a specific set of Syncfusion Blazor UI components. It will reduce the theme file size for production environment. Refer to [here](https://blazor.syncfusion.com/documentation/appearance/theme-studio/) for more details about ThemeStudio.
