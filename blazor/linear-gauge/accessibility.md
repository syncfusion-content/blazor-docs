---
layout: post
title: Accessibility in Blazor Linear Gauge Component | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor Linear Gauge component and more.
platform: Blazor
control: Linear Gauge
documentation: ug
---

# Accessibility in Blazor Linear Gauge Component

The [Blazor Linear Gauge](https://www.syncfusion.com/blazor-components/blazor-linear-gauge) component follows commonly used accessibility guidelines and standards, such as [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles).

The accessibility compliance for the Blazor Linear Gauge component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
| [Section 508 Support](../common/accessibility) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
| [Screen Reader Support](../common/accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Color Contrast](../common/accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Mobile Device Support](../common/accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
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

The Blazor Linear Gauge component followed the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/) patterns to meet the accessibility. The following `WAI-ARIA` attributes are used in the Linear Gauge component.

| Attributes | Purpose |
| --- | --- |
| `role=region` | It is specified in the title and pointer. The pointer supports the interactive drag-and-drop function to update the pointer value. |
| `aria-label` | Provides an accessible name for the title, axis labels, text pointer and annotation. |

## Screen reading in Linear Gauge

Accessibility in the Blazor Linear Gauge component ensures that all users, regardless of ability or disability, can use screen reading. The following Linear Gauge elements will be read aloud using screen reading software, such as Narrator for Windows.

| Elements | Description |
| --- | --- |
| Title | Reads the title of the Linear Gauge.|
| Axis labels | Reads the axis labels of the Linear Gauge.|
| Text pointer | Reads the text content shown as a pointer in Linear Gauge. |
| Annotation | Reads the content specified in the annotation. |

## Ensuring accessibility

The Blazor Linear Gauge component's accessibility levels are ensured through an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) software tool during automated testing.

The accessibility compliance of the Linear Gauge component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/lineargauge) in a new window to evaluate the accessibility of the Linear Gauge component with accessibility tools.
