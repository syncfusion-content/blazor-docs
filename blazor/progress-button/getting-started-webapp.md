---
layout: post
title: Getting started with Syncfusion ProgressButton in Blazor Web App
description: Check out the documentation for getting started with Syncfusion Blazor ProgressButton Components in Blazor Web App.
platform: Blazor
control: ProgressButton
documentation: ug
---

# Getting Started with Blazor ProgressButton in Blazor Web App

This section explains how to include the [Blazor ProgressButton](https://www.syncfusion.com/blazor-components/blazor-progress-button) component in a Blazor Web App using [Visual Studio](https://visualstudio.microsoft.com/vs/) and Visual Studio Code.

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

- [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App in Visual Studio

Create a Blazor Web App using Visual Studio 2022 via [Microsoft templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

Configure the appropriate [interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) and [interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=windows) when creating the app.

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor SplitButtons and Themes NuGet in the app

To add the ProgressButton component, open the NuGet Package Manager in Visual Studio (Tools → NuGet Package Manager → Manage NuGet Packages for Solution), then search for and install [Syncfusion.Blazor.SplitButtons](https://www.nuget.org/packages/Syncfusion.Blazor.SplitButtons) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/).

If using `WebAssembly` or `Auto` render modes in a Blazor Web App, install the Syncfusion Blazor component NuGet packages in the client project.

Alternatively, use the following Package Manager commands:

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.SplitButtons -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the full package list and component details.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

- [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App in Visual Studio Code

Create a Blazor Web App using Visual Studio Code via [Microsoft templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project).

Configure the appropriate [interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) and [interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vsc) when creating the app.

For example, in a Blazor Web App with the `Auto` interactive render mode, run the following commands:

{% tabs %}
{% highlight c# tabtitle="Blazor Web App" %}

dotnet new blazor -o BlazorWebApp -int Auto
cd BlazorWebApp
cd BlazorWebApp.Client

{% endhighlight %}
{% endtabs %}

N> For details on creating a Blazor Web App with different interactive modes and locations, see the [render interactive modes guide](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=visual-studio-code#render-interactive-modes)..

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor SplitButtons and Themes NuGet in the app

If using `WebAssembly` or `Auto` render modes in a Blazor Web App, install the Syncfusion Blazor component NuGet packages in the client project.

- Press Ctrl+` to open the integrated terminal in Visual Studio Code.
- Ensure you are in the project directory that contains the `.csproj` file.
- Run the following commands to install [Syncfusion.Blazor.SplitButtons](https://www.nuget.org/packages/Syncfusion.Blazor.SplitButtons) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/):

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.SplitButtons -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}

{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the full package list and component details.

{% endtabcontent %}

{% endtabcontents %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

| Interactive render mode | Description |
| -- | -- |
| WebAssembly or Auto | Open **~/_Imports.razor** in the client project. |
| Server | Open **~/_Imports.razor** in the `Components` folder. |

Import the `Syncfusion.Blazor` and `Syncfusion.Blazor.SplitButtons` namespaces.

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.SplitButtons

{% endhighlight %}
{% endtabs %}

Now register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in the **~/Program.cs** file(s) of your Blazor Web App.

If the interactive render mode is `WebAssembly` or `Auto`, register the service in both **~/Program.cs** files (server and client) of the Blazor Web App.

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

If the interactive render mode is `Server`, the project contains a single **~/Program.cs** file. Register the Syncfusion Blazor service only in that file.

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

Theme stylesheets and scripts are served via [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets) from the installed NuGet packages. Add the stylesheet reference in the `<head>` and the script at the end of `<body>` in **~/Components/App.razor**:

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

N> For theme reference options, see [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) (Static Web Assets, [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)). For script reference approaches, see [Adding script references](https://blazor.syncfusion.com/documentation/common/adding-script-references).

## Add Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor ProgressButton component

Add the Syncfusion Blazor ProgressButton component to a page in the **~Pages/.razor** file. If the interactivity location is set to `Per page/component`, define a render mode at the top of the page as shown:

| Interactivity location | RenderMode | Code |
| --- | --- | --- |
| Per page/component | Auto | @rendermode InteractiveAuto |
|  | WebAssembly | @rendermode InteractiveWebAssembly |
|  | Server | @rendermode InteractiveServer |
|  | None | --- |

N> If the interactivity location is `Global` and the render mode is `Auto`, `WebAssembly`, or `Server`, the render mode is configured in `App.razor` by default.

{% tabs %}
{% highlight razor %}

@* desired render mode define here *@
@rendermode InteractiveAuto

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight razor %}

<SfProgressButton Content="Spin Left"></SfProgressButton>

{% endhighlight %}
{% endtabs %}

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This will render the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor ProgressButton component in your default web browser.

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDLzDiqDgZzSLSvX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor ProgressButton Component](./images/blazor-progressbutton-component.png)" %}

N> [View the sample on GitHub.](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/ProgressButton/BlazorWebApp)

## See also

- [Getting started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for client-side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-dotnet-cli)
- [Getting started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for server-side in Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)
- [Getting started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for server-side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-dotnet-cli)

N> Explore the [Blazor ProgressButton example](https://blazor.syncfusion.com/demos/buttons/progress-button?theme=bootstrap5) to learn how to render and configure the ProgressButton.