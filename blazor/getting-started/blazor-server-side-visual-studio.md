---
layout: post
title: Getting started with Syncfusion Blazor Server App in Visual Studio
description: Check out the documentation for getting started with Syncfusion Blazor Components and more.
platform: Blazor
component: Common
documentation: ug
---

# Getting Started with Blazor Server Side App in Visual Studio

This article provides a step-by-step instructions for building Syncfusion Blazor Server App with `Blazor Calendar` component using [Visual Studio](https://visualstudio.microsoft.com/vs/). 

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Server App in Visual Studio

Refer to the [Tooling for Blazor](https://docs.microsoft.com/en-us/aspnet/core/blazor/tooling?pivots=windows) to create a new **Blazor Server App** using Visual Studio.

## Install Syncfusion Blazor Packages in the App

Syncfusion Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). In order to use Syncfusion Blazor components in your application, you need to add reference to the corresponding NuGet. Refer to [NuGet packages topic](https://blazor.syncfusion.com/documentation/nuget-packages) for available NuGet packages list with component details. 

To add Blazor Calendar component in your app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search for [Syncfusion.Blazor.Calendars](https://www.nuget.org/packages/Syncfusion.Blazor.Calendars/) and then install it.

## Add Style Sheet

Checkout [Blazor Themes topic](https://blazor.syncfusion.com/documentation/appearance/themes) to learn different ways to refer themes in Blazor application to have the expected appearance for Syncfusion Blazor components. Here, theme is referred using [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets).

To add theme to your app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search for [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) and then install it. Then, you can refer theme as follows,

* For **.NET 6** app, add the Syncfusion bootstrap5 theme in the `<head>` element of the **~/Pages/_Layout.cshtml** page.

    {% tabs %}
    {% highlight cshtml tabtitle=~/_Layout.cshtml %}
        <head>
            ....
            <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
        </head>
    {% endhighlight %}
    {% endtabs %}

* For **.NET 5 and .NET 3.X** app, add the Syncfusion bootstrap5 theme in the `<head>` element of the **~/Pages/_Host.cshtml** page.

    {% tabs %}
    {% highlight cshtml tabtitle=~/_Layout.cshtml %}
        <head>
            ....
            <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
        </head>
    {% endhighlight %}
    {% endtabs %}

## Add Script Reference

Checkout [Adding Script Reference topic](https://blazor.syncfusion.com/documentation/common/adding-script-references) to learn different ways to add script reference in Blazor Application. In this getting started walk-through, needed scripts are referenced via javascript script isolation approach. 

> Syncfusion recommends to reference scripts using [Static Web Assets](https://blazor.syncfusion.com/documentation/common/adding-script-references#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/common/adding-script-references#cdn-reference) and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator) by [disabling JavaScript isolation](https://blazor.syncfusion.com/documentation/common/adding-script-references#disable-javascript-isolation) for better loading performance of the blazor application. 

## Register Syncfusion Blazor Service

* Open **~/_Imports.razor** file and import the `Syncfusion.Blazor` namespace.

    {% tabs %}
    {% highlight razor tabtitle=~/Imports.razor %}

        @using Syncfusion.Blazor
        @using Syncfusion.Blazor.Calendars

    {% endhighlight %}
    {% endtabs %}

* Now, register the Syncfusion Blazor Service to the Blazor Server App.

    a) For **.NET 6** app, open the **~/Program.cs** file and register the Syncfusion Blazor Service.

    {% tabs %}
    {% highlight c# tabtitle=~/Program.cs %}

        using Microsoft.AspNetCore.Components;
        using Microsoft.AspNetCore.Components.Web;
        using Syncfusion.Blazor;

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        ....
        builder.Services.AddSyncfusionBlazor();
        var app = builder.Build();
        ....
    {% endhighlight %}
    {% endtabs %}

    b) For **.NET 5 and .NET 3.X** app, open the **~/Startup.cs** file and register the Syncfusion Blazor Service.

    {% tabs %}
    {% highlight c# tabtitle=~/Startup.cs %}

    using Syncfusion.Blazor;

    namespace WebApplication1
    {
        public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
            {
                ....
                ....
                services.AddSyncfusionBlazor();
            }
        }
    }
    
    {% endhighlight %}
    {% endtabs %}

## Add Syncfusion Blazor component
* Open **~/_Imports.razor** file or the razor page you are going to add component and import the `Syncfusion.Blazor.Calendars` namespace. 

    {% tabs %}
    {% highlight razor tabtitle=~/Imports.razor %}

        @using Syncfusion.Blazor
        @using Syncfusion.Blazor.Calendars

    {% endhighlight %}
    {% endtabs %}

* Now, add the Syncfusion Calendar component in a file under the `~/Pages` folder. For example, the Calendar component is added in the **~/Pages/Index.razor** page.

    {% tabs %}
    {% highlight razor tabtitle=~/Index.razor %}

        <SfCalendar TValue="DateTime"/>

    {% endhighlight %}
    {% endtabs %}

* Run the application. Then, the Syncfusion Blazor Calendar component will be rendered in the default web browser.

    ![Blazor Calendar Component](images/browser-output.png)

> You need to include a valid license key (either paid or trial key) within your applications. Please refer to this [help topic](https://blazor.syncfusion.com/documentation/getting-started/license-key/overview) for more information.