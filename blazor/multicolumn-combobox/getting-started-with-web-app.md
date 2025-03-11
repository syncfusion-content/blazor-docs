---
layout: post
title: Getting Started with Syncfusion Blazor MultiColumn ComboBox in WebApp
description: Checkout and learn here all about the documentation for getting started with Blazor MultiColumn ComboBox component in Blazor Web App.
platform: Blazor
component: MultiColumn ComboBox
documentation: ug
---

# Getting Started with Blazor MultiColumn ComboBox Component in Web App

This section briefly explains about how to include [Blazor MultiColumn ComboBox](https://www.syncfusion.com/blazor-components/blazor-multicolumn-combobox) component in your Blazor Web App using [Visual Studio](https://visualstudio.microsoft.com/vs/) and Visual Studio Code.


To get started quickly with Blazor MultiColumn ComboBox component, you can check the video below.

{% youtube "https://www.youtube.com/watch?v=2B5ctnHw4vk" %}

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App in Visual Studio

You can create a **Blazor Web App** using Visual Studio 2022 via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

You need to configure the corresponding [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=windows) while creating a Blazor Web Application.

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor MultiColumnComboBox and Themes NuGet in the Blazor Web App

To add **Blazor MultiColumn ComboBox** component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search and install [Syncfusion.Blazor.MultiColumnComboBox](https://www.nuget.org/packages/Syncfusion.Blazor.MultiColumnComboBox/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/).

If you utilize `WebAssembly or Auto` render modes in the Blazor Web App need to be install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components NuGet packages within the client project.

Alternatively, you can utilize the following package manager command to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.MultiColumnComboBox -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App in Visual Studio Code

You can create a **Blazor Web App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project).

You need to configure the corresponding [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vsc) while creating a Blazor Web Application.

For example, in a Blazor Web App with the `Auto` interactive render mode, use the following commands.

{% tabs %}
{% highlight c# tabtitle="Blazor Web App" %}

dotnet new blazor -o BlazorWebApp -int Auto
cd BlazorWebApp
cd BlazorWebApp.Client

{% endhighlight %}
{% endtabs %}

N> For more information on creating a **Blazor Web App** with various interactive modes and locations, refer to this [link](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=visual-studio-code#render-interactive-modes).

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor MultiColumnComboBox and Themes NuGet in the App

If you utilize `WebAssembly` or `Auto` render modes in the Blazor Web App need to be install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components NuGet packages within the client project.

* Press <kbd>Ctrl</kbd>+<kbd>`</kbd> to open the integrated terminal in Visual Studio Code.
* Ensure you’re in the project root directory where your `.csproj` file is located.
* Run the following command to install a [Syncfusion.Blazor.MultiColumnComboBox](https://www.nuget.org/packages/Syncfusion.Blazor.MultiColumnComboBox) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet package and ensure all dependencies are installed.

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.MultiColumnComboBox -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}

{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

{% endtabcontent %}

{% endtabcontents %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

| Interactive Render Mode | Description |
| -- | -- |
| WebAssembly or Auto | Open **~/_Imports.razor** file from the client project.|
| Server | Open **~/_import.razor** file, which is located in the `Components` folder.|

Import the `Syncfusion.Blazor` and `Syncfusion.Blazor.MultiColumnComboBox` namespace.

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.MultiColumnComboBox

{% endhighlight %}
{% endtabs %}

Now, register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service in the **~/Program.cs** file of your Blazor Web App.

If the **Interactive Render Mode** is set to `WebAssembly` or `Auto`, you need to register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in both **~/Program.cs** files of your Blazor Web App.

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

If the **Interactive Render Mode** is set to `Server`, your project will contain a single **~/Program.cs** file. So, you should register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service only in that **~/Program.cs** file.

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

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the stylesheet reference in the `<head>` section and the script reference at the end of the `<body>` in the **~/Components/App.razor** file as shown below:

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

N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in your Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in your Blazor application.

## Add Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor MultiColumn ComboBox component

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor MultiColumn ComboBox component in `.razor` file inside the `Pages` folder. If an interactivity location as `Per page/component` in the web app, define a render mode at top of the component, as follows:

| Interactivity location | RenderMode | Code |
| --- | --- | --- |
| Per page/component | Auto | @rendermode InteractiveAuto |
|  | WebAssembly | @rendermode InteractiveWebAssembly |
|  | Server | @rendermode InteractiveServer |
|  | None | --- |

N> If an **Interactivity Location** is set to `Global` and the **Render Mode** is set to `Auto` or `WebAssembly` or `Server`, the render mode is configured in the `App.razor` file by default.

{% tabs %}
{% highlight razor %}

@* desired render mode define here *@
@rendermode InteractiveAuto

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight razor %}

<SfMultiColumnComboBox TItem="string" TValue="string" Placeholder="Select a game"></SfMultiColumnComboBox>

{% endhighlight %}
{% endtabs %}

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This will render the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor MultiColumn ComboBox component in your default web browser.

{% previewsample "https://blazorplayground.syncfusion.com/embed/hthpNuiEUXUBXNYa?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor MultiColumn ComboBox Component](./images/blazor-multicolumncombobox-component.png)" %}

## Binding Data Source and Mapping Fields

After initialization, populate the MultiColumn ComboBox with data using the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_DataSource) property. In this case, the MultiColumn ComboBox binds its DataSource to the Products list, which contains multiple product columns. Both the [ValueField](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_ValueField) and [TextField](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_TextField) properties are set to the Name property of the Product class, ensuring that product names are displayed in the dropdown. The [@bind-Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html) is used to bind the selected value, with an initial value of "Smart phone" pre-selected in this example.

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

The MultiColumn ComboBox supports auto-generating columns, which simplifies the process by automatically creating columns based on the data source. Additionally, you can customize the column header text to reflect specific data, adjust the column [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.MultiColumnComboboxColumn.html#Syncfusion_Blazor_MultiColumnComboBox_MultiColumnComboboxColumn_Width) for optimal display, and set the [TextAlign](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.MultiColumnComboboxColumn.html#Syncfusion_Blazor_MultiColumnComboBox_MultiColumnComboboxColumn_TextAlign) (left, center, or right) to enhance readability.

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

By default, the width of the popup list automatically adjusts to match the width of the MultiColumn ComboBox input element, and the height is set to `350px`. Both the height and width of the popup list can be customized using the [PopupHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_PopupHeight) and [PopupWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.SfMultiColumnComboBox-2.html#Syncfusion_Blazor_MultiColumnComboBox_SfMultiColumnComboBox_2_PopupWidth) properties, respectively.

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

