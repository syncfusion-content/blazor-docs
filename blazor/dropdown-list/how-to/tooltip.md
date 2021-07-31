---
layout: post
title: DropDownList options with tooltip in Blazor DropDown List | Syncfusion
description: Learn here all about DropDownList options with tooltip in Syncfusion Blazor DropDown List component and more.
platform: Blazor
control: DropDown List
documentation: ug
---

# DropDownList options with tooltip in Blazor DropDown List Component

You can achieve this behavior by using tooltip component. When the mouse is hovered over the DropDownList option, a tooltip appears with information about the hovered list item.

The following code demonstrates how to display a tooltip when hovering over the DropDownList option.

```cshtml
@using Syncfusion.Blazor.DropDowns;
@using Syncfusion.Blazor.Popups;

<SfTooltip @ref="TooltipObj" ID="Tooltip" Target=".e-list-item .name[title]">
</SfTooltip>

<SfDropDownList TItem="GameFields" TValue="string" Placeholder="Select a game" DataSource="@Games">
    <DropDownListFieldSettings Text="Text" Value="ID"></DropDownListFieldSettings>
    <DropDownListTemplates TItem="GameFields">
            <ItemTemplate>
                    <div class="name" title="@((context as GameFields).Text)"> @((context as GameFields).Text) </div>
            </ItemTemplate>
        </DropDownListTemplates>
    <DropDownListEvents TValue="string" TItem="GameFields" Opened="OnOpen" OnClose="OnClose"></DropDownListEvents>
</SfDropDownList>

@code{

    SfTooltip TooltipObj;
    public Boolean isOpen { get; set; } = false;
    
    public class GameFields
    {
        public string ID { get; set; }
        public string Text { get; set; }
    }
    
    private List<GameFields> Games = new List<GameFields>() {
        new GameFields(){ ID= "Game1", Text= "American Football" },
        new GameFields(){ ID= "Game2", Text= "Badminton" },
        new GameFields(){ ID= "Game3", Text= "Basketball" },
        new GameFields(){ ID= "Game4", Text= "Cricket" },
        new GameFields(){ ID= "Game5", Text= "Football" },
        new GameFields(){ ID= "Game6", Text= "Golf" },
        new GameFields(){ ID= "Game7", Text= "Hockey" },
        new GameFields(){ ID= "Game8", Text= "Rugby"},
        new GameFields(){ ID= "Game9", Text= "Snooker" },
        new GameFields(){ ID= "Game10", Text= "Tennis"},
    };

    public void OnOpen(PopupEventArgs args)
    {
        isOpen = true;
    }

    public void OnClose(PopupEventArgs args)
    {
        TooltipObj.CloseAsync();
    }
    
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (isOpen)
        {
            await TooltipObj.RefreshAsync();
        }
    }
}
```

The output will be as follows.

![dropdownlist](../images/tooltip.png)