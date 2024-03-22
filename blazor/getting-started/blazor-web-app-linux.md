---
layout: post
title: Getting Started - Syncfusion Blazor Web App in Linux
description: Check out the documentation for getting started with Blazor Web App and Syncfusion Blazor Components in Visual Studio using .NET CLI and much more.
platform: Blazor
component: Common
documentation: ug
---

# Getting Started with Blazor Web App in Linux (Ubuntu)

## Prerequisites

Ensure you have the latest version of the [.NET SDK](https://learn.microsoft.com/en-us/dotnet/core/install/linux-ubuntu) installed. If you previously installed the SDK, you can determine the installed version by executing the following command in a terminal.

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet --version

{% endhighlight %}
{% endtabs %}

## Create a Blazor Web project using .NET CLI

Run the following command in a terminal to create a new Blazor Web App. For a Blazor Web App with `Server` interactive render mode & `Per page/component` interactivity location, use the following commands,

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet new blazor -o BlazorApp
cd BlazorApp

{% endhighlight %}
{% endtabs %}

For a Blazor Web App with `WebAssembly` interactive render mode & `Per page/component` interactivity location, use the following commands.

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet new blazor -o BlazorApp -int WebAssembly
cd BlazorApp
cd BlazorApp.Client

{% endhighlight %}
{% endtabs %}

For a Blazor Web App with `Auto` interactive render mode & `Per page/component` interactivity location, use the following commands.

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet new blazor -o BlazorApp -int Auto
cd BlazorApp
cd BlazorApp.Client

{% endhighlight %}
{% endtabs %}

This command creates new Blazor Web app project and places it in a new directory called `BlazorApp` inside your current location. See [dotnet new CLI command](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?pivots=linux-macos&view=aspnetcore-8.0) command topics for more details.

## Install Syncfusion Blazor Calendars and Themes NuGet in the App

Here’s an example of how to add Blazor Calendar component in the application using the following command in the terminal to install a [Syncfusion.Blazor.Calendars](https://www.nuget.org/packages/Syncfusion.Blazor.Calendars/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet package. See [Install and manage packages using the dotnet CLI](https://learn.microsoft.com/en-us/nuget/consume-packages/install-use-packages-dotnet-cli) topics for more details.

If you utilize `WebAssembly or Auto` render modes in the Blazor Web App, you need to install Syncfusion Blazor components NuGet packages within the client project.

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.Calendars --version {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes --version {{ site.releaseversion }}
dotnet restore

{% endhighlight %}
{% endtabs %}

N> Syncfusion Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

## Register Syncfusion Blazor Service

Open **~/_Imports.razor** file and import the Syncfusion.Blazor and Syncfusion.Blazor.Calendars namespace.


```cshtml

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Calendars

```

Now, register the Syncfusion Blazor Service in the **~/Program.cs** file of your App.
If you select an Interactive render mode as `WebAssembly` or `Auto`, you need to register the Syncfusion Blazor service in both **~/Program.cs** files of your Blazor Web App.


```cshtml

....
using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor();
....

```

## Add Stylesheet and Script Resources

The theme stylesheet and script can be accessed from NuGet through Static Web Assets. Include the stylesheet reference in the <head> section and the script reference at the end of the <body> in the ~/Components/App.razor file as shown below:

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

Add the Syncfusion Blazor Calendar component in the ~/Pages/.razor file. Ensure the page is defined with a render mode at the top of the ~Pages/.razor component, as follows:

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

*	In the terminal, run the following command to build and start the app. The app will listen on http://localhost:<port number> and you can view it in the browser.
*	If an interactive render mode as WebAssembly or Auto in the web app, you should run the Blazor server project.

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet run

{% endhighlight %}
{% endtabs %}

![Blazor Calendar Component](images/output-calendar-using-blazor-webassembly.png)
