---
layout: post
title: Getting started with Syncfusion Toast Component in Blazor Web App
description: Check out the documentation for getting started with Syncfusion Blazor Toast Components in Blazor Web App.
platform: Blazor
control: Toast
documentation: ug
---

# Getting Started with Blazor Toast in Blazor Web App

This section explains how to add the [Blazor Toast](https://www.syncfusion.com/blazor-components/blazor-toast) component to a Blazor Web App using [Visual Studio](https://visualstudio.microsoft.com/vs/) or Visual Studio Code.

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

- [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App in Visual Studio

Create a **Blazor Web App** using Visual Studio 2022 via [Microsoft templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vs) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

Configure the appropriate [interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) and [interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vs) when creating the Blazor Web App.

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Notifications and Themes NuGet in the App

To add the **Blazor Toast** component, open the NuGet Package Manager in Visual Studio (Tools → NuGet Package Manager → Manage NuGet Packages for Solution), then install [Syncfusion.Blazor.Notifications](https://www.nuget.org/packages/Syncfusion.Blazor.Notifications) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/).

For `WebAssembly` or `Auto` render modes in a Blazor Web App, install the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet packages in the Client project. For `Server` render mode, install them in the Server project.

Alternatively, execute the following Package Manager commands:

```powershell
Install-Package Syncfusion.Blazor.Notifications -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}
```

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the full list of packages and components.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

- [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App in Visual Studio Code

Create a **Blazor Web App** using Visual Studio Code via [Microsoft templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project).

Configure the appropriate [interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) and [interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vsc) when creating the Blazor Web App.

For example, in a Blazor Web App with the `Auto` interactive render mode, use the following commands:

```bash
dotnet new blazor -o BlazorWebApp -int Auto
cd BlazorWebApp
cd BlazorWebApp.Client
```

N> For more information on creating a **Blazor Web App** with various interactive modes and locations, refer to this [link](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=visual-studio-code#render-interactive-modes).

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Notifications and Themes NuGet in the App

For `WebAssembly` or `Auto` render modes in a Blazor Web App, install the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet packages in the Client project.

- Open the integrated terminal in Visual Studio Code.
- Navigate to the project directory that contains the `.csproj` file.
- Run the following commands to install [Syncfusion.Blazor.Notifications](https://www.nuget.org/packages/Syncfusion.Blazor.Notifications) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) and restore dependencies.

```bash
dotnet add package Syncfusion.Blazor.Notifications -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore
```

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the full list of packages and components.

{% endtabcontent %}

{% endtabcontents %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

| Interactive Render Mode | Description |
| -- | -- |
| WebAssembly or Auto | Open **~/_Imports.razor** file from the Client project. |
| Server | Open **~/_Imports.razor** file located in the `Components` folder. |

Import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Notifications` namespaces:

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Notifications

{% endhighlight %}
{% endtabs %}

Register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in the **~/Program.cs** file of the Blazor Web App.

If the **Interactive Render Mode** is set to `WebAssembly` or `Auto`, register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in both Program.cs files (Server and Client).

{% tabs %}
{% highlight c# tabtitle="Server(~/_Program.cs)" hl_lines="3 11" %}

using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
```

{% endhighlight %}
{% highlight c# tabtitle="Client(~/_Program.cs)" hl_lines="2 5" %}

using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSyncfusionBlazor();

await builder.Build().RunAsync();

{% endhighlight %}
{% endtabs %}

If the **Interactive Render Mode** is set to `Server`, the project contains a single **~/Program.cs** file. In this case, register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service only in that file.

{% tabs %}
{% highlight c# tabtitle="~/_Program.cs" hl_lines="2 9" %}

using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSyncfusionBlazor();

var app = builder.Build();

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

The theme stylesheet and script are provided via NuGet as [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the stylesheet reference in the `<head>` section and the script reference at the end of the `<body>` in the **~/Components/App.razor** file:

```html
<head>
    <!-- ... -->
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>

<body>
    <!-- ... -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```

N> See the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic for additional options to reference themes ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)). Also, refer to [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) for approaches to add script references in a Blazor application.

## Add Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Toast component

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Toast component to a page in the **~/Pages** folder. If the interactivity location is set to `Per page/component`, define a render mode at the top of the `~/Pages/*.razor` component as follows:

| Interactivity location | RenderMode | Code |
| --- | --- | --- |
| Per page/component | Auto | @rendermode InteractiveAuto |
|  | WebAssembly | @rendermode InteractiveWebAssembly |
|  | Server | @rendermode InteractiveServer |
|  | None | --- |

N> If the **Interactivity Location** is set to `Global` and the **Render Mode** is set to `Auto`, `WebAssembly`, or `Server`, the render mode is configured in the `App.razor` file by default.

Render mode directive:

{% tabs %}
{% highlight razor %}

@* Desired render mode defined here *@
@rendermode InteractiveAuto

{% endhighlight %}
{% endtabs %}

Toast component example:

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

Use <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Toast component renders in the default web browser.

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDrzNiKXJRibajXZ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Toast Component](./images/blazor-toast.png)" %}

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/Toast/BlazorWebApp).

## See Also

- [Show or hide toast from any page using service in Blazor](https://support.syncfusion.com/kb/article/11734/show-or-hide-toast-from-any-page-using-service-in-blazor)
- [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for client-side in .NET Core CLI](../getting-started/blazor-webassembly-dotnet-cli)
- [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for server-side in Visual Studio](../getting-started/blazor-server-side-visual-studio)
- [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for server-side in .NET Core CLI](../getting-started/blazor-server-side-dotnet-cli)

N> An interactive [Blazor Toast example](https://blazor.syncfusion.com/demos/toast/default-functionalities?theme=bootstrap5) demonstrates how to render and configure the Toast component.