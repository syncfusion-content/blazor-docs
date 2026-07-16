---
layout: post
title: Open a Dialog on Item click in Blazor ContextMenu | Syncfusion®
description: Checkout and learn here all about Open a dialog on Context Menu item click in Blazor ContextMenu component and more.
platform: Blazor
control: Context Menu
documentation: ug
---

# Open a Dialog on Item Click in Blazor Context Menu

This section explains how to open a Dialog when a Context Menu item is selected. This can be achieved by handling the [ItemSelected](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuEvents-1.html#Syncfusion_Blazor_Navigations_MenuEvents_1_ItemSelected) event of the Context Menu and invoking the Dialog component's methods programmatically.

In the following example, the ContextMenu component is rendered for a target element, and the ItemSelected event is used to detect the selected menu item. When the Save As... item is clicked, the event handler calls the Dialog's [ShowAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialog.html#Syncfusion_Blazor_Popups_SfDialog_ShowAsync_System_Nullable_System_Boolean__) method to open the Dialog component. The dialog can then be closed by clicking the Submit button, which invokes the [HideAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.SfDialog.html#Syncfusion_Blazor_Popups_SfDialog_HideAsync_System_String_) method.

The sample demonstrates the integration of the ContextMenu and Dialog components to provide contextual actions and user interaction.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Popups

<div id="target">Right click/Touch hold to open the ContextMenu </div>
<SfContextMenu Target="#target" TValue="MenuItem">
    <MenuItems>
        <MenuItem Text="Back"></MenuItem>
        <MenuItem Text="Forward"></MenuItem>
        <MenuItem Text="Reload"></MenuItem>
        <MenuItem Separator="true"></MenuItem>
        <MenuItem Text="Save As..."></MenuItem>
        <MenuItem Text="Print"></MenuItem>
        <MenuItem Text="Cast"></MenuItem>
    </MenuItems>
    <MenuEvents TValue="MenuItem" ItemSelected="@SelectedHandler"></MenuEvents>
</SfContextMenu>
<SfDialog @ref="dialogObj" Content="@content" Visible="false" Target="#target" Width="200px" Height="140px">
    <DialogButtons>
        <DialogButton Content="Submit" IsPrimary="true" OnClick="@Clicked"></DialogButton>
    </DialogButtons>
</SfDialog>

@code {
    private SfDialog dialogObj;
    private string content = "This file can be saved as PDF";

    private async Task SelectedHandler(MenuEventArgs<MenuItem> e)
    {
        if (e.Item.Text == "Save As...")
            await dialogObj.ShowAsync();
    }
    private async Task Clicked(object args)
    {
        await dialogObj.HideAsync();
    }
}

<style>
    #target {
        border: 1px dashed;
        height: 150px;
        padding: 10px;
        position: relative;
        text-align: justify;
        color: gray;
        user-select: none;
    }
</style>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjrnXQCdVnBegosr?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor ContextMenu](./../images/blazor-contextmenu.webp)" %}
