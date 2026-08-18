---
layout: post
title: Accessibility in Blazor Chips | Syncfusion®
description: Learn how Blazor Chips meet WCAG 2.2, Section 508, and ADA standards with WAI-ARIA roles, keyboard navigation, and screen reader support.
platform: Blazor
control: Chips
documentation: ug
---

# Accessibility in Blazor Chips

The [Blazor Chips](https://www.syncfusion.com/blazor-components/blazor-chips) component follows the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Chips component is outlined below.

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

The Blazor Chips component follows the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/) patterns to meet accessibility requirements. The following ARIA attributes are used in the Chips component:

| Attributes | Purpose |
| -- | -- |
| `role=listbox` | Indicates that the ChipList component wrapper element acts as a `listbox`, which contains a set of selectable options. |
| `role=option` | Indicates each selectable chip within the ChipList (used when `Selection` is set to `Single` or `Multiple`). |
| `aria-label` | Provides an accessible name for the Chip. |
| `aria-selected` | Indicates whether the chip is currently selected. |
| `aria-disabled` | Indicates the element is perceivable but disabled. |
| `aria-multiselectable` | Indicates that multiple items in the ChipList can be selected at the same time. |

## Keyboard interaction

The following shortcut keys are used to access the Blazor Chip component seamlessly. To make the <kbd>Delete</kbd> key functional, set [`EnableDelete`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfChip.html#Syncfusion_Blazor_Buttons_SfChip_EnableDelete) to `true` on the `SfChip` component. Focus order follows the order in which chips are rendered.

| Windows | Mac | Actions |
|------------|-------|------------|
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Selects the targeted chip from the Chip/ChipItems. |
| <kbd>Delete</kbd> | <kbd>Delete</kbd> | Deletes the targeted chip from the Chip/ChipItems. |

## Ensuring accessibility

The Blazor Chips component's accessibility is validated through the [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) software tool during automated testing.

The accessibility compliance of the Chip component is shown in the following sample. The sample references the local image files (`andrew.png`, `janet.png`, `laura.png`, `margaret.png`) that ship with the Syncfusion Blazor sample assets. The [sample](https://blazor.syncfusion.com/accessibility/chips) can be opened in a new window to evaluate the accessibility of the Chip component with accessibility tools.

```cshtml
@using Syncfusion.Blazor.Buttons
<SfChip ID="chip-avatar" EnableDelete="true" CssClass="e-chip-avatar" Selection="SelectionType.Single">
    <ChipItems>
        <ChipItem Text="Andrew" LeadingIconCss='andrew'></ChipItem>
        <ChipItem Text="Janet" LeadingIconCss='janet'></ChipItem>
        <ChipItem Text="Laura" LeadingIconCss='laura'></ChipItem>
        <ChipItem Text="Margaret" LeadingIconCss='margaret'></ChipItem>
    </ChipItems>
</SfChip>

<style>
    #chip-avatar .andrew {
        background-image: url('./andrew.png')
    }

    #chip-avatar .margaret {
        background-image: url('./margaret.png')
    }

    #chip-avatar .laura {
        background-image: url('./laura.png')
    }

    #chip-avatar .janet {
        background-image: url('./janet.png')
    }
</style>

```

![Accessibility in Blazor Chip](./images/blazor-chip-accessibility.gif)

## See also

* [Accessibility in Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)
* [Getting Started with Blazor Chip](getting-started.md)
* [Types in Blazor Chip](types.md)
* [Customization in Blazor Chip](customization.md)
* [Events in Blazor Chip](events.md)
* [CSS Structure in Blazor Chip](style.md)