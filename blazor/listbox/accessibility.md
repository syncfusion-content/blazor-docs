---
layout: post
title: Accessibility in Blazor ListBox Component | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor ListBox component and much more.
platform: Blazor
control: List Box
documentation: ug
---

# Accessibility in Blazor ListBox Component

The ListBox component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the ListBox component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2](https://www.w3.org/TR/WCAG22/) Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Section 508](https://www.section508.gov/) Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Screen Reader Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Right-To-Left Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Color Contrast | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Mobile Device Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Keyboard Navigation Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Accessibility Checker](https://www.npmjs.com/package/accessibility-checker) Validation | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Axe-core](https://www.npmjs.com/package/axe-core) Accessibility Validation | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>
<div><img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/intermediate.png" alt="Intermediate"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/no.png" alt="No"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

The ListBox component followed the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/listbox/) patterns to meet the accessibility. The following ARIA attributes are used in the ListBox component:

| Attributes | Purpose |
| --- | --- |
| `role` | Indicates the ListBox component wrapper element as `listbox`, the `UL` element as `presentation`, and its list item as `option`. |
| `aria-label` | Provides an accessible name for the ListBox component. |
| `aria-multiselectable` | Applied to the element with the ListBox role, tells assistive technologies that the list supports multiple selection. The default value is true. |
| `aria-selected` | Applied to elements with role option that are visually styled as selected to inform assistive technologies that the options are selected. |

## Keyboard interaction

The ListBox component followed the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/listbox/#keyboardinteraction) guideline, making it easy for people who use assistive technologies (AT) and those who completely rely on keyboard navigation. The following keyboard shortcuts are supported by the ListBox component.

| **Press** | **To do this** |
| --- | --- |
| <kbd>Up arrow</kbd> | Moves focus to the previous option. |
| <kbd>Down arrow</kbd> | Moves focus to the next option. |
| <kbd>Home</kbd> | Moves focus to first option. |
| <kbd>End</kbd> | Moves focus to last option. |
| <kbd>Space</kbd> | Changes the selection state of the focused option. |
| <kbd>Ctrl + A</kbd> | Selects all options in the list. |
| <kbd>Ctrl + Shift + Home</kbd> | Selects the focused option and all options up to the first option. |
| <kbd>Ctrl + Shift + End</kbd> | Selects the focused option and all options down to the last option. |
| <kbd>Ctrl + (Up or Down)</kbd> | Press Ctrl key with up / down arrow or mouse to select multiple items. |

## Ensuring accessibility

The ListBox component's accessibility levels are ensured through an [accessibility-checker](https://www.npmjs.com/package/accessibility-checker) and [axe-core](https://www.npmjs.com/package/axe-core) software tools during automated testing.

The accessibility compliance of the ListBox component is shown in the following sample. Open the [sample](https://ej2.syncfusion.com/accessibility/list-box.html) in a new window to evaluate the accessibility of the ListBox component with accessibility tools.

{% previewsample "https://ej2.syncfusion.com/accessibility/list-box.html" %}