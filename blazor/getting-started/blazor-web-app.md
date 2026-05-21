---
layout: post
title: Getting Started with Blazor DataGrid Component in Blazor Web App | Syncfusion
description: Learn how to get started with the Syncfusion Blazor DataGrid component in a Blazor Web App using Visual Studio, Visual Studio Code, and the .NET CLI.
platform: Blazor
component: Common
documentation: ug
---

# Getting Started with Blazor Web App

This article provides step-by-step instructions for building a Blazor Web App with the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) component using [Visual Studio](https://visualstudio.microsoft.com/vs/), [Visual Studio Code](https://code.visualstudio.com/), and the [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/).

To get started quickly with a Blazor Web App, watch the following video.

{% youtube
"youtube:https://www.youtube.com/watch?v=hjPGxApA5W8" %}

## Using Playground

[Blazor Playground](https://blazor.syncfusion.com/documentation/common/playground/getting-started) allows you to interact with our Blazor components directly in your web browser without needing to install any NuGet packages. By default, the [Syncfusion.Blazor](https://www.nuget.org/packages/Syncfusion.Blazor) package is included in this.

{% playground "https://blazorplayground.syncfusion.com/" %}

## Using Blazor Templates

Create a Blazor Web App using Blazor Templates in both [Visual Studio](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio) and [Visual Studio Code](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project).

## Manually creating a project

This section provides a brief guide on how to manually create a Blazor Web App.

### Create a new Blazor Web App

{% tabcontents %}

{% tabcontent Visual Studio %}

Create a **Blazor Web App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) or the [Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Run the following command to create a new Blazor Web App.

```bash
dotnet new blazor -o BlazorWebApp -int Auto
```

Alternatively, create a **Blazor Web App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vsc) or the [Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project).

{% endtabcontent %}

{% tabcontent .NET CLI %}

Run the following command to create a new Blazor Web App.

```bash
dotnet new blazor -o BlazorWebApp -int Auto
```

{% endtabcontent %}

{% endtabcontents %}

N> Configure the appropriate [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-10.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) while creating a Blazor Web App. For detailed information, refer to the [interactive render mode documentation](https://blazor.syncfusion.com/documentation/common/interactive-render-mode).

### Install the required Blazor packages

Install the [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet packages using one of the following methods. If using the `WebAssembly` or `Auto` render modes in the Blazor Web App, install these packages in the `.Client` project.

{% tabcontents %}

{% tabcontent Visual Studio %}

1. Go to *Tools → NuGet Package Manager → Manage NuGet Packages for Solution*.
2. Search the required NuGet packages (`Syncfusion.Blazor.Grid` and `Syncfusion.Blazor.Themes`) and install them.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Open the terminal and run the following commands.

```bash
dotnet add package Syncfusion.Blazor.Grid -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
```

{% endtabcontent %}

{% tabcontent .NET CLI %}

Open the command prompt and run the following commands.

```bash
dotnet add package Syncfusion.Blazor.Grid -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
```

{% endtabcontent %}

{% endtabcontents %}

N> All Syncfusion Blazor packages are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for details.

### Add import namespaces

After the packages are installed, open the **~/_Imports.razor** file in the `.Client` project and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Grids` namespaces.

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids

{% endhighlight %}
{% endtabs %}

### Register the Blazor service

Open the **Program.cs** file in Blazor Web App and register the Blazor service.

{% tabs %}
{% highlight C# tabtitle="Program.cs" %}

...
using Syncfusion.Blazor;
...
builder.Services.AddSyncfusionBlazor();
....

{% endhighlight %}
{% endtabs %}

N> If the **Interactive Render Mode** is set to `WebAssembly` or `Auto`, register the Blazor service in **Program.cs** files of both the server and client projects in your Blazor Web App.

### Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the stylesheet and script references in the **App.razor** file.

{% tabs %}
{% highlight html tabtitle="App.razor" %}

...
<link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
...
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

{% endhighlight %}
{% endtabs %}

N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in your Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in your Blazor application.

### Add Blazor DataGrid component

* Open a Razor file located in the **~/Pages/*.razor** (for example, **Home.razor**) and add the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) component inside the razor file.
* If the interactivity location is set to `Per page/component` in the Web App, define a render mode at the top of the razor file. (For example, `InteractiveServer`, `InteractiveWebAssembly` or `InteractiveAuto`).

N> If the **Interactivity** is set to `Global` with `Auto` or `WebAssembly`, the render mode is automatically configured in the `App.razor` file by default.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@rendermode InteractiveAuto

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" />

@code{
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 10).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

### Run the application

{% tabcontents %}

{% tabcontent Visual Studio %}

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. The Blazor DataGrid component will render in your default web browser.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

* Open the terminal and navigate to the `.Client` project folder, and run the following command.

```bash
dotnet run
```

{% endtabcontent %}

{% tabcontent .NET CLI %}

* Open the command prompt and navigate to the `.Client` project folder, and run the following command.

```bash
dotnet run
```

{% endtabcontent %}

{% endtabcontents %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXVesWjwqtDJZluz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor DataGrid Component](images/blazor-datagrid-component.webp)" %}