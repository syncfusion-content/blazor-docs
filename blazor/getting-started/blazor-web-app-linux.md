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
