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

## Ensuring accessibility

The HeatMap component's accessibility levels are ensured through an [accessibility-checker](https://www.npmjs.com/package/accessibility-checker) and [axe-core](https://www.npmjs.com/package/axe-core) software tools during automated testing.

The accessibility compliance of the HeatMap component is shown in [this sample](https://blazor.syncfusion.com/accessibility/heatmap). Open the sample in a new window to evaluate the accessibility of the HeatMap component with accessibility tools.
