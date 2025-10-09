---
layout: post
title: Accessibility in Blazor Circular Gauge Component | Syncfusion
description: Check out and learn about Accessibility support in the Syncfusion Blazor Circular Gauge component.
platform: Blazor
control: Circular Gauge
documentation: ug
---


# Accessibility in Blazor Circular Gauge Component

The [Blazor Circular Gauge](https://www.syncfusion.com/blazor-components/blazor-circular-gauge) component adheres to widely used accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/), and [WAI-ARIA roles](https://www.w3.org/TR/wai-aria/#roles).

The accessibility compliance for the Blazor Circular Gauge component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
| [Section 508 Support](../common/accessibility) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
| [Screen Reader Support](../common/accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Right-To-Left Support](../common/accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
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

The Blazor Circular Gauge component follows [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/) patterns to meet accessibility requirements. The following WAI-ARIA attributes are used in the Circular Gauge component.

| Attributes | Purpose |
| --- | --- |
| `role=region` | Applied to the pointer, annotation, and title. The pointer supports interactive drag-and-drop to update its value. |
| `aria-label` | Provides accessible names for axis labels, title, legend item labels, text pointers, and annotations. |

## Screen reading in Circular Gauge

Accessibility in the Blazor Circular Gauge ensures that all users, regardless of ability, can rely on screen readers. The following Circular Gauge elements are announced by screen readers such as Narrator on Windows.

| Elements | Description |
| --- | --- |
| Axis labels | Reads the axis labels of the Circular Gauge. |
| Title | Reads the title of the Circular Gauge. |
| Legend item label | Reads the label of the legend item in the Circular Gauge. |
| Text pointer | Reads the text content shown as a pointer in the Circular Gauge. |
| Annotation | Reads the content specified in the annotation. |

## Ensuring accessibility

Accessibility for the Blazor Circular Gauge component is validated using the [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) testing library during automated testing.

The accessibility compliance of the Circular Gauge component is demonstrated in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/circulargauge) in a new window to evaluate the accessibility of the Circular Gauge component with accessibility tools.
