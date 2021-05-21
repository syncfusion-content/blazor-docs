---
layout: post
title: Configure Syncfusion Blazor Client Resources in Production Environment in Blazor - Syncfusion
description: Check out the documentation for Configure Syncfusion Blazor Client Resources in Production Environment in Blazor
platform: Blazor
component: Common
documentation: ug
---

# How to Configure Syncfusion Blazor Client Resources in Production Environment

* The Syncfusion Blazor suit maintains the built-in script resources (interop scripts) by default. So, there is no need to include script reference in the application end.

> Warning: Starting with version 18.3.0.35 (Volume 3, 2020), the Syncfusion Blazor library is integrated with the JavaScript Isolation feature of Blazor. So, you don’t need to add `DisableScriptManager` anymore in the `AddSyncfusionBlazor` service for your production environment to configure the Syncfusion init interop script (`syncfusion-blazor.min.js`) manually. i.e. The Syncfusion Blazor library itself handles the Syncfusion init interop script and it is no longer need to be added manually in the layout page (_Host.cshtml/index.html) for production.

## Adding Syncfusion Blazor init interop script in the production application

> Warning: Starting with version 18.3.0.35 (Volume 3, 2020), the below configuration is no longer needed for the production environment. You can use the default [getting started](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio-2019/#importing-syncfusion-blazor-component-in-the-application) configuration in production mode.

* Set `DisableScriptManager` as true to the `AddSyncfusionBlazor` service in the `~/Startup.cs` file for Blazor server app or `~/Program.cs` file for Blazor WebAssembly app.

    **Blazor Server App (~/Startup.cs)**

{% tabs %}

{% highlight C# %}

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();
        services.AddServerSideBlazor();

        // Set DisableScriptManager as true to load init script manually in the application end
        services.AddSyncfusionBlazor(true);

        services.AddSingleton<WeatherForecastService>();
    }

{% endhighlight %}

{% endtabs %}

    **Blazor WebAssembly App (~/Program.cs)**
{% tabs %}

{% highlight C# %}

    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args)    ;
        ....
        ....

        // Set DisableScriptManager as true to load init script manually in the application end
        builder.Services.AddSyncfusionBlazor(true);

        await builder.Build().RunAsync();
    }

{% endhighlight %}

{% endtabs %}

* Add Syncfusion Blazor resources manually in the `~/Pages/_Host.cshtml` file for Blazor server app or `~/wwwroot/index.html` file for Blazor WebAssembly app.

{% tabs %}

{% highlight HTML %}

    <head>
        ....
        ....
        <link href="_content/Syncfusion.Blazor/styles/bootstrap4.css" rel="stylesheet" />
        <script src="_content/Syncfusion.Blazor/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
    </head>

{% endhighlight %}

{% endtabs %}

* Now, publish the application with the production environment in the server.

## Creating custom themes for Syncfusion Blazor UI Components

[ThemeStudio](http://ej2.syncfusion.com/themestudio/) is an online web application where you can customize the Syncfusion built-in themes and generate custom theme files for a specific set of Syncfusion Blazor UI components. It will reduce the theme file size for production environment. Refer to [here](https://blazor.syncfusion.com/documentation/appearance/theme-studio/) for more details about ThemeStudio.
