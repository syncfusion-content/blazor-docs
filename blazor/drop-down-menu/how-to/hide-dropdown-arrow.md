---
layout: post
title: Hide dropdown arrow in Blazor Dropdown Menu Component | Syncfusion
description: Checkout and learn here all about Hide dropdown arrow in Syncfusion Blazor Dropdown Menu component and more.
platform: Blazor
control: Dropdown Menu
documentation: ug
---

# Hide Dropdown Arrow in Blazor Dropdown Menu Component

You can hide the dropdown arrow from the Dropdown Menu by adding class `e-caret-hide` to Dropdown Menu element using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfDropDownButton.html#Syncfusion_Blazor_SplitButtons_SfDropDownButton_CssClass) property.

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



![Hiding DropDown Arrow in Blazor DropDownMenu](./../images/blazor-dropdownmenu-hide-arrow.png)