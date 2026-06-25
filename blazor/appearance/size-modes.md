---
layout: post
title: Enable Touch Friendly Size Modes in Blazor | Syncfusion®
description: Learn how to enable touch-friendly sizing with the .e-bigger class in Blazor, apply it app-wide or per component, and toggle at runtime.
platform: Blazor
control: Appearance
documentation: ug
---

# Enable Touch Friendly Size Modes in Blazor

Blazor components support two size modes: **normal** and **touch** (bigger theme). The touch mode provides larger, touch-friendly UI elements for better accessibility on touch devices.

## Set the size mode for the application

You can enable touch mode for the entire application by adding the `.e-bigger` class to the `body` element.

### Step 1: Define the touch-friendly CSS class

Add the `.e-bigger` CSS class to your application stylesheet (`~/wwwroot/css/app.css` or `~/wwwroot/app.css`).

{% tabs %}
{% highlight css tabtitle=".css" %}

.e-bigger {
    font-size: x-large;
}

{% endhighlight %}
{% endtabs %}

### Step 2: Apply the class to the document body

Add the `.e-bigger` class to the `body` element.

- For **Blazor Web App**: Add to `~/Components/App.razor`
- For **Blazor WebAssembly Standalone App**: Add to `~/wwwroot/index.html`

{% tabs %}
{% highlight html tabtitle="App.razor / index.html" %}

<body class="e-bigger">
    ...
</body>

{% endhighlight %}
{% endtabs %}

## Set the size mode for a component

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

### Step 1: Add the CSS class

Add the `.e-bigger` CSS class in the `~/wwwroot/css/app.css` or `~/wwwroot/app.css` file.

{% tabs %}
{% highlight css tabtitle=".css" %}

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

### Step 2: Add the JavaScript functions

Add the following JavaScript methods to toggle the size mode. Place the script in the appropriate file:
- **Blazor Web App**: `~/Components/App.razor`
- **Blazor WebAssembly Standalone App**: `~/wwwroot/index.html`

{% tabs %}
{% highlight html tabtitle="App.razor / index.html" %}

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

### Step 3: Call the JavaScript from .NET

Inject the [IJSRuntime](https://learn.microsoft.com/en-us/dotnet/api/microsoft.jsinterop.ijsruntime?view=aspnetcore-10.0) abstraction and call the JavaScript methods.

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

## Change the size mode for a component at runtime

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

## Customize the font size and font family

You can customize the font size and font family for all components by overriding the CSS for the `.e-control` class:

{% tabs %}
{% highlight css tabtitle=".css" %}

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