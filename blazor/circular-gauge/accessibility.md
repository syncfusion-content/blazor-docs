---
layout: post
title: Accessibility in Blazor Circular Gauge Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor Circular Gauge component and more.
platform: Blazor
control: Circular Gauge
documentation: ug
---


# Accessibility in Blazor Circular Gauge Component

Circular Gauge has built-in accessibility features like screen reading and WAI-ARIA attributes.

## WAI-ARIA attributes

The Circular Gauge component followed the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/alert/) patterns to meet the accessibility. The following ARIA attributes are used in the Circular Gauge component:


| Attributes | Purpose |
| --- | --- |
| `role=region` | It is specified in the pointer, annotation, and title. The pointer supports the interactive drag-and-drop function to update the pointer value. |
| `aria-label` | Provides an accessible name for the title, pointers and annotation. |

## Screen reading in Circular Gauge

Accessibility in the Circular Gauge component ensures that all users, regardless of ability or disability, can use screen reading. The following Circular Gauge elements will be read aloud using screen reading software, such as Narrator for Windows.

| Elements | Description |
| --- | --- |
| Title | Reads the title of the Circular Gauge. |

## Ensuring accessibility

The Circular Gauge component's accessibility levels are ensured through an [accessibility-checker](https://www.npmjs.com/package/accessibility-checker) and [axe-core](https://www.npmjs.com/package/axe-core) software tools during automated testing.

The accessibility compliance of the Circular Gauge component is shown in [this sample](https://blazor.syncfusion.com/accessibility/circulargauge). Open the sample in a new window to evaluate the accessibility of the Circular Gauge component with accessibility tools.
