---
layout: post
title: Getting Started with Blazor Sunburst Chart in WASM App | Syncfusion®
description: Learn how to configure and render the Syncfusion Blazor Sunburst Chart in a Blazor WebAssembly standalone application.
platform: Blazor
control: Sunburst Chart
documentation: ug
keywords: Blazor Sunburst Chart, Blazor WASM Sunburst Chart, SfSunburstChart, hierarchical data, Sunburst Chart getting started
---

<!-- markdownlint-disable MD040 -->

# Getting Started with Blazor Sunburst Chart in WASM App

This section briefly explains how to include the `Blazor Sunburst Chart` component in a Blazor WebAssembly App using [Visual Studio](https://visualstudio.microsoft.com/vs/), [Visual Studio Code](https://code.visualstudio.com/), and the [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/).

> **Ready to streamline your Blazor development?** <br/>Discover the full potential of Blazor components with AI Coding Assistants. Effortlessly integrate, configure, and enhance your projects with intelligent, context-aware code suggestions, streamlined setups, and real-time insights—all seamlessly integrated into your preferred AI-powered IDEs like VS Code, Cursor, Code Studio and more. [Explore AI Coding Assistants](https://blazor.syncfusion.com/documentation/ai-coding-assistant/overview)

## Using .NET CLI Templates

Quickly set up a Blazor application using the preconfigured [Syncfusion WebAssembly App Template](https://help.syncfusion.com/extension/syncfusion-blazor-webassemblyapp-template-via-nuget/installation).

First, install the template using the .NET CLI.

{% tabs %}
{% highlight razor tabtitle=".NET CLI" %}

dotnet new install Syncfusion.Blazor.WebAssemblyApp.Templates

{% endhighlight %}
{% endtabs %}

Next, create a new project with the following command.

{% tabs %}
{% highlight razor tabtitle="WebAssembly" %}

dotnet new syncfusionblazorwasmapp --name MyApp --pwa true

{% endhighlight %}

{% endtabs %}

After creating the project, navigate to the main project folder (for example, `MyApp`) and run the following command.

{% highlight razor tabtitle=".NET CLI" %}

cd MyApp
dotnet run

{% endhighlight %}

## Manually creating a new Blazor WebAssembly (Standalone) App

{% tabcontents %}

{% tabcontent Visual Studio %}

Create a **Blazor WebAssembly App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) or the [Syncfusion® Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Run the following command to create a new Blazor WebAssembly App.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet new blazorwasm -o BlazorApp
cd BlazorApp

{% endhighlight %}
{% endtabs %}

Alternatively, create a **Blazor WebAssembly App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vsc) or the [Syncfusion® Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project), or the [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension.

{% endtabcontent %}

{% endtabcontents %}

### Install the required Blazor package

Install the [Syncfusion.Blazor.Charts](https://www.nuget.org/packages/Syncfusion.Blazor.Charts/) NuGet package. This package delivers every Syncfusion Blazor chart component, including the `Blazor Sunburst Chart`. All Syncfusion Blazor packages are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for details.

{% tabcontents %}

{% tabcontent Visual Studio %}

1. Go to *Tools → NuGet Package Manager → Manage NuGet Packages for Solution*.
2. Search the required NuGet package (`Syncfusion.Blazor.Charts`) and install it.

Alternatively, you can install the package using the Package Manager Console with the following command.

{% tabs %}
{% highlight razor tabtitle="Package Manager Console" %}

Install-Package Syncfusion.Blazor.Charts -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Open the terminal and run the following command.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet add package Syncfusion.Blazor.Charts -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

### Add import namespaces

After the package is installed, open the **~/_Imports.razor** file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Charts` namespaces.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Charts

{% endhighlight %}
{% endtabs %}

### Register the Blazor service

Open the **Program.cs** file in Blazor WebAssembly App and register the Blazor service and include the required namespace reference `using Syncfusion.Blazor;` at the top.

{% tabs %}
{% highlight C# tabtitle="Program.cs" %}

builder.Services.AddSyncfusionBlazor();

{% endhighlight %}
{% endtabs %}

### Add script resource

Include the required [script references](https://blazor.syncfusion.com/documentation/common/adding-script-references) at the end of the `<body>` section in the **~wwwroot/index.html** file to enable Sunburst Chart functionality.

{% tabs %}
{% highlight html tabtitle="index.html" %}

<script src="_content/Syncfusion.Blazor.Charts/scripts/sf-sunburst-chart.js" type="text/javascript"></script>


{% endhighlight %}
{% endtabs %}

### Add Blazor Sunburst Chart component

Open a Razor file located in the **~/Pages/*.razor** (for example, **Home.razor**) and add the `Blazor Sunburst Chart` component inside the razor file.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

<SfSunburstChart TItem="NodeDetails"
                 DataSource="@DataSource"
                 IdMemberPath="@nameof(NodeDetails.Id)"
                 ParentIdMemberPath="@nameof(NodeDetails.ParentId)"
                 ValueMemberPath="@nameof(NodeDetails.Value)"
                 LabelMemberPath="@nameof(NodeDetails.Name)"
                 Width="100%"
                 Height="450px">
</SfSunburstChart>

@code {
    public class NodeDetails
    {
        public string Id { get; set; } = string.Empty;
        public string? ParentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Value { get; set; }
    }

    public List<NodeDetails> DataSource = new()
    {
        new NodeDetails { Id = "USA", ParentId = null, Name = "USA" },
        new NodeDetails { Id = "USA-Electronics", ParentId = "USA", Name = "Electronics", Value = 35 },
        new NodeDetails { Id = "India", ParentId = null, Name = "India" },
        new NodeDetails { Id = "India-Electronics", ParentId = "India", Name = "Electronics", Value = 30 },
        new NodeDetails { Id = "Germany", ParentId = null, Name = "Germany" },
        new NodeDetails { Id = "Germany-Electronics", ParentId = "Germany", Name = "Electronics", Value = 20 }
    };
}

{% endhighlight %}
{% endtabs %}

### Run the application

{% tabcontents %}

{% tabcontent Visual Studio %}

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. The `Blazor Sunburst Chart` component will render in your default web browser.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Open the terminal and run the following command.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet run

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

<!-- TODO: Add Blazor Playground sample after release -->
![Blazor Sunburst Chart](images/getting-started/blazor-sunburst-chart.webp)

## Populate Sunburst Chart with data

The `Blazor Sunburst Chart` renders hierarchical data as concentric rings. As shown in the previous example, the hierarchy is described through a single flat `IEnumerable<TItem>` collection, and the chart derives the levels from how each row's `ParentId` maps to another row's `Id`. Each root row (`ParentId` is `null`) becomes the innermost ring, and each level of children becomes the next outer ring.

Key mappings to configure:

* `DataSource` — the `IEnumerable<NodeDetails>` collection that supplies the nodes.
* `IdMemberPath` — the unique identifier of each row (`NodeDetails.Id`).
* `ParentIdMemberPath` — the parent reference for each row (`NodeDetails.ParentId`); set to `null` for top-level rows.
* `LabelMemberPath` — the field that provides the segment text (`NodeDetails.Name`).
* `ValueMemberPath` — the numeric field that determines the segment sweep (`NodeDetails.Value`).

Leaf rows carry the numeric `Value` that drives rendering. Ancestor rows without a `Value` display the aggregated value of their descendants.

## See also

1. [Getting Started with Blazor for Client-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app)
2. [Getting Started with Blazor for Server-Side in Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)