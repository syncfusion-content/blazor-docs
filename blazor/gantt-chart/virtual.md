---
layout: post
title: Virtual in Blazor Gantt Chart Component | Syncfusion 
description: Learn about Virtual in Blazor Gantt Chart component of Syncfusion, and more details.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Virtualization

Gantt Chart allows you to load a large amount of data without performance degradation.

## Row Virtualization

Row virtualization allows you to render rows only in the content viewport on load time. It is an alternative way of paging in which the rows will be loaded while scrolling vertically. To set up the row virtualization, you need to define
`EnableVirtualization` as true and content height by [`Height`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_Height) property.

The number of records displayed in the Gantt Chart is determined implicitly by the height of the content area.

{% aspTab template="gantt-chart/virtualization", sourceFiles="index.razor,ganttdata.cs" %}

{% endaspTab %}

## Limitations for Virtualization

* Due to the element height limitation in browsers, the maximum number of records loaded by the Gantt chart is limited by the browser capability.
* It is necessary to mention the height of the Gantt in pixels when enabling Virtual Scrolling.
* Cell selection will not be persisted in a row.
* Programmatic selection using the **SelectRows** method is not supported in virtual scrolling.
* Currently Editing, Row Drag and Drop are not supported with Virtual scrolling.
