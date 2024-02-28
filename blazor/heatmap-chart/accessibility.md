---
layout: post
title: Accessibility in Blazor HeatMap chart component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor HeatMap chart component and much more.
platform: Blazor
control: HeatMap Chart
documentation: ug
---

# Accessibility in Blazor HeatMap component

HeatMap has built-in accessibility features like WAI-ARIA attributes.

## WAI-ARIA attributes

The HeatMap component followed the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/alert/) patterns to meet the accessibility. The following ARIA attributes are used in the HeatMap component:

| Attributes | Purpose |
| --- | --- |
| `role=img` | It is specified in the legend and border of the HeatMap. This role is provided to specify the information in a visual manner. |
| `aria-label` | Provides an accessible name for the gradient HeatMap cells. |
| `aria-hidden` | Provides an accessible name for the legends. |

## Screen reading in HeatMap

HeatMap has built-in accessibility features like screen reading. Screen reading in the HeatMap control allows all users, regardless of ability or disability, to use the control. The following HeatMap elements will be read aloud with screen reading software like Narrator for Windows.

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

The accessibility compliance of the HeatMap component is shown in [this sample](https://blazor.syncfusion.com/accessibility/heatmap). Open the sample in a new window to evaluate the accessibility of the HeatMap component with accessibility tools.
