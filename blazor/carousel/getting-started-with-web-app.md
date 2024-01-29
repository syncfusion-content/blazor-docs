---
layout: post
title: Getting Started with Syncfusion Blazor Carousel Component in Web App
description: Checkout and learn about the documentation for getting started with Blazor Carousel Component in Blazor Web App.
platform: Blazor
component: Carousel
documentation: ug
---

# Getting Started with Blazor Carousel Component in Web App

This section briefly explains about how to include [Blazor Carousel](https://www.syncfusion.com/blazor-components/blazor-carousel) component in your Blazor Web App using [Visual Studio](https://visualstudio.microsoft.com/vs/).

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App

You can create a **Blazor Web App** using Visual Studio 2022 via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0) or the [Syncfusion Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

You need to configure the corresponding [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=windows) while creating a Blazor Web Application.

## Install Syncfusion Blazor Navigations and Themes NuGet in the Blazor Web App

To add **Blazor Carousel** component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search and install [Syncfusion.Blazor.Navigations](https://www.nuget.org/packages/Syncfusion.Blazor.Navigations/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/).

If you utilize `WebAssembly or Auto` render modes in the Blazor Web App need to be install Syncfusion Blazor components NuGet packages within the client project.

Alternatively, you can utilize the following package manager command to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Navigations -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

## Register Syncfusion Blazor Service

Open **~/_Imports.razor** file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Navigations` namespace.

```cshtml

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Navigations
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
....
<body>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```

N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in your Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in your Blazor application.

## Add Syncfusion Blazor Carousel component

Add the Syncfusion Blazor Carousel component in `.razor` file inside the `Pages` folder. If an interactivity location as `Per page/component` in the web app, define a render mode at top of the component, as follows:

{% tabs %}
{% highlight razor %}

@* desired render mode define here *@
@rendermode InteractiveAuto

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight razor %}

```cshtml
@using Syncfusion.Blazor.Navigations

<div class="control-container">
    <SfCarousel>
        <CarouselItem>
            <figure class="img-container">
                <img src="images/carousel/bridge.png" alt="Golden Gate Bridge, San Francisco" style="height:100%;width:100%;" />
                <figcaption class="img-caption">Golden Gate Bridge, San Francisco</figcaption>
            </figure>
        </CarouselItem>
        <CarouselItem>
            <figure class="img-container">
                <img src="images/carousel/trees.png" alt="Spring Flower Trees" style="height:100%;width:100%;" />
                <figcaption class="img-caption">Spring Flower Trees</figcaption>
            </figure>
        </CarouselItem>
        <CarouselItem>
            <figure class="img-container">
                <img src="images/carousel/waterfall.png" alt="Oddadalen Waterfalls, Norway" style="height:100%;width:100%;" />
                <figcaption class="img-caption">Oddadalen Waterfalls, Norway</figcaption>
            </figure>
        </CarouselItem>
        <CarouselItem>
            <figure class="img-container">
                <img src="images/carousel/sea.png" alt="Anse Source d'Argent, Seychelles" style="height:100%;width:100%;" />
                <figcaption class="img-caption">Anse Source d'Argent, Seychelles</figcaption>
            </figure>
        </CarouselItem>
        <CarouselItem>
            <figure class="img-container">
                <img src="images/carousel/rocks.png" alt="Stonehenge, England" style="height:100%;width:100%;" />
                <figcaption class="img-caption">Stonehenge, England</figcaption>
            </figure>
        </CarouselItem>
    </SfCarousel>
</div>

<style>
    .control-container {
        background-color: #e5e5e5;
        height: 300px;
        margin: 0 auto;
        width: 500px;
    }

    .e-carousel .e-carousel-items .e-carousel-item .img-container {
        height: 100%;
    }

    .e-carousel .e-carousel-items .e-carousel-item .img-caption {
        bottom: 4em;
        color: #fff;
        font-size: 12pt;
        height: 2em;
        position: relative;
        padding: 0.3em 1em;
        text-align: center;
        width: 100%;
    }
</style>
```

{% endhighlight %}
{% endtabs %}

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This will render the Syncfusion Blazor Carousel component in your default web browser.

![Blazor Carousel Component](images/getting_started.png)

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/Carousel).

## See also

1. [Getting Started with Syncfusion Blazor for client-side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-dotnet-cli)
2. [Getting Started with Syncfusion Blazor for client-side in Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-visual-studio)
3. [Getting Started with Syncfusion Blazor for server-side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-dotnet-cli)

