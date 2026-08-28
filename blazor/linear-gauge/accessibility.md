---
layout: post
title: Accessibility in Blazor Linear Gauge | Syncfusion®
description: Discover the Blazor Linear Gauge accessibility compliance for WCAG 2.2, Section 508, WAI-ARIA roles, screen reader support, and axe-core validation.
platform: Blazor
control: Linear Gauge
documentation: ug
---

# Accessibility in Blazor Linear Gauge

The [Blazor Linear Gauge](https://www.syncfusion.com/blazor-components/blazor-linear-gauge) is a data visualization component for rendering numeric values along a linear scale. Accessibility features such as WAI-ARIA attributes, screen reader support, and keyboard interaction are built in so that users with diverse abilities can interpret gauge values.

The following sections describe the accessibility standards supported, the WAI-ARIA attributes applied, and the elements exposed to assistive technologies.

## Accessibility compliance

The Blazor Linear Gauge component follows common accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/), and [WAI-ARIA roles](https://www.w3.org/TR/wai-aria/#roles).

The accessibility compliance for the Blazor Linear Gauge component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility) | AA |
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

The Blazor Linear Gauge component follows the [WAI-ARIA Authoring Practices](https://www.w3.org/WAI/ARIA/apg/) to meet accessibility requirements. The following `WAI-ARIA` attributes are used in the Linear Gauge component.

| Attributes | Purpose |
| --- | --- |
| `role=region` | Defines a landmark region for the gauge and is applied to the title and pointer elements. The pointer acts as an interactive control that supports drag-and-drop to update its value. |
| `aria-label` | Provides an accessible name for the title, axis labels, text pointer, and annotation elements. |
## Screen reading in Linear Gauge

Accessibility in the Blazor Linear Gauge component ensures that all users, regardless of ability or disability, can use screen reading. The following Linear Gauge elements will be read aloud using screen reading software, such as Narrator for Windows.

| Elements | Description |
| --- | --- |
| Title | Reads the title of the Linear Gauge. |
| Axis labels | Reads the axis labels of the Linear Gauge. |
| Text pointer | Reads the text content shown as a pointer in the Linear Gauge. |
| Annotation | Reads the content specified in the annotation. |

## Ensuring accessibility

Accessibility in the Blazor Linear Gauge component is validated using the [axe-core](https://www.deque.com/axe/core-documentation/) accessibility testing engine during automated regression testing. The integrated [Deque.AxeCore.Playwright](https://www.nuget.org/packages/Deque.AxeCore.Playwright) NuGet package is used to execute axe-core checks against the rendered Linear Gauge.

The accessibility compliance of the Linear Gauge component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/lineargauge) in a new window to evaluate the accessibility of the Linear Gauge component with accessibility tools.
## See also

* [Getting Started with Blazor Linear Gauge](getting-started.md)
* [Blazor Linear Gauge User Interaction](user-interaction.md)
* [Internationalization in Blazor Linear Gauge](internationalization.md)
* [Accessibility in Syncfusion Blazor Components](../common/accessibility)
