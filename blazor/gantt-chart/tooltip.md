---
layout: post
title: Tooltip in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about Tooltip in Syncfusion Blazor Gantt Chart component and much more details.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Tooltip in Blazor Gantt Chart Component

The [Blazor Gantt Chart](https://www.syncfusion.com/blazor-components/blazor-gantt-chart) component has a support to display a tooltip for various UI elements like taskbar, timeline cells, and grid cells





### Clip mode

The clip mode provides options to display its overflow cell content and it can be defined by the `GanttColumn.ClipMode` property.

The following are three types of `ClipMode`:

* `Clip`: Truncates the cell content when it overflows its area.
* `Ellipsis`: Displays ellipsis when content of the cell overflows its area.
* `EllipsisWithTooltip`: Displays ellipsis when content of the cell overflows its area; it displays the tooltip content when hover over ellipsis.

N> By default, all the column's `ClipMode` property is defined as `EllipsisWithTooltip`.

