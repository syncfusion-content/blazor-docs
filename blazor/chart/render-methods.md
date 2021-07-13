---
layout: post
title: Render Methods in Blazor Chart Component | Syncfusion 
description: Learn about Render Methods in Blazor Chart component of Syncfusion, and more details.
platform: Blazor
control: Chart
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# Rendering Types

Chart uses following rendering methods.

* SVG
* Canvas

## SVG

SVG is used to render Chart by default for all browsers except IE8 and old versions.

## Canvas

You can switch between SVG and Canvas rendering by using the `EnableCanvas` option. The canvas mode rendering is used in the following scenarios,

* Plotting large number of data points.
* Performing high frequency live updates.

**Limitations**

* Animation is not supported.

> Note: You can refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations. You can also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to knows various chart types and how to represent time-dependent data, showing trends in data at equal intervals.

## See Also

* [Data label](./data-labels)
* [Tooltip](./tool-tip)
* [Legend](./legend)
* [Marker](./data-markers)