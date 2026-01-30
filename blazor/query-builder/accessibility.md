---
layout: post
title: Accessibility in Blazor Query Builder component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor ContextMenu component and more.
platform: Blazor
control: QueryBuilder
documentation: ug
---

# Accessibility in Blazor Query Builder component

The Blazor Query Builder follows widely accepted accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Query Builder is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | AAA |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">  |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) |<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>
<div><img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/intermediate.png" alt="Intermediate"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/no.png" alt="No"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

WAI-ARIA (Web Accessibility Initiative – Accessible Rich Internet Applications) defines a way to increase the accessibility of web pages, dynamic content, and user interface components. ARIA provides additional semantics to describe role, state, and functionality.

The following list of ARIA attributes is used in Blazor Query Builder.

| Attributes | Purpose |
| --- | --- |
| `role` | Identifies the Query Builder region and roles on interactive controls to assist screen readers. |

## Keyboard interaction

The Blazor Query Builder follows keyboard interaction guidelines, making it accessible for people who use assistive technologies (AT) and those who rely on keyboard navigation. The following keyboard shortcuts are supported.

| Windows | Mac | Actions |
| --- | --- | --- |
| <kbd>Tab</kbd> / <kbd>Shift + Tab</kbd> | <kbd>Tab</kbd> / <kbd>⇧</kbd> + <kbd>Tab</kbd> | Move focus between fields, operators, values, and action buttons within a rule. |

## Ensuring accessibility

The Blazor Query Builder’s accessibility levels are verified using [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with Playwright tests.

The accessibility compliance of the Blazor Query Builder is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/querybuilder) in a new window to evaluate the accessibility of the Blazor Query Builder with accessibility tools.

{% previewsample "https://ej2.syncfusion.com/accessibility/query-builder.html" %}

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)