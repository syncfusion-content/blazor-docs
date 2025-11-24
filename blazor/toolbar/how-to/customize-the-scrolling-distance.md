---
layout: post
title: Customize the Scrolling distance in Blazor Toolbar | Syncfusion
description: Learn here all about customize the scrolling distance in Syncfusion Blazor Toolbar component and more.
platform: Blazor
control: Toolbar
documentation: ug
---

# Customize the Scrolling Distance in Blazor Toolbar Component

The toolbar `ScrollStep` property supports to customize the scrolling distance, by clicking the left and right side navigation icons. A required value can be passed through the `ScrollStep` property to customize toolbar scrolling distance.

```csharp

@using Syncfusion.Blazor.Navigations

<SfToolbar Width="600" ScrollStep="50">
    <ToolbarItems>
        <ToolbarItem PrefixIcon="e-icons e-cut" Tooltiptext="Cut"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-copy" Tooltiptext="Copy"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-paste" Tooltiptext="Paste"></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-bold" Tooltiptext="Bold"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-underline" Tooltiptext="Underline"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-italic" Tooltiptext="Italic"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-paint-bucket" Tooltiptext="Color-Picker"></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-align-left" Tooltiptext="Align-Left"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-align-right" Tooltiptext="Align-Right"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-align-center" Tooltiptext="Align-Center"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-justify" Tooltiptext="Align-Justify"></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-list-unordered" Tooltiptext="Bullets"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-list-ordered" Tooltiptext="Numbering"></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-sort-ascending" Tooltiptext="Sort A - Z"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-sort-descending" Tooltiptext="Sort Z - A"></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-upload-1" Tooltiptext="Upload"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-download" Tooltiptext="Download"></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-increase-indent" Tooltiptext="Text Indent"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-decrease-indent" Tooltiptext="Text Outdent"></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-erase" Tooltiptext="Clear"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-refresh" Tooltiptext="Reload"></ToolbarItem>
        <ToolbarItem PrefixIcon="e-icons e-export" Tooltiptext="Export"></ToolbarItem>
    </ToolbarItems>
</SfToolbar>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LZryMZCNAknqZPUj?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Custominzing Scroll Step in Blazor Toolbar](../images/blazor-toolbar-scrollstep.gif)" %}