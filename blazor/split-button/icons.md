---
layout: post
title: Icons And Separator in Blazor SplitButton Component | Syncfusion
description: Checkout and learn here all about icons and separator in Syncfusion Blazor SplitButton component and more.
platform: Blazor
control: Split Button
documentation: ug
---

# Icons and separator in Blazor Split Button component

## Split Button icons

[Blazor Split Button](https://www.syncfusion.com/blazor-components/blazor-split-button) can have an icon to provide the visual representation of the action. To place the icon on a Split Button, set the [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfSplitButton.html#Syncfusion_Blazor_SplitButtons_SfSplitButton_IconCss) property to `e-icons` with the required icon CSS. By default, the icon is positioned to the left side of the Split Button. The icon's position can be customized by using the [IconPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfSplitButton.html#Syncfusion_Blazor_SplitButtons_SfSplitButton_IconPosition) property.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfSplitButton Content="Paste" IconCss="e-icons e-paste">
    <DropDownMenuItems>
        <DropDownMenuItem Text="Cut"></DropDownMenuItem>
        <DropDownMenuItem Text="Copy"></DropDownMenuItem>
        <DropDownMenuItem Text="Paste"></DropDownMenuItem>
    </DropDownMenuItems>
</SfSplitButton>
<SfSplitButton Content="Paste" IconCss="e-icons e-paste" IconPosition="SplitButtonIconPosition.Top">
    <DropDownMenuItems>
        <DropDownMenuItem Text="Cut"></DropDownMenuItem>
        <DropDownMenuItem Text="Copy"></DropDownMenuItem>
        <DropDownMenuItem Text="Paste"></DropDownMenuItem>
    </DropDownMenuItems>
</SfSplitButton>

<style>
    .e-paste::before {
        content: '\e739';
    }
</style>

```

![Blazor SplitButton with Icon](./images/blazor-splitbutton-icon.png)

Third-party or custom icons can also be applied by assigning the appropriate class name to the [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfSplitButton.html#Syncfusion_Blazor_SplitButtons_SfSplitButton_IconCss) property. Ensure the corresponding icon font or stylesheet is referenced in the application.

## Vertical button

A vertical layout for the Split Button can be achieved by adding the `e-vertical` class via the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfSplitButton.html#Syncfusion_Blazor_SplitButtons_SfSplitButton_CssClass) property. This stacks the icon and text vertically within the primary button.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfSplitButton Content="Paste" IconCss="e-icons e-paste" CssClass="e-vertical">
    <DropDownMenuItems>
        <DropDownMenuItem Text="Cut" ></DropDownMenuItem>
        <DropDownMenuItem Text="Copy" ></DropDownMenuItem>
        <DropDownMenuItem Text="Paste"></DropDownMenuItem>
    </DropDownMenuItems>
</SfSplitButton>

<style>
    .e-paste::before {
        content: '\e739';
    }
</style>

```

![Blazor SplitButton in Vertical](./images/blazor-splitbutton-vertical.png)

## Separator

Separators are horizontal lines used to group items in the popup menu. Separators are non-selectable and serve only as visual dividers. Enable a separator between items by setting the [Separator](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.DropDownMenuItem.html#Syncfusion_Blazor_SplitButtons_DropDownMenuItem_Separator) property to `true` on a `DropDownMenuItem`.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfSplitButton Content="Paste" IconCss="e-icons e-paste" CssClass="e-vertical">
    <DropDownMenuItems>
        <DropDownMenuItem Text="Cut"></DropDownMenuItem>
        <DropDownMenuItem Text="Copy"></DropDownMenuItem>
        <DropDownMenuItem Separator="true"></DropDownMenuItem>
        <DropDownMenuItem Text="Paste"></DropDownMenuItem>
    </DropDownMenuItems>
</SfSplitButton>

<style>
    .e-paste::before {
        content: '\e739';
    }
</style>

```

![Blazor SplitButton with Separator](./images/blazor-splitbutton-separator.png)

## See Also

* [Split Button popup with icons](./popup-items#icons)