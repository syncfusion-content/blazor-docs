---
layout: post
title: Show/Hide Toolbar Item in Blazor Toolbar Component | Syncfusion
description: Checkout and learn here all about how to show or hide toolbar item in Syncfusion Blazor Toolbar component and more.
platform: Blazor
control: Toolbar
documentation: ug
---

# Show/Hide Toolbar Item in Blazor Toolbar Component

The `Visible` property of a Toolbar item controls its visibility by setting its value to `true` or `false`. In the following code example, the paste action is initially hidden. Clicking the 'Cut' button makes the 'Paste' button visible.

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDhSsXCXqYOTHppI?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Showing or Hiding Blazor Toolbar Items](../images/blazor-toolbar-show-or-hide-item.png)