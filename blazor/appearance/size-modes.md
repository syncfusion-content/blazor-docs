---
layout: post
title: Enable Touch-Friendly Size Modes in Blazor | Syncfusion
description: Learn how to enable touch-friendly sizing with the .e-bigger class in Syncfusion Blazor, apply it app-wide or per component, and toggle at runtime.
platform: Blazor
control: Appearance
documentation: ug
---

# Enable Touch-Friendly Size Modes in Blazor

Blazor components support two size modes: **normal** and **touch** (bigger theme). The touch mode provides larger, touch-friendly UI elements for better accessibility on touch devices.

## Prerequisites and setup

Before applying the size modes, ensure you have created your Blazor application.

* **Blazor Web App**: Follow the [Blazor getting started](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app) guide
* **Blazor WebAssembly Standalone App**: Follow the [Blazor getting started](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app) guide

### Install the required NuGet packages

Install the following NuGet packages to use Blazor components and apply size modes.

1. **[Syncfusion.Blazor.Calendars](https://www.nuget.org/packages/Syncfusion.Blazor.Calendars)**
2. **[Syncfusion.Blazor.Buttons](https://www.nuget.org/packages/Syncfusion.Blazor.Buttons)**
3. **[Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes)**

You can install these packages using the Package Manager Console or the .NET CLI.

{% tabs %}
{% highlight bash tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Calendars -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Buttons -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.Calendars --version {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Buttons --version {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes --version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

For the complete list of available packages, refer to the [Blazor NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages).

## Size mode for the application

You can enable touch mode for the entire application by adding the `.e-bigger` class to the `body` element.

1. Define the `.e-bigger` CSS class in your app stylesheet (`~/wwwroot/css/app.css` or `~/wwwroot/app.css`):

   {% tabs %}
   {% highlight css tabtitle="~/wwwroot/css/app.css or ~/wwwroot/app.css" %}

   .e-bigger {
       font-size: x-large;
   }

   {% endhighlight %}
   {% endtabs %}

2. Add the `.e-bigger` class to the `body` element:
   - For **Blazor Web App**: Add to `~/Components/App.razor`
   - For **Blazor WebAssembly Standalone App**: Add to `~/wwwroot/index.html`

   {% tabs %}
   {% highlight html tabtitle="App.razor or index.html" %}

   <body class="e-bigger">
       ...
   </body>

   {% endhighlight %}
   {% endtabs %}

## Size mode for a component

You can enable touch mode for individual components by wrapping them in a `div` with the `.e-bigger` class.

If the Blazor Web App uses interactivity location **Per page/component**, ensure a render mode is defined at the top of the page.

{% tabs %}
{% highlight razor %}

@rendermode InteractiveAuto

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight razor %}

@page "/"

@using Syncfusion.Blazor.Calendars
@using Syncfusion.Blazor.Buttons

<div class="demo-container">
    <div class="e-bigger">
        <SfCalendar TValue="DateTime?" Value="@DateValue"></SfCalendar>
    </div>

    <div class="e-bigger">
        <SfButton>Button</SfButton>
    </div>

    <div class="e-bigger">
        <SfCheckBox Label="Checked" @bind-Checked="isChecked"></SfCheckBox>
    </div>
</div>

<style>
    /* Adds consistent vertical spacing between the Blazor components. */
    .demo-container {
        display: flex;
        flex-direction: column;
        gap: 1rem;
    }

    /* Applies the touch-friendly size mode to Blazor components. */
    .e-bigger {
        font-size: x-large;
    }
</style>

@code {
    private bool isChecked = true;
    public DateTime? DateValue { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 28);
}

{% endhighlight %}
{% endtabs %}

## Change size mode for the application at runtime

You can dynamically toggle between touch and normal modes at runtime using [JavaScript interop](https://learn.microsoft.com/en-us/aspnet/core/blazor/javascript-interoperability/?view=aspnetcore-8.0).

### Step 1: Add CSS class

Add the `.e-bigger` CSS class in the `~/wwwroot/css/app.css` or `~/wwwroot/app.css` file.

{% tabs %}
{% highlight css tabtitle="~/wwwroot/css/app.css or ~/wwwroot/app.css" %}

/* Applies touch-friendly size mode to the application. */
.e-bigger {
    font-size: x-large;
}

/* Adds consistent vertical spacing between the Blazor components. */
.demo-container {
    display: flex;
    flex-direction: column;
    gap: 1rem;
}

{% endhighlight %}
{% endtabs %}

### Step 2: Add JavaScript functions

Add the following JavaScript methods to toggle the size mode. Place the script in the appropriate file:
- **Blazor Web App**: `~/Components/App.razor`
- **Blazor WebAssembly Standalone App**: `~/wwwroot/index.html`

{% tabs %}
{% highlight html tabtitle="App.razor or index.html" %}

<script>
    function onTouch() {
        document.body.classList.add('e-bigger');
    }

    function onMouse() {
        document.body.classList.remove('e-bigger');
    }
</script>

{% endhighlight %}
{% endtabs %}

### Step 3: Call JavaScript from .NET

Inject the `IJSRuntime` abstraction and call the JavaScript methods.

{% tabs %}
{% highlight razor %}

@page "/"

@using Syncfusion.Blazor.Calendars
@using Syncfusion.Blazor.Buttons
@inject IJSRuntime JSRuntime

<p>Size modes for application</p>
<p>This demo shows size modes applied for an entire application.</p>

<div class="demo-container">
    <div>
        <button @onclick="EnableTouchMode">Touch Mode</button>
        <button @onclick="EnableMouseMode">Mouse Mode</button>
    </div>

    <div>
        <SfCalendar TValue="DateTime?" Value="@DateValue"></SfCalendar>
    </div>

    <div>
        <SfButton>Button</SfButton>
    </div>

    <div>
        <SfCheckBox Label="Checked" @bind-Checked="isChecked"></SfCheckBox>
    </div>
</div>

@code {
    private bool isChecked = true;
    public DateTime? DateValue { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 28);

    private async Task EnableTouchMode()
    {
        await JSRuntime.InvokeVoidAsync("onTouch");
    }

    private async Task EnableMouseMode()
    {
        await JSRuntime.InvokeVoidAsync("onMouse");
    }
}

{% endhighlight %}
{% endtabs %}

![change-size-mode-for-application-at-runtime](images/change-size-mode-for-an-application-at-runtime.webp)

N> [View sample in GitHub](https://github.com/SyncfusionExamples/size-mode-in-blazor-application)

## Change size mode for a component at runtime

You can dynamically change the size mode for individual components by conditionally applying the `.e-bigger` CSS class.

{% tabs %}
{% highlight razor %}

@page "/"

@using Syncfusion.Blazor.Calendars
@using Syncfusion.Blazor.Buttons

<h2>Blazor component size modes</h2>
<p>This demo shows size modes applied for individual components.</p>

<div class="demo-container">
    <div>
        <button @onclick="EnableTouchMode">Touch Mode</button>
        <button @onclick="EnableMouseMode">Mouse Mode</button>
    </div>

    <div class="@touchCSS">
        <SfCalendar TValue="DateTime?" Value="@DateValue"></SfCalendar>
    </div>

    <div class="@touchCSS">
        <SfButton>Button</SfButton>
    </div>

    <div class="@touchCSS">
        <SfCheckBox Label="Checked" @bind-Checked="isChecked"></SfCheckBox>
    </div>
</div>

<style>
    /* Adds consistent vertical spacing between the Blazor components. */
    .demo-container {
        display: flex;
        flex-direction: column;
        gap: 1rem;
    }

    /* Applies the touch-friendly size mode to Blazor components. */
    .e-bigger {
        font-size: x-large;
    }
</style>

@code {
    private bool isChecked = true;
    public DateTime? DateValue { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 28);
    private string touchCSS = string.Empty;

    private void EnableTouchMode()
    {
        touchCSS = "e-bigger";
    }

    private void EnableMouseMode()
    {
        touchCSS = string.Empty;
    }
}

{% endhighlight %}
{% endtabs %}

![change-size-mode-for-a-control-at-runtime](images/change-size-mode-for-a-component-at-runtime.webp)

N> [View sample in GitHub](https://github.com/SyncfusionExamples/size-mode-in-blazor-application)

## Customize font size and font family

You can customize the font size and font family for all components by overriding the CSS for the `.e-control` class:

{% tabs %}
{% highlight css tabtitle="~/wwwroot/css/app.css or ~/wwwroot/app.css" %}

.e-control, [class^="e-"] *:not([class*="e-icon"]) {
    font-size: 1rem !important;
    font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif !important;
}

{% endhighlight %}
{% endtabs %}

## See also

* [Sidebar responsiveness](https://blazor.syncfusion.com/documentation/sidebar/auto-close)
* [DataGrid responsiveness](https://blazor.syncfusion.com/documentation/datagrid/columns#responsive-columns)
* [TreeGrid responsiveness](https://blazor.syncfusion.com/documentation/treegrid/scrolling#responsive-with-parent-container)
* [Dashboard layout responsiveness](https://blazor.syncfusion.com/documentation/dashboard-layout/responsive-adaptive)
* [Kanban responsiveness](https://blazor.syncfusion.com/documentation/kanban/responsive-mode)
* [Toolbar responsiveness](https://blazor.syncfusion.com/documentation/toolbar/responsive-mode)
* [Tab responsiveness](https://blazor.syncfusion.com/documentation/tabs/responsive-modes)