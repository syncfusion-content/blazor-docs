---
layout: post
title: Blazor Bullet Chart Accessibility Examples | Syncfusion®
description: Learn how to enable accessibility in Syncfusion Blazor Bullet Chart with keyboard navigation, screen reader support, and WCAG 2.2 compliance.
platform: Blazor
control: Bullet Chart
documentation: ug
---

# Blazor Bullet Chart Accessibility

The Blazor Bullet Chart component follows accessibility guidelines and standards, including the [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), and [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, as well as [WAI-ARIA roles](https://www.w3.org/TR/wai-aria/#roles) commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Bullet Chart component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | AA |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
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

<div><img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="No"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

The Blazor Bullet Chart component follows [WAI-ARIA authoring practices](https://www.w3.org/WAI/ARIA/apg/) to support accessibility. The following roles and attributes are used in the Blazor Bullet Chart component:

* img (role)
* button (role)
* region (role)
* aria-label (attribute)
* aria-pressed (attribute)

## Keyboard Interaction

The Blazor Bullet Chart component follows [keyboard interface](https://www.w3.org/WAI/ARIA/apg/practices/keyboard-interface/) guidelines, making it easier for people who use assistive technologies (AT) or rely on keyboard navigation. The following keyboard shortcuts are supported by the Blazor Bullet Chart component.

| Windows | Mac | Description |
| --- | --- | --- |
| <kbd>Alt</kbd> + <kbd>J</kbd> | <kbd>⌥</kbd> + <kbd>J</kbd> | Moves focus to the Bullet Chart element. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Moves focus to the next element in the Bullet Chart. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Moves the focus to the previous element in the Bullet Chart. |
| <kbd>↑</kbd> / <kbd>→</kbd> | <kbd>↑</kbd> / <kbd>→</kbd> | Moves focus to the next legend item. |
| <kbd>↓</kbd> / <kbd>←</kbd> | <kbd>↓</kbd> / <kbd>←</kbd> | Moves focus to the previous legend item. |
| <kbd>Ctrl + P</kbd> | <kbd>⌘</kbd> + <kbd>P</kbd> | Prints the Bullet Chart. |

## Ensuring accessibility

The Blazor Bullet Chart component's accessibility is evaluated using the [accessibility-checker](https://www.npmjs.com/package/accessibility-checker) and [axe-core](https://www.npmjs.com/package/axe-core) tools during automated testing.

The accessibility compliance of the Blazor Bullet Chart component is demonstrated in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/bullet-chart) in a new window to evaluate the component with accessibility tools.


## See also

* [Accessibility in Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)