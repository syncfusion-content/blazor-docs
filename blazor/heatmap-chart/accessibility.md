---
layout: post
title: Accessibility in Blazor HeatMap chart component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor HeatMap chart component and much more.
platform: Blazor
control: HeatMap Chart
documentation: ug
---

# Accessibility in Blazor HeatMap Chart component

The [Blazor HeatMap Chart](https://www.syncfusion.com/blazor-components/blazor-heatmap-chart) component follows commonly used accessibility guidelines and standards, such as [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles).

The accessibility compliance for the Blazor HeatMap Chart component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility) | AAA |
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

Blazor HeatMap Chart component followed the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/) patterns to meet the accessibility. The following `WAI-ARIA` attributes are used in the HeatMap component.

| Attributes | Purpose |
| --- | --- |
| `role=img` | It is specified in the legend and border of the HeatMap. This role is provided to specify the information in a visual manner. |
| `role=region` | It specifies the HeatMap areas that do not support interactive functions like cell selection. |
| `aria-label` | Provides an accessible name for the title, legend title, legend item labels, axis labels, cell labels and multilevel labels. |

## Screen reading in HeatMap

Blazor HeatMap Chart has built-in accessibility features like screen reading. Screen reading in the HeatMap component allows all users, regardless of ability or disability, to use the component. The following HeatMap elements will be read aloud with screen reading software like Narrator for Windows.

| Elements | Description |
| --- | --- |
| Title | Reads the contents of the HeatMap chart's title. |
| Axis labels | Reads the x and y axis labels of the HeatMap chart. |
| Multilevel labels | Reads the multilevel labels in the x and y axis of the HeatMap chart. |
| Cell labels | Reads the labels from the cells in the Heatmap chart. |
| Legend title | Reads the contents of the legend's title as specified in HeatMap chart. |
| Legend item label | Reads the label of a legend item in HeatMap chart. |

## Ensuring accessibility

The Blazor HeatMap component's accessibility levels are ensured through an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) software tool during automated testing.

The accessibility compliance of the HeatMap component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/heatmap) in a new window to evaluate the accessibility of the HeatMap component with accessibility tools.
