---
layout: post
title: Improve Blazor Performance with Virtualization | Syncfusion
description: Learn how Syncfusion Blazor components use row and column virtualization, overscan count, virtual placeholders, frozen columns, and infinite scrolling.
platform: Blazor
control: Common
documentation: ug
---

# Improve Blazor Performance with Virtualization

Virtualization improves the performance of [Blazor components](https://www.syncfusion.com/blazor-components) by rendering only the items visible in the viewport and recycling DOM elements as the user scrolls. This reduces initial load time, lowers memory usage, and keeps the DOM size small, resulting in smoother scrolling and more responsive interactions.

With virtualization enabled, large datasets become easier to handle, even when they contain thousands of records.

## Components supporting virtualization

The following Blazor components provide built-in virtualization support for efficiently handling large datasets.

* **[DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid)** - Supports row virtualization, column virtualization, overscan buffering, virtual loading placeholders (mask rows), frozen columns with virtualization, and infinite scrolling.
* **[Scheduler](https://www.syncfusion.com/blazor-components/blazor-scheduler)** - Supports virtual scrolling to efficiently render large appointment collections and improve timeline performance.
* **[ListView](https://www.syncfusion.com/blazor-components/blazor-listview)** - Supports UI virtualization with window or container scrolling modes.
* **[File Manager](https://www.syncfusion.com/blazor-components/blazor-file-manager)** - Supports UI virtualization in both Details and Large Icons views.
* **[TreeView](https://www.syncfusion.com/blazor-components/blazor-treeview)** - Supports UI virtualization to render only visible nodes, significantly improving performance in large hierarchical structures.
* **[Gantt Chart](https://www.syncfusion.com/blazor-components/blazor-gantt-chart)** - Supports row virtualization, timeline virtualization, and column virtualization to efficiently render large project schedules and complex timelines.
* **[TreeGrid](https://www.syncfusion.com/blazor-components/blazor-tree-grid)** - Supports row virtualization, column virtualization, and cell placeholders (VirtualMaskRow) for smoother loading with large hierarchical data.

## Advantages of virtualization

| Benefit              | Explanation                                       |
|----------------------|---------------------------------------------------|
| Faster initial load  | Renders only the items visible in the viewport    |
| Reduced DOM size     | Keeps the DOM size small and reduces memory usage |
| Smoother scrolling   | Reuses DOM elements to avoid frequent reflows     |
| Scalable             | Handles tens of thousands of records efficiently  |

## DataGrid virtualization

The [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) supports several virtualization features that help it handle large datasets efficiently.

For complete virtualization guidance, see:

* [Virtual Scrolling in Blazor DataGrid](https://blazor.syncfusion.com/documentation/datagrid/virtual-scrolling)
* [Infinite Scrolling in Blazor DataGrid](https://blazor.syncfusion.com/documentation/datagrid/infinite-scrolling)

## Scheduler virtualization

The [Blazor Scheduler](https://www.syncfusion.com/blazor-components/blazor-scheduler) supports virtual scrolling to efficiently render large appointment collections and improve timeline performance. This helps reduce DOM size and keeps the scheduler responsive when working with extensive schedules.

For complete virtualization guidance, see:

* [Virtual Scrolling in Blazor Scheduler](https://blazor.syncfusion.com/documentation/scheduler/virtual-scrolling)

## ListView virtualization

The [Blazor ListView](https://www.syncfusion.com/blazor-components/blazor-listview) supports UI virtualization, which improves performance when working with large datasets. Instead of rendering all items at once, only the items visible within the viewport are created. This keeps the component responsive and reduces memory usage even when the list contains thousands of records.

For complete virtualization guidance, see:

* [Virtualization in Blazor ListView](https://blazor.syncfusion.com/documentation/listview/virtualization)

## File Manager virtualization

The [Blazor File Manager](https://www.syncfusion.com/blazor-components/blazor-file-manager) supports UI virtualization to efficiently load large numbers of files and folders without affecting performance. It renders only the items visible in the viewport, enabling smooth navigation even when directories contain thousands of entries.

For complete virtualization guidance, see:

* [Virtualization in Blazor File Manager](https://blazor.syncfusion.com/documentation/file-manager/virtualization)

## TreeView virtualization

The [Blazor TreeView](https://www.syncfusion.com/blazor-components/blazor-treeview) supports UI virtualization to render only the visible nodes in the hierarchy. This improves rendering speed and responsiveness when working with large trees.

For complete virtualization guidance, see:

* [Virtualization in Blazor TreeView](https://blazor.syncfusion.com/documentation/treeview/virtualization)

## Gantt Chart virtualization

The [Blazor Gantt Chart](https://www.syncfusion.com/blazor-components/blazor-gantt-chart) supports row, timeline, and column virtualization to handle large project schedules efficiently. This reduces DOM size and improves scrolling performance in complex timelines.

For complete virtualization guidance, see:

* [Virtualization in Blazor Gantt Chart](https://blazor.syncfusion.com/documentation/gantt-chart/virtualization)

## TreeGrid virtualization

The [Blazor TreeGrid](https://www.syncfusion.com/blazor-components/blazor-tree-grid) supports row virtualization, column virtualization, and virtual placeholder rendering for hierarchical data. This improves performance when displaying large nested datasets.

For complete virtualization guidance, see:

* [Virtualization in Blazor TreeGrid](https://blazor.syncfusion.com/documentation/treegrid/virtualization)