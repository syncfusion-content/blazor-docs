---
layout: post
title: Getting started with Syncfusion Maps Component in Blazor Web App
description: Check out the documentation for getting started with Syncfusion Blazor Maps Component in Blazor Web App.
platform: Blazor
component: Maps
documentation: ug
---

# Getting started with Blazor Maps Component in Blazor Web App

This section briefly explains how to include [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Maps](https://www.syncfusion.com/blazor-components/blazor-map) component in your Blazor Web App using [Visual Studio](https://visualstudio.microsoft.com/vs/), [Visual Studio Code](https://code.visualstudio.com/), and the [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/).

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App in Visual Studio

Create a **Blazor Web App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio). For detailed instructions, refer to the [Blazor Web App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app) documentation.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App in Visual Studio Code

Create a **Blazor Web App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project). For detailed instructions, refer to the [Blazor Web App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=visual-studio-code) documentation.

For example, in a Blazor Web App with the `Auto` interactive render mode, use the following commands in the integrated terminal (<kbd>Ctrl</kbd>+<kbd>`</kbd>):

{% tabs %}
{% highlight c# tabtitle="Blazor Web App" %}

dotnet new blazor -o BlazorWebApp -int Auto
cd BlazorWebApp

{% endhighlight %}
{% endtabs %}

N> If the application is configured with WebAssembly or Auto render modes, you may optionally navigate to the client project directory to manage client-specific dependencies. Once the required changes are completed, ensure that you navigate back to the root project directory.

```
cd BlazorWebApp.Client
cd ..
```

{% endtabcontent %}

{% tabcontent .NET CLI %}

## Prerequisites

Install the latest version of [.NET SDK](https://dotnet.microsoft.com/en-us/download). If you previously installed the SDK, determine the installed version by executing the following command in a command prompt (Windows) or terminal (macOS) or command shell (Linux).

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet --version

{% endhighlight %}
{% endtabs %}

## Create a Blazor Web App using .NET CLI

Run the following command to create a new Blazor Web App in a command prompt (Windows) or terminal (macOS) or command shell (Linux). For detailed instructions, refer to the [Blazor Web App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=.net-cli) documentation.

For example, in a Blazor Web App with the `Auto` interactive render mode, use the following commands:

{% tabs %}
{% highlight c# tabtitle="Blazor Web App" %}

dotnet new blazor -o BlazorWebApp -int Auto
cd BlazorWebApp

{% endhighlight %}
{% endtabs %}

N> If the application is configured with WebAssembly or Auto render modes, you may optionally navigate to the client project directory to manage client-specific dependencies. Once the required changes are completed, ensure that you navigate back to the root project directory.

```
cd BlazorWebApp.Client
cd ..
```

{% endtabcontent %}

{% endtabcontents %}

N> Configure the appropriate [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-10.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) while creating a Blazor Web App. For detailed information, refer to the [interactive render mode documentation](https://blazor.syncfusion.com/documentation/common/interactive-render-mode).

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor packages

Install the [Syncfusion.Blazor.Maps](https://www.nuget.org/packages/Syncfusion.Blazor.Maps) NuGet package in your project using the NuGet Package Manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), or the integrated terminal in Visual Studio Code (dotnet add package Syncfusion.Blazor.Maps --version {{ site.releaseversion }}), or the .NET CLI.

Alternatively, run the following command in the Package Manager Console to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Maps -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

If using the `WebAssembly` or `Auto` render modes in the Blazor Web App, install this package in the client project.

N> All Syncfusion Blazor packages are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for details.

## Add import namespaces

After the packages are installed, open the **~/_Imports.razor** file in the client project and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Maps` namespaces.

N> The `~/` notation represents the root directory of your project. This file is typically located in your project's root folder.

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Maps

{% endhighlight %}
{% endtabs %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service

Register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in the **Program.cs** file of your Blazor Web App. This step enables the Syncfusion components to work in your application.

{% tabs %}
{% highlight c# tabtitle="Program.cs" %}

....
using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor();
....

{% endhighlight %}
{% endtabs %}

N> If the **Interactive Render Mode** is set to `WebAssembly` or `Auto`, register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in **Program.cs** files of both the server and client projects in your Blazor Web App.

## Add script resources

The Syncfusion JavaScript library needs to be included in your application. The script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/common/adding-script-references#static-web-assets). Include the script reference in the **~/Components/App.razor** file (this is the root layout file of your application).

```html

<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

```

N> Check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in your Blazor application.

## Add Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Maps component with GeoJSON data

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Maps component in the **~/Components/Pages/Home.razor** file. If the interactivity location is set to `Per page/component`, define a render mode at the top of the `~Pages/Home.razor` file.

N> If the Interactivity Location is set to `Global`, the render mode is automatically configured in the `App.razor` file by default.

{% tabs %}
{% highlight razor %}

@* desired render mode defined here *@
@rendermode InteractiveAuto

{% endhighlight %}
{% endtabs %}

Bind GeoJSON data to the Maps to render any geometric shape in SVG (Scalable Vector Graphics) for powerful data visualization of shapes. You can use the [ShapeData](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer-1.html#Syncfusion_Blazor_Maps_MapsLayer_1_ShapeData) property in [MapsLayer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer-1.html) to load the GeoJSON shape data into the Maps component.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

<!-- SfMaps is the root container component for the maps -->
<SfMaps>
    <!-- MapsLayers contains one or more map layers to display on the map -->
    <MapsLayers>
        <!-- MapsLayer defines a map layer with shape data and configuration -->
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
        </MapsLayer>
    </MapsLayers>
</SfMaps>

{% endhighlight %}
{% endtabs %}

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This will render the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Maps component in the default web browser.

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZVRNhjJJCBhIpFe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Maps with GeoJSON Layer](./images/blazor-map.png)" %}

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/Maps).

N> The "world-map.json" file contains the World map GeoJSON data.

## Bind data source

The [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer-1.html#Syncfusion_Blazor_Maps_MapsLayer_1_DataSource) property is used to represent statistical data in the Maps component. We can define a list of objects as a data source to the Maps component. This data source will be further used to color the map, display data labels, display tooltips, and more. Assign the below list **SecurityCouncilDetails** to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer-1.html#Syncfusion_Blazor_Maps_MapsLayer_1_DataSource) property in [MapsLayer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer-1.html).

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@code {
    public List<UNCouncilCountry> SecurityCouncilDetails = new List<UNCouncilCountry>{
         new UNCouncilCountry { Name= "China", Membership= "Permanent" },
         new UNCouncilCountry { Name= "France", Membership= "Permanent" },
         new UNCouncilCountry { Name= "Russia", Membership= "Permanent" },
         new UNCouncilCountry { Name= "Kazakhstan", Membership= "Non-Permanent" },
         new UNCouncilCountry { Name= "Poland", Membership= "Non-Permanent" },
         new UNCouncilCountry { Name= "Sweden", Membership= "Non-Permanent" },
         new UNCouncilCountry { Name= "United Kingdom", Membership= "Permanent" },
         new UNCouncilCountry { Name= "United States", Membership= "Permanent" },
         new UNCouncilCountry { Name= "Bolivia", Membership= "Non-Permanent" },
         new UNCouncilCountry { Name= "Eq. Guinea", Membership= "Non-Permanent" },
         new UNCouncilCountry { Name= "Ethiopia", Membership= "Non-Permanent" },
         new UNCouncilCountry { Name= "Côte d Ivoire", Membership= "Permanent" },
         new UNCouncilCountry { Name= "Kuwait", Membership= "Non-Permanent" },
         new UNCouncilCountry { Name= "Netherlands", Membership= "Non-Permanent" },
         new UNCouncilCountry { Name= "Peru", Membership= "Non-Permanent" }
    };

    public class UNCouncilCountry
    {
        public string Name { get; set; }
        public string Membership { get; set; }
    };
}

{% endhighlight %}
{% endtabs %}

N> The United Nations Security Council data is referred from [source](https://en.wikipedia.org/wiki/List_of_members_of_the_United_Nations_Security_Council).

You should also specify the field names in the shape data and data source to the [ShapePropertyPath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer-1.html#Syncfusion_Blazor_Maps_MapsLayer_1_ShapePropertyPath) and [ShapeDataPath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer-1.html#Syncfusion_Blazor_Maps_MapsLayer_1_ShapeDataPath) properties, respectively. These are used to identify the appropriate shapes and match the specific data source values to them.

The following complete example shows a Maps component with the GeoJSON layer and data source binding:

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.Maps
@rendermode InteractiveAuto

<SfMaps>
    <MapsLayers>
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}'
                   ShapePropertyPath='new string[] {"name"}'
                   DataSource="SecurityCouncilDetails"
                   ShapeDataPath="Name" TValue="UNCouncilCountry">
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {
    public List<UNCouncilCountry> SecurityCouncilDetails = new List<UNCouncilCountry>{
         new UNCouncilCountry { Name= "China", Membership= "Permanent" },
         new UNCouncilCountry { Name= "France", Membership= "Permanent" },
         new UNCouncilCountry { Name= "Russia", Membership= "Permanent" },
         new UNCouncilCountry { Name= "Kazakhstan", Membership= "Non-Permanent" },
         new UNCouncilCountry { Name= "Poland", Membership= "Non-Permanent" },
         new UNCouncilCountry { Name= "Sweden", Membership= "Non-Permanent" },
         new UNCouncilCountry { Name= "United Kingdom", Membership= "Permanent" },
         new UNCouncilCountry { Name= "United States", Membership= "Permanent" },
         new UNCouncilCountry { Name= "Bolivia", Membership= "Non-Permanent" },
         new UNCouncilCountry { Name= "Eq. Guinea", Membership= "Non-Permanent" },
         new UNCouncilCountry { Name= "Ethiopia", Membership= "Non-Permanent" },
         new UNCouncilCountry { Name= "Côte d Ivoire", Membership= "Permanent" },
         new UNCouncilCountry { Name= "Kuwait", Membership= "Non-Permanent" },
         new UNCouncilCountry { Name= "Netherlands", Membership= "Non-Permanent" },
         new UNCouncilCountry { Name= "Peru", Membership= "Non-Permanent" }
    };

    public class UNCouncilCountry
    {
        public string Name { get; set; }
        public string Membership { get; set; }
    };
}

{% endhighlight %}
{% endtabs %}

This example demonstrates the complete setup with:
- The **ShapeData** pointing to the GeoJSON world map
- The **ShapePropertyPath** set to `"name"` to match shape names
- The **DataSource** bound to `SecurityCouncilDetails`
- The **ShapeDataPath** set to `"Name"` to match data source field

N> Please [refer to the section](populate-data#data-binding) for more information on data binding.

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/Maps).

## See also

* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Web Assembly App in Visual Studio or .NET CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app)

* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Web App in Visual Studio or .NET CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app)
