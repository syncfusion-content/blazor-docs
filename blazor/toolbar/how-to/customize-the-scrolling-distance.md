---
layout: post
title: How to customize scrolling distance in Blazor Toolbar | Syncfusion
description: Control how far Blazor Toolbar scrolls using the ScrollStep property when navigation icons are clicked.
platform: Blazor
control: Toolbar
documentation: ug
---

# How to customize scrolling distance in Blazor Toolbar

The Toolbar's [`ScrollStep`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfToolbar.html#Syncfusion_Blazor_Navigations_SfToolbar_ScrollStep) property lets you customize the scrolling distance when the left or right navigation icons are clicked. Pass the desired value to the `ScrollStep` property to control the scroll behavior.

N> The `ScrollStep` value applies only when the Toolbar's [`OverflowMode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfToolbar.html#Syncfusion_Blazor_Navigations_SfToolbar_OverflowMode) is set to `Scrollable` (the default). The default `ScrollStep` value is `0`.

```cshtml

@using Syncfusion.Blazor.Navigations

<SfToolbar Width="600" ScrollStep="50">
    <ToolbarItems>
        <ToolbarItem PrefixIcon="e-icons e-cut" TooltipText="Cut"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-copy" TooltipText="Copy"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-paste" TooltipText="Paste"></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-bold" TooltipText="Bold"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-underline" TooltipText="Underline"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-italic" TooltipText="Italic"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-paint-bucket" TooltipText="Color-Picker"></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-align-left" TooltipText="Align-Left"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-align-right" TooltipText="Align-Right"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-align-center" TooltipText="Align-Center"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-justify" TooltipText="Align-Justify"></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-list-unordered" TooltipText="Bullets"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-list-ordered" TooltipText="Numbering"></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-sort-ascending" TooltipText="Sort A - Z"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-sort-descending" TooltipText="Sort Z - A"></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-upload-1" TooltipText="Upload"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-download" TooltipText="Download"></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-increase-indent" TooltipText="Text Indent"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-decrease-indent" TooltipText="Text Outdent"></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-erase" TooltipText="Clear"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-refresh" TooltipText="Reload"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-export" TooltipText="Export"></ToolbarItem>
    </ToolbarItems>
</SfToolbar>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjrdNwtBTddNsjxS?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Customizing Scroll Step in Blazor Toolbar](../images/blazor-toolbar-scrollstep.webp)" %}