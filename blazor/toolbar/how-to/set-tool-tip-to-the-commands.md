---
layout: post
title: How to set tooltip to the commands in Blazor Toolbar | Syncfusion
description: Show tooltips on Blazor Toolbar commands by setting the TooltipText property on each ToolbarItem for helpful guidance.
platform: Blazor
control: Toolbar
documentation: ug
---

# How to set tooltip to the commands in Blazor Toolbar

The [`TooltipText`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_TooltipText) property of a Toolbar item sets the hint text that appears on mouse hover.

Initialize the Tooltip with the Blazor Toolbar as the target.

```cshtml

@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Popups

<SfTooltip ID="Tooltip" Target="#Element [title]">
    <SfToolbar ID="Element" Width="300">
        <ToolbarItems>
            <ToolbarItem Type="ItemType.Button" Text="Cut" TooltipText="Cut"></ToolbarItem>
            <ToolbarItem Type="ItemType.Button" Text="Copy" TooltipText="Copy"></ToolbarItem>
            <ToolbarItem Type="ItemType.Button" Text="Paste" TooltipText="Paste"></ToolbarItem>
            <ToolbarItem Type="ItemType.Button" Text="Undo" TooltipText="Undo"></ToolbarItem>
            <ToolbarItem Type="ItemType.Button" Text="Redo" TooltipText="Redo"></ToolbarItem>
        </ToolbarItems>
    </SfToolbar>
</SfTooltip>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNBHXwjhzcniXuMv?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Toolbar with Tooltip](../images/blazor-toolbar-with-tooltip.webp)" %}