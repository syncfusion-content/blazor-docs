---
layout: post
title: Getting Started with Blazor DataGrid in Web App | Syncfusion
description: Check out and learn about the documentation for getting started with Blazor DataGrid in Blazor Web App.
platform: Blazor
component: DataGrid
documentation: ug
---

# Getting Started with Blazor DataGrid Component in Blazor Web App

This section briefly explains how to include the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) component in your Blazor Web App using [Visual Studio](https://visualstudio.microsoft.com/vs/), [Visual Studio Code](https://code.visualstudio.com/), and the [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/).

> **Ready to streamline your Blazor development?** <br/>Discover the full potential of Blazor components with AI Coding Assistants. Effortlessly integrate, configure, and enhance your projects with intelligent, context-aware code suggestions, streamlined setups, and real-time insights—all seamlessly integrated into your preferred AI-powered IDEs like VS Code, Cursor, Code Studio and more. [Explore AI Coding Assistants](https://blazor.syncfusion.com/documentation/ai-coding-assistant/overview)

A Blazor Web App can be configured using a combination of **Interactive render mode** and **Interactivity location**. Choose the configuration that matches your application. The following table outlines the available render modes and interactivity options.

| Interactive render mode | Interactivity location | Project structure | Where Syncfusion® components run |
| --- | --- | --- | --- |
| **Interactive Server** | Per page/component | Single project (`BlazorWebApp`) | Server-side over SignalR |
| **Interactive Server** | Global | Single project (`BlazorWebApp`) | Server-side over SignalR |
| **Interactive WebAssembly** | Per page/component | Server + `.Client` project | Client-side in the browser |
| **Interactive WebAssembly** | Global | Server + `.Client` project | Client-side in the browser |
| **Interactive Auto** | Per page/component | Server + `.Client` project | WebAssembly after the initial server render |
| **Interactive Auto** | Global | Server + `.Client` project | WebAssembly after the initial server render |

## Blazor Web App project configuration reference

The following table maps each render mode and interactivity configuration to the corresponding project and file locations referenced throughout this guide.

| Interactive render mode | Interactivity location | Install NuGet packages in | `_Imports.razor` location | Register Blazor service in | Razor page location | `@rendermode` required |
| --- | --- | --- | --- | --- | --- | --- |
| **Interactive Server** | Per page/component | `BlazorWebApp` | `BlazorWebApp/Components/_Imports.razor` | `BlazorWebApp/Program.cs` | `BlazorWebApp/Components/Pages` | Yes, use `@rendermode InteractiveServer` |
| **Interactive Server** | Global | `BlazorWebApp` | `BlazorWebApp/Components/_Imports.razor` | `BlazorWebApp/Program.cs` | `BlazorWebApp/Components/Pages` | No (configured in `App.razor`) |
| **Interactive WebAssembly** | Per page/component | `BlazorWebApp.Client` | `BlazorWebApp.Client/_Imports.razor` | Both `BlazorWebApp/Program.cs` and `BlazorWebApp.Client/Program.cs` | `BlazorWebApp.Client/Pages` | Yes, use `@rendermode InteractiveWebAssembly` |
| **Interactive WebAssembly** | Global | `BlazorWebApp.Client` | `BlazorWebApp.Client/_Imports.razor` | Both `BlazorWebApp/Program.cs` and `BlazorWebApp.Client/Program.cs` | `BlazorWebApp.Client/Pages` | No (configured in `App.razor`) |
| **Interactive Auto** | Per page/component | `BlazorWebApp.Client` | `BlazorWebApp.Client/_Imports.razor` | Both `BlazorWebApp/Program.cs` and `BlazorWebApp.Client/Program.cs` | `BlazorWebApp.Client/Pages` | Yes, use `@rendermode InteractiveAuto` |
| **Interactive Auto** | Global | `BlazorWebApp.Client` | `BlazorWebApp.Client/_Imports.razor` | Both `BlazorWebApp/Program.cs` and `BlazorWebApp.Client/Program.cs` | `BlazorWebApp.Client/Pages` | No (configured in `App.razor`) |

## Create a new Blazor Web App

{% tabcontents %}

{% tabcontent Visual Studio %}

Create a **Blazor Web App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) or the [Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Run the following command to create a new Blazor Web App.

{% tabs %}
{% highlight bash tabtitle="Terminal" %}

dotnet new blazor -o BlazorWebApp --interactivity Auto
cd BlazorWebApp
cd BlazorWebApp.Client

{% endhighlight %}
{% endtabs %}

Alternatively, create a **Blazor Web App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vsc), the [Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project), or the [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension.

{% endtabcontent %}

{% tabcontent .NET CLI %}

Run the following command to create a new Blazor Web App.

{% tabs %}
{% highlight bash tabtitle="Command Prompt" %}

dotnet new blazor -o BlazorWebApp --interactivity Auto
cd BlazorWebApp
cd BlazorWebApp.Client

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

N> Configure the appropriate [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-10.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) while creating a Blazor Web App. For detailed information, refer to the [interactive render mode documentation](https://blazor.syncfusion.com/documentation/common/interactive-render-mode).

## Install the required NuGet packages

Install the [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet packages. All Syncfusion® Blazor packages are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for details.

Refer to the [Blazor Web App project configuration reference](#blazor-web-app-project-configuration-reference) for the appropriate project location to install the required NuGet packages based on your selected render mode and interactivity configuration.

{% tabcontents %}

{% tabcontent Visual Studio %}

1. Go to *Tools → NuGet Package Manager → Manage NuGet Packages for Solution*.
2. Search the required NuGet packages (`Syncfusion.Blazor.Grid` and `Syncfusion.Blazor.Themes`) and install them.

Alternatively, you can install the same packages using the Package Manager Console with the following commands.

{% tabs %}
{% highlight powershell tabtitle="Package Manager Console" %}

Install-Package Syncfusion.Blazor.Grid -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Open the terminal and run the following commands.

{% tabs %}
{% highlight bash tabtitle="Terminal" %}

dotnet add package Syncfusion.Blazor.Grid -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent .NET CLI %}

Open the command prompt and run the following commands.

{% tabs %}
{% highlight bash tabtitle="Command Prompt" %}

dotnet add package Syncfusion.Blazor.Grid -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

## Add import namespaces

After installing the required packages, import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Grids` namespaces into the **_Imports.razor** file. For the appropriate file location based on your selected render mode and interactivity configuration, refer to the [Blazor Web App project configuration reference](#blazor-web-app-project-configuration-reference).

{% tabs %}
{% highlight razor tabtitle="_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids

{% endhighlight %}
{% endtabs %}

## Register Syncfusion® Blazor Service

Register the Syncfusion® Blazor service in the **Program.cs** file. For the appropriate file location based on your selected render mode and interactivity configuration, refer to the [Blazor Web App project configuration reference](#blazor-web-app-project-configuration-reference).

{% tabs %}
{% highlight c# tabtitle="Program.cs" %}

....
using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor();
....

{% endhighlight %}
{% endtabs %}

## Add theme stylesheet and script references

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the [stylesheet](https://blazor.syncfusion.com/documentation/appearance/themes) and [script references](https://blazor.syncfusion.com/documentation/common/adding-script-references) in the **~/Components/App.razor** file.

{% tabs %}
{% highlight razor tabtitle="App.razor" %}

...
<link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
...
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

{% endhighlight %}
{% endtabs %}

## Add Syncfusion® Blazor DataGrid component

Open a Razor page (for example, **Home.razor** or **Counter.razor**) and add the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) component. For the appropriate Razor page location based on your selected render mode and interactivity configuration, refer to the [Blazor Web App project configuration reference](#blazor-web-app-project-configuration-reference).

N> When the interactivity location is set to **Per page/component**, add the appropriate `@rendermode` directive at the top of the Razor page. When using **Global** interactivity, the render mode is configured in `App.razor`, and no page-level `@rendermode` directive is required.

The following example uses `InteractiveAuto` for **Per page/component** interactivity. Adjust the `@rendermode` directive to match your selected render mode.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@rendermode InteractiveAuto
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData">
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code
{
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> Order = new List<OrderDetails>();
    public OrderDetails(int OrderID, string CustomerId, double Freight, string ShipCountry)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.Freight = Freight;
        this.ShipCountry = ShipCountry;    
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (Order.Count == 0)
        {
            Order.Add(new OrderDetails(10248, "VINET", 32.38, "France"));
            Order.Add(new OrderDetails(10249, "TOMSP", 11.61, "Germany"));
            Order.Add(new OrderDetails(10250, "HANAR", 65.83, "Brazil"));
            Order.Add(new OrderDetails(10251, "VICTE", 41.34, "France"));
            Order.Add(new OrderDetails(10252, "SUPRD", 51.3, "Belgium"));
        }
        return Order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCountry { get; set; }
}

{% endhighlight %}
{% endtabs %}

## Run the application

{% tabcontents %}

{% tabcontent Visual Studio %}

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. The Blazor DataGrid component will render in your default web browser.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Open the terminal and run the application from the appropriate project folder.

{% tabs %}
{% highlight bash tabtitle="Interactive Server" %}

dotnet run

{% endhighlight %}
{% highlight bash tabtitle="Interactive WebAssembly / Interactive Auto" %}

cd ..
cd BlazorWebApp
dotnet run

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent .NET CLI %}

Open the command prompt and run the application from the appropriate project folder.

{% tabs %}
{% highlight razor tabtitle="Interactive Server" %}

dotnet run

{% endhighlight %}
{% highlight razor tabtitle="Interactive WebAssembly / Interactive Auto" %}

cd ..
cd BlazorWebApp
dotnet run

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/htrHZdNkKnhrXYsw?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}
