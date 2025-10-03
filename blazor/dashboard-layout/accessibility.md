---
layout: post
title: Accessibility in Blazor Dashboard Layout Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor Dashboard Layout component and more.
platform: Blazor
control: Dashboard Layout
documentation: ug
---

# Accessibility in Blazor Dashboard Layout Component

The [Blazor Dashboard Layout](https://www.syncfusion.com/blazor-components/blazor-dashboard) component is designed with a strong focus on accessibility, adhering to the [WAI-ARIA (Web Accessibility Initiative - Accessible Rich Internet Applications)](https://www.w3.org/WAI/ARIA/apg/patterns/) specifications. It applies appropriate WAI-ARIA roles, states, and properties to ensure intuitive navigation and interaction for users relying on assistive technologies (AT).

The component follows established accessibility guidelines and standards, including the [ADA (Americans with Disabilities Act)](https://www.ada.gov/), [Section 508](https://www.section508.gov/), and [WCAG 2.2 (Web Content Accessibility Guidelines)](https://www.w3.org/TR/WCAG22/) standards. It also incorporates [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility features.

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

## WAI-ARIA Attributes

The Blazor Dashboard Layout component integrates [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/) patterns to enhance accessibility. The following ARIA attributes are used within the Dashboard Layout component:

| **Attributes** | **Purpose** |
| --- | --- |
| role=presentation | Indicates the role as a presentation for the table when the `showGridLines` property is enabled. |
| aria-grabbed | Indicates whether the attribute is set to `true`. It has been selected for dragging. If this attribute is set to `false`, the element can be grabbed for a drag-and-drop operation, but will not be currently grabbed.|

## Keyboard Interaction

Keyboard support is not applicable for the Dashboard Layout.

## Ensuring Accessibility

The accessibility levels of the Blazor Dashboard Layout component are verified through automated testing using the [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) software tool.


A sample demonstrating the accessibility compliance of the Dashboard Layout component is available. Open the [sample](https://blazor.syncfusion.com/accessibility/dashboardlayout) in a new window to evaluate its accessibility using various tools.

## See Also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)