---
layout: post
title: Accessibility in Blazor TreeMap Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor TreeMap component and much more.
platform: Blazor
control: TreeMap
documentation: ug
---

# Accessibility in Blazor TreeMap Component

TreeMap has built-in accessibility features like screen reading and WAI-ARIA attributes.

## WAI-ARIA attributes

The TreeMap component follows the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/alert/) patterns to meet the accessibility. The following ARIA attributes are used in the TreeMap component:

| Attributes | Purpose |
| --- | --- |
| `role=region` | It specifies the TreeMap areas that do not support interactive functions like selection and highlight. |
| `aria-label` | Provides an accessible name for the title, sub-title and TreeMap leaf items. |

## Screen reading in TreeMap

Accessibility in the TreeMap component ensures that all users, regardless of ability or disability, can use screen reading. The following TreeMap elements will be read aloud using screen reading software, such as Narrator for Windows.

| Elements | Description |
| --- | --- |
| Data labels | Reads the labels displayed on leaf items of the TreeMap. |

## Ensuring accessibility

The TreeMap component's accessibility levels are ensured through an [accessibility-checker](https://www.npmjs.com/package/accessibility-checker) and [axe-core](https://www.npmjs.com/package/axe-core) software tools during automated testing.

The accessibility compliance of the TreeMap component is shown in [this sample](https://blazor.syncfusion.com/accessibility/treemap). Open the sample in a new window to evaluate the accessibility of the TreeMap component with accessibility tools.
