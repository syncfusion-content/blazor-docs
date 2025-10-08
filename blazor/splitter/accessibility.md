---
layout: post
title: Accessibility in Blazor Splitter Component | Syncfusion
description: Learn about the accessibility compliance of the Syncfusion Blazor Splitter component and more.
platform: Blazor
control: Splitter
documentation: ug
---

# Accessibility in Blazor Splitter Component

The [Blazor Splitter](https://www.syncfusion.com/blazor-components/blazor-splitter) component adheres to accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and commonly used [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) for evaluating accessibility.

The accessibility compliance for the Blazor Splitter component is outlined below.

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

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="No"> - The component does not meet the requirement.</div>


## Keyboard Interaction

The following key shortcuts can be used to access the Blazor Splitter without interruptions:

| Windows | Mac | Actions |
| --- | --- | --- |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Helps in focusing the splitter on the page and switching between the consecutive splitter bars. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Helps in focusing the previous splitter bar element on the splitter. |
| <kbd>→</kbd> | <kbd>→</kbd> | Helps in moving the active `Horizontal` orientated splitter bar to its `Right` side. |
| <kbd>←</kbd> | <kbd>←</kbd> | Helps in moving the active `Horizontal` orientated splitter bar to its `Left` side. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Helps in moving the active `Vertical` orientated splitter bar to its `Up` side. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Helps in moving the active `Vertical` orientated splitter bar to its `Down` side. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Helps to toggle between `Expand` and `Collapse` actions of the splitter bar when it is active. |

## Ensuring Accessibility

The Blazor Splitter component's accessibility levels are ensured through an [axe-core](https://www.npmjs.com/package/axe-core) software tool during automated testing.

The accessibility compliance of the Splitter component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/splitter) in a new window to evaluate the accessibility of the Splitter component with accessibility tools.

## See Also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> components](../common/accessibility)