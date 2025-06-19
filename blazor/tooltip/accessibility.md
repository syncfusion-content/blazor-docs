---
layout: post
title: Accessibility in Blazor Tooltip Component | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor Tooltip component and much more.
platform: Blazor
control: Tooltip
documentation: ug
---

# Accessibility in Blazor Tooltip Component

The [Blazor Tooltip](https://www.syncfusion.com/blazor-components/blazor-tooltip) component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Tooltip component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2](https://www.w3.org/TR/WCAG22/) Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Section 508](https://www.section508.gov/) Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
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

The Blazor Tooltip component followed the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/tooltip/) patterns to meet the accessibility. The following ARIA attributes are used in the Tooltip component.

| Attributes | Purpose |
| --- | --- |
| role=”tooltip” | The element that serves as the container for the Tooltip has the ARIA role of `tooltip`. |
| aria-describedby | This attribute is added to the target element on which the Tooltip gets opened, when focusing or hovering over it. It usually holds the randomly generated `Id` value of the Tooltip element.<br/><br/>In case, the target element already holds an `aria-describedby` attribute with `Id` value of some other component, then the Tooltip Id value can be additionally appended to the existing `aria-describedby` attribute separated by a space as shown in the example below.<br/><br/>**For example**:<br/>aria-describedby = “my-text my-tooltip”<br/>**my-text** is the Id of some other component.<br/>**my-tooltip** is the id of Tooltip component.<br/><br/>When the Tooltip is closed, the `aria-describedby` attribute is removed from the target. |
| aria-hidden | This attribute is assigned to the Tooltip element whose default value is `true`.<br/><br/>When `true`, it denotes that the Tooltip element is in a hidden or a closed state. When the Tooltip appears on the screen, it’s value changes to `false`. |

## Keyboard interaction

The Blazor Tooltip component followed the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/tooltip/#keyboardinteraction) guideline, making it easy for people who use assistive technologies (AT) and those who completely rely on keyboard navigation. The following keyboard shortcuts are supported by the Tooltip component.

| Windows | Mac | Actions |
| --- | --- | --- |
| <kbd>Escape</kbd> | <kbd>Escape</kbd> | Closes or dismisses the Tooltip. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | A form control receiving focus (say through tab key), opens the Tooltip, and on focus out closes it. |

## Ensuring accessibility

The Blazor Tooltip component's accessibility levels are ensured through an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) software tool during automated testing.

The accessibility compliance of the Tooltip component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/tooltip) in a new window to evaluate the accessibility of the Tooltip component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)