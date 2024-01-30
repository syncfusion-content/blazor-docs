---
layout: post
title: Getting started with Syncfusion Media Query in Blazor Web App
description: Check out the documentation for getting started with Syncfusion Blazor Media Query Components in Blazor Web App.
platform: Blazor
control: Media Query
documentation: ug
---

# Getting started with Blazor Media Query in Blazor Web App

This section briefly explains about how to include `Blazor Media Query` component in your Blazor Web App using [Visual Studio](https://visualstudio.microsoft.com/vs/).

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App

You can create a **Blazor Web App** using Visual Studio 2022 via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0) or the [Syncfusion Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

You need to configure the corresponding [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=windows) while creating a Blazor Web Application.

## Install Syncfusion Blazor Core and Themes NuGet in the App

To add **Blazor Media Query** component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search and install [Syncfusion.Blazor.Core](https://www.nuget.org/packages/Syncfusion.Blazor.Core) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/).

If you utilize `WebAssembly or Auto` render modes in the Blazor Web App need to be install Syncfusion Blazor components NuGet packages within the client project.

Alternatively, you can utilize the following package manager command to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Core  -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

## Register Syncfusion Blazor Service

Open **~/_Imports.razor** file and import the `Syncfusion.Blazor` namespace .

```cshtml

@using Syncfusion.Blazor

```

Now, register the Syncfusion Blazor Service in the **~/Program.cs** file of your Blazor Web App.

If you select an **Interactive render mode** as `WebAssembly` or `Auto`, you need to register the Syncfusion Blazor service in both **~/Program.cs** files of your Blazor Web App.

```cshtml

....
using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor();
....

```

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the stylesheet reference in the `<head>` section and the script reference at the end of the `<body>` in the **~/Components/App.razor** file as shown below:

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/material.css" rel="stylesheet" />
</head>

<body>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```

N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in your Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in your Blazor application.

## Add Syncfusion Blazor Media Query component

Add the Syncfusion Blazor Media Query component in the **~Pages/.razor** file. If an interactivity location as `Per page/component` in the web app, define a render mode at the top of the `~Pages/.razor` component, as follows:

{% tabs %}
{% highlight razor %}

@* desired render mode define here *@
@rendermode InteractiveAuto

{% endhighlight %}
{% endtabs %}

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

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This will render the Syncfusion Blazor Media Query component in your default web browser.

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXVfNMDbAUuQhQzI?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Media Query Component](images/blazor-media-query.png)" %}

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/MediaQuery/BlazorWebApp).

## See also

* [Getting Started with Syncfusion Blazor for Client-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-dotnet-cli)
* [Getting Started with Syncfusion Blazor for Server-side in Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)
* [Getting Started with Syncfusion Blazor for Server-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-dotnet-cli)