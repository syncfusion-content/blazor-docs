---
layout: post
title: Accessibility in Blazor TreeMap Component | Syncfusion
description: Check out and learn here all about Accessibility in Syncfusion Blazor TreeMap component and much more.
platform: Blazor
control: TreeMap
documentation: ug
---

# Accessibility in Blazor TreeMap Component

The [Blazor TreeMap](https://www.syncfusion.com/blazor-components/blazor-treemap) component adheres to widely adopted accessibility standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/), and [WAI-ARIA roles](https://www.w3.org/TR/wai-aria/#roles).

The accessibility compliance for the Blazor TreeMap component is summarized below.

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

The Blazor TreeMap component follows [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/) patterns to support accessibility. The following ARIA attributes are used in the TreeMap component:

| Attributes | Purpose |
| --- | --- |
| `role=region` | Identifies TreeMap areas without interactive behavior such as selection or highlight. |
| `role=button` | Identifies TreeMap areas where interactive behavior such as selection or highlight is available. |
| `aria-label` | Provides accessible names for the title, subtitle, data labels, legend title, and legend item labels. |

## Screen reading in TreeMap

Accessibility support in the Blazor TreeMap component enables screen readers to announce relevant content. The following TreeMap elements are read by screen readers such as Narrator on Windows.

| Elements | Description |
| --- | --- |
| Data labels | Announces the labels displayed on leaf items of the TreeMap. |
| Title | Announces the TreeMap title. |
| Subtitle | Announces the subtitle below the main title. |
| Legend title | Announces the legend title in the TreeMap. |
| Legend item label | Announces the label of each legend item in the TreeMap. |

## Ensuring accessibility

The Blazor TreeMap component’s accessibility is validated using the [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) tool during automated testing.

The accessibility compliance of the TreeMap component is demonstrated in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/treemap) in a new window to evaluate TreeMap accessibility with testing tools.
