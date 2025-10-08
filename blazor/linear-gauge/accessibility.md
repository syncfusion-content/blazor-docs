---
layout: post
title: Accessibility in Blazor Linear Gauge Component | Syncfusion
description: Check out and learn here all about accessibility in Syncfusion Blazor Linear Gauge component and more.
platform: Blazor
control: Linear Gauge
documentation: ug
---

# Accessibility in Blazor Linear Gauge Component

The [Blazor Linear Gauge](https://www.syncfusion.com/blazor-components/blazor-linear-gauge) component adheres to widely recognized accessibility standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/), and applicable [WAI-ARIA roles](https://www.w3.org/TR/wai-aria/#roles).

The accessibility compliance for the Blazor Linear Gauge component is outlined below.

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

The Blazor Linear Gauge component follows [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/) patterns to support accessibility. The following ARIA attributes are used in the Linear Gauge component.

| Attributes | Purpose |
|-----|-----|
| `role=region` | Applied to the title and interactive pointer elements to identify landmark content and support pointer interactions such as drag-and-drop. |
| `aria-label` | Provides accessible names for the title, axis labels, text pointer, and annotations. |

## Screen reading in Linear Gauge

Accessibility features ensure that content is available to screen readers. The following Linear Gauge elements are announced by screen-reading software, such as Narrator on Windows.

| Elements | Description |
|-----|-----|
| Title | Announces the Linear Gauge title.|
| Axis labels | Announces the axis labels in the Linear Gauge.|
| Text pointer | Announces the text content shown as a pointer in the Linear Gauge. |
| Annotation | Announces the content provided in the annotation. |

## Ensuring accessibility

The Blazor Linear Gauge component's accessibility is validated using the [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) tool during automated testing.

The accessibility compliance of the Linear Gauge component is demonstrated in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/lineargauge) in a new window to evaluate the component with accessibility tools.
