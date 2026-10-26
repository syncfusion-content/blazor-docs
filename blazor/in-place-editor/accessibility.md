---
layout: post
title: Accessibility in Blazor In-place Editor | Syncfusion
description: Learn how Blazor In-place Editor supports accessibility standards, keyboard navigation, screen readers, and ARIA attributes.
platform: Blazor
control: In-place Editor
documentation: ug
---

# Accessibility in Blazor In-place Editor

The [Blazor In-place editor](https://www.syncfusion.com/blazor-components/blazor-in-place-editor) component follows accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/), and [WAI‑ARIA](https://www.w3.org/TR/wai-aria/) specifications that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor In-place Editor component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | AA |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> |
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>
<div><img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> - All features of the component meet the requirement.</div>
<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partially meets requirement"> - Some features of the component do not meet the requirement.</div>
<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="Not supported"> - The component does not meet the requirement.</div>

## Keyboard interaction

Use the following key shortcuts to operate the Blazor In-place Editor efficiently with a keyboard:

| Windows | Mac | Actions |
| --- | --- | --- |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Move focus to the Blazor In-place Editor on the page and navigate forward between consecutive Blazor In-place Editor instances. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Move focus to the previous Blazor In-place Editor instance or to the previous focusable element. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Switches the Blazor In-place Editor to edit mode. |
| <kbd>Esc</kbd> | <kbd>Esc</kbd> | Cancels the edit and switches the Blazor In-place Editor back to display mode. |

## Ensuring accessibility

The Blazor In-place editor component's accessibility is validated with the [axe-core](https://www.npmjs.com/package/axe-core) tool during automated testing.

The accessibility compliance of the Blazor In-place Editor component is demonstrated in the following sample. Open the [accessibility sample for Blazor In-place Editor](https://blazor.syncfusion.com/accessibility/inplace-editor) in a new window to evaluate accessibility with your preferred tools.

## See also

- [Accessibility in Blazor components](../common/accessibility)
