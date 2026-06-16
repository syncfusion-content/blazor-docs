---
layout: post
title: Getting Started with Blazor Maps in Blazor WASM App | Syncfusion
description: Checkout and learn about getting started with Blazor Maps component in Blazor WebAssembly Application.
platform: Blazor
component: Maps
documentation: ug
---

# Getting Started with Blazor Maps Component in Blazor WASM App

This section briefly explains how to include [Blazor Maps](https://www.syncfusion.com/blazor-components/blazor-map) component in a Blazor WebAssembly App using [Visual Studio](https://visualstudio.microsoft.com/vs/), [Visual Studio Code](https://code.visualstudio.com/), and the [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/).

### Create a new Blazor WASM App

{% tabcontents %}

{% tabcontent Visual Studio %}

Create a **Blazor WebAssembly App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) or the [Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio). For detailed instructions, refer to the [Blazor WebAssembly App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app) documentation.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Run the following command to create a new Blazor WebAssembly App.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet new blazorwasm -o BlazorApp

{% endhighlight %}
{% endtabs %}

Alternatively, create a **Blazor WebAssembly App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vsc), the [Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project), or the [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension.

{% endtabcontent %}

{% tabcontent .NET CLI %}

Run the following command to create a new Blazor WebAssembly App.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}

dotnet new blazorwasm -o BlazorApp

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

### Install the required Blazor packages

Install the [Syncfusion.Blazor.Maps](https://www.nuget.org/packages/Syncfusion.Blazor.Maps/) NuGet package. All Syncfusion Blazor packages are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for details.

{% tabcontents %}

{% tabcontent Visual Studio %}

1. Go to *Tools → NuGet Package Manager → Manage NuGet Packages for Solution*.
2. Search the required NuGet packages (`Syncfusion.Blazor.Maps`) and install it.

Alternatively, you can install the same package using the Package Manager Console with the following command.

{% tabs %}
{% highlight razor tabtitle="Package Manager Console" %}

Install-Package Syncfusion.Blazor.Maps -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Open the terminal and run the following command.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet add package Syncfusion.Blazor.Maps -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent .NET CLI %}

Open the command prompt and run the following command.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}

dotnet add package Syncfusion.Blazor.Maps -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

### Add import namespaces

After the package is installed, open the **~/_Imports.razor** file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Maps` namespaces.

N> The `~/` notation represents the root directory of your project. This file is typically located in your project's root folder.

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Maps

{% endhighlight %}
{% endtabs %}

### Register the Blazor service

Open the **Program.cs** file in Blazor WebAssembly App and register the Blazor service.

{% tabs %}
{% highlight C# tabtitle="Program.cs" %}

....
using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor();
....

{% endhighlight %}
{% endtabs %}

### Add script resources

The script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the [script references](https://blazor.syncfusion.com/documentation/common/adding-script-references) in the **~wwwroot/index.html** file.

{% tabs %}
{% highlight html tabtitle="index.html" %}

<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

{% endhighlight %}
{% endtabs %}

N> Check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in the Blazor application.

### Add Blazor Maps component with GeoJSON data

Open a Razor file located in the **~/Pages/*Index.razor** and add the [Blazor Maps](https://www.syncfusion.com/blazor-components/blazor-map) component inside the razor file. Bind GeoJSON data to the Maps to render any geometric shape in SVG (Scalable Vector Graphics) for powerful data visualization of shapes. You can use the [ShapeData](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer-1.html#Syncfusion_Blazor_Maps_MapsLayer_1_ShapeData) property in [MapsLayer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer-1.html) to load the GeoJSON shape data into the Maps component.

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

**Run the application**

{% tabcontents %}

{% tabcontent Visual Studio %}

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. The Blazor Maps component will render in your default web browser.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Open the terminal and run the following command.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet run

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent .NET CLI %}

Open the command prompt and run the following command.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}

dotnet run

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZBzNsUjWcevzcvR?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Maps with GeoJSON Layer](./images/blazor-map.webp)" %}

N> The "world-map.json" file contains the World map GeoJSON data.

### Bind data source

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

N> Please [refer to the section](populate-data#data-binding) for more information on data binding.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

<SfMaps>
    <MapsLayers>
        @*To map shape data name field and data source field*@
        <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}'
                   ShapePropertyPath='new string[] {"name"}'
                   DataSource="SecurityCouncilDetails"
                   ShapeDataPath="Name" TValue="UNCouncilCountry">
        </MapsLayer>
    </MapsLayers>
</SfMaps>

{% endhighlight %}
{% endtabs %}

N> For example, consider field names specified in [ShapePropertyPath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer-1.html#Syncfusion_Blazor_Maps_MapsLayer_1_ShapePropertyPath) and [ShapeDataPath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsLayer-1.html#Syncfusion_Blazor_Maps_MapsLayer_1_ShapeDataPath) have the same value: **"United States"**. So corresponding color, data label and tooltip related settings will be applied to the **United States** shape.

The following complete example shows a Maps component with the GeoJSON layer and data source binding:

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.Maps

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

### See also

* [Getting Started with Blazor for WebAssembly application in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app)

* [Getting Started with Blazor for server-side application in Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)

* [Getting Started with Blazor for server-side application in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app)