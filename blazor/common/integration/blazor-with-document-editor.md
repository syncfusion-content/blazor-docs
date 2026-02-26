---
layout: post
title: Syncfusion® Blazor Document Editor and DataGrid Integration
description: Step-by-step guide to integrating Syncfusion Blazor Document Editor and DataGrid in Blazor applications.
platform: Blazor
control: common
documentation: ug
---

# Integrating Syncfusion® DataGrid with Document Editor in Blazor Apps

This guide shows how to integrate the **Syncfusion® Blazor Document Editor** (WordProcessor) together with the **Syncfusion® Blazor DataGrid** in a Blazor Web App using `Server` render mode.

This guide uses [Visual Studio Code](https://code.visualstudio.com/). If you haven’t created your Blazor app yet, follow the [Blazor getting started guide](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=visual-studio-code) instructions for Visual Studio Code, then return to this article.

## Prerequisites

* [Syncfusion Blazor system requirements](https://blazor.syncfusion.com/documentation/system-requirements): Make sure your development environment meets the required system specifications for using Syncfusion Blazor components.

## Create Project

Create a Blazor Web App using Server render mode. Open the terminal and run the command:

{% tabs %}
{% highlight c# tabtitle="Blazor Web App" %}

dotnet new blazor -o BlazorWebAppServer -int Server
cd BlazorWebAppServer

{% endhighlight %}
{% endtabs %}

Alternatively, manually create via the [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vsc) or the [Syncfusion® Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project).

## Install NuGet Packages

Open the integrated terminal in the project folder (where the `.csproj` is) and run:

{% tabs %}
{% highlight bash tabtitle="Terminal" %}

dotnet add package Syncfusion.Blazor.WordProcessor -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Grid -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}
{% endtabs %}

> Do not install `Syncfusion.Blazor` together with `Syncfusion.Blazor.WordProcessor`. They conflict and produce ambiguity errors.

> Syncfusion Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the available NuGet package list with component details. Verify the latest versions before installation.

## Add Required Namespaces

Add Syncfusion namespaces to your project-level `_Imports.razor`:

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.DocumentEditor
@using Syncfusion.Blazor.Grids

{% endhighlight %}
{% endtabs %}

## Register Syncfusion Blazor Service

Register the Syncfusion Blazor service in your app’s **~/Program.cs**.

{% tabs %}
{% highlight c# tabtitle="Server(~/_Program.cs)" hl_lines="1 7" %}

using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
....

{% endhighlight %}
{% endtabs %}

## Add Stylesheet and Script Resources

Add the theme CSS and Syncfusion scripts in `~/App.razor`:

```html
<head>
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>

<body>
   	<!-- Syncfusion Blazor Document Editor component's script reference-->
	<script src="_content/Syncfusion.Blazor.WordProcessor/scripts/syncfusion-blazor-documenteditor.min.js" type="text/javascript"></script>
	<!-- Syncfusion Blazor DataGrid component's script reference -->
	<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```

## Configure Render Mode(Per-Page / Component Interactivity)

If your app’s interactivity location is set to `Per page/component`, add a render mode directive at the top of `~Pages/*.razor` where you need interactivity. 

| Interactivity location | RenderMode | Code |
| --- | --- | --- |
| Per page/component | Auto | @rendermode InteractiveAuto |
|  | WebAssembly | @rendermode InteractiveWebAssembly |
|  | Server | @rendermode InteractiveServer |
|  | None | --- |

**Example for server render mode use:**

{% tabs %}
{% highlight razor %}

@* Define the desired render mode here *@
@rendermode InteractiveServer

{% endhighlight %}
{% endtabs %}

N> If an **Interactivity Location** is set to `Global` and the **Render Mode** is set to `Auto` or `WebAssembly`, the render mode is configured in the `App.razor` file by default. No per‑page directive is necessary.

## Add Syncfusion Blazor Document Editor component and DataGrid component

Add the Syncfusion Document Editor and DataGrid components to a `.razor` file within your app: 

{% tabs %}
{% highlight razor %}

@page "/"
@rendermode InteractiveServer

<h1>DocumentEditor</h1>

<SfDocumentEditorContainer EnableToolbar=true></SfDocumentEditorContainer>

<h1>DataGrid</h1>

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

Note: By default, the `SfDocumentEditorContainer` component initializes an `SfDocumentEditor` instance internally. If you like to use the events of `SfDocumentEditor` component, then you can set `UseDefaultEditor` property as **false** and define your own `SfDocumentEditor` instance with event hooks in the application (Razor file).

## Run the Application

Run from the project root:

{% tabs %}
{% highlight bash tabtitle="Terminal" %}

dotnet run

{% endhighlight %}
{% endtabs %}

The app launches and renders the Syncfusion® Blazor Document Editor and DataGrid in your default browser.

![Blazor DataGrid with Document Editor](../images/DocumentEditor-With-DataGrid.png)
