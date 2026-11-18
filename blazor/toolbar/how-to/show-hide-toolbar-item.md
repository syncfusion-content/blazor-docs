---
layout: post
title: How to show or hide toolbar item in Blazor Toolbar | Syncfusion
description: Show or hide individual Blazor Toolbar items dynamically using the Visible property of ToolbarItem at runtime.
platform: Blazor
control: Toolbar
documentation: ug
---

# How to show or hide toolbar item in Blazor Toolbar

The [`Visible`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_Visible) property of a Toolbar item controls its visibility by setting its value to `true` (visible) or `false` (hidden). In the following code example, the paste action is initially hidden. Clicking the 'Cut' button toggles the 'Paste' button between visible and hidden states.

```cshtml

@using Syncfusion.Blazor.Navigations

<SfToolbar>
    <ToolbarItems>
        <ToolbarItem PrefixIcon="e-icons e-cut" OnClick="@OnItemClick" Text="Cut" TooltipText="Cut"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-paste" Visible="@ShowItem" Text="Paste" TooltipText="Paste"></ToolbarItem>
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
    public bool ShowItem { get; set; } = false;
    public void OnItemClick()
    {
        ShowItem = !ShowItem;
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXhdZwtrpQGcBVEU?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Showing or Hiding Blazor Toolbar Items](../images/blazor-toolbar-show-or-hide-item.webp)" %}