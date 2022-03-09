---
layout: post
title: Accessibility in Blazor AutoComplete Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor AutoComplete component and more.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Accessibility in Blazor AutoComplete Component

The [AutoComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html) component has been designed, keeping in mind the [WAI-ARIA](https://www.w3.org/TR/wai-aria-practices/) specifications, and applies the `WAI-ARIA` roles, states, and properties along with `keyboard support`. This component is characterized by complete keyboard interaction support and ARIA accessibility support that makes it easy for people who use assistive technologies (AT) or those who completely rely on keyboard navigation.

## ARIA attributes

The AutoComplete component uses the `combobox` role and each list item has an `option` role. The following `ARIA Attributes` denotes the AutoComplete state:

| **Property** | **Functionalities** |
| --- | --- |
| aria-haspopup | Indicates whether the AutoComplete input element has a suggestion list or not. |
| aria-expanded | Indicates whether the suggestion list has expanded or not. |
| aria-selected | Indicates the selected option from the list. |
| aria-readonly | Indicates the readonly state of the AutoComplete element. |
| aria-disabled | Indicates whether the AutoComplete component is in disabled state or not.|
| aria-activedescendent | This attribute holds the ID of the active list item to focus its descendant child element. |
| aria-owns | This attribute contains the ID of the suggestion list to indicate popup as a child element. |
| aria-autocomplete | This attribute contains the ‘both’ to a list of options shows and the currently selected suggestion also shows inline. |

## Keyboard interaction

You can use the following key shortcuts to access the AutoComplete without interruptions:

| **Keyboard shortcuts** | **Actions** |
| --- | --- |
| <kbd>Arrow Down</kbd> | In popup hidden state, opens the suggestion list. In popup open state, selects the first item when no item selected else selects the item next to the currently selected item. |
| <kbd>Arrow Up</kbd> | In popup hidden state, opens the suggestion list. In popup open state, selects the last item when no item selected else selects the item previous to the currently selected one. |
| <kbd>Page Down</kbd> | Scrolls down to the next page and selects the first item when popup list opens. |
| <kbd>Page Up</kbd> | Scrolls up to previous page and selects the first item when popup list opens. |
| <kbd>Enter</kbd> | Selects the focused item and set to AutoComplete component. |
| <kbd>Tab</kbd> | Focuses the next tab indexed element when the popup is closed. Otherwise, closes the popup list and remains the focus in component if it is in open state. |
| <kbd>Shift + tab </kbd> | Focuses the previous tab indexed element when the popup is closed.  Otherwise, closes the popup list and remains the focus in component if it is in open state. |
| <kbd>Alt + Down</kbd> | Opens the popup list. |
| <kbd>Alt + Up</kbd> | In popup hidden state, opens the popup list. In popup open state, closes the popup list. |
| <kbd>Esc(Escape)</kbd> | Closes the popup list when it is in open state then removes the selection. |
| <kbd>Home</kbd> | Cursor moves to before of the first character in input. |
| <kbd>End</kbd> | Cursor moves to next of the last character in input. |

> In the following sample, disable the AutoComplete component using <kbd>t</kbd> keys.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfAutoComplete TValue="string" TItem="Countries" @ref="AutoObj" Placeholder="Select a country" Enabled="@enable" @onkeypress="@(e => KeyPressed(e))" DataSource="@LocalData">
    <AutoCompleteFieldSettings Value="Name"></AutoCompleteFieldSettings>
</SfAutoComplete>

@code {

    public SfAutoComplete<string, Countries> AutoObj;

    public bool enable { get; set; } = true ;
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



![Accessibility in Blazor AutoComplete](./images/blazor-autocomplete-accessibility.png)