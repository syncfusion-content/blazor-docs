---
layout: post
title: Reference script files for Blazor | Syncfusion®
description: Add Blazor script references via CDN, static web assets, or the Custom Resource Generator (CRG) and much more details.
platform: Blazor
control: Common
documentation: ug
---

# Reference scripts in Blazor applications

This page explains script isolation and how to reference Blazor scripts from the CDN, static web assets, and the Custom Resource Generator (CRG).

N> JavaScript interop files are required for features that cannot be implemented natively in Blazor.

## CDN reference

You can refer the Blazor scripts using the CDN resources.

* For **.NET 8, .NET 9, and .NET 10** Blazor Web App (any render mode: Server, WebAssembly, or Auto), add scripts in `~/Components/App.razor`.
* For a **Blazor WebAssembly (standalone) App**, add scripts in `~/wwwroot/index.html`.

Blazor components are available on the CDN per version. Ensure that the version in the URLs matches the NuGet package version used in the application.

<table>
<tr>
<td><b>Component</b></td>
<td><b>CDN Script Reference</b></td>
</tr>

<tr>
<td><p>All Blazor UI Components</p></td>
<td>

{% highlight cshtml %}
https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/syncfusion-blazor.min.js
{% endhighlight %}

</td>
</tr>
</table>

```html
<head>
    ...
    <script src="https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>
```

Additionally, Blazor components provide the latest scripts on the CDN without versioning. You can use this in a development environment if you want to always use the latest version of the scripts. It is not recommended to use this in a production environment.

| Component | CDN Script Reference |
| --- | --- |
| All Blazor UI Components | https://cdn.syncfusion.com/blazor/syncfusion-blazor.min.js |

## Static web assets

You can refer to the Blazor scripts from NuGet packages by using static web assets.

### Enable static web assets usage

To use static web assets, call [UseStaticFiles](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.builder.staticfileextensions.usestaticfiles?view=aspnetcore-10.0) in the app's **~/Program.cs** file.

N> For a **Blazor Web App** (render mode: Auto) and a **Blazor WebAssembly App**, call `UseStaticFiles` in the **Server** project.

### Reference scripts from static web assets

* Combined scripts are available in the [Syncfusion.Blazor.Core](https://www.nuget.org/packages/Syncfusion.Blazor.Core/) package. To refer the script from static web assets, use the code below.

    ```html
    <head>
        ...
        <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
    </head>
    ```

### Prevent stale cached assets using asset fingerprinting

Browsers cache static web assets such as `_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js` to improve load times. After the Syncfusion Blazor NuGet packages are upgraded, a browser can continue to use the previously cached script while the server runs the newer Syncfusion assemblies. This version mismatch can cause runtime errors. Asset fingerprinting prevents this issue by generating a unique URL whenever the file content changes, so browsers automatically download the latest assets after an upgrade.

Asset fingerprinting is available in .NET 9 and later through [MapStaticAssets](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/static-files?view=aspnetcore-10.0#mapstaticassets) and the `@Assets[]` resource collection. Static web assets from Razor class libraries, such as `_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js`, are included in the fingerprinting process.

1. Call `MapStaticAssets()` in the **~/Program.cs** file. For a **Blazor Web App**, call it in the **Server** project.

    {% tabs %}
    {% highlight cs tabtitle="Program.cs" hl_lines="6" %}

    var app = builder.Build();

    app.UseHttpsRedirection();
    app.UseAntiforgery();

    app.MapStaticAssets();
    app.MapRazorComponents<App>()
        .AddInteractiveServerRenderMode();

    app.Run();

    {% endhighlight %}
    {% endtabs %}

2. Reference the Syncfusion theme and script assets through `@Assets[]`. Add the [stylesheet](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets) at the end of the `<head>` section in the **~/Components/App.razor** file.

    {% tabs %}
    {% highlight razor tabtitle="App.razor" %}

    <link href="@Assets["_content/Syncfusion.Blazor.Themes/fluent2.css"]" rel="stylesheet" />

    {% endhighlight %}
    {% endtabs %}

    Add the script reference at the end of the `<body>` section in the same file.

    {% tabs %}
    {% highlight razor tabtitle="App.razor" %}

    <script src="@Assets["_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js"]" type="text/javascript"></script>

    {% endhighlight %}
    {% endtabs %}

The `@Assets[]` resource collection requires .NET 9 or later. The following table lists where to apply the fingerprinted references for each application type.

<table>
<thead>
<tr>
<th>Application type</th>
<th>Call <code>MapStaticAssets()</code> in</th>
<th>Add the references in</th>
<th>Reference syntax</th>
</tr>
</thead>
<tbody>
<tr>
<td>Blazor Web App (Server, WebAssembly, or Auto render modes)</td>
<td><strong>~/Program.cs</strong> of the <strong>Server</strong> project</td>
<td><strong>~/Components/App.razor</strong> of the <strong>Server</strong> project</td>
<td><code>@Assets["_content/..."]</code></td>
</tr>
<tr>
<td>Blazor Server App</td>
<td><strong>~/Program.cs</strong></td>
<td>Host page that contains the <code>&lt;head&gt;</code> and <code>&lt;body&gt;</code> elements, such as <strong>~/Pages/_Host.cshtml</strong> or <strong>~/Components/App.razor</strong></td>
<td><code>@Assets["_content/..."]</code></td>
</tr>
<tr>
<td>Blazor WebAssembly standalone App</td>
<td>Not applicable</td>
<td><strong>~/wwwroot/index.html</strong></td>
<td><code>@Assets[]</code> is not available. Use the <a href="#alternative-cache-busting-approaches" aria-label="Alternative cache-busting approaches">alternative cache-busting approaches</a>.</td>
</tr>
</tbody>
</table>

The rendered URL contains a fingerprint computed from the file content, so the URL changes whenever the file changes after a package upgrade. Fingerprinted assets are served with the `immutable` cache directive, which allows browsers to cache them safely while still receiving updated files when the content changes.

`MapStaticAssets()` serves only the assets listed in the static assets manifest that is generated during build and publish. To serve files that are not part of the manifest, call `UseStaticFiles()` along with `MapStaticAssets()`. For more information, refer to [Static files in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/static-files?view=aspnetcore-10.0).

#### Runtime behavior of fingerprinted Syncfusion assets

* The `syncfusion-blazor.min.js` bundle does not load additional Syncfusion JavaScript files relative to its own URL. Serving the script through a fingerprinted URL therefore does not affect component initialization or rendering.
* Syncfusion theme files, such as `fluent2.css` and `bootstrap5.css`, are self-contained and do not depend on external fonts or images referenced through relative URLs for normal rendering. Serving the stylesheet through a fingerprinted URL therefore does not affect theme rendering. If a customized stylesheet references additional assets through relative URLs, reference those assets using `@Assets[]` or absolute paths.

#### Alternative cache-busting approaches

The `@Assets[]` resource collection is available in **Blazor Web App** and **Blazor Server** applications that target .NET 9 or later. For applications that cannot use `MapStaticAssets()`, such as applications targeting earlier .NET versions or standalone **Blazor WebAssembly** applications, use one of the following approaches.

**Version query string**

Append a version query string to the script and stylesheet references, and update it after each Syncfusion Blazor package upgrade. This approach works in all application types. In a standalone **Blazor WebAssembly** application, add the references to the **~/wwwroot/index.html** file, as shown in the following code snippet.

{% tabs %}
{% highlight html tabtitle="index.html" %}

<link href="_content/Syncfusion.Blazor.Themes/fluent2.css?v=35.1.40" rel="stylesheet" />

<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js?v=35.1.40" type="text/javascript"></script>

{% endhighlight %}
{% endtabs %}

N> In standalone **Blazor WebAssembly** applications, reference Syncfusion assets using paths that begin with `_content/`. The `~/` prefix is not supported in **wwwroot/index.html** because the file is not processed by Razor.

**The asp-append-version tag helper**

In applications that render **.cshtml** files, such as a Blazor Server application that uses the **~/Pages/_Host.cshtml** host page, use the `asp-append-version` tag helper. It uses [IFileVersionProvider](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.viewfeatures.ifileversionprovider?view=aspnetcore-10.0) to append a content-based hash to the URL, ensuring that browsers request the updated file whenever the file content changes.

{% tabs %}
{% highlight cshtml tabtitle="_Host.cshtml" %}

<script src="~/_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" asp-append-version="true"></script>

{% endhighlight %}
{% endtabs %}

The tag helper is processed on the server. Therefore, it cannot be used in static files such as the **index.html** file of a standalone **Blazor WebAssembly** application, or in **.razor** files.

Asset fingerprinting is still the recommended approach when the application supports it. The asset URL is generated automatically from the file content, so no version number needs to be updated manually after upgrading the Syncfusion Blazor packages, and cached client-side assets cannot get out of sync with the upgraded Syncfusion assemblies.

## Individual component script references

Blazor components provide component-wise scripts that can be referenced externally in the application. If you are using only a few components, you can directly reference the required component scripts from the CDN or static web assets without using the [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator), instead of referencing the single script that includes all components.

You can add a component script reference in one of the following ways based on usage:

<table>
<tr>
<td><b>Usage</b></td>
<td><b>Script reference</b></td>
</tr>

<tr>
<td><p>Refer from static web assets</p></td>
<td>

{% highlight cshtml %}
<head>
    ...
    <!--<script src="_content/<Package name>/scripts/<Component script name>" type="text/javascript"></script>-->
    <script src="_content/Syncfusion.Blazor.Inputs/scripts/sf-textbox.min.js" type="text/javascript"></script>
</head>
{% endhighlight %}

</td>
</tr>

<tr>
<td><p>Refer from CDN</p></td>
<td>

{% highlight cshtml %}
<head>
    ...
    <!--<script src="https://cdn.syncfusion.com/blazor/<Version>/<Component script name>" type="text/javascript"></script>-->
    <script src="https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/sf-textbox.min.js" type="text/javascript"></script>
</head>
{% endhighlight %}

</td>
</tr>
</table>

The following table lists the components and their script file names.

<table>
    <tr>
        <th>Component</th>
        <th>Script name</th>
    </tr>
    <tr>
        <td>TextBox</td>
        <td>sf-textbox.min.js</td>
    </tr>
    <tr>
        <td>TextArea</td>
        <td>sf-textarea.min.js</td>
    </tr>
    <tr>
        <td>Toggle Switch Button</td>
        <td>sf-switch.min.js</td>
    </tr>
    <tr>
        <td>Numeric TextBox</td>
        <td>sf-numerictextbox.min.js</td>
    </tr>
    <tr>
        <td>Input Mask</td>
        <td>sf-maskedtextbox.min.js</td>
    </tr>
    <tr>
        <td>OTP Input</td>
        <td>sf-otp-input.min.js</td>
    </tr>
    <tr>
        <td>File Upload</td>
        <td>sf-uploader.min.js</td>
    </tr>
    <tr>
        <td>Range Slider</td>
        <td>sf-slider.min.js</td>
    </tr>
    <tr>
        <td>Calendar</td>
        <td>sf-calendar.min.js</td>
    </tr>
    <tr>
        <td>DatePicker</td>
        <td>sf-datepicker.min.js</td>
    </tr>
    <tr>
        <td>DateTime Picker</td>
        <td>sf-datepicker.min.js</td>
    </tr>
    <tr>
        <td>DateRangePicker</td>
        <td>sf-daterangepicker.min.js</td>
    </tr>
    <tr>
        <td>TimePicker</td>
        <td>sf-timepicker.min.js</td>
    </tr>
    <tr>
        <td>AutoComplete</td>
        <td>sf-dropdownlist.min.js</td>
    </tr>
    <tr>
        <td>ComboBox</td>
        <td>sf-dropdownlist.min.js</td>
    </tr>
    <tr>
        <td>Dropdown List</td>
        <td>sf-dropdownlist.min.js</td>
    </tr>
    <tr>
        <td>Multicolumn ComboBox</td>
        <td>sf-multicolumncombobox.min.js</td>
    </tr>
    <tr>
        <td>MultiSelect Dropdown</td>
        <td>sf-multiselect.min.js</td>
    </tr>
    <tr>
        <td>Mention</td>
        <td>sf-mention.min.js</td>
    </tr>
    <tr>
        <td>Dropdown Menu</td>
        <td>sf-drop-down-button.min.js</td>
    </tr>
    <tr>
        <td>Split Button</td>
        <td>sf-drop-down-button.min.js</td>
    </tr>
    <tr>
        <td>Progress Button</td>
        <td>sf-spinner.min.js</td>
    </tr>
    <tr>
        <td>ListBox</td>
        <td>sf-listbox.min.js</td>
    </tr>
    <tr>
        <td>Color Picker</td>
        <td>sf-colorpicker.min.js</td>
    </tr>
    <tr>
        <td>Signature</td>
        <td>sf-signature.min.js</td>
    </tr>
    <tr>
        <td>Rating</td>
        <td>sf-rating.min.js</td>
    </tr>
    <tr>
        <td>Speech to Text</td>
        <td>sf-speechtotext.min.js</td>
    </tr>
    <tr>
        <td>Context Menu</td>
        <td>sf-contextmenu.min.js</td>
    </tr>
    <tr>
        <td>Menu Bar</td>
        <td>sf-menu.min.js</td>
    </tr>
    <tr>
        <td>Breadcrumb</td>
        <td>sf-breadcrumb.min.js</td>
    </tr>
    <tr>
        <td>Carousel</td>
        <td>sf-carousel.min.js</td>
    </tr>
    <tr>
        <td>Dropdown Tree</td>
        <td>sf-dropdowntree.min.js</td>
    </tr>
    <tr>
        <td>Stepper</td>
        <td>sf-stepper.min.js</td>
    </tr>
    <tr>
        <td>Query Builder</td>
        <td>sf-querybuilder.min.js</td>
    </tr>
    <tr>
        <td>Grid</td>
        <td>sf-grid.min.js</td>
    </tr>
    <tr>
        <td>Accordion</td>
        <td>sf-accordion.min.js</td>
    </tr>
    <tr>
        <td>Tabs</td>
        <td>sf-tab.min.js</td>
    </tr>
    <tr>
        <td>Toolbar</td>
        <td>sf-toolbar.min.js</td>
    </tr>
    <tr>
        <td>Scheduler</td>
        <td>sf-schedule.min.js</td>
    </tr>
    <tr>
        <td>Barcode Generator</td>
        <td>sf-barcode.min.js</td>
    </tr>
    <tr>
        <td>Maps</td>
        <td>sf-maps.min.js</td>
    </tr>
    <tr>
        <td>Circular Gauge</td>
        <td>sf-circulargauge.min.js</td>
    </tr>
    <tr>
        <td>Linear Gauge</td>
        <td>sf-lineargauge.min.js</td>
    </tr>
    <tr>
        <td>HeatMap</td>
        <td>sf-heatmap.min.js</td>
    </tr>
    <tr>
        <td>Chart</td>
        <td>sf-chart.min.js</td>
    </tr>
    <tr>
        <td>3D Chart</td>
        <td>sf-chart3d.min.js</td>
    </tr>
    <tr>
        <td>Chart Wizard</td>
        <td>sf-chart-wizard.min.js</td>
    </tr>
    <tr>
        <td>CheckBox</td>
        <td>sf-checkbox.min.js</td>
    </tr>
    <tr>
        <td>Accumulation Chart</td>
        <td>sf-accumulation-chart.min.js</td>
    </tr>
    <tr>
        <td>Stock Chart</td>
        <td>sf-stock-chart.min.js</td>
    </tr>
    <tr>
        <td>Bullet Chart</td>
        <td>sf-bullet-chart.min.js</td>
    </tr>
    <tr>
        <td>Sparkline</td>
        <td>sf-sparkline.min.js</td>
    </tr>
    <tr>
        <td>Sunburst Chart</td>
        <td>sf-sunburst-chart.min.js</td>
    </tr>
    <tr>
        <td>TreeMap</td>
        <td>sf-treemap.min.js</td>
    </tr>
    <tr>
        <td>ProgressBar</td>
        <td>sf-progressbar.min.js</td>
    </tr>
    <tr>
        <td>Smith Chart</td>
        <td>sf-smith-chart.min.js</td>
    </tr>
    <tr>
        <td>Range Selector</td>
        <td>sf-range-navigator.min.js</td>
    </tr>
    <tr>
        <td>Sankey</td>
        <td>sf-sankey.min.js</td>
    </tr>
    <tr>
        <td>File Manager</td>
        <td>sf-filemanager.min.js</td>
    </tr>
    <tr>
        <td>Tooltip</td>
        <td>sf-tooltip.min.js</td>
    </tr>
    <tr>
        <td>ListView</td>
        <td>sf-listview.min.js</td>
    </tr>
    <tr>
        <td>Dashboard Layout</td>
        <td>sf-dashboard-layout.min.js</td>
    </tr>
    <tr>
        <td>Sidebar</td>
        <td>sf-sidebar.min.js</td>
    </tr>
    <tr>
        <td>TreeView</td>
        <td>sf-treeview.min.js</td>
    </tr>
    <tr>
        <td>Pivot Table</td>
        <td>sf-pivotview.min.js</td>
    </tr>
    <tr>
        <td>TreeGrid</td>
        <td>sf-treegrid.min.js</td>
    </tr>
    <tr>
        <td>Spinner</td>
        <td>sf-spinner.min.js</td>
    </tr>
    <tr>
        <td>Splitter</td>
        <td>sf-splitter.min.js</td>
    </tr>
    <tr>
        <td>Floating Action Button</td>
        <td>sf-floating-action-button.min.js</td>
    </tr>
    <tr>
        <td>Speed Dial</td>
        <td>sf-speeddial.min.js</td>
    </tr>
    <tr>
        <td>Toast</td>
        <td>sf-toast.min.js</td>
    </tr>
    <tr>
        <td>Dialog</td>
        <td>sf-dialog.min.js</td>
    </tr>
    <tr>
        <td>In-Place Editor</td>
        <td>sf-inplaceeditor.min.js</td>
    </tr>
    <tr>
        <td>Kanban</td>
        <td>sf-kanban.min.js</td>
    </tr>
    <tr>
        <td>Image Editor</td>
        <td>sf-image-editor.min.js</td>
    </tr>
    <tr>
        <td>Pager</td>
        <td>sf-pager.min.js</td>
    </tr>
    <tr>
        <td>Diagram</td>
        <td>sf-diagramcomponent.min.js</td>
    </tr>
    <tr>
        <td>Gantt Chart</td>
        <td>sf-gantt.min.js</td>
    </tr>
    <tr>
        <td>Ribbon</td>
        <td>sf-ribbon.min.js</td>
    </tr>
    <tr>
        <td>Rich Text Editor</td>
        <td>sf-richtexteditor.min.js</td>
    </tr>
    <tr>
        <td>Block Editor</td>
        <td>sf-blockeditor.min.js</td>
    </tr>
    <tr>
        <td>AI AssistView</td>
        <td>sf-ai-assistview.min.js</td>
    </tr>
    <tr>
        <td>Chat UI</td>
        <td>sf-chat-ui.min.js</td>
    </tr>
</table>

## Custom Resource Generator

Blazor provides an option to generate component interop scripts by using the [Custom Resource Generator](https://blazor.syncfusion.com/crg/) (CRG) tool. Learn how to [generate component-wise scripts using CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator).

## See also

* [CDN Fallback](https://blazor.syncfusion.com/documentation/common/cdn-fallback)