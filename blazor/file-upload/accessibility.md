---
layout: post
title: Accessibility in Blazor File Upload Component | Syncfusion
description: Learn about accessibility features in the Syncfusion Blazor File Upload component, including support for WCAG 2.2, Section 508, and ARIA standards.
platform: Blazor
control: File Upload
documentation: ug
---

# Accessibility in Blazor File Upload Component

The Syncfusion [Blazor File Upload](https://www.syncfusion.com/blazor-components/blazor-file-upload) component follows accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), and [WCAG 2.2](https://www.w3.org/TR/WCAG22/). It offers built-in ARIA accessibility support, making it compatible with screen readers and other assistive technologies.

The accessibility compliance for the Blazor File Upload component is outlined below:

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Right-To-Left (RTL) Support](../common/accessibility#right-to-left-rtl-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Color Contrast Support](../common/accessibility#color-contrast-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
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

## Keyboard Navigation

The Blazor Uploader component includes complete ARIA support for operation with screen readers and other assistive technologies. Focus moves predictably through interactive elements such as the browse button, file list items, and action buttons (remove, retry, and clear). Status updates (for example, upload progress and error messages) are exposed to assistive technologies.

The following are the standard keys that work in the Uploader component:

| Windows | Mac | Actions |
| --- | --- | --- |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Moves focus to the next focusable element. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Moves focus to the previous focusable element. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Triggers the action associated with the focused button element. |
| <kbd>Esc</kbd> | <kbd>Esc</kbd> | Closes the file selection dialog. If a file drop is in progress, it cancels the upload. |

## Ensuring Accessibility

The Blazor File Upload component's accessibility levels are ensured through an [axe-core](https://www.npmjs.com/package/axe-core) software tool during automated testing.

The accessibility compliance of the File Upload component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/uploader) in a new window to evaluate the accessibility of the component with accessibility tools.

## See Also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Components](../common/accessibility)