---
layout: post
title: DropDownList options with tooltip in Blazor ComboBox | Syncfusion
description: Learn here all about DropDownList options with tooltip in Syncfusion Blazor ComboBox component and more.
platform: Blazor
control: ComboBox
documentation: ug
---

# Show tooltip for ComboBox items in Blazor

Display a tooltip for ComboBox list items by using the SfTooltip component. When the user hovers over an item in the ComboBox popup, a tooltip appears with information about the hovered item.

The following example shows how to display a tooltip when hovering over ComboBox list items.

```cshtml
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Popups

<SfComboBox TValue="string" TItem="GameFields" 
            DataSource="@Games" 
            Placeholder="Select a game"
            Width="300px">
    <ComboBoxFieldSettings Text="Text" Value="ID"></ComboBoxFieldSettings>
    <ComboBoxTemplates TItem="GameFields">
        <ItemTemplate>
            <SfTooltip Target=".custom-item" Content="@context.Text">
                <div class="custom-item">@context.Text</div>
            </SfTooltip>
        </ItemTemplate>
    </ComboBoxTemplates>
</SfComboBox>

@code {
    public class GameFields
    {
        public string ID { get; set; }
        public string Text { get; set; }
    }

    private List<GameFields> Games = new List<GameFields>() 
    {
        new GameFields(){ ID= "Game1", Text= "American Football" },
        new GameFields(){ ID= "Game2", Text= "Badminton" },
        new GameFields(){ ID= "Game3", Text= "Basketball" },
        new GameFields(){ ID= "Game4", Text= "Cricket" },
        new GameFields(){ ID= "Game5", Text= "Football" },
        new GameFields(){ ID= "Game6", Text= "Golf" }
    };
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/htrqMBVwKYqDMxaA?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Combobox displays Tooltip for Dropdown Items](../images/blazor-combobox-tooltip.png)" %}
