---
layout: post
title: Getting started with Syncfusion Blazor Web App in Visual Studio
description: Check out the documentation for getting started with Syncfusion Blazor Components in Blazor Web App.
platform: Blazor
component: Common
documentation: ug
---

# Getting Started with Blazor Web App

This article provides a step-by-step instructions for building `Blazor Web App` with `Blazor Accordion` component using [Visual Studio](https://visualstudio.microsoft.com/vs/).

## Using Playground

[Blazor Playground](https://blazor.syncfusion.com/documentation/blazor-playground/overview) allows you to interact with our Blazor components directly in your web browser without need to install any required NuGet packages. By default, the `Syncfusion.Blazor` package is included in this.

To use the individual component in Blazor playground, uninstall the existing package and then install the needed NuGet package.

![Blazor Playground with Accordion component](images/pg-accordion.png)

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Using Syncfusion Blazor Template

Run the following command to create a new Blazor Web App in a command prompt (Windows) or terminal (macOS) or command shell (Linux).

If you set the Authentication Type as `None` and Interactivity location as `Per page/component`, you need to use the following command.

|Interactive<br/> render mode | Command |
|---|---|
| server | <pre lang="xml">dotnet new blazor -o BlazorApp -int Server<br/>cd BlazorApp</pre>|
|WebAssembly|<pre lang="xml">dotnet new blazor -o BlazorApp -int WebAssembly<br/>cd BlazorApp<br/>cd BlazorApp.Client</pre>|
|Auto|<pre lang="xml">dotnet new blazor -o BlazorApp -int Auto<br/>cd BlazorApp<br/>cd BlazorApp.Client</pre>|
|None|<pre lang="xml">dotnet new blazor -o BlazorApp -int None<br/>cd BlazorApp</pre>|

If you set the Authentication Type as `Individual Accounts` and Interactivity location as `Per page/component`, you need to use the following command.

|Interactive<br/> render mode | Command |
|---|---|
| server | <pre lang="xml">dotnet new blazor -o BlazorApp -au Individual -int Server<br/>cd BlazorApp</pre>|
|WebAssembly|<pre lang="xml">dotnet new blazor -o BlazorApp -au Individual -int WebAssembly<br/>cd BlazorApp<br/>cd BlazorApp.Client</pre>|
|Auto|<pre lang="xml">dotnet new blazor -o BlazorApp -au Individual -int Auto<br/>cd BlazorApp<br/>cd BlazorApp.Client</pre>|
|None|<pre lang="xml">dotnet new blazor -o BlazorApp -au Individual -int None<br/>cd BlazorApp</pre>|

If you set the Authentication Type as `Individual Accounts` and Interactivity location as `Global`, you need to use the following command.

|Interactive<br/> render mode | Command |
|---|---|
| server | <pre lang="xml">dotnet new blazor -o BlazorApp -au Individual -int Server -ai<br/>cd BlazorApp</pre>|
|WebAssembly|<pre lang="xml">dotnet new blazor -o BlazorApp -au Individual -int WebAssembly -ai<br/>cd BlazorApp<br/>cd BlazorApp.Client</pre>|
|Auto|<pre lang="xml">dotnet new blazor -o BlazorApp -au Individual -int Auto -ai<br/>cd BlazorApp<br/>cd BlazorApp.Client</pre>|
|None|<pre lang="xml">dotnet new blazor -o BlazorApp -au Individual -int None -ai<br/>cd BlazorApp</pre>|

If you set the Authentication Type as `None` and Interactivity location as `Global`, you need to use the following command.

|Interactive<br/> render mode | Command |
|---|---|
| server | <pre lang="xml">dotnet new blazor -o BlazorApp -int Server-ai<br/>cd BlazorApp</pre>|
|WebAssembly|<pre lang="xml">dotnet new blazor -o BlazorApp -int WebAssembly -ai<br/>cd BlazorApp<br/>cd BlazorApp.Client</pre>|
|Auto|<pre lang="xml">dotnet new blazor -o BlazorApp8 -int Auto -ai<br/>cd BlazorApp<br/>cd BlazorApp.Client</pre>|
|None|<pre lang="xml">dotnet new blazor -o BlazorApp8 -int None -ai<br/>cd BlazorApp</pre>|


N> If you want to see more available templates, you need to run the `dotnet new blazor --help` or `dotnet new blazor -h` command.

## Manually Creating a project

### Create a new Blazor Web App

You can create a **Blazor Web App** using Visual Studio 2022 via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0) or the [Syncfusion Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

You need to configure the corresponding [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=windows) while creating a Blazor Web Application.

### Install Syncfusion Blazor Navigations and Themes NuGet in the Blazor Web App

Here's an example of how to add **Blazor Accordion** component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search and install [Syncfusion.Blazor.Navigations](https://www.nuget.org/packages/Syncfusion.Blazor.Navigations/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/).

If you utilize `WebAssembly or Auto` render modes in the Blazor Web App need to be install Syncfusion Blazor components NuGet packages within the client project.

Alternatively, you can utilize the following package manager command to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Navigations -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

### Register Syncfusion Blazor Service

Open **~/_Imports.razor** file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Navigations` namespace .

```cshtml

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Navigations

```

Now, register the Syncfusion Blazor Service in the **~/Program.cs** file of your Blazor Web App. For a app with `WebAssembly` or `Auto (Server and WebAssembly)` interactive render mode, register the Syncfusion Blazor service in both **~/Program.cs** files of your web app.
```cshtml

....
using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor();
....

```

### Add stylesheet and script resources

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

### Add Syncfusion Blazor Accordion component

Add the Syncfusion Blazor Accordion component in the **~/Components/Pages/*.razor** file. If an interactivity location as `Per page/component` in the web app, define a render mode at the top of the `~Pages/*.razor` component, as follows:

{% tabs %}
{% highlight razor %}

@* desired render mode define here *@
@rendermode InteractiveAuto

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight razor %}

<SfAccordion>
    <AccordionItems>
        <AccordionItem Header="Margeret Peacock" Content="Margeret Peacock was born on Saturday , 01 December 1990. Now lives at Coventry House Miner Rd., London,UK. Margeret Peacock holds a position of Sales Coordinator in our WA department, (Seattle USA). Joined our company on Saturday , 01 May 2010"></AccordionItem>
        <AccordionItem Header="Laura Callahan" Content="Laura Callahan was born on Tuesday , 06 November 1990. Now lives at Edgeham Hollow Winchester Way, London,UK. Laura Callahan holds a position of Sales Coordinator in our WA department, (Seattle USA). Joined our company on Saturday , 01 May 2010"></AccordionItem>
        <AccordionItem Header="Albert Dodsworth" Content="Albert Dodsworth was born on Thursday , 19 October 1989. Now lives at 4726 - 11th Ave. N.E., Seattle,USA.Albert Dodsworth holds a position of Sales Representative in our WA department, (Seattle USA). Joined our company on Friday , 01 May 2009"></AccordionItem>
    </AccordionItems>
</SfAccordion>

{% endhighlight %}
{% endtabs %}

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This will render the Syncfusion Blazor Accordion component in your default web browser.

![Blazor Accordion Component](images/blazor-accordion-component.png)
