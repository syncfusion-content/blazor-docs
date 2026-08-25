---
layout: post
title: Getting Started with Blazor Sparkline Charts in a Web App | Syncfusion®
description: Learn how to add and configure the Syncfusion Blazor Sparkline component in a Blazor Web App, including project creation, package installation, service registration, and data binding.
platform: Blazor
control: Sparkline Charts
documentation: ug
---

# Getting Started with Blazor Sparkline Charts in a Web App

This topic explains how to add and configure the [Blazor Sparkline Charts](https://www.syncfusion.com/blazor-components/blazor-sparkline) component in a Blazor Web App using [Visual Studio](https://visualstudio.microsoft.com/vs/), [Visual Studio Code](https:/rn.microsoft.com/dotnet/core/tools/.

Before you begin, ensure that a supported .NET SDK is installed. Run the following command to verify the installed SDK version:

{% tabs %}
{% highlight bash tabtitle="Terminal" %}

dotnet --version

{% endhighlight %}
{% endtabs %}

Refer to the Syncfusion Blazor system requirements and NuGet package documentation for the supported .NET, Blazor, tooling, and package versions.

## Create a Blazor Web App

{% tabcontents %}

{% tabcontent Visual Studio %}

Create a **Blazor Web App** using the Microsoft Blazor Web App template in Visual Studio.

You can also create the application using the [Syncfusion Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

For detailed instructions, refer to:

- [Microsoft Blazor tooling documentation](https://learn.microsoft.com/aspnet/core/blazor/tooling)
- [Syncfusion Blazor Web App getting started documentation](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app)

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Open a terminal and run the following commands to create a Blazor Web App with Auto interactivity:

{% tabs %}
{% highlight bash tabtitle="Terminal" %}

dotnet new blazor -o BlazorWebApp --interactivity Auto
cd BlazorWebApp

{% endhighlight %}
{% endtabs %}

The `Auto` render mode creates both server and `.Client` projects.

You can also create a Blazor Web App using:

- [Microsoft Blazor templates](https://learn.microsoft.com/aspnet/core/blazor/tooling)
- [Syncfusion Blazor Extension for Visual Studio Code](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project)
- [C# Dev Kit](https://isualstudio.com/items?itemName=ms-dotnettools.csdevkit

{% endtabcontent %}

{% tabcontent .NET CLI %}

Run the following commands to create a Blazor Web App with Auto interactivity:

{% tabs %}
{% highlight bash tabtitle="Command Prompt" %}

dotnet new blazor -o BlazorWebApp --interactivity Auto
cd BlazorWebApp

{% endhighlight %}
{% endtabs %}

The `Auto` render mode creates both server and `.Client` projects.

{% endtabcontent %}

{% endtabcontents %}

N> Select the appropriate [interactive render modecom/aspnet/core/blazor/components/render-modes#render-modes and interactivity location when creating the application. For more information, refer to the [Syncfusion interactive render mode documentation](https://blazor.syncfusion.com/documentation/common/interactive-render-mode).

## Install the required Blazor package

Install the https://www.nuget.org/packages/Syncfusion.Blazor.Sparkline NuGet package.

- For `InteractiveServer`, install the package in the server project.
- For `InteractiveWebAssembly`, install the package in the `.Client` project.
- For `InteractiveAuto`, install the package in the project or projects where Syncfusion components and services are used. In the standard Auto-interactivity setup, install it in both the server and `.Client` projects.

All Syncfusion Blazor packages are available on [NuGet.org](https://www.nuget.org/packages?q=syncfusion.blazor). For more information, refer to the [Syncfusion Blazor NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) documentation.

{% tabcontents %}

{% tabcontent Visual Studio %}

1. Select **Tools → NuGet Package Manager → Manage NuGet Packages for Solution**.
2. Search for `Syncfusion.Blazor.Sparkline`.
3. Select the required project or projects and install the package.

Alternatively, use the Package Manager Console:

{% tabs %}
{% highlight powershell tabtitle="Package Manager Console" %}

Install-Package Syncfusion.Blazor.Sparkline -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Run the following command from the project that will use the Sparkline component:

{% tabs %}
{% highlight bash tabtitle="Terminal" %}

dotnet add package Syncfusion.Blazor.Sparkline --version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

For an Auto-interactivity application, repeat the command from the `.Client` project if the component will use WebAssembly interactivity.

{% endtabcontent %}

{% tabcontent .NET CLI %}

Run the following command from the project that will use the Sparkline component:

{% tabs %}
{% highlight bash tabtitle="Command Prompt" %}

dotnet add package Syncfusion.Blazor.Sparkline --version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

For an Auto-interactivity application, repeat the command from the `.Client` project if the component will use WebAssembly interactivity.

{% endtabcontent %}

{% endtabcontents %}

## Add the required namespaces

Open the `_Imports.razor` file associated with the Razor component and add the following namespaces:

{% tabs %}
{% highlight razor tabtitle="_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Charts
@using static Microsoft.AspNetCore.Components.Web.RenderMode

{% endhighlight %}
{% endtabs %}

Use the `_Imports.razor` file in:

- The server project for server-interactive components.
- The `.Client` project for WebAssembly-interactive components.
- Both projects when the components are used with both server and WebAssembly interactivity.

The static render-mode import is required when using directives such as `@rendermode InteractiveAuto`.

## Register Syncfusion Blazor services

Open `Program.cs` and add the Syncfusion namespace:

{% tabs %}
{% highlight csharp tabtitle="Program.cs" %}

using Syncfusion.Blazor;

{% endhighlight %}
{% endtabs %}

Register Syncfusion Blazor services before building the application:

{% tabs %}
{% highlight csharp tabtitle="Program.cs" %}

builder.Services.AddSyncfusionBlazor();

{% endhighlight %}
{% endtabs %}

Register the services in:

- The server project's `Program.cs` for `InteractiveServer`.
- The `.Client` project's `Program.cs` for `InteractiveWebAssembly`.
- Both `Program.cs` files for `InteractiveAuto`.

If the application requires Syncfusion license registration, follow the [Syncfusion license key registration](https://blazor.syncfusion.com/documentation/licensing/license-key-registration) instructions.

## Add theme and script resources

### Add the theme stylesheet

Add a Syncfusion theme stylesheet to the `<head>` section of `App.razor`. The following example uses the Fluent 2 theme exposed through static web assets:

{% tabs %}
{% highlight razor tabtitle="App.razor" %}

_content/Syncfusion.Blazor.Themes/fluent2.css

{% endhighlight %}
{% endtabs %}

For other available themes and configuration methods, refer to the [Syncfusion Blazor themes](https://blazor.syncfusion.com/documentation/appearance/themes) documentation.

### Add the script reference

Add the following script reference near the end of the `<body>` section in `App.razor`:

{% tabs %}
{% highlight razor tabtitle="App.razor" %}

_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.jsscript>

{% endhighlight %}
{% endtabs %}

For more information, refer to the [Syncfusion script reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) documentation.

## Add the Blazor Sparkline component

Open a Razor component in the `Pages` folder, such as `Home.razor`, and add the Sparkline component.

If the application's interactivity location is `Per page/component`, add the render mode that matches the project configuration.

The following example uses Auto interactivity:

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@rendermode InteractiveAuto

<SfSparkline TValue="double"
             DataSource="SparklineData"
             Height="80px"
             Width="150px">
</SfSparkline>

@code {
    private readonly List<double> SparklineData =
    [
        34, 36, 32, 35, 40, 38, 33, 37, 34, 31, 30, 29
    ];
}

{% endhighlight %}
{% endtabs %}

Use `InteractiveServer` or `InteractiveWebAssembly` instead of `InteractiveAuto` when the application uses the corresponding render mode.

If interactivity is configured globally, the `@rendermode` directive is not required on each component.

## Bind the Sparkline component to a data source

The `DataSource` property accepts an `IEnumerable<TValue>` data source or a supported `DataManager` instance.

The following example binds a collection of `WeatherReport` objects. The `Month` property supplies category x-values, and the `Celsius` property supplies numeric y-values.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@rendermode InteractiveAuto

<SfSparkline TValue="WeatherReport"
             DataSource="ClimateData"
             XName="Month"
             YName="Celsius"
             ValueType="SparklineValueType.Category"
             Height="80px"
             Width="150px">
</SfSparkline>

@code {
    public sealed class WeatherReport
    {
        public required string Month { get; init; }

        public double Celsius { get; init; }
    }

    private readonly List<WeatherReport> ClimateData =
    [
        new() { Month = "Jan", Celsius = 34 },
        new() { Month = "Feb", Celsius = 36 },
        new() { Month = "Mar", Celsius = 32 },
        new() { Month = "Apr", Celsius = 35 },
        new() { Month = "May", Celsius = 40 },
        new() { Month = "Jun", Celsius = 38 },
        new() { Month = "Jul", Celsius = 33 },
        new() { Month = "Aug", Celsius = 37 },
        new() { Month = "Sep", Celsius = 34 },
        new() { Month = "Oct", Celsius = 31 },
        new() { Month = "Nov", Celsius = 30 },
        new() { Month = "Dec", Celsius = 29 }
    ];
}

{% endhighlight %}
{% endtabs %}

Use `SparklineValueType.Category` because `Month` contains categorical string values.

When loading data asynchronously, initialize the collection before rendering or conditionally render the Sparkline after the data is available. Avoid assigning a null data source.

## Run the application

{% tabcontents %}

{% tabcontent Visual Studio %}

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> on Windows or select **Debug → Start Without Debugging** to launch the application.

The Sparkline component is rendered in the default web browser.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Open a terminal, navigate to the `BlazorWebApp` project folder, and run:

{% tabs %}
{% highlight bash tabtitle="Terminal" %}

dotnet run

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent .NET CLI %}

Open a command prompt, navigate to the `BlazorWebApp` project folder, and run:

{% tabs %}
{% highlight bash tabtitle="Command Prompt" %}

dotnet run

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZVdDQDRtmNUMSyI?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "./images/blazor-sparkline.webp" %}

N> https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/Sparkline.

## Additional configuration

### Change the Sparkline type

Set the `Type` property to `Line`, `Column`, `WinLoss`, `Pie`, or `Area`.

The following example renders an Area Sparkline:

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

<SfSparkline TValue="WeatherReport"
             DataSource="ClimateData"
             XName="Month"
             YName="Celsius"
             ValueType="SparklineValueType.Category"
             Type="SparklineType.Area"
             Height="80px"
             Width="150px">
</SfSparkline>

{% endhighlight %}
{% endtabs %}

See the #bind-the-sparkline-component-to-a-data-source for the `WeatherReport` and `ClimateData` definitions.

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDBdZcZdNmrZAISz?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "./images/blazor-area-sparkline.webp" %}

### Add data labels

Use `SparklineDataLabelSettings.Visible` to specify which data labels are displayed.

The supported `VisibleType` values include:

- `VisibleType.Start`
- `VisibleType.End`
- `VisibleType.All`
- `VisibleType.High`
- `VisibleType.Low`
- `VisibleType.Negative`

The following example displays labels for the first and last data points:

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

<SfSparkline TValue="WeatherReport"
             DataSource="ClimateData"
             XName="Month"
             YName="Celsius"
             ValueType="SparklineValueType.Category"
             Height="80px"
             Width="150px">
    <SparklineDataLabelSettings
        Visible="new List<VisibleType>
        {
            VisibleType.Start,
            VisibleType.End
        }">
    </SparklineDataLabelSettings>

    <SparklinePadding Left="10" Right="10">
    </SparklinePadding>
</SfSparkline>

{% endhighlight %}
{% endtabs %}

See the #bind-the-sparkline-component-to-a-data-source for the `WeatherReport` and `ClimateData` definitions.

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNVRXGjdtQApBCIY?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "./images/blazor-sparkline-data-label.webp" %}

### Enable the tooltip

Enable the tooltip by setting `SparklineTooltipSettings.Visible` to `true`.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

<SfSparkline TValue="WeatherReport"
             DataSource="ClimateData"
             XName="Month"
             YName="Celsius"
             ValueType="SparklineValueType.Category"
             Height="80px"
             Width="150px">
    <SparklineTooltipSettings TValue="WeatherReport"
                              Visible="true">
    </SparklineTooltipSettings>
</SfSparkline>

{% endhighlight %}
{% endtabs %}

See the #bind-the-sparkline-component-to-a-data-source for the `WeatherReport` and `ClimateData` definitions.

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjBHNmNdXmcKOFsY?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "./images/blazor-sparkline-tooltip.webp" %}

## Troubleshooting

### The Sparkline is not displayed

Verify that:

- The Syncfusion theme stylesheet is loaded.
- The Syncfusion Blazor script is included in `App.razor`.
- `AddSyncfusionBlazor()` is registered in the correct project.
- The component has an interactive render mode.
- The `DataSource`, `XName`, and `YName` values are valid.
- The Sparkline has a nonzero width and height.

### The component or namespace cannot be found

Verify that:

- `Syncfusion.Blazor.Sparkline` is installed in the project containing the Razor component.
- `Syncfusion.Blazor` and `Syncfusion.Blazor.Charts` are imported in the appropriate `_Imports.razor` file.
- The package version is compatible with the application's target framework.

### Auto or WebAssembly interactivity fails

Verify that the package and Syncfusion services are configured in the `.Client` project. For Auto interactivity, also verify the server-project configuration.

## See also

1. https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app
2. https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio
3. https://blazor.syncfusion.com/documentation/common/interactive-render-mode
4. [Syncfusion Blazor themes](https://blazor.syncfusion.com/documentation/appearance/themes)
5. [Syncfusion license key registration](https://blazor.syncfusion.com/documentation/licensing/license-key-registration)