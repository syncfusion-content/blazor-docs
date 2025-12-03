---
layout: post
title: Enable/Disable Toolbar Item in Blazor Toolbar Component | Syncfusion
description: Checkout and learn here all about how to enable/disable toolbar item in Syncfusion Blazor Toolbar component and more.
platform: Blazor
control: Toolbar
documentation: ug
---

# Enable/Disable Toolbar Item in Blazor Toolbar Component

The `Disabled` property of a Toolbar item enables or disables the item by setting its value to `false` or `true` respectively. In the following code example, the paste action is initially disabled. Clicking the 'Cut' button enables the 'Paste' button.

```csharp

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/VtrIMDCZUEcssLph?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Enabling or Disabling Blazor Toolbar Item](../images/blazor-toolbar-disable-item.gif)" %}