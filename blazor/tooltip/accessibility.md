---
layout: post
title: Accessibility in Blazor Tooltip Component | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor Tooltip component and much more.
platform: Blazor
control: Tooltip
documentation: ug
---

# Accessibility in Blazor Tooltip Component

The [Blazor Tooltip](https://www.syncfusion.com/blazor-components/blazor-tooltip) component follows accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WAI-ARIA roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Tooltip component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2](https://www.w3.org/TR/WCAG22/) Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> |
| [Section 508](https://www.section508.gov/) Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> |
| Screen Reader Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Meets requirement"> |
| Right-To-Left Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Meets requirement"> |
| Color Contrast | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Meets requirement"> |
| Mobile Device Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Meets requirement"> |
| Keyboard Navigation Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Meets requirement"> |
| [Axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) Accessibility Validation | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Meets requirement"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Meets requirement"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partially meets requirement"> - Some features of the component do not fully meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/no.png" alt="Does not meet requirement"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

The Blazor Tooltip component follows the [WAI-ARIA tooltip pattern](https://www.w3.org/WAI/ARIA/apg/patterns/tooltip/) to meet accessibility requirements. The following ARIA attributes are used in the Tooltip component.

| Attributes | Purpose |
| --- | --- |
| `role="tooltip"` | The element that serves as the container for the tooltip has the ARIA role of `tooltip`. |
| `aria-describedby` | This attribute is applied to the target element when the tooltip is shown by focus or hover. It typically contains the unique `ID` of the tooltip element.<br/><br/>If the target element already has an `aria-describedby` attribute referencing another component, the tooltip `ID` is appended, separated by a space.<br/><br/><strong>For example</strong>:<br/>`aria-describedby="my-text my-tooltip"`<br/><strong>my-text</strong> is the ID of another component.<br/><strong>my-tooltip</strong> is the ID of the tooltip component.<br/><br/>When the tooltip is hidden, the tooltip `ID` is removed from `aria-describedby`. |
| `aria-hidden` | This attribute is set on the tooltip element. The default value is `true` (hidden). When the tooltip is visible, its value changes to `false`. |

## Keyboard interaction

The Blazor Tooltip component follows the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/tooltip/#keyboardinteraction) guideline, making it accessible for people who use assistive technologies and those who rely on keyboard navigation. The following keyboard shortcuts are supported by the Tooltip component.

| Windows | Mac | Actions |
| --- | --- | --- |
| <kbd>Escape</kbd> | <kbd>Escape</kbd> | Closes or dismisses the tooltip. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | When a form control receives focus via the Tab key, the tooltip opens; when focus moves away, it closes. |

## Ensuring accessibility

The Blazor Tooltip component's accessibility levels are validated with the [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) tool during automated testing.

The accessibility compliance of the Tooltip component is demonstrated in the following sample. Open the [Tooltip accessibility sample](https://blazor.syncfusion.com/accessibility/tooltip) in a new window to evaluate the component with accessibility tools.
## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)