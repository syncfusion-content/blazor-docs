---
layout: post
title: Getting Started with MultiSelect Dropdown in MAUI App | Syncfusion®
description: Check out and learn about the documentation for getting started with Blazor MultiSelect Dropdown Component in Blazor MAUI App and much more details.
platform: Blazor
component: MultiSelect Dropdown
documentation: ug
---

# Getting Started with Blazor MultiSelect Dropdown in Blazor MAUI App

This guide walks through integrating the [Blazor MultiSelect Dropdown](https://www.syncfusion.com/blazor-components/blazor-multiselect-dropdown) component in a Blazor MAUI App using [Visual Studio](https://visualstudio.microsoft.com/vs/), [Visual Studio Code](https://code.visualstudio.com/), and the [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/).

## Create a new Blazor MAUI App

{% tabcontents %}

{% tabcontent Visual Studio %}

Create a Blazor MAUI App using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/dotnet/maui/get-started/first-app?pivots=devices-windows&view=net-maui-9.0&tabs=vswin). For detailed instructions, refer to the [Blazor MAUI App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/maui-blazor-app) documentation.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Run the following command to create a new Blazor MAUI App.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet new maui-blazor -o MauiBlazorApp
cd MauiBlazorApp

{% endhighlight %}
{% endtabs %}

Alternatively, create a **Blazor MAUI App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/dotnet/maui/get-started/first-app?pivots=devices-windows&view=net-maui-9.0&tabs=visual-studio-code) or the [Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project). For detailed instructions, refer to the [Blazor MAUI App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/maui-blazor-app) documentation.

{% endtabcontent %}

{% tabcontent .NET CLI %}

Run the following command to create a new Blazor MAUI App.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}

dotnet new maui-blazor -o MauiBlazorApp
cd MauiBlazorApp

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

## Install the required Blazor packages

Install [Syncfusion.Blazor.DropDowns](https://www.nuget.org/packages/Syncfusion.Blazor.DropDowns/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet packages. All Syncfusion Blazor packages are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for details.

{% tabcontents %}

{% tabcontent Visual Studio %}

1. Go to *Tools → NuGet Package Manager → Manage NuGet Packages for Solution*.
2. Search the required NuGet packages (`Syncfusion.Blazor.DropDowns` and `Syncfusion.Blazor.Themes`) and install them.

Alternatively, you can install the same packages using the Package Manager Console with the following commands.

{% tabs %}
{% highlight razor tabtitle="Package Manager Console" %}

Install-Package Syncfusion.Blazor.DropDowns -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Open the terminal and run the following commands.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet add package Syncfusion.Blazor.DropDowns -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent .NET CLI %}

Open the command prompt and run the following commands.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}

dotnet add package Syncfusion.Blazor.DropDowns -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

## Add import namespaces

After the packages are installed, open the **~/Components/_Imports.razor** file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.DropDowns` namespaces.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor 
@using Syncfusion.Blazor.DropDowns

{% endhighlight %}
{% endtabs %}

## Register the Blazor service

Open the **MauiProgram.cs** file in Blazor MAUI App and register the Blazor service.

{% tabs %}
{% highlight c# tabtitle="MauiProgram.cs" %}

....
using Syncfusion.Blazor;

....

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        ....
        builder.Services.AddSyncfusionBlazor();
        ....
    }
}

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the [stylesheet](https://blazor.syncfusion.com/documentation/appearance/themes) and [script references](https://blazor.syncfusion.com/documentation/common/adding-script-references) in the **~wwwroot/index.html** file.

{% tabs %}
{% highlight html tabtitle="index.html" %}

...
<link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
...
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

{% endhighlight %}
{% endtabs %}

## Add Blazor MultiSelect Dropdown component

Open a Razor file located in the **~/Components/Pages/*.razor** (for example, **Home.razor**) and add the [Blazor MultiSelect Dropdown](https://www.syncfusion.com/blazor-components/blazor-multiselect-dropdown) component inside the razor file.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

<SfMultiSelect TValue="string[]" TItem="string" Placeholder='First Name'></SfMultiSelect>

{% endhighlight %}
{% endtabs %}

## Run the application on Windows

{% tabcontents %}

{% tabcontent Visual Studio %}

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. The Blazor MultiSelect Dropdown component will render in your default web browser.

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

![Blazor MultiSelect Dropdown Component](./images/blazor-multiselect-dropdown-maui-app.webp)

## Run the application on Android

To run the Blazor MultiSelect Dropdown in your Blazor MAUI app on an Android emulator, follow the steps below.

1. Set up and start the Android emulator. For help, see the [Android Device Manager guide](https://learn.microsoft.com/en-us/dotnet/maui/android/emulator/device-manager#android-device-manager-on-windows).

2. Run your app using the emulator to view the MultiSelect Dropdown.

N> If you face any issues with the Android emulator, check the [Troubleshooting Android Emulator guide](https://learn.microsoft.com/en-us/dotnet/maui/android/emulator/troubleshooting) for solutions.

![Blazor MultiSelect Dropdown Component](./images/blazing-fast-multiselect-dropdown-blazor.webp)

## Binding data source

After initialization, populate the MultiSelect using the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_DataSource) property. In the following example, a list of objects is bound to the component and `TItem` specifies the data type. Display and value fields are mapped via `MultiSelectFieldSettings`.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

<SfMultiSelect TValue="string[]" TItem="Games" Placeholder="Favorite Sports" DataSource="@LocalData">
    <MultiSelectFieldSettings Text="Text" Value="ID"></MultiSelectFieldSettings>
</SfMultiSelect>

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
    new Games() { ID= "Game8", Text= "Rugby" },
    new Games() { ID= "Game9", Text= "Snooker" },
    new Games() { ID= "Game10", Text= "Tennis" },
    };
}

{% endhighlight %}
{% endtabs %}

![Data Binding in Blazor MultiSelect Dropdown](./images/blazing-fast-multiselect-dropdown-data-binding.webp)

## Configure the popup list

By default, the width of the popup list automatically adjusts according to the MultiSelect input element's width, and the height auto adjust's according to the height of the popup list items.

The height and width of the popup list can also be customized using the [PopupHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_PopupHeight) and [PopupWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_PopupWidth) properties respectively.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

<SfMultiSelect TValue="string[]" TItem="Games" Placeholder="Favorite Sports" PopupHeight="350px" PopupWidth="350px" DataSource="@LocalData">
    <MultiSelectFieldSettings Text="Text" Value="ID"></MultiSelectFieldSettings>
</SfMultiSelect>

{% endhighlight %}
{% endtabs %}

![Configuring Popup List in Blazor MultiSelect Dropdown](./images/blazor-multiselect-dropdown-configure-poup-list.webp)

## Get selected value

Get the selected value of the MultiSelect component in the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectEvents-2.html#Syncfusion_Blazor_DropDowns_MultiSelectEvents_2_ValueChange) event using the [ChangeEventArgs.Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MultiSelectChangeEventArgs-1.html#Syncfusion_Blazor_DropDowns_MultiSelectChangeEventArgs_1_Value) property.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

{% include_relative code-snippet/getting-started/get-selected-value.razor %}

{% endhighlight %}
{% endtabs %}

## See also

1. [Getting Started with Blazor WebAssembly Standalone App](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app)
2. [Getting Started with Blazor Web App](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app)
3. [Getting Started with Blazor Server App](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)
4. [Data Binding in Blazor MultiSelect Dropdown Component](https://blazor.syncfusion.com/documentation/multiselect-dropdown/data-binding)
5. [Virtualization in Blazor MultiSelect Dropdown Component](https://blazor.syncfusion.com/documentation/multiselect-dropdown/virtualization)