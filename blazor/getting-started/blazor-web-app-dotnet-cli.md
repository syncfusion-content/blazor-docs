---
layout: post
title: Getting Started - Syncfusion Blazor Web App in .NET CLI
description: Checkout the documentation for getting started with Blazor Web App and Syncfusion Blazor Components in Visual Studio using .NET CLI and much more.
platform: Blazor
component: Common
documentation: ug
---

#  Getting Started with Blazor Web App in .NET CLI

This article provides a step-by-step instructions for building Blazor Web App with `Syncfusion Blazor` component using the [.NET CLI](https://dotnet.microsoft.com/en-us/download/dotnet).

## Using Playground

[Blazor Playground](https://blazor.syncfusion.com/documentation/blazor-playground/overview) allows you to interact with our Blazor components directly in your web browser without need to install any required NuGet packages. By default, the `Syncfusion.Blazor` package is included in this.

[https://blazorplayground.syncfusion.com/](https://blazorplayground.syncfusion.com/)

To use the individual component in Blazor playground, uninstall the existing package and then install the needed NuGet package.

![Blazor Playground with Accordion component](images/pg-accordion.png)

## Prerequisites

Latest version of the [.NET Core SDK](https://dotnet.microsoft.com/en-us/download). If you previously installed the SDK, you can determine the installed version by executing the following command in a command prompt (Windows) or terminal (macOS) or command shell (Linux).

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet --version

{% endhighlight %}
{% endtabs %}

## Create a Blazor Web project using .NET CLI

Run the following command to create a new Blazor Web App in a command prompt (Windows) or terminal (macOS) or command shell (Linux).

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

This command creates new Blazor Web app project and places it in a new directory called `BlazorApp` inside your current location. See [Create Blazor app topic](https://dotnet.microsoft.com/en-us/learn/aspnet/blazor-tutorial/create) and [dotnet new CLI command](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?pivots=linux-macos&view=aspnetcore-8.0) topics for more details.

N> If you want to see more available templates, you need to run the `dotnet new blazor --help` or `dotnet new blazor -h` command.

## Install Syncfusion Blazor Calendars and Themes NuGet in the App

Here's an example of how to add **Blazor Calendar** component in the application using the following command in the command prompt (Windows) or terminal (Linux and macOS) to install a [Syncfusion.Blazor.Calendars](https://www.nuget.org/packages/Syncfusion.Blazor.Calendars/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet package. See [Install and manage packages using the dotnet CLI](https://learn.microsoft.com/en-us/nuget/consume-packages/install-use-packages-dotnet-cli) topics for more details.

If you utilize `WebAssembly or Auto` render modes in the Blazor Web App need to be install Syncfusion Blazor components NuGet packages within the client project.

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.Calendars --version {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes --version {{ site.releaseversion }}
dotnet restore

{% endhighlight %}
{% endtabs %}

N> Syncfusion Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

## Register Syncfusion Blazor Service

Open **~/_Imports.razor** file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Calendars` namespace.

```cshtml

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Calendars

```

Now, register the Syncfusion Blazor Service in the **~/Program.cs** file of your App.

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
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>
....
<body>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```

N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in your Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in your Blazor application.

## Add Syncfusion Blazor component

Add the Syncfusion Blazor Calendar component in the **~/Pages/.razor** file. If an interactivity location as `Per page/component` in the web app, define a render mode at the top of the `~Pages/.razor` component, as follows:

{% tabs %}
{% highlight razor %}

@* desired render mode define here *@
@rendermode InteractiveAuto

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight razor %}

<SfCalendar TValue="DateTime" />

{% endhighlight %}
{% endtabs %}

* In the command prompt (Windows) or terminal (Linux and macOS) to run the following command to build and start the app. The app listening on `http://localhost:<port number>` and view it in the browser.

* If an interactive render mode as `WebAssembly` or `Auto` in the web app, you should run the Blazor server project.

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet run

{% endhighlight %}
{% endtabs %}

![Blazor Calendar Component](images/output-calendar-using-blazor-webassembly.png)

## See also

* [Getting Started with Blazor Server App using .NET CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-dotnet-cli)
