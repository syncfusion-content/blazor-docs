---
layout: post
title: How to Open Dialog in Blazor Context Menu Component | Syncfusion
description: Checkout and learn about Open Dialog in Blazor Context Menu component of Syncfusion, and more details.
platform: Blazor
control: Context Menu
documentation: ug
---

# Open a dialog on Context Menu item click

This section explains about how to open a dialog on Context Menu item click. This can be achieved by handling dialog open in [`ItemSelected`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuEvents-1.html#Syncfusion_Blazor_Navigations_MenuEvents_1_ItemSelected) event of the Context Menu.

In the following sample, Dialog will open while clicking `Save As...` item.

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
<SfDialog @ref="dialogObj" Content="@content" Visible="false" Target="#target" Width="200px" Height="110px">
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
            await dialogObj.Show();
    }
    private async Task Clicked(object args)
    {
        await dialogObj.Hide();
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

Output be like
![Context Menu Sample](./../images/dialog.png)