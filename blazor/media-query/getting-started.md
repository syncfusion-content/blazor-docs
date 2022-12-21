---
layout: post
title: Getting Started with Blazor Media Query Component | Syncfusion
description: Checkout and learn about getting started with Blazor Media Query component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Media Query
documentation: ug
---

# Getting Started with Blazor Media Query Component

This section briefly explains about how to include `Blazor Media Query` component in your Blazor Server App and Blazor WebAssembly App using Visual Studio. 

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio

You can create **Blazor Server App** or **Blazor WebAssembly App** using Visual Studio in one of the following ways,

* [Create a Project using Microsoft Templates](https://docs.microsoft.com/en-us/aspnet/core/blazor/tooling?pivots=windows)

* [Create a Project using Syncfusion Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project)

## Install Syncfusion Blazor Core NuGet in the App

Syncfusion Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). In order to use Syncfusion Blazor components in the application, add reference to the corresponding NuGet. Refer to [NuGet packages topic](https://blazor.syncfusion.com/documentation/nuget-packages) for available NuGet packages list with component details and [Benefits of using individual NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages#benefits-of-using-individual-nuget-packages). 

To add Blazor Media Query component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search for [Syncfusion.Blazor.Core](https://www.nuget.org/packages/Syncfusion.Blazor.Core) and then install it.

## Register Syncfusion Blazor Service

Open **~/_Imports.razor** file and import the `Syncfusion.Blazor` namespace.

{% tabs %}
{% highlight razor tabtitle="~/Imports.razor" %}

@using Syncfusion.Blazor

{% endhighlight %}
{% endtabs %}

Now, register the Syncfusion Blazor Service in the Blazor Server App or Blazor WebAssembly App. Here, Syncfusion Blazor Service is registered by setting [IgnoreScriptIsolation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_IgnoreScriptIsolation) property as `true` to load the scripts externally in the [next steps](#add-script-reference).

> From 2022 Vol-1 (20.1) version, the default value of `IgnoreScriptIsolation` is changed to `true`. It is not necessary to set the `IgnoreScriptIsolation` property to refer scripts externally, since the default value has already been changed to true, and this property is obsolete.

### Blazor Server App

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

{% highlight c# tabtitle=".NET 5 and .NET 3.X (~/Startup.cs)" hl_lines="1 12" %}

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

### Blazor WebAssembly App

Open **~/Program.cs** file and register the Syncfusion Blazor Service in the client web app.

{% tabs %}
{% highlight c# tabtitle=".NET 6 (~/Program.cs)" hl_lines="3 11" %}

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(serviceProvider => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSyncfusionBlazor();
await builder.Build().RunAsync();
....

{% endhighlight %}

{% highlight c# tabtitle=".NET 5 and .NET 3.X (~/Program.cs)" hl_lines="1 10" %}

using Syncfusion.Blazor;

namespace WebApplication1
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

## Add script reference

Checkout [Adding Script Reference topic](https://blazor.syncfusion.com/documentation/common/adding-script-references) to learn different ways to add script reference in Blazor Application. In this getting started walk-through, the required scripts are referred using [Static Web Assets](https://blazor.syncfusion.com/documentation/common/adding-script-references#static-web-assets) externally inside the `<head>` as follows. Refer to [Enable static web assets usage](https://blazor.syncfusion.com/documentation/common/adding-script-references#enable-static-web-assets-usage) topic to use static assets in your project.

### Blazor Server App

* For **.NET 6** app, refer script in the `<head>` of the **~/Pages/_Layout.cshtml** file.

* For **.NET 5 and .NET 3.X** app, refer script in the `<head>` of the **~/Pages/_Host.cshtml** file.

{% tabs %}
{% highlight cshtml tabtitle=".NET 6 (~/_Layout.cshtml)" hl_lines="4 5 6" %}

<head>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
    <!--Use below script reference if you are using Syncfusion.Blazor Single NuGet-->
    <!--<script  src="_content/Syncfusion.Blazor/scripts/syncfusion-blazor.min.js"  type="text/javascript"></script>-->
</head>

{% endhighlight %}

{% highlight cshtml tabtitle=".NET 5 and .NET 3.X (~/_Host.cshtml)" hl_lines="4 5 6" %}

<head>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
    <!--Use below script reference if you are using Syncfusion.Blazor Single NuGet-->
    <!--<script  src="_content/Syncfusion.Blazor/scripts/syncfusion-blazor.min.js"  type="text/javascript"></script>-->
</head>

{% endhighlight %}
{% endtabs %}

### Blazor WebAssembly App

For Blazor WebAssembly App, refer script in the `<head>` of the **~/index.html** file.

{% tabs %}
{% highlight html tabtitle="~/index.html" hl_lines="4 5 6" %}

<head>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
    <!--Use below script reference if you are using Syncfusion.Blazor Single NuGet-->
    <!--<script  src="_content/Syncfusion.Blazor/scripts/syncfusion-blazor.min.js"  type="text/javascript"></script>-->
</head>

{% endhighlight %}
{% endtabs %}

> Syncfusion recommends to reference scripts using [Static Web Assets](https://blazor.syncfusion.com/documentation/common/adding-script-references#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/common/adding-script-references#cdn-reference) and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator) by [disabling JavaScript isolation](https://blazor.syncfusion.com/documentation/common/adding-script-references#disable-javascript-isolation) for better loading performance of the Blazor application.

## Add Syncfusion Blazor Media Query component

* Now, add the Syncfusion Blazor Media Query component in razor file. Here, the Media Query component is added in the **~/Pages/Index.razor** page under the `~/Pages` folder.

{% tabs %}
{% highlight razor %}

<SfMediaQuery @bind-ActiveBreakPoint="activeBreakpoint"></SfMediaQuery>
<br />
@if (activeBreakpoint == "Small")
{
    deviceSize = "small-device";
}
else if (activeBreakpoint == "Medium")
{
    deviceSize = "medium-device";
}
else
{
    deviceSize = "";
}

<div class="mediaquery-demo @deviceSize">
    <div class="header e-skeleton e-skeleton-text">
        <div class="search-box e-skeleton e-skeleton-text"></div>
    </div>
    <div class="banner e-skeleton e-skeleton-text e-shimmer-pulse"></div>
    <div class="main-container">
        <ul>
            <li>
                <div class="content e-skeleton e-skeleton-text e-shimmer-pulse"></div>
                <div class="title e-skeleton e-skeleton-text e-shimmer-pulse"></div>
                <p class="e-skeleton e-skeleton-text e-shimmer-pulse"></p>
            </li>
            <li>
                <div class="content e-skeleton e-skeleton-text e-shimmer-pulse"></div>
                <div class="title e-skeleton e-skeleton-text e-shimmer-pulse"></div>
                <p class="e-skeleton e-skeleton-text e-shimmer-pulse"></p>
            </li>
        </ul>
    </div>
    <div class="footer e-skeleton e-skeleton-text"></div>
</div>

@code {
    private string deviceSize { get; set; }
    private string activeBreakpoint { get; set; }
}
<style>
    .mediaquery-demo {
        height: 715px;
        margin: 0 10%;
        border: 2px solid #f3f2f1;
        border-top-width: 0px;
        border-radius: 4px;
        overflow: hidden;
    }

    .mediaquery-demo .e-skeleton {
        display: block;
    }

    .mediaquery-demo .header {
        height: 6vh;
        text-align: center;
        overflow: visible;
    }

        .mediaquery-demo .header .search-box {
            width: 25%;
            height: 55%;
            margin-top: 1.5vh;
            display: inline-block;
            border-radius: 7px;
            float: right;
            margin-right: 3%;
            background-color: white;
        }

    .mediaquery-demo .banner {
        height: 35%;
        margin: 1% 8%;
    }

    .mediaquery-demo .main-container {
        margin: 0 8%;
        height: 35%;
    }

    .mediaquery-demo .main-container ul {
        list-style: none;
        display: flex;
        height: 100%;
        padding: 0;
        justify-content: space-between;
        padding-top: 20px;
    }

        .mediaquery-demo .main-container ul li {
            width: 49%;
        }

    .mediaquery-demo .main-container li .content {
        height: 60%;
    }

    .mediaquery-demo .main-container li .title,
    .mediaquery-demo .main-container li p {
        width: 50%;
        height: 7%;
        margin-top: 3%;
    }

    .mediaquery-demo .main-container li p {
        width: 80%;
    }

    .mediaquery-demo .footer {
        height: 20%;
        margin: 0% 8%;
    }

    .mediaquery-demo.medium-device .header .search-box {
        width: 50%;
        float: none;
        margin-right: 0px;
    }

    .mediaquery-demo.medium-device .banner,
    .mediaquery-demo.medium-device .main-container,
    .mediaquery-demo.medium-device .footer {
        margin: 0px;
    }

    .mediaquery-demo.medium-device .banner {
        margin-top: 1%;
    }

    .mediaquery-demo.medium-device .main-container {
        height: 42%;
    }

    .mediaquery-demo.medium-device .main-container ul {
        flex-direction: column;
    }

    .mediaquery-demo.medium-device .main-container ul li {
        height: 50%;
        display: flex;
        margin-bottom: 2%;
        margin-left: 5%;
        width: 100%;
    }

    .mediaquery-demo.medium-device .main-container li .content {
        height: auto;
        width: 30%;
    }

    .mediaquery-demo.medium-device .main-container li .title,
    .mediaquery-demo.medium-device .main-container li p {
        height: 24%;
    }

    .mediaquery-demo.medium-device .main-container li .title {
        margin-left: 5%;
        width: 25%;
        margin-top: 0;
    }

    .mediaquery-demo.medium-device .main-container li p {
        margin-top: 8%;
        margin-left: -25%;
        width: 55%;
    }

    .mediaquery-demo.small-device .header .search-box {
        text-align: center;
        float: none;
        width: 60%;
        height: 65%;
        margin-top: 8vh;
        background-color: inherit;
    }

    .mediaquery-demo.small-device .banner,
    .mediaquery-demo.small-device .main-container,
    .mediaquery-demo.small-device .footer {
        margin: 0px;
        height: 20%;
    }

    .mediaquery-demo.small-device .banner {
        margin: 8vh 0 0;
    }

    .mediaquery-demo.small-device .main-container {
        height: 48%;
    }

    .mediaquery-demo.small-device .main-container ul {
        display: block;
    }

    .mediaquery-demo.small-device .main-container ul li {
        height: 50%;
        display: block;
        width: 90%;
        margin: 0 auto;
    }

    .mediaquery-demo.small-device .main-container li .content {
        height: 40%;
        width: auto;
    }

    .mediaquery-demo.small-device .main-container li .title {
        width: 40%;
        height: 10%;
    }

    .mediaquery-demo.small-device .main-container li p {
        width: auto;
        height: 10%;
    }
</style>

{% endhighlight %}
{% endtabs %}

* Press <kbd>ctrl</kbd>+<kbd>F5</kbd> or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the application. The Syncfusion Blazor Media Query component will then render the layout based on browser view size, as shown in the large device layout below.

![Blazor Media Query Component](images/blazor-media-query.png)

## See also

* [Getting Started with Syncfusion Blazor for Client-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-dotnet-cli)
* [Getting Started with Syncfusion Blazor for Server-side in Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)
* [Getting Started with Syncfusion Blazor for Server-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-dotnet-cli)