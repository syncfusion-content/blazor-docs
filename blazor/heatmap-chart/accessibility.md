---
layout: post
title: Accessibility in Blazor HeatMap chart component | Syncfusion
description: Check out and learn here all about Accessibility in Syncfusion Blazor HeatMap chart component and much more.
platform: Blazor
control: HeatMap Chart
documentation: ug
---

# Accessibility in Blazor HeatMap Chart Component

The [Blazor HeatMap Chart](https://www.syncfusion.com/blazor-components/blazor-heatmap-chart) component follows widely recognized accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/), and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles).

The accessibility compliance for the Blazor HeatMap Chart component is summarized below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
| [Section 508 Support](../common/accessibility) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
| [Screen Reader Support](../common/accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Right-To-Left Support](../common/accessibility) | Not Applicable |
| [Color Contrast](../common/accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Mobile Device Support](../common/accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Keyboard Navigation Support](../common/accessibility) | Not Applicable |
| [Axe-core Accessibility Validation](../common/accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="No"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

The Blazor HeatMap Chart component follows [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/) patterns to ensure accessibility. The following WAI-ARIA attributes are used:

| Attribute | Purpose |
| --- | --- |
| `role=img` | Applied to the legend and border of the HeatMap to specify visual information. |
| `role=region` | Specifies HeatMap areas that do not support interactive functions like cell selection. |
| `aria-label` | Provides accessible names for the title, legend title, legend item labels, axis labels, cell labels, and multilevel labels. |

## Screen reading in HeatMap

The Blazor HeatMap Chart includes built-in accessibility features for screen readers. The following elements are read aloud by screen reading software:

| Element | Description |
| --- | --- |
| Title | Reads the HeatMap chart's title. |
| Axis labels | Reads the x and y axis labels. |
| Multilevel labels | Reads multilevel labels on both axes. |
| Cell labels | Reads the labels from the cells. |
| Legend title | Reads the legend's title. |
| Legend item label | Reads the label of a legend item. |

## Ensuring accessibility

The Blazor HeatMap component's accessibility is validated using the [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) tool during automated testing.

Accessibility compliance can be evaluated in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/heatmap) in a new window to review the HeatMap component's accessibility with accessibility tools.
