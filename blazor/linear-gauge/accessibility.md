---
layout: post
title: Accessibility in Blazor Linear Gauge Component | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor Linear Gauge component and more.
platform: Blazor
control: Linear Gauge
documentation: ug
---

# Accessibility in Blazor Linear Gauge Component

Linear Gauge has built-in accessibility features like screen reading and WAI-ARIA attributes.

## WAI-ARIA attributes

The Linear Gauge component followed the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/alert/) patterns to meet the accessibility. The following ARIA attributes are used in the Linear Gauge component:

| Attributes | Purpose |
| --- | --- |
| `role=region` | It is specified in the title and pointer. In the pointer where the interactive drag and drop function is supported to update the pointer value. |
| `aria-label` | Provides an accessible name for the pointers and title. |

## Screen reading in Linear Gauge

Accessibility in the Linear Gauge component ensures that all users, regardless of ability or disability, can use screen reading. The following Linear Gauge elements will be read aloud using screen reading software, such as Narrator for Windows.

| Elements | Description |
| --- | --- |
| Axis labels | Reads the axis labels of the Linear Gauge.|
| Text pointer | Reads the text content shown as a pointer in Linear Gauge. |
| Annotation | Reads the content specified in the annotation. |

## Ensuring accessibility

The Linear Gauge component's accessibility levels are ensured through an [accessibility-checker](https://www.npmjs.com/package/accessibility-checker) and [axe-core](https://www.npmjs.com/package/axe-core) software tools during automated testing.