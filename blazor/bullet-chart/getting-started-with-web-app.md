---
layout: post
title: Getting Started with Blazor Bullet Chart in Web App | Syncfusion®
description: Learn how to get started with Syncfusion Blazor Bullet Chart in a Blazor Web App, including server and client setup, packages, and first chart.
platform: Blazor
control: Bullet Chart
documentation: ug
---

# Blazor Bullet Chart Getting Started in Web App

This section briefly explains how to include the [Blazor Bullet Chart](https://www.syncfusion.com/blazor-components/blazor-bullet-chart) component in your Blazor Web App using [Visual Studio](https://visualstudio.microsoft.com/vs/), [Visual Studio Code](https://code.visualstudio.com/), and the [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/). This guide targets Blazor Web Apps created with .NET 8 or later.

## Create a new Blazor Web App

{% tabcontents %}

{% tabcontent Visual Studio %}

Create a **Blazor Web App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) or the [Syncfusion® Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Run the following command to create a new Blazor Web App.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet new blazor -o BlazorWebApp --interactivity Auto
cd BlazorWebApp
cd BlazorWebApp.Client

{% endhighlight %}
{% endtabs %}

Alternatively, create a **Blazor Web App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vsc), the [Syncfusion® Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project), or the [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension.

{% endtabcontent %}

{% tabcontent .NET CLI %}

Run the following command to create a new Blazor Web App.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}

dotnet new blazor -o BlazorWebApp --interactivity Auto
cd BlazorWebApp
cd BlazorWebApp.Client

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

N> Configure the appropriate [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-10.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) while creating a Blazor Web App. For detailed information, refer to the [interactive render mode documentation](https://blazor.syncfusion.com/documentation/common/interactive-render-mode).

## Install the required Blazor package

Install the [Syncfusion.Blazor.BulletChart](https://www.nuget.org/packages/Syncfusion.Blazor.BulletChart/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet packages. All Syncfusion Blazor packages are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for details. For `WebAssembly` or `Auto` render modes, install these packages in the `.Client` project. For `Server` render mode, install them in the server project.

{% tabcontents %}

{% tabcontent Visual Studio %}

1. Go to *Tools → NuGet Package Manager → Manage NuGet Packages for Solution*.
2. Search the required NuGet packages (`Syncfusion.Blazor.BulletChart` and `Syncfusion.Blazor.Themes`) and install them in the project that contains the component.

Alternatively, you can install the same package using the Package Manager Console with the following command.

{% tabs %}
{% highlight razor tabtitle="Package Manager Console" %}

Install-Package Syncfusion.Blazor.BulletChart -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Open the terminal and run the following command.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet add package Syncfusion.Blazor.BulletChart -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent .NET CLI %}

Open the command prompt and run the following command.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}

dotnet add package Syncfusion.Blazor.BulletChart -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

## Add namespace imports

After the packages are installed, open the **~/_Imports.razor** file in the project that contains the component and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Charts` namespaces.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Charts

{% endhighlight %}
{% endtabs %}

## Register the Blazor service

Open the **Program.cs** file in the project that contains the component and register the Blazor service. Include the required namespace reference `using Syncfusion.Blazor;` at the top. If the **Interactive Render Mode** is set to `WebAssembly` or `Auto`, register the Blazor service in the **Program.cs** files of both the server and client projects in your Blazor Web App.

{% tabs %}
{% highlight C# tabtitle="Program.cs" %}

using Syncfusion.Blazor;

builder.Services.AddSyncfusionBlazor();

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

In the **App.razor** file, add the Syncfusion theme stylesheet at the end of the `<head>` section and the required [script reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) at the end of the `<body>` section. Ensure that static web assets are enabled in the server project so these resources can be served.

{% tabs %}
{% highlight razor tabtitle="App.razor" %}

<link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />

<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

{% endhighlight %}
{% endtabs %}

## Add Blazor Bullet Chart component

Open a Razor file in the project that contains the component and add the [Blazor Bullet Chart](https://www.syncfusion.com/blazor-components/blazor-bullet-chart) component inside the Razor file.

N> If the interactivity location is set to `Per page/component` in the Web App, define a render mode at the top of the Razor file. The following sample uses `InteractiveAuto`; replace it with `InteractiveServer` or `InteractiveWebAssembly` when using those modes. If the **Interactivity** is set to `Global` with `Auto` or `WebAssembly`, the render mode is configured in the `App.razor` file.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@page "/"
@rendermode InteractiveAuto

<SfBulletChart DataSource="@BulletChartData" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="300" Interval="50">
</SfBulletChart>

@code
{
    public class ChartData
    {
        public double FieldValue { get; set; }
        public double TargetValue { get; set; }
    }
    public List<ChartData> BulletChartData = new List<ChartData>
    {
        new ChartData { FieldValue = 270, TargetValue = 250 }
    };
}

{% endhighlight %}
{% endtabs %}

## Run the application

{% tabcontents %}

{% tabcontent Visual Studio %}

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. The [Blazor Bullet Chart](https://www.syncfusion.com/blazor-components/blazor-bullet-chart) component will render in your default web browser.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Open the terminal and navigate to the main project folder (for example, `BlazorWebApp`) and run the following command.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

cd ..
cd BlazorWebApp
dotnet run

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent .NET CLI %}

Open the command prompt and navigate to the main project folder (for example, `BlazorWebApp`) and run the following command.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}

cd ..
cd BlazorWebApp
dotnet run

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXBdjHiMJdxpZLsR?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Bullet Chart Component](images/blazor-bullet-chart-component.webp)" %}

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/BulletChart).

The following examples modify the `Home.razor` page created in the preceding step.

## Adding title

Add a title by using the [Title](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html#Syncfusion_Blazor_Charts_SfBulletChart_1_Title) property in the Bullet Chart to provide quick information to the user about the data plotted in the component.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

<SfBulletChart DataSource="@BulletChartData" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="300" Interval="50" Title="Revenue">
</SfBulletChart>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDLHjRiCzHdclwiM?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Bullet Chart with Title](images/blazor-bullet-chart-title.webp)" %}

## Adding ranges

Add ranges by using the [BulletChartRangeCollection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartRangeCollection.html) to represent qualitative performance levels across the scale.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

<SfBulletChart DataSource="@BulletChartData" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="300" Interval="50" Title="Revenue">
    <BulletChartRangeCollection>
        <BulletChartRange End=150> </BulletChartRange>
        <BulletChartRange End=250></BulletChartRange>
        <BulletChartRange End=300></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtLxtnMszRcrejzZ?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Adding Range in Blazor Bullet Chart](images/blazor-bullet-chart-ranges.webp)" %}

## Adding tooltip

Use the tooltip to show the measured values by setting the [Enable](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartTooltip-1.html#Syncfusion_Blazor_Charts_BulletChartTooltip_1_Enable) property to **true** in the [BulletChartTooltip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartTooltip-1.html).

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

<SfBulletChart DataSource="@BulletChartData" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="300" Interval="50" Title="Revenue">
    <BulletChartTooltip TValue="ChartData" Enable="true"></BulletChartTooltip>
    <BulletChartRangeCollection>
        <BulletChartRange End=150> </BulletChartRange>
        <BulletChartRange End=250></BulletChartRange>
        <BulletChartRange End=300></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDhRXniWTxmeRSpM?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Bullet Chart displays tooltip](images/blazor-bullet-chart-tooltip.webp)" %}

## See also

1. [Getting Started with Blazor Web App](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app)
2. [Getting Started with Blazor WebAssembly App in Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app)
3. [Getting Started with Blazor Server App in Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)

