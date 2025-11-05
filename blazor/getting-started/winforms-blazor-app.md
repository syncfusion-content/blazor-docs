---
layout: post
title: Getting Started with WinForms Blazor App in Visual Studio | Syncfusion
description: Check out the documentation for getting started with WinForms Blazor App and Syncfusion Blazor Components in Visual Studio and much more.
platform: Blazor
component: Common
documentation: ug
---

# Getting Started with WinForms Blazor Application

This section explains how to create and run a first WinForms Blazor App (.NET WinForms Blazor) that uses Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components.

## What is WinForms Blazor App?

A WinForms Blazor app hosts a Blazor web app inside a Windows Forms application by using the `BlazorWebView` control. This enables a Blazor web app to integrate with desktop platform features and UI controls. The `BlazorWebView` control can be added to any form in the WinForms app and pointed to the root of the Blazor app. The Blazor components run in the .NET process and render the web UI to an embedded web view control. WinForms Blazor apps run on platforms supported by WinForms (Windows).

Visual Studio provides the **WinForms Application** template to create WinForms Blazor Apps.

## Prerequisites

* [Supported platforms (WinForms documentation)](https://learn.microsoft.com/en-us/dotnet/desktop/winforms/overview/?view=netdesktop-8.0)
* [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)

## Create a new WinForms Blazor App in Visual Studio

To create a **WinForms Blazor App** using Visual Studio, it is essential<sup style="font-size:70%">&reg;</sup> to follow the comprehensive steps outlined in the [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/hybrid/tutorials/windows-forms?view=aspnetcore-8.0) documentation. Ensuring that you understand each step from the official guide will provide the foundation needed to continue with this documentation.

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Calendars and Themes NuGet in the App

To add the **Blazor Calendar** component to the app, open NuGet Package Manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), then search for and install [Syncfusion.Blazor.Calendars](https://www.nuget.org/packages/Syncfusion.Blazor.Calendars/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/). Alternatively, use the following Package Manager commands.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Calendars -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Ensure that the package `Microsoft.AspNetCore.Components.WebView.WindowsForms` is updated to version `8.0.16` or later.

![Winforms Blazor App NuGet package reference](images/winforms/winforms-blazor-package-reference.png)

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the available package list and component mapping.

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

Open **~/_Imports.razor** file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Calendars` namespaces.

```cshtml

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Calendars

```

Now, register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in the `Form1.cs` file of your WinForms Blazor App.

{% tabs %}
{% highlight C# tabtitle="~/Form1.cs" hl_lines="1 3" %}

    using Syncfusion.Blazor;
    ....
    service.AddSyncfusionBlazor();
    ....

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

The theme stylesheet and script are provided by the NuGet packages via [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Reference the stylesheet and script in the `<head>` of the **~wwwroot/index.html** file.

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>
```
N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in your Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in your Blazor application.

## Add Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor component

Add a Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor component to any Razor file. The following example adds the Calendar component in `~/Counter.razor`.

{% tabs %}
{% highlight razor %}

<SfCalendar TValue="DateTime"></SfCalendar>

{% endhighlight %}
{% endtabs %}

In the Visual Studio toolbar, select the start button to build and run the app.

![WinForms Blazor App with Syncfusion Blazor Components](images/winforms/winforms-blazor-calendar.png)