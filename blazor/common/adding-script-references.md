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

N> The javascript interop files needs to be added to support the features that can't be implemented in native blazor.

## CDN Reference

You can refer the Syncfusion Blazor scripts through the CDN resources.

* For **Blazor Web App**, reference scripts in `~/Components/App.razor` file.
* For **Blazor WASM App**, reference scripts in `~/wwwroot/index.html` file.
* For **Blazor Server App**, reference scripts in `~/Pages/_Layout.cshtml` file for `.NET 6` project and in `~/Pages/_Host.cshtml` file for `.NET 7` project.

Syncfusion Blazor components are available in CDN for each version. Make sure that the version in the URLs matches the version of the Syncfusion Blazor Package you are using .

<table>
<tr>
<td><b>Component</b></td>
<td><b>CDN Script Reference</b></td>
</tr>

<tr>
<td><p>All components except PDF Viewer, PDF Viewer(NextGen) & Document Editor</p></td>
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

<tr>
<td><p>PDF Viewer(NextGen)</p></td>
<td>

{% highlight cshtml %}
https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/syncfusion-blazor-sfpdfviewer.min.js
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

If you are using `PDF Viewer`,`PDF Viewer(NextGen)` or `DocumentEditor`, ensure to add additional script references as follows,

```html
<head>
    ....
    <script src="https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/syncfusion-blazor-pdfviewer.min.js" type="text/javascript"></script>
    <script src="https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/syncfusion-blazor-documenteditor.min.js" type="text/javascript"></script>
    <script src="https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/syncfusion-blazor-sfpdfviewer.min.js" type="text/javascript"></script>
</head>
```

In addition to above, Syncfusion Blazor components provides latest scripts in CDN without versioning. You can use this in development environment if you want to always use the latest version of scripts. It is not recommended to use this in production environment.

| Component | CDN Script Reference |
| --- | --- |
|  All components except PDF Viewer, PDF Viewer(NextGen) & Document Editor | https://cdn.syncfusion.com/blazor/syncfusion-blazor.min.js |
| PDF Viewer | https://cdn.syncfusion.com/blazor/syncfusion-blazor-pdfviewer.min.js |
| Document Editor | https://cdn.syncfusion.com/blazor/syncfusion-blazor-documenteditor.min.js |
| PDF Viewer(NextGen) | https://cdn.syncfusion.com/blazor/syncfusion-blazor-sfpdfviewer.min.js |


N> To add custom PDF Viewer(NextGen) script file in your application, refer [How to refer SfPdfViewer script file in application](../pdfviewer-2/how-to/refer-sfpdfviewer-script-in-application).

## Static web assets

You can refer the Syncfusion Blazor scripts through the NuGet package's static web assets.

### Enable static web assets usage

To use static web assets, ensure [UseStaticFiles](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.builder.staticfileextensions.usestaticfiles?view=aspnetcore-8.0) method in the **~/Program.cs** file of your app.

N> For **Blazor Web App with interaction mode as  Auto & Blazor WASM App**, call `UseStaticFiles` method in **Server project**.

### Refer script from static web assets

* The combined scripts available in [Syncfusion.Blazor.Core](https://www.nuget.org/packages/Syncfusion.Blazor.Core/) package. To refer script from static web assets, use the code below.

    ```html
    <head>
        ...
        <script  src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js"  type="text/javascript"></script>
    </head>
    ```

* If you're using the PDF viewer, PDF Viewer(NextGen) or Document Editor component, use the code below to refer to script from static web assets.

    ```html
    <head>
        ...
       <script  src="_content/Syncfusion.Blazor.PdfViewer/scripts/syncfusion-blazor-pdfviewer.min.js"  type="text/javascript"></script>
       <script  src="_content/Syncfusion.Blazor.WordProcessor/scripts/syncfusion-blazor-documenteditor.min.js"  type="text/javascript"></script>
       <script  src="_content/Syncfusion.Blazor.SfPdfViewer/scripts/syncfusion-blazor-sfpdfviewer.min.js"  type="text/javascript"></script>
    </head>
    ```

    N> The PDF Viewer and Document Editor component scripts are  available in static web assets from 19.3.* version.

## Individual control script reference

Syncfusion Blazor components provides component-wise scripts which can be referenced externally in application. If you are using minimal components, then you can import the selected components scripts via CDN or Static web assets directly without using [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator) instead of referencing single script with all components.

You can add a component script reference in one of the following ways based on usage,

<table>
<tr>
<td><b>Usage</b></td>
<td><b>Script reference</b></td>
</tr>

<tr>
<td><p>Refer from Static web assets</p></td>
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
        <td>TextBox</td>
        <td>sf-textbox.min.js</td>
    </tr>
    <tr>
        <td>NumericTextBox</td>
        <td>sf-numerictextbox.min.js</td>
    </tr>
    <tr>
        <td>MaskedTextBox</td>
        <td>sf-maskedtextbox.min.js</td>
    </tr>
    <tr>
        <td>Uploader</td>
        <td>sf-uploader.min.js</td>
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
        <td>DateTimePicker</td>
        <td>sf-datepicker.min.js</td>
    </tr>
    <tr>
        <td>DateRangePicker</td>
        <td>sf-daterangepicker.min.js</td>
    </tr>
    <tr>
        <td>DiagramComponent</td>
        <td>sf-diagramcomponent.min.js</td>
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
        <td>DropDownList</td>
        <td>sf-dropdownlist.min.js</td>
    </tr>
    <tr>
        <td>MultiSelect</td>
        <td>sf-multiselect.min.js</td>
    </tr>
    <tr>
        <td>DropDownButton</td>
        <td>sf-drop-down-button.min.js</td>
    </tr>
    <tr>
        <td>SplitButton</td>
        <td>sf-drop-down-button.min.js</td>
    </tr>
    <tr>
        <td>ProgressButton</td>
        <td>sf-spinner.min.js</td>
    </tr>
    <tr>
        <td>ListBox</td>
        <td>sf-listbox.min.js</td>
    </tr>
    <tr>
        <td>ColorPicker</td>
        <td>sf-colorpicker.min.js</td>
    </tr>
    <tr>
        <td>Signature</td>
        <td>sf-signature.min.js</td>
    </tr>
    <tr>
        <td>ContextMenu</td>
        <td>sf-contextmenu.min.js</td>
    </tr>
    <tr>
        <td>Menu</td>
        <td>sf-menu.min.js</td>
    </tr>
    <tr>
        <td>Breadcrumb</td>
        <td>sf-breadcrumb.min.js</td>
    </tr>
    <tr>
        <td>QueryBuilder</td>
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
        <td>Tab</td>
        <td>sf-tab.min.js</td>
    </tr>
    <tr>
        <td>Toolbar</td>
        <td>sf-toolbar.min.js</td>
    </tr>
    <tr>
        <td>Schedule</td>
        <td>sf-schedule.min.js</td>
    </tr>
    <tr>
        <td>BarcodeGenerator</td>
        <td>sf-barcode.min.js</td>
    </tr>
    <tr>
        <td>Maps</td>
        <td>sf-maps.min.js</td>
    </tr>
    <tr>
        <td>CircularGauge</td>
        <td>sf-circulargauge.min.js</td>
    </tr>
    <tr>
        <td>LinearGauge</td>
        <td>sf-lineargauge.min.js</td>
    </tr>
    <tr>
        <td>Chart</td>
        <td>sf-chart.min.js</td>
    </tr>
    <tr>
        <td>AccumulationChart</td>
        <td>sf-accumulation-chart.min.js</td>
    </tr>
    <tr>
        <td>StockChart</td>
        <td>sf-stock-chart.min.js</td>
    </tr>
    <tr>
        <td>BulletChart</td>
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
        <td>SmithChart</td>
        <td>sf-smith-chart.min.js</td>
    </tr>
    <tr>
        <td>RangeNavigator</td>
        <td>sf-range-navigator.min.js</td>
    </tr>
    <tr>
        <td>HeatMap</td>
        <td>sf-heatmap.min.js</td>
    </tr>
    <tr>
        <td>FileManager</td>
        <td>sf-filemanager.min.js</td>
    </tr>
    <tr>
        <td>Slider</td>
        <td>sf-slider.min.js</td>
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
        <td>DashboardLayout</td>
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
        <td>PivotView</td>
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
        <td>Toast</td>
        <td>sf-toast.min.js</td>
    </tr>
    <tr>
        <td>Dialog</td>
        <td>sf-dialog.min.js</td>
    </tr>
    <tr>
        <td>RichTextEditor</td>
        <td>sf-richtexteditor.min.js</td>
    </tr>
    <tr>
        <td>InPlaceEditor</td>
        <td>sf-inplaceeditor.min.js</td>
    </tr>
    <tr>
        <td>Kanban</td>
        <td>sf-kanban.min.js</td>
    </tr>
    <tr>
        <td>Gantt</td>
        <td>sf-gantt.min.js</td>
    </tr>
    <tr>
        <td>PdfViewer</td>
        <td>sf-pdfviewer.min.js</td>
    </tr>
    <tr>
        <td>ImageEditor</td>
        <td>sf-image-editor.min.js</td>
    </tr>
    <tr>
        <td>DocumentEditor</td>
        <td>sf-documenteditor.min.js</td>
    </tr>
    <tr>
        <td>Pager</td>
        <td>sf-pager.min.js</td>
    </tr>
</table>

## Custom Resource Generator

The Syncfusion Blazor provides an option to generate a component's interop scripts using the [Custom Resource Generator](https://blazor.syncfusion.com/crg/) (CRG) tool for the Blazor components. Refer [here to generate the component-wise scripts externally using CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator).

## See also

* [CDN Fallback](https://blazor.syncfusion.com/documentation/common/cdn-fallback)
