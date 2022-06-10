---
layout: post
title: Disable a Dropdown Menu in Blazor Dropdown Menu Component | Syncfusion
description: Checkout and learn here all about Disable a Dropdown Menu in Syncfusion Blazor Dropdown Menu component and more.
platform: Blazor
control: Dropdown Menu
documentation: ug
---

# Disable a Dropdown Menu in Blazor Dropdown Menu Component

Dropdown Menu component can be enabled/disabled by giving [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfDropDownButton.html#Syncfusion_Blazor_SplitButtons_SfDropDownButton_Disabled) property. To disable Dropdown Menu component, the disabled property can be set as `true`.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfDropDownButton Disabled="true" Content="Message">
    <DropDownMenuItems>
        <DropDownMenuItem Text="Edit"></DropDownMenuItem>
        <DropDownMenuItem Text="Delete"></DropDownMenuItem>
        <DropDownMenuItem Text="Mark as Read"></DropDownMenuItem>
        <DropDownMenuItem Text="Like Message"></DropDownMenuItem>
    </DropDownMenuItems>
</SfDropDownButton>
```


![Blazor DropDownMenu with Disable State](./../images/blazor-dropdownmenu-in-disable-state.png)