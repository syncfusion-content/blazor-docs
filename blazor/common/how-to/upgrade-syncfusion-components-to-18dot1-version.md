---
layout: post
title: Configure Syncfusion Blazor Client Resources in Production
description: Check out the documentation for Configure Syncfusion Blazor Client Resources in Production Environment in Blazor
platform: Blazor
component: Common
documentation: ug
---

# How to upgrade Syncfusion Blazor Components to 18.1.0.36 version

To upgrade Syncfusion Blazor Components to 18.1.0.36 version, you need to check the following:

## NuGet changes

Previous versions of the Syncfusion Blazor NuGet package name is `Syncfusion.EJ2.Blazor`. From version 18.1.0.36, it will be `Syncfusion.Blazor`. Other Blazor packages will also have the same name changes.

For example, refer to the following table for changes in the Blazor packages name.

| Before 18.1.0.36 version | From 18.1.0.36 version |
| ------------- | ------------- |
| Syncfusion.EJ2.Blazor | Syncfusion.Blazor |
| Syncfusion.EJ2.WordEditor.Blazor | Syncfusion.WordEditor.Blazor |
| Syncfusion.EJ2.Blazor.PdfViewerServer.Windows | Syncfusion.Blazor.PdfViewerServer.Windows |
| Syncfusion.EJ2.Blazor.PdfViewerServer.Linux | Syncfusion.Blazor.PdfViewerServer.Linux |
| Syncfusion.EJ2.Blazor.PdfViewerServer.OSX | Syncfusion.Blazor.PdfViewerServer.OSX |

## Namespace changes

The previous version of Syncfusion Blazor contains the namespace `Syncfusion.EJ2.Blazor` followed by component package names such as Buttons, Charts, Grids, and Inputs. After 18.1.0.36 version, this has been modified to `Syncfusion.Blazor` followed by its package name. Check the following table for examples.

| Before 18.1.0.36 version | From 18.1.0.36 version |
| ------------- | ------------- |
| Syncfusion.EJ2.Blazor | Syncfusion.Blazor |
| Syncfusion.EJ2.Blazor.Buttons | Syncfusion.Blazor.Buttons |
| Syncfusion.EJ2.Blazor.Calendars | Syncfusion.Blazor.Calendars |
| Syncfusion.EJ2.Blazor.Charts | Syncfusion.Blazor.Charts |
| Syncfusion.EJ2.Blazor.Grids | Syncfusion.Blazor.Grids |

## Component name changes

In the previous version, the component names are prefixed with Ejs (example: EjsGrid, EjsChart) which has been changed to the prefix Sf (example: SfGrid, SfChart). Check the following examples for your reference.

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

Till the previous version, you will be loading scripts `ej2.min.js` and `ejs-interop.min.js` manually in the application, which is not required from 18.1.0.36 version. The script will be loaded from NuGet through static web assets for the components loaded on the page. We have also provided styles as static web assets to load in the application.

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

Still, you can load the resource from CRG by disabling default script loading from static web assets by passing arguments to `AddSyncfusionBlazor` service in the `~/Program.cs` file.

## DataManager changes

In the previous version, Query's initialization was made as `new ej.data.Query()`. From version 18.0.1.36, it has been changed to `new sf.data.Query()`. Check the following table for examples.

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

N> To downgrade the project from 18.1.0.36 version, you need to do the reverse process of the previous steps.