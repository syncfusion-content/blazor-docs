---
layout: post
title: Getting Started with Blazor Dialog Component | Syncfusion
description: Checkout and learn about getting started with Blazor Dialog component in Blazor WebAssembly Application.
platform: Blazor
control: Dialog
documentation: ug
---

# Getting Started with Blazor Dialog Component

This section explains how to add the [Blazor Dialog](https://www.syncfusion.com/blazor-components/blazor-modal-dialog) component to a Blazor WebAssembly app using Visual Studio and Visual Studio Code.

To get started quickly with the Blazor Dialog component, watch the following video or use the sample on [GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/Dialog).
{% youtube
"youtube:https://www.youtube.com/watch?v=uSyGKuB8ghg"%}

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio

Create a **Blazor WebAssembly App** using Visual Studio via [Microsoft templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-7.0&pivots=vs) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Popups and Themes NuGet in the App

To add the **Blazor Dialog** component, open NuGet Package Manager in Visual Studio (Tools → NuGet Package Manager → Manage NuGet Packages for Solution), then search for and install [Syncfusion.Blazor.Popups](https://www.nuget.org/packages/Syncfusion.Blazor.Popups) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/). Alternatively, use the following Package Manager commands:

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Popups -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). For the list of available packages and component details, see the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio Code

Create a **Blazor WebAssembly App** using Visual Studio Code via [Microsoft templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-7.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project).

Alternatively, create a WebAssembly application using the following commands in the terminal (<kbd>Ctrl</kbd>+<kbd>`</kbd>).

{% tabs %}

{% highlight c# tabtitle="Blazor WASM App" %}

dotnet new blazorwasm -o BlazorApp
cd BlazorApp

{% endhighlight %}

{% endtabs %}

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Popups and Themes NuGet in the App

* Press <kbd>Ctrl</kbd>+<kbd>`</kbd> to open the integrated terminal in Visual Studio Code.
* Ensure the current directory contains the project’s `.csproj` file.
* Run the following commands to install [Syncfusion.Blazor.Popups](https://www.nuget.org/packages/Syncfusion.Blazor.Popups) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/), and then restore packages.

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.Popups -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}

{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). For the list of available packages and component details, see the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic.

{% endtabcontent %}

{% endtabcontents %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

Open **~/_Imports.razor** and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Popups` namespaces.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Popups

{% endhighlight %}
{% endtabs %}

Now, register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in the **~/Program.cs** file of your Blazor WebAssembly app.

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

The theme stylesheet and script are provided via NuGet using [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the stylesheet and script references in the `<head>` section of **~/index.html**.

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>
```
N> See the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic for different ways to reference themes—[Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator). For script reference approaches, see [Adding script references](https://blazor.syncfusion.com/documentation/common/adding-script-references).

## Add Blazor Dialog component

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Dialog component in **~/Pages/Index.razor**.

{% tabs %}
{% highlight cshtml %}

<SfDialog Width="250px">
    <DialogTemplates>
        <Content> This is a Dialog with content </Content>
    </DialogTemplates>
</SfDialog>

{% endhighlight %}
{% endtabs %}

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This renders the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Dialog component in the default web browser.

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDhTjVLBVzsCojDt?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
![Blazor Dialog](./images/blazor-dialog.png)

N> * In the dialog control, max-height is calculated based on the dialog target element height. If the **Target** property is not configured, the **document.body** is considered as a target. Therefore, to show a dialog in proper height, you need to add min-height to the target element.

N> * If the dialog is rendered based on the body, then the dialog will get the height based on its body element height. If the height of the dialog is larger than the body height, then the dialog's height will not be set. For this scenario, you can set the CSS style for the html and body to get the dialog height.

{% tabs %}
{% highlight cs %}

html, body {
   height: 100%;
}

{% endhighlight %}
{% endtabs %}

## Created and Destroyed Events

- The [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogEvents.html#Syncfusion_Blazor_Popups_DialogEvents_Created) event fires when the dialog is initialized and rendered in the DOM.

- The [Destroyed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogEvents.html#Syncfusion_Blazor_Popups_DialogEvents_Destroyed) event triggers when the dialog component is removed from the DOM. These lifecycle events allow executing custom code at specific points in the component's existence.

```cshtml

@using Syncfusion.Blazor.Popups

<SfDialog>
    <DialogEvents Created="@CreatedHandler" Destroyed="@DestroyedHandler"></DialogEvents>
</SfDialog>
@code {

    public void CreatedHandler(Object args)
    {
        // Here, you can customize your code.
    }

    private void DestroyedHandler()
    {
        // Here, you can customize your code.
    }
}

```

## Prerender the Dialog

The [AllowPrerender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialog.html#Syncfusion_Blazor_Popups_SfDialog_AllowPrerender) property controls how the dialog DOM elements are handled when the dialog is hidden. Understanding this property is crucial for optimizing performance in your application.

* By default, AllowPrerender is set to false. In this mode, dialog DOM elements are completely removed from the DOM when the dialog is hidden and recreated each time the dialog is shown. This approach saves memory but requires re-rendering on each display.
* When AllowPrerender is set to true, the dialog elements remain in the DOM even when hidden, which improves performance for frequently accessed dialogs but uses more memory.

```cshtml

@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Buttons

<div id="target">
    <div>
        <button class="e-btn" @onclick="@OnBtnClick">Open</button>
    </div>
    <SfDialog Target="#target" Width="300px" ShowCloseIcon="true" @bind-Visible="Visibility" AllowPrerender="true" Header="AllowPrerender Dialog" Content="This is a dialog with content">
    </SfDialog>
</div>
<style>
    #target {
        height: 500px;
    }
</style>
@code {
    private bool Visibility { get; set; } = false;
    private void OnBtnClick()
    {
        this.Visibility = true;
    }
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXVyNPspKoXXlIYf?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Set Header to Dialog

The [Header](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogTemplates.html#Syncfusion_Blazor_Popups_DialogTemplates_Header) property allows rendering a dialog with a custom text header.

```cshtml

@using Syncfusion.Blazor.Popups

<SfDialog Width="250px" Header="Dialog Header"></SfDialog>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZhyjEByHgdKnwXS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
![Blazor Dialog with Header](./images/blazor-dialog-header.png)

## Set Content to Dialog 

The [Content](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialog.html#Syncfusion_Blazor_Popups_SfDialog_Content) property allows rendering a dialog with custom text content.

```cshtml

@using Syncfusion.Blazor.Popups

<SfDialog Width="250px" Content="This is a dialog with Content property."></SfDialog>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXhIZPssAIpntkQY?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
![Blazor Dialog with Content](./images/blazor-dialog-content.png)

## See also

* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for client-side in .NET Core CLI](../getting-started/blazor-webassembly-app)

* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for server-side in Visual Studio](../getting-started/blazor-server-side-visual-studio)

* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for server-side in .NET Core CLI](../getting-started/blazor-web-app)

N> Explore our [Blazor Dialog example](https://blazor.syncfusion.com/demos/dialog/default-functionalities?theme=bootstrap5) that shows how to render and configure the Dialog.