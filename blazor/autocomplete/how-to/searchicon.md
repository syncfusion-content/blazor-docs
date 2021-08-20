---
layout: post
title: Search icon with Blazor AutoComplete Component | Syncfusion
description: Learn here all about adding search icon for Syncfusion Blazor AutoComplete component and more details.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Adding search icon in the Blazor AutoComplete component.

You can add the search icon to the AutoComplete component by overriding the content of the existing icon.

The following code demonstrates how to add a search icon to the AutoComplete component.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfAutoComplete TValue="string" TItem="GameFields" Width="300px" ShowPopupButton="true" Placeholder="e.g. Basketball" DataSource="@Games">
    <AutoCompleteFieldSettings Value="Text"></AutoCompleteFieldSettings>
</SfAutoComplete>

<style>
    .e-ddl.e-input-group.e-control-wrapper .e-ddl-icon::before {
        content: '\e724';
        font-family: 'e-icons';
        font-size: 16px;
        opacity: 0.4;
    }
</style>

@code{
    public class GameFields
    {
        public string ID { get; set; }
        public string Text { get; set; }
    }
    public List<GameFields> Games = new List<GameFields>()
    {
        new GameFields(){ ID= "Game1", Text= "American Football" },
        new GameFields(){ ID= "Game2", Text= "Badminton" },
        new GameFields(){ ID= "Game3", Text= "Basketball" },
        new GameFields(){ ID= "Game4", Text= "Cricket" },
        new GameFields(){ ID= "Game5", Text= "Football" },
    };
}
```

The output will be as follows.

![Blazor AutoComplete Search Icon](../images/blazor_searchicon_autocomplete.png)