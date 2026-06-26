---
layout: post
title: Getting Started with Blazor FAB Component in WASM App | Syncfusion
description: Checkout and learn about getting started with Blazor Floating Action Button component in Blazor WebAssembly Application.
platform: Blazor
control: Floating Action Button
documentation: ug
---

# Getting Started with Blazor Floating Action Button in Blazor WASM App

This section briefly explains about how to include [Blazor Floating Action Button](https://www.syncfusion.com/blazor-components/blazor-fab) component in a Blazor WebAssembly App using [Visual Studio](https://visualstudio.microsoft.com/vs/), [Visual Studio Code](https://code.visualstudio.com/), and the [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/).

## Create a new Blazor WebAssembly (Standalone) App

{% tabcontents %}

{% tabcontent Visual Studio %}

Create a **Blazor WebAssembly App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) or the [Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Run the following command to create a new Blazor WebAssembly App.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet new blazorwasm -o BlazorApp
cd BlazorApp

{% endhighlight %}
{% endtabs %}

Alternatively, create a **Blazor WebAssembly App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vsc) or the [Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project), or the [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension.

{% endtabcontent %}

{% tabcontent .NET CLI %}

Run the following command to create a new Blazor WebAssembly App.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}

dotnet new blazorwasm -o BlazorApp
cd BlazorApp

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

## Install the required Blazor packages

Install the [Syncfusion.Blazor.Buttons](https://www.nuget.org/packages/Syncfusion.Blazor.Buttons/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet packages. All Syncfusion Blazor packages are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for details.

{% tabcontents %}

{% tabcontent Visual Studio %}

1. Go to *Tools → NuGet Package Manager → Manage NuGet Packages for Solution*.
2. Search the required NuGet packages (`Syncfusion.Blazor.Buttons` and `Syncfusion.Blazor.Themes`) and install them.

Alternatively, you can install the same packages using the Package Manager Console with the following commands.

{% tabs %}
{% highlight razor tabtitle="Package Manager Console" %}

Install-Package Syncfusion.Blazor.Buttons -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Open the terminal and run the following commands.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet add package Syncfusion.Blazor.Buttons -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent .NET CLI %}

Open the command prompt and run the following commands.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}

dotnet add package Syncfusion.Blazor.Buttons -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

## Add import namespaces

After the packages are installed, open the **~/_Imports.razor** file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Buttons` namespaces.

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Buttons

{% endhighlight %}
{% endtabs %}

## Register the Blazor service

Open the **Program.cs** file in Blazor WebAssembly App and register the Blazor service.

{% tabs %}
{% highlight C# tabtitle="Program.cs" %}

....
using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor();
....

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the [stylesheet](https://blazor.syncfusion.com/documentation/appearance/themes) and [script references](https://blazor.syncfusion.com/documentation/common/adding-script-references) in the **~wwwroot/index.html** file.

{% tabs %}
{% highlight html tabtitle="index.html" %}

...
<link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
...
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

{% endhighlight %}
{% endtabs %}

## Add Blazor Floating Action Button component

Open a Razor file located in the **~/Pages/*.razor** (for example, **Home.razor**) and add the [Blazor Floating Action Button](https://www.syncfusion.com/blazor-components/blazor-fab) component inside the razor file.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.Buttons

<div id="target" style="min-height:200px; position:relative; width:300px; border:1px solid;">
    <SfFab Target="#target" Content="Add"></SfFab>
</div>

{% endhighlight %}
{% endtabs %}

**Run the application**

{% tabcontents %}

{% tabcontent Visual Studio %}

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. The Blazor Floating Action Button component will render in your default web browser.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Open the terminal and run the following command.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet run

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent .NET CLI %}

Open the command prompt and run the following command.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}

dotnet run

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZLTtsVaAldOGCVR?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "![Blazor Floating Action Button Component](./images/blazor-fab-component.webp)" %}

N> [View sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/FloatingActionButton).

## Event Click In Blazor Floating Action Button

The floating action button control triggers the [OnClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfFab.html#Syncfusion_Blazor_Buttons_SfFab_OnClick) event when you click the floating action button. Use this event to perform the required action.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

<div id="target" style="min-height:200px; position:relative; width:300px; border:1px solid;">
    <SfFab Target="#target" IconCss="e-icons e-plus" OnClick="EventClick"></SfFab>
</div>

@code
{    
    public void EventClick()
    {
        // Here, you can call your desired action.
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDBTtMrOqlmTgqWc?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Floating Action Button Component](./images/blazor-fab-event-click-sample.webp)" %}
