---
layout: post
title: Change Theme Dynamically in Blazor Applications | Syncfusion®
description: Learn how to switch Blazor themes dynamically in Web App and WebAssembly apps using a dropdown, query strings, and JavaScript interop.
platform: Blazor
component: Appearance
documentation: ug
---

# Change Theme Dynamically in Blazor Applications

In Blazor applications, you can switch themes dynamically by changing the stylesheet reference at runtime. The implementation approach varies depending on your Blazor application type.

## Prerequisites

Before implementing theme switching, ensure you have created your Blazor application.

* **Blazor Web App**: Follow the [Blazor getting started](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app) guide
* **Blazor WebAssembly Standalone App**: Follow the [Blazor getting started](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app) guide

## Install the required NuGet packages

All theme switching implementations for both Blazor Web App and Blazor WebAssembly Standalone App require the following NuGet packages:

1. **[Syncfusion.Blazor.DropDowns](https://www.nuget.org/packages/Syncfusion.Blazor.DropDowns)** - For the theme switcher dropdown component
2. **[Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid)** - For the sample DataGrid component to demonstrate theme changes
3. **[Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes)** - For the theme stylesheet assets used by the sample

Install these packages using one of the following methods.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.DropDowns -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Grid -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% highlight C# tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.DropDowns --version {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Grid --version {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes --version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

For the complete list of available packages, refer to the [Blazor NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages).

## Change theme dynamically in Blazor Web App

The following steps demonstrate how to dynamically switch themes in a Blazor Web App using Blazor themes with the [Blazor Dropdown List](https://www.syncfusion.com/blazor-components/blazor-dropdown-list) component.

### 1. Configure theme loading

For a **Blazor Web App** using **Server**, **WebAssembly**, or **Auto** interactive render modes, update the `~/Components/App.razor` file to read the `theme` query string parameter and load the corresponding theme stylesheet.

{% tabs %}
{% highlight razor tabtitle="App.razor" %}

@using Microsoft.AspNetCore.WebUtilities
@inject NavigationManager Navigation

@{
    var allowedThemes = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        "bootstrap5.3",
        "bootstrap5.3-dark",
        "fluent2",
        "fluent2-dark",
        "material3",
        "material3-dark",
        "tailwind3",
        "tailwind3-dark",
        "highcontrast"
    };

    var uri = new Uri(Navigation.Uri);
    var query = QueryHelpers.ParseQuery(uri.Query);

    var themeName = query.TryGetValue("theme", out var theme) &&
                    allowedThemes.Contains(theme.FirstOrDefault() ?? string.Empty)
        ? theme.FirstOrDefault()!
        : "bootstrap5.3";
}

<!DOCTYPE html>
<html lang="en">

<head>
    ...
    <!-- Sets the selected theme name into styles -->
    <link href="@("_content/Syncfusion.Blazor.Themes/" + themeName + ".css")" rel="stylesheet" />
</head>

<body>
    ...  
    <!-- Blazor core script (required for UI components) -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>

{% endhighlight %}
{% endtabs %}

### 2. Create a dropdown component for theme selection

Create a new `ThemeSwitcher.razor` file in the `~/Components` folder with the following code. This component uses the [Blazor Dropdown List](https://www.syncfusion.com/blazor-components/blazor-dropdown-list) to enable users to select a theme, which updates the URL query string and triggers a page reload with the selected theme.

{% tabs %}
{% highlight razor tabtitle="ThemeSwitcher.razor" %}

@rendermode InteractiveServer
@using Syncfusion.Blazor.DropDowns
@using Microsoft.AspNetCore.WebUtilities
@inject NavigationManager Navigation

<div class="theme-switcher-container">
    <SfDropDownList TItem="ThemeOption"
                    TValue="string"
                    DataSource="@Themes"
                    @bind-Value="CurrentTheme">
        <DropDownListFieldSettings Text="Text" Value="Id" />
        <DropDownListEvents TItem="ThemeOption"
                            TValue="string"
                            ValueChange="OnThemeChanged" />
    </SfDropDownList>
</div>

@code {
    private string CurrentTheme = "bootstrap5.3";

    // Restrict theme names to prevent arbitrary CSS path injection via query string.
    private static readonly HashSet<string> AllowedThemes = new(StringComparer.OrdinalIgnoreCase)
    {
        "bootstrap5.3", "bootstrap5.3-dark",
        "fluent2", "fluent2-dark",
        "material3", "material3-dark",
        "tailwind3", "tailwind3-dark",
        "highcontrast"
    };

    private static readonly List<ThemeOption> Themes =
    [
        new() { Id = "bootstrap5.3", Text = "Bootstrap 5.3" },
        new() { Id = "bootstrap5.3-dark", Text = "Bootstrap 5.3 Dark" },
        new() { Id = "fluent2", Text = "Fluent 2" },
        new() { Id = "fluent2-dark", Text = "Fluent 2 Dark" },
        new() { Id = "material3", Text = "Material 3" },
        new() { Id = "material3-dark", Text = "Material 3 Dark" },
        new() { Id = "tailwind3", Text = "Tailwind 3.4" },
        new() { Id = "tailwind3-dark", Text = "Tailwind 3.4 Dark" },
        new() { Id = "highcontrast", Text = "High Contrast" }
    ];

    protected override void OnInitialized()
    {
        var uri = Navigation.ToAbsoluteUri(Navigation.Uri);
        var query = QueryHelpers.ParseQuery(uri.Query);

        if (query.TryGetValue("theme", out var theme) &&
            AllowedThemes.Contains(theme.FirstOrDefault() ?? string.Empty))
        {
            CurrentTheme = theme.First()!;
        }
    }

    private void OnThemeChanged(ChangeEventArgs<string, ThemeOption> args)
    {
        if (string.IsNullOrWhiteSpace(args?.Value) || !AllowedThemes.Contains(args.Value))
        {
            return;
        }

        CurrentTheme = args.Value;

        Navigation.NavigateTo(
            Navigation.GetUriWithQueryParameter("theme", CurrentTheme),
            forceLoad: true);
    }

    private sealed class ThemeOption
    {
        public string Id { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
    }
}

{% endhighlight %}
{% endtabs %}

N> Change the `@rendermode` directive to `InteractiveAuto` or `InteractiveWebAssembly` based on your application's render mode configuration.

### 3. Add the theme switcher component

Include the `ThemeSwitcher` component in your `~/Components/Layout/MainLayout.razor` file to display the theme switcher in your application layout.

{% tabs %}
{% highlight razor tabtitle="MainLayout.razor" hl_lines="5 6 7" %}

@inherits LayoutComponentBase

<div class="page">
    <div class="top-row px-4">
        <div class="theme-switcher">
            <ThemeSwitcher />
        </div>
        <a href="https://learn.microsoft.com/aspnet/core/" target="_blank">About</a>
    </div>

    <article class="content px-4">
        @Body
    </article>
</div>

{% endhighlight %}
{% endtabs %}

![Change theme dynamically in Blazor Web App](images/blazor-web-app-dynamic-theme-switch.webp)

N> [View sample in GitHub](https://github.com/SyncfusionExamples/theme-switching-in-blazor-server-app)

## Change theme dynamically in Blazor WebAssembly (WASM) standalone app

The following steps demonstrate how to dynamically switch themes in a Blazor WebAssembly (WASM) standalone application using Blazor themes with the [Blazor Dropdown List](https://www.syncfusion.com/blazor-components/blazor-dropdown-list) component. Unlike Blazor Web App, standalone WASM apps use [JavaScript interop](https://learn.microsoft.com/en-us/aspnet/core/blazor/javascript-interoperability/?view=aspnetcore-10.0) to dynamically change themes without requiring a full page reload, as they run entirely in the browser without server-side rendering capabilities.

### 1. Configure theme switching with JavaScript

Add the following code to the `~/wwwroot/index.html` file. This script dynamically updates the theme stylesheet reference when the user selects a theme from the dropdown.

{% tabs %}
{% highlight html tabtitle="index.html" %}

<head>
    ...
    <!-- Sets the selected theme name into styles -->
    <link id="theme" href="_content/Syncfusion.Blazor.Themes/bootstrap5.3.css" rel="stylesheet" />
</head>

<body>
    ...
    <!-- Blazor core script (required for UI components) -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
    <!-- Updates the theme stylesheet at runtime -->
    <script>
        function setTheme(theme) {
            document.getElementsByTagName('body')[0].style.display = 'none';
            let synclink = document.getElementById('theme');
            synclink.href = '_content/Syncfusion.Blazor.Themes/' + theme + '.css';
            setTimeout(function () { document.getElementsByTagName('body')[0].style.display = 'block'; }, 300);
        }
    </script>
</body>

{% endhighlight %}
{% endtabs %}

### 2. Add the theme switcher dropdown

Modify your `~/Layout/MainLayout.razor` file to include the theme switcher dropdown using the [Blazor Dropdown List](https://www.syncfusion.com/blazor-components/blazor-dropdown-list). This dropdown calls the JavaScript `setTheme()` function when the user selects a different theme.

{% tabs %}
{% highlight razor tabtitle="MainLayout.razor" %}

@inherits LayoutComponentBase
@inject IJSRuntime JSRuntime
@using Syncfusion.Blazor.DropDowns

<div class="page">
    <div class="sidebar">
        <NavMenu />
    </div>

    <main>
        <div class="top-row px-4">
            <div class="theme-switcher">
                <SfDropDownList TItem="ThemeDetails" TValue="string" @bind-Value="themeName" DataSource="@Themes">
                    <DropDownListFieldSettings Text="Text" Value="ID"></DropDownListFieldSettings>
                    <DropDownListEvents TItem="ThemeDetails" TValue="string" ValueChange="OnThemeChange"></DropDownListEvents>
                </SfDropDownList>
            </div>
            <a href="https://learn.microsoft.com/aspnet/" target="_blank">About</a>
        </div>

        <article class="content px-4">
            @Body
        </article>
    </main>
</div>

@code {
    private string themeName = "bootstrap5.3";

    public class ThemeDetails
    {
        public string ID { get; set; }
        public string Text { get; set; }
    }

    private List<ThemeDetails> Themes = new List<ThemeDetails>()
    {
        new ThemeDetails(){ ID = "bootstrap5.3", Text = "Bootstrap 5.3" },
        new ThemeDetails(){ ID = "bootstrap5.3-dark", Text = "Bootstrap 5.3 Dark" },
        new ThemeDetails(){ ID = "fluent2", Text = "Fluent 2" },
        new ThemeDetails(){ ID = "fluent2-dark", Text = "Fluent 2 Dark" },
        new ThemeDetails(){ ID = "material3", Text = "Material 3" },
        new ThemeDetails(){ ID = "material3-dark", Text = "Material 3 Dark" },
        new ThemeDetails(){ ID = "tailwind3", Text = "Tailwind 3.4" },
        new ThemeDetails(){ ID = "tailwind3-dark", Text = "Tailwind 3.4 Dark" },
        new ThemeDetails(){ ID = "highcontrast", Text = "High Contrast" }
    };

    public void OnThemeChange(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string, ThemeDetails> args)
    {
        JSRuntime.InvokeAsync<object>("setTheme", args.ItemData.ID);
    }
}

{% endhighlight %}
{% endtabs %}

![Change theme dynamically in Blazor WASM app](images/blazor-wasm-app-dynamic-theme-switch.webp)

N> [View sample in GitHub](https://github.com/SyncfusionExamples/theme-switching-in-blazor-WASM-app)

## Add a sample component to visualize theme changes

After implementing the theme switcher in either Blazor Web App or Blazor WebAssembly Standalone App, add a sample component to visualize the theme changes. The following example uses the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) component to demonstrate how themes are applied dynamically.

Create or update the appropriate page file based on your application type.

* For **Blazor Web App**: Update `~/Components/Pages/Home.razor`
* For **Blazor WebAssembly Standalone App**: Update `~/Pages/Home.razor`

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@page "/"

@using Syncfusion.Blazor.Grids

<PageTitle>Home</PageTitle>

<h1>Dynamically Change Theme</h1>

<SfGrid DataSource="@Orders" AllowPaging="true">
    <GridPageSettings PageSizes="true" PageSize="10"></GridPageSettings>
    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" />
        <GridColumn Field="@nameof(Order.CustomerID)" HeaderText="Customer" Width="150" />
        <GridColumn Field="@nameof(Order.OrderDate)" HeaderText="Order Date" Format="d" Type="ColumnType.Date" Width="140" />
        <GridColumn Field="@nameof(Order.Freight)" HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120" />
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; } = [];

    protected override void OnInitialized()
    {
        var customers = new[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" };

        Orders = Enumerable.Range(1, 75).Select(x => new Order
        {
            OrderID = 1000 + x,
            CustomerID = customers[x % customers.Length],
            Freight = 2.1 * x,
            OrderDate = DateTime.Today.AddDays(-x)
        }).ToList();
    }

    public class Order
    {
        public int OrderID { get; set; }
        public string? CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public double Freight { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

Now, run your application and use the theme switcher dropdown to change themes. The [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) component will immediately reflect the selected theme, demonstrating the dynamic theme switching functionality.