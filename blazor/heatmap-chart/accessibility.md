---
layout: post
title: Accessibility in Blazor HeatMap Chart Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor HeatMap Chart component and much more.
platform: Blazor
control: HeatMap Chart
documentation: ug
---

# Accessibility in Blazor HeatMap Component

HeatMap has built-in accessibility features like WAI-ARIA attributes.

## WAI-ARIA attributes

The HeatMap component followed the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/alert/) patterns to meet the accessibility. The following ARIA attributes are used in the HeatMap component:

| Attributes | Purpose |
| --- | --- |
| `role=img` | It is specified in the legend and border of the heatmap element. It is used to identify the specified element is a SVG element in the HeatMap component. |
| `aria-label` | Provides an accessible name for the gradient heatmap cells. |
| `aria-hidden` | Provides an accessible name for the legends. |

## Ensuring accessibility

The HeatMap component's accessibility levels are ensured through an [accessibility-checker](https://www.npmjs.com/package/accessibility-checker) and [axe-core](https://www.npmjs.com/package/axe-core) software tools during automated testing.
