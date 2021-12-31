---
layout: post
title: Getting Started with Blazor Breadcrumb Component | Syncfusion
description: Checkout and learn about getting started with Blazor Breadcrumb component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Breadcrumb
documentation: ug
---

# Getting Started with Blazor Breadcrumb Component

This section briefly explains about how to include [Blazor Breadcrumb](https://www.syncfusion.com/blazor-components/blazor-breadcrumb) component in your Blazor Server App and Blazor WebAssembly App using Visual Studio. 

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio

You can create **Blazor Server App** or **Blazor WebAssembly App** using Visual Studio in one of the following ways,

* [Create a Project using Microsoft Templates](https://docs.microsoft.com/en-us/aspnet/core/blazor/tooling?pivots=windows)

* [Create a Project using Syncfusion Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/vs2019-extensions/create-project)

## Install Syncfusion Blazor Navigations NuGet in the App

Syncfusion Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). In order to use Syncfusion Blazor components in the application, add reference to the corresponding NuGet. Refer to [NuGet packages topic](https://blazor.syncfusion.com/documentation/nuget-packages) for available NuGet packages list with component details. 

To add Blazor Breadcrumb component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search for [Syncfusion.Blazor.Navigations](https://www.nuget.org/packages/Syncfusion.Blazor.Navigations/) and then install it.

## Register Syncfusion Blazor Service

Open **~/_Imports.razor** file and import the `Syncfusion.Blazor` namespace.

{% tabs %}
{% highlight razor tabtitle="~/Imports.razor" %}

@using Syncfusion.Blazor

{% endhighlight %}
{% endtabs %}

Now, register the Syncfusion Blazor Service in the Blazor Server App or Blazor WebAssembly App. Here, Syncfusion Blazor Service is registered by setting [IgnoreScriptIsolation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_IgnoreScriptIsolation) property as `true` to load the scripts externally in the [next steps](#add-script-reference).

### Blazor Server App

* For **.NET 6** app, open the **~/Program.cs** file and register the Syncfusion Blazor Service.

* For **.NET 5 and .NET 3.X** app, open the **~/Startup.cs** file and register the Syncfusion Blazor Service.

{% tabs %}
{% highlight c# tabtitle=".NET 6 (~/Program.cs)" hl_lines="10" %}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; );

var app = builder.Build();
....

{% endhighlight %}

{% highlight c# tabtitle=".NET 5 and .NET 3.X (~/Startup.cs)" hl_lines="12" %}

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
            services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; );
        }
        ...
    }
}

{% endhighlight %}
{% endtabs %}

### Blazor WebAssembly App

Open **~/Program.cs** file and register the Syncfusion Blazor Service in the client web app.

{% tabs %}
{% highlight c# tabtitle=".NET 6 (~/Program.cs)" %}

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; );
await builder.Build().RunAsync();
....

{% endhighlight %}

{% highlight c# tabtitle=".NET 5 and .NET 3.X (~/Program.cs)" %}
using Syncfusion.Blazor;

namespace WebApplication1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            ....
            builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; );
            await builder.Build().RunAsync();
        }
    }
}
{% endhighlight %}
{% endtabs %}

## Add Style Sheet

Checkout the [Blazor Themes topic](https://blazor.syncfusion.com/documentation/appearance/themes) to learn different ways to refer themes in Blazor application, and to have the expected appearance for Syncfusion Blazor components. Here, the theme is referred using [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets).

To add theme to the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search for [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) and then install it. Then, the theme style sheet from NuGet can be referred as follows,

### Blazor Server App

* For **.NET 6** app, add the Syncfusion bootstrap5 theme in the `<head>` element of the **~/Pages/_Layout.cshtml** file.

* For **.NET 5 and .NET 3.X** app, add the Syncfusion bootstrap5 theme in the `<head>` element of the **~/Pages/_Host.cshtml** file.

{% tabs %}
{% highlight cshtml tabtitle=".NET 6 (~/_Layout.cshtml)" %}

<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>

{% endhighlight %}

{% highlight cshtml tabtitle=".NET 5 and .NET 3.X (~/_Host.cshtml)" %}

<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>

{% endhighlight %}
{% endtabs %}

### Blazor WebAssembly App

The theme style sheet from NuGet can be referred inside the `<head>` element of **wwwroot/index.html** file in the client web app.

{% tabs %}
{% highlight html tabtitle="~/index.html" %}

<head>
    ...
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>

{% endhighlight %}
{% endtabs %}

## Add Script Reference

Checkout [Adding Script Reference topic](https://blazor.syncfusion.com/documentation/common/adding-script-references) to learn different ways to add script reference in Blazor Application. In this getting started walk-through, the required scripts are referenced externally inside the `<head>` as follows,

### Blazor Server App

* **~/Pages/_Layout.cshtml** file for **.NET 6** app.

* **~/Pages/_Host.cshtml** file for **.NET 5 and .NET 3.X** app.

{% tabs %}
{% highlight cshtml tabtitle=".NET 6 (~/_Layout.cshtml)" %}

<head>
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="https://cdn.syncfusion.com/blazor/19.4.38/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>

{% endhighlight %}

{% highlight cshtml tabtitle=".NET 5 and .NET 3.X (~/_Host.cshtml)" %}

<head>
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="https://cdn.syncfusion.com/blazor/19.4.38/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>

{% endhighlight %}
{% endtabs %}

### Blazor WebAssembly App

{% tabs %}
{% highlight html tabtitle="~/index.html" %}

<head>
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="https://cdn.syncfusion.com/blazor/19.4.38/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>

{% endhighlight %}
{% endtabs %}

> Syncfusion recommends to reference scripts using [Static Web Assets](https://blazor.syncfusion.com/documentation/common/adding-script-references#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/common/adding-script-references#cdn-reference) and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator) by [disabling JavaScript isolation](https://blazor.syncfusion.com/documentation/common/adding-script-references#disable-javascript-isolation) for better loading performance of the Blazor application.

## Add Syncfusion Blazor Breadcrumb component

* Open **~/_Imports.razor** file or any razor page under the `~/Pages` folder where the component is to be added and import the `Syncfusion.Blazor.Navigations` namespace.

{% tabs %}
{% highlight razor tabtitle="~/Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Navigations

{% endhighlight %}
{% endtabs %}

* Now, add the Syncfusion Breadcrumb component in razor file. Here, the Breadcrumb component is added in the **~/Pages/Index.razor** page under the `~/Pages` folder.

{% tabs %}
{% highlight razor %}

<SfBreadcrumb></SfBreadcrumb>

{% endhighlight %}
{% endtabs %}

* Press F5 to run the application. Then, the Syncfusion Blazor Breadcrumb component will be rendered in the default web browser.

![Blazor Breadcrumb Component](./images/blazor-Breadcrumb-component.png)

> The Breadcrumb component will render based on the current URL, when the Breadcrumb items are not specified.

## Add items to the Breadcrumb component

To render Breadcrumb component with items use [BreadcrumbItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html) tag directive as like below code example.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Navigations

<SfBreadcrumb>
    <BreadcrumbItems>
        <BreadcrumbItem IconCss="e-icons e-home" Url="https://blazor.syncfusion.com/demos/"/>
        <BreadcrumbItem Text="Components" Url="https://blazor.syncfusion.com/demos/datagrid/overview"/>
        <BreadcrumbItem Text="Navigations" Url="https://blazor.syncfusion.com/demos/menu-bar/default-functionalities"/>
        <BreadcrumbItem Text="Breadcrumb" Url="./breadcrumb/default-functionalities"/>
    </BreadcrumbItems>
</SfBreadcrumb>
{% endhighlight %}
{% endtabs %}

> Place list of [BreadcrumbItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItem.html) within [BreadcrumbItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.BreadcrumbItems.html) tag directive.

![Blazor Breadcrumb Component](./images/blazor-Breadcrumb-items.png)

## Enable or disable navigation

Breadcrumb component enables or disables built-in URL navigation based on the [EnableNavigation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfBreadcrumb.html#Syncfusion_Blazor_Navigations_SfBreadcrumb_EnableNavigation) property. By default, the navigation will be enabled when setting the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfBreadcrumb.html#Syncfusion_Blazor_Navigations_SfBreadcrumb_Url) property. To prevent Breadcrumb item navigation, set the [EnableNavigation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfBreadcrumb.html#Syncfusion_Blazor_Navigations_SfBreadcrumb_EnableNavigation) property as `false` in Breadcrumb.

## See Also

* [Getting Started with Syncfusion Blazor for client side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-dotnet-cli/)
* [Getting Started with Syncfusion Blazor for server side in Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio-2019/)
* [Getting Started with Syncfusion Blazor for server side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-dotnet-cli/)