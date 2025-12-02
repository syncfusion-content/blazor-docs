---
layout: post
title: Configure Syncfusion Blazor Client Resources in Production
description: Migrate a Blazor application from EJ2-based package to Syncfusion Blazor 18.1.0.36, including NuGet, namespace, component prefix, resource, DataManager changes.
platform: Blazor
control: Common
documentation: ug
---

# How to upgrade Syncfusion® Blazor Components to 18.1.0.36 version

This guide explains the one-time migration required when upgrading from Syncfusion Blazor packages to version 18.1.0.36 and later.

## NuGet changes

In previous versions, the primary Syncfusion Blazor NuGet package name was `Syncfusion.EJ2.Blazor`. Starting with version 18.1.0.36, the package name is `Syncfusion.Blazor`. Other Blazor packages follow the same naming change.

The following table shows example package ID changes:

| Before 18.1.0.36 version | From 18.1.0.36 version |
| ------------- | ------------- |
| Syncfusion.EJ2.Blazor | Syncfusion.Blazor |
| Syncfusion.EJ2.WordEditor.Blazor | Syncfusion.WordEditor.Blazor |
| Syncfusion.EJ2.Blazor.PdfViewerServer.Windows | Syncfusion.Blazor.PdfViewerServer.Windows |
| Syncfusion.EJ2.Blazor.PdfViewerServer.Linux | Syncfusion.Blazor.PdfViewerServer.Linux |
| Syncfusion.EJ2.Blazor.PdfViewerServer.OSX | Syncfusion.Blazor.PdfViewerServer.OSX |

## Namespace changes

Earlier versions used the root namespace `Syncfusion.EJ2.Blazor` followed by component package names such as Buttons, Charts, Grids, and Inputs. From version 18.1.0.36, the root namespace is `Syncfusion.Blazor` followed by the package name. The following table provides examples:

| Before 18.1.0.36 version | From 18.1.0.36 version |
| ------------- | ------------- |
| Syncfusion.EJ2.Blazor | Syncfusion.Blazor |
| Syncfusion.EJ2.Blazor.Buttons | Syncfusion.Blazor.Buttons |
| Syncfusion.EJ2.Blazor.Calendars | Syncfusion.Blazor.Calendars |
| Syncfusion.EJ2.Blazor.Charts | Syncfusion.Blazor.Charts |
| Syncfusion.EJ2.Blazor.Grids | Syncfusion.Blazor.Grids |

## Component name changes

In earlier versions, component names were prefixed with Ejs (for example, EjsGrid, EjsChart). Starting with 18.1.0.36, the prefix is Sf (for example, SfGrid, SfChart). See the following examples:

<!-- markdownlint-disable MD033 -->
<table>
<tr>
<td>
<b>Before v18.1.0.36</b>
</td>
<td>
<b>From v18.1.0.36</b>
</td>
</tr>
<tr>
<td>

{% highlight razor %}
<EjsButton>Button</EjsButton>
{% endhighlight %}

</td>
<td>

{% highlight razor %}
<SfButton>Button</SfButton>
{% endhighlight %}

</td>
</tr>
<tr>
<td>

{% highlight razor %}
<EjsCalendar TValue="DateTime"></EjsCalendar>
{% endhighlight %}

</td>
<td>

{% highlight razor %}
<SfCalendar TValue="DateTime"></SfCalendar>
{% endhighlight %}

</td>
</tr>
</table>

## Resource changes

In earlier versions, the application manually referenced the `ej2.min.js` and `ejs-interop.min.js` scripts. Starting with 18.1.0.36, scripts are loaded automatically via static web assets from the NuGet package for the components used on the page. Styles are also provided as static web assets to reference in the application.

<!-- markdownlint-disable MD033 -->
<table>
<tr>
<td>
<b>Before v18.1.0.36</b>
</td>
<td>
<b>From v18.1.0.36</b>
</td>
</tr>
<tr>
<td>

{% highlight razor %}
<head>
    ....
    ....
    <link href="https://cdn.syncfusion.com/ej2/17.4.55/material.css" rel="stylesheet" />
    <script src="https://cdn.syncfusion.com/ej2/17.4.55/dist/ej2.min.js"></script>
    <script src="https://cdn.syncfusion.com/ej2/17.4.55/dist/ejs.interop.min.js"></script>
</head>

{% endhighlight %}

</td>
<td>

{% highlight razor %}
<head>
    ....
    ....
    <link href="_content/Syncfusion.Blazor/styles/bootstrap4.css" rel="stylesheet" />
</head>

{% endhighlight %}

</td>
</tr>
</table>

If needed, resources can be loaded from the Custom Resource Generator (CRG) by disabling default script loading from static web assets using options passed to the `AddSyncfusionBlazor` service in the `~/Program.cs` file.

## DataManager changes

In previous versions, Query initialization used `new ej.data.Query()`. From version 18.1.0.36, it uses `new sf.data.Query()`. See the following examples:

<!-- markdownlint-disable MD033 -->
<table>
<tr>
<td>
<b>Before v18.1.0.36</b>
</td>
<td>
<b>From v18.1.0.36</b>
</td>
</tr>
<tr>
<td>

{% highlight razor %}
@using Syncfusion.EJ2.Blazor.Data

@{ var chartQuery = $"new ej.data.Query().where('EmployeeID', 'equal', {employee.EmployeeID}, false)"; }

<EjsChart Height="390px" Title="Sales Report" DataSource="@OrderData">
    ....
    ....
        <ChartSeriesCollection>
        <ChartSeries XName="ShipCity" YName="Freight" Type="ChartSeriesType.Column" Query="@chartQuery">
        </ChartSeries>
        </ChartSeriesCollection>
    ....
    ....
</EjsChart>

{% endhighlight %}

</td>
<td>

{% highlight razor %}
@using Syncfusion.Blazor.Data

@{ var chartQuery = $"new sf.data.Query().where('EmployeeID', 'equal', {employee.EmployeeID}, false)"; }

<SfChart Height="390px" Title="Sales Report" DataSource="@OrderData">
    ....
    ....
        <ChartSeriesCollection>
        <ChartSeries XName="ShipCity" YName="Freight" Type="ChartSeriesType.Column" Query="@chartQuery">
        </ChartSeries>
        </ChartSeriesCollection>
    ....
    ....
</SfChart>

{% endhighlight %}

</td>
</tr>
</table>

N> To downgrade a project from version 18.1.0.36, reverse the steps outlined above.
