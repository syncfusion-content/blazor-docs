---
layout: post
title: Accessibility in Blazor Accordion | Syncfusion®
description: Learn how Blazor Accordion meets WCAG 2.2, Section 508, and ADA standards with WAI-ARIA roles, states, properties, and full keyboard navigation.
platform: Blazor
control: Accordion
documentation: ug
---

# Accessibility in Blazor Accordion

The [Blazor Accordion](https://www.syncfusion.com/blazor-components/blazor-accordion) component has been designed keeping in mind the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/accordion/) specifications, by applying the appropriate WAI-ARIA roles, states, and properties along with keyboard support. This makes it usable for people who rely on assistive technologies, with information about the elements exposed through attributes like `aria-labelledby`. It helps to provide information about the elements in a document for assistive technology. The component implements keyboard navigation by following the [WAI-ARIA practices](https://www.w3.org/WAI/ARIA/apg/) and is tested in major screen readers, including NVDA 2023+, JAWS 2024+, VoiceOver (macOS/iOS), and TalkBack (Android).

The Blazor Accordion component follows accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Accordion component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2](https://www.w3.org/TR/WCAG22/) Support | AA |
| [Section 508](https://www.section508.gov/) Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Screen Reader Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Right-To-Left Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Color Contrast | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Mobile Device Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Keyboard Navigation Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) Accessibility Validation | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/no.png" alt="No"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

| Attributes             | Purpose |
|----------------------|---------------|
| role                 | **Button:** Attribute is set to the Accordion header elements to indicate that the element can be used to toggle the visibility of the associated content section, describing the actual role of the element.<br> **Region:** Attribute is set to the Accordion panel elements to create a landmark region that contains the currently expanded Accordion panel, describing the actual role of the element.  |
| aria-labelledby      | Attribute is set to content (panel) and it points to the corresponding Accordion header. |
| aria-controls        | Attribute is set to the header and it points to the corresponding Accordion content.  |
| aria-expanded        | Attribute is set to the Accordion header elements to indicate the expand state of the Accordion item. Default value of this attribute is `false`. If an item is expanded, the attribute value changes to `true`. |
| aria-hidden          | Attribute is set to the Accordion panel elements to indicate the visibility of the Accordion item content. Default value of this attribute is `true`. If an item content is visible, the attribute value changes to `false`. |
| aria-disabled        | Set on the Accordion header (button) to indicate that the corresponding item is disabled, preventing toggle interaction. |

## Keyboard interaction

Keyboard navigation is enabled by default. The possible keys are:

| Windows | Mac | Description |
|---------------|-----------|--------|
| <kbd>Space</kbd> / <kbd>Enter</kbd> | <kbd>Space</kbd> / <kbd>Enter</kbd> | When the focus is on the Accordion header, activating the focused element expands or collapses the corresponding panel. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Focus the next Accordion header. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Focus the previous Accordion header. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | Focus the first Accordion header. |
| <kbd>End</kbd> | <kbd>End</kbd> | Focus the last Accordion header. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Move focus into the Accordion header group from the preceding element, or out of the group to the next focusable element. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>Shift</kbd> + <kbd>Tab</kbd> | Move focus backward out of the Accordion header group. |

When a panel is expanded, focus remains on its header. Use the arrow keys to navigate between headers rather than moving into panel content.

## Ensuring accessibility

The Blazor Accordion component's accessibility levels are ensured through an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) software tool during automated testing.

The accessibility compliance of the Blazor Accordion component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/accordion) in a new window to evaluate the accessibility of the Blazor Accordion with accessibility tools.

## See also

* [Accessibility in Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)