---
layout: post
title: Accessibility in Blazor HeatMap Chart Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor HeatMap Chart component and much more.
platform: Blazor
control: HeatMap Chart
documentation: ug
---

# Accessibility in Blazor HeatMap Component

HeatMap has built-in accessibility features like screen reading. Screen reading in the HeatMap component allows all users, regardless of ability or disability, to use the component. The following HeatMap elements will be read aloud with screen reading software like Narrator for Windows.

| Elements | Description |
| --- | --- |
| Title | Reads the contents of the HeatMap chart's title. |
| Axis labels | Reads the x and y axis labels of the HeatMap chart. |
| Multilevel labels | Reads the multilevel labels in the x and y axis of the HeatMap chart. |
| Cell labels | Reads the labels from the cells in the Heatmap chart. |
| Legend title | Reads the contents of the legend's title as specified in HeatMap chart. |
| Legend item label | Reads the label of a legend item in HeatMap chart. |

## Ensuring accessibility

The HeatMap component's accessibility levels are ensured through an [accessibility-checker](https://www.npmjs.com/package/accessibility-checker) and [axe-core](https://www.npmjs.com/package/axe-core) software tools during automated testing.
