---
layout: post
title: Icons and Navigation in Blazor Context Menu | Syncfusion®
description: Add icons to Blazor Context Menu items and configure navigation to URLs or click handlers, supporting external and in-app links.
platform: Blazor
control: Context Menu
documentation: ug
---

# Icons and Navigation in Blazor Context Menu

## Icons

The [Blazor Context Menu](https://www.syncfusion.com/blazor-components/blazor-context-menu) item has an icon/image in it to provide a visual representation of the action. To place the icon on a menu item, set the [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuItem.html#Syncfusion_Blazor_Navigations_MenuItem_IconCss) property to e-icons with the required icon CSS. By default, the icon is positioned to the left side of the menu item. In the following sample, the icons for Cut, Copy and Paste menu items are added using the `IconCss` property.

```cshtml
@using Syncfusion.Blazor.Navigations

<div id="target">Right click/Touch hold to open the ContextMenu </div>
<SfContextMenu Target="#target" TValue="MenuItem">
    <MenuItems>
        <MenuItem Text="Cut" IconCss="e-icons e-cut"></MenuItem>
        <MenuItem Text="Copy" IconCss="e-icons e-copy"></MenuItem>
        <MenuItem Text="Paste" IconCss="e-icons e-paste"></MenuItem>
    </MenuItems>
</SfContextMenu>

<style>
    #target {
        border: 1px dashed;
        height: 150px;
        padding: 10px;
        position: relative;
        text-align: justify;
        color: gray;
        user-select: none;
    }
    .e-cut::before {
        content: '\e279';
    }
    .e-copy::before {
        content: '\e280';
    }
    .e-paste::before {
        content: '\e601';
    }
</style>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZLxjniETEUzIMNB?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Context Menu with Icon](./images/blazor-contextmenu-icon.webp)" %}

N> The Context Menu provides a set of [icons](https://blazor.syncfusion.com/documentation/appearance/icons) that can be loaded by applying `e-icons` class name to the element.
You can also use third party icons on the Context Menu using the `IconCss`property.

## Navigation

Navigation in the ContextMenu is used to navigate to another web page when a menu item is clicked. This can be achieved by providing a link to the menu item using the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuItem.html#Syncfusion_Blazor_Navigations_MenuItem_Url) property. In the following sample, navigation URLs for Flipkart, Amazon, and Snapdeal menu items are added using the `Url` property.

```cshtml
@using Syncfusion.Blazor.Navigations

<div id="target">Right click/Touch hold to open the ContextMenu </div>
<SfContextMenu Target="#target" TValue="MenuItem">
    <MenuItems>
        <MenuItem Text="Flipkart" Url="https://www.flipkart.com"></MenuItem>
        <MenuItem Text="Amazon" Url="https://www.amazon.com"></MenuItem>
        <MenuItem Text="Snapdeal" Url="https://www.snapdeal.com"></MenuItem>
    </MenuItems>
</SfContextMenu>

<style>
    #target {
        border: 1px dashed;
        height: 150px;
        padding: 10px;
        position: relative;
        text-align: justify;
        color: gray;
        user-select: none;
    }
</style>

```

N> For security reasons, external domains are not supported/loaded within the preview samples.

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDVHZdskpEUcEtAV?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Navigation in Blazor Context Menu](./images/blazor-contextmenu-navigation.webp)" %}
