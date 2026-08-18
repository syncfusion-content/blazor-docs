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

Blazor provides an option to generate component interop scripts by using the [Custom Resource Generator](https://blazor.syncfusion.com/crg) (CRG) tool. Learn how to [generate component-wise scripts using CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator).

## See also

* [CDN Fallback](https://blazor.syncfusion.com/documentation/common/cdn-fallback)