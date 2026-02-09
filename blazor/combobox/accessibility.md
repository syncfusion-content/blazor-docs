---
layout: post
title: Accessibility in Blazor ComboBox Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor ComboBox component and much more.
platform: Blazor
control: ComboBox
documentation: ug
---

# Accessibility in Blazor ComboBox Component

The [Blazor ComboBox](https://www.syncfusion.com/blazor-components/blazor-combobox) component has been designed with the `WAI-ARIA` specifications in mind, and applies the WAI-ARIA roles, states, and properties along with `keyboard support`. This component is characterized
by complete keyboard interaction support and ARIA accessibility support that makes it easy for people who use assistive technologies (AT) or those who completely rely on keyboard navigation.

The Blazor ComboBox component follows accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), and [WCAG 2.2](https://www.w3.org/TR/WCAG22/), and it implements appropriate [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) commonly used to evaluate accessibility.

The accessibility compliance for the Blazor ComboBox component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | AAA |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> |
| [Right-to-left support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> |
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>
<div><img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partially meets requirement"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="Does not meet requirement"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

The Blazor ComboBox component uses the `combobox` role, and each list item has an `option` role. The following `ARIA attributes` denotes the ComboBox state:

| **Properties** | **Functionalities** |
| --- | --- |
| `aria-haspopup` | Indicates that the ComboBox input has a popup (listbox). |
| `aria-expanded` | Indicates the expanded or collapsed state of the popup list. |
| `aria-selected` | Indicates the selected option. |
| `aria-readonly` | Indicates that the ComboBox is read-only. |
| `aria-disabled` | Indicates that the ComboBox is disabled. |
| `aria-activedescendant` | References the ID of the active option in the listbox to indicate focus for assistive technologies. |
| `aria-owns` | References the ID of the popup list to associate it as a controlled element. |
| `aria-autocomplete`  | Indicates the autocomplete behavior (for example, `list` or `both`) depending on whether the list and inline suggestion are shown. |

## Keyboard interaction

Use the following key shortcuts to access and operate the Blazor ComboBox:

| Windows | Mac | Actions |
| --- | --- | --- |
|**Focus**| | |
|<kbd>Alt + J</kbd> | <kbd>⌥</kbd> + <kbd>J</kbd> | Focuses the first component in the sample (sample-specific shortcut for demonstration). |
|**Input Navigation**| | |
| <kbd>Alt</kbd> + <kbd>↓</kbd> | <kbd>⌥</kbd> + <kbd>↓</kbd> | Opens the popup list. |
| <kbd>Alt</kbd> + <kbd>↑</kbd> | <kbd>⌥</kbd> + <kbd>↑</kbd> | Closes the popup list. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | Moves the cursor to the beginning of the input. |
| <kbd>End</kbd> | <kbd>End</kbd> | Moves the cursor to the end of the input. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Focuses on the next TabIndex element on the page when the popup is closed. Otherwise, closes the popup list and remains the focus of the component. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Focuses on the previous TabIndex element on the page when the popup is closed. Otherwise, closes the popup list and remains the focus of the component. |
|**Selection**| | |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Selects the focused item. If open, the popup closes; otherwise, toggles the popup. |
|**Popup Navigation**| | |
| <kbd>Esc</kbd> | <kbd>Escape</kbd> | Closes the popup when open and keeps the current selection. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Selects the first item when none is selected; otherwise, moves to the next item. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Moves to the previous item. |
| <kbd>Page Down</kbd> | <kbd>Page Down</kbd> | Scrolls down one page in the list and selects the first visible item. |
| <kbd>Page Up</kbd> | <kbd>Page Up</kbd> | Scrolls up one page in the list and selects the first visible item. |

N> In the following sample, pressing the <kbd>t</kbd> key disables the ComboBox for demonstration purposes.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfComboBox TValue="string" TItem="Country" @ref="ComboObj" Enabled="@enable" Placeholder="Select a country" @onkeypress="@(e => KeyPressed(e))" DataSource="@LocalData">
    <ComboBoxFieldSettings Value="Code" Text="Name"></ComboBoxFieldSettings>
</SfComboBox>

@code {

    public SfComboBox<string, Country> ComboObj;

    public bool enable { get; set; } = true;
    public class Country
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }

    List<Country> LocalData = new List<Country> {
        new Country() { Name = "Australia", Code = "AU" },
        new Country() { Name = "Bermuda", Code = "BM" },
        new Country() { Name = "Canada", Code = "CA" },
        new Country() { Name = "Cameroon", Code = "CM" },
        new Country() { Name = "Denmark", Code = "DK" },
        new Country() { Name = "France", Code = "FR" },
        new Country() { Name = "Finland", Code = "FI" },
        new Country() { Name = "Germany", Code = "DE" },
        new Country() { Name = "Greenland", Code = "GL" },
        new Country() { Name = "Hong Kong", Code = "HK" },
    };

    public void KeyPressed(KeyboardEventArgs args)
    {
        if (args.Key == "t")
        {
            enable = false;
        }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hZBAsrrQgPQyWcgL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Ensuring accessibility

The Blazor ComboBox component’s accessibility levels are validated using [axe-core](https://www.npmjs.com/package/axe-core) during automated testing.

The accessibility compliance of the ComboBox component is demonstrated in the following sample. Open the [ComboBox accessibility sample](https://blazor.syncfusion.com/accessibility/combobox) in a new window to evaluate the component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> components](../common/accessibility)