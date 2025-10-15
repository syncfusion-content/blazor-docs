---
layout: post
title: Getting Started with Syncfusion Blazor MultiColumn ComboBox
description: Checkout and learn about getting started with Blazor MultiColumn ComboBox component in Blazor WebAssembly Application.
platform: Blazor
control: MultiColumn ComboBox
documentation: ug
---

# Getting Started with Blazor MultiColumn ComboBox Component

This guide explains how to include the [Blazor MultiColumn ComboBox](https://www.syncfusion.com/blazor-components/blazor-multicolumn-combobox) component in a Blazor WebAssembly app using Visual Studio and Visual Studio Code.

To get started quickly with the Blazor MultiColumn ComboBox component, watch the following video or explore the [GitHub sample](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/MultiColumnComboBox).

{% youtube "https://www.youtube.com/watch?v=2B5ctnHw4vk" %}

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio

Create a **Blazor WebAssembly App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-7.0&pivots=vs) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor MultiColumnComboBox and Themes NuGet in the App

To add the Blazor MultiColumn ComboBox component, open NuGet Package Manager in Visual Studio (Tools → NuGet Package Manager → Manage NuGet Packages for Solution), then search for and install [Syncfusion.Blazor.MultiColumnComboBox](https://www.nuget.org/packages/Syncfusion.Blazor.MultiColumnComboBox) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/). Alternatively, run the following Package Manager commands:

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.MultiColumnComboBox -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the list of available packages and component details.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio Code

Create a **Blazor WebAssembly App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-7.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project).

Alternatively, create a WebAssembly application using the following command in the terminal (<kbd>Ctrl</kbd>+<kbd>`</kbd>).

{% tabs %}

{% highlight c# tabtitle="Blazor WASM App" %}

dotnet new blazorwasm -o BlazorApp
cd BlazorApp

{% endhighlight %}

{% endtabs %}

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor MultiColumnComboBox and Themes NuGet in the App

- Press <kbd>Ctrl</kbd>+<kbd>`</kbd> to open the integrated terminal in Visual Studio Code.
- Ensure the current directory contains the project `.csproj` file.
- Run the following commands to install [Syncfusion.Blazor.MultiColumnComboBox](https://www.nuget.org/packages/Syncfusion.Blazor.MultiColumnComboBox) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) and restore packages.

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.MultiColumnComboBox -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}

{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the list of available packages and component details.

{% endtabcontent %}

{% endtabcontents %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

Open **~/_Imports.razor** and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.MultiColumnComboBox` namespaces.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.MultiColumnComboBox

{% endhighlight %}
{% endtabs %}

Now register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in **~/Program.cs** for the Blazor WebAssembly app.

{% tabs %}
{% highlight C# tabtitle="~/Program.cs" hl_lines="3 11" %}

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSyncfusionBlazor();
await builder.Build().RunAsync();
....

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

Access the theme stylesheet and script from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Add the stylesheet and script references in the `<head>` section of **~/index.html**.

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>
```
N> See [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) to learn different ways to reference themes ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)). For script reference options, see [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references).

## Add Blazor MultiColumn ComboBox component

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor MultiColumn ComboBox component in **~/Pages/Index.razor**.

{% tabs %}
{% highlight razor %}

<SfMultiColumnComboBox TItem="string" TValue="string" Placeholder="Select any product"></SfMultiColumnComboBox>

{% endhighlight %}
{% endtabs %}

- Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This renders the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor MultiColumn ComboBox component in the default web browser.

{% previewsample "https://blazorplayground.syncfusion.com/embed/hthpNuiEUXUBXNYa?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor MultiColumn ComboBox Component](./images/blazor-multicolumncombobox-component.png)" %}

## Binding Data Source and Mapping Fields

After initialization, populate the MultiColumn ComboBox using the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_DataSource) property. In this example, the component binds its DataSource to a `Products` list with multiple fields. Both the [ValueField](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_ValueField) and [TextField](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_TextField) properties are set to the `Name` property of the `Product` class so product names are displayed in the dropdown. The [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html) attribute binds the selected value, with an initial value of "Smartphone" preselected in this example.

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

The MultiColumn ComboBox supports auto-generating columns, which automatically creates columns based on the data source. You can also customize the column header text to reflect specific data, adjust [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.MultiColumnComboboxColumn.html#Syncfusion_Blazor_MultiColumnComboBox_MultiColumnComboboxColumn_Width) for optimal display, and set [TextAlign](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.MultiColumnComboboxColumn.html#Syncfusion_Blazor_MultiColumnComboBox_MultiColumnComboboxColumn_TextAlign) (left, center, or right) to enhance readability.

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

By default, the popup list automatically matches the width of the MultiColumn ComboBox input element, and the height is set to `350px`. Customize both using the [PopupHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_PopupHeight) and [PopupWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_PopupWidth) properties.

{% tabs %}
{% highlight razor %}

<SfMultiColumnComboBox @bind-Value="@Value" DataSource="@Products" PopupHeight="350px" PopupWidth="400px" ValueField="Name" TextField="Name" Placeholder="Select any product"></SfMultiColumnComboBox>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXhJjECYAMdTnsmm?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Customizing Popup Height and Width in Blazor MultiColumn ComboBox](./images/blazor-multicolumncombobox-popup-customization.png)" %}

## See also

* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for Client-Side in .NET Core CLI](../getting-started/blazor-webassembly-dotnet-cli)
* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for Server-side in Visual Studio](../getting-started/blazor-server-side-visual-studio)
* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for Server-Side in .NET Core CLI](../getting-started/blazor-server-side-dotnet-cli)