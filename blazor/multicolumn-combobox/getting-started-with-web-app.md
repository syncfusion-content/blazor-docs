---
layout: post
title: Getting Started with Syncfusion Blazor MultiColumn ComboBox in WebApp
description: Checkout and learn here all about the documentation for getting started with Blazor MultiColumn ComboBox component in Blazor Web App.
platform: Blazor
control: MultiColumn ComboBox
documentation: ug
---

# Getting Started with Blazor MultiColumn ComboBox Component in Web App

This section explains how to include the [Blazor MultiColumn ComboBox](https://www.syncfusion.com/blazor-components/blazor-multicolumn-combobox) in a Blazor Web App using [Visual Studio](https://visualstudio.microsoft.com/vs/) and Visual Studio Code.

To get started quickly with the Blazor MultiColumn ComboBox, see the following video:

{% youtube "https://www.youtube.com/watch?v=2B5ctnHw4vk" %}

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App in Visual Studio

Create a **Blazor Web App** using Visual Studio 2022 via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vs) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

Configure the appropriate [interactive render mode](https://learn.microsoft.com/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) and [interactivity location](https://learn.microsoft.com/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vs) when creating the Blazor Web App.

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor MultiColumn ComboBox and Themes NuGet in the Blazor Web App

To add the Blazor MultiColumn ComboBox, open NuGet Package Manager in Visual Studio (Tools → NuGet Package Manager → Manage NuGet Packages for Solution), then search for and install [Syncfusion.Blazor.MultiColumnComboBox](https://www.nuget.org/packages/Syncfusion.Blazor.MultiColumnComboBox/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/).

If using the WebAssembly or Auto render modes in a Blazor Web App, install the Syncfusion Blazor component NuGet packages in the client project.

Alternatively, run the following Package Manager commands:

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.MultiColumnComboBox -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the full package list and component details.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App in Visual Studio Code

Create a **Blazor Web App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project).

Configure the appropriate [interactive render mode](https://learn.microsoft.com/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) and [interactivity location](https://learn.microsoft.com/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vsc) when creating the Blazor Web App.

For example, in a Blazor Web App with the Auto interactive render mode, use the following commands:

{% tabs %}
{% highlight c# tabtitle="Blazor Web App" %}

dotnet new blazor -o BlazorWebApp -int Auto
cd BlazorWebApp
cd BlazorWebApp.Client

{% endhighlight %}
{% endtabs %}

N> For details on creating a Blazor Web App with various interactive modes and locations, see the [render interactive modes](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=visual-studio-code#render-interactive-modes) section.

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor MultiColumn ComboBox and Themes NuGet in the App

If using WebAssembly or Auto render modes in a Blazor Web App, install the Syncfusion Blazor component NuGet packages in the client project.

* Press <kbd>Ctrl</kbd>+<kbd>`</kbd> to open the integrated terminal in Visual Studio Code.
* Ensure the current directory contains the target `.csproj`.
* Run the following commands to install [Syncfusion.Blazor.MultiColumnComboBox](https://www.nuget.org/packages/Syncfusion.Blazor.MultiColumnComboBox) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/), then restore packages.

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.MultiColumnComboBox -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}

{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the full package list and component details.

{% endtabcontent %}

{% endtabcontents %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

| Interactive Render Mode | Description |
| -- | -- |
| WebAssembly or Auto | Open the ~/_Imports.razor file in the client project. |
| Server | Open the ~/_Imports.razor file located in the Components folder. |

Import the `Syncfusion.Blazor` and `Syncfusion.Blazor.MultiColumnComboBox` namespaces.

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.MultiColumnComboBox

{% endhighlight %}
{% endtabs %}

Now, register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in the **~/Program.cs** file(s) of the Blazor Web App. If the interactive render mode is set to WebAssembly or Auto, register services in both the server and client Program.cs files. Ensure the Syncfusion license is registered early in Program.cs using the provided license key to avoid runtime license warnings.

{% tabs %}
{% highlight c# tabtitle="Server(~/_Program.cs)" hl_lines="3 11" %}

...
...
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
....

{% endhighlight %}
{% highlight c# tabtitle="Client(~/_Program.cs)" hl_lines="2 5" %}

...
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSyncfusionBlazor();

await builder.Build().RunAsync();

{% endhighlight %}
{% endtabs %}

If the interactive render mode is set to Server, the project contains a single **~/Program.cs** file. In this case, register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service only in that file.

{% tabs %}
{% highlight c# tabtitle="~/_Program.cs" hl_lines="2 9" %}

...
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
....

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

Access the theme stylesheet and script from NuGet via [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Add the stylesheet reference in the `<head>` section and the script reference at the end of the `<body>` in the **~/Components/App.razor** file:

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>
....
<body>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```

N> See [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) for theme reference options ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)). For script reference options, see [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references).

## Add Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor MultiColumn ComboBox component

Add the Syncfusion Blazor MultiColumn ComboBox component to a `.razor` file under the `Pages` folder. When the interactivity location is Per page/component, define a render mode at the top of the component as shown:

| Interactivity location | RenderMode | Code |
| --- | --- | --- |
| Per page/component | Auto | @rendermode InteractiveAuto |
|  | WebAssembly | @rendermode InteractiveWebAssembly |
|  | Server | @rendermode InteractiveServer |
|  | None | --- |

N> If the Interactivity Location is set to Global and the Render Mode is Auto, WebAssembly, or Server, the render mode is configured in the `App.razor` file by default.

{% tabs %}
{% highlight razor %}

@* desired render mode define here *@
@rendermode InteractiveAuto

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight razor %}

<SfMultiColumnComboBox TItem="string" TValue="string" Placeholder="Select any product"></SfMultiColumnComboBox>

{% endhighlight %}
{% endtabs %}

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This renders the Syncfusion Blazor MultiColumn ComboBox component in the default web browser.

{% previewsample "https://blazorplayground.syncfusion.com/embed/hthpNuiEUXUBXNYa?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor MultiColumn ComboBox Component](./images/blazor-multicolumncombobox-component.png)" %}

## Binding Data Source and Mapping Fields

After initialization, populate the MultiColumn ComboBox using the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_DataSource) property. In this example, the component binds to a `Products` list with multiple fields. The [ValueField](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_ValueField) and [TextField](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_TextField) are both mapped to the `Name` property so product names are displayed. The [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html) attribute binds the selected value, with an initial value of “Smartphone” preselected in this example.

{% tabs %}
{% highlight razor %}

<SfMultiColumnComboBox @bind-Value="@Value" DataSource="@Products" ValueField="Name" TextField="Name" Placeholder="Select any product"></SfMultiColumnComboBox>

@code {
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Availability { get; set; }
        public string Category { get; set; }
        public double Rating { get; set; }
    }
    private List<Product> Products = new List<Product>();
    private string Value { get; set; } = "Smartphone";
    protected override Task OnInitializedAsync()
    {
        Products = new List<Product>
        {
            new Product { Name = "Laptop", Price = 999.99m, Availability = "In Stock", Category = "Electronics", Rating = 4.5 },
            new Product { Name = "Smartphone", Price = 599.99m, Availability = "Out of Stock", Category = "Electronics", Rating = 4.3 },
            new Product { Name = "Tablet", Price = 299.99m, Availability = "In Stock", Category = "Electronics", Rating = 4.2 },
            new Product { Name = "Headphones", Price = 49.99m, Availability = "In Stock", Category = "Accessories", Rating = 4.0 }
        };
        return base.OnInitializedAsync();
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNBJDEWkAXYkTeMy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor MultiColumn ComboBox with Data Binding](./images/blazor-multicolumncombobox-binding-data.png)" %}

## Configuring the Columns

The MultiColumn ComboBox supports auto-generating columns from the data source. You can also customize the column header text, adjust [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.MultiColumnComboboxColumn.html#Syncfusion_Blazor_MultiColumnComboBox_MultiColumnComboboxColumn_Width) for optimal display, and set [TextAlign](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.MultiColumnComboboxColumn.html#Syncfusion_Blazor_MultiColumnComboBox_MultiColumnComboboxColumn_TextAlign) (left, center, or right) to enhance readability.

{% tabs %}
{% highlight razor %}

 <SfMultiColumnComboBox @bind-Value="@Value" DataSource="@Products" PopupWidth="600px" ValueField="Name" TextField="Name" Placeholder="Select any product">
     <MultiColumnComboboxColumns>
         <MultiColumnComboboxColumn Field="Name" Width="200px" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Center"></MultiColumnComboboxColumn>
         <MultiColumnComboboxColumn Field="Price" Width="200px" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Center"></MultiColumnComboboxColumn>
         <MultiColumnComboboxColumn Field="Availability" Width="200px" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Center"></MultiColumnComboboxColumn>
     </MultiColumnComboboxColumns>
 </SfMultiColumnComboBox>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rthptYsEgssKVDPs?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor MultiColumn ComboBox with Data Binding](./images/blazor-multicolumncombobox-columns.png)" %}

## Configuring the popup list

By default, the popup list width matches the input element width, and the height is `350px`. Customize the popup height and width using [PopupHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_PopupHeight) and [PopupWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_PopupWidth).

{% tabs %}
{% highlight razor %}

<SfMultiColumnComboBox @bind-Value="@Value" DataSource="@Products" PopupHeight="350px" PopupWidth="400px" ValueField="Name" TextField="Name" Placeholder="Select any product"></SfMultiColumnComboBox>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXhJjECYAMdTnsmm?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Customizing Popup Height and Width in Blazor MultiColumn ComboBox](./images/blazor-multicolumncombobox-popup-customization.png)" %}

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/MultiColumnComboBox).

## See also

1. [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for client-side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-dotnet-cli)
2. [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for client-side in Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-visual-studio)
3. [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for server-side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-dotnet-cli)