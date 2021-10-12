---
layout: post
title: Popup Items in Blazor SplitButton Component | Syncfusion
description: Checkout and learn here all about popup items in Syncfusion Blazor SplitButton component and much more.
platform: Blazor
control: Split Button
documentation: ug
---

# Popup Items in Blazor SplitButton Component

## Icons

The Popup action item have an icon or image to provide visual representation of the action. To place the icon on a popup item, set the [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfSplitButton.html#Syncfusion_Blazor_SplitButtons_SfSplitButton_IconCss) property to `e-icons` with the required icon CSS. By default, the icon is positioned to the left side of the popup action item.

In the following sample, the icons for Cut, Copy, Paste menu items are added using the IconCss property.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfSplitButton Content="Paste" IconCss="e-icons e-paste">
    <DropDownMenuItems>
        <DropDownMenuItem IconCss="e-icons e-cut" Text="Cut"></DropDownMenuItem>
        <DropDownMenuItem IconCss="e-icons e-copy" Text="Copy"></DropDownMenuItem>
        <DropDownMenuItem IconCss="e-icons e-paste" Text="Paste"></DropDownMenuItem>
    </DropDownMenuItems>
</SfSplitButton>

<style>
    .e-paste::before {
        content: '\e739';
    }

    .e-cut::before {
        content: '\e73f';
    }

    .e-copy::before {
        content: '\e77b';
    }

</style>

```

![Blazor SplitButton Items with Icon](./images/blazor-splitbutton-item-with-icon.png)

## Template

### Item Templating

Popup items can be customized using the `CssClass` property. Customize the items using CSS style.

```cshtml

@using Syncfusion.Blazor.SplitButtons

<SfSplitButton Content="Edit" CssClass="custom">
    <DropDownMenuItems>
        <DropDownMenuItem Text="Cut"></DropDownMenuItem>
        <DropDownMenuItem Text="Copy"></DropDownMenuItem>
        <DropDownMenuItem Text="Paste"></DropDownMenuItem>
    </DropDownMenuItems>
</SfSplitButton>

<style>

    .custom li {
        float: left;
        font-size: 10px;
        padding-left: 50px;
        font-style: oblique;
    }
</style>

```

![Blazor SplitButton with Item Template](./images/blazor-splitbutton-item-template.png)