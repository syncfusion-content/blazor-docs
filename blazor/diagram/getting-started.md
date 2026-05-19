---
layout: post
title: Getting Started with Diagram Component in Blazor Server App|Syncfusion
description: Checkout and learn about the documentation for getting started with Blazor Diagram Component in Blazor Server App.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Getting Started with Diagram Component in the Blazor Server App.

This section explains the step-by-step process of integrating the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Diagram](https://www.syncfusion.com/blazor-components/blazor-diagram) component into your Blazor Server app using Visual Studio, Visual Studio Code and .NET CLI. We'll break it down into simple steps to make it easy to follow. Additionally, you can find a fully functional example project on our [GitHub repository](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/DiagramComponent).

> **Ready to streamline your Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor development?** <br/>Discover the full potential of Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components with Syncfusion<sup style="font-size:70%">&reg;</sup> AI Coding Assistants. Effortlessly integrate, configure, and enhance your projects with intelligent, context-aware code suggestions, streamlined setups, and real-time insights—all seamlessly integrated into your preferred AI-powered IDEs like VS Code, Cursor, Syncfusion<sup style="font-size:70%">&reg;</sup> CodeStudio and more. [Explore Syncfusion<sup style="font-size:70%">&reg;</sup> AI Coding Assistants](https://blazor.syncfusion.com/documentation/ai-coding-assistant/overview)

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio

Create a **Blazor Server App** using the **Blazor Web App** template in Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio). For detailed instructions, refer to the [Blazor Server App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio) documentation.

N> Configure the [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-10.0#render-modes) is **Server** and Choose the appropriate [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) while creating a project.
<br/> If you use the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio), a sample application can be generated automatically.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio Code

Create a **Blazor Server App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project). For detailed instructions, refer to the [Blazor Server App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio?tabcontent=visual-studio-code) documentation.

N> Configure the [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-10.0#render-modes) is **Server** and Choose the appropriate [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) while creating a project.
<br/> If you use the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio), a sample application can be generated automatically.

{% endtabcontent %}

{% tabcontent .NET CLI %}

## Prerequisites

Install the latest version of [.NET SDK](https://dotnet.microsoft.com/en-us/download). If the .NET SDK is already installed, determine the installed version by running the following command in a command prompt (Windows), terminal (macOS), or command shell (Linux).

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet --version

{% endhighlight %}
{% endtabs %}

## Create a Blazor Server App using .NET CLI

Run the following command to create a new Blazor Server App in a command prompt (Windows) or terminal (macOS) or command shell (Linux). For detailed instructions, refer to the [Blazor Server App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio?tabcontent=.net-cli) documentation.

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet new blazor -o BlazorApp -int Server
cd BlazorApp

{% endhighlight %}
{% endtabs %}

This command creates a new Blazor application and places it in a new directory called `BlazorApp` inside your current location. 
N> See the [Create a Blazor App](https://dotnet.microsoft.com/en-us/learn/aspnet/blazor-tutorial/create), [dotnet new CLI command](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?pivots=cli&view=aspnetcore-10.0) and [interactive render mode documentation](https://blazor.syncfusion.com/documentation/common/interactive-render-mode) topics for more details.

{% endtabcontent %}

{% endtabcontents %}

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor packages

{% tabcontents %}

{% tabcontent Visual Studio %}

Install [Syncfusion.Blazor.Diagram](https://www.nuget.org/packages/Syncfusion.Blazor.Diagram) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet packages in your project using the NuGet Package Manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution → Select the package -> Install*).

Alternatively, run the following commands in the Package Manager Console(*Tools → NuGet Package Manager → Package Manager Console*) to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Diagram -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Install [Syncfusion.Blazor.Diagram](https://www.nuget.org/packages/Syncfusion.Blazor.Diagram) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet packages in your project using the C# package management(*Right click the ".csproj" file, -> C# package management -> Add nuget package -> Select nuget package and version*)

{% endtabcontent %}

{% tabcontent .NET CLI %}

Install [Syncfusion.Blazor.Diagram](https://www.nuget.org/packages/Syncfusion.Blazor.Diagram) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet packages in your project using the .NET CLI command.

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.Diagram --version {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes --version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}
{% endtabcontents %}

N> All Syncfusion Blazor packages are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for details.

## Add import namespaces

After the packages are installed, open the **~/_Imports.razor** file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Diagram` namespaces.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor;
@using Syncfusion.Blazor.Diagram;

{% endhighlight %}
{% endtabs %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service

Register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in the **Program.cs** file.

{% tabs %}
{% highlight C# tabtitle="Program.cs" %}

....
using Syncfusion.Blazor;
....
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSyncfusionBlazor();
....

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the stylesheet and script references in the **~/Components/App.razor** file.

```html
<head>
    ...
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
</head>
<body>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```

N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in Blazor application.

## Configure Render Mode

If your create application uses `Per page/component` interactivity, add this at the top of **Pages/Home.razor**:

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@* desired render mode define here *@
@rendermode InteractiveServer

{% endhighlight %}
{% endtabs %}

N> If the render mode is set to **None**, the diagram will not render.
<br/> If the `Interactivity Location` is set to **Global**, this step is not required.

## Add Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Diagram component

Add the DiagramComponent to create an empty diagram.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

<SfDiagramComponent Width="100%" Height="600px"/>

{% endhighlight %}
{% endtabs %}

## Create your first Diagram with nodes and connectors

This section explains how to create a simple flowchart by adding nodes, customizing their appearance, and connecting them using connectors.

The following example creates a flowchart with four nodes: **Start**, **Process**, **Decision**, and **End**. It also applies common node and connector settings using the `NodeCreating` and `ConnectorCreating` properties.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

<SfDiagramComponent Width="100%" Height="600px" Nodes="@nodes" Connectors="@connectors" NodeCreating="@NodeCreating" ConnectorCreating="@ConnectorCreating" />

@code {
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>()
        {
            new Node()
            {
               ID = "node1", OffsetX = 300, OffsetY = 100,
               Shape = new FlowShape() { Type = NodeShapes.Flow, Shape = NodeFlowShapes.Terminator },
               Annotations = new DiagramObjectCollection<ShapeAnnotation>()
               {
                  new ShapeAnnotation(){ Content = "Start" }
               }
            },
            new Node()
            {
               ID = "node2", OffsetX = 300, OffsetY = 200,
               Shape = new FlowShape() { Type = NodeShapes.Flow, Shape = NodeFlowShapes.Process },
               Annotations = new DiagramObjectCollection<ShapeAnnotation>()
               {
                  new ShapeAnnotation(){ Content = "Process" }
               }
            },
            new Node()
            { 
               ID = "node3", OffsetX = 300, OffsetY = 300,
               Shape = new FlowShape() { Type = NodeShapes.Flow, Shape = NodeFlowShapes.Decision },
               Annotations = new DiagramObjectCollection<ShapeAnnotation>()
               {
                  new ShapeAnnotation(){ Content = "Decision?" }
               }
            },
            new Node()
            {
               ID = "node4", OffsetX = 300, OffsetY = 400,
               Shape = new FlowShape() { Type = NodeShapes.Flow, Shape = NodeFlowShapes.Terminator },
               Annotations = new DiagramObjectCollection<ShapeAnnotation>()
               {
                  new ShapeAnnotation(){ Content = "End" }
               }
            }
        };
        connectors = new DiagramObjectCollection<Connector>()
        {
            new Connector()
            {
                ID = "connector1",
                SourceID = "node1",
                TargetID = "node2",
            },
            new Connector()
            {
                ID = "connector2",
                SourceID = "node2",
                TargetID = "node3",
            },            
            new Connector()
            {
                ID = "connector2",
                SourceID = "node3",
                TargetID = "node4",
            },
        };
    }

    private void NodeCreating(IDiagramObject obj)
    {
        Node node = obj as Node;
        node.Style = new ShapeStyle() { Fill = "#E8F4FF", StrokeColor = "#357BD2" };
        node.Width = 140;
        node.Height = 50;
    }

    private void ConnectorCreating(IDiagramObject obj)
    {
        (obj as Connector).Type = ConnectorSegmentType.Orthogonal;
    }
}

{% endhighlight %}
{% endtabs %}

In this example:

* [`OffsetX`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Node.html#Syncfusion_Blazor_Diagram_Node_OffsetX) and [`OffsetY`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Node.html#Syncfusion_Blazor_Diagram_Node_OffsetY) define the position of each node.
* [`Shape`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Node.html#Syncfusion_Blazor_Diagram_Node_Shape) defines the node shape configuration, and [`FlowShape.Shape`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.NodeFlowShapes.html#fields) specifies flowchart shapes such as **Terminator**, **Process**, or **Decision**.
* [`ShapeAnnotation`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.ShapeAnnotation.html) adds text inside each node using the [`Content`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Annotation.html#Syncfusion_Blazor_Diagram_Annotation_Content) property.
* [`SourceID`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Connector.html#Syncfusion_Blazor_Diagram_Connector_SourceID) and [`TargetID`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.Connector.html#Syncfusion_Blazor_Diagram_Connector_TargetID) connect one node to another.
* [`NodeCreating`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_NodeCreating) applies common width, height, fill color, and stroke color to all nodes.
* [`ConnectorCreating`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_ConnectorCreating) applies common connector settings, such as orthogonal routing.

## Run the application

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application in Visual Studio. 
* Run the application using `dotnet run` command in Command prompt.
* This will render the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Diagram component in the default web browser.