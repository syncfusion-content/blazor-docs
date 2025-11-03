---
layout: post
title: Accessibility in Blazor Dashboard Layout Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor Dashboard Layout component and more.
platform: Blazor
control: Dashboard Layout
documentation: ug
---

# Accessibility in Blazor Dashboard Layout Component

The [Blazor Dashboard Layout](https://www.syncfusion.com/blazor-components/blazor-dashboard) component has been designed keeping in mind the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/) specifications, by applying the prompt `WAI-ARIA` roles, states, and properties. This component is characterized by ARIA accessibility support, which makes navigation easy for people who use assistive technologies (AT).

The Blazor Dashboard Layout component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Dashboard Layout component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2](https://www.w3.org/TR/WCAG22/) Support | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial"> |
| [Section 508](https://www.section508.gov/) Support | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial"> |
| Screen Reader Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Right-To-Left Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Color Contrast | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Mobile Device Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Keyboard Navigation Support | Not applicable |
| [Axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) Accessibility Validation | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/no.png" alt="No"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

The Blazor Dashboard Layout component followed the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/) patterns to meet the accessibility. The following ARIA attributes are used in the Dashboard Layout component:

| **Attributes** | **Purpose** |
| --- | --- |
| role=presentation | Indicates the role as a presentation for the table when the `showGridLines` property is enabled. |
| aria-grabbed | Indicates whether the attribute is set to `true`. It has been selected for dragging. If this attribute is set to `false`, the element can be grabbed for a drag-and-drop operation, but will not be currently grabbed.|

## Keyboard interaction

Keyboard support is not applicable for the Dashboard Layout.

## Ensuring accessibility

The Blazor Dashboard Layout component's accessibility levels are ensured through an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) software tool during automated testing.

The accessibility compliance of the Dashboard Layout component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/dashboardlayout) in a new window to evaluate the accessibility of the Dashboard Layout component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)