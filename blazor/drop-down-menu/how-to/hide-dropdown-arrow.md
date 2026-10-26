---
layout: post
title: How to hide the dropdown arrow in Blazor Dropdown Menu | Syncfusion®
description: Hide the Blazor Dropdown Menu caret arrow with the IconCss property or by overriding the e-caret icon CSS to create a flat menu.
platform: Blazor
control: Dropdown Menu
documentation: ug
---

# How to hide the dropdown arrow in Blazor Dropdown Menu

Hide the default dropdown caret in the Dropdown Menu by applying the built-in `e-caret-hide` CSS class through the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfDropDownButton.html#Syncfusion_Blazor_SplitButtons_SfDropDownButton_CssClass) property. This approach removes the visual indicator while preserving the button’s behavior, which is useful for icon-only buttons or custom indicators. Ensure alternate visual cues or labels are provided so users recognize the control as a dropdown.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfDropDownButton CssClass="e-caret-hide" Content="Message">
    <DropDownMenuItems>
        <DropDownMenuItem Text="Edit"></DropDownMenuItem>
        <DropDownMenuItem Text="Delete"></DropDownMenuItem>
        <DropDownMenuItem Text="Mark as Read"></DropDownMenuItem>
        <DropDownMenuItem Text="Like Message"></DropDownMenuItem>
    </DropDownMenuItems>
</SfDropDownButton>

```

![Hide the caret icon in the Blazor DropDownMenu](./../images/blazor-dropdownmenu-hide-arrow.webp)