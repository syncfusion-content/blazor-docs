---
layout: post
title: How to Hide Dropdown Arrow in Blazor Dropdown Menu Component | Syncfusion
description: Checkout and learn about Hide Dropdown Arrow in Blazor Dropdown Menu component of Syncfusion, and more details.
platform: Blazor
control: Dropdown Menu
documentation: ug
---

# Hide dropdown arrow

You can hide the dropdown arrow from the Dropdown Menu by adding class `e-caret-hide`
to Dropdown Menu element using [`CssClass`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfDropDownButton.html#Syncfusion_Blazor_SplitButtons_SfDropDownButton_CssClass)
property.

```csharp
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

Output be like

![Button Sample](./../images/ddb-hide.png)
