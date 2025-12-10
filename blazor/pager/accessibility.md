---
layout: post
title: Accessibility Support in the Blazor Pager Component | Syncfusion
description: Learn about accessibility features and compliance in the Syncfusion Blazor Pager component, including WAI-ARIA roles and keyboard navigation.
platform: Blazor
control: Pager
documentation: ug
---

# Accessibility in Blazor Pager Component

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Pager component is designed to meet widely recognized accessibility standards, ensuring compatibility with assistive technologies and delivering an inclusive experience. It adheres to the following guidelines:

- [ADA](https://www.ada.gov/) – Americans with Disabilities Act compliance for accessible digital content.
- [Section 508](https://www.section508.gov/) – U.S. federal accessibility requirements for software applications.
- [WCAG 2.2](https://www.w3.org/TR/WCAG22/) – Web Content Accessibility Guidelines for perceivable, operable, and understandable content.
- [WAI-ARIA Roles](https://www.w3.org/TR/wai-aria/#roles) – Accessible Rich Internet Applications specifications for improved interaction with assistive technologies.

## Accessibility Compliance

The table below lists the accessibility features supported by the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Pager component:

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">  |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>

**Legend:**

<div><img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> - Fully meets the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> - Partially meets the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="No"> - Does not meet the requirement.</div>

## WAI-ARIA

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Pager component applies Accessible Rich Internet Applications ([WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/)) roles and attributes to improve interoperability with assistive technologies.

| **Element**         | **Purpose**                                      | **Applied Role / Attribute**       |
|----------------------|--------------------------------------------------|-------------------------------------|
| Pager root container | Identifies the region as page navigation        | `role="navigation"`                |
| Pager wrapper        | Groups the collection of page selectors         | `role="pager"`                     |
| Page selector        | Represents an interactive control for page selection | `role="button"`                |
| Navigation region    | Provides an accessible name for the navigation area | `aria-label="<descriptive text>"` |


## Keyboard navigation

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Pager component supports keyboard interactions to ensure accessibility for individuals relying on assistive technologies or keyboard navigation. The available shortcuts are:

| **Windows**                     | **Mac**                          | **Action**                                |
|---------------------------------|----------------------------------|-------------------------------------------|
| <kbd>Page Down</kbd> / <kbd>→</kbd> | <kbd>Page Down</kbd> / <kbd>→</kbd> | Navigate to the next page                |
| <kbd>Page Up</kbd> / <kbd>←</kbd>   | <kbd>Page Up</kbd> / <kbd>←</kbd>   | Navigate to the previous page            |
| <kbd>Enter</kbd> / <kbd>Space</kbd> | <kbd>Enter</kbd> / <kbd>Space</kbd> | Select the currently focused page        |
| <kbd>Tab</kbd>                      | <kbd>Tab</kbd>                      | Move focus to the next pager item        |
| <kbd>Shift</kbd> + <kbd>Tab</kbd>   | <kbd>⇧</kbd> + <kbd>Tab</kbd>       | Move focus to the previous pager item    |
| <kbd>Home</kbd>                     | <kbd>Home</kbd>                     | Navigate to the first page               |
| <kbd>End</kbd>                      | <kbd>End</kbd>                      | Navigate to the last page                |
| <kbd>Alt</kbd> + <kbd>Page Up</kbd> | <kbd>⌥</kbd> + <kbd>Page Up</kbd>   | Navigate to the previous pager group     |
| <kbd>Alt</kbd> + <kbd>Page Down</kbd>| <kbd>⌥</kbd> + <kbd>Page Down</kbd> | Navigate to the next pager group         |


## Ensuring accessibility

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Pager component’s accessibility compliance is validated using [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) integrated with Playwright tests. This automated testing ensures adherence to accessibility standards and identifies potential issues.

An interactive sample is available to evaluate the component’s accessibility using standard tools:

- [Accessibility Evaluation Sample](https://blazor.syncfusion.com/accessibility/pager)

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)