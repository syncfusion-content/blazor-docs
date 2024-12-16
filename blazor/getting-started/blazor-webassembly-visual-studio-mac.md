---
layout: post
title: Getting started with Syncfusion Blazor WebAssembly App in VS for Mac
description: Check out the documentation for getting started with Blazor WebAssembly App and Syncfusion Blazor Components in Visual Studio for Mac and much more.
platform: Blazor
component: Common
documentation: ug
---

<!-- markdownlint-disable MD024 -->

# Getting Started with Blazor WebAssembly App in VS for Mac

This articles provides a step-by-step instructions for building Blazor WebAssembly App with Blazor Calendar component using [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/).

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a Blazor WebAssembly App in Visual Studio for Mac

You can create **Blazor WebAssembly App** in Visual Studio for mac by the following way.

* [Create a project using Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-7.0&pivots=macos)

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Packages in the App

Here's an example of how to add **Blazor Calendar** component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search and install [Syncfusion.Blazor.Calendars](https://www.nuget.org/packages/Syncfusion.Blazor.Calendars/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/).

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

Open **~/_Imports.razor** file and import the following namespace.

```cshtml

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Calendars

```

Now, register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service in the **~/Program.cs** file of your Blazor WebAssembly App.

{% tabs %}
{% highlight c# tabtitle="Blazor WebAssembly App (~/Program.cs)" hl_lines="1 5" %}

using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
....
builder.Services.AddSyncfusionBlazor();

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Reference the stylesheet and script in the `<head>` of the main page as follows:

* For Blazor WebAssembly app, include it in the **~wwwroot/index.html** file.

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>
```
N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in your Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in your Blazor application.

## Add Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor component

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Calendar component in the **~/Pages/Index.razor** file.

{% tabs %}
{% highlight razor %}

<SfCalendar TValue="DateTime" />

{% endhighlight %}
{% endtabs %}

* <kbd>⌘</kbd>+<kbd>F5</kbd> to run the app. Then, the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Calendar component will be rendered in the default web browser.

![Blazor Calendar Component](images/output-calendar-using-blazor-webassembly.png)

N> When using a PDF viewer on macOS (ARM), we recommend our [PDF Viewer](https://blazor.syncfusion.com/documentation/pdfviewer-2/migration) since it is compatible with macOS (ARM).

## See Also

* [Getting Started with Blazor Server App for Mac](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-mac)
