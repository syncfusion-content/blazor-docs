---
layout: post
title: Accessibility in Blazor Dropdown Menu Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor Dropdown Menu component and more.
platform: Blazor
control: Dropdown Menu
documentation: ug
---

# Accessibility in Blazor Dropdown Menu Component

The Dropdown Menu component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Dropdown Menu component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2](https://www.w3.org/TR/WCAG22/) Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Section 508](https://www.section508.gov/) Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Screen Reader Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Right-To-Left Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Color Contrast | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Mobile Device Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Keyboard Navigation Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Accessibility Checker](https://www.npmjs.com/package/accessibility-checker) Validation | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Axe-core](https://www.npmjs.com/package/axe-core) Accessibility Validation | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |

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

The Dropdown Menu component followed the [WAI-ARIA] patterns to meet the accessibility. The following ARIA attributes are used in the Dropdown Menu component:

| Attributes | Purpose |
| --- | --- |
| `role` | Indicates the Dropdown Menu component as `button`, Dropdown Menu popup as `menu`, and the dropdown popup action items as `menuitem`. |
| `aria-haspopup` | Indicates the availability of the popup element. |
| `aria-expanded` | Indicates whether the popup can be expanded or collapsed, as well as indicates whether its current state is expanded or collapsed. |
| `aria-owns` | Identifies an elements in order to define a visual, functional, or contextual parent/child relationship between DOM elements where the DOM hierarchy cannot be used to represent the relationship. |
| `aria-disabled` | Indicates that the element is perceivable but disabled, so it is not editable or otherwise operable. |

## Keyboard interaction

The Dropdown button component followed the [keyboard interaction] guideline, making it easy for people who use assistive technologies (AT) and those who completely rely on keyboard navigation. The following keyboard shortcuts are supported by the Dropdown Menu component.

| **Press** | **To do this** |
| --- | --- |
| <kbd>Esc</kbd> | Closes the popup. |
| <kbd>Enter</kbd> | Opens the popup, or activates the highlighted item and closes the popup. |
| <kbd>Space</kbd> | Opens the popup. |
| <kbd>Up</kbd> | Navigates up or to the previous action item. |
| <kbd>Alt + Up Arrow</kbd> | Closes the popup. |
| <kbd>Alt + Down Arrow</kbd> | Opens the popup. |

## Ensuring accessibility

The Drop down component's accessibility levels are ensured through an [accessibility-checker](https://www.npmjs.com/package/accessibility-checker) and [axe-core](https://www.npmjs.com/package/axe-core) software tools during automated testing.

The accessibility compliance of the Dropdown Menu component is shown in the following sample. Open the [sample](https://ej2.syncfusion.com/accessibility/drop-down-button.html) in a new window to evaluate the accessibility of the Dropdown Menu component with accessibility tools.

{% previewsample "https://ej2.syncfusion.com/accessibility/drop-down-button.html" %}

## See also
![Accessibility in Blazor DropDownMenu](./images/blazor-dropdownmenu-component.png)