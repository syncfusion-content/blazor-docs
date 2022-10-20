---
layout: post
title: Getting Started with Blazor Electron App in Visual Studio | Syncfusion
description: Check out the documentation for getting started with Blazor Electron App and Syncfusion Blazor Components in Visual Studio and much more.
platform: Blazor
component: Common
documentation: ug
---

# Getting Started with Blazor Electron Application

This section explains how to create and run the Blazor Electron app with Syncfusion Blazor components.

## What is Electron App

[Electron](https://www.electronjs.org/) framework supports building cross-platform desktop applications with web technologies. It utilizes Node.js and the Chromium rendering engine to run a web application on a desktop shell.

## Create a Blazor server-side application using .NET CLI

Open command prompt from the location to create the application. Run the following command to create a new Blazor server-side application without HTTPS support. Here, the application is names as BlazorElectronAppNet6.

```
dotnet new blazorserver --no-https -o BlazorElectronAppNet6

```
## Install Syncfusion Blazor Packages in the App

Navigate to the application folder and install required Syncfusion NuGet package in application. Syncfusion Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). To use Syncfusion Blazor components in the application, add reference to the corresponding NuGet. Refer to [NuGet packages topic](https://blazor.syncfusion.com/documentation/nuget-packages) for available NuGet packages list with component details and [Benefits of using individual NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages#benefits-of-using-individual-nuget-packages). 

To add Blazor Grid component in the app install [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid/) NuGet package by running the below commands

```
cd BlazorElectronAppNet6

dotnet add package Syncfusion.Blazor.Grid

```

Open **~/_Imports.razor** file and import the `Syncfusion.Blazor` namespace.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor

{% endhighlight %}
{% endtabs %}

Now, register the Syncfusion Blazor Service in the Blazor Server App. Here, Syncfusion Blazor Service is registered by setting [IgnoreScriptIsolation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_IgnoreScriptIsolation) property as `true` to load the scripts externally in the [next steps](#add-script-reference).

> From 2022 Vol-1 (20.1) version, the default value of `IgnoreScriptIsolation` is changed to `true`. It is not necessary to set the `IgnoreScriptIsolation` property to refer scripts externally, since the default value has already been changed to true, and this property is obsolete.

* For **.NET 6** app, open the **~/Program.cs** file and register the Syncfusion Blazor Service.
* For **.NET 5 and .NET 3.X** app, open the **~/Startup.cs** file and register the Syncfusion Blazor Service.

{% tabs %}
{% highlight c# tabtitle=".NET 6 (~/Program.cs)" hl_lines="3 10" %}

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
{% highlight c# tabtitle=".NET 5 and .NET 3.X (~/Startup.cs)" hl_lines="3 12" %}

using Syncfusion.Blazor;

namespace BlazorApplication
{
    public class Startup
    {
        ...
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSyncfusionBlazor();
        }
        ...
    }
}

{% endhighlight %}
{% endtabs %}

## Add style sheet

Checkout the [Blazor Themes topic](https://blazor.syncfusion.com/documentation/appearance/themes) to learn different ways ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference) and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) to refer themes in Blazor application, and to have the expected appearance for Syncfusion Blazor components. Here, the theme is referred using [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Refer to [Enable static web assets usage](https://blazor.syncfusion.com/documentation/appearance/themes#enable-static-web-assets-usage) topic to use static assets in your project.

To add theme to the app, run the below commands to install [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) in the application. 

```
dotnet add package Syncfusion.Blazor.Themes

```

Then, the theme style sheet from NuGet can be referred inside the `<head>` as follows,

* **~/Pages/_Host.cshtml** file for **.NET 5 and .NET 3.X**.
* **~/Pages/_Layout.cshtml** for **.NET 6**.

{% tabs %}
{% highlight cshtml tabtitle=".NET 6 (~/_Layout.cshtml)" hl_lines="3 4 5" %}

<head>
    ...
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <!--Refer theme style sheet as below if you are using Syncfusion.Blazor Single NuGet-->
    <!--<link href="_content/Syncfusion.Blazor/styles/bootstrap5.css" rel="stylesheet" />-->
</head>

{% endhighlight %}
{% highlight cshtml tabtitle=".NET 5 and .NET 3.X (~/_Host.cshtml)" hl_lines="3 4 5" %}

<head>
    ...
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <!--Refer theme style sheet as below if you are using Syncfusion.Blazor Single NuGet-->
    <!--<link href="_content/Syncfusion.Blazor/styles/bootstrap5.css" rel="stylesheet" />-->
</head>

{% endhighlight %}
{% endtabs %}

## Add script reference

Checkout [Adding Script Reference topic](https://blazor.syncfusion.com/documentation/common/adding-script-references) to learn different ways to add script reference in Blazor Application. In this getting started walk-through, the required scripts are referred using [Static Web Assets](https://blazor.syncfusion.com/documentation/common/adding-script-references#static-web-assets) externally inside the `<head>` as follows. Refer to [Enable static web assets usage](https://blazor.syncfusion.com/documentation/common/adding-script-references#enable-static-web-assets-usage) topic to use static assets in your project.

* **~/Pages/_Host.cshtml** file for **.NET 5 and .NET 3.X**.
* **~/Pages/_Layout.cshtml** for **.NET 6**.

{% tabs %}
{% highlight cshtml tabtitle=".NET 6 (~/_Layout.cshtml)" hl_lines="4 5 6" %}

<head>
    ...
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
    <!--Use below script reference if you are using Syncfusion.Blazor Single NuGet-->
    <!--<script  src="_content/Syncfusion.Blazor/scripts/syncfusion-blazor.min.js"  type="text/javascript"></script>-->
</head>

{% endhighlight %}
{% highlight cshtml tabtitle=".NET 5 and .NET 3.X (~/_Host.cshtml)" hl_lines="4 5 6" %}

<head>
    ...
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script  src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
    <!--Use below script reference if you are using Syncfusion.Blazor Single NuGet-->
    <!--<script  src="_content/Syncfusion.Blazor/scripts/syncfusion-blazor.min.js"  type="text/javascript"></script>-->
</head>

{% endhighlight %}
{% endtabs %}

> Syncfusion recommends to reference scripts using [Static Web Assets](https://blazor.syncfusion.com/documentation/common/adding-script-references#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/common/adding-script-references#cdn-reference) and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator) for better loading performance of the Blazor application. 
 
 ## Add Blazor DataGrid component

* Open **~/_Imports.razor** file or any other page under the `~/Pages` folder where the component is to be added and import the **Syncfusion.Blazor.Grid** namespace.

{% tabs %}
{% highlight razor tabtitle="~/Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids

{% endhighlight %}
{% endtabs %}

* Now, add the Syncfusion DataGrid component in razor file. Here, the DataGrid component is added in the **~/Pages/Index.razor** file under the **~/Pages** folder.

{% tabs %}
{% highlight razor %}

<SfGrid DataSource="@Orders" />

@code{
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 5).Select(x => new Order()
        {
            OrderID = 0 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }

    }
}

{% endhighlight %}
{% endtabs %}

Now, the Blazor server application with Sycnfusion Grid component is created.

![Blazor DataGrid Component](images\electron\server-syncfusion-grid.png)

## Configure Electron SetUp in the application

1. Install [ElectronNET.API](https://www.nuget.org/packages/ElectronNET.API/) NuGet package in the application running below command

```

dotnet add package ElectronNET.API

```

2. Create a local .NET tool manifest file by running the following command. This will create a manifest file in the **~/.config/dotnet-tools.json** location. 

```

dotnet new tool-manifest

```
![Local dotnet tool](images\electron\net-tool-manifest.png)

3. Install the electronize tool locally in the project by running the below command.

```

dotnet tool install ElectronNET.CLI

```
![Electron NET CLI](images\electron\net-cli.png)

4. Run the below command to configure Electron.NET manifest tool and update the launch profile of the application.

```

dotnet electronize init

```
![Update launch profile](images\electron\update-launch-profile.png)

5. To integrate Electron.NET in the application add the below code in **~/Program.cs** file of the application.

{% tabs %}
{% highlight c# tabtitle=".NET 6 (~/Program.cs)" hl_lines="2 9 10" %}

using Syncfusion.Blazor;
using ElectronNET.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
...
builder.Services.AddSyncfusionBlazor();
builder.Services.AddElectron();
builder.WebHost.UseElectron(args);

var app = builder.Build();
....

{% endhighlight %}
{% highlight c# tabtitle=".NET 5 and .NET 3.X (~/Program.cs)" hl_lines="1 12" %}

using ElectronNET.API;

public class Program
{
    .....
    .....

    public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseElectron(args);
        webBuilder.UseStartup<Startup>();
    });
}

{% endhighlight %}
{% endtabs %}

6. To open the Electron window add the below code in the **~/Startup.cs** file of .NET 3.X and .NET 5 applications, in **~/Program.cs** file of .NET 6 applications.

{% tabs %}
{% highlight c# tabtitle=".NET 6 (~/Program.cs)" %}

using ElectronNET.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
...
builder.WebHost.UseElectron(args);

if (HybridSupport.IsElectronActive)
{
    // Open the Electron-Window here
    Task.Run(async () => {
        var window = await Electron.WindowManager.CreateWindowAsync();
    });
}

var app = builder.Build();
....

{% endhighlight %}
{% highlight c# tabtitle=".NET 5 and .NET 3.X (~/Startup.cs)" hl_lines="13 18" %}

using ElectronNET.API;

public class Startup
{
    ……
    ……

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        ……
        ……
        // Open the Electron-Window
            Task.Run(async () => {
                var window = await Electron.WindowManager.CreateWindowAsync();
            });
    }
}

{% endhighlight %}
{% endtabs %}

7. Run the application using the below command.

```

dotnet electronize start

```
![Electron app output](images\electron\electron-grid-output.png)

> To close the electron app when closed the electron window add the below code in the application.

```

Task.Run(async () => {
        var window = await Electron.WindowManager.CreateWindowAsync();
        window.OnClosed += () => {
            Electron.App.Quit();
        };
    });

```

8. Run the below command lines to do production builds based on platform

```

dotnet electronize build /target win
dotnet electronize build /target osx
dotnet electronize build /target linux

```

> [View the complete Blazor Server electron application with Syncfusion controls on GitHub](https://github.com/SyncfusionExamples/blazor-electron-app)