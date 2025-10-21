---
layout: post
title: Create Blazor Dropdown Menu with Rounded Corner | Syncfusion
description: Learn here all about creating Syncfusion Blazor Dropdown Menu Component with rounded corner and more.
platform: Blazor
control: Dropdown Menu
documentation: ug
---

# Create Blazor Dropdown Menu with Rounded Corner

Dropdown Menu with rounded corner can be achieved by adding the `border-radius` CSS property to button element.

In the following example, the `e-round-corner` class sets a `5px` `border-radius`, which is applied to the DropDownButton via the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfDropDownButton.html#Syncfusion_Blazor_SplitButtons_SfDropDownButton_CssClass) property. Adjust the radius value as needed to align with your design system, and apply similar styling to `.e-dropdown-popup` if you want the menu panel to share the same rounded appearance.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfDropDownButton CssClass="e-round-corner" Content="Clipboard">
    <DropDownMenuItems>
        <DropDownMenuItem Text="Edit"></DropDownMenuItem>
        <DropDownMenuItem Text="Copy"></DropDownMenuItem>
        <DropDownMenuItem Text="Paste"></DropDownMenuItem>
    </DropDownMenuItems>
</SfDropDownButton>

<style>
    .e-round-corner {
        border-radius: 5px;
    }
</style>

```

![Blazor DropDownMenu with Rounded Corner](./../images/blazor-dropdownmenu-with-rounded-corner.png)