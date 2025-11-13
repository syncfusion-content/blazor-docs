---
layout: post
title: Customization in Blazor DropDown List | Syncfusion
description: Checkout and learn here all about Customization in Syncfusion Blazor DropDown List component and much more.
platform: Blazor
control: DropDownList
documentation: ug
---

# Customization in Blazor DropDown List

## Open Dropdown list dropdown on focus

Automatically open the dropdown by using [ShowPopupAsync()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_ShowPopupAsync) method on [Focus](https://blazor.syncfusion.com/documentation/dropdown-list/events#focus) event. The `ShowPopupAsync()` method opens the popup that displays the list of items.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfDropDownList @ref=@popup TItem="GameFields" TValue="string" DataSource="@Games">
    <DropDownListEvents  TItem="GameFields" TValue="string" Focus="@FocusHandler"></DropDownListEvents>
    <DropDownListFieldSettings Text="Text" Value="ID"></DropDownListFieldSettings>
</SfDropDownList>

@code {
    public class GameFields
    {
        public string ID { get; set; }
        public string Text { get; set; }
    }
    SfDropDownList<string, GameFields> popup;
    private List<GameFields> Games = new List<GameFields>() {
        new GameFields(){ ID= "Game1", Text= "American Football" },
        new GameFields(){ ID= "Game2", Text= "Badminton" },
        new GameFields(){ ID= "Game3", Text= "Basketball" },
        new GameFields(){ ID= "Game4", Text= "Cricket" },
     };

    private void FocusHandler()
    {
        popup.ShowPopupAsync();
       
    }
}
```

![Blazor Dropdown List Customization](./images/blazor-dropdownlist-customization.png)