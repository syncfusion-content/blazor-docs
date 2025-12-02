---
layout: post
title: Getting Started with Web App in Blazor ComboBox | Syncfusion
description: Checkout and learn here all about the documentation for getting started with Blazor ComboBox component in Blazor Web App.
platform: Blazor
component: ComboBox
documentation: ug
---

# Getting Started with Blazor ComboBox Component in Web App

This section briefly explains about how to include [Blazor ComboBox](https://www.syncfusion.com/blazor-components/blazor-combobox) component in your Blazor Web App using [Visual Studio](https://visualstudio.microsoft.com/vs/), [Visual Studio Code](https://code.visualstudio.com/), and the [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/).

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App in Visual Studio

You can create a **Blazor Web App** using Visual Studio 2022 via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

Configure the appropriate [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-10.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) while creating a Blazor Web App.

![Create Blazor Web App](images/blazor-create-web-app.png)

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DropDowns and Themes NuGet in the Blazor Web App

To add the **Blazor ComboBox** component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), then search and install [Syncfusion.Blazor.DropDowns](https://www.nuget.org/packages/Syncfusion.Blazor.DropDowns/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/).

If using the `WebAssembly or Auto` render modes in the Blazor Web App, install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor component NuGet packages in the client project.

Alternatively, you can utilize the following package manager command to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.DropDowns -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the available NuGet packages list with component details.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App in Visual Studio Code

You can create a **Blazor Web App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project).

Configure the appropriate interactive render mode and interactivity location when setting up a Blazor Web App. For detailed information, refer to the [interactive render mode documentation](https://blazor.syncfusion.com/documentation/common/interactive-render-mode).

For example, in a Blazor Web App with the `Auto` interactive render mode, use the following commands.

{% tabs %}
{% highlight c# tabtitle="Blazor Web App" %}

dotnet new blazor -o BlazorWebApp -int Auto
cd BlazorWebApp
cd BlazorWebApp.Client

{% endhighlight %}
{% endtabs %}

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DropDowns and Themes NuGet in the App

If using the `WebAssembly` or `Auto` render modes in the Blazor Web App, install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor component NuGet packages in the client project.

* Press <kbd>Ctrl</kbd>+<kbd>`</kbd> to open the integrated terminal in Visual Studio Code.
* Ensure you’re in the project root directory where your `.csproj` file is located.
* Run the following command to install a [Syncfusion.Blazor.DropDowns](https://www.nuget.org/packages/Syncfusion.Blazor.DropDowns/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet package and ensure all dependencies are installed.

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.DropDowns -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}

{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the available NuGet packages list with component details.

{% endtabcontent %}

{% tabcontent .NET CLI %}

## Prerequisites

Latest version of the [.NET SDK](https://dotnet.microsoft.com/en-us/download). If you previously installed the SDK, you can determine the installed version by executing the following command in a command prompt (Windows) or terminal (macOS) or command shell (Linux).

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet --version

{% endhighlight %}
{% endtabs %}

## Create a Blazor Web App using .NET CLI

Run the following command to create a new Blazor Web App in a command prompt (Windows) or terminal (macOS) or command shell (Linux).

Configure the appropriate interactive render mode and interactivity location when setting up a Blazor Web Application. For detailed information, refer to the [interactive render mode documentation](https://blazor.syncfusion.com/documentation/common/interactive-render-mode).

For example, in a Blazor Web App with the `Auto` interactive render mode, use the following commands.

{% tabs %}
{% highlight c# tabtitle="Blazor Web App" %}

dotnet new blazor -o BlazorWebApp -int Auto
cd BlazorWebApp
cd BlazorWebApp.Client

{% endhighlight %}
{% endtabs %}

This command creates a new Blazor Web App and places it in a new directory called `BlazorWebApp` inside your current location. See the [Create a Blazor App](https://dotnet.microsoft.com/en-us/learn/aspnet/blazor-tutorial/create) and [dotnet new CLI command](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?pivots=cli&view=aspnetcore-10.0) topics for more details.

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DropDowns and Themes NuGet in the App

Here's an example of how to add the **Blazor ComboBox** component to the application by using the following commands in a command prompt (Windows), terminal (Linux and macOS), or PowerShell to install the [Syncfusion.Blazor.DropDowns](https://www.nuget.org/packages/Syncfusion.Blazor.DropDowns/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet packages. See [Install and manage packages using the dotnet CLI](https://learn.microsoft.com/en-us/nuget/consume-packages/install-use-packages-dotnet-cli) for more details.

If using the `WebAssembly` or `Auto` render modes in the Blazor Web App, install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor component NuGet packages in the client project.

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.DropDowns --version {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes --version {{ site.releaseversion }}
dotnet restore

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the available NuGet package list with component details.

{% endtabcontent %}

{% endtabcontents %}

## Add Import Namespaces

Open the **~/_Imports.razor** file in the client project and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.DropDowns` namespaces.

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.DropDowns

{% endhighlight %}
{% endtabs %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

Register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service in the **~/Program.cs** file of your Blazor Web App.

If the **Interactive Render Mode** is set to `WebAssembly` or `Auto`, register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in the **~/Program.cs** files of the main `server` project and associated `.Client` project.

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

## Add Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor ComboBox component

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor ComboBox component to a Razor page located under the Pages folder (e.g., Pages/Home.razor) in either the **Server** or **Client** project. If an interactivity location as `Per page/component` in the web app, define a render mode at top of the component, as follows:

| Interactivity location | RenderMode | Code |
| --- | --- | --- |
| Per page/component | Auto | @rendermode InteractiveAuto |
|  | WebAssembly | @rendermode InteractiveWebAssembly |
|  | None | --- |

N> If an **Interactivity Location** is set to `Global` and the **Render Mode** is set to `Auto` or `WebAssembly`, the render mode is configured in the `App.razor` file by default.

{% tabs %}
{% highlight razor %}

@* desired render mode define here *@
@rendermode InteractiveAuto

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight razor %}

<SfComboBox TValue="string" TItem="string" Placeholder="Select a game"></SfComboBox>

{% endhighlight %}
{% endtabs %}

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This will render the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor ComboBox component in the default web browser.

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtBpNiBuBWhiNjHa?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor ComboBox Component](./images/blazor-combobox-component.png)" %}

## Binding data source

After initializing, populate the ComboBox with data using the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_DataSource) property. Here, an array of string values is passed to the ComboBox component.

{% tabs %}
{% highlight razor %}

<SfComboBox TValue="string" TItem="Games" Placeholder="Select a game" DataSource="@LocalData">
    <ComboBoxFieldSettings Value="ID" Text="Text"></ComboBoxFieldSettings>
</SfComboBox>

@code {
  public class Games
  {
    public string ID { get; set; }
    public string Text { get; set; }
  }
  List<Games> LocalData = new List<Games> {
    new Games() { ID= "Game1", Text= "American Football" },
    new Games() { ID= "Game2", Text= "Badminton" },
    new Games() { ID= "Game3", Text= "Basketball" },
    new Games() { ID= "Game4", Text= "Cricket" },
    new Games() { ID= "Game5", Text= "Football" },
    new Games() { ID= "Game6", Text= "Golf" },
    new Games() { ID= "Game7", Text= "Hockey" },
    new Games() { ID= "Game8", Text= "Rugby"},
    new Games() { ID= "Game9", Text= "Snooker" },
    new Games() { ID= "Game10", Text= "Tennis"},
  };
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtBpjsLOhCBHPRgS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor ComboBox with Data Binding](./images/blazor-combobox-data-binding.png)" %}

## Custom values

The ComboBox allows the users to give input as custom value, which is not required to present in predefined set of values. By default, this support is enabled by [AllowCustom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfComboBox-2.html#Syncfusion_Blazor_DropDowns_SfComboBox_2_AllowCustom) property. In this case, both text field and value field are considered as same. The custom value will be sent to post back handler when a form is about to be submitted.

{% tabs %}
{% highlight razor %}

<SfComboBox TValue="string"  TItem="Games" AllowCustom=true Placeholder="Select a game" DataSource="@LocalData">
    <ComboBoxFieldSettings Value="ID" Text="Text"></ComboBoxFieldSettings>
</SfComboBox>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNVzXMVOrszHZiMo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor ComboBox with Custom Values](./images/blazor-combobox-custom-values.png)" %}

## Configure the popup list

By default, the width of the popup list automatically adjusts according to the ComboBox input element's width, and the height of the popup list has `350px`. The height and width of the popup list can also be customized using the [PopupHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfComboBox-2.html) and [PopupWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfComboBox-2.html) properties respectively.

{% tabs %}
{% highlight razor %}

<SfComboBox TValue="string" TItem="Games"PopupHeight="350px" PopupWidth="350px" Placeholder="Select a game" DataSource="@LocalData">
    <ComboBoxFieldSettings Value="ID" Text="Text"></ComboBoxFieldSettings>
</SfComboBox>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZBpXirahMIhXWui?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Customizing Popup Height and Width in Blazor ComboBox](./images/blazor-combobox-popup-customization.png)" %}

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/ComboBox).

## See also

1. [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for client-side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app)
2. [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for client-side in Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-visual-studio)
3. [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for server-side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app)

