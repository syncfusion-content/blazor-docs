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

To get start quickly with Blazor Web App, you can check on this video.

{% youtube
"youtube:https://www.youtube.com/watch?v=hjPGxApA5W8" %}

## Using Playground

[Blazor Playground](https://blazor.syncfusion.com/documentation/blazor-playground/overview) allows you to interact with our Blazor components directly in your web browser without need to install any required NuGet packages. By default, the `Syncfusion.Blazor` package is included in this.

[https://blazorplayground.syncfusion.com/](https://blazorplayground.syncfusion.com/)

To use the individual component in Blazor playground, uninstall the existing package and then install the needed NuGet package.

![Blazor Playground with Accordion component](images/pg-accordion.png)

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App

You can create a **Blazor Web App** using Visual Studio 2022 via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

You need to configure the corresponding [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=windows) while creating a Blazor Web Application.

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Navigations and Themes NuGet in the Blazor Web App

Here's an example of how to add **Blazor Accordion** component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search and install [Syncfusion.Blazor.Navigations](https://www.nuget.org/packages/Syncfusion.Blazor.Navigations/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/).

If you utilize `WebAssembly or Auto` render modes in the Blazor Web App need to be install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components NuGet packages within the client project.

Alternatively, you can utilize the following package manager command to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Navigations -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

If you previously installed the SDK, you can determine the installed version by executing the following command in a command prompt (Windows) or terminal (macOS) or command shell (Linux).

{% tabs %}
{% highlight c# tabtitle="SDK version" %}

dotnet --version

{% endhighlight %}
{% endtabs %}

## Create a new Blazor Web App in Visual Studio Code

You can create a **Blazor Web App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project).

You need to configure the corresponding [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vsc) while creating a Blazor Web Application.

For example, in a Blazor Web App with the `Auto` interactive render mode, use the following commands.

{% tabs %}
{% highlight c# tabtitle="Blazor Web App" %}

dotnet new blazor -o BlazorWebApp -int Auto
cd BlazorWebApp
cd BlazorWebApp.Client

{% endhighlight %}
{% endtabs %}

Run the following command to create a new **Blazor Web App** with various interactive modes and locations in a command prompt (Windows) or terminal (macOS) or command shell (Linux).

If you set the Authentication Type as `None` and Interactivity location as `Per page/component`, you need to use the following command.

<table>
<tr>
<th>Interactive Render Mode</th>
<th>Command</th>
</tr>
<tr>
<td>Server</td>
<td>
{% highlight c# %}
dotnet new blazor -o BlazorApp -int Server
{% endhighlight %}
</td>
</tr>
<tr>
<td>WebAssembly</td>
<td>
{% highlight c# %}
dotnet new blazor -o BlazorApp -int WebAssembly
{% endhighlight %}
</td>
</tr>
<tr>
<td>Auto</td>
<td>
{% highlight c# %}
dotnet new blazor -o BlazorApp -int Auto
{% endhighlight %}
</td>
</tr>
<tr>
<td>None</td>
<td>
{% highlight c# %}
dotnet new blazor -o BlazorApp -int None
{% endhighlight %}
</td>
</tr>
</table>

If you set the Authentication Type as `Individual Accounts` and Interactivity location as `Per page/component`, you need to use the following command.

<table>
<tr>
<th>Interactive Render Mode</th>
<th>Command</th>
</tr>
<tr>
<td>Server</td>
<td>
{% highlight c# %}
dotnet new blazor -o BlazorApp -au Individual -int Server
{% endhighlight %}
</td>
</tr>
<tr>
<td>WebAssembly</td>
<td>
{% highlight c# %}
dotnet new blazor -o BlazorApp -au Individual -int WebAssembly
{% endhighlight %}
</td>
</tr>
<tr>
<td>Auto</td>
<td>
{% highlight c# %}
dotnet new blazor -o BlazorApp -au Individual -int Auto
{% endhighlight %}
</td>
</tr>
<tr>
<td>None</td>
<td>
{% highlight c# %}
dotnet new blazor -o BlazorApp -au Individual -int None
{% endhighlight %}
</td>
</tr>
</table>

If you set the Authentication Type as `Individual Accounts` and Interactivity location as `Global`, you need to use the following command.

<table>
<tr>
<th>Interactive Render Mode</th>
<th>Command</th>
</tr>
<tr>
<td>Server</td>
<td>
{% highlight c# %}
dotnet new blazor -o BlazorApp -au Individual -int Server -ai
{% endhighlight %}
</td>
</tr>
<tr>
<td>WebAssembly</td>
<td>
{% highlight c# %}
dotnet new blazor -o BlazorApp -au Individual -int WebAssembly -ai
{% endhighlight %}
</td>
</tr>
<tr>
<td>Auto</td>
<td>
{% highlight c# %}
dotnet new blazor -o BlazorApp -au Individual -int Auto -ai
{% endhighlight %}
</td>
</tr>
<tr>
<td>None</td>
<td>
{% highlight c# %}
dotnet new blazor -o BlazorApp -au Individual -int None -ai
{% endhighlight %}
</td>
</tr>
</table>

If you set the Authentication Type as `None` and Interactivity location as `Global`, you need to use the following command.

<table>
<tr>
<th>Interactive Render Mode</th>
<th>Command</th>
</tr>
<tr>
<td>Server</td>
<td>
{% highlight c# %}
dotnet new blazor -o BlazorApp -int Server-ai
{% endhighlight %}
</td>
</tr>
<tr>
<td>WebAssembly</td>
<td>
{% highlight c# %}
dotnet new blazor -o BlazorApp -int WebAssembly -ai
{% endhighlight %}
</td>
</tr>
<tr>
<td>Auto</td>
<td>
{% highlight c# %}
dotnet new blazor -o BlazorApp8 -int Auto -ai
{% endhighlight %}
</td>
</tr>
<tr>
<td>None</td>
<td>
{% highlight c# %}
dotnet new blazor -o BlazorApp8 -int None -ai
{% endhighlight %}
</td>
</tr>
</table>

N> If you want to see more available templates, you need to run the `dotnet new blazor --help` or `dotnet new blazor -h` command.

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Navigations and Themes NuGet in the App

If you utilize `WebAssembly` or `Auto` render modes in the Blazor Web App need to be install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components NuGet packages within the client project.

* Press <kbd>Ctrl</kbd>+<kbd>`</kbd> to open the integrated terminal in Visual Studio Code.
* Ensure you’re in the project root directory where your `.csproj` file is located.
* Run the following command to install a [Syncfusion.Blazor.Navigations](https://www.nuget.org/packages/Syncfusion.Blazor.Navigations) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet package and ensure all dependencies are installed.

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.Navigations -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}

{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

{% endtabcontent %}

{% endtabcontents %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

| Interactive Render Mode | Description |
| -- | -- |
| WebAssembly or Auto | Open **~/_Imports.razor** file from the client project.|
| Server | Open **~/_import.razor** file, which is located in the `Components` folder.|

Import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Navigations` namespace.

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Navigations

{% endhighlight %}
{% endtabs %}

Now, register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service in the **~/Program.cs** file of your Blazor Web App.

If the **Interactive Render Mode** is set to `WebAssembly` or `Auto`, you need to register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in both **~/Program.cs** files of your Blazor Web App.

{% tabs %}
{% highlight c# tabtitle="Server(~/_Program.cs)" hl_lines="3 11" %}

...
...
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
....

{% endhighlight %}
{% highlight c# tabtitle="Client(~/_Program.cs)" hl_lines="2 5" %}

...
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSyncfusionBlazor();

await builder.Build().RunAsync();

{% endhighlight %}
{% endtabs %}

If the **Interactive Render Mode** is set to `Server`, your project will contain a single **~/Program.cs** file. So, you should register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service only in that **~/Program.cs** file.

{% tabs %}
{% highlight c# tabtitle="~/_Program.cs" hl_lines="2 9" %}

...
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
....

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the stylesheet reference in the `<head>` section and the script reference at the end of the `<body>` in the **~/Components/App.razor** file as shown below:

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>

<body>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>

```

N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in your Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in your Blazor application.

## Add Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Accordion component

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Accordion component in the **~/Components/Pages/*.razor** file. If an interactivity location as `Per page/component` in the web app, define a render mode at the top of the `~Pages/*.razor` component, as follows:

| Interactivity location | RenderMode | Code |
| --- | --- | --- |
| Per page/component | Auto | @rendermode InteractiveAuto |
|  | WebAssembly | @rendermode InteractiveWebAssembly |
|  | Server | @rendermode InteractiveServer |
|  | None | --- |

N> If an **Interactivity Location** is set to `Global` and the **Render Mode** is set to `Auto` or `WebAssembly` or `Server`, the render mode is configured in the `App.razor` file by default.

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

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This will render the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Accordion component in your default web browser.

![Blazor Accordion Component](images/blazor-accordion-component.png)
