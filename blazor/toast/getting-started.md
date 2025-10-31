---
layout: post
title: Getting Started with Blazor Toast Component | Syncfusion
description: Checkout and learn about getting started with Blazor Toast component in Blazor WebAssembly Application.
platform: Blazor
control: Toast
documentation: ug
---

# Getting Started with Blazor Toast Component

This section explains how to add the [Blazor Toast](https://www.syncfusion.com/blazor-components/blazor-toast) component to a Blazor WebAssembly app using Visual Studio or Visual Studio Code.

A quick-start video and a sample repository are available:
- Video: 
{% youtube
"youtube:https://www.youtube.com/watch?v=tMa7JvcfNcY"%}
- Sample on [GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/Toast)

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

- [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio

Create a Blazor WebAssembly app using Visual Studio via [Microsoft templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vs) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Notifications and Themes NuGet in the App

Install [Syncfusion.Blazor.Notifications](https://www.nuget.org/packages/Syncfusion.Blazor.Notifications) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) using the NuGet Package Manager (Tools → NuGet Package Manager → Manage NuGet Packages for Solution), or run the following commands:

```powershell
Install-Package Syncfusion.Blazor.Notifications -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}
```

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the list of available packages and component details.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

- [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio Code

Create a Blazor WebAssembly app using Visual Studio Code via [Microsoft templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project).

Alternatively, create a WebAssembly application using the following commands in the integrated terminal:

```bash
dotnet new blazorwasm -o BlazorApp
cd BlazorApp
```

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Notifications and Themes NuGet in the App

Use the integrated terminal in Visual Studio Code from the project root (where the `.csproj` file is located), then run:

```bash
dotnet add package Syncfusion.Blazor.Notifications -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore
```

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the list of available packages and component details.

{% endtabcontent %}

{% endtabcontents %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

Open `~/_Imports.razor` and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Notifications` namespaces:

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Notifications

{% endhighlight %}
{% endtabs %}

Register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in `~/Program.cs` of the Blazor WebAssembly app:

{% tabs %}
{% highlight c# tabtitle="~/Program.cs" hl_lines="3 11" %}

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

The theme stylesheet and script are provided via NuGet as [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the stylesheet and script references in the `<head>` section of `~/wwwroot/index.html`:

```html
<head>
    <!-- ... -->
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>
```

N> See the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover options for referencing themes ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)). Also, see [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) for different approaches to add script references in a Blazor application.

## Add Blazor Toast component

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Toast component to `~/Pages/Index.razor`:

{% tabs %}
{% highlight razor %}

<div class="col-lg-12 control-section toast-default-section">
    <SfToast ID="toast_default" @ref="ToastObj" Title="Adaptive Tiles Meeting" Content="@ToastContent" Timeout="5000" Icon="e-meeting">
        <ToastPosition X="@ToastPosition"></ToastPosition>
    </SfToast>
    <div class="col-lg-12 col-sm-12 col-md-12 center">
        <div id="toastBtnDefault" style="margin: auto; text-align: center">
            <button class="e-btn" @onclick="@ShowOnClick">Show Toasts</button>
            <button class="e-btn" @onclick="@HideOnClick">Hide All</button>
        </div>
    </div>
</div>

<style>
    #toast_default .e-meeting::before {
        content: "\e705";
        font-size: 17px;
    }

    .bootstrap4 #toast_default .e-meeting::before {
        content: "\e763";
        font-size: 20px;
    }
</style>

@code {
    private SfToast ToastObj;
    private string ToastPosition = "Right";
    private string ToastContent = "Conference Room 01 / Building 135 10:00 AM-10:30 AM";

    private async Task ShowOnClick()
    {
        await ToastObj.ShowAsync();
    }

    private async Task HideOnClick()
    {
        await ToastObj.HideAsync("All");
    }
}

{% endhighlight %}
{% endtabs %}

Launch the application with <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS). The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Toast component renders in the default web browser.

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDrzNiKXJRibajXZ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Toast Component](./images/blazor-toast.png)" %}

## See Also

- [Show or hide toast from any page using service in Blazor](https://support.syncfusion.com/kb/article/11734/show-or-hide-toast-from-any-page-using-service-in-blazor)
- [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor WebAssembly App in Visual Studio or .NET CLI](../getting-started/blazor-webassembly-dotnet-cli)
- [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Web App in Visual Studio or .NET CLI](../getting-started/blazor-server-side-visual-studio)

N> An interactive [Blazor Toast example](https://blazor.syncfusion.com/demos/toast/default-functionalities?theme=bootstrap5) demonstrates how to render and configure the Toast component.