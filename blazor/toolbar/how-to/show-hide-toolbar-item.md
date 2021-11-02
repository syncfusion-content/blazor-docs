---
layout: post
title: Show/Hide Toolbar item in Blazor Toolbar Component | Syncfusion
description: Checkout and learn here all about how to show or hide toolbar item in Syncfusion Blazor Toolbar component and more.
platform: Blazor
control: Toolbar
documentation: ug
---

# Show/Hide Toolbar item in Blazor Toolbar Component

The `Visible` property of the Toolbar item is used to show or hide the item by setting true or false value to the property. In the following code example initially paste action will be hide. On clicking the cut button, the paste button will be show.

```csharp

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

![Showing or Hiding Blazor Toolbar Items](../images/blazor-toolbar-show-or-hide-item.png)