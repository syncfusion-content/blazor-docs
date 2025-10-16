---
layout: post
title: Accessibility in Blazor Image Editor component | Syncfusion
description: Learn about accessibility support in the Blazor Image Editor component for Blazor Server and WebAssembly applications.
platform: Blazor
control: Image Editor
documentation: ug
---

# Accessibility in Blazor Image Editor component

The Blazor Image Editor component follows accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Image Editor component is outlined below.

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

## Keyboard interaction

The Blazor Image Editor component follows keyboard interaction guidelines, making it accessible for people who use assistive technologies (AT) and those who rely on keyboard navigation. The following keyboard shortcuts are supported by the Blazor Image Editor component.

| Windows | Mac | Actions |
| --- | --- | --- |
| <kbd>Ctrl</kbd> + <kbd>Z</kbd> | <kbd>⌘</kbd> + <kbd>Z</kbd> | Undo the last action. |
| <kbd>Ctrl</kbd> + <kbd>Y</kbd> | <kbd>⌘</kbd> + <kbd>Y</kbd> | Redo the last action. |
| <kbd>Ctrl</kbd> + <kbd>S</kbd> | <kbd>⌘</kbd> + <kbd>S</kbd> | Save the image. |
| <kbd>Ctrl</kbd> + <kbd>O</kbd> | <kbd>⌘</kbd> + <kbd>O</kbd> | Open an image. |
| <kbd>Delete</kbd> | <kbd>Delete</kbd> | Delete the selected shape. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Apply selection crop or image resize. |
| <kbd>Escape</kbd> | <kbd>Escape</kbd> | Discard operations such as annotation drawings and crop selections. |

## Ensuring accessibility

The Blazor Image Editor component's accessibility levels are validated using [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with Playwright tests.

The accessibility compliance of the Blazor Image Editor component is demonstrated in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/image-editor) in a new window to evaluate the Blazor Image Editor component with accessibility tools.

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXrICNDYqKacaGsS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)