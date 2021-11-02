---
layout: post
title: Enable/Disable Toolbar item in Blazor Toolbar Component | Syncfusion
description: Checkout and learn here all about how to enable/disable toolbar item in Syncfusion Blazor Toolbar component and more.
platform: Blazor
control: Toolbar
documentation: ug
---

# Enable/Disable Toolbar item in Blazor Toolbar Component

The `Disabled` property of the toolbar item is used to enable or disable the item by setting false or true value to the property. In the following code example initially paste action will be disabled. On clicking the cut button, the paste button will be enabled.

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


![Enabling or Disabling Blazor Toolbar Item](../images/blazor-toolbar-disable-item.gif)