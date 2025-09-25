---
layout: post
title: Getting Started with Blazor Avatar Component | Syncfusion
description: Checkout and learn about getting started with Blazor Avatar component in Blazor WebAssembly Application.
platform: Blazor
control: Avatar
documentation: ug
---

<!-- markdownlint-disable MD024 -->

# Getting Started with Blazor Avatar Component

This section provides a brief explanation on how to include the Syncfusion [Blazor Avatar](https://blazor.syncfusion.com/documentation/avatar/getting-started) component in your Blazor WebAssembly App using Visual Studio and Visual Studio Code.

To get started quickly with the Avatar component using Blazor, you can check out this video tutorial:

{% youtube
"youtube:https://www.youtube.com/watch?v=IYZEZUQd6JE"%}

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio

You can create a **Blazor WebAssembly App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-7.0&pivots=vs) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Themes NuGet in the App

To add **Blazor Avatar** component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search and install [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/). 
Alternatively, you can utilize the following package manager command in the Package Manager Console:

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) for available NuGet packages list with component details. Remember to replace `{{ site.releaseversion }}` with your specific Syncfusion Blazor version (e.g., `24.1.41`).

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio Code

You can create a **Blazor WebAssembly App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-7.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project).

Alternatively, a WebAssembly application can be created by executing the following command in the terminal: (<kbd>Ctrl</kbd>+<kbd>`</kbd>)

{% tabs %}

{% highlight c# tabtitle="Blazor WASM App" %}

dotnet new blazorwasm -o BlazorApp
cd BlazorApp

{% endhighlight %}

{% endtabs %}

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Themes NuGet in the App

* Press <kbd>Ctrl</kbd>+<kbd>`</kbd> to open the integrated terminal in Visual Studio Code.
* Ensure you’re in the project root directory where your `.csproj` file is located.
* Run the following command to install a [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet package and ensure all dependencies are installed.

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}

{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) for available NuGet packages list with component details. Remember to replace `{{ site.releaseversion }}` with your specific Syncfusion Blazor version (e.g., `24.1.41`).

{% endtabcontent %}

{% endtabcontents %}

## Add Stylesheet

The theme stylesheet can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the stylesheet reference within the `<head>` section of the **~/index.html** file.

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>
```
N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in your Blazor application.

## Add Blazor Avatar component

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Avatar component to your **~/Pages/Index.razor** file. Its appearance can be customized using properties such as `Size`, and content can be provided through `ChildContent` or `ContentTemplate`.


{% tabs %}
{% highlight razor %}

<!-- xSmall Avatar-->
<div class="e-avatar e-avatar-xsmall image"></div>

<!-- Small Avatar-->
<div class="e-avatar e-avatar-small image"></div>

<!-- Avatar-->
<div class="e-avatar image"></div>

<!-- Large Avatar-->
<div class="e-avatar e-avatar-large image"></div>

<!-- xLarge Avatar-->
<div class="e-avatar e-avatar-xlarge image"></div>

<style>
    .e-avatar {
        background-image: url(https://ej2.syncfusion.com/demos/src/avatar/images/pic01.png);
    }
</style>

{% endhighlight %}
{% endtabs %}

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This action will render the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Avatar components in the default web browser.

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNreZyVMASlmWFyr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "![Blazor Avatar Component](./images/blazor-avatar-component.png)" %}
