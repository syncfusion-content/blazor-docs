---
layout: post
title: Styles and Appearances in Blazor ContextMenu Component | Syncfusion®
description: Checkout and learn here all the features about Styles and Appearances in Blazor ContextMenu component and more.
platform: Blazor
control: Context Menu
documentation: ug
---

# Style and Appearance in Blazor ContextMenu Component

To modify the [Blazor ContextMenu](https://www.syncfusion.com/blazor-components/blazor-context-menu) appearance, you need to override the default CSS of the ContextMenu component. Find the list of CSS classes and its corresponding section in the ContextMenu component. You can also create your own custom theme for the controls using our [Theme Studio](https://blazor.syncfusion.com/themestudio/?theme=bootstrap5).

| CSS Class | Purpose of Class |
| ----- | ----- |
| .e-contextmenu-container .e-menu-parent | To customize the parent ContextMenu |
| .e-contextmenu-container ul .e-menu-item | To customize the ContextMenu items |
| .e-contextmenu-container ul .e-menu-item.e-focused | To customize the ContextMenu items on focus |
| .e-contextmenu-container ul .e-menu-item.e-selected .e-caret::before | To customize the selected ContextMenu caret icon |
| .e-contextmenu-container ul .e-menu-item .e-menu-icon::before | To customize the icons of the ContextMenu |

## Customizing the appearance

You can override the default CSS classes listed above to customize the ContextMenu. In the following example, the ContextMenu items are customized with a custom background, font color, and font style.

```cshtml
@using Syncfusion.Blazor.Navigations

<div id="target">Right click/Touch hold to open the ContextMenu </div>
<SfContextMenu Target="#target" TValue="MenuItem" CssClass="custom">
    <MenuItems>
        <MenuItem Text="Cut"></MenuItem>
        <MenuItem Text="Copy"></MenuItem>
        <MenuItem Text="Paste"></MenuItem>
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
    .custom.e-contextmenu-container .e-menu-parent {
        background-color: #f4f4f4;
        border: 1px solid #cccccc;
    }
    .custom.e-contextmenu-container .e-menu-item {
        color: #1a73e8;
        font-size: 14px;
        font-style: italic;
    }
    .custom.e-contextmenu-container .e-menu-item.e-focused {
        background-color: #e8f0fe;
        color: #0b57d0;
    }
</style>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjBxjlXzqfeaBsbk?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Customizing the Appearance of Blazor ContextMenu](./images/blazor-contextmenu-style-and-appearance.webp)" %}