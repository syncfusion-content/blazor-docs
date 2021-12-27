---
layout: post
title: Getting started with Syncfusion Blazor Server App in Visual Studio
description: Check out the documentation for getting started with Syncfusion Blazor Components in Visual Studio and much more.
platform: Blazor
component: Common
documentation: ug
---

# Getting Started with Blazor Server Side App in Visual Studio

This article provides step-by-step instructions for building Blazor Server App with the `Blazor Calendar` component using [Visual Studio](https://visualstudio.microsoft.com/vs/). 

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Server App in Visual Studio

You can create **Blazor Server App** using Visual Studio in one of the following ways,

* [Create a Project using Microsoft Templates](https://docs.microsoft.com/en-us/aspnet/core/blazor/tooling?pivots=windows)

* [Create a Project using Syncfusion Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/vs2019-extensions/create-project)

## Install Syncfusion Blazor Packages in the App

Syncfusion Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). To use Syncfusion Blazor components in the application, add a reference to the corresponding NuGet. Refer to the [NuGet packages topic](https://blazor.syncfusion.com/documentation/nuget-packages) for the available NuGet packages list with component details. 

To add the Blazor Calendar component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search for [Syncfusion.Blazor.Calendars](https://www.nuget.org/packages/Syncfusion.Blazor.Calendars/) and then install it.

## Add Style Sheet

Checkout the [Blazor Themes topic](https://blazor.syncfusion.com/documentation/appearance/themes) to learn different ways to refer to themes in the Blazor application, and to have the expected appearance for Syncfusion Blazor components. Here, the theme is referred using [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets).

To add theme to the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search for [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) and then install it. Then, the theme style sheet from NuGet can be referred as follows,

* For **.NET 6** app, add the Syncfusion bootstrap5 theme in the `<head>` element of the **~/Pages/_Layout.cshtml** page.

    {% tabs %}
    {% highlight cshtml %}
        <head>
            ....
            <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
        </head>
    {% endhighlight %}
    {% endtabs %}

* For **.NET 5 and .NET 3.X** app, add the Syncfusion bootstrap5 theme in the `<head>` element of the **~/Pages/_Host.cshtml** page.

    {% tabs %}
    {% highlight cshtml %}
        <head>
            ....
            <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
        </head>
    {% endhighlight %}
    {% endtabs %}

## Add Script Reference

Checkout [Adding Script Reference topic](https://blazor.syncfusion.com/documentation/common/adding-script-references) to learn different ways to add script reference in the Blazor Application. In this getting started walk-through, the required scripts are referenced automatically via javascript script isolation approach. 

> Syncfusion recommends reference scripts using [Static Web Assets](https://blazor.syncfusion.com/documentation/common/adding-script-references#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/common/adding-script-references#cdn-reference) and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator) by [disabling JavaScript isolation](https://blazor.syncfusion.com/documentation/common/adding-script-references#disable-javascript-isolation) for better loading performance of the Blazor application. 

## Register Syncfusion Blazor Service

* Open **~/_Imports.razor** file and import the `Syncfusion.Blazor` namespace.

    {% tabs %}
    {% highlight razor %}
    @using Syncfusion.Blazor
    {% endhighlight %}
    {% endtabs %}

* Now, register the Syncfusion Blazor Service in the Blazor Server App.

* For **.NET 6** app, open the **~/Program.cs** file and register the Syncfusion Blazor Service.
        
        {% tabs %}
        {% highlight c# %}
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
        {% endtabs %}

* For **.NET 5 and .NET 3.X** app, open the **~/Startup.cs** file and register the Syncfusion Blazor Service.

        {% tabs %}
        {% highlight c# %}

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

## Add Syncfusion Blazor component

* Open **~/_Imports.razor** file or any razor page under the `~/Pages` folder where the component is to be added and import the `Syncfusion.Blazor.Calendars` namespace.
 
    {% tabs %}
    {% highlight razor %}

    @using Syncfusion.Blazor
    @using Syncfusion.Blazor.Calendars
    
    {% endhighlight %}
    {% endtabs %}

* Now, add the Syncfusion Calendar component in the razor file. Here, the Calendar component is added in the **~/Pages/Index.razor** page under the `~/Pages` folder.

    {% tabs %}
    {% highlight razor %}

    <SfCalendar TValue="DateTime"/>

    {% endhighlight %}
    {% endtabs %}

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the app. Then, the Syncfusion Blazor Calendar component will be rendered in the default web browser.

    ![Blazor Calendar Component](images/browser-output.png)

> You need to include a valid license key (either paid or trial key) within your applications. Please refer to this [help topic](https://blazor.syncfusion.com/documentation/getting-started/license-key/overview) for more information.