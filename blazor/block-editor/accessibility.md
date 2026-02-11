---
layout: post
title: Accessibility in Blazor Block Editor Component | Syncfusion
description: Checkout and learn about Accessibility and Keyboard interaction with Blazor Block Editor component and more details.
platform: Blazor
control: Block Editor
documentation: ug
---

# Accessibility in Blazor Block Editor component

The Blazor Block Editor component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Block Editor component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | AA |
| [Section 508 Support](../common/accessibility#accessibility-standards) |<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="No"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Accessibility Checker Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="No"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

The following ARIA attributes are recommended for the Blazor Block Editor to improve discoverability and operability by assistive technologies.

| Attribute | Purpose |
|---|---|
| `role="application"` | Applied to the outer editor container when the editor manages keyboard handling and behaves like an application. |
| `role="textbox"` + `contenteditable="true"` | Marks the editable region; pair with `aria-multiline="true"` for multi-line editing. |
| `aria-label` | Provides an accessible name for the editor or its regions (connect a visible or offscreen heading). |
| `aria-placeholder` | Short hint text for empty editing surfaces. |
| `aria-describedby` | Attach helper text or usage instructions (e.g., keyboard shortcuts). |
| `role="toolbar"` | Applied to the formatting toolbar container. Use `aria-orientation` when needed. |
| `aria-pressed` | For toggle toolbar buttons (bold/italic) to indicate on/off state. |
| `aria-haspopup` / `aria-controls` / `aria-expanded` | For controls that open popups or dialogs; `aria-controls` should reference the popup `id`. |
| `aria-readonly` / `aria-disabled` | Mark non-editable editor surfaces and disabled toolbar controls. |
| `aria-hidden` | Hide offscreen or collapsed regions from assistive technologies. |
| `aria-owns` | Use only when DOM order prevents a meaningful parent/child relationship and explicit ownership is required. |

## Keyboard interaction

The Blazor Block Editor component follows [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/alert/#keyboardinteraction) guidelines, making it easy for people who use assistive technologies (AT) or rely solely on keyboard navigation. The component supports a variety of keyboard shortcuts for common actions.

For a complete list of keyboard shortcuts, refer to the [Keyboard Support](https://blazor.syncfusion.com/documentation/block-editor/keyboard-shortcuts) documentation.

## Ensuring accessibility

The Blazor Block Editor component's accessibility levels are ensured through an [axe-core](https://www.npmjs.com/package/axe-core) software tool during automated testing.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> components](../common/accessibility)
