---
layout: post
title: Accessibility in Blazor Accordion Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor Accordion component, including WAI-ARIA support, keyboard interaction, and compliance with WCAG, Section 508, and ADA standards.
platform: Blazor
control: Accordion
documentation: ug
---

# Accessibility in Blazor Accordion Component

The [Blazor Accordion](https://www.syncfusion.com/blazor-components/blazor-accordion) component has been designed keeping in mind the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/accordion/) specifications, by applying the prompt WAI-ARIA roles, states and properties along with the keyboard support. Thus, making it usable for people who use assistive WAI-ARIA Accessibility supports that is achieved through the attributes like `aria-labelledby`. It helps to provides information about the elements in a document for assistive technology. The component implements the keyboard navigation support by following the [WAI-ARIA practices](https://www.w3.org/WAI/ARIA/apg/) and tested in major screen readers.

The Blazor Accordion component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Accordion component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2](https://www.w3.org/TR/WCAG22/) Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
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

The Syncfusion Blazor Accordion component automatically applies the following WAI-ARIA attributes to its elements to enhance accessibility:

| Attributes             | Purpose |
|----------------------|---------------|
| role                 | **Button:** Applied to the Accordion header elements, indicating they function as interactive buttons that toggle the visibility of their associated content sections. <br> **Region**: Applied to the Accordion panel elements, defining them as landmark regions that contain the currently expanded content, making them discoverable by assistive technologies.        |
| aria-labelledby      | This attribute is set on the Accordion content (panel) and points to the `id` of its corresponding Accordion header. This establishes a programmatic relationship, allowing screen readers to announce the header as the label for the content.   |
| aria-controls        | This attribute is set on the Accordion header and points to the `id` of its corresponding Accordion content. This indicates that the header controls the visibility of the specified content panel.  |
| aria-expanded        | Applied to the Accordion header elements, this attribute communicates the current expansion state of the Accordion item to assistive technologies. It has a default value of `false` (collapsed). When an item expands, its value programmatically changes to `true`. |
| aria-hidden          | Applied to the Accordion panel elements, this attribute indicates whether the content is visible or hidden. A value of `true` means the content is hidden and not exposed to assistive technologies. Conversely, `false` means the content is visible. The default value is `true` for collapsed content, changing to `false` when the content becomes visible. |
| aria-disabled        | It indicates the disabled state of the Accordion and its items.  |

## Keyboard interaction

Keyboard navigation is a fundamental aspect of accessibility and comes enabled by default in the Blazor Accordion. Users can navigate and interact with the Accordion items using the following keys:

| Windows | Mac | Description |
|---------------|-----------|--------|
| <kbd>Space</kbd> / <kbd>Enter</kbd> | <kbd>Space</kbd> / <kbd>Enter</kbd> | When the focus is on the Accordion header, clicking on the focused element makes the element to expand and collapse. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Focus the next Accordion header. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Focus the previous Accordion header. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | Focus the first Accordion header. |
| <kbd>End</kbd> | <kbd>End</kbd> | Focus the last Accordion header. |

## Ensuring accessibility

The Blazor Accordion component's accessibility levels are ensured through an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) software tool during automated testing.

The accessibility compliance of the Accordion component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/accordion) in a new window to evaluate the accessibility of the Accordion component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)