---
layout: post
title: Adding script references in Blazor - Syncfusion
description: Learn here about that how to add the script references manually in the Syncfusion Blazor Components.
platform: Blazor
component: Common
documentation: ug
---

# Reference scripts in Blazor Application

This section provides information about the script isolation process and how to reference scripts from CDN, Static Web Assets and Custom resource generator (CRG) for Syncfusion Blazor Components.

> The javascript interop files needs to be added to support the features that can't be implemented in native blazor. 

## CDN Reference

You can refer the Syncfusion Blazor scripts through the CDN resources.

> From 2022 Vol1 (20.1) version, JavaScript isolation is marked as obsolete and disabled by default to refer scripts externally. Refer [Disable JavaScript isolation](https://blazor.syncfusion.com/documentation/common/adding-script-references#disable-javascript-isolation) topic to disable for earlier versions to refer scripts externally.

* For **Blazor WASM App**, reference scripts in `~/wwwroot/index.html` file. 
* For **Blazor Server App**, reference scripts in `~/Pages/_Layout.cshtml` file for `.NET 6` project and in `~/Pages/_Host.cshtml` file for `.NET 5 and .NET Core 3.X` project.

Syncfusion Blazor components are available in CDN for each version. Make sure that the version in the URLs matches the version of the Syncfusion Blazor Package you are using.

<table>
<tr>
<td><b>Component</b></td>
<td><b>CDN Script Reference</b></td>
</tr>

<tr>
<td><p>All components except PDF Viewer & Document Editor</p></td>
<td>

{% highlight cshtml %}
https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/syncfusion-blazor.min.js
{% endhighlight %}

</td>
</tr>

<tr>
<td><p>PDF Viewer</p></td>
<td>

{% highlight cshtml %}
https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/syncfusion-blazor-pdfviewer.min.js
{% endhighlight %}

</td>
</tr>

<tr>
<td><p>Document Editor</p></td>
<td>

{% highlight cshtml %}
https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/syncfusion-blazor-documenteditor.min.js
{% endhighlight %}

</td>
</tr>
</table>

```html
<head>
    ....
    <script src="https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>
```

If you are using `PDFViewer` or `DocumentEditor`, ensure to add additional script references as follows,

```html
<head>
    ....
    <script src="https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/syncfusion-blazor-pdfviewer.min.js" type="text/javascript"></script>
    <script src="https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/syncfusion-blazor-documenteditor.min.js" type="text/javascript"></script>
</head>
```

In addition to above, Syncfusion Blazor components provides latest scripts in CDN without versioning. You can use this in development environment if you want to always use the latest version of scripts. It is not recommended to use this in production environment. 

W> The un-versioned CDN links which always maintains latest version scripts are deprecated from 2022 Vol1 - 20.1 version. These links are available with `19.4` version scripts to avoid breaking in sites and apps that uses un-versioned links. 

| Component | CDN Script Reference |
| --- | --- |
|  All components except PDF Viewer & Document Editor | https://cdn.syncfusion.com/blazor/syncfusion-blazor.min.js |
| PDF Viewer | https://cdn.syncfusion.com/blazor/syncfusion-blazor-pdfviewer.min.js |
| Document Editor | https://cdn.syncfusion.com/blazor/syncfusion-blazor-documenteditor.min.js |

## Static web assets

You can refer the Syncfusion Blazor scripts through the NuGet package's static web assets.

> From 2022 Vol1 (20.1) version, JavaScript isolation is marked as obsolete and disabled by default to refer scripts externally. Refer [Disable JavaScript isolation](https://blazor.syncfusion.com/documentation/common/adding-script-references#disable-javascript-isolation) topic to disable for earlier versions to refer scripts externally.

### Enable static web assets usage

To use static web assets, ensure [UseStaticFiles](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.builder.staticfileextensions.usestaticfiles) method is called as follows,

* For **.NET 6** app, open the **~/Program.cs** file and call `UseStaticFiles` method.
* For **.NET 5 and .NET 3.X** app, open the **~/Startup.cs** file and call `UseStaticFiles` method.

> For **Blazor WASM App**, call `UseStaticFiles` method in **Server project** of the above mentioned file. 

### Refer script from static web assets

* If you are using Syncfusion [Blazor individual NuGet package](https://blazor.syncfusion.com/documentation/nuget-packages), the combined scripts available in [Syncfusion.Blazor.Core](https://www.nuget.org/packages/Syncfusion.Blazor.Core/) package. To refer script from static web assets, use the code below.

    ```html
    <head>
        ...
        <script  src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js"  type="text/javascript"></script>
    </head>
    ```

* If you're using the PDF viewer or Document Editor component, use the code below to refer to script from static web assets.

    ```html
    <head>
        ...
       <script  src="_content/Syncfusion.Blazor.PdfViewer/scripts/syncfusion-blazor-pdfviewer.min.js"  type="text/javascript"></script>
       <script  src="_content/Syncfusion.Blazor.WordProcessor/scripts/syncfusion-blazor-documenteditor.min.js"  type="text/javascript"></script>
    </head>
    ```

* If you are using [Syncfusion.Blazor](https://www.nuget.org/packages/Syncfusion.Blazor/) NuGet package, use the code below to refer to script from static web assets.

    It is not recommended to use [Syncfusion.Blazor](https://www.nuget.org/packages/Syncfusion.Blazor/) NuGet for production environment. Use individual NuGet packages for production.  

    ```html
    <head>
        ...
        <script  src="_content/Syncfusion.Blazor/scripts/syncfusion-blazor.min.js"  type="text/javascript"></script>
    </head>
    ```

    > The PDF Viewer and Document Editor component scripts are  available in static web assets from 19.3.* version. If you are using PDF Viewer or Document Editor component with 19.2.* version, it automatically switch to the JavaScript isolation in the application end.


## JavaScript isolation

Syncfusion Blazor components supports JavaScript isolation where the needed scripts are loaded by the component itself when its rendered. So, you don't have to reference scripts externally in application. 

> Syncfusion recommends to reference scripts using [Static Web Assets](https://blazor.syncfusion.com/documentation/common/adding-script-references#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/common/adding-script-references#cdn-reference) and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator) over JavaScript isolation approach for better loading performance of the blazor application. 

From 2022 Vol1 (20.1) version version, JavaScript isolation is marked as obsolete and disabled by default. You can enable JavaScript isolation by following below steps,

**Blazor Server App**

* For **.NET 6** app, open the **~/Program.cs** file and register the Syncfusion Blazor Service by setting `IgnoreScriptIsolation` as `false`.

* For **.NET 5 and .NET 3.X** app, open the **~/Startup.cs** file and register the Syncfusion Blazor Service by setting `IgnoreScriptIsolation` as `false`.

{% tabs %}
{% highlight c# tabtitle=".NET 6 (~/Program.cs)" hl_lines="10" %}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = false; });

var app = builder.Build();
....

{% endhighlight %}

{% highlight c# tabtitle=".NET 5 and .NET 3.X (~/Startup.cs)" hl_lines="12" %}

using Syncfusion.Blazor;

namespace BlazorApplication
{
    public class Startup
    {
        ...
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = false; });
        }
        ...
    }
}

{% endhighlight %}
{% endtabs %}

**Blazor WASM App**

For Blazor WebAssembly App, set [IgnoreScriptIsolation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_IgnoreScriptIsolation) property as `false` using `AddSyncfusionBlazor` service method in `~/Program.cs` file.

{% tabs %}
{% highlight c# tabtitle=".NET 6 (~/Program.cs)" hl_lines="11" %}

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = false; });
await builder.Build().RunAsync();
....

{% endhighlight %}

{% highlight c# tabtitle=".NET 5 and .NET 3.X (~/Program.cs)" hl_lines="10" %}

using Syncfusion.Blazor;

namespace WebApplication1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            ....
            builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = false; });
            await builder.Build().RunAsync();
        }
    }
}
{% endhighlight %}
{% endtabs %}

## Disable JavaScript isolation

> From 2022 Vol1 (20.1) version version, JavaScript isolation is marked as obsolete and disabled by default. You don't have to make below additional changes.

The Syncfusion Blazor components supports to refer scripts externally at the application-end by disabling default JavaScript isolation approach for better initial loading performance which explained in the previous section. You can disable JS isolation by setting [IgnoreScriptIsolation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_IgnoreScriptIsolation) as `true` while adding Syncfusion blazor service using `AddSyncfusionBlazor()`. 

### Blazor Server App

* For **.NET 6** app, open the **~/Program.cs** file and register the Syncfusion Blazor Service by setting `IgnoreScriptIsolation`.

* For **.NET 5 and .NET 3.X** app, open the **~/Startup.cs** file and register the Syncfusion Blazor Service by setting `IgnoreScriptIsolation`.

{% tabs %}
{% highlight c# tabtitle=".NET 6 (~/Program.cs)" hl_lines="10" %}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });

var app = builder.Build();
....

{% endhighlight %}

{% highlight c# tabtitle=".NET 5 and .NET 3.X (~/Startup.cs)" hl_lines="12" %}

using Syncfusion.Blazor;

namespace BlazorApplication
{
    public class Startup
    {
        ...
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });
        }
        ...
    }
}

{% endhighlight %}
{% endtabs %}

### Blazor WASM App

For Blazor WebAssembly App, set [IgnoreScriptIsolation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_IgnoreScriptIsolation) property as `true` using `AddSyncfusionBlazor` service method in `~/Program.cs` file.

{% tabs %}
{% highlight c# tabtitle=".NET 6 (~/Program.cs)" hl_lines="11" %}

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });
await builder.Build().RunAsync();
....

{% endhighlight %}

{% highlight c# tabtitle=".NET 5 and .NET 3.X (~/Program.cs)" hl_lines="10" %}

using Syncfusion.Blazor;

namespace WebApplication1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            ....
            builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });
            await builder.Build().RunAsync();
        }
    }
}
{% endhighlight %}
{% endtabs %}

> If you set [IgnoreScriptIsolation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_IgnoreScriptIsolation) property as `true`, You need to reference scripts externally via [Static Web Assets](https://blazor.syncfusion.com/documentation/common/adding-script-references#static-web-assets) or [CDN](https://blazor.syncfusion.com/documentation/common/adding-script-references#cdn-reference) or and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator). 

## Individual control script reference

Syncfusion Blazor components provides component-wise scripts which can be referenced externally in application. If you are using minimal components, then you can import the selected components scripts via CDN or Static web assets directly without using [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator) instead of referencing single script with all components. 

You can add a component script reference in one of the following ways based on usage, 

<table>
<tr>
<td><b>Usage</b></td>
<td><b>Script reference</b></td>
</tr>

<tr>
<td><p>Refer from Static web assets when using <strong>Syncfusion.Blazor</strong> NuGet</p></td>
<td>

{% highlight cshtml %}
<head>
    ...
    <!--<script src="_content/Syncfusion.Blazor/scripts/<Component script name>" type="text/javascript"></script>-->
    <script src="_content/Syncfusion.Blazor/scripts/sf-textbox.min.js" type="text/javascript"></script>
</head>
{% endhighlight %}

</td>
</tr>

<tr>
<td><p>Refer from Static web assets when using <a href="https://blazor.syncfusion.com/documentation/nuget-packages">individual NuGet packages</a></p></td>
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
<td><p>Refer scripts from CDN</p></td>
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

The following table lists components and its script reference.

<table>
    <tr>
        <th>Component</th>
        <th>Script name</th>
    </tr>
    <tr>
        <th>TextBox</th>
        <th>sf-textbox.min.js</th>
    </tr>
    <tr>
        <th>NumericTextBox</th>
        <th>sf-numerictextbox.min.js</th>
    </tr>
    <tr>
        <th>MaskedTextBox</th>
        <th>sf-maskedtextbox.min.js</th>
    </tr>
    <tr>
        <th>Uploader</th>
        <th>sf-uploader.min.js</th>
    </tr>
    <tr>
        <th>Calendar</th>
        <th>sf-calendar.min.js</th>
    </tr>
    <tr>
        <th>DatePicker</th>
        <th>sf-datepicker.min.js</th>
    </tr>
    <tr>
        <th>DateTimePicker</th>
        <th>sf-datepicker.min.js</th>
    </tr>
    <tr>
        <th>DateRangePicker</th>
        <th>sf-daterangepicker.min.js</th>
    </tr>
    <tr>
        <th>DiagramComponent</th>
        <th>sf-diagramcomponent.min.js</th>
    </tr>
    <tr>
        <th>TimePicker</th>
        <th>sf-timepicker.min.js</th>
    </tr>
    <tr>
        <th>AutoComplete</th>
        <th>sf-dropdownlist.min.js</th>
    </tr>
    <tr>
        <th>ComboBox</th>
        <th>sf-dropdownlist.min.js</th>
    </tr>
    <tr>
        <th>DropDownList</th>
        <th>sf-dropdownlist.min.js</th>
    </tr>
    <tr>
        <th>MultiSelect</th>
        <th>sf-multiselect.min.js</th>
    </tr>
    <tr>
        <th>DropDownButton</th>
        <th>sf-drop-down-button.min.js</th>
    </tr>
    <tr>
        <th>SplitButton</th>
        <th>sf-drop-down-button.min.js</th>
    </tr>
    <tr>
        <th>ProgressButton</th>
        <th>sf-spinner.min.js</th>
    </tr>
    <tr>
        <th>ListBox</th>
        <th>sf-listbox.min.js</th>
    </tr>
    <tr>
        <th>ColorPicker</th>
        <th>sf-colorpicker.min.js</th>
    </tr>
    <tr>
        <th>Signature</th>
        <th>sf-signature.min.js</th>
    </tr>
    <tr>
        <th>ContextMenu</th>
        <th>sf-contextmenu.min.js</th>
    </tr>
    <tr>
        <th>Menu</th>
        <th>sf-menu.min.js</th>
    </tr>
    <tr>
        <th>Breadcrumb</th>
        <th>sf-breadcrumb.min.js</th>
    </tr>
    <tr>
        <th>QueryBuilder</th>
        <th>sf-querybuilder.min.js</th>
    </tr>
    <tr>
        <th>Grid</th>
        <th>sf-grid.min.js</th>
    </tr>
    <tr>
        <th>Accordion</th>
        <th>sf-accordion.min.js</th>
    </tr>
    <tr>
        <th>Tab</th>
        <th>sf-tab.min.js</th>
    </tr>
    <tr>
        <th>Toolbar</th>
        <th>sf-toolbar.min.js</th>
    </tr>
    <tr>
        <th>Schedule</th>
        <th>sf-schedule.min.js</th>
    </tr>
    <tr>
        <th>BarcodeGenerator</th>
        <th>sf-barcode.min.js</th>
    </tr>
    <tr>
        <th>Maps</th>
        <th>sf-maps.min.js</th>
    </tr>
    <tr>
        <th>CircularGauge</th>
        <th>sf-circulargauge.min.js</th>
    </tr>
    <tr>
        <th>LinearGauge</th>
        <th>sf-lineargauge.min.js</th>
    </tr>
    <tr>
        <th>Chart</th>
        <th>sf-chart.min.js</th>
    </tr>
    <tr>
        <th>AccumulationChart</th>
        <th>sf-accumulation-chart.min.js</th>
    </tr>
    <tr>
        <th>StockChart</th>
        <th>sf-stock-chart.min.js</th>
    </tr>
    <tr>
        <th>BulletChart</th>
        <th>sf-bullet-chart.min.js</th>
    </tr>
    <tr>
        <th>Sparkline</th>
        <th>sf-sparkline.min.js</th>
    </tr>
    <tr>
        <th>TreeMap</th>
        <th>sf-treemap.min.js</th>
    </tr>
    <tr>
        <th>ProgressBar</th>
        <th>sf-progressbar.min.js</th>
    </tr>
    <tr>
        <th>SmithChart</th>
        <th>sf-smith-chart.min.js</th>
    </tr>
    <tr>
        <th>RangeNavigator</th>
        <th>sf-range-navigator.min.js</th>
    </tr>
    <tr>
        <th>HeatMap</th>
        <th>sf-heatmap.min.js</th>
    </tr>
    <tr>
        <th>FileManager</th>
        <th>sf-filemanager.min.js</th>
    </tr>
    <tr>
        <th>Slider</th>
        <th>sf-slider.min.js</th>
    </tr>
    <tr>
        <th>Tooltip</th>
        <th>sf-tooltip.min.js</th>
    </tr>
    <tr>
        <th>ListView</th>
        <th>sf-listview.min.js</th>
    </tr>
    <tr>
        <th>DashboardLayout</th>
        <th>sf-dashboard-layout.min.js</th>
    </tr>
    <tr>
        <th>Sidebar</th>
        <th>sf-sidebar.min.js</th>
    </tr>
    <tr>
        <th>TreeView</th>
        <th>sf-treeview.min.js</th>
    </tr>
    <tr>
        <th>PivotView</th>
        <th>sf-pivotview.min.js</th>
    </tr>
    <tr>
        <th>TreeGrid</th>
        <th>sf-treegrid.min.js</th>
    </tr>
    <tr>
        <th>Spinner</th>
        <th>sf-spinner.min.js</th>
    </tr>
    <tr>
        <th>Splitter</th>
        <th>sf-splitter.min.js</th>
    </tr>
    <tr>
        <th>Toast</th>
        <th>sf-toast.min.js</th>
    </tr>
    <tr>
        <th>Dialog</th>
        <th>sf-dialog.min.js</th>
    </tr>
    <tr>
        <th>RichTextEditor</th>
        <th>sf-richtexteditor.min.js</th>
    </tr>
    <tr>
        <th>InPlaceEditor</th>
        <th>sf-inplaceeditor.min.js</th>
    </tr>
    <tr>
        <th>Kanban</th>
        <th>sf-kanban.min.js</th>
    </tr>
    <tr>
        <th>Gantt</th>
        <th>sf-gantt.min.js</th>
    </tr>
    <tr>
        <th>PdfViewer</th>
        <th>sf-pdfviewer.min.js</th>
    </tr>
    <tr>
        <th>DocumentEditor</th>
        <th>sf-documenteditor.min.js</th>
    </tr>
    <tr>
        <th>Pager</th>
        <th>sf-pager.min.js</th>
    </tr>
</table>

## Custom Resource Generator

The Syncfusion Blazor provides an option to generate a component's interop scripts using the [Custom Resource Generator](https://blazor.syncfusion.com/crg) (CRG) tool for the Blazor components. Refer [here to generate the component-wise scripts externally using CRG](./custom-resource-generator).

## See also

* [CDN Fallback](./cdn-fallback)
