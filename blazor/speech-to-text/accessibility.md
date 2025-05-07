---
layout: post
title: Accessibility in Blazor SpeechToText Component | Syncfusion
description: Checkout and learn about Accessibility in Blazor SpeechToText component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: SpeechToText
documentation: ug
---

# Accessibility in Blazor SpeechToText component

The SpeechToText component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the SpeechToText component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Accessibility Checker Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |

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

The following ARIA attributes are used in the SpeechToText component:

| Attributes | Purpose |
| ------------ | ----------------------- |
| `aria-label` | Provides an accessible name for the SpeechToText button. |

## Keyboard interaction

The following keyboard shortcuts are supported by the SpeechToText component.

| Windows | Mac | Actions |
| --- | --- | --- |
| <kbd>Enter</kbd>/<kbd>Space</kbd> | <kbd>Enter</kbd>/<kbd>Space</kbd> | When the SpeechToText button has focus, pressing the enter/space key changes the state of the button. |

## Ensuring accessibility

The Blazor SpeechToText component's accessibility levels are ensured through an [axe-core](https://www.npmjs.com/package/axe-core) software tool during automated testing.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> components](../common/accessibility)
