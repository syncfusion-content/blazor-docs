---
layout: post
title: Accessibility in Blazor Circular Gauge Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor Circular Gauge component and more.
platform: Blazor
control: Circular Gauge
documentation: ug
---


# Accessibility in Blazor Circular Gauge Component

The Circular Gauge component follows commonly used accessibility guidelines and standards, such as [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles).

The accessibility compliance for the Circular Gauge component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
| [Section 508 Support](../common/accessibility) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
| [Screen Reader Support](../common/accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Right-To-Left Support](../common/accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Color Contrast](../common/accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Mobile Device Support](../common/accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Accessibility Checker Validation](../common/accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
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

The Circular Gauge component followed the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/alert/) patterns to meet the accessibility. The following ARIA attributes are used in the Circular Gauge component.


| Attributes | Purpose |
| --- | --- |
| `role=region` | It is specified in the pointer, annotation, and title. The pointer supports the interactive drag-and-drop function to update the pointer value. |
| `aria-label` | Provides an accessible name for the axis labels, title, legend item labels, text pointers and annotation. |

## Screen reading in Circular Gauge

Accessibility in the Circular Gauge component ensures that all users, regardless of ability or disability, can use screen reading. The following Circular Gauge elements will be read aloud using screen reading software, such as Narrator for Windows.

| Elements | Description |
| --- | --- |
| Axis labels | Reads the axis labels of the Circular Gauge. |
| Title | Reads the title of the Circular Gauge. |
| Legend item label | Reads the label of the legend item in the Circular Gauge. |
| Text pointer | Reads the text content shown as a pointer in Circular Gauge. |
| Annotation | Reads the content specified in the annotation. |

## Ensuring accessibility

The Circular Gauge component's accessibility levels are ensured through an [accessibility-checker](https://www.npmjs.com/package/accessibility-checker) and [axe-core](https://www.npmjs.com/package/axe-core) software tools during automated testing.

The accessibility compliance of the Circular Gauge component is shown in [this sample](https://blazor.syncfusion.com/accessibility/circulargauge). Open the sample in a new window to evaluate the accessibility of the Circular Gauge component with accessibility tools.
