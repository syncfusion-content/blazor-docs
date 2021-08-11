---
layout: post
title: Set Tooltip to the commands in Blazor Toolbar Component | Syncfusion
description: Learn here all about Set Blazor Tooltip to the commands in Syncfusion Blazor Toolbar component and more.
platform: Blazor
control: Toolbar
documentation: ug
---

# Set Tooltip to the commands in Blazor Toolbar Component

The `TooltipText` property of the Toolbar item is used to set the HTML Tooltip to the commands that can be viewed as hint texts on mouse hover.

Initialize the Tooltip with the Toolbar target. Refer to the following code example:

```csharp

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

Output be like the below.

![Tooltip](../images/toolbar_tooltip.png)