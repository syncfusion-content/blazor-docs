---
layout: post
title: Accessibility in Blazor Chip Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor Chip component and much more details.
platform: Blazor
control: Chip
documentation: ug
---

# Accessibility in Blazor Chip Component

The [Blazor Chips](https://www.syncfusion.com/blazor-components/blazor-chips) component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Chips component is outlined below.

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

The Blazor Chips component followed the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/) patterns to meet the accessibility. The following ARIA attributes are used in the Chips component:

| Attributes | Purpose |
| -- | -- |
| `role=listbox` | Indicates the ChipList component wrapper element as `listbox`. |
| `role=option` | Used to convey a significant and contextual message to the user(ChipList). |
| `role=button` | Used to convey a significant and contextual message to the user(Single Chip). |
| `aria-label` | Provides an accessible name for the Chip. |
| `aria-selected` | Indicates the element is selected. |
| `aria-disabled` | Indicates element is perceivable but disabled. |
| `aria-multiselectable` | Indicates multiple items to be selected. |

## Keyboard interaction

The following shortcut keys are used to access the Blazor Chip component without any interruption.

| Windows | Mac | Actions |
|------------|-------|------------|
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Selects the targeted chip from the Chip/ChipItems. |
| <kbd>Delete</kbd> | <kbd>Delete</kbd> | Deletes the targeted chip from the Chip/ChipItems. |

## Ensuring accessibility

The Blazor Chips component's accessibility levels are ensured through an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) software tool during automated testing.

The accessibility compliance of the Chip component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/chips) in a new window to evaluate the accessibility of the Chip component with accessibility tools.

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

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)