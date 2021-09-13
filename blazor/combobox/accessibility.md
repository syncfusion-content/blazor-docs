---
layout: post
title: Accessibility in Blazor ComboBox Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor ComboBox component and much more.
platform: Blazor
control: ComboBox
documentation: ug
---

# Accessibility in Blazor ComboBox Component

The ComboBox component has been designed with the `WAI-ARIA` specifications in mind, and applies the WAI-ARIA roles, states, and properties along with `keyboard support`. This component is characterized
by complete keyboard interaction support and ARIA accessibility support that makes it easy for people who use assistive technologies (AT) or those who completely rely on keyboard navigation.

## ARIA attributes

The ComboBox component uses the `combobox` role, and each list item has an `option` role. The following `ARIA attributes` denotes the ComboBox state:

| **Properties**        | **Functionalities**                                                                                                    |
| --------------------- | ---------------------------------------------------------------------------------------------------------------------- |
| aria-haspopup         | Indicates whether the ComboBox input element has a popup list or not.                                                  |
| aria-expanded         | Indicates whether the popup list has expanded or not.                                                                  |
| aria-selected         | Indicates the selected option.                                                                                         |
| aria-readonly         | Indicates the readonly state of the ComboBox element.                                                                  |
| aria-disabled         | Indicates whether the ComboBox component is in a disabled state or not.                                                |
| aria-activedescendent | This attribute holds the ID of the active list item to focus its descendant child element.                             |
| aria-owns             | This attribute contains the ID of the popup list to indicate popup as a child element.                                 |
| aria-autocomplete     | This attribute contains the ‘both’ to a list of options shows and the currently selected suggestion also shows inline. |

## Keyboard interaction

You can use the following key shortcuts to access the ComboBox without interruptions:

| **Keyboard shortcuts**  | **Actions**                                                                                                                                             |
| ----------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------- |
| <kbd>Arrow Down</kbd>   | Selects the first item in the ComboBox when no item is selected. Otherwise, selects the item next to the currently selected item.                          |
| <kbd>Arrow Up</kbd>     | Selects the item previous to the currently selected one.                                                                                                |
| <kbd>Page Down</kbd>    | Scrolls down to the next page and selects the first item when popup list opens.                                                                         |
| <kbd>Page Up</kbd>      | Scrolls up to the previous page and selects the first item when popup list opens.                                                                       |
| <kbd>Enter</kbd>        | Selects the focused item and popup list closes when it is in open state.                                                                                |
| <kbd>Tab</kbd>          | Focuses on the next TabIndex element on the page when the popup is closed. Otherwise, closes the popup list and remains the focus of the component.     |
| <kbd>Shift + tab </kbd> | Focuses on the previous TabIndex element on the page when the popup is closed. Otherwise, closes the popup list and remains the focus of the component. |
| <kbd>Alt + Down</kbd>   | Open the popup list                                                                                                                                     |
| <kbd>Alt + Up</kbd>     | Closes the popup list                                                                                                                                    |
| <kbd>Esc(Escape)</kbd>  | Closes the popup list when it is in an open state and the currently selected item remains the same.                                                     |
| <kbd>Home</kbd>         | Cursor moves before the first character in input                                                                                                      |
| <kbd>End</kbd>          | Cursor moves next to the last character in input                                                                                                         |

> In the following sample, disable the ComboBox component using <kbd>t</kbd> keys.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfComboBox TValue="string" TItem="Countries" @ref="ComboObj" Enabled="@enable" Placeholder="Select a country" @onkeypress="@(e => KeyPressed(e))" DataSource="@LocalData">
    <ComboBoxFieldSettings Value="Code" Text="Name"></ComboBoxFieldSettings>
</SfComboBox>

@code {

    public SfComboBox<string, Countries> ComboObj;

    public bool enable { get; set; } = true;
    public class Countries
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }

    List<Countries> LocalData = new List<Countries> {
        new Countries() { Name = "Australia", Code = "AU" },
        new Countries() { Name = "Bermuda", Code = "BM" },
        new Countries() { Name = "Canada", Code = "CA" },
        new Countries() { Name = "Cameroon", Code = "CM" },
        new Countries() { Name = "Denmark", Code = "DK" },
        new Countries() { Name = "France", Code = "FR" },
        new Countries() { Name = "Finland", Code = "FI" },
        new Countries() { Name = "Germany", Code = "DE" },
        new Countries() { Name = "Greenland", Code = "GL" },
        new Countries() { Name = "Hong Kong", Code = "HK" },
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

The output will be as follows.

![Accessibility in Blazor ComboBox](./images/blazor-combobox-accessibility.png)