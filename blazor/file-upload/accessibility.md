---
layout: post
title: Accessibility in Blazor File Upload Component | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor File Upload component and more.
platform: Blazor
control: File Upload
documentation: ug
---

# Accessibility in Blazor File Upload Component

The [Blazor Uploader](https://www.syncfusion.com/blazor-components/blazor-file-upload) component adheres to accepted accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) commonly used to evaluate accessibility. The component provides ARIA-compliant structures for buttons and status updates to ensure compatibility with screen readers and assistive technologies.

The accessibility compliance for the Blazor Uploader component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>
<div><img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> - Some features of the component do not fully meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="No"> - The component does not meet the requirement.</div>

## Keyboard interaction

The Blazor Uploader component includes complete ARIA support for operation with screen readers and other assistive technologies. Focus moves predictably through interactive elements such as the browse button, file list items, and action buttons (remove, retry, and clear). Status updates (for example, upload progress and error messages) are exposed to assistive technologies.

The following are the standard keys that work in the Uploader component:

| Windows | Mac | Actions |
| --- | --- | --- |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Move focus to the next focusable element. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Move focus to the previous focusable element. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Invoke the action of the focused button or control. |
| <kbd>Esc</kbd> | <kbd>Esc</kbd> | Close only the file browser dialog and cancel an in-progress upload when a file is being dropped. |

## Ensuring accessibility

The Blazor Uploader component's accessibility levels are validated using the [axe-core](https://www.npmjs.com/package/axe-core) tool during automated testing. The component supports ARIA attributes, roles, and live region announcements for status changes to improve the experience for screen reader users. Text labels, button tooltips, and status messages can be localized to support accessibility across languages and regions.

The accessibility compliance of the Uploader component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/uploader) in a new window to evaluate the accessibility of the Uploader component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> components](../common/accessibility)