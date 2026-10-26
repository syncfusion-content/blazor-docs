---
layout: post
title: How to enable or disable toolbar item in Blazor Toolbar | Syncfusion
description: Enable or disable individual Blazor Toolbar items using the Disabled property of ToolbarItem for interactive control.
platform: Blazor
control: Toolbar
documentation: ug
---

# How to enable or disable toolbar item in Blazor Toolbar

The [`Disabled`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_Disabled) property of a Toolbar item enables or disables the item by setting its value to `false` or `true`, respectively. In the following code example, the paste action is initially disabled. Clicking the 'Cut' button toggles the 'Paste' button between enabled and disabled states.

```cshtml

@using Syncfusion.Blazor.Navigations

<SfToolbar>
    <ToolbarItems>
        <ToolbarItem PrefixIcon="e-icons e-cut" OnClick="@OnItemClick" Text="Cut" TooltipText="Cut"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-paste" Disabled="@ShowIcon" Text="Paste" TooltipText="Paste"></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-bold" Text="Bold" TooltipText="Bold"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-underline" Text="Underline" TooltipText="Underline"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-italic" Text="Italic" TooltipText="Italic"></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-align-left" Text="Left" TooltipText="Align-Left"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-align-right" Text="Right" TooltipText="Align-Right"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-align-center" Text="Center" TooltipText="Align-Center"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-justify" Text="Justify" TooltipText="Align-Justify"></ToolbarItem>
    </ToolbarItems>
</SfToolbar>

@code{
    public bool ShowIcon { get; set; } = true;
    public void OnItemClick()
    {
        ShowIcon = !ShowIcon;
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXVRNwtLJdOJndWb?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Enabling or Disabling Blazor Toolbar Item](../images/blazor-toolbar-disable-item.webp)" %}