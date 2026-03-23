---
layout: post
title: Getting Started with MAUI Blazor App in Visual Studio | Syncfusion
description: Check out the documentation for getting started with MAUI Blazor App and Syncfusion Blazor Components in Visual Studio and much more.
platform: Blazor
component: Common
documentation: ug
---

# Getting Started with .NET MAUI Blazor Hybrid App

This section explains how to create and run the .NET Multi-platform Blazor App UI (.NET MAUI Blazor App) with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components.

To get started quickly with a .NET MAUI Blazor App, review the following video.

{% youtube
"youtube:https://www.youtube.com/watch?v=wnceZx-Xezs" %}

## What is .NET MAUI Blazor App?

A .NET MAUI Blazor App is a .NET MAUI application where a Blazor Web App is hosted in the .NET MAUI app using the `BlazorWebView` control. This enables a Blazor Web App to integrate with platform features and UI controls. The `BlazorWebView` can be added to any page of a .NET MAUI app and pointed to the root of the Blazor App. The Blazor components run in the .NET process and render their web UI into the embedded web view control. .NET MAUI Blazor apps can run on all platforms supported by .NET MAUI.

Visual Studio provides the **.NET MAUI Blazor App** template to create .NET MAUI Blazor Apps.

## Prerequisites

* .NET SDK 8.0 or above
* [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [Visual Studio 2026](https://visualstudio.microsoft.com/downloads/) with the required workloads:
   * [Mobile development with .NET](https://learn.microsoft.com/en-us/dotnet/maui/get-started/installation?tabs=vswin)
   * ASP.NET and web development

## Create a new .NET MAUI Blazor App in Visual Studio

Create a **.NET MAUI Blazor App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/hybrid/tutorials/maui?view=aspnetcore-8.0) documentation.

## BlazorWebView in .NET MAUI Blazor App

The above steps create a multi-targeted .NET MAUI Blazor App that can be deployed to Android, iOS, macOS, and Windows.

In `MainPage.xaml`, the `BlazorWebView` is added and points to the root of the Blazor app. The root Blazor component for the app is in `Routes.razor`, which Razor compiles into a type named `Routes` in the application's root namespace.

{% tabs %}
{% highlight xaml tabtitle="MainPage.xaml" %}

<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:MauiBlazorApp"
             xmlns:components="clr-namespace:MauiBlazorApp.Components"
             x:Class="MauiBlazorApp.MainPage">

    <BlazorWebView x:Name="blazorWebView" HostPage="wwwroot/index.html">
        <BlazorWebView.RootComponents>
            <RootComponent Selector="#app" ComponentType="{x:Type local:Components.Routes}" />
        </BlazorWebView.RootComponents>
    </BlazorWebView>

</ContentPage>

{% endhighlight %}
{% endtabs %}

For more details, refer to the [Create a .NET MAUI Blazor App](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/blazorwebview#create-a-net-maui-blazor-app) topic. 

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Grid and Themes NuGet in the App

To add the **Blazor DataGrid** component to the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), then search and install [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes). Alternatively, run the following commands in the Package Manager Console to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Grid -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the available NuGet package list with component details.

## Add Import Namespaces

Open the `~/_Imports.razor` file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Grids` namespaces:

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids

{% endhighlight %}
{% endtabs %}

## Register Syncfusion Blazor Service

Register the Syncfusion Blazor service in the `MauiProgram.cs` file of the MAUI Blazor App.

{% tabs %}
{% highlight C# tabtitle="~/MauiProgram.cs" hl_lines="1 3" %}

    using Syncfusion.Blazor;
    ....
    builder.Services.AddSyncfusionBlazor();
    ....

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the stylesheet in the `<head>` and the script at the end of the `<body>` in the **~wwwroot/index.html** file as shown below:

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

N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in the Blazor application. Also, see [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in the Blazor application.

## Add Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor component

Add a Syncfusion Blazor component to any Razor file in the Blazor project. The example below adds the Blazor Grid component into `Pages/Home.razor` file.

{% tabs %}
{% highlight razor %}

<SfGrid DataSource="@Orders" />

@code {
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 5).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

In the Visual Studio toolbar, click the **Windows Machine** to build and run the app. Ensure the run profile is set to `Windows Machine` before starting the app.

![Build and run MAUI Blazor App](images/maui/windows-machine-mode.webp)

N> To run the application on Android or iOS, refer to [MAUI Getting Started](https://learn.microsoft.com/en-us/aspnet/core/blazor/hybrid/tutorials/maui?view=aspnetcore-8.0#run-the-app-in-the-android-emulator) for setup instructions.

![MAUI Blazor App with Syncfusion Blazor Components](images/maui/maui-blazor-datagrid.webp)

N> Download the demo from [GitHub](https://github.com/SyncfusionExamples/MAUI-Blazor-App-using-Syncfusion-Blazor-Components).

## How to use images in .NET MAUI Blazor Application

Add images to the `wwwroot` folder of the application and reference them using the `img` tag in the Blazor App.

In the following example, images are added under the `images` folder in the `wwwroot` folder.

{% tabs %}
{% highlight razor %}

<img src="images/welcome_picture.png" height="60" width="60" />

{% endhighlight %}
{% endtabs %}

![MAUI Blazor App with added image](images\maui\maui-image.webp)

## Troubleshooting

### How to solve deployment errors in Windows?

If the error dialog “There were deployment errors” appears, enable Developer Mode. For more details, refer to [Enable your device for development](https://learn.microsoft.com/en-us/windows/apps/get-started/enable-your-device-for-development).

![Enable developer mode in system settings](images/maui/enable-developer-mode.webp)

<hr/>

### How to solve deployment errors in iOS?

In iOS, code is statically compiled ahead of time. Configure Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor assemblies in the `MtouchExtraArgs` tag for the iOS Release configuration in the project when deploying to a real device.

```
<PropertyGroup Condition="$(TargetFramework.Contains('-ios')) And $(Configuration.Contains('Release')) ">
  <UseInterpreter>true</UseInterpreter>
  <MtouchExtraArgs>--linkskip=Syncfusion.Blazor.Themes --linkskip=Syncfusion.Blazor.Inputs</MtouchExtraArgs>
</PropertyGroup>
```

Possible errors if the `MtouchExtraArgs` tag is not configured:

1. The app does not load on a real device with the error “An unhandled error has occurred” after compiling in Release mode with Visual Studio and deploying to a real device.
2. AOT-related failures such as [`Attempting to JIT compile method while running in aot-only mode`](https://github.com/dotnet/macios/issues/12416)

**Reference**:

* [Could not AOT the assembly of my App](https://learn.microsoft.com/en-us/answers/questions/396055/could-not-aot-the-assembly-of-my-app)

<hr/>

### How to solve "The project doesn't know how to run the profile Windows Machine" while running MAUI Blazor App?

* This issue has been addressed in a recent release of Visual Studio. For details, see the discussion [here](https://developercommunity.visualstudio.com/t/the-project-doesnt-know-how-to-run-the-profile-win/1530395).

* Alternatively, install [Single-project MSIX Packaging Tools](https://marketplace.visualstudio.com/items?itemName=ProjectReunion.MicrosoftSingleProjectMSIXPackagingToolsDev17) to resolve this error.

## See also

### MAUI Blazor Diagram

* [How to create Diagram Builder in MAUI platform?](https://support.syncfusion.com/kb/article/11346/how-to-create-diagram-builder-in-maui-platform)

N> [View MAUI Blazor Diagram Builder Source Code in GitHub](https://github.com/syncfusion/blazor-showcase-diagram-builder/tree/master/MAUI)
