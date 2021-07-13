---
layout: post
title: How to Position Popup in Blazor Dropdown Menu Component | Syncfusion
description: Checkout and learn about Position Popup in Blazor Dropdown Menu component of Syncfusion, and more details.
platform: Blazor
control: Dropdown Menu
documentation: ug
---

# Position Popup Open

Popup open position can be changed according to the requirement.  We have set the Popup open position using `CssClass` property as `custom` in `Top` and `Left` for the popup element.

In the following example, the `Top` position of the popup element.

```csharp

@using Syncfusion.Blazor.SplitButtons

<SfDropDownButton Content="EDIT" CssClass="custom">
    <DropDownMenuItems>
        <DropDownMenuItem Text="Cut"></DropDownMenuItem>
        <DropDownMenuItem Text="Copy"></DropDownMenuItem>
        <DropDownMenuItem Text="Paste"></DropDownMenuItem>
    </DropDownMenuItems>
</SfDropDownButton>

<style>
    .custom.e-dropdown-popup {
        margin: -122px -27px;
    }
</style>

```

Output be like

![Button Sample](./../images/ddb-position.png)