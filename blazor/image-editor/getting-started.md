---
layout: post
title: Getting Started with Blazor Image Editor Component | Syncfusion
description: Learn how to add and configure the Syncfusion Blazor Image Editor component in a Blazor WebAssembly App using Visual Studio or Visual Studio Code.
platform: Blazor
control: Image Editor
documentation: ug
---

# Getting Started with Blazor Image Editor Component

This section explains how to include the [Blazor Image Editor](https://www.syncfusion.com/blazor-components/blazor-image-editor) component in a Blazor WebAssembly app using Visual Studio and Visual Studio Code.

To get started quickly with the Blazor Image Editor component, refer to this video or the corresponding [GitHub sample](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/imageEditor):

{% youtube "youtube:https://www.youtube.com/watch?v=lBB8oHvTuII"%}

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor app in Visual Studio

Create a **Blazor WebAssembly App** using Visual Studio via [Microsoft templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-7.0&pivots=vs) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor ImageEditor and themes NuGet packages

To add the **Blazor Image Editor** component, open the NuGet Package Manager in Visual Studio (Tools → NuGet Package Manager → Manage NuGet Packages for Solution), then search for and install [Syncfusion.Blazor.ImageEditor](https://www.nuget.org/packages/Syncfusion.Blazor.ImageEditor/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/). Alternatively, the following Package Manager commands can be used:

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.ImageEditor -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the list of available packages with component details.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor app in Visual Studio Code

Create a **Blazor WebAssembly App** using Visual Studio Code via [Microsoft templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-7.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project).

Alternatively, create a WebAssembly application using the following terminal commands (<kbd>Ctrl</kbd>+<kbd>`</kbd>):

{% tabs %}

{% highlight c# tabtitle="Blazor WASM App" %}

dotnet new blazorwasm -o BlazorApp
cd BlazorApp

{% endhighlight %}

{% endtabs %}

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor ImageEditor and themes NuGet packages

* Press <kbd>Ctrl</kbd>+<kbd>`</kbd> to open the integrated terminal in Visual Studio Code.
* Ensure the command is run in the project root directory where the `.csproj` file is located.
* Run the following commands to install [Syncfusion.Blazor.ImageEditor](https://www.nuget.org/packages/Syncfusion.Blazor.ImageEditor) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) and restore dependencies.

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.ImageEditor -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}

{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the list of available packages with component details.

{% endtabcontent %}

{% endtabcontents %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service

Open **~/_Imports.razor** and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.ImageEditor` namespaces.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.ImageEditor

{% endhighlight %}
{% endtabs %}

Register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in **~/Program.cs** of the Blazor WebAssembly app.

{% tabs %}
{% highlight C# tabtitle="~/Program.cs" hl_lines="3 11" %}

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSyncfusionBlazor();
await builder.Build().RunAsync();
....

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the stylesheet and script references in the `<head>` section of **~/index.html**.

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>
```
N> See the [Blazor themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic for methods to reference themes in a Blazor application: [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator). Also, see [Adding script reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) for approaches to add script references.

## Add Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Image Editor component

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Image Editor component in **~/Pages/Index.razor**.

{% tabs %}
{% highlight razor tabtitle="~/Index.razor" %}

<SfImageEditor Height="500"></SfImageEditor>

{% endhighlight %}
{% endtabs %}

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the app. This renders the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Image Editor component in the default web browser.

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXrICNDYqKacaGsS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Image Editor Component](./images/blazor-image-editor-component.jpg)" %}

## See also

* [Getting started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for client side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app)
* [Getting started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for server side in Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)
* [Getting started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for server side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app)

N> Explore the [Blazor Image Editor example](https://blazor.syncfusion.com/demos/image-editor/default-functionalities?theme=bootstrap5) to see how to render and configure the Image Editor.
