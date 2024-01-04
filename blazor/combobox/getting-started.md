---
layout: post
title: Getting Started with Blazor ComboBox Component | Syncfusion
description: Checkout and learn about getting started with Blazor ComboBox component in Blazor Sever App and Blazor WebAssembly App.
platform: Blazor
control: ComboBox
documentation: ug
---

# Getting Started with Blazor ComboBox Component

This section briefly explains about how to include [Blazor ComboBox](https://www.syncfusion.com/blazor-components/blazor-combobox) component in your Blazor Server App and Blazor WebAssembly App using Visual Studio.

To get started quickly with Blazor ComboBox component, you can check out this video or [GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/ComboBox) sample.

{% youtube
"youtube:https://www.youtube.com/watch?v=VYK2xHC_Lrg"%}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio

You can create a **Blazor Server App** or **Blazor WebAssembly App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-7.0) or the [Syncfusion Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

## Install Syncfusion Blazor DropDowns and Themes NuGet in the App

To add **Blazor ComboBox** component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search and install [Syncfusion.Blazor.DropDowns](https://www.nuget.org/packages/Syncfusion.Blazor.DropDowns) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/). Alternatively, you can utilize the following package manager command to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.DropDowns -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

## Register Syncfusion Blazor Service

Open **~/_Imports.razor** file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.DropDowns` namespace.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.DropDowns

{% endhighlight %}
{% endtabs %}

Now, register the Syncfusion Blazor Service in the **~/Program.cs** file of your Blazor Server App or Blazor WebAssembly App.

{% tabs %}
{% highlight C# tabtitle="Blazor Server App" hl_lines="3 10" %}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
....

{% endhighlight %}
{% highlight C# tabtitle="Blazor WebAssembly App" hl_lines="3 11" %}

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

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Reference the stylesheet and script in the `<head>` of the main page as follows:

* For **.NET 6** Blazor Server app, include it in **~/Pages/_Layout.cshtml** file.

* For **.NET 7** Blazor Server app, include it in the **~/Pages/_Host.cshtml** file.

* For Blazor WebAssembly app, include it in the **~/index.html** file.

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>
```
N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in your Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in your Blazor application.

## Add Blazor ComboBox component

Add the Syncfusion Blazor ComboBox component in the **~/Pages/Index.razor** file.

{% tabs %}
{% highlight razor %}

<SfComboBox TValue="string" TItem="string" Placeholder="Select a game"></SfComboBox>

{% endhighlight %}
{% endtabs %}

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This will render the Syncfusion Blazor ComboBox component in your default web browser.

![Blazor ComboBox Component](./images/blazor-combobox-component.png)

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

![Blazor ComboBox with Data Binding](./images/blazor-combobox-data-binding.png)

## Custom values

The ComboBox allows the users to give input as custom value, which is not required to present in predefined set of values. By default, this support is enabled by [AllowCustom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfComboBox-2.html#Syncfusion_Blazor_DropDowns_SfComboBox_2_AllowCustom) property. In this case, both text field and value field are considered as same. The custom value will be sent to post back handler when a form is about to be submitted.

{% tabs %}
{% highlight razor %}

<SfComboBox TValue="string"  TItem="Games" AllowCustom=true Placeholder="Select a game" DataSource="@LocalData">
    <ComboBoxFieldSettings Value="ID" Text="Text"></ComboBoxFieldSettings>
</SfComboBox>

{% endhighlight %}
{% endtabs %}

![Blazor ComboBox with Custom Values](./images/blazor-combobox-custom-values.png)

## Configure the popup list

By default, the width of the popup list automatically adjusts according to the ComboBox input element's width, and the height of the popup list has `350px`. The height and width of the popup list can also be customized using the [PopupHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfComboBox-2.html) and [PopupWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfComboBox-2.html) properties respectively.

{% tabs %}
{% highlight razor %}

<SfComboBox TValue="string" TItem="Games"PopupHeight="350px" PopupWidth="350px" Placeholder="Select a game" DataSource="@LocalData">
    <ComboBoxFieldSettings Value="ID" Text="Text"></ComboBoxFieldSettings>
</SfComboBox>

{% endhighlight %}
{% endtabs %}

![Customizing Popup Height and Width in Blazor ComboBox](./images/blazor-combobox-popup-customization.png)

## See also

* [Getting Started with Syncfusion Blazor for Client-Side in .NET Core CLI](../getting-started/blazor-webassembly-dotnet-cli)
* [Getting Started with Syncfusion Blazor for Server-side in Visual Studio](../getting-started/blazor-server-side-visual-studio)
* [Getting Started with Syncfusion Blazor for Server-Side in .NET Core CLI](../getting-started/blazor-server-side-dotnet-cli)
