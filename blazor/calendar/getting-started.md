---
layout: post
title: Getting Started with Blazor Calendar Component | Syncfusion
description: Checkout and learn about getting started with Blazor Calendar component in Blazor WebAssembly Application.
platform: Blazor
control: Calendar
documentation: ug
---

# Getting Started with Blazor Calendar Component

This guide shows how to add the [Blazor Calendar](https://www.syncfusion.com/blazor-components/blazor-calendar) component to a Blazor WebAssembly app using Visual Studio and Visual Studio Code. It targets modern .NET and Blazor WebAssembly tooling.

To get started quickly with the Blazor Calendar component, refer to the following video or the [GitHub sample](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/Calendar).

{% youtube
"youtube:https://www.youtube.com/watch?v=PbmIW_tWzVo"%}

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio

Create a **Blazor WebAssembly App** using Visual Studio via [Microsoft templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-7.0&pivots=vs) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Calendars and Themes NuGet in the App

To add the **Blazor Calendar** component, open the NuGet Package Manager in Visual Studio (Tools → NuGet Package Manager → Manage NuGet Packages for Solution), then search for and install [Syncfusion.Blazor.Calendars](https://www.nuget.org/packages/Syncfusion.Blazor.Calendars) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes). Alternatively, run the following Package Manager commands:

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Calendars -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for a list of available packages.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio Code

Create a **Blazor WebAssembly App** using Visual Studio Code via [Microsoft templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-7.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project).

Alternatively, create a WebAssembly application using the following commands in the terminal (<kbd>Ctrl</kbd>+<kbd>`</kbd>):

{% tabs %}

{% highlight c# tabtitle="Blazor WASM App" %}

dotnet new blazorwasm -o BlazorApp
cd BlazorApp

{% endhighlight %}

{% endtabs %}

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Calendars and Themes NuGet in the App

- Press <kbd>Ctrl</kbd>+<kbd>`</kbd> to open the integrated terminal in Visual Studio Code.
- Ensure you are in the project root directory where the `.csproj` file is located.
- Run the following commands to install [Syncfusion.Blazor.Calendars](https://www.nuget.org/packages/Syncfusion.Blazor.Calendars) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) and restore dependencies:

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.Calendars -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}

{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for a list of available packages.

{% endtabcontent %}

{% endtabcontents %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

Open **~/_Imports.razor** and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Calendars` namespaces.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Calendars

{% endhighlight %}
{% endtabs %}

Now register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in **~/Program.cs** for your Blazor WebAssembly app.

{% tabs %}
{% highlight C# tabtitle="~/Program.cs" hl_lines="3 11" %}

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(serviceProvider => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSyncfusionBlazor();
await builder.Build().RunAsync();
....

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

The theme stylesheet and script are provided via NuGet [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the stylesheet and script references in the `<head>` section of **~/index.html**:

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>
```
N> See [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) for available themes and reference methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)). For script options, see [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references).

## Add Blazor Calendar component

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Calendar component to **~/Pages/Index.razor**:

{% tabs %}
{% highlight razor %}

<SfCalendar TValue="DateTime"></SfCalendar>

{% endhighlight %}
{% endtabs %}

- Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Calendar component renders in your default web browser.

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDVpNsVIpTDiqybO?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Calendar Component](./images/blazor-calendar-component.png)" %}

## Setting the Value, Min, and Max dates

The Calendar component provides an option to select a date within a specified range by defining the [Min](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.CalendarBase-1.html#Syncfusion_Blazor_Calendars_CalendarBase_1_Min) and [Max](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.CalendarBase-1.html#Syncfusion_Blazor_Calendars_CalendarBase_1_Max) properties. You can also set a date value within a specific range using the [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfCalendar-1.html) property. For more information, refer to the [Date Range](./date-range) section. Min and Max are inclusive boundaries; out-of-range dates are disabled.

Here, the Calendar allows selecting a date from the 5th to the 27th of the current month. `TValue` specifies the type of the Calendar component.

{% tabs %}
{% highlight razor %}

<SfCalendar TValue="DateTime" Min='@MinDate' Value='@DateValue' Max='@MaxDate'></SfCalendar>

@code{
    public DateTime MinDate {get;set;} = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 05);
    public DateTime MaxDate {get;set;} = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 27);
    public DateTime DateValue {get;set;} = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 15);
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNLzjMLSzUEDfIGE?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Selection in Blazor Calendar Component](./images/blazor-calendar-selection.png)" %}

## See also

* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Web Assembly App in Visual Studio or .NET CLI](../getting-started/blazor-webassembly-app)
* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Web App in Visual Studio or .NET CLI](../getting-started/blazor-web-app)

N> Explore the [Blazor Calendar Example](https://blazor.syncfusion.com/demos/calendar/default-functionalities?theme=bootstrap5) that shows how to render and configure the Calendar.