---
layout: post
title: Position popup open in Blazor Dropdown Menu Component | Syncfusion
description: Checkout and learn here all about Position popup open in Syncfusion Blazor Dropdown Menu component and more.
platform: Blazor
control: Dropdown Menu
documentation: ug
---

# Position popup open in Blazor Dropdown Menu Component

Popup open position can be changed according to the requirement.  We have set the Popup open position using `CssClass` property as `custom` in `Top` and `Left` for the popup element.

In the following example, the `Top` position of the popup element.

```csharp

@using Syncfusion.Blazor.SplitButtons

<div style="margin: 150px auto; width: 250px;">
    <SfDropDownButton Content="EDIT" CssClass="custom">
        <DropDownMenuItems>
            <DropDownMenuItem Text="Cut"></DropDownMenuItem>
            <DropDownMenuItem Text="Copy"></DropDownMenuItem>
            <DropDownMenuItem Text="Paste"></DropDownMenuItem>
        </DropDownMenuItems>
    </SfDropDownButton>
</div>

<style>
    .custom.e-dropdown-popup {
        margin: -135px -27px;
    }
</style>

```



![Changing Popup Position in Blazor DropDownMenu](./../images/blazor-dropdownmenu-popup-position.png)
