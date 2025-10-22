---
layout: post
title: Accessibility in Blazor CheckBox Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor CheckBox component and much more.
platform: Blazor
control: CheckBox
documentation: ug
---

# Accessibility in Blazor CheckBox Component

The Blazor CheckBox component follows established accessibility standards, including ADA, Section 508, and WCAG 2.2 guidelines. It supports screen readers, keyboard navigation, right-to-left (RTL) layouts, and high-contrast themes. For component details, see the CheckBox overview in the documentation (https://blazor.syncfusion.com/documentation/checkbox/) and the SfCheckBox API reference (https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfCheckBox.html). For enabling RTL at the component level, refer to Right-to-left support (./how-to/right-to-left).

The accessibility compliance for the Blazor CheckBox component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
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

The Blazor CheckBox component follows the WAI-ARIA Authoring Practices for checkboxes to ensure compatibility with assistive technologies. The following ARIA roles and attributes are used:

| Attributes | Purpose |
| --- | --- |
| `role="checkbox"` | Identifies the element as a checkbox control to assistive technologies. |
| `aria-checked` | Conveys the current state of the checkbox: `true`, `false`, or `mixed` (for indeterminate state). |
| `aria-disabled` | Indicates that the element is perceivable but disabled, so it is not editable or otherwise operable. |
| `aria-readonly` | Indicates that the value cannot be changed by the user (read-only state). |
| `aria-labelledby` / `aria-label` | Provides an accessible name. When the `Label` parameter is used, it associates a visible label with the checkbox. |
| `tabindex` | Ensures the checkbox is focusable via keyboard navigation in the expected order. |

For guidance on ARIA usage, see the ARIA checkbox pattern (https://www.w3.org/WAI/ARIA/apg/patterns/checkbox/).

## Keyboard interaction

The Blazor CheckBox component follows the keyboard interaction guidance, making it accessible to users who rely on keyboards or assistive technologies. The following keyboard shortcuts are supported:

| Windows | Mac | Actions |
| --- | --- | --- |
| <kbd>Tab</kbd> / <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>Tab</kbd> / <kbd>Shift</kbd> + <kbd>Tab</kbd> | Moves focus to the checkbox or away from it following the tab sequence. |
| <kbd>Space</kbd> | <kbd>Space</kbd> | When the CheckBox has focus, pressing Space toggles its state. |

For detailed keyboard recommendations, see the ARIA checkbox keyboard interaction guidance (https://www.w3.org/WAI/ARIA/apg/patterns/checkbox/#keyboardinteraction).

## Ensuring accessibility

The Blazor CheckBox component's accessibility levels are validated using axe-core with Playwright tests to catch common issues such as missing names, incorrect ARIA states, and insufficient color contrast. Results can vary based on theme customization; ensure color contrast meets WCAG minimum ratios.

The accessibility compliance of the Blazor CheckBox component is shown in the following sample. Open the sample in a new window to evaluate the component with accessibility tools.

{% previewsample "https://ej2.syncfusion.com/accessibility/checkbox.html" %}

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)